using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Personasroles
    {
        public int CodigoPersonasRoles { get; set; }
        public string CodigoPersona { get; set; }
        public int CodigoRol { get; set; }

        public Personas CodigoPersonaNavigation { get; set; }
        public Roles CodigoRolNavigation { get; set; }
    }
}
