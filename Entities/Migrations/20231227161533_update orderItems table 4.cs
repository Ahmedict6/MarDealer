using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class updateorderItemstable4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderAdressMobile",
                table: "Orders",
                newName: "OrderAddressMobile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderAddressMobile",
                table: "Orders",
                newName: "OrderAdressMobile");
        }
    }
}
