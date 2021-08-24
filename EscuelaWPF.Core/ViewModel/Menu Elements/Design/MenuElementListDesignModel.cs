using System.Collections.Generic;

namespace EscuelaWPF.Core
{
    public class MenuElementListDesignModel : MenuElementListViewModel
    {

        #region Singleton

        public static MenuElementListDesignModel Instance => new();

        #endregion

        #region Constructor
        public MenuElementListDesignModel()
        {
            Items = new List<MenuElementViewModel>(new[]
            {
                new MenuElementViewModel { Type = MenuElementType.Header, Text = "Add a group"},
                new MenuElementViewModel { Type = MenuElementType.TextAndIcon, Text = "Primero"},
                new MenuElementViewModel { Type = MenuElementType.TextAndIcon, Text = "Segundo-B"},
                new MenuElementViewModel { Type = MenuElementType.TextAndIcon, Text = "Segundo-C"},
            });

        } 
        #endregion
    }
}
