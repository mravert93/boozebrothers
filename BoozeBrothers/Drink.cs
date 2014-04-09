using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeBrothers
{
    public class Drink : INotifyPropertyChanged
    {
        private String name;
        private String description;
        private List<String> ingredients;
        private int rating;
        private String icon;
        private List<Step> steps;

        #region Dependency Definitions


        public string titleProperty
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("titleProperty");
            }
        }

        public List<String> ingredProperty
        {
            get { return ingredients; }
            set
            {
                ingredients = value;
                OnPropertyChanged("ingredProperty");
            }
        }

        public string descProperty
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("descProperty");
            }
        }

        public int ratingProperty
        {
            get { return rating; }
            set
            {
                rating = Convert.ToInt32(value);
                OnPropertyChanged("ratingProperty");
            }
        }

        public String iconProperty
        {
            get { return icon; }
            set
            {
                icon = value;
                OnPropertyChanged("iconProperty");
            }
        }

        public List<Step> stepsProperty
        {
            get { return steps; }
            set
            {
                steps = value;
            }
        }

        #endregion

        #region Constructor

        Drink(String name, String desc, List<String> ingred, int rating, String icon, List<Step> steps)
        {
            this.titleProperty = name;
            this.descProperty = desc;
            this.ingredProperty = ingred;
            this.ratingProperty = rating;
            this.iconProperty = icon;
            this.stepsProperty = steps;
        }

        #endregion

        #region Drink Definitons

        public static Drink longIsland = new Drink(
            "Long Island Iced Tea", "It's from long island so you know it'll fuck you up!",
            new List<String>(new String[] { "Ice", "Vodka", "Rum", "Tequila", "Mixer" }), 4, "",
            new List<Step>(
                new Step[] {
                    new Step("Pour Ice", "Pour ice into mixer", "", 
                        new List<String>(new String[] {"Ice", "Mixer"})),
                        new Step("Mix Alcohol", "Pour all of the alcohol into mixer", "",
                            new List<string>(new String[] {"Mixer", "Vodka", "Rum", "Tequila"}))}));


        #endregion

        #region IPropertyChange

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
