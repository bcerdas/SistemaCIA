using SistemaCIA.Models.ContextDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCIA.Models.Academias
{
    public class AcademiasNivelesModel
    {
        public string Nombre { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public int? CantNiveles { get; set; }
        public List<Niveles> niveles { get; set; }

    }
}
