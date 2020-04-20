using System;
using System.Windows.Forms;
using MobilityScm.BarcodeScann.Arguments;
using MobilityScm.Modelo.Tipos;
using System.Text;
using System.Runtime.InteropServices;
using MobilityScm.Vertical.Entidades;
namespace MobilityScm.BarcodeScann

{
    public class BarcodeScanner
    {

        #region "Auxilares"

        private const int SPI_GETOEMINFO = 260;

        [DllImport("coredll.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        private static extern int SystemParametersInfoString(int uiAction, int uiParam, StringBuilder pvParam, int fWinIni);

        private static string ObtenerInformacionModelo()
        {
            try
            {
                StringBuilder sb = new StringBuilder(256);

                if (SystemParametersInfoString(SPI_GETOEMINFO, sb.Capacity, sb, 0) != 0)
                {
                    return sb.ToString();
                }
            }
            catch
            {
            }

            return "<Unknown platform>";
        }

        #endregion 
      
        private IBarcodeScanner _barcodeScanner;
        public event EventHandler<BarcodeDataEventArg> DataReady;
        public string Handheld = "";
        public void SetupScanner(Form parent)
        {
            Handheld  = ObtenerInformacionModelo();
            Operacion op;
            if (Handheld == "MC67" || Handheld == "MC65" || Handheld == "MC92N0" || Handheld.ToUpper() == "MOTOROLA WINCE" || Handheld == "ES400" || Handheld == "7545")
            {
                _barcodeScanner = new Motorola.BarcodeScanner();
                op = _barcodeScanner.SetupScanner(parent);
            }
            else
            {
                _barcodeScanner = new PA692.BarcodeScanner();
                op = _barcodeScanner.SetupScanner(parent);
                Handheld = "PA692";
            }
            if (op.Resultado == ResultadoOperacionTipo.Error)
            {
                Handheld = "PA400";
                _barcodeScanner = new PA400.BarcodeScanner();
                op = _barcodeScanner.SetupScanner(parent);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                    throw new Exception(op.Mensaje);
            }
            _barcodeScanner.BarcodeIsScanned += barcodeScanner_BarcodeIsScanned;
        }

        void barcodeScanner_BarcodeIsScanned(object sender, BarcodeDataEventArg e)
        {
            if (DataReady != null)
            {
                DataReady(this, e);
            }
        }

        public void Enabled()
        {
            _barcodeScanner.Enabled();
        }

        public void Disabled()
        {
            _barcodeScanner.Disabled();
        }
    }
}