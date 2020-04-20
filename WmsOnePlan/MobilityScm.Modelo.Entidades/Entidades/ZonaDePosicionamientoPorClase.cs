using System;

namespace MobilityScm.Modelo.Entidades
{
    public class ZonaDePosicionamientoPorClase
    {
        public int ID { get; set; }

        public Guid ID_SLOTTING_ZONE { get; set; }

        public int FAMILY { get; set; }

        public string DESCRIPTION_FAMILY { get; set; }
    }
}
