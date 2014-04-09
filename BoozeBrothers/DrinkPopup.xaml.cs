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

namespace BoozeBrothers
{
    /// <summary>
    /// Interaction logic for DrinkPopup.xaml
    /// </summary>
    public partial class DrinkPopup : Page
    {
        private Drink _drink;

        public DrinkPopup(Drink drink)
        {
            InitializeComponent();
            _drink = drink;

            //Set Dependencies
            Title.SetBinding(TextBox.TextProperty, new Binding("titleProperty")
            {
                Source = _drink,
                Mode = BindingMode.TwoWay
            });

            Ingredients.SetBinding(TextBox.TextProperty, new Binding("ingredProperty")
            {
                Source = _drink,
                Mode = BindingMode.TwoWay,
                Converter = new ListToStringConverter()
            });

            Description.SetBinding(TextBox.TextProperty, new Binding("descProperty")
            {
                Source = _drink,
                Mode = BindingMode.TwoWay
            });

            Rating.SetBinding(TextBox.TextProperty, new Binding("ratingProperty")
            {
                Source = _drink,
                Mode = BindingMode.TwoWay
            });

        }

        //Take the user to the steps section
        public void goToSteps(object sender, RoutedEventArgs e)
        {

        }
    }
}
