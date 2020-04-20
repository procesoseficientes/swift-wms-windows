namespace ConfiguracionBotonesYModeloDispositivo
{
    partial class Configuracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.UiEtiquetaNombreFabricante = new System.Windows.Forms.Label();
            this.UiEtiquetaFabricante = new System.Windows.Forms.Label();
            this.UiEtiquetaModelo = new System.Windows.Forms.Label();
            this.UiEtiquetaNombreModelo = new System.Windows.Forms.Label();
            this.UiEtiquetaNombreBoton = new System.Windows.Forms.Label();
            this.UiEtiquetaBoton = new System.Windows.Forms.Label();
            this.UiEtiquetaValorAscii = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UiEtiquetaNombreFabricante
            // 
            this.UiEtiquetaNombreFabricante.Location = new System.Drawing.Point(12, 18);
            this.UiEtiquetaNombreFabricante.Name = "UiEtiquetaNombreFabricante";
            this.UiEtiquetaNombreFabricante.Size = new System.Drawing.Size(91, 20);
            this.UiEtiquetaNombreFabricante.Text = "Manufacturer:";
            // 
            // UiEtiquetaFabricante
            // 
            this.UiEtiquetaFabricante.Location = new System.Drawing.Point(99, 11);
            this.UiEtiquetaFabricante.Name = "UiEtiquetaFabricante";
            this.UiEtiquetaFabricante.Size = new System.Drawing.Size(119, 38);
            // 
            // UiEtiquetaModelo
            // 
            this.UiEtiquetaModelo.Location = new System.Drawing.Point(80, 49);
            this.UiEtiquetaModelo.Name = "UiEtiquetaModelo";
            this.UiEtiquetaModelo.Size = new System.Drawing.Size(138, 43);
            // 
            // UiEtiquetaNombreModelo
            // 
            this.UiEtiquetaNombreModelo.Location = new System.Drawing.Point(12, 49);
            this.UiEtiquetaNombreModelo.Name = "UiEtiquetaNombreModelo";
            this.UiEtiquetaNombreModelo.Size = new System.Drawing.Size(59, 20);
            this.UiEtiquetaNombreModelo.Text = "Model:";
            // 
            // UiEtiquetaNombreBoton
            // 
            this.UiEtiquetaNombreBoton.Location = new System.Drawing.Point(12, 106);
            this.UiEtiquetaNombreBoton.Name = "UiEtiquetaNombreBoton";
            this.UiEtiquetaNombreBoton.Size = new System.Drawing.Size(206, 30);
            this.UiEtiquetaNombreBoton.Text = "Presione una tecla para mostrar el valor ASCII";
            // 
            // UiEtiquetaBoton
            // 
            this.UiEtiquetaBoton.Location = new System.Drawing.Point(3, 158);
            this.UiEtiquetaBoton.Name = "UiEtiquetaBoton";
            this.UiEtiquetaBoton.Size = new System.Drawing.Size(100, 30);
            this.UiEtiquetaBoton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UiEtiquetaValorAscii
            // 
            this.UiEtiquetaValorAscii.Location = new System.Drawing.Point(137, 158);
            this.UiEtiquetaValorAscii.Name = "UiEtiquetaValorAscii";
            this.UiEtiquetaValorAscii.Size = new System.Drawing.Size(100, 30);
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.UiEtiquetaValorAscii);
            this.Controls.Add(this.UiEtiquetaBoton);
            this.Controls.Add(this.UiEtiquetaNombreBoton);
            this.Controls.Add(this.UiEtiquetaModelo);
            this.Controls.Add(this.UiEtiquetaNombreModelo);
            this.Controls.Add(this.UiEtiquetaFabricante);
            this.Controls.Add(this.UiEtiquetaNombreFabricante);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu1;
            this.Name = "Configuracion";
            this.Text = "Form1";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Deactivate += new System.EventHandler(this.Configuracion_Deactivate);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Configuracion_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Configuracion_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label UiEtiquetaNombreFabricante;
        private System.Windows.Forms.Label UiEtiquetaFabricante;
        private System.Windows.Forms.Label UiEtiquetaModelo;
        private System.Windows.Forms.Label UiEtiquetaNombreModelo;
        private System.Windows.Forms.Label UiEtiquetaNombreBoton;
        private System.Windows.Forms.Label UiEtiquetaBoton;
        private System.Windows.Forms.Label UiEtiquetaValorAscii;
    }
}

