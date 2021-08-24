using System;
using System.Windows.Input;

namespace EscuelaWPF.Core
{
    public class SectionEntryViewModel : BaseEntryViewModel
    {
        public string CompoundName { get; set; }

        public SectionEntryViewModel() : base()
        {
            
        }

        public void setName()
        {
            CompoundName = IoC.SectionService.GetbyId(OriginalText).Result.ToString();
        }
        internal override bool IsValid()
        {
            return IoC.SectionService.GetbyId(EditedText) != null;
        }
    }
}
