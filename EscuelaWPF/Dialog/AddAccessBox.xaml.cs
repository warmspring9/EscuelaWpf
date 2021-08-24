using EscuelaWPF.Interfaces;

namespace EscuelaWPF
{
    /// <summary>
    /// Interaction logic for DialogMessageBox.xaml
    /// </summary>
    public partial class AddAccessBox : BaseDialogUserControl, ICloseable
    {
        public AddAccessBox()
        {
            InitializeComponent();

        }

        public void Close()
        {
            base.CLose();
        }
    }
}
