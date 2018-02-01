using SistemaCIA.Models.ContextDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaCIA.Models.Academias
{
    public class MatriculaAcademiaModel
    {
        [Required]
        public string CodigoPersona { get; set; }
        [Required]
        public string NombrePersona { get; set; }
        public bool Becado { get; set; }
        public string Observaciones { get; set; }
        public int Abono { get; set; }
        [Required]
        public int Niveles { get; set; }
        public List<MatriculadosAcademiasModel> Matriculados { get; set; }
}
}
