using System;
using System.Collections.Generic;

namespace SistemaCIA.Models.ContextDb
{
    public partial class Personas
    {
        public Personas()
        {
            BoletasconsolidacionLlenadoPorNavigation = new HashSet<Boletasconsolidacion>();
            BoletasconsolidacionPersonaAsignadaNavigation = new HashSet<Boletasconsolidacion>();
            CelulasAsistenteNavigation = new HashSet<Celulas>();
            CelulasLiderNavigation = new HashSet<Celulas>();
            Celulaspersonas = new HashSet<Celulaspersonas>();
            ChatmensajesPersona1Navigation = new HashSet<Chatmensajes>();
            ChatmensajesPersona2Navigation = new HashSet<Chatmensajes>();
            Cumbrelideresmatricula = new HashSet<Cumbrelideresmatricula>();
            CumbretimoteosmatriculaCodigoPersonaNavigation = new HashSet<Cumbretimoteosmatricula>();
            CumbretimoteosmatriculaGuiaNavigation = new HashSet<Cumbretimoteosmatricula>();
            EncuentrosAsistenteCocinaNavigation = new HashSet<Encuentros>();
            EncuentrosAsistenteNavigation = new HashSet<Encuentros>();
            EncuentrosCocinaNavigation = new HashSet<Encuentros>();
            EncuentrosCoordinadorNavigation = new HashSet<Encuentros>();
            EncuentrosDecoracionNavigation = new HashSet<Encuentros>();
            EncuentrosFinanzasNavigation = new HashSet<Encuentros>();
            EncuentrosGuiaH1Navigation = new HashSet<Encuentros>();
            EncuentrosGuiaH2Navigation = new HashSet<Encuentros>();
            EncuentrosGuiaM1Navigation = new HashSet<Encuentros>();
            EncuentrosGuiaM2Navigation = new HashSet<Encuentros>();
            EncuentrosGuiaNavigation = new HashSet<Encuentros>();
            EncuentrosLogisticaNavigation = new HashSet<Encuentros>();
            EncuentrosMusicaNavigation = new HashSet<Encuentros>();
            EncuentrosServidorNavigation = new HashSet<Encuentros>();
            EncuentrosmatriculaCodigoPersonaNavigation = new HashSet<Encuentrosmatricula>();
            EncuentrosmatriculaGuiaNavigation = new HashSet<Encuentrosmatricula>();
            Matriculaenlinea = new HashSet<Matriculaenlinea>();
            Matriculaenlineaalumnos = new HashSet<Matriculaenlineaalumnos>();
            Personasroles = new HashSet<Personasroles>();
            Procesoox3personas = new HashSet<Procesoox3personas>();
            ReencuentrosmatriculaCodigoPersonaNavigation = new HashSet<Reencuentrosmatricula>();
            ReencuentrosmatriculaGuiaNavigation = new HashSet<Reencuentrosmatricula>();
            Usuarios = new HashSet<Usuarios>();
        }

        public string CodigoPersona { get; set; }
        public int CodigoMinisterio { get; set; }
        public int CodigoArea { get; set; }
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
        public DateTime? FechaIngreso { get; set; }
        public string NivelAcademias { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public sbyte CumbreTimoteos { get; set; }
        public sbyte CumbreLideres { get; set; }
        public string Sexo { get; set; }

        public Areasdeministerio CodigoAreaNavigation { get; set; }
        public Ministerios CodigoMinisterioNavigation { get; set; }
        public ICollection<Boletasconsolidacion> BoletasconsolidacionLlenadoPorNavigation { get; set; }
        public ICollection<Boletasconsolidacion> BoletasconsolidacionPersonaAsignadaNavigation { get; set; }
        public ICollection<Celulas> CelulasAsistenteNavigation { get; set; }
        public ICollection<Celulas> CelulasLiderNavigation { get; set; }
        public ICollection<Celulaspersonas> Celulaspersonas { get; set; }
        public ICollection<Chatmensajes> ChatmensajesPersona1Navigation { get; set; }
        public ICollection<Chatmensajes> ChatmensajesPersona2Navigation { get; set; }
        public ICollection<Cumbrelideresmatricula> Cumbrelideresmatricula { get; set; }
        public ICollection<Cumbretimoteosmatricula> CumbretimoteosmatriculaCodigoPersonaNavigation { get; set; }
        public ICollection<Cumbretimoteosmatricula> CumbretimoteosmatriculaGuiaNavigation { get; set; }
        public ICollection<Encuentros> EncuentrosAsistenteCocinaNavigation { get; set; }
        public ICollection<Encuentros> EncuentrosAsistenteNavigation { get; set; }
        public ICollection<Encuentros> EncuentrosCocinaNavigation { get; set; }
        public ICollection<Encuentros> EncuentrosCoordinadorNavigation { get; set; }
        public ICollection<Encuentros> EncuentrosDecoracionNavigation { get; set; }
        public ICollection<Encuentros> EncuentrosFinanzasNavigation { get; set; }
        public ICollection<Encuentros> EncuentrosGuiaH1Navigation { get; set; }
        public ICollection<Encuentros> EncuentrosGuiaH2Navigation { get; set; }
        public ICollection<Encuentros> EncuentrosGuiaM1Navigation { get; set; }
        public ICollection<Encuentros> EncuentrosGuiaM2Navigation { get; set; }
        public ICollection<Encuentros> EncuentrosGuiaNavigation { get; set; }
        public ICollection<Encuentros> EncuentrosLogisticaNavigation { get; set; }
        public ICollection<Encuentros> EncuentrosMusicaNavigation { get; set; }
        public ICollection<Encuentros> EncuentrosServidorNavigation { get; set; }
        public ICollection<Encuentrosmatricula> EncuentrosmatriculaCodigoPersonaNavigation { get; set; }
        public ICollection<Encuentrosmatricula> EncuentrosmatriculaGuiaNavigation { get; set; }
        public ICollection<Matriculaenlinea> Matriculaenlinea { get; set; }
        public ICollection<Matriculaenlineaalumnos> Matriculaenlineaalumnos { get; set; }
        public ICollection<Personasroles> Personasroles { get; set; }
        public ICollection<Procesoox3personas> Procesoox3personas { get; set; }
        public ICollection<Reencuentrosmatricula> ReencuentrosmatriculaCodigoPersonaNavigation { get; set; }
        public ICollection<Reencuentrosmatricula> ReencuentrosmatriculaGuiaNavigation { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
