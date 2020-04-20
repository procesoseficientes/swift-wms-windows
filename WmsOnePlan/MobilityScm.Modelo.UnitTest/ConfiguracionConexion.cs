using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilityScm.Utilerias;

namespace MobilityScm.Modelo.PruebaUnitaria
{
    internal class ConfiguracionConexion : IConfiguracionDeConexion
    {
        public string Esquema => "alsersa";

        public string StringConnection => "Server=192.168.1.114;Database=OP_WMS_ALSERSA;User=sa;Pwd=M0b1SCM@7710";
    }
}
