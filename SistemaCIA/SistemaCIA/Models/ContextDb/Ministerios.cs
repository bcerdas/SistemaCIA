using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Ministerios
    {
        public Ministerios()
        {
            Areasdeministerio = new HashSet<Areasdeministerio>();
            Personas = new HashSet<Personas>();
            Roles = new HashSet<Roles>();
        }

        public int CodigoMinisterio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? CantMiembros { get; set; }

        public ICollection<Areasdeministerio> Areasdeministerio { get; set; }
        public ICollection<Personas> Personas { get; set; }
        public ICollection<Roles> Roles { get; set; }
    }
}
