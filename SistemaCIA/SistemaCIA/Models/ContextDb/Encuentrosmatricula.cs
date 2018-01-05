using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Encuentrosmatricula
    {
        public Encuentrosmatricula()
        {
            Encuentroabonos = new HashSet<Encuentroabonos>();
        }

        public int CodigoEncMatricula { get; set; }
        public int CodigoEncuentro { get; set; }
        public string CodigoPersona { get; set; }
        public string Guia { get; set; }
        public int Saldo { get; set; }
        public int Abono { get; set; }
        public string Observaciones { get; set; }

        public Encuentros CodigoEncuentroNavigation { get; set; }
        public Personas CodigoPersonaNavigation { get; set; }
        public Personas GuiaNavigation { get; set; }
        public ICollection<Encuentroabonos> Encuentroabonos { get; set; }
    }
}
