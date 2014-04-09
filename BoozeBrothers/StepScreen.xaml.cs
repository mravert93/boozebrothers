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
    /// Interaction logic for StepScreen.xaml
    /// </summary>
    public partial class StepScreen : Page
    {
        private Step _curStep;
        private Drink _drink;
        private int _curIndex;

        public StepScreen(Drink drink, int currentStep)
        {
            InitializeComponent();

            List<Step> steps = drink.stepsProperty;
            if (currentStep >= steps.Count)
            {
                //Goto Congrats
            }

            _curStep = steps.ElementAt(currentStep);
            _drink = drink;
            _curIndex = currentStep;

            stepTitle.SetBinding(TextBlock.TextProperty, new Binding("titleProperty")
            {
                Source = _curStep,
                Mode = BindingMode.TwoWay
            });

            stepsIngred.SetBinding(TextBlock.TextProperty, new Binding("ingredProperty")
            {
                Source = _curStep,
                Mode = BindingMode.TwoWay
            });

            stepsDesc.SetBinding(TextBlock.TextProperty, new Binding("descProperty")
            {
                Source = _curStep,
                Mode = BindingMode.TwoWay
            });
        }

        //Takes the user to the next step or completion page if there are no more steps
        public void goToNextStep(object sender, RoutedEventArgs e)
        {
            _curIndex++;
            StepScreen nextStep = new StepScreen(this._drink, _curIndex);
            this.NavigationService.Navigate(nextStep);
        }
    }
}
