using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobilityScm.Modelo.Vistas.Certificacion.Wms_Settings
{
    public partial class WMS_Settings
    {
        public WMS_Settings(bool UseDinamicHost)
        {
            this.Url = VariablesDeAmbienteCertificacion.DireccionDeServicio + "/Catalogues/WMS_Settings" +
                ".asmx";
        }
    }
}
