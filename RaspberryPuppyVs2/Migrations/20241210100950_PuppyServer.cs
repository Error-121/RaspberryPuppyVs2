using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaspberryPuppyVs2.Migrations
{
    /// <inheritdoc />
    public partial class PuppyServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personalities",
                columns: table => new
                {
                    TagNr = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Race = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Temperament = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personalities", x => x.TagNr);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagNr = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Temperature = table.Column<int>(type: "int", nullable: false),
                    TimeOutside = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Personalities_TagNr",
                        column: x => x.TagNr,
                        principalTable: "Personalities",
                        principalColumn: "TagNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TagNr",
                table: "Trips",
                column: "TagNr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Personalities");
        }
    }
}
