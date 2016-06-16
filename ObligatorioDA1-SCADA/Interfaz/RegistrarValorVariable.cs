using System;
using System.Windows.Forms;
using Dominio;
using Persistencia;
using Excepciones;

namespace Interfaz
{
    public partial class RegistrarValorVariable : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;
        private Variable unaVariable;

        public RegistrarValorVariable(IAccesoADatos modelo, Panel panelSistema, Variable variable)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            unaVariable = variable;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                unaVariable.SetValorActual(numValor.Value);
                modelo.ActualizarVariable(unaVariable);
                modelo.ActualizarElemento(unaVariable.ElementoPadre, true);
                MessageBox.Show("Valor agregado correctamente", "Éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
            }
            catch (ElementoSCADAExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
