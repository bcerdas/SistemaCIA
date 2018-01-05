using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Celulaspersonas
    {
        public int CodigoCelulasPersonas { get; set; }
        public string CodigoPersona { get; set; }
        public string CodigoCelula { get; set; }

        public Celulas CodigoCelulaNavigation { get; set; }
        public Personas CodigoPersonaNavigation { get; set; }
    }
}
