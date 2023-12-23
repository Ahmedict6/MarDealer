using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class updateordertable5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderPaymentNo",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderPaymentNo",
                table: "Orders",
                column: "OrderPaymentNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderPayments_OrderPaymentNo",
                table: "Orders",
                column: "OrderPaymentNo",
                principalTable: "OrderPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderPayments_OrderPaymentNo",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderPaymentNo",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderPaymentNo",
                table: "Orders");
        }
    }
}
