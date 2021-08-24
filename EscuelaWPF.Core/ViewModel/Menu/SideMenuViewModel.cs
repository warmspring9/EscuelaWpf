using EscuelaWPF.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EscuelaWPF.Core
{
    public class SideMenuViewModel: BaseViewModel
    {

        #region Public Properties

        public ObservableCollection<MenuItemViewModel> Items { get; set; }

        public string SearchValue { get; set; } = "Buscar";
        public MenuElementObjectType CurrentType { get; set; }

        public Boolean IsSearch { get; set; } = true;


        #endregion

        #region Commands

        public ICommand TeacherCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand StudentCommand { get; set; }

        public ICommand GuardianCommand { get; set; }

        public ICommand SectionCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        #endregion

        #region Constructor

        public SideMenuViewModel()
        {
            TeacherCommand = new RelayCommand(GetTeachers);
            StudentCommand = new RelayCommand(GetStudent);
            GuardianCommand = new RelayCommand(GetGuardian);
            SectionCommand = new RelayCommand(GetSection);
            SearchCommand = new RelayCommand(Search);

            AddCommand = new RelayCommand(AddObject);

            CurrentType = MenuElementObjectType.Teacher;
        }

        private void Search()
        {
            switch (CurrentType)
            {
                case MenuElementObjectType.Teacher:
                    SearchTeacher();
                    break;
                case MenuElementObjectType.Student:
                    SearchStudent();
                    break;
                case MenuElementObjectType.Guardian:
                    SearchGuardian();
                    break;
                default:
                    break;
            }
        }

        private void SearchTeacher()
        {
            if (SearchValue != "" && SearchValue != "Buscar")
            {
                Items = new ObservableCollection<MenuItemViewModel>();
                List<Teacher> temp = IoC.SearchService.GetSearchedTeacher(SearchValue).Result;
                if (temp != null)
                {
                    foreach (Teacher teacher in temp)
                    {
                        Items.Add(new MenuItemViewModel()
                        {
                            Name = teacher.Name,
                            Id = teacher.Id.ToString(),
                            Initials = teacher.Name.Substring(0, 1) + teacher.Last_name.Substring(0, 1),
                            ProfilePictureRGB = "FF331F",
                            Type = MenuElementObjectType.Teacher,
                            Info = teacher
                        });
                    }

                }
            } else
            {
                SearchValue = "Buscar";
            }
        }

        private void SearchStudent()
        {
            if (SearchValue != "" && SearchValue != "Buscar")
            {
                Items = new ObservableCollection<MenuItemViewModel>();
                List<Student> temp = IoC.SearchService.GetSearchedStudent(SearchValue).Result;
                if (temp != null)
                {
                    foreach (Student student in temp)
                    {
                        Items.Add(new MenuItemViewModel()
                        {
                            Name = student.Name,
                            Id = student.Id.ToString(),
                            Initials = student.Name.Substring(0, 1) + student.Last_name.Substring(0, 1),
                            ProfilePictureRGB = "663a82",
                            Type = MenuElementObjectType.Student,
                            Info = student
                        });

                    }
                }
            }
            else
            {
                SearchValue = "Buscar";
            }
        }

        private void SearchGuardian()
        {
            if (SearchValue != "" && SearchValue != "Buscar")
            {
                Items = new ObservableCollection<MenuItemViewModel>();
                List<Guardian> temp = IoC.SearchService.GetSearchedGuardian(SearchValue).Result;
                if (temp != null)
                {
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
            }
            else
            {
                SearchValue = "Buscar";
            }
        }

        private void AddObject()
        {
            switch (CurrentType)
            {
                case MenuElementObjectType.Teacher:
                    AddTeacherAsync();
                    break;
                case MenuElementObjectType.Student:
                    AddStudentAsync();
                    break;
                case MenuElementObjectType.Guardian:
                    AddGuardianAsync();
                    break;
                case MenuElementObjectType.Section:
                    AddSectionAsync();
                    break;
                default:
                    break;
            }
        }
        private async void AddStudentAsync()
        {
            await IoC.UI.ShowAddStudentModal(new AddStudentBoxViewModel
            {
                Title = "Agregar Estudiante",
            });
        }

        private async void AddGuardianAsync()
        {
            await IoC.UI.ShowAddGuardianModal(new AddGuardianBoxViewModel
            {
                Title = "Agregar Encargado",
                NameHint = "Nombre",
                LastNameHint = "Apellido",
                PhoneNumberHint = "Numero de telefono",
                IdHint = "Identificacion"
            });
        }
        private async void AddTeacherAsync()
        {
            await IoC.UI.ShowAddTeacherModal(new AddTeacherBoxViewModel
            {
                Title = "Agregar Professor",
                NameHint = "Nombre",
                LastNameHint = "Apellido",
                PhoneNumberHint = "Numero de telefono",
                IdHint = "Identificacion"
            });
        }

        private async void AddSectionAsync()
        {
            await IoC.UI.ShowAddSectionModal(new AddSectionBoxViewModel
            {
                Title = "Agregar Seccion",
            });
        }



        #endregion

        #region Functions

        public void GetTeachers()
        {
            IsSearch = true;
            Items = new ObservableCollection<MenuItemViewModel>();
            List<Teacher> temp = IoC.TeacherService.GetAllAsync().Result;
            foreach (Teacher teacher in temp){
                Items.Add(new MenuItemViewModel()
                {
                    Name = teacher.Name,
                    Id = teacher.Id.ToString(),
                    Initials = teacher.Name.Substring(0, 1) + teacher.Last_name.Substring(0, 1),
                    ProfilePictureRGB = "FF331F",
                    Type = MenuElementObjectType.Teacher,
                    Info = teacher
                });
            }
            CurrentType = MenuElementObjectType.Teacher;
        }

        public void GetStudent()
        {
            IsSearch = true;
            Items = new ObservableCollection<MenuItemViewModel>();
            List<Student> temp = IoC.StudentService.GetAllAsync().Result;
            foreach (Student student in temp)
            {
                Items.Add(new MenuItemViewModel()
                {
                    Name = student.Name,
                    Id = student.Id.ToString(),
                    Initials = student.Name.Substring(0, 1) + student.Last_name.Substring(0, 1),
                    ProfilePictureRGB = "663a82",
                    Type = MenuElementObjectType.Student,
                    Info = student
                });

            }
            CurrentType = MenuElementObjectType.Student;
        }

        public void GetGuardian()
        {
            IsSearch = true;
            Items = new ObservableCollection<MenuItemViewModel>();
            List<Guardian> temp = IoC.GuardianService.GetAllAsync().Result;
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

            CurrentType = MenuElementObjectType.Guardian;
        }

        private async void GetSection()
        {
            IsSearch = false;
            Items = new ObservableCollection<MenuItemViewModel>();
            List<Section> temp = IoC.SectionService.GetAllAsync().Result;
            foreach (Section section in temp)
            {
                Items.Add(new MenuItemViewModel()
                {
                    Name = section.Name,
                    Id = section.Id.ToString(),
                    Initials = section.Name.Substring(0, 2),
                    ProfilePictureRGB = "4287f5",
                    Type = MenuElementObjectType.Section,
                    Info = section
                });

            }

            CurrentType = MenuElementObjectType.Section;
        }

        #endregion
    }
}
