using Dominio;
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
        void RegistrarIncidente(Incidente incidenteARegistrar);
        void ActualizarTipo(Tipo unTipo);
        void ActualizarElemento(ElementoSCADA unElemento);
        void ActualizarVariable(Variable unaVariable);
        void ActualizarElementoAgregacionDispositivo(ElementoSCADA unElemento, Dispositivo unDispositivo);
        void CambiarEstrategia(int codigoEstrategia);
    }
}