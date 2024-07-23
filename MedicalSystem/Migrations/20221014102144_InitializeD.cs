using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalSystem.Migrations
{
    public partial class InitializeD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_MedicSpecialities_Specialiteid",
                schema: "DC",
                table: "Doctors");

            migrationBuilder.AlterColumn<string>(
                name: "imageUser",
                schema: "DC",
                table: "Doctors",
                type: "varchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<int>(
                name: "Specialiteid",
                schema: "DC",
                table: "Doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_MedicSpecialities_Specialiteid",
                schema: "DC",
                table: "Doctors",
                column: "Specialiteid",
                principalSchema: "DC",
                principalTable: "MedicSpecialities",
                principalColumn: "specId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_MedicSpecialities_Specialiteid",
                schema: "DC",
                table: "Doctors");

            migrationBuilder.AlterColumn<string>(
                name: "imageUser",
                schema: "DC",
                table: "Doctors",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Specialiteid",
                schema: "DC",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_MedicSpecialities_Specialiteid",
                schema: "DC",
                table: "Doctors",
                column: "Specialiteid",
                principalSchema: "DC",
                principalTable: "MedicSpecialities",
                principalColumn: "specId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
