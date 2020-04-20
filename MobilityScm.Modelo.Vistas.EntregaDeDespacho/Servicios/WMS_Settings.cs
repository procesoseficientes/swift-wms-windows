using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobilityScm.Modelo.Vistas.EntregaDeDespacho.WMS_Settings
{
    public partial class WMS_Settings
    {
        public WMS_Settings(bool UseDynamicHost)
        {
            this.Url = VariablesDeAmbienteEntregaDeDespacho.DireccionDeServicio + "/Catalogues/WMS_Settings" +
                ".asmx";
        }
    }
}
