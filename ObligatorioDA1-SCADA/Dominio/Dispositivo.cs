using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                Regex caracteresAlfabeticos = new Regex(@"[A-Z]", RegexOptions.IgnoreCase);
                if (value != null && caracteresAlfabeticos.IsMatch(value))
                {
                    nombre = value.Trim();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
