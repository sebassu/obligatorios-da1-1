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
    public partial class RegistrarPlantaIndustrial : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;
        //private PlantaIndustrial plantaAModificar;

        public RegistrarPlantaIndustrial(IAccesoADatos modelo, Panel panelSistema, /*PlantaIndustrial plantaAModificar = */ object p = null)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;

            /*if (plantaAModificar == null)
            {
                lblMenuPlantaIndustrial.Text = "Registrar Planta Industrial";
            }
            else
            {
                lblMenuPlantaIndustrial.Text = "Editar Planta Industrial";
                this.plantaAModificar = plantaAModificar;
                txtNombrePlanta.Text = plantaAModificar.Nombre;
                txtNombreDireccion.Text = plantaAModificar.Direccion;
                txtNombreCiudad.Text = plantaAModificar.Ciudad;
            }*/

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
            if (Auxiliar.EsTextoValido(txtDireccionPlanta.Text))
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
            if (Auxiliar.EsTextoValido(txtCiudadPlanta.Text))
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
    }
}
