using Microsoft.EntityFrameworkCore.Migrations;

namespace NavProperty.Server.Migrations
{
    public partial class MoreSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Korisniks",
                columns: new[] { "ID", "Ime", "Prezime" },
                values: new object[] { -3, "Asd", "Dsa" });

            migrationBuilder.InsertData(
                table: "Korisniks",
                columns: new[] { "ID", "Ime", "Prezime" },
                values: new object[] { -4, "Qwe", "Ewq" });

            migrationBuilder.InsertData(
                table: "Adresas",
                columns: new[] { "ID", "Broj", "Korisnik_FK", "Ulica" },
                values: new object[] { "d", "56756", -3, "jftj" });

            migrationBuilder.InsertData(
                table: "Adresas",
                columns: new[] { "ID", "Broj", "Korisnik_FK", "Ulica" },
                values: new object[] { "e", "5656yu", -4, "yukyuk" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Adresas",
                keyColumn: "ID",
                keyValue: "d");

            migrationBuilder.DeleteData(
                table: "Adresas",
                keyColumn: "ID",
                keyValue: "e");

            migrationBuilder.DeleteData(
                table: "Korisniks",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Korisniks",
                keyColumn: "ID",
                keyValue: -3);
        }
    }
}
