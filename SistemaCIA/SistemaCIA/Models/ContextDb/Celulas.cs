using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Celulas
    {
        public Celulas()
        {
            Boletasconsolidacion = new HashSet<Boletasconsolidacion>();
            Celulaspersonas = new HashSet<Celulaspersonas>();
            Informescelulares = new HashSet<Informescelulares>();
            InverseCelulaRaizNavigation = new HashSet<Celulas>();
        }

        public string CodigoCelula { get; set; }
        public string Lider { get; set; }
        public string Asistente { get; set; }
        public string CelulaRaiz { get; set; }
        public string Lugar { get; set; }
        public string Direccion { get; set; }
        public string Hora { get; set; }
        public string Dia { get; set; }
        public int PromedioPersonas { get; set; }

        public Personas AsistenteNavigation { get; set; }
        public Celulas CelulaRaizNavigation { get; set; }
        public Personas LiderNavigation { get; set; }
        public ICollection<Boletasconsolidacion> Boletasconsolidacion { get; set; }
        public ICollection<Celulaspersonas> Celulaspersonas { get; set; }
        public ICollection<Informescelulares> Informescelulares { get; set; }
        public ICollection<Celulas> InverseCelulaRaizNavigation { get; set; }
    }
}
