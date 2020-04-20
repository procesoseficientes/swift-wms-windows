namespace MobilityScm.Modelo.Vistas.EntregaDeDespacho.Vistas
{
    partial class EntregaDeDespacho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntregaDeDespacho));
            this.UiVistaEntregaCertificacion = new Resco.Controls.DetailView.DetailView();
            this.Separator1 = new Resco.Controls.DetailView.Item();
            this.UiEtiquetaEncabezado = new Resco.Controls.DetailView.Item();
            this.UiTextoEntrega = new Resco.Controls.DetailView.ItemTextBox();
            this.UiTextoEscanear = new Resco.Controls.DetailView.ItemTextBox();
            this.UiBotonFinalizar = new Resco.Controls.OutlookControls.ImageButton();
            this.UiBotonDetalle = new Resco.Controls.OutlookControls.ImageButton();
            this.UiBotonEntregarDespacho = new Resco.Controls.OutlookControls.ImageButton();
            this.UiListaDetalle = new Resco.Controls.AdvancedTree.AdvancedTree();
            this.NodeTemplate2 = new Resco.Controls.AdvancedTree.NodeTemplate();
            this.LABEL_ID = new Resco.Controls.AdvancedTree.TextCell();
            this.MATERIAL_ID = new Resco.Controls.AdvancedTree.TextCell();
            this.QTY = new Resco.Controls.AdvancedTree.TextCell();
            this.NodeTemplate3 = new Resco.Controls.AdvancedTree.NodeTemplate();
            this.SERIAL_NUMBER = new Resco.Controls.AdvancedTree.TextCell();
            this.UiBotonImprimir = new Resco.Controls.OutlookControls.ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonFinalizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonEntregarDespacho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonImprimir)).BeginInit();
            this.SuspendLayout();
            // 
            // UiVistaEntregaCertificacion
            // 
            this.UiVistaEntregaCertificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UiVistaEntregaCertificacion.DisabledForeColor = System.Drawing.Color.Gray;
            this.UiVistaEntregaCertificacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiVistaEntregaCertificacion.EnableDesignTimeCustomItems = true;
            this.UiVistaEntregaCertificacion.ForeColor = System.Drawing.Color.White;
            this.UiVistaEntregaCertificacion.GradientBackColor = new Resco.Controls.DetailView.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.DetailView.FillDirection.Vertical);
            this.UiVistaEntregaCertificacion.Items.Add(this.Separator1);
            this.UiVistaEntregaCertificacion.Items.Add(this.UiEtiquetaEncabezado);
            this.UiVistaEntregaCertificacion.Items.Add(this.UiTextoEntrega);
            this.UiVistaEntregaCertificacion.Items.Add(this.UiTextoEscanear);
            this.UiVistaEntregaCertificacion.KeyNavigation = true;
            this.UiVistaEntregaCertificacion.KeyTabNavigation = true;
            this.UiVistaEntregaCertificacion.LabelWidth = 90;
            this.UiVistaEntregaCertificacion.Location = new System.Drawing.Point(0, 0);
            this.UiVistaEntregaCertificacion.Name = "UiVistaEntregaCertificacion";
            this.UiVistaEntregaCertificacion.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.Dots;
            this.UiVistaEntregaCertificacion.SeparatorWidth = 0;
            this.UiVistaEntregaCertificacion.Size = new System.Drawing.Size(240, 400);
            this.UiVistaEntregaCertificacion.TabIndex = 22;
            this.UiVistaEntregaCertificacion.TabStop = false;
            this.UiVistaEntregaCertificacion.TouchScrolling = true;
            this.UiVistaEntregaCertificacion.UseClickVisualize = true;
            this.UiVistaEntregaCertificacion.UseGradient = true;
            this.UiVistaEntregaCertificacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaEntregaCertificacion_KeyUp);
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
            this.UiEtiquetaEncabezado.Label = "Entrega de Despacho";
            this.UiEtiquetaEncabezado.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiEtiquetaEncabezado.LabelBackColor = System.Drawing.Color.Black;
            this.UiEtiquetaEncabezado.LabelForeColor = System.Drawing.Color.White;
            this.UiEtiquetaEncabezado.LabelHeight = 24;
            this.UiEtiquetaEncabezado.Name = "UiEtiquetaEncabezado";
            this.UiEtiquetaEncabezado.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiEtiquetaEncabezado.TextBackColor = System.Drawing.Color.White;
            // 
            // UiTextoEntrega
            // 
            this.UiTextoEntrega.CharacterCasing = Resco.Controls.DetailView.ItemTextBoxCharacterCasing.Upper;
            this.UiTextoEntrega.Height = 20;
            this.UiTextoEntrega.Label = "Ola de Picking";
            this.UiTextoEntrega.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoEntrega.LabelForeColor = System.Drawing.Color.White;
            this.UiTextoEntrega.LabelHeight = 20;
            this.UiTextoEntrega.Name = "UiTextoEntrega";
            this.UiTextoEntrega.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoEntrega.Tag = "";
            this.UiTextoEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoEntrega.TextForeColor = System.Drawing.Color.White;
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
            this.UiTextoEscanear.ReadOnly = true;
            this.UiTextoEscanear.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoEscanear.Text = "...";
            this.UiTextoEscanear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoEscanear.TextForeColor = System.Drawing.Color.DarkOrange;
            // 
            // UiBotonFinalizar
            // 
            this.UiBotonFinalizar.BackColor = System.Drawing.Color.Black;
            this.UiBotonFinalizar.BorderColor = System.Drawing.Color.Goldenrod;
            this.UiBotonFinalizar.BorderStyle = Resco.Controls.RescoBorderStyle.FixedSingle;
            this.UiBotonFinalizar.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonFinalizar.ForeColor = System.Drawing.Color.White;
            this.UiBotonFinalizar.Location = new System.Drawing.Point(184, 322);
            this.UiBotonFinalizar.Name = "UiBotonFinalizar";
            this.UiBotonFinalizar.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonFinalizar.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonFinalizar.Size = new System.Drawing.Size(52, 75);
            this.UiBotonFinalizar.TabIndex = 27;
            this.UiBotonFinalizar.Text = "Finalizar";
            this.UiBotonFinalizar.Visible = false;
            this.UiBotonFinalizar.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonFinalizar.WordWrap = true;
            this.UiBotonFinalizar.Click += new System.EventHandler(this.UiBotonFinalizar_Click);
            this.UiBotonFinalizar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaEntregaCertificacion_KeyUp);
            // 
            // UiBotonDetalle
            // 
            this.UiBotonDetalle.BackColor = System.Drawing.Color.Black;
            this.UiBotonDetalle.BorderColor = System.Drawing.Color.Goldenrod;
            this.UiBotonDetalle.BorderStyle = Resco.Controls.RescoBorderStyle.FixedSingle;
            this.UiBotonDetalle.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonDetalle.ForeColor = System.Drawing.Color.White;
            this.UiBotonDetalle.Location = new System.Drawing.Point(68, 322);
            this.UiBotonDetalle.Name = "UiBotonDetalle";
            this.UiBotonDetalle.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonDetalle.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonDetalle.Size = new System.Drawing.Size(54, 75);
            this.UiBotonDetalle.TabIndex = 26;
            this.UiBotonDetalle.Text = "Detalle";
            this.UiBotonDetalle.Visible = false;
            this.UiBotonDetalle.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonDetalle.WordWrap = true;
            this.UiBotonDetalle.Click += new System.EventHandler(this.UiBotonDetalle_Click);
            this.UiBotonDetalle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaEntregaCertificacion_KeyUp);
            // 
            // UiBotonEntregarDespacho
            // 
            this.UiBotonEntregarDespacho.BackColor = System.Drawing.Color.Black;
            this.UiBotonEntregarDespacho.BorderColor = System.Drawing.Color.Goldenrod;
            this.UiBotonEntregarDespacho.BorderStyle = Resco.Controls.RescoBorderStyle.FixedSingle;
            this.UiBotonEntregarDespacho.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonEntregarDespacho.ForeColor = System.Drawing.Color.White;
            this.UiBotonEntregarDespacho.Location = new System.Drawing.Point(2, 323);
            this.UiBotonEntregarDespacho.Name = "UiBotonEntregarDespacho";
            this.UiBotonEntregarDespacho.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonEntregarDespacho.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonEntregarDespacho.Size = new System.Drawing.Size(61, 75);
            this.UiBotonEntregarDespacho.TabIndex = 25;
            this.UiBotonEntregarDespacho.Text = "Entregar Despacho";
            this.UiBotonEntregarDespacho.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonEntregarDespacho.WordWrap = true;
            this.UiBotonEntregarDespacho.Click += new System.EventHandler(this.UiBotonEntregarDespacho_Click);
            this.UiBotonEntregarDespacho.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaEntregaCertificacion_KeyUp);
            // 
            // UiListaDetalle
            // 
            this.UiListaDetalle.AutoScroll = true;
            this.UiListaDetalle.BackColor = System.Drawing.Color.Transparent;
            this.UiListaDetalle.GradientBackColor = new Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.AdvancedTree.FillDirection.Vertical);
            this.UiListaDetalle.GridColor = System.Drawing.Color.Transparent;
            this.UiListaDetalle.Location = new System.Drawing.Point(0, 46);
            this.UiListaDetalle.MinusImage = ((System.Drawing.Image)(resources.GetObject("UiListaDetalle.MinusImage")));
            this.UiListaDetalle.Name = "UiListaDetalle";
            this.UiListaDetalle.PlusImage = ((System.Drawing.Image)(resources.GetObject("UiListaDetalle.PlusImage")));
            this.UiListaDetalle.PlusMinusMargin = new System.Drawing.Size(4, 4);
            this.UiListaDetalle.PlusMinusSize = new System.Drawing.Size(40, 40);
            this.UiListaDetalle.ScrollbarSmallChange = 24;
            this.UiListaDetalle.ScrollbarWidth = 24;
            this.UiListaDetalle.SelectionMode = Resco.Controls.AdvancedTree.SelectionMode.SelectDeselect;
            this.UiListaDetalle.Size = new System.Drawing.Size(240, 270);
            this.UiListaDetalle.TabIndex = 28;
            this.UiListaDetalle.Templates.Add(this.NodeTemplate2);
            this.UiListaDetalle.Templates.Add(this.NodeTemplate3);
            this.UiListaDetalle.TouchScrolling = true;
            this.UiListaDetalle.TouchSensitivity = 9;
            this.UiListaDetalle.UseGradient = true;
            this.UiListaDetalle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaEntregaCertificacion_KeyUp);
            // 
            // NodeTemplate2
            // 
            this.NodeTemplate2.BackColor = System.Drawing.Color.Transparent;
            this.NodeTemplate2.CellTemplates.Add(this.LABEL_ID);
            this.NodeTemplate2.CellTemplates.Add(this.MATERIAL_ID);
            this.NodeTemplate2.CellTemplates.Add(this.QTY);
            this.NodeTemplate2.GradientBackColor = new Resco.Controls.AdvancedTree.GradientColor(System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.SystemColors.ControlLightLight, Resco.Controls.AdvancedTree.FillDirection.Vertical);
            this.NodeTemplate2.Height = 40;
            this.NodeTemplate2.Name = "NodeTemplate2";
            // 
            // LABEL_ID
            // 
            this.LABEL_ID.Border = Resco.Controls.AdvancedTree.BorderType.Raised;
            this.LABEL_ID.CellSource.ColumnName = "LABEL_ID";
            this.LABEL_ID.CustomizeCell = true;
            this.LABEL_ID.DesignName = "LABEL_ID";
            this.LABEL_ID.ForeColor = System.Drawing.Color.White;
            this.LABEL_ID.Location = new System.Drawing.Point(0, 11);
            this.LABEL_ID.SelectedBackColor = System.Drawing.Color.White;
            this.LABEL_ID.Size = new System.Drawing.Size(42, 25);
            this.LABEL_ID.TextFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            // 
            // MATERIAL_ID
            // 
            this.MATERIAL_ID.Border = Resco.Controls.AdvancedTree.BorderType.Raised;
            this.MATERIAL_ID.CellSource.ColumnName = "MATERIAL_ID";
            this.MATERIAL_ID.CustomizeCell = true;
            this.MATERIAL_ID.DesignName = "MATERIAL_ID";
            this.MATERIAL_ID.ForeColor = System.Drawing.Color.White;
            this.MATERIAL_ID.Location = new System.Drawing.Point(44, 11);
            this.MATERIAL_ID.SelectedBackColor = System.Drawing.Color.White;
            this.MATERIAL_ID.Size = new System.Drawing.Size(110, 25);
            this.MATERIAL_ID.TextFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            // 
            // QTY
            // 
            this.QTY.Border = Resco.Controls.AdvancedTree.BorderType.Raised;
            this.QTY.CellSource.ColumnName = "QTY";
            this.QTY.CustomizeCell = true;
            this.QTY.DesignName = "QTY";
            this.QTY.ForeColor = System.Drawing.Color.White;
            this.QTY.Location = new System.Drawing.Point(156, 11);
            this.QTY.SelectedBackColor = System.Drawing.Color.White;
            this.QTY.Size = new System.Drawing.Size(39, 25);
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
            // UiBotonImprimir
            // 
            this.UiBotonImprimir.BackColor = System.Drawing.Color.Black;
            this.UiBotonImprimir.BorderColor = System.Drawing.Color.Goldenrod;
            this.UiBotonImprimir.BorderStyle = Resco.Controls.RescoBorderStyle.FixedSingle;
            this.UiBotonImprimir.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.UiBotonImprimir.ForeColor = System.Drawing.Color.White;
            this.UiBotonImprimir.Location = new System.Drawing.Point(127, 322);
            this.UiBotonImprimir.Name = "UiBotonImprimir";
            this.UiBotonImprimir.PressedBackColor = System.Drawing.Color.Orange;
            this.UiBotonImprimir.PressedForeColor = System.Drawing.Color.White;
            this.UiBotonImprimir.Size = new System.Drawing.Size(54, 75);
            this.UiBotonImprimir.TabIndex = 29;
            this.UiBotonImprimir.Text = "Imprimir Etiqueta";
            this.UiBotonImprimir.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.UiBotonImprimir.WordWrap = true;
            this.UiBotonImprimir.Click += new System.EventHandler(this.UiBotonImprimir_Click);
            this.UiBotonImprimir.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaEntregaCertificacion_KeyUp);
            // 
            // EntregaDeDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.UiBotonImprimir);
            this.Controls.Add(this.UiListaDetalle);
            this.Controls.Add(this.UiBotonFinalizar);
            this.Controls.Add(this.UiBotonDetalle);
            this.Controls.Add(this.UiBotonEntregarDespacho);
            this.Controls.Add(this.UiVistaEntregaCertificacion);
            this.Name = "EntregaDeDespacho";
            this.Size = new System.Drawing.Size(240, 400);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaEntregaCertificacion_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonFinalizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonEntregarDespacho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiBotonImprimir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Resco.Controls.DetailView.DetailView UiVistaEntregaCertificacion;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonFinalizar;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonDetalle;
        internal Resco.Controls.OutlookControls.ImageButton UiBotonEntregarDespacho;
        private Resco.Controls.DetailView.Item Separator1;
        private Resco.Controls.DetailView.Item UiEtiquetaEncabezado;
        private Resco.Controls.DetailView.ItemTextBox UiTextoEntrega;
        private Resco.Controls.DetailView.ItemTextBox UiTextoEscanear;
        internal Resco.Controls.AdvancedTree.AdvancedTree UiListaDetalle;
        private Resco.Controls.AdvancedTree.NodeTemplate NodeTemplate2;
        private Resco.Controls.AdvancedTree.TextCell LABEL_ID;
        private Resco.Controls.AdvancedTree.TextCell MATERIAL_ID;
        private Resco.Controls.AdvancedTree.TextCell QTY;
        private Resco.Controls.AdvancedTree.NodeTemplate NodeTemplate3;
        private Resco.Controls.AdvancedTree.TextCell SERIAL_NUMBER;
        private Resco.Controls.OutlookControls.ImageButton UiBotonImprimir;

    }
}
