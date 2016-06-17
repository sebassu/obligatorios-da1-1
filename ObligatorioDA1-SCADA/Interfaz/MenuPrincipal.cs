using Dominio;
using Persistencia;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using Excepciones;
using System.Collections;

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
            try
            {
                indiceSeleccionado = modelo.CodigoDeEstrategiaSeleccionada();
                cbxMetodoGuardadoIncidentes.SelectedIndex = indiceSeleccionado;
            }
            catch (AccesoADatosExcepcion e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarInstalacion_Click(object sender, EventArgs e)
        {
            VerificarElementoSeleccionado(AbrirPanelRegistrarInstalacion);
        }

        private void VerificarElementoSeleccionado(Action unaAccionARealizar)
        {
            TreeNode seleccionado = treeViewProduccion.SelectedNode;
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
            ElementoSCADA elementoSeleccionado = treeViewProduccion.SelectedNode.Tag as ElementoSCADA;
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarInstalacion(modelo, panelSistema, elementoSeleccionado, false));
        }

        private void VerificarComponenteSeleccionado(Action unaAccionARealizar)
        {
            TreeNode seleccionado = treeViewProduccion.SelectedNode;
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
            object seleccion = treeViewProduccion.SelectedNode.Tag;
            Instalacion instalacionAModificar = seleccion as Instalacion;
            if (Auxiliar.NoEsNulo(instalacionAModificar))
            {
                panelSistema.Controls.Clear();
                panelSistema.Controls.Add(new RegistrarInstalacion(modelo, panelSistema, instalacionAModificar, true));
            }
            else
            {
                MessageBox.Show("Es necesario utilizar la función de \"Modificar " + seleccion.GetType().Name +
                    "\" para la selección realizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregarDispositivo_Click(object sender, EventArgs e)
        {
            if (modelo.ExistenTipos())
            {
                ElementoSCADA unElemento = null;
                if (Auxiliar.NoEsNulo(treeViewProduccion.SelectedNode))
                {
                    object objetoSeleccionado = treeViewProduccion.SelectedNode.Tag;
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
            TreeNode nodoSeleccionado = treeViewProduccion.SelectedNode;
            if (Auxiliar.NoEsNulo(nodoSeleccionado) && treeViewProduccion.SelectedNode.Tag is Componente)
            {
                Componente unComponente = treeViewProduccion.SelectedNode.Tag as Componente;
                panelSistema.Controls.Clear();
                panelSistema.Controls.Add(new RegistrarVariable(modelo, panelSistema, unComponente));
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Componente para acceder a esta funcionalidad", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            Componente componentePadre = unaVariable.ElementoPadre as Componente;
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

        private void RecargarTodoComponente()
        {
            RecargarTreeView();
            RecargarTableroDeControl();
            ActivacionBotonesVariables();
            ActivacionBotonesTipo();
            ActivacionBotonesIncidente();
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
            if (Auxiliar.NoEsNulo(treeViewProduccion.SelectedNode))
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
                treeViewProduccion.BeginUpdate();
                treeViewProduccion.Nodes.Clear();
                foreach (ElementoSCADA elemento in modelo.ElementosPrimarios)
                {
                    TreeNode nodo = ObtenerNodoDeRamaJerarquica(elemento);
                    treeViewProduccion.Nodes.Add(nodo);
                }
                Cursor.Current = Cursors.Default;
                treeViewProduccion.EndUpdate();
                treeViewProduccion.ExpandAll();
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
            ElementoSCADA componenteSeleccionado = treeViewProduccion.SelectedNode.Tag as ElementoSCADA;
            if (Auxiliar.NoEsNulo(componenteSeleccionado))
            {
                ActivacionBotonesIncidente();
                RecargarTableroDeControl();
                if (componenteSeleccionado.Variables.Count > 0)
                {
                    foreach (Variable variableDelComponente in componenteSeleccionado.Variables)
                    {
                        ListViewItem itemAAgregar = new ListViewItem(variableDelComponente.ToString());
                        itemAAgregar.Tag = variableDelComponente;
                        lstVariables.Items.Add(itemAAgregar);
                    }
                    return;
                }
            }
            lstVariables.Items.Add(new ListViewItem("Sin datos a mostrar."));
        }

        private void RecargarTableroDeControl()
        {
            if (Auxiliar.NoEsNulo(treeViewProduccion.SelectedNode))
            {
                PlantaIndustrial elementoSeleccionado = treeViewProduccion.SelectedNode.Tag as PlantaIndustrial;
                if (Auxiliar.NoEsNulo(elementoSeleccionado))
                {
                    lstTableroControl.Clear();
                    if (elementoSeleccionado.Dependencias.Count > 0)
                    {
                        foreach (ElementoSCADA elemento in elementoSeleccionado.Dependencias)
                        {
                            ImprimirMensajeAlarmasAdvertencias(elemento);
                        }
                    }
                    else
                    {
                        lstTableroControl.AppendText("\nSin datos a mostrar.");
                    }
                }
            }
        }

        private void ImprimirMensajeAlarmasAdvertencias(ElementoSCADA elemento)
        {

            if (elemento.CantidadAlarmasActivas > 0)
            {
                lstTableroControl.SelectionBackColor = Color.Red;
                lstTableroControl.AppendText("\n" + elemento.Nombre + ": " + elemento.CantidadAlarmasActivas + " Alarma(s)\n");
            }
            else if (elemento.CantidadAdvertenciasActivas > 0)
            {
                lstTableroControl.SelectionBackColor = Color.Yellow;
                lstTableroControl.AppendText("\n" + elemento.Nombre + ": " + elemento.CantidadAdvertenciasActivas + " Advertencia(s)\n");
            }
            else
            {
                lstTableroControl.SelectionBackColor = Color.Chartreuse;
                lstTableroControl.AppendText("\n" + elemento.Nombre + ": 0 Alarmas/Advertencias\n");
            }
        }

        private void btnEditarDispositivo_Click(object sender, EventArgs e)
        {
            VerificarComponenteSeleccionado(AbrirPanelEditarDispositivo);
        }

        private void AbrirPanelEditarDispositivo()
        {
            if (Auxiliar.NoEsNulo(treeViewProduccion.SelectedNode))
            {
                object seleccion = treeViewProduccion.SelectedNode.Tag;
                Dispositivo dispositivoAModificar = seleccion as Dispositivo;
                if (Auxiliar.NoEsNulo(dispositivoAModificar))
                {
                    panelSistema.Controls.Clear();
                    panelSistema.Controls.Add(new RegistrarDispositivo(modelo, panelSistema, null, dispositivoAModificar));
                }
                else
                {
                    MessageBox.Show("Es necesario utilizar la función de \"Modificar " + seleccion.GetType().Name +
                        "\" para la selección realizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnBorrarInstalacion_Click(object sender, EventArgs e)
        {
            VerificarComponenteSeleccionado(EliminarInstalacionSeleccionada);
        }

        private void EliminarInstalacionSeleccionada()
        {
            object seleccion = treeViewProduccion.SelectedNode.Tag;
            Instalacion instalacionAEliminar = seleccion as Instalacion;
            if (Auxiliar.NoEsNulo(instalacionAEliminar))
            {
                EliminarElemento(instalacionAEliminar);
            }
            else
            {
                MessageBox.Show("Es necesario utilizar la función de \"Eliminar" + seleccion.GetType().Name
                    + "\"  para la selección realizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EliminarElemento(ElementoSCADA elementoAEliminar)
        {
            if (Auxiliar.EsListaVacia(elementoAEliminar.Dependencias))
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea continuar con la operación?"
                        + " La eliminación es irreversible", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    modelo.EliminarElemento(elementoAEliminar);
                    treeViewProduccion.Nodes.Remove(treeViewProduccion.SelectedNode);
                    RecargarTableroDeControl();
                }
            }
            else {
                MessageBox.Show("No es posible eliminar al elemento seleccionado: posee dependencias.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarDispositivo_Click(object sender, EventArgs e)
        {
            VerificarComponenteSeleccionado(EliminarDispositivoSeleccionado);
        }

        private void EliminarDispositivoSeleccionado()
        {
            object seleccion = treeViewProduccion.SelectedNode.Tag;
            Dispositivo dispositivoAEliminar = seleccion as Dispositivo;
            if (Auxiliar.NoEsNulo(dispositivoAEliminar))
            {
                EliminarElemento(dispositivoAEliminar);
            }
            else
            {
                MessageBox.Show("Es necesario utilizar la función de \"Eliminar" + seleccion.GetType().Name
                    + "\"  para la selección realizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            VerificarElementoSCADASeleccionado(AbrirRegistrarIncidente);
        }

        private void AbrirRegistrarIncidente()
        {
            ElementoSCADA elementoSeleccionado = treeViewProduccion.SelectedNode.Tag as ElementoSCADA;
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarIncidente(modelo, panelSistema, elementoSeleccionado));
        }

        private void btnVerIncidentes_Click(object sender, EventArgs e)
        {
            VerificarElementoSCADASeleccionado(AbrirPanelVerIncidentes);
        }

        private void VerificarElementoSCADASeleccionado(Action unaAccionARealizar)
        {
            TreeNode elementoSeleccionado = treeViewProduccion.SelectedNode;
            if (Auxiliar.NoEsNulo(elementoSeleccionado))
            {
                if (elementoSeleccionado.Tag is ElementoSCADA)
                {
                    unaAccionARealizar.Invoke();
                    return;
                }
            }
            MessageBox.Show("Debe seleccionar un elemento para acceder a esta funcionalidad", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AbrirPanelVerIncidentes()
        {
            ElementoSCADA elementoSeleccionado = treeViewProduccion.SelectedNode.Tag as ElementoSCADA;
            DialogResult resultado = MessageBox.Show("¿Desea visualizar los incidentes de manera recursiva?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            IList incidentesAVisualizar = FiltrarPorDependencias(modelo.Incidentes, elementoSeleccionado, resultado == DialogResult.Yes);
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new VerIncidentes(modelo, panelSistema, elementoSeleccionado, incidentesAVisualizar));
        }

        private IList FiltrarPorDependencias(IList incidentes, ElementoSCADA elementoActual, bool esRecursivo)
        {
            List<Tuple<string, Incidente>> retorno = new List<Tuple<string, Incidente>>();
            FiltrarPorDependenciasAux(incidentes, elementoActual, esRecursivo, retorno);
            return retorno.AsReadOnly();
        }

        private void FiltrarPorDependenciasAux(IList incidentes, ElementoSCADA elementoActual, bool esRecursivo, List<Tuple<string, Incidente>> retorno)
        {
            foreach (Incidente incidenteIteracion in incidentes)
            {
                if (incidenteIteracion.IdElementoAsociado.Equals(elementoActual.ID))
                {
                    retorno.Add(Tuple.Create(elementoActual.ToString(), incidenteIteracion));
                }
            }
            if (esRecursivo)
            {
                foreach (ElementoSCADA elementoIteracion in elementoActual.Dependencias)
                {
                    FiltrarPorDependenciasAux(incidentes, elementoIteracion, esRecursivo, retorno);
                }
            }
        }

        private void btnAgregarPlantaIndustrial_Click(object sender, EventArgs e)
        {
            PlantaIndustrial plantaIndustrialPadre = null;
            TreeNode seleccionado = treeViewProduccion.SelectedNode;
            if (Auxiliar.NoEsNulo(seleccionado))
            {
                plantaIndustrialPadre = seleccionado.Tag as PlantaIndustrial;
            }
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarPlantaIndustrial(modelo, panelSistema, plantaIndustrialPadre, false));
        }

        private void btnEliminarPlantaIndustrial_Click(object sender, EventArgs e)
        {
            VerificarPlantaIndustrialSeleccionada(EliminarPlantaIndustrialSeleccionada);
        }

        private void VerificarPlantaIndustrialSeleccionada(Action unaAccionARealizar)
        {
            if (Auxiliar.NoEsNulo(treeViewProduccion.SelectedNode))
            {
                PlantaIndustrial plantaSeleccionada = treeViewProduccion.SelectedNode.Tag as PlantaIndustrial;
                if (Auxiliar.NoEsNulo(plantaSeleccionada))
                {
                    unaAccionARealizar.Invoke();
                    return;
                }
            }
            MessageBox.Show("Debe seleccionar una Planta Industrial para acceder a esta funcionalidad", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarPlantaIndustrialSeleccionada()
        {
            object seleccion = treeViewProduccion.SelectedNode.Tag;
            PlantaIndustrial plantaIndustrialAEliminar = seleccion as PlantaIndustrial;
            if (Auxiliar.NoEsNulo(plantaIndustrialAEliminar))
            {
                EliminarElemento(plantaIndustrialAEliminar);
            }
            else
            {
                MessageBox.Show("Es necesario utilizar la función de \"Eliminar " + seleccion.GetType().Name
                    + "\"  para la selección realizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditarPlantaIndustrial_Click(object sender, EventArgs e)
        {
            VerificarPlantaIndustrialSeleccionada(AbrirPanelEditarPlantaIndustrial);
        }

        private void AbrirPanelEditarPlantaIndustrial()
        {
            object seleccion = treeViewProduccion.SelectedNode.Tag;
            PlantaIndustrial plantaAModificar = seleccion as PlantaIndustrial;
            if (Auxiliar.NoEsNulo(plantaAModificar))
            {
                panelSistema.Controls.Clear();
                panelSistema.Controls.Add(new RegistrarPlantaIndustrial(modelo, panelSistema, plantaAModificar, true));
            }
            else
            {
                MessageBox.Show("Es necesario utilizar la función de \"Modificar " + seleccion.GetType().Name +
                    "\" para la selección realizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int indiceSeleccionado;
        private void cbxMetodoGuardadoIncidentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceSeleccionadoNuevo = cbxMetodoGuardadoIncidentes.SelectedIndex;
            if (indiceSeleccionadoNuevo != indiceSeleccionado)
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea continuar con la operación?"
                    + " Se eliminarán los incidentes registrados hasta el momento.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    modelo.CambiarEstrategia(indiceSeleccionadoNuevo);
                    indiceSeleccionado = indiceSeleccionadoNuevo;
                }
                else
                {
                    cbxMetodoGuardadoIncidentes.SelectedIndex = indiceSeleccionado;
                }
            }
        }

        private void treeViewPlantaDeProduccion_DoubleClick(object sender, EventArgs e)
        {
            if (Auxiliar.NoEsNulo(treeViewProduccion.SelectedNode))
            {
                ElementoSCADA elementoSeleccionado = treeViewProduccion.SelectedNode.Tag as ElementoSCADA;
                if (Auxiliar.NoEsNulo(elementoSeleccionado))
                {
                    MostrarDrillDownVariables(elementoSeleccionado);
                }
            }
        }

        private void MostrarDrillDownVariables(ElementoSCADA unElemento)
        {
            string mensaje;
            if (unElemento.CantidadAlarmasActivas > 0)
            {
                mensaje = "Detalle de alarmas:\n\n";
                GenerarMensajeDrillDown(unElemento, true, unElemento.CantidadAlarmasActivas, ref mensaje);
            }
            else if (unElemento.CantidadAdvertenciasActivas > 0)
            {
                mensaje = "Detalle de advertencias:\n\n";
                GenerarMensajeDrillDown(unElemento, false, unElemento.CantidadAdvertenciasActivas, ref mensaje);
            }
            else {
                mensaje = "El elemento seleccionado no posee alarmas ni advertencias activas.";
            }
            MessageBox.Show(mensaje, "Drill down de variables", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GenerarMensajeDrillDown(ElementoSCADA unElemento, bool buscarAlarmas, int cantidadActual, ref string retorno)
        {
            if (cantidadActual > 0)
            {
                foreach (Variable variableIteracion in unElemento.Variables)
                {
                    if (buscarAlarmas && variableIteracion.AlarmaActiva)
                    {
                        retorno += variableIteracion.ToString() + " -> " + unElemento.ToString() + "\n";
                        cantidadActual = cantidadActual - 1;
                    }
                    else if (!buscarAlarmas && variableIteracion.AdvertenciaActiva)
                    {
                        retorno += variableIteracion.ToString() + " -> " + unElemento.ToString() + "\n";
                        cantidadActual = cantidadActual - 1;
                    }
                }
                foreach (ElementoSCADA elementoHijo in unElemento.Dependencias)
                {
                    GenerarMensajeDrillDown(elementoHijo, buscarAlarmas, cantidadActual, ref retorno);
                }
            }
        }
    }
}