using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class UsuarioPorPiloto
    {
        public int? CODE { get; set; }
        public string USER_CODE { get; set; }
        public int? PILOT_CODE { get; set; }
        public DateTime? LAST_UPDATE { get; set; }
        public string LAST_UPDATE_BY { get; set; }
    }
}