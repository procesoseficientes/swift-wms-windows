using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Data;
using MobilityScm.Keyboard.Entidades;


namespace MobilityScm.Keyboard
{
    public static class ButtonConfiguration
    {
        private static string WS_Host = string.Empty;
        private static string Environment = string.Empty;

        public static List<ButtonAction> ListaConfiguracion
        {
            get
            {
                if (listaConfiguracion == null)
                {
                    string pResult = string.Empty;
                    WMS_Settings.WMS_Settings client = new MobilityScm.Keyboard.WMS_Settings.WMS_Settings(WS_Host);
                    string modeloDispositivo = UsuarioDeseaObtenerInformacionModelo();
                    string fabricante = UsuarioDeseaObtenerInformacionFabricante();
                    DataTable dt = client.GetHHButtonSettings(modeloDispositivo, fabricante, ref  pResult, Environment);
                    listaConfiguracion = new List<ButtonAction>();
                    if (dt.Rows.Count<= 0)
                    {
                        throw new Exception("No existe configuración de botones para " + modeloDispositivo + " " + fabricante);
                    }
                    foreach (DataRow item in dt.Rows)
                    {
                        listaConfiguracion.Add(new ButtonAction { Action = item.Field<string>("CODE_ACTION"), AsciiValue = item.Field<int>("ASCCI_VALUE") });
                    }
                    return listaConfiguracion;
                    
                }
                return listaConfiguracion;
            }
        }

        private static List<ButtonAction> listaConfiguracion;

        

        public static MobilityScm.Modelo.Tipos.FuncionBoton ObtenerActionDeBoton(this System.Windows.Forms.KeyEventArgs e, string pEnvironment, string pWS_Host)
        {
            WS_Host = pWS_Host;
            Environment = pEnvironment;
            int keyValue = Convert.ToInt32(e.KeyValue.ToString());
            var y = ListaConfiguracion.Where(x => x.AsciiValue == keyValue).ToList();
            if (y.Count> 0)
            {
                return (MobilityScm.Modelo.Tipos.FuncionBoton ) Enum.Parse(typeof(MobilityScm.Modelo.Tipos.FuncionBoton), y.FirstOrDefault().Action, true);
            }
            return MobilityScm.Modelo.Tipos.FuncionBoton.INDEFINIDO;
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

    }
}
