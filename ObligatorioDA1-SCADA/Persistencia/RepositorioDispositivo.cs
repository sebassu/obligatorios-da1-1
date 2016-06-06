using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    internal class RepositorioDispositivo : IRepositorio<Dispositivo>
    {
        public ContextoSCADA contexto;
        public DbSet<Dispositivo> coleccionEntidades;

        internal RepositorioDispositivo(ContextoSCADA unContexto)
        {
            contexto = unContexto;
            contexto.Configuration.LazyLoadingEnabled = true;
            coleccionEntidades = unContexto.Set<Dispositivo>();
        }

        public virtual List<Dispositivo> Obtener()
        {
            return coleccionEntidades.Include("TipoAuxiliar").ToList();
        }

        public virtual Dispositivo RetornarPorId(object id)
        {
            return coleccionEntidades.Find(id);
        }

        public virtual void Insertar(Dispositivo entidad)
        {
            contexto = new ContextoSCADA();
            contexto.Tipos.Attach(entidad.Tipo);
            contexto.DispositivosPrimarios.Add(entidad);
            contexto.SaveChanges();
        }

        public virtual void Eliminar(object id)
        {
            Dispositivo entidadAEliminar = coleccionEntidades.Find(id);
            Eliminar(entidadAEliminar);
        }

        public virtual void Eliminar(Dispositivo entidadAEliminar)
        {
            AttachSiCorresponde(entidadAEliminar);
            coleccionEntidades.Remove(entidadAEliminar);
            contexto.SaveChanges();
        }

        protected void AttachSiCorresponde(Dispositivo entidad)
        {
            if (contexto.Entry(entidad).State == EntityState.Detached)
            {
                coleccionEntidades.Attach(entidad);
            }
        }

        public virtual void Actualizar(Dispositivo entidadAActualizar)
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

