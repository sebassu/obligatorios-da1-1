using Dominio;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistencia
{
    public class ContextoSCADA : DbContext
    {
        public DbSet<IElementoSCADA> ElementosPrimarios { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Incidente> Incidentes { get; set; }

        public ContextoSCADA() : base("name=ContextoSCADA")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContextoSCADA>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
