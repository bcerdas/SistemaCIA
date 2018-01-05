using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Chatmensajes
    {
        public int CodigoChatMensajes { get; set; }
        public string Persona1 { get; set; }
        public string Persona2 { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }

        public Personas Persona1Navigation { get; set; }
        public Personas Persona2Navigation { get; set; }
    }
}
