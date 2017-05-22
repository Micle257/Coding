// -----------------------------------------------------------------------
//  <copyright file="MenuRepository.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Core.Models;
    using Extensions;
    using JetBrains.Annotations;

    /// <summary> Represents a repository for <see cref="Menu" /> entity. </summary>
    public class MenuRepository : Repository<Menu>
    {
        /// <summary> Initializes a new instance of the <see cref="MenuRepository" /> class. </summary>
        /// <param name="context"> The context. </param>
        public MenuRepository([NotNull] DataContext context) : base(context) { }

        /// <summary> Adds the menu entity to the data context. </summary>
        /// <param name="name"> The name of menu. </param>
        /// <param name="hierarchyLevel"> The hierarchy level. </param>
        /// <param name="parent"> The parent. </param>
        /// <param name="isEnabled"> If set to <c> true </c> menu is enabled. </param>
        /// <returns> A newly instantiated <see cref="Menu" />. </returns>
        /// <exception cref="ArgumentNullException"> name - Name of a menu is not valid (argument is null or whitespace). </exception>
        /// <exception cref="ArgumentException"> Menu with no parent menu must be in root category </exception>
        public void AddMenu([NotNull] string name, MenuHierarchyLevel hierarchyLevel, Menu parent, bool isEnabled = true)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Name of a menu is not valid (argument is null or whitespace).");

            if (parent != null && hierarchyLevel != MenuHierarchyLevel.Root)
                throw new ArgumentException("Menu with no parent menu must be in root category");

            var menu = new Menu
                       {
                           DisplayName = name,
                           IsEnabled = isEnabled,
                           ParentMenu = parent,
                           MenuHierarchyLevel = hierarchyLevel
                       };
            menu.GenerateSlug();

            Context.Menus.Add(menu);
        }

        /// <summary> Gets the menus from the data context through Stored Procedure. </summary>
        /// <returns> An <see cref="IList{T}" />. </returns>
        public IList<Menu> GetMenus()
        {
            var menus = Context.ExecuteStoredProcedure<Menu>("[dbo].[spGetMenuData]");
            return menus;
        }
    }
}