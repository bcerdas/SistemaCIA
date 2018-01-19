using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Informescelulares
    {
        public int CodigoInformeCelular { get; set; }
        public DateTime Fecha { get; set; }
        public int Asistencia { get; set; }
        public int Visitas { get; set; }
        public int Ofrenda { get; set; }
        public string Observaciones { get; set; }
        public bool SeRealizo { get; set; }
    }
}
