using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreMoryatools.DataAccess.Migrations
{
    public partial class addbankmaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bankmaster",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bankname = table.Column<string>(nullable: false),
                    bankifsccode = table.Column<string>(nullable: true),
                    bankbranch = table.Column<string>(nullable: true),
                    accountno = table.Column<string>(nullable: true),
                    accountholdername = table.Column<int>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankmaster", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bankmaster");
        }
    }
}
