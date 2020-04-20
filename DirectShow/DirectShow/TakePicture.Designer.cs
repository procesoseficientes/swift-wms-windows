namespace DirectShow
{
    partial class TakePicture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TakePicture));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItemCapture = new System.Windows.Forms.MenuItem();
            this.menuItemMenu = new System.Windows.Forms.MenuItem();
            this.menuItemBright = new System.Windows.Forms.MenuItem();
            this.menuItemBright3 = new System.Windows.Forms.MenuItem();
            this.menuItemBright2 = new System.Windows.Forms.MenuItem();
            this.menuItemBright1 = new System.Windows.Forms.MenuItem();
            this.menuItemBright0 = new System.Windows.Forms.MenuItem();
            this.menuItemBrightN1 = new System.Windows.Forms.MenuItem();
            this.menuItemBrightN2 = new System.Windows.Forms.MenuItem();
            this.menuItemBrightN3 = new System.Windows.Forms.MenuItem();
            this.menuItemColor = new System.Windows.Forms.MenuItem();
            this.menuItemResolution = new System.Windows.Forms.MenuItem();
            this.menuItemRes1 = new System.Windows.Forms.MenuItem();
            this.menuItemRes2 = new System.Windows.Forms.MenuItem();
            this.menuItemRes3 = new System.Windows.Forms.MenuItem();
            this.menuItemRes4 = new System.Windows.Forms.MenuItem();
            this.menuItemRes5 = new System.Windows.Forms.MenuItem();
            this.menuItemRes6 = new System.Windows.Forms.MenuItem();
            this.menuItemRes7 = new System.Windows.Forms.MenuItem();
            this.menuItemWBalance = new System.Windows.Forms.MenuItem();
            this.menuItemWBalance0 = new System.Windows.Forms.MenuItem();
            this.menuItemWBalance1 = new System.Windows.Forms.MenuItem();
            this.menuItemWBalance2 = new System.Windows.Forms.MenuItem();
            this.menuItemWBalance3 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom = new System.Windows.Forms.MenuItem();
            this.menuItemZoom1 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom2 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom3 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom4 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom5 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom6 = new System.Windows.Forms.MenuItem();
            this.menuItemStart = new System.Windows.Forms.MenuItem();
            this.menuItemStop = new System.Windows.Forms.MenuItem();
            this.menuItemFlash = new System.Windows.Forms.MenuItem();
            this.menuItemToggleLED = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItemCapture);
            this.mainMenu1.MenuItems.Add(this.menuItemMenu);
            // 
            // menuItemCapture
            // 
            this.menuItemCapture.Text = "Capturar";
            this.menuItemCapture.Click += new System.EventHandler(this.menuItemCapture_Click);
            // 
            // menuItemMenu
            // 
            this.menuItemMenu.MenuItems.Add(this.menuItemBright);
            this.menuItemMenu.MenuItems.Add(this.menuItemColor);
            this.menuItemMenu.MenuItems.Add(this.menuItemResolution);
            this.menuItemMenu.MenuItems.Add(this.menuItemWBalance);
            this.menuItemMenu.MenuItems.Add(this.menuItemZoom);
            this.menuItemMenu.MenuItems.Add(this.menuItemStart);
            this.menuItemMenu.MenuItems.Add(this.menuItemStop);
            this.menuItemMenu.MenuItems.Add(this.menuItemFlash);
            this.menuItemMenu.MenuItems.Add(this.menuItemToggleLED);
            this.menuItemMenu.MenuItems.Add(this.menuItemExit);
            this.menuItemMenu.Text = "Menu";
            // 
            // menuItemBright
            // 
            this.menuItemBright.MenuItems.Add(this.menuItemBright3);
            this.menuItemBright.MenuItems.Add(this.menuItemBright2);
            this.menuItemBright.MenuItems.Add(this.menuItemBright1);
            this.menuItemBright.MenuItems.Add(this.menuItemBright0);
            this.menuItemBright.MenuItems.Add(this.menuItemBrightN1);
            this.menuItemBright.MenuItems.Add(this.menuItemBrightN2);
            this.menuItemBright.MenuItems.Add(this.menuItemBrightN3);
            this.menuItemBright.Text = "Brillo";
            // 
            // menuItemBright3
            // 
            this.menuItemBright3.Text = "3";
            this.menuItemBright3.Click += new System.EventHandler(this.menuItemBright_Click);
            // 
            // menuItemBright2
            // 
            this.menuItemBright2.Text = "2";
            this.menuItemBright2.Click += new System.EventHandler(this.menuItemBright_Click);
            // 
            // menuItemBright1
            // 
            this.menuItemBright1.Text = "1";
            this.menuItemBright1.Click += new System.EventHandler(this.menuItemBright_Click);
            // 
            // menuItemBright0
            // 
            this.menuItemBright0.Checked = true;
            this.menuItemBright0.Text = "0";
            this.menuItemBright0.Click += new System.EventHandler(this.menuItemBright_Click);
            // 
            // menuItemBrightN1
            // 
            this.menuItemBrightN1.Text = "-1";
            this.menuItemBrightN1.Click += new System.EventHandler(this.menuItemBright_Click);
            // 
            // menuItemBrightN2
            // 
            this.menuItemBrightN2.Text = "-2";
            this.menuItemBrightN2.Click += new System.EventHandler(this.menuItemBright_Click);
            // 
            // menuItemBrightN3
            // 
            this.menuItemBrightN3.Text = "-3";
            this.menuItemBrightN3.Click += new System.EventHandler(this.menuItemBright_Click);
            // 
            // menuItemColor
            // 
            this.menuItemColor.Checked = true;
            this.menuItemColor.Text = "Color";
            this.menuItemColor.Click += new System.EventHandler(this.menuItemColor_Click);
            // 
            // menuItemResolution
            // 
            this.menuItemResolution.MenuItems.Add(this.menuItemRes1);
            this.menuItemResolution.MenuItems.Add(this.menuItemRes2);
            this.menuItemResolution.MenuItems.Add(this.menuItemRes3);
            this.menuItemResolution.MenuItems.Add(this.menuItemRes4);
            this.menuItemResolution.MenuItems.Add(this.menuItemRes5);
            this.menuItemResolution.MenuItems.Add(this.menuItemRes6);
            this.menuItemResolution.MenuItems.Add(this.menuItemRes7);
            this.menuItemResolution.Text = "Resolución";
            // 
            // menuItemRes1
            // 
            this.menuItemRes1.Checked = true;
            this.menuItemRes1.Text = "320 x 240";
            this.menuItemRes1.Click += new System.EventHandler(this.menuItemResolution_Click);
            // 
            // menuItemRes2
            // 
            this.menuItemRes2.Text = "640 x 480";
            this.menuItemRes2.Click += new System.EventHandler(this.menuItemResolution_Click);
            // 
            // menuItemRes3
            // 
            this.menuItemRes3.Text = "800 x 600";
            this.menuItemRes3.Click += new System.EventHandler(this.menuItemResolution_Click);
            // 
            // menuItemRes4
            // 
            this.menuItemRes4.Text = "1152 x 864";
            this.menuItemRes4.Click += new System.EventHandler(this.menuItemResolution_Click);
            // 
            // menuItemRes5
            // 
            this.menuItemRes5.Text = "1600 x 1200";
            this.menuItemRes5.Click += new System.EventHandler(this.menuItemResolution_Click);
            // 
            // menuItemRes6
            // 
            this.menuItemRes6.Text = "2048 x 1536";
            this.menuItemRes6.Click += new System.EventHandler(this.menuItemResolution_Click);
            // 
            // menuItemRes7
            // 
            this.menuItemRes7.Text = "2560 x 1920";
            this.menuItemRes7.Click += new System.EventHandler(this.menuItemResolution_Click);
            // 
            // menuItemWBalance
            // 
            this.menuItemWBalance.MenuItems.Add(this.menuItemWBalance0);
            this.menuItemWBalance.MenuItems.Add(this.menuItemWBalance1);
            this.menuItemWBalance.MenuItems.Add(this.menuItemWBalance2);
            this.menuItemWBalance.MenuItems.Add(this.menuItemWBalance3);
            this.menuItemWBalance.Text = "Balance";
            // 
            // menuItemWBalance0
            // 
            this.menuItemWBalance0.Checked = true;
            this.menuItemWBalance0.Text = "0";
            this.menuItemWBalance0.Click += new System.EventHandler(this.menuItemWBalance_Click);
            // 
            // menuItemWBalance1
            // 
            this.menuItemWBalance1.Text = "1";
            this.menuItemWBalance1.Click += new System.EventHandler(this.menuItemWBalance_Click);
            // 
            // menuItemWBalance2
            // 
            this.menuItemWBalance2.Text = "2";
            this.menuItemWBalance2.Click += new System.EventHandler(this.menuItemWBalance_Click);
            // 
            // menuItemWBalance3
            // 
            this.menuItemWBalance3.Text = "3";
            this.menuItemWBalance3.Click += new System.EventHandler(this.menuItemWBalance_Click);
            // 
            // menuItemZoom
            // 
            this.menuItemZoom.MenuItems.Add(this.menuItemZoom1);
            this.menuItemZoom.MenuItems.Add(this.menuItemZoom2);
            this.menuItemZoom.MenuItems.Add(this.menuItemZoom3);
            this.menuItemZoom.MenuItems.Add(this.menuItemZoom4);
            this.menuItemZoom.MenuItems.Add(this.menuItemZoom5);
            this.menuItemZoom.MenuItems.Add(this.menuItemZoom6);
            this.menuItemZoom.Text = "Zoom";
            // 
            // menuItemZoom1
            // 
            this.menuItemZoom1.Checked = true;
            this.menuItemZoom1.Text = "x1";
            this.menuItemZoom1.Click += new System.EventHandler(this.menuItemZoom_Click);
            // 
            // menuItemZoom2
            // 
            this.menuItemZoom2.Text = "x2";
            this.menuItemZoom2.Click += new System.EventHandler(this.menuItemZoom_Click);
            // 
            // menuItemZoom3
            // 
            this.menuItemZoom3.Text = "x3";
            this.menuItemZoom3.Click += new System.EventHandler(this.menuItemZoom_Click);
            // 
            // menuItemZoom4
            // 
            this.menuItemZoom4.Text = "x4";
            this.menuItemZoom4.Click += new System.EventHandler(this.menuItemZoom_Click);
            // 
            // menuItemZoom5
            // 
            this.menuItemZoom5.Text = "x5";
            this.menuItemZoom5.Click += new System.EventHandler(this.menuItemZoom_Click);
            // 
            // menuItemZoom6
            // 
            this.menuItemZoom6.Text = "x6";
            this.menuItemZoom6.Click += new System.EventHandler(this.menuItemZoom_Click);
            // 
            // menuItemStart
            // 
            this.menuItemStart.Text = "Iniciar";
            this.menuItemStart.Click += new System.EventHandler(this.menuItemStart_Click);
            // 
            // menuItemStop
            // 
            this.menuItemStop.Text = "Detener";
            this.menuItemStop.Click += new System.EventHandler(this.menuItemStop_Click);
            // 
            // menuItemFlash
            // 
            this.menuItemFlash.Text = "Flash";
            this.menuItemFlash.Click += new System.EventHandler(this.menuItemFlash_Click);
            // 
            // menuItemToggleLED
            // 
            this.menuItemToggleLED.Text = "LED";
            this.menuItemToggleLED.Click += new System.EventHandler(this.menuItemToggleLED_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Text = "Salir";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // TakePicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 400);
            this.ControlBox = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "TakePicture";
            this.Text = "Tomar Foto";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItemCapture;
        private System.Windows.Forms.MenuItem menuItemMenu;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemStart;
        private System.Windows.Forms.MenuItem menuItemStop;
        private System.Windows.Forms.MenuItem menuItemResolution;
        private System.Windows.Forms.MenuItem menuItemRes1;
        private System.Windows.Forms.MenuItem menuItemRes2;
        private System.Windows.Forms.MenuItem menuItemRes3;
        private System.Windows.Forms.MenuItem menuItemRes4;
        private System.Windows.Forms.MenuItem menuItemRes5;
        private System.Windows.Forms.MenuItem menuItemRes6;
        private System.Windows.Forms.MenuItem menuItemRes7;
        private System.Windows.Forms.MenuItem menuItemFlash;
        private System.Windows.Forms.MenuItem menuItemToggleLED;
        private System.Windows.Forms.MenuItem menuItemZoom;
        private System.Windows.Forms.MenuItem menuItemZoom1;
        private System.Windows.Forms.MenuItem menuItemZoom2;
        private System.Windows.Forms.MenuItem menuItemZoom3;
        private System.Windows.Forms.MenuItem menuItemZoom4;
        private System.Windows.Forms.MenuItem menuItemZoom5;
        private System.Windows.Forms.MenuItem menuItemZoom6;
        private System.Windows.Forms.MenuItem menuItemBright;
        private System.Windows.Forms.MenuItem menuItemBright3;
        private System.Windows.Forms.MenuItem menuItemBright2;
        private System.Windows.Forms.MenuItem menuItemBright1;
        private System.Windows.Forms.MenuItem menuItemBright0;
        private System.Windows.Forms.MenuItem menuItemBrightN1;
        private System.Windows.Forms.MenuItem menuItemBrightN2;
        private System.Windows.Forms.MenuItem menuItemBrightN3;
        private System.Windows.Forms.MenuItem menuItemWBalance;
        private System.Windows.Forms.MenuItem menuItemWBalance0;
        private System.Windows.Forms.MenuItem menuItemWBalance1;
        private System.Windows.Forms.MenuItem menuItemWBalance2;
        private System.Windows.Forms.MenuItem menuItemWBalance3;
        private System.Windows.Forms.MenuItem menuItemColor;

    }
}

