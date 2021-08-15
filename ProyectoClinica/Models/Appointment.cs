using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoClinica.Models
{
    public class Appointment
    {
        [Key]
        public int IdAppointment { get; set; }

        [DisplayName("Fecha Cita")]
        public DateTime DateAppo { get; set; }

        public int PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public Patient Patient { get; set; }

    }
}
