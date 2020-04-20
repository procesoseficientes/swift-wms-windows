using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using MobilityScm.Bluetooth;

namespace MobilityScm.Print.Zebra
{
    public static class PrintModule
    {
        public static MobilityScm.Bluetooth.Bluetooth bluetooth;

        public static bool ImprimirLicencia(bool reimpresion, int licencia, string regimen, string empresa, string usuario, ref string resultado, string direccionImpresora)
        {
            try
            {

                String xstrmsg = "! 0 50 50 635 1 " + System.Environment.NewLine;
                xstrmsg += "! U1 LMARGIN 10" + System.Environment.NewLine + "! U1 PAGE-WIDTH 1400" + System.Environment.NewLine;
                xstrmsg += "CENTER 570 T 0 6 3 10 " + empresa + System.Environment.NewLine;
                xstrmsg += "LINE 0 60 570 60 2" + System.Environment.NewLine;
                xstrmsg += "CENTER 570 T 0 5 0 70 " + regimen + System.Environment.NewLine;
                xstrmsg += "BARCODE 39 1 1 150 20 140 " + licencia + "-" + System.Environment.NewLine;
                xstrmsg += "CENTER 570 T 0 6 0 310 " + licencia + System.Environment.NewLine;

                if (reimpresion)
                {
                    xstrmsg += "CENTER 570 T 0 4 0 360 *REIMPRESION*" + System.Environment.NewLine;
                }

                xstrmsg += "LINE 0 500 570 500 2" + System.Environment.NewLine;
                xstrmsg += "CENTER 570 T 0 2 0 510 " + usuario + " " + DateTime.Now.ToString() + System.Environment.NewLine;
                xstrmsg += "CENTER 570 T 0 1 0 550 www.mobilityscm.com" + System.Environment.NewLine;
                xstrmsg += "L 5 T 0 2 0 130 " + System.Environment.NewLine + "PRINT" + System.Environment.NewLine;
                                
                bluetooth.Print(xstrmsg);
                return true;
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return false;
        }

        public static void PrintLabel(string clientCode, string clientName, string regimen, string label_id, string state_code, string wavePickingId, string usuario, string direccionImpresora)
        {

            try
            {
                var printDate = DateTime.Now;
                string print = "! 0 50 50 635 1 " + System.Environment.NewLine;
                print += "! U1 LMARGIN 10" + System.Environment.NewLine + "! U1 PAGE-WIDTH 1400" + System.Environment.NewLine;
                print += "CENTER 570 T 0 5 3 10 " + clientName + System.Environment.NewLine;
                print += "CENTER 570 T 0 5 3 60 " + clientCode + System.Environment.NewLine;
                print += "LINE 0 100 570 100 2" + System.Environment.NewLine;
                print += "CENTER 570 T 0 5 0 115 " + "" + regimen + " " + System.Environment.NewLine;
                print += "BARCODE 39 1 1 160 20 160 " + label_id + System.Environment.NewLine;
                print += "CENTER 570 T 0 3 0 340 Codigo Etiqueta: " + label_id + System.Environment.NewLine;
                
                if (!string.IsNullOrEmpty(wavePickingId))
                {
                    print += "CENTER 570 T 0 5 0 370 T: " + wavePickingId + System.Environment.NewLine;
                }

                if (!string.IsNullOrEmpty(state_code))
                {
                    print += "CENTER 570 T 0 5 0 410 Departamento: " + state_code + " " + System.Environment.NewLine;
                }

                print += "LINE 0 500 570 500 2" + System.Environment.NewLine;
                print += "CENTER 570 T 0 2 0 510 " + usuario + " " + printDate.ToString("dd/MM/yyyy hh:mm tt") + System.Environment.NewLine;
                print += "CENTER 570 T 0 1 0 550 www.mobilityscm.com" + System.Environment.NewLine;
                print += "L 5 T 0 2 0 130 " + System.Environment.NewLine + "PRINT" + System.Environment.NewLine;
                
                bluetooth.Print(print);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
