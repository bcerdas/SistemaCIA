using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCIA.Models.Academias
{
    public class MatriculadosAcademiasModel
    {

        public int CodigoAcademiaMatricula { get; set; }
        public string Lider { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string NivelAcademias { get; set; }
        public int Saldo { get; set; }
        public string NivelMatriculado { get; set; }
        public int Abono { get; set; }
        public int? Becado { get; set; }

    }
}
