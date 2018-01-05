using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Academiasniveles
    {
        public int CodigoAcademiasNiveles { get; set; }
        public int CodigoAcademias { get; set; }
        public int CodigoNivel { get; set; }

        public Academias CodigoAcademiasNavigation { get; set; }
        public Niveles CodigoNivelNavigation { get; set; }
    }
}
