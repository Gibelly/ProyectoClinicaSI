using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoClinica.Models
{
    public class UserType
    {
        [Key]
      
        public int UserTypeId { get; set; }

        [StringLength(30, ErrorMessage = "el maximo es de 30 caracteres")]
        [Display(Name = "Tipo de Usuario")]
        public string Type { get; set; }

        public IEnumerable<Login> Logins { get; set; }
    }
}
