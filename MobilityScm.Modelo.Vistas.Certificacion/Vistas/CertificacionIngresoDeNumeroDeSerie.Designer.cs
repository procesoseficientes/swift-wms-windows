namespace MobilityScm.Modelo.Vistas.Certificacion.Vistas
{
    partial class CertificacionIngresoDeNumeroDeSerie
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
            this.UiVistaCertificacion = new Resco.Controls.DetailView.DetailView();
            this.Separator1 = new Resco.Controls.DetailView.Item();
            this.UiEtiquetaEncabezado = new Resco.Controls.DetailView.Item();
            this.UiTextoMaterial = new Resco.Controls.DetailView.ItemTextBox();
            this.UiTextoNumeroDeSerie = new Resco.Controls.DetailView.ItemTextBox();
            this.UiTextoNumeroDeSerieAnterior = new Resco.Controls.DetailView.ItemTextBox();
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
            this.UiVistaCertificacion.Items.Add(this.UiTextoMaterial);
            this.UiVistaCertificacion.Items.Add(this.UiTextoNumeroDeSerie);
            this.UiVistaCertificacion.Items.Add(this.UiTextoNumeroDeSerieAnterior);
            this.UiVistaCertificacion.KeyNavigation = true;
            this.UiVistaCertificacion.KeyTabNavigation = true;
            this.UiVistaCertificacion.LabelWidth = 90;
            this.UiVistaCertificacion.Location = new System.Drawing.Point(0, 0);
            this.UiVistaCertificacion.Name = "UiVistaCertificacion";
            this.UiVistaCertificacion.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.Dots;
            this.UiVistaCertificacion.SeparatorWidth = 0;
            this.UiVistaCertificacion.Size = new System.Drawing.Size(240, 400);
            this.UiVistaCertificacion.TabIndex = 22;
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
            this.UiEtiquetaEncabezado.Label = "Certificación(Ingreso de Número de Series)";
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
            this.UiTextoMaterial.Height = 20;
            this.UiTextoMaterial.Label = "Material";
            this.UiTextoMaterial.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoMaterial.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiTextoMaterial.LabelHeight = 20;
            this.UiTextoMaterial.Name = "UiTextoMaterial";
            this.UiTextoMaterial.ReadOnly = true;
            this.UiTextoMaterial.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoMaterial.Text = "...";
            this.UiTextoMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoMaterial.TextForeColor = System.Drawing.Color.DarkOrange;
            // 
            // UiTextoNumeroDeSerie
            // 
            this.UiTextoNumeroDeSerie.Height = 20;
            this.UiTextoNumeroDeSerie.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiTextoNumeroDeSerie.Label = "Número de Serie";
            this.UiTextoNumeroDeSerie.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoNumeroDeSerie.LabelForeColor = System.Drawing.Color.White;
            this.UiTextoNumeroDeSerie.LabelHeight = 20;
            this.UiTextoNumeroDeSerie.Name = "UiTextoNumeroDeSerie";
            this.UiTextoNumeroDeSerie.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoNumeroDeSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UiTextoNumeroDeSerie.TextForeColor = System.Drawing.Color.White;
            // 
            // UiTextoNumeroDeSerieAnterior
            // 
            this.UiTextoNumeroDeSerieAnterior.Height = 20;
            this.UiTextoNumeroDeSerieAnterior.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiTextoNumeroDeSerieAnterior.Label = "Número de Serie Anterior";
            this.UiTextoNumeroDeSerieAnterior.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoNumeroDeSerieAnterior.LabelForeColor = System.Drawing.Color.White;
            this.UiTextoNumeroDeSerieAnterior.LabelHeight = 20;
            this.UiTextoNumeroDeSerieAnterior.Name = "UiTextoNumeroDeSerieAnterior";
            this.UiTextoNumeroDeSerieAnterior.ReadOnly = true;
            this.UiTextoNumeroDeSerieAnterior.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoNumeroDeSerieAnterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UiTextoNumeroDeSerieAnterior.TextForeColor = System.Drawing.Color.White;
            // 
            // CertificacionIngresoDeNumeroDeSerie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.UiVistaCertificacion);
            this.Name = "CertificacionIngresoDeNumeroDeSerie";
            this.Size = new System.Drawing.Size(240, 400);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaCertificacion_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        internal Resco.Controls.DetailView.DetailView UiVistaCertificacion;
        private Resco.Controls.DetailView.Item Separator1;
        private Resco.Controls.DetailView.Item UiEtiquetaEncabezado;
        private Resco.Controls.DetailView.ItemTextBox UiTextoMaterial;
        private Resco.Controls.DetailView.ItemTextBox UiTextoNumeroDeSerie;
        private Resco.Controls.DetailView.ItemTextBox UiTextoNumeroDeSerieAnterior;
    }
}
