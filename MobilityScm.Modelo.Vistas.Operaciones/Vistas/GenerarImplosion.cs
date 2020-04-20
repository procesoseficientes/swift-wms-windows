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
    public partial class GenerarImplosion : UserControl, IControl
    {
        public GenerarImplosion()
        {
            InitializeComponent();
            CargarBodegasUsuario();
            IsNew = true;
        }

        #region IControl Members

        public bool IsNew { get; set; }

        public void UnLoad()
        {
            try
            {
                //Eliminar evento de escaner
                VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.DataReady -= EscanerDeCodigoDeBarras_DataReady;
                VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.Disabled();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void Load()
        {
            try
            {
                //Agregar evento de escaner
                VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.DataReady += new EventHandler<MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg>(EscanerDeCodigoDeBarras_DataReady);
                VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.Enabled();

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void LimpiarCampos()
        {
            UiTextoMaterial.Text = string.Empty;
            UiTextoCantidad.Text = string.Empty;
            CodigoCliente = string.Empty;
            UiListaComponentes.DataSource = null;
            UiBotonImplosion.Enabled = false;
        }

        private void CargarBodegasUsuario()
        {
            try
            {
                var servicio = new MobilityScm.Modelo.Vistas.Operaciones.WMS_Locations.WMS_Locations(true);
                var resultado = string.Empty;
                var ds = servicio.GetAssociatedWarehouseWithUser(VariablesDeAmbienteOperaciones.Usuario, VariablesDeAmbienteOperaciones.Ambiente, ref resultado);
                if (resultado != "OK")
                {
                    MessageBox.Show(resultado, "Error");
                }
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    UiComboBodegas.DataSource = ds.Tables[0];
                    UiComboBodegas.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private bool ValidarMaterial(string codigoIngresado, bool focoCantidad)
        {
            try
            {
                if (codigoIngresado != string.Empty)
                {
                    UiTextoMaterial.Text = string.Empty;

                    UiBotonImplosion.Enabled = false;
                    var servicio = new MobilityScm.Modelo.Vistas.Operaciones.Wms_Materials.WMS_Materials(true);
                    var resultado = servicio.ValidarSiMaterialEsMasterPack(VariablesDeAmbienteOperaciones.Ambiente, codigoIngresado);
                    if (resultado != null && Convert.ToInt32(resultado.Rows[0]["Resultado"].ToString()) == (int)MobilityScm.Modelo.Tipos.ResultadoOperacionTipo.Exito)
                    {
                        UiTextoMaterial.Text = resultado.Rows[0]["DbData"].ToString();
                        if (focoCantidad)
                        {
                            UiTextoCantidad.SetFocus();
                        }
                        return true;
                    }
                    else
                    {
                        UiTextoMaterial.SetFocus();
                        MessageBox.Show(resultado.Rows[0]["Mensaje"].ToString(), "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return false;
        }

        void EscanerDeCodigoDeBarras_DataReady(object sender, MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg e)
        {
            if (e != null && e.BarcodeData != string.Empty)
            {
                ValidarMaterial(e.BarcodeData.Remove(e.BarcodeData.Length - 1, 1), true);
            }
        }

        private static GenerarImplosion _GenerarImplosion;
        public static GenerarImplosion Create()
        {
            if (_GenerarImplosion != null)
            {
                return _GenerarImplosion;
            }

            _GenerarImplosion = new GenerarImplosion();
            return _GenerarImplosion;
        }


        #endregion

        #region Metodos

        private string CodigoCliente;

        private bool ValidarCampos()
        {
            try
            {
                if (UiTextoMaterial.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Debe de escanear material.", "Validación");
                    return false;
                }

                if (UiTextoCantidad.Text.Trim() == string.Empty || int.Parse(UiTextoCantidad.Text) <= 0)
                {
                    MessageBox.Show("Debe de agregar cantidad.", "Validación");
                    return false;
                }

                if (UiComboBodegas.Value.ToString().Trim() == string.Empty)
                {
                    MessageBox.Show("Debe de seleccionar una bodega.", "Validación");
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
            var nombreDeObjeto = ObtenerNombreDeObjetoSeleccionado(sender);
            if (nombreDeObjeto == "UiTextoCantidad")
            {
                UiBotonImplosion.Enabled = false;
            }

            switch (e.ObtenerActionDeBoton(VariablesDeAmbienteOperaciones.Ambiente, VariablesDeAmbienteOperaciones.DireccionDeServicio))
            {
                case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR:
                    if (nombreDeObjeto == "UiTextoMaterial")
                    {
                        ValidarMaterial(UiTextoMaterial.Text, true);
                    }
                    if (nombreDeObjeto == "UiTextoCantidad")
                    {
                        UsuarioDeseaBuscar();
                    }

                    break;
                case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR:
                    this.Back();
                    break;
                case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR:
                    break;
                case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR:
                    UsuarioDeseaBuscar();
                    break;
            }
        }

        private void UsuarioDeseaBuscar()
        {
            try
            {
                UiBotonBuscar.Focus();
                UiBotonImplosion.Enabled = false;
                if (ValidarCampos() && ValidarMaterial(UiTextoMaterial.Text, false))
                {
                    var servicio = new MobilityScm.Modelo.Vistas.Operaciones.Wms_Materials.WMS_Materials(true);
                    var resultado = new DataSet();
                    resultado = servicio.ValidarInventarioDeImplosionDeMasterpack(VariablesDeAmbienteOperaciones.Ambiente, UiTextoMaterial.Text.Trim(), UiComboBodegas.Value.ToString().Trim(), int.Parse(UiTextoCantidad.Text));
                    if (Convert.ToInt32(resultado.Tables[0].Rows[0]["Resultado"].ToString()) == (int)MobilityScm.Modelo.Tipos.ResultadoOperacionTipo.Error)
                    {
                        MessageBox.Show(resultado.Tables[0].Rows[0]["Mensaje"].ToString(), "Error");
                    }
                    else if (resultado.Tables[1] != null && resultado.Tables[1].Rows.Count > 0)
                    {
                        UiBotonImplosion.Enabled = true;
                    }

                    if (resultado.Tables[1] != null && resultado.Tables[1].Rows.Count > 0)
                    {
                        UiListaComponentes.DataSource = resultado.Tables[1];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void UsuarioDeseaGenerarImplosion()
        {
            try
            {
                var servicio = new Wms_Materials.WMS_Materials(true);
                var resultado = servicio.AgregarControlDeMasterPackEnImplosion(VariablesDeAmbienteOperaciones.Ambiente, UiTextoMaterial.Text, Convert.ToInt32(UiTextoCantidad.Text), VariablesDeAmbienteOperaciones.Usuario);

                if (Convert.ToInt32(resultado.Rows[0]["Resultado"].ToString()) == (int)MobilityScm.Modelo.Tipos.ResultadoOperacionTipo.Error)
                {
                    MessageBox.Show(resultado.Rows[0]["Mensaje"].ToString(), "Error");
                    return;
                }
                EscaneadoDeProductos.Create(UiTextoMaterial.Text, Convert.ToInt32(resultado.Rows[0]["DbData"].ToString()), UiComboBodegas.Value.ToString()).ShowPane();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #endregion

        #region Eventos de controles
        private void UiBotonBuscar_Click(object sender, EventArgs e)
        {
            UsuarioDeseaBuscar();
        }

        private void UiBotonImplosion_Click(object sender, EventArgs e)
        {
            UsuarioDeseaGenerarImplosion();
        }

        private void UiVistaImplosion_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiListaComponentes_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiPanelBotones_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void GenerarImplosion_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiBotonBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiBotonImplosion_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiVistaImplosion_ItemChanged(object sender, Resco.Controls.DetailView.ItemEventArgs e)
        {
            if (e.item.Name != "UiTextoMaterial")
            {
                UiBotonImplosion.Enabled = false;
            }
        }
        #endregion




    }
}
