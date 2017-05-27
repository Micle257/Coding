// -----------------------------------------------------------------------
//  <copyright file="MenuRepositoryTests.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer.Tests.UnitTests
{
    using System.Collections.Generic;
    using Core;
    using Core.Models;
    using Infrastructure.Repositories;
    using Moq;
    using Xunit;

    public class MenuRepositoryTests
    {
        readonly Mock<MenuRepository> _mock;

        public MenuRepositoryTests()
        {
            var menu0 = new Menu
                        {
                            MenuHierarchyLevel = MenuHierarchyLevel.Root,
                            Id = 0
                        };
            var menu2 = new Menu
                        {
                            MenuHierarchyLevel = MenuHierarchyLevel.TopCategory,
                            Id = 2,
                            ParentMenu = menu0
                        };
            var menus = new List<Menu>
                        {
                            menu0,
                            new Menu
                            {
                                MenuHierarchyLevel = MenuHierarchyLevel.Root,
                                Id = 1
                            },
                            menu2,
                            new Menu
                            {
                                MenuHierarchyLevel = MenuHierarchyLevel.TopCategory,
                                Id = 3,
                                ParentMenu = menu0
                            },
                            new Menu
                            {
                                MenuHierarchyLevel = MenuHierarchyLevel.Category,
                                Id = 4,
                                ParentMenu = menu2
                            },
                            new Menu
                            {
                                MenuHierarchyLevel = MenuHierarchyLevel.Category,
                                Id = 5,
                                ParentMenu = menu2
                            }
                        };

            _mock = new Mock<MenuRepository>();
            _mock.Setup(r => r.GetMenus()).Returns(() => menus);
        }
    }
}