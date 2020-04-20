namespace MobilityScm.Modelo.Vistas
{
    partial class ConsultaDeBodega
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
            this.UiVistaConsultaUbicacion = new Resco.Controls.DetailView.DetailView();
            this.UiSeparador = new Resco.Controls.DetailView.Item();
            this.UiEtiquetaEncabezado = new Resco.Controls.DetailView.Item();
            this.UiTextoBodega = new Resco.Controls.DetailView.ItemTextBox();
            this.SuspendLayout();
            // 
            // UiVistaConsultaUbicacion
            // 
            this.UiVistaConsultaUbicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UiVistaConsultaUbicacion.DisabledForeColor = System.Drawing.Color.Gray;
            this.UiVistaConsultaUbicacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiVistaConsultaUbicacion.EnableDesignTimeCustomItems = true;
            this.UiVistaConsultaUbicacion.ForeColor = System.Drawing.Color.White;
            this.UiVistaConsultaUbicacion.GradientBackColor = new Resco.Controls.DetailView.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.DetailView.FillDirection.Vertical);
            this.UiVistaConsultaUbicacion.Items.Add(this.UiSeparador);
            this.UiVistaConsultaUbicacion.Items.Add(this.UiEtiquetaEncabezado);
            this.UiVistaConsultaUbicacion.Items.Add(this.UiTextoBodega);
            this.UiVistaConsultaUbicacion.KeyNavigation = true;
            this.UiVistaConsultaUbicacion.KeyTabNavigation = true;
            this.UiVistaConsultaUbicacion.LabelWidth = 90;
            this.UiVistaConsultaUbicacion.Location = new System.Drawing.Point(0, 0);
            this.UiVistaConsultaUbicacion.Name = "UiVistaConsultaUbicacion";
            this.UiVistaConsultaUbicacion.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.Dots;
            this.UiVistaConsultaUbicacion.SeparatorWidth = 0;
            this.UiVistaConsultaUbicacion.Size = new System.Drawing.Size(240, 400);
            this.UiVistaConsultaUbicacion.TabIndex = 4;
            this.UiVistaConsultaUbicacion.TabStop = false;
            this.UiVistaConsultaUbicacion.TouchScrolling = true;
            this.UiVistaConsultaUbicacion.UseClickVisualize = true;
            this.UiVistaConsultaUbicacion.UseGradient = true;
            this.UiVistaConsultaUbicacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaMasterPack_KeyUp);
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
            this.UiEtiquetaEncabezado.Label = "Consulta Bodega";
            this.UiEtiquetaEncabezado.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiEtiquetaEncabezado.LabelBackColor = System.Drawing.Color.Black;
            this.UiEtiquetaEncabezado.LabelForeColor = System.Drawing.Color.White;
            this.UiEtiquetaEncabezado.LabelHeight = 24;
            this.UiEtiquetaEncabezado.Name = "UiEtiquetaEncabezado";
            this.UiEtiquetaEncabezado.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiEtiquetaEncabezado.TextBackColor = System.Drawing.Color.White;
            // 
            // UiTextoBodega
            // 
            this.UiTextoBodega.CharacterCasing = Resco.Controls.DetailView.ItemTextBoxCharacterCasing.Upper;
            this.UiTextoBodega.Height = 24;
            this.UiTextoBodega.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiTextoBodega.Label = "Bodega";
            this.UiTextoBodega.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoBodega.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiTextoBodega.LabelHeight = 24;
            this.UiTextoBodega.Name = "UiTextoBodega";
            this.UiTextoBodega.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoBodega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoBodega.TextForeColor = System.Drawing.Color.DarkOrange;
            // 
            // ConsultaDeBodega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.UiVistaConsultaUbicacion);
            this.Name = "ConsultaDeBodega";
            this.Size = new System.Drawing.Size(240, 400);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaMasterPack_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        internal Resco.Controls.DetailView.DetailView UiVistaConsultaUbicacion;
        private Resco.Controls.DetailView.Item UiSeparador;
        private Resco.Controls.DetailView.Item UiEtiquetaEncabezado;
        private Resco.Controls.DetailView.ItemTextBox UiTextoBodega;
    }
}
