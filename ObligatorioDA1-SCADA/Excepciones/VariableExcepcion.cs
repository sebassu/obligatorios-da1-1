using System;

namespace Excepciones
{
    public class VariableExcepcion : Exception
    {
        public VariableExcepcion(string mensaje) : base(mensaje) { }
    }
}