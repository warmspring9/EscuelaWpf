using EscuelaWPF.Interfaces;
using EscuelaWPF.Service;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace EscuelaWPF.Core
{ 
    public class AddStudentBoxViewModel : BaseDialogViewModel
    {
        public string NameHint { get; set; } = "Nombre";
        public string LastNameHint { get; set; } = "Apellido";
        public string PhoneNumberHint { get; set; } = "Numero de telefono";
        public string IdHint { get; set; } = "Identificacion";
        public string GuardianHint { get; set; } = "Encargado";
        public string SectionHint { get; set; } = "Seccion";
        public string DocumentHint { get; set; } = "Documento";

        public string EditName { get; set; }
        public string EditLastName { get; set; }
        public string EditPhoneNumber { get; set; }
        public string EditId { get; set; }
        public string EditGuardian { get; set; }
        public string EditSection { get; set; }
        public string ExpirationDate { get; set; }
        public string Image { get; set; }
        public string Extension { get; set; }
        public string Document { get; set; }

        #region Commands

        public RelayCommand<ICloseable> SaveCommand { get; private set; }
        #endregion

        public AddStudentBoxViewModel()
        {
            SaveCommand = new RelayCommand<ICloseable>(AddStudent);
        }

        public void AddStudent(ICloseable window)
        {
            try
            {
                Student temp = new();
                temp.Name = EditName;
                temp.Last_name = EditLastName;
                temp.Phone_num = EditPhoneNumber;
                temp.Id = int.Parse(EditId);
                temp.State_id = 1;
                temp.Guardian_id = long.Parse(EditGuardian);
                temp.Section_id = int.Parse(EditSection);
                temp.Image = Image+Extension;
                temp.Document = Document;
                temp.Expiration_date = Convert.ToDateTime(ExpirationDate);
                _ = IoC.StudentService.Post(temp);

                /*if (window != null)
                {
                    window.Close();
                }*/

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
