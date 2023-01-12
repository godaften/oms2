using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMS.Plugins.EFCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddnullableforLejerIDinMedarbejde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medarbejdere_Lejere_LejerID",
                table: "Medarbejdere");

            migrationBuilder.AlterColumn<int>(
                name: "LejerID",
                table: "Medarbejdere",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Medarbejdere",
                keyColumn: "MedarbejderID",
                keyValue: 1,
                column: "LejerID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Medarbejdere",
                keyColumn: "MedarbejderID",
                keyValue: 2,
                column: "LejerID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Medarbejdere",
                keyColumn: "MedarbejderID",
                keyValue: 3,
                column: "LejerID",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Medarbejdere_Lejere_LejerID",
                table: "Medarbejdere",
                column: "LejerID",
                principalTable: "Lejere",
                principalColumn: "LejerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medarbejdere_Lejere_LejerID",
                table: "Medarbejdere");

            migrationBuilder.AlterColumn<int>(
                name: "LejerID",
                table: "Medarbejdere",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Medarbejdere_Lejere_LejerID",
                table: "Medarbejdere",
                column: "LejerID",
                principalTable: "Lejere",
                principalColumn: "LejerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
