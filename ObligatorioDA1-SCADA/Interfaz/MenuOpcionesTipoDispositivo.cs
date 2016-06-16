using System;
using System.Drawing;
using System.Windows.Forms;
using Dominio;
using Persistencia;
using Excepciones;

namespace Interfaz
{
    public partial class MenuOpcionesTipoDispositivo : UserControl
    {
        private IAccesoADatos modelo;
        private Panel panelSistema;
        public MenuOpcionesTipoDispositivo(IAccesoADatos modelo, Panel panelSistema)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.panelSistema = panelSistema;
            RecargarListaTipos();
        }

        private void RecargarListaTipos()
        {
            lstTiposDispositivos.Rows.Clear();
            foreach (Tipo tipo in modelo.Tipos)
            {
                lstTiposDispositivos.Rows.Add(tipo, tipo.Descripcion);
            }
        }

        private void btnVolverMenuPrincipal_Click(object sender, EventArgs e)
        {
            AuxiliarInterfaz.VolverAPrincipal(modelo, panelSistema);
        }

        private void btnEliminarTipoDispositivo_Click(object sender, EventArgs e)
        {
            Tipo tipoAEliminar = lstTiposDispositivos.SelectedRows[0].Cells[0].Value as Tipo;
            if (Auxiliar.NoEsNulo(tipoAEliminar))
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea continuar con la operación?"
                    + " La eliminación es irreversible", "Confirmación", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {

                        modelo.EliminarTipo(tipoAEliminar);
                        MessageBox.Show("El tipo de dispositivo fue eliminado correctamente", "Éxito");
                    }
                    catch (AccesoADatosExcepcion)
                    {
                        MessageBox.Show("El tipo se encuentra asignado a un Dispositivo.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    RecargarListaTipos();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de dispositivo para acceder a esta funcionalidad");
            }
        }

        private void lstTiposDispositivos_SelectionChanged(object sender, EventArgs e)
        {
            if (Auxiliar.EsListaVacia(lstTiposDispositivos.SelectedRows))
            {
                btnEliminarTipoDispositivo.Enabled = false;
                btnEliminarTipoDispositivo.BackColor = Color.LightPink;
                btnEditarTipoDispositivo.Enabled = false;
                btnEditarTipoDispositivo.BackColor = Color.LightCyan;
            }
            else
            {
                btnEliminarTipoDispositivo.Enabled = true;
                btnEliminarTipoDispositivo.BackColor = Color.Red;
                btnEditarTipoDispositivo.Enabled = true;
                btnEditarTipoDispositivo.BackColor = Color.PaleTurquoise;
            }
        }

        private void btnEditarTipoDispositivo_Click(object sender, EventArgs e)
        {
            Tipo tipoAModificar = lstTiposDispositivos.SelectedRows[0].Cells[0].Value as Tipo;
            if (Auxiliar.NoEsNulo(tipoAModificar))
            {
                panelSistema.Controls.Clear();
                panelSistema.Controls.Add(new RegistrarTipoDispositivo(modelo, panelSistema, tipoAModificar));
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de dispositivo para acceder a esta funcionalidad");
            }
        }
    }
}
