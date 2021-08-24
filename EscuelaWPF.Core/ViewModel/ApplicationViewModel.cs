namespace EscuelaWPF.Core
{
    public class ApplicationViewModel: BaseViewModel
    {

        public bool SideMenuVisible { get; set; }

        public bool SettingsPageVisible { get; set; }
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        public BaseViewModel CurrentPageViewModel { get; private set; }

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page"></param>
        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;

            //Show side menU
            if (page != ApplicationPage.Login)
            {
                SideMenuVisible = true;
            }
        }

        public void GoToPage(ApplicationPage page, BaseViewModel viewModel)
        {
            CurrentPage = page;

            CurrentPageViewModel = viewModel;

            SettingsPageVisible = false;

            OnPropertyChanged(nameof(CurrentPage));

            //Show side menU
            if (page != ApplicationPage.Login)
            {
                SideMenuVisible = true;
            }
        }
    }
}
