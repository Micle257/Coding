// -----------------------------------------------------------------------
//  <copyright file="FunctionalTest.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer.Tests.FunctionalTests
{
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

        public DataContext GetContext() => new BussinesContext(@"Data Source=PENTAGON\SQLEXPRESS;Initial Catalog=dynamicmenudatatest;Integrated Security=True;Pooling=False").DataContext;
    }
}