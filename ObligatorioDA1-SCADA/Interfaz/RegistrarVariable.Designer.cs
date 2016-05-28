namespace Interfaz
{
    partial class RegistrarVariable
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
            this.lblValorMin = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblErrorNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombreInstalacion = new System.Windows.Forms.Label();
            this.lblMenuVariable = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.lblErrorValores = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            this.SuspendLayout();
            // 
            // lblValorMin
            // 
            this.lblValorMin.AutoSize = true;
            this.lblValorMin.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorMin.Location = new System.Drawing.Point(47, 216);
            this.lblValorMin.Name = "lblValorMin";
            this.lblValorMin.Size = new System.Drawing.Size(104, 21);
            this.lblValorMin.TabIndex = 32;
            this.lblValorMin.Text = "Valor Mínimo";
            this.lblValorMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(832, 475);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 46);
            this.btnCancelar.TabIndex = 31;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(730, 475);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(96, 46);
            this.btnAceptar.TabIndex = 30;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblErrorNombre
            // 
            this.lblErrorNombre.AutoSize = true;
            this.lblErrorNombre.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNombre.Location = new System.Drawing.Point(520, 142);
            this.lblErrorNombre.Name = "lblErrorNombre";
            this.lblErrorNombre.Size = new System.Drawing.Size(125, 21);
            this.lblErrorNombre.TabIndex = 29;
            this.lblErrorNombre.Text = "Nombre inválido";
            this.lblErrorNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(179, 139);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(319, 26);
            this.txtNombre.TabIndex = 28;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // lblNombreInstalacion
            // 
            this.lblNombreInstalacion.AutoSize = true;
            this.lblNombreInstalacion.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreInstalacion.Location = new System.Drawing.Point(47, 142);
            this.lblNombreInstalacion.Name = "lblNombreInstalacion";
            this.lblNombreInstalacion.Size = new System.Drawing.Size(66, 21);
            this.lblNombreInstalacion.TabIndex = 27;
            this.lblNombreInstalacion.Text = "Nombre";
            this.lblNombreInstalacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMenuVariable
            // 
            this.lblMenuVariable.AutoSize = true;
            this.lblMenuVariable.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuVariable.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMenuVariable.Location = new System.Drawing.Point(372, 12);
            this.lblMenuVariable.Name = "lblMenuVariable";
            this.lblMenuVariable.Size = new System.Drawing.Size(219, 34);
            this.lblMenuVariable.TabIndex = 26;
            this.lblMenuVariable.Text = "Registrar Variable";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 21);
            this.label2.TabIndex = 35;
            this.label2.Text = "Valor Máximo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numMin
            // 
            this.numMin.DecimalPlaces = 3;
            this.numMin.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMin.Location = new System.Drawing.Point(179, 214);
            this.numMin.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.numMin.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(120, 26);
            this.numMin.TabIndex = 38;
            this.numMin.Leave += new System.EventHandler(this.rangoValores_Leave);
            // 
            // numMax
            // 
            this.numMax.DecimalPlaces = 3;
            this.numMax.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMax.Location = new System.Drawing.Point(179, 288);
            this.numMax.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.numMax.Minimum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            -2147483648});
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(120, 26);
            this.numMax.TabIndex = 39;
            this.numMax.Leave += new System.EventHandler(this.rangoValores_Leave);
            // 
            // lblErrorValores
            // 
            this.lblErrorValores.AutoSize = true;
            this.lblErrorValores.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorValores.ForeColor = System.Drawing.Color.Red;
            this.lblErrorValores.Location = new System.Drawing.Point(346, 255);
            this.lblErrorValores.Name = "lblErrorValores";
            this.lblErrorValores.Size = new System.Drawing.Size(382, 21);
            this.lblErrorValores.TabIndex = 40;
            this.lblErrorValores.Text = "El valor mínimo debe ser menor que el valor máximo";
            this.lblErrorValores.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegistrarVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblErrorValores);
            this.Controls.Add(this.numMax);
            this.Controls.Add(this.numMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblValorMin);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblErrorNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombreInstalacion);
            this.Controls.Add(this.lblMenuVariable);
            this.Name = "RegistrarVariable";
            this.Size = new System.Drawing.Size(972, 571);
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblValorMin;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblErrorNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombreInstalacion;
        private System.Windows.Forms.Label lblMenuVariable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.Label lblErrorValores;
    }
}
