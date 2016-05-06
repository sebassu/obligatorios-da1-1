using System;

namespace Dominio
{
    public class Dispositivo
    {

        private string nombre;
        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                if (Auxiliar.EsTextoValido(value))
                {
                    nombre = value.Trim();
                }
                else
                {
                    throw new ArgumentException("Nombre inválido.");
                }
            }
        }

        private Tipo tipoDispositivo;
        public Tipo Tipo
        {
            get
            {
                return tipoDispositivo;
            }
            set
            {
                if (Auxiliar.NoEsNulo(value))
                {
                    tipoDispositivo = value;
                }
                else
                {
                    throw new ArgumentException("Tipo inválido.");
                }
            }
        }

        private bool enUso;
        public bool EnUso
        {
            get
            {
                return enUso;
            }
            set
            {
                enUso = value;
            }
        }
    }
}
