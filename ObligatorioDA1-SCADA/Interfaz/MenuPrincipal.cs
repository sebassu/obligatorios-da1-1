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
    public partial class MenuPrincipal : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;

        public MenuPrincipal(IAccesoADatos modelo, Panel panelSistema)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
        }

        private void btnAgregarInstalacion_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarInstalacion(modelo, panelSistema));
        }

        private void btnAgregarDispositivo_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarDispositivo(modelo, panelSistema));
        }

        private void btnAgregarTipoDispositivo_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarTipoDispositivo(modelo, panelSistema));
        }

        private void btnAgregarVariable_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarVariable(modelo, panelSistema));
        }

        private void btnAgregarValorVariable_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarValorVariable(modelo, panelSistema));
        }

        private void btnValoresHistoricos_Click(object sender, EventArgs e)
        {
            if (lstVariables.Items.Count != 0)
            {
                panelSistema.Controls.Clear();
                panelSistema.Controls.Add(new VariableValorHistorico(modelo, panelSistema));
            }
            else
            {
                MessageBox.Show("Debe seleccionar una variable para acceder a esta funcionalidad");
            }
        }
    }
}
