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
    public partial class RegistrarInstalacion : UserControl
    {
        private Panel panelSistema;

        public RegistrarInstalacion(Panel panelSistema)
        {
            InitializeComponent();
            this.panelSistema = panelSistema;
            lblErrorNombre.Text = "";
        }

        private void txtNombreInstalacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Auxiliar.ComprobarTexto(sender, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new MenuPrincipal(panelSistema));
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombreInstalacion.Text.Trim() == "")
            {
                lblErrorNombre.Text = "Nombre inválido";
            }
            //else extraigo el nombre y lo cargo en la lista del sistema de instalaciones
        }
    }
}
