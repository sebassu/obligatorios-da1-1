using System;

namespace Excepciones
{
    [Serializable]
    public class VariableExcepcion : Exception
    {
        public VariableExcepcion(string mensaje) : base(mensaje) { }
    }
}