using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class Piloto
    {
        public int? PILOT_CODE { get; set; }
        public string NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string IDENTIFICATION_DOCUMENT_NUMBER { get; set; }
        public string LICENSE_NUMBER { get; set; }
        public string LICESE_TYPE { get; set; }
        public DateTime? LICENSE_EXPIRATION_DATE { get; set; }
        public string ADDRESS { get; set; }
        public string TELEPHONE { get; set; }
        public string MAIL { get; set; }
        public string COMMENT { get; set; }
        public DateTime? LAST_UPDATE { get; set; }
        public string LAST_UPDATE_BY { get; set; }
        public string ROLE_ID { get; set; }
        public string ROLE_NAME { get; set; }
        public string USER_CODE { get; set; }
        public string LOGIN_NAME { get; set; }
        public string VEHICLE_CODE { get; set; }

        public bool IS_SELECTED { get; set; }
        public Piloto ShallowCopy()
        {
            return (Piloto)this.MemberwiseClone();
        }
    }
}