using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class ConfiguracionDeAmbiente
    {
        public string platform { get; set; }
        public string environmentName { get; set; }
        public string wsHost { get; set; }
        public string sqlConnection { get; set; }
        public string status { get; set; }
    }
}
