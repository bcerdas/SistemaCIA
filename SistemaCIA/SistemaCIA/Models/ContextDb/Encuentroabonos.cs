using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Encuentroabonos
    {
        public int CodigoEncuentroAbonos { get; set; }
        public int CodigoEncMatricula { get; set; }
        public DateTime Fecha { get; set; }
        public int Abono { get; set; }

        public Encuentrosmatricula CodigoEncMatriculaNavigation { get; set; }
    }
}
