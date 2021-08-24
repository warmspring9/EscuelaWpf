using EscuelaWPF.Core;
using System.Security;

namespace EscuelaWPF.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        public LoginPage(LoginViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }

        /// <summary>
        /// The secure password for this login page
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
