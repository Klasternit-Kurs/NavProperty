using Microsoft.EntityFrameworkCore.Migrations;

namespace NavProperty.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisniks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisniks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Adresas",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Ulica = table.Column<string>(nullable: true),
                    Broj = table.Column<string>(nullable: true),
                    KorisnikID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Adresas_Korisniks_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisniks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresas_KorisnikID",
                table: "Adresas",
                column: "KorisnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresas");

            migrationBuilder.DropTable(
                name: "Korisniks");
        }
    }
}
