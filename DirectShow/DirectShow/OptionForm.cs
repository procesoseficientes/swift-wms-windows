using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DirectShow_Sample
{
    public partial class OptionForm : Form
    {
        int x = 0, y = 320, width = 480, height = 400;
        string strFilePath = @"\Flash Storage\unitech.jpg";

        public OptionForm()
        {
            InitializeComponent();
        }

        private void OptionForm_Load(object sender, EventArgs e)
        {
            textXPos.Text = x.ToString();
            textYPos.Text = y.ToString();
            textWidth.Text = width.ToString();
            textHeight.Text = height.ToString();

            textFilePath.Text = strFilePath;
        }

        public int PreviewY
        {
            get { return y; }
            set { y = value; }
        }

        public int PreviewX
        {
            get { return x; }
            set { x = value; }
        }

        public int PreviewWidth
        {
            get { return width; }
            set { width = value; }
        }

        public int PreviewHeight
        {
            get { return height; }
            set { height = value; }
        }

        public string FilePath
        {
            get { return strFilePath; }
            set { strFilePath = value; }
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void OptionForm_Closing(object sender, CancelEventArgs e)
        {
            x = int.Parse(textXPos.Text);
            y = int.Parse(textYPos.Text);
            width = int.Parse(textWidth.Text);
            height = int.Parse(textHeight.Text);

            strFilePath = textFilePath.Text;
        }
    }
}