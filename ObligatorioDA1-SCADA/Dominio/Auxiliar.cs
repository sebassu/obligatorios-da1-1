using System.Collections;
using System.Text.RegularExpressions;

namespace Dominio
{
    public abstract class Auxiliar
    {
        public static bool ContieneCaracteresAlfabeticos(string unString)
        {
            Regex caracteresAlfabeticos = new Regex(@"[A-Z]", RegexOptions.IgnoreCase);
            return caracteresAlfabeticos.IsMatch(unString);
        }

        public static bool EsTextoValido(string value)
        {
            return !string.IsNullOrEmpty(value) && ContieneCaracteresAlfabeticos(value);
        }

        public static bool NoEsNulo(object unObjeto)
        {
            return unObjeto != null;
        }

        public static bool EsListaVacia(IList variables)
        {
            return variables.Count == 0;
        }
    }
}
