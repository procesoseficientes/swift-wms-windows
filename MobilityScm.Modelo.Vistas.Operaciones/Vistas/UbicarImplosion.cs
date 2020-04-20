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

namespace MobilityScm.Modelo.Vistas.Operaciones.Vistas
{
    public partial class UbicarImplosion : UserControl, IControl
    {
        public UbicarImplosion()
        {
            InitializeComponent();
            IsNew = true;
            this.TabStop = true;
        }

        #region IControl Members

        public bool IsNew { get; set; }

        public void UnLoad()
        {
            //remove handlers
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.DataReady -= BarcodeScanner_DataReady;
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.Disabled();
        }

        public void Load()
        {
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.DataReady += new EventHandler<MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg>(BarcodeScanner_DataReady);
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.Enabled();
            
            LimpiarCampos();
        }

        void BarcodeScanner_DataReady(object sender, MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg e)
        {
            if (e != null && e.BarcodeData != string.Empty)
            {
                ValidarUbicacion(e.BarcodeData.Remove(e.BarcodeData.Length - 1, 1));
            }
        }

        private static UbicarImplosion _UbicarImplosion;
        private static string codigoMaterial;
        private static string bodega;
        private static int licencia;

        
        public static UbicarImplosion Create(string _codigoMaterial, string _bodega, int _licencia)
        {
            codigoMaterial = _codigoMaterial;
            bodega = _bodega;
            licencia = _licencia;
            
            if (_UbicarImplosion != null)
            {
                return _UbicarImplosion;
            }
            _UbicarImplosion = new UbicarImplosion();

            return _UbicarImplosion;
        }
        #endregion

        #region Metodos
        private void LimpiarCampos()
        {
            UiTextoUbicacion.Text = string.Empty;
            UiBotonUbicar.Visible = false;
            UiListaUbicacion.Focus();
        }

        private bool ValidarUbicacion(string ubicacionIngresada)
        {
            try
            {
                if (ubicacionIngresada != string.Empty)
                {
                    UiTextoUbicacion.Text = string.Empty;
                    
                    var servicio = new MobilityScm.Modelo.Vistas.Operaciones.WMS_Locations.WMS_Locations(true);

                    var resultado = servicio.ValidarUbicacionExisteEnBodega(VariablesDeAmbienteOperaciones.Ambiente, bodega, ubicacionIngresada);
                    if (resultado)
                    {
                        UiTextoUbicacion.Text = ubicacionIngresada;
                        UiTextoUbicacion.SetFocus();
                        UiBotonUbicar.Visible = true;
                        return true;
                    }
                    else
                    {
                        UiTextoUbicacion.SetFocus();
                        UiBotonUbicar.Visible = false;
                        MessageBox.Show("La ubicación no esta asociada a la bodega o no existe.", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return false;
        }

        private void UsuarioDeseaUbicar()
        {
            try
            {
                UiBotonUbicar.Focus();

                if (ValidarUbicacion(UiTextoUbicacion.Text))
                {
                    var servicio = new MobilityScm.Modelo.Vistas.Operaciones.Wms_Materials.WMS_Materials(true);
                    var resultado = new DataSet();
                    var ubicacion = UiTextoUbicacion.Text.Trim();
                    resultado = servicio.FinalizarImplosionDeMasterpack(VariablesDeAmbienteOperaciones.Ambiente, ref ubicacion, licencia, codigoMaterial, 0, VariablesDeAmbienteOperaciones.Usuario);
                    if (Convert.ToInt32(resultado.Tables[0].Rows[0]["Resultado"].ToString()) == (int)MobilityScm.Modelo.Tipos.ResultadoOperacionTipo.Error)
                    {
                        MessageBox.Show(resultado.Tables[0].Rows[0]["Mensaje"].ToString(), "Error");
                        return;
                    }

                    this.Back(2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #endregion

        #region Eventos de controles
        private void UiBotonUbicar_Click(object sender, EventArgs e)
        {
            UsuarioDeseaUbicar();
        }

        private void UiPanelBoton_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiBotonUbicar_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiVistaEncabezado_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UsuarioPresionoBoton(object sender, KeyEventArgs e)
        {
            if (e.ObtenerActionDeBoton(VariablesDeAmbienteOperaciones.Ambiente, VariablesDeAmbienteOperaciones.DireccionDeServicio) == MobilityScm.Modelo.Tipos.FuncionBoton.SALIR)
            {
                this.Back();
            }
        }

        private void UbicarImplosion_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiListaUbicacion_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }
        #endregion  

       

     

        

    }
}
