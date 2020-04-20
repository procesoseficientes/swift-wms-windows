using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobilityScm.Modelo.Vistas.Operaciones.Wms_Polizas
{

    public partial class WMS_Polizas
    {
        public WMS_Polizas(bool UseDinamicHost)
        {
            this.Url =  VariablesDeAmbienteOperaciones.DireccionDeServicio + "/Trans/Wms_Poliza" +
                ".asmx";
        }
    }
}
