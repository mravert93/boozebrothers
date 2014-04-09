using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeBrothers
{
    public class Step : INotifyPropertyChanged
    {
        private List<String> inged;
        private String desc;
        private String title;
        private String pic;

        #region Properties

        public List<String> ingredProperty
        {
            get { return inged; }
            set 
            { 
                inged = value;
                OnPropertyChanged("ingredProperty");
            }
        }

        public String descProperty
        {
            get { return desc; }
            set 
            { 
                desc = value;
                OnPropertyChanged("descProperty");
            }
        }

        public String titleProperty
        {
            get { return title; }
            set 
            {
                title = value;
                OnPropertyChanged("titleProperty");
            }
        }

        public String picProperty
        {
            get { return pic; }
            set 
            {
                pic = value;
                OnPropertyChanged("picProperty");
            }
        }

        #endregion

        #region Constructor

        public Step(String title, String desc, String pic, List<String> ingred)
        {
            this.title = title;
            this.desc = desc;
            this.pic = pic;
            this.inged = ingred;
        }

        #endregion

        #region Notify Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
