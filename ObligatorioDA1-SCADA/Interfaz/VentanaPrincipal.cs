using System.Windows.Forms;

namespace Interfaz
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();

            MaximizeBox = false;
            MinimizeBox = false;

            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new MenuPrincipal(panelSistema));
        }
    }
}
