using System;
using System.Windows.Forms;
using Dominio;
using Excepciones;

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
                numMin.Value = unaVariable.MinimoAlarma;
                numMax.Value = unaVariable.MaximoAlarma;
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
            decimal valorMinimo = numMin.Value;
            decimal valorMaximo = numMax.Value;
            try
            {
                if (Auxiliar.EsTextoValido(nombre) && valorMaximo >= valorMinimo)
                {
                    if (Auxiliar.NoEsNulo(variableAModificar))
                    {
                        ModificarVariable(nombre, valorMinimo, valorMaximo);
                        MessageBox.Show("La variable fue modificada correctamente.", "Éxito");
                    }
                    else {
                        componenteAModificar.AgregarVariable(Variable.NombreMinimoMaximo(nombre, valorMinimo, valorMaximo));
                        MessageBox.Show("La variable fue registrada correctamente.", "Éxito");
                    }
                    AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
                }
                else {
                    MessageBox.Show("Revise los datos ingresados y reintente.", "Error");
                }
            }
            catch (VariableExcepcion ex1)
            {
                MessageBox.Show(ex1.Message, "Error");
            }
        }

        private void ModificarVariable(string nombre, decimal valorMinimo, decimal valorMaximo)
        {
            variableAModificar.Nombre = nombre;
           // variableAModificar.Maximo = valorMaximo;
           // variableAModificar.Minimo = valorMinimo;
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
