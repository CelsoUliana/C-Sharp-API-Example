using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C_Sharp_API_Example.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type1 = table.Column<int>(type: "int", nullable: false),
                    Type2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonBattles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pokemon1Id = table.Column<int>(type: "int", nullable: false),
                    Pokemon2Id = table.Column<int>(type: "int", nullable: false),
                    PokemonWinnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonBattles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonBattles_Pokemons_Pokemon1Id",
                        column: x => x.Pokemon1Id,
                        principalTable: "Pokemons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonBattles_Pokemons_Pokemon2Id",
                        column: x => x.Pokemon2Id,
                        principalTable: "Pokemons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonBattles_Pokemons_PokemonWinnerId",
                        column: x => x.PokemonWinnerId,
                        principalTable: "Pokemons",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "Attack", "Defense", "HP", "Name", "Speed", "Type1", "Type2" },
                values: new object[] { 1, 255, 255, 255, "Charizad", 255, 2, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonBattles_Pokemon1Id",
                table: "PokemonBattles",
                column: "Pokemon1Id");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonBattles_Pokemon2Id",
                table: "PokemonBattles",
                column: "Pokemon2Id");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonBattles_PokemonWinnerId",
                table: "PokemonBattles",
                column: "PokemonWinnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonBattles");

            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
