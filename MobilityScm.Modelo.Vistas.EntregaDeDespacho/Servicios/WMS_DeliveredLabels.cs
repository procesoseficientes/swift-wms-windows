using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobilityScm.Modelo.Vistas.EntregaDeDespacho.WMS_DeliveredLabels
{
    public partial class WMS_DeliveredLabels
    {
        public WMS_DeliveredLabels(bool UseDynamicHost)
        {
            this.Url = VariablesDeAmbienteEntregaDeDespacho.DireccionDeServicio + "/Trans/WMS_DeliveredLabels" +
                ".asmx";
        }
    }
}
