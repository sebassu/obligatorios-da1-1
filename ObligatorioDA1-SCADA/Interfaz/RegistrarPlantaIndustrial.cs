using System;
using Persistencia;
using System.Windows.Forms;
using Dominio;
using Excepciones;

namespace Interfaz
{
    public partial class RegistrarPlantaIndustrial : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;
        private PlantaIndustrial plantaAModificar;
        private bool esParaModificar;

        public RegistrarPlantaIndustrial(IAccesoADatos modelo, Panel panelSistema,
            PlantaIndustrial plantaAModificar = null, bool esParaModificar = false)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            this.esParaModificar = esParaModificar;

            if (!esParaModificar)
            {
                lblMenuPlantaIndustrial.Text = "Registrar Planta Industrial";
            }
            else
            {
                lblMenuPlantaIndustrial.Text = "Editar Planta Industrial";
                this.plantaAModificar = plantaAModificar;
                txtNombrePlanta.Text = plantaAModificar.Nombre;
                txtDireccionPlanta.Text = plantaAModificar.Direccion;
                txtCiudadPlanta.Text = plantaAModificar.Ciudad;
            }

            lblErrorNombre.Hide();
            lblErrorDireccion.Hide();
            lblErrorCiudad.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
        }

        private void txtNombrePlanta_Leave(object sender, EventArgs e)
        {
            if (Auxiliar.EsTextoValido(txtNombrePlanta.Text))
            {
                lblErrorNombre.Hide();
            }
            else
            {
                lblErrorNombre.Show();
            }
        }

        private void txtNombrePlanta_KeyPress(object sender, KeyPressEventArgs e)
        {
            AuxiliarInterfaz.ComprobarTexto(sender, e);
        }

        private void txtDireccionPlanta_Leave(object sender, EventArgs e)
        {
            if (Auxiliar.EsDireccionValida(txtDireccionPlanta.Text))
            {
                lblErrorDireccion.Hide();
            }
            else
            {
                lblErrorDireccion.Show();
            }
        }

        private void txtDireccionPlanta_KeyPress(object sender, KeyPressEventArgs e)
        {
            AuxiliarInterfaz.ComprobarTexto(sender, e);
        }

        private void txtCiudadPlanta_Leave(object sender, EventArgs e)
        {
            if (Auxiliar.EsCiudadValida(txtCiudadPlanta.Text))
            {
                lblErrorCiudad.Hide();
            }
            else
            {
                lblErrorCiudad.Show();
            }
        }

        private void txtCiudadPlanta_KeyPress(object sender, KeyPressEventArgs e)
        {
            AuxiliarInterfaz.ComprobarTexto(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (lblErrorNombre.Visible || lblErrorDireccion.Visible || lblErrorCiudad.Visible)
            {
                MessageBox.Show("No se puede registrar la planta industrial, hay campos con errores.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string nombrePlantaIndustrial = txtNombrePlanta.Text;
                    string direccionPlantaIndustrial = txtDireccionPlanta.Text;
                    string ciudadPlantaIndustrial = txtCiudadPlanta.Text;
                    if (!esParaModificar)
                    {
                        if (plantaAModificar == null)
                        {
                            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.NombreDireccionCiudad(nombrePlantaIndustrial,
                                direccionPlantaIndustrial, ciudadPlantaIndustrial);
                            modelo.RegistrarElemento(unaPlantaIndustrial);
                            MessageBox.Show("La planta industrial fue registrada correctamente", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.NombreDireccionCiudad(nombrePlantaIndustrial,
                                direccionPlantaIndustrial, ciudadPlantaIndustrial);
                            plantaAModificar.AgregarDependencia(unaPlantaIndustrial);
                            MessageBox.Show("La planta industrial fue registrada correctamente", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        plantaAModificar.Nombre = nombrePlantaIndustrial;
                        plantaAModificar.Direccion = direccionPlantaIndustrial;
                        plantaAModificar.Ciudad = ciudadPlantaIndustrial;
                        MessageBox.Show("La instalación fue modificada correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        modelo.ActualizarElemento(plantaAModificar);
                    }
                    AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
                }
                catch (ElementoSCADAExcepcion excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
