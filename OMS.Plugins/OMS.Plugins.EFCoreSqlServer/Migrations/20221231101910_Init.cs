using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OMS.Plugins.EFCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontorhuse",
                columns: table => new
                {
                    KontorhusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KontorhusNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KontorhusTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KontorhusEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontorhuse", x => x.KontorhusID);
                });

            migrationBuilder.CreateTable(
                name: "Lejere",
                columns: table => new
                {
                    LejerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lejere", x => x.LejerID);
                });

            migrationBuilder.CreateTable(
                name: "Medarbejdere",
                columns: table => new
                {
                    MedarbejderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medarbejdere", x => x.MedarbejderID);
                });

            migrationBuilder.CreateTable(
                name: "KontorhusLejere",
                columns: table => new
                {
                    KontorhusID = table.Column<int>(type: "int", nullable: false),
                    LejerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KontorhusLejere", x => new { x.KontorhusID, x.LejerID });
                    table.ForeignKey(
                        name: "FK_KontorhusLejere_Kontorhuse_KontorhusID",
                        column: x => x.KontorhusID,
                        principalTable: "Kontorhuse",
                        principalColumn: "KontorhusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KontorhusLejere_Lejere_LejerID",
                        column: x => x.LejerID,
                        principalTable: "Lejere",
                        principalColumn: "LejerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kontorhuse",
                columns: new[] { "KontorhusID", "KontorhusEmail", "KontorhusNavn", "KontorhusTelefon" },
                values: new object[,]
                {
                    { 1, "johnny@mail.dk", "BusinessHouse", "12141516" },
                    { 2, "johnny@mail.dk", "HappyHouse", "33341516" }
                });

            migrationBuilder.InsertData(
                table: "Lejere",
                columns: new[] { "LejerID", "Email", "Navn", "Telefon" },
                values: new object[,]
                {
                    { 1, "minmail1@email.dk", "Askov", "12131415" },
                    { 2, "minmail2@email.dk", "Transportfirmaet", "23242526" },
                    { 3, "minmail3@email.dk", "Tolkemanden", "34353637" },
                    { 4, "minmail14@email.dk", "Larsen", "4531415" },
                    { 5, "minmail5@email.dk", "Petersen Business A/S", "53242526" },
                    { 6, "minmail6@email.dk", "Jensens Super Service ApS", "64353637" }
                });

            migrationBuilder.InsertData(
                table: "Medarbejdere",
                columns: new[] { "MedarbejderID", "Email", "Navn", "Telefon" },
                values: new object[,]
                {
                    { 1, "lars@test.dk", "Lars", "12131415" },
                    { 2, "kurt@test.dk", "Kurt", "13131415" },
                    { 3, "hans@test.dk", "Hans", "14131415" }
                });

            migrationBuilder.InsertData(
                table: "KontorhusLejere",
                columns: new[] { "KontorhusID", "LejerID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_KontorhusLejere_LejerID",
                table: "KontorhusLejere",
                column: "LejerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KontorhusLejere");

            migrationBuilder.DropTable(
                name: "Medarbejdere");

            migrationBuilder.DropTable(
                name: "Kontorhuse");

            migrationBuilder.DropTable(
                name: "Lejere");
        }
    }
}
