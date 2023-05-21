using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.db.Migrations
{
    public partial class Favorites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_FavoriteProducts_FavoriteProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FavoriteProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FavoriteProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FavoriteProducts");

            migrationBuilder.AddColumn<int>(
                name: "FavoriteId",
                table: "FavoriteProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "FavoriteProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 2210m, "Best tour to Thailand", "Tour to Thailand" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Best tour to India", "Tour to India" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Best tour to Jamaica", "Tour to Jamaica" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Best tour to Seychelles", "Tour to Seychelles" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Best tour to UAE", "Tour to UAE" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Best tour to to Egypt", "Tour to Egypt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Best tour to Bali", "Tour to Bali" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Best tour to Mexico", "Tour to Mexico" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Best tour to Aruba", "Tour to Aruba" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Best tour to Bulgaria", "Tour to Bulgaria" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Best tour to Turkey", "Tour to Turkey" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Best tour to Greece", "Tour to Greece" });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProducts_FavoriteId",
                table: "FavoriteProducts",
                column: "FavoriteId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProducts_ProductId",
                table: "FavoriteProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProducts_Favorites_FavoriteId",
                table: "FavoriteProducts",
                column: "FavoriteId",
                principalTable: "Favorites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProducts_Products_ProductId",
                table: "FavoriteProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProducts_Favorites_FavoriteId",
                table: "FavoriteProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProducts_Products_ProductId",
                table: "FavoriteProducts");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteProducts_FavoriteId",
                table: "FavoriteProducts");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteProducts_ProductId",
                table: "FavoriteProducts");

            migrationBuilder.DropColumn(
                name: "FavoriteId",
                table: "FavoriteProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "FavoriteProducts");

            migrationBuilder.AddColumn<int>(
                name: "FavoriteProductId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FavoriteProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 2100m, "Tour to Thailand", "Best tour to Thailand" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Tour to India", "Best tour to India" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Tour to Jamaica", "Best tour to Jamaica" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Tour to Seychelles", "Best tour to Seychelles" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Tour to UAE", "Best tour to UAE" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Tour to Egypt", "Best tour to Egypt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Tour to Bali", "Best tour to Bali" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Tour to Mexico", "Best tour to Mexico" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Tour to Aruba", "Best tour to Aruba" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Tour to Bulgaria", "Best tour to Bulgaria" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Tour to Тurkey", "Best tour to Turkey" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Tour to Greece", "Best tour to Greece" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FavoriteProductId",
                table: "Products",
                column: "FavoriteProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FavoriteProducts_FavoriteProductId",
                table: "Products",
                column: "FavoriteProductId",
                principalTable: "FavoriteProducts",
                principalColumn: "Id");
        }
    }
}
