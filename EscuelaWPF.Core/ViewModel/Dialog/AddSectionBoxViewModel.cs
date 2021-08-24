using EscuelaWPF.Interfaces;
using EscuelaWPF.Service;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace EscuelaWPF.Core
{ 
    public class AddSectionBoxViewModel : BaseDialogViewModel
    {
        public string NameHint { get; set; } = "Nombre";
        public string EndTimeHint { get; set; } = "Fecha de Fin";
        public string TeacherHint { get; set; } = "Identificacion del Profesor";
        public string IdHint { get; set; }

        public string EditName { get; set; }
        public DateTime EditEndTime { get; set; }
        public string EditTeacher { get; set; }
        public string EditId { get; set; }

        #region Commands

        public RelayCommand<ICloseable> SaveCommand { get; private set; }
        #endregion

        public AddSectionBoxViewModel()
        {
            SaveCommand = new RelayCommand<ICloseable>(AddTeacher);
        }

        public void AddTeacher(ICloseable window)
        {
            try
            {
                Section temp = new();
                temp.Name = EditName;
                temp.Exit_time = EditEndTime;
                temp.Teacher_id = (long)Convert.ToDouble(EditTeacher);
                temp.State_id = 1;
                _ = IoC.SectionService.Post(temp);

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
