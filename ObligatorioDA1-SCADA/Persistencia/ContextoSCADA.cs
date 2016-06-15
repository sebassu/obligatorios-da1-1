using Dominio;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistencia
{
    public class ContextoSCADA : DbContext
    {
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<PlantaIndustrial> Plantas { get; set; }
        public DbSet<Instalacion> Instalaciones { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Variable> Variables { get; set; }
        public DbSet<Incidente> Incidentes { get; set; }

        public ContextoSCADA(string nombreConexion) : base(nombreConexion)
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContextoSCADA>());
        }

        public void EliminarDatos()
        {
            Plantas.RemoveRange(Plantas);
            Instalaciones.RemoveRange(Instalaciones);
            Dispositivos.RemoveRange(Dispositivos);
            SaveChanges();
            Tipos.RemoveRange(Tipos);
            SaveChanges();
            Tipos.RemoveRange(Tipos);
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Tipo>().ToTable("Tipo");
            modelBuilder.Entity<Dispositivo>().ToTable("Dispositivo");
            modelBuilder.Entity<Instalacion>().ToTable("Instalacion");
            modelBuilder.Entity<PlantaIndustrial>().ToTable("PlantaIndustrial");
            modelBuilder.Entity<Variable>().ToTable("Variable");
            modelBuilder.Entity<Tipo>().ToTable("Tipos");
            base.OnModelCreating(modelBuilder);
        }
    }
}
