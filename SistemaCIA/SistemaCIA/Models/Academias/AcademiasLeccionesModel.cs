using SistemaCIA.Models.ContextDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCIA.Models.Academias
{
    public class AcademiasLeccionesModel
    {

        public int CodigoAcademia { set; get; } 
        public List<Academiaslecciones> leccionesExpositores { set; get; }
        public List<Academiasniveles> academiasNiveles { set; get; }


    }
}
