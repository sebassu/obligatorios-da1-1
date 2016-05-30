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
            this.lstTiposDispositivos = new System.Windows.Forms.DataGridView();
            this.btnVolverMenuPrincipal = new System.Windows.Forms.Button();
            this.lblIncidentes = new System.Windows.Forms.Label();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNivelGravedad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lstTiposDispositivos)).BeginInit();
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
            this.colDescripcion,
            this.colFecha,
            this.colNivelGravedad});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lstTiposDispositivos.DefaultCellStyle = dataGridViewCellStyle5;
            this.lstTiposDispositivos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.lstTiposDispositivos.Location = new System.Drawing.Point(90, 57);
            this.lstTiposDispositivos.MultiSelect = false;
            this.lstTiposDispositivos.Name = "lstTiposDispositivos";
            this.lstTiposDispositivos.ReadOnly = true;
            this.lstTiposDispositivos.RowHeadersWidth = 40;
            this.lstTiposDispositivos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.lstTiposDispositivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lstTiposDispositivos.Size = new System.Drawing.Size(768, 394);
            this.lstTiposDispositivos.TabIndex = 40;
            // 
            // btnVolverMenuPrincipal
            // 
            this.btnVolverMenuPrincipal.Location = new System.Drawing.Point(831, 475);
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
            // colDescripcion
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescripcion.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDescripcion.FillWeight = 149.1292F;
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.MinimumWidth = 429;
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 429;
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
            // VerIncidentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstTiposDispositivos);
            this.Controls.Add(this.btnVolverMenuPrincipal);
            this.Controls.Add(this.lblIncidentes);
            this.Name = "VerIncidentes";
            this.Size = new System.Drawing.Size(972, 571);
            ((System.ComponentModel.ISupportInitialize)(this.lstTiposDispositivos)).EndInit();
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
    }
}
