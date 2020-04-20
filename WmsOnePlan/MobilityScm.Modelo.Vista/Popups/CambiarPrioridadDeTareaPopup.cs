using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace MobilityScm.Modelo.Popups
{
    public partial class CambiarPrioridadDeTareaPopup : XtraUserControl
    {
        public List<string> Prioridades { get; set; }
        public CambiarPrioridadDeTareaPopup(List<string> prioridades)
        {
            InitializeComponent();


            Prioridades = prioridades;
            var lc = new LayoutControl
            {
                Name = "Layout",
                Dock = DockStyle.Fill
            };

            var seBanda = new SearchLookUpEdit
            {
                Name = "Prioridad"
                ,
                Properties =
                {
                    DataSource = Prioridades
                }
            };

            lc.AddItem(string.Empty, seBanda).TextVisible = false;
            Controls.Add(lc);
        }
    }
}
