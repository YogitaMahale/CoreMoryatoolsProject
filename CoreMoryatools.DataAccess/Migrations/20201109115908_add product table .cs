using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreMoryatools.DataAccess.Migrations
{
    public partial class addproducttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cid = table.Column<int>(nullable: false),
                    productname = table.Column<string>(nullable: false),
                    mainimage = table.Column<string>(nullable: true),
                    HSNCode = table.Column<string>(nullable: true),
                    sku = table.Column<string>(nullable: true),
                    customerprice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    dealerprice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    wholesaleprice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    superwholesaleprice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    discountprice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    shortdescp = table.Column<string>(nullable: true),
                    longdescp = table.Column<string>(nullable: true),
                    gst = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    LandingPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    alertquantites = table.Column<int>(nullable: false),
                    quantites = table.Column<int>(nullable: false),
                    RealStock = table.Column<int>(nullable: false),
                    seqno = table.Column<int>(nullable: false),
                    video1 = table.Column<string>(nullable: true),
                    video2 = table.Column<string>(nullable: true),
                    video3 = table.Column<string>(nullable: true),
                    video4 = table.Column<string>(nullable: true),
                    video_name_1 = table.Column<string>(nullable: true),
                    video_name_2 = table.Column<string>(nullable: true),
                    video_name_3 = table.Column<string>(nullable: true),
                    video_name_4 = table.Column<string>(nullable: true),
                    createddate = table.Column<DateTime>(nullable: false),
                    modifieddate = table.Column<DateTime>(nullable: false),
                    isstock = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false),
                    isdelete = table.Column<bool>(nullable: false),
                    isHotproduct = table.Column<bool>(nullable: false),
                    isNewArrivalProduct = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_Category_cid",
                        column: x => x.cid,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_cid",
                table: "product",
                column: "cid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
