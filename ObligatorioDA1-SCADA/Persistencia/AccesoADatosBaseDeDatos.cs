using System;
using Dominio;
using System.Collections;
using Excepciones;
using System.Collections.Generic;

namespace Persistencia
{
    public class AccesoADatosBaseDeDatos : IAccesoADatos
    {
        private RepositorioDispositivo manejadorDispositivos;
        private RepositorioTipo manejadorTipos;
        private RepositorioPlantaIndustrial manejadorPlantas;
        private RepositorioInstalacion manejadorInstalaciones;

        public AccesoADatosBaseDeDatos()
        {
            manejadorTipos = new RepositorioTipo(new ContextoSCADA());
            manejadorDispositivos = new RepositorioDispositivo(new ContextoSCADA());
            manejadorPlantas = new RepositorioPlantaIndustrial(new ContextoSCADA());
            manejadorInstalaciones = new RepositorioInstalacion(new ContextoSCADA());
        }

        public IList ElementosPrimarios
        {
            get
            {
                List<ElementoSCADA> listaAuxiliar = new List<ElementoSCADA>();
                foreach (PlantaIndustrial plantaIndustrialIteracion in manejadorPlantas.Obtener())
                {
                    if (plantaIndustrialIteracion.EsDePrimerNivel())
                    {
                        listaAuxiliar.Add(plantaIndustrialIteracion);
                    }
                }
                foreach (Dispositivo dispositivoIteracion in manejadorDispositivos.Obtener())
                {
                    if (dispositivoIteracion.EsDePrimerNivel())
                    {
                        listaAuxiliar.Add(dispositivoIteracion);
                    }
                }
                return listaAuxiliar.AsReadOnly();
            }
        }

        public void EliminarDatos()
        {
            ContextoSCADA contexto = new ContextoSCADA();
            contexto.EliminarDatos();
        }

        public IList Incidentes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList Tipos
        {
            get
            {
                return manejadorTipos.Obtener().AsReadOnly();
            }
        }

        public void EliminarTipo(Tipo unTipo)
        {
            manejadorTipos.Eliminar(unTipo);
        }

        public bool ExistenTipos()
        {
            return manejadorTipos.Obtener().Count != 0;
        }

        public void RegistrarElemento(ElementoSCADA unElemento)
        {
            Action<Dispositivo> insercionDispositivo = delegate (Dispositivo d) { manejadorDispositivos.Insertar(d); };
            Action<PlantaIndustrial> insercionPlanta = delegate (PlantaIndustrial p) { manejadorPlantas.Insertar(p); };
            EjecutarAccionEnSetQueCorresponda(unElemento, insercionDispositivo, insercionPlanta);
        }

        public void EliminarElemento(ElementoSCADA unElemento)
        {
            Action<Dispositivo> eliminacionDispositivo = delegate (Dispositivo d) { manejadorDispositivos.Eliminar(d); };
            Action<PlantaIndustrial> eliminacionPlanta = delegate (PlantaIndustrial p) { manejadorPlantas.Eliminar(p); };
            EjecutarAccionEnSetQueCorresponda(unElemento, eliminacionDispositivo, eliminacionPlanta);
        }

        private void EjecutarAccionEnSetQueCorresponda(ElementoSCADA unElemento, Action<Dispositivo> accionAEjecutarParaDispositivo, Action<PlantaIndustrial> accionAEjecutarParaPlanta)
        {
            if (Auxiliar.NoEsNulo(unElemento))
            {
                Dispositivo elementoCasteadoADispositivo = unElemento as Dispositivo;
                if (Auxiliar.NoEsNulo(elementoCasteadoADispositivo))
                {
                    accionAEjecutarParaDispositivo(elementoCasteadoADispositivo);
                }
                else
                {
                    PlantaIndustrial elementoCasteadoAPlanta = unElemento as PlantaIndustrial;
                    if (Auxiliar.NoEsNulo(elementoCasteadoAPlanta))
                    {
                        accionAEjecutarParaPlanta(elementoCasteadoAPlanta);
                    }
                    else
                    {
                        throw new AccesoADatosExcepcion("Tipo de elemento no soportado.");
                    }
                }
            }
            else
            {
                throw new AccesoADatosExcepcion("Elemento nulo recibido.");
            }
        }

        public void RegistrarIncidente(ElementoSCADA unElemento, Incidente incidenteARegistrar)
        {
            throw new NotImplementedException();
        }

        public void RegistrarTipo(Tipo unTipo)
        {
            if (Auxiliar.NoEsNulo(unTipo) && !Tipos.Contains(unTipo))
            {
                manejadorTipos.Insertar(unTipo);
            }
            else
            {
                throw new AccesoADatosExcepcion("Tipo nulo recibido.");
            }
        }

        public void ActualizarTipo(Tipo unTipo)
        {
            manejadorTipos.Actualizar(unTipo);
        }

        public void ActualizarElemento(ElementoSCADA unElemento)
        {
            Action<Dispositivo> actualizacionDispositivo = delegate (Dispositivo d) { manejadorDispositivos.Actualizar(d); };
            Action<PlantaIndustrial> actualizacionPlanta = delegate (PlantaIndustrial p) { manejadorPlantas.Actualizar(p); };
            EjecutarAccionEnSetQueCorresponda(unElemento, actualizacionDispositivo, actualizacionPlanta);
        }

        public void ActualizarElementoAgregacionDispositivo(ElementoSCADA unElemento, Dispositivo unDispositivo)
        {
            if (unElemento is Instalacion)
            {
                manejadorInstalaciones.ActualizarAgregacionDispositivo((Instalacion)unElemento, unDispositivo);
            }
            else
                manejadorPlantas.ActualizarAgregacionDispositivo((PlantaIndustrial)unElemento, unDispositivo);
        }
    }
}