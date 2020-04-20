using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using InTheHand.Net;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using MobilityScm.Bluetooth.Interface;

namespace MobilityScm.Bluetooth.OTHER
{
    internal class Bluetooth : IBluetooth
    {
        public string DeviceName { get; set; }
        public string DeviceAddress { get; set; }

        #region IBluetooth Members

        bool IBluetooth.ConnectPrinter(bool enable) {
            return true;
        }


        void IBluetooth.Print(string zpl)
        {
            BluetoothClient bluetoothClient = new BluetoothClient();
            Guid serviceClass = BluetoothService.SerialPort;
            BluetoothEndPoint bluetoothEndPoint = new BluetoothEndPoint(BluetoothAddress.Parse(DeviceAddress), serviceClass);
            bluetoothClient.Connect(bluetoothEndPoint);
            Thread.Sleep(1000);
            Stream peerStream = bluetoothClient.GetStream();
            StreamWriter sw = new StreamWriter(peerStream);
            try
            {
                if (DeviceAddress == "")
                {
                    throw new Exception("Debe seleccionar la impresora móvil");
                }
                sw.Write(zpl);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sw.Flush();
                sw.Close();
                bluetoothClient.Close();
                bluetoothClient.Dispose();
            }
        }

        string[] IBluetooth.ExploreDevices()
        {
            string[] listDevices;
            try
            {
                BluetoothClient bluetoothClient = new BluetoothClient();                
                BluetoothDeviceInfo[] devicesInfo = bluetoothClient.DiscoverDevices(5, true, true, true);                                
                listDevices = new string[devicesInfo.Length];
                listDevices = (from dev in devicesInfo
                               select (dev.DeviceName + "|" + dev.DeviceAddress.ToString())).ToArray<string>();           
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
