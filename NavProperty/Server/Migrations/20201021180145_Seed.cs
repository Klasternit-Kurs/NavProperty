using Microsoft.EntityFrameworkCore.Migrations;

namespace NavProperty.Server.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresas_Korisniks_KorisnikID",
                table: "Adresas");

            migrationBuilder.DropIndex(
                name: "IX_Adresas_KorisnikID",
                table: "Adresas");

            migrationBuilder.DropColumn(
                name: "KorisnikID",
                table: "Adresas");

            migrationBuilder.AddColumn<int>(
                name: "Korisnik_FK",
                table: "Adresas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Korisniks",
                columns: new[] { "ID", "Ime", "Prezime" },
                values: new object[] { -1, "Pera", "Peric" });

            migrationBuilder.InsertData(
                table: "Korisniks",
                columns: new[] { "ID", "Ime", "Prezime" },
                values: new object[] { -2, "Neko", "Nekic" });

            migrationBuilder.InsertData(
                table: "Adresas",
                columns: new[] { "ID", "Broj", "Korisnik_FK", "Ulica" },
                values: new object[] { "a", "123", -1, "abc" });

            migrationBuilder.InsertData(
                table: "Adresas",
                columns: new[] { "ID", "Broj", "Korisnik_FK", "Ulica" },
                values: new object[] { "b", "321", -1, "qwe" });

            migrationBuilder.InsertData(
                table: "Adresas",
                columns: new[] { "ID", "Broj", "Korisnik_FK", "Ulica" },
                values: new object[] { "c", "765", -2, "zxc" });

            migrationBuilder.CreateIndex(
                name: "IX_Adresas_Korisnik_FK",
                table: "Adresas",
                column: "Korisnik_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresas_Korisniks_Korisnik_FK",
                table: "Adresas",
                column: "Korisnik_FK",
                principalTable: "Korisniks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresas_Korisniks_Korisnik_FK",
                table: "Adresas");

            migrationBuilder.DropIndex(
                name: "IX_Adresas_Korisnik_FK",
                table: "Adresas");

            migrationBuilder.DeleteData(
                table: "Adresas",
                keyColumn: "ID",
                keyValue: "a");

            migrationBuilder.DeleteData(
                table: "Adresas",
                keyColumn: "ID",
                keyValue: "b");

            migrationBuilder.DeleteData(
                table: "Adresas",
                keyColumn: "ID",
                keyValue: "c");

            migrationBuilder.DeleteData(
                table: "Korisniks",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Korisniks",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "Korisnik_FK",
                table: "Adresas");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikID",
                table: "Adresas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adresas_KorisnikID",
                table: "Adresas",
                column: "KorisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresas_Korisniks_KorisnikID",
                table: "Adresas",
                column: "KorisnikID",
                principalTable: "Korisniks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
