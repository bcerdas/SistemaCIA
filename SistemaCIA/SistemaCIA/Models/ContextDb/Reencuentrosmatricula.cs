using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Reencuentrosmatricula
    {
        public Reencuentrosmatricula()
        {
            Reencuentroabonos = new HashSet<Reencuentroabonos>();
        }

        public int CodigoReMatricula { get; set; }
        public int CodigoReencuentro { get; set; }
        public string CodigoPersona { get; set; }
        public string Guia { get; set; }
        public int Saldo { get; set; }
        public int Abono { get; set; }

        public Personas CodigoPersonaNavigation { get; set; }
        public Reencuentros CodigoReencuentroNavigation { get; set; }
        public Personas GuiaNavigation { get; set; }
        public ICollection<Reencuentroabonos> Reencuentroabonos { get; set; }
    }
}
