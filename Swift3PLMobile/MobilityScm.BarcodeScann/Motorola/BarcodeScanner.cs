using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MobilityScm.Vertical.Entidades;
using MobilityScm.BarcodeScann.Arguments;
using Symbol.Barcode2;
using MobilityScm.Modelo.Tipos;

namespace MobilityScm.BarcodeScann.Motorola
{
   public  class BarcodeScanner : IBarcodeScanner, IDisposable
    {

       void xScanner_OnScan(ScanDataCollection scancollection)
       {
           ScanData scanData = scancollection.GetFirst;
           if (BarcodeIsScanned != null && scanData.Result == Results.SUCCESS)
           {
               BarcodeIsScanned(this, new BarcodeDataEventArg
               {
                   BarcodeData = scanData.Text+ '\r'
               });
               Enabled();
           }

       }
        #region IBarcodeScanner Members

        public event EventHandler<BarcodeDataEventArg> BarcodeIsScanned;

        private Barcode2 xScanner;

        public Operacion SetupScanner(System.Windows.Forms.Form parent)
        {
            try
            {
                
                if (xScanner == null  ||  !xScanner.IsEnabled)
                {
                    xScanner = null;
                    xScanner = new Barcode2();
                    xScanner.OnScan += new Barcode2.OnScanHandler(xScanner_OnScan);
                    xScanner.Config.TriggerMode = TRIGGERMODES.HARD;
                    xScanner.Config.ScanDataSize = 512;
                    //xScanner.Enable();
                    //xScanner.Scan(); 
                }
                return new Operacion
                {
                    Codigo = 0,
                    Resultado = ResultadoOperacionTipo.Exito,
                    Mensaje = "Proceso Existos"
                };
            }
            catch (Exception ex)
            {
                return new Operacion
                {
                    Codigo = 0,
                    Resultado = ResultadoOperacionTipo.Exito,
                    Mensaje = ex.Message
                };
            }
        }

        public void Enabled()
        {
            xScanner.Enable();
            xScanner.Scan();
        }

        public void Disabled()
        {
            xScanner.Disable();
        }

       

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            xScanner.Dispose();
        }

        #endregion
    }
}
