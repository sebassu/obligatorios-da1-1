using System;
using Dominio;
using System.Collections;
using Excepciones;
using System.Collections.Generic;

namespace Persistencia
{
    public class AccesoADatosBaseDeDatos : IAccesoADatos
    {
        private RepositorioDispositivo manejadorDispositivosPrimerNivel;
        private RepositorioTipo manejadorTipos;
        private RepositorioPlantaIndustrial manejadorPlantasPrimerNivel;

        public AccesoADatosBaseDeDatos()
        {
            manejadorTipos = new RepositorioTipo(new ContextoSCADA());
            manejadorDispositivosPrimerNivel = new RepositorioDispositivo(new ContextoSCADA());
            manejadorPlantasPrimerNivel = new RepositorioPlantaIndustrial(new ContextoSCADA());
        }

        public IList ElementosPrimarios
        {
            get
            {
                List<ElementoSCADA> listaAuxiliar = new List<ElementoSCADA>();
                foreach (PlantaIndustrial plantaIndustrialIteracion in manejadorPlantasPrimerNivel.Obtener())
                {
                    listaAuxiliar.Add(plantaIndustrialIteracion);
                }
                foreach (Dispositivo dispositivoIteracion in manejadorDispositivosPrimerNivel.Obtener())
                {
                    listaAuxiliar.Add(dispositivoIteracion);
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
            Action<Dispositivo> insercionDispositivo = delegate (Dispositivo d) { manejadorDispositivosPrimerNivel.Insertar(d); };
            Action<PlantaIndustrial> insercionPlanta = delegate (PlantaIndustrial p) { manejadorPlantasPrimerNivel.Insertar(p); };
            EjecutarAccionEnSetQueCorresponda(unElemento, insercionDispositivo, insercionPlanta);
        }

        public void EliminarElemento(ElementoSCADA unElemento)
        {
            Action<Dispositivo> eliminacionDispositivo = delegate (Dispositivo d) { manejadorDispositivosPrimerNivel.Eliminar(d); };
            Action<PlantaIndustrial> eliminacionPlanta = delegate (PlantaIndustrial p) { manejadorPlantasPrimerNivel.Eliminar(p); };
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
    }
}