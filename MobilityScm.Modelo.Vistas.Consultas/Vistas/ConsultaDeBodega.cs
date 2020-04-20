using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobilityScm.Louncher;
using MobilityScm.Keyboard;


namespace MobilityScm.Modelo.Vistas
{
    public partial class ConsultaDeBodega : UserControl, IControl
    {
        public static MobilityScm.Modelo.Tipos.Escanear Escanear { get; set; }

        public ConsultaDeBodega()
        {
            InitializeComponent();
            IsNew = true;
        }

        #region IControl Members

        public bool IsNew { get; set; }

        public void UnLoad()
        {
            //remove handlers
            VariablesDeAmbienteParaConsulta.BarcodeScanner.DataReady -= BarcodeScanner_DataReady;
            VariablesDeAmbienteParaConsulta.BarcodeScanner.Disabled();
        }

        public void Load()
        {
            //
            VariablesDeAmbienteParaConsulta.BarcodeScanner.DataReady += new EventHandler<MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg>(BarcodeScanner_DataReady);
            VariablesDeAmbienteParaConsulta.BarcodeScanner.Enabled();
        }


        private static ConsultaDeBodega _ConsultaDeBodega;
        public static ConsultaDeBodega Create()
        {            
            Escanear = MobilityScm.Modelo.Tipos.Escanear.Ubicacion;            
            if (_ConsultaDeBodega != null)
            {
                _ConsultaDeBodega.UiTextoBodega.Text = "";
                _ConsultaDeBodega.Focus();
                return _ConsultaDeBodega;
            }

            _ConsultaDeBodega = new ConsultaDeBodega();
            _ConsultaDeBodega.Focus();
            return _ConsultaDeBodega;
        }

        static void BarcodeScanner_DataReady(object sender, MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg e)
        {
            try
            {
                switch (Escanear)
                {
                    case MobilityScm.Modelo.Tipos.Escanear.Ubicacion:
                        _ConsultaDeBodega.UiTextoBodega.Text = e.BarcodeData.Remove(e.BarcodeData.Length - 1, 1);
                        _ConsultaDeBodega.ValidarUbicacion();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #endregion


        #region Eventos de Pantalla

        private void UiVistaMasterPack_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.ObtenerActionDeBoton(VariablesDeAmbienteParaConsulta.Enviroment, VariablesDeAmbienteParaConsulta.WsHost))
            {
                case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR:
                    ValidarUbicacion();
                    break;
                case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR:
                    this.Back();
                    break;
                case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR:
                    break;
                case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR:                    
                    break;
            }
        }

        #endregion        


        #region Metodos

        public void ValidarUbicacion() {
            try {                
                if (!string.IsNullOrEmpty(UiTextoBodega.Text)) {
                    var servicio = new MobilityScm.Modelo.WMS_InfoTrans.WMS_InfoTrans(true);
                    var resultado = string.Empty;
                    var dt = servicio.GetLocation(UiTextoBodega.Text, ref resultado, VariablesDeAmbienteParaConsulta.Enviroment);
                    Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = false;
                    Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Red;
                    if (!string.IsNullOrEmpty(resultado))
                    {                        
                        Resco.Controls.MessageBox.MessageBoxEx.Show(resultado);
                    }
                    else
                    {
                        if (dt.Rows.Count > 0)
                        {
                            Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green;
                            Resco.Controls.MessageBox.MessageBoxEx.Show("La ubicación existe.");                            
                        }
                        else
                        {
                            Resco.Controls.MessageBox.MessageBoxEx.Show("La ubicación no existe.");                                                        
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        #endregion
    }
}
