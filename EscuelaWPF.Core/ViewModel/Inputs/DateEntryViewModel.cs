using System;
using System.Windows.Input;

namespace EscuelaWPF.Core
{
    public class DateEntryViewModel : BaseViewModel
    {
        public string Label { get; set; }

        public DateTime EditedText { get; set; }

        public DateTime OriginalText { get; set; }

        public bool IsEditing { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public DateEntryViewModel()
        {
            CancelCommand = new RelayCommand(() => { IsEditing = false; });
            EditCommand = new RelayCommand(Edit);
        }

        public void Edit()
        {
            IsEditing = true;
        }

        public bool IsValid()
        {
            return true;
        }
    }
}