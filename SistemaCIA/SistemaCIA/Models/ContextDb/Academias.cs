using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Academias
    {
        public Academias()
        {
            Academiasniveles = new HashSet<Academiasniveles>();
        }

        public int CodigoAcademias { get; set; }
        public DateTime Fecha { get; set; }
        public int? CantNiveles { get; set; }
        public int? Asistencia { get; set; }
        public int? MontoIngreso { get; set; }
        public int? MontoSalida { get; set; }
        public int? Total { get; set; }

        public ICollection<Academiasniveles> Academiasniveles { get; set; }
    }
}
