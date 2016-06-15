using System;
using System.Windows.Forms;
using Dominio;
using Persistencia;

namespace Interfaz
{
    public partial class VerIncidentes : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;
        private ElementoSCADA unElemento;
        public VerIncidentes(IAccesoADatos modelo, Panel panelSistema, ElementoSCADA unElemento)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            this.unElemento = unElemento;
            RecargarListaIncidentes();
        }

        private void RecargarListaIncidentes()
        {
            //Prueba
            lstTiposDispositivos.Rows.Clear();
            foreach (Tipo tipo in modelo.Tipos)
            {
                lstTiposDispositivos.Rows.Add(tipo, tipo.Descripcion, 1);
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
            if (lblErrorFiltrado.Visible)
            {
                MessageBox.Show("No se puede aplicar el filtrado, la fecha desde debe ser menor a la fecha hasta", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Aplico el filtrado
            }
        }
    }
}
