namespace MobilityScm.Modelo.Vistas.Operaciones.Vistas
{
    partial class LicenciasUnificacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenciasUnificacion));
            this.UiTreeDetalle = new Resco.Controls.AdvancedTree.AdvancedTree();
            this.nodeTemplate1 = new Resco.Controls.AdvancedTree.NodeTemplate();
            this.textCell1 = new Resco.Controls.AdvancedTree.TextCell();
            this.UiBotonImprimirLicencia = new Resco.Controls.AdvancedTree.ButtonCell();
            this.nodeTemplate2 = new Resco.Controls.AdvancedTree.NodeTemplate();
            this.textCell2 = new Resco.Controls.AdvancedTree.TextCell();
            this.textCell3 = new Resco.Controls.AdvancedTree.TextCell();
            this.nodeTemplate3 = new Resco.Controls.AdvancedTree.NodeTemplate();
            this.textCell4 = new Resco.Controls.AdvancedTree.TextCell();
            this.textCell5 = new Resco.Controls.AdvancedTree.TextCell();
            this.textCell6 = new Resco.Controls.AdvancedTree.TextCell();
            this.textCell7 = new Resco.Controls.AdvancedTree.TextCell();
            this.textCell8 = new Resco.Controls.AdvancedTree.TextCell();
            this.SuspendLayout();
            // 
            // UiTreeDetalle
            // 
            this.UiTreeDetalle.AutoScroll = true;
            this.UiTreeDetalle.BackColor = System.Drawing.Color.Transparent;
            this.UiTreeDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiTreeDetalle.GradientBackColor = new Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.AdvancedTree.FillDirection.Vertical);
            this.UiTreeDetalle.GridColor = System.Drawing.Color.Transparent;
            this.UiTreeDetalle.KeyNavigation = true;
            this.UiTreeDetalle.Location = new System.Drawing.Point(0, 0);
            this.UiTreeDetalle.MinusImage = ((System.Drawing.Image)(resources.GetObject("UiTreeDetalle.MinusImage")));
            this.UiTreeDetalle.Name = "UiTreeDetalle";
            this.UiTreeDetalle.PlusImage = ((System.Drawing.Image)(resources.GetObject("UiTreeDetalle.PlusImage")));
            this.UiTreeDetalle.PlusMinusMargin = new System.Drawing.Size(4, 4);
            this.UiTreeDetalle.PlusMinusSize = new System.Drawing.Size(32, 32);
            this.UiTreeDetalle.ScrollbarSmallChange = 24;
            this.UiTreeDetalle.ScrollbarWidth = 24;
            this.UiTreeDetalle.SelectionMode = Resco.Controls.AdvancedTree.SelectionMode.SelectDeselect;
            this.UiTreeDetalle.Size = new System.Drawing.Size(240, 400);
            this.UiTreeDetalle.TabIndex = 1;
            this.UiTreeDetalle.Templates.Add(this.nodeTemplate1);
            this.UiTreeDetalle.Templates.Add(this.nodeTemplate2);
            this.UiTreeDetalle.Templates.Add(this.nodeTemplate3);
            this.UiTreeDetalle.TouchScrolling = true;
            this.UiTreeDetalle.TouchSensitivity = 9;
            this.UiTreeDetalle.TreeNodeLines = true;
            this.UiTreeDetalle.UseGradient = true;
            this.UiTreeDetalle.ButtonClick += new Resco.Controls.AdvancedTree.ButtonEventHandler(this.UiTreeDetalle_ButtonClick);
            this.UiTreeDetalle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiTreeDetalle_KeyUp_1);
            // 
            // nodeTemplate1
            // 
            this.nodeTemplate1.BackColor = System.Drawing.Color.Transparent;
            this.nodeTemplate1.CellTemplates.Add(this.textCell1);
            this.nodeTemplate1.CellTemplates.Add(this.UiBotonImprimirLicencia);
            this.nodeTemplate1.ForeColor = System.Drawing.Color.Transparent;
            this.nodeTemplate1.GradientBackColor = new Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, Resco.Controls.AdvancedTree.FillDirection.Vertical);
            this.nodeTemplate1.Height = 30;
            this.nodeTemplate1.Name = "nodeTemplate1";
            this.nodeTemplate1.UseTemplateBackground = true;
            // 
            // textCell1
            // 
            this.textCell1.Border = Resco.Controls.AdvancedTree.BorderType.Raised;
            this.textCell1.CellSource.ColumnIndex = 1;
            this.textCell1.DesignName = "textCell1";
            this.textCell1.ForeColor = System.Drawing.Color.White;
            this.textCell1.FormatString = "Licencia: {0}";
            this.textCell1.Location = new System.Drawing.Point(0, 0);
            this.textCell1.Size = new System.Drawing.Size(120, 30);
            // 
            // UiBotonImprimirLicencia
            // 
            this.UiBotonImprimirLicencia.ButtonStyle = Resco.Controls.AdvancedTree.ButtonCell.ButtonType.VistaStyleImageButton;
            this.UiBotonImprimirLicencia.DesignName = "UiBotonImprimirLicencia";
            this.UiBotonImprimirLicencia.Location = new System.Drawing.Point(120, 0);
            this.UiBotonImprimirLicencia.Size = new System.Drawing.Size(-1, 30);
            this.UiBotonImprimirLicencia.Text = "Imprimir";
            // 
            // nodeTemplate2
            // 
            this.nodeTemplate2.BackColor = System.Drawing.Color.Transparent;
            this.nodeTemplate2.CellTemplates.Add(this.textCell2);
            this.nodeTemplate2.CellTemplates.Add(this.textCell3);
            this.nodeTemplate2.ForeColor = System.Drawing.Color.Transparent;
            this.nodeTemplate2.GradientBackColor = new Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, Resco.Controls.AdvancedTree.FillDirection.Vertical);
            this.nodeTemplate2.Height = 30;
            this.nodeTemplate2.Name = "nodeTemplate2";
            this.nodeTemplate2.UseTemplateBackground = true;
            // 
            // textCell2
            // 
            this.textCell2.Border = Resco.Controls.AdvancedTree.BorderType.Raised;
            this.textCell2.CellSource.ColumnIndex = 1;
            this.textCell2.DesignName = "textCell2";
            this.textCell2.ForeColor = System.Drawing.Color.White;
            this.textCell2.Location = new System.Drawing.Point(0, 0);
            this.textCell2.Size = new System.Drawing.Size(90, 30);
            // 
            // textCell3
            // 
            this.textCell3.Border = Resco.Controls.AdvancedTree.BorderType.Raised;
            this.textCell3.CellSource.ColumnIndex = 2;
            this.textCell3.DesignName = "textCell3";
            this.textCell3.ForeColor = System.Drawing.Color.White;
            this.textCell3.Location = new System.Drawing.Point(90, 0);
            this.textCell3.Size = new System.Drawing.Size(-1, 30);
            // 
            // nodeTemplate3
            // 
            this.nodeTemplate3.BackColor = System.Drawing.Color.Transparent;
            this.nodeTemplate3.CellTemplates.Add(this.textCell4);
            this.nodeTemplate3.CellTemplates.Add(this.textCell5);
            this.nodeTemplate3.CellTemplates.Add(this.textCell6);
            this.nodeTemplate3.CellTemplates.Add(this.textCell7);
            this.nodeTemplate3.CellTemplates.Add(this.textCell8);
            this.nodeTemplate3.ForeColor = System.Drawing.Color.Transparent;
            this.nodeTemplate3.GradientBackColor = new Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, Resco.Controls.AdvancedTree.FillDirection.Vertical);
            this.nodeTemplate3.Height = 120;
            this.nodeTemplate3.Name = "nodeTemplate3";
            this.nodeTemplate3.UseTemplateBackground = true;
            // 
            // textCell4
            // 
            this.textCell4.Border = Resco.Controls.AdvancedTree.BorderType.Raised;
            this.textCell4.CellSource.ColumnIndex = 2;
            this.textCell4.DesignName = "textCell4";
            this.textCell4.ForeColor = System.Drawing.Color.White;
            this.textCell4.FormatString = "Lote: {0}";
            this.textCell4.Location = new System.Drawing.Point(0, 0);
            this.textCell4.Size = new System.Drawing.Size(-1, 30);
            // 
            // textCell5
            // 
            this.textCell5.Border = Resco.Controls.AdvancedTree.BorderType.Raised;
            this.textCell5.CellSource.ColumnIndex = 3;
            this.textCell5.DesignName = "textCell5";
            this.textCell5.ForeColor = System.Drawing.Color.White;
            this.textCell5.FormatString = "Fecha Expiración: {0}";
            this.textCell5.Location = new System.Drawing.Point(0, 30);
            this.textCell5.Size = new System.Drawing.Size(-1, 30);
            // 
            // textCell6
            // 
            this.textCell6.Border = Resco.Controls.AdvancedTree.BorderType.Raised;
            this.textCell6.CellSource.ColumnIndex = 5;
            this.textCell6.DesignName = "textCell6";
            this.textCell6.ForeColor = System.Drawing.Color.White;
            this.textCell6.FormatString = "Tono: {0}";
            this.textCell6.Location = new System.Drawing.Point(0, 60);
            this.textCell6.Size = new System.Drawing.Size(65, 30);
            // 
            // textCell7
            // 
            this.textCell7.Border = Resco.Controls.AdvancedTree.BorderType.Raised;
            this.textCell7.CellSource.ColumnIndex = 6;
            this.textCell7.DesignName = "textCell7";
            this.textCell7.ForeColor = System.Drawing.Color.White;
            this.textCell7.FormatString = "Calibre: {0}";
            this.textCell7.Location = new System.Drawing.Point(65, 60);
            this.textCell7.Size = new System.Drawing.Size(-1, 30);
            // 
            // textCell8
            // 
            this.textCell8.CellSource.ColumnIndex = 8;
            this.textCell8.DesignName = "textCell8";
            this.textCell8.FormatString = "Orden de Preparado: {0}";
            this.textCell8.Location = new System.Drawing.Point(0, 90);
            this.textCell8.Size = new System.Drawing.Size(-1, 30);
            // 
            // LicenciasUnificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.UiTreeDetalle);
            this.Name = "LicenciasUnificacion";
            this.Size = new System.Drawing.Size(240, 400);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LicenciasUnificacion_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private Resco.Controls.AdvancedTree.AdvancedTree UiTreeDetalle;
        private Resco.Controls.AdvancedTree.NodeTemplate nodeTemplate1;
        private Resco.Controls.AdvancedTree.TextCell textCell1;
        private Resco.Controls.AdvancedTree.ButtonCell UiBotonImprimirLicencia;
        private Resco.Controls.AdvancedTree.NodeTemplate nodeTemplate2;
        private Resco.Controls.AdvancedTree.TextCell textCell2;
        private Resco.Controls.AdvancedTree.TextCell textCell3;
        private Resco.Controls.AdvancedTree.NodeTemplate nodeTemplate3;
        private Resco.Controls.AdvancedTree.TextCell textCell4;
        private Resco.Controls.AdvancedTree.TextCell textCell5;
        private Resco.Controls.AdvancedTree.TextCell textCell6;
        private Resco.Controls.AdvancedTree.TextCell textCell7;
        private Resco.Controls.AdvancedTree.TextCell textCell8;
    }
}
