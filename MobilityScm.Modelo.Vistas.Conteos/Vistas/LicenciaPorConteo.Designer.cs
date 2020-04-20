namespace MobilityScm.Modelo.Vistas
{
    partial class LicenciaPorConteo
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
            this.UiVistaLicenciaPorConteo = new Resco.Controls.DetailView.DetailView();
            this.UiBotonFinalizarUbicacion = new Resco.Controls.OutlookControls.ImageButton();
            this.UiPanelProductos = new Resco.Controls.CommonControls.TouchPanel();
            this.UiListaMateriales = new Resco.Controls.AdvancedList.AdvancedList();
            this.Material = new Resco.Controls.AdvancedList.RowTemplate();
            this.MATERIAL_ID = new Resco.Controls.AdvancedList.TextCell();
            this.MATERIAL_NAME = new Resco.Controls.AdvancedList.TextCell();
            this.UiBotonMostraSku = new Resco.Controls.OutlookControls.ImageButton();
            this.UiBotonLimpiarLicencia = new Resco.Controls.OutlookControls.ImageButton();
            this.UiSeparador = new Resco.Controls.DetailView.Item();
            this.UiEtiquetaEncabezado = new Resco.Controls.DetailView.Item();
            this.UiEtiquetaUbicacion = new Resco.Controls.DetailView.Item();
            this.UiEtiquetaLicencia = new Resco.Controls.DetailView.Item();
            this.UiEtiquetaMaterial = new Resco.Controls.DetailView.Item();
            this.UiTextoLote = new Resco.Controls.DetailView.ItemTextBox();
            this.UiFechaDeExpiracion = new Resco.Controls.DetailView.ItemDateTime();
            this.UiTextoCantidad = new Resco.Controls.DetailView.ItemTextBox();
            this.UiTextoSerie = new Resco.Controls.DetailView.ItemTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonFinalizarUbicacion)).BeginInit();
            this.UiPanelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonMostraSku)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonLimpiarLicencia)).BeginInit();
            this.SuspendLayout();
            // 
            // UiVistaLicenciaPorConteo
            // 
            this.UiVistaLicenciaPorConteo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UiVistaLicenciaPorConteo.DisabledForeColor = System.Drawing.Color.Gray;
            this.UiVistaLicenciaPorConteo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiVistaLicenciaPorConteo.EnableDesignTimeCustomItems = true;
            this.UiVistaLicenciaPorConteo.ForeColor = System.Drawing.Color.White;
            this.UiVistaLicenciaPorConteo.GradientBackColor = new Resco.Controls.DetailView.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.DetailView.FillDirection.Vertical);
            this.UiVistaLicenciaPorConteo.Items.Add(this.UiSeparador);
            this.UiVistaLicenciaPorConteo.Items.Add(this.UiEtiquetaEncabezado);
            this.UiVistaLicenciaPorConteo.Items.Add(this.UiEtiquetaUbicacion);
            this.UiVistaLicenciaPorConteo.Items.Add(this.UiEtiquetaLicencia);
            this.UiVistaLicenciaPorConteo.Items.Add(this.UiEtiquetaMaterial);
            this.UiVistaLicenciaPorConteo.Items.Add(this.UiTextoLote);
            this.UiVistaLicenciaPorConteo.Items.Add(this.UiFechaDeExpiracion);
            this.UiVistaLicenciaPorConteo.Items.Add(this.UiTextoCantidad);
            this.UiVistaLicenciaPorConteo.Items.Add(this.UiTextoSerie);
            this.UiVistaLicenciaPorConteo.KeyNavigation = true;
            this.UiVistaLicenciaPorConteo.KeyTabNavigation = true;
            this.UiVistaLicenciaPorConteo.LabelWidth = 90;
            this.UiVistaLicenciaPorConteo.Location = new System.Drawing.Point(0, 0);
            this.UiVistaLicenciaPorConteo.Name = "UiVistaLicenciaPorConteo";
            this.UiVistaLicenciaPorConteo.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.Dots;
            this.UiVistaLicenciaPorConteo.SeparatorWidth = 0;
            this.UiVistaLicenciaPorConteo.Size = new System.Drawing.Size(240, 400);
            this.UiVistaLicenciaPorConteo.TabIndex = 4;
            this.UiVistaLicenciaPorConteo.TabStop = false;
            this.UiVistaLicenciaPorConteo.TouchScrolling = true;
            this.UiVistaLicenciaPorConteo.UseClickVisualize = true;
            this.UiVistaLicenciaPorConteo.UseGradient = true;
            this.UiVistaLicenciaPorConteo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaLicenciaPorConteo_KeyUp);
            // 
            // UiBotonFinalizarUbicacion
            // 
            this.UiBotonFinalizarUbicacion.BackColor = System.Drawing.Color.Black;
            this.UiBotonFinalizarUbicacion.BorderColor = System.Drawing.Color.Orange;
            this.UiBotonFinalizarUbicacion.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonFinalizarUbicacion.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.UiBotonFinalizarUbicacion.ForeColor = System.Drawing.Color.White;
            this.UiBotonFinalizarUbicacion.Location = new System.Drawing.Point(170, 322);
            this.UiBotonFinalizarUbicacion.Name = "UiBotonFinalizarUbicacion";
            this.UiBotonFinalizarUbicacion.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonFinalizarUbicacion.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonFinalizarUbicacion.Size = new System.Drawing.Size(67, 75);
            this.UiBotonFinalizarUbicacion.TabIndex = 19;
            this.UiBotonFinalizarUbicacion.Text = "Finalizar Ubicación";
            this.UiBotonFinalizarUbicacion.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonFinalizarUbicacion.WordWrap = true;
            this.UiBotonFinalizarUbicacion.Click += new System.EventHandler(this.UiBotonFinalizarUbicacion_Click);
            this.UiBotonFinalizarUbicacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaLicenciaPorConteo_KeyUp);
            // 
            // UiPanelProductos
            // 
            this.UiPanelProductos.Controls.Add(this.UiListaMateriales);
            this.UiPanelProductos.Location = new System.Drawing.Point(16, 38);
            this.UiPanelProductos.Name = "UiPanelProductos";
            this.UiPanelProductos.Size = new System.Drawing.Size(210, 277);
            this.UiPanelProductos.Visible = false;
            // 
            // UiListaMateriales
            // 
            this.UiListaMateriales.DataRows.Clear();
            this.UiListaMateriales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiListaMateriales.GradientBackColor = new Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.AdvancedList.FillDirection.Horizontal);
            this.UiListaMateriales.Location = new System.Drawing.Point(0, 0);
            this.UiListaMateriales.Name = "UiListaMateriales";
            this.UiListaMateriales.Size = new System.Drawing.Size(210, 277);
            this.UiListaMateriales.TabIndex = 3;
            this.UiListaMateriales.Templates.Add(this.Material);
            // 
            // Material
            // 
            this.Material.BackColor = System.Drawing.Color.Transparent;
            this.Material.CellTemplates.Add(this.MATERIAL_ID);
            this.Material.CellTemplates.Add(this.MATERIAL_NAME);
            this.Material.Height = 42;
            this.Material.Name = "Material";
            // 
            // MATERIAL_ID
            // 
            this.MATERIAL_ID.CellSource.ColumnName = "MATERIAL_ID";
            this.MATERIAL_ID.DesignName = "MATERIAL_ID";
            this.MATERIAL_ID.ForeColor = System.Drawing.Color.White;
            this.MATERIAL_ID.FormatString = "Código: {0}";
            this.MATERIAL_ID.Location = new System.Drawing.Point(1, 4);
            this.MATERIAL_ID.Name = "MATERIAL_ID";
            this.MATERIAL_ID.Size = new System.Drawing.Size(239, 16);
            this.MATERIAL_ID.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            // 
            // MATERIAL_NAME
            // 
            this.MATERIAL_NAME.CellSource.ColumnName = "MATERIAL_NAME";
            this.MATERIAL_NAME.DesignName = "MATERIAL_NAME";
            this.MATERIAL_NAME.ForeColor = System.Drawing.Color.White;
            this.MATERIAL_NAME.Location = new System.Drawing.Point(1, 22);
            this.MATERIAL_NAME.Name = "MATERIAL_NAME";
            this.MATERIAL_NAME.Size = new System.Drawing.Size(239, 19);
            // 
            // UiBotonMostraSku
            // 
            this.UiBotonMostraSku.BackColor = System.Drawing.Color.Black;
            this.UiBotonMostraSku.BorderColor = System.Drawing.Color.Orange;
            this.UiBotonMostraSku.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonMostraSku.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.UiBotonMostraSku.ForeColor = System.Drawing.Color.White;
            this.UiBotonMostraSku.Location = new System.Drawing.Point(3, 322);
            this.UiBotonMostraSku.Name = "UiBotonMostraSku";
            this.UiBotonMostraSku.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonMostraSku.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonMostraSku.Size = new System.Drawing.Size(78, 75);
            this.UiBotonMostraSku.TabIndex = 21;
            this.UiBotonMostraSku.Text = "Materiales";
            this.UiBotonMostraSku.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonMostraSku.WordWrap = true;
            this.UiBotonMostraSku.Click += new System.EventHandler(this.UiBotonMostraSku_Click);
            // 
            // UiBotonLimpiarLicencia
            // 
            this.UiBotonLimpiarLicencia.BackColor = System.Drawing.Color.Black;
            this.UiBotonLimpiarLicencia.BorderColor = System.Drawing.Color.Orange;
            this.UiBotonLimpiarLicencia.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonLimpiarLicencia.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.UiBotonLimpiarLicencia.ForeColor = System.Drawing.Color.White;
            this.UiBotonLimpiarLicencia.Location = new System.Drawing.Point(90, 322);
            this.UiBotonLimpiarLicencia.Name = "UiBotonLimpiarLicencia";
            this.UiBotonLimpiarLicencia.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonLimpiarLicencia.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonLimpiarLicencia.Size = new System.Drawing.Size(74, 75);
            this.UiBotonLimpiarLicencia.TabIndex = 23;
            this.UiBotonLimpiarLicencia.Text = "Limpiar licencia";
            this.UiBotonLimpiarLicencia.Visible = false;
            this.UiBotonLimpiarLicencia.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonLimpiarLicencia.WordWrap = true;
            this.UiBotonLimpiarLicencia.Click += new System.EventHandler(this.UiBotonLimpiarLicencia_Click);
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
            this.UiEtiquetaEncabezado.Label = "Escanear Licencia";
            this.UiEtiquetaEncabezado.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiEtiquetaEncabezado.LabelBackColor = System.Drawing.Color.Black;
            this.UiEtiquetaEncabezado.LabelForeColor = System.Drawing.Color.White;
            this.UiEtiquetaEncabezado.LabelHeight = 24;
            this.UiEtiquetaEncabezado.Name = "UiEtiquetaEncabezado";
            this.UiEtiquetaEncabezado.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiEtiquetaEncabezado.TextBackColor = System.Drawing.Color.White;
            // 
            // UiEtiquetaUbicacion
            // 
            this.UiEtiquetaUbicacion.Height = 0;
            this.UiEtiquetaUbicacion.ItemBorder = Resco.Controls.DetailView.ItemBorder.None;
            this.UiEtiquetaUbicacion.Label = "Ubicación";
            this.UiEtiquetaUbicacion.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiEtiquetaUbicacion.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiEtiquetaUbicacion.LabelHeight = 24;
            this.UiEtiquetaUbicacion.Name = "UiEtiquetaUbicacion";
            this.UiEtiquetaUbicacion.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            // 
            // UiEtiquetaLicencia
            // 
            this.UiEtiquetaLicencia.Height = 0;
            this.UiEtiquetaLicencia.ItemBorder = Resco.Controls.DetailView.ItemBorder.None;
            this.UiEtiquetaLicencia.Label = "Licencia";
            this.UiEtiquetaLicencia.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiEtiquetaLicencia.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiEtiquetaLicencia.LabelHeight = 24;
            this.UiEtiquetaLicencia.Name = "UiEtiquetaLicencia";
            this.UiEtiquetaLicencia.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            // 
            // UiEtiquetaMaterial
            // 
            this.UiEtiquetaMaterial.Height = 0;
            this.UiEtiquetaMaterial.ItemBorder = Resco.Controls.DetailView.ItemBorder.None;
            this.UiEtiquetaMaterial.Label = "Material";
            this.UiEtiquetaMaterial.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiEtiquetaMaterial.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiEtiquetaMaterial.LabelHeight = 24;
            this.UiEtiquetaMaterial.Name = "UiEtiquetaMaterial";
            this.UiEtiquetaMaterial.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            // 
            // UiTextoLote
            // 
            this.UiTextoLote.Height = 24;
            this.UiTextoLote.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiTextoLote.Label = "Lote";
            this.UiTextoLote.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.UiTextoLote.LabelForeColor = System.Drawing.Color.White;
            this.UiTextoLote.LabelHeight = 24;
            this.UiTextoLote.Name = "UiTextoLote";
            this.UiTextoLote.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UiTextoLote.TextForeColor = System.Drawing.Color.White;
            // 
            // UiFechaDeExpiracion
            // 
            this.UiFechaDeExpiracion.DateTime = new System.DateTime(2017, 2, 22, 18, 26, 16, 0);
            this.UiFechaDeExpiracion.DateTimeStyle = Resco.Controls.DetailView.RescoDateTimePickerStyle.Date;
            this.UiFechaDeExpiracion.Height = 24;
            this.UiFechaDeExpiracion.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiFechaDeExpiracion.Label = "Fecha Expiración";
            this.UiFechaDeExpiracion.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.UiFechaDeExpiracion.LabelForeColor = System.Drawing.Color.White;
            this.UiFechaDeExpiracion.LabelHeight = 24;
            this.UiFechaDeExpiracion.Name = "UiFechaDeExpiracion";
            this.UiFechaDeExpiracion.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiFechaDeExpiracion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UiFechaDeExpiracion.TextForeColor = System.Drawing.Color.White;
            // 
            // UiTextoCantidad
            // 
            this.UiTextoCantidad.Height = 24;
            this.UiTextoCantidad.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiTextoCantidad.Label = "Cantidad";
            this.UiTextoCantidad.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.UiTextoCantidad.LabelForeColor = System.Drawing.Color.White;
            this.UiTextoCantidad.LabelHeight = 24;
            this.UiTextoCantidad.Name = "UiTextoCantidad";
            this.UiTextoCantidad.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UiTextoCantidad.TextForeColor = System.Drawing.Color.White;
            // 
            // UiTextoSerie
            // 
            this.UiTextoSerie.Height = 24;
            this.UiTextoSerie.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiTextoSerie.Label = "Serie";
            this.UiTextoSerie.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.UiTextoSerie.LabelForeColor = System.Drawing.Color.White;
            this.UiTextoSerie.LabelHeight = 24;
            this.UiTextoSerie.Name = "UiTextoSerie";
            this.UiTextoSerie.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UiTextoSerie.TextForeColor = System.Drawing.Color.White;
            // 
            // LicenciaPorConteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.UiBotonLimpiarLicencia);
            this.Controls.Add(this.UiBotonMostraSku);
            this.Controls.Add(this.UiPanelProductos);
            this.Controls.Add(this.UiBotonFinalizarUbicacion);
            this.Controls.Add(this.UiVistaLicenciaPorConteo);
            this.Name = "LicenciaPorConteo";
            this.Size = new System.Drawing.Size(240, 400);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaLicenciaPorConteo_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonFinalizarUbicacion)).EndInit();
            this.UiPanelProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonMostraSku)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonLimpiarLicencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Resco.Controls.DetailView.DetailView UiVistaLicenciaPorConteo;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonFinalizarUbicacion;
        private Resco.Controls.CommonControls.TouchPanel UiPanelProductos;
        internal Resco.Controls.AdvancedList.AdvancedList UiListaMateriales;
        private Resco.Controls.AdvancedList.RowTemplate Material;
        private Resco.Controls.AdvancedList.TextCell MATERIAL_ID;
        private Resco.Controls.AdvancedList.TextCell MATERIAL_NAME;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonMostraSku;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonLimpiarLicencia;
        private Resco.Controls.DetailView.Item UiSeparador;
        private Resco.Controls.DetailView.Item UiEtiquetaEncabezado;
        private Resco.Controls.DetailView.Item UiEtiquetaUbicacion;
        private Resco.Controls.DetailView.Item UiEtiquetaLicencia;
        private Resco.Controls.DetailView.Item UiEtiquetaMaterial;
        private Resco.Controls.DetailView.ItemTextBox UiTextoLote;
        private Resco.Controls.DetailView.ItemDateTime UiFechaDeExpiracion;
        private Resco.Controls.DetailView.ItemTextBox UiTextoCantidad;
        private Resco.Controls.DetailView.ItemTextBox UiTextoSerie;
    }
}
