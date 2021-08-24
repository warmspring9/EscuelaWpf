using EscuelaWPF.Interfaces;

namespace EscuelaWPF
{
    /// <summary>
    /// Interaction logic for DialogMessageBox.xaml
    /// </summary>
    public partial class AddTeacherBox : BaseDialogUserControl, ICloseable
    {
        public AddTeacherBox()
        {
            InitializeComponent();

        }

        public void Close()
        {
            base.CLose();
        }
    }
}
