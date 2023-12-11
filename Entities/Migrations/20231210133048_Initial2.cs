using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "DocumentItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentItems_ProductId",
                table: "DocumentItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentItems_Products_ProductId",
                table: "DocumentItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentItems_Products_ProductId",
                table: "DocumentItems");

            migrationBuilder.DropIndex(
                name: "IX_DocumentItems_ProductId",
                table: "DocumentItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "DocumentItems");
        }
    }
}
