using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueAt",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TodoItems",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "IsDone",
                table: "TodoItems",
                newName: "IsDelivered");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "TodoItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "TodoItems",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "IsDelivered",
                table: "TodoItems",
                newName: "IsDone");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueAt",
                table: "TodoItems",
                type: "datetime2",
                nullable: true);
        }
    }
}
