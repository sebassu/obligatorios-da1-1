using System;
using System.Windows.Forms;
using Dominio;

namespace Interfaz
{
    public partial class VariableValorHistorico : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;

        public VariableValorHistorico(IAccesoADatos modelo, Panel panelSistema, Variable variable)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            if (Auxiliar.EsListaVacia(variable.Historico))
            {
                valoresHistoricos.Rows.Add("Sin", "datos a", " mostrar");
            }
            else {
                foreach (Tuple<DateTime, double> elemento in variable.Historico)
                {
                    valoresHistoricos.Rows.Add(elemento.Item2, elemento.Item1.Date, elemento.Item1.Hour);
                }
            }
        }

        private void btnVolverMenuPrincipal_Click(object sender, EventArgs e)
        {
            AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
        }
    }
}
