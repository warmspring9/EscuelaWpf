using EscuelaWPF.Interfaces;
using EscuelaWPF.Service;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace EscuelaWPF.Core
{ 
    public class AddAttendanceBoxViewModel : BaseDialogViewModel
    {
        public string UsernameHint { get; set; } = "Identificacion del Estudiante";
        public string PasswordHint { get; set; } = "Identificacion del guaridan";

        public string EditUsername { get; set; }
        public string EditPassword { get; set; }

        #region Commands

        public RelayCommand<ICloseable> SaveCommand { get; private set; }
        #endregion

        public AddAttendanceBoxViewModel()
        {
            SaveCommand = new RelayCommand<ICloseable>(AddAccess);
        }

        public void AddAccess(ICloseable window)
        {
            try
            {
                Access temp = new();
                temp.Username = EditUsername;
                temp.Password = EditPassword;
                temp.State_id = 1;
                _ = IoC.AccessService.Post(temp);

                if (window != null)
                {
                    window.Close();
                }

            } catch
            {
                IoC.UI.ShowMesssage(new MessageBoxViewModel
                {
                    Title = "Oops",
                    Message = "Por favor revisar los datos suministrados",
                    OkText = "Continuar"
                });
            }
            
        }
    }
}
