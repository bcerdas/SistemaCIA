# SistemaCIA

Scaffold-DbContext "server=localhost;User Id=UserCIA;password=cia1q2w3e4r;database=SistemaCIADB;" Pomelo.EntityFrameworkCore.MySql -OutputDir Models/ContextDb -f


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
