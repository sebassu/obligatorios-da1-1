using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    internal class RepositorioPlantaIndustrial : IRepositorio<PlantaIndustrial>
    {
        public ContextoSCADA contexto;
        public DbSet<PlantaIndustrial> coleccionEntidades;

        internal RepositorioPlantaIndustrial(ContextoSCADA unContexto)
        {
            contexto = unContexto;
            contexto.Configuration.LazyLoadingEnabled = true;
            coleccionEntidades = unContexto.Set<PlantaIndustrial>();
        }

        public virtual List<PlantaIndustrial> Obtener()
        {
            return coleccionEntidades.ToList();
        }

        public virtual PlantaIndustrial RetornarPorId(object id)
        {
            return coleccionEntidades.Find(id);
        }

        public virtual void Insertar(PlantaIndustrial entidad)
        {
            coleccionEntidades.Add(entidad);
            contexto.SaveChanges();
        }

        public virtual void Eliminar(object id)
        {
            PlantaIndustrial entidadAEliminar = coleccionEntidades.Find(id);
            Eliminar(entidadAEliminar);
        }

        public virtual void Eliminar(PlantaIndustrial entidadAEliminar)
        {
            AttachSiCorresponde(entidadAEliminar);
            coleccionEntidades.Remove(entidadAEliminar);
            contexto.SaveChanges();
        }

        protected void AttachSiCorresponde(PlantaIndustrial entidad)
        {
            if (contexto.Entry(entidad).State == EntityState.Detached)
            {
                coleccionEntidades.Attach(entidad);
            }
        }

        public virtual void Actualizar(PlantaIndustrial entidadAActualizar)
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