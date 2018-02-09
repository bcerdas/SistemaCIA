using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Procesoox3informer5
    {
        public int CodigoProcesoOx3InformeR5 { get; set; }
        public int CodigoProcesoOx3Personas { get; set; }
        public int Asistencia { get; set; }
        public int Convertidos { get; set; }
        public int Visitas { get; set; }
        public int Ofrenda { get; set; }
        public int Observaciones { get; set; }

        public Procesoox3personasorando CodigoProcesoOx3PersonasNavigation { get; set; }
    }
}
