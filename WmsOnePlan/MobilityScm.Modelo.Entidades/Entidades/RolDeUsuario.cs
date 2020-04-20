using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class RolDeUsuario
    {
        public string ROLE_ID { get; set; }
        public string ROLE_NAME { get; set; }
        public string ROLE_DESCRIPTION { get; set; }
        public string USER_CODE { get; set; }
    }
}