using System;
using Dominio;
using System.Collections;
using Excepciones;
using System.Collections.Generic;
using System.Data.Entity;

namespace Persistencia
{
    public class AccesoADatosBaseDeDatos : IAccesoADatos
    {
        private string stringConexion;
        private RepositorioDispositivo manejadorDispositivos;
        private RepositorioTipo manejadorTipos;
        private RepositorioPlantaIndustrial manejadorPlantas;
        private RepositorioInstalacion manejadorInstalaciones;

        private static readonly Action<Dispositivo> accionErronea = delegate (Dispositivo d) { throw new AccesoADatosExcepcion("Accion no soportada"); };

        public AccesoADatosBaseDeDatos(string stringConexionASetear)
        {
            stringConexion = stringConexionASetear;
            ContextoSCADA contexto = new ContextoSCADA(stringConexionASetear);
            manejadorTipos = new RepositorioTipo(contexto);
            manejadorDispositivos = new RepositorioDispositivo(contexto);
            manejadorPlantas = new RepositorioPlantaIndustrial(contexto);
            manejadorInstalaciones = new RepositorioInstalacion(contexto);
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
            ContextoSCADA contexto = new ContextoSCADA(stringConexion);
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
            Action<Instalacion> insercionInstalacion = delegate (Instalacion i) { manejadorInstalaciones.Insertar(i); };
            EjecutarAccionEnSetQueCorresponda(unElemento, insercionDispositivo, insercionPlanta, insercionInstalacion);
        }

        public void EliminarElemento(ElementoSCADA unElemento)
        {
            Action<Dispositivo> eliminacionDispositivo = delegate (Dispositivo d) { manejadorDispositivos.Eliminar(d); };
            Action<PlantaIndustrial> eliminacionPlanta = delegate (PlantaIndustrial p) { manejadorPlantas.Eliminar(p); };
            Action<Instalacion> eliminacionInstalacion = delegate (Instalacion i) { manejadorInstalaciones.Eliminar(i); };
            EjecutarAccionEnSetQueCorresponda(unElemento, eliminacionDispositivo, eliminacionPlanta, eliminacionInstalacion);
        }

        private void EjecutarAccionEnSetQueCorresponda(ElementoSCADA unElemento, Action<Dispositivo> accionAEjecutarParaDispositivo,
                    Action<PlantaIndustrial> accionAEjecutarParaPlanta, Action<Instalacion> accionAEjecutarParaInstalacion)
        {
            if (Auxiliar.NoEsNulo(unElemento))
            {
                Dispositivo elementoCasteadoADispositivo = unElemento as Dispositivo;
                if (Auxiliar.NoEsNulo(elementoCasteadoADispositivo))
                {
                    accionAEjecutarParaDispositivo(elementoCasteadoADispositivo);
                }
                else {
                    Instalacion elementoCasteadoAInstalacion = unElemento as Instalacion;
                    if (Auxiliar.NoEsNulo(elementoCasteadoAInstalacion))
                    {
                        accionAEjecutarParaInstalacion(elementoCasteadoAInstalacion);
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
            Action<Instalacion> actualizacionInstalacion = delegate (Instalacion i) { manejadorInstalaciones.Actualizar(i); };
            EjecutarAccionEnSetQueCorresponda(unElemento, actualizacionDispositivo, actualizacionPlanta, actualizacionInstalacion);
        }

        public void ActualizarElementoAgregacionDispositivo(ElementoSCADA unElemento, Dispositivo unDispositivo)
        {
            Action<PlantaIndustrial> actualizacionPlanta = delegate (PlantaIndustrial p) { manejadorPlantas.ActualizarAgregacionDispositivo(p, unDispositivo); };
            Action<Instalacion> actualizacionInstalacion = delegate (Instalacion i) { manejadorInstalaciones.ActualizarAgregacionDispositivo(i, unDispositivo); };
            EjecutarAccionEnSetQueCorresponda(unElemento, accionErronea, actualizacionPlanta, actualizacionInstalacion);
        }

        public void ActualizarVariable(Variable unaVariable)
        {
            using (ContextoSCADA contexto = new ContextoSCADA("name=ContextoSCADA"))
            {
                contexto.Variables.Attach(unaVariable);
                contexto.Entry(unaVariable).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}