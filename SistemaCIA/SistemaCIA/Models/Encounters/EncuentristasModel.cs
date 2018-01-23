using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCIA.Models.Encounters
{
    public class EncuentristasModel
    {
        public string CodigoPersona { get; set; }
        
        public int CodigoEncuentro { get; set; }
        
        public string Lider { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string NombreCompletoMadre { get; set; }
        public string TelefonoMadre { get; set; }
        public string NombreCompletoPadre { get; set; }
        public string TelefonoPadre { get; set; }
        public string NombreCompletoConyuge { get; set; }
        public string TelefonoConyuge { get; set; }
        public string NombreCompletoEncargado { get; set; }
        public string TelefonoEncargado { get; set; }
        public string ParentescoEncargado { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public string Sexo { get; set; }
        public string NombreEncuentro { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
    }
}
