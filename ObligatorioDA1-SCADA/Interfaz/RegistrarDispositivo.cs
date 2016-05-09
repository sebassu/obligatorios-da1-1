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
        private IAccesoADatos modelo;
        private Panel panelSistema;

        public RegistrarDispositivo(IAccesoADatos modelo, Panel panelSistema)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            txtNombreDispositivo.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new MenuPrincipal(modelo, panelSistema));
        }

        private void txtNombreDispositivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            AuxiliarInterfaz.ComprobarTexto(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //if (txtNombreDispositivo.Text.Trim() == "")
            //{
            //    lblErrorNombre.Text = "Nombre inválido";
            //}
            //else if ((string)cbxTipoDispositivo.SelectedItem == "")
            //{
            //    lblErrorTipo.Text = "Debe seleccionar un tipo";
            //}
            ////else cargo los datos en la lista de dispositivos del sistema
        }

        private void txtNombreDispositivo_Leave(object sender, EventArgs e)
        {
            if (Auxiliar.EsTextoValido(txtNombreDispositivo.Text))
            {
                lblErrorNombre.Hide();
            }
            else
            {
                lblErrorNombre.Show();
            }
        }
    }
}
