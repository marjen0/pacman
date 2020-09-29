using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacmans",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    xCoordinate = table.Column<int>(nullable: false),
                    yCoordinate = table.Column<int>(nullable: false),
                    currentDirection = table.Column<int>(nullable: false),
                    nextDirection = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacmans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Lives = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacmans");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
