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
    public partial class RegistrarInstalacion : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;

        public RegistrarInstalacion(IAccesoADatos modelo, Panel panelSistema)
        {
            InitializeComponent();
            this.modelo = modelo;
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
                Instalacion unaInstalacion = Instalacion.ConstructorNombre(unNombre);
                modelo.RegistrarComponente(unaInstalacion);
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
