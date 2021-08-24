namespace EscuelaWPF.Core
{
    public class MenuListItemDesignModel : MenuItemViewModel
    {
        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static MenuListItemDesignModel Instance => new();

        #endregion

        #region Constructor

        public MenuListItemDesignModel()
        {
            Initials = "LM";
            Name = "Liopardo El Moto";
            Id = "11750076111";
            ProfilePictureRGB = "FF331F";
        }

        #endregion
    }
}
