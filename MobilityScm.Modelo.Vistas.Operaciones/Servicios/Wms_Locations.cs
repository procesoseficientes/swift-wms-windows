using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobilityScm.Modelo.Vistas.Operaciones.WMS_Locations
{
    public partial class WMS_Locations 
    {
        public WMS_Locations(bool UseDinamicHost)
        {
            this.Url = VariablesDeAmbienteOperaciones.DireccionDeServicio + "/Catalogues/WMS_Locations" +
                ".asmx"; 
        }
    }
}
