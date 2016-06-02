using Excepciones;
using System.Collections;
using System.Collections.Generic;

namespace Dominio
{
    public class AccesoADatosEnMemoria : IAccesoADatos
    {
        private List<IElementoSCADA> componentesPrimarios;
        public IList ComponentesPrimarios
        {
            get
            {
                return componentesPrimarios.AsReadOnly();
            }
        }

        private List<Tipo> tipos;
        public IList Tipos
        {
            get
            {
                return tipos.AsReadOnly();
            }
        }

        public AccesoADatosEnMemoria()
        {
            componentesPrimarios = new List<IElementoSCADA>();
            tipos = new List<Tipo>();
        }

        public void RegistrarComponente(Componente unComponente)
        {
            if (Auxiliar.NoEsNulo(unComponente))
            {
                componentesPrimarios.Add(unComponente);
            }
            else
            {
                throw new AccesoADatosEnMemoriaExcepcion("Objeto (Componente) nulo recibido.");
            }
        }

        public void RegistrarTipo(Tipo unTipo)
        {
            if (Auxiliar.NoEsNulo(unTipo))
            {
                tipos.Add(unTipo);
                existenTipos = true;
            }
            else
            {
                throw new AccesoADatosEnMemoriaExcepcion("Objeto (Tipo) nulo recibido.");
            }
        }

        public bool EliminarComponente(Componente unComponente)
        {
            return componentesPrimarios.Remove(unComponente);
        }

        public bool EliminarTipo(Tipo unTipo)
        {
            return tipos.Remove(unTipo);
        }

        bool existenTipos;
        public bool ExistenTipos()
        {
            return existenTipos;
        }

        public void RegistrarPlantaIndustrial(PlantaIndustrial unaPlanta)
        {
            if (Auxiliar.NoEsNulo(unaPlanta))
            {
                componentesPrimarios.Add(unaPlanta);
            }
            else
            {
                throw new AccesoADatosEnMemoriaExcepcion("Objeto (Planta Industrial) nulo recibido.");
            }
        }

        public bool EliminarPlantaIndustrial(PlantaIndustrial unaPlanta)
        {
            return componentesPrimarios.Remove(unaPlanta);
        }
    }
}