namespace MobilityScm.Modelo.Vistas.Operaciones.Vistas
{
    partial class EscaneadoDeUnificacion
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
            this.UiPanelBotones = new Resco.Controls.CommonControls.TouchPanel();
            this.UiBotonUnificarLicencias = new Resco.Controls.OutlookControls.ImageButton();
            this.UiBotonDetalle = new Resco.Controls.OutlookControls.ImageButton();
            this.UiVistaContenidos = new Resco.Controls.DetailView.DetailView();
            this.UiSeparador = new Resco.Controls.DetailView.Item();
            this.UiEtiquetaEncabezado = new Resco.Controls.DetailView.Item();
            this.UiTextoUbicacion = new Resco.Controls.DetailView.ItemTextBox();
            this.UiTextoMaterial = new Resco.Controls.DetailView.ItemTextBox();
            this.UiTextoDescripcion = new Resco.Controls.DetailView.ItemTextBox();
            this.UiPanelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonUnificarLicencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // UiPanelBotones
            // 
            this.UiPanelBotones.Controls.Add(this.UiBotonUnificarLicencias);
            this.UiPanelBotones.Controls.Add(this.UiBotonDetalle);
            this.UiPanelBotones.GradientBackColor = new Resco.Controls.CommonControls.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.CommonControls.FillDirection.Horizontal);
            this.UiPanelBotones.Location = new System.Drawing.Point(0, 297);
            this.UiPanelBotones.Name = "UiPanelBotones";
            this.UiPanelBotones.Size = new System.Drawing.Size(240, 103);
            this.UiPanelBotones.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiPanelBotones_KeyUp);
            // 
            // UiBotonUnificarLicencias
            // 
            this.UiBotonUnificarLicencias.BackColor = System.Drawing.Color.Black;
            this.UiBotonUnificarLicencias.BorderColor = System.Drawing.Color.Orange;
            this.UiBotonUnificarLicencias.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonUnificarLicencias.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.UiBotonUnificarLicencias.ForeColor = System.Drawing.Color.White;
            this.UiBotonUnificarLicencias.Location = new System.Drawing.Point(156, 27);
            this.UiBotonUnificarLicencias.Name = "UiBotonUnificarLicencias";
            this.UiBotonUnificarLicencias.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonUnificarLicencias.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonUnificarLicencias.Size = new System.Drawing.Size(81, 73);
            this.UiBotonUnificarLicencias.TabIndex = 27;
            this.UiBotonUnificarLicencias.Text = "Unificar Licencias";
            this.UiBotonUnificarLicencias.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonUnificarLicencias.WordWrap = true;
            this.UiBotonUnificarLicencias.Click += new System.EventHandler(this.UiBotonUnificarLicencias_Click);
            // 
            // UiBotonDetalle
            // 
            this.UiBotonDetalle.BackColor = System.Drawing.Color.Black;
            this.UiBotonDetalle.BorderColor = System.Drawing.Color.Orange;
            this.UiBotonDetalle.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonDetalle.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.UiBotonDetalle.ForeColor = System.Drawing.Color.White;
            this.UiBotonDetalle.Location = new System.Drawing.Point(3, 27);
            this.UiBotonDetalle.Name = "UiBotonDetalle";
            this.UiBotonDetalle.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonDetalle.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonDetalle.Size = new System.Drawing.Size(81, 73);
            this.UiBotonDetalle.TabIndex = 26;
            this.UiBotonDetalle.Text = "Detalle";
            this.UiBotonDetalle.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonDetalle.WordWrap = true;
            this.UiBotonDetalle.Click += new System.EventHandler(this.UiBotonDetalle_Click);
            this.UiBotonDetalle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiBotonDetalle_KeyUp);
            // 
            // UiVistaContenidos
            // 
            this.UiVistaContenidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UiVistaContenidos.DisabledForeColor = System.Drawing.Color.Gray;
            this.UiVistaContenidos.EnableDesignTimeCustomItems = true;
            this.UiVistaContenidos.ForeColor = System.Drawing.Color.White;
            this.UiVistaContenidos.GradientBackColor = new Resco.Controls.DetailView.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.DetailView.FillDirection.Vertical);
            this.UiVistaContenidos.Items.Add(this.UiSeparador);
            this.UiVistaContenidos.Items.Add(this.UiEtiquetaEncabezado);
            this.UiVistaContenidos.Items.Add(this.UiTextoUbicacion);
            this.UiVistaContenidos.Items.Add(this.UiTextoMaterial);
            this.UiVistaContenidos.Items.Add(this.UiTextoDescripcion);
            this.UiVistaContenidos.KeyNavigation = true;
            this.UiVistaContenidos.KeyTabNavigation = true;
            this.UiVistaContenidos.LabelWidth = 90;
            this.UiVistaContenidos.Location = new System.Drawing.Point(0, 0);
            this.UiVistaContenidos.Name = "UiVistaContenidos";
            this.UiVistaContenidos.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.Dots;
            this.UiVistaContenidos.SeparatorWidth = 0;
            this.UiVistaContenidos.Size = new System.Drawing.Size(240, 299);
            this.UiVistaContenidos.TabIndex = 5;
            this.UiVistaContenidos.TabStop = false;
            this.UiVistaContenidos.TouchScrolling = true;
            this.UiVistaContenidos.UseClickVisualize = true;
            this.UiVistaContenidos.UseGradient = true;
            this.UiVistaContenidos.ItemGotFocus += new Resco.Controls.DetailView.ItemEventHandler(this.UiVistaContenidos_ItemGotFocus);
            this.UiVistaContenidos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaContenidos_KeyUp);
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
            this.UiEtiquetaEncabezado.Label = "Escanear Ubicación";
            this.UiEtiquetaEncabezado.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiEtiquetaEncabezado.LabelBackColor = System.Drawing.Color.Black;
            this.UiEtiquetaEncabezado.LabelForeColor = System.Drawing.Color.White;
            this.UiEtiquetaEncabezado.LabelHeight = 24;
            this.UiEtiquetaEncabezado.Name = "UiEtiquetaEncabezado";
            this.UiEtiquetaEncabezado.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiEtiquetaEncabezado.TextBackColor = System.Drawing.Color.White;
            // 
            // UiTextoUbicacion
            // 
            this.UiTextoUbicacion.CharacterCasing = Resco.Controls.DetailView.ItemTextBoxCharacterCasing.Upper;
            this.UiTextoUbicacion.Height = 24;
            this.UiTextoUbicacion.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiTextoUbicacion.Label = "Ubicación";
            this.UiTextoUbicacion.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoUbicacion.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiTextoUbicacion.LabelHeight = 24;
            this.UiTextoUbicacion.Name = "UiTextoUbicacion";
            this.UiTextoUbicacion.ReadOnly = true;
            this.UiTextoUbicacion.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoUbicacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoUbicacion.TextForeColor = System.Drawing.Color.DarkOrange;
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
            // UiTextoDescripcion
            // 
            this.UiTextoDescripcion.Height = 24;
            this.UiTextoDescripcion.Label = "Descripción";
            this.UiTextoDescripcion.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoDescripcion.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiTextoDescripcion.LabelHeight = 24;
            this.UiTextoDescripcion.MultiLine = true;
            this.UiTextoDescripcion.Name = "UiTextoDescripcion";
            this.UiTextoDescripcion.ReadOnly = true;
            this.UiTextoDescripcion.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoDescripcion.TextForeColor = System.Drawing.Color.DarkOrange;
            this.UiTextoDescripcion.WordWrap = true;
            // 
            // EscaneadoDeUnificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.UiVistaContenidos);
            this.Controls.Add(this.UiPanelBotones);
            this.Name = "EscaneadoDeUnificacion";
            this.Size = new System.Drawing.Size(240, 400);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EscaneadoDeUnificacion_KeyUp);
            this.UiPanelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonUnificarLicencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Resco.Controls.CommonControls.TouchPanel UiPanelBotones;
        private Resco.Controls.DetailView.DetailView UiVistaContenidos;
        private Resco.Controls.DetailView.Item UiSeparador;
        private Resco.Controls.DetailView.Item UiEtiquetaEncabezado;
        private Resco.Controls.DetailView.ItemTextBox UiTextoUbicacion;
        private Resco.Controls.DetailView.ItemTextBox UiTextoMaterial;
        private Resco.Controls.DetailView.ItemTextBox UiTextoDescripcion;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonDetalle;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonUnificarLicencias;
    }
}
