using System;

namespace MobilityScm.Modelo.Argumentos
{
    public class ConsultaArgumento : EventArgs
    {
        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public string Login { get; set; }
        public string CodigoBodega { get; set; }

        public string GrupoParametro { get; set; }
        public string IdParametro { get; set; }

        public bool SiNo { get; set; }
    }
}
