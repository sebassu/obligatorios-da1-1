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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblMenuOpcionesTipoDispositivo = new System.Windows.Forms.Label();
            this.btnEditarTipoDispositivo = new System.Windows.Forms.Button();
            this.btnEliminarTipoDispositivo = new System.Windows.Forms.Button();
            this.btnVolverMenuPrincipal = new System.Windows.Forms.Button();
            this.lstTiposDispositivos = new System.Windows.Forms.DataGridView();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lstTiposDispositivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lstTiposDispositivos.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lstTiposDispositivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.lstTiposDispositivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstTiposDispositivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Valor,
            this.Fecha});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lstTiposDispositivos.DefaultCellStyle = dataGridViewCellStyle8;
            this.lstTiposDispositivos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.lstTiposDispositivos.Location = new System.Drawing.Point(172, 61);
            this.lstTiposDispositivos.MultiSelect = false;
            this.lstTiposDispositivos.Name = "lstTiposDispositivos";
            this.lstTiposDispositivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lstTiposDispositivos.Size = new System.Drawing.Size(617, 394);
            this.lstTiposDispositivos.TabIndex = 37;
            this.lstTiposDispositivos.SelectionChanged += new System.EventHandler(this.lstTiposDispositivos_SelectionChanged);
            // 
            // Valor
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valor.DefaultCellStyle = dataGridViewCellStyle6;
            this.Valor.FillWeight = 50.76142F;
            this.Valor.HeaderText = "Nombre";
            this.Valor.Name = "Valor";
            // 
            // Fecha
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle7;
            this.Fecha.FillWeight = 149.2386F;
            this.Fecha.HeaderText = "Descripción";
            this.Fecha.Name = "Fecha";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
    }
}
