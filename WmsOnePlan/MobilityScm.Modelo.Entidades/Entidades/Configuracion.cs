using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class Configuracion
    {
        public string PARAM_TYPE { get; set; }

        public string PARAM_GROUP { get; set; }

        public string PARAM_GROUP_CAPTION { get; set; }

        public string PARAM_NAME { get; set; }

        public string PARAM_CAPTION { get; set; }

        public decimal? NUMERIC_VALUE { get; set; }

        public decimal? MONEY_VALUE { get; set; }

        public string TEXT_VALUE { get; set; }

        public DateTime? DATE_VALUE { get; set; }

        public decimal? RANGE_NUM_START { get; set; }

        public decimal? RANGE_NUM_END { get; set; }

        public DateTime? RANGE_DATE_START { get; set; }

        public DateTime? RANGE_DATE_END { get; set; }

        public string SPARE1 { get; set; }

        public string SPARE2 { get; set; }

        public bool IS_SELECTED { get; set; }

        public string LOGIN { get; set; }

        public string SPARE3 { get; set; }

        public string COLOR { get; set; }
    }
}
