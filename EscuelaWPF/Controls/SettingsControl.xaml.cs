using EscuelaWPF.Core;
using EscuelaWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace EscuelaWPF
{
    /// <summary>
    /// Interaction logic for SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();

            DataContext = IoC.Settings;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Access temp = (Access)btn.Content;
            IoC.Settings.SetContent(temp);
        }
    }
}
