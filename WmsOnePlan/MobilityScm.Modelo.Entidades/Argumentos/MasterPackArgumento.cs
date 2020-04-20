

using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class MasterPackArgumento: ConsultaArgumento
    {
        public MasterPackEncabezado MasterPackEncabezado { get; set; }
        public string Login { get; set; }
    }
}
