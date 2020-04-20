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

namespace MobilityScm.Modelo.Vistas.Operaciones.Vistas
{
    public partial class EscaneadoDeUnificacion : UserControl, IControl
    {
        public EscaneadoDeUnificacion()
        {
            InitializeComponent();
            IsNew = true;
        }

        public static Int32 LicenciaDestino;
        public static string Ubicacion;
        public static string CodigoMaterial = "";
        public EscanerEnUnificacion EstadoEscaner = EscanerEnUnificacion.EscanearUbicacion;

        #region IControl Members
        
        public bool IsNew { get; set; }
        public void UnLoad()
        {            
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.DataReady -= BarcodeScanner_DataReady;            
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.Disabled();
        }

        public void Load()
        {
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.DataReady += new EventHandler<MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg>(BarcodeScanner_DataReady);
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.Enabled();
            BloquearCampos(true);
            if (Ubicacion == null)
            {
                LimpiarCampos();
            }
        }
      
        void BarcodeScanner_DataReady(object sender, MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg e)
        {
            string codigo = e.BarcodeData.Remove(e.BarcodeData.Length - 1, 1);
            switch (EstadoEscaner)
            {
                case EscanerEnUnificacion.EscanearUbicacion:
                    ValidarUbicacion(codigo);
                    break;
                case EscanerEnUnificacion.EscanearMaterial:
                    UiTextoMaterial.Text = codigo;
                    UiTextoMaterial.SetFocus();
                    ObtenerDatosDelMaterial(codigo);
                    break;
            }
        }

        private static EscaneadoDeUnificacion _EscaneadoDeUnificacion;
        public static EscaneadoDeUnificacion Create(string ubicacion, string material)
        {
            Ubicacion = ubicacion;
            CodigoMaterial = material;
            if (_EscaneadoDeUnificacion != null)
            {
                return _EscaneadoDeUnificacion;
            }

            _EscaneadoDeUnificacion = new EscaneadoDeUnificacion();
            return _EscaneadoDeUnificacion;
        }
        #endregion

        #region Metodos
        private void LimpiarCampos()
        {
            EstadoEscaner = EscanerEnUnificacion.EscanearUbicacion;
            UiTextoUbicacion.Text = string.Empty;
            UiTextoMaterial.Text = string.Empty;
            UiTextoDescripcion.Text = string.Empty;
        }

        private void BloquearCampos(bool estado)
        {
            UiTextoUbicacion.Enabled = estado;
            UiTextoMaterial.Enabled = estado;
            UiTextoDescripcion.Enabled = estado;
        }

        private void ObtenerDatosDelMaterial(string codigo)
        {
            try
            {
                string res = string.Empty;
                var servicio = new Wms_Materials.WMS_Materials(true);
                var resultado = servicio.SearchByBarCodeMultipleClients(codigo, ref res, VariablesDeAmbienteOperaciones.Ambiente);

                if (resultado != null)
                {
                    UiTextoDescripcion.Text = resultado.Tables[0].Rows[0]["MATERIAL_NAME"].ToString();
                    CodigoMaterial = resultado.Tables[0].Rows[0]["MATERIAL_ID"].ToString();
                    return;
                }
                else
                {
                    MessageBox.Show(res, "Error");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                LimpiarCampos();
            }
        }

        private bool ValidarUbicacion(string ubicacionIngresada)
        {
            try
            {
                if (ubicacionIngresada != string.Empty)
                {
                    UiTextoUbicacion.Text = string.Empty;

                    var servicio = new MobilityScm.Modelo.Vistas.Operaciones.WMS_Locations.WMS_Locations(true);

                    var resultado = servicio.ValidarUbicacionExisteEnBodega(VariablesDeAmbienteOperaciones.Ambiente, "", ubicacionIngresada);
                    if (resultado)
                    {
                        UiTextoUbicacion.Text = ubicacionIngresada;
                        UiTextoMaterial.SetFocus();
                        Ubicacion = ubicacionIngresada;
                        EstadoEscaner = EscanerEnUnificacion.EscanearMaterial;
                        return true;
                    }
                    else
                    {
                        UiTextoUbicacion.SetFocus();
                        MessageBox.Show("La ubicación no existe.", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return false;
        }

        private void UsuarioPresionoBoton(object sender, KeyEventArgs e)
        {
            switch (e.ObtenerActionDeBoton(VariablesDeAmbienteOperaciones.Ambiente, VariablesDeAmbienteOperaciones.DireccionDeServicio))
            {
                case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR:
                    this.Back();
                    break;
                default:
                    break;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(Ubicacion))
            {
                MessageBox.Show("Debe de escanear una ubicación para unificarla.", "Error");
                return false;
            }
            return true;
        }

        private DataSet UnificarLicencias()
        {
            try
            {
                string respuesta = "";
                var servicio = new MobilityScm.Modelo.Vistas.Operaciones.WMS_Trans.WMS_Trans(true);
                var resultado = servicio.UnificarLicenciasPorUbicacionYMaterial(Ubicacion, CodigoMaterial, VariablesDeAmbienteOperaciones.Usuario, ref respuesta, VariablesDeAmbienteOperaciones.Ambiente);

                if (respuesta == Tipos.Ok.OK.ToString())
                {
                    return resultado;
                }
                else
                {
                    MessageBox.Show(respuesta, "Error");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return null;
            }
        }
        #endregion

        #region Eventos Controles
        private void UiBotonDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                DetalleDeUnificacion.Create(UiTextoUbicacion.Text, CodigoMaterial).ShowPane();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void UiVistaContenidos_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiVistaContenidos_ItemGotFocus(object sender, Resco.Controls.DetailView.ItemEventArgs e)
        {
            if (e.item.Name == "UiTextoUbicacion")
            {
                EstadoEscaner = EscanerEnUnificacion.EscanearUbicacion;
            }
        }

        private void UiPanelBotones_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiBotonDetalle_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiBotonUnificarLicencias_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (MessageBox.Show("¿Desea unificar esta ubicación?", "Unificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    var licencias = UnificarLicencias();
                    if (licencias != null)
                    {
                        LicenciasUnificacion.Create(licencias).ShowPane();
                    }
                }
            }
        }

        private void EscaneadoDeUnificacion_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }
        #endregion  

    }
}
