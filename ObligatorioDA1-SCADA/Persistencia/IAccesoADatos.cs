using Dominio;
using System.Collections;

namespace Persistencia
{
    public interface IAccesoADatos
    {
        IList ElementosPrimarios { get; }
        IList Tipos { get; }
        IList Incidentes { get; }
        EstrategiaGuardadoIncidentes ManejadorIncidentes { get; set; }
        void RegistrarTipo(Tipo unTipo);
        void RegistrarElemento(ElementoSCADA unElemento);
        void EliminarTipo(Tipo unTipo);
        void EliminarElemento(ElementoSCADA unElemento);
        void EliminarDatos();
        bool ExistenTipos();
        void RegistrarIncidente(Incidente incidenteARegistrar);
        void ActualizarTipo(Tipo unTipo);
        void ActualizarElemento(ElementoSCADA unElemento, bool afectaATodaLaJerarquia = false);
        void ActualizarVariable(Variable unaVariable);
        void ActualizarElementoAgregacionDispositivo(ElementoSCADA unElemento, Dispositivo unDispositivo);
        void CambiarEstrategia(int codigoEstrategia);
        int CodigoDeEstrategiaSeleccionada();
    }
}