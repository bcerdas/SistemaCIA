using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Cumbretimoteos
    {
        public Cumbretimoteos()
        {
            Cumbretimoteosmatricula = new HashSet<Cumbretimoteosmatricula>();
        }

        public int CodigoCumbreTimoteos { get; set; }
        public string Nombre { get; set; }
        public string Lema { get; set; }
        public string Objetivo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int? Asistencia { get; set; }

        public ICollection<Cumbretimoteosmatricula> Cumbretimoteosmatricula { get; set; }
    }
}
