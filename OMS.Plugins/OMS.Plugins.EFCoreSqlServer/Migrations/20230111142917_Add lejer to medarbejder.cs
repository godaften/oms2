using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMS.Plugins.EFCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Addlejertomedarbejder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LejerID",
                table: "Medarbejdere",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Lejere",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "SMSTelefon",
                table: "Lejere",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.UpdateData(
                table: "Medarbejdere",
                keyColumn: "MedarbejderID",
                keyValue: 1,
                column: "LejerID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medarbejdere",
                keyColumn: "MedarbejderID",
                keyValue: 2,
                column: "LejerID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medarbejdere",
                keyColumn: "MedarbejderID",
                keyValue: 3,
                column: "LejerID",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Medarbejdere_LejerID",
                table: "Medarbejdere",
                column: "LejerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medarbejdere_Lejere_LejerID",
                table: "Medarbejdere",
                column: "LejerID",
                principalTable: "Lejere",
                principalColumn: "LejerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medarbejdere_Lejere_LejerID",
                table: "Medarbejdere");

            migrationBuilder.DropIndex(
                name: "IX_Medarbejdere_LejerID",
                table: "Medarbejdere");

            migrationBuilder.DropColumn(
                name: "LejerID",
                table: "Medarbejdere");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Lejere",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SMSTelefon",
                table: "Lejere",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
