namespace Interfaz
{
    partial class VerIncidentes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lstTiposDispositivos = new System.Windows.Forms.DataGridView();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNivelGravedad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVolverMenuPrincipal = new System.Windows.Forms.Button();
            this.lblIncidentes = new System.Windows.Forms.Label();
            this.fechaDesde = new System.Windows.Forms.DateTimePicker();
            this.fechaHasta = new System.Windows.Forms.DateTimePicker();
            this.nivelDeGravedad = new System.Windows.Forms.NumericUpDown();
            this.btnAplicarFiltros = new System.Windows.Forms.Button();
            this.lblFiltrado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNivelGravedad = new System.Windows.Forms.Label();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lstTiposDispositivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nivelDeGravedad)).BeginInit();
            this.SuspendLayout();
            // 
            // lstTiposDispositivos
            // 
            this.lstTiposDispositivos.AllowUserToAddRows = false;
            this.lstTiposDispositivos.AllowUserToDeleteRows = false;
            this.lstTiposDispositivos.AllowUserToResizeColumns = false;
            this.lstTiposDispositivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.lstTiposDispositivos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.lstTiposDispositivos.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lstTiposDispositivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.lstTiposDispositivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstTiposDispositivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescripcion,
            this.colFecha,
            this.colNivelGravedad});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lstTiposDispositivos.DefaultCellStyle = dataGridViewCellStyle10;
            this.lstTiposDispositivos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.lstTiposDispositivos.Location = new System.Drawing.Point(90, 169);
            this.lstTiposDispositivos.MultiSelect = false;
            this.lstTiposDispositivos.Name = "lstTiposDispositivos";
            this.lstTiposDispositivos.ReadOnly = true;
            this.lstTiposDispositivos.RowHeadersWidth = 40;
            this.lstTiposDispositivos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.lstTiposDispositivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lstTiposDispositivos.Size = new System.Drawing.Size(768, 311);
            this.lstTiposDispositivos.TabIndex = 40;
            // 
            // colDescripcion
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescripcion.DefaultCellStyle = dataGridViewCellStyle7;
            this.colDescripcion.FillWeight = 149.1292F;
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.MinimumWidth = 429;
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 429;
            // 
            // colFecha
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colFecha.DefaultCellStyle = dataGridViewCellStyle8;
            this.colFecha.FillWeight = 50.87117F;
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.MinimumWidth = 146;
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 146;
            // 
            // colNivelGravedad
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNivelGravedad.DefaultCellStyle = dataGridViewCellStyle9;
            this.colNivelGravedad.HeaderText = "Nivel de gravedad";
            this.colNivelGravedad.Name = "colNivelGravedad";
            this.colNivelGravedad.ReadOnly = true;
            this.colNivelGravedad.Width = 151;
            // 
            // btnVolverMenuPrincipal
            // 
            this.btnVolverMenuPrincipal.Location = new System.Drawing.Point(831, 493);
            this.btnVolverMenuPrincipal.Name = "btnVolverMenuPrincipal";
            this.btnVolverMenuPrincipal.Size = new System.Drawing.Size(96, 46);
            this.btnVolverMenuPrincipal.TabIndex = 39;
            this.btnVolverMenuPrincipal.Text = "Volver al menú principal";
            this.btnVolverMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnVolverMenuPrincipal.Click += new System.EventHandler(this.btnVolverMenuPrincipal_Click);
            // 
            // lblIncidentes
            // 
            this.lblIncidentes.AutoSize = true;
            this.lblIncidentes.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncidentes.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblIncidentes.Location = new System.Drawing.Point(423, 9);
            this.lblIncidentes.Name = "lblIncidentes";
            this.lblIncidentes.Size = new System.Drawing.Size(134, 34);
            this.lblIncidentes.TabIndex = 38;
            this.lblIncidentes.Text = "Incidentes";
            // 
            // fechaDesde
            // 
            this.fechaDesde.Font = new System.Drawing.Font("Franklin Gothic Book", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaDesde.Location = new System.Drawing.Point(300, 95);
            this.fechaDesde.Name = "fechaDesde";
            this.fechaDesde.Size = new System.Drawing.Size(218, 21);
            this.fechaDesde.TabIndex = 41;
            // 
            // fechaHasta
            // 
            this.fechaHasta.Font = new System.Drawing.Font("Franklin Gothic Book", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaHasta.Location = new System.Drawing.Point(581, 95);
            this.fechaHasta.Name = "fechaHasta";
            this.fechaHasta.Size = new System.Drawing.Size(218, 21);
            this.fechaHasta.TabIndex = 42;
            // 
            // nivelDeGravedad
            // 
            this.nivelDeGravedad.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nivelDeGravedad.Location = new System.Drawing.Point(243, 129);
            this.nivelDeGravedad.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nivelDeGravedad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nivelDeGravedad.Name = "nivelDeGravedad";
            this.nivelDeGravedad.Size = new System.Drawing.Size(56, 26);
            this.nivelDeGravedad.TabIndex = 43;
            this.nivelDeGravedad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAplicarFiltros
            // 
            this.btnAplicarFiltros.Location = new System.Drawing.Point(831, 105);
            this.btnAplicarFiltros.Name = "btnAplicarFiltros";
            this.btnAplicarFiltros.Size = new System.Drawing.Size(75, 38);
            this.btnAplicarFiltros.TabIndex = 44;
            this.btnAplicarFiltros.Text = "Aplicar Filtros";
            this.btnAplicarFiltros.UseVisualStyleBackColor = true;
            this.btnAplicarFiltros.Click += new System.EventHandler(this.btnAplicarFiltros_Click);
            // 
            // lblFiltrado
            // 
            this.lblFiltrado.AutoSize = true;
            this.lblFiltrado.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltrado.Location = new System.Drawing.Point(90, 57);
            this.lblFiltrado.Name = "lblFiltrado";
            this.lblFiltrado.Size = new System.Drawing.Size(158, 21);
            this.lblFiltrado.TabIndex = 46;
            this.lblFiltrado.Text = "Opciones de Filtrado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 47;
            this.label1.Text = "Fecha:";
            // 
            // lblNivelGravedad
            // 
            this.lblNivelGravedad.AutoSize = true;
            this.lblNivelGravedad.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivelGravedad.Location = new System.Drawing.Point(90, 131);
            this.lblNivelGravedad.Name = "lblNivelGravedad";
            this.lblNivelGravedad.Size = new System.Drawing.Size(142, 21);
            this.lblNivelGravedad.TabIndex = 48;
            this.lblNivelGravedad.Text = "Nivel de Gravedad:";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(239, 95);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(55, 21);
            this.lblFechaDesde.TabIndex = 49;
            this.lblFechaDesde.Text = "Desde";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(523, 95);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(52, 21);
            this.lblFechaHasta.TabIndex = 50;
            this.lblFechaHasta.Text = "Hasta";
            // 
            // VerIncidentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFechaHasta);
            this.Controls.Add(this.lblFechaDesde);
            this.Controls.Add(this.lblNivelGravedad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFiltrado);
            this.Controls.Add(this.btnAplicarFiltros);
            this.Controls.Add(this.nivelDeGravedad);
            this.Controls.Add(this.fechaHasta);
            this.Controls.Add(this.fechaDesde);
            this.Controls.Add(this.lstTiposDispositivos);
            this.Controls.Add(this.btnVolverMenuPrincipal);
            this.Controls.Add(this.lblIncidentes);
            this.Name = "VerIncidentes";
            this.Size = new System.Drawing.Size(972, 571);
            ((System.ComponentModel.ISupportInitialize)(this.lstTiposDispositivos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nivelDeGravedad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView lstTiposDispositivos;
        private System.Windows.Forms.Button btnVolverMenuPrincipal;
        private System.Windows.Forms.Label lblIncidentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNivelGravedad;
        private System.Windows.Forms.DateTimePicker fechaDesde;
        private System.Windows.Forms.DateTimePicker fechaHasta;
        private System.Windows.Forms.NumericUpDown nivelDeGravedad;
        private System.Windows.Forms.Button btnAplicarFiltros;
        private System.Windows.Forms.Label lblFiltrado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNivelGravedad;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
    }
}
