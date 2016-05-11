using System;

namespace Excepciones
{
    [Serializable]
    public class AccesoADatosEnMemoriaExcepcion : Exception
    {
        public AccesoADatosEnMemoriaExcepcion(string mensaje) : base(mensaje) { }
    }
}