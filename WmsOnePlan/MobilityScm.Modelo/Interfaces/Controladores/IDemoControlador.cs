using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Vistas;

namespace MobilityScm.Modelo.Interfaces.Controladores
{
    public interface IDemoControlador
    {
        IDemoServicio DemoServicio { get; set; }

        
    }
}