using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class addordermodule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exporters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNo = table.Column<int>(type: "int", nullable: false),
                    ExporterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportPercentage = table.Column<int>(type: "int", nullable: false),
                    FrightPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SocialInsuracePrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoundationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exporters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exporters_Users_UserNo",
                        column: x => x.UserNo,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LookupData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LookupDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LookupType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PaymentTypeCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentTypeModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOrderAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNo = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrderAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrderAddresses_Users_UserNo",
                        column: x => x.UserNo,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exporters_UserNo",
                table: "Exporters",
                column: "UserNo");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderAddresses_UserNo",
                table: "UserOrderAddresses",
                column: "UserNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exporters");

            migrationBuilder.DropTable(
                name: "LookupData");

            migrationBuilder.DropTable(
                name: "UserOrderAddresses");
        }
    }
}
