using Dominio;

namespace Persistencia
{
    internal class RepositorioTipo : Repositorio<Tipo>
    {
        internal RepositorioTipo(ContextoSCADA unContexto) : base(unContexto) { }
    }
}