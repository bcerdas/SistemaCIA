using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Procesoox3
    {
        public Procesoox3()
        {
            Procesoox3personasorando = new HashSet<Procesoox3personasorando>();
            Procesox3celulas = new HashSet<Procesox3celulas>();
        }

        public int CodigoProcesoOx3 { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int CantOrando { get; set; }
        public int? TotalConvertidos { get; set; }
        public string Nombre { get; set; }
        public bool AperturaDeCelulas { get; set; }

        public ICollection<Procesoox3personasorando> Procesoox3personasorando { get; set; }
        public ICollection<Procesox3celulas> Procesox3celulas { get; set; }
    }
}
