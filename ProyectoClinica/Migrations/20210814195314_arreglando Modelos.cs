using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoClinica.Migrations
{
    public partial class arreglandoModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Patients_PacienteId",
                table: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_PacienteId",
                table: "Diagnoses");

            migrationBuilder.AddColumn<int>(
                name: "IdPaciente",
                table: "Diagnoses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_IdPaciente",
                table: "Diagnoses",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Patients_IdPaciente",
                table: "Diagnoses",
                column: "IdPaciente",
                principalTable: "Patients",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Patients_IdPaciente",
                table: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_IdPaciente",
                table: "Diagnoses");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "Diagnoses");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_PacienteId",
                table: "Diagnoses",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Patients_PacienteId",
                table: "Diagnoses",
                column: "PacienteId",
                principalTable: "Patients",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
