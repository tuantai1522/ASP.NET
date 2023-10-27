using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class cloneDataProductsAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "DisplayOrder" },
                values: new object[,]
                {
                    { 1, "Áo nam", 1 },
                    { 2, "Áo nữ", 2 },
                    { 3, "Quần nam", 3 },
                    { 4, "Quần nữ", 4 },
                    { 5, "Giày nam", 5 },
                    { 6, "Giày nữ", 6 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "Description", "ListPrice", "Price", "Price100", "Price50", "ProductName" },
                values: new object[,]
                {
                    { 1, 1, "Áo thun nam trắng", 40.0, 40.0, 30.0, 35.0, "Áo T-Shirt Together" },
                    { 2, 1, "Áo thun nam trắng", 80.0, 80.0, 70.0, 75.0, "Áo phông SandBoxWrangler" },
                    { 3, 1, "Áo thun nam xanh", 95.0, 95.0, 85.0, 90.0, "Áo Polo Cotton" },
                    { 4, 1, "Áo thun nam xanh", 20.0, 20.0, 10.0, 15.0, "Áo phông oversize" },
                    { 5, 1, "Áo thun nam hồng", 100.0, 100.0, 90.0, 95.0, "Áo phông in hình sao biển" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);
        }
    }
}
