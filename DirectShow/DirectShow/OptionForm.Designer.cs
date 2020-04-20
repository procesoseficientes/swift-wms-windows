namespace DirectShow_Sample
{
    partial class OptionForm
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
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.textFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textXPos = new System.Windows.Forms.TextBox();
            this.textYPos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textWidth = new System.Windows.Forms.TextBox();
            this.textHeight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItemExit);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.Text = "File path : ";
            // 
            // textFilePath
            // 
            this.textFilePath.Location = new System.Drawing.Point(75, 14);
            this.textFilePath.Name = "textFilePath";
            this.textFilePath.Size = new System.Drawing.Size(162, 21);
            this.textFilePath.TabIndex = 1;
            this.textFilePath.Text = "Flash Storage\\\\Unitech.jpg";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.Text = "X Pos : ";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.Text = "Y Pos : ";
            // 
            // textXPos
            // 
            this.textXPos.Location = new System.Drawing.Point(63, 53);
            this.textXPos.Name = "textXPos";
            this.textXPos.Size = new System.Drawing.Size(68, 21);
            this.textXPos.TabIndex = 5;
            // 
            // textYPos
            // 
            this.textYPos.Location = new System.Drawing.Point(63, 83);
            this.textYPos.Name = "textYPos";
            this.textYPos.Size = new System.Drawing.Size(68, 21);
            this.textYPos.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.Text = "Width : ";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.Text = "Height : ";
            // 
            // textWidth
            // 
            this.textWidth.Location = new System.Drawing.Point(63, 117);
            this.textWidth.Name = "textWidth";
            this.textWidth.Size = new System.Drawing.Size(68, 21);
            this.textWidth.TabIndex = 9;
            // 
            // textHeight
            // 
            this.textHeight.Location = new System.Drawing.Point(63, 144);
            this.textHeight.Name = "textHeight";
            this.textHeight.Size = new System.Drawing.Size(68, 21);
            this.textHeight.TabIndex = 10;
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.textHeight);
            this.Controls.Add(this.textWidth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textYPos);
            this.Controls.Add(this.textXPos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textFilePath);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "OptionForm";
            this.Text = "OptionForm";
            this.Load += new System.EventHandler(this.OptionForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OptionForm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textXPos;
        private System.Windows.Forms.TextBox textYPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textWidth;
        private System.Windows.Forms.TextBox textHeight;
    }
}