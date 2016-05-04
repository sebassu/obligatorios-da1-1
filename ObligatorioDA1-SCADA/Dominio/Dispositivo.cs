using System;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Dispositivo
    {
        private string nombre;
        private bool enUso;
        private Tipo tipoDispositivo;

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

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                if (!String.IsNullOrEmpty(value) && contieneCaracteresAlfabeticos(value))
                {
                    nombre = value.Trim();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

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
                    throw new ArgumentException();
                }
            }
        }

        private bool contieneCaracteresAlfabeticos(string unString)
        {
            Regex caracteresAlfabeticos = new Regex(@"[A-Z]", RegexOptions.IgnoreCase);
            return caracteresAlfabeticos.IsMatch(unString);
        }
    }
}
