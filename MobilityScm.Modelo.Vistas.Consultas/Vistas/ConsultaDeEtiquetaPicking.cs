using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobilityScm.Louncher;
using MobilityScm.BarcodeScann.Arguments;
using MobilityScm.Keyboard;
using MobilityScm.Print.Zebra;


namespace MobilityScm.Modelo.Vistas
{
    public partial class ConsultaDeEtiquetaPicking : UserControl, IControl
    {
        public ConsultaDeEtiquetaPicking()
        {
            InitializeComponent();
            IsNew = true;

        }

        #region IControl Members

        public bool IsNew { get; set; }

        private static ConsultaDeEtiquetaPicking _ConsultaDeEtiquetaPicking;
        public static ConsultaDeEtiquetaPicking Create()
        {
            if (_ConsultaDeEtiquetaPicking != null)
            {
                return _ConsultaDeEtiquetaPicking;
            }

            _ConsultaDeEtiquetaPicking = new ConsultaDeEtiquetaPicking();
            return _ConsultaDeEtiquetaPicking;
        }


        public void UnLoad()
        {
            VariablesDeAmbienteParaConsulta.BarcodeScanner.DataReady -= new EventHandler<BarcodeDataEventArg>(BarcodeScanner_DataReady);
            VariablesDeAmbienteParaConsulta.BarcodeScanner.Disabled();
        }

        public void Load()
        {
            VariablesDeAmbienteParaConsulta.BarcodeScanner.DataReady += new EventHandler<BarcodeDataEventArg>(BarcodeScanner_DataReady);
            VariablesDeAmbienteParaConsulta.BarcodeScanner.Enabled();
            CargarTiposDeConsulta();
            LimpiarCampos();
        }

        #endregion

        private void LimpiarCampos()
        {
            UiEtiquetaUbicacionSalida.Text = string.Empty;
            UiListaMaterialesEnEtiqueta.DataSource = null;
            UiTextoEscanear.Text = string.Empty;
            UiBotonImprimir.Visible = false;
        }

        private string codigoCliente, nombreCliente, regimen, departamento, etiqueta, numeroDeOlaDePicking;

        void BarcodeScanner_DataReady(object sender, BarcodeDataEventArg e)
        {
            try
            {
                string codigo = e.BarcodeData.Remove(e.BarcodeData.Length - 1, 1);
                UsuarioDeseaConsultarEtiqueta(codigo);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UsuarioDeseaConsultarEtiqueta(string codigoEtiqueta)
        {
            var servicio = new WMS_InfoInventory.WMS_InfoInventory(true);
            string resultado = string.Empty;
            var informacionEtiquetaTabla = servicio.ObtenerInformacionDeLaEtiquetaOCaja(UiListaTipoCertificacion.Value.ToString()
                                                            , codigoEtiqueta, VariablesDeAmbienteParaConsulta.Enviroment, ref resultado);
            if (resultado == "OK")
            {
                if (informacionEtiquetaTabla == null || informacionEtiquetaTabla.Rows.Count <= 0)
                {
                    LimpiarCampos();
                    MessageBox.Show("No se encontró información de la etiqueta.");
                    return;
                }
                UiEtiquetaUbicacionSalida.Text = informacionEtiquetaTabla.Rows[0]["LOCATION_SPOT_TARGET"].ToString();
                UiTextoEscanear.Text = codigoEtiqueta;
                var olaPicking = int.Parse(informacionEtiquetaTabla.Rows[0]["WAVE_PICKING_ID"].ToString());
                codigoCliente = informacionEtiquetaTabla.Rows[0]["CLIENT_OWNER"].ToString();
                nombreCliente = informacionEtiquetaTabla.Rows[0]["CLIENT_NAME"].ToString();
                departamento = informacionEtiquetaTabla.Rows[0]["STATE_CODE"].ToString();
                regimen = informacionEtiquetaTabla.Rows[0]["REGIMEN"].ToString();
                etiqueta = codigoEtiqueta;
                numeroDeOlaDePicking = informacionEtiquetaTabla.Rows[0]["WAVE_PICKING_ID"].ToString();

                var detalleEtiquetaTabla = servicio.ObtenerDetalleDeLaEtiquetaOCaja(UiListaTipoCertificacion.Value.ToString()
                                            , codigoEtiqueta, olaPicking, VariablesDeAmbienteParaConsulta.Enviroment, ref resultado);

                UiListaMaterialesEnEtiqueta.DataSource = detalleEtiquetaTabla;
                UiBotonImprimir.Visible = true;
            }
            else
            {
                LimpiarCampos();
                MessageBox.Show(resultado);
            }
        }

        private void UiBotonImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                PrintModule.PrintLabel(codigoCliente, nombreCliente, regimen, etiqueta, departamento, numeroDeOlaDePicking, VariablesDeAmbienteParaConsulta.UserId, VariablesDeAmbienteParaConsulta.Printer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarTiposDeConsulta()
        {
            try
            {
                var servicioConfiguracion = new MobilityScm.Modelo.Wms_Settings.WMS_Settings(true);
                var resultado = string.Empty;
                var ds = servicioConfiguracion.GetParam_ByParamKey("SISTEMA", "TIPOS_ETIQUETAS_PICKING", "", ref resultado, VariablesDeAmbienteParaConsulta.Enviroment);
                if (resultado.ToUpper().Equals("OK"))
                {
                    UiListaTipoCertificacion.DataSource = null;
                    UiListaTipoCertificacion.DataSource = ds.Tables[0];
                    foreach (DataRow fila in ds.Tables[0].Rows)
                    {
                        if (EsParametroPredeterminado(int.Parse(fila["NUMERIC_VALUE"].ToString())))
                        {
                            UiListaTipoCertificacion.Text = fila["PARAM_CAPTION"].ToString();
                            UiListaTipoCertificacion.Value = fila["PARAM_NAME"].ToString();
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(resultado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool EsParametroPredeterminado(int valor)
        {
            return (valor == 1);
        }

        private void UiVistaConsultaEtiqueta_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }
        private void UsuarioPresionoBoton(object sender, KeyEventArgs e)
        {
            var nombreDeObjeto = ObtenerNombreDeObjetoSeleccionado(sender);

            switch (e.ObtenerActionDeBoton(VariablesDeAmbienteParaConsulta.Enviroment, VariablesDeAmbienteParaConsulta.WsHost))
            {

                case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR:
                    if (nombreDeObjeto == "UiTextoEscanear")
                    {
                        UsuarioDeseaConsultarEtiqueta(UiTextoEscanear.Text);
                    }

                    break;
                case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR:
                    this.Back();
                    break;
            }

        }
        private string ObtenerNombreDeObjetoSeleccionado(object sender)
        {
            if (sender.GetType() == typeof(Resco.Controls.DetailView.DetailView) && ((Resco.Controls.DetailView.DetailView)sender).SelectedItem != null)
            {
                return ((Resco.Controls.DetailView.DetailView)sender).SelectedItem.Name;
            }
            return string.Empty;
        }

        private void UiListaMaterialesEnEtiqueta_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }
    }
}
