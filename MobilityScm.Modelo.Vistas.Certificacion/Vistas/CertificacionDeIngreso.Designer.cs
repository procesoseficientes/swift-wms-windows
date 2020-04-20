namespace MobilityScm.Modelo.Vistas.Certificacion.Vistas
{
    partial class CertificacionDeIngreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertificacionDeIngreso));
            this.UiVistaCertificacion = new Resco.Controls.DetailView.DetailView();
            this.Separator1 = new Resco.Controls.DetailView.Item();
            this.UiEtiquetaEncabezado = new Resco.Controls.DetailView.Item();
            this.UiTextoManifiesto = new Resco.Controls.DetailView.ItemTextBox();
            this.UiListaTipoCertificacion = new Resco.Controls.DetailView.ItemAdvancedComboBox();
            this.UiTextoEscanear = new Resco.Controls.DetailView.ItemTextBox();
            this.UiEtiquetaDescripcion = new Resco.Controls.DetailView.ItemTextBox();
            this.UiTextoCantidad = new Resco.Controls.DetailView.ItemTextBox();
            this.UiBotonCrearCertificacion = new Resco.Controls.OutlookControls.ImageButton();
            this.UiBotonDetalle = new Resco.Controls.OutlookControls.ImageButton();
            this.UiListaDetalleCertificacion = new Resco.Controls.AdvancedTree.AdvancedTree();
            this.NodeTemplate2 = new Resco.Controls.AdvancedTree.NodeTemplate();
            this.CERTIFICATION_TYPE = new Resco.Controls.AdvancedTree.TextCell();
            this.MATERIAL_ID = new Resco.Controls.AdvancedTree.TextCell();
            this.QTY = new Resco.Controls.AdvancedTree.TextCell();
            this.NodeTemplate3 = new Resco.Controls.AdvancedTree.NodeTemplate();
            this.SERIAL_NUMBER = new Resco.Controls.AdvancedTree.TextCell();
            this.UiBotonFinalizar = new Resco.Controls.OutlookControls.ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonCrearCertificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonFinalizar)).BeginInit();
            this.SuspendLayout();
            // 
            // UiVistaCertificacion
            // 
            this.UiVistaCertificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UiVistaCertificacion.DisabledForeColor = System.Drawing.Color.Gray;
            this.UiVistaCertificacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiVistaCertificacion.EnableDesignTimeCustomItems = true;
            this.UiVistaCertificacion.ForeColor = System.Drawing.Color.White;
            this.UiVistaCertificacion.GradientBackColor = new Resco.Controls.DetailView.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.DetailView.FillDirection.Vertical);
            this.UiVistaCertificacion.Items.Add(this.Separator1);
            this.UiVistaCertificacion.Items.Add(this.UiEtiquetaEncabezado);
            this.UiVistaCertificacion.Items.Add(this.UiTextoManifiesto);
            this.UiVistaCertificacion.Items.Add(this.UiListaTipoCertificacion);
            this.UiVistaCertificacion.Items.Add(this.UiTextoEscanear);
            this.UiVistaCertificacion.Items.Add(this.UiEtiquetaDescripcion);
            this.UiVistaCertificacion.Items.Add(this.UiTextoCantidad);
            this.UiVistaCertificacion.KeyNavigation = true;
            this.UiVistaCertificacion.KeyTabNavigation = true;
            this.UiVistaCertificacion.LabelWidth = 90;
            this.UiVistaCertificacion.Location = new System.Drawing.Point(0, 0);
            this.UiVistaCertificacion.Name = "UiVistaCertificacion";
            this.UiVistaCertificacion.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.Dots;
            this.UiVistaCertificacion.SeparatorWidth = 0;
            this.UiVistaCertificacion.Size = new System.Drawing.Size(240, 400);
            this.UiVistaCertificacion.TabIndex = 21;
            this.UiVistaCertificacion.TabStop = false;
            this.UiVistaCertificacion.TouchScrolling = true;
            this.UiVistaCertificacion.UseClickVisualize = true;
            this.UiVistaCertificacion.UseGradient = true;
            this.UiVistaCertificacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaCertificacion_KeyUp);
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
            this.UiEtiquetaEncabezado.Label = "Certificación";
            this.UiEtiquetaEncabezado.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiEtiquetaEncabezado.LabelBackColor = System.Drawing.Color.Black;
            this.UiEtiquetaEncabezado.LabelForeColor = System.Drawing.Color.White;
            this.UiEtiquetaEncabezado.LabelHeight = 24;
            this.UiEtiquetaEncabezado.Name = "UiEtiquetaEncabezado";
            this.UiEtiquetaEncabezado.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiEtiquetaEncabezado.TextBackColor = System.Drawing.Color.White;
            // 
            // UiTextoManifiesto
            // 
            this.UiTextoManifiesto.CharacterCasing = Resco.Controls.DetailView.ItemTextBoxCharacterCasing.Upper;
            this.UiTextoManifiesto.Height = 20;
            this.UiTextoManifiesto.Label = "Manifiesto";
            this.UiTextoManifiesto.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoManifiesto.LabelForeColor = System.Drawing.Color.White;
            this.UiTextoManifiesto.LabelHeight = 20;
            this.UiTextoManifiesto.Name = "UiTextoManifiesto";
            this.UiTextoManifiesto.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoManifiesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoManifiesto.TextForeColor = System.Drawing.Color.White;
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
            this.UiTextoEscanear.Label = "...";
            this.UiTextoEscanear.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoEscanear.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiTextoEscanear.LabelHeight = 20;
            this.UiTextoEscanear.Name = "UiTextoEscanear";
            this.UiTextoEscanear.ReadOnly = true;
            this.UiTextoEscanear.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoEscanear.Text = "...";
            this.UiTextoEscanear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoEscanear.TextForeColor = System.Drawing.Color.DarkOrange;
            // 
            // UiEtiquetaDescripcion
            // 
            this.UiEtiquetaDescripcion.CharacterCasing = Resco.Controls.DetailView.ItemTextBoxCharacterCasing.Upper;
            this.UiEtiquetaDescripcion.Height = 40;
            this.UiEtiquetaDescripcion.Label = "Cliente:";
            this.UiEtiquetaDescripcion.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.UiEtiquetaDescripcion.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiEtiquetaDescripcion.LabelHeight = 1;
            this.UiEtiquetaDescripcion.MultiLine = true;
            this.UiEtiquetaDescripcion.Name = "UiEtiquetaDescripcion";
            this.UiEtiquetaDescripcion.ReadOnly = true;
            this.UiEtiquetaDescripcion.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiEtiquetaDescripcion.TextForeColor = System.Drawing.Color.White;
            // 
            // UiTextoCantidad
            // 
            this.UiTextoCantidad.Height = 20;
            this.UiTextoCantidad.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiTextoCantidad.Label = "Cantidad:";
            this.UiTextoCantidad.LabelForeColor = System.Drawing.Color.White;
            this.UiTextoCantidad.LabelHeight = 20;
            this.UiTextoCantidad.Name = "UiTextoCantidad";
            this.UiTextoCantidad.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoCantidad.Text = "1";
            this.UiTextoCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UiTextoCantidad.TextForeColor = System.Drawing.Color.White;
            // 
            // UiBotonCrearCertificacion
            // 
            this.UiBotonCrearCertificacion.BackColor = System.Drawing.Color.Black;
            this.UiBotonCrearCertificacion.BorderColor = System.Drawing.Color.Goldenrod;
            this.UiBotonCrearCertificacion.BorderStyle = Resco.Controls.RescoBorderStyle.FixedSingle;
            this.UiBotonCrearCertificacion.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonCrearCertificacion.ForeColor = System.Drawing.Color.White;
            this.UiBotonCrearCertificacion.Location = new System.Drawing.Point(1, 323);
            this.UiBotonCrearCertificacion.Name = "UiBotonCrearCertificacion";
            this.UiBotonCrearCertificacion.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonCrearCertificacion.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonCrearCertificacion.Size = new System.Drawing.Size(75, 75);
            this.UiBotonCrearCertificacion.TabIndex = 16;
            this.UiBotonCrearCertificacion.Text = "Crear Certificación";
            this.UiBotonCrearCertificacion.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonCrearCertificacion.WordWrap = true;
            this.UiBotonCrearCertificacion.Click += new System.EventHandler(this.UiBotonCrearCertificacion_Click);
            this.UiBotonCrearCertificacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaCertificacion_KeyUp);
            // 
            // UiBotonDetalle
            // 
            this.UiBotonDetalle.BackColor = System.Drawing.Color.Black;
            this.UiBotonDetalle.BorderColor = System.Drawing.Color.Goldenrod;
            this.UiBotonDetalle.BorderStyle = Resco.Controls.RescoBorderStyle.FixedSingle;
            this.UiBotonDetalle.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonDetalle.ForeColor = System.Drawing.Color.White;
            this.UiBotonDetalle.Location = new System.Drawing.Point(82, 322);
            this.UiBotonDetalle.Name = "UiBotonDetalle";
            this.UiBotonDetalle.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonDetalle.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonDetalle.Size = new System.Drawing.Size(75, 75);
            this.UiBotonDetalle.TabIndex = 22;
            this.UiBotonDetalle.Text = "Detalle";
            this.UiBotonDetalle.Visible = false;
            this.UiBotonDetalle.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonDetalle.WordWrap = true;
            this.UiBotonDetalle.Click += new System.EventHandler(this.UiBotonDetalle_Click);
            this.UiBotonDetalle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaCertificacion_KeyUp);
            // 
            // UiListaDetalleCertificacion
            // 
            this.UiListaDetalleCertificacion.AutoScroll = true;
            this.UiListaDetalleCertificacion.BackColor = System.Drawing.Color.Transparent;
            this.UiListaDetalleCertificacion.GradientBackColor = new Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.AdvancedTree.FillDirection.Vertical);
            this.UiListaDetalleCertificacion.GridColor = System.Drawing.Color.Transparent;
            this.UiListaDetalleCertificacion.Location = new System.Drawing.Point(0, 28);
            this.UiListaDetalleCertificacion.MinusImage = ((System.Drawing.Image)(resources.GetObject("UiListaDetalleCertificacion.MinusImage")));
            this.UiListaDetalleCertificacion.Name = "UiListaDetalleCertificacion";
            this.UiListaDetalleCertificacion.PlusImage = ((System.Drawing.Image)(resources.GetObject("UiListaDetalleCertificacion.PlusImage")));
            this.UiListaDetalleCertificacion.PlusMinusMargin = new System.Drawing.Size(4, 4);
            this.UiListaDetalleCertificacion.PlusMinusSize = new System.Drawing.Size(40, 40);
            this.UiListaDetalleCertificacion.ScrollbarSmallChange = 24;
            this.UiListaDetalleCertificacion.ScrollbarWidth = 24;
            this.UiListaDetalleCertificacion.SelectionMode = Resco.Controls.AdvancedTree.SelectionMode.SelectDeselect;
            this.UiListaDetalleCertificacion.Size = new System.Drawing.Size(240, 276);
            this.UiListaDetalleCertificacion.TabIndex = 23;
            this.UiListaDetalleCertificacion.Templates.Add(this.NodeTemplate2);
            this.UiListaDetalleCertificacion.Templates.Add(this.NodeTemplate3);
            this.UiListaDetalleCertificacion.TouchScrolling = true;
            this.UiListaDetalleCertificacion.TouchSensitivity = 9;
            this.UiListaDetalleCertificacion.UseGradient = true;
            this.UiListaDetalleCertificacion.Visible = false;
            this.UiListaDetalleCertificacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaCertificacion_KeyUp);
            // 
            // NodeTemplate2
            // 
            this.NodeTemplate2.BackColor = System.Drawing.Color.Transparent;
            this.NodeTemplate2.CellTemplates.Add(this.CERTIFICATION_TYPE);
            this.NodeTemplate2.CellTemplates.Add(this.MATERIAL_ID);
            this.NodeTemplate2.CellTemplates.Add(this.QTY);
            this.NodeTemplate2.GradientBackColor = new Resco.Controls.AdvancedTree.GradientColor(System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.SystemColors.ControlLightLight, Resco.Controls.AdvancedTree.FillDirection.Vertical);
            this.NodeTemplate2.Height = 40;
            this.NodeTemplate2.Name = "NodeTemplate2";
            // 
            // CERTIFICATION_TYPE
            // 
            this.CERTIFICATION_TYPE.Border = Resco.Controls.AdvancedTree.BorderType.Raised;
            this.CERTIFICATION_TYPE.CellSource.ColumnName = "CERTIFICATION_TYPE";
            this.CERTIFICATION_TYPE.CustomizeCell = true;
            this.CERTIFICATION_TYPE.DesignName = "CERTIFICATION_TYPE";
            this.CERTIFICATION_TYPE.ForeColor = System.Drawing.Color.White;
            this.CERTIFICATION_TYPE.Location = new System.Drawing.Point(0, 11);
            this.CERTIFICATION_TYPE.SelectedBackColor = System.Drawing.Color.White;
            this.CERTIFICATION_TYPE.Size = new System.Drawing.Size(70, 25);
            this.CERTIFICATION_TYPE.TextFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            // 
            // MATERIAL_ID
            // 
            this.MATERIAL_ID.Border = Resco.Controls.AdvancedTree.BorderType.Raised;
            this.MATERIAL_ID.CellSource.ColumnName = "MATERIAL_ID";
            this.MATERIAL_ID.CustomizeCell = true;
            this.MATERIAL_ID.DesignName = "MATERIAL_ID";
            this.MATERIAL_ID.ForeColor = System.Drawing.Color.White;
            this.MATERIAL_ID.Location = new System.Drawing.Point(71, 11);
            this.MATERIAL_ID.SelectedBackColor = System.Drawing.Color.White;
            this.MATERIAL_ID.Size = new System.Drawing.Size(90, 25);
            this.MATERIAL_ID.TextFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            // 
            // QTY
            // 
            this.QTY.Border = Resco.Controls.AdvancedTree.BorderType.Raised;
            this.QTY.CellSource.ColumnName = "QTY";
            this.QTY.CustomizeCell = true;
            this.QTY.DesignName = "QTY";
            this.QTY.ForeColor = System.Drawing.Color.White;
            this.QTY.Location = new System.Drawing.Point(160, 11);
            this.QTY.SelectedBackColor = System.Drawing.Color.White;
            this.QTY.Size = new System.Drawing.Size(35, 25);
            this.QTY.TextFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            // 
            // NodeTemplate3
            // 
            this.NodeTemplate3.BackColor = System.Drawing.Color.Transparent;
            this.NodeTemplate3.CellTemplates.Add(this.SERIAL_NUMBER);
            this.NodeTemplate3.GradientBackColor = new Resco.Controls.AdvancedTree.GradientColor(System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.SystemColors.ControlLightLight, Resco.Controls.AdvancedTree.FillDirection.Vertical);
            this.NodeTemplate3.Height = 40;
            this.NodeTemplate3.Name = "NodeTemplate3";
            // 
            // SERIAL_NUMBER
            // 
            this.SERIAL_NUMBER.Border = Resco.Controls.AdvancedTree.BorderType.Raised;
            this.SERIAL_NUMBER.CellSource.ColumnName = "SERIAL_NUMBER";
            this.SERIAL_NUMBER.CustomizeCell = true;
            this.SERIAL_NUMBER.DesignName = "SERIAL_NUMBER";
            this.SERIAL_NUMBER.ForeColor = System.Drawing.Color.White;
            this.SERIAL_NUMBER.Location = new System.Drawing.Point(0, 0);
            this.SERIAL_NUMBER.SelectedBackColor = System.Drawing.Color.White;
            this.SERIAL_NUMBER.Size = new System.Drawing.Size(194, 25);
            this.SERIAL_NUMBER.TextFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            // 
            // UiBotonFinalizar
            // 
            this.UiBotonFinalizar.BackColor = System.Drawing.Color.Black;
            this.UiBotonFinalizar.BorderColor = System.Drawing.Color.Goldenrod;
            this.UiBotonFinalizar.BorderStyle = Resco.Controls.RescoBorderStyle.FixedSingle;
            this.UiBotonFinalizar.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonFinalizar.ForeColor = System.Drawing.Color.White;
            this.UiBotonFinalizar.Location = new System.Drawing.Point(162, 322);
            this.UiBotonFinalizar.Name = "UiBotonFinalizar";
            this.UiBotonFinalizar.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonFinalizar.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonFinalizar.Size = new System.Drawing.Size(75, 75);
            this.UiBotonFinalizar.TabIndex = 24;
            this.UiBotonFinalizar.Text = "Finalizar";
            this.UiBotonFinalizar.Visible = false;
            this.UiBotonFinalizar.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonFinalizar.WordWrap = true;
            this.UiBotonFinalizar.Click += new System.EventHandler(this.UiBotonFinalizar_Click);
            // 
            // CertificacionDeIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.UiBotonFinalizar);
            this.Controls.Add(this.UiListaDetalleCertificacion);
            this.Controls.Add(this.UiBotonDetalle);
            this.Controls.Add(this.UiBotonCrearCertificacion);
            this.Controls.Add(this.UiVistaCertificacion);
            this.Name = "CertificacionDeIngreso";
            this.Size = new System.Drawing.Size(240, 400);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaCertificacion_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonCrearCertificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonFinalizar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Resco.Controls.DetailView.DetailView UiVistaCertificacion;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonCrearCertificacion;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonDetalle;
        private Resco.Controls.DetailView.Item Separator1;
        private Resco.Controls.DetailView.Item UiEtiquetaEncabezado;
        private Resco.Controls.DetailView.ItemTextBox UiTextoManifiesto;
        private Resco.Controls.DetailView.ItemAdvancedComboBox UiListaTipoCertificacion;
        private Resco.Controls.DetailView.ItemTextBox UiTextoEscanear;
        private Resco.Controls.DetailView.ItemTextBox UiEtiquetaDescripcion;
        private Resco.Controls.DetailView.ItemTextBox UiTextoCantidad;
        internal Resco.Controls.AdvancedTree.AdvancedTree UiListaDetalleCertificacion;
        private Resco.Controls.AdvancedTree.NodeTemplate NodeTemplate2;
        private Resco.Controls.AdvancedTree.TextCell CERTIFICATION_TYPE;
        private Resco.Controls.AdvancedTree.TextCell MATERIAL_ID;
        private Resco.Controls.AdvancedTree.TextCell QTY;
        private Resco.Controls.AdvancedTree.NodeTemplate NodeTemplate3;
        private Resco.Controls.AdvancedTree.TextCell SERIAL_NUMBER;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonFinalizar;

    }
}
