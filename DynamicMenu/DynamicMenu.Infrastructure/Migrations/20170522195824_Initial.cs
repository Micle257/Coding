// -----------------------------------------------------------------------
//  <copyright file="20170522195824_Initial.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.Infrastructure.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                                         "Menus",
                                         table => new
                                                  {
                                                      Id = table.Column<int>(nullable: false)
                                                                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                                                      CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                                                      DisplayName = table.Column<string>(nullable: true),
                                                      IsEnabled = table.Column<bool>(nullable: false),
                                                      LastUpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                                                      MenuHierarchyLevel = table.Column<int>(nullable: false),
                                                      ParentMenuId = table.Column<int>(nullable: true),
                                                      Slug = table.Column<string>(nullable: false)
                                                  },
                                         constraints: table =>
                                                      {
                                                          table.PrimaryKey("PK_Menus", x => x.Id);
                                                          table.ForeignKey(
                                                                           "FK_Menus_Menus_ParentMenuId",
                                                                           x => x.ParentMenuId,
                                                                           "Menus",
                                                                           "Id",
                                                                           onDelete: ReferentialAction.Restrict);
                                                      });

            migrationBuilder.CreateIndex(
                                         "IX_Menus_ParentMenuId",
                                         "Menus",
                                         "ParentMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                                       "Menus");
        }
    }
}