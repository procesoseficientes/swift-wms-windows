using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface ICatalogoZonaServicio
    {
        IList<Zona> ConsultarZonas();

        Operacion AgregarZona(ZonaArgumento arg);

        Operacion EliminarZona(ZonaArgumento arg);

        Operacion ActualizarZona(ZonaArgumento arg);

        IList<Zona> ConsultarZonasParaAsociar(ZonaArgumento arg);

        IList<Zona> ConsultarZonasAsociadas(ZonaArgumento arg);

        Operacion AsociarZonaDeReabastecimiento(ZonaArgumento arg);

        Operacion DesAsociarZonaDeReabastecimiento(ZonaArgumento arg);
    }
}
