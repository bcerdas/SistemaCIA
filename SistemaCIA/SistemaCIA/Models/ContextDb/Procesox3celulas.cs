using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Procesox3celulas
    {
        public Procesox3celulas()
        {
            Procesoox3informer5 = new HashSet<Procesoox3informer5>();
            Procesoox3informer6 = new HashSet<Procesoox3informer6>();
            Procesoox3personasorando = new HashSet<Procesoox3personasorando>();
        }

        public int CodigoProcesoX3celula { get; set; }
        public string CodigoCelula { get; set; }
        public int CodigoProcesoX3 { get; set; }
        public int CantidadPersonasOrando { get; set; }

        public Celulas CodigoCelulaNavigation { get; set; }
        public Procesoox3 CodigoProcesoX3Navigation { get; set; }
        public ICollection<Procesoox3informer5> Procesoox3informer5 { get; set; }
        public ICollection<Procesoox3informer6> Procesoox3informer6 { get; set; }
        public ICollection<Procesoox3personasorando> Procesoox3personasorando { get; set; }
    }
}
