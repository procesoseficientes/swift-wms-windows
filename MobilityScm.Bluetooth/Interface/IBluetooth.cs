using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Bluetooth.Interface
{
    internal interface IBluetooth
    {
        string DeviceName { get; set; }
        string DeviceAddress { get; set; }
        void Print(string zpl);
        string[] ExploreDevices();

        bool ConnectPrinter(bool enable);
    }
}
