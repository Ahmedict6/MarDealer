using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class updateordermodule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderPayments_PyamentNo",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserType_UserTypeNo",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTypeNo",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PyamentNo",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PyamentNo",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Provider",
                table: "OrderPayments",
                newName: "PyamentDescription");

            migrationBuilder.AddColumn<string>(
                name: "PaymentType",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LookupValue",
                table: "LookupData",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LookupValue",
                table: "LookupData");

            migrationBuilder.RenameColumn(
                name: "PyamentDescription",
                table: "OrderPayments",
                newName: "Provider");

            migrationBuilder.AddColumn<int>(
                name: "PyamentNo",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserTypeDescritpion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTypeModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeNo",
                table: "Users",
                column: "UserTypeNo");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PyamentNo",
                table: "Orders",
                column: "PyamentNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderPayments_PyamentNo",
                table: "Orders",
                column: "PyamentNo",
                principalTable: "OrderPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserType_UserTypeNo",
                table: "Users",
                column: "UserTypeNo",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
