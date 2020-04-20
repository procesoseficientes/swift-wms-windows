using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace MobilityScm.Modelo.Popups
{
    public sealed class ReasignarTareaLineaDePickingPopup : XtraUserControl
    {
        public List<string> Bandas { get; set; }

        public ReasignarTareaLineaDePickingPopup(List<string> bandas)
        {
            InitializeComponent();

            Bandas = bandas;
            var lc = new LayoutControl
            {
                Name = "Layout",
                Dock = DockStyle.Fill
            };

            var seBanda = new SearchLookUpEdit
            {
                Name = "Banda"
                ,Properties =
                {
                    DataSource = Bandas
                }
            };
            
            lc.AddItem(string.Empty, seBanda).TextVisible = false;
            Controls.Add(lc);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ReasignarTareaLineaDePickingPopup
            // 
            this.Name = "ReasignarTareaLineaDePickingPopup";
            this.Size = new System.Drawing.Size(246, 45);
            this.ResumeLayout(false);

        }
    }
}
