namespace Interfaz
{
    partial class RegistrarInstalacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarInstalacion));
            this.lblMenuInstalacion = new System.Windows.Forms.Label();
            this.lblErrorNombre = new System.Windows.Forms.Label();
            this.txtNombreInstalacion = new System.Windows.Forms.TextBox();
            this.lblNombreInstalacion = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMenuInstalacion
            // 
            this.lblMenuInstalacion.AutoSize = true;
            this.lblMenuInstalacion.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuInstalacion.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMenuInstalacion.Location = new System.Drawing.Point(358, 14);
            this.lblMenuInstalacion.Name = "lblMenuInstalacion";
            this.lblMenuInstalacion.Size = new System.Drawing.Size(251, 34);
            this.lblMenuInstalacion.TabIndex = 4;
            this.lblMenuInstalacion.Text = "Registrar Instalación";
            // 
            // lblErrorNombre
            // 
            this.lblErrorNombre.AutoSize = true;
            this.lblErrorNombre.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNombre.Location = new System.Drawing.Point(500, 143);
            this.lblErrorNombre.Name = "lblErrorNombre";
            this.lblErrorNombre.Size = new System.Drawing.Size(131, 23);
            this.lblErrorNombre.TabIndex = 13;
            this.lblErrorNombre.Text = "Nombre inválido";
            this.lblErrorNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombreInstalacion
            // 
            this.txtNombreInstalacion.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreInstalacion.Location = new System.Drawing.Point(156, 140);
            this.txtNombreInstalacion.Name = "txtNombreInstalacion";
            this.txtNombreInstalacion.Size = new System.Drawing.Size(319, 30);
            this.txtNombreInstalacion.TabIndex = 12;
            this.txtNombreInstalacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreInstalacion_KeyPress);
            // 
            // lblNombreInstalacion
            // 
            this.lblNombreInstalacion.AutoSize = true;
            this.lblNombreInstalacion.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreInstalacion.Location = new System.Drawing.Point(47, 143);
            this.lblNombreInstalacion.Name = "lblNombreInstalacion";
            this.lblNombreInstalacion.Size = new System.Drawing.Size(70, 23);
            this.lblNombreInstalacion.TabIndex = 11;
            this.lblNombreInstalacion.Text = "Nombre";
            this.lblNombreInstalacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(832, 476);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 46);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(730, 476);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(96, 46);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(198, 237);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(338, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // RegistrarInstalacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblErrorNombre);
            this.Controls.Add(this.txtNombreInstalacion);
            this.Controls.Add(this.lblNombreInstalacion);
            this.Controls.Add(this.lblMenuInstalacion);
            this.Name = "RegistrarInstalacion";
            this.Size = new System.Drawing.Size(972, 571);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMenuInstalacion;
        private System.Windows.Forms.Label lblErrorNombre;
        private System.Windows.Forms.TextBox txtNombreInstalacion;
        private System.Windows.Forms.Label lblNombreInstalacion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
