using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobilityScm.Louncher;
using MobilityScm.Keyboard;
using MobilityScm.Modelo.Estados;
using MobilityScm.Print.Zebra;
using MobilityScm.Modelo.Tipos;

namespace MobilityScm.Modelo.Vistas.Certificacion.Vistas
{
    public partial class CertificacionIngresoDeNumeroDeSerie : UserControl, IControl
    {
        public static MobilityScm.Modelo.Tipos.Escanear Escanear { get; set; }

        private static int CertificacionId { get; set; }
        private static int ManifiestoId { get; set; }
        private static string MaterialId { get; set; }
        private static string DescripcionMaterial { get; set; }

        public CertificacionIngresoDeNumeroDeSerie()
        {
            InitializeComponent();
            IsNew = true;
        }

        #region IControl Members

        public bool IsNew { get; set; }

        public void UnLoad()
        {
            VariablesDeAmbienteCertificacion.EscanerDeCodigoDeBarras.DataReady -= BarcodeScanner_DataReady;
            VariablesDeAmbienteCertificacion.EscanerDeCodigoDeBarras.Disabled();
            
        }

        public void Load()
        {
            CargarControles();
            VariablesDeAmbienteCertificacion.EscanerDeCodigoDeBarras.DataReady += new EventHandler<MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg>(BarcodeScanner_DataReady);
            VariablesDeAmbienteCertificacion.EscanerDeCodigoDeBarras.Enabled();
            
        }

        private static CertificacionIngresoDeNumeroDeSerie _CertificacionIngresoDeNumeroDeSerie;
        public static CertificacionIngresoDeNumeroDeSerie Create(int certificacionId, int manifiestoId, string materialId, string descripcionMaterial)
        {
            CertificacionId = certificacionId;
            ManifiestoId = manifiestoId;
            MaterialId = materialId;
            DescripcionMaterial = descripcionMaterial;

            if (_CertificacionIngresoDeNumeroDeSerie != null)
            {
                return _CertificacionIngresoDeNumeroDeSerie;
            }

            _CertificacionIngresoDeNumeroDeSerie = new CertificacionIngresoDeNumeroDeSerie();
            return _CertificacionIngresoDeNumeroDeSerie;
        }

        void BarcodeScanner_DataReady(object sender, MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg e)
        {
            try
            {                
                string codigo = e.BarcodeData.Remove(e.BarcodeData.Length - 1, 1);
                switch (Escanear)
                {
                    case Escanear.Serie:
                        UsuarioEscaneoSerie(codigo);
                        break;                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Eventos de Controles

        private void UiVistaCertificacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.ObtenerActionDeBoton(VariablesDeAmbienteCertificacion.Empresa, VariablesDeAmbienteCertificacion.DireccionDeServicio))
                {
                    case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR:
                        if (!string.IsNullOrEmpty(UiTextoNumeroDeSerie.Text)) {
                            UsuarioEscaneoSerie(UiTextoNumeroDeSerie.Text);
                        }
                        break;
                    case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR:
                        this.Back();
                        break;                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Metodos

        private bool ProcesoExitoso(int valor)
        {
            return valor > 0;
        }

        private bool ProcesoExitoso(string valor)
        {
            return string.IsNullOrEmpty(valor);
        }

        private bool UsuarioPuedeEliminarSerie(int valor)
        {
            return (valor == 2);
        }

        private bool LlegoAlCienPorCiento(decimal valor)
        {
            return (valor == 100);
        }

        private void CargarControles()
        {
            try
            {
                UiTextoMaterial.Label = MaterialId;
                UiTextoMaterial.Text = DescripcionMaterial;
                Escanear = Escanear.Serie;
                UiTextoNumeroDeSerie.Tag = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

        private void UsuarioEscaneoSerie(string numeroDeSerie) {
            try
            {
                var servicioDeCertificado = new MobilityScm.Modelo.Vistas.Certificacion.Wms_Certification.WMS_Certification(true);
                var resultado = string.Empty;
                var dt = servicioDeCertificado.InsertCertificationBySerialNumber(CertificacionId, ManifiestoId, MaterialId, numeroDeSerie, ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    if (UsuarioPuedeEliminarSerie(int.Parse(dt.Rows[0]["Resultado"].ToString())))
                    {
                        if (MessageBox.Show(dt.Rows[0]["Mensaje"].ToString(), "Manifiesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            EliminarNumeroDeSerie(numeroDeSerie);
                        }
                    }
                    else if (ProcesoExitoso(int.Parse(dt.Rows[0]["Resultado"].ToString())))
                    {
                        var cantidad = int.Parse(dt.Rows[0]["DbData"].ToString());
                        UiTextoNumeroDeSerieAnterior.Label = "( " + cantidad + ")" + " Numero de Serie Anterior";
                        UiTextoNumeroDeSerieAnterior.Text = numeroDeSerie.ToString();

                        var dtMaterial = servicioDeCertificado.InsertCertificationDetail(CertificacionId, 0, 1, "MATERIAL", VariablesDeAmbienteCertificacion.Usuario, MaterialId, string.Empty,ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                        if (ProcesoExitoso(resultado))
                        {
                            if (ProcesoExitoso(int.Parse(dtMaterial.Rows[0]["Resultado"].ToString())))
                            {
                                ValidarCertificacion();
                            }
                            else
                            {
                                EliminarNumeroDeSerie(numeroDeSerie);
                                MessageBox.Show(dtMaterial.Rows[0]["Mensaje"].ToString());                                
                            }
                        }
                        else
                        {
                            MessageBox.Show(resultado);
                        }

                    }
                    else
                    {
                        MessageBox.Show(dt.Rows[0]["Mensaje"].ToString());
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

        private void EliminarNumeroDeSerie(string numeroDeSerie)
        {
            try {
                var servicioDeCertificado = new MobilityScm.Modelo.Vistas.Certificacion.Wms_Certification.WMS_Certification(true);
                var resultado = string.Empty;
                var dt = servicioDeCertificado.DeleteCertificationBySerialNumber(CertificacionId,  MaterialId, numeroDeSerie, ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                if (ProcesoExitoso(resultado))
                {                    
                    if (ProcesoExitoso(int.Parse(dt.Rows[0]["Resultado"].ToString())))
                    {
                        var cantidad = int.Parse(dt.Rows[0]["DbData"].ToString());
                        UiTextoNumeroDeSerieAnterior.Label = "( " + cantidad + ")" + " Numero de Serie Anterior";
                        UiTextoNumeroDeSerieAnterior.Text = numeroDeSerie.ToString();
                    }
                    else
                    {
                        MessageBox.Show(dt.Rows[0]["Mensaje"].ToString());
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

        private void ValidarCertificacion()
        {
            try
            {
                var servicioDeCertificado = new MobilityScm.Modelo.Vistas.Certificacion.Wms_Certification.WMS_Certification(true);
                var resultado = string.Empty;                
                var dt = servicioDeCertificado.ValidateIfCertificationIsComplete(CertificacionId, ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    if (ProcesoExitoso(int.Parse(dt.Rows[0]["Resultado"].ToString())))
                    {
                        UiEtiquetaEncabezado.Label = "Certificación(" + dt.Rows[0]["DbData"].ToString() + "%)";
                        if (LlegoAlCienPorCiento(decimal.Parse(dt.Rows[0]["DbData"].ToString())))
                        {
                            CerrarCertificacion();
                        }
                    }
                    else
                    {
                        MessageBox.Show(dt.Rows[0]["Mensaje"].ToString());
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

        private void CerrarCertificacion()
        {
            try
            {
                var servicioDeCertificado = new MobilityScm.Modelo.Vistas.Certificacion.Wms_Certification.WMS_Certification(true);
                var resultado = string.Empty;                
                var dt = servicioDeCertificado.MarkManifestAsCertified(ManifiestoId, CertificacionId, VariablesDeAmbienteCertificacion.Usuario, ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    if (ProcesoExitoso(int.Parse(dt.Rows[0]["Resultado"].ToString())))
                    {
                        this.Back();
                    }
                    else
                    {
                        MessageBox.Show(dt.Rows[0]["Mensaje"].ToString());
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

        #endregion

        
        
    }
}
