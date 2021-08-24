using EscuelaWPF.Service;
using System;
using System.Windows.Input;

namespace EscuelaWPF.Core
{
    /// <summary>
    /// View Model For each menu list item
    /// </summary>
    public class MenuItemViewModel
    {
        #region Private Members
        #endregion

        #region Public Propertires

        public string Name { get; set; }

        public string Id { get; set; }

        public string Image { get; set; }

        public string Initials { get; set; }

        public string ProfilePictureRGB { get; set; }

        public Entity Info { get; set; }

        public MenuElementObjectType Type { get; set; }

        #endregion

        #region Commands

        public ICommand OpenDetailsCommand { get; set; }

        #endregion

        #region Contructor
        public MenuItemViewModel()
        {
            OpenDetailsCommand = new RelayCommand(OpenDetails);
        }

        private void OpenDetails()
        {
            switch (Type)
            {
                case MenuElementObjectType.Teacher:
                    IoC.App.GoToPage(ApplicationPage.TeacherDetails, new TeacherDetailViewModel((Teacher)Info));
                    break;
                case MenuElementObjectType.Student:
                    IoC.App.GoToPage(ApplicationPage.StudentDetails, new StudentDetailViewModel((Student)Info));
                    break;
                case MenuElementObjectType.Guardian:
                    IoC.App.GoToPage(ApplicationPage.GuardianDetails, new GuardianDetailViewModel((Guardian)Info));
                    break;
                case MenuElementObjectType.Section:
                    IoC.App.GoToPage(ApplicationPage.SectionDetails, new SectionDetailViewModel((Section)Info));
                    break;
                default:
                    return;

            }

        }
        #endregion

        #region 
        #endregion
    }
}
