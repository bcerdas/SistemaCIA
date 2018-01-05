using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Reencuentroabonos
    {
        public int CodigoReecuentroAbonos { get; set; }
        public int CodigoReMatricula { get; set; }
        public DateTime Fecha { get; set; }
        public int Abono { get; set; }

        public Reencuentrosmatricula CodigoReMatriculaNavigation { get; set; }
    }
}
