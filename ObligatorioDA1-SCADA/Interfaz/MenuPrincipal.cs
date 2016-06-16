using Dominio;
using Persistencia;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            cbxMetodoGuardadoIncidentes.SelectedItem = "Base de Datos";
            indiceSeleccionado = 0;
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
                MessageBox.Show("Es necesario utilizar la función de \"Modificar\" al elemento que corresponda para la selección realizada",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregarDispositivo_Click(object sender, EventArgs e)
        {
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
            TreeNode nodoSeleccionado = treeViewPlantaDeProduccion.SelectedNode;
            if (Auxiliar.NoEsNulo(nodoSeleccionado) && treeViewPlantaDeProduccion.SelectedNode.Tag is Componente)
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

        private void btnCargarDatosPrueba_Click(object sender, EventArgs e)
        {
            // CargarDatosDePrueba();
            MessageBox.Show("Funcion no disponible");
        }

        private void RecargarTodoComponente()
        {
            RecargarTreeView();
            RecargarTableroDeControl();
            ActivacionBotonesVariables();
            ActivacionBotonesTipo();
            ActivacionBotonAgregarVariable();
            ActivacionBotonesIncidente();
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
            ElementoSCADA componenteSeleccionado = treeViewPlantaDeProduccion.SelectedNode.Tag as ElementoSCADA;
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
            if (Auxiliar.NoEsNulo(treeViewPlantaDeProduccion.SelectedNode))
            {
                PlantaIndustrial elementoSeleccionado = treeViewPlantaDeProduccion.SelectedNode.Tag as PlantaIndustrial;
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
                        lstTableroControl.AppendText("Sin datos a mostrar.");
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
            if (Auxiliar.NoEsNulo(treeViewPlantaDeProduccion.SelectedNode))
            {
                Dispositivo dispositivoAModificar = treeViewPlantaDeProduccion.SelectedNode.Tag as Dispositivo;
                if (Auxiliar.NoEsNulo(dispositivoAModificar))
                {
                    panelSistema.Controls.Clear();
                    panelSistema.Controls.Add(new RegistrarDispositivo(modelo, panelSistema, null, dispositivoAModificar));
                }
                else
                {
                    MessageBox.Show("Es necesario utilizar la función de \"Modificar\" de otro tipo para la selección realizada",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                    modelo.EliminarElemento(instalacionAEliminar);
                    treeViewPlantaDeProduccion.Nodes.Remove(treeViewPlantaDeProduccion.SelectedNode);
                    RecargarTableroDeControl();
                }
            }
            else
            {
                MessageBox.Show("Es necesario utilizar la función de \"Eliminar\" al elemento que corresponda para la selección realizada",
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
                    modelo.EliminarElemento(dispositivoAEliminar);
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
            VerificarElementoSCADASeleccionado(AbrirRegistrarIncidente);
        }

        private void AbrirRegistrarIncidente()
        {
            ElementoSCADA elementoSeleccionado = treeViewPlantaDeProduccion.SelectedNode.Tag as ElementoSCADA;
            panelSistema.Controls.Clear();
            panelSistema.Controls.Add(new RegistrarIncidente(modelo, panelSistema, elementoSeleccionado));
        }

        private void btnVerIncidentes_Click(object sender, EventArgs e)
        {
            VerificarElementoSCADASeleccionado(AbrirPanelVerIncidentes);
        }

        private void VerificarElementoSCADASeleccionado(Action unaAccionARealizar)
        {
            TreeNode elementoSeleccionado = treeViewPlantaDeProduccion.SelectedNode;
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
            ElementoSCADA elementoSeleccionado = treeViewPlantaDeProduccion.SelectedNode.Tag as ElementoSCADA;
            DialogResult resultado = MessageBox.Show("¿Desea vizualizar los incidentes de manera recursiva?",
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
            TreeNode seleccionado = treeViewPlantaDeProduccion.SelectedNode;
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
            if (Auxiliar.NoEsNulo(treeViewPlantaDeProduccion.SelectedNode))
            {
                PlantaIndustrial plantaSeleccionada = treeViewPlantaDeProduccion.SelectedNode.Tag as PlantaIndustrial;
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
            PlantaIndustrial plantaIndustrialAEliminar = treeViewPlantaDeProduccion.SelectedNode.Tag as PlantaIndustrial;
            if (Auxiliar.NoEsNulo(plantaIndustrialAEliminar))
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea continuar con la operación?"
                        + " La eliminación es irreversible", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    modelo.EliminarElemento(plantaIndustrialAEliminar);
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
    }
}
