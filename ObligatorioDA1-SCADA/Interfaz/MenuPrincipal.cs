using Dominio;
using System;
using System.Windows.Forms;
using Dominio;

namespace Interfaz
{
    public partial class MenuPrincipal : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;

        public MenuPrincipal(IAccesoADatos modelo, Panel panelSistema)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
        }

        private void btnAgregarInstalacion_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarInstalacion(modelo, panelSistema));
        }

        private void btnEditarInstalacion_Click(object sender, EventArgs e)
        {
            TreeNode seleccionado = treeViewPlantaDeProduccion.SelectedNode;
            if (Auxiliar.NoEsNulo(seleccionado))
            {
                Instalacion instalacionAModificar = treeViewPlantaDeProduccion.SelectedNode.Tag as Instalacion;
                if (Auxiliar.NoEsNulo(instalacionAModificar))
                {
                    panelSistema.Controls.Clear();
                    panelSistema.Controls.Add(new RegistrarInstalacion(modelo, panelSistema, instalacionAModificar));
                }
                else
                {
                    MessageBox.Show("Es necesario utilizar la función de editar Dispositivo para la selección realizada");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una instalación para acceder a esta funcionalidad");
            }
        }

        private void btnAgregarDispositivo_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarDispositivo(modelo, panelSistema));
        }

        private void btnAgregarTipoDispositivo_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarTipoDispositivo(modelo, panelSistema));
        }

        private void btnAgregarVariable_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarVariable(modelo, panelSistema));
        }

        private void btnAgregarValorVariable_Click(object sender, EventArgs e)
        {
            if (lstVariables.SelectedItems.Count != 0)
            {
                Variable unaVariable = lstVariables.SelectedItems[0].Tag as Variable;
                panelSistema.Controls.Clear();
                panelSistema.Controls.Add(new RegistrarValorVariable(modelo, panelSistema, unaVariable));
            }
            else
            {
                MessageBox.Show("Debe seleccionar una variable para acceder a esta funcionalidad");
            }
        }

        private void btnValoresHistoricos_Click(object sender, EventArgs e)
        {
            if (lstVariables.SelectedItems.Count != 0)
            {
                Variable unaVariable = lstVariables.SelectedItems[0].Tag as Variable;
                panelSistema.Controls.Clear();
                panelSistema.Controls.Add(new VariableValorHistorico(modelo, panelSistema, unaVariable));
            }
            else
            {
                MessageBox.Show("Debe seleccionar una variable para acceder a esta funcionalidad");
            }
        }

        private void btnCargarDatosPrueba_Click(object sender, EventArgs e)
        {
            CargarDatosDePrueba();
        }

        private void CargarDatosDePrueba()
        {
            Tipo tipo1 = Tipo.NombreDescripcion("Tipo 1", "Buen tipo");
            Tipo tipo2 = Tipo.NombreDescripcion("Tipo 2", "Otro tipo");
            Componente componente1 = Instalacion.ConstructorNombre("Extracción");
            Componente componente2 = Dispositivo.NombreTipoEnUso("Picadora", tipo1, true);
            Componente componente3 = Instalacion.ConstructorNombre("Molienda");
            Componente componente4 = Dispositivo.NombreTipoEnUso("Molino", tipo1, true);
            Variable variable1 = Variable.NombreMinimoMaximo("Velocidad", 0, 100);
            Variable variable2 = Variable.NombreMinimoMaximo("Carga", 0, 500);
            componente4.AgregarVariable(variable1);
            componente4.AgregarVariable(variable2);
            Componente componente5 = Dispositivo.NombreTipoEnUso("Prensa", tipo1, true);
            componente3.AgregarComponente(componente4);
            componente3.AgregarComponente(componente5);
            componente1.AgregarComponente(componente2);
            componente1.AgregarComponente(componente3);
            modelo.RegistrarComponente(componente1);
            Componente componente6 = Instalacion.ConstructorNombre("Clarificación");
            Componente componente7 = Dispositivo.NombreTipoEnUso("Batea", tipo2, true);
            Componente componente8 = Dispositivo.NombreTipoEnUso("Calentadores", tipo2, true);
            componente6.AgregarComponente(componente7);
            componente6.AgregarComponente(componente8);
            modelo.RegistrarComponente(componente6);
            Componente componente9 = Instalacion.ConstructorNombre("Evaporación");
            Componente componente10 = Instalacion.ConstructorNombre("Evaporadores");
            Variable variable3 = Variable.NombreMinimoMaximo("Temperatura", 0, 200);
            Variable variable4 = Variable.NombreMinimoMaximo("Presión", 10, 30);
            componente10.AgregarVariable(variable3);
            componente10.AgregarVariable(variable4);
            Componente componente11 = Dispositivo.NombreTipoEnUso("Evaporador 1", tipo1, true);
            Componente componente12 = Dispositivo.NombreTipoEnUso("Evaporador 2", tipo1, true);
            componente10.AgregarComponente(componente11);
            componente10.AgregarComponente(componente12);
            componente9.AgregarComponente(componente10);
            modelo.RegistrarComponente(componente9);
            Componente componente13 = Instalacion.ConstructorNombre("Centrifugación");
            Componente componente14 = Dispositivo.NombreTipoEnUso("Centrifugadora 1", tipo2, true);
            Componente componente15 = Dispositivo.NombreTipoEnUso("Centrifugadora 2", tipo2, true);
            componente13.AgregarComponente(componente14);
            componente13.AgregarComponente(componente15);
            modelo.RegistrarComponente(componente13);
        }
    }
}
