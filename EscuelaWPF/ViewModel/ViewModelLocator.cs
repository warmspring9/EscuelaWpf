using EscuelaWPF.Core;

namespace EscuelaWPF
{
    public class ViewModelLocator
    {

        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();
        public static ApplicationViewModel ApplicationViewModel => (ApplicationViewModel)IoC.Get<ApplicationViewModel>();
    }
}
