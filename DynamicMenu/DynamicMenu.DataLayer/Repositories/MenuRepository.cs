// -----------------------------------------------------------------------
//  <copyright file="MenuRepository.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using Core.Models;
    using Extensions;
    using JetBrains.Annotations;

    /// <summary> Represents a repository for <see cref="Menu" /> entity. </summary>
    public class MenuRepository : Repository<Menu>
    {
        /// <summary> Initializes a new instance of the <see cref="MenuRepository" /> class. </summary>
        /// <param name="context"> The context. </param>
        public MenuRepository([NotNull] DataContext context) : base(context) { }

        /// <summary> Gets the menus from the data context through Stored Procedure. </summary>
        /// <returns> An <see cref="IList{T}" />. </returns>
        public IList<Menu> GetMenus()
        {
            var menus = Context.ExecuteStoredProcedure<Menu>("[dbo].[spGetMenuData]");
            return menus;
        }
    }
}