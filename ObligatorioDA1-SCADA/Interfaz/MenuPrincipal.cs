﻿using Dominio;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

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
            RecargarTodoComponente();
        }

        private void btnAgregarInstalacion_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarInstalacion(modelo, panelSistema));
        }

        private void VerificarComponenteSeleccionado(Action unaAccionARealizar)
        {
            TreeNode seleccionado = treeViewPlantaDeProduccion.SelectedNode;
            if (Auxiliar.NoEsNulo(seleccionado))
            {
                unaAccionARealizar.Invoke();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un componente para acceder a esta funcionalidad");
            }
        }

        private void btnEditarInstalacion_Click(object sender, EventArgs e)
        {
            VerificarComponenteSeleccionado(AbrirPanelEditarInstalacion);
        }

        private void AbrirPanelEditarInstalacion()
        {
            Instalacion instalacionAModificar = treeViewPlantaDeProduccion.SelectedNode.Tag as Instalacion;
            if (Auxiliar.NoEsNulo(instalacionAModificar))
            {
                panelSistema.Controls.Clear();
                panelSistema.Controls.Add(new RegistrarInstalacion(modelo, panelSistema, instalacionAModificar));
            }
            else
            {
                MessageBox.Show("Es necesario utilizar la función de \"Editar Dispositivo\" para la selección realizada");
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
            VerificarVariableSeleccionada(AbrirRegistrarValor);
        }

        private void btnValoresHistoricos_Click(object sender, EventArgs e)
        {
            VerificarVariableSeleccionada(AbrirHistorico);
        }

        private void VerificarVariableSeleccionada(Action unaAccionARealizar)
        {
            if (lstVariables.SelectedItems.Count != 0)
            {
                unaAccionARealizar.Invoke();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una variable para acceder a esta funcionalidad");
            }
        }

        private void AbrirHistorico()
        {
            Variable unaVariable = lstVariables.SelectedItems[0].Tag as Variable;
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new VariableValorHistorico(modelo, panelSistema, unaVariable));
        }

        private void AbrirRegistrarValor()
        {
            Variable unaVariable = lstVariables.SelectedItems[0].Tag as Variable;
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarValorVariable(modelo, panelSistema, unaVariable));
        }

        private void btnCargarDatosPrueba_Click(object sender, EventArgs e)
        {
            CargarDatosDePrueba();
        }

        private void CargarDatosDePrueba()
        {
            modelo = new AccesoADatosEnMemoria();
            Tipo tipo1 = Tipo.NombreDescripcion("Tipo 1", "Buen tipo");
            Tipo tipo2 = Tipo.NombreDescripcion("Tipo 2", "Otro tipo");
            modelo.RegistrarTipo(tipo1);
            modelo.RegistrarTipo(tipo2);
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
            RecargarTodoComponente();
        }

        private void RecargarTodoComponente()
        {
            RecargarTreeView();
            RecargarTableroDeControl();
        }

        private void RecargarTreeView()
        {
            Cursor.Current = Cursors.WaitCursor;
            treeViewPlantaDeProduccion.BeginUpdate();
            treeViewPlantaDeProduccion.Nodes.Clear();
            foreach (Componente componente in modelo.ComponentesPrimarios)
            {
                TreeNode nodo = ObtenerNodoDeRamaJerarquica(componente);
                treeViewPlantaDeProduccion.Nodes.Add(nodo);
            }
            Cursor.Current = Cursors.Default;
            treeViewPlantaDeProduccion.EndUpdate();
        }

        private TreeNode ObtenerNodoDeRamaJerarquica(Componente componente)
        {
            List<TreeNode> listaAuxiliar = new List<TreeNode>();
            foreach (Componente hijo in componente.Dependencias)
            {
                listaAuxiliar.Add(ObtenerNodoDeRamaJerarquica(hijo));
            }
            TreeNode retorno = new TreeNode(componente.ToString(), listaAuxiliar.ToArray());
            retorno.Tag = componente;
            return retorno;
        }

        private void treeViewPlantaDeProduccion_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Componente componenteSeleccionado = treeViewPlantaDeProduccion.SelectedNode.Tag as Componente;
            if (Auxiliar.NoEsNulo(componenteSeleccionado) && componenteSeleccionado.Variables.Count > 0)
            {
                foreach (Variable variableDelComponente in componenteSeleccionado.Variables)
                {
                    ListViewItem itemAAgregar = new ListViewItem(variableDelComponente.ToString());
                    itemAAgregar.Tag = variableDelComponente;
                    lstVariables.Items.Add(itemAAgregar);
                }
            }
            else
            {
                lstVariables.Text = "Sin datos para mostrar.";
            }
        }

        private void RecargarTableroDeControl()
        {
            lstTableroControl.Text = "";
            foreach (Componente componente in modelo.ComponentesPrimarios)
            {
                if (componente.CantidadAlarmasActivas > 0)
                {
                    lstTableroControl.SelectionBackColor = Color.Red;
                }
                else
                {
                    lstTableroControl.SelectionBackColor = Color.Green;
                }
                lstTableroControl.AppendText(componente.Nombre + ": " + componente.CantidadAlarmasActivas + " Alarmas\n\n");
            }
        }

        private void btnEditarDispositivo_Click(object sender, EventArgs e)
        {
            VerificarComponenteSeleccionado(AbrirPanelEditarDispositivo);
        }

        private void AbrirPanelEditarDispositivo()
        {
            Dispositivo dispositivoAModificar = treeViewPlantaDeProduccion.SelectedNode.Tag as Dispositivo;
            if (Auxiliar.NoEsNulo(dispositivoAModificar))
            {
                panelSistema.Controls.Clear();
                panelSistema.Controls.Add(new RegistrarDispositivo(modelo, panelSistema, dispositivoAModificar));
            }
            else
            {
                MessageBox.Show("Es necesario utilizar la función de \"Editar Instalación\" para la selección realizada");
            }
        }

        private void btnBorrarInstalacion_Click(object sender, EventArgs e)
        {
            VerificarComponenteSeleccionado(EliminarInstalacionSeleccionada);
        }

        private void EliminarInstalacionSeleccionada()
        {
            Instalacion instalacionAEliminar = treeViewPlantaDeProduccion.SelectedNode.Tag as Instalacion;
            if (Auxiliar.NoEsNulo(instalacionAEliminar))
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea continuar con la operación?"
                    + " La eliminación es irreversible", "Confirmación", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    Instalacion padre = instalacionAEliminar.InstalacionPadre;
                    if (Auxiliar.NoEsNulo(padre))
                    {
                        padre.EliminarComponente(instalacionAEliminar);
                    }
                    else
                    {
                        modelo.EliminarComponente(instalacionAEliminar);
                    }
                    treeViewPlantaDeProduccion.Nodes.Remove(treeViewPlantaDeProduccion.SelectedNode);
                }
            }
            else
            {
                MessageBox.Show("Es necesario utilizar la función de \"Eliminar Dispositivo\" para la selección realizada");
            }
        }

        private void btnEliminarDispositivo_Click(object sender, EventArgs e)
        {
            VerificarComponenteSeleccionado(EliminarDispositivoSeleccionado);
        }

        private void EliminarDispositivoSeleccionado()
        {
            Dispositivo dispositivoAEliminar = treeViewPlantaDeProduccion.SelectedNode.Tag as Dispositivo;
            if (Auxiliar.NoEsNulo(dispositivoAEliminar))
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea continuar con la operación?"
                    + " La eliminación es irreversible", "Confirmación", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    Instalacion padre = dispositivoAEliminar.InstalacionPadre;
                    if (Auxiliar.NoEsNulo(padre))
                    {
                        padre.EliminarComponente(dispositivoAEliminar);
                    }
                    else
                    {
                        modelo.EliminarComponente(dispositivoAEliminar);
                    }
                    treeViewPlantaDeProduccion.Nodes.Remove(treeViewPlantaDeProduccion.SelectedNode);
                }
            }
            else
            {
                MessageBox.Show("Es necesario utilizar la función de \"Eliminar Instalación\" para la selección realizada");
            }
        }
    }
}
