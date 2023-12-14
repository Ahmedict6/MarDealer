using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class AddCommenttbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNo = table.Column<int>(type: "int", nullable: false),
                    SpecificationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificationDescritpion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSpecifications_Products_ProductNo",
                        column: x => x.ProductNo,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentReviewStars = table.Column<int>(type: "int", nullable: false),
                    UserNo = table.Column<int>(type: "int", nullable: false),
                    CommentType = table.Column<int>(type: "int", nullable: false),
                    RefranceNumber = table.Column<int>(type: "int", nullable: false),
                    CommentCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersComments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecifications_ProductNo",
                table: "ProductSpecifications",
                column: "ProductNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSpecifications");

            migrationBuilder.DropTable(
                name: "UsersComments");
        }
    }
}
