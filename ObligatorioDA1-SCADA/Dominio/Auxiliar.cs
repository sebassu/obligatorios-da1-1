using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Dominio
{
    public abstract class Auxiliar
    {
        internal static bool ContieneCaracteresAlfabeticos(string unString)
        {
            Regex caracteresAlfabeticos = new Regex(@"[A-Z]", RegexOptions.IgnoreCase);
            return caracteresAlfabeticos.IsMatch(unString);
        }

        internal static bool EsTextoValido(string value)
        {
            return !string.IsNullOrEmpty(value) && ContieneCaracteresAlfabeticos(value);
        }

        internal static bool NoEsNulo(object unObjeto)
        {
            return unObjeto != null;
        }

        public static void ComprobarTexto(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)
                    || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
