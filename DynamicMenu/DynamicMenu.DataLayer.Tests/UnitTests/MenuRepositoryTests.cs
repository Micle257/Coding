// -----------------------------------------------------------------------
//  <copyright file="BussinesContextTests.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer.Tests.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Core.Models;
    using Moq;
    using Xunit;

    public class MenuRepositoryTests
    {
        Mock<MenuRepository> _mock;

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

        //[Fact] TODO to Web tests
        //public void ShouldGetCategories()
        //{
        //        var categories = bc.GetCategories(menus);

        //        Assert.Equal(6, categories.Count);
        //        Assert.Equal(2, categories.Where(c => c.Menu.MenuHierarchyLevel == MenuHierarchyLevel.Root).Count());
        //        Assert.Equal(2, categories.Where(c => c.Menu.MenuHierarchyLevel == MenuHierarchyLevel.TopCategory).Count());
        //        Assert.Equal(2, categories.Where(c => c.Menu.MenuHierarchyLevel == MenuHierarchyLevel.Category).Count());

        //        Assert.Equal(2, categories.FirstOrDefault(c => c.Menu.Id == 0).Children.Count);
        //        Assert.Equal(2, categories.FirstOrDefault(c => c.Menu.Id == 2).Children.Count);
        //}
    }
}