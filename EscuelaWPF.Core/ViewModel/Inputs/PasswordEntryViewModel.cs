using System;
using System.Security;
using System.Windows.Input;

namespace EscuelaWPF.Core
{
    public class PasswordEntryViewModel : BaseViewModel
    {
        public string Label { get; set; }

        public string EditedPassword{ get; set; }

        public string OriginalPassword { get; set; }

        public string OriginalPasswordHint { get; set; } = "Current Password";

        public string NewPasswordHint { get; set; } = "New Password";

        public string ConfirmPasswordHint { get; set; } = "Confirm Password";

        public bool IsEditing { get; set; } = false;

        public ICommand EditCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public PasswordEntryViewModel() 
        {
            CancelCommand = new RelayCommand(() => { IsEditing = false; });
            EditCommand = new RelayCommand(Edit);
        }

        public void Edit()
        {
            IsEditing = true;
        }

        internal bool isValid()
        {
            if (OriginalPasswordHint.Equals(OriginalPassword) && NewPasswordHint.Equals(ConfirmPasswordHint) && !NewPasswordHint.Equals(""))
                return true;

            return false;
        }
    }
}
