// -----------------------------------------------------------------------
//  <copyright file="NavigationCategoryViewModel.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.Infrastructure.ViewModels
{
    using System.Collections.Generic;
    using Core.Models;

    /// <summary> Represents a view model for category navigation in partial view. </summary>
    public class NavigationCategoryViewModel
    {
        /// <summary> Gets or sets the title. </summary>
        /// <value> The <see cref="string" />. </value>
        public string Title => Menu.DisplayName;

        /// <summary> Gets or sets the menu. </summary>
        /// <value> The <see cref="Menu" />. </value>
        public Menu Menu { get; set; }

        /// <summary> Gets or sets the children categories. </summary>
        /// <value> The <see cref="List{T}" />. </value>
        public List<NavigationCategoryViewModel> Children { get; set; }
    }
}