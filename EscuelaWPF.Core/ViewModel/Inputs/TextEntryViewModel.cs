using System;
using System.Windows.Input;

namespace EscuelaWPF.Core
{
    public class TextEntryViewModel : BaseEntryViewModel
    {
        public TextEntryViewModel() : base()
        {

        }
        internal override bool IsValid()
        {
            return true;
        }
    }
}
