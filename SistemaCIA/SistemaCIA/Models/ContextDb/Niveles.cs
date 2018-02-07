using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Niveles
    {
        public Niveles()
        {
            Academiasmatriculas = new HashSet<Academiasmatriculas>();
            Academiasniveles = new HashSet<Academiasniveles>();
            Matriculaenlinea = new HashSet<Matriculaenlinea>();
            Niveleslecciones = new HashSet<Niveleslecciones>();
            Personas = new HashSet<Personas>();
        }

        public int CodigoNivel { get; set; }
        public string Nombre { get; set; }
        public string Tema { get; set; }
        public string Descripcion { get; set; }
        public int CantidadLecciones { get; set; }

        public ICollection<Academiasmatriculas> Academiasmatriculas { get; set; }
        public ICollection<Academiasniveles> Academiasniveles { get; set; }
        public ICollection<Matriculaenlinea> Matriculaenlinea { get; set; }
        public ICollection<Niveleslecciones> Niveleslecciones { get; set; }
        public ICollection<Personas> Personas { get; set; }
    }
}
