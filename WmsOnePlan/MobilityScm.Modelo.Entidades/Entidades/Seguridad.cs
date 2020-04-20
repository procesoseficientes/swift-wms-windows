using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class Seguridad
    {
        public string CHECK_ID { get; set; }

        public string CATEGORY { get; set; }

        public string DESCRIPTION { get; set; }

        public string PARENT { get; set; }

        public string ACCESS { get; set; }

        public decimal? MPC_1 { get; set; }

        public decimal? MPC_2 { get; set; }

        public string MPC_3 { get; set; }

        public decimal? MPC_4 { get; set; }

        public string MPC_5 { get; set; }

        public string LOGIN { get; set; }
    }
}
