﻿using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Academiasmatriculas
    {
        public Academiasmatriculas()
        {
            Academiasabono = new HashSet<Academiasabono>();
        }

        public int CodigoAcademiaMatricula { get; set; }
        public int CodigoAcademias { get; set; }
        public string CodigoPersona { get; set; }
        public string Observaciones { get; set; }
        public int Saldo { get; set; }
        public int Abono { get; set; }
        public int? Becado { get; set; }

        public Academias CodigoAcademiasNavigation { get; set; }
        public Personas CodigoPersonaNavigation { get; set; }
        public ICollection<Academiasabono> Academiasabono { get; set; }
    }
}