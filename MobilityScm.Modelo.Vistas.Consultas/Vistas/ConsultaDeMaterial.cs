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
    public partial class ConsultaDeMaterial : UserControl, IControl
    {
        public static MobilityScm.Modelo.Tipos.Escanear Escanear { get; set; }

        public ConsultaDeMaterial()
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


        private static ConsultaDeMaterial _ConsultaDeMaterial;
        public static ConsultaDeMaterial Create()
        {            
            Escanear = MobilityScm.Modelo.Tipos.Escanear.Material;            
            if (_ConsultaDeMaterial != null)
            {
                _ConsultaDeMaterial.UiTextoCodigoSku.Text = "";
                _ConsultaDeMaterial.UiTextoDescripcionMaterial.Text = "";            
                return _ConsultaDeMaterial;
            }

            _ConsultaDeMaterial = new ConsultaDeMaterial();            
            return _ConsultaDeMaterial;
        }

        static void BarcodeScanner_DataReady(object sender, MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg e)
        {
            try
            {
                switch (Escanear)
                {
                    case MobilityScm.Modelo.Tipos.Escanear.Material:
                        _ConsultaDeMaterial.UiTextoCodigoSku .Text = e.BarcodeData.Remove(e.BarcodeData.Length - 1, 1);
                        _ConsultaDeMaterial.ValidarMaterial();
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
                    ValidarMaterial();
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

        public void ValidarMaterial()
        {
            try
            {
                if (!string.IsNullOrEmpty(UiTextoCodigoSku.Text))
                {
                    UiTextoDescripcionMaterial.Text = "";                        
                    var servicio = new MobilityScm.Modelo.WMS_InfoTrans.WMS_InfoTrans(true);
                    var resultado = string.Empty;
                    var dt = servicio.GetMaterial(UiTextoCodigoSku.Text, ref resultado, VariablesDeAmbienteParaConsulta.Enviroment);
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
                            if (dt.Rows.Count == 1)
                            {
                                UiTextoDescripcionMaterial.Text = dt.Rows[0]["MATERIAL_NAME"].ToString();
                            }
                            else {
                                var cadena = new StringBuilder();
                                foreach (DataRow fila in dt.Rows)
                                {
                                    cadena.Append(fila["MATERIAL_ID"].ToString() + "-" + fila["MATERIAL_NAME"].ToString() + Environment.NewLine);
                                }
                                UiTextoDescripcionMaterial.Text = cadena.ToString();
                            }                            
                        }
                        else
                        {
                            Resco.Controls.MessageBox.MessageBoxEx.Show("El sku no existe.");
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
