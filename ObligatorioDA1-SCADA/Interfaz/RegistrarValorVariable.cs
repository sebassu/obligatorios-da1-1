using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Interfaz
{
    public partial class RegistrarValorVariable : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;

        public RegistrarValorVariable(IAccesoADatos modelo, Panel panelSistema)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new MenuPrincipal(modelo, panelSistema));
        }
    }
}
