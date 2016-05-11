namespace Interfaz
{
    partial class MenuPrincipal
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
            this.lblMenuPrincipal = new System.Windows.Forms.Label();
            this.treeViewPlantaDeProduccion = new System.Windows.Forms.TreeView();
            this.lblPlantaDeProduccion = new System.Windows.Forms.Label();
            this.lblTableroControl = new System.Windows.Forms.Label();
            this.lblVariables = new System.Windows.Forms.Label();
            this.lstVariables = new System.Windows.Forms.ListView();
            this.lblOpcionesInstalacion = new System.Windows.Forms.Label();
            this.btnEliminarInstalacion = new System.Windows.Forms.Button();
            this.btnAgregarInstalacion = new System.Windows.Forms.Button();
            this.btnEditarInstalacion = new System.Windows.Forms.Button();
            this.btnEditarDispositivo = new System.Windows.Forms.Button();
            this.btnEliminarDispositivo = new System.Windows.Forms.Button();
            this.btnAgregarDispositivo = new System.Windows.Forms.Button();
            this.lblOpcionesDispositivo = new System.Windows.Forms.Label();
            this.btnAgregarTipoDispositivo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditarVariable = new System.Windows.Forms.Button();
            this.btnEliminarVariable = new System.Windows.Forms.Button();
            this.btnAgregarVariable = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregarValorVariable = new System.Windows.Forms.Button();
            this.btnValoresHistoricos = new System.Windows.Forms.Button();
            this.lstTableroControl = new System.Windows.Forms.RichTextBox();
            this.btnCargarDatosPrueba = new System.Windows.Forms.Button();
            this.btnMenuOpcionesTipo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMenuPrincipal
            // 
            this.lblMenuPrincipal.AutoSize = true;
            this.lblMenuPrincipal.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuPrincipal.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMenuPrincipal.Location = new System.Drawing.Point(417, 9);
            this.lblMenuPrincipal.Name = "lblMenuPrincipal";
            this.lblMenuPrincipal.Size = new System.Drawing.Size(181, 34);
            this.lblMenuPrincipal.TabIndex = 2;
            this.lblMenuPrincipal.Text = "Menú Principal";
            // 
            // treeViewPlantaDeProduccion
            // 
            this.treeViewPlantaDeProduccion.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewPlantaDeProduccion.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewPlantaDeProduccion.Location = new System.Drawing.Point(22, 94);
            this.treeViewPlantaDeProduccion.Name = "treeViewPlantaDeProduccion";
            this.treeViewPlantaDeProduccion.Size = new System.Drawing.Size(225, 439);
            this.treeViewPlantaDeProduccion.TabIndex = 3;
            this.treeViewPlantaDeProduccion.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewPlantaDeProduccion_AfterSelect);
            // 
            // lblPlantaDeProduccion
            // 
            this.lblPlantaDeProduccion.AutoSize = true;
            this.lblPlantaDeProduccion.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlantaDeProduccion.Location = new System.Drawing.Point(55, 60);
            this.lblPlantaDeProduccion.Name = "lblPlantaDeProduccion";
            this.lblPlantaDeProduccion.Size = new System.Drawing.Size(167, 23);
            this.lblPlantaDeProduccion.TabIndex = 4;
            this.lblPlantaDeProduccion.Text = "Planta de Producción";
            this.lblPlantaDeProduccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTableroControl
            // 
            this.lblTableroControl.AutoSize = true;
            this.lblTableroControl.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableroControl.Location = new System.Drawing.Point(428, 60);
            this.lblTableroControl.Name = "lblTableroControl";
            this.lblTableroControl.Size = new System.Drawing.Size(155, 23);
            this.lblTableroControl.TabIndex = 5;
            this.lblTableroControl.Text = "Tablero de Control";
            this.lblTableroControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVariables
            // 
            this.lblVariables.AutoSize = true;
            this.lblVariables.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVariables.Location = new System.Drawing.Point(459, 293);
            this.lblVariables.Name = "lblVariables";
            this.lblVariables.Size = new System.Drawing.Size(82, 23);
            this.lblVariables.TabIndex = 7;
            this.lblVariables.Text = "Variables";
            this.lblVariables.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstVariables
            // 
            this.lstVariables.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lstVariables.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVariables.Location = new System.Drawing.Point(363, 329);
            this.lstVariables.MultiSelect = false;
            this.lstVariables.Name = "lstVariables";
            this.lstVariables.Size = new System.Drawing.Size(266, 204);
            this.lstVariables.TabIndex = 8;
            this.lstVariables.UseCompatibleStateImageBehavior = false;
            this.lstVariables.View = System.Windows.Forms.View.SmallIcon;
            this.lstVariables.SelectedIndexChanged += new System.EventHandler(this.lstVariables_SelectedIndexChanged);
            // 
            // lblOpcionesInstalacion
            // 
            this.lblOpcionesInstalacion.AutoSize = true;
            this.lblOpcionesInstalacion.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcionesInstalacion.ForeColor = System.Drawing.Color.Black;
            this.lblOpcionesInstalacion.Location = new System.Drawing.Point(780, 60);
            this.lblOpcionesInstalacion.Name = "lblOpcionesInstalacion";
            this.lblOpcionesInstalacion.Size = new System.Drawing.Size(110, 23);
            this.lblOpcionesInstalacion.TabIndex = 11;
            this.lblOpcionesInstalacion.Text = "Instalaciones";
            this.lblOpcionesInstalacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEliminarInstalacion
            // 
            this.btnEliminarInstalacion.BackColor = System.Drawing.Color.Red;
            this.btnEliminarInstalacion.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarInstalacion.Location = new System.Drawing.Point(816, 88);
            this.btnEliminarInstalacion.Name = "btnEliminarInstalacion";
            this.btnEliminarInstalacion.Size = new System.Drawing.Size(40, 44);
            this.btnEliminarInstalacion.TabIndex = 13;
            this.btnEliminarInstalacion.Text = "-";
            this.btnEliminarInstalacion.UseVisualStyleBackColor = false;
            this.btnEliminarInstalacion.Click += new System.EventHandler(this.btnBorrarInstalacion_Click);
            // 
            // btnAgregarInstalacion
            // 
            this.btnAgregarInstalacion.BackColor = System.Drawing.Color.Chartreuse;
            this.btnAgregarInstalacion.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarInstalacion.Location = new System.Drawing.Point(761, 89);
            this.btnAgregarInstalacion.Name = "btnAgregarInstalacion";
            this.btnAgregarInstalacion.Size = new System.Drawing.Size(40, 43);
            this.btnAgregarInstalacion.TabIndex = 12;
            this.btnAgregarInstalacion.Text = "+";
            this.btnAgregarInstalacion.UseVisualStyleBackColor = false;
            this.btnAgregarInstalacion.Click += new System.EventHandler(this.btnAgregarInstalacion_Click);
            // 
            // btnEditarInstalacion
            // 
            this.btnEditarInstalacion.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnEditarInstalacion.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarInstalacion.Location = new System.Drawing.Point(870, 88);
            this.btnEditarInstalacion.Name = "btnEditarInstalacion";
            this.btnEditarInstalacion.Size = new System.Drawing.Size(40, 44);
            this.btnEditarInstalacion.TabIndex = 14;
            this.btnEditarInstalacion.Text = "I";
            this.btnEditarInstalacion.UseVisualStyleBackColor = false;
            this.btnEditarInstalacion.Click += new System.EventHandler(this.btnEditarInstalacion_Click);
            // 
            // btnEditarDispositivo
            // 
            this.btnEditarDispositivo.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnEditarDispositivo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarDispositivo.Location = new System.Drawing.Point(870, 177);
            this.btnEditarDispositivo.Name = "btnEditarDispositivo";
            this.btnEditarDispositivo.Size = new System.Drawing.Size(40, 44);
            this.btnEditarDispositivo.TabIndex = 18;
            this.btnEditarDispositivo.Text = "I";
            this.btnEditarDispositivo.UseVisualStyleBackColor = false;
            this.btnEditarDispositivo.Click += new System.EventHandler(this.btnEditarDispositivo_Click);
            // 
            // btnEliminarDispositivo
            // 
            this.btnEliminarDispositivo.BackColor = System.Drawing.Color.Red;
            this.btnEliminarDispositivo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarDispositivo.Location = new System.Drawing.Point(816, 177);
            this.btnEliminarDispositivo.Name = "btnEliminarDispositivo";
            this.btnEliminarDispositivo.Size = new System.Drawing.Size(40, 44);
            this.btnEliminarDispositivo.TabIndex = 17;
            this.btnEliminarDispositivo.Text = "-";
            this.btnEliminarDispositivo.UseVisualStyleBackColor = false;
            this.btnEliminarDispositivo.Click += new System.EventHandler(this.btnEliminarDispositivo_Click);
            // 
            // btnAgregarDispositivo
            // 
            this.btnAgregarDispositivo.BackColor = System.Drawing.Color.Chartreuse;
            this.btnAgregarDispositivo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDispositivo.Location = new System.Drawing.Point(761, 178);
            this.btnAgregarDispositivo.Name = "btnAgregarDispositivo";
            this.btnAgregarDispositivo.Size = new System.Drawing.Size(40, 43);
            this.btnAgregarDispositivo.TabIndex = 16;
            this.btnAgregarDispositivo.Text = "+";
            this.btnAgregarDispositivo.UseVisualStyleBackColor = false;
            this.btnAgregarDispositivo.Click += new System.EventHandler(this.btnAgregarDispositivo_Click);
            // 
            // lblOpcionesDispositivo
            // 
            this.lblOpcionesDispositivo.AutoSize = true;
            this.lblOpcionesDispositivo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcionesDispositivo.ForeColor = System.Drawing.Color.Black;
            this.lblOpcionesDispositivo.Location = new System.Drawing.Point(786, 151);
            this.lblOpcionesDispositivo.Name = "lblOpcionesDispositivo";
            this.lblOpcionesDispositivo.Size = new System.Drawing.Size(99, 23);
            this.lblOpcionesDispositivo.TabIndex = 15;
            this.lblOpcionesDispositivo.Text = "Dispositivos";
            this.lblOpcionesDispositivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAgregarTipoDispositivo
            // 
            this.btnAgregarTipoDispositivo.BackColor = System.Drawing.Color.Chartreuse;
            this.btnAgregarTipoDispositivo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTipoDispositivo.Location = new System.Drawing.Point(761, 269);
            this.btnAgregarTipoDispositivo.Name = "btnAgregarTipoDispositivo";
            this.btnAgregarTipoDispositivo.Size = new System.Drawing.Size(40, 43);
            this.btnAgregarTipoDispositivo.TabIndex = 20;
            this.btnAgregarTipoDispositivo.Text = "+";
            this.btnAgregarTipoDispositivo.UseVisualStyleBackColor = false;
            this.btnAgregarTipoDispositivo.Click += new System.EventHandler(this.btnAgregarTipoDispositivo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(750, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 23);
            this.label1.TabIndex = 19;
            this.label1.Text = "Tipos de Dispositivos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEditarVariable
            // 
            this.btnEditarVariable.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnEditarVariable.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarVariable.Location = new System.Drawing.Point(870, 357);
            this.btnEditarVariable.Name = "btnEditarVariable";
            this.btnEditarVariable.Size = new System.Drawing.Size(40, 44);
            this.btnEditarVariable.TabIndex = 26;
            this.btnEditarVariable.Text = "I";
            this.btnEditarVariable.UseVisualStyleBackColor = false;
            this.btnEditarVariable.Click += new System.EventHandler(this.btnEditarVariable_Click);
            // 
            // btnEliminarVariable
            // 
            this.btnEliminarVariable.BackColor = System.Drawing.Color.Red;
            this.btnEliminarVariable.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarVariable.Location = new System.Drawing.Point(816, 357);
            this.btnEliminarVariable.Name = "btnEliminarVariable";
            this.btnEliminarVariable.Size = new System.Drawing.Size(40, 44);
            this.btnEliminarVariable.TabIndex = 25;
            this.btnEliminarVariable.Text = "-";
            this.btnEliminarVariable.UseVisualStyleBackColor = false;
            this.btnEliminarVariable.Click += new System.EventHandler(this.btnEliminarVariable_Click);
            // 
            // btnAgregarVariable
            // 
            this.btnAgregarVariable.BackColor = System.Drawing.Color.Chartreuse;
            this.btnAgregarVariable.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarVariable.Location = new System.Drawing.Point(761, 358);
            this.btnAgregarVariable.Name = "btnAgregarVariable";
            this.btnAgregarVariable.Size = new System.Drawing.Size(40, 43);
            this.btnAgregarVariable.TabIndex = 24;
            this.btnAgregarVariable.Text = "+";
            this.btnAgregarVariable.UseVisualStyleBackColor = false;
            this.btnAgregarVariable.Click += new System.EventHandler(this.btnAgregarVariable_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(797, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Variables";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAgregarValorVariable
            // 
            this.btnAgregarValorVariable.Location = new System.Drawing.Point(752, 407);
            this.btnAgregarValorVariable.Name = "btnAgregarValorVariable";
            this.btnAgregarValorVariable.Size = new System.Drawing.Size(75, 39);
            this.btnAgregarValorVariable.TabIndex = 27;
            this.btnAgregarValorVariable.Text = "Agregar Valor";
            this.btnAgregarValorVariable.UseVisualStyleBackColor = true;
            this.btnAgregarValorVariable.Click += new System.EventHandler(this.btnAgregarValorVariable_Click);
            // 
            // btnValoresHistoricos
            // 
            this.btnValoresHistoricos.Location = new System.Drawing.Point(846, 407);
            this.btnValoresHistoricos.Name = "btnValoresHistoricos";
            this.btnValoresHistoricos.Size = new System.Drawing.Size(75, 39);
            this.btnValoresHistoricos.TabIndex = 28;
            this.btnValoresHistoricos.Text = "Ver Histórico";
            this.btnValoresHistoricos.UseVisualStyleBackColor = true;
            this.btnValoresHistoricos.Click += new System.EventHandler(this.btnValoresHistoricos_Click);
            // 
            // lstTableroControl
            // 
            this.lstTableroControl.BackColor = System.Drawing.Color.White;
            this.lstTableroControl.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTableroControl.Location = new System.Drawing.Point(363, 94);
            this.lstTableroControl.Name = "lstTableroControl";
            this.lstTableroControl.ReadOnly = true;
            this.lstTableroControl.Size = new System.Drawing.Size(266, 184);
            this.lstTableroControl.TabIndex = 29;
            this.lstTableroControl.Text = "";
            // 
            // btnCargarDatosPrueba
            // 
            this.btnCargarDatosPrueba.Location = new System.Drawing.Point(801, 492);
            this.btnCargarDatosPrueba.Name = "btnCargarDatosPrueba";
            this.btnCargarDatosPrueba.Size = new System.Drawing.Size(75, 47);
            this.btnCargarDatosPrueba.TabIndex = 30;
            this.btnCargarDatosPrueba.Text = "Cargar datos de Prueba";
            this.btnCargarDatosPrueba.UseVisualStyleBackColor = true;
            this.btnCargarDatosPrueba.Click += new System.EventHandler(this.btnCargarDatosPrueba_Click);
            // 
            // btnMenuOpcionesTipo
            // 
            this.btnMenuOpcionesTipo.Location = new System.Drawing.Point(816, 269);
            this.btnMenuOpcionesTipo.Name = "btnMenuOpcionesTipo";
            this.btnMenuOpcionesTipo.Size = new System.Drawing.Size(94, 43);
            this.btnMenuOpcionesTipo.TabIndex = 31;
            this.btnMenuOpcionesTipo.Text = "Menú de Opciones";
            this.btnMenuOpcionesTipo.UseVisualStyleBackColor = true;
            this.btnMenuOpcionesTipo.Click += new System.EventHandler(this.btnMenuOpcionesTipo_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMenuOpcionesTipo);
            this.Controls.Add(this.btnCargarDatosPrueba);
            this.Controls.Add(this.lstTableroControl);
            this.Controls.Add(this.btnValoresHistoricos);
            this.Controls.Add(this.btnAgregarValorVariable);
            this.Controls.Add(this.btnEditarVariable);
            this.Controls.Add(this.btnEliminarVariable);
            this.Controls.Add(this.btnAgregarVariable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgregarTipoDispositivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditarDispositivo);
            this.Controls.Add(this.btnEliminarDispositivo);
            this.Controls.Add(this.btnAgregarDispositivo);
            this.Controls.Add(this.lblOpcionesDispositivo);
            this.Controls.Add(this.btnEditarInstalacion);
            this.Controls.Add(this.btnEliminarInstalacion);
            this.Controls.Add(this.btnAgregarInstalacion);
            this.Controls.Add(this.lblOpcionesInstalacion);
            this.Controls.Add(this.lstVariables);
            this.Controls.Add(this.lblVariables);
            this.Controls.Add(this.lblTableroControl);
            this.Controls.Add(this.lblPlantaDeProduccion);
            this.Controls.Add(this.treeViewPlantaDeProduccion);
            this.Controls.Add(this.lblMenuPrincipal);
            this.Name = "MenuPrincipal";
            this.Size = new System.Drawing.Size(972, 571);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMenuPrincipal;
        private System.Windows.Forms.TreeView treeViewPlantaDeProduccion;
        private System.Windows.Forms.Label lblPlantaDeProduccion;
        private System.Windows.Forms.Label lblTableroControl;
        private System.Windows.Forms.Label lblVariables;
        private System.Windows.Forms.ListView lstVariables;
        private System.Windows.Forms.Label lblOpcionesInstalacion;
        private System.Windows.Forms.Button btnEliminarInstalacion;
        private System.Windows.Forms.Button btnAgregarInstalacion;
        private System.Windows.Forms.Button btnEditarInstalacion;
        private System.Windows.Forms.Button btnEditarDispositivo;
        private System.Windows.Forms.Button btnEliminarDispositivo;
        private System.Windows.Forms.Button btnAgregarDispositivo;
        private System.Windows.Forms.Label lblOpcionesDispositivo;
        private System.Windows.Forms.Button btnAgregarTipoDispositivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditarVariable;
        private System.Windows.Forms.Button btnEliminarVariable;
        private System.Windows.Forms.Button btnAgregarVariable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregarValorVariable;
        private System.Windows.Forms.Button btnValoresHistoricos;
        private System.Windows.Forms.RichTextBox lstTableroControl;
        private System.Windows.Forms.Button btnCargarDatosPrueba;
        private System.Windows.Forms.Button btnMenuOpcionesTipo;
    }
}
