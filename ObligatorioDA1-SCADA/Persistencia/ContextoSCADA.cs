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

        public ContextoSCADA(string nombreConexion) : base(nombreConexion)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContextoSCADA>());
        }

        public void EliminarDatos()
        {
            Tipos.RemoveRange(Tipos);
            Dispositivos.RemoveRange(Dispositivos);
            Plantas.RemoveRange(Plantas);
            Instalaciones.RemoveRange(Instalaciones);
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
