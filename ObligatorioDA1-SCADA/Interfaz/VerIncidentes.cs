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
    public partial class VerIncidentes : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;
        public VerIncidentes(IAccesoADatos modelo, Panel panelSistema, IElementoSCADA unELemento)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            RecargarListaIncidentes();
        }

        private void RecargarListaIncidentes()
        {
            //Prueba
            //lstTiposDispositivos.Rows.Clear();
            //foreach (IElementoSCADA elemento in modelo.ComponentesPrimarios)
            //{
            //    lstTiposDispositivos.Rows.Add(elemento, elemento.Descripcion, 1);
            //}
        }

        private void btnVolverMenuPrincipal_Click(object sender, EventArgs e)
        {
            AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
        }

        private void btnAplicarFiltros_Click(object sender, EventArgs e)
        {
            if (fechaDesde.Value > fechaHasta.Value)
            {
                MessageBox.Show("La fecha desde debe ser menor o igual a la fecha hasta", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
