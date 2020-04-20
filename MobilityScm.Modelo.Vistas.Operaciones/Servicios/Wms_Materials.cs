using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobilityScm.Modelo.Vistas.Operaciones.Wms_Materials
{
    public partial class WMS_Materials
    {
        public WMS_Materials(bool UseDinamicHost)
        {
            this.Url = VariablesDeAmbienteOperaciones.DireccionDeServicio + "/Catalogues/WMS_Materials" +
                ".asmx";
        }
    }
}
