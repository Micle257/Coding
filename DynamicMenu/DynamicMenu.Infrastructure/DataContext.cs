﻿// -----------------------------------------------------------------------
//  <copyright file="DataContext.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.Infrastructure
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Core.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary> Represents a database context for this application. </summary>
    public class DataContext : DbContext
    {
        /// <summary> Initializes a new instance of the <see cref="DataContext" /> class with context options. </summary>
        /// <param name="contextOptions"> The context options. </param>
        public DataContext(DbContextOptions contextOptions) : base(contextOptions) { }

        /// <summary> Gets or sets the menu database table. </summary>
        /// <value> The <see cref="DbSet{T}" /> of the <see cref="Menu" /> entities. </value>
        public DbSet<Menu> Menus { get; set; }

        /// <inheritdoc />
        public override int SaveChanges()
        {
            ApplyUpdate();
            return base.SaveChanges();
        }

        /// <inheritdoc />
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ApplyUpdate();
            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary> Updates timestamps values on changed entities. </summary>
        void ApplyUpdate()
        {
            var entries = ChangeTracker?.Entries()
                                       .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            if (entries == null)
                return;

            foreach (var entry in entries)
            {
                var entity = (BaseEntity) entry.Entity;
                if (entry.State == EntityState.Added)
                    entity.CreatedAt = DateTimeOffset.UtcNow;
                entity.LastUpdatedAt = DateTimeOffset.UtcNow;
            }
        }
    }
}