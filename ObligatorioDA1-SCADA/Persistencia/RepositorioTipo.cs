using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    internal class RepositorioTipo : IRepositorio<Tipo>
    {
        public ContextoSCADA contexto;
        public DbSet<Tipo> coleccionEntidades;

        internal RepositorioTipo(ContextoSCADA unContexto)
        {
            contexto = unContexto;
            contexto.Configuration.LazyLoadingEnabled = true;
            coleccionEntidades = unContexto.Set<Tipo>();
        }

        public virtual List<Tipo> Obtener()
        {
            return coleccionEntidades.ToList();
        }

        public virtual Tipo RetornarPorId(object id)
        {
            return coleccionEntidades.Find(id);
        }

        public virtual void Insertar(Tipo entidad)
        {
            coleccionEntidades.Add(entidad);
            contexto.SaveChanges();
        }

        public virtual void Eliminar(object id)
        {
            Tipo entidadAEliminar = coleccionEntidades.Find(id);
            Eliminar(entidadAEliminar);
        }

        public virtual void Eliminar(Tipo entidadAEliminar)
        {
            AttachSiCorresponde(entidadAEliminar);
            coleccionEntidades.Remove(entidadAEliminar);
            contexto.SaveChanges();
        }

        protected void AttachSiCorresponde(Tipo entidad)
        {
            if (contexto.Entry(entidad).State == EntityState.Detached)
            {
                coleccionEntidades.Attach(entidad);
            }
        }

        public virtual void Actualizar(Tipo entidadAActualizar)
        {
            coleccionEntidades.Attach(entidadAActualizar);
            contexto.Entry(entidadAActualizar).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        private bool fueDisposed = false;
        protected virtual void DisposeAuxiliar()
        {
            if (!fueDisposed)
            {
                contexto.Dispose();
            }
            fueDisposed = true;
        }

        public void Dispose()
        {
            DisposeAuxiliar();
            GC.SuppressFinalize(this);
        }
    }
}