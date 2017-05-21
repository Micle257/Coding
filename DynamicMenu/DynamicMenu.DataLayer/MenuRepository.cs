// -----------------------------------------------------------------------
//  <copyright file="MenuRepository.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer
{
    using Entities;
    using JetBrains.Annotations;

    /// <summary> Represents a repository for <see cref="Menu" /> entity. </summary>
    public class MenuRepository : Repository<Menu>
    {
        /// <summary> Initializes a new instance of the <see cref="MenuRepository" /> class. </summary>
        /// <param name="context"> The context. </param>
        public MenuRepository([NotNull] DataContext context) : base(context) { }
    }
}