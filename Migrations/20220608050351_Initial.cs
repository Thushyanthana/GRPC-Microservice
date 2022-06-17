using Microsoft.EntityFrameworkCore.Migrations;

namespace userGRPC.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameWithInitail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark1 = table.Column<double>(type: "float", nullable: false),
                    Mark2 = table.Column<double>(type: "float", nullable: false),
                    Mark3 = table.Column<double>(type: "float", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
