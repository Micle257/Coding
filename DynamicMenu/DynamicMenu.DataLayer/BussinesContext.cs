// -----------------------------------------------------------------------
//  <copyright file="BussinesContext.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer
{
    using System;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;

    /// <summary> Represents a context which wraps database context of this application in sql server connection. </summary>
    public class BussinesContext : IDisposable
    {
        /// <summary> The database context. </summary>
        [NotNull]
        readonly DataContext _context;

        /// <summary> Initializes a new instance of the <see cref="BussinesContext" /> class with default context settings. </summary>
        public BussinesContext()
            : this(@"Data Source=PENTAGON\SQLEXPRESS;Initial Catalog=dynamicmenudata;Integrated Security=True;Pooling=False") { }

        /// <summary> Initializes a new instance of the <see cref="BussinesContext" /> class with sql connection string. </summary>
        /// <param name="connectionString"> The connection string. </param>
        public BussinesContext([NotNull] string connectionString)
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer(connectionString);
            _context = new DataContext(builder.Options);
        }

        /// <summary> Gets the data context. </summary>
        /// <value> The <see cref="DataContext" />. </value>
        public DataContext DataContext => _context;

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary> Adds the menu entity to the data context. </summary>
        /// <param name="name"> The name of menu. </param>
        /// <param name="hierarchyLevel"> The hierarchy level. </param>
        /// <param name="parent"> The parent. </param>
        /// <param name="isEnabled"> If set to <c> true </c> menu is enabled. </param>
        /// <returns> A newly instantiated <see cref="Menu" />. </returns>
        /// <exception cref="ArgumentNullException"> name - Name of a menu is not valid (argument is null or whitespace). </exception>
        /// <exception cref="ArgumentException"> Menu with no parent menu must be in root category </exception>
        public Menu AddMenu([NotNull] string name, MenuHierarchyLevel hierarchyLevel, Menu parent, bool isEnabled = true)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Name of a menu is not valid (argument is null or whitespace).");

            if (parent != null && hierarchyLevel != MenuHierarchyLevel.Root)
                throw new ArgumentException("Menu with no parent menu must be in root category");

            var menu = new Menu
                       {
                           DisplayName = name,
                           IsEnabled = isEnabled,
                           ParentMenu = parent,
                           MenuHierarchyLevel = hierarchyLevel
                       };
            menu.GenerateSlug();

            _context.Menus.Add(menu);
            _context.SaveChanges();

            return menu;
        }

        /// <summary> Releases unmanaged and - optionally - managed resources. </summary>
        /// <param name="disposing"> If set to <c> true </c> perform release both managed and unmanaged resources; otherwise, release only unmanaged resources. </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            _context.Dispose();
        }
    }
}