using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Usuarios
    {
        public string Usuario { get; set; }
        public string CodigoPersona { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string CodigoRecuperacion { get; set; }
        public string CorreoSeguridad { get; set; }

        public Personas CodigoPersonaNavigation { get; set; }
    }
}
