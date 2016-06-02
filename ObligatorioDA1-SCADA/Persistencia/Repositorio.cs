using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Persistencia
{
    internal class Repositorio<T> : IRepositorio<T>, IDisposable where T : class
    {
        private ContextoSCADA contexto;
        private DbSet<T> coleccionEntidades;

        internal Repositorio(ContextoSCADA unContexto)
        {
            contexto = unContexto;
            coleccionEntidades = unContexto.Set<T>();
        }

        public virtual List<T> Obtener(Expression<Func<T, bool>> expresionFiltro = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> ordenacion = null, string propertiesInclude = "")
        {
            IQueryable<T> consulta = coleccionEntidades;
            if (expresionFiltro != null)
            {
                consulta = consulta.Where(expresionFiltro);
            }
            foreach (var propertyInclude in propertiesInclude.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                consulta = consulta.Include(propertyInclude);
            }
            if (ordenacion != null)
            {
                return ordenacion(consulta).ToList();
            }
            else
            {
                return consulta.ToList();
            }
        }

        public virtual T RetornarPorId(object id)
        {
            return coleccionEntidades.Find(id);
        }

        public virtual void Insertar(T entidad)
        {
            coleccionEntidades.Add(entidad);
            contexto.SaveChanges();
        }

        public virtual void Eliminar(object id)
        {
            T entityToDelete = coleccionEntidades.Find(id);
            Eliminar(entityToDelete);
            contexto.SaveChanges();
        }

        public virtual void Eliminar(T entidadAEliminar)
        {
            if (contexto.Entry(entidadAEliminar).State == EntityState.Detached)
            {
                coleccionEntidades.Attach(entidadAEliminar);
            }
            coleccionEntidades.Remove(entidadAEliminar);
        }

        public virtual void Actualizar(T entidadAActualizar)
        {
            coleccionEntidades.Attach(entidadAActualizar);
            contexto.Entry(entidadAActualizar).State = EntityState.Modified;
        }

        private bool fueDisposed = false;
        protected virtual void Dispose(bool siendoDisposed)
        {
            if (!fueDisposed)
            {
                if (siendoDisposed)
                {
                    contexto.Dispose();
                }
            }
            fueDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

