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
        public VerIncidentes(IAccesoADatos modelo, Panel panelSistema, Incidente unIncidente/*en realidad se recibe un IElementoSCADA*/)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
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
    }
}
