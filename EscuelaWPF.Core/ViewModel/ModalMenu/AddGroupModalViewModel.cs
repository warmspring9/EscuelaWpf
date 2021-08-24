using System.Collections.Generic;

namespace EscuelaWPF.Core
{
    /// <summary>
    /// A view model for the <see cref="AddGroupModal"/>
    /// </summary>
    public class AddGroupModalViewModel : BaseModalViewModel
    {
        #region Public Properties



        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddGroupModalViewModel()
        {
            Content = new MenuElementListViewModel
            {
                Items = new List<MenuElementViewModel>(new[]
                {
                    //This is where the real data should go
                    new MenuElementViewModel { Text = "Real Group 1", Type = MenuElementType.Header },
                    new MenuElementViewModel { Text = "Real Group 2"},
                    new MenuElementViewModel { Text = "Real Group 3"},
                })
            };
        }

        #endregion
    }
}
