using System;
using System.Windows.Forms;
using MobilityScm.BarcodeScann.Arguments;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.BarcodeScann
{
    public interface IBarcodeScanner
    {
        event EventHandler<BarcodeDataEventArg> BarcodeIsScanned;
        Operacion SetupScanner(Form parent);
        void Enabled();
        void Disabled();
    }

 
}