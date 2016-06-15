using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    internal class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected ContextoSCADA contexto;
        protected DbSet<T> coleccionEntidades;

        internal Repositorio(ContextoSCADA unContexto)
        {
            contexto = unContexto;
            coleccionEntidades = unContexto.Set<T>();
        }

        public virtual List<T> Obtener()
        {
            return coleccionEntidades.ToList();
        }

        public virtual void Insertar(T entidad)
        {
            coleccionEntidades.Add(entidad);
            contexto.SaveChanges();
        }

        public virtual void Eliminar(T entidadAEliminar)
        {
            AttachSiCorresponde(entidadAEliminar);
            contexto.Entry(entidadAEliminar).State = EntityState.Deleted;
            contexto.SaveChanges();
        }

        protected void AttachSiCorresponde(T entidad)
        {
            if (contexto.Entry(entidad).State == EntityState.Detached)
            {
                coleccionEntidades.Attach(entidad);
            }
        }

        public virtual void Actualizar(T entidadAActualizar)
        {
            coleccionEntidades.Attach(entidadAActualizar);
            contexto.Entry(entidadAActualizar).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}

