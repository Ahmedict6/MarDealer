using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentTypeModifiedDate",
                table: "LookupData",
                newName: "LookupModifiedDate");

            migrationBuilder.RenameColumn(
                name: "PaymentTypeCreatedDate",
                table: "LookupData",
                newName: "LookupCreatedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LookupModifiedDate",
                table: "LookupData",
                newName: "PaymentTypeModifiedDate");

            migrationBuilder.RenameColumn(
                name: "LookupCreatedDate",
                table: "LookupData",
                newName: "PaymentTypeCreatedDate");
        }
    }
}
