namespace Interfaz
{
    partial class RegistrarIncidente
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
            this.lblErrorDescripcion = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblMenuIncidente = new System.Windows.Forms.Label();
            this.txtNombreInstalacion = new System.Windows.Forms.TextBox();
            this.lblNivelGravedad = new System.Windows.Forms.Label();
            this.numValor = new System.Windows.Forms.NumericUpDown();
            this.lblFecha = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.numValor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(832, 476);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 46);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(730, 476);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(96, 46);
            this.btnAceptar.TabIndex = 20;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // lblErrorDescripcion
            // 
            this.lblErrorDescripcion.AutoSize = true;
            this.lblErrorDescripcion.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorDescripcion.ForeColor = System.Drawing.Color.Red;
            this.lblErrorDescripcion.Location = new System.Drawing.Point(561, 143);
            this.lblErrorDescripcion.Name = "lblErrorDescripcion";
            this.lblErrorDescripcion.Size = new System.Drawing.Size(153, 21);
            this.lblErrorDescripcion.TabIndex = 19;
            this.lblErrorDescripcion.Text = "Descripción inválida";
            this.lblErrorDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(47, 143);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(94, 21);
            this.lblDescripcion.TabIndex = 17;
            this.lblDescripcion.Text = "Descripción";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMenuIncidente
            // 
            this.lblMenuIncidente.AutoSize = true;
            this.lblMenuIncidente.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuIncidente.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMenuIncidente.Location = new System.Drawing.Point(359, 14);
            this.lblMenuIncidente.Name = "lblMenuIncidente";
            this.lblMenuIncidente.Size = new System.Drawing.Size(231, 34);
            this.lblMenuIncidente.TabIndex = 16;
            this.lblMenuIncidente.Text = "Registrar Incidente";
            // 
            // txtNombreInstalacion
            // 
            this.txtNombreInstalacion.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreInstalacion.Location = new System.Drawing.Point(217, 140);
            this.txtNombreInstalacion.Multiline = true;
            this.txtNombreInstalacion.Name = "txtNombreInstalacion";
            this.txtNombreInstalacion.Size = new System.Drawing.Size(319, 99);
            this.txtNombreInstalacion.TabIndex = 18;
            // 
            // lblNivelGravedad
            // 
            this.lblNivelGravedad.AutoSize = true;
            this.lblNivelGravedad.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivelGravedad.Location = new System.Drawing.Point(47, 266);
            this.lblNivelGravedad.Name = "lblNivelGravedad";
            this.lblNivelGravedad.Size = new System.Drawing.Size(138, 21);
            this.lblNivelGravedad.TabIndex = 22;
            this.lblNivelGravedad.Text = "Nivel de Gravedad";
            this.lblNivelGravedad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numValor
            // 
            this.numValor.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numValor.Location = new System.Drawing.Point(217, 264);
            this.numValor.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numValor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numValor.Name = "numValor";
            this.numValor.Size = new System.Drawing.Size(120, 26);
            this.numValor.TabIndex = 23;
            this.numValor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(47, 315);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(58, 21);
            this.lblFecha.TabIndex = 24;
            this.lblFecha.Text = "Fecha ";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar1.Location = new System.Drawing.Point(217, 315);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 25;
            // 
            // RegistrarIncidente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.numValor);
            this.Controls.Add(this.lblNivelGravedad);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblErrorDescripcion);
            this.Controls.Add(this.txtNombreInstalacion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblMenuIncidente);
            this.Name = "RegistrarIncidente";
            this.Size = new System.Drawing.Size(972, 571);
            ((System.ComponentModel.ISupportInitialize)(this.numValor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblErrorDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblMenuIncidente;
        private System.Windows.Forms.TextBox txtNombreInstalacion;
        private System.Windows.Forms.Label lblNivelGravedad;
        private System.Windows.Forms.NumericUpDown numValor;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}
