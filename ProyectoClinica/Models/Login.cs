using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoClinica.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Apellidos")]
        public string Lastname { get; set; }

        [DisplayName("Nombre de Usuario")]
        public string User { get; set; }

        [Display(Name = "Tipo de Usuario")]
        public int UserTypeId { get; set; }

        [Display(Name = "Tipo de Usuario")]

        [ForeignKey("UserTypeId")]
        public UserType Type { get; set; }


        [DisplayName("Tipo Usuario")]
        public string TypeUser { get; set; }
      
        [DisplayName("Contraseña")]
        public string Password { get; set; }
    }
}
