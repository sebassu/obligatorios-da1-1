using System.Collections;

namespace Dominio
{
    public interface IAccesoADatos
    {
        IList ElementosPrimarios { get; }
        IList Tipos { get; }
        void RegistrarTipo(Tipo unTipo);
        void RegistrarElemento(IElementoSCADA unElemento);
        bool EliminarTipo(Tipo unTipo);
        bool EliminarElemento(IElementoSCADA unElemento);
        bool ExistenTipos();
    }
}