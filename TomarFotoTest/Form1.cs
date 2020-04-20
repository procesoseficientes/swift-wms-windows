using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TomarFotoTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var fc = new MobilityScm.Views.TomarFoto
            {
                Name = "fc",
                Width = 240,
                Height = 400,
                Left = 0,
                Top = 0,
                Parent = this
            };
        }
    }
}