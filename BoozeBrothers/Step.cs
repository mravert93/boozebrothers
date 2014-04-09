using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeBrothers
{
    public class Step
    {
        private List<String> inged;
        private String desc;
        private String title;
        private String pic;

        #region Properties

        public List<String> ingredProperty
        {
            get { return inged; }
            set { inged = value; }
        }

        public String descProperty
        {
            get { return desc; }
            set { desc = value; }
        }

        public String titleProperty
        {
            get { return title; }
            set { title = value; }
        }

        public String picProperty
        {
            get { return pic; }
            set { pic = value; }
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

    }
}
