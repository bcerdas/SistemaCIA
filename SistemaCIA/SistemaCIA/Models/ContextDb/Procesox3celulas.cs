using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Procesox3celulas
    {
        public int CodigoProcesoX3celula { get; set; }
        public string CodigoCelula { get; set; }
        public int CodigoProcesoX3 { get; set; }
        public int CantidadPersonasOrando { get; set; }

        public Celulas CodigoCelulaNavigation { get; set; }
        public Procesoox3 CodigoProcesoX3Navigation { get; set; }
    }
}
