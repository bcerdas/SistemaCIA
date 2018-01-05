using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Reencuentros
    {
        public Reencuentros()
        {
            Reencuentrosmatricula = new HashSet<Reencuentrosmatricula>();
        }

        public int CodigoReencuentro { get; set; }
        public string Nombre { get; set; }
        public string Lema { get; set; }
        public string Objetivo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int? Asistencia { get; set; }

        public ICollection<Reencuentrosmatricula> Reencuentrosmatricula { get; set; }
    }
}
