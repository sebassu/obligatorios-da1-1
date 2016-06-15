﻿using Dominio;
using Persistencia;
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
            VerificarElementoSeleccionado(AbrirPanelRegistrarInstalacion);
        }

        private void VerificarElementoSeleccionado(Action unaAccionARealizar)
        {
            TreeNode seleccionado = treeViewPlantaDeProduccion.SelectedNode;
            if (Auxiliar.NoEsNulo(seleccionado))
            {
                if (seleccionado.Tag is PlantaIndustrial || seleccionado.Tag is Instalacion)
                {
                    unaAccionARealizar.Invoke();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una planta industrial o una instalación para acceder a esta funcionalidad",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para acceder a esta funcionalidad", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirPanelRegistrarInstalacion()
        {
            ElementoSCADA elementoSeleccionado = treeViewPlantaDeProduccion.SelectedNode.Tag as ElementoSCADA;
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarInstalacion(modelo, panelSistema, elementoSeleccionado, false));
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
                MessageBox.Show("Debe seleccionar un componente para acceder a esta funcionalidad", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                panelSistema.Controls.Add(new RegistrarInstalacion(modelo, panelSistema, instalacionAModificar, true));
            }
            else
            {
                MessageBox.Show("Es necesario utilizar la función de \"Modificar Dispositivo\" para la selección realizada", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregarDispositivo_Click(object sender, EventArgs e)
        {
            /*****************************************/
            //Evaluar Cambiar a interfaz.
            /*****************************************/
            if (modelo.ExistenTipos())
            {
                ElementoSCADA unElemento = null;
                if (Auxiliar.NoEsNulo(treeViewPlantaDeProduccion.SelectedNode))
                {
                    object objetoSeleccionado = treeViewPlantaDeProduccion.SelectedNode.Tag;
                    unElemento = objetoSeleccionado as Instalacion;
                    if (unElemento == null)
                    {
                        unElemento = objetoSeleccionado as PlantaIndustrial;
                    }
                }
                panelSistema.Controls.Clear();
                panelSistema.Controls.Add(new RegistrarDispositivo(modelo, panelSistema, unElemento));
            }
            else
            {
                MessageBox.Show("No existen tipos de dispositivos registrados en el sistema", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarTipoDispositivo_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarTipoDispositivo(modelo, panelSistema));
        }

        private void btnAgregarVariable_Click(object sender, EventArgs e)
        {
            if (Auxiliar.NoEsNulo(treeViewPlantaDeProduccion.SelectedNode.Tag as Componente))
            {
                Componente unComponente = treeViewPlantaDeProduccion.SelectedNode.Tag as Componente;
                panelSistema.Controls.Clear();
                panelSistema.Controls.Add(new RegistrarVariable(modelo, panelSistema, unComponente));
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Componente para acceder a esta funcionalidad", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregarValorVariable_Click(object sender, EventArgs e)
        {
            VerificarVariableSeleccionada(AbrirRegistrarValor);
        }

        private void btnValoresHistoricos_Click(object sender, EventArgs e)
        {
            VerificarVariableSeleccionada(AbrirHistorico);
        }

        private void btnEliminarVariable_Click(object sender, EventArgs e)
        {
            VerificarVariableSeleccionada(EliminarVariableSeleccionada);
        }

        private void btnEditarVariable_Click(object sender, EventArgs e)
        {
            VerificarVariableSeleccionada(EditarVariableSeleccionada);
        }

        private void VerificarVariableSeleccionada(Action unaAccionARealizar)
        {
            if (lstVariables.SelectedItems.Count != 0)
            {
                unaAccionARealizar.Invoke();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Variable para acceder a esta funcionalidad", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void EliminarVariableSeleccionada()
        {
            Variable unaVariable = lstVariables.SelectedItems[0].Tag as Variable;
            Componente componentePadre = unaVariable.ComponentePadre;
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea continuar con la operación?"
                    + " La eliminación es irreversible", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                componentePadre.EliminarVariable(unaVariable);
                lstVariables.Items.Remove(lstVariables.SelectedItems[0]);
                MessageBox.Show("La variable seleccionada fue borrada correctamente", "Éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            ActivacionBotonesVariables();
            RecargarTableroDeControl();
        }

        private void EditarVariableSeleccionada()
        {
            Variable unaVariable = lstVariables.SelectedItems[0].Tag as Variable;
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarVariable(modelo, panelSistema, null, unaVariable));
        }

        private void btnCargarDatosPrueba_Click(object sender, EventArgs e)
        {
            CargarDatosDePrueba();
        }

        private void CargarDatosDePrueba()
        {
            modelo = new AccesoADatosBaseDeDatos();
            Tipo tipo1 = Tipo.NombreDescripcion("Tipo 1", "Buen tipo");
            Tipo tipo2 = Tipo.NombreDescripcion("Tipo 2", "Otro tipo");
            modelo.RegistrarTipo(tipo1);
            modelo.RegistrarTipo(tipo2);
            Componente componente1 = Instalacion.ConstructorNombre("Extracción");
            Componente componente2 = Dispositivo.NombreTipo("Picadora", tipo1);
            Componente componente3 = Instalacion.ConstructorNombre("Molienda");
            Componente componente4 = Dispositivo.NombreTipo("Molino", tipo1);
            Variable variable1 = Variable.NombreMinimoMaximo("Velocidad", 0, 100);
            Variable variable2 = Variable.NombreMinimoMaximo("Carga", 0, 500);
            componente4.AgregarVariable(variable1);
            componente4.AgregarVariable(variable2);
            Componente componente5 = Dispositivo.NombreTipo("Prensa", tipo1);
            componente3.AgregarDependencia(componente4);
            componente3.AgregarDependencia(componente5);
            componente1.AgregarDependencia(componente2);
            componente1.AgregarDependencia(componente3);
            modelo.RegistrarElemento(componente1);
            Componente componente6 = Instalacion.ConstructorNombre("Clarificación");
            Componente componente7 = Dispositivo.NombreTipo("Batea", tipo2);
            Componente componente8 = Dispositivo.NombreTipo("Calentadores", tipo2);
            componente6.AgregarDependencia(componente7);
            componente6.AgregarDependencia(componente8);
            modelo.RegistrarElemento(componente6);
            Componente componente9 = Instalacion.ConstructorNombre("Evaporación");
            Componente componente10 = Instalacion.ConstructorNombre("Evaporadores");
            Variable variable3 = Variable.NombreMinimoMaximo("Temperatura", 0, 200);
            Variable variable4 = Variable.NombreMinimoMaximo("Presión", 10, 30);
            componente10.AgregarVariable(variable3);
            componente10.AgregarVariable(variable4);
            Componente componente11 = Dispositivo.NombreTipo("Evaporador 1", tipo1);
            Componente componente12 = Dispositivo.NombreTipo("Evaporador 2", tipo1);
            componente10.AgregarDependencia(componente11);
            componente10.AgregarDependencia(componente12);
            componente9.AgregarDependencia(componente10);
            modelo.RegistrarElemento(componente9);
            Componente componente13 = Instalacion.ConstructorNombre("Centrifugación");
            Componente componente14 = Dispositivo.NombreTipo("Centrifugadora 1", tipo2);
            Componente componente15 = Dispositivo.NombreTipo("Centrifugadora 2", tipo2);
            componente13.AgregarDependencia(componente14);
            componente13.AgregarDependencia(componente15);
            modelo.RegistrarElemento(componente13);
            RecargarTodoComponente();
        }

        private void RecargarTodoComponente()
        {
            RecargarTreeView();
            RecargarTableroDeControl();
            ActivacionBotonesVariables();
            ActivacionBotonesTipo();
            ActivacionBotonAgregarVariable();
        }

        private void ActivacionBotonAgregarVariable()
        {
            /*if (modelo.ExistenDispositivos() || modelo.ExistenInstalaciones())
            {
                btnAgregarVariable.Enabled = true;
                btnAgregarVariable.BackColor = Color.Chartreuse;
            }
            else
            {
                btnAgregarVariable.Enabled = false;
                btnAgregarVariable.BackColor = Color.LightGreen;
            }*/
        }

        private void ActivacionBotonesVariables()
        {
            if (lstVariables.SelectedItems.Count > 0 && lstVariables.SelectedItems[0].Tag is Variable)
            {
                btnEditarVariable.Enabled = true;
                btnEliminarVariable.Enabled = true;
                btnAgregarValorVariable.Enabled = true;
                btnValoresHistoricos.Enabled = true;
                Variable variableSeleccionada = (Variable)lstVariables.SelectedItems[0].Tag;
                btnValoresHistoricos.Enabled = !Auxiliar.EsListaVacia(variableSeleccionada.Historico);
                btnEliminarVariable.BackColor = Color.Red;
                btnEditarVariable.BackColor = Color.PaleTurquoise;
            }
            else
            {
                btnEditarVariable.Enabled = false;
                btnEliminarVariable.Enabled = false;
                btnAgregarValorVariable.Enabled = false;
                btnValoresHistoricos.Enabled = false;
                btnEliminarVariable.BackColor = Color.LightPink;
                btnEditarVariable.BackColor = Color.LightCyan;

            }
        }

        private void ActivacionBotonesTipo()
        {
            if (modelo.ExistenTipos())
            {
                btnAgregarDispositivo.Enabled = true;
                btnMenuOpcionesTipo.Enabled = true;
            }
            else
            {
                btnAgregarDispositivo.Enabled = false;
                btnMenuOpcionesTipo.Enabled = false;
            }
        }

        private void ActivacionBotonesIncidente()
        {
            if (Auxiliar.NoEsNulo(treeViewPlantaDeProduccion.SelectedNode))
            {
                btnAgregarIncidente.Enabled = true;
                btnAgregarIncidente.BackColor = Color.Chartreuse;
            }
            else
            {
                btnAgregarIncidente.Enabled = false;
                btnAgregarIncidente.BackColor = Color.LightGreen;
            }
        }


        private void RecargarTreeView()
        {
            using (ContextoSCADA c = new ContextoSCADA("name=ContextoSCADA"))
            {
                Cursor.Current = Cursors.WaitCursor;
                treeViewPlantaDeProduccion.BeginUpdate();
                treeViewPlantaDeProduccion.Nodes.Clear();
                foreach (ElementoSCADA elemento in modelo.ElementosPrimarios)
                {
                    TreeNode nodo = ObtenerNodoDeRamaJerarquica(elemento);
                    treeViewPlantaDeProduccion.Nodes.Add(nodo);
                }
                Cursor.Current = Cursors.Default;
                treeViewPlantaDeProduccion.EndUpdate();
                ActivacionBotonesIncidente();
            }
        }

        private TreeNode ObtenerNodoDeRamaJerarquica(ElementoSCADA elemento)
        {
            List<TreeNode> listaAuxiliar = new List<TreeNode>();
            foreach (ElementoSCADA hijo in elemento.Dependencias)
            {
                listaAuxiliar.Add(ObtenerNodoDeRamaJerarquica(hijo));
            }
            TreeNode retorno = new TreeNode(elemento.ToString(), listaAuxiliar.ToArray());
            Dispositivo dispositivo = elemento as Dispositivo;
            if (Auxiliar.NoEsNulo(dispositivo) && !dispositivo.EnUso)
            {
                retorno.ForeColor = Color.OrangeRed;
            }
            else
            {
                retorno.ForeColor = Color.Black;
            }
            retorno.Tag = elemento;
            return retorno;
        }

        private void treeViewPlantaDeProduccion_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lstVariables.Clear();
            Componente componenteSeleccionado = treeViewPlantaDeProduccion.SelectedNode.Tag as Componente;
            if (Auxiliar.NoEsNulo(componenteSeleccionado))
            {
                ActivacionBotonesIncidente();
                if (componenteSeleccionado.Variables.Count > 0)
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
                    lstVariables.Items.Add(new ListViewItem("\n\nSin datos a mostrar"));
                }
            }
            else
            {
                lstVariables.Text = "Sin datos para mostrar.";
            }
        }

        private void RecargarTableroDeControl()
        {
            lstTableroControl.Clear();
            foreach (ElementoSCADA elemento in modelo.ElementosPrimarios)
            {
                if (elemento.EnUso)
                {
                    if (elemento.CantidadAlarmasActivas > 0)
                    {
                        lstTableroControl.SelectionBackColor = Color.Red;
                    }
                    else
                    {
                        lstTableroControl.SelectionBackColor = Color.Chartreuse;
                    }
                    lstTableroControl.AppendText("\n" + elemento.Nombre + ": " + elemento.CantidadAlarmasActivas + " Alarmas\n");
                }
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
                panelSistema.Controls.Add(new RegistrarDispositivo(modelo, panelSistema, null, dispositivoAModificar));
            }
            else
            {
                MessageBox.Show("Es necesario utilizar la función de \"Modificar Instalación\" para la selección realizada");
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
                        + " La eliminación es irreversible", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    ElementoSCADA padre = instalacionAEliminar.ElementoPadre;
                    if (Auxiliar.NoEsNulo(padre))
                    {
                        padre.EliminarDependencia(instalacionAEliminar);
                    }
                    else
                    {
                        modelo.EliminarElemento(instalacionAEliminar);
                    }
                    treeViewPlantaDeProduccion.Nodes.Remove(treeViewPlantaDeProduccion.SelectedNode);
                    RecargarTableroDeControl();
                }
            }
            else
            {
                MessageBox.Show("Es necesario utilizar la función de \"Eliminar Dispositivo\" para la selección realizada",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        + " La eliminación es irreversible", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    ElementoSCADA padre = dispositivoAEliminar.ElementoPadre;
                    if (Auxiliar.NoEsNulo(padre))
                    {
                        padre.EliminarDependencia(dispositivoAEliminar);
                    }
                    else
                    {
                        modelo.EliminarElemento(dispositivoAEliminar);
                    }
                    treeViewPlantaDeProduccion.Nodes.Remove(treeViewPlantaDeProduccion.SelectedNode);
                    RecargarTableroDeControl();
                }
            }
            else
            {
                MessageBox.Show("Es necesario utilizar otra función de eliminado para la selección realizada",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lstVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivacionBotonesVariables();
        }

        private void btnMenuOpcionesTipo_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new MenuOpcionesTipoDispositivo(modelo, panelSistema));
        }

        private void btnAgregarIncidente_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarIncidente(modelo, panelSistema));
        }

        private void btnVerIncidentes_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new VerIncidentes(modelo, panelSistema, null));
        }

        private void btnAgregarPlantaIndustrial_Click(object sender, EventArgs e)
        {
            TreeNode seleccionado = treeViewPlantaDeProduccion.SelectedNode;
            if (Auxiliar.NoEsNulo(seleccionado))
            {
                if (seleccionado.Tag is PlantaIndustrial)
                {
                    PlantaIndustrial plantaIndustrialPadre = seleccionado.Tag as PlantaIndustrial;
                    panelSistema.Controls.Clear();
                    panelSistema.Controls.Add(new RegistrarPlantaIndustrial(modelo, panelSistema, plantaIndustrialPadre, false));
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una Planta Industrial para acceder a esta funcionalidad", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                panelSistema.Controls.Clear();
                panelSistema.Controls.Add(new RegistrarPlantaIndustrial(modelo, panelSistema, null, false));
            }
        }

        private void btnEliminarPlantaIndustrial_Click(object sender, EventArgs e)
        {
            VerificarPlantaIndustrialSeleccionada(EliminarPlantaIndustrialSeleccionada);
        }

        private void VerificarPlantaIndustrialSeleccionada(Action unaAccionARealizar)
        {
            PlantaIndustrial plantaSeleccionada = treeViewPlantaDeProduccion.SelectedNode.Tag as PlantaIndustrial;
            if (Auxiliar.NoEsNulo(plantaSeleccionada))
            {
                unaAccionARealizar.Invoke();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Planta Industrial para acceder a esta funcionalidad", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarPlantaIndustrialSeleccionada()
        {
            PlantaIndustrial plantaIndustrialAEliminar = treeViewPlantaDeProduccion.SelectedNode.Tag as PlantaIndustrial;
            if (Auxiliar.NoEsNulo(plantaIndustrialAEliminar))
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea continuar con la operación?"
                        + " La eliminación es irreversible", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    ElementoSCADA padre = plantaIndustrialAEliminar.ElementoPadre;
                    if (Auxiliar.NoEsNulo(padre))
                    {
                        padre.EliminarDependencia(plantaIndustrialAEliminar);
                    }
                    else
                    {
                        modelo.EliminarElemento(plantaIndustrialAEliminar);
                    }
                    treeViewPlantaDeProduccion.Nodes.Remove(treeViewPlantaDeProduccion.SelectedNode);
                    RecargarTableroDeControl();
                }
            }
            else
            {
                MessageBox.Show("Es necesario utilizar otra función de eliminado para la selección realizada",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEditarPlantaIndustrial_Click(object sender, EventArgs e)
        {
            VerificarPlantaIndustrialSeleccionada(AbrirPanelEditarPlantaIndustrial);
        }

        private void AbrirPanelEditarPlantaIndustrial()
        {
            PlantaIndustrial plantaAModificar = treeViewPlantaDeProduccion.SelectedNode.Tag as PlantaIndustrial;
            if (Auxiliar.NoEsNulo(plantaAModificar))
            {
                panelSistema.Controls.Clear();
                panelSistema.Controls.Add(new RegistrarPlantaIndustrial(modelo, panelSistema, plantaAModificar, true));
            }
            else
            {
                MessageBox.Show("Es necesario utilizar otra función de \"Modificar\" para la selección realizada");
            }
        }
    }
}
