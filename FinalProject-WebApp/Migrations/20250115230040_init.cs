using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject_WebApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ShowCase = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 16, 2, 0, 39, 976, DateTimeKind.Local).AddTicks(8658), "Book", 0 },
                    { 2, new DateTime(2025, 1, 16, 2, 0, 39, 976, DateTimeKind.Local).AddTicks(8668), "Computer", 0 },
                    { 3, new DateTime(2025, 1, 16, 2, 0, 39, 976, DateTimeKind.Local).AddTicks(8669), "Phone", 0 },
                    { 4, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(615), "Baby", 0 },
                    { 5, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(925), "Music", 0 },
                    { 6, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(936), "Outdoors & Shoes", 0 },
                    { 7, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(969), "Games, Beauty & Clothing", 0 },
                    { 8, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(992), "Grocery, Home & Kids", 0 },
                    { 9, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(1011), "Sports", 0 },
                    { 10, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(1020), "Health, Kids & Home", 0 },
                    { 11, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(1037), "Games & Automotive", 0 },
                    { 12, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(1051), "Automotive", 0 },
                    { 13, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(1058), "Automotive & Garden", 0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "ImageUrl", "Name", "Price", "ShowCase", "Status", "Summary" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(1917), "default.png", "Istanbul", 35m, true, 0, null },
                    { 2, 1, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(1924), "default.png", "Fatih", 35m, true, 0, null },
                    { 3, 2, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(1925), "default.png", "Asus Pc", 35000m, false, 0, null },
                    { 4, 2, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(1927), "default.png", "Lenovo Pc", 38000m, true, 0, null },
                    { 5, 2, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(1928), "default.png", "Mac Book", 65000m, true, 0, null },
                    { 6, 2, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(1931), "default.png", "HP Pc", 65000m, false, 0, null },
                    { 7, 1, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(1932), "default.png", "Roman", 45m, true, 0, null },
                    { 8, 3, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(1933), "default.png", "Iphone 16 Pro Max", 99000m, false, 0, null },
                    { 9, 3, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(1935), "default.png", "Iphone 15 Pro Max", 85000m, false, 0, null },
                    { 10, 3, new DateTime(2025, 1, 16, 2, 0, 39, 979, DateTimeKind.Local).AddTicks(1937), "default.png", "Samsung", 65000m, true, 0, null },
                    { 11, 13, new DateTime(2025, 1, 16, 2, 0, 39, 981, DateTimeKind.Local).AddTicks(4020), "default.png", "Tasty Frozen Car", 65404.10m, true, 0, null },
                    { 12, 3, new DateTime(2025, 1, 16, 2, 0, 39, 981, DateTimeKind.Local).AddTicks(4724), "default.png", "Generic Steel Chicken", 22477.45m, false, 0, null },
                    { 13, 3, new DateTime(2025, 1, 16, 2, 0, 39, 981, DateTimeKind.Local).AddTicks(4768), "default.png", "Awesome Steel Soap", 62743.89m, false, 0, null },
                    { 14, 7, new DateTime(2025, 1, 16, 2, 0, 39, 981, DateTimeKind.Local).AddTicks(4795), "default.png", "Fantastic Wooden Pants", 77401.11m, true, 0, null },
                    { 15, 3, new DateTime(2025, 1, 16, 2, 0, 39, 981, DateTimeKind.Local).AddTicks(4893), "default.png", "Refined Frozen Bacon", 75952.55m, true, 0, null },
                    { 16, 2, new DateTime(2025, 1, 16, 2, 0, 39, 981, DateTimeKind.Local).AddTicks(4920), "default.png", "Refined Fresh Soap", 68719.45m, true, 0, null },
                    { 17, 10, new DateTime(2025, 1, 16, 2, 0, 39, 981, DateTimeKind.Local).AddTicks(4946), "default.png", "Awesome Granite Shirt", 26964.25m, true, 0, null },
                    { 18, 7, new DateTime(2025, 1, 16, 2, 0, 39, 981, DateTimeKind.Local).AddTicks(4972), "default.png", "Handcrafted Cotton Shirt", 43962.45m, false, 0, null },
                    { 19, 8, new DateTime(2025, 1, 16, 2, 0, 39, 981, DateTimeKind.Local).AddTicks(4999), "default.png", "Tasty Soft Cheese", 82596.75m, false, 0, null },
                    { 20, 3, new DateTime(2025, 1, 16, 2, 0, 39, 981, DateTimeKind.Local).AddTicks(5027), "default.png", "Tasty Concrete Sausages", 78849.71m, false, 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
