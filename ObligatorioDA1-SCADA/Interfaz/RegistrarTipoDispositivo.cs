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
    public partial class RegistrarTipoDispositivo : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;

        public RegistrarTipoDispositivo(IAccesoADatos modelo, Panel panelSistema)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            txtNombre.Hide();
            txtDescripcion.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new MenuPrincipal(modelo, panelSistema));
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)
                || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            AuxiliarInterfaz.ComprobarTexto(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //lblErrorNombre.Text = "";
            //lblErrorDescripcion.Text = "";

            //if (txtNombre.Text.Trim() == "" && txtDescripcion.Text.Trim() == "")
            //{
            //    lblErrorNombre.Text = "Nombre inválido";
            //    lblErrorDescripcion.Text = "Descripción inválida";
            //}
            //else if (txtNombre.Text.Trim() == "")
            //{
            //    lblErrorNombre.Text = "Nombre inválido";
            //}
            //else if (txtDescripcion.Text.Trim() == "")
            //{
            //    lblErrorDescripcion.Text = "Descripción inválida";
            //}
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (Auxiliar.EsTextoValido(txtNombre.Text))
            {
                lblErrorNombre.Hide();
            }
            else
            {
                lblErrorNombre.Show();
            }
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (Auxiliar.EsTextoValido(txtDescripcion.Text))
            {
                lblErrorDescripcion.Hide();
            }
            else
            {
                lblErrorDescripcion.Show();
            }
        }
    }
}
