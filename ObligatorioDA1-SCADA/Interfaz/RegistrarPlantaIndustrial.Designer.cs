namespace Interfaz
{
    partial class RegistrarPlantaIndustrial
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
            this.lblErrorNombre = new System.Windows.Forms.Label();
            this.txtNombrePlanta = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblMenuPlantaIndustrial = new System.Windows.Forms.Label();
            this.lblErrorDireccion = new System.Windows.Forms.Label();
            this.txtDireccionPlanta = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblErrorCiudad = new System.Windows.Forms.Label();
            this.txtCiudadPlanta = new System.Windows.Forms.TextBox();
            this.lblCiudad = new System.Windows.Forms.Label();
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
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblErrorNombre
            // 
            this.lblErrorNombre.AutoSize = true;
            this.lblErrorNombre.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNombre.Location = new System.Drawing.Point(500, 143);
            this.lblErrorNombre.Name = "lblErrorNombre";
            this.lblErrorNombre.Size = new System.Drawing.Size(125, 21);
            this.lblErrorNombre.TabIndex = 19;
            this.lblErrorNombre.Text = "Nombre inválido";
            this.lblErrorNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombrePlanta
            // 
            this.txtNombrePlanta.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombrePlanta.Location = new System.Drawing.Point(156, 140);
            this.txtNombrePlanta.Name = "txtNombrePlanta";
            this.txtNombrePlanta.Size = new System.Drawing.Size(319, 26);
            this.txtNombrePlanta.TabIndex = 18;
            this.txtNombrePlanta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombrePlanta_KeyPress);
            this.txtNombrePlanta.Leave += new System.EventHandler(this.txtNombrePlanta_Leave);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(47, 143);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(66, 21);
            this.lblNombre.TabIndex = 17;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMenuPlantaIndustrial
            // 
            this.lblMenuPlantaIndustrial.AutoSize = true;
            this.lblMenuPlantaIndustrial.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuPlantaIndustrial.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMenuPlantaIndustrial.Location = new System.Drawing.Point(358, 14);
            this.lblMenuPlantaIndustrial.Name = "lblMenuPlantaIndustrial";
            this.lblMenuPlantaIndustrial.Size = new System.Drawing.Size(310, 34);
            this.lblMenuPlantaIndustrial.TabIndex = 16;
            this.lblMenuPlantaIndustrial.Text = "Registrar Planta Industrial";
            // 
            // lblErrorDireccion
            // 
            this.lblErrorDireccion.AutoSize = true;
            this.lblErrorDireccion.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorDireccion.ForeColor = System.Drawing.Color.Red;
            this.lblErrorDireccion.Location = new System.Drawing.Point(500, 209);
            this.lblErrorDireccion.Name = "lblErrorDireccion";
            this.lblErrorDireccion.Size = new System.Drawing.Size(136, 21);
            this.lblErrorDireccion.TabIndex = 24;
            this.lblErrorDireccion.Text = "Dirección inválida";
            this.lblErrorDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDireccionPlanta
            // 
            this.txtDireccionPlanta.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccionPlanta.Location = new System.Drawing.Point(156, 206);
            this.txtDireccionPlanta.Name = "txtDireccionPlanta";
            this.txtDireccionPlanta.Size = new System.Drawing.Size(319, 26);
            this.txtDireccionPlanta.TabIndex = 23;
            this.txtDireccionPlanta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccionPlanta_KeyPress);
            this.txtDireccionPlanta.Leave += new System.EventHandler(this.txtDireccionPlanta_Leave);
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(47, 209);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(77, 21);
            this.lblDireccion.TabIndex = 22;
            this.lblDireccion.Text = "Dirección";
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblErrorCiudad
            // 
            this.lblErrorCiudad.AutoSize = true;
            this.lblErrorCiudad.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorCiudad.ForeColor = System.Drawing.Color.Red;
            this.lblErrorCiudad.Location = new System.Drawing.Point(500, 274);
            this.lblErrorCiudad.Name = "lblErrorCiudad";
            this.lblErrorCiudad.Size = new System.Drawing.Size(119, 21);
            this.lblErrorCiudad.TabIndex = 27;
            this.lblErrorCiudad.Text = "Ciudad inválida";
            this.lblErrorCiudad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCiudadPlanta
            // 
            this.txtCiudadPlanta.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiudadPlanta.Location = new System.Drawing.Point(156, 271);
            this.txtCiudadPlanta.Name = "txtCiudadPlanta";
            this.txtCiudadPlanta.Size = new System.Drawing.Size(319, 26);
            this.txtCiudadPlanta.TabIndex = 26;
            this.txtCiudadPlanta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCiudadPlanta_KeyPress);
            this.txtCiudadPlanta.Leave += new System.EventHandler(this.txtCiudadPlanta_Leave);
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCiudad.Location = new System.Drawing.Point(47, 274);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(60, 21);
            this.lblCiudad.TabIndex = 25;
            this.lblCiudad.Text = "Ciudad";
            this.lblCiudad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegistrarPlantaIndustrial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblErrorCiudad);
            this.Controls.Add(this.txtCiudadPlanta);
            this.Controls.Add(this.lblCiudad);
            this.Controls.Add(this.lblErrorDireccion);
            this.Controls.Add(this.txtDireccionPlanta);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblErrorNombre);
            this.Controls.Add(this.txtNombrePlanta);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblMenuPlantaIndustrial);
            this.Name = "RegistrarPlantaIndustrial";
            this.Size = new System.Drawing.Size(972, 571);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblErrorNombre;
        private System.Windows.Forms.TextBox txtNombrePlanta;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblMenuPlantaIndustrial;
        private System.Windows.Forms.Label lblErrorDireccion;
        private System.Windows.Forms.TextBox txtDireccionPlanta;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblErrorCiudad;
        private System.Windows.Forms.TextBox txtCiudadPlanta;
        private System.Windows.Forms.Label lblCiudad;
    }
}
