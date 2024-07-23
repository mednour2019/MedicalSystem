using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalSystem.Migrations
{
    public partial class InitializeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DC");

            migrationBuilder.CreateTable(
                name: "MedicSpecialities",
                schema: "DC",
                columns: table => new
                {
                    specId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    specName = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicSpecialities", x => x.specId);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                schema: "DC",
                columns: table => new
                {
                    doctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "varchar(200)", nullable: false),
                    imageUser = table.Column<string>(type: "varchar(250)", nullable: false),
                    sexe = table.Column<string>(type: "varchar(200)", nullable: false),
                    age = table.Column<string>(type: "varchar(200)", nullable: false),
                    birthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cin = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Specialiteid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.doctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_MedicSpecialities_Specialiteid",
                        column: x => x.Specialiteid,
                        principalSchema: "DC",
                        principalTable: "MedicSpecialities",
                        principalColumn: "specId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Specialiteid",
                schema: "DC",
                table: "Doctors",
                column: "Specialiteid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "DC");

            migrationBuilder.DropTable(
                name: "MedicSpecialities",
                schema: "DC");
        }
    }
}
