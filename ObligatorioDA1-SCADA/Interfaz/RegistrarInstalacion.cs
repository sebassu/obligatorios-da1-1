using System;
using System.Windows.Forms;
using Dominio;
using Persistencia;
using Excepciones;

namespace Interfaz
{
    public partial class RegistrarInstalacion : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;
        private ElementoSCADA elementoRecibido;
        private bool esParaModificar;

        public RegistrarInstalacion(IAccesoADatos modelo, Panel panelSistema,
            ElementoSCADA elementoRecibido = null, bool esParaModificar = false)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.esParaModificar = esParaModificar;
            this.elementoRecibido = elementoRecibido;
            if (!esParaModificar)
            {
                lblMenuInstalacion.Text = "Registrar Instalación";
            }
            else
            {
                lblMenuInstalacion.Text = "Editar Instalación";
                txtNombreInstalacion.Text = elementoRecibido.Nombre;
            }
            this.panelSistema = panelSistema;
            lblErrorNombre.Hide();
        }

        private void txtNombreInstalacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            AuxiliarInterfaz.ComprobarTexto(sender, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (lblErrorNombre.Visible)
            {
                MessageBox.Show("No se puede registrar la instalación, hay campos con errores.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string unNombre = txtNombreInstalacion.Text;
                    if (!esParaModificar)
                    {
                        Instalacion unaInstalacion = Instalacion.ConstructorNombre(unNombre);
                        elementoRecibido.AgregarDependencia(unaInstalacion);
                        modelo.ActualizarElemento(elementoRecibido);
                        MessageBox.Show("La instalación fue registrada correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        elementoRecibido.Nombre = unNombre;
                        MessageBox.Show("La instalación fue modificada correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
                }
                catch (ElementoSCADAExcepcion excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (AccesoADatosExcepcion excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtNombreInstalacion_Leave(object sender, EventArgs e)
        {
            if (Auxiliar.EsTextoValido(txtNombreInstalacion.Text))
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
