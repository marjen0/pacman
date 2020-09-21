using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class CreatePlayerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ghosts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    xCoordinate = table.Column<int>(nullable: false),
                    yCoordinate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ghosts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    Lives = table.Column<int>(nullable: false),
                    xCoordinate = table.Column<int>(nullable: false),
                    yCoordinate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ghosts");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
