namespace Interfaz
{
    partial class RegistrarDispositivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarDispositivo));
            this.lblMenuDispositivo = new System.Windows.Forms.Label();
            this.lblNombreDispositivo = new System.Windows.Forms.Label();
            this.lblTipoDispositivo = new System.Windows.Forms.Label();
            this.txtNombreDispositivo = new System.Windows.Forms.TextBox();
            this.lblEnUso = new System.Windows.Forms.Label();
            this.cbxTipoDispositivo = new System.Windows.Forms.ComboBox();
            this.lblErrorNombre = new System.Windows.Forms.Label();
            this.chkEnUso = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblErrorTipo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMenuDispositivo
            // 
            this.lblMenuDispositivo.AutoSize = true;
            this.lblMenuDispositivo.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuDispositivo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMenuDispositivo.Location = new System.Drawing.Point(358, 13);
            this.lblMenuDispositivo.Name = "lblMenuDispositivo";
            this.lblMenuDispositivo.Size = new System.Drawing.Size(250, 34);
            this.lblMenuDispositivo.TabIndex = 3;
            this.lblMenuDispositivo.Text = "Registrar Dispositivo";
            // 
            // lblNombreDispositivo
            // 
            this.lblNombreDispositivo.AutoSize = true;
            this.lblNombreDispositivo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreDispositivo.Location = new System.Drawing.Point(46, 143);
            this.lblNombreDispositivo.Name = "lblNombreDispositivo";
            this.lblNombreDispositivo.Size = new System.Drawing.Size(70, 23);
            this.lblNombreDispositivo.TabIndex = 5;
            this.lblNombreDispositivo.Text = "Nombre";
            this.lblNombreDispositivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTipoDispositivo
            // 
            this.lblTipoDispositivo.AutoSize = true;
            this.lblTipoDispositivo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDispositivo.Location = new System.Drawing.Point(46, 209);
            this.lblTipoDispositivo.Name = "lblTipoDispositivo";
            this.lblTipoDispositivo.Size = new System.Drawing.Size(42, 23);
            this.lblTipoDispositivo.TabIndex = 6;
            this.lblTipoDispositivo.Text = "Tipo";
            this.lblTipoDispositivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombreDispositivo
            // 
            this.txtNombreDispositivo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreDispositivo.Location = new System.Drawing.Point(155, 140);
            this.txtNombreDispositivo.Name = "txtNombreDispositivo";
            this.txtNombreDispositivo.Size = new System.Drawing.Size(319, 30);
            this.txtNombreDispositivo.TabIndex = 7;
            this.txtNombreDispositivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreDispositivo_KeyPress);
            // 
            // lblEnUso
            // 
            this.lblEnUso.AutoSize = true;
            this.lblEnUso.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnUso.Location = new System.Drawing.Point(46, 278);
            this.lblEnUso.Name = "lblEnUso";
            this.lblEnUso.Size = new System.Drawing.Size(59, 23);
            this.lblEnUso.TabIndex = 8;
            this.lblEnUso.Text = "En uso";
            this.lblEnUso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxTipoDispositivo
            // 
            this.cbxTipoDispositivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoDispositivo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipoDispositivo.FormattingEnabled = true;
            this.cbxTipoDispositivo.Location = new System.Drawing.Point(155, 209);
            this.cbxTipoDispositivo.Name = "cbxTipoDispositivo";
            this.cbxTipoDispositivo.Size = new System.Drawing.Size(319, 31);
            this.cbxTipoDispositivo.TabIndex = 9;
            // 
            // lblErrorNombre
            // 
            this.lblErrorNombre.AutoSize = true;
            this.lblErrorNombre.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNombre.Location = new System.Drawing.Point(499, 140);
            this.lblErrorNombre.Name = "lblErrorNombre";
            this.lblErrorNombre.Size = new System.Drawing.Size(131, 23);
            this.lblErrorNombre.TabIndex = 10;
            this.lblErrorNombre.Text = "Nombre inválido";
            this.lblErrorNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkEnUso
            // 
            this.chkEnUso.AutoSize = true;
            this.chkEnUso.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnUso.Location = new System.Drawing.Point(155, 283);
            this.chkEnUso.Name = "chkEnUso";
            this.chkEnUso.Size = new System.Drawing.Size(15, 14);
            this.chkEnUso.TabIndex = 11;
            this.chkEnUso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkEnUso.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(730, 476);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(96, 46);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(832, 476);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 46);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(651, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 297);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lblErrorTipo
            // 
            this.lblErrorTipo.AutoSize = true;
            this.lblErrorTipo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorTipo.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTipo.Location = new System.Drawing.Point(499, 212);
            this.lblErrorTipo.Name = "lblErrorTipo";
            this.lblErrorTipo.Size = new System.Drawing.Size(199, 23);
            this.lblErrorTipo.TabIndex = 15;
            this.lblErrorTipo.Text = "Debe seleccionar un tipo";
            this.lblErrorTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegistrarDispositivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblErrorTipo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.chkEnUso);
            this.Controls.Add(this.lblErrorNombre);
            this.Controls.Add(this.cbxTipoDispositivo);
            this.Controls.Add(this.lblEnUso);
            this.Controls.Add(this.txtNombreDispositivo);
            this.Controls.Add(this.lblTipoDispositivo);
            this.Controls.Add(this.lblNombreDispositivo);
            this.Controls.Add(this.lblMenuDispositivo);
            this.Name = "RegistrarDispositivo";
            this.Size = new System.Drawing.Size(972, 571);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMenuDispositivo;
        private System.Windows.Forms.Label lblNombreDispositivo;
        private System.Windows.Forms.Label lblTipoDispositivo;
        private System.Windows.Forms.TextBox txtNombreDispositivo;
        private System.Windows.Forms.Label lblEnUso;
        private System.Windows.Forms.ComboBox cbxTipoDispositivo;
        private System.Windows.Forms.Label lblErrorNombre;
        private System.Windows.Forms.CheckBox chkEnUso;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblErrorTipo;
    }
}
