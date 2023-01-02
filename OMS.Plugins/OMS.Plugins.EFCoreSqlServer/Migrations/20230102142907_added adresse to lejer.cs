using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMS.Plugins.EFCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class addedadressetolejer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Lejere",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Lejere");
        }
    }
}
