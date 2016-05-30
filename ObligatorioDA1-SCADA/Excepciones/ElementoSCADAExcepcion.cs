using System;

namespace Excepciones
{
    [Serializable]
    public class ElementoSCADAExcepcion : Exception
    {
        public ElementoSCADAExcepcion(string mensaje) : base(mensaje) { }
    }
}