using EscuelaWPF.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EscuelaWPF.ViewModel
{
    /// <summary>
    /// View Model For a Custom flat window
    /// </summary>
    public class DialogWindowViewModel : WindowViewModel
    {

        #region Public Members

        public string Title { get; set; }

        public Control Content { get; set; }

        #endregion

        #region Constructor

        public DialogWindowViewModel(Window window) : base(window)
        {
            WindowMinimumHeight = 100;
            WindowMinimumWidth = 250;

            TitleHeight = 30;
        }

        #endregion

    }
}
