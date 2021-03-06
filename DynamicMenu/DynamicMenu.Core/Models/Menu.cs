﻿// -----------------------------------------------------------------------
//  <copyright file="Menu.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.Core.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary> Represents a entity for dynamic menu. </summary>
    public class Menu : BaseEntity
    {
        /// <summary> Gets or sets the reference to the parent menu. </summary>
        /// <value> The <see cref="Menu" />. </value>
        [ForeignKey("ParentMenuId")]
        public virtual Menu ParentMenu { get; set; }

        /// <summary> Gets or sets the parent menu identifier. </summary>
        /// <value> The <see cref="int" />. </value>
        public int? ParentMenuId { get; set; }

        /// <summary> Gets or sets the slug identifier of the menu. </summary>
        /// <value> The <see cref="string" />. </value>
        [Required]
        public string Slug { get; set; }

        /// <summary> Gets or sets the name displayed in the front-end. </summary>
        /// <value> The <see cref="string" />. </value>
        public string DisplayName { get; set; }

        /// <summary> Gets or sets a value indicating whether this menu is enabled. </summary>
        /// <value>
        ///     <c> true </c> if this instance is enabled; otherwise, <c> false </c>. </value>
        public bool IsEnabled { get; set; } = true;

        /// <summary> Gets or sets the menu's hierarchy level. </summary>
        /// <value> The <see cref="MenuHierarchyLevel" />. </value>
        public MenuHierarchyLevel MenuHierarchyLevel { get; set; }
    }
}