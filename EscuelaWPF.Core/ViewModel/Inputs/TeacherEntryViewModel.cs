using System;
using System.Windows.Input;

namespace EscuelaWPF.Core
{
    public class TeacherEntryViewModel : BaseEntryViewModel
    {
        public string CompoundName { get; set; }

        public TeacherEntryViewModel() : base()
        {
            
        }

        public void setName()
        {
            CompoundName = IoC.TeacherService.GetbyId(OriginalText).Result.ToString();
        }
        internal override bool IsValid()
        {
            return IoC.TeacherService.GetbyId(EditedText) != null;
        }
    }
}
