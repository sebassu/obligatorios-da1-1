using System;
using System.Windows.Forms;
using Dominio;

namespace Interfaz
{
    public partial class RegistrarInstalacion : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;
        private Instalacion instalacionAModificar;

        public RegistrarInstalacion(IAccesoADatos modelo, Panel panelSistema, Instalacion instalacionAModificar = null)
        {
            InitializeComponent();
            if (instalacionAModificar == null)
            {
                lblMenuInstalacion.Text = "Registrar Instalación";
                this.modelo = modelo;
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
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new MenuPrincipal(modelo, panelSistema));
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string unNombre = txtNombreInstalacion.Text;
                if (instalacionAModificar == null)
                {                   
                    Instalacion unaInstalacion = Instalacion.ConstructorNombre(unNombre);
                    modelo.RegistrarComponente(unaInstalacion);
                }
                else
                {
                    instalacionAModificar.Nombre = unNombre;
                }
            }
            catch (ArgumentException excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error");
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
