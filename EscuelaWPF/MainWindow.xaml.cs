using EscuelaWPF.Core;
using EscuelaWPF.ViewModel;
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

namespace EscuelaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new WindowViewModel(this);
        }

        private void AppWindow_Deactivated(object sender, EventArgs e)
        {
            (DataContext as WindowViewModel).DimmedOverlayVisible = true;
        }

        private void AppWindow_Activated(object sender, EventArgs e)
        {
            (DataContext as WindowViewModel).DimmedOverlayVisible = false;
        }
    }
}
