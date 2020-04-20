namespace MobilityScm.Modelo.Vistas.Operaciones.Vistas
{
    partial class UbicarImplosion
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
            this.UiVistaEncabezado = new Resco.Controls.DetailView.DetailView();
            this.UiSeparador = new Resco.Controls.DetailView.Item();
            this.UiEtiquetaEncabezado = new Resco.Controls.DetailView.Item();
            this.UiTextoUbicacion = new Resco.Controls.DetailView.ItemTextBox();
            this.UiPanelBoton = new Resco.Controls.CommonControls.TouchPanel();
            this.UiBotonUbicar = new Resco.Controls.OutlookControls.ImageButton();
            this.UiListaUbicacion = new Resco.Controls.AdvancedList.AdvancedList();
            this.UiPanelBoton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonUbicar)).BeginInit();
            this.SuspendLayout();
            // 
            // UiVistaEncabezado
            // 
            this.UiVistaEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UiVistaEncabezado.DisabledForeColor = System.Drawing.Color.Gray;
            this.UiVistaEncabezado.EnableDesignTimeCustomItems = true;
            this.UiVistaEncabezado.ForeColor = System.Drawing.Color.White;
            this.UiVistaEncabezado.GradientBackColor = new Resco.Controls.DetailView.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70))))), System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))), Resco.Controls.DetailView.FillDirection.Vertical);
            this.UiVistaEncabezado.Items.Add(this.UiSeparador);
            this.UiVistaEncabezado.Items.Add(this.UiEtiquetaEncabezado);
            this.UiVistaEncabezado.Items.Add(this.UiTextoUbicacion);
            this.UiVistaEncabezado.KeyNavigation = true;
            this.UiVistaEncabezado.KeyTabNavigation = true;
            this.UiVistaEncabezado.LabelWidth = 90;
            this.UiVistaEncabezado.Location = new System.Drawing.Point(0, 0);
            this.UiVistaEncabezado.Name = "UiVistaEncabezado";
            this.UiVistaEncabezado.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.Dots;
            this.UiVistaEncabezado.SeparatorWidth = 0;
            this.UiVistaEncabezado.Size = new System.Drawing.Size(240, 123);
            this.UiVistaEncabezado.TabIndex = 5;
            this.UiVistaEncabezado.TabStop = false;
            this.UiVistaEncabezado.TouchScrolling = true;
            this.UiVistaEncabezado.UseClickVisualize = true;
            this.UiVistaEncabezado.UseGradient = true;
            this.UiVistaEncabezado.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaEncabezado_KeyUp);
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
            this.UiEtiquetaEncabezado.Label = "Ubicación";
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
            this.UiTextoUbicacion.Label = "Escanear Ubicación";
            this.UiTextoUbicacion.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoUbicacion.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiTextoUbicacion.LabelHeight = 24;
            this.UiTextoUbicacion.Name = "UiTextoUbicacion";
            this.UiTextoUbicacion.ReadOnly = true;
            this.UiTextoUbicacion.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoUbicacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoUbicacion.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.UiTextoUbicacion.TextForeColor = System.Drawing.Color.DarkOrange;
            // 
            // UiPanelBoton
            // 
            this.UiPanelBoton.Controls.Add(this.UiBotonUbicar);
            this.UiPanelBoton.Controls.Add(this.UiListaUbicacion);
            this.UiPanelBoton.GradientBackColor = new Resco.Controls.CommonControls.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))), System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30))))), Resco.Controls.CommonControls.FillDirection.Vertical);
            this.UiPanelBoton.Location = new System.Drawing.Point(0, 120);
            this.UiPanelBoton.Name = "UiPanelBoton";
            this.UiPanelBoton.Size = new System.Drawing.Size(240, 280);
            this.UiPanelBoton.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiPanelBoton_KeyUp);
            // 
            // UiBotonUbicar
            // 
            this.UiBotonUbicar.BackColor = System.Drawing.Color.Black;
            this.UiBotonUbicar.BorderColor = System.Drawing.Color.Orange;
            this.UiBotonUbicar.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonUbicar.DisabledForeColor = System.Drawing.Color.Gray;
            this.UiBotonUbicar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.UiBotonUbicar.ForeColor = System.Drawing.Color.White;
            this.UiBotonUbicar.Location = new System.Drawing.Point(15, 9);
            this.UiBotonUbicar.Name = "UiBotonUbicar";
            this.UiBotonUbicar.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonUbicar.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonUbicar.Size = new System.Drawing.Size(208, 129);
            this.UiBotonUbicar.TabIndex = 24;
            this.UiBotonUbicar.Text = "OK";
            this.UiBotonUbicar.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonUbicar.WordWrap = true;
            this.UiBotonUbicar.Click += new System.EventHandler(this.UiBotonUbicar_Click);
            this.UiBotonUbicar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiBotonUbicar_KeyUp);
            // 
            // UiListaUbicacion
            // 
            this.UiListaUbicacion.BackColor = System.Drawing.Color.Transparent;
            this.UiListaUbicacion.DataRows.Clear();
            this.UiListaUbicacion.GradientBackColor = new Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30))))), System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30))))), System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30))))), System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30))))), Resco.Controls.AdvancedList.FillDirection.Horizontal);
            this.UiListaUbicacion.GridColor = System.Drawing.Color.Transparent;
            this.UiListaUbicacion.Location = new System.Drawing.Point(0, 250);
            this.UiListaUbicacion.Name = "UiListaUbicacion";
            this.UiListaUbicacion.Size = new System.Drawing.Size(237, 30);
            this.UiListaUbicacion.TabIndex = 4;
            this.UiListaUbicacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiListaUbicacion_KeyUp);
            // 
            // UbicarImplosion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.UiPanelBoton);
            this.Controls.Add(this.UiVistaEncabezado);
            this.Name = "UbicarImplosion";
            this.Size = new System.Drawing.Size(240, 400);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UbicarImplosion_KeyUp);
            this.UiPanelBoton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonUbicar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Resco.Controls.DetailView.DetailView UiVistaEncabezado;
        private Resco.Controls.CommonControls.TouchPanel UiPanelBoton;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonUbicar;
        private Resco.Controls.DetailView.Item UiSeparador;
        private Resco.Controls.DetailView.Item UiEtiquetaEncabezado;
        private Resco.Controls.DetailView.ItemTextBox UiTextoUbicacion;
        private Resco.Controls.AdvancedList.AdvancedList UiListaUbicacion;

    }
}
