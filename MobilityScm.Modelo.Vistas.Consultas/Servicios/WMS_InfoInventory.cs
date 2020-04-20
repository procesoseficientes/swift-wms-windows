using System;
using System.Collections.Generic;
using System.Text;
using MobilityScm.Modelo.Vistas;

namespace MobilityScm.Modelo.WMS_InfoInventory
{
    public partial class WMS_InfoInventory
    {
        public WMS_InfoInventory(bool UseDinamicHost)
        {
            this.Url = VariablesDeAmbienteParaConsulta.WsHost + "/Info/WMS_InfoInventory" +
                ".asmx";
        }
    }
}
