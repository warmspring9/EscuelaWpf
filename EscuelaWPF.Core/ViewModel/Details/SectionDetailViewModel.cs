using EscuelaWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EscuelaWPF.Core
{
    public class SectionDetailViewModel : BaseViewModel
    {

        /* 
        "id": 888888888,
        "name": "B",
        "last_name": "C",
        "phone_num": "88888888",
        "state_id": 1 
        */
        #region Public Parameter
        public TextEntryViewModel Name { get; set; }

        public TextEntryViewModel Id { get; set; }

        public DateEntryViewModel ExitTime { get; set; }

        public TeacherEntryViewModel Teacher { get; set; }

        public bool IsEditing { get; set; } = false;

        public string Image { get; set; }

        public string EditBtn { get; set; }

        public string Extension { get; set; }
        public DateTime Created { get; set; }
        #endregion

        #region Commands

        public ICommand SaveCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand EditImage { get; set; }

        public ICommand DeleteCommand { get; set; }

        #endregion

        #region Constructor
        public SectionDetailViewModel() { }

        public SectionDetailViewModel(Section section)
        {
            EditBtn = "Editar";
            IsEditing = false;
            Name = new TextEntryViewModel()
            {
                OriginalText = section.Name,
                EditedText = section.Name,
                IsEditing = true,
                Label = "Nombre"
            };
            Id = new TextEntryViewModel()
            {
                OriginalText = section.Id.ToString(),
                EditedText = section.Id.ToString(),
                IsEditing = true,
                Label = "Id"
            };
            ExitTime = new DateEntryViewModel()
            {
                OriginalText = section.Exit_time,
                EditedText = section.Exit_time,
                IsEditing = true,
                Label = "Salida"
            };
            Teacher = new TeacherEntryViewModel()
            {
                OriginalText = section.Teacher_id.ToString(),
                EditedText = section.Teacher_id.ToString(),
                IsEditing = true,
                Label = "Profesor"
            };
            Created = section.Created;
            Teacher.setName();

            SaveCommand = new RelayCommand(SaveAsync);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
        }


        private void Delete()
        {
            IoC.SectionService.Delete(Id.OriginalText);
        }
        #endregion

        private void Edit()
        {
            if (!IsEditing)
            {
                EditBtn = "Cancelar";
                IsEditing = true;

            }
            else
            {
                EditBtn = "Editar";
                IsEditing = false;
                Reset();
            }
            Name.IsEditing = !Name.IsEditing;
            ExitTime.IsEditing = !ExitTime.IsEditing;
            Teacher.IsEditing = !Teacher.IsEditing;

        }

        private async void SaveAsync()
        {
            if (Teacher.IsValid())
            {
                
                IsEditing = false;
                EditBtn = "Edit";
                Section temp = new();
                temp.Name = Name.OriginalText = Name.EditedText;
                temp.Id = Id.OriginalText;
                temp.Exit_time = ExitTime.OriginalText = ExitTime.EditedText;
                temp.State_id = 1;
                temp.Created = Created;
                Teacher.OriginalText = Teacher.EditedText;
                temp.Teacher_id = (long)Convert.ToDouble(Teacher.EditedText);
                //Service put a teacher;
                try
                {
                    IoC.SectionService.Put(temp);
                    await IoC.UI.ShowMesssage(new MessageBoxViewModel
                    {
                        Title = "Exito!",
                        Message = "Se actualizo la seccion con exito",
                        OkText = "OK"
                    });
                    Edit();
                }
                catch
                {
                    await IoC.UI.ShowMesssage(new MessageBoxViewModel
                    {
                        Title = "Oops",
                        Message = "Algo salio mal en el servidor",
                        OkText = "Continuar"
                    });
                    IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login, new LoginViewModel());
                    IoC.App.SideMenuVisible = false;
                }
            }
            else
            {
                await IoC.UI.ShowMesssage(new MessageBoxViewModel
                {
                    Title = "Oops",
                    Message = "El profesor no es valido",
                    OkText = "Continuar"
                });
            }
            
        }
        private void Reset()
        {
            Name.EditedText = Name.OriginalText;
            ExitTime.EditedText = ExitTime.OriginalText;
            Id.EditedText = Id.OriginalText;
            Teacher.EditedText = Teacher.OriginalText;
        }
    }
}
