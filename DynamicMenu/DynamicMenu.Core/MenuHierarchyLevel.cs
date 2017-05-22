// -----------------------------------------------------------------------
//  <copyright file="MenuHierarchyLevel.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.Core
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