using System;
using System.Windows.Forms;
using MobilityScm.BarcodeScann.Arguments;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Vertical.Entidades;
using USICF;

namespace MobilityScm.BarcodeScann.PA692
{
    internal class BarcodeScanner:IBarcodeScanner
    {
        public event EventHandler<BarcodeDataEventArg> BarcodeIsScanned;

        private USIClass _scanner;

        

        public Operacion SetupScanner(Form parent)
        {
            try
            {
                
                _scanner = new USIClass(parent);
                _scanner.SetWorkingMode(USIClass.WorkingMode.SWM_BARCODE);
                _scanner.EnableScanner(true);
                _scanner.DataReady += ScannerDataReady;
                return new Operacion
                {
                    Codigo = 0,
                    Resultado = ResultadoOperacionTipo.Exito,
                    Mensaje = "Proceso Existos"
                };


            }
            catch (Exception e)
            {

                return new Operacion
                {
                    Codigo = -1,
                    Resultado = ResultadoOperacionTipo.Error,
                    Mensaje = e.Message
                }; 
            }
            
        }

        public void Enabled()
        {
            _scanner.EnableScanner(true);
        }

        public void Disabled()
        {
            _scanner.EnableScanner(false);
        }


        void ScannerDataReady(object sender, USIEventArgs e)
        {
            if (BarcodeIsScanned != null)
            {
                BarcodeIsScanned(this , new BarcodeDataEventArg
                {
                    BarcodeData = e.BarcodeData
                });
            }
        }

    }
}