using System;
using System.Windows.Forms;
using Dominio;
using Persistencia;
using Excepciones;

namespace Interfaz
{
    public partial class RegistrarIncidente : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;
        private ElementoSCADA elementoAsociado;

        public RegistrarIncidente(IAccesoADatos modelo, Panel panelSistema, ElementoSCADA elementoAModificar)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            elementoAsociado = elementoAModificar;
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (lblErrorDescripcion.Visible || lblErrorFecha.Visible)
            {
                MessageBox.Show("Aún quedan campos sin completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    byte gravedad = (byte)numValor.Value;
                    DateTime fecha = monthCalendar.SelectionStart;
                    string descripcion = txtDescripcion.Text;
                    Incidente incidenteAAgregar = Incidente.IDElementoDescripcionFechaGravedad(elementoAsociado.ID, descripcion, fecha, gravedad);
                    modelo.RegistrarIncidente(incidenteAAgregar);
                    MessageBox.Show("El incidente ha sido registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (IncidenteExcepcion ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
