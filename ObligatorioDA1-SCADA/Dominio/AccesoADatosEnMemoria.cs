﻿using System;
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
                if (unComponente is Dispositivo)
                {
                    existenDispositivos = true;
                }
                else if (unComponente is Instalacion)
                {
                    existenInstalaciones = true;
                }
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

        bool existenDispositivos;
        public bool ExistenDispositivos()
        {
            return existenDispositivos;
        }

        bool existenInstalaciones;
        public bool ExistenInstalaciones()
        {
            return existenInstalaciones;
        }

        bool existenTipos;
        public bool ExistenTipos()
        {
            return existenTipos;
        }
    }
}