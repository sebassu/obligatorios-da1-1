using System;
using System.Text.RegularExpressions;

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
    }
}
