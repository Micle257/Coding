// -----------------------------------------------------------------------
//  <copyright file="Menu.cs" company="The Pentagon">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer
{
    /// <summary> Represents a entity for dynamic menu. </summary>
    public class Menu : BaseEntity
    {
        /// <summary> Gets or sets the reference to the parent menu. </summary>
        /// <value> The <see cref="Menu" />. </value>
        public virtual Menu ParentMenu { get; set; }

        /// <summary> Gets or sets the title of the menu. </summary>
        /// <value> The <see cref="string" />. </value>
        public string Title { get; set; }

        /// <summary> Gets or sets a value indicating whether this menu is enabled. </summary>
        /// <value>
        ///     <c> true </c> if this instance is enabled; otherwise, <c> false </c>. </value>
        public bool IsEnabled { get; set; }

        /// <summary> Gets or sets the menu's hierarchy level. </summary>
        /// <value> The <see cref="MenuHierarchyLevel" />. </value>
        public MenuHierarchyLevel MenuHierarchyLevel { get; set; }
    }
}