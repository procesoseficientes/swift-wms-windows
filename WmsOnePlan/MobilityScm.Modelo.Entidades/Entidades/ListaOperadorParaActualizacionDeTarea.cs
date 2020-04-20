using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    public class ListaOperadorParaActualizacionDeTarea : CredencialesDeUsuario
    {
        public IList<string> operators { get; set; }
    }
}
