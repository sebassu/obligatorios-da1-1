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
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblNivelGravedad = new System.Windows.Forms.Label();
            this.numValor = new System.Windows.Forms.NumericUpDown();
            this.lblFecha = new System.Windows.Forms.Label();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.lblErrorFecha = new System.Windows.Forms.Label();
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
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.lblErrorDescripcion.Location = new System.Drawing.Point(561, 117);
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
            this.lblDescripcion.Location = new System.Drawing.Point(47, 117);
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
            this.lblMenuIncidente.Location = new System.Drawing.Point(366, 14);
            this.lblMenuIncidente.Name = "lblMenuIncidente";
            this.lblMenuIncidente.Size = new System.Drawing.Size(231, 34);
            this.lblMenuIncidente.TabIndex = 16;
            this.lblMenuIncidente.Text = "Registrar Incidente";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(217, 114);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(319, 99);
            this.txtDescripcion.TabIndex = 18;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            this.txtDescripcion.Leave += new System.EventHandler(this.txtDescripcion_Leave);
            // 
            // lblNivelGravedad
            // 
            this.lblNivelGravedad.AutoSize = true;
            this.lblNivelGravedad.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivelGravedad.Location = new System.Drawing.Point(47, 240);
            this.lblNivelGravedad.Name = "lblNivelGravedad";
            this.lblNivelGravedad.Size = new System.Drawing.Size(138, 21);
            this.lblNivelGravedad.TabIndex = 22;
            this.lblNivelGravedad.Text = "Nivel de Gravedad";
            this.lblNivelGravedad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numValor
            // 
            this.numValor.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numValor.Location = new System.Drawing.Point(217, 238);
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
            this.lblFecha.Location = new System.Drawing.Point(47, 289);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(58, 21);
            this.lblFecha.TabIndex = 24;
            this.lblFecha.Text = "Fecha ";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // monthCalendar
            // 
            this.monthCalendar.Font = new System.Drawing.Font("Franklin Gothic Book", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar.Location = new System.Drawing.Point(217, 289);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 25;
            this.monthCalendar.Leave += new System.EventHandler(this.monthCalendar_Leave);
            // 
            // lblErrorFecha
            // 
            this.lblErrorFecha.AutoSize = true;
            this.lblErrorFecha.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorFecha.ForeColor = System.Drawing.Color.Red;
            this.lblErrorFecha.Location = new System.Drawing.Point(561, 289);
            this.lblErrorFecha.Name = "lblErrorFecha";
            this.lblErrorFecha.Size = new System.Drawing.Size(350, 21);
            this.lblErrorFecha.TabIndex = 26;
            this.lblErrorFecha.Text = "La fecha no puede ser mayor a la del día de hoy";
            this.lblErrorFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegistrarIncidente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblErrorFecha);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.numValor);
            this.Controls.Add(this.lblNivelGravedad);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblErrorDescripcion);
            this.Controls.Add(this.txtDescripcion);
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
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblNivelGravedad;
        private System.Windows.Forms.NumericUpDown numValor;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Label lblErrorFecha;
    }
}
