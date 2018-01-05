using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Cumbretimoteosabonos
    {
        public int CodigoCumbreTimoteosAbonos { get; set; }
        public int CodigoCtmatricula { get; set; }
        public DateTime Fecha { get; set; }
        public int Abono { get; set; }

        public Cumbretimoteosmatricula CodigoCtmatriculaNavigation { get; set; }
    }
}
