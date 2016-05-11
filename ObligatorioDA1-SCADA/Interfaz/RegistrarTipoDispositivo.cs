using System;
using System.Windows.Forms;
using Dominio;
using Excepciones;

namespace Interfaz
{
    public partial class RegistrarTipoDispositivo : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;
        private Tipo tipoAModificar;

        public RegistrarTipoDispositivo(IAccesoADatos modelo, Panel panelSistema, Tipo unTipo = null)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            if (Auxiliar.NoEsNulo(unTipo))
            {
                lblTituloDispositivo.Text = "Editar Tipo de Dispositivo";
                tipoAModificar = unTipo;
                txtNombre.Text = unTipo.Nombre;
                txtDescripcion.Text = unTipo.Descripcion;
            }
            lblErrorNombre.Hide();
            lblErrorDescripcion.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            AuxiliarInterfaz.ComprobarTexto(sender, e);
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
                    MessageBox.Show("No se puede registrar el tipo de dispositivo, hay campos con errores de formato", "Error");
                }
                else if (Auxiliar.EsTextoValido(txtNombre.Text) && Auxiliar.EsTextoValido(txtDescripcion.Text))
                {
                    if (Auxiliar.NoEsNulo(tipoAModificar))
                    {
                        tipoAModificar.Nombre = txtNombre.Text;
                        tipoAModificar.Descripcion = txtDescripcion.Text;
                        MessageBox.Show("El tipo de dispositivo fue modificado correctamente", "Éxito");
                    }
                    else
                    {
                        Tipo unTipo = Tipo.NombreDescripcion(txtNombre.Text, txtDescripcion.Text);
                        modelo.RegistrarTipo(unTipo);
                        MessageBox.Show("El tipo de dispositivo fue registrado correctamente", "Éxito");
                    }
                    panelSistema.Controls.Clear();
                    panelSistema.Controls.Add(new MenuOpcionesTipoDispositivo(modelo, panelSistema));
                }
                else
                {
                    MessageBox.Show("No deje campos sin rellenar", "Error");
                }
            }
            catch (TipoExcepcion ex)
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
