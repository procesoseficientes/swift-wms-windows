using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class Dominio
    {
        public int? id { get; set; }
        public string domain { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string server { get; set; }
        public int port { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
    }
}
