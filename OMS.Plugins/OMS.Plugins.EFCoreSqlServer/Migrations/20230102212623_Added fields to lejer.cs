using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMS.Plugins.EFCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Addedfieldstolejer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Lejere",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Adresse",
                table: "Lejere",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lokale",
                table: "Lejere",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SMSTelefon",
                table: "Lejere",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Lejere",
                keyColumn: "LejerID",
                keyValue: 1,
                columns: new[] { "Adresse", "Lokale", "SMSTelefon" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Lejere",
                keyColumn: "LejerID",
                keyValue: 2,
                columns: new[] { "Adresse", "Lokale", "SMSTelefon" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Lejere",
                keyColumn: "LejerID",
                keyValue: 3,
                columns: new[] { "Adresse", "Lokale", "SMSTelefon" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Lejere",
                keyColumn: "LejerID",
                keyValue: 4,
                columns: new[] { "Adresse", "Lokale", "SMSTelefon" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Lejere",
                keyColumn: "LejerID",
                keyValue: 5,
                columns: new[] { "Adresse", "Lokale", "SMSTelefon" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Lejere",
                keyColumn: "LejerID",
                keyValue: 6,
                columns: new[] { "Adresse", "Lokale", "SMSTelefon" },
                values: new object[] { "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lokale",
                table: "Lejere");

            migrationBuilder.DropColumn(
                name: "SMSTelefon",
                table: "Lejere");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Lejere",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Adresse",
                table: "Lejere",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Lejere",
                keyColumn: "LejerID",
                keyValue: 1,
                column: "Adresse",
                value: null);

            migrationBuilder.UpdateData(
                table: "Lejere",
                keyColumn: "LejerID",
                keyValue: 2,
                column: "Adresse",
                value: null);

            migrationBuilder.UpdateData(
                table: "Lejere",
                keyColumn: "LejerID",
                keyValue: 3,
                column: "Adresse",
                value: null);

            migrationBuilder.UpdateData(
                table: "Lejere",
                keyColumn: "LejerID",
                keyValue: 4,
                column: "Adresse",
                value: null);

            migrationBuilder.UpdateData(
                table: "Lejere",
                keyColumn: "LejerID",
                keyValue: 5,
                column: "Adresse",
                value: null);

            migrationBuilder.UpdateData(
                table: "Lejere",
                keyColumn: "LejerID",
                keyValue: 6,
                column: "Adresse",
                value: null);
        }
    }
}
