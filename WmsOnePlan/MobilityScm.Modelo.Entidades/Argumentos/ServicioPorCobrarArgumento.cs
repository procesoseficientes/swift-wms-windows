using MobilityScm.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Argumentos
{
    public class ServicioPorCobrarArgumento: EventArgs
    {
        public ServicioPorCobrar ServicioPorCobrar { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFinal { get; set; }

        public string Login { get; set; }

        public List<ServicioPorCobrar> ListaDeServiciosPorCobrar { get; set; }
    }
}
