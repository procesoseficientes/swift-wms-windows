using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobilityScm.Modelo.Vistas.Operaciones.WMS_InfoTrans
{
    public partial class WMS_InfoTrans
    {
        public WMS_InfoTrans(bool UseDynamicHost)
        {
            this.Url = VariablesDeAmbienteOperaciones.DireccionDeServicio + "/Info/WMS_InfoTrans" +
                ".asmx";
        }
    }
}
