using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Symbol.WPAN.Bluetooth;
using MobilityScm.Vertical.Entidades;
using MobilityScm.Bluetooth.Interface;

namespace MobilityScm.Bluetooth.MC92NO
{

    internal class Bluetooth : IBluetooth
    {        
        private Symbol.WPAN.Bluetooth.Bluetooth WpanBluetooth{get;set;}
        private RemoteDevices RemoteDevices {get;set;}
        private RemoteDevice RemoteDevice{get;set;}

        public string DeviceName { get; set; }
        public string DeviceAddress { get; set; }

        private string PrinterName { get; set; }
        private string PrinterServiceName { get; set; }
        private string CurrPrinterBTAddress { get; set; }
        private bool IsConnected { get; set; }
        

        public Bluetooth(string deviceName, string deviceAddress)
        {
            WpanBluetooth = new Symbol.WPAN.Bluetooth.Bluetooth();
            RemoteDevices = WpanBluetooth.RemoteDevices;
            DeviceName = deviceName;
            DeviceAddress = deviceAddress;
            
            PrinterName = string.Empty;
            PrinterServiceName = string.Empty;
            CurrPrinterBTAddress = string.Empty;
            IsConnected = false;
        }

        bool IBluetooth.ConnectPrinter(bool enable)
        {
            if (enable)
            {
                try
                {
                    RemoteDevice = new RemoteDevice(DeviceName, DeviceAddress, PrinterServiceName);
                    if (!RemoteDevice.IsPaired)
                    {
                        RemoteDevices.Add(RemoteDevice);
                        RemoteDevice.Pair();
                        IsConnected = true;
                        return true;
                    }
                    else
                    {
                        RefreshConnectPrinter(true, DeviceAddress);
                    }
                }
                catch (Exception ex)
                {
                    IsConnected = false;
                    throw (ex);
                }
            }
            else
            {
                if (RemoteDevice.IsPaired)
                {
                    RemoteDevice.UnPair();
                    return false;
                }

                IsConnected = false;
            }

            return false;
        }

        private void RefreshConnectPrinter(bool enable, string PrinterBTAddress)
        {
            try
            {
                if (enable)
                {
                    string parsedPrinterBTAddress = DeviceAddress;
                    try
                    {
                        RemoteDevices = WpanBluetooth.RemoteDevices;
                        RemoteDevices.Refresh();
                        for (int i = 0; i <= RemoteDevices.Length - 1; i++)
                        {
                            if (RemoteDevices[i].Address == parsedPrinterBTAddress)
                            {
                                if (!RemoteDevices[i].IsPaired)
                                {
                                    RemoteDevices[i].Pair();
                                    RemoteDevice = RemoteDevices[i];
                                    PrinterName = RemoteDevice.Name;
                                    PrinterServiceName = RemoteDevice.ServiceName;
                                    IsConnected = true;                                    
                                }
                                else
                                {
                                    IsConnected = true;                                    
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        IsConnected = false;
                        throw (ex);
                    }
                }
                else
                {
                    RemoteDevices.RefreshCancel();
                    if (RemoteDevice.IsPaired)
                    {
                        RemoteDevice.UnPair();                        
                    }

                    IsConnected = false;
                }
            }
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException)
                {
                    RefreshConnectPrinter(enable, PrinterBTAddress);
                }
            }            
        }


        #region IBluetooth Members


        void IBluetooth.Print(string zpl)
        {
            if (!string.IsNullOrEmpty(DeviceAddress))
            {
                if (!RemoteDevice.IsComPortOpened)
                {
                    RemoteDevice.OpenPort();
                    Thread.Sleep(1000);
                    if (RemoteDevice.IsComPortOpened)
                    {
                        RemoteDevice.Write(Encoding.Default.GetBytes(zpl));
                    }
                    else
                    {
                        throw new Exception("El dispositivo no se encuentra listo para imprimir, por favor espere un momento.");
                    }

                    RemoteDevice.ClosePort();
                    Thread.Sleep(1500);
                }
                else
                {
                    throw new Exception("El dispositivo no se encuentra listo para imprimir, por favor espere un momento.");
                }
            }
            else
            {
                throw new Exception("Debe seleccionar la impresora móvil");
            }

        }


        string[] IBluetooth.ExploreDevices()
        {
            string[] listDevices;
            try
            {
                var bluetooth = new Symbol.WPAN.Bluetooth.Bluetooth();
                bluetooth.Enable();
                listDevices = new string[bluetooth.RemoteDevices.Length];
                for (int i = 0; i <= bluetooth.RemoteDevices.Length - 1; i++)
                {
                    listDevices[i] = bluetooth.RemoteDevices[i].Name + "|" + bluetooth.RemoteDevices[i].Address;
                }

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
