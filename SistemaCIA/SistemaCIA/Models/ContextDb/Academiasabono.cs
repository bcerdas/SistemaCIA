using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Academiasabono
    {
        public int CodigoAcademiaAbono { get; set; }
        public int CodigoAcademiasMatricula { get; set; }
        public int Abono { get; set; }
        public DateTime Fecha { get; set; }

        public Academiasmatriculas CodigoAcademiasMatriculaNavigation { get; set; }
    }
}
