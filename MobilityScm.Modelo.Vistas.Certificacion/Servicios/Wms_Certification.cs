using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobilityScm.Modelo.Vistas.Certificacion.Wms_Certification
{
    public partial class WMS_Certification
    {
        public WMS_Certification(bool UseDinamicHost)
        {
            this.Url = VariablesDeAmbienteCertificacion.DireccionDeServicio + "/Trans/Wms_Certification" +
                ".asmx";
        }
    }
}
