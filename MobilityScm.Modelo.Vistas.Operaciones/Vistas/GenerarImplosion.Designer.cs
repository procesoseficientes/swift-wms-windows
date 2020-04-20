namespace MobilityScm.Modelo.Vistas.Operaciones.Vistas
{
    partial class GenerarImplosion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerarImplosion));
            this.UiVistaImplosion = new Resco.Controls.DetailView.DetailView();
            this.UiSeparador = new Resco.Controls.DetailView.Item();
            this.UiEtiquetaEncabezado = new Resco.Controls.DetailView.Item();
            this.UiTextoMaterial = new Resco.Controls.DetailView.ItemTextBox();
            this.UiTextoCantidad = new Resco.Controls.DetailView.ItemNumeric();
            this.UiComboBodegas = new Resco.Controls.DetailView.ItemComboBox();
            this.UiPanelBotones = new Resco.Controls.CommonControls.TouchPanel();
            this.UiBotonBuscar = new Resco.Controls.OutlookControls.ImageButton();
            this.UiBotonImplosion = new Resco.Controls.OutlookControls.ImageButton();
            this.UiPanelComponentes = new Resco.Controls.CommonControls.TouchPanel();
            this.UiListaComponentes = new Resco.Controls.AdvancedList.AdvancedList();
            this.RowTemplate1 = new Resco.Controls.AdvancedList.RowTemplate();
            this.UiTextoComponente = new Resco.Controls.AdvancedList.TextCell();
            this.UiCantidadRequerida = new Resco.Controls.AdvancedList.TextCell();
            this.UiCantidadDisponible = new Resco.Controls.AdvancedList.TextCell();
            this.RowTemplate2 = new Resco.Controls.AdvancedList.RowTemplate();
            this.UiEncabezado = new Resco.Controls.AdvancedList.TextCell();
            this.TextCell1 = new Resco.Controls.AdvancedList.TextCell();
            this.TextCell2 = new Resco.Controls.AdvancedList.TextCell();
            this.UiPanelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonImplosion)).BeginInit();
            this.UiPanelComponentes.SuspendLayout();
            this.SuspendLayout();
            // 
            // UiVistaImplosion
            // 
            this.UiVistaImplosion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UiVistaImplosion.DisabledForeColor = System.Drawing.Color.Gray;
            this.UiVistaImplosion.EnableDesignTimeCustomItems = true;
            this.UiVistaImplosion.ForeColor = System.Drawing.Color.White;
            this.UiVistaImplosion.GradientBackColor = new Resco.Controls.DetailView.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.DetailView.FillDirection.Vertical);
            this.UiVistaImplosion.Items.Add(this.UiSeparador);
            this.UiVistaImplosion.Items.Add(this.UiEtiquetaEncabezado);
            this.UiVistaImplosion.Items.Add(this.UiTextoMaterial);
            this.UiVistaImplosion.Items.Add(this.UiTextoCantidad);
            this.UiVistaImplosion.Items.Add(this.UiComboBodegas);
            this.UiVistaImplosion.KeyNavigation = true;
            this.UiVistaImplosion.KeyTabNavigation = true;
            this.UiVistaImplosion.LabelWidth = 90;
            this.UiVistaImplosion.Location = new System.Drawing.Point(0, 0);
            this.UiVistaImplosion.Name = "UiVistaImplosion";
            this.UiVistaImplosion.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.Dots;
            this.UiVistaImplosion.SeparatorWidth = 0;
            this.UiVistaImplosion.Size = new System.Drawing.Size(240, 187);
            this.UiVistaImplosion.TabIndex = 5;
            this.UiVistaImplosion.TabStop = false;
            this.UiVistaImplosion.TouchScrolling = true;
            this.UiVistaImplosion.UseClickVisualize = true;
            this.UiVistaImplosion.UseGradient = true;
            this.UiVistaImplosion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaImplosion_KeyUp);
            this.UiVistaImplosion.ItemChanged += new Resco.Controls.DetailView.ItemEventHandler(this.UiVistaImplosion_ItemChanged);
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
            this.UiEtiquetaEncabezado.Label = "Implosión de Materiales";
            this.UiEtiquetaEncabezado.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiEtiquetaEncabezado.LabelBackColor = System.Drawing.Color.Black;
            this.UiEtiquetaEncabezado.LabelForeColor = System.Drawing.Color.White;
            this.UiEtiquetaEncabezado.LabelHeight = 24;
            this.UiEtiquetaEncabezado.Name = "UiEtiquetaEncabezado";
            this.UiEtiquetaEncabezado.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiEtiquetaEncabezado.TextBackColor = System.Drawing.Color.White;
            // 
            // UiTextoMaterial
            // 
            this.UiTextoMaterial.CharacterCasing = Resco.Controls.DetailView.ItemTextBoxCharacterCasing.Upper;
            this.UiTextoMaterial.Height = 24;
            this.UiTextoMaterial.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiTextoMaterial.Label = "Escanear Master Pack";
            this.UiTextoMaterial.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoMaterial.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiTextoMaterial.LabelHeight = 24;
            this.UiTextoMaterial.Name = "UiTextoMaterial";
            this.UiTextoMaterial.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoMaterial.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.UiTextoMaterial.TextForeColor = System.Drawing.Color.DarkOrange;
            // 
            // UiTextoCantidad
            // 
            this.UiTextoCantidad.Height = 24;
            this.UiTextoCantidad.Label = "Cantidad a implosionar";
            this.UiTextoCantidad.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoCantidad.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiTextoCantidad.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.UiTextoCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UiTextoCantidad.Name = "UiTextoCantidad";
            this.UiTextoCantidad.NumericValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UiTextoCantidad.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoCantidad.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.UiTextoCantidad.TextForeColor = System.Drawing.Color.DarkOrange;
            // 
            // UiComboBodegas
            // 
            this.UiComboBodegas.AutoHeight = true;
            this.UiComboBodegas.DisplayMember = "NAME";
            this.UiComboBodegas.Height = 18;
            this.UiComboBodegas.Label = "Bodega";
            this.UiComboBodegas.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiComboBodegas.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiComboBodegas.LineAlign = Resco.Controls.DetailView.VerticalAlignment.Middle;
            this.UiComboBodegas.Name = "UiComboBodegas";
            this.UiComboBodegas.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiComboBodegas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiComboBodegas.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.UiComboBodegas.TextForeColor = System.Drawing.Color.DarkOrange;
            this.UiComboBodegas.ValueMember = "WAREHOUSE_ID";
            // 
            // UiPanelBotones
            // 
            this.UiPanelBotones.Controls.Add(this.UiBotonBuscar);
            this.UiPanelBotones.Controls.Add(this.UiBotonImplosion);
            this.UiPanelBotones.GradientBackColor = new Resco.Controls.CommonControls.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.CommonControls.FillDirection.Horizontal);
            this.UiPanelBotones.Location = new System.Drawing.Point(0, 339);
            this.UiPanelBotones.Name = "UiPanelBotones";
            this.UiPanelBotones.Size = new System.Drawing.Size(240, 61);
            this.UiPanelBotones.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiPanelBotones_KeyUp);
            // 
            // UiBotonBuscar
            // 
            this.UiBotonBuscar.BackColor = System.Drawing.Color.Black;
            this.UiBotonBuscar.BorderColor = System.Drawing.Color.Orange;
            this.UiBotonBuscar.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonBuscar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.UiBotonBuscar.ForeColor = System.Drawing.Color.White;
            this.UiBotonBuscar.Location = new System.Drawing.Point(33, 7);
            this.UiBotonBuscar.Name = "UiBotonBuscar";
            this.UiBotonBuscar.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonBuscar.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonBuscar.Size = new System.Drawing.Size(77, 50);
            this.UiBotonBuscar.TabIndex = 23;
            this.UiBotonBuscar.Text = "Buscar";
            this.UiBotonBuscar.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonBuscar.WordWrap = true;
            this.UiBotonBuscar.Click += new System.EventHandler(this.UiBotonBuscar_Click);
            this.UiBotonBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiBotonBuscar_KeyUp);
            // 
            // UiBotonImplosion
            // 
            this.UiBotonImplosion.BackColor = System.Drawing.Color.Black;
            this.UiBotonImplosion.BorderColor = System.Drawing.Color.Orange;
            this.UiBotonImplosion.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonImplosion.Enabled = false;
            this.UiBotonImplosion.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.UiBotonImplosion.ForeColor = System.Drawing.Color.White;
            this.UiBotonImplosion.Location = new System.Drawing.Point(132, 7);
            this.UiBotonImplosion.Name = "UiBotonImplosion";
            this.UiBotonImplosion.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonImplosion.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonImplosion.Size = new System.Drawing.Size(77, 50);
            this.UiBotonImplosion.TabIndex = 22;
            this.UiBotonImplosion.Text = "Implosión";
            this.UiBotonImplosion.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonImplosion.WordWrap = true;
            this.UiBotonImplosion.Click += new System.EventHandler(this.UiBotonImplosion_Click);
            this.UiBotonImplosion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiBotonImplosion_KeyUp);
            // 
            // UiPanelComponentes
            // 
            this.UiPanelComponentes.Controls.Add(this.UiListaComponentes);
            this.UiPanelComponentes.GradientBackColor = new Resco.Controls.CommonControls.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.CommonControls.FillDirection.Horizontal);
            this.UiPanelComponentes.Location = new System.Drawing.Point(0, 186);
            this.UiPanelComponentes.Name = "UiPanelComponentes";
            this.UiPanelComponentes.Size = new System.Drawing.Size(240, 154);
            // 
            // UiListaComponentes
            // 
            this.UiListaComponentes.DataRows.Clear();
            this.UiListaComponentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiListaComponentes.GradientBackColor = new Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.AdvancedList.FillDirection.Horizontal);
            this.UiListaComponentes.HeaderRow = new Resco.Controls.AdvancedList.HeaderRow(1, new string[] {
            resources.GetString("UiListaComponentes.HeaderRow")});
            this.UiListaComponentes.Location = new System.Drawing.Point(0, 0);
            this.UiListaComponentes.Name = "UiListaComponentes";
            this.UiListaComponentes.ShowHeader = true;
            this.UiListaComponentes.Size = new System.Drawing.Size(240, 154);
            this.UiListaComponentes.TabIndex = 4;
            this.UiListaComponentes.Templates.Add(this.RowTemplate1);
            this.UiListaComponentes.Templates.Add(this.RowTemplate2);
            this.UiListaComponentes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiListaComponentes_KeyUp);
            // 
            // RowTemplate1
            // 
            this.RowTemplate1.BackColor = System.Drawing.Color.Transparent;
            this.RowTemplate1.CellTemplates.Add(this.UiTextoComponente);
            this.RowTemplate1.CellTemplates.Add(this.UiCantidadRequerida);
            this.RowTemplate1.CellTemplates.Add(this.UiCantidadDisponible);
            this.RowTemplate1.Height = 43;
            this.RowTemplate1.Name = "RowTemplate1";
            // 
            // UiTextoComponente
            // 
            this.UiTextoComponente.CellSource.ColumnName = "MATERIAL_ID";
            this.UiTextoComponente.DesignName = "UiTextoComponente";
            this.UiTextoComponente.ForeColor = System.Drawing.Color.White;
            this.UiTextoComponente.Location = new System.Drawing.Point(0, 0);
            this.UiTextoComponente.Size = new System.Drawing.Size(128, 43);
            // 
            // UiCantidadRequerida
            // 
            this.UiCantidadRequerida.CellSource.ColumnName = "QTY";
            this.UiCantidadRequerida.DesignName = "UiCantidadRequerida";
            this.UiCantidadRequerida.ForeColor = System.Drawing.Color.White;
            this.UiCantidadRequerida.Location = new System.Drawing.Point(128, 0);
            this.UiCantidadRequerida.Size = new System.Drawing.Size(47, 43);
            // 
            // UiCantidadDisponible
            // 
            this.UiCantidadDisponible.CellSource.ColumnName = "QTY_AVAILABLE";
            this.UiCantidadDisponible.DesignName = "UiCantidadDisponible";
            this.UiCantidadDisponible.ForeColor = System.Drawing.Color.White;
            this.UiCantidadDisponible.Location = new System.Drawing.Point(175, 0);
            this.UiCantidadDisponible.Size = new System.Drawing.Size(65, 43);
            // 
            // RowTemplate2
            // 
            this.RowTemplate2.BackColor = System.Drawing.Color.Transparent;
            this.RowTemplate2.CellTemplates.Add(this.UiEncabezado);
            this.RowTemplate2.CellTemplates.Add(this.TextCell1);
            this.RowTemplate2.CellTemplates.Add(this.TextCell2);
            this.RowTemplate2.Height = 28;
            this.RowTemplate2.Name = "RowTemplate2";
            // 
            // UiEncabezado
            // 
            this.UiEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.UiEncabezado.DesignName = "UiEncabezado";
            this.UiEncabezado.ForeColor = System.Drawing.Color.DarkOrange;
            this.UiEncabezado.FormatString = "Componente";
            this.UiEncabezado.Location = new System.Drawing.Point(0, 0);
            this.UiEncabezado.Size = new System.Drawing.Size(128, 28);
            // 
            // TextCell1
            // 
            this.TextCell1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.TextCell1.DesignName = "TextCell1";
            this.TextCell1.ForeColor = System.Drawing.Color.DarkOrange;
            this.TextCell1.FormatString = "Cantidad";
            this.TextCell1.Location = new System.Drawing.Point(128, 0);
            this.TextCell1.Size = new System.Drawing.Size(47, 28);
            // 
            // TextCell2
            // 
            this.TextCell2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.TextCell2.DesignName = "TextCell2";
            this.TextCell2.ForeColor = System.Drawing.Color.DarkOrange;
            this.TextCell2.FormatString = "Disponible";
            this.TextCell2.Location = new System.Drawing.Point(175, 0);
            this.TextCell2.Size = new System.Drawing.Size(65, 28);
            // 
            // GenerarImplosion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.UiPanelComponentes);
            this.Controls.Add(this.UiPanelBotones);
            this.Controls.Add(this.UiVistaImplosion);
            this.Name = "GenerarImplosion";
            this.Size = new System.Drawing.Size(240, 400);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GenerarImplosion_KeyUp);
            this.UiPanelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonImplosion)).EndInit();
            this.UiPanelComponentes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal Resco.Controls.DetailView.DetailView UiVistaImplosion;
        private Resco.Controls.CommonControls.TouchPanel UiPanelBotones;
        private Resco.Controls.CommonControls.TouchPanel UiPanelComponentes;
        private Resco.Controls.AdvancedList.AdvancedList UiListaComponentes;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonBuscar;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonImplosion;
        private Resco.Controls.AdvancedList.RowTemplate RowTemplate1;
        private Resco.Controls.AdvancedList.TextCell UiTextoComponente;
        private Resco.Controls.AdvancedList.TextCell UiCantidadRequerida;
        private Resco.Controls.AdvancedList.TextCell UiCantidadDisponible;
        private Resco.Controls.AdvancedList.RowTemplate RowTemplate2;
        private Resco.Controls.AdvancedList.TextCell UiEncabezado;
        private Resco.Controls.AdvancedList.TextCell TextCell1;
        private Resco.Controls.AdvancedList.TextCell TextCell2;
        private Resco.Controls.DetailView.Item UiSeparador;
        private Resco.Controls.DetailView.Item UiEtiquetaEncabezado;
        private Resco.Controls.DetailView.ItemTextBox UiTextoMaterial;
        private Resco.Controls.DetailView.ItemNumeric UiTextoCantidad;
        private Resco.Controls.DetailView.ItemComboBox UiComboBodegas;

    }
}
