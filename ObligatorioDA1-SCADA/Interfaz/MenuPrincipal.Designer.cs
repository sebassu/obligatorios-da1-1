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
            this.label3 = new System.Windows.Forms.Label();
            this.menuOpciones = new System.Windows.Forms.MenuStrip();
            this.plantasIndustrialesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAgregarPlantaIndustrial = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEliminarPlantaIndustrial = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditarPlantaIndustrial = new System.Windows.Forms.ToolStripMenuItem();
            this.instalacionesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAgregarInstalacion = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEliminarInstalacion = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditarInstalacion = new System.Windows.Forms.ToolStripMenuItem();
            this.dispositivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAgregarDispositivo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEliminarDispositivo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditarDispositivo = new System.Windows.Forms.ToolStripMenuItem();
            this.lblIncidentes = new System.Windows.Forms.Label();
            this.btnAgregarIncidente = new System.Windows.Forms.Button();
            this.btnVerIncidentes = new System.Windows.Forms.Button();
            this.menuOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMenuPrincipal
            // 
            this.lblMenuPrincipal.AutoSize = true;
            this.lblMenuPrincipal.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuPrincipal.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMenuPrincipal.Location = new System.Drawing.Point(417, 25);
            this.lblMenuPrincipal.Name = "lblMenuPrincipal";
            this.lblMenuPrincipal.Size = new System.Drawing.Size(181, 34);
            this.lblMenuPrincipal.TabIndex = 2;
            this.lblMenuPrincipal.Text = "Menú Principal";
            // 
            // treeViewPlantaDeProduccion
            // 
            this.treeViewPlantaDeProduccion.AllowDrop = true;
            this.treeViewPlantaDeProduccion.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewPlantaDeProduccion.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewPlantaDeProduccion.HideSelection = false;
            this.treeViewPlantaDeProduccion.Location = new System.Drawing.Point(22, 110);
            this.treeViewPlantaDeProduccion.Name = "treeViewPlantaDeProduccion";
            this.treeViewPlantaDeProduccion.Size = new System.Drawing.Size(225, 426);
            this.treeViewPlantaDeProduccion.TabIndex = 3;
            this.treeViewPlantaDeProduccion.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewPlantaDeProduccion_AfterSelect);
            // 
            // lblPlantaDeProduccion
            // 
            this.lblPlantaDeProduccion.AutoSize = true;
            this.lblPlantaDeProduccion.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlantaDeProduccion.Location = new System.Drawing.Point(50, 76);
            this.lblPlantaDeProduccion.Name = "lblPlantaDeProduccion";
            this.lblPlantaDeProduccion.Size = new System.Drawing.Size(172, 21);
            this.lblPlantaDeProduccion.TabIndex = 4;
            this.lblPlantaDeProduccion.Text = "Plantas de Producción";
            this.lblPlantaDeProduccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTableroControl
            // 
            this.lblTableroControl.AutoSize = true;
            this.lblTableroControl.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableroControl.Location = new System.Drawing.Point(428, 76);
            this.lblTableroControl.Name = "lblTableroControl";
            this.lblTableroControl.Size = new System.Drawing.Size(143, 21);
            this.lblTableroControl.TabIndex = 5;
            this.lblTableroControl.Text = "Tablero de Control";
            this.lblTableroControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVariables
            // 
            this.lblVariables.AutoSize = true;
            this.lblVariables.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVariables.Location = new System.Drawing.Point(459, 310);
            this.lblVariables.Name = "lblVariables";
            this.lblVariables.Size = new System.Drawing.Size(77, 21);
            this.lblVariables.TabIndex = 7;
            this.lblVariables.Text = "Variables";
            this.lblVariables.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstVariables
            // 
            this.lstVariables.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lstVariables.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVariables.HideSelection = false;
            this.lstVariables.Location = new System.Drawing.Point(363, 345);
            this.lstVariables.MultiSelect = false;
            this.lstVariables.Name = "lstVariables";
            this.lstVariables.Size = new System.Drawing.Size(266, 204);
            this.lstVariables.TabIndex = 8;
            this.lstVariables.UseCompatibleStateImageBehavior = false;
            this.lstVariables.View = System.Windows.Forms.View.SmallIcon;
            this.lstVariables.SelectedIndexChanged += new System.EventHandler(this.lstVariables_SelectedIndexChanged);
            // 
            // btnAgregarTipoDispositivo
            // 
            this.btnAgregarTipoDispositivo.BackColor = System.Drawing.Color.Chartreuse;
            this.btnAgregarTipoDispositivo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTipoDispositivo.Location = new System.Drawing.Point(761, 227);
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
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(750, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "Tipos de Dispositivos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEditarVariable
            // 
            this.btnEditarVariable.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnEditarVariable.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarVariable.Location = new System.Drawing.Point(870, 315);
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
            this.btnEliminarVariable.Location = new System.Drawing.Point(816, 315);
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
            this.btnAgregarVariable.Location = new System.Drawing.Point(761, 316);
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
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(797, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "Variables";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAgregarValorVariable
            // 
            this.btnAgregarValorVariable.Location = new System.Drawing.Point(752, 365);
            this.btnAgregarValorVariable.Name = "btnAgregarValorVariable";
            this.btnAgregarValorVariable.Size = new System.Drawing.Size(75, 39);
            this.btnAgregarValorVariable.TabIndex = 27;
            this.btnAgregarValorVariable.Text = "Agregar Valor";
            this.btnAgregarValorVariable.UseVisualStyleBackColor = true;
            this.btnAgregarValorVariable.Click += new System.EventHandler(this.btnAgregarValorVariable_Click);
            // 
            // btnValoresHistoricos
            // 
            this.btnValoresHistoricos.Location = new System.Drawing.Point(846, 365);
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
            this.lstTableroControl.Location = new System.Drawing.Point(363, 110);
            this.lstTableroControl.Name = "lstTableroControl";
            this.lstTableroControl.ReadOnly = true;
            this.lstTableroControl.Size = new System.Drawing.Size(266, 184);
            this.lstTableroControl.TabIndex = 29;
            this.lstTableroControl.Text = "";
            // 
            // btnCargarDatosPrueba
            // 
            this.btnCargarDatosPrueba.Location = new System.Drawing.Point(801, 450);
            this.btnCargarDatosPrueba.Name = "btnCargarDatosPrueba";
            this.btnCargarDatosPrueba.Size = new System.Drawing.Size(75, 47);
            this.btnCargarDatosPrueba.TabIndex = 30;
            this.btnCargarDatosPrueba.Text = "Cargar datos de Prueba";
            this.btnCargarDatosPrueba.UseVisualStyleBackColor = true;
            this.btnCargarDatosPrueba.Click += new System.EventHandler(this.btnCargarDatosPrueba_Click);
            // 
            // btnMenuOpcionesTipo
            // 
            this.btnMenuOpcionesTipo.Location = new System.Drawing.Point(816, 227);
            this.btnMenuOpcionesTipo.Name = "btnMenuOpcionesTipo";
            this.btnMenuOpcionesTipo.Size = new System.Drawing.Size(94, 39);
            this.btnMenuOpcionesTipo.TabIndex = 31;
            this.btnMenuOpcionesTipo.Text = "Menú de Opciones";
            this.btnMenuOpcionesTipo.UseVisualStyleBackColor = true;
            this.btnMenuOpcionesTipo.Click += new System.EventHandler(this.btnMenuOpcionesTipo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(22, 546);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Dispositivos que no están en uso se muestran en naranja.";
            // 
            // menuOpciones
            // 
            this.menuOpciones.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plantasIndustrialesMenu,
            this.instalacionesMenu,
            this.dispositivosToolStripMenuItem});
            this.menuOpciones.Location = new System.Drawing.Point(0, 0);
            this.menuOpciones.Name = "menuOpciones";
            this.menuOpciones.Size = new System.Drawing.Size(972, 24);
            this.menuOpciones.TabIndex = 33;
            // 
            // plantasIndustrialesMenu
            // 
            this.plantasIndustrialesMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarPlantaIndustrial,
            this.btnEliminarPlantaIndustrial,
            this.btnEditarPlantaIndustrial});
            this.plantasIndustrialesMenu.Name = "plantasIndustrialesMenu";
            this.plantasIndustrialesMenu.Size = new System.Drawing.Size(120, 20);
            this.plantasIndustrialesMenu.Text = "Plantas Industriales";
            // 
            // btnAgregarPlantaIndustrial
            // 
            this.btnAgregarPlantaIndustrial.Name = "btnAgregarPlantaIndustrial";
            this.btnAgregarPlantaIndustrial.Size = new System.Drawing.Size(213, 22);
            this.btnAgregarPlantaIndustrial.Text = "Registrar Planta Industrial";
            // 
            // btnEliminarPlantaIndustrial
            // 
            this.btnEliminarPlantaIndustrial.Name = "btnEliminarPlantaIndustrial";
            this.btnEliminarPlantaIndustrial.Size = new System.Drawing.Size(213, 22);
            this.btnEliminarPlantaIndustrial.Text = "Eliminar Planta Industrial";
            // 
            // btnEditarPlantaIndustrial
            // 
            this.btnEditarPlantaIndustrial.Name = "btnEditarPlantaIndustrial";
            this.btnEditarPlantaIndustrial.Size = new System.Drawing.Size(213, 22);
            this.btnEditarPlantaIndustrial.Text = "Modificar Planta Industrial";
            // 
            // instalacionesMenu
            // 
            this.instalacionesMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarInstalacion,
            this.btnEliminarInstalacion,
            this.btnEditarInstalacion});
            this.instalacionesMenu.Name = "instalacionesMenu";
            this.instalacionesMenu.Size = new System.Drawing.Size(87, 20);
            this.instalacionesMenu.Text = "Instalaciones";
            // 
            // btnAgregarInstalacion
            // 
            this.btnAgregarInstalacion.Name = "btnAgregarInstalacion";
            this.btnAgregarInstalacion.Size = new System.Drawing.Size(185, 22);
            this.btnAgregarInstalacion.Text = "Registrar Instalación";
            this.btnAgregarInstalacion.Click += new System.EventHandler(this.btnAgregarInstalacion_Click);
            // 
            // btnEliminarInstalacion
            // 
            this.btnEliminarInstalacion.Name = "btnEliminarInstalacion";
            this.btnEliminarInstalacion.Size = new System.Drawing.Size(185, 22);
            this.btnEliminarInstalacion.Text = "Eliminar Instalación";
            this.btnEliminarInstalacion.Click += new System.EventHandler(this.btnBorrarInstalacion_Click);
            // 
            // btnEditarInstalacion
            // 
            this.btnEditarInstalacion.Name = "btnEditarInstalacion";
            this.btnEditarInstalacion.Size = new System.Drawing.Size(185, 22);
            this.btnEditarInstalacion.Text = "Modificar Instalación";
            this.btnEditarInstalacion.Click += new System.EventHandler(this.btnEditarInstalacion_Click);
            // 
            // dispositivosToolStripMenuItem
            // 
            this.dispositivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarDispositivo,
            this.btnEliminarDispositivo,
            this.btnEditarDispositivo});
            this.dispositivosToolStripMenuItem.Name = "dispositivosToolStripMenuItem";
            this.dispositivosToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.dispositivosToolStripMenuItem.Text = "Dispositivos";
            // 
            // btnAgregarDispositivo
            // 
            this.btnAgregarDispositivo.Name = "btnAgregarDispositivo";
            this.btnAgregarDispositivo.Size = new System.Drawing.Size(186, 22);
            this.btnAgregarDispositivo.Text = "Registrar Dispositivo";
            this.btnAgregarDispositivo.Click += new System.EventHandler(this.btnAgregarDispositivo_Click);
            // 
            // btnEliminarDispositivo
            // 
            this.btnEliminarDispositivo.Name = "btnEliminarDispositivo";
            this.btnEliminarDispositivo.Size = new System.Drawing.Size(186, 22);
            this.btnEliminarDispositivo.Text = "Eliminar Dispositivo";
            this.btnEliminarDispositivo.Click += new System.EventHandler(this.btnEliminarDispositivo_Click);
            // 
            // btnEditarDispositivo
            // 
            this.btnEditarDispositivo.Name = "btnEditarDispositivo";
            this.btnEditarDispositivo.Size = new System.Drawing.Size(186, 22);
            this.btnEditarDispositivo.Text = "Modificar Dispositivo";
            this.btnEditarDispositivo.Click += new System.EventHandler(this.btnEditarDispositivo_Click);
            // 
            // lblIncidentes
            // 
            this.lblIncidentes.AutoSize = true;
            this.lblIncidentes.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncidentes.ForeColor = System.Drawing.Color.Black;
            this.lblIncidentes.Location = new System.Drawing.Point(793, 117);
            this.lblIncidentes.Name = "lblIncidentes";
            this.lblIncidentes.Size = new System.Drawing.Size(86, 21);
            this.lblIncidentes.TabIndex = 34;
            this.lblIncidentes.Text = "Incidentes";
            this.lblIncidentes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAgregarIncidente
            // 
            this.btnAgregarIncidente.BackColor = System.Drawing.Color.Chartreuse;
            this.btnAgregarIncidente.Location = new System.Drawing.Point(752, 144);
            this.btnAgregarIncidente.Name = "btnAgregarIncidente";
            this.btnAgregarIncidente.Size = new System.Drawing.Size(75, 39);
            this.btnAgregarIncidente.TabIndex = 35;
            this.btnAgregarIncidente.Text = "Agregar Incidente";
            this.btnAgregarIncidente.UseVisualStyleBackColor = false;
            this.btnAgregarIncidente.Click += new System.EventHandler(this.btnAgregarIncidente_Click);
            // 
            // btnVerIncidentes
            // 
            this.btnVerIncidentes.Location = new System.Drawing.Point(846, 144);
            this.btnVerIncidentes.Name = "btnVerIncidentes";
            this.btnVerIncidentes.Size = new System.Drawing.Size(75, 39);
            this.btnVerIncidentes.TabIndex = 36;
            this.btnVerIncidentes.Text = "Ver Incidentes";
            this.btnVerIncidentes.UseVisualStyleBackColor = true;
            this.btnVerIncidentes.Click += new System.EventHandler(this.btnVerIncidentes_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnVerIncidentes);
            this.Controls.Add(this.btnAgregarIncidente);
            this.Controls.Add(this.lblIncidentes);
            this.Controls.Add(this.label3);
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
            this.Controls.Add(this.lstVariables);
            this.Controls.Add(this.lblVariables);
            this.Controls.Add(this.lblTableroControl);
            this.Controls.Add(this.lblPlantaDeProduccion);
            this.Controls.Add(this.treeViewPlantaDeProduccion);
            this.Controls.Add(this.lblMenuPrincipal);
            this.Controls.Add(this.menuOpciones);
            this.Name = "MenuPrincipal";
            this.Size = new System.Drawing.Size(972, 571);
            this.menuOpciones.ResumeLayout(false);
            this.menuOpciones.PerformLayout();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuOpciones;
        private System.Windows.Forms.ToolStripMenuItem plantasIndustrialesMenu;
        private System.Windows.Forms.ToolStripMenuItem btnAgregarPlantaIndustrial;
        private System.Windows.Forms.ToolStripMenuItem btnEliminarPlantaIndustrial;
        private System.Windows.Forms.ToolStripMenuItem btnEditarPlantaIndustrial;
        private System.Windows.Forms.ToolStripMenuItem instalacionesMenu;
        private System.Windows.Forms.ToolStripMenuItem btnAgregarInstalacion;
        private System.Windows.Forms.ToolStripMenuItem btnEliminarInstalacion;
        private System.Windows.Forms.ToolStripMenuItem btnEditarInstalacion;
        private System.Windows.Forms.ToolStripMenuItem dispositivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnAgregarDispositivo;
        private System.Windows.Forms.ToolStripMenuItem btnEliminarDispositivo;
        private System.Windows.Forms.ToolStripMenuItem btnEditarDispositivo;
        private System.Windows.Forms.Label lblIncidentes;
        private System.Windows.Forms.Button btnAgregarIncidente;
        private System.Windows.Forms.Button btnVerIncidentes;
    }
}
