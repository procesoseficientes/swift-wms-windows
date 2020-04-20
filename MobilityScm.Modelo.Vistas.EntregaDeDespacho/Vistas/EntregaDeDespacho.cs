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
using MobilityScm.Modelo.Vistas;

namespace MobilityScm.Modelo.Vistas.EntregaDeDespacho.Vistas
{
    public partial class EntregaDeDespacho : UserControl, IControl
    {
        public static MobilityScm.Modelo.Tipos.Escanear Escanear { get; set; }

        private bool UsuarioPuedeFinalizarParcial { get; set; }

        public bool RegresaDeConsultaDeEtiquetaPicking { get; set; }

        private int EntregaId { get; set; }

        public EntregaDeDespacho()
        {
            InitializeComponent();
            IsNew = true;
            RegresaDeConsultaDeEtiquetaPicking = false;
        }

        #region IControl Members

        public void UnLoad()
        {
            VariablesDeAmbienteEntregaDeDespacho.EscanerDeCodigoDeBarras.DataReady -= BarcodeScanner_DataReady;
            VariablesDeAmbienteEntregaDeDespacho.EscanerDeCodigoDeBarras.Disabled();
        }

        public void Load()
        {
            VariablesDeAmbienteEntregaDeDespacho.EscanerDeCodigoDeBarras.DataReady += new EventHandler<MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg>(BarcodeScanner_DataReady);
            VariablesDeAmbienteEntregaDeDespacho.EscanerDeCodigoDeBarras.Enabled();
            if (!RegresaDeConsultaDeEtiquetaPicking)
            {
                CargarParametros();
                LimpiarControles();
            }
        }

        private static EntregaDeDespacho _EntregaDeDespacho;
        public static EntregaDeDespacho Create()
        {
            if (_EntregaDeDespacho != null)
            {
                return _EntregaDeDespacho;
            }

            _EntregaDeDespacho = new EntregaDeDespacho();
            return _EntregaDeDespacho;
        }

        public bool IsNew { get; set; }

        #endregion

        #region Eventos de Controles

        void BarcodeScanner_DataReady(object sender, MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg e)
        {
            try
            {
                UiListaDetalle.Visible = false;
                string codigo = e.BarcodeData.Remove(e.BarcodeData.Length - 1, 1);
                switch (Escanear)
                {
                    case Escanear.OlaDePicking:
                        UiTextoEntrega.Text = codigo.ToString();
                        CargarOlaDePicking(int.Parse(codigo));
                        break;
                    case Escanear.Etiqueta:
                        UsuarioEscaneoEtiqueta(int.Parse(codigo));
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UiVistaEntregaCertificacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.ObtenerActionDeBoton(VariablesDeAmbienteEntregaDeDespacho.Empresa, VariablesDeAmbienteEntregaDeDespacho.DireccionDeServicio))
                {
                    case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR:
                        switch (Escanear)
                        {
                            case Escanear.OlaDePicking:
                                if (!string.IsNullOrEmpty(UiTextoEntrega.Text))
                                {
                                    CargarOlaDePicking(int.Parse(UiTextoEntrega.Text));
                                }
                                break;
                            case Escanear.Etiqueta:
                                UsuarioEscaneoEtiqueta(int.Parse(UiTextoEscanear.Text));
                                break;
                        }
                        break;
                    case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR:
                        RegresaDeConsultaDeEtiquetaPicking = false;
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

        private void UiBotonEntregarDespacho_Click(object sender, EventArgs e)
        {
            try
            {
                if (UiTextoEntrega.ReadOnly)
                {
                    LimpiarControles();
                }
                else
                {
                    CrearEntregaDeDespacho();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UiBotonFinalizar_Click(object sender, EventArgs e)
        {
            CerrarEntregaDeDespacho(Enums.GetStringValue(EstadosDeEntrega.Partial));
        }

        private void UiBotonDetalle_Click(object sender, EventArgs e)
        {
            UiListaDetalle.Visible = !UiListaDetalle.Visible;
            if (UiListaDetalle.Visible)
            {
                CargarDetalle();
            }

        }

        private void UiBotonImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                RegresaDeConsultaDeEtiquetaPicking = true;
                ConsultaDeEtiquetaPicking.Create().ShowPane();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Metodos

        private bool ProcesoExitoso(string valor)
        {
            return string.IsNullOrEmpty(valor);
        }

        private bool ProcesoExitoso(int valor)
        {
            return valor > 0;
        }

        private bool ExisteRegistro(int valor)
        {
            return valor > 0;
        }

        private bool LlegoAlCienPorciento(decimal valor)
        {
            return (valor == 100);
        }

        private bool UsuarioPuedeEliminarEtiqueta(string valor)
        {
            return (valor == EstadoDeEtiqueta.EtiquetaYaExiste.ToString());
        }

        private bool EsParametroPredeterminado(string valor)
        {
            return (valor == Enums.GetStringValue(SiNo.Si));
        }

        private bool EstadoDeEtiquetaEsCompletoOParcial(DataTable tabla)
        {
            return (tabla.Rows[0]["DELIVERED_STATUS"].ToString().ToUpper().Equals("COMPLETED") || tabla.Rows[0]["DELIVERED_STATUS"].ToString().ToUpper().Equals("PARTIAL"));
        }

        private void CargarOlaDePicking(int olaDePicking)
        {
            try
            {
                var servicioDeEntrega = new MobilityScm.Modelo.Vistas.EntregaDeDespacho.WMS_DeliveredLabels.WMS_DeliveredLabels(true);
                var resultado = string.Empty;
                var dt = servicioDeEntrega.GetLabelsByWavePicking(olaDePicking, ref resultado, VariablesDeAmbienteEntregaDeDespacho.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    if (ExisteRegistro(dt.Rows.Count))
                    {
                        UiTextoEntrega.Tag = olaDePicking;
                        UiTextoEntrega.Label = string.Format("Ola de Picking({0})", olaDePicking.ToString());

                        EntregaId = (dt.Rows[0]["DELIVERED_DISPATCH_HEADER_ID"] == DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["DELIVERED_DISPATCH_HEADER_ID"].ToString());

                        if (ExisteRegistro(EntregaId))
                        {
                            if (EstadoDeEtiquetaEsCompletoOParcial(dt))
                            {
                                Escanear = Escanear.Nada;
                                UiBotonFinalizar.Visible = false;
                                UiTextoEntrega.Label = string.Format("Entrega de Despacho({0}) Completado", olaDePicking.ToString());
                            }
                            else
                            {
                                Escanear = Escanear.Etiqueta;
                                UiBotonFinalizar.Visible = UsuarioPuedeFinalizarParcial;
                                ValidarEntregaDeDespacho();
                            }
                            UiTextoEntrega.ReadOnly = true;
                            UiBotonDetalle.Visible = true;
                            UiListaDetalle.Visible = false;
                            UiBotonEntregarDespacho.Text = "Escanear Despacho";
                        }
                    }
                    else
                    {
                        MessageBox.Show("La ola de picking no existe.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CrearEntregaDeDespacho()
        {
            try
            {
                if (UiTextoEntrega.Tag == null) return;
                if (MessageBox.Show("¿Desea crear la entrega para este despacho?", "Entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    var servicioDeEntrega = new MobilityScm.Modelo.Vistas.EntregaDeDespacho.WMS_DeliveredLabels.WMS_DeliveredLabels(true);
                    var resultado = string.Empty;
                    var olaDePickihng = int.Parse(UiTextoEntrega.Tag.ToString());
                    var dt = servicioDeEntrega.InsertDeliveredDispatchHeader(olaDePickihng, Enums.GetStringValue(EstadosDeEntrega.Creado), VariablesDeAmbienteEntregaDeDespacho.Usuario, ref resultado, VariablesDeAmbienteEntregaDeDespacho.Ambiente);
                    if (ProcesoExitoso(resultado))
                    {
                        if (ExisteRegistro(dt.Rows.Count))
                        {
                            EntregaId = int.Parse(dt.Rows[0]["DbData"].ToString());

                            UiTextoEntrega.ReadOnly = true;
                            UiBotonEntregarDespacho.Text = "Escanear Despacho";
                            UiBotonFinalizar.Visible = UsuarioPuedeFinalizarParcial;
                            UiBotonDetalle.Visible = true;
                            UiListaDetalle.Visible = false;
                            Escanear = Escanear.Etiqueta;
                        }
                        else
                        {
                            MessageBox.Show("La entrega de despacho no existe.");
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

        private void UsuarioEscaneoEtiqueta(int etiqueta)
        {
            try
            {
                var servicioDeEntrega = new MobilityScm.Modelo.Vistas.EntregaDeDespacho.WMS_DeliveredLabels.WMS_DeliveredLabels(true);
                var resultado = string.Empty;
                var olaDePicking = int.Parse(UiTextoEntrega.Tag.ToString());
                var dt = servicioDeEntrega.InsertDeliveredLabel(EntregaId, olaDePicking, etiqueta, Enums.GetStringValue(EstadosDeEntrega.Entregado), VariablesDeAmbienteEntregaDeDespacho.Usuario, ref resultado, VariablesDeAmbienteEntregaDeDespacho.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    if (UsuarioPuedeEliminarEtiqueta(dt.Rows[0]["Resultado"].ToString()))
                    {
                        if (MessageBox.Show(dt.Rows[0]["Mensaje"].ToString(), "Entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            EliminarEtiqueta(int.Parse(dt.Rows[0]["DbData"].ToString()));
                        }
                        ValidarEntregaDeDespacho();
                    }
                    else if (ProcesoExitoso(int.Parse(dt.Rows[0]["Resultado"].ToString())))
                    {
                        UiTextoEscanear.Text = "Última etiqueta escaneada: " + etiqueta.ToString();
                        ValidarEntregaDeDespacho();
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


        private void ValidarEntregaDeDespacho()
        {
            try
            {
                var servicioDeEntrega = new MobilityScm.Modelo.Vistas.EntregaDeDespacho.WMS_DeliveredLabels.WMS_DeliveredLabels(true);
                var resultado = string.Empty;
                var olaDePicking = int.Parse(UiTextoEntrega.Tag.ToString());
                var dt = servicioDeEntrega.ValidateIfDeliveryPickingIsComplete(olaDePicking, ref resultado, VariablesDeAmbienteEntregaDeDespacho.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    var codigoResultado = int.Parse(dt.Rows[0]["Resultado"].ToString());
                    var mensaje = dt.Rows[0]["Mensaje"].ToString();
                    var codigo = decimal.Parse(dt.Rows[0]["DbData"].ToString());

                    if (ProcesoExitoso(codigoResultado))
                    {
                        UiEtiquetaEncabezado.Label = "Ola de Picking (" + dt.Rows[0]["DbData"].ToString() + "%)";
                        if (LlegoAlCienPorciento(codigo))
                        {
                            CerrarEntregaDeDespacho(Enums.GetStringValue(EstadosDeEntrega.Completado));
                            UiBotonFinalizar.Visible = false;
                            Escanear = Escanear.Nada;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CerrarEntregaDeDespacho(string estado)
        {
            try
            {
                if (estado.Equals(Enums.GetStringValue(EstadosDeEntrega.Partial)))
                {
                    if (MessageBox.Show("¿Desea finalizar la entrega para este Despacho.?", "Entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                    {
                        return;
                    }
                }

                var servicioDeCertificado = new MobilityScm.Modelo.Vistas.EntregaDeDespacho.WMS_DeliveredLabels.WMS_DeliveredLabels(true);
                var resultado = string.Empty;
                var olaDePicking = int.Parse(UiTextoEntrega.Tag.ToString());
                var dt = servicioDeCertificado.ChangeStatusDEliveredDispatchHeader(EntregaId, estado, VariablesDeAmbienteEntregaDeDespacho.Usuario, ref resultado, VariablesDeAmbienteEntregaDeDespacho.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    var codigoResultado = int.Parse(dt.Rows[0]["Resultado"].ToString());
                    var mensaje = dt.Rows[0]["Mensaje"].ToString();

                    if (ProcesoExitoso(codigoResultado))
                    {
                        Escanear = Escanear.Nada;
                        UiTextoEscanear.Visible = false;
                        UiBotonFinalizar.Visible = false;
                        UiTextoEntrega.Label = string.Format("Ola de Picking({0}) Completado", olaDePicking.ToString());
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

        private void LimpiarControles()
        {
            try
            {
                UiBotonEntregarDespacho.Text = "Entregar Despacho";
                UiTextoEntrega.Tag = null;
                UiTextoEntrega.ReadOnly = false;
                UiBotonDetalle.Visible = false;
                UiBotonFinalizar.Visible = false;
                UiListaDetalle.Visible = false;
                Escanear = Escanear.OlaDePicking;
                UiTextoEntrega.Label = "Ola de Picking(0)";
                UiEtiquetaEncabezado.Label = "Entrega de Despacho";
                UiTextoEntrega.Text = "";
                UiTextoEscanear.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void EliminarEtiqueta(int etiquetaId)
        {
            try
            {
                var servicioDeEntrega = new MobilityScm.Modelo.Vistas.EntregaDeDespacho.WMS_DeliveredLabels.WMS_DeliveredLabels(true);
                var resultado = string.Empty;
                var olaDePicking = int.Parse(UiTextoEntrega.Tag.ToString());
                var dt = servicioDeEntrega.DeleteDeliveredLabel(etiquetaId, Enums.GetStringValue(EstadosDeEntrega.Picked), ref resultado, VariablesDeAmbienteEntregaDeDespacho.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    var codigoResultado = int.Parse(dt.Rows[0]["Resultado"].ToString());
                    var mensaje = dt.Rows[0]["Mensaje"].ToString();

                    if (ProcesoExitoso(codigoResultado))
                    {
                        ValidarEntregaDeDespacho();
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

        private void CargarParametros()
        {
            try
            {
                UsuarioPuedeFinalizarParcial = false;
                var servicioDeConfiguracion = new MobilityScm.Modelo.Vistas.EntregaDeDespacho.WMS_Settings.WMS_Settings(true);
                var resultado = string.Empty;

                var dt = servicioDeConfiguracion.GetParameter(Enums.GetStringValue(GrupoParametro.EntregaDeDespacho), Enums.GetStringValue(IdParametro.Parcial), ref resultado, VariablesDeAmbienteEntregaDeDespacho.Ambiente);
                if (ProcesoExitoso(resultado))
                {
                    if (ProcesoExitoso(dt.Rows.Count))
                    {
                        var valor = dt.Rows[0]["VALUE"].ToString();
                        UsuarioPuedeFinalizarParcial = EsParametroPredeterminado(valor);
                    }

                }
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
                var servicioDeEntrega = new MobilityScm.Modelo.Vistas.EntregaDeDespacho.WMS_DeliveredLabels.WMS_DeliveredLabels(true);
                var resultado = string.Empty;
                var dt = servicioDeEntrega.GetDeliveredDispatchDetail(EntregaId, ref resultado, VariablesDeAmbienteEntregaDeDespacho.Ambiente);
                UiListaDetalle.Nodes.Clear();
                if (ProcesoExitoso(resultado))
                {
                    foreach (DataRow item in dt.Tables["GetDeliveredDispatchDetail"].Rows)
                    {
                        var nodo = new BoundNode(0, 0, item);
                        UiListaDetalle.Nodes.Add(nodo);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


    }
}
