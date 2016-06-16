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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lstIncidentes = new System.Windows.Forms.DataGridView();
            this.btnVolverMenuPrincipal = new System.Windows.Forms.Button();
            this.lblIncidentes = new System.Windows.Forms.Label();
            this.lblFiltrado = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblNivelDeGravedad = new System.Windows.Forms.Label();
            this.numNivelGravedad = new System.Windows.Forms.NumericUpDown();
            this.dateTimeFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.dateTimeFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.btnAplicarFiltrado = new System.Windows.Forms.Button();
            this.lblErrorFiltrado = new System.Windows.Forms.Label();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNivelGravedad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementoPadre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lstIncidentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNivelGravedad)).BeginInit();
            this.SuspendLayout();
            // 
            // lstIncidentes
            // 
            this.lstIncidentes.AllowUserToAddRows = false;
            this.lstIncidentes.AllowUserToDeleteRows = false;
            this.lstIncidentes.AllowUserToResizeColumns = false;
            this.lstIncidentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.lstIncidentes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.lstIncidentes.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lstIncidentes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.lstIncidentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstIncidentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescripcion,
            this.colFecha,
            this.colNivelGravedad,
            this.ElementoPadre});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lstIncidentes.DefaultCellStyle = dataGridViewCellStyle5;
            this.lstIncidentes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.lstIncidentes.Location = new System.Drawing.Point(90, 147);
            this.lstIncidentes.MultiSelect = false;
            this.lstIncidentes.Name = "lstIncidentes";
            this.lstIncidentes.ReadOnly = true;
            this.lstIncidentes.RowHeadersWidth = 40;
            this.lstIncidentes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.lstIncidentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lstIncidentes.Size = new System.Drawing.Size(768, 345);
            this.lstIncidentes.TabIndex = 40;
            // 
            // btnVolverMenuPrincipal
            // 
            this.btnVolverMenuPrincipal.Location = new System.Drawing.Point(831, 509);
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
            // lblFiltrado
            // 
            this.lblFiltrado.AutoSize = true;
            this.lblFiltrado.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltrado.Location = new System.Drawing.Point(44, 43);
            this.lblFiltrado.Name = "lblFiltrado";
            this.lblFiltrado.Size = new System.Drawing.Size(66, 21);
            this.lblFiltrado.TabIndex = 41;
            this.lblFiltrado.Text = "Filtrado";
            this.lblFiltrado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(68, 76);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(58, 21);
            this.lblFecha.TabIndex = 42;
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNivelDeGravedad
            // 
            this.lblNivelDeGravedad.AutoSize = true;
            this.lblNivelDeGravedad.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivelDeGravedad.Location = new System.Drawing.Point(68, 113);
            this.lblNivelDeGravedad.Name = "lblNivelDeGravedad";
            this.lblNivelDeGravedad.Size = new System.Drawing.Size(142, 21);
            this.lblNivelDeGravedad.TabIndex = 43;
            this.lblNivelDeGravedad.Text = "Nivel de Gravedad:";
            this.lblNivelDeGravedad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numNivelGravedad
            // 
            this.numNivelGravedad.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNivelGravedad.Location = new System.Drawing.Point(227, 112);
            this.numNivelGravedad.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numNivelGravedad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNivelGravedad.Name = "numNivelGravedad";
            this.numNivelGravedad.Size = new System.Drawing.Size(48, 22);
            this.numNivelGravedad.TabIndex = 44;
            this.numNivelGravedad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dateTimeFechaDesde
            // 
            this.dateTimeFechaDesde.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeFechaDesde.Location = new System.Drawing.Point(261, 77);
            this.dateTimeFechaDesde.Name = "dateTimeFechaDesde";
            this.dateTimeFechaDesde.Size = new System.Drawing.Size(200, 20);
            this.dateTimeFechaDesde.TabIndex = 45;
            this.dateTimeFechaDesde.Leave += new System.EventHandler(this.dateTime_Leave);
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(152, 76);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(103, 21);
            this.lblFechaDesde.TabIndex = 46;
            this.lblFechaDesde.Text = "Fecha Desde";
            this.lblFechaDesde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(484, 76);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(100, 21);
            this.lblFechaHasta.TabIndex = 47;
            this.lblFechaHasta.Text = "Fecha Hasta";
            this.lblFechaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimeFechaHasta
            // 
            this.dateTimeFechaHasta.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeFechaHasta.Location = new System.Drawing.Point(590, 77);
            this.dateTimeFechaHasta.Name = "dateTimeFechaHasta";
            this.dateTimeFechaHasta.Size = new System.Drawing.Size(200, 20);
            this.dateTimeFechaHasta.TabIndex = 48;
            this.dateTimeFechaHasta.Leave += new System.EventHandler(this.dateTime_Leave);
            // 
            // btnAplicarFiltrado
            // 
            this.btnAplicarFiltrado.Location = new System.Drawing.Point(839, 88);
            this.btnAplicarFiltrado.Name = "btnAplicarFiltrado";
            this.btnAplicarFiltrado.Size = new System.Drawing.Size(86, 41);
            this.btnAplicarFiltrado.TabIndex = 49;
            this.btnAplicarFiltrado.Text = "Aplicar Filtrado";
            this.btnAplicarFiltrado.UseVisualStyleBackColor = true;
            this.btnAplicarFiltrado.Click += new System.EventHandler(this.btnAplicarFiltrado_Click);
            // 
            // lblErrorFiltrado
            // 
            this.lblErrorFiltrado.AutoSize = true;
            this.lblErrorFiltrado.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorFiltrado.ForeColor = System.Drawing.Color.Red;
            this.lblErrorFiltrado.Location = new System.Drawing.Point(574, 43);
            this.lblErrorFiltrado.Name = "lblErrorFiltrado";
            this.lblErrorFiltrado.Size = new System.Drawing.Size(377, 21);
            this.lblErrorFiltrado.TabIndex = 50;
            this.lblErrorFiltrado.Text = "La fecha \"desde\" debe ser mayor a la fecha \"hasta\"";
            this.lblErrorFiltrado.Visible = false;
            // 
            // colDescripcion
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescripcion.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDescripcion.FillWeight = 149.1292F;
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.MinimumWidth = 325;
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 325;
            // 
            // colFecha
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colFecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFecha.FillWeight = 50.87117F;
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.MinimumWidth = 146;
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 146;
            // 
            // colNivelGravedad
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNivelGravedad.DefaultCellStyle = dataGridViewCellStyle4;
            this.colNivelGravedad.HeaderText = "Nivel de gravedad";
            this.colNivelGravedad.Name = "colNivelGravedad";
            this.colNivelGravedad.ReadOnly = true;
            this.colNivelGravedad.Width = 151;
            // 
            // ElementoPadre
            // 
            this.ElementoPadre.HeaderText = "Elemento";
            this.ElementoPadre.Name = "ElementoPadre";
            this.ElementoPadre.ReadOnly = true;
            this.ElementoPadre.Width = 104;
            // 
            // VerIncidentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblErrorFiltrado);
            this.Controls.Add(this.btnAplicarFiltrado);
            this.Controls.Add(this.dateTimeFechaHasta);
            this.Controls.Add(this.lblFechaHasta);
            this.Controls.Add(this.lblFechaDesde);
            this.Controls.Add(this.dateTimeFechaDesde);
            this.Controls.Add(this.numNivelGravedad);
            this.Controls.Add(this.lblNivelDeGravedad);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblFiltrado);
            this.Controls.Add(this.lstIncidentes);
            this.Controls.Add(this.btnVolverMenuPrincipal);
            this.Controls.Add(this.lblIncidentes);
            this.Name = "VerIncidentes";
            this.Size = new System.Drawing.Size(972, 571);
            ((System.ComponentModel.ISupportInitialize)(this.lstIncidentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNivelGravedad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView lstIncidentes;
        private System.Windows.Forms.Button btnVolverMenuPrincipal;
        private System.Windows.Forms.Label lblIncidentes;
        private System.Windows.Forms.Label lblFiltrado;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblNivelDeGravedad;
        private System.Windows.Forms.NumericUpDown numNivelGravedad;
        private System.Windows.Forms.DateTimePicker dateTimeFechaDesde;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dateTimeFechaHasta;
        private System.Windows.Forms.Button btnAplicarFiltrado;
        private System.Windows.Forms.Label lblErrorFiltrado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNivelGravedad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementoPadre;
    }
}
