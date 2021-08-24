﻿using EscuelaWPF.Interfaces;
using EscuelaWPF.Service;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace EscuelaWPF.Core
{ 
    public class AddTeacherBoxViewModel : BaseDialogViewModel
    {
        public string NameHint { get; set; } = "Nombre";
        public string LastNameHint { get; set; } = "Apellido";
        public string PhoneNumberHint { get; set; } = "Numero de telefono";
        public string IdHint { get; set; }

        public string EditName { get; set; }
        public string EditLastName { get; set; }
        public string EditPhoneNumber { get; set; }
        public string EditId { get; set; }

        #region Commands

        public RelayCommand<ICloseable> SaveCommand { get; private set; }
        #endregion

        public AddTeacherBoxViewModel()
        {
            SaveCommand = new RelayCommand<ICloseable>(AddTeacher);
        }

        public void AddTeacher(ICloseable window)
        {
            try
            {
                Teacher temp = new();
                temp.Name = EditName;
                temp.Last_name = EditLastName;
                temp.Phone_num = EditPhoneNumber;
                temp.Id = int.Parse(EditId);
                temp.State_id = 1;
                _ = IoC.TeacherService.Post(temp);

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
