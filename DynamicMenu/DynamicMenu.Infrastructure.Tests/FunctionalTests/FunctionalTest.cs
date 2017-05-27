// -----------------------------------------------------------------------
//  <copyright file="FunctionalTest.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer.Tests.FunctionalTests
{
    using Infrastructure;
    using Microsoft.EntityFrameworkCore;

    public class FunctionalTest
    {
        public FunctionalTest()
        {
            using (var db = GetContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        public DataContext GetContext()
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseInMemoryDatabase();
            return new DataContext(builder.Options);
        }
    }
}