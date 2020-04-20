using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace MobilityScm.Modelo.Reportes
{
    public partial class BalanceDeSaldosFiscal : DevExpress.XtraReports.UI.XtraReport
    {
        public BalanceDeSaldosFiscal()
        {
            InitializeComponent();
        }

        private void BalanceDeSaldosFiscal_DataSourceDemanded(object sender, EventArgs e)
        {
           
        }

        private void xrLabel18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
            xrLabel18.Text =decimal.Parse((string.IsNullOrEmpty(xrLabel18.Text) ? "0" : xrLabel18.Text)).ToString("###,###,##0.00");
        }

        private void xrLabel19_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
            xrLabel19.Text =
                decimal.Parse((string.IsNullOrEmpty(xrLabel19.Text) ? "0" : xrLabel19.Text)).ToString("###,###,##0.00");
        }

        private void xrLabel20_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            xrLabel20.Text =
                decimal.Parse((string.IsNullOrEmpty(xrLabel20.Text) ? "0" : xrLabel20.Text)).ToString("###,###,##0.00");
        }
    }
}
