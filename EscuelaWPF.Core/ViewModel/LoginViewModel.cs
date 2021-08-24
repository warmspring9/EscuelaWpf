using EscuelaWPF.Service;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EscuelaWPF.Core
{
    /// <summary>
    /// View Model For a Login Screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Private Members

        #endregion

        #region Public Properties
        /// <summary>
        /// The username for the user
        /// </summary>
        public string Username { get; set; }

        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }
        #endregion

        #region Constructor

        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));

        }
        #endregion

        /// <summary>
        /// Attemts to login the user
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
            try
            {
                var Password = (parameter as IHavePassword).SecurePassword.Unsecure();
                var user = Username;
                Login login = new(user, Password);
                if (await IoC.LoginService.MakeLogin(login))
                {
                    IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Menu, new MenuViewModel());
                }
                else
                {
                    await IoC.UI.ShowMesssage(new MessageBoxViewModel
                    {
                        Title = "Oops",
                        Message = "Hubo un error en el inicio de sesion porfavor revisa tu usuario y contrsena",
                        OkText = "OK"
                    });
                }
            }
            catch
            {

            }

        }
    }
}
