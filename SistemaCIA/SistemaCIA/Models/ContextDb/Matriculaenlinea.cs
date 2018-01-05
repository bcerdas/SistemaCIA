using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Matriculaenlinea
    {
        public string CodigoMatriculaEnLinea { get; set; }
        public int CodigoCurso { get; set; }
        public string Maestro { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int? CantEstudiantes { get; set; }
        public int? CantAprobados { get; set; }
        public int? CantReprobados { get; set; }
        public int? MontoIngreso { get; set; }

        public Niveles CodigoCursoNavigation { get; set; }
        public Personas MaestroNavigation { get; set; }
    }
}
