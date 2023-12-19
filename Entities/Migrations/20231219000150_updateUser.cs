using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class updateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSpecifications_Products_ProductNo",
                table: "ProductSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_ProductSpecifications_ProductNo",
                table: "ProductSpecifications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecifications_ProductNo",
                table: "ProductSpecifications",
                column: "ProductNo");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSpecifications_Products_ProductNo",
                table: "ProductSpecifications",
                column: "ProductNo",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
