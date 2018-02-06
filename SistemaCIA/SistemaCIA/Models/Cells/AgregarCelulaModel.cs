using SistemaCIA.Models.ContextDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCIA.Models.Cells
{
    public class AgregarCelulaModel
    {

        public string CodigoCelula { get; set; }
        public string Lider { get; set; }
        public string Asistente { get; set; }
        public string CelulaRaiz { get; set; }
        public string Lugar { get; set; }
        public string Direccion { get; set; }
        public string Hora { get; set; }
        public string Dia { get; set; }
        public List<Personas> personas { get; set; }

    }
}
