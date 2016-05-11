using System;
using System.Windows.Forms;
using Dominio;

namespace Interfaz
{
    public partial class RegistrarVariable : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;
        private Componente componenteAModificar;
        private Variable variableAModificar;

        public RegistrarVariable(IAccesoADatos modelo, Panel panelSistema, Componente unComponente = null, Variable unaVariable = null)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            if (Auxiliar.NoEsNulo(unaVariable))
            {
                variableAModificar = unaVariable;
                txtNombre.Text = unaVariable.Nombre;
                numMin.Value = unaVariable.Minimo;
                numMax.Value = unaVariable.Maximo;
                lblMenuVariable.Text = "Modificar Variable";
            }
            else {
                componenteAModificar = unComponente;
            }
            lblErrorNombre.Hide();
            lblErrorValores.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new MenuPrincipal(modelo, panelSistema));
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            AuxiliarInterfaz.ComprobarTexto(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            decimal minimo = numMin.Value;
            decimal maximo = numMax.Value;
            try
            {
                if (Auxiliar.NoEsNulo(variableAModificar))
                {
                    variableAModificar.Nombre = nombre;
                    variableAModificar.Maximo = maximo;
                    variableAModificar.Minimo = minimo;
                    MessageBox.Show("La variable fue modificada correctamente.", "Éxito");
                }
                else {
                    componenteAModificar.AgregarVariable(Variable.NombreMinimoMaximo(nombre, minimo, maximo));
                    MessageBox.Show("La variable fue registrada correctamente.", "Éxito");
                }
                AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
            }
            catch (ArgumentException ex1)
            {
                MessageBox.Show(ex1.Message, "Error");
            }
            catch (InvalidOperationException ex2)
            {
                MessageBox.Show(ex2.Message, "Error");
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (Auxiliar.EsTextoValido(txtNombre.Text))
            {
                lblErrorNombre.Hide();
            }
            else
            {
                lblErrorNombre.Show();
            }
        }

        private void rangoValores_Leave(object sender, EventArgs e)
        {
            if (numMin.Value > numMax.Value)
            {
                lblErrorValores.Show();
            }
            else
            {
                lblErrorValores.Hide();
            }
        }
    }
}
