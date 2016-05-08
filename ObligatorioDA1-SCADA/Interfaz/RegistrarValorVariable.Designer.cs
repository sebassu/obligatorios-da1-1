namespace Interfaz
{
    partial class RegistrarValorVariable
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblMenuValorVariable = new System.Windows.Forms.Label();
            this.numValor = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numValor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(832, 475);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 46);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(730, 475);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(96, 46);
            this.btnAceptar.TabIndex = 18;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(60, 142);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(50, 23);
            this.lblValor.TabIndex = 15;
            this.lblValor.Text = "Valor";
            this.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMenuValorVariable
            // 
            this.lblMenuValorVariable.AutoSize = true;
            this.lblMenuValorVariable.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuValorVariable.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMenuValorVariable.Location = new System.Drawing.Point(326, 12);
            this.lblMenuValorVariable.Name = "lblMenuValorVariable";
            this.lblMenuValorVariable.Size = new System.Drawing.Size(316, 34);
            this.lblMenuValorVariable.TabIndex = 14;
            this.lblMenuValorVariable.Text = "Registrar Valor de Variable";
            // 
            // numValor
            // 
            this.numValor.DecimalPlaces = 3;
            this.numValor.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numValor.Location = new System.Drawing.Point(176, 140);
            this.numValor.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.numValor.Minimum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            -2147483648});
            this.numValor.Name = "numValor";
            this.numValor.Size = new System.Drawing.Size(120, 30);
            this.numValor.TabIndex = 20;
            // 
            // RegistrarValorVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numValor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblMenuValorVariable);
            this.Name = "RegistrarValorVariable";
            this.Size = new System.Drawing.Size(972, 571);
            ((System.ComponentModel.ISupportInitialize)(this.numValor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblMenuValorVariable;
        private System.Windows.Forms.NumericUpDown numValor;
    }
}
