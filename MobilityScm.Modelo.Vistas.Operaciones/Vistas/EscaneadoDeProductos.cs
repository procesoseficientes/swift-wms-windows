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
    public partial class EscaneadoDeProductos : UserControl, IControl
    {
        public EscaneadoDeProductos()
        {
            InitializeComponent();
            IsNew = true;
        }

        public static Int32 LicenciaDestino;
        public static string CodigoMasterPack;
        public static string Bodega;
        public EscanerEnImplosion EstadoEscaner = EscanerEnImplosion.EscanearLicencia;
        public static bool PuedeUbicar = false;

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
            BloquearCampos(!PuedeUbicar);
            
        }

        void BarcodeScanner_DataReady(object sender, MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg e)
        {
            string codigo = e.BarcodeData.Remove(e.BarcodeData.Length - 1, 1);
            switch (EstadoEscaner)
            {
                case EscanerEnImplosion.EscanearLicencia:
                    UiTextoLicencia.Text = codigo.Split('-')[0].ToString();
                    UiTextoMaterial.Text = string.Empty;
                    UiTextoCantidad.Value = 0;
                    UiTextoMaterial.SetFocus();
                    EstadoEscaner = EscanerEnImplosion.EscanearMaterial;
                    break;
                case EscanerEnImplosion.EscanearMaterial:
                    ValidarMaterialYLicencia(codigo);
                    break;
            }
        }

        private static EscaneadoDeProductos _EscaneadoDeProductos;
        public static EscaneadoDeProductos Create(string codigoMasterPack, int licencia, string bodega)
        {
            CodigoMasterPack = codigoMasterPack;
            LicenciaDestino = licencia;
            Bodega = bodega;
            PuedeUbicar = false;

            if (_EscaneadoDeProductos != null)
            {
                return _EscaneadoDeProductos;
            }

            _EscaneadoDeProductos = new EscaneadoDeProductos();
            return _EscaneadoDeProductos;
        }

        #endregion

        #region Metodos

        private void LimpiarCampos()
        {
            EstadoEscaner = EscanerEnImplosion.EscanearLicencia;
            UiTextoCantidad.Value = 0;
            UiTextoLicencia.Text = string.Empty;
            UiTextoMaterial.Text = string.Empty;
        }

        private void ValidarMaterialYLicencia(string materialEscaneado)
        {
            try
            {
                var servicio = new Wms_Materials.WMS_Materials(true);
                var resultado = servicio.ObtenerInventarioDeMaterialPorLicencia(VariablesDeAmbienteOperaciones.Ambiente, Convert.ToInt32(UiTextoLicencia.Text), LicenciaDestino, CodigoMasterPack, materialEscaneado, Bodega);
                if (Convert.ToInt32(resultado.Rows[0]["Resultado"].ToString()) == (int)MobilityScm.Modelo.Tipos.ResultadoOperacionTipo.Error)
                {
                    MessageBox.Show(resultado.Rows[0]["Mensaje"].ToString(), "Error");
                    return;
                }
                var data = resultado.Rows[0]["DbData"].ToString().Split('|');

                UiTextoMaterial.Text = data[1];
                UiTextoCantidad.Value = (Convert.ToDecimal(data[0]) > 0 ? data[0].ToString() : "0");
                UiTextoCantidad.Tag = data[0];
                UiTextoCantidad.SetFocus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
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

        private void UsuarioPresionoBoton(object sender, KeyEventArgs e)
        {
            switch (e.ObtenerActionDeBoton(VariablesDeAmbienteOperaciones.Ambiente, VariablesDeAmbienteOperaciones.DireccionDeServicio))
            {
                case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR:
                    if (ObtenerNombreDeObjetoSeleccionado(sender) == "UiTextoCantidad")
                    {
                        UsuarioDeseaAgregarMaterial();
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

        private void BloquearCampos(bool estado)
        {
            UiTextoLicencia.Enabled = estado;
            UiTextoMaterial.Enabled = estado;
            UiTextoCantidad.Enabled = estado;
            UiBotonUbicar.Enabled = !estado;
        }

        private void UsuarioDeseaAgregarMaterial()
        {
            try
            {
                if (ValidarCampos())
                {
                    var servicio = new Wms_Materials.WMS_Materials(true);
                    var resultado = servicio.AgregarParteDeImplosionATarea(VariablesDeAmbienteOperaciones.Ambiente, Convert.ToInt32(UiTextoLicencia.Text)
                        , UiTextoMaterial.Text, Convert.ToDecimal(UiTextoCantidad.Text), VariablesDeAmbienteOperaciones.Usuario, CodigoMasterPack, LicenciaDestino);

                    if (Convert.ToInt32(resultado.Rows[0]["Resultado"].ToString()) == (int)MobilityScm.Modelo.Tipos.ResultadoOperacionTipo.Error)
                    {
                        MessageBox.Show(resultado.Rows[0]["Mensaje"].ToString(), "Error");
                        return;
                    }

                    if (Convert.ToInt32(resultado.Rows[0]["Codigo"].ToString()) == (int)MobilityScm.Modelo.Tipos.ResultadoOperacionTipo.Exito)
                    {
                        BloquearCampos(false);
                        PuedeUbicar = true;
                    }
                    else 
                    {
                        UiTextoLicencia.SetFocus();
                    }
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private bool ValidarCampos()
        {
            try
            {
                if (UiTextoLicencia.Text.ToString().Trim() == string.Empty)
                {
                    MessageBox.Show("Debe de seleccionar una bodega.", "Validación");
                    return false;
                }

                if (UiTextoMaterial.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Debe de escanear material.", "Validación");
                    return false;
                }
                if (UiTextoCantidad.Value.ToString().Trim() == string.Empty || Convert.ToDecimal(UiTextoCantidad.Value) <= 0)
                {
                    MessageBox.Show("Debe de agregar cantidad.", "Validación");
                    return false;
                }

                if (Convert.ToDecimal(UiTextoCantidad.Tag) < Convert.ToDecimal(UiTextoCantidad.Text))
                {
                    MessageBox.Show("La cantidad no puede sobrepasar el disponible " + UiTextoCantidad.Tag, "Validación");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return false;
        }

        #endregion



        #region Eventos de controles
        private void UiVistaContenido_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiBotonImprimirLicencia_Click(object sender, EventArgs e)
        {
            try
            {
                string resultado = string.Empty;
                PrintModule.ImprimirLicencia(false, LicenciaDestino, Tipos.Enums.GetStringValue(Tipos.Regimen.General), VariablesDeAmbienteOperaciones.Empresa, VariablesDeAmbienteOperaciones.Usuario, ref resultado, VariablesDeAmbienteOperaciones.DireccionDeImpresora);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void UiBotonCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea cancelar la implosión?", "MobilitySCM", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    var servicio = new Wms_Materials.WMS_Materials(true);
                    var resultado = servicio.CancelarImplosionEnProgreso(VariablesDeAmbienteOperaciones.Ambiente, LicenciaDestino, CodigoMasterPack, VariablesDeAmbienteOperaciones.Usuario);

                    if (Convert.ToInt32(resultado.Rows[0]["Resultado"].ToString()) == (int)MobilityScm.Modelo.Tipos.ResultadoOperacionTipo.Error)
                    {
                        MessageBox.Show(resultado.Rows[0]["Mensaje"].ToString(), "Error");
                        return;
                    }
                    LimpiarCampos();
                    this.Back();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void UiBotonDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                DetalleImplosion.Create(LicenciaDestino, CodigoMasterPack).ShowPane();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void UiVistaContenido_ItemGotFocus(object sender, Resco.Controls.DetailView.ItemEventArgs e)
        {
            if (e.item.Name == "UiTextoLicencia")
            {
                EstadoEscaner = EscanerEnImplosion.EscanearLicencia;
            }
        }

        private void UiBotonUbicar_Click(object sender, EventArgs e)
        {
            UbicarImplosion.Create(CodigoMasterPack, Bodega,LicenciaDestino).ShowPane();
        }
        #endregion

        
    }
}
