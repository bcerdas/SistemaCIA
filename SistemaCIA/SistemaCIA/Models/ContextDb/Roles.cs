using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Roles
    {
        public Roles()
        {
            Personasroles = new HashSet<Personasroles>();
        }

        public int CodigoRol { get; set; }
        public int CodigoMinisterio { get; set; }
        public string Nombre { get; set; }
        public string Descrpcion { get; set; }

        public Ministerios CodigoMinisterioNavigation { get; set; }
        public ICollection<Personasroles> Personasroles { get; set; }
    }
}
