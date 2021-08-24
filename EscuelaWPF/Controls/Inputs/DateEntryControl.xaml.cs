using EscuelaWPF.Core;
using System;
using System.Windows.Controls;

namespace EscuelaWPF
{
    /// <summary>
    /// Interaction logic for TextEntryControl.xaml
    /// </summary>
    public partial class DateEntryControl : UserControl
    {
        public DateEntryControl()
        {
            InitializeComponent();
        }

        private void datePicker2_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateEntryViewModel cont = (DateEntryViewModel)this.DataContext;
            cont.EditedText = (DateTime)datePicker2.SelectedDate;
        }
    }
}
