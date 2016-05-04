using System;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Dispositivo
    {

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
                if (value != null)
                {
                    tipoDispositivo = value;
                }
                else
                {
                    throw new ArgumentException("Descripción inválida.");
                }
            }
        }
    }
}
