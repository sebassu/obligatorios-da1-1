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
                numMinAlarma.Value = unaVariable.MinimoAlarma;
                numMaxAlarma.Value = unaVariable.MaximoAlarma;
                minAdv.Value = unaVariable.MinimoAdvertencia;
                maxAdv.Value = unaVariable.MaximoAdvertencia;
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
            decimal valorMinimoAlarma = numMinAlarma.Value;
            decimal valorMaximoAlarma = numMaxAlarma.Value;
            decimal valorMinimoAdvertencia = minAdv.Value;
            decimal valorMaximoAdvertencia = maxAdv.Value;
            try
            {
                if (!(lblErrorNombre.Visible || lblErrorValores.Visible))
                {
                    EjecutarCambios(nombre, valorMinimoAlarma, valorMaximoAlarma, valorMinimoAdvertencia, valorMaximoAdvertencia);
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

        private void EjecutarCambios(string nombre, decimal valorMinimoAlarma, decimal valorMaximoAlarma, decimal valorMinimoAdvertencia, decimal valorMaximoAdvertencia)
        {
            if (Auxiliar.NoEsNulo(variableAModificar))
            {
                ModificarVariable(nombre, valorMinimoAlarma, valorMaximoAlarma, valorMinimoAdvertencia, valorMaximoAdvertencia);
                modelo.ActualizarVariable(variableAModificar);
                MessageBox.Show("La variable fue modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Variable variableAAgregar = Variable.NombreRangosAdvertenciaAlarma(nombre, valorMinimoAlarma,
                    valorMinimoAdvertencia, valorMaximoAdvertencia, valorMaximoAlarma);
                componenteAModificar.AgregarVariable(variableAAgregar);
                modelo.ActualizarElemento(componenteAModificar);
                MessageBox.Show("La variable fue registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
        }

        private void ModificarVariable(string nombre, decimal valorMinimo, decimal valorMaximo,
            decimal minimoAdvertencia, decimal maximoAdvertencia)
        {
            variableAModificar.Nombre = nombre;
            variableAModificar.SetValoresLimites(valorMinimo, minimoAdvertencia, maximoAdvertencia, valorMaximo);
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
            decimal valorMinimoAlarma = numMinAlarma.Value;
            decimal valorMaximoAlarma = numMaxAlarma.Value;
            decimal valorMinimoAdvertencia = minAdv.Value;
            decimal valorMaximoAdvertencia = maxAdv.Value;
            if (!Auxiliar.ValoresMonotonosCrecientes(valorMinimoAlarma,
                valorMinimoAdvertencia, valorMaximoAdvertencia, valorMaximoAlarma))
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
