using System.Windows.Forms;

namespace Interfaz
{
    internal class AuxiliarInterfaz
    {
        internal static void ComprobarTexto(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)
                    || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}