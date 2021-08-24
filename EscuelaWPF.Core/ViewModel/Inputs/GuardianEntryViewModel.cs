using System;
using System.Windows.Input;

namespace EscuelaWPF.Core
{
    public class GuardianEntryViewModel : BaseEntryViewModel
    {
        public string CompoundName { get; set; }

        public GuardianEntryViewModel() : base()
        {
            
        }

        public void setName()
        {
            CompoundName = IoC.GuardianService.GetbyId(OriginalText).Result.ToString();
        }
        internal override bool IsValid()
        {
            return IoC.GuardianService.GetbyId(EditedText) != null;
        }
    }
}
