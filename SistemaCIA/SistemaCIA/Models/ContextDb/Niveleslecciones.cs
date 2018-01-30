using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Niveleslecciones
    {
        public Niveleslecciones()
        {
            Academiaslecciones = new HashSet<Academiaslecciones>();
        }

        public int CodigoNivelLeccion { get; set; }
        public int CodigoNivel { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int NumeroLeccion { get; set; }

        public Niveles CodigoNivelNavigation { get; set; }
        public ICollection<Academiaslecciones> Academiaslecciones { get; set; }
    }
}
