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
                foreach (Dispositivo dispositivoIteracion in manejadorDispositivosPrimerNivel.Obtener())
                {
                    listaAuxiliar.Add(dispositivoIteracion);
                }
                foreach (PlantaIndustrial plantaIndustrialIteracion in manejadorPlantasPrimerNivel.Obtener())
                {
                    listaAuxiliar.Add(plantaIndustrialIteracion);
                }
                listaAuxiliar.Sort();
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

        public void EliminarElemento(ElementoSCADA unElemento)
        {
            manejadorDispositivosPrimerNivel.Eliminar(unElemento);
        }

        public void EliminarIncidente(Incidente unIncidente)
        {
            throw new NotImplementedException();
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
            if (Auxiliar.NoEsNulo(unElemento))
            {
                Dispositivo elementoCasteadoADispositivo = unElemento as Dispositivo;
                if (Auxiliar.NoEsNulo(elementoCasteadoADispositivo))
                {
                    manejadorDispositivosPrimerNivel.Insertar(elementoCasteadoADispositivo);
                }
                else
                {
                    PlantaIndustrial elementoCasteadoAPlanta = unElemento as PlantaIndustrial;
                    if (Auxiliar.NoEsNulo(elementoCasteadoAPlanta))
                    {
                        manejadorPlantasPrimerNivel.Insertar(elementoCasteadoAPlanta);
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
            if (Auxiliar.NoEsNulo(unTipo))
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