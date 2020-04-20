using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MobilityScm.Modelo.Vistas;

namespace MobilityScm.Modelo.WMS_InfoTrans
{
    public partial class WMS_InfoTrans
    {
        public WMS_InfoTrans(bool UseDinamicHost)
        {
            this.Url = VariablesDeAmbiente.WsHost + "/Info/WMS_InfoTrans" +
                ".asmx";
        }
    }
}
