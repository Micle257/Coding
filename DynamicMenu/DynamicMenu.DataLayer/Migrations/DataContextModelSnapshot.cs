// -----------------------------------------------------------------------
//  <copyright file="DataContextModelSnapshot.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.Infrastructure.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;

    [DbContext(typeof(DataContext))]
    class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                    .HasAnnotation("ProductVersion", "1.1.2")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DynamicMenu.Core.Models.Menu",
                                b =>
                                {
                                    b.Property<int>("Id")
                                     .ValueGeneratedOnAdd();

                                    b.Property<DateTimeOffset>("CreatedAt");

                                    b.Property<string>("DisplayName");

                                    b.Property<bool>("IsEnabled");

                                    b.Property<DateTimeOffset>("LastUpdatedAt");

                                    b.Property<int>("MenuHierarchyLevel");

                                    b.Property<int?>("ParentMenuId");

                                    b.Property<string>("Slug")
                                     .IsRequired();

                                    b.HasKey("Id");

                                    b.HasIndex("ParentMenuId");

                                    b.ToTable("Menus");
                                });

            modelBuilder.Entity("DynamicMenu.Core.Models.Menu",
                                b =>
                                {
                                    b.HasOne("DynamicMenu.Core.Models.Menu", "ParentMenu")
                                     .WithMany()
                                     .HasForeignKey("ParentMenuId");
                                });
        }
    }
}