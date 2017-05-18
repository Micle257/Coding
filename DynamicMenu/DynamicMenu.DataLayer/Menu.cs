// -----------------------------------------------------------------------
//  <copyright file="Menu.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary> Represents a entity for dynamic menu. </summary>
    public class Menu : BaseEntity
    {
        /// <summary> Gets or sets the reference to the parent menu. </summary>
        /// <value> The <see cref="Menu" />. </value>
        public virtual Menu ParentMenu { get; set; }

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
        public bool IsEnabled { get; set; }

        /// <summary> Gets or sets the menu's hierarchy level. </summary>
        /// <value> The <see cref="MenuHierarchyLevel" />. </value>
        public MenuHierarchyLevel MenuHierarchyLevel { get; set; }

        /// <summary> Generates the slug from display name. </summary>
        /// <exception cref="ArgumentNullException"> DisplayName - Name of the menu is not valid (argument is null or whitespace). </exception>
        /// <exception cref="FormatException"> The display name must contain only letters, digits, spaces or punctuations </exception>
        public void GenerateSlug()
        {
            if (string.IsNullOrWhiteSpace(DisplayName))
                throw new ArgumentNullException(nameof(DisplayName), "Name of the menu is not valid (argument is null or whitespace).");

            if (!DisplayName.ToCharArray().All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || char.IsPunctuation(c)))
                throw new FormatException("The display name must contain only letters, digits, spaces or punctuations");

            Slug = DisplayName.Replace(' ', '-')?.ToLowerInvariant();
        }
    }
}