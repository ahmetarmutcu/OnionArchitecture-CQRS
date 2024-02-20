using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnionArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priorty = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDateTime", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 20, 15, 45, 21, 516, DateTimeKind.Local).AddTicks(3227), "Sports" },
                    { 2, new DateTime(2024, 2, 20, 15, 45, 21, 516, DateTimeKind.Local).AddTicks(3235), "Clothing" },
                    { 3, new DateTime(2024, 2, 20, 15, 45, 21, 516, DateTimeKind.Local).AddTicks(3286), "Computers, Garden & Toys" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDateTime", "Name", "ParentId", "Priorty" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 20, 15, 45, 21, 516, DateTimeKind.Local).AddTicks(5911), "Elektrik", 0, 1 },
                    { 2, new DateTime(2024, 2, 20, 15, 45, 21, 516, DateTimeKind.Local).AddTicks(5912), "Moda", 0, 2 },
                    { 3, new DateTime(2024, 2, 20, 15, 45, 21, 516, DateTimeKind.Local).AddTicks(5914), "Bilgisayar", 1, 1 },
                    { 4, new DateTime(2024, 2, 20, 15, 45, 21, 516, DateTimeKind.Local).AddTicks(5915), "Kadın", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 20, 15, 45, 21, 518, DateTimeKind.Local).AddTicks(3030), "Doloremque çarpan umut ötekinden nostrum.", "Sokaklarda." },
                    { 2, 3, new DateTime(2024, 2, 20, 15, 45, 21, 518, DateTimeKind.Local).AddTicks(3066), "Çıktılar et incidunt aut tempora.", "Karşıdakine domates." },
                    { 3, 4, new DateTime(2024, 2, 20, 15, 45, 21, 518, DateTimeKind.Local).AddTicks(3097), "Çünkü reprehenderit perferendis aliquam kulu.", "Quasi." }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedDateTime", "Description", "Discount", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 20, 15, 45, 21, 520, DateTimeKind.Local).AddTicks(4897), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 4.961950698502630m, 691.03m, "Gorgeous Rubber Fish" },
                    { 2, 3, new DateTime(2024, 2, 20, 15, 45, 21, 520, DateTimeKind.Local).AddTicks(4927), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 6.556671728501220m, 71.59m, "Small Cotton Chicken" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                table: "Details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
