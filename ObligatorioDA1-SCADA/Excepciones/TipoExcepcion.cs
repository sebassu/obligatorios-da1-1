using System;

namespace Excepciones
{
    [Serializable]
    public class TipoExcepcion : Exception
    {
        public TipoExcepcion(string mensaje) : base(mensaje) { }
    }
}