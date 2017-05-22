// -----------------------------------------------------------------------
//  <copyright file="DataContextTests.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer.Tests.FunctionalTests
{
    using System.Linq;
    using Xunit;

    public class DataContextTests : FunctionalTest
    {
        [Fact]
        public void ShouldCreateDatabase()
        {
            using (var db = GetContext())
            {
                db.Database.EnsureDeleted();
                var created = db.Database.EnsureCreated();
                Assert.True(created);
            }
        }

        [Fact]
        public void ShouldAddDataToDatabase()
        {
            using (var db = GetContext())
            {
                var menu = new Menu {Slug = "New", MenuHierarchyLevel = MenuHierarchyLevel.Root};

                db.Menus.Add(menu);
                db.SaveChanges();

                var exists = db.Menus.Any(a => a.Id == menu.Id);

                Assert.True(exists);
            }
        }
    }
}