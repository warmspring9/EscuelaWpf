using EscuelaWPF.Core;
using EscuelaWPF.Interfaces;

namespace EscuelaWPF
{
    /// <summary>
    /// Interaction logic for DialogMessageBox.xaml
    /// </summary>
    public partial class AddAuthorizationBox : BaseDialogUserControl, ICloseable
    {
        public AddAuthorizationBox()
        {
            InitializeComponent();

        }

        public void Close()
        {
            base.CLose();
        }

        private void datePicker2_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            AddAuthorizationBoxViewModel cont = (AddAuthorizationBoxViewModel)this.DataContext;
            cont.EditEndTime = datePicker2.SelectedDate.ToString();
        }

        private void datePicker1_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            AddAuthorizationBoxViewModel cont = (AddAuthorizationBoxViewModel)this.DataContext;
            cont.EditStartTime = datePicker1.SelectedDate.ToString();
        }
    }
}
