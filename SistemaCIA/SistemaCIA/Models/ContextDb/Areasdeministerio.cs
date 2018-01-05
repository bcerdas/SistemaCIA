using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Areasdeministerio
    {
        public Areasdeministerio()
        {
            Personas = new HashSet<Personas>();
        }

        public int CodigoArea { get; set; }
        public int CodigoMinisterio { get; set; }
        public string Nombre { get; set; }
        public string Objetivo { get; set; }
        public int? CantMiembros { get; set; }

        public Ministerios CodigoMinisterioNavigation { get; set; }
        public ICollection<Personas> Personas { get; set; }
    }
}
