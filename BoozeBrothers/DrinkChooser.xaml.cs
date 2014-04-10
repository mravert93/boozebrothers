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
using Microsoft.Speech.AudioFormat;
using Microsoft.Speech.Recognition;

namespace BoozeBrothers
{
    /// <summary>
    /// Interaction logic for DrinkChooser.xaml
    /// </summary>
    public partial class DrinkChooser : Page
    {
        private Drink _drink;
        private SpeechRecognitionEngine speechEngine;

        public DrinkChooser()
        {
            InitializeComponent();
        }

        //Display the drink's information to the user
        public void viewInfo(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is KinectCircleButton)
            {
                goToSteps(sender, e);
            }
            else
            {

                var button = (KinectTileButton)e.OriginalSource;
                switch (button.Name)
                {
                    case "drink0":
                        DrinkPopup info = new DrinkPopup(Drink.longIsland);
                        this._drink = Drink.longIsland;
                        this._stepsButton.Visibility = Visibility.Visible;
                        _popupFrame.Navigate(info);
                        _popupFrame.Visibility = Visibility.Visible;
                        break;
                    default:
                        break;
                }
            }
        }

        //Take the user to the steps section
        public void goToSteps(object sender, RoutedEventArgs e)
        {
            StepScreen firstStep = new StepScreen(this._drink, 0);
            this.NavigationService.Navigate(firstStep);
        }

        #region Speech Recognition

        //get the metadata for the speech recognizer
        private static RecognizerInfo GetKinectRecognizer()
        {
            foreach (RecognizerInfo recognizer in SpeechRecognitionEngine.InstalledRecognizers())
            {
                string value;
                recognizer.AdditionalInfo.TryGetValue("Kinect", out value);
                if ("True".Equals(value, StringComparison.OrdinalIgnoreCase) && "en-US".Equals(recognizer.Culture.Name,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return recognizer;
                }
            }

            return null;
        }

        //When the window loads up, load up the speech recognizer
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            RecognizerInfo ri = GetKinectRecognizer();

            if (ri != null)
            {
                this.speechEngine = new SpeechRecognitionEngine(ri.Id);

                //Creating the grammar for the speech to recognize
                var help = new Choices();
                help.Add(new SemanticResultValue("help", "HELP"));
                help.Add(new SemanticResultValue("clear", "CLEAR"));

                var gb = new GrammarBuilder { Culture = ri.Culture };
                gb.Append(help);

                var g = new Grammar(gb);

                speechEngine.SpeechRecognized += speechEngine_SpeechRecognized;
                speechEngine.SpeechRecognitionRejected += speechEngine_SpeechRecognitionRejected;
            }
        }

        void speechEngine_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void speechEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //Speech utter confidence in which speech is treated as if its heard or not
            const double ConfidenceThreshold = 0.3;

             if (e.Result.Confidence >= ConfidenceThreshold)
            {
                switch (e.Result.Semantics.Value.ToString())
                {
                    case "HELP":
                        this.Test.Visibility = Visibility.Visible;
                        break;
                    case "CLEAR":
                        this.Test.Visibility = Visibility.Hidden;
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}
