using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Cumbrelideresmatricula
    {
        public int CodigoClmatricula { get; set; }
        public int CodigoCumbreLideres { get; set; }
        public string CodigoPersona { get; set; }
        public int Saldo { get; set; }
        public int Abono { get; set; }

        public Cumbrelideres CodigoCumbreLideresNavigation { get; set; }
        public Personas CodigoPersonaNavigation { get; set; }
    }
}
