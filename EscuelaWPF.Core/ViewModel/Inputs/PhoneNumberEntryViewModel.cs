using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EscuelaWPF.Core
{
    public class PhoneNumberEntryViewModel : BaseEntryViewModel
    {
        public PhoneNumberEntryViewModel() : base() { }
        internal override bool IsValid()
        {
            int errorCounter = Regex.Matches(EditedText, @"[a-zA-Z]").Count;
            return errorCounter == 0;
        }
    }
}
