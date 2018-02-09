using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Procesoox3personasorando
    {
        public Procesoox3personasorando()
        {
            Procesoox3informer5 = new HashSet<Procesoox3informer5>();
            Procesoox3informer6 = new HashSet<Procesoox3informer6>();
            Procesoox3personas = new HashSet<Procesoox3personas>();
        }

        public int CodigoProcesoOx3PersonaOrando { get; set; }
        public int CodigoProcesoOx3 { get; set; }
        public string Codigopersona { get; set; }
        public DateTime? R5Fecha { get; set; }
        public string R5Lugar { get; set; }
        public string R5Direccion { get; set; }
        public string R5Hora { get; set; }
        public DateTime? R6Fecha { get; set; }
        public string R6Lugar { get; set; }
        public string R6Direccion { get; set; }
        public string R6Hora { get; set; }

        public Procesoox3 CodigoProcesoOx3Navigation { get; set; }
        public Personas CodigopersonaNavigation { get; set; }
        public ICollection<Procesoox3informer5> Procesoox3informer5 { get; set; }
        public ICollection<Procesoox3informer6> Procesoox3informer6 { get; set; }
        public ICollection<Procesoox3personas> Procesoox3personas { get; set; }
    }
}
