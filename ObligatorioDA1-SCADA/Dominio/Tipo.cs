using System;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Tipo
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
                if (!String.IsNullOrEmpty(value) && contieneCaracteresAlfabeticos(value))
                {
                    this.nombre = value.Trim();
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