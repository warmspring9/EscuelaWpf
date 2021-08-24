using EscuelaWPF.Interfaces;

namespace EscuelaWPF
{
    /// <summary>
    /// Interaction logic for DialogMessageBox.xaml
    /// </summary>
    public partial class AddAttendanceBox : BaseDialogUserControl, ICloseable
    {
        public AddAttendanceBox()
        {
            InitializeComponent();

        }

        public void Close()
        {
            base.CLose();
        }
    }
}
