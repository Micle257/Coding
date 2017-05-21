using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMenu.DataLayer.Tests.UnitTests
{
    using Xunit;

    public class BussinesContextTests
    {
        [Fact]
        public void ShouldGetCategories()
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

            using (var bc = new BussinesContext(context: null))
            {
                var categories = bc.GetCategories(menus);

                Assert.Equal(6, categories.Count);
                Assert.Equal(2, categories.Where(c => c.Menu.MenuHierarchyLevel == MenuHierarchyLevel.Root).Count());
                Assert.Equal(2, categories.Where(c => c.Menu.MenuHierarchyLevel == MenuHierarchyLevel.TopCategory).Count());
                Assert.Equal(2, categories.Where(c => c.Menu.MenuHierarchyLevel == MenuHierarchyLevel.Category).Count());

                Assert.Equal(2, categories.FirstOrDefault(c => c.Menu.Id == 0).Children.Count);
                Assert.Equal(2, categories.FirstOrDefault(c => c.Menu.Id == 2).Children.Count);
            }
        }
    }
}
