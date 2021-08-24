using EscuelaWPF.Core;
using System;
using System.Windows.Controls;

namespace EscuelaWPF
{
    /// <summary>
    /// Interaction logic for SideMenuControl.xaml
    /// </summary>
    public partial class SideMenuControl : UserControl
    {
        public SideMenuControl()
        {
            InitializeComponent();

            DataContext = new SideMenuViewModel();

        }

        private void Open_Settings(object sender, System.Windows.RoutedEventArgs e)
        {
            IoC.App.SettingsPageVisible = true;
        }
    }
}
