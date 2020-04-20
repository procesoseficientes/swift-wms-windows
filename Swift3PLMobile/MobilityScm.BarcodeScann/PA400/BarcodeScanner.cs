using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BarcodeControlLib;
using Microsoft.WindowsCE.Forms;
using MobilityScm.BarcodeScann.Arguments;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.BarcodeScann.PA400
{
    internal class  BarcodeScanner:IBarcodeScanner
    {
        public event EventHandler<BarcodeDataEventArg> BarcodeIsScanned;

        IntPtr _ghScanner = IntPtr.Zero;
        IntPtr _gpscanBuffer = IntPtr.Zero;
        Barcode.SCAN_BUFFER _scanBuffer;
        private Form _parent;


        private void HardwareButtonsConfig(Form parent)
        {
            try
            {
// ReSharper disable once ObjectCreationAsStatement
                new HardwareButton {AssociatedControl = parent, HardwareKey = HardwareKeys.ApplicationKey3};
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + " Check if the hardware button is physically available on this device.");
            }
        }

        public Operacion SetupScanner(Form parent)
        {
            _parent = parent;
          

            string returnMesssage;
            _scanBuffer = new Barcode.SCAN_BUFFER();
            try
            {

                var retVal = (int)Barcode.SCAN_Open(ref _ghScanner);
                if (retVal == Barcode.E_SCN_SUCCESS)
                {
                    //We have a scanner handle, ready to rock and roll

                    // Enabled scanning and the software trigger (Host trigger mode)
                    retVal = (int) Barcode.SCAN_EnableScanning(_ghScanner, 1);
                    if (retVal != Barcode.E_SCN_SUCCESS)
                    {
                        returnMesssage= ("Did not Enabled Scanning");
                        goto Cleanup;
                    }

                    retVal = (int) Barcode.SCAN_EnableSoftTrigger(_ghScanner, 1);
                    if (retVal != Barcode.E_SCN_SUCCESS)
                    {
                        returnMesssage = ("Did not Enabled Soft Trigger");
                        goto Cleanup;
                    }

                    _gpscanBuffer = Barcode.SCAN_AllocateBuffer(Barcode.Max_DATA);

                    if (_gpscanBuffer == IntPtr.Zero)
                    {
                        returnMesssage = ("Could not allocate buffer");
                        goto Cleanup;
                    }



                    //Use the settings set in the control config 
                    Barcode.SCAN_UseControlPanelConfiguration(_ghScanner, 1);
                    IntPtr gPrefixSufix = IntPtr.Zero;
                    var prefixSufix = Barcode.SCAN_GetPrefixSuffix(_ghScanner,gPrefixSufix);


                    //we have a buffer! now we can scan

                    HardwareButtonsConfig(parent);
                    parent.KeyUp += parent_KeyUp;
                    return new Operacion
                    {
                        Codigo = 0,
                        Mensaje = "Proseso exitoso",
                        Resultado = ResultadoOperacionTipo.Exito
                    };

                }
                throw new ArgumentException("We do not have a scanner handle");
                
            }
            catch (Exception e)
            {

                return new Operacion
                {
                    Codigo = -1,
                    Mensaje = e.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };

            }

        Cleanup:
            if (_gpscanBuffer != IntPtr.Zero)
                Barcode.SCAN_DeallocateBuffer(_gpscanBuffer);
            if (_ghScanner != IntPtr.Zero)
                Barcode.SCAN_Close(_ghScanner);

            return new Operacion
            {
                Codigo =-1,
                Mensaje = returnMesssage ,
                Resultado = ResultadoOperacionTipo.Error
            };

        }

        public void Enabled()
        {
            SetupScanner(_parent);
        }

        public void Disabled()
        {
            if (_ghScanner==IntPtr.Zero) return;
            _parent.KeyUp -= parent_KeyUp;
            var retVal = (int) Barcode.SCAN_Close(_ghScanner);

        }

        void parent_KeyUp(object sender, KeyEventArgs e)
        {
            switch ((HardwareKeys)e.KeyCode)
            {
                case HardwareKeys.ApplicationKey3:
                    OnScann();
                    break;
            }
        }

        private void OnScann()
        {
            try
            {
                

                if (_ghScanner != IntPtr.Zero)
                {

                    // Initiate scanning. Timeout in 3 seconds.
                    var retVal = (int)Barcode.SCAN_ReadLabelWait(_ghScanner, _gpscanBuffer, Barcode.SCAN_TYPE_TRIGGER);

                    if (Barcode.E_SCN_SUCCESS == retVal)
                    {
                        //copy data to scan buffer

                        _scanBuffer = (Barcode.SCAN_BUFFER)Marshal.PtrToStructure(_gpscanBuffer, _scanBuffer.GetType());

                        String scanGot = System.Text.Encoding.ASCII.GetString(_scanBuffer.szData,
                                                                                0,
                                                                                (int)_scanBuffer.dwDataLength);
                        if (BarcodeIsScanned!=null)
                        {
                            BarcodeIsScanned(this, new BarcodeDataEventArg
                            {
                                BarcodeData = scanGot + '\r'
                            });
                        }
                    }
                    else
                    {
                        //Console.WriteLine("There was a problem Scanning, returned " + retVal);
                    }
                }

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }

        }
    }
}
