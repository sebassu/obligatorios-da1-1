using System;
using System.Windows.Forms;
using Dominio;
using Persistencia;
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
            else
            {
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
            decimal valorMinimoAlarma = numMin.Value;
            decimal valorMaximoAlarma = numMax.Value;
            decimal valorMinimoAdvertencia = minAdv.Value;
            decimal valorMaximoAdvertencia = maxAdv.Value;
            try
            {
                if (!(lblErrorNombre.Visible || lblErrorValores.Visible))
                {
                    if (Auxiliar.NoEsNulo(variableAModificar))
                    {
                        ModificarVariable(nombre, valorMinimoAlarma, valorMaximoAlarma, valorMinimoAdvertencia, valorMaximoAdvertencia);
                        MessageBox.Show("La variable fue modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //componenteAModificar.AgregarVariable(Variable.NombreMinimoMaximo(nombre, valorMinimo, valorMaximo));
                        var rangosAdvertencias = new Tuple<decimal, decimal>(valorMinimoAdvertencia, valorMaximoAdvertencia);
                        var rangosAlarmas = new Tuple<decimal, decimal>(valorMinimoAlarma, valorMaximoAlarma);
                        Variable variableAAgregar = Variable.NombreRangosAdvertenciaAlarma(nombre, rangosAdvertencias, rangosAlarmas);
                        componenteAModificar.AgregarVariable(variableAAgregar);
                        modelo.ActualizarElemento(componenteAModificar);
                        MessageBox.Show("La variable fue registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
                }
                else
                {
                    MessageBox.Show("Revise los datos ingresados y reintente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (VariableExcepcion ex1)
            {
                MessageBox.Show(ex1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificarVariable(string nombre, decimal valorMinimo, decimal valorMaximo,
            decimal minimoAdvertencia, decimal maximoAdvertencia)
        {
            variableAModificar.Nombre = nombre;
            //variableAModificar.MaximoAlarma = valorMaximo;
            //variableAModificar.MinimoAlarma = valorMinimo;
            //variableAModificar.MaximoAdvertencia = maximoAdvertencia;
            //variableAModificar.MinimoAdvertencia = minimoAdvertencia;
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
            if ((numMin.Value > minAdv.Value) || (minAdv.Value > maxAdv.Value) || (maxAdv.Value > numMax.Value))
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
