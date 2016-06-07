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
        private Instalacion instalacionAModificar;
        private bool esParaModificar;

        public RegistrarInstalacion(IAccesoADatos modelo, Panel panelSistema, Instalacion instalacionAModificar = null, bool esParaModificar = false)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.esParaModificar = esParaModificar;
            if (!esParaModificar && instalacionAModificar == null)
            {
                lblMenuInstalacion.Text = "Registrar Instalación";
            }
            else
            {
                lblMenuInstalacion.Text = "Editar Instalación";
                this.instalacionAModificar = instalacionAModificar;
                txtNombreInstalacion.Text = instalacionAModificar.Nombre;
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
                        if (instalacionAModificar == null)
                        {
                            Instalacion unaInstalacion = Instalacion.ConstructorNombre(unNombre);
                            modelo.RegistrarElemento(unaInstalacion);
                            MessageBox.Show("La instalación fue registrada correctamente", "Éxito");
                        }
                        else
                        {
                            Instalacion unaInstalacion = Instalacion.ConstructorNombre(unNombre);
                            instalacionAModificar.AgregarDependencia(unaInstalacion);
                            MessageBox.Show("La instalación fue registrada correctamente", "Éxito");
                        }
                    }
                    else
                    {
                        instalacionAModificar.Nombre = unNombre;
                        MessageBox.Show("La instalación fue modificada correctamente", "Éxito");
                    }
                    AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
                }
                catch (ElementoSCADAExcepcion excepcion)
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
