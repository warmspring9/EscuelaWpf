using EscuelaWPF.Core;

namespace EscuelaWPF
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : BasePage<MenuViewModel>
    {
        public MenuPage(MenuViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }

    }
}
