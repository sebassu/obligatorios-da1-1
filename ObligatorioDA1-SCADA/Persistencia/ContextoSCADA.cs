using Dominio;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistencia
{
    public class ContextoSCADA : DbContext
    {
        public DbSet<Dispositivo> DispositivosPrimarios { get; set; }
        public DbSet<PlantaIndustrial> PlantasPrimarias { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Incidente> Incidentes { get; set; }

        public ContextoSCADA() : base("name=ContextoSCADA")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContextoSCADA>());
        }

        public void EliminarDatos()
        {
            /*  Database.ExecuteSqlCommand("delete from ElementoSCADA");
              Database.ExecuteSqlCommand("delete from Tipo");
              Database.ExecuteSqlCommand("delete from Incidente");*/
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
