using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoClinica.Models
{
    public class Diagnosis
    {
        [Key]
        public int IdDiagnosis { get; set; }

        [DisplayName("Síntomas")]
        [Required(ErrorMessage = "Agregrar los Sintomas es obligatorio")]       
        [MinLength(2, ErrorMessage = "No debe tener menos de 2 carácteres")]
        public string Symptoms { get; set; }

        [DisplayName("Exámenes")]
        [MinLength(2, ErrorMessage = "No debe tener menos de 2 carácteres")]
        public string Exams { get; set; }

        [DisplayName("Prescripción Médica")]
        [StringLength(70, ErrorMessage = "No debe tener mas de 40 carácteres")]
        [MinLength(2, ErrorMessage = "No debe tener menos de 2 carácteres")]
        public string Prescription { get; set; }

        public int PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public Patient Patient { get; set; }


    }
}
