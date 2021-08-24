using EscuelaWPF.Core;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace EscuelaWPF
{
    /// <summary>
    /// Interaction logic for MenuItemControl.xaml
    /// </summary>
    public partial class DeletableMenuItemControl : UserControl
    {
        public DeletableMenuItemControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var btn = (Button)sender;
            String id = (string)btn.Tag;
            _ = IoC.AuthorizationService.Delete(id);
        }
    }
}
