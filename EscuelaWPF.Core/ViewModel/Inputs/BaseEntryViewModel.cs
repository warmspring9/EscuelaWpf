using System;
using System.Windows.Input;

namespace EscuelaWPF.Core
{
    public abstract class BaseEntryViewModel : BaseViewModel
    {
        public string Label { get; set; }

        public string EditedText { get; set; }

        public string OriginalText { get; set; }

        public bool IsEditing { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public BaseEntryViewModel()
        {
            CancelCommand = new RelayCommand(() => { IsEditing = false; });
            EditCommand = new RelayCommand(Edit);
        }

        public void Edit()
        {
            IsEditing = true;
        }

        internal abstract bool IsValid();
    }
}
