using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace MobilityScm.Modelo.Popups
{
    public partial class ListaParaParametrosGeneralesPopup : XtraUserControl
    {
        public ListaParaParametrosGeneralesPopup(List<Entidades.Configuracion> prioridades)
        {
            InitializeComponent();

            var layoutControl = new LayoutControl
            {
                Name = "Layout",
                Dock = DockStyle.Fill
            };

            var searchLookUpBand = new SearchLookUpEdit
            {
                Name = "Listado"
                ,
                Properties =
                {
                    ValueMember = "PARAM_NAME",
                    DisplayMember = "TEXT_VALUE",
                    DataSource = prioridades
                },
            };

            var column = searchLookUpBand.Properties.View.Columns.AddField("TEXT_VALUE");
            column.Caption = @"Descripción";
            column.Visible = true;
            

            layoutControl.AddItem(string.Empty, searchLookUpBand).TextVisible = false;
            Controls.Add(layoutControl);
        }

        public ListaParaParametrosGeneralesPopup(List<Entidades.Configuracion> prioridades, string caption)
        {
            InitializeComponent();
            Height = 75;
            Width = 250;
            var layoutControl = new LayoutControl
            {
                Name = "Layout",
                Dock = DockStyle.Fill
            };

            var searchLookUpBand = new SearchLookUpEdit
            {
                Name = "Listado"
                ,
                Properties =
                {
                    ValueMember = "PARAM_NAME",
                    DisplayMember = "TEXT_VALUE",
                    DataSource = prioridades
                },
            };

            var column = searchLookUpBand.Properties.View.Columns.AddField("TEXT_VALUE");
            column.Caption = @"Descripción";
            column.Visible = true;

            var txtReference = new TextEdit();
            txtReference.Name = "txtReference";
            

            layoutControl.AddItem(caption, txtReference);
            layoutControl.AddItem(string.Empty, searchLookUpBand).TextVisible = false;
            Controls.Add(layoutControl);
        }
    }

    
}
