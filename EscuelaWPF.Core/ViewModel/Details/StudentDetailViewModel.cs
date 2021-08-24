using EscuelaWPF.Service;
using ServiceStack.Text;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EscuelaWPF.Core
{
    public class StudentDetailViewModel : BaseViewModel
    {

        #region Public Parameter
        public TextEntryViewModel Name { get; set; }

        public TextEntryViewModel Id { get; set; }

        public TextEntryViewModel LastName { get; set; }

        public PhoneNumberEntryViewModel PhoneNumber { get; set; }

        public string Document { get; set; }
        public DateTime Expiration_date { get; set; }

        public GuardianEntryViewModel Guardian { get; set; }

        public SectionEntryViewModel Section { get; set; }

        public bool IsEditing { get; set; } = false;

        public string Image { get; set; }

        public string EditBtn { get; set; }

        public string Extension { get; set; }

        public ObservableCollection<MenuItemViewModel> Items { get; set; }

        public int State_id { get; set; }
        #endregion

        #region Commands

        public ICommand SaveCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand EditImage { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand AddAuthorization { get; set; }

        public ICommand AddAttendance { get; set; }
        
        public ICommand DownloadCommand { get; set; }

        public ICommand DownloadDocummentCommand { get; set; }

        #endregion

        #region Constructor
        public StudentDetailViewModel() { }

        public StudentDetailViewModel(Student student)
        {
            State_id = student.State_id;
            EditBtn = "Editar";
            IsEditing = false;
            Name = new TextEntryViewModel()
            {
                OriginalText = student.Name,
                EditedText = student.Name,
                IsEditing = true,
                Label = "Nombre"
            };
            LastName = new TextEntryViewModel()
            {
                OriginalText = student.Last_name,
                EditedText = student.Last_name,
                IsEditing = true,
                Label = "Apellido"
            };
            Id = new TextEntryViewModel()
            {
                OriginalText = student.Id.ToString(),
                EditedText = student.Id.ToString(),
                IsEditing = true,
                Label = "Id"
            };
            PhoneNumber = new PhoneNumberEntryViewModel()
            {
                OriginalText = student.Phone_num,
                EditedText = student.Phone_num,
                IsEditing = true,
                Label = "Telefono"
            };
            Guardian = new GuardianEntryViewModel()
            {
                OriginalText = student.Guardian_id.ToString(),
                EditedText = student.Guardian_id.ToString(),
                IsEditing = true,
                Label = "Encargado"
            };
            Section = new SectionEntryViewModel()
            {
                OriginalText = student.Section_id.ToString(),
                EditedText = student.Section_id.ToString(),
                IsEditing = true,
                Label = "Seccion"
            };
            Section.setName();
            Guardian.setName();
            Image = ConditionImage(student.Image);
            Document = student.Document;
            Expiration_date = student.Expiration_date;

            SaveCommand = new RelayCommand(SaveAsync);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
            AddAuthorization = new RelayCommand(AddAuth);
            AddAttendance = new RelayCommand(AddAtt);
            DownloadCommand = new RelayCommand(downCSV);
            DownloadDocummentCommand = new RelayCommand(downDoc);

            Items = new ObservableCollection<MenuItemViewModel>();
            List<Guardian> temp = IoC.StudentService.GetGuardians(student.Id).Result;
            foreach (Guardian guardian in temp)
            {
                Items.Add(new MenuItemViewModel()
                {
                    Name = guardian.Name,
                    Id = guardian.Id.ToString(),
                    Initials = guardian.Name.Substring(0, 1) + guardian.Last_name.Substring(0, 1),
                    ProfilePictureRGB = "60f411",
                    Type = MenuElementObjectType.Guardian,
                    Info = guardian
                });

            }
        }

        private void downDoc()
        {
            string downloadPath = new KnownFolder(KnownFolderType.Downloads).Path;
            String doc = Document.Remove(Document.Length - 5, 5); ;
            byte[] bytes = Convert.FromBase64String(doc);

            System.IO.FileStream stream =
                            new FileStream(downloadPath + "\\" + Id.OriginalText + ".pdf", FileMode.CreateNew);
            System.IO.BinaryWriter writer =
                new BinaryWriter(stream);
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();
        }

        private void downCSV()
        {

            List<Attendance> temp = IoC.AttendanceService.GetAllAsync().Result;
            List<AttendanceEntries> entriers = new List<AttendanceEntries>();
            foreach (Attendance att in temp)
            {
                entriers.Add(new AttendanceEntries
                {
                    Descripcion = att.description,
                    Hora_Entrada = att.entrance_time,
                    Hora_Salida = att.exit_time,
                    Nombre_Estudiante = IoC.StudentService.GetbyId(att.student_id.ToString()).Result.Name,
                    Nombre_Guardian = IoC.GuardianService.GetbyId(att.guardian_id.ToString()).Result.Name
                });
            }

            CSVHelper helper = new CSVHelper();
            helper.ToCSV(entriers, Id.OriginalText);

            IoC.UI.ShowMesssage(new MessageBoxViewModel
            {
                Title = "Descarga Exitosa!!",
                Message = "Se descargo la asistencia del estudiante exitosamente en la carpeta de descargas",
                OkText = "Continuar"
            });
        }

        private void AddAtt()
        {
            IoC.UI.ShowAddAttendanceModal(new AddAttendanceBoxViewModel
            {
            });
        }

        private void AddAuth()
        {
            IoC.UI.ShowAddAuthModal(new AddAuthorizationBoxViewModel
            {
                Student_Id = Id.OriginalText
            });
        }

        private void Delete()
        {
            IoC.StudentService.Delete(Id.OriginalText);
        }
        private string ConditionImage(string image)
        {
            //Condition the image that comes here
            if(image == null)
            {
                return null;
            }
            Extension = image.Remove(0,image.Length-5);
            return image.Remove(image.Length - 5, 5);
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
            LastName.IsEditing = !LastName.IsEditing;
            PhoneNumber.IsEditing = !PhoneNumber.IsEditing;
            Guardian.IsEditing = !Guardian.IsEditing;
            Section.IsEditing = !Section.IsEditing;

        }

        private async void SaveAsync()
        {
            if (PhoneNumber.IsValid() && Guardian.IsValid() && Section.IsValid())
            {
                
                IsEditing = false;
                EditBtn = "Edit";
                Student temp = new();
                temp.Name = Name.OriginalText = Name.EditedText;
                temp.Last_name = LastName.OriginalText = LastName.EditedText;
                temp.Id = (long)Convert.ToDouble(Id.OriginalText);
                temp.Phone_num = PhoneNumber.OriginalText = PhoneNumber.EditedText;
                temp.Image = Image+Extension;
                temp.Document = Document;
                temp.Expiration_date = Expiration_date;
                temp.Section_id = (int)Convert.ToDouble(Section.EditedText);
                temp.Guardian_id = (long)Convert.ToDouble(Guardian.EditedText);
                temp.State_id = State_id;
                //Service put a student;
                try
                {
                    IoC.StudentService.Put(temp);
                    await IoC.UI.ShowMesssage(new MessageBoxViewModel
                    {
                        Title = "Exito!",
                        Message = "Se actualizo el estudiante con exito",
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
                    Message = "El numero de telefono no es valido",
                    OkText = "Continuar"
                });
            }
            
        }
        private void Reset()
        {
            Name.EditedText = Name.OriginalText;
            LastName.EditedText = LastName.OriginalText;
            Id.EditedText = Id.OriginalText;
            PhoneNumber.EditedText = PhoneNumber.OriginalText;
        }
    }
}
