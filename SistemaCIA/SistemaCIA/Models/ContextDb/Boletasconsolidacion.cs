using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Boletasconsolidacion
    {
        public int CodigoBoleta { get; set; }
        public string PersonaAsignada { get; set; }
        public DateTime Fecha { get; set; }
        public string Actividad { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string TelefonoCasa { get; set; }
        public string TelefonoMovil { get; set; }
        public string TipoBoleta { get; set; }
        public string InvitadoPor { get; set; }
        public string CelulaDe { get; set; }
        public string Peticion { get; set; }
        public string LlenadoPor { get; set; }

        public Celulas CelulaDeNavigation { get; set; }
        public Personas LlenadoPorNavigation { get; set; }
        public Personas PersonaAsignadaNavigation { get; set; }
    }
}
