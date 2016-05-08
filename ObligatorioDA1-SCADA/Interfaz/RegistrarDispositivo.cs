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
    public partial class RegistrarDispositivo : UserControl
    {
        private Panel panelSistema;

        public RegistrarDispositivo(Panel panelSistema)
        {
            InitializeComponent();
            this.panelSistema = panelSistema;
            lblErrorNombre.Text = "";
            lblErrorTipo.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new MenuPrincipal(panelSistema));
        }

        private void txtNombreDispositivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            AuxiliarInterfaz.ComprobarTexto(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombreDispositivo.Text.Trim() == "")
            {
                lblErrorNombre.Text = "Nombre inválido";
            }
            else if ((string)cbxTipoDispositivo.SelectedItem == "")
            {
                lblErrorTipo.Text = "Debe seleccionar un tipo";
            }
            //else cargo los datos en la lista de dispositivos del sistema
        }
    }
}
