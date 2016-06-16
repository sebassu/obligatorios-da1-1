using System;
using System.Windows.Forms;
using Dominio;
using Persistencia;
using System.Collections;

namespace Interfaz
{
    public partial class VerIncidentes : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;
        private ElementoSCADA unElemento;
        private IList incidentesAVisualizar;
        public VerIncidentes(IAccesoADatos modelo, Panel panelSistema, ElementoSCADA unElemento, IList incidentesAVisualizar)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            this.unElemento = unElemento;
            this.incidentesAVisualizar = incidentesAVisualizar;
        }

        private void RecargarListaIncidentes(Tuple<string, Incidente> incidenteAVisualizar)
        {
            if (incidenteAVisualizar.Item2.Fecha >= dateTimeFechaDesde.Value.Date &&
                incidenteAVisualizar.Item2.Fecha <= dateTimeFechaHasta.Value.Date &&
                incidenteAVisualizar.Item2.NivelGravedad == numNivelGravedad.Value)
            {

                lstIncidentes.Rows.Add(incidenteAVisualizar.Item2.Descripcion, incidenteAVisualizar.Item2.Fecha.Day + "/" +
                    incidenteAVisualizar.Item2.Fecha.Month + "/" + incidenteAVisualizar.Item2.Fecha.Year,
                    incidenteAVisualizar.Item2.NivelGravedad, incidenteAVisualizar.Item1);
            }
        }

        private void btnVolverMenuPrincipal_Click(object sender, EventArgs e)
        {
            AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
        }

        private void dateTime_Leave(object sender, EventArgs e)
        {
            if (dateTimeFechaDesde.Value > dateTimeFechaHasta.Value)
            {
                lblErrorFiltrado.Show();
            }
            else
            {
                lblErrorFiltrado.Hide();
            }
        }

        private void btnAplicarFiltrado_Click(object sender, EventArgs e)
        {
            lstIncidentes.Rows.Clear();
            if (lblErrorFiltrado.Visible)
            {
                MessageBox.Show("No se puede aplicar el filtrado, la fecha desde debe ser menor a la fecha hasta", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (Tuple<string, Incidente> incidente in incidentesAVisualizar)
                {
                    RecargarListaIncidentes(incidente);
                }
            }
        }
    }
}
