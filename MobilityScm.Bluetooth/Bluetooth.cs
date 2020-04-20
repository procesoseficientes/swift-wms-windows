using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MobilityScm.Vertical.Entidades;
using MobilityScm.Bluetooth.Interface;
using System.Runtime.InteropServices;

namespace MobilityScm.Bluetooth
{
    public class Bluetooth
    {
        #region "Auxilares"

        private const int SPI_GETOEMINFO = 260;

        [DllImport("coredll.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        private static extern int SystemParametersInfoString(int uiAction, int uiParam, StringBuilder pvParam, int fWinIni);

        private static string GetModelInformation()
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

        #region IBluetooth Members

        public string Handheld { get; set; }
        public string DeviceName { get; set; }
        public string DeviceAddress { get; set; }
        private IBluetooth _bluetooth;

        public void SetupBluetooth()
        {
            Handheld = GetModelInformation();
            if (Handheld.ToUpper() == "MOTOROLA WINCE")
            {
                _bluetooth = new MC92NO.Bluetooth(DeviceName, DeviceAddress);
                if (!string.IsNullOrEmpty(DeviceAddress))
                {
                    _bluetooth.ConnectPrinter(true);
                }
            }
            else
            {
                _bluetooth = new OTHER.Bluetooth();
            }            
        }

        public void Print(string zpl)
        {
            try
            {
                _bluetooth.DeviceName = DeviceName;
                _bluetooth.DeviceAddress = DeviceAddress;
                _bluetooth.Print(zpl);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string[] ExploreDevices()
        {
            string[] listDevices;
            try {
                listDevices = _bluetooth.ExploreDevices();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listDevices;
        }

        #endregion
    }
}
