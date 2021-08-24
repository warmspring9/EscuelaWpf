using EscuelaWPF.Core;
using System.Threading.Tasks;
using System.Windows;

namespace EscuelaWPF
{
    public class UIManager : IUIManager
    {
        public Task ShowMesssage(MessageBoxViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);
        }
        public Task ShowAddTeacherModal(AddTeacherBoxViewModel viewModel)
        {
            return new AddTeacherBox().ShowDialog(viewModel);
        }

        public Task ShowAddAccessModal(AddAccessBoxViewModel viewModel)
        {
            return new AddAccessBox().ShowDialog(viewModel);
        }

        public Task ShowAddAuthModal(AddAuthorizationBoxViewModel viewModel)
        {
            return new AddAuthorizationBox().ShowDialog(viewModel);
        }

        public Task ShowAddGuardianModal(AddGuardianBoxViewModel viewModel)
        {
            return new AddTeacherBox().ShowDialog(viewModel);
        }

        public Task ShowAddStudentModal(AddStudentBoxViewModel viewModel)
        {
            return new AddStudentBox().ShowDialog(viewModel);
        }

        public Task ShowAddSectionModal(AddSectionBoxViewModel viewModel)
        {
            return new AddSectionBox().ShowDialog(viewModel);
        }

        public Task ShowAddAttendanceModal(AddAttendanceBoxViewModel viewModel)
        {
            return new AddAttendanceBox().ShowDialog(viewModel);
        }
    }

    
}
