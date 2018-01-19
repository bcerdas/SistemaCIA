using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Encuentros
    {
        public Encuentros()
        {
            Encuentrosmatricula = new HashSet<Encuentrosmatricula>();
        }

        public int CodigoEncuentro { get; set; }
        public string Nombre { get; set; }
        public string Lema { get; set; }
        public string Objetivo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int? Asistencia { get; set; }
        public string Coordinador { get; set; }
        public string Asistente { get; set; }
        public string Logistica { get; set; }
        public string Servidor { get; set; }
        public string Cocina { get; set; }
        public string AsistenteCocina { get; set; }
        public string Musica { get; set; }
        public string GuiaH1 { get; set; }
        public string GuiaH2 { get; set; }
        public string GuiaM1 { get; set; }
        public string GuiaM2 { get; set; }
        public string Guia { get; set; }
        public string Finanzas { get; set; }
        public string Decoracion { get; set; }
        public int? TotalDinero { get; set; }
        public int? TotalInvertido { get; set; }
        public int? MontoDecoracion { get; set; }
        public int? MontoLogistica { get; set; }
        public int? MontoComida { get; set; }
        public int? MontoServicio { get; set; }
        public int? MontoTransporte { get; set; }
        public int? TotalRestante { get; set; }
        public int? MontoOtros { get; set; }
        public string Estado { get; set; }

        public Personas AsistenteCocinaNavigation { get; set; }
        public Personas AsistenteNavigation { get; set; }
        public Personas CocinaNavigation { get; set; }
        public Personas CoordinadorNavigation { get; set; }
        public Personas DecoracionNavigation { get; set; }
        public Personas FinanzasNavigation { get; set; }
        public Personas GuiaH1Navigation { get; set; }
        public Personas GuiaH2Navigation { get; set; }
        public Personas GuiaM1Navigation { get; set; }
        public Personas GuiaM2Navigation { get; set; }
        public Personas GuiaNavigation { get; set; }
        public Personas LogisticaNavigation { get; set; }
        public Personas MusicaNavigation { get; set; }
        public Personas ServidorNavigation { get; set; }
        public ICollection<Encuentrosmatricula> Encuentrosmatricula { get; set; }
    }
}
