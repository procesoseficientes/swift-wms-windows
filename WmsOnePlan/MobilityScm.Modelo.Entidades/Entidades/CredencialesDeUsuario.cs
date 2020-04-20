using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class CredencialesDeUsuario
    {
        public string password { get; set; }
        public string loginId { get; set; }
        public string userRole { get; set; }
        public string userName { get; set; }
        public string loginImage { get; set; }
        public string validationType { get; set; }
        public int? branchId { get; set; }
        public string dbUser { get; set; }
        public string dbPassword { get; set; }
        public string deviceId { get; set; }
        public string serverIp { get; set; }
    }
}
