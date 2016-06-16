using Persistencia;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class VentanaPrincipal : Form
    {
        private IAccesoADatos modelo;
        public VentanaPrincipal(IAccesoADatos unAccesoADatos)
        {
            modelo = unAccesoADatos;
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new MenuPrincipal(modelo, panelSistema));
        }
    }
}
