// -----------------------------------------------------------------------
//  <copyright file="Category.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer
{
    using System.Collections.Generic;
    using Entities;

    /// <summary> Represents a data model for category. </summary>
    class Category
    {
        /// <summary> Gets the title. </summary>
        /// <value> The <see cref="string" />. </value>
        public string Title => Menu.DisplayName;

        /// <summary> Gets or sets the reference to menu entity. </summary>
        /// <value> The <see cref="Menu" />. </value>
        public Menu Menu { get; set; }

        /// <summary> Gets or sets the children categories. </summary>
        /// <value> The list of the <see cref="Category" />. </value>
        public IList<Category> Children { get; set; }
    }
}