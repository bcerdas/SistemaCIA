using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Niveles
    {
        public Niveles()
        {
            Academiasniveles = new HashSet<Academiasniveles>();
            Matriculaenlinea = new HashSet<Matriculaenlinea>();
        }

        public int CodigoNivel { get; set; }
        public string Nombre { get; set; }
        public string Tema { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Academiasniveles> Academiasniveles { get; set; }
        public ICollection<Matriculaenlinea> Matriculaenlinea { get; set; }
    }
}
