using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCIA.Models.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Ingrese un valor")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Ingrese un valor")]
        public string Clave { get; set; }
    }
}
