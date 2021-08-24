using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaWPF.Core
{
    /// <summary>
    ///  The UI manager that handles any UI interaction in the app
    /// </summary>
    public interface IUIManager
    {
        Task ShowMesssage(MessageBoxViewModel viewModel);
        Task ShowAddTeacherModal(AddTeacherBoxViewModel messageBoxViewModel);

        Task ShowAddGuardianModal(AddGuardianBoxViewModel messageBoxViewModel);

        Task ShowAddAccessModal(AddAccessBoxViewModel messageBoxViewModel);

        Task ShowAddAuthModal(AddAuthorizationBoxViewModel messageViewModel);

        Task ShowAddStudentModal(AddStudentBoxViewModel messageBoxViewModel);

        Task ShowAddSectionModal(AddSectionBoxViewModel messageBoxViewModel);

        Task ShowAddAttendanceModal(AddAttendanceBoxViewModel messageBoxViewModel);
    }
}
