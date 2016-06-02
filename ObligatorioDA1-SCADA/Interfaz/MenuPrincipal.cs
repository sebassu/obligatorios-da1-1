using Dominio;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using Excepciones;

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
                panelSistema.Controls.Add(new RegistrarInstalacion(modelo, panelSistema, instalacionAModificar));
            }
            else
            {
                MessageBox.Show("Es necesario utilizar la función de \"Modificar Dispositivo\" para la selección realizada", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregarDispositivo_Click(object sender, EventArgs e)
        {
            if (modelo.ExistenTipos())
            {
                IElementoSCADA unaInstalacion = null;
                if (Auxiliar.NoEsNulo(treeViewPlantaDeProduccion.SelectedNode))
                {
                    unaInstalacion = treeViewPlantaDeProduccion.SelectedNode.Tag as IElementoSCADA;
                }
                panelSistema.Controls.Clear();
                panelSistema.Controls.Add(new RegistrarDispositivo(modelo, panelSistema, unaInstalacion));
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
            if (Auxiliar.NoEsNulo(treeViewPlantaDeProduccion.SelectedNode))
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
            componente3.AgregarDependencia(componente4);
            componente3.AgregarDependencia(componente5);
            componente1.AgregarDependencia(componente2);
            componente1.AgregarDependencia(componente3);
            modelo.RegistrarComponente(componente1);
            Componente componente6 = Instalacion.ConstructorNombre("Clarificación");
            Componente componente7 = Dispositivo.NombreTipoEnUso("Batea", tipo2, true);
            Componente componente8 = Dispositivo.NombreTipoEnUso("Calentadores", tipo2, true);
            componente6.AgregarDependencia(componente7);
            componente6.AgregarDependencia(componente8);
            modelo.RegistrarComponente(componente6);
            Componente componente9 = Instalacion.ConstructorNombre("Evaporación");
            Componente componente10 = Instalacion.ConstructorNombre("Evaporadores");
            Variable variable3 = Variable.NombreMinimoMaximo("Temperatura", 0, 200);
            Variable variable4 = Variable.NombreMinimoMaximo("Presión", 10, 30);
            componente10.AgregarVariable(variable3);
            componente10.AgregarVariable(variable4);
            Componente componente11 = Dispositivo.NombreTipoEnUso("Evaporador 1", tipo1, true);
            Componente componente12 = Dispositivo.NombreTipoEnUso("Evaporador 2", tipo1, true);
            componente10.AgregarDependencia(componente11);
            componente10.AgregarDependencia(componente12);
            componente9.AgregarDependencia(componente10);
            modelo.RegistrarComponente(componente9);
            Componente componente13 = Instalacion.ConstructorNombre("Centrifugación");
            Componente componente14 = Dispositivo.NombreTipoEnUso("Centrifugadora 1", tipo2, true);
            Componente componente15 = Dispositivo.NombreTipoEnUso("Centrifugadora 2", tipo2, true);
            componente13.AgregarDependencia(componente14);
            componente13.AgregarDependencia(componente15);
            modelo.RegistrarComponente(componente13);
            RecargarTodoComponente();
        }

        private void RecargarTodoComponente()
        {
            RecargarTreeView();
            RecargarTableroDeControl();
            ActivacionBotonesVariables();
            ActivacionBotonesTipo();
            //ActivacionBotonAgregarVariable();
        }

        //private void ActivacionBotonAgregarVariable()
        //{
        //    /*if (modelo.ExistenDispositivos() || modelo.ExistenInstalaciones())
        //    {
        //        btnAgregarVariable.Enabled = true;
        //        btnAgregarVariable.BackColor = Color.Chartreuse;
        //    }
        //    else
        //    {
        //        btnAgregarVariable.Enabled = false;
        //        btnAgregarVariable.BackColor = Color.LightGreen;
        //    }*/
        //}

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
            ActivacionBotonesIncidente();
        }

        private TreeNode ObtenerNodoDeRamaJerarquica(IElementoSCADA elementoActual)
        {
            List<TreeNode> listaAuxiliar = new List<TreeNode>();
            foreach (IElementoSCADA hijo in elementoActual.Dependencias)
            {
                listaAuxiliar.Add(ObtenerNodoDeRamaJerarquica(hijo));
            }
            TreeNode retorno = new TreeNode(elementoActual.ToString(), listaAuxiliar.ToArray());
            if (!elementoActual.EnUso)
            {
                retorno.ForeColor = Color.OrangeRed;
            }
            else
            {
                retorno.ForeColor = Color.Black;
            }
            retorno.Tag = elementoActual;
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
            foreach (IElementoSCADA elemento in modelo.ComponentesPrimarios)
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
                MessageBox.Show("Es necesario utilizar la función de \"Modificar Instalación\" para la selección realizada", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    IElementoSCADA padre = instalacionAEliminar.ElementoPadre;
                    if (Auxiliar.NoEsNulo(padre))
                    {
                        padre.EliminarDependencia(instalacionAEliminar);
                    }
                    else
                    {
                        modelo.EliminarComponente(instalacionAEliminar);
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
                    IElementoSCADA padre = dispositivoAEliminar.ElementoPadre;
                    if (Auxiliar.NoEsNulo(padre))
                    {
                        padre.EliminarDependencia(dispositivoAEliminar);
                    }
                    else
                    {
                        modelo.EliminarComponente(dispositivoAEliminar);
                    }
                    treeViewPlantaDeProduccion.Nodes.Remove(treeViewPlantaDeProduccion.SelectedNode);
                    RecargarTableroDeControl();
                }
            }
            else
            {
                MessageBox.Show("Es necesario utilizar la función de \"Eliminar Instalación\" para la selección realizada",
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
            VerificarElementoSeleccionado(AgregarIncidente);
        }

        private void AgregarIncidente()
        {
            IElementoSCADA unElemento = treeViewPlantaDeProduccion.SelectedNode.Tag as IElementoSCADA;
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarIncidente(modelo, panelSistema, unElemento));
        }

        private void btnVerIncidentes_Click(object sender, EventArgs e)
        {
            VerificarElementoSeleccionado(AbrirIncidentes);
        }

        private void VerificarElementoSeleccionado(Action unaAccionARealizar)
        {
            TreeNode seleccionado = treeViewPlantaDeProduccion.SelectedNode;
            if (Auxiliar.NoEsNulo(seleccionado))
            {
                unaAccionARealizar.Invoke();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para acceder a esta funcionalidad", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AbrirIncidentes()
        {
            IElementoSCADA unElemento = treeViewPlantaDeProduccion.SelectedNode.Tag as IElementoSCADA;
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new VerIncidentes(modelo, panelSistema, unElemento));
        }

        private void btnAgregarPlantaIndustrial_Click(object sender, EventArgs e)
        {
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarPlantaIndustrial(modelo, panelSistema, null));
        }

        private void treeViewPlantaDeProduccion_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void treeViewPlantaDeProduccion_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void treeViewPlantaDeProduccion_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = treeViewPlantaDeProduccion.PointToClient(new Point(e.X, e.Y));
            treeViewPlantaDeProduccion.SelectedNode = treeViewPlantaDeProduccion.GetNodeAt(targetPoint);
        }

        private void treeViewPlantaDeProduccion_DragDrop(object sender, DragEventArgs e)
        {
            Point puntoLlegada = treeViewPlantaDeProduccion.PointToClient(new Point(e.X, e.Y));
            TreeNode nodoDestino = treeViewPlantaDeProduccion.GetNodeAt(puntoLlegada);
            TreeNode nodoArrastrado = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (Auxiliar.NoEsNulo(nodoArrastrado) && !nodoArrastrado.Equals(nodoDestino))
            {
                try
                {
                    if (e.Effect == DragDropEffects.Move)
                    {
                        IElementoSCADA elementoArrastrado = nodoArrastrado.Tag as IElementoSCADA;
                        EliminarPadre(elementoArrastrado);
                        if (Auxiliar.NoEsNulo(nodoDestino))
                        {
                            IElementoSCADA elementoDestino = nodoDestino.Tag as IElementoSCADA;
                            elementoDestino.AgregarDependencia(elementoArrastrado);
                            nodoArrastrado.Remove();
                            nodoDestino.Nodes.Add(nodoArrastrado);
                        }
                        else
                        {
                            //Agregar Dependencia en AccesoADatos.
                        }
                    }
                    nodoDestino.Expand();
                    RecargarTableroDeControl();
                }
                catch (ElementoSCADAExcepcion excepcionProducida)
                {
                    MessageBox.Show(excepcionProducida.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EliminarPadre(IElementoSCADA elementoArrastrado)
        {
            IElementoSCADA padreArrastrado = elementoArrastrado.ElementoPadre;
            if (Auxiliar.NoEsNulo(padreArrastrado))
            {
                padreArrastrado.EliminarDependencia(elementoArrastrado);
            }
            else
            {
                // Eliminar Dependencia de AccesoADatos.
            }
        }

        private void btnEliminarPlantaIndustrial_Click(object sender, EventArgs e)
        {
            //VerificarPlantaIndustrialSeleccionada(EliminarPlantaIndustrialSeleccionada);
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
                panelSistema.Controls.Add(new RegistrarPlantaIndustrial(modelo, panelSistema, plantaAModificar));
            }
            else
            {
                MessageBox.Show("Es necesario utilizar otra función de \"Modificar\" para la selección realizada", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
