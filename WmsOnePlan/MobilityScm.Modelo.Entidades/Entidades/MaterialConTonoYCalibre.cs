using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class MaterialConTonoYCalibre
    {
        // ReSharper disable once InconsistentNaming
        public string MATERIAL_ID { get; set; }
        // ReSharper disable once InconsistentNaming
        public string TONE { get; set; }
        // ReSharper disable once InconsistentNaming
        public string CALIBER { get; set; }
        public decimal QTY { get; set; }
        public decimal QTY_AVAILABLE { get; set; }
        public decimal QTY_ORDER { get; set; }
        public decimal QTY_PICKED { get; set; }
    }
}