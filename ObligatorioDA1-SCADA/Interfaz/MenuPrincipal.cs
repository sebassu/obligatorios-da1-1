using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class MenuPrincipal : UserControl
    {
        private Panel panelSistema;

        public MenuPrincipal(Panel panelSistema)
        {
            InitializeComponent();
            this.panelSistema = panelSistema;
        }

        private void btnAgregarInstalacion_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarInstalacion(panelSistema));
        }

        private void btnAgregarDispositivo_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarDispositivo(panelSistema));
        }

        private void btnAgregarTipoDispositivo_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarTipoDispositivo(panelSistema));
        }

        private void btnAgregarVariable_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarVariable(panelSistema));
        }

        private void btnAgregarValorVariable_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarValorVariable(panelSistema));
        }
    }
}
