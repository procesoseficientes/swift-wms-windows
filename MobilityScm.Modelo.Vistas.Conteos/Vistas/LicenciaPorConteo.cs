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

namespace MobilityScm.Modelo.Vistas
{
    public partial class LicenciaPorConteo : UserControl, IControl
    {
        private static int TareaId { get; set; }
        private static string Ubicacion { get; set; }
        private int Licencia { get; set; }
        private string CodigoMaterial { get; set; }
        private bool ManejaLote { get; set; }
        private bool ManejaSerie { get; set; }
        private bool ConteoPorSku { get; set; }

        public static MobilityScm.Modelo.Tipos.Escanear Escanear { get; set; }


        public LicenciaPorConteo()
        {
            InitializeComponent();
            IsNew = true;
        }

        #region IControl Members

        public bool IsNew { get; set; }

        public void UnLoad()
        {
            //remove handlers
            VariablesDeAmbiente.BarcodeScanner.DataReady -= BarcodeScanner_DataReady;
            VariablesDeAmbiente.BarcodeScanner.Disabled();
        }

        public void Load()
        {
            VariablesDeAmbiente.BarcodeScanner.DataReady += new EventHandler<MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg>(BarcodeScanner_DataReady);
            VariablesDeAmbiente.BarcodeScanner.Enabled();
            _LicenciaPorConteo.LlenarControles();
        }

        #endregion

        private static LicenciaPorConteo _LicenciaPorConteo;
        public static LicenciaPorConteo Create(int taskId, string location)
        {

            TareaId = taskId;
            Ubicacion = location;
            if (_LicenciaPorConteo != null)
            {
                return _LicenciaPorConteo;
            }

            _LicenciaPorConteo = new LicenciaPorConteo();
            return _LicenciaPorConteo;
        }

        static void BarcodeScanner_DataReady(object sender, MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg e)
        {
            try
            {
                var servicio = new MobilityScm.Modelo.WMS_PhisicalCouting.WMS_Phisical_Couting(true);

                switch (Escanear)
                {
                    case MobilityScm.Modelo.Tipos.Escanear.Licencia:
                        _LicenciaPorConteo.LeerLicencia(int.Parse(e.BarcodeData.Split('-')[0]));
                        break;
                    case MobilityScm.Modelo.Tipos.Escanear.Material:
                        _LicenciaPorConteo.LeerMaterial(e.BarcodeData.Remove(e.BarcodeData.Length - 1, 1));
                        break;
                    case MobilityScm.Modelo.Tipos.Escanear.Lote:
                        _LicenciaPorConteo.EstablecerLote(e.BarcodeData.Remove(e.BarcodeData.Length - 1, 1));
                        break;
                    case MobilityScm.Modelo.Tipos.Escanear.Serie:
                        _LicenciaPorConteo.EstablecerSerie(e.BarcodeData.Remove(e.BarcodeData.Length - 1, 1));
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        #region Metodo

        private void EstablecerLote(string lote)
        {
            UiTextoLote.Text = lote;
            if (ManejaLote && !ManejaSerie)
            {
                ValidarSiEsReconteoDeMaterial();
            }

        }

        private void EstablecerSerie(string serie)
        {
            UiTextoSerie.Text = serie;
            if (ValidarSiEsReconteoDeMaterial())
            {
                GrabarConteo();
            }
        }

        private void LlenarControles()
        {
            try
            {
                Escanear = MobilityScm.Modelo.Tipos.Escanear.Licencia;
                UiEtiquetaUbicacion.Label = Ubicacion;
                UiEtiquetaLicencia.Label = "Licencia";
                UiEtiquetaMaterial.Label = "Material";
                UiFechaDeExpiracion.Visible = false;
                UiTextoLote.Visible = false;
                UiTextoCantidad.Visible = false;
                UiTextoSerie.Visible = false;
                UiBotonMostraSku.Visible = false;
                UiPanelProductos.Visible = false;
                UiTextoLote.Text = "";
                UiFechaDeExpiracion.Value = DateTime.Today;
                LlenarMaterialesDeSugerencia(TareaId, Ubicacion);
                UiBotonLimpiarLicencia.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void LlenarMaterialesDeSugerencia(int taskId, string location)
        {
            try
            {
                ConteoPorSku = false;
                var servicio = new MobilityScm.Modelo.WMS_PhisicalCouting.WMS_Phisical_Couting(true);
                var resultado = string.Empty;
                var dt = servicio.GetNextMaterialForCount(VariablesDeAmbiente.UserId, taskId, location, ref resultado, VariablesDeAmbiente.Enviroment);
                if (!string.IsNullOrEmpty(resultado))
                {
                    MessageBox.Show(resultado, "Error");
                }
                else
                {
                    UiListaMateriales.DataSource = null;
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows.Count == 1)
                        {

                            UiEtiquetaMaterial.Label = "Material: " + dt.Rows[0]["MATERIAL_ID"] + "|" + dt.Rows[0]["MATERIAL_NAME"];
                            UiListaMateriales.DataSource = dt;
                        }
                        else
                        {
                            UiListaMateriales.DataSource = dt;
                            UiBotonMostraSku.Visible = true;
                        }
                        ConteoPorSku = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void LeerLicencia(int licencia)
        {
            try
            {
                var servicio = new MobilityScm.Modelo.WMS_PhisicalCouting.WMS_Phisical_Couting(true);
                var resultado = string.Empty;
                if (!servicio.ValidateScannedLicence(licencia, ref resultado, VariablesDeAmbiente.Enviroment))
                {
                    MessageBox.Show(resultado, "Error");
                }
                else
                {
                    UiBotonLimpiarLicencia.Visible = true;
                    Licencia = licencia;
                    UiEtiquetaLicencia.Label = "Licencia: " + licencia.ToString();
                    Escanear = MobilityScm.Modelo.Tipos.Escanear.Material;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void LeerMaterial(string codigoBarraMaterial)
        {
            try
            {
                if (ConteoPorSku)
                {
                    BuscarMaterialEnSugeridos(codigoBarraMaterial);
                    return;
                }
                else
                {
                    var servicio = new MobilityScm.Modelo.WMS_PhisicalCouting.WMS_Phisical_Couting(true);
                    var resultado = string.Empty;
                    var dt = servicio.GetScannedMaterial(Licencia, codigoBarraMaterial, ref resultado, VariablesDeAmbiente.Enviroment);
                    if (!resultado.Equals("OK"))
                    {
                        MessageBox.Show(resultado, "Error");
                    }
                    else
                    {
                        if (dt.Rows.Count > 0)
                        {
                            EstablercerMaterial(dt.Rows[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void BuscarMaterialEnSugeridos(string codigoBarraMaterial)
        {
            try
            {
                if (UiListaMateriales.DataSource == null)
                {
                    return;
                }
                foreach (DataRow fila in ((DataTable)UiListaMateriales.DataSource).Rows)
                {
                    if (fila["BARCODE_ID"].ToString().Equals(codigoBarraMaterial) || fila["MATERIAL_ID"].ToString().Equals(codigoBarraMaterial))
                    {
                        EstablercerMaterial(fila);
                        return;
                    }
                }
                MessageBox.Show("Material no esta en el conteo.", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void EstablercerMaterial(DataRow fila)
        {
            try
            {
                CodigoMaterial = fila["MATERIAL_ID"].ToString();
                UiEtiquetaMaterial.Label = "Material: " + CodigoMaterial + "|" + fila["MATERIAL_NAME"].ToString();
                if (int.Parse(fila["BATCH_REQUESTED"].ToString()) == 1)
                {
                    UiFechaDeExpiracion.Visible = true;
                    UiTextoLote.Visible = true;
                    ManejaLote = true;
                }
                else
                {
                    UiFechaDeExpiracion.Visible = false;
                    UiTextoLote.Visible = false;
                    ManejaLote = false;
                }

                if (int.Parse(fila["SERIAL_NUMBER_REQUESTS"].ToString()) == 1)
                {
                    UiTextoCantidad.Visible = false;
                    UiTextoCantidad.Text = "";
                    UiTextoSerie.Visible = true;
                    UiTextoSerie.Text = "";
                    ManejaSerie = true;
                }
                else
                {
                    UiTextoCantidad.Visible = true;
                    UiTextoCantidad.Text = "1";
                    UiTextoSerie.Visible = false;
                    UiTextoSerie.Text = "";
                    ManejaSerie = false;
                }

                if (!ManejaLote && !ManejaSerie)
                {
                    ValidarSiEsReconteoDeMaterial();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private bool ValidarSiEsReconteoDeMaterial()
        {
            try
            {
                var servicio = new MobilityScm.Modelo.WMS_PhisicalCouting.WMS_Phisical_Couting(true);
                var resultado = string.Empty;
                var serie = (ManejaSerie) ? UiTextoSerie.Text : string.Empty;
                var lote = (ManejaLote) ? UiTextoLote.Text : string.Empty;
                var dt = servicio.ValidateScannedMaterialForCountingTask(VariablesDeAmbiente.UserId, TareaId, Ubicacion, Licencia, CodigoMaterial, lote, serie, ref resultado, VariablesDeAmbiente.Enviroment);
                if (!string.IsNullOrEmpty(resultado))
                {
                    MessageBox.Show(resultado, "Error");
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (decimal.Parse(dt.Rows[0]["DbData"].ToString()) > 0)

                            if (ManejaSerie)
                            {
                                MessageBox.Show("La Serie ya fue ingresada.", "Error");
                                return false;
                            }
                            else
                            {
                                UiTextoCantidad.Text = dt.Rows[0]["DbData"].ToString();
                            }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
        }

        private void GrabarConteo()
        {
            try
            {
                WMS_InfoTrans.WMS_InfoTrans client = new MobilityScm.Modelo.WMS_InfoTrans.WMS_InfoTrans(true);
                string pResult = string.Empty;
                DataTable dtResult;
                dtResult = client.ValidateTaskStatus(VariablesDeAmbiente.UserId, 0, Convert.ToInt32(TareaId), 0
                                                        , "", "TAREA_CONTEO", VariablesDeAmbiente.Enviroment, ref  pResult);

                if (pResult == "OK" && !dtResult.Rows[0][1].ToString().Contains("cancelada"))
                {
                    var servicio = new MobilityScm.Modelo.WMS_PhisicalCouting.WMS_Phisical_Couting(true);
                    var resultado = string.Empty;
                    var serie = (ManejaSerie) ? UiTextoSerie.Text : string.Empty;
                    var cantidad = (ManejaSerie) ? 1 : decimal.Parse(UiTextoCantidad.Text);
                    DateTime? fechaExpiracion = (ManejaLote) ? UiFechaDeExpiracion.DateTime.Date : (DateTime?)null;
                    var lote = (ManejaLote) ? UiTextoLote.Text : string.Empty;

                    if (!servicio.InsertCountExecution(VariablesDeAmbiente.UserId, TareaId, Ubicacion, Licencia, CodigoMaterial, cantidad, fechaExpiracion, lote, serie, ref resultado, VariablesDeAmbiente.Enviroment))
                    {
                        if (!string.IsNullOrEmpty(resultado))
                        {
                            MessageBox.Show(resultado, "Error");
                        }
                    }
                    else
                    {
                        if (ManejaSerie)
                        {
                            UiTextoSerie.Label = (ManejaSerie) ? "Serie: " + serie : "Serie";
                            UiTextoSerie.Text = "";
                        }
                        else
                        {
                            LimpiarControlesParaNuevoSku();
                            if (ConteoPorSku)
                            {
                                SugerirElPrimerMaterial();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(pResult == "OK" ? dtResult.Rows[0][1].ToString() : pResult, "Error");
                }          

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void FinalizarUbicacion()
        {
            try
            {
                var servicio = new MobilityScm.Modelo.WMS_PhisicalCouting.WMS_Phisical_Couting(true);
                var resultado = string.Empty;
                var dt = servicio.FinishLocation(VariablesDeAmbiente.UserId, TareaId, Ubicacion, ref resultado, VariablesDeAmbiente.Enviroment);
                if (!string.IsNullOrEmpty(resultado))
                {
                    MessageBox.Show(resultado, "Error");
                }
                else
                {
                    if (dt.Rows[0][0].ToString().Equals("OK") || dt.Rows[0][0].ToString().Equals("COMPLETED"))
                    {
                        this.Back();
                    }
                    else
                    {
                        MessageBox.Show(dt.Rows[0][0].ToString(), "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void LimpiarControlesParaNuevoSku()
        {
            try
            {
                Escanear = MobilityScm.Modelo.Tipos.Escanear.Material;
                UiEtiquetaMaterial.Label = "Material";
                UiFechaDeExpiracion.Visible = false;
                UiTextoLote.Text = "";
                UiTextoLote.Visible = false;
                UiTextoCantidad.Text = "";
                UiTextoCantidad.Visible = false;
                UiTextoSerie.Text = "";
                UiTextoSerie.Visible = false;
                CodigoMaterial = string.Empty;
                ManejaLote = false;
                ManejaSerie = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void LimpiarControlesParaNuevaLicencia()
        {
            try
            {
                UiBotonLimpiarLicencia.Visible = false;
                UiEtiquetaLicencia.Label = "Licencia";
                Licencia = 0;
                LimpiarControlesParaNuevoSku();
                Escanear = MobilityScm.Modelo.Tipos.Escanear.Licencia;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void SugerirElPrimerMaterial()
        {
            try
            {
                if (((DataTable)UiListaMateriales.DataSource).Rows.Count == 1)
                {
                    var fila = ((DataTable)UiListaMateriales.DataSource).Rows[0];
                    UiEtiquetaMaterial.Label = "Material: " + fila["MATERIAL_ID"] + "|" + fila["MATERIAL_NAME"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        #endregion

        #region Eventos de Controles

        private void UiVistaLicenciaPorConteo_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.ObtenerActionDeBoton(VariablesDeAmbiente.Enviroment, VariablesDeAmbiente.WsHost))
            {
                case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR:
                    if (Escanear == MobilityScm.Modelo.Tipos.Escanear.Lote || Escanear == MobilityScm.Modelo.Tipos.Escanear.Serie)
                    {
                        ValidarSiEsReconteoDeMaterial();
                    }
                    else
                    {
                        UsuarioDeseaGrabarConteo();
                    }
                    break;
                case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR:
                    this.Back();
                    break;
                case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR:
                    break;
                case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR:
                    UsuarioDeseaGrabarConteo();
                    break;
            }
        }

        private void UsuarioDeseaGrabarConteo()
        {
            if (ManejaSerie)
            {
                if (ValidarSiEsReconteoDeMaterial())
                {
                    GrabarConteo();
                }
            }
            else
            {
                GrabarConteo();
            }
            UiBotonFinalizarUbicacion.Focus();
        }

        private void UiBotonMostraSku_Click(object sender, EventArgs e)
        {
            UiPanelProductos.Visible = !UiPanelProductos.Visible;
        }

        private void UiTextoLote_GotFocus(object sender, Resco.Controls.DetailView.ItemEventArgs e)
        {
            var uiTexto = (Resco.Controls.DetailView.ItemTextBox)sender;
            Escanear = MobilityScm.Modelo.Tipos.Escanear.Material;
            switch (uiTexto.Name)
            {
                case "UiTextoLote":
                    Escanear = MobilityScm.Modelo.Tipos.Escanear.Lote;
                    break;
                case "UiTextoSerie":
                    Escanear = MobilityScm.Modelo.Tipos.Escanear.Serie;
                    break;
            }
        }

        private void UiTextoLote_LostFocus(object sender, Resco.Controls.DetailView.ItemEventArgs e)
        {
            Escanear = MobilityScm.Modelo.Tipos.Escanear.Material;
        }

        private void UiBotonFinalizarUbicacion_Click(object sender, EventArgs e)
        {
            FinalizarUbicacion();
        }

        #endregion

        private void UiBotonLimpiarLicencia_Click(object sender, EventArgs e)
        {
            LimpiarControlesParaNuevaLicencia();
        }


    }
}
