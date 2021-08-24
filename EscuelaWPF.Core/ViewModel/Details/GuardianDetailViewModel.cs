using EscuelaWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EscuelaWPF.Core
{
    public class GuardianDetailViewModel : BaseViewModel
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

        public TextEntryViewModel LastName { get; set; }

        public PhoneNumberEntryViewModel PhoneNumber { get; set; }

        public bool IsEditing { get; set; } = false;

        public string Image { get; set; }

        public string EditBtn { get; set; }

        public string Extension { get; set; }
        #endregion

        #region Commands

        public ICommand SaveCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand EditImage { get; set; }

        public ICommand DeleteCommand { get; set; }

        #endregion

        #region Constructor
        public GuardianDetailViewModel() { }

        public GuardianDetailViewModel(Guardian guardian)
        {
            EditBtn = "Editar";
            IsEditing = false;
            Name = new TextEntryViewModel()
            {
                OriginalText = guardian.Name,
                EditedText = guardian.Name,
                IsEditing = true,
                Label = "Nombre"
            };
            LastName = new TextEntryViewModel()
            {
                OriginalText = guardian.Last_name,
                EditedText = guardian.Last_name,
                IsEditing = true,
                Label = "Apellido"
            };
            Id = new TextEntryViewModel()
            {
                OriginalText = guardian.Id.ToString(),
                EditedText = guardian.Id.ToString(),
                IsEditing = true,
                Label = "Id"
            };
            PhoneNumber = new PhoneNumberEntryViewModel()
            {
                OriginalText = guardian.Phone_num,
                EditedText = guardian.Phone_num,
                IsEditing = true,
                Label = "Telefono"
            };
            Image = ConditionImage(guardian.Image);

            SaveCommand = new RelayCommand(SaveAsync);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
        }


        private void Delete()
        {
            IoC.GuardianService.Delete(Id.OriginalText);
        }
        private string ConditionImage(string image)
        {
            //Condition the image that comes here
            if(image == null)
            {
                return null;
            }
            Extension = image.Remove(0,image.Length-5);
            return image.Remove(image.Length - 5, 5); ;
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

        }

        private async void SaveAsync()
        {
            if (PhoneNumber.IsValid())
            {
                
                IsEditing = false;
                EditBtn = "Edit";
                Guardian temp = new();
                temp.Name = Name.OriginalText = Name.EditedText;
                temp.Last_name = LastName.OriginalText = LastName.EditedText;
                temp.Id = (long)Convert.ToDouble(Id.OriginalText);
                temp.Phone_num = PhoneNumber.OriginalText = PhoneNumber.EditedText;
                temp.Image = Image+Extension;
                //Service put a teacher;
                try
                {
                    IoC.GuardianService.Put(temp);
                    await IoC.UI.ShowMesssage(new MessageBoxViewModel
                    {
                        Title = "Exito!",
                        Message = "Se actualizo el guardian con exito",
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
