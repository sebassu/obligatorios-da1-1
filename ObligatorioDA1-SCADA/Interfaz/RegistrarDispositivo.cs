using System;
using System.Windows.Forms;
using Dominio;

namespace Interfaz
{
    public partial class RegistrarDispositivo : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;
        private Dispositivo dispositivoAModificar;

        public RegistrarDispositivo(IAccesoADatos modelo, Panel panelSistema, Dispositivo unDispositivo = null)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            dispositivoAModificar = unDispositivo;
            lblErrorNombre.Hide();
            lblErrorTipo.Hide();
            cbxTipoDispositivo.SelectedIndex = 0;
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
