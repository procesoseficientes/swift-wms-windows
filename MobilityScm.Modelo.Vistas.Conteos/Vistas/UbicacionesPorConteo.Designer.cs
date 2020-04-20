namespace MobilityScm.Modelo.Vistas
{
    partial class UbicacionesPorConteo
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
            this.UiListaUbicacionesPorConteo = new Resco.Controls.AdvancedList.AdvancedList();
            this.LOCATION = new Resco.Controls.AdvancedList.TextCell();
            this.WAREHOUSE_ID = new Resco.Controls.AdvancedList.TextCell();
            this.ZONE = new Resco.Controls.AdvancedList.TextCell();
            this.Ubicacion = new Resco.Controls.AdvancedList.RowTemplate();
            this.SuspendLayout();
            // 
            // UiListaUbicacionesPorConteo
            // 
            this.UiListaUbicacionesPorConteo.DataRows.Clear();
            this.UiListaUbicacionesPorConteo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiListaUbicacionesPorConteo.GradientBackColor = new Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.AdvancedList.FillDirection.Horizontal);
            this.UiListaUbicacionesPorConteo.Location = new System.Drawing.Point(0, 0);
            this.UiListaUbicacionesPorConteo.Name = "UiListaUbicacionesPorConteo";
            this.UiListaUbicacionesPorConteo.Size = new System.Drawing.Size(240, 400);
            this.UiListaUbicacionesPorConteo.TabIndex = 2;
            this.UiListaUbicacionesPorConteo.Templates.Add(this.Ubicacion);
            this.UiListaUbicacionesPorConteo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UbicacionesPorConteo_KeyUp);
            // 
            // LOCATION
            // 
            this.LOCATION.CellSource.ColumnName = "LOCATION";
            this.LOCATION.DesignName = "LOCATION";
            this.LOCATION.ForeColor = System.Drawing.Color.White;
            this.LOCATION.Location = new System.Drawing.Point(1, 4);
            this.LOCATION.Name = "LOCATION";
            this.LOCATION.Size = new System.Drawing.Size(239, 16);
            this.LOCATION.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            // 
            // WAREHOUSE_ID
            // 
            this.WAREHOUSE_ID.CellSource.ColumnName = "WAREHOUSE_ID";
            this.WAREHOUSE_ID.DesignName = "WAREHOUSE_ID";
            this.WAREHOUSE_ID.ForeColor = System.Drawing.Color.White;
            this.WAREHOUSE_ID.Location = new System.Drawing.Point(1, 22);
            this.WAREHOUSE_ID.Name = "WAREHOUSE_ID";
            this.WAREHOUSE_ID.Size = new System.Drawing.Size(108, 19);
            // 
            // ZONE
            // 
            this.ZONE.CellSource.ColumnName = "ZONE";
            this.ZONE.DesignName = "ZONE";
            this.ZONE.ForeColor = System.Drawing.Color.White;
            this.ZONE.Location = new System.Drawing.Point(111, 23);
            this.ZONE.Name = "ZONE";
            this.ZONE.Size = new System.Drawing.Size(129, 19);
            // 
            // Ubicacion
            // 
            this.Ubicacion.BackColor = System.Drawing.Color.Transparent;
            this.Ubicacion.CellTemplates.Add(this.LOCATION);
            this.Ubicacion.CellTemplates.Add(this.WAREHOUSE_ID);
            this.Ubicacion.CellTemplates.Add(this.ZONE);
            this.Ubicacion.Height = 42;
            this.Ubicacion.Name = "Ubicacion";
            // 
            // UbicacionesPorConteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.UiListaUbicacionesPorConteo);
            this.Name = "UbicacionesPorConteo";
            this.Size = new System.Drawing.Size(240, 400);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UbicacionesPorConteo_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        internal Resco.Controls.AdvancedList.AdvancedList UiListaUbicacionesPorConteo;
        private Resco.Controls.AdvancedList.RowTemplate Ubicacion;
        private Resco.Controls.AdvancedList.TextCell LOCATION;
        private Resco.Controls.AdvancedList.TextCell WAREHOUSE_ID;
        private Resco.Controls.AdvancedList.TextCell ZONE;
    }
}
