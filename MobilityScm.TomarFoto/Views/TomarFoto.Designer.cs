namespace MobilityScm.Views
{
    partial class TomarFoto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TomarFoto));
            this.uiFondo = new System.Windows.Forms.PictureBox();
            this._imagenVista = new System.Windows.Forms.PictureBox();
            this.btnDeletePic = new Resco.Controls.OutlookControls.ImageButton();
            this.btnTakePic = new Resco.Controls.OutlookControls.ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeletePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTakePic)).BeginInit();
            this.SuspendLayout();
            // 
            // uiFondo
            // 
            this.uiFondo.Image = ((System.Drawing.Image)(resources.GetObject("uiFondo.Image")));
            this.uiFondo.Location = new System.Drawing.Point(0, 0);
            this.uiFondo.Name = "uiFondo";
            this.uiFondo.Size = new System.Drawing.Size(240, 400);
            // 
            // _imagenVista
            // 
            this._imagenVista.Location = new System.Drawing.Point(3, 3);
            this._imagenVista.Name = "_imagenVista";
            this._imagenVista.Size = new System.Drawing.Size(234, 313);
            this._imagenVista.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // btnDeletePic
            // 
            this.btnDeletePic.BackColor = System.Drawing.Color.Black;
            this.btnDeletePic.BorderColor = System.Drawing.Color.Orange;
            this.btnDeletePic.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.btnDeletePic.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.btnDeletePic.ForeColor = System.Drawing.Color.White;
            this.btnDeletePic.Location = new System.Drawing.Point(51, 322);
            this.btnDeletePic.Name = "btnDeletePic";
            this.btnDeletePic.PressedBackColor = System.Drawing.Color.Orange;
            this.btnDeletePic.PressedForeColor = System.Drawing.Color.White;
            this.btnDeletePic.Size = new System.Drawing.Size(65, 75);
            this.btnDeletePic.TabIndex = 26;
            this.btnDeletePic.Text = "Eliminar";
            this.btnDeletePic.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.btnDeletePic.WordWrap = true;
            this.btnDeletePic.Click += new System.EventHandler(this.btnDeletePic_Click);
            // 
            // btnTakePic
            // 
            this.btnTakePic.BackColor = System.Drawing.Color.Black;
            this.btnTakePic.BorderColor = System.Drawing.Color.Orange;
            this.btnTakePic.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton;
            this.btnTakePic.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.btnTakePic.ForeColor = System.Drawing.Color.White;
            this.btnTakePic.Location = new System.Drawing.Point(122, 322);
            this.btnTakePic.Name = "btnTakePic";
            this.btnTakePic.PressedBackColor = System.Drawing.Color.Orange;
            this.btnTakePic.PressedForeColor = System.Drawing.Color.White;
            this.btnTakePic.Size = new System.Drawing.Size(65, 75);
            this.btnTakePic.TabIndex = 27;
            this.btnTakePic.Text = "Foto";
            this.btnTakePic.VistaButtonInflate = new System.Drawing.Size(-2, -2);
            this.btnTakePic.WordWrap = true;
            this.btnTakePic.Click += new System.EventHandler(this.btnTakePic_Click);
            // 
            // TomarFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnTakePic);
            this.Controls.Add(this.btnDeletePic);
            this.Controls.Add(this._imagenVista);
            this.Controls.Add(this.uiFondo);
            this.Name = "TomarFoto";
            this.Size = new System.Drawing.Size(240, 400);
            ((System.ComponentModel.ISupportInitialize)(this.btnDeletePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTakePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox uiFondo;
        private System.Windows.Forms.PictureBox _imagenVista;
        internal Resco.Controls.OutlookControls.ImageButton btnDeletePic;
        internal Resco.Controls.OutlookControls.ImageButton btnTakePic;
    }
}
