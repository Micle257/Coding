using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicMenu.Web.ViewModels
{
    using Core.Models;

    /// <summary>
    /// Represents a view model for category navigation in partial view.
    /// </summary>
    public class NavigationCategoryViewModel
    {
        /// <summary>
        /// Gets or sets the menu.
        /// </summary>
        /// <value>
        /// The <see cref="Menu"/>.
        /// </value>
        public Menu Menu { get; set; }

        /// <summary>
        /// Gets or sets the children categories.
        /// </summary>
        /// <value>
        /// The <see cref="List{NavigationCategoryViewModel}"/>.
        /// </value>
        public List<NavigationCategoryViewModel> Children { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The <see cref="string"/>.
        /// </value>
        public string Title => Menu.DisplayName;
    }
}
