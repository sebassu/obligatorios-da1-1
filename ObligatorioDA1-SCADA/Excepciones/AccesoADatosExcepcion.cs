using System;

namespace Excepciones
{
    [Serializable]
    public class AccesoADatosExcepcion : Exception
    {
        public AccesoADatosExcepcion(string mensaje) : base(mensaje) { }
    }
}