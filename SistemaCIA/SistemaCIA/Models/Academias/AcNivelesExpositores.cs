using SistemaCIA.Models.ContextDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCIA.Models.Academias
{
    public class AcNivelesExpositores
    {
        public int CodigoNivel { get; set; }
        public string NombreNivel { get; set; }
        public string NombreLeccion { get; set; }
        public int NumeroLeccion { get; set; }
        public string Expositor { get; set; }
        
    }
}
