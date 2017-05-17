// -----------------------------------------------------------------------
//  <copyright file="MenuHierarchyLevel.cs" company="The Pentagon">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer
{
    /// <summary> Specifies a hierarchy level of navigation menu. </summary>
    public enum MenuHierarchyLevel
    {
        /// <summary> The top most, root level. </summary>
        Root,

        /// <summary> The top, secondary category. </summary>
        TopCategory,

        /// <summary> The specific category. </summary>
        Category
    }
}