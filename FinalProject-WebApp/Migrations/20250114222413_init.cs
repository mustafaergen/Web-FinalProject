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
                values: new object[] { 1, new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(3954), "Book", 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "Status" },
                values: new object[] { 2, new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(3963), "Computer", 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "Status" },
                values: new object[] { 3, new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(3964), "Phone", 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "ImageUrl", "Name", "Price", "ShowCase", "Status", "Summary" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4451), "default.png", "Istanbul", 35m, true, 0, null },
                    { 2, 1, new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4456), "default.png", "Fatih", 35m, true, 0, null },
                    { 3, 2, new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4457), "default.png", "Asus Pc", 35000m, false, 0, null },
                    { 4, 2, new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4458), "default.png", "Lenovo Pc", 38000m, true, 0, null },
                    { 5, 2, new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4460), "default.png", "Mac Book", 65000m, true, 0, null },
                    { 6, 2, new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4461), "default.png", "HP Pc", 65000m, false, 0, null },
                    { 7, 1, new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4462), "default.png", "Roman", 45m, true, 0, null },
                    { 8, 3, new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4463), "default.png", "Iphone 16 Pro Max", 99000m, false, 0, null },
                    { 9, 3, new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4464), "default.png", "Iphone 15 Pro Max", 85000m, false, 0, null },
                    { 10, 3, new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4466), "default.png", "Samsung", 65000m, true, 0, null }
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
