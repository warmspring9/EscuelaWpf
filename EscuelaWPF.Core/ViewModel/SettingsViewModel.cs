using EscuelaWPF.Core;
using EscuelaWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EscuelaWPF.Core
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Commands

        public ICommand CloseCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand RefreshCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand AddCommand { get; set; }

        #endregion

        #region Public Properties

        public Access CurrentAccess { get; set; }

        public TextEntryViewModel Username { get; set; }

        public PasswordEntryViewModel Password { get; set; }

        public List<Access> Items { get; set; }

        public string EditBtn { get; set; }

        public bool IsEditing { get; set; }

        public Access currentAccess { get; set; }

        public bool Deletable { get; set; }

        #endregion

        #region Constructor

        public SettingsViewModel()
        {

            CloseCommand = new RelayCommand(() => { IoC.App.SettingsPageVisible = false; });
            RefreshCommand = new RelayCommand(Refresh);
            DeleteCommand = new RelayCommand(Delete);
            AddCommand = new RelayCommand(Add);

            EditBtn = "Editar";
            Deletable = false;


            Username = new TextEntryViewModel()
            {
                Label = "Usuario",
                OriginalText = "Usuario",
                EditedText = "Usuario",
                IsEditing = false
            };
            Password = new PasswordEntryViewModel()
            {
                Label = "Acceso",
                OriginalPassword = "Acceso",
                EditedPassword = "Acceso",
                IsEditing = false
            };
            IsEditing = true;
            EditCommand = new RelayCommand(Edit);
            SaveCommand = new RelayCommand(Save);
        }

        private async void Add()
        {
            await IoC.UI.ShowAddAccessModal(new AddAccessBoxViewModel
            {
                Title = "Agregar Acceso",
            });
        }

        private void Delete()
        {
            if (Deletable)
            {
                _ = IoC.AccessService.Delete(currentAccess.Id);
            }
        }

        public void SetContent(Access value)
        {
            Username.OriginalText = value.Username;
            Username.EditedText = value.Username;
            Password.OriginalPassword = value.Password;
            currentAccess = value;
            Deletable = true;
        }
        private void Edit()
        {
            if (!IsEditing)
            {
                EditBtn = "Cancelar";
                IsEditing = true;
                
            } else
            {
                EditBtn = "Editar";
                IsEditing = false;
                Reset();
            }
            Password.IsEditing = !Password.IsEditing;
            Username.IsEditing = !Username.IsEditing;

        }

        private void Refresh()
        {
            Items = IoC.AccessService.GetAllAsync().Result;
        }
        private async void Save()
        {
            if (Username.IsValid())
            {
                currentAccess.Username = Username.EditedText;

                if (Password.isValid())
                {
                    currentAccess.Password = Password.NewPasswordHint;
                }
                try
                {
                    IoC.AccessService.Put(currentAccess);

                    await IoC.UI.ShowMesssage(new MessageBoxViewModel
                    {
                        Title = "Edicion Exitosa",
                        Message = "Se ha editado el acceso exitosamente",
                        OkText = "OK"
                    });
                }
                catch
                {
                    await IoC.UI.ShowMesssage(new MessageBoxViewModel
                    {
                        Title = "Edicion Fallida",
                        Message = "Por favor revisar los datos ingresados",
                        OkText = "OK"
                    });
                }
            } else
            {
                await IoC.UI.ShowMesssage(new MessageBoxViewModel
                {
                    Title = "Entradas invalidas",
                    Message = "Por favor revisar los datos ingresados",
                    OkText = "OK"
                });
            }
            
        }

        private void Reset()
        {
            Username.EditedText = "Username";
            Password.NewPasswordHint = "New Password";
            Password.OriginalPasswordHint = "Current Password";
            Password.ConfirmPasswordHint = "Confirm Password";
        }
        #endregion
    }
}
