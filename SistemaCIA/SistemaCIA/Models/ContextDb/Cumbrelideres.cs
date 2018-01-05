using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Cumbrelideres
    {
        public Cumbrelideres()
        {
            Cumbrelideresmatricula = new HashSet<Cumbrelideresmatricula>();
        }

        public int CodigoCumbreLideres { get; set; }
        public string Nombre { get; set; }
        public string Lema { get; set; }
        public string Objetivo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int? Asistencia { get; set; }

        public ICollection<Cumbrelideresmatricula> Cumbrelideresmatricula { get; set; }
    }
}
