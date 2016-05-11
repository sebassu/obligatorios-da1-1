using System;

namespace Excepciones
{
    public class TipoExcepcion : Exception
    {
        public TipoExcepcion(string mensaje) : base(mensaje) { }
    }
}