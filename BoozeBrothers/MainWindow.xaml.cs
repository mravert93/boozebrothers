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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// /Kinect Sensor Chooser
        /// </summary>
        private readonly KinectSensorChooser senserChooser;

        public MainWindow()
        {
            InitializeComponent();

            this.senserChooser = new KinectSensorChooser();
            this.senserChooser.KinectChanged += SensorChooserOnKinectChanged;
            this.sensorChooserUI.KinectSensorChooser = this.senserChooser;
            this.senserChooser.Start();

            var regionSensorBinding = new Binding("Kinect") { Source = this.senserChooser };
            BindingOperations.SetBinding(this.kinectRegion, KinectRegion.KinectSensorProperty, regionSensorBinding);

            _mainWindow.Navigate(new StartMenu());
        }

        //Called when the kinect finds a new sensor
        public static void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
        {
            if (args.OldSensor != null)
            {
                try
                {
                    args.OldSensor.DepthStream.Range = DepthRange.Default;
                    args.OldSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    args.OldSensor.DepthStream.Disable();
                    args.OldSensor.SkeletonStream.Disable();
                }
                catch (InvalidOperationException)
                {

                    //Log it or something
                }
            }

            if (args.NewSensor != null)
            {
                try
                {
                    args.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    args.NewSensor.SkeletonStream.Enable();

                    try
                    {
                        args.NewSensor.DepthStream.Range = DepthRange.Near;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;
                    }
                    catch (InvalidOperationException)
                    {
                        //None kinect for windows do not support new mode
                        args.NewSensor.DepthStream.Range = DepthRange.Default;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    }
                }
                catch (InvalidOperationException)
                {
                    //I dont know do something about this like plug it in you fuck
                }
            }
        }

        //Executes shutdown tasks
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.senserChooser.Stop();
        }
    }
}
