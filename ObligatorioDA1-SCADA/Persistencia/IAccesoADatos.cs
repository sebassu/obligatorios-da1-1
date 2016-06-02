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
        void RegistrarElemento(IElementoSCADA unElemento);
        bool EliminarTipo(Tipo unTipo);
        bool EliminarElemento(IElementoSCADA unElemento);
        bool ExistenTipos();
        void RegistrarIncidente(IElementoSCADA unElemento, Incidente incidenteARegistrar);
        void EliminarIncidente(Incidente unIncidente);
    }
}