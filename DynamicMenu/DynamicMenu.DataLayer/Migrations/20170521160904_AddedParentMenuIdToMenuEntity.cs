// -----------------------------------------------------------------------
//  <copyright file="20170521160904_AddedParentMenuIdToMenuEntity.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedParentMenuIdToMenuEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                                            "FK_Menus_Menus_ParentMenuId",
                                            "Menus");

            migrationBuilder.AlterColumn<int>(
                                              "ParentMenuId",
                                              "Menus",
                                              nullable: false,
                                              oldClrType: typeof(int),
                                              oldNullable: true);

            migrationBuilder.AddForeignKey(
                                           "FK_Menus_Menus_ParentMenuId",
                                           "Menus",
                                           "ParentMenuId",
                                           "Menus",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                                            "FK_Menus_Menus_ParentMenuId",
                                            "Menus");

            migrationBuilder.AlterColumn<int>(
                                              "ParentMenuId",
                                              "Menus",
                                              nullable: true,
                                              oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                                           "FK_Menus_Menus_ParentMenuId",
                                           "Menus",
                                           "ParentMenuId",
                                           "Menus",
                                           principalColumn: "Id",
                                           onDelete: ReferentialAction.Restrict);
        }
    }
}