using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class updateordertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PyamentType",
                table: "UserPaymentInformations");

            migrationBuilder.RenameColumn(
                name: "PaymentType",
                table: "Orders",
                newName: "ReceiverName");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Expiry",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeNo",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Expiry",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentTypeNo",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ReceiverName",
                table: "Orders",
                newName: "PaymentType");

            migrationBuilder.AddColumn<int>(
                name: "PyamentType",
                table: "UserPaymentInformations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
