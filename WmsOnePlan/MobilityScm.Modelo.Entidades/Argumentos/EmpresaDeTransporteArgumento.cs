using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class EmpresaDeTransporteArgumento: EventArgs
    {
        public IList<EmpresaDeTransporte> EmpresasDeTransporte { get; set; }
        public EmpresaDeTransporte EmpresaDeTransporte { get; set; }
    }
}