﻿using Dominio;
using System.Collections;

namespace Persistencia
{
    public interface IAccesoADatos
    {
        IList ElementosPrimarios { get; }
        IList Tipos { get; }
        IList Incidentes { get; }
        void RegistrarTipo(Tipo unTipo);
        void RegistrarElemento(ElementoSCADA unElemento);
        void EliminarTipo(Tipo unTipo);
        void EliminarElemento(ElementoSCADA unElemento);
        void EliminarDatos();
        bool ExistenTipos();
        void RegistrarIncidente(ElementoSCADA unElemento, Incidente incidenteARegistrar);
        void ActualizarTipo(Tipo unTipo);
        void ActualizarElemento(ElementoSCADA unElemento);
        void ActualizarElementoAgregacionDispositivo(ElementoSCADA unElemento, Dispositivo unDispositivo);
    }
}