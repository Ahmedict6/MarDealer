using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class updateorderItemstable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentTypeNo",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ReceiverName",
                table: "Orders",
                newName: "OrderReceiverName");

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "Orders",
                newName: "OrderAdressMobile");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Orders",
                newName: "OrderAddress");

            migrationBuilder.AddColumn<string>(
                name: "ExporterName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ExporterPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PaymentType",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExporterName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ExporterPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderReceiverName",
                table: "Orders",
                newName: "ReceiverName");

            migrationBuilder.RenameColumn(
                name: "OrderAdressMobile",
                table: "Orders",
                newName: "Mobile");

            migrationBuilder.RenameColumn(
                name: "OrderAddress",
                table: "Orders",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeNo",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
