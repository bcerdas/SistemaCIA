using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Academiaslecciones
    {
        public int CodigoAcademiaLeccion { get; set; }
        public int CodigoAcademias { get; set; }
        public int? CodigoAcademiaNivel { get; set; }
        public string CodigoMaestro { get; set; }
        public int CodigoLeccion { get; set; }

        public Academiasniveles CodigoAcademiaNivelNavigation { get; set; }
        public Academias CodigoAcademiasNavigation { get; set; }
        public Niveleslecciones CodigoLeccionNavigation { get; set; }
        public Personas CodigoMaestroNavigation { get; set; }
    }
}
