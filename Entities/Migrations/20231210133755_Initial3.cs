using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "RefreneceNumber",
                table: "DocumentItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocumentType",
                table: "DocumentItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentItems_Products_RefreneceNumber",
                table: "DocumentItems");

            migrationBuilder.DropIndex(
                name: "IX_DocumentItems_RefreneceNumber",
                table: "DocumentItems");

            migrationBuilder.AlterColumn<string>(
                name: "RefreneceNumber",
                table: "DocumentItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentType",
                table: "DocumentItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
