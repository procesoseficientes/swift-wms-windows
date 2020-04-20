using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MobilityScm.Modelo.Vistas;

namespace MobilityScm.Modelo.WMS_PhisicalCouting
{
    public partial class WMS_Phisical_Couting
    {
        public WMS_Phisical_Couting(bool UseDinamicHost)
        {
            this.Url = VariablesDeAmbiente.WsHost + "/Catalogues/WMS_Phisical_Couting" +
                ".asmx";
        }
    }
}
