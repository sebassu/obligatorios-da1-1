using System;

namespace Excepciones
{
    [Serializable]
    public class IncidenteExcepcion : Exception
    {
        public IncidenteExcepcion(string mensaje) : base(mensaje) { }
    }
}