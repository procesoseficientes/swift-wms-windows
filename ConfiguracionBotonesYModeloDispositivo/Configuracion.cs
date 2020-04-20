using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ConfiguracionBotonesYModeloDispositivo
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
            UsuarioDeseaMostrarInformacionDeDispositivo();
        }

      

        private void Configuracion_KeyDown(object sender, KeyEventArgs e)
        {
          

        }

        private void Configuracion_KeyUp(object sender, KeyEventArgs e)
        {
            UiEtiquetaBoton.Text = e.KeyData.ToString();
            UiEtiquetaValorAscii.Text = e.KeyValue.ToString();

            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up

            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }
        }

        private  void UsuarioDeseaMostrarInformacionDeDispositivo()
        {
            UiEtiquetaModelo.Text = UsuarioDeseaObtenerInformacionModelo();
            UiEtiquetaFabricante.Text = UsuarioDeseaObtenerInformacionFabricante();
        }

        private const int SPI_GETOEMINFO = 260;
        private const int SPI_GETPLATFORMMANUFACTURER = 262;

        [DllImport("coredll.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        private static extern int SystemParametersInfoString(int uiAction, int uiParam, StringBuilder pvParam, int fWinIni);

        private static string UsuarioDeseaObtenerInformacionModelo()
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

        private static string UsuarioDeseaObtenerInformacionFabricante()
        {
            try
            {
                StringBuilder sb = new StringBuilder(256);

                if (SystemParametersInfoString(SPI_GETPLATFORMMANUFACTURER, sb.Capacity, sb, 0) != 0)
                {
                    return sb.ToString();
                }
            }
            catch
            {
            }

            return "<Unknown Manufacturer>";
        }

        private void Configuracion_Deactivate(object sender, EventArgs e)
        {
          //  MessageBox.Show("HOLA");
        }

        //public static void ShowWindowsMenu(bool enable)
        //{
        //    try
        //    {
        //        if (enable)
        //        {
        //            if (_taskBar != IntPtr.Zero)
        //            {
        //                // display the start bar
        //                SetWindowPos(_taskBar, IntPtr.Zero, 0, 0, 480, 36, Convert.ToInt32(WindowPosition.SWP_SHOWWINDOW));
        //            }
        //        }
        //        else
        //        {
        //            _taskBar = FindWindowCE("HHTaskBar", null);
        //            // Find the handle to the Start Bar
        //            if (_taskBar != IntPtr.Zero)
        //            {
        //                // If the handle is found then hide the start bar
        //                // Hide the start bar
        //                SetWindowPos(_taskBar, IntPtr.Zero, 0, 0, 0, 0, Convert.ToInt32(WindowPosition.SWP_HIDEWINDOW));
        //            }
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        //ErrorWrapper(If(enable, "Show Start", "Hide Start"), err)
        //    }
        //    try
        //    {
        //        if (enable)
        //        {
        //            if (_sipButton != IntPtr.Zero)
        //            {
        //                // If the handle is found then hide the start bar
        //                // display the start bar
        //                SetWindowPos(_sipButton, IntPtr.Zero, 0, 0, 480, 36, Convert.ToInt32(WindowPosition.SWP_SHOWWINDOW));
        //            }
        //        }
        //        else
        //        {
        //            _sipButton = FindWindowCE("MS_SIPBUTTON", "MS_SIPBUTTON");
        //            if (_sipButton != IntPtr.Zero)
        //            {
        //                // If the handle is found then hide the start bar
        //                // Hide the start bar
        //                SetWindowPos(_sipButton, IntPtr.Zero, 0, 0, 0, 0, Convert.ToInt32(WindowPosition.SWP_HIDEWINDOW));
        //            }
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        //ErrorWrapper(If(enable, "Show SIP", "Hide SIP"), err)
        //    }
        //}

    }
}