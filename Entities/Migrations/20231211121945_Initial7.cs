using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class Initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentItems",
                table: "DocumentItems");

            migrationBuilder.DropColumn(
                name: "GUID",
                table: "DocumentItems");

            migrationBuilder.AddColumn<Guid>(
                name: "ID",
                table: "DocumentItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentItems",
                table: "DocumentItems",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentItems",
                table: "DocumentItems");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "DocumentItems");

            migrationBuilder.AddColumn<int>(
                name: "GUID",
                table: "DocumentItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentItems",
                table: "DocumentItems",
                column: "GUID");
        }
    }
}
