using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Procesoox3
    {
        public Procesoox3()
        {
            Procesoox3personas = new HashSet<Procesoox3personas>();
        }

        public int CodigoProcesoOx3 { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int CantOrando { get; set; }
        public int? TotalConvertidos { get; set; }

        public ICollection<Procesoox3personas> Procesoox3personas { get; set; }
    }
}
