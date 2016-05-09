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
    public partial class VariableValorHistorico : UserControl
    {
        private Panel panelSistema;

        public VariableValorHistorico(Panel panelSistema)
        {
            InitializeComponent();
            this.panelSistema = panelSistema;
        }

        private void btnVolverMenuPrincipal_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new MenuPrincipal(panelSistema));
        }
    }
}
