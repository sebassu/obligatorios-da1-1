namespace Interfaz
{
    partial class MenuOpcionesTipoDispositivo
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblMenuOpcionesTipoDispositivo = new System.Windows.Forms.Label();
            this.btnEditarTipoDispositivo = new System.Windows.Forms.Button();
            this.btnEliminarTipoDispositivo = new System.Windows.Forms.Button();
            this.btnVolverMenuPrincipal = new System.Windows.Forms.Button();
            this.lstTiposDispositivos = new System.Windows.Forms.DataGridView();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lstTiposDispositivos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMenuOpcionesTipoDispositivo
            // 
            this.lblMenuOpcionesTipoDispositivo.AutoSize = true;
            this.lblMenuOpcionesTipoDispositivo.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuOpcionesTipoDispositivo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMenuOpcionesTipoDispositivo.Location = new System.Drawing.Point(356, 9);
            this.lblMenuOpcionesTipoDispositivo.Name = "lblMenuOpcionesTipoDispositivo";
            this.lblMenuOpcionesTipoDispositivo.Size = new System.Drawing.Size(251, 34);
            this.lblMenuOpcionesTipoDispositivo.TabIndex = 3;
            this.lblMenuOpcionesTipoDispositivo.Text = "Tipos de Dispositivos";
            // 
            // btnEditarTipoDispositivo
            // 
            this.btnEditarTipoDispositivo.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnEditarTipoDispositivo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarTipoDispositivo.Location = new System.Drawing.Point(888, 61);
            this.btnEditarTipoDispositivo.Name = "btnEditarTipoDispositivo";
            this.btnEditarTipoDispositivo.Size = new System.Drawing.Size(40, 44);
            this.btnEditarTipoDispositivo.TabIndex = 24;
            this.btnEditarTipoDispositivo.Text = "I";
            this.btnEditarTipoDispositivo.UseVisualStyleBackColor = false;
            this.btnEditarTipoDispositivo.Click += new System.EventHandler(this.btnEditarTipoDispositivo_Click);
            // 
            // btnEliminarTipoDispositivo
            // 
            this.btnEliminarTipoDispositivo.BackColor = System.Drawing.Color.Red;
            this.btnEliminarTipoDispositivo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarTipoDispositivo.Location = new System.Drawing.Point(831, 61);
            this.btnEliminarTipoDispositivo.Name = "btnEliminarTipoDispositivo";
            this.btnEliminarTipoDispositivo.Size = new System.Drawing.Size(40, 44);
            this.btnEliminarTipoDispositivo.TabIndex = 23;
            this.btnEliminarTipoDispositivo.Text = "-";
            this.btnEliminarTipoDispositivo.UseVisualStyleBackColor = false;
            this.btnEliminarTipoDispositivo.Click += new System.EventHandler(this.btnEliminarTipoDispositivo_Click);
            // 
            // btnVolverMenuPrincipal
            // 
            this.btnVolverMenuPrincipal.Location = new System.Drawing.Point(831, 475);
            this.btnVolverMenuPrincipal.Name = "btnVolverMenuPrincipal";
            this.btnVolverMenuPrincipal.Size = new System.Drawing.Size(96, 46);
            this.btnVolverMenuPrincipal.TabIndex = 35;
            this.btnVolverMenuPrincipal.Text = "Volver al menú principal";
            this.btnVolverMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnVolverMenuPrincipal.Click += new System.EventHandler(this.btnVolverMenuPrincipal_Click);
            // 
            // lstTiposDispositivos
            // 
            this.lstTiposDispositivos.AllowUserToAddRows = false;
            this.lstTiposDispositivos.AllowUserToDeleteRows = false;
            this.lstTiposDispositivos.AllowUserToResizeColumns = false;
            this.lstTiposDispositivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.lstTiposDispositivos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.lstTiposDispositivos.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lstTiposDispositivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.lstTiposDispositivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstTiposDispositivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombre,
            this.colDescripcion});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lstTiposDispositivos.DefaultCellStyle = dataGridViewCellStyle4;
            this.lstTiposDispositivos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.lstTiposDispositivos.Location = new System.Drawing.Point(172, 61);
            this.lstTiposDispositivos.MultiSelect = false;
            this.lstTiposDispositivos.Name = "lstTiposDispositivos";
            this.lstTiposDispositivos.ReadOnly = true;
            this.lstTiposDispositivos.RowHeadersWidth = 40;
            this.lstTiposDispositivos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.lstTiposDispositivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lstTiposDispositivos.Size = new System.Drawing.Size(617, 394);
            this.lstTiposDispositivos.TabIndex = 37;
            this.lstTiposDispositivos.SelectionChanged += new System.EventHandler(this.lstTiposDispositivos_SelectionChanged);
            // 
            // colNombre
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNombre.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNombre.FillWeight = 50.87117F;
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.MinimumWidth = 146;
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 146;
            // 
            // colDescripcion
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescripcion.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDescripcion.FillWeight = 149.1292F;
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.MinimumWidth = 429;
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 429;
            // 
            // MenuOpcionesTipoDispositivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstTiposDispositivos);
            this.Controls.Add(this.btnVolverMenuPrincipal);
            this.Controls.Add(this.btnEditarTipoDispositivo);
            this.Controls.Add(this.btnEliminarTipoDispositivo);
            this.Controls.Add(this.lblMenuOpcionesTipoDispositivo);
            this.Name = "MenuOpcionesTipoDispositivo";
            this.Size = new System.Drawing.Size(972, 571);
            ((System.ComponentModel.ISupportInitialize)(this.lstTiposDispositivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMenuOpcionesTipoDispositivo;
        private System.Windows.Forms.Button btnEditarTipoDispositivo;
        private System.Windows.Forms.Button btnEliminarTipoDispositivo;
        private System.Windows.Forms.Button btnVolverMenuPrincipal;
        private System.Windows.Forms.DataGridView lstTiposDispositivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
    }
}
