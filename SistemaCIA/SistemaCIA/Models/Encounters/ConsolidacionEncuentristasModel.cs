using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCIA.Models.Encounters
{
    public class ConsolidacionEncuentristasModel
    {
        public string CodigoPersona { get; set; }
        public int CodigoMatriculaEncuentro { get; set; }
        public int CodigoEncuentro { get; set; }
        public string Guia { get; set; }
        public string Lider { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }

        public DateTime? FechaDeNacimiento { get; set; }
        public int Saldo { get; set; }
        public int Abono { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
    }
}
