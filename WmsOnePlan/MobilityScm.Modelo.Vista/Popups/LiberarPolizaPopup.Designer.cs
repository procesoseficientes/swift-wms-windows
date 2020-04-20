namespace MobilityScm.Modelo.Popups
{
    partial class LiberarPolizaPopup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiberarPolizaPopup));
            this.label1 = new System.Windows.Forms.Label();
            this.UiTxtDocumento = new DevExpress.XtraEditors.TextEdit();
            this.UiMemoComentario = new DevExpress.XtraEditors.MemoEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.UiBtnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.UiBtnCancelar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.UiTxtDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiMemoComentario.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Documento Liberación";
            // 
            // UiTxtDocumento
            // 
            this.UiTxtDocumento.Location = new System.Drawing.Point(33, 56);
            this.UiTxtDocumento.Name = "UiTxtDocumento";
            this.UiTxtDocumento.Size = new System.Drawing.Size(230, 20);
            this.UiTxtDocumento.TabIndex = 1;
            // 
            // UiMemoComentario
            // 
            this.UiMemoComentario.Location = new System.Drawing.Point(33, 117);
            this.UiMemoComentario.Name = "UiMemoComentario";
            this.UiMemoComentario.Size = new System.Drawing.Size(442, 118);
            this.UiMemoComentario.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Comentarios";
            // 
            // UiBtnGrabar
            // 
            this.UiBtnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("UiBtnGrabar.Image")));
            this.UiBtnGrabar.Location = new System.Drawing.Point(93, 257);
            this.UiBtnGrabar.Name = "UiBtnGrabar";
            this.UiBtnGrabar.Size = new System.Drawing.Size(107, 23);
            this.UiBtnGrabar.TabIndex = 4;
            this.UiBtnGrabar.Text = "Grabar";
            this.UiBtnGrabar.Click += new System.EventHandler(this.UiBtnGrabar_Click);
            // 
            // UiBtnCancelar
            // 
            this.UiBtnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("UiBtnCancelar.Image")));
            this.UiBtnCancelar.Location = new System.Drawing.Point(295, 257);
            this.UiBtnCancelar.Name = "UiBtnCancelar";
            this.UiBtnCancelar.Size = new System.Drawing.Size(107, 23);
            this.UiBtnCancelar.TabIndex = 5;
            this.UiBtnCancelar.Text = "Cancelar";
            this.UiBtnCancelar.Click += new System.EventHandler(this.UiBtnCancelar_Click);
            // 
            // LiberarPolizaPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 310);
            this.Controls.Add(this.UiBtnCancelar);
            this.Controls.Add(this.UiBtnGrabar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UiMemoComentario);
            this.Controls.Add(this.UiTxtDocumento);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LiberarPolizaPopup";
            this.Text = "Liberar Póliza";
            this.Load += new System.EventHandler(this.LiberarPolizaPopup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UiTxtDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiMemoComentario.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit UiTxtDocumento;
        private DevExpress.XtraEditors.MemoEdit UiMemoComentario;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton UiBtnGrabar;
        private DevExpress.XtraEditors.SimpleButton UiBtnCancelar;
    }
}