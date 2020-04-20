using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IPosicionamientoServicio
    {
        IList<ZonaDePosicionamiento> ObtenerZonaDePosicionamientos(PosicionamientoArgumento arg);

        IList<ZonaDePosicionamiento> ObtenerZonaDePosicionamientosSubClase(PosicionamientoArgumento arg);

        Operacion GrabarZonaDePosicionamiento(PosicionamientoArgumento arg);

        Operacion AgregarClasesParaZonaDePosicionamiento(PosicionamientoArgumento arg);

        Operacion AgregarSubClasesParaZonaDePosicionamiento(PosicionamientoArgumento arg);

        Operacion QuitarClasesParaZonaDePosicionamiento(PosicionamientoArgumento arg);

        Operacion QuitarSubClasesParaZonaDePosicionamiento(PosicionamientoArgumento arg);

        IList<Operacion> ProcessarXmlObtenidoExcel(PosicionamientoArgumento arg);
    }
}
