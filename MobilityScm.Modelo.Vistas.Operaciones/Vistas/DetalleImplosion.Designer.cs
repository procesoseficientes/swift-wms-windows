namespace MobilityScm.Modelo.Vistas.Operaciones.Vistas
{
    partial class DetalleImplosion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetalleImplosion));
            this.UiListaDetalle = new Resco.Controls.AdvancedList.AdvancedList();
            this.UiTextoMaterial = new Resco.Controls.AdvancedList.TextCell();
            this.UiTextoCantidad = new Resco.Controls.AdvancedList.TextCell();
            this.UiTextoAcumulado = new Resco.Controls.AdvancedList.TextCell();
            this.RowTemplate2 = new Resco.Controls.AdvancedList.RowTemplate();
            this.UiEtiquetaMaterial = new Resco.Controls.AdvancedList.TextCell();
            this.UiEtiquetaCantidad = new Resco.Controls.AdvancedList.TextCell();
            this.UiEtiquetaProcesado = new Resco.Controls.AdvancedList.TextCell();
            this.RowTemplate1 = new Resco.Controls.AdvancedList.RowTemplate();
            this.SuspendLayout();
            // 
            // UiListaDetalle
            // 
            this.UiListaDetalle.DataRows.Clear();
            this.UiListaDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiListaDetalle.GradientBackColor = new Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.AdvancedList.FillDirection.Vertical);
            this.UiListaDetalle.HeaderRow = new Resco.Controls.AdvancedList.HeaderRow(1, new string[] {
            resources.GetString("UiListaDetalle.HeaderRow")});
            this.UiListaDetalle.Location = new System.Drawing.Point(0, 0);
            this.UiListaDetalle.Name = "UiListaDetalle";
            this.UiListaDetalle.ShowHeader = true;
            this.UiListaDetalle.Size = new System.Drawing.Size(240, 400);
            this.UiListaDetalle.TabIndex = 0;
            this.UiListaDetalle.Templates.Add(this.RowTemplate2);
            this.UiListaDetalle.Templates.Add(this.RowTemplate1);
            this.UiListaDetalle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiListaDetalle_KeyUp);
            // 
            // UiTextoMaterial
            // 
            this.UiTextoMaterial.CellSource.ColumnName = "MATERIAL_ID";
            this.UiTextoMaterial.DesignName = "UiTextoMaterial";
            this.UiTextoMaterial.ForeColor = System.Drawing.Color.White;
            this.UiTextoMaterial.Location = new System.Drawing.Point(0, 0);
            this.UiTextoMaterial.Size = new System.Drawing.Size(137, 40);
            // 
            // UiTextoCantidad
            // 
            this.UiTextoCantidad.CellSource.ColumnName = "QTY";
            this.UiTextoCantidad.DesignName = "UiTextoCantidad";
            this.UiTextoCantidad.ForeColor = System.Drawing.Color.White;
            this.UiTextoCantidad.Location = new System.Drawing.Point(136, 0);
            this.UiTextoCantidad.Size = new System.Drawing.Size(54, 40);
            // 
            // UiTextoAcumulado
            // 
            this.UiTextoAcumulado.CellSource.ColumnName = "QTY_PROCESSED";
            this.UiTextoAcumulado.DesignName = "UiTextoAcumulado";
            this.UiTextoAcumulado.ForeColor = System.Drawing.Color.White;
            this.UiTextoAcumulado.Location = new System.Drawing.Point(189, 0);
            this.UiTextoAcumulado.Size = new System.Drawing.Size(51, 40);
            // 
            // RowTemplate2
            // 
            this.RowTemplate2.CellTemplates.Add(this.UiTextoMaterial);
            this.RowTemplate2.CellTemplates.Add(this.UiTextoCantidad);
            this.RowTemplate2.CellTemplates.Add(this.UiTextoAcumulado);
            this.RowTemplate2.GradientBackColor = new Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.AdvancedList.FillDirection.Horizontal);
            this.RowTemplate2.Height = 40;
            this.RowTemplate2.Name = "RowTemplate2";
            // 
            // UiEtiquetaMaterial
            // 
            this.UiEtiquetaMaterial.BackColor = System.Drawing.Color.Black;
            this.UiEtiquetaMaterial.CellSource.ConstantData = "Componente";
            this.UiEtiquetaMaterial.DesignName = "UiEtiquetaMaterial";
            this.UiEtiquetaMaterial.ForeColor = System.Drawing.Color.DarkOrange;
            this.UiEtiquetaMaterial.Location = new System.Drawing.Point(0, 0);
            this.UiEtiquetaMaterial.Size = new System.Drawing.Size(138, 30);
            // 
            // UiEtiquetaCantidad
            // 
            this.UiEtiquetaCantidad.BackColor = System.Drawing.Color.Black;
            this.UiEtiquetaCantidad.CellSource.ConstantData = "Cantidad";
            this.UiEtiquetaCantidad.DesignName = "UiEtiquetaCantidad";
            this.UiEtiquetaCantidad.ForeColor = System.Drawing.Color.DarkOrange;
            this.UiEtiquetaCantidad.Location = new System.Drawing.Point(137, 0);
            this.UiEtiquetaCantidad.Size = new System.Drawing.Size(51, 29);
            // 
            // UiEtiquetaProcesado
            // 
            this.UiEtiquetaProcesado.BackColor = System.Drawing.Color.Black;
            this.UiEtiquetaProcesado.CellSource.ConstantData = "Procesado";
            this.UiEtiquetaProcesado.DesignName = "UiEtiquetaProcesado";
            this.UiEtiquetaProcesado.ForeColor = System.Drawing.Color.DarkOrange;
            this.UiEtiquetaProcesado.Location = new System.Drawing.Point(188, 0);
            this.UiEtiquetaProcesado.Size = new System.Drawing.Size(-1, 29);
            // 
            // RowTemplate1
            // 
            this.RowTemplate1.CellTemplates.Add(this.UiEtiquetaMaterial);
            this.RowTemplate1.CellTemplates.Add(this.UiEtiquetaCantidad);
            this.RowTemplate1.CellTemplates.Add(this.UiEtiquetaProcesado);
            this.RowTemplate1.Height = 29;
            this.RowTemplate1.Name = "RowTemplate1";
            // 
            // DetalleImplosion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.UiListaDetalle);
            this.Name = "DetalleImplosion";
            this.Size = new System.Drawing.Size(240, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private Resco.Controls.AdvancedList.AdvancedList UiListaDetalle;
        private Resco.Controls.AdvancedList.RowTemplate RowTemplate2;
        private Resco.Controls.AdvancedList.TextCell UiTextoMaterial;
        private Resco.Controls.AdvancedList.TextCell UiTextoCantidad;
        private Resco.Controls.AdvancedList.TextCell UiTextoAcumulado;
        private Resco.Controls.AdvancedList.RowTemplate RowTemplate1;
        private Resco.Controls.AdvancedList.TextCell UiEtiquetaMaterial;
        private Resco.Controls.AdvancedList.TextCell UiEtiquetaCantidad;
        private Resco.Controls.AdvancedList.TextCell UiEtiquetaProcesado;

    }
}
