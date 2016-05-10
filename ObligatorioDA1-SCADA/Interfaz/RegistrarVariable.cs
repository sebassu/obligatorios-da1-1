using System;
using System.Windows.Forms;
using Dominio;

namespace Interfaz
{
    public partial class RegistrarVariable : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;

        public RegistrarVariable(IAccesoADatos modelo, Panel panelSistema)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            lblErrorNombre.Hide();
            lblErrorValores.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new MenuPrincipal(modelo, panelSistema));
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            AuxiliarInterfaz.ComprobarTexto(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //lblErrorNombre.Text = "";
            //lblErrorValores.Text = "";

            //if (txtNombre.Text.Trim() == "" && (numMin.Value >= numMax.Value))
            //{
            //    lblErrorNombre.Text = "Nombre inválido";
            //    lblErrorValores.Text = "El valor mínimo debe ser menor estricto que el valor máximo";
            //}
            //else if (txtNombre.Text.Trim() == "")
            //{
            //    lblErrorNombre.Text = "Nombre inválido";
            //}
            //else if (numMin.Value >= numMax.Value)
            //{
            //    lblErrorValores.Text = "El valor mínimo debe ser menor estricto que el valor máximo";
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

        private void rangoValores_Leave(object sender, EventArgs e)
        {
            if (numMin.Value > numMax.Value)
            {
                lblErrorValores.Show();
            }
            else
            {
                lblErrorValores.Hide();
            }
        }
    }
}
