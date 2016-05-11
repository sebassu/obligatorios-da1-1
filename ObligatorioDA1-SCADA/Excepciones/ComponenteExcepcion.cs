using System;

namespace Excepciones
{
    public class ComponenteExcepcion : Exception
    {
        public ComponenteExcepcion(string mensaje) : base(mensaje) { }
    }
}