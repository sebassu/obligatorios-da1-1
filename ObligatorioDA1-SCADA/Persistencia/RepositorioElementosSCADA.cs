using Dominio;

namespace Persistencia
{
    internal class RepositorioElementosSCADA : Repositorio<IElementoSCADA>
    {
        internal RepositorioElementosSCADA(ContextoSCADA unContexto) : base(unContexto) { }

        public override void Insertar(IElementoSCADA entidadAAgregar)
        {
            if (entidadAAgregar is Dispositivo)
            {
                contexto.Tipos.Attach(((Dispositivo)entidadAAgregar).Tipo);
            }
            base.Insertar(entidadAAgregar);
        }

        public override void Eliminar(object id)
        {
            IElementoSCADA entityToDelete = coleccionEntidades.Find(id);
            Eliminar(entityToDelete);
        }

        public override void Eliminar(IElementoSCADA entidadAEliminar)
        {
            AttachSiCorresponde(entidadAEliminar);
            EliminarDependenciasSinActualizar(entidadAEliminar);
            IElementoSCADA elementoPadre = entidadAEliminar.ElementoPadre;
            if (Auxiliar.NoEsNulo(elementoPadre))
            {
                Actualizar(elementoPadre);
            }
            else
            {
                contexto.SaveChanges();
            }
        }

        private void EliminarDependenciasSinActualizar(IElementoSCADA entidadAEliminar)
        {
            AttachSiCorresponde(entidadAEliminar);
            foreach (IElementoSCADA unaDependencia in entidadAEliminar.Dependencias)
            {
                EliminarDependenciasSinActualizar(unaDependencia);
            }
            coleccionEntidades.Remove(entidadAEliminar);
        }
    }
}
