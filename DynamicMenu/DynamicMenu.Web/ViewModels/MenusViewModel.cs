// -----------------------------------------------------------------------
//  <copyright file="MenusViewModel.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.Web.ViewModels
{
    using System.Collections.Generic;
    using DataLayer;

    /// <summary>
    /// Represents a view model for category side menu.
    /// </summary>
    public class MenusViewModel
    {
        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The <see cref="IList{T}"/> of <see cref="Category"/>.
        /// </value>
        public IList<Category> Categories { get; set; }
    }
}