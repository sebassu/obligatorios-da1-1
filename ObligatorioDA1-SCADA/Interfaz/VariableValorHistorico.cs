using System;
using System.Windows.Forms;
using Dominio;
using Persistencia;

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
            else
            {
                foreach (Tuple<DateTime, decimal> elemento in variable.Historico)
                {
                    DateTime fechaYHora = elemento.Item1;
                    decimal valor = elemento.Item2;
                    valoresHistoricos.Rows.Add(valor, fechaYHora.ToShortDateString(), fechaYHora.ToShortTimeString());
                }
            }
        }

        private void btnVolverMenuPrincipal_Click(object sender, EventArgs e)
        {
            AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
        }
    }
}
