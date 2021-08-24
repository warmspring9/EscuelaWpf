using EscuelaWPF.Interfaces;
using EscuelaWPF.Service;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace EscuelaWPF.Core
{ 
    public class AddAuthorizationBoxViewModel : BaseDialogViewModel
    {
        public string Guardian_Hint { get; set; } = "Identificacion de Guardian";

        public string Start_Time { get; set; } = "Hora de Inicio";

        public string End_Time { get; set; } = "Hora de Fin";
        public string Guardian_id { get; set; }
        public String EditStartTime { get; set; }

        public String EditEndTime { get; set; }

        public string Student_Id { get; set; }

        #region Commands

        public RelayCommand<ICloseable> SaveCommand { get; private set; }
        #endregion

        public AddAuthorizationBoxViewModel()
        {
            SaveCommand = new RelayCommand<ICloseable>(AddAccess);
        }

        public void AddAccess(ICloseable window)
        {
            Authorization temp = new();
            temp.Guardian_id = Guardian_id;
            temp.Student_id = Student_Id;
            temp.State_id = 1;
            temp.Start_time = Convert.ToDateTime(EditStartTime);
            if (EditEndTime != null)
            {
                temp.End_time = Convert.ToDateTime(EditEndTime);
                if (temp.Start_time >= temp.End_time)
                {
                    IoC.UI.ShowMesssage(new MessageBoxViewModel
                    {
                        Title = "Oops",
                        Message = "Por favor definir un rango de tiempo valido",
                        OkText = "Continuar"
                    });
                    return;

                }

                try
                {
                    _ = IoC.AuthorizationService.Post(temp);

                    if (window != null)
                    {
                        window.Close();
                    }

                }
                catch
                {
                    IoC.UI.ShowMesssage(new MessageBoxViewModel
                    {
                        Title = "Oops",
                        Message = "Por favor revisar los datos suministrados",
                        OkText = "Continuar"
                    });
                }
            } else
            {
                IoC.UI.ShowMesssage(new MessageBoxViewModel
                {
                    Title = "Oops",
                    Message = "Por favor definir un tiempo de fin",
                    OkText = "Continuar"
                });
                return;
            }
           
        }
    }
}
