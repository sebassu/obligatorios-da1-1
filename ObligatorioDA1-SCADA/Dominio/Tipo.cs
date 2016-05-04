using System;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Tipo
    {
        private string nombre;
        private string descripcion;

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && contieneCaracteresAlfabeticos(value))
                {
                    nombre = value.Trim();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && contieneCaracteresAlfabeticos(value))
                {
                    descripcion = value.Trim();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private bool contieneCaracteresAlfabeticos(string unValor)
        {
            Regex caracteresAlfabeticos = new Regex(@"[A-Z]", RegexOptions.IgnoreCase);
            return caracteresAlfabeticos.IsMatch(unValor);
        }
    }
}