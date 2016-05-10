namespace Interfaz
{
    partial class VariableValorHistorico
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
            this.btnVolverMenuPrincipal = new System.Windows.Forms.Button();
            this.lblValorHistorico = new System.Windows.Forms.Label();
            this.valoresHistoricos = new System.Windows.Forms.DataGridView();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.valoresHistoricos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolverMenuPrincipal
            // 
            this.btnVolverMenuPrincipal.Location = new System.Drawing.Point(832, 475);
            this.btnVolverMenuPrincipal.Name = "btnVolverMenuPrincipal";
            this.btnVolverMenuPrincipal.Size = new System.Drawing.Size(96, 46);
            this.btnVolverMenuPrincipal.TabIndex = 34;
            this.btnVolverMenuPrincipal.Text = "Volver al menú principal";
            this.btnVolverMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnVolverMenuPrincipal.Click += new System.EventHandler(this.btnVolverMenuPrincipal_Click);
            // 
            // lblValorHistorico
            // 
            this.lblValorHistorico.AutoSize = true;
            this.lblValorHistorico.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorHistorico.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblValorHistorico.Location = new System.Drawing.Point(372, 12);
            this.lblValorHistorico.Name = "lblValorHistorico";
            this.lblValorHistorico.Size = new System.Drawing.Size(180, 34);
            this.lblValorHistorico.TabIndex = 32;
            this.lblValorHistorico.Text = "Valor Histórico";
            // 
            // valoresHistoricos
            // 
            this.valoresHistoricos.AllowUserToAddRows = false;
            this.valoresHistoricos.AllowUserToDeleteRows = false;
            this.valoresHistoricos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.valoresHistoricos.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.valoresHistoricos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.valoresHistoricos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.valoresHistoricos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Valor,
            this.Fecha,
            this.Hora});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.valoresHistoricos.DefaultCellStyle = dataGridViewCellStyle5;
            this.valoresHistoricos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.valoresHistoricos.Location = new System.Drawing.Point(172, 61);
            this.valoresHistoricos.Name = "valoresHistoricos";
            this.valoresHistoricos.Size = new System.Drawing.Size(617, 394);
            this.valoresHistoricos.TabIndex = 36;
            // 
            // Valor
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valor.DefaultCellStyle = dataGridViewCellStyle2;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // Fecha
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Hora
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hora.DefaultCellStyle = dataGridViewCellStyle4;
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            // 
            // VariableValorHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.valoresHistoricos);
            this.Controls.Add(this.btnVolverMenuPrincipal);
            this.Controls.Add(this.lblValorHistorico);
            this.Name = "VariableValorHistorico";
            this.Size = new System.Drawing.Size(972, 571);
            ((System.ComponentModel.ISupportInitialize)(this.valoresHistoricos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolverMenuPrincipal;
        private System.Windows.Forms.Label lblValorHistorico;
        private System.Windows.Forms.DataGridView valoresHistoricos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
    }
}
