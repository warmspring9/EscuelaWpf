namespace EscuelaWPF.Core
{
    public class BaseModalViewModel: BaseViewModel
    {

        #region Public Properties

        
        public string Background { get; set; }
        /// <summary>
        /// The content inside this modal
        /// </summary>
        public BaseViewModel Content { get; set; }

        public ElementAlignment ArrowAlignment { get; set; }

        #endregion

        #region Constructor

        public BaseModalViewModel()
        {
            Background = "ffffff";
            ArrowAlignment = ElementAlignment.Left;
        }

        #endregion
    }
}
