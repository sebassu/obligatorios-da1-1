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
            foreach (Tipo tipo in modelo.Tipos)
            {
                cbxTipoDispositivo.Items.Add(tipo);
            }
            if (Auxiliar.NoEsNulo(unDispositivo))
            {
                dispositivoAModificar = unDispositivo;
                txtNombreDispositivo.Text = unDispositivo.Nombre;
                chkEnUso.Checked = dispositivoAModificar.EnUso;
                cbxTipoDispositivo.SelectedItem = unDispositivo.Tipo;
            }
            else
            {
                cbxTipoDispositivo.SelectedIndex = 0;
            }
            lblErrorNombre.Hide();
            lblErrorTipo.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
        }

        private void txtNombreDispositivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            AuxiliarInterfaz.ComprobarTexto(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreDispositivo = txtNombreDispositivo.Text;
                Tipo tipoDispositivo = (Tipo)cbxTipoDispositivo.SelectedItem;
                bool estaEnUso = chkEnUso.Checked;
                if (Auxiliar.NoEsNulo(dispositivoAModificar))
                {
                    dispositivoAModificar.Nombre = nombreDispositivo;
                    dispositivoAModificar.Tipo = tipoDispositivo;
                    dispositivoAModificar.EnUso = estaEnUso;
                }
                else
                {
                    Dispositivo dispositivoAAgregar = Dispositivo.NombreTipoEnUso(nombreDispositivo, tipoDispositivo, estaEnUso);
                    modelo.RegistrarComponente(dispositivoAAgregar);
                }
                AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
            }
            catch (ArgumentException excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error");
            }
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
