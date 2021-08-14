using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoClinica.Migrations
{
    public partial class ModeloDiagnostico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    IdDiagnosis = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exams = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prescription = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.IdDiagnosis);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Patients_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Patients",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_PacienteId",
                table: "Diagnoses",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnoses");
        }
    }
}
