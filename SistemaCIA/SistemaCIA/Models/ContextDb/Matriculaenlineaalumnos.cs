using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Matriculaenlineaalumnos
    {
        public int CodigoMatriculaEnLineaAlumnos { get; set; }
        public string Alumno { get; set; }
        public int? Pago { get; set; }
        public string Estado { get; set; }
        public int? Nota { get; set; }

        public Personas AlumnoNavigation { get; set; }
    }
}
