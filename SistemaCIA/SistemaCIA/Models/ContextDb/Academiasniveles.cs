using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Academiasniveles
    {
        public Academiasniveles()
        {
            Academiaslecciones = new HashSet<Academiaslecciones>();
            Academiasmatriculas = new HashSet<Academiasmatriculas>();
        }

        public int CodigoAcademiasNiveles { get; set; }
        public int CodigoAcademias { get; set; }
        public int CodigoNivel { get; set; }
        public int? Grupo { get; set; }

        public Academias CodigoAcademiasNavigation { get; set; }
        public Niveles CodigoNivelNavigation { get; set; }
        public ICollection<Academiaslecciones> Academiaslecciones { get; set; }
        public ICollection<Academiasmatriculas> Academiasmatriculas { get; set; }
    }
}
