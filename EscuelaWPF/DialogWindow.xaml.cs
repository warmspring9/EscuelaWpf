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
    public partial class DialogWindow : Window
    {
        #region Private Members

        private DialogWindowViewModel mViewModel;

        #endregion

        #region Public Properties

        public DialogWindowViewModel ViewModel
        {
            get => mViewModel;
            set
            {
                mViewModel = value;

                DataContext = mViewModel;
            }
        }

        #endregion

        public DialogWindow()
        {
            InitializeComponent();
        }
    }
}
