using System;

namespace MobilityScm.Modelo.Argumentos
{
    public class Clase
    {
        public int CLASS_ID { get; set; }

        public string CLASS_NAME { get; set; }

        public string CLASS_DESCRIPTION { get; set; }

        public string CLASS_TYPE { get; set; }

        public string CLASS_TYPE_DESCRIPTION { get; set; }

        public string CREATED_BY { get; set; }

        public DateTime CREATED_DATETIME { get; set; }

        public string LAST_UPDATED_BY { get; set; }

        public DateTime LAST_UPDATED { get; set; }

        public Boolean IS_SELECTED { get; set; } = false;

        public int PRIORITY { get; set; }
    }
}