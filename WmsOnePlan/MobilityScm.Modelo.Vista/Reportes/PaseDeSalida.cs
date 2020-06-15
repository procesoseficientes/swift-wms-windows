using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace MobilityScm.Modelo.Reportes
{
    public partial class PaseDeSalida : DevExpress.XtraReports.UI.XtraReport
    {
        public PaseDeSalida()
        {
            InitializeComponent();
        }

        public PaseDeSalida(bool mostrarCampos, bool mostrarEtiquetaReimpresion)
        {
            InitializeComponent();
            UiEtiquetaVendedor.Visible = mostrarCampos;
            UiEtiquetaValorVendedor.Visible = mostrarCampos;
            UiEtiquetaSucursal.Visible = mostrarCampos;
            UiEtiquetaValorSucursal.Visible = mostrarCampos;
            UiEtiquetaFechaComprometida.Visible = mostrarCampos;
            UiEtiquetaValorFechaComprometida.Visible = mostrarCampos;
            UiEtiquetaTipoDePago.Visible = mostrarCampos;
            UiEtiquetaValorTipoDePago.Visible = mostrarCampos;
            UiEtiquetaObservaciones.Visible = mostrarCampos;
            UiEtiquetaValorObservaciones.Visible = mostrarCampos;
            UiEtiquetaReimpresion.Visible = mostrarEtiquetaReimpresion;
        }

        private void PaseDeSalida_DataSourceDemanded(object sender, EventArgs e)
        {
            try
            {
                UiEtiquetaERP.Text = ((bool)GeneraFactura.Value) ? "No. Factura:" : "No. Entrega: ";
                UiEtiquetaGarantia.Visible = ((bool)MostrorEtiquetaGarantia.Value);
                UiPanelCodiciones.Visible = ((bool)MostrorEtiquetaGarantia.Value);

                var logo = ImagenLogo.Value.ToString();
                logo = logo.Replace("data:image/png;base64,", "");
                logo = logo.Replace("data:image/jpeg;base64,", "");

                var data = Convert.FromBase64String(logo);

                var stream = new MemoryStream(data, 0, data.Length);
                var image = Image.FromStream(stream);
                UiLogoContainer.Image = image;
                UiLogoContainer.Sizing = ImageSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                var data = Convert.FromBase64String(LogoDeImagenPredeterminada.Value.ToString());
                var stream = new MemoryStream(data, 0, data.Length);
                var image = Image.FromStream(stream);
                UiLogoContainer.Image = image;
                UiLogoContainer.Sizing = ImageSizeMode.StretchImage;
            }
        }

        private void UiEtiquetaValorFechaComprometida_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            UiEtiquetaValorFechaComprometida.Text = DateTime.Parse(UiEtiquetaValorFechaComprometida.Text).ToString("d");
        }
    }
}
