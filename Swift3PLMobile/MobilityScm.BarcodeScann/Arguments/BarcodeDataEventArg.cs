using System;

namespace MobilityScm.BarcodeScann.Arguments
{
    public class BarcodeDataEventArg:EventArgs
    {
        public string BarcodeData { get; set; }
    }
}