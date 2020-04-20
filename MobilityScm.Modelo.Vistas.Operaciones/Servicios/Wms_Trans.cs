using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobilityScm.Modelo.Vistas.Operaciones.WMS_Trans
{
    public partial class WMS_Trans
    {
        public WMS_Trans(bool UseDinamicHost)
        {
            this.Url = VariablesDeAmbienteOperaciones.DireccionDeServicio + "/Trans/WMS_Trans" +
                ".asmx";
        }
    }
}
