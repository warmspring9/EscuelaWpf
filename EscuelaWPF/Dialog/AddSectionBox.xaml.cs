using EscuelaWPF.Core;
using EscuelaWPF.Interfaces;

namespace EscuelaWPF
{
    /// <summary>
    /// Interaction logic for DialogMessageBox.xaml
    /// </summary>
    public partial class AddSectionBox : BaseDialogUserControl, ICloseable
    {
        public AddSectionBox()
        {
            InitializeComponent();

        }

        public void Close()
        {
            base.CLose();
        }

        private void datePicker2_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            AddSectionBoxViewModel context = (AddSectionBoxViewModel)DataContext;
            context.EditEndTime = (System.DateTime)datePicker2.SelectedDate;
        }
    }
}
