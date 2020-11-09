using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreMoryatools.DataAccess.Migrations
{
    public partial class addproductimagestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productimages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pid = table.Column<int>(nullable: false),
                    imagename = table.Column<string>(nullable: false),
                    isdelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productimages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productimages_product_pid",
                        column: x => x.pid,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productimages_pid",
                table: "productimages",
                column: "pid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productimages");
        }
    }
}
