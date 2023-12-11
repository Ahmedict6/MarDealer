using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentItems_Products_RefreneceNumber",
                table: "DocumentItems");

            migrationBuilder.DropIndex(
                name: "IX_DocumentItems_RefreneceNumber",
                table: "DocumentItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DocumentItems_RefreneceNumber",
                table: "DocumentItems",
                column: "RefreneceNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentItems_Products_RefreneceNumber",
                table: "DocumentItems",
                column: "RefreneceNumber",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
