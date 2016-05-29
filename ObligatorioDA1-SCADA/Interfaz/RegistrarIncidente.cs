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
    public partial class RegistrarIncidente : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;

        public RegistrarIncidente(IAccesoADatos modelo, Panel panelSistema)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            lblErrorDescripcion.Hide();
            lblErrorFecha.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
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

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            AuxiliarInterfaz.ComprobarTextoSinSaltoDeLinea(sender, e);
        }

        private void monthCalendar_Leave(object sender, EventArgs e)
        {
            if (monthCalendar.SelectionStart > DateTime.Now)
            {
                lblErrorFecha.Show();
            }
            else
            {
                lblErrorFecha.Hide();
            }
        }
    }
}
