using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SistemaCIA.Models.ContextDb
{
    public partial class SistemaCIADBContext : DbContext
    {
        public virtual DbSet<Academias> Academias { get; set; }
        public virtual DbSet<Academiasabono> Academiasabono { get; set; }
        public virtual DbSet<Academiaslecciones> Academiaslecciones { get; set; }
        public virtual DbSet<Academiasmatriculas> Academiasmatriculas { get; set; }
        public virtual DbSet<Academiasniveles> Academiasniveles { get; set; }
        public virtual DbSet<Areasdeministerio> Areasdeministerio { get; set; }
        public virtual DbSet<Boletasconsolidacion> Boletasconsolidacion { get; set; }
        public virtual DbSet<Celulas> Celulas { get; set; }
        public virtual DbSet<Celulaspersonas> Celulaspersonas { get; set; }
        public virtual DbSet<Chatmensajes> Chatmensajes { get; set; }
        public virtual DbSet<Cumbrelideres> Cumbrelideres { get; set; }
        public virtual DbSet<Cumbrelideresmatricula> Cumbrelideresmatricula { get; set; }
        public virtual DbSet<Cumbretimoteos> Cumbretimoteos { get; set; }
        public virtual DbSet<Cumbretimoteosabonos> Cumbretimoteosabonos { get; set; }
        public virtual DbSet<Cumbretimoteosmatricula> Cumbretimoteosmatricula { get; set; }
        public virtual DbSet<Encuentroabonos> Encuentroabonos { get; set; }
        public virtual DbSet<Encuentros> Encuentros { get; set; }
        public virtual DbSet<Encuentrosmatricula> Encuentrosmatricula { get; set; }
        public virtual DbSet<Informescelulares> Informescelulares { get; set; }
        public virtual DbSet<Matriculaenlinea> Matriculaenlinea { get; set; }
        public virtual DbSet<Matriculaenlineaalumnos> Matriculaenlineaalumnos { get; set; }
        public virtual DbSet<Ministerios> Ministerios { get; set; }
        public virtual DbSet<Niveles> Niveles { get; set; }
        public virtual DbSet<Niveleslecciones> Niveleslecciones { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Personasroles> Personasroles { get; set; }
        public virtual DbSet<Procesoox3> Procesoox3 { get; set; }
        public virtual DbSet<Procesoox3informer5> Procesoox3informer5 { get; set; }
        public virtual DbSet<Procesoox3informer6> Procesoox3informer6 { get; set; }
        public virtual DbSet<Procesoox3personas> Procesoox3personas { get; set; }
        public virtual DbSet<Reencuentroabonos> Reencuentroabonos { get; set; }
        public virtual DbSet<Reencuentros> Reencuentros { get; set; }
        public virtual DbSet<Reencuentrosmatricula> Reencuentrosmatricula { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;User Id=UserCIA;password=cia1q2w3e4r;database=SistemaCIADB;");
            }
        }

        public SistemaCIADBContext(DbContextOptions<SistemaCIADBContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Academias>(entity =>
            {
                entity.HasKey(e => e.CodigoAcademias);

                entity.ToTable("academias");

                entity.Property(e => e.CodigoAcademias)
                    .HasColumnName("codigoAcademias")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Asistencia)
                    .HasColumnName("asistencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CantNiveles)
                    .HasColumnName("cantNiveles")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.MontoIngreso)
                    .HasColumnName("montoIngreso")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MontoSalida)
                    .HasColumnName("montoSalida")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Academiasabono>(entity =>
            {
                entity.HasKey(e => e.CodigoAcademiaAbono);

                entity.ToTable("academiasabono");

                entity.HasIndex(e => e.CodigoAcademiasMatricula)
                    .HasName("codigoAcademiasMatricula");

                entity.Property(e => e.CodigoAcademiaAbono)
                    .HasColumnName("codigoAcademiaAbono")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Abono)
                    .HasColumnName("abono")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoAcademiasMatricula)
                    .HasColumnName("codigoAcademiasMatricula")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CodigoAcademiasMatriculaNavigation)
                    .WithMany(p => p.Academiasabono)
                    .HasForeignKey(d => d.CodigoAcademiasMatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("academiasabono_ibfk_1");
            });

            modelBuilder.Entity<Academiaslecciones>(entity =>
            {
                entity.HasKey(e => e.CodigoAcademiaLeccion);

                entity.ToTable("academiaslecciones");

                entity.HasIndex(e => e.CodigoAcademias)
                    .HasName("codigoAcademias");

                entity.HasIndex(e => e.CodigoLeccion)
                    .HasName("codigoLeccion");

                entity.HasIndex(e => e.CodigoMaestro)
                    .HasName("codigoMaestro");

                entity.Property(e => e.CodigoAcademiaLeccion)
                    .HasColumnName("codigoAcademiaLeccion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoAcademias)
                    .HasColumnName("codigoAcademias")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoLeccion)
                    .HasColumnName("codigoLeccion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoMaestro)
                    .IsRequired()
                    .HasColumnName("codigoMaestro")
                    .HasMaxLength(15);

                entity.HasOne(d => d.CodigoAcademiasNavigation)
                    .WithMany(p => p.Academiaslecciones)
                    .HasForeignKey(d => d.CodigoAcademias)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("academiaslecciones_ibfk_1");

                entity.HasOne(d => d.CodigoLeccionNavigation)
                    .WithMany(p => p.Academiaslecciones)
                    .HasForeignKey(d => d.CodigoLeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("academiaslecciones_ibfk_3");

                entity.HasOne(d => d.CodigoMaestroNavigation)
                    .WithMany(p => p.Academiaslecciones)
                    .HasForeignKey(d => d.CodigoMaestro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("academiaslecciones_ibfk_2");
            });

            modelBuilder.Entity<Academiasmatriculas>(entity =>
            {
                entity.HasKey(e => e.CodigoAcademiaMatricula);

                entity.ToTable("academiasmatriculas");

                entity.HasIndex(e => e.CodigoAcademias)
                    .HasName("codigoAcademias");

                entity.HasIndex(e => e.CodigoPersona)
                    .HasName("codigoPersona");

                entity.Property(e => e.CodigoAcademiaMatricula)
                    .HasColumnName("codigoAcademiaMatricula")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Abono)
                    .HasColumnName("abono")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Becado)
                    .HasColumnName("becado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoAcademias)
                    .HasColumnName("codigoAcademias")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoPersona)
                    .IsRequired()
                    .HasColumnName("codigoPersona")
                    .HasMaxLength(15);

                entity.Property(e => e.Observaciones)
                    .HasColumnName("observaciones")
                    .HasMaxLength(500);

                entity.Property(e => e.Saldo)
                    .HasColumnName("saldo")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CodigoAcademiasNavigation)
                    .WithMany(p => p.Academiasmatriculas)
                    .HasForeignKey(d => d.CodigoAcademias)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("academiasmatriculas_ibfk_1");

                entity.HasOne(d => d.CodigoPersonaNavigation)
                    .WithMany(p => p.Academiasmatriculas)
                    .HasForeignKey(d => d.CodigoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("academiasmatriculas_ibfk_2");
            });

            modelBuilder.Entity<Academiasniveles>(entity =>
            {
                entity.HasKey(e => e.CodigoAcademiasNiveles);

                entity.ToTable("academiasniveles");

                entity.HasIndex(e => e.CodigoAcademias)
                    .HasName("codigoAcademias");

                entity.HasIndex(e => e.CodigoNivel)
                    .HasName("codigoNivel");

                entity.Property(e => e.CodigoAcademiasNiveles)
                    .HasColumnName("codigoAcademiasNiveles")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoAcademias)
                    .HasColumnName("codigoAcademias")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoNivel)
                    .HasColumnName("codigoNivel")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CodigoAcademiasNavigation)
                    .WithMany(p => p.Academiasniveles)
                    .HasForeignKey(d => d.CodigoAcademias)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("academiasniveles_ibfk_1");

                entity.HasOne(d => d.CodigoNivelNavigation)
                    .WithMany(p => p.Academiasniveles)
                    .HasForeignKey(d => d.CodigoNivel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("academiasniveles_ibfk_2");
            });

            modelBuilder.Entity<Areasdeministerio>(entity =>
            {
                entity.HasKey(e => e.CodigoArea);

                entity.ToTable("areasdeministerio");

                entity.HasIndex(e => e.CodigoMinisterio)
                    .HasName("codigoMinisterio");

                entity.Property(e => e.CodigoArea)
                    .HasColumnName("codigoArea")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CantMiembros)
                    .HasColumnName("cantMiembros")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoMinisterio)
                    .HasColumnName("codigoMinisterio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(40);

                entity.Property(e => e.Objetivo)
                    .IsRequired()
                    .HasColumnName("objetivo")
                    .HasMaxLength(500);

                entity.HasOne(d => d.CodigoMinisterioNavigation)
                    .WithMany(p => p.Areasdeministerio)
                    .HasForeignKey(d => d.CodigoMinisterio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("areasdeministerio_ibfk_1");
            });

            modelBuilder.Entity<Boletasconsolidacion>(entity =>
            {
                entity.HasKey(e => e.CodigoBoleta);

                entity.ToTable("boletasconsolidacion");

                entity.HasIndex(e => e.CelulaDe)
                    .HasName("celulaDe");

                entity.HasIndex(e => e.LlenadoPor)
                    .HasName("llenadoPor");

                entity.HasIndex(e => e.PersonaAsignada)
                    .HasName("personaAsignada");

                entity.Property(e => e.CodigoBoleta)
                    .HasColumnName("codigoBoleta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Actividad)
                    .IsRequired()
                    .HasColumnName("actividad")
                    .HasMaxLength(50);

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasColumnName("apellido1")
                    .HasMaxLength(20);

                entity.Property(e => e.Apellido2)
                    .HasColumnName("apellido2")
                    .HasMaxLength(20);

                entity.Property(e => e.CelulaDe)
                    .HasColumnName("celulaDe")
                    .HasMaxLength(15);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(500);

                entity.Property(e => e.Edad)
                    .HasColumnName("edad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvitadoPor)
                    .HasColumnName("invitadoPor")
                    .HasMaxLength(70);

                entity.Property(e => e.LlenadoPor)
                    .IsRequired()
                    .HasColumnName("llenadoPor")
                    .HasMaxLength(15);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(20);

                entity.Property(e => e.PersonaAsignada)
                    .IsRequired()
                    .HasColumnName("personaAsignada")
                    .HasMaxLength(15);

                entity.Property(e => e.Peticion)
                    .HasColumnName("peticion")
                    .HasMaxLength(500);

                entity.Property(e => e.Sexo)
                    .HasColumnName("sexo")
                    .HasMaxLength(10);

                entity.Property(e => e.TelefonoCasa)
                    .HasColumnName("telefonoCasa")
                    .HasMaxLength(15);

                entity.Property(e => e.TelefonoMovil)
                    .HasColumnName("telefonoMovil")
                    .HasMaxLength(15);

                entity.Property(e => e.TipoBoleta)
                    .HasColumnName("tipoBoleta")
                    .HasMaxLength(15);

                entity.HasOne(d => d.CelulaDeNavigation)
                    .WithMany(p => p.Boletasconsolidacion)
                    .HasForeignKey(d => d.CelulaDe)
                    .HasConstraintName("boletasconsolidacion_ibfk_2");

                entity.HasOne(d => d.LlenadoPorNavigation)
                    .WithMany(p => p.BoletasconsolidacionLlenadoPorNavigation)
                    .HasForeignKey(d => d.LlenadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("boletasconsolidacion_ibfk_3");

                entity.HasOne(d => d.PersonaAsignadaNavigation)
                    .WithMany(p => p.BoletasconsolidacionPersonaAsignadaNavigation)
                    .HasForeignKey(d => d.PersonaAsignada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("boletasconsolidacion_ibfk_1");
            });

            modelBuilder.Entity<Celulas>(entity =>
            {
                entity.HasKey(e => e.CodigoCelula);

                entity.ToTable("celulas");

                entity.HasIndex(e => e.Asistente)
                    .HasName("asistente");

                entity.HasIndex(e => e.CelulaRaiz)
                    .HasName("celulaRaiz");

                entity.HasIndex(e => e.Lider)
                    .HasName("lider");

                entity.Property(e => e.CodigoCelula)
                    .HasColumnName("codigoCelula")
                    .HasMaxLength(15);

                entity.Property(e => e.Asistente)
                    .HasColumnName("asistente")
                    .HasMaxLength(15);

                entity.Property(e => e.CelulaRaiz)
                    .HasColumnName("celulaRaiz")
                    .HasMaxLength(15);

                entity.Property(e => e.Dia)
                    .IsRequired()
                    .HasColumnName("dia")
                    .HasMaxLength(10);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(500);

                entity.Property(e => e.Hora)
                    .IsRequired()
                    .HasColumnName("hora")
                    .HasMaxLength(10);

                entity.Property(e => e.Lider)
                    .IsRequired()
                    .HasColumnName("lider")
                    .HasMaxLength(15);

                entity.Property(e => e.Lugar)
                    .IsRequired()
                    .HasColumnName("lugar")
                    .HasMaxLength(40);

                entity.Property(e => e.PromedioPersonas)
                    .HasColumnName("promedioPersonas")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.AsistenteNavigation)
                    .WithMany(p => p.CelulasAsistenteNavigation)
                    .HasForeignKey(d => d.Asistente)
                    .HasConstraintName("celulas_ibfk_2");

                entity.HasOne(d => d.CelulaRaizNavigation)
                    .WithMany(p => p.InverseCelulaRaizNavigation)
                    .HasForeignKey(d => d.CelulaRaiz)
                    .HasConstraintName("celulas_ibfk_3");

                entity.HasOne(d => d.LiderNavigation)
                    .WithMany(p => p.CelulasLiderNavigation)
                    .HasForeignKey(d => d.Lider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("celulas_ibfk_1");
            });

            modelBuilder.Entity<Celulaspersonas>(entity =>
            {
                entity.HasKey(e => e.CodigoCelulasPersonas);

                entity.ToTable("celulaspersonas");

                entity.HasIndex(e => e.CodigoCelula)
                    .HasName("codigoCelula");

                entity.HasIndex(e => e.CodigoPersona)
                    .HasName("codigoPersona");

                entity.Property(e => e.CodigoCelulasPersonas)
                    .HasColumnName("codigoCelulasPersonas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoCelula)
                    .IsRequired()
                    .HasColumnName("codigoCelula")
                    .HasMaxLength(15);

                entity.Property(e => e.CodigoPersona)
                    .IsRequired()
                    .HasColumnName("codigoPersona")
                    .HasMaxLength(15);

                entity.HasOne(d => d.CodigoCelulaNavigation)
                    .WithMany(p => p.Celulaspersonas)
                    .HasForeignKey(d => d.CodigoCelula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("celulaspersonas_ibfk_2");

                entity.HasOne(d => d.CodigoPersonaNavigation)
                    .WithMany(p => p.Celulaspersonas)
                    .HasForeignKey(d => d.CodigoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("celulaspersonas_ibfk_1");
            });

            modelBuilder.Entity<Chatmensajes>(entity =>
            {
                entity.HasKey(e => e.CodigoChatMensajes);

                entity.ToTable("chatmensajes");

                entity.HasIndex(e => e.Persona1)
                    .HasName("persona1");

                entity.HasIndex(e => e.Persona2)
                    .HasName("persona2");

                entity.Property(e => e.CodigoChatMensajes)
                    .HasColumnName("codigoChatMensajes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .HasColumnName("mensaje")
                    .HasMaxLength(3000);

                entity.Property(e => e.Persona1)
                    .HasColumnName("persona1")
                    .HasMaxLength(15);

                entity.Property(e => e.Persona2)
                    .HasColumnName("persona2")
                    .HasMaxLength(15);

                entity.HasOne(d => d.Persona1Navigation)
                    .WithMany(p => p.ChatmensajesPersona1Navigation)
                    .HasForeignKey(d => d.Persona1)
                    .HasConstraintName("chatmensajes_ibfk_1");

                entity.HasOne(d => d.Persona2Navigation)
                    .WithMany(p => p.ChatmensajesPersona2Navigation)
                    .HasForeignKey(d => d.Persona2)
                    .HasConstraintName("chatmensajes_ibfk_2");
            });

            modelBuilder.Entity<Cumbrelideres>(entity =>
            {
                entity.HasKey(e => e.CodigoCumbreLideres);

                entity.ToTable("cumbrelideres");

                entity.Property(e => e.CodigoCumbreLideres)
                    .HasColumnName("codigoCumbreLideres")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Asistencia)
                    .HasColumnName("asistencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaFinal)
                    .HasColumnName("fechaFinal")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lema)
                    .HasColumnName("lema")
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(70);

                entity.Property(e => e.Objetivo)
                    .HasColumnName("objetivo")
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<Cumbrelideresmatricula>(entity =>
            {
                entity.HasKey(e => e.CodigoClmatricula);

                entity.ToTable("cumbrelideresmatricula");

                entity.HasIndex(e => e.CodigoCumbreLideres)
                    .HasName("codigoCumbreLideres");

                entity.HasIndex(e => e.CodigoPersona)
                    .HasName("codigoPersona");

                entity.Property(e => e.CodigoClmatricula)
                    .HasColumnName("codigoCLMatricula")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Abono)
                    .HasColumnName("abono")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoCumbreLideres)
                    .HasColumnName("codigoCumbreLideres")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoPersona)
                    .IsRequired()
                    .HasColumnName("codigoPersona")
                    .HasMaxLength(15);

                entity.Property(e => e.Saldo)
                    .HasColumnName("saldo")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CodigoCumbreLideresNavigation)
                    .WithMany(p => p.Cumbrelideresmatricula)
                    .HasForeignKey(d => d.CodigoCumbreLideres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cumbrelideresmatricula_ibfk_1");

                entity.HasOne(d => d.CodigoPersonaNavigation)
                    .WithMany(p => p.Cumbrelideresmatricula)
                    .HasForeignKey(d => d.CodigoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cumbrelideresmatricula_ibfk_2");
            });

            modelBuilder.Entity<Cumbretimoteos>(entity =>
            {
                entity.HasKey(e => e.CodigoCumbreTimoteos);

                entity.ToTable("cumbretimoteos");

                entity.Property(e => e.CodigoCumbreTimoteos)
                    .HasColumnName("codigoCumbreTimoteos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Asistencia)
                    .HasColumnName("asistencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaFinal)
                    .HasColumnName("fechaFinal")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lema)
                    .HasColumnName("lema")
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(70);

                entity.Property(e => e.Objetivo)
                    .HasColumnName("objetivo")
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<Cumbretimoteosabonos>(entity =>
            {
                entity.HasKey(e => e.CodigoCumbreTimoteosAbonos);

                entity.ToTable("cumbretimoteosabonos");

                entity.HasIndex(e => e.CodigoCtmatricula)
                    .HasName("codigoCTMatricula");

                entity.Property(e => e.CodigoCumbreTimoteosAbonos)
                    .HasColumnName("codigoCumbreTimoteosAbonos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Abono)
                    .HasColumnName("abono")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoCtmatricula)
                    .HasColumnName("codigoCTMatricula")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CodigoCtmatriculaNavigation)
                    .WithMany(p => p.Cumbretimoteosabonos)
                    .HasForeignKey(d => d.CodigoCtmatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cumbretimoteosabonos_ibfk_1");
            });

            modelBuilder.Entity<Cumbretimoteosmatricula>(entity =>
            {
                entity.HasKey(e => e.CodigoCtmatricula);

                entity.ToTable("cumbretimoteosmatricula");

                entity.HasIndex(e => e.CodigoCumbreTimoteos)
                    .HasName("codigoCumbreTimoteos");

                entity.HasIndex(e => e.CodigoPersona)
                    .HasName("codigoPersona");

                entity.HasIndex(e => e.Guia)
                    .HasName("guia");

                entity.Property(e => e.CodigoCtmatricula)
                    .HasColumnName("codigoCTMatricula")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Abono)
                    .HasColumnName("abono")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoCumbreTimoteos)
                    .HasColumnName("codigoCumbreTimoteos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoPersona)
                    .IsRequired()
                    .HasColumnName("codigoPersona")
                    .HasMaxLength(15);

                entity.Property(e => e.Guia)
                    .IsRequired()
                    .HasColumnName("guia")
                    .HasMaxLength(15);

                entity.Property(e => e.Saldo)
                    .HasColumnName("saldo")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CodigoCumbreTimoteosNavigation)
                    .WithMany(p => p.Cumbretimoteosmatricula)
                    .HasForeignKey(d => d.CodigoCumbreTimoteos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cumbretimoteosmatricula_ibfk_1");

                entity.HasOne(d => d.CodigoPersonaNavigation)
                    .WithMany(p => p.CumbretimoteosmatriculaCodigoPersonaNavigation)
                    .HasForeignKey(d => d.CodigoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cumbretimoteosmatricula_ibfk_2");

                entity.HasOne(d => d.GuiaNavigation)
                    .WithMany(p => p.CumbretimoteosmatriculaGuiaNavigation)
                    .HasForeignKey(d => d.Guia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cumbretimoteosmatricula_ibfk_3");
            });

            modelBuilder.Entity<Encuentroabonos>(entity =>
            {
                entity.HasKey(e => e.CodigoEncuentroAbonos);

                entity.ToTable("encuentroabonos");

                entity.HasIndex(e => e.CodigoEncMatricula)
                    .HasName("codigoEncMatricula");

                entity.Property(e => e.CodigoEncuentroAbonos)
                    .HasColumnName("codigoEncuentroAbonos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Abono)
                    .HasColumnName("abono")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoEncMatricula)
                    .HasColumnName("codigoEncMatricula")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CodigoEncMatriculaNavigation)
                    .WithMany(p => p.Encuentroabonos)
                    .HasForeignKey(d => d.CodigoEncMatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("encuentroabonos_ibfk_1");
            });

            modelBuilder.Entity<Encuentros>(entity =>
            {
                entity.HasKey(e => e.CodigoEncuentro);

                entity.ToTable("encuentros");

                entity.HasIndex(e => e.Asistente)
                    .HasName("asistente");

                entity.HasIndex(e => e.AsistenteCocina)
                    .HasName("asistenteCocina");

                entity.HasIndex(e => e.Cocina)
                    .HasName("cocina");

                entity.HasIndex(e => e.Coordinador)
                    .HasName("coordinador");

                entity.HasIndex(e => e.Decoracion)
                    .HasName("decoracion");

                entity.HasIndex(e => e.Finanzas)
                    .HasName("finanzas");

                entity.HasIndex(e => e.Guia)
                    .HasName("guia");

                entity.HasIndex(e => e.GuiaH1)
                    .HasName("guiaH1");

                entity.HasIndex(e => e.GuiaH2)
                    .HasName("guiaH2");

                entity.HasIndex(e => e.GuiaM1)
                    .HasName("guiaM1");

                entity.HasIndex(e => e.GuiaM2)
                    .HasName("guiaM2");

                entity.HasIndex(e => e.Logistica)
                    .HasName("logistica");

                entity.HasIndex(e => e.Musica)
                    .HasName("musica");

                entity.HasIndex(e => e.Servidor)
                    .HasName("servidor");

                entity.Property(e => e.CodigoEncuentro)
                    .HasColumnName("codigoEncuentro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Asistencia)
                    .HasColumnName("asistencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Asistente)
                    .HasColumnName("asistente")
                    .HasMaxLength(15);

                entity.Property(e => e.AsistenteCocina)
                    .HasColumnName("asistenteCocina")
                    .HasMaxLength(15);

                entity.Property(e => e.Cocina)
                    .HasColumnName("cocina")
                    .HasMaxLength(15);

                entity.Property(e => e.Coordinador)
                    .HasColumnName("coordinador")
                    .HasMaxLength(15);

                entity.Property(e => e.Decoracion)
                    .HasColumnName("decoracion")
                    .HasMaxLength(15);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'Disponible'");

                entity.Property(e => e.FechaFinal)
                    .HasColumnName("fechaFinal")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Finanzas)
                    .HasColumnName("finanzas")
                    .HasMaxLength(15);

                entity.Property(e => e.Guia)
                    .HasColumnName("guia")
                    .HasMaxLength(15);

                entity.Property(e => e.GuiaH1)
                    .HasColumnName("guiaH1")
                    .HasMaxLength(15);

                entity.Property(e => e.GuiaH2)
                    .HasColumnName("guiaH2")
                    .HasMaxLength(15);

                entity.Property(e => e.GuiaM1)
                    .HasColumnName("guiaM1")
                    .HasMaxLength(15);

                entity.Property(e => e.GuiaM2)
                    .HasColumnName("guiaM2")
                    .HasMaxLength(15);

                entity.Property(e => e.Lema)
                    .HasColumnName("lema")
                    .HasMaxLength(50);

                entity.Property(e => e.Logistica)
                    .HasColumnName("logistica")
                    .HasMaxLength(15);

                entity.Property(e => e.MontoComida)
                    .HasColumnName("montoComida")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MontoDecoracion)
                    .HasColumnName("montoDecoracion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MontoLogistica)
                    .HasColumnName("montoLogistica")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MontoOtros)
                    .HasColumnName("montoOtros")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MontoServicio)
                    .HasColumnName("montoServicio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MontoTransporte)
                    .HasColumnName("montoTransporte")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Musica)
                    .HasColumnName("musica")
                    .HasMaxLength(15);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(70);

                entity.Property(e => e.Objetivo)
                    .HasColumnName("objetivo")
                    .HasMaxLength(400);

                entity.Property(e => e.Servidor)
                    .HasColumnName("servidor")
                    .HasMaxLength(15);

                entity.Property(e => e.TotalDinero)
                    .HasColumnName("totalDinero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TotalInvertido)
                    .HasColumnName("totalInvertido")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TotalRestante)
                    .HasColumnName("totalRestante")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.AsistenteNavigation)
                    .WithMany(p => p.EncuentrosAsistenteNavigation)
                    .HasForeignKey(d => d.Asistente)
                    .HasConstraintName("encuentros_ibfk_2");

                entity.HasOne(d => d.AsistenteCocinaNavigation)
                    .WithMany(p => p.EncuentrosAsistenteCocinaNavigation)
                    .HasForeignKey(d => d.AsistenteCocina)
                    .HasConstraintName("encuentros_ibfk_6");

                entity.HasOne(d => d.CocinaNavigation)
                    .WithMany(p => p.EncuentrosCocinaNavigation)
                    .HasForeignKey(d => d.Cocina)
                    .HasConstraintName("encuentros_ibfk_5");

                entity.HasOne(d => d.CoordinadorNavigation)
                    .WithMany(p => p.EncuentrosCoordinadorNavigation)
                    .HasForeignKey(d => d.Coordinador)
                    .HasConstraintName("encuentros_ibfk_1");

                entity.HasOne(d => d.DecoracionNavigation)
                    .WithMany(p => p.EncuentrosDecoracionNavigation)
                    .HasForeignKey(d => d.Decoracion)
                    .HasConstraintName("encuentros_ibfk_14");

                entity.HasOne(d => d.FinanzasNavigation)
                    .WithMany(p => p.EncuentrosFinanzasNavigation)
                    .HasForeignKey(d => d.Finanzas)
                    .HasConstraintName("encuentros_ibfk_13");

                entity.HasOne(d => d.GuiaNavigation)
                    .WithMany(p => p.EncuentrosGuiaNavigation)
                    .HasForeignKey(d => d.Guia)
                    .HasConstraintName("encuentros_ibfk_12");

                entity.HasOne(d => d.GuiaH1Navigation)
                    .WithMany(p => p.EncuentrosGuiaH1Navigation)
                    .HasForeignKey(d => d.GuiaH1)
                    .HasConstraintName("encuentros_ibfk_8");

                entity.HasOne(d => d.GuiaH2Navigation)
                    .WithMany(p => p.EncuentrosGuiaH2Navigation)
                    .HasForeignKey(d => d.GuiaH2)
                    .HasConstraintName("encuentros_ibfk_9");

                entity.HasOne(d => d.GuiaM1Navigation)
                    .WithMany(p => p.EncuentrosGuiaM1Navigation)
                    .HasForeignKey(d => d.GuiaM1)
                    .HasConstraintName("encuentros_ibfk_10");

                entity.HasOne(d => d.GuiaM2Navigation)
                    .WithMany(p => p.EncuentrosGuiaM2Navigation)
                    .HasForeignKey(d => d.GuiaM2)
                    .HasConstraintName("encuentros_ibfk_11");

                entity.HasOne(d => d.LogisticaNavigation)
                    .WithMany(p => p.EncuentrosLogisticaNavigation)
                    .HasForeignKey(d => d.Logistica)
                    .HasConstraintName("encuentros_ibfk_3");

                entity.HasOne(d => d.MusicaNavigation)
                    .WithMany(p => p.EncuentrosMusicaNavigation)
                    .HasForeignKey(d => d.Musica)
                    .HasConstraintName("encuentros_ibfk_7");

                entity.HasOne(d => d.ServidorNavigation)
                    .WithMany(p => p.EncuentrosServidorNavigation)
                    .HasForeignKey(d => d.Servidor)
                    .HasConstraintName("encuentros_ibfk_4");
            });

            modelBuilder.Entity<Encuentrosmatricula>(entity =>
            {
                entity.HasKey(e => e.CodigoEncMatricula);

                entity.ToTable("encuentrosmatricula");

                entity.HasIndex(e => e.CodigoEncuentro)
                    .HasName("codigoEncuentro");

                entity.HasIndex(e => e.CodigoPersona)
                    .HasName("codigoPersona");

                entity.HasIndex(e => e.Guia)
                    .HasName("guia");

                entity.Property(e => e.CodigoEncMatricula)
                    .HasColumnName("codigoEncMatricula")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Abono)
                    .HasColumnName("abono")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoEncuentro)
                    .HasColumnName("codigoEncuentro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoPersona)
                    .IsRequired()
                    .HasColumnName("codigoPersona")
                    .HasMaxLength(15);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'Prematriculado'");

                entity.Property(e => e.Guia)
                    .HasColumnName("guia")
                    .HasMaxLength(15);

                entity.Property(e => e.Observaciones)
                    .HasColumnName("observaciones")
                    .HasMaxLength(500);

                entity.Property(e => e.Saldo)
                    .HasColumnName("saldo")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CodigoEncuentroNavigation)
                    .WithMany(p => p.Encuentrosmatricula)
                    .HasForeignKey(d => d.CodigoEncuentro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("encuentrosmatricula_ibfk_1");

                entity.HasOne(d => d.CodigoPersonaNavigation)
                    .WithMany(p => p.EncuentrosmatriculaCodigoPersonaNavigation)
                    .HasForeignKey(d => d.CodigoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("encuentrosmatricula_ibfk_2");

                entity.HasOne(d => d.GuiaNavigation)
                    .WithMany(p => p.EncuentrosmatriculaGuiaNavigation)
                    .HasForeignKey(d => d.Guia)
                    .HasConstraintName("encuentrosmatricula_ibfk_3");
            });

            modelBuilder.Entity<Informescelulares>(entity =>
            {
                entity.HasKey(e => e.CodigoInformeCelular);

                entity.ToTable("informescelulares");

                entity.Property(e => e.CodigoInformeCelular)
                    .HasColumnName("codigoInformeCelular")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Asistencia)
                    .HasColumnName("asistencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Observaciones)
                    .HasColumnName("observaciones")
                    .HasMaxLength(500);

                entity.Property(e => e.Ofrenda)
                    .HasColumnName("ofrenda")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SeRealizo)
                    .HasColumnName("seRealizo")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Visitas)
                    .HasColumnName("visitas")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Matriculaenlinea>(entity =>
            {
                entity.HasKey(e => e.CodigoMatriculaEnLinea);

                entity.ToTable("matriculaenlinea");

                entity.HasIndex(e => e.CodigoCurso)
                    .HasName("codigoCurso");

                entity.HasIndex(e => e.Maestro)
                    .HasName("maestro");

                entity.Property(e => e.CodigoMatriculaEnLinea)
                    .HasColumnName("codigoMatriculaEnLinea")
                    .HasMaxLength(15);

                entity.Property(e => e.CantAprobados)
                    .HasColumnName("cantAprobados")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CantEstudiantes)
                    .HasColumnName("cantEstudiantes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CantReprobados)
                    .HasColumnName("cantReprobados")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoCurso)
                    .HasColumnName("codigoCurso")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaFinal)
                    .HasColumnName("fechaFinal")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Maestro)
                    .IsRequired()
                    .HasColumnName("maestro")
                    .HasMaxLength(15);

                entity.Property(e => e.MontoIngreso)
                    .HasColumnName("montoIngreso")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CodigoCursoNavigation)
                    .WithMany(p => p.Matriculaenlinea)
                    .HasForeignKey(d => d.CodigoCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("matriculaenlinea_ibfk_1");

                entity.HasOne(d => d.MaestroNavigation)
                    .WithMany(p => p.Matriculaenlinea)
                    .HasForeignKey(d => d.Maestro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("matriculaenlinea_ibfk_2");
            });

            modelBuilder.Entity<Matriculaenlineaalumnos>(entity =>
            {
                entity.HasKey(e => e.CodigoMatriculaEnLineaAlumnos);

                entity.ToTable("matriculaenlineaalumnos");

                entity.HasIndex(e => e.Alumno)
                    .HasName("alumno");

                entity.Property(e => e.CodigoMatriculaEnLineaAlumnos)
                    .HasColumnName("codigoMatriculaEnLineaAlumnos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Alumno)
                    .IsRequired()
                    .HasColumnName("alumno")
                    .HasMaxLength(15);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(20);

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pago)
                    .HasColumnName("pago")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.AlumnoNavigation)
                    .WithMany(p => p.Matriculaenlineaalumnos)
                    .HasForeignKey(d => d.Alumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("matriculaenlineaalumnos_ibfk_1");
            });

            modelBuilder.Entity<Ministerios>(entity =>
            {
                entity.HasKey(e => e.CodigoMinisterio);

                entity.ToTable("ministerios");

                entity.Property(e => e.CodigoMinisterio)
                    .HasColumnName("codigoMinisterio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CantMiembros)
                    .HasColumnName("cantMiembros")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Niveles>(entity =>
            {
                entity.HasKey(e => e.CodigoNivel);

                entity.ToTable("niveles");

                entity.Property(e => e.CodigoNivel)
                    .HasColumnName("codigoNivel")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.Tema)
                    .IsRequired()
                    .HasColumnName("tema")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Niveleslecciones>(entity =>
            {
                entity.HasKey(e => e.CodigoNivelLeccion);

                entity.ToTable("niveleslecciones");

                entity.HasIndex(e => e.CodigoNivel)
                    .HasName("codigoNivel");

                entity.Property(e => e.CodigoNivelLeccion)
                    .HasColumnName("codigoNivelLeccion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoNivel)
                    .HasColumnName("codigoNivel")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.NumeroLeccion)
                    .HasColumnName("numeroLeccion")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CodigoNivelNavigation)
                    .WithMany(p => p.Niveleslecciones)
                    .HasForeignKey(d => d.CodigoNivel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("niveleslecciones_ibfk_1");
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.HasKey(e => e.CodigoPersona);

                entity.ToTable("personas");

                entity.HasIndex(e => e.CodigoArea)
                    .HasName("codigoArea");

                entity.HasIndex(e => e.CodigoMinisterio)
                    .HasName("codigoMinisterio");

                entity.HasIndex(e => e.Lider)
                    .HasName("lider");

                entity.HasIndex(e => e.NivelAcademias)
                    .HasName("nivelAcademias");

                entity.Property(e => e.CodigoPersona)
                    .HasColumnName("codigoPersona")
                    .HasMaxLength(15);

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasColumnName("apellido1")
                    .HasMaxLength(15);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasColumnName("apellido2")
                    .HasMaxLength(15);

                entity.Property(e => e.CodigoArea)
                    .HasColumnName("codigoArea")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoMinisterio)
                    .HasColumnName("codigoMinisterio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CumbreLideres)
                    .HasColumnName("cumbreLideres")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.CumbreTimoteos)
                    .HasColumnName("cumbreTimoteos")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(500);

                entity.Property(e => e.FechaDeNacimiento)
                    .HasColumnName("fechaDeNacimiento")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fechaIngreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lider)
                    .HasColumnName("lider")
                    .HasMaxLength(15);

                entity.Property(e => e.NivelAcademias)
                    .HasColumnName("nivelAcademias")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(15);

                entity.Property(e => e.NombreCompletoConyuge)
                    .HasColumnName("nombreCompletoConyuge")
                    .HasMaxLength(70);

                entity.Property(e => e.NombreCompletoEncargado)
                    .HasColumnName("nombreCompletoEncargado")
                    .HasMaxLength(70);

                entity.Property(e => e.NombreCompletoMadre)
                    .HasColumnName("nombreCompletoMadre")
                    .HasMaxLength(70);

                entity.Property(e => e.NombreCompletoPadre)
                    .HasColumnName("nombreCompletoPadre")
                    .HasMaxLength(70);

                entity.Property(e => e.ParentescoEncargado)
                    .HasColumnName("parentescoEncargado")
                    .HasMaxLength(20);

                entity.Property(e => e.Sexo)
                    .HasColumnName("sexo")
                    .HasMaxLength(10);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(15);

                entity.Property(e => e.TelefonoConyuge)
                    .HasColumnName("telefonoConyuge")
                    .HasMaxLength(15);

                entity.Property(e => e.TelefonoEncargado)
                    .HasColumnName("telefonoEncargado")
                    .HasMaxLength(15);

                entity.Property(e => e.TelefonoMadre)
                    .HasColumnName("telefonoMadre")
                    .HasMaxLength(15);

                entity.Property(e => e.TelefonoPadre)
                    .HasColumnName("telefonoPadre")
                    .HasMaxLength(15);

                entity.HasOne(d => d.CodigoAreaNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.CodigoArea)
                    .HasConstraintName("personas_ibfk_2");

                entity.HasOne(d => d.CodigoMinisterioNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.CodigoMinisterio)
                    .HasConstraintName("personas_ibfk_1");

                entity.HasOne(d => d.LiderNavigation)
                    .WithMany(p => p.InverseLiderNavigation)
                    .HasForeignKey(d => d.Lider)
                    .HasConstraintName("personas_ibfk_4");

                entity.HasOne(d => d.NivelAcademiasNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.NivelAcademias)
                    .HasConstraintName("personas_ibfk_3");
            });

            modelBuilder.Entity<Personasroles>(entity =>
            {
                entity.HasKey(e => e.CodigoPersonasRoles);

                entity.ToTable("personasroles");

                entity.HasIndex(e => e.CodigoPersona)
                    .HasName("codigoPersona");

                entity.HasIndex(e => e.CodigoRol)
                    .HasName("codigoRol");

                entity.Property(e => e.CodigoPersonasRoles)
                    .HasColumnName("codigoPersonasRoles")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoPersona)
                    .IsRequired()
                    .HasColumnName("codigoPersona")
                    .HasMaxLength(15);

                entity.Property(e => e.CodigoRol)
                    .HasColumnName("codigoRol")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CodigoPersonaNavigation)
                    .WithMany(p => p.Personasroles)
                    .HasForeignKey(d => d.CodigoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("personasroles_ibfk_1");

                entity.HasOne(d => d.CodigoRolNavigation)
                    .WithMany(p => p.Personasroles)
                    .HasForeignKey(d => d.CodigoRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("personasroles_ibfk_2");
            });

            modelBuilder.Entity<Procesoox3>(entity =>
            {
                entity.HasKey(e => e.CodigoProcesoOx3);

                entity.ToTable("procesoox3");

                entity.Property(e => e.CodigoProcesoOx3)
                    .HasColumnName("codigoProcesoOx3")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CantOrando)
                    .HasColumnName("cantOrando")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaFinal)
                    .HasColumnName("fechaFinal")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalConvertidos)
                    .HasColumnName("totalConvertidos")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Procesoox3informer5>(entity =>
            {
                entity.HasKey(e => e.CodigoProcesoOx3InformeR5);

                entity.ToTable("procesoox3informer5");

                entity.HasIndex(e => e.CodigoProcesoOx3Personas)
                    .HasName("codigoProcesoOx3Personas");

                entity.Property(e => e.CodigoProcesoOx3InformeR5)
                    .HasColumnName("codigoProcesoOx3InformeR5")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Asistencia)
                    .HasColumnName("asistencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoProcesoOx3Personas)
                    .HasColumnName("codigoProcesoOx3Personas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Convertidos)
                    .HasColumnName("convertidos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Observaciones)
                    .HasColumnName("observaciones")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ofrenda)
                    .HasColumnName("ofrenda")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Visitas)
                    .HasColumnName("visitas")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CodigoProcesoOx3PersonasNavigation)
                    .WithMany(p => p.Procesoox3informer5)
                    .HasForeignKey(d => d.CodigoProcesoOx3Personas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("procesoox3informer5_ibfk_1");
            });

            modelBuilder.Entity<Procesoox3informer6>(entity =>
            {
                entity.HasKey(e => e.CodigoProcesoOx3InformeR6);

                entity.ToTable("procesoox3informer6");

                entity.HasIndex(e => e.CodigoProcesoOx3Personas)
                    .HasName("codigoProcesoOx3Personas");

                entity.Property(e => e.CodigoProcesoOx3InformeR6)
                    .HasColumnName("codigoProcesoOx3InformeR6")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Asistencia)
                    .HasColumnName("asistencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoProcesoOx3Personas)
                    .HasColumnName("codigoProcesoOx3Personas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Convertidos)
                    .HasColumnName("convertidos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Observaciones)
                    .HasColumnName("observaciones")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ofrenda)
                    .HasColumnName("ofrenda")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Visitas)
                    .HasColumnName("visitas")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CodigoProcesoOx3PersonasNavigation)
                    .WithMany(p => p.Procesoox3informer6)
                    .HasForeignKey(d => d.CodigoProcesoOx3Personas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("procesoox3informer6_ibfk_1");
            });

            modelBuilder.Entity<Procesoox3personas>(entity =>
            {
                entity.HasKey(e => e.CodigoProcesoOx3Personas);

                entity.ToTable("procesoox3personas");

                entity.HasIndex(e => e.CodigoProcesoOx3)
                    .HasName("codigoProcesoOx3");

                entity.HasIndex(e => e.Codigopersona)
                    .HasName("codigopersona");

                entity.Property(e => e.CodigoProcesoOx3Personas)
                    .HasColumnName("codigoProcesoOx3Personas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoProcesoOx3)
                    .HasColumnName("codigoProcesoOx3")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Codigopersona)
                    .HasColumnName("codigopersona")
                    .HasMaxLength(15);

                entity.Property(e => e.ContactoDos1)
                    .HasColumnName("contactoDos1")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ContactoDos2)
                    .HasColumnName("contactoDos2")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ContactoDos3)
                    .HasColumnName("contactoDos3")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ContactoUno1)
                    .HasColumnName("contactoUno1")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ContactoUno2)
                    .HasColumnName("contactoUno2")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ContactoUno3)
                    .HasColumnName("contactoUno3")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasColumnName("nombre1")
                    .HasMaxLength(70);

                entity.Property(e => e.Nombre2)
                    .IsRequired()
                    .HasColumnName("nombre2")
                    .HasMaxLength(70);

                entity.Property(e => e.Nombre3)
                    .IsRequired()
                    .HasColumnName("nombre3")
                    .HasMaxLength(70);

                entity.Property(e => e.Observaciones1)
                    .HasColumnName("observaciones1")
                    .HasMaxLength(500);

                entity.Property(e => e.Observaciones2)
                    .HasColumnName("observaciones2")
                    .HasMaxLength(500);

                entity.Property(e => e.Observaciones3)
                    .HasColumnName("observaciones3")
                    .HasMaxLength(500);

                entity.Property(e => e.R5Direccion)
                    .HasColumnName("r5Direccion")
                    .HasMaxLength(500);

                entity.Property(e => e.R5Fecha)
                    .HasColumnName("r5Fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.R5Hora)
                    .HasColumnName("r5Hora")
                    .HasMaxLength(10);

                entity.Property(e => e.R5Lugar)
                    .HasColumnName("r5Lugar")
                    .HasMaxLength(40);

                entity.Property(e => e.R6Direccion)
                    .HasColumnName("r6Direccion")
                    .HasMaxLength(500);

                entity.Property(e => e.R6Fecha)
                    .HasColumnName("r6Fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.R6Hora)
                    .HasColumnName("r6Hora")
                    .HasMaxLength(10);

                entity.Property(e => e.R6Lugar)
                    .HasColumnName("r6Lugar")
                    .HasMaxLength(40);

                entity.HasOne(d => d.CodigoProcesoOx3Navigation)
                    .WithMany(p => p.Procesoox3personas)
                    .HasForeignKey(d => d.CodigoProcesoOx3)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("procesoox3personas_ibfk_1");

                entity.HasOne(d => d.CodigopersonaNavigation)
                    .WithMany(p => p.Procesoox3personas)
                    .HasForeignKey(d => d.Codigopersona)
                    .HasConstraintName("procesoox3personas_ibfk_2");
            });

            modelBuilder.Entity<Reencuentroabonos>(entity =>
            {
                entity.HasKey(e => e.CodigoReecuentroAbonos);

                entity.ToTable("reencuentroabonos");

                entity.HasIndex(e => e.CodigoReMatricula)
                    .HasName("codigoReMatricula");

                entity.Property(e => e.CodigoReecuentroAbonos)
                    .HasColumnName("codigoReecuentroAbonos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Abono)
                    .HasColumnName("abono")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoReMatricula)
                    .HasColumnName("codigoReMatricula")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CodigoReMatriculaNavigation)
                    .WithMany(p => p.Reencuentroabonos)
                    .HasForeignKey(d => d.CodigoReMatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reencuentroabonos_ibfk_1");
            });

            modelBuilder.Entity<Reencuentros>(entity =>
            {
                entity.HasKey(e => e.CodigoReencuentro);

                entity.ToTable("reencuentros");

                entity.Property(e => e.CodigoReencuentro)
                    .HasColumnName("codigoReencuentro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Asistencia)
                    .HasColumnName("asistencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaFinal)
                    .HasColumnName("fechaFinal")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lema)
                    .HasColumnName("lema")
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(70);

                entity.Property(e => e.Objetivo)
                    .HasColumnName("objetivo")
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<Reencuentrosmatricula>(entity =>
            {
                entity.HasKey(e => e.CodigoReMatricula);

                entity.ToTable("reencuentrosmatricula");

                entity.HasIndex(e => e.CodigoPersona)
                    .HasName("codigoPersona");

                entity.HasIndex(e => e.CodigoReencuentro)
                    .HasName("codigoReencuentro");

                entity.HasIndex(e => e.Guia)
                    .HasName("guia");

                entity.Property(e => e.CodigoReMatricula)
                    .HasColumnName("codigoReMatricula")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Abono)
                    .HasColumnName("abono")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoPersona)
                    .IsRequired()
                    .HasColumnName("codigoPersona")
                    .HasMaxLength(15);

                entity.Property(e => e.CodigoReencuentro)
                    .HasColumnName("codigoReencuentro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Guia)
                    .IsRequired()
                    .HasColumnName("guia")
                    .HasMaxLength(15);

                entity.Property(e => e.Saldo)
                    .HasColumnName("saldo")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CodigoPersonaNavigation)
                    .WithMany(p => p.ReencuentrosmatriculaCodigoPersonaNavigation)
                    .HasForeignKey(d => d.CodigoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reencuentrosmatricula_ibfk_2");

                entity.HasOne(d => d.CodigoReencuentroNavigation)
                    .WithMany(p => p.Reencuentrosmatricula)
                    .HasForeignKey(d => d.CodigoReencuentro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reencuentrosmatricula_ibfk_1");

                entity.HasOne(d => d.GuiaNavigation)
                    .WithMany(p => p.ReencuentrosmatriculaGuiaNavigation)
                    .HasForeignKey(d => d.Guia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reencuentrosmatricula_ibfk_3");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.CodigoRol);

                entity.ToTable("roles");

                entity.HasIndex(e => e.CodigoMinisterio)
                    .HasName("codigoMinisterio");

                entity.Property(e => e.CodigoRol)
                    .HasColumnName("codigoRol")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoMinisterio)
                    .HasColumnName("codigoMinisterio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(40);

                entity.HasOne(d => d.CodigoMinisterioNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.CodigoMinisterio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roles_ibfk_1");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Usuario);

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.CodigoPersona)
                    .HasName("codigoPersona");

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(25);

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasMaxLength(500);

                entity.Property(e => e.CodigoPersona)
                    .IsRequired()
                    .HasColumnName("codigoPersona")
                    .HasMaxLength(15);

                entity.Property(e => e.CodigoRecuperacion)
                    .HasColumnName("codigoRecuperacion")
                    .HasMaxLength(20);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasMaxLength(50);

                entity.Property(e => e.CorreoSeguridad)
                    .HasColumnName("correoSeguridad")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CodigoPersonaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CodigoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuarios_ibfk_1");
            });
        }
    }
}
