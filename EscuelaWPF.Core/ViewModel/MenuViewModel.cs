using System;
using System.Windows.Input;

namespace EscuelaWPF.Core
{
    public class MenuViewModel : BaseViewModel
    {

        #region Public Properties
        /// <summary>
        /// Boolean if the attachment menu is visible
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }


        /// <summary>
        /// View Model For the attachment menu
        /// </summary>
        public AddGroupModalViewModel AddGroupMd { get; set; }

        #endregion


        #region Public Commands

        /// <summary>
        /// Command for when the attachment button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }
        public ICommand SendCommand { get; set; }

        #endregion
        #region Constructor

        public MenuViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);

            AddGroupMd = new AddGroupModalViewModel();

            SendCommand = new RelayCommand(Send);
        }

        private async void Send()
        {
            await IoC.UI.ShowMesssage(new MessageBoxViewModel
            {
                Title = "Message Title",
                Message = "Custom ui message",
                OkText = "OK"
            });

        }
        #endregion

        #region Command Methods

        public void AttachmentButton()
        {
            AttachmentMenuVisible ^= true;
        }

        #endregion
    }
}
