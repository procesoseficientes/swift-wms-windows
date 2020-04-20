using System;
using System.Collections.Generic;
using System.Text;
using MobilityScm.Modelo.Vistas;

namespace MobilityScm.Modelo.WMS_InfoTrans
{
    public partial class WMS_InfoTrans
    {
        public WMS_InfoTrans(bool UseDinamicHost)
        {
            this.Url = VariablesDeAmbienteParaConsulta.WsHost + "/Info/WMS_InfoTrans" +
                ".asmx";
        }
    }
}
