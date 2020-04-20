using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class Documento
    {
        public string DocumentId { get; set; }
        public int ExternalSourceId { get; set; }
        public string Owner { get; set; }
    }
}
