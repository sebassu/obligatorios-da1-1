using Dominio;
using Excepciones;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    internal class RepositorioTipo : Repositorio<Tipo>
    {
        internal RepositorioTipo(ContextoSCADA contexto) : base(contexto) { }

        //public override void Actualizar(Tipo entidadAActualizar)
        //{
        //    contexto.Tipos.Attach(entidadAActualizar);
        //    contexto.Entry(entidadAActualizar).State = EntityState.Modified;
        //    contexto.SaveChanges();
        //}

        public override void Eliminar(Tipo entidadAEliminar)
        {
            //Dispositivo dispositivoConsultado = contexto.DispositivosPrimarios.Include("TipoAuxiliar").
            //    Where(x => x.TipoAuxiliar.Equals(entidadAEliminar)) as Dispositivo;
            //da siempre null

            //Dispositivo dispositivoConsultado = contexto.DispositivosPrimarios.Where(x => x.TipoAuxiliar.Equals(entidadAEliminar)) as Dispositivo;

            List<Dispositivo> dispositivosAConsultar = contexto.Dispositivos.ToList();
            bool existeTipoAsociado = false;

            foreach (var dispo in dispositivosAConsultar)
            {
                if (dispo.Tipo.Equals(entidadAEliminar))
                {
                    existeTipoAsociado = true;
                    break;
                }
            }

            //if (dispositivoConsultado == null)
            if (existeTipoAsociado == false)
            {
                base.Eliminar(entidadAEliminar);
            }
            else
            {
                throw new AccesoADatosExcepcion("El tipo se encuentra asignado a un Dispositivo.");
            }
        }

        //public override void Insertar(Tipo entidad)
        //{
        //    contexto.Tipos.Add(entidad);
        //    contexto.SaveChanges();
        //}

        //public override List<Tipo> Obtener()
        //{
        //    return contexto.Tipos.ToList();
        //}

        //protected override void AttachSiCorresponde(Tipo entidad)
        //{
        //    if (contexto.Entry(entidad).State != EntityState.Detached)
        //    {
        //        contexto.Tipos.Attach(entidad);
        //    }
        //}
    }
}