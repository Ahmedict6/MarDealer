using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class initialdbsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocuemntName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    RefereneceNumber = table.Column<int>(type: "int", nullable: true),
                    DocuementCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookupValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "OrderPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PyamentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryDescritpion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountDescritpion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercent = table.Column<int>(type: "int", nullable: false),
                    UserNo = table.Column<int>(type: "int", nullable: false),
                    DiscountStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountEnddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDiscounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryDescritpion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InventoryModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPaymentInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNo = table.Column<int>(type: "int", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expiry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PyamentType = table.Column<int>(type: "int", nullable: false),
                    UserCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaymentInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTypeNo = table.Column<int>(type: "int", nullable: false),
                    UserInformationNo = table.Column<int>(type: "int", nullable: false),
                    UserPaymentInformationNo = table.Column<int>(type: "int", nullable: true),
                    UserCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryDescritpion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryNo = table.Column<int>(type: "int", nullable: false),
                    CategoryCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_ProductCategories_CategoryNo",
                        column: x => x.CategoryNo,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNo = table.Column<int>(type: "int", nullable: false),
                    ExporterNo = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserNo",
                        column: x => x.UserNo,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddressInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNo = table.Column<int>(type: "int", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddressInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddressInformations_Users_UserNo",
                        column: x => x.UserNo,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "SubOfSubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryDescritpion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategoryNo = table.Column<int>(type: "int", nullable: false),
                    CategoryCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubOfSubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubOfSubCategory_SubCategory_SubCategoryNo",
                        column: x => x.SubCategoryNo,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescritpion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCategoryNo = table.Column<int>(type: "int", nullable: false),
                    SubCategoryNo = table.Column<int>(type: "int", nullable: false),
                    SubOfSubCategoryNo = table.Column<int>(type: "int", nullable: false),
                    ProductInventoryNo = table.Column<int>(type: "int", nullable: false),
                    ProductDiscountNo = table.Column<int>(type: "int", nullable: false),
                    UserNo = table.Column<int>(type: "int", nullable: false),
                    ProductUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryNo",
                        column: x => x.ProductCategoryNo,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductDiscounts_ProductDiscountNo",
                        column: x => x.ProductDiscountNo,
                        principalTable: "ProductDiscounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductInventories_ProductInventoryNo",
                        column: x => x.ProductInventoryNo,
                        principalTable: "ProductInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_SubCategory_SubCategoryNo",
                        column: x => x.SubCategoryNo,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Products_SubOfSubCategory_SubOfSubCategoryNo",
                        column: x => x.SubOfSubCategoryNo,
                        principalTable: "SubOfSubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    ProductNo = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderItemCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderItemModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderNo",
                        column: x => x.OrderNo,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductNo",
                        column: x => x.ProductNo,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Exporters_UserNo",
                table: "Exporters",
                column: "UserNo");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderNo",
                table: "OrderItems",
                column: "OrderNo");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductNo",
                table: "OrderItems",
                column: "ProductNo");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserNo",
                table: "Orders",
                column: "UserNo");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryNo",
                table: "Products",
                column: "ProductCategoryNo");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductDiscountNo",
                table: "Products",
                column: "ProductDiscountNo");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductInventoryNo",
                table: "Products",
                column: "ProductInventoryNo");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryNo",
                table: "Products",
                column: "SubCategoryNo");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubOfSubCategoryNo",
                table: "Products",
                column: "SubOfSubCategoryNo");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecifications_ProductNo",
                table: "ProductSpecifications",
                column: "ProductNo");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryNo",
                table: "SubCategory",
                column: "CategoryNo");

            migrationBuilder.CreateIndex(
                name: "IX_SubOfSubCategory_SubCategoryNo",
                table: "SubOfSubCategory",
                column: "SubCategoryNo");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddressInformations_UserNo",
                table: "UserAddressInformations",
                column: "UserNo");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderAddresses_UserNo",
                table: "UserOrderAddresses",
                column: "UserNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "DocumentItems");

            migrationBuilder.DropTable(
                name: "Exporters");

            migrationBuilder.DropTable(
                name: "LookupData");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "OrderPayments");

            migrationBuilder.DropTable(
                name: "ProductSpecifications");

            migrationBuilder.DropTable(
                name: "UserAddressInformations");

            migrationBuilder.DropTable(
                name: "UserOrderAddresses");

            migrationBuilder.DropTable(
                name: "UserPaymentInformations");

            migrationBuilder.DropTable(
                name: "UsersComments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProductDiscounts");

            migrationBuilder.DropTable(
                name: "ProductInventories");

            migrationBuilder.DropTable(
                name: "SubOfSubCategory");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
