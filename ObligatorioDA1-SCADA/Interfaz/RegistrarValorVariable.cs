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
        private Variable unaVariable;

        public RegistrarValorVariable(IAccesoADatos modelo, Panel panelSistema, Variable variable)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            unaVariable = variable;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new MenuPrincipal(modelo, panelSistema));
        }
    }
}
