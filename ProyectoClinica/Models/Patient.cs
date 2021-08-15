using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoClinica.Models
{
    public class Patient
    {
        [Key]
        public int IdPaciente { get; set; }

        [DisplayName("Nombres")]
        [Required(ErrorMessage ="El nombre del paciente es obligatorio")]
        [StringLength(70,ErrorMessage ="No debe tener mas de 70 carácteres")]
        [MinLength(2, ErrorMessage = "No debe tener menos de 2 carácteres")]
        public string Name { get; set; }

        [DisplayName("Apellidos")]
        [Required(ErrorMessage = "El apellido del paciente es obligatorio")]
        [StringLength(70, ErrorMessage = "No debe tener mas de 70 carácteres")]
        [MinLength(2, ErrorMessage = "No debe tener menos de 2 carácteres")]
        public string LastName { get; set; }

        [DisplayName("Edad")]
        [Required(ErrorMessage = "La edad del paciente es obligatoria")]
        public int Age { get; set; }

        [DisplayName("Género")]
        public string Gender { get; set; }

        [DisplayName("Dirección")]
        public string Direction { get; set; }

        [DisplayName("Celular")]
        [Required(ErrorMessage = "El télefono del paciente es obligatorio")]
        [StringLength(40, ErrorMessage = "No debe tener mas de 40 carácteres")]
        [MinLength(2, ErrorMessage = "No debe tener menos de 2 carácteres")]
        public string Cel { get; set; }


        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Diagnosis> Diagnoses { get; set; }
    }
}
