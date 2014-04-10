using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;

namespace BoozeBrothers
{
    /// <summary>
    /// Interaction logic for Congrats.xaml
    /// </summary>
    public partial class Congrats : Page
    {
        Drink _drink;

        public Congrats(Drink drink)
        {
            this._drink = drink;

            InitializeComponent();
        }

        //Takes the user back to the start menu
        public void goHome(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StartMenu());
        }

        //Changes the rating of the drink and then brings the user to the start screen
        public void rateDrink(object sender, RoutedEventArgs e)
        {
            KinectCircleButton button = (KinectCircleButton)e.OriginalSource;
            String rating = button.Name.ToString();

            switch (rating)
            {
                case "star1":
                    this._drink.ratingProperty = 1;
                    goHome(sender, e);
                    break;
                case "star2":
                    this._drink.ratingProperty = 2;
                    goHome(sender, e);
                    break;
                case "star3":
                    this._drink.ratingProperty = 3;
                    goHome(sender, e);
                    break;
                case "star4":
                    this._drink.ratingProperty = 4;
                    goHome(sender, e);
                    break;
                case "star5":
                    this._drink.ratingProperty = 5;
                    goHome(sender, e);
                    break;
                default:
                    break;
            }
        }
    }
}
