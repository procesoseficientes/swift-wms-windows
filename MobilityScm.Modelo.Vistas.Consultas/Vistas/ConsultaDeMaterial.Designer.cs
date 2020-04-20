namespace MobilityScm.Modelo.Vistas
{
    partial class ConsultaDeMaterial
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
            this.UiVistaConsultaMaterial = new Resco.Controls.DetailView.DetailView();
            this.UiSeparador = new Resco.Controls.DetailView.Item();
            this.UiEtiquetaEncabezado = new Resco.Controls.DetailView.Item();
            this.UiTextoCodigoSku = new Resco.Controls.DetailView.ItemTextBox();
            this.UiTextoDescripcionMaterial = new Resco.Controls.DetailView.ItemTextBox();
            this.UiTextoCliente = new Resco.Controls.DetailView.ItemTextBox();
            this.SuspendLayout();
            // 
            // UiVistaConsultaMaterial
            // 
            this.UiVistaConsultaMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UiVistaConsultaMaterial.DisabledForeColor = System.Drawing.Color.Gray;
            this.UiVistaConsultaMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiVistaConsultaMaterial.EnableDesignTimeCustomItems = true;
            this.UiVistaConsultaMaterial.ForeColor = System.Drawing.Color.White;
            this.UiVistaConsultaMaterial.GradientBackColor = new Resco.Controls.DetailView.GradientColor(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(40)))), ((int)(((byte)(71))))), System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(78)))), ((int)(((byte)(132))))), Resco.Controls.DetailView.FillDirection.Vertical);
            this.UiVistaConsultaMaterial.Items.Add(this.UiSeparador);
            this.UiVistaConsultaMaterial.Items.Add(this.UiEtiquetaEncabezado);
            this.UiVistaConsultaMaterial.Items.Add(this.UiTextoCodigoSku);
            this.UiVistaConsultaMaterial.Items.Add(this.UiTextoDescripcionMaterial);
            this.UiVistaConsultaMaterial.Items.Add(this.UiTextoCliente);
            this.UiVistaConsultaMaterial.KeyNavigation = true;
            this.UiVistaConsultaMaterial.KeyTabNavigation = true;
            this.UiVistaConsultaMaterial.LabelWidth = 90;
            this.UiVistaConsultaMaterial.Location = new System.Drawing.Point(0, 0);
            this.UiVistaConsultaMaterial.Name = "UiVistaConsultaMaterial";
            this.UiVistaConsultaMaterial.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.Dots;
            this.UiVistaConsultaMaterial.SeparatorWidth = 0;
            this.UiVistaConsultaMaterial.Size = new System.Drawing.Size(240, 400);
            this.UiVistaConsultaMaterial.TabIndex = 4;
            this.UiVistaConsultaMaterial.TabStop = false;
            this.UiVistaConsultaMaterial.TouchScrolling = true;
            this.UiVistaConsultaMaterial.UseClickVisualize = true;
            this.UiVistaConsultaMaterial.UseGradient = true;
            this.UiVistaConsultaMaterial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaMasterPack_KeyUp);
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
            this.UiEtiquetaEncabezado.Label = "Consulta de Sku";
            this.UiEtiquetaEncabezado.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiEtiquetaEncabezado.LabelBackColor = System.Drawing.Color.Black;
            this.UiEtiquetaEncabezado.LabelForeColor = System.Drawing.Color.White;
            this.UiEtiquetaEncabezado.LabelHeight = 24;
            this.UiEtiquetaEncabezado.Name = "UiEtiquetaEncabezado";
            this.UiEtiquetaEncabezado.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiEtiquetaEncabezado.TextBackColor = System.Drawing.Color.White;
            // 
            // UiTextoCodigoSku
            // 
            this.UiTextoCodigoSku.CharacterCasing = Resco.Controls.DetailView.ItemTextBoxCharacterCasing.Upper;
            this.UiTextoCodigoSku.Height = 24;
            this.UiTextoCodigoSku.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiTextoCodigoSku.Label = "Sku";
            this.UiTextoCodigoSku.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoCodigoSku.LabelForeColor = System.Drawing.Color.DarkOrange;
            this.UiTextoCodigoSku.LabelHeight = 24;
            this.UiTextoCodigoSku.Name = "UiTextoCodigoSku";
            this.UiTextoCodigoSku.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoCodigoSku.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UiTextoCodigoSku.TextForeColor = System.Drawing.Color.DarkOrange;
            // 
            // UiTextoDescripcionMaterial
            // 
            this.UiTextoDescripcionMaterial.Height = 100;
            this.UiTextoDescripcionMaterial.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiTextoDescripcionMaterial.Label = "Descripción";
            this.UiTextoDescripcionMaterial.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.UiTextoDescripcionMaterial.LabelForeColor = System.Drawing.Color.Yellow;
            this.UiTextoDescripcionMaterial.LabelHeight = 24;
            this.UiTextoDescripcionMaterial.MultiLine = true;
            this.UiTextoDescripcionMaterial.Name = "UiTextoDescripcionMaterial";
            this.UiTextoDescripcionMaterial.ReadOnly = true;
            this.UiTextoDescripcionMaterial.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoDescripcionMaterial.TextForeColor = System.Drawing.Color.Yellow;
            // 
            // UiTextoCliente
            // 
            this.UiTextoCliente.Height = 24;
            this.UiTextoCliente.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat;
            this.UiTextoCliente.Label = "Cliente";
            this.UiTextoCliente.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.UiTextoCliente.LabelForeColor = System.Drawing.Color.Yellow;
            this.UiTextoCliente.LabelHeight = 24;
            this.UiTextoCliente.Name = "UiTextoCliente";
            this.UiTextoCliente.ReadOnly = true;
            this.UiTextoCliente.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop;
            this.UiTextoCliente.TextForeColor = System.Drawing.Color.Yellow;
            this.UiTextoCliente.Visible = false;
            // 
            // ConsultaDeMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.UiVistaConsultaMaterial);
            this.Name = "ConsultaDeMaterial";
            this.Size = new System.Drawing.Size(240, 400);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UiVistaMasterPack_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        internal Resco.Controls.DetailView.DetailView UiVistaConsultaMaterial;
        private Resco.Controls.DetailView.Item UiSeparador;
        private Resco.Controls.DetailView.Item UiEtiquetaEncabezado;
        private Resco.Controls.DetailView.ItemTextBox UiTextoCodigoSku;
        private Resco.Controls.DetailView.ItemTextBox UiTextoDescripcionMaterial;
        private Resco.Controls.DetailView.ItemTextBox UiTextoCliente;
    }
}
