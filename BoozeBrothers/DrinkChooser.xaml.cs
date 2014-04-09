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

using Microsoft.Kinect.Toolkit.Controls;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect;

namespace BoozeBrothers
{
    /// <summary>
    /// Interaction logic for DrinkChooser.xaml
    /// </summary>
    public partial class DrinkChooser : Page
    {
        private Drink _drink;

        public DrinkChooser()
        {
            InitializeComponent();
        }

        //Display the drink's information to the user
        public void viewInfo(object sender, RoutedEventArgs e)
        {
            var button = (KinectTileButton) e.OriginalSource;
            switch (button.Name)
            {
                case "drink0":
                    DrinkPopup info = new DrinkPopup(Drink.longIsland);
                    this._drink = Drink.longIsland;
                    _popupFrame.Navigate(info);
                    _popupFrame.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        //Take the user to the steps section
        public void goToSteps(object sender, RoutedEventArgs e)
        {
            StepScreen firstStep = new StepScreen(this._drink, 0);
            this.NavigationService.Navigate(firstStep);
        }
    }
}
