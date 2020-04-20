using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class EmpresaDeTransporte
    {
        public int? TRANSPORT_COMPANY_CODE { get; set; }
        public string NAME { get; set; }
        public string ADDRESS { get; set; }
        public string TELEPHONE { get; set; }
        public string CONTACT { get; set; }
        public string MAIL { get; set; }

        public string LAST_UPDATE_BY { get; set; }
        public DateTime LAST_UPDATE { get; set; }
        public int IS_OWN { get; set; }
    }
}