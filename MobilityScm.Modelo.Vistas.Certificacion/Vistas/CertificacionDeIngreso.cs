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
using Resco.Controls.AdvancedTree;

namespace MobilityScm.Modelo.Vistas.Certificacion.Vistas
{
    public partial class CertificacionDeIngreso : UserControl, IControl
    {
        public static MobilityScm.Modelo.Tipos.Escanear Escanear { get; set; }

        private bool UsuarioPuedeFinalizarParcial { get; set; }

        private int CertificacionId { get; set; }
        private bool RetornaDeIngresarSeries { get; set; }
        
        public CertificacionDeIngreso()
        {
            InitializeComponent();
            IsNew = true;
            RetornaDeIngresarSeries = false;
        }

        #region IControl Members

        public bool IsNew { get; set; }

        public void UnLoad()
        {
            VariablesDeAmbienteCertificacion.EscanerDeCodigoDeBarras.DataReady -= BarcodeScanner_DataReady;
            VariablesDeAmbienteCertificacion.EscanerDeCodigoDeBarras.Disabled();
            UiListaTipoCertificacion.Changed -= UiListaTipoCertificacion_Changed;
        }

        public void Load()
        {
            VariablesDeAmbienteCertificacion.EscanerDeCodigoDeBarras.DataReady += new EventHandler<MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg>(BarcodeScanner_DataReady);
            VariablesDeAmbienteCertificacion.EscanerDeCodigoDeBarras.Enabled();
            UiListaTipoCertificacion.Changed += new Resco.Controls.DetailView.ItemEventHandler(UiListaTipoCertificacion_Changed);            
            CargarControles();            
        }

        private static CertificacionDeIngreso _CertificacionDeIngreso;
        public static CertificacionDeIngreso Create()
        {
            if (_CertificacionDeIngreso != null)
            {
                return _CertificacionDeIngreso;
            }

            _CertificacionDeIngreso = new CertificacionDeIngreso();
            return _CertificacionDeIngreso;
        }

        #endregion

        #region Eventos de Controles

        void UiListaTipoCertificacion_Changed(object sender, Resco.Controls.DetailView.ItemEventArgs e)
        {
            try
            {
                if (e.item.Value == null) return;
                MostrarControlesPorTipoDeCertificacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void BarcodeScanner_DataReady(object sender, MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg e)
        {
            try
            {
                UiListaDetalleCertificacion.Visible = false;
                char delimiter = '-';

                string codigo = e.BarcodeData.Remove(e.BarcodeData.Length - 1, 1);
                switch (Escanear)
                {
                    case Escanear.Manifiesto:
                        if (!FormatoCorrecto(codigo))
                        {
                            MessageBox.Show("Formato de manifiesto incorrecto");
                            break;
                        }
                        codigo = codigo.Split(delimiter)[1].ToString();
                        CargarManifiesto(int.Parse(codigo));
                        UiTextoManifiesto.Text = codigo.ToString();
                        break;
                    case Escanear.Material:
                        UsuarioEscaneoMaterial(codigo);
                        break;
                    case Escanear.Etiqueta:
                        UsuarioEscaneoEtiqueta(int.Parse(codigo));
                        break;
                    case Escanear.Caja:
                        UsuarioEscaneoCaja(codigo);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UiVistaCertificacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.ObtenerActionDeBoton(VariablesDeAmbienteCertificacion.Empresa, VariablesDeAmbienteCertificacion.DireccionDeServicio))
                {
                    case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR:
                        switch (Escanear)
                        {
                            case Escanear.Manifiesto:
                                CargarManifiesto(int.Parse(UiTextoManifiesto.Text));
                                break;
                            case Escanear.Material:
                                UsuarioDeseaAceptarMaterial();
                                break;
                        }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UiBotonCrearCertificacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (CrearManifiesto(UiTextoManifiesto.ReadOnly))
                {
                    CrearCertificado();
                }
                else
                {
                    CargarControles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UiBotonDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                CargarDetalle();
                UiListaDetalleCertificacion.Visible = !UiListaDetalleCertificacion.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UiBotonFinalizar_Click(object sender, EventArgs e)
        {
            FinalizarCertificacionParcial();
        }

        #endregion

        #region Metodos

        private void MostrarBotones()
        {
            UiBotonCrearCertificacion.Visible = true;
            UiBotonDetalle.Visible = true;
        }

        private bool FormatoCorrecto(string codigo)
        {
            return codigo.Split('-').Length == 2;
        }
        
        private bool ProcesoExitoso(string valor)
        {
            return string.IsNullOrEmpty(valor);
        }

        private bool CrearManifiesto(bool valor)
        {
            return !valor;
        }

        private bool ProcesoExitoso(int valor)
        {
            return valor > 0;
        }

        private bool ExisteRegistro(int valor)
        {
            return valor > 0;
        }

        private bool EsParametroPredeterminado(int valor)
        {
            return (valor == 1);
        }

        private bool UsuarioPuedeEliminarEtiqueta(int valor)
        {
            return (valor == 2);
        }

        private bool LlegoAlCienPorciento(decimal valor)
        {
            return (valor == 100);
        }

        private bool MaterialConNumeroDeSerie(int valor)
        {
            return valor == 1;
        }

        private void LimpiarControlesDeMaterial()
        {
            UiTextoEscanear.Text = "...";
            UiEtiquetaDescripcion.Text = "...";
            UiTextoCantidad.Visible = false;
            UiTextoCantidad.Text = "";
        }

        private void CargarControles()
        {
            try
            {
                UiListaTipoCertificacion.Visible = false;
                UiTextoEscanear.Visible = false;
                UiEtiquetaDescripcion.Visible = false;
                UiTextoCantidad.Visible = false;
                UiBotonCrearCertificacion.Visible = false;
                Escanear = Escanear.Manifiesto;
                UiTextoManifiesto.ReadOnly = false;
                UiTextoManifiesto.Label = "Manifiesto";
                UiTextoManifiesto.Text = "";
                UiBotonCrearCertificacion.Text = "Crear Certificación";
                UiBotonDetalle.Visible = false;
                UiEtiquetaEncabezado.Label = "Certificación(0%)";
                UiListaDetalleCertificacion.Visible = false;
                UiBotonFinalizar.Visible = false;
                CargarParametros();

                if (RetornaDeIngresarSeries)
                {
                    RetornaDeIngresarSeries = false;
                    var manifiestoId = int.Parse(UiTextoManifiesto.Tag.ToString());
                    CargarManifiesto(manifiestoId);
                }
                else
                {
                    UiTextoManifiesto.Tag = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarTiposDeCertificacion()
        {
            try
            {
                var servicioConfiguracion = new MobilityScm.Modelo.Vistas.Certificacion.Wms_Settings.WMS_Settings(true);
                var resultado = string.Empty;
                var ds = servicioConfiguracion.GetParam_ByParamKey("CERTIFICACION", "TIPOS_CERTIFICACION", "", ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                if (resultado.ToUpper().Equals("OK"))
                {
                    UiListaTipoCertificacion.DataSource = null;
                    UiListaTipoCertificacion.DataSource = ds.Tables[0];
                    foreach (DataRow fila in ds.Tables[0].Rows)
                    {
                        if (EsParametroPredeterminado(int.Parse(fila["NUMERIC_VALUE"].ToString())))
                        {
                            UiListaTipoCertificacion.Text = fila["NUMERIC_VALUE"].ToString();
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

        private void MostrarControlesPorTipoDeCertificacion()
        {
            try
            {
                if (UiListaTipoCertificacion.Value == null) return;
                switch (UiListaTipoCertificacion.Value.ToString())
                {
                    case "ETIQUETA":
                        UiTextoEscanear.Visible = true;
                        UiTextoEscanear.Label = "Escanear etiqueta.";
                        UiEtiquetaDescripcion.Visible = false;
                        UiTextoCantidad.Visible = false;
                        Escanear = Escanear.Etiqueta;
                        LimpiarControlesDeMaterial();
                        break;
                    case "MATERIAL":
                        UiTextoEscanear.Visible = true;
                        UiTextoEscanear.Label = "Escanear material.";
                        UiEtiquetaDescripcion.Visible = true;
                        UiTextoCantidad.Visible = false;
                        Escanear = Escanear.Material;
                        LimpiarControlesDeMaterial();
                        break;
                    case "CAJA":
                        UiTextoEscanear.Visible = true;
                        UiTextoEscanear.Label = "Escanear Caja.";
                        UiEtiquetaDescripcion.Visible = false;
                        UiTextoCantidad.Visible = false;
                        Escanear = Escanear.Caja;
                        LimpiarControlesDeMaterial();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarManifiesto(int manifiestoId)
        {
            try
            {
                var servicioDeCertificado = new MobilityScm.Modelo.Vistas.Certificacion.Wms_Certification.WMS_Certification(true);
                var resultado = string.Empty;
                var dt = servicioDeCertificado.GetManifiestHeader(manifiestoId, ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    if (ExisteRegistro(dt.Rows.Count))
                    {
                        UiTextoManifiesto.Tag = manifiestoId;
                        UiTextoManifiesto.Label = string.Format("Manifiesto({0})", manifiestoId.ToString());
                        CertificacionId = (dt.Rows[0]["CERTIFICATION_HEADER_ID"] == DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["CERTIFICATION_HEADER_ID"].ToString());
                        if (ExisteRegistro(CertificacionId))
                        {
                            if (dt.Rows[0]["STATUS_CERTIFICATION"].ToString().ToUpper().Equals("COMPLETED"))
                            {
                                Escanear = Escanear.Nada;
                                UiListaTipoCertificacion.Visible = false;
                                UiTextoEscanear.Visible = false;
                                UiEtiquetaDescripcion.Visible = false;
                                UiTextoCantidad.Visible = false;
                                UiBotonFinalizar.Visible = false;
                                UiTextoManifiesto.ReadOnly = true;
                                UiTextoManifiesto.Label = string.Format("Manifiesto({0}) Completado", manifiestoId.ToString());                                
                            }
                            else
                            {
                                UiListaTipoCertificacion.Visible = true;
                                UiTextoManifiesto.ReadOnly = true;
                                CargarTiposDeCertificacion();                                
                                UiBotonFinalizar.Visible = UsuarioPuedeFinalizarParcial;
                            }
                            UiBotonCrearCertificacion.Text = "Escanear Manifiesto";
                            UiBotonCrearCertificacion.Visible = true;
                            UiBotonDetalle.Visible = true;                            
                            ValidarCertificacion();
                        }
                        else
                        {
                            UiBotonCrearCertificacion.Visible = true;
                            UiBotonDetalle.Visible = false;
                            UiBotonFinalizar.Visible = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El manifiesto escaneado no existe o ya fue procesado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CrearCertificado()
        {
            try
            {
                if (UiTextoManifiesto.Tag == null) return;
                if (MessageBox.Show("¿Desea crear la certificación para este manifiesto.?", "Manifiesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    var servicioDeCertificado = new MobilityScm.Modelo.Vistas.Certificacion.Wms_Certification.WMS_Certification(true);
                    var resultado = string.Empty;
                    var manifiestoId = int.Parse(UiTextoManifiesto.Tag.ToString());
                    var dt = servicioDeCertificado.InsertCertificationHeader(manifiestoId, VariablesDeAmbienteCertificacion.Usuario, ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                    if (ProcesoExitoso(resultado))
                    {
                        if (ExisteRegistro(dt.Rows.Count))
                        {
                            CertificacionId = int.Parse(dt.Rows[0]["DbData"].ToString());
                            UiBotonCrearCertificacion.Visible = false;
                            UiListaTipoCertificacion.Visible = true;
                            UiTextoManifiesto.ReadOnly = true;
                            UiBotonCrearCertificacion.Text = "Escanear Manifiesto";
                            UiBotonFinalizar.Visible = true;
                            UiBotonFinalizar.Visible = UsuarioPuedeFinalizarParcial;
                            CargarTiposDeCertificacion();
                            MostrarBotones();
                        }
                        else
                        {
                            MessageBox.Show("El manifiesto no existe.");
                        }
                    }
                    else
                    {
                        MessageBox.Show(resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UsuarioEscaneoMaterial(string materialId)
        {
            try
            {
                var servicioDeCertificado = new MobilityScm.Modelo.Vistas.Certificacion.Wms_Certification.WMS_Certification(true);
                var resultado = string.Empty;
                var manifiestoId = int.Parse(UiTextoManifiesto.Tag.ToString());
                var dt = servicioDeCertificado.GetMaterialForManifest(manifiestoId, materialId, ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    if (ExisteRegistro(dt.Rows.Count))
                    {
                        if (MaterialConNumeroDeSerie(int.Parse(dt.Rows[0]["SERIAL_NUMBER_REQUESTS"].ToString())))
                        {
                            RetornaDeIngresarSeries = true;
                            CertificacionIngresoDeNumeroDeSerie.Create(CertificacionId, manifiestoId, dt.Rows[0]["MATERIAL_ID"].ToString(), dt.Rows[0]["MATERIAL_NAME"].ToString()).ShowPane();
                        }
                        else
                        {
                            UiTextoEscanear.Text = dt.Rows[0]["MATERIAL_ID"].ToString();
                            UiEtiquetaDescripcion.Text = dt.Rows[0]["MATERIAL_NAME"].ToString();
                            UiTextoCantidad.Visible = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El material escaneado no pertenece al manifiesto.");
                    }

                }
                else
                {
                    MessageBox.Show(resultado);
                }
                MostrarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UsuarioDeseaAceptarMaterial()
        {
            try
            {
                var cantidad = decimal.Parse(UiTextoCantidad.Text);
                if (cantidad <= 0) return;
                var servicioDeCertificado = new MobilityScm.Modelo.Vistas.Certificacion.Wms_Certification.WMS_Certification(true);
                var resultado = string.Empty;
                var manifiestoId = int.Parse(UiTextoManifiesto.Tag.ToString());

                var dt = servicioDeCertificado.InsertCertificationDetail(CertificacionId, 0, cantidad, "MATERIAL", VariablesDeAmbienteCertificacion.Usuario, UiTextoEscanear.Text, string.Empty, ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    if (ProcesoExitoso(int.Parse(dt.Rows[0]["Resultado"].ToString())))
                    {
                        LimpiarControlesDeMaterial();
                        ValidarCertificacion();
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
                MostrarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UsuarioEscaneoEtiqueta(int etiqueta)
        {
            try
            {
                var servicioDeCertificado = new MobilityScm.Modelo.Vistas.Certificacion.Wms_Certification.WMS_Certification(true);
                var resultado = string.Empty;
                var manifiestoId = int.Parse(UiTextoManifiesto.Tag.ToString());
                var dt = servicioDeCertificado.InsertCertificationDetail(CertificacionId, etiqueta, 0, "ETIQUETA", VariablesDeAmbienteCertificacion.Usuario, string.Empty, string.Empty, ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    if (UsuarioPuedeEliminarEtiqueta(int.Parse(dt.Rows[0]["Resultado"].ToString())))
                    {
                        if (MessageBox.Show(dt.Rows[0]["Mensaje"].ToString(), "Manifiesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            EliminarEtiqueta(int.Parse(dt.Rows[0]["DbData"].ToString()));
                        }
                        ValidarCertificacion();
                    }
                    else if (ProcesoExitoso(int.Parse(dt.Rows[0]["Resultado"].ToString())))
                    {
                        UiTextoEscanear.Text = "Ultima etiqueta escaneada: " + etiqueta.ToString();
                        ValidarCertificacion();
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

        private void UsuarioEscaneoCaja(string codigoCaja)
        {
            try
            {
                var servicioDeCertificado = new MobilityScm.Modelo.Vistas.Certificacion.Wms_Certification.WMS_Certification(true);
                var resultado = string.Empty;
                var manifiestoId = int.Parse(UiTextoManifiesto.Tag.ToString());
                var dt = servicioDeCertificado.InsertCertificationDetail(CertificacionId, 0, 0, "CAJA", VariablesDeAmbienteCertificacion.Usuario, string.Empty, codigoCaja, ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    var codigoResultado = int.Parse(dt.Rows[0]["Resultado"].ToString());
                    var mensaje = dt.Rows[0]["Mensaje"].ToString();
                    var codigoCertificacion = dt.Rows[0]["Codigo"].ToString();
                    var codigo = dt.Rows[0]["DbData"].ToString();
                    if (UsuarioPuedeEliminarEtiqueta(codigoResultado))
                    {
                        if (MessageBox.Show(mensaje, "Manifiesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            EliminarCaja(codigo, codigoCertificacion);
                        }
                        ValidarCertificacion();
                    }
                    else if (ProcesoExitoso(codigoResultado))
                    {
                        UiTextoEscanear.Text = "Última caja escaneada: " + codigoCaja.ToString();
                        ValidarCertificacion();
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
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

        private void EliminarEtiqueta(int certifiacionDetalleId)
        {
            try
            {
                var servicioDeCertificado = new MobilityScm.Modelo.Vistas.Certificacion.Wms_Certification.WMS_Certification(true);
                var resultado = string.Empty;
                var manifiestoId = int.Parse(UiTextoManifiesto.Tag.ToString());
                var dt = servicioDeCertificado.DeleteCertificationDetail(certifiacionDetalleId, string.Empty, ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    var codigoResultado = int.Parse(dt.Rows[0]["Resultado"].ToString());
                    var mensaje = dt.Rows[0]["Mensaje"].ToString();

                    if (ProcesoExitoso(codigoResultado))
                    {
                        ValidarCertificacion();
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                }
                else
                {
                    MessageBox.Show(resultado);
                }
                MostrarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EliminarCaja(string codigoCaja, string codigoCertificacion)
        {
            try
            {
                var servicioDeCertificado = new MobilityScm.Modelo.Vistas.Certificacion.Wms_Certification.WMS_Certification(true);
                var resultado = string.Empty;
                var manifiestoId = int.Parse(UiTextoManifiesto.Tag.ToString());
                var dt = servicioDeCertificado.DeleteCertificationDetail(int.Parse(codigoCertificacion), codigoCaja, ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    var codigoResultado = int.Parse(dt.Rows[0]["Resultado"].ToString());
                    var mensaje = dt.Rows[0]["Mensaje"].ToString();

                    if (ProcesoExitoso(codigoResultado))
                    {
                        ValidarCertificacion();
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                }
                else
                {
                    MessageBox.Show(resultado);
                }
                MostrarBotones();
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
                var manifiestoId = int.Parse(UiTextoManifiesto.Tag.ToString());
                var dt = servicioDeCertificado.ValidateIfCertificationIsComplete(CertificacionId, ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    var codigoResultado = int.Parse(dt.Rows[0]["Resultado"].ToString());
                    var mensaje = dt.Rows[0]["Mensaje"].ToString();
                    var codigo = decimal.Parse(dt.Rows[0]["DbData"].ToString());

                    if (ProcesoExitoso(codigoResultado))
                    {
                        UiEtiquetaEncabezado.Label = "Certificación(" + dt.Rows[0]["DbData"].ToString() + "%)";
                        if (LlegoAlCienPorciento(codigo))
                        {
                            CerrarCertificacion();
                        }
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                }
                else
                {
                    MessageBox.Show(resultado);
                }
                MostrarBotones();
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
                var manifiestoId = int.Parse(UiTextoManifiesto.Tag.ToString());
                var dt = servicioDeCertificado.MarkManifestAsCertified(manifiestoId, CertificacionId, VariablesDeAmbienteCertificacion.Usuario, ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    var codigoResultado = int.Parse(dt.Rows[0]["Resultado"].ToString());
                    var mensaje = dt.Rows[0]["Mensaje"].ToString();

                    if (ProcesoExitoso(codigoResultado))
                    {
                        Escanear = Escanear.Nada;
                        UiListaTipoCertificacion.Visible = false;
                        UiTextoEscanear.Visible = false;
                        UiEtiquetaDescripcion.Visible = false;
                        UiTextoCantidad.Visible = false;
                        UiBotonFinalizar.Visible = false;                        
                        UiTextoManifiesto.Label = string.Format("Manifiesto({0}) Completado", manifiestoId.ToString());                                
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                }
                else
                {
                    MessageBox.Show(resultado);
                }
                MostrarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarDetalle()
        {
            try
            {
                var servicioDeCertificado = new MobilityScm.Modelo.Vistas.Certificacion.Wms_Certification.WMS_Certification(true);
                var resultado = string.Empty;
                var dt = servicioDeCertificado.GetCertificationDetailConsolidated(CertificacionId, ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                UiListaDetalleCertificacion.Nodes.Clear();
                if (ProcesoExitoso(resultado))
                {
                    foreach (DataRow item in dt.Tables["GetCertificationDetailConsolidated"].Rows)
                    {
                        var nodo = new BoundNode(0, 0, item);
                        UiListaDetalleCertificacion.Nodes.Add(nodo);

                        DataRow[] series = null;
                        series = item.GetChildRows("Series_Number_By_Material");
                        if (series.Length == 0)
                        {
                            nodo.HidePlusMinus = true;
                        }
                        nodo.Collapse();

                        foreach (DataRow serieRow in series)
                        {
                            BoundNode serieNode = default(BoundNode);
                            serieNode = new BoundNode(1, 1, serieRow);
                            nodo.Nodes.Add(serieNode);
                            serieNode.HidePlusMinus = true;
                        }

                    }
                }
                MostrarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FinalizarCertificacionParcial()
        {
            try
            {
                if (MessageBox.Show("¿Desea finalizar la certificación parcial?", "Manifiesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    CerrarCertificacion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarParametros() { 
            try
            {
                UsuarioPuedeFinalizarParcial = false;
                var servicioDeConfiguracion = new MobilityScm.Modelo.Vistas.Certificacion.Wms_Settings.WMS_Settings(true);
                var resultado = string.Empty;
                
                var dt = servicioDeConfiguracion.GetParameter(Enums.GetStringValue(GrupoParametro.Certificacion), Enums.GetStringValue(IdParametro.Parcial), ref resultado, VariablesDeAmbienteCertificacion.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    if (ProcesoExitoso(dt.Rows.Count)) 
                    {
                        var valor = int.Parse(dt.Rows[0]["VALUE"].ToString());
                        UsuarioPuedeFinalizarParcial = EsParametroPredeterminado(valor);
                    }
                    
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
