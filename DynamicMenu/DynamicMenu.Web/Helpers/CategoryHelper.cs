using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicMenu.Web.Helpers
{
    using Core;
    using Core.Models;
    using ViewModels;

    /// <summary>
    /// Provides helper methods for category logic.
    /// </summary>
    public static class CategoryHelper
    {
        /// <summary>
        /// Gets the root navigation categories.
        /// </summary>
        /// <param name="menus">The menus entities.</param>
        /// <returns>
        /// A <see cref="List{T}"/> of root <see cref="NavigationCategoryViewModel"/>s.
        /// </returns>
        public static IList<NavigationCategoryViewModel> GetCategories(IList<Menu> menus)
        {
            var rootMenus = new List<Menu>();
            var topMenus = new List<Menu>();
            var headMenus = new List<Menu>();
            foreach (var menu in menus)
            {
                switch (menu.MenuHierarchyLevel)
                {
                    case MenuHierarchyLevel.Root:
                        rootMenus.Add(menu);
                        break;
                    case MenuHierarchyLevel.TopCategory:
                        topMenus.Add(menu);
                        break;
                    case MenuHierarchyLevel.Category:
                        headMenus.Add(menu);
                        break;
                }
            }
            var categories = headMenus.Select(menu => new NavigationCategoryViewModel { Menu = menu }).ToList();

            foreach (var topMenu in topMenus)
            {
                var children = categories.Where(c => c.Menu.ParentMenuId == topMenu.Id).ToList();
                categories.Add(new NavigationCategoryViewModel { Children = children, Menu = topMenu });
            }
            foreach (var rootMenu in rootMenus)
            {
                var children = categories.Where(c => c.Menu.ParentMenuId == rootMenu.Id).ToList();
                categories.Add(new NavigationCategoryViewModel { Children = children, Menu = rootMenu });
            }

            return categories.Where(c => c.Menu.MenuHierarchyLevel == MenuHierarchyLevel.Root).ToList();
        }
    }
}
