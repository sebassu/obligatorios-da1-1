using System;
using System.Windows.Forms;
using Dominio;
using Excepciones;

namespace Interfaz
{
    public partial class RegistrarDispositivo : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;
        private Dispositivo dispositivoAModificar;
        private IElementoSCADA elementoAModificar;

        public RegistrarDispositivo(IAccesoADatos modelo, Panel panelSistema, IElementoSCADA unElemento = null, Dispositivo unDispositivo = null)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            elementoAModificar = unElemento;
            foreach (Tipo tipo in modelo.Tipos)
            {
                cbxTipoDispositivo.Items.Add(tipo);
            }
            if (Auxiliar.NoEsNulo(unDispositivo))
            {
                lblMenuDispositivo.Text = "Editar Dispositivo";
                dispositivoAModificar = unDispositivo;
                txtNombreDispositivo.Text = unDispositivo.Nombre;
                chkEnUso.Checked = dispositivoAModificar.EnUso;
                cbxTipoDispositivo.SelectedItem = unDispositivo.Tipo;
            }
            else
            {
                cbxTipoDispositivo.SelectedIndex = 0;
                txtNombreDispositivo.Text = "";
            }
            lblErrorNombre.Hide();
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
                    if (Auxiliar.NoEsNulo(elementoAModificar))
                    {
                        elementoAModificar.AgregarDependencia(dispositivoAAgregar);
                    }
                    else
                    {
                        modelo.RegistrarComponente(dispositivoAAgregar);
                    }
                }
                MessageBox.Show("El dispositivo fue registrado correctamente");
                AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
            }
            catch (ElementoSCADAExcepcion excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
