using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NguyenManhHung_2122110438_asp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "Name", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 4, 26, 8, 33, 8, 701, DateTimeKind.Local).AddTicks(3576), "This is a default brand", "https://example.com/defaultbrand.png", "Default Brand", new DateTime(2025, 4, 26, 8, 33, 8, 701, DateTimeKind.Local).AddTicks(3699) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "IsActive", "Name", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 4, 26, 8, 33, 8, 701, DateTimeKind.Local).AddTicks(8101), "All kinds of electronics", "https://example.com/electronics.jpg", true, "Electronics", new DateTime(2025, 4, 26, 8, 33, 8, 701, DateTimeKind.Local).AddTicks(8204) });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
