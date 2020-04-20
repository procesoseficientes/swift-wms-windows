namespace MobilityScm.Modelo.Vistas
{
    partial class ConsultaDeEtiquetaPicking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaDeEtiquetaPicking));
            this.UiVistaConsultaEtiqueta = new Resco.Controls.DetailView.DetailView();
            this.Separator1 = new Resco.Controls.DetailView.Item();
            this.UiEtiquetaEncabezado = new Resco.Controls.DetailView.Item();
            this.UiListaTipoCertificacion = new Resco.Controls.DetailView.ItemAdvancedComboBox();
            this.UiTextoEscanear = new Resco.Controls.DetailView.ItemTextBox();
            this.UiEtiquetaUbicacionSalida = new Resco.Controls.DetailView.ItemTextBox();
            this.UiPanelBotones = new Resco.Controls.CommonControls.TouchPanel();
            this.UiBotonImprimir = new Resco.Controls.OutlookControls.ImageButton();
            this.UiListaMaterialesEnEtiqueta = new Resco.Controls.AdvancedList.AdvancedList();
            this.RowTemplate1 = new Resco.Controls.AdvancedList.RowTemplate();
            this.UiTextoMaterial = new Resco.Controls.AdvancedList.TextCell();
            this.UiNombreMaterial = new Resco.Controls.AdvancedList.TextCell();
            this.UiCantidadDisponible = new Resco.Controls.AdvancedList.TextCell();
            this.UiColEstado = new Resco.Controls.AdvancedList.TextCell();
            this.RowTemplate2 = new Resco.Controls.AdvancedList.RowTemplate();
            this.UiEncabezado = new Resco.Controls.AdvancedList.TextCell();
            this.TextCell2 = new Resco.Controls.AdvancedList.TextCell();
            this.UiPanelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonImprimir)).BeginInit();
            this.SuspendLayout();
            // 
            // UiVistaConsultaEtiqueta
            // 
            this.UiVistaConsultaEtiqueta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UiVistaConsultaEtiqueta.DisabledForeColor = System.Drawing.Color.Gray;
            this.UiVistaConsultaEtiqueta.EnableDesignTimeCustomItems = true;
            this.UiVistaConsultaEtiqueta.ForeColor = System.Drawing.Color.White;
            this.UiVistaConsultaEtiqueta.GradientBackColor = new Resco.Controls.DetailView.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.DetailView.FillDirection.Vertical);
            this.UiVistaConsultaEtiqueta.Items.Add(this.Separator1);
            this.UiVistaConsultaEtiqueta.Items.Add(this.UiEtiquetaEncabezado);
            this.UiVistaConsultaEtiqueta.Items.Add(this.UiListaTipoCertificacion);
            this.UiVistaConsultaEtiqueta.Items.Add(this.UiTextoEscanear);
            this.UiVistaConsultaEtiqueta.Items.Add(this.UiEtiquetaUbicacionSalida);
            this.UiVistaConsultaEtiqueta.KeyNavigation = true;
            this.UiVistaConsultaEtiqueta.KeyTabNavigation = true;
            this.UiVistaConsultaEtiqueta.LabelWidth = 90;
            this.UiVistaConsultaEtiqueta.Location = new System.Drawing.Point(0, 0);
            this.UiVistaConsultaEtiqueta.Name = "UiVistaConsultaEtiqueta";
            this.UiVistaConsultaEtiqueta.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.Dots;
            this.UiVistaConsultaEtiqueta.SeparatorWidth = 0;
            this.UiVistaConsultaEtiqueta.Size = new System.Drawing.Size(240, 162);
            this.UiVistaConsultaEtiqueta.TabIndex = 22;
            this.UiVistaConsultaEtiqueta.TabStop = false;
            this.UiVistaConsultaEtiqueta.TouchScrolling = true;
            this.UiVistaConsultaEtiqueta.UseClickVisualize = true;
            this.UiVistaConsultaEtiqueta.UseGradient = true;
            this.UiVistaConsultaEtiqueta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaConsultaEtiqueta_KeyUp);
            // 
            // Separator1
            // 
            this.Separator1.Height = 0;
            this.Separator1.ItemBorder = Resco.Controls.DetailView.ItemBorder.None;
            this.Separator1.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.Separator1.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(95)))), ((int)(((byte)(0)))));
            this.Separator1.LabelHeight = 3;
            this.Separator1.Name = "Separator1";
            this.Separator1.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.Separator1.TextBackColor = System.Drawing.Color.Black;
            // 
            // UiEtiquetaEncabezado
            // 
            this.UiEtiquetaEncabezado.Height = 0;
            this.UiEtiquetaEncabezado.ItemBorder = Resco.Controls.DetailView.ItemBorder.None;
            this.UiEtiquetaEncabezado.Label = "Consulta de Etiqueta de Picking";
            this.UiEtiquetaEncabezado.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiEtiquetaEncabezado.LabelBackColor = System.Drawing.Color.Black;
            this.UiEtiquetaEncabezado.LabelForeColor = System.Drawing.Color.White;
            this.UiEtiquetaEncabezado.LabelHeight = 24;
            this.UiEtiquetaEncabezado.Name = "UiEtiquetaEncabezado";
            this.UiEtiquetaEncabezado.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiEtiquetaEncabezado.TextBackColor = System.Drawing.Color.White;
            // 
            // UiListaTipoCertificacion
            // 
            this.UiListaTipoCertificacion.CancelButtonVisible = true;
            this.UiListaTipoCertificacion.DisplayMember = "PARAM_CAPTION";
            this.UiListaTipoCertificacion.FullScreenList = true;
            this.UiListaTipoCertificacion.Height = 20;
            this.UiListaTipoCertificacion.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiListaTipoCertificacion.LabelHeight = 0;
            this.UiListaTipoCertificacion.LineAlign = Resco.Controls.DetailView.VerticalAlignment.Middle;
            this.UiListaTipoCertificacion.ListGridLines = true;
            this.UiListaTipoCertificacion.Name = "UiListaTipoCertificacion";
            this.UiListaTipoCertificacion.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiListaTipoCertificacion.TextForeColor = System.Drawing.Color.White;
            this.UiListaTipoCertificacion.TouchScrolling = true;
            this.UiListaTipoCertificacion.ValueMember = "PARAM_NAME";
            // 
            // UiTextoEscanear
            // 
            this.UiTextoEscanear.CharacterCasing = Resco.Controls.DetailView.ItemTextBoxCharacterCasing.Upper;
            this.UiTextoEscanear.Height = 20;
            this.UiTextoEscanear.Label = "Escanear Etiqueta";
            this.UiTextoEscanear.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoEscanear.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiTextoEscanear.LabelHeight = 20;
            this.UiTextoEscanear.Name = "UiTextoEscanear";
            this.UiTextoEscanear.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoEscanear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoEscanear.TextForeColor = System.Drawing.Color.White;
            // 
            // UiEtiquetaUbicacionSalida
            // 
            this.UiEtiquetaUbicacionSalida.CharacterCasing = Resco.Controls.DetailView.ItemTextBoxCharacterCasing.Upper;
            this.UiEtiquetaUbicacionSalida.Height = 20;
            this.UiEtiquetaUbicacionSalida.Label = "Ubicación de Salida";
            this.UiEtiquetaUbicacionSalida.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiEtiquetaUbicacionSalida.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiEtiquetaUbicacionSalida.LabelHeight = 15;
            this.UiEtiquetaUbicacionSalida.MultiLine = true;
            this.UiEtiquetaUbicacionSalida.Name = "UiEtiquetaUbicacionSalida";
            this.UiEtiquetaUbicacionSalida.ReadOnly = true;
            this.UiEtiquetaUbicacionSalida.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiEtiquetaUbicacionSalida.Text = "...";
            this.UiEtiquetaUbicacionSalida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiEtiquetaUbicacionSalida.TextForeColor = System.Drawing.Color.White;
            // 
            // UiPanelBotones
            // 
            this.UiPanelBotones.Controls.Add(this.UiBotonImprimir);
            this.UiPanelBotones.GradientBackColor = new Resco.Controls.CommonControls.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.CommonControls.FillDirection.Horizontal);
            this.UiPanelBotones.Location = new System.Drawing.Point(0, 362);
            this.UiPanelBotones.Name = "UiPanelBotones";
            this.UiPanelBotones.Size = new System.Drawing.Size(240, 38);
            this.UiPanelBotones.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaConsultaEtiqueta_KeyUp);
            // 
            // UiBotonImprimir
            // 
            this.UiBotonImprimir.BackColor = System.Drawing.Color.Black;
            this.UiBotonImprimir.BorderColor = System.Drawing.Color.Orange;
            this.UiBotonImprimir.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonImprimir.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.UiBotonImprimir.ForeColor = System.Drawing.Color.White;
            this.UiBotonImprimir.Location = new System.Drawing.Point(40, 3);
            this.UiBotonImprimir.Name = "UiBotonImprimir";
            this.UiBotonImprimir.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonImprimir.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonImprimir.Size = new System.Drawing.Size(157, 32);
            this.UiBotonImprimir.TabIndex = 23;
            this.UiBotonImprimir.Text = "Reimprimir";
            this.UiBotonImprimir.Visible = false;
            this.UiBotonImprimir.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonImprimir.WordWrap = true;
            this.UiBotonImprimir.Click += new System.EventHandler(this.UiBotonImprimir_Click);
            this.UiBotonImprimir.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaConsultaEtiqueta_KeyUp);
            // 
            // UiListaMaterialesEnEtiqueta
            // 
            this.UiListaMaterialesEnEtiqueta.DataRows.Clear();
            this.UiListaMaterialesEnEtiqueta.GradientBackColor = new Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.AdvancedList.FillDirection.Horizontal);
            this.UiListaMaterialesEnEtiqueta.HeaderRow = new Resco.Controls.AdvancedList.HeaderRow(1, new string[] {
            resources.GetString("UiListaMaterialesEnEtiqueta.HeaderRow")});
            this.UiListaMaterialesEnEtiqueta.Location = new System.Drawing.Point(0, 161);
            this.UiListaMaterialesEnEtiqueta.Name = "UiListaMaterialesEnEtiqueta";
            this.UiListaMaterialesEnEtiqueta.ShowHeader = true;
            this.UiListaMaterialesEnEtiqueta.Size = new System.Drawing.Size(240, 206);
            this.UiListaMaterialesEnEtiqueta.TabIndex = 26;
            this.UiListaMaterialesEnEtiqueta.Templates.Add(this.RowTemplate1);
            this.UiListaMaterialesEnEtiqueta.Templates.Add(this.RowTemplate2);
            this.UiListaMaterialesEnEtiqueta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiListaMaterialesEnEtiqueta_KeyUp);
            // 
            // RowTemplate1
            // 
            this.RowTemplate1.BackColor = System.Drawing.Color.Transparent;
            this.RowTemplate1.CellTemplates.Add(this.UiTextoMaterial);
            this.RowTemplate1.CellTemplates.Add(this.UiNombreMaterial);
            this.RowTemplate1.CellTemplates.Add(this.UiCantidadDisponible);
            this.RowTemplate1.CellTemplates.Add(this.UiColEstado);
            this.RowTemplate1.Height = 51;
            this.RowTemplate1.Name = "RowTemplate1";
            // 
            // UiTextoMaterial
            // 
            this.UiTextoMaterial.CellSource.ColumnName = "MATERIAL_ID";
            this.UiTextoMaterial.DesignName = "UiTextoMaterial";
            this.UiTextoMaterial.ForeColor = System.Drawing.Color.White;
            this.UiTextoMaterial.Location = new System.Drawing.Point(0, 0);
            this.UiTextoMaterial.Size = new System.Drawing.Size(175, 21);
            // 
            // UiNombreMaterial
            // 
            this.UiNombreMaterial.CellSource.ColumnName = "MATERIAL_NAME";
            this.UiNombreMaterial.DesignName = "UiNombreMaterial";
            this.UiNombreMaterial.ForeColor = System.Drawing.Color.White;
            this.UiNombreMaterial.Location = new System.Drawing.Point(0, 20);
            this.UiNombreMaterial.Size = new System.Drawing.Size(174, 31);
            this.UiNombreMaterial.TextFont = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            // 
            // UiCantidadDisponible
            // 
            this.UiCantidadDisponible.Alignment = Resco.Controls.AdvancedList.Alignment.MiddleCenter;
            this.UiCantidadDisponible.CellSource.ColumnName = "QUANTITY";
            this.UiCantidadDisponible.DesignName = "UiCantidadDisponible";
            this.UiCantidadDisponible.ForeColor = System.Drawing.Color.White;
            this.UiCantidadDisponible.Location = new System.Drawing.Point(175, 0);
            this.UiCantidadDisponible.Size = new System.Drawing.Size(65, 21);
            // 
            // UiColEstado
            // 
            this.UiColEstado.Alignment = Resco.Controls.AdvancedList.Alignment.MiddleCenter;
            this.UiColEstado.CellSource.ColumnName = "STATUS";
            this.UiColEstado.DesignName = "UiColEstado";
            this.UiColEstado.ForeColor = System.Drawing.Color.White;
            this.UiColEstado.Location = new System.Drawing.Point(173, 21);
            this.UiColEstado.Size = new System.Drawing.Size(-1, 30);
            this.UiColEstado.TextFont = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            // 
            // RowTemplate2
            // 
            this.RowTemplate2.BackColor = System.Drawing.Color.Transparent;
            this.RowTemplate2.CellTemplates.Add(this.UiEncabezado);
            this.RowTemplate2.CellTemplates.Add(this.TextCell2);
            this.RowTemplate2.Height = 28;
            this.RowTemplate2.Name = "RowTemplate2";
            // 
            // UiEncabezado
            // 
            this.UiEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.UiEncabezado.DesignName = "UiEncabezado";
            this.UiEncabezado.ForeColor = System.Drawing.Color.DarkOrange;
            this.UiEncabezado.FormatString = "Material";
            this.UiEncabezado.Location = new System.Drawing.Point(0, 0);
            this.UiEncabezado.Size = new System.Drawing.Size(173, 28);
            // 
            // TextCell2
            // 
            this.TextCell2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.TextCell2.DesignName = "TextCell2";
            this.TextCell2.ForeColor = System.Drawing.Color.DarkOrange;
            this.TextCell2.FormatString = "Cantidad";
            this.TextCell2.Location = new System.Drawing.Point(173, 0);
            this.TextCell2.Size = new System.Drawing.Size(67, 28);
            // 
            // ConsultaDeEtiquetaPicking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.UiPanelBotones);
            this.Controls.Add(this.UiVistaConsultaEtiqueta);
            this.Controls.Add(this.UiListaMaterialesEnEtiqueta);
            this.Name = "ConsultaDeEtiquetaPicking";
            this.Size = new System.Drawing.Size(240, 400);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaConsultaEtiqueta_KeyUp);
            this.UiPanelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonImprimir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Resco.Controls.DetailView.DetailView UiVistaConsultaEtiqueta;
        private Resco.Controls.CommonControls.TouchPanel UiPanelBotones;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonImprimir;
        private Resco.Controls.AdvancedList.AdvancedList UiListaMaterialesEnEtiqueta;
        private Resco.Controls.DetailView.Item Separator1;
        private Resco.Controls.DetailView.Item UiEtiquetaEncabezado;
        private Resco.Controls.DetailView.ItemAdvancedComboBox UiListaTipoCertificacion;
        private Resco.Controls.DetailView.ItemTextBox UiTextoEscanear;
        private Resco.Controls.DetailView.ItemTextBox UiEtiquetaUbicacionSalida;
        private Resco.Controls.AdvancedList.RowTemplate RowTemplate1;
        private Resco.Controls.AdvancedList.TextCell UiTextoMaterial;
        private Resco.Controls.AdvancedList.TextCell UiNombreMaterial;
        private Resco.Controls.AdvancedList.TextCell UiCantidadDisponible;
        private Resco.Controls.AdvancedList.TextCell UiColEstado;
        private Resco.Controls.AdvancedList.RowTemplate RowTemplate2;
        private Resco.Controls.AdvancedList.TextCell UiEncabezado;
        private Resco.Controls.AdvancedList.TextCell TextCell2;
    }
}
