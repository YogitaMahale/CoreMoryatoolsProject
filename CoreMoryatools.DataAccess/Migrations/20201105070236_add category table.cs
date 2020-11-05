using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreMoryatools.DataAccess.Migrations
{
    public partial class addcategorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    img = table.Column<string>(nullable: true),
                    shortdesc = table.Column<string>(nullable: true),
                    longdescp = table.Column<string>(nullable: true),
                    seqno = table.Column<int>(nullable: false),
                    field1 = table.Column<string>(nullable: true),
                    field2 = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
