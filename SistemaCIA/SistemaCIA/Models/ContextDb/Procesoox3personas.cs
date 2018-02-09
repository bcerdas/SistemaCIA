using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Procesoox3personas
    {
        public int CodigoProcesoOx3Personas { get; set; }
        public int CodigoProceso0x3PersonaOrando { get; set; }
        public string NombreCompleto { get; set; }
        public int NumeroPersona { get; set; }
        public string Necesidades { get; set; }
        public bool ContactoUno { get; set; }
        public string ObservacionesContactoUno { get; set; }
        public bool ContactoDos { get; set; }
        public string ObservacionesContactoDos { get; set; }
        public bool AsistioR5 { get; set; }
        public bool AsistioR6 { get; set; }
        public bool SeConvirtio { get; set; }

        public Procesoox3personasorando CodigoProceso0x3PersonaOrandoNavigation { get; set; }
    }
}
