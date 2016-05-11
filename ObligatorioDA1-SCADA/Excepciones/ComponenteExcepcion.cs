using System;

namespace Excepciones
{
    [Serializable]
    public class ComponenteExcepcion : Exception
    {
        public ComponenteExcepcion(string mensaje) : base(mensaje) { }
    }
}