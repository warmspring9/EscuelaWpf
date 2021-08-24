using EscuelaWPF.Core;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EscuelaWPF
{
    public class BaseDialogUserControl : UserControl
    {
        #region Private Properties
        /// <summary>
        /// The dialog window we will be contained within
        /// </summary>
        private DialogWindow mDialogWindow;
        #endregion

        #region Public Properties

        public int WindowMinimumWidth { get; set; } = 250;

        public int WindowMinimumHeight { get; set; } = 100;

        public int TitleHeight { get; set; } = 30;

        public string Title { get; set; }

        #endregion

        #region Commands

        public ICommand CloseCommand { get; set; }

        #endregion

        #region Constructor
        public BaseDialogUserControl()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                mDialogWindow = new DialogWindow();
                mDialogWindow.ViewModel = new ViewModel.DialogWindowViewModel(mDialogWindow);
            }

            CloseCommand = new RelayCommand(()=> CLose());
        }

        #endregion

        public void CLose()
        {
            mDialogWindow.Close();
        }

        #region Dialog Show

        public Task ShowDialog<T>(T viewModel)
            where T: BaseDialogViewModel
        {
            var tcs = new TaskCompletionSource<bool>();

            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {

                    mDialogWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidth;
                    mDialogWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
                    mDialogWindow.ViewModel.Title = viewModel.Title ?? Title;
                    mDialogWindow.ViewModel.TitleHeight = TitleHeight;

                    mDialogWindow.ViewModel.Content = this;

                    DataContext = viewModel;

                    mDialogWindow.Owner = Application.Current.MainWindow;
                    mDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                    mDialogWindow.ShowDialog();
                }
                finally
                {
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }

        #endregion
    }
}
