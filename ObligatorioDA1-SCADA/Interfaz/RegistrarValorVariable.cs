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
    public partial class RegistrarValorVariable : UserControl
    {
        private Panel panelSistema;

        public RegistrarValorVariable(Panel panelSistema)
        {
            InitializeComponent();
            this.panelSistema = panelSistema;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new MenuPrincipal(panelSistema));
        }
    }
}
