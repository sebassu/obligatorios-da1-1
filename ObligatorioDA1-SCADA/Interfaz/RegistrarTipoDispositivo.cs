using System;
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
            lblErrorNombre.Hide();
            lblErrorDescripcion.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
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
            try
            {
                if (lblErrorNombre.Visible || lblErrorDescripcion.Visible)
                {
                    MessageBox.Show("No se puede registrar el tipo de dispositivo, hay campos con errores de formato");
                }
                else if (Auxiliar.EsTextoValido(txtNombre.Text) && Auxiliar.EsTextoValido(txtDescripcion.Text))
                {
                    Tipo unTipo = Tipo.NombreDescripcion(txtNombre.Text, txtDescripcion.Text);
                    modelo.RegistrarTipo(unTipo);

                    MessageBox.Show("El tipo de dispositivo fue registrado correctamente");

                    AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
                }
                else
                {
                    MessageBox.Show("No deje campos sin rellenar");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
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
