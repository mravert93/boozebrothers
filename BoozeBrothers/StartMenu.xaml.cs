﻿using System;
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
    /// Interaction logic for StartMenu.xaml
    /// </summary>
    public partial class StartMenu : Page
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        public void goToChooseDrink(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DrinkChooser.xaml", UriKind.Relative));
        }
    }
}
