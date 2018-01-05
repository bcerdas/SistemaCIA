using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Cumbretimoteosmatricula
    {
        public Cumbretimoteosmatricula()
        {
            Cumbretimoteosabonos = new HashSet<Cumbretimoteosabonos>();
        }

        public int CodigoCtmatricula { get; set; }
        public int CodigoCumbreTimoteos { get; set; }
        public string CodigoPersona { get; set; }
        public string Guia { get; set; }
        public int Saldo { get; set; }
        public int Abono { get; set; }

        public Cumbretimoteos CodigoCumbreTimoteosNavigation { get; set; }
        public Personas CodigoPersonaNavigation { get; set; }
        public Personas GuiaNavigation { get; set; }
        public ICollection<Cumbretimoteosabonos> Cumbretimoteosabonos { get; set; }
    }
}
