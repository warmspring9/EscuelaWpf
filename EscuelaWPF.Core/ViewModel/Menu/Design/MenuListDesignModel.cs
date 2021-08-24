using System.Collections.Generic;

namespace EscuelaWPF.Core
{
    public class MenuListDesignModel : MenuListViewModel
    {
        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static MenuListDesignModel Instance => new();

        #endregion

        #region Constructor

        public MenuListDesignModel()
        {
            Items = new List<MenuItemViewModel>
            {
                new MenuItemViewModel
                {
                    Name = "Jaimico Milico",
                    Initials = "JM",
                    Id = "119854736",
                    ProfilePictureRGB = "ffffff"
                },
                new MenuItemViewModel
                {
                    Name = "Jaimico Milico el tico",
                    Initials = "NOT",
                    Id = "119854736",
                    ProfilePictureRGB = "FF331F"
                },
                new MenuItemViewModel
                {
                    Name = "Jaimico Milico",
                    Initials = "J",
                    Id = "119854736",
                    ProfilePictureRGB = "FF331F"
                },
                new MenuItemViewModel
                {
                    Name = "Jaimico Milico",
                    Initials = "JM",
                    Id = "119854736",
                    ProfilePictureRGB = "FF331F"
                },
                new MenuItemViewModel
                {
                    Name = "Jaimico Milico",
                    Initials = "JM",
                    Id = "119854736",
                    ProfilePictureRGB = "ffffff"
                },
                new MenuItemViewModel
                {
                    Name = "Jaimico Milico el tico",
                    Initials = "NOT",
                    Id = "119854736",
                    ProfilePictureRGB = "FF331F"
                },
                new MenuItemViewModel
                {
                    Name = "Jaimico Milico",
                    Initials = "J",
                    Id = "119854736",
                    ProfilePictureRGB = "FF331F"
                },
                new MenuItemViewModel
                {
                    Name = "Jaimico Milico",
                    Initials = "JM",
                    Id = "119854736",
                    ProfilePictureRGB = "FF331F"
                },
                new MenuItemViewModel
                {
                    Name = "Jaimico Milico",
                    Initials = "JM",
                    Id = "119854736",
                    ProfilePictureRGB = "ffffff"
                },
                new MenuItemViewModel
                {
                    Name = "Jaimico Milico el tico mitico salpico rico",
                    Initials = "NOT",
                    Id = "119854736",
                    ProfilePictureRGB = "FF331F"
                },
                new MenuItemViewModel
                {
                    Name = "Jaimico Milico",
                    Initials = "J",
                    Id = "119854736",
                    ProfilePictureRGB = "FF331F"
                },
                new MenuItemViewModel
                {
                    Name = "Jaimico Milico",
                    Initials = "JM",
                    Id = "119854736",
                    ProfilePictureRGB = "FF331F"
                },
            };
        }

        #endregion
    }
}
