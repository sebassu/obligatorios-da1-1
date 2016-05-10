using System;
using System.Collections;
using System.Collections.Generic;

namespace Dominio
{
    public class AccesoADatosEnMemoria : IAccesoADatos
    {
        private List<Componente> componentesPrimarios;
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
            componentesPrimarios = new List<Componente>();
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
                throw new ArgumentException("Objeto (Componente) nulo recibido.");
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
                throw new ArgumentException("Objeto (Tipo) nulo recibido.");
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

        public bool ExistenDispositivos()
        {
            foreach (Componente componenteIteracion in ComponentesPrimarios)
            {
                if (componenteIteracion is Dispositivo)
                {
                    return true;
                }
                else {
                    Instalacion componenteCasteado = componenteIteracion as Instalacion;
                    if (componenteCasteado.CantidadDispositivosHijos > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ExistenInstalaciones()
        {
            foreach (Componente componenteIteracion in ComponentesPrimarios)
            {
                if (componenteIteracion is Instalacion)
                {
                    return true;
                }
            }
            return false;
        }

        bool existenTipos;
        public bool ExistenTipos()
        {
            return existenTipos;
        }
    }
}