using Dominio;
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

        internal static void VolverAPrincipal(IAccesoADatos unSistema, Panel panelSistema)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new MenuPrincipal(unSistema, panelSistema));
        }
    }
}