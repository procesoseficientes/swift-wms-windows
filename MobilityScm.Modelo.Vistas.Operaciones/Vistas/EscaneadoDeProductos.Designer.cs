namespace MobilityScm.Modelo.Vistas.Operaciones.Vistas
{
    partial class EscaneadoDeProductos
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UiVistaContenido = new Resco.Controls.DetailView.DetailView();
            this.UiSeparador = new Resco.Controls.DetailView.Item();
            this.UiEtiquetaEncabezado = new Resco.Controls.DetailView.Item();
            this.UiTextoLicencia = new Resco.Controls.DetailView.ItemTextBox();
            this.UiTextoMaterial = new Resco.Controls.DetailView.ItemTextBox();
            this.UiTextoCantidad = new Resco.Controls.DetailView.ItemNumeric();
            this.UiPanelBotones = new Resco.Controls.CommonControls.TouchPanel();
            this.UiBotonUbicar = new Resco.Controls.OutlookControls.ImageButton();
            this.UiBotonCancelar = new Resco.Controls.OutlookControls.ImageButton();
            this.UiBotonImprimirLicencia = new Resco.Controls.OutlookControls.ImageButton();
            this.UiBotonDetalle = new Resco.Controls.OutlookControls.ImageButton();
            this.UiPanelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonUbicar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonImprimirLicencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // UiVistaContenido
            // 
            this.UiVistaContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UiVistaContenido.DisabledForeColor = System.Drawing.Color.Gray;
            this.UiVistaContenido.EnableDesignTimeCustomItems = true;
            this.UiVistaContenido.ForeColor = System.Drawing.Color.White;
            this.UiVistaContenido.GradientBackColor = new Resco.Controls.DetailView.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.DetailView.FillDirection.Vertical);
            this.UiVistaContenido.Items.Add(this.UiSeparador);
            this.UiVistaContenido.Items.Add(this.UiEtiquetaEncabezado);
            this.UiVistaContenido.Items.Add(this.UiTextoLicencia);
            this.UiVistaContenido.Items.Add(this.UiTextoMaterial);
            this.UiVistaContenido.Items.Add(this.UiTextoCantidad);
            this.UiVistaContenido.KeyNavigation = true;
            this.UiVistaContenido.KeyTabNavigation = true;
            this.UiVistaContenido.LabelWidth = 90;
            this.UiVistaContenido.Location = new System.Drawing.Point(0, 0);
            this.UiVistaContenido.Name = "UiVistaContenido";
            this.UiVistaContenido.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.Dots;
            this.UiVistaContenido.SeparatorWidth = 0;
            this.UiVistaContenido.Size = new System.Drawing.Size(240, 299);
            this.UiVistaContenido.TabIndex = 5;
            this.UiVistaContenido.TabStop = false;
            this.UiVistaContenido.TouchScrolling = true;
            this.UiVistaContenido.UseClickVisualize = true;
            this.UiVistaContenido.UseGradient = true;
            this.UiVistaContenido.ItemGotFocus += new Resco.Controls.DetailView.ItemEventHandler(this.UiVistaContenido_ItemGotFocus);
            this.UiVistaContenido.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaContenido_KeyUp);
            // 
            // UiSeparador
            // 
            this.UiSeparador.Height = 0;
            this.UiSeparador.ItemBorder = Resco.Controls.DetailView.ItemBorder.None;
            this.UiSeparador.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.UiSeparador.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(95)))), ((int)(((byte)(0)))));
            this.UiSeparador.LabelHeight = 3;
            this.UiSeparador.Name = "UiSeparador";
            this.UiSeparador.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiSeparador.TextBackColor = System.Drawing.Color.Black;
            // 
            // UiEtiquetaEncabezado
            // 
            this.UiEtiquetaEncabezado.Height = 0;
            this.UiEtiquetaEncabezado.ItemBorder = Resco.Controls.DetailView.ItemBorder.None;
            this.UiEtiquetaEncabezado.Label = "Escanear Componente";
            this.UiEtiquetaEncabezado.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiEtiquetaEncabezado.LabelBackColor = System.Drawing.Color.Black;
            this.UiEtiquetaEncabezado.LabelForeColor = System.Drawing.Color.White;
            this.UiEtiquetaEncabezado.LabelHeight = 24;
            this.UiEtiquetaEncabezado.Name = "UiEtiquetaEncabezado";
            this.UiEtiquetaEncabezado.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiEtiquetaEncabezado.TextBackColor = System.Drawing.Color.White;
            // 
            // UiTextoLicencia
            // 
            this.UiTextoLicencia.CharacterCasing = Resco.Controls.DetailView.ItemTextBoxCharacterCasing.Upper;
            this.UiTextoLicencia.Height = 24;
            this.UiTextoLicencia.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiTextoLicencia.Label = "Licencia";
            this.UiTextoLicencia.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoLicencia.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiTextoLicencia.LabelHeight = 24;
            this.UiTextoLicencia.Name = "UiTextoLicencia";
            this.UiTextoLicencia.ReadOnly = true;
            this.UiTextoLicencia.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoLicencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoLicencia.TextForeColor = System.Drawing.Color.DarkOrange;
            // 
            // UiTextoMaterial
            // 
            this.UiTextoMaterial.Height = 24;
            this.UiTextoMaterial.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiTextoMaterial.Label = "Material";
            this.UiTextoMaterial.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoMaterial.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiTextoMaterial.LabelHeight = 24;
            this.UiTextoMaterial.Name = "UiTextoMaterial";
            this.UiTextoMaterial.ReadOnly = true;
            this.UiTextoMaterial.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoMaterial.TextForeColor = System.Drawing.Color.DarkOrange;
            // 
            // UiTextoCantidad
            // 
            this.UiTextoCantidad.Height = 24;
            this.UiTextoCantidad.Label = "Cantidad";
            this.UiTextoCantidad.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoCantidad.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiTextoCantidad.Name = "UiTextoCantidad";
            this.UiTextoCantidad.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoCantidad.TextForeColor = System.Drawing.Color.DarkOrange;
            // 
            // UiPanelBotones
            // 
            this.UiPanelBotones.Controls.Add(this.UiBotonUbicar);
            this.UiPanelBotones.Controls.Add(this.UiBotonCancelar);
            this.UiPanelBotones.Controls.Add(this.UiBotonImprimirLicencia);
            this.UiPanelBotones.Controls.Add(this.UiBotonDetalle);
            this.UiPanelBotones.GradientBackColor = new Resco.Controls.CommonControls.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.CommonControls.FillDirection.Horizontal);
            this.UiPanelBotones.Location = new System.Drawing.Point(0, 297);
            this.UiPanelBotones.Name = "UiPanelBotones";
            this.UiPanelBotones.Size = new System.Drawing.Size(240, 103);
            // 
            // UiBotonUbicar
            // 
            this.UiBotonUbicar.BackColor = System.Drawing.Color.Black;
            this.UiBotonUbicar.BorderColor = System.Drawing.Color.Orange;
            this.UiBotonUbicar.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonUbicar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.UiBotonUbicar.ForeColor = System.Drawing.Color.White;
            this.UiBotonUbicar.Location = new System.Drawing.Point(180, 30);
            this.UiBotonUbicar.Name = "UiBotonUbicar";
            this.UiBotonUbicar.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonUbicar.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonUbicar.Size = new System.Drawing.Size(60, 73);
            this.UiBotonUbicar.TabIndex = 26;
            this.UiBotonUbicar.Text = "Ubicar";
            this.UiBotonUbicar.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonUbicar.WordWrap = true;
            this.UiBotonUbicar.Click += new System.EventHandler(this.UiBotonUbicar_Click);
            // 
            // UiBotonCancelar
            // 
            this.UiBotonCancelar.BackColor = System.Drawing.Color.Black;
            this.UiBotonCancelar.BorderColor = System.Drawing.Color.Orange;
            this.UiBotonCancelar.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonCancelar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.UiBotonCancelar.ForeColor = System.Drawing.Color.White;
            this.UiBotonCancelar.Location = new System.Drawing.Point(0, 30);
            this.UiBotonCancelar.Name = "UiBotonCancelar";
            this.UiBotonCancelar.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonCancelar.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonCancelar.Size = new System.Drawing.Size(60, 73);
            this.UiBotonCancelar.TabIndex = 25;
            this.UiBotonCancelar.Text = "Cancelar";
            this.UiBotonCancelar.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonCancelar.WordWrap = true;
            this.UiBotonCancelar.Click += new System.EventHandler(this.UiBotonCancelar_Click);
            // 
            // UiBotonImprimirLicencia
            // 
            this.UiBotonImprimirLicencia.BackColor = System.Drawing.Color.Black;
            this.UiBotonImprimirLicencia.BorderColor = System.Drawing.Color.Orange;
            this.UiBotonImprimirLicencia.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonImprimirLicencia.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.UiBotonImprimirLicencia.ForeColor = System.Drawing.Color.White;
            this.UiBotonImprimirLicencia.Location = new System.Drawing.Point(60, 30);
            this.UiBotonImprimirLicencia.Name = "UiBotonImprimirLicencia";
            this.UiBotonImprimirLicencia.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonImprimirLicencia.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonImprimirLicencia.Size = new System.Drawing.Size(60, 73);
            this.UiBotonImprimirLicencia.TabIndex = 24;
            this.UiBotonImprimirLicencia.Text = "Imprimir Licencia";
            this.UiBotonImprimirLicencia.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonImprimirLicencia.WordWrap = true;
            this.UiBotonImprimirLicencia.Click += new System.EventHandler(this.UiBotonImprimirLicencia_Click);
            // 
            // UiBotonDetalle
            // 
            this.UiBotonDetalle.BackColor = System.Drawing.Color.Black;
            this.UiBotonDetalle.BorderColor = System.Drawing.Color.Orange;
            this.UiBotonDetalle.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonDetalle.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.UiBotonDetalle.ForeColor = System.Drawing.Color.White;
            this.UiBotonDetalle.Location = new System.Drawing.Point(120, 30);
            this.UiBotonDetalle.Name = "UiBotonDetalle";
            this.UiBotonDetalle.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonDetalle.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonDetalle.Size = new System.Drawing.Size(60, 73);
            this.UiBotonDetalle.TabIndex = 23;
            this.UiBotonDetalle.Text = "Detalle";
            this.UiBotonDetalle.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonDetalle.WordWrap = true;
            this.UiBotonDetalle.Click += new System.EventHandler(this.UiBotonDetalle_Click);
            // 
            // EscaneadoDeProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.UiPanelBotones);
            this.Controls.Add(this.UiVistaContenido);
            this.Name = "EscaneadoDeProductos";
            this.Size = new System.Drawing.Size(240, 400);
            this.UiPanelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonUbicar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonImprimirLicencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Resco.Controls.DetailView.DetailView UiVistaContenido;
        private Resco.Controls.CommonControls.TouchPanel UiPanelBotones;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonUbicar;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonCancelar;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonImprimirLicencia;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonDetalle;
        private Resco.Controls.DetailView.Item UiSeparador;
        private Resco.Controls.DetailView.Item UiEtiquetaEncabezado;
        private Resco.Controls.DetailView.ItemTextBox UiTextoLicencia;
        private Resco.Controls.DetailView.ItemTextBox UiTextoMaterial;
        private Resco.Controls.DetailView.ItemNumeric UiTextoCantidad;
    }
}
