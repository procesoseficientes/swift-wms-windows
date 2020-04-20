using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace MobilityScm.Modelo.Reportes
{
    public partial class ReporteDeSolicitudDeTraslado : DevExpress.XtraReports.UI.XtraReport
    {
        public ReporteDeSolicitudDeTraslado()
        {
            InitializeComponent();
        }

        private void ReporteDeSolicitudDeTraslado_DataSourceDemanded(object sender, EventArgs e)
        {
            try
            {
                var logo = ImagenLogo.Value.ToString();
                logo = logo.Replace("data:image/png;base64,", "");
                logo = logo.Replace("data:image/jpeg;base64,", "");

                var data = Convert.FromBase64String(logo);

                var stream = new MemoryStream(data, 0, data.Length);
                var image = Image.FromStream(stream);
                UiLogoContainer.Image = image;
                UiLogoContainer.Sizing = ImageSizeMode.StretchImage;
            }
            catch (Exception)
            {
                var data = Convert.FromBase64String(Configuracion.Configuracion.ImagenPorDefecto);

                var stream = new MemoryStream(data, 0, data.Length);
                var image = Image.FromStream(stream);
                UiLogoContainer.Image = image;
                UiLogoContainer.Sizing = ImageSizeMode.StretchImage;
            }
        }
    }
}
