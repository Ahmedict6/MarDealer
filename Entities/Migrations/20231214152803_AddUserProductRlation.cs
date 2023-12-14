using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class AddUserProductRlation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_UserNo",
                table: "Products",
                column: "UserNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserNo",
                table: "Products",
                column: "UserNo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserNo",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserNo",
                table: "Products");
        }
    }
}
