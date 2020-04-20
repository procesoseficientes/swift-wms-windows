using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting.Native;
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Tipos;

namespace MobilityScm.Modelo.Vistas
{
    public partial class ConsultaDeManifiestoVista : VistaBase, IConsultaDeManifiestoVista
    {
        #region Eventos
        public event EventHandler<ManifiestoArgumento> UsuarioDeseaCancelarManifiesto;
        public event EventHandler<ManifiestoArgumento> UsuarioDeseaActualizarVehiculoAManifiesto;
        public event EventHandler<ManifiestoArgumento> UsuarioDeseaObtenerDetallesDeManifiestos;
        public event EventHandler<ManifiestoArgumento> UsuarioDeseaObtenerEncabezadosDeManifiesto;
        public event EventHandler<ManifiestoArgumento> UsuarioDeseaQuitarDetallesDeManifiesto;
        public event EventHandler<ManifiestoArgumento> UsuarioDeseaObtenerVehiculosConPilotoAsociado;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler VistaTerminoDeCargar;
        #endregion

        #region Propiedades
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public ConsultaDeManifiestoVista()
        {
            InitializeComponent();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();

            Mvx.Ioc.RegisterType<IConsultaDeManifiestoServicio, ConsultaDeManifiestoServicio>();
            Mvx.Ioc.RegisterType<IManifiestoCargaServicio, ManifiestoCargaServicio>();
            Mvx.Ioc.RegisterType<IVehiculoServicio, VehiculoServicio>();
            Mvx.Ioc.RegisterType<IParametroServicio, ParametroServicio>();
            Mvx.Ioc.RegisterType<IConsultaDeManifiestoControlador, ConsultaDeManifiestoControlador>();
            Mvx.Ioc.RegisterSingleton<IConsultaDeManifiestoVista, ConsultaDeManifiestoVista>(this);
            Mvx.Ioc.Resolve<IConsultaDeManifiestoControlador>();
        }

        public IList<ManifiestoDetalle> DetallesDeManifiestos
        {
            get
            {
                return (IList<ManifiestoDetalle>)UiContenedorManifiestosDetalle.DataSource;
            }

            set
            {
                UiContenedorManifiestosDetalle.DataSource = value;
            }
        }

        public IList<ManifiestoEncabezado> EncabezadosDeManifiesto
        {
            get
            {
                return (IList<ManifiestoEncabezado>)UiContenedorManifiestosEncabezado.DataSource;
            }

            set
            {
                UiContenedorManifiestosEncabezado.DataSource = value;
            }
        }

        public IList<Vehiculo> TodosVehiculos { get; set; }

        public IList<Vehiculo> Vehiculos
        {
            get
            {
                return (IList<Vehiculo>)UiListaVehiculos.Properties.DataSource;
            }
            set
            {
                UiListaVehiculos.Properties.DataSource = value.Where(d => d.WEIGHT > ObtenerPesoDeManifiesto()).OrderBy(o => o.WEIGHT).ToList();
            }
        }

        private decimal ObtenerPesoDeManifiesto()
        {
            return DetallesDeManifiestos?.Sum(detallesDeManifiesto => detallesDeManifiesto.WEIGHT) ?? 0;
        }

        public string Usuario { get; set; }

        private bool UsuarioSeleccionoListaDeManifiestoDetalleCompleta { get; set; }
        public int VehiculoSeleccionado => (int)(UiListaVehiculos.EditValue ?? 0);

        public void TerminoProceso(object mensaje, dynamic sender)
        {
            throw new NotImplementedException();
        }

        public IList<Parametro> Parametros { get; set; }

        #endregion

        #region Eventos de Pagina      

        private void UiFechaInicial_EditValueChanged(object sender, EventArgs e)
        {
            if (UiFechaInicial.EditValue == null || UiFechaFinal.EditValue == null) return;
            ObtenerManifiestos(sender);
        }
        private void UiFechaFinal_EditValueChanged(object sender, EventArgs e)
        {
            if (UiFechaInicial.EditValue == null || UiFechaFinal.EditValue == null) return;
            ObtenerManifiestos(sender);
        }

        private void ConsultaDeManifiestoVista_Load(object sender, EventArgs e)
        {
            try
            {
                UiFechaInicial.EditValue = DateTime.Today;
                UiFechaFinal.EditValue = DateTime.Today.AddDays(.999999);
                VistaCargandosePorPrimeraVez?.Invoke(sender, e);
                UiListaVehiculos.Properties.PopupFormWidth = UiListaVehiculos.Width - 10;

                CargarOGuardarDisenios(UiContenedorManifiestosEncabezado, false, Usuario, GetType().Name);
                CargarOGuardarDisenios(UiContenedorManifiestosDetalle, false, Usuario, GetType().Name);
                MostrarColumnasTipoDespacho();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }

        }
        private void UiVistaManifiestosEncabezado_Click(object sender, EventArgs e)
        {
            ObtenerDetalleDeManifiesto(sender);
            Vehiculos = TodosVehiculos;
        }

        private void UiBotonRefrescar_ItemClick(object sender, ItemClickEventArgs e)
        {
            ObtenerManifiestos(sender);
        }

        private void UiBotonActualizarVehiculo_ItemClick(object sender, ItemClickEventArgs e)
        {
            ActualizarVehiculoAsociado(sender);
        }

        private void UiBotonDesasociar_ItemClick(object sender, ItemClickEventArgs e)
        {
            DesasociarDemandasDespachoDeManifiesto(sender);
        }

        private void UiBotonCancelarManifiesto_ItemClick(object sender, ItemClickEventArgs e)
        {
            CancelarManifiestoDeCarga(sender);
        }

        private void UiListaVehiculos_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag.ToString() == "REFRESCAR-VEHICULOS")
            {
                UsuarioDeseaObtenerVehiculosConPilotoAsociado?.Invoke(sender,
                    new ManifiestoArgumento { Vehiculo = new Vehiculo() });
            }
        }

        #endregion

        #region Metodos

        private void MostrarColumnasTipoDespacho()
        {
            try
            {
                var parametroTipoDespacho = Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.ObtieneTipoDeDemanda) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.DemandaDePicking));
                var mostrarTipoDespacho = (parametroTipoDespacho != null && int.Parse(parametroTipoDespacho.VALUE) == (int)SiNo.Si);

                UiColCodigoTipoDespacho.Visible = mostrarTipoDespacho;
                UiColCodigoTipoDespacho.OptionsColumn.ShowInCustomizationForm = mostrarTipoDespacho;
                UiColNombreTipoDespacho.Visible = mostrarTipoDespacho;
                UiColNombreTipoDespacho.OptionsColumn.ShowInCustomizationForm = mostrarTipoDespacho;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void ObtenerDetalleDeManifiesto(object sender)
        {
            if (UiVistaManifiestosEncabezado.FocusedRowHandle < 0) return;
            UsuarioDeseaObtenerDetallesDeManifiestos?.Invoke(
               sender, new ManifiestoArgumento
               {
                   IdManifiestoDeCarga = ((ManifiestoEncabezado)UiVistaManifiestosEncabezado.GetRow(UiVistaManifiestosEncabezado.FocusedRowHandle)).MANIFEST_HEADER_ID.ToString()
               }
               );
        }
        private void CancelarManifiestoDeCarga(object sender)
        {
            if (UiVistaManifiestosEncabezado.FocusedRowHandle < 0) return;
            if (MessageBox.Show("Esta acción eliminará completamente el manifiesto y no podrá ser recuperado. ¿Desea continuar?", "Confirme acción", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UsuarioDeseaCancelarManifiesto?.Invoke(sender, new ManifiestoArgumento
                {
                    ManifiestoEncabezado = new ManifiestoEncabezado
                    {
                        MANIFEST_HEADER_ID = ((ManifiestoEncabezado)UiVistaManifiestosEncabezado.GetRow(UiVistaManifiestosEncabezado.FocusedRowHandle)).MANIFEST_HEADER_ID
                    ,
                        STATUS = Enums.GetStringValue(EstadosManifiesto.Cancelado)
                    }
                });
            }
            ObtenerManifiestos(sender);
        }
        private void DesasociarDemandasDespachoDeManifiesto(object sender)
        {
            if (NoHayEncabezadoSeleccionadoONoHayDetallesSeleccionados())
                return;

            UsuarioDeseaQuitarDetallesDeManifiesto?.Invoke(sender, new ManifiestoArgumento
            {
                DemandasDespacho = PrepararDemandaDespachosParaDesasociar(),
                ManifiestoEncabezado = new ManifiestoEncabezado { MANIFEST_HEADER_ID = ((ManifiestoEncabezado)UiVistaManifiestosEncabezado.GetRow(UiVistaManifiestosEncabezado.FocusedRowHandle)).MANIFEST_HEADER_ID }
            });

            ObtenerDetalleDeManifiesto(sender);
        }

        private bool NoHayEncabezadoSeleccionadoONoHayDetallesSeleccionados()
        {
            return UiVistaManifiestosEncabezado.FocusedRowHandle < 0 || !DetallesDeManifiestos.Any(d => d.IS_SELECTED);
        }

        private string PrepararDemandaDespachosParaDesasociar()
        {
            return String.Join("|",
                DetallesDeManifiestos.Where(d => d.IS_SELECTED)
                    .Select(m => m.PICKING_DEMAND_HEADER_ID)
                    .Distinct()
                    .ToList());
        }

        private void ObtenerManifiestos(object sender)
        {
            if (FechaInicialEsMayorAFechaFinal()) InteraccionConUsuarioServicio.Alerta("Fecha final no debe ser menor a fecha Inicial");
            UsuarioDeseaObtenerEncabezadosDeManifiesto?.Invoke(sender, new ManifiestoArgumento
            {
                FechaFinal = Convert.ToDateTime(UiFechaFinal.EditValue),
                FechaInicial = Convert.ToDateTime(UiFechaInicial.EditValue),
                ManifiestoEncabezado = new ManifiestoEncabezado { STATUS = null },
                Login = InteraccionConUsuarioServicio.ObtenerUsuario()
            });
        }

        private bool FechaInicialEsMayorAFechaFinal()
        {
            return Convert.ToDateTime(UiFechaFinal.EditValue) < Convert.ToDateTime(UiFechaInicial.EditValue);
        }

        private void ActualizarVehiculoAsociado(object sender)
        {
            if (nohayEncabezadoSeleccionadoONohayVehiculoSeleccionado()) return;
            UsuarioDeseaActualizarVehiculoAManifiesto?.Invoke(sender, new ManifiestoArgumento
            {
                ManifiestoEncabezado =
                    new ManifiestoEncabezado
                    {
                        MANIFEST_HEADER_ID =
                            ((ManifiestoEncabezado)
                                UiVistaManifiestosEncabezado.GetRow(UiVistaManifiestosEncabezado.FocusedRowHandle))
                                .MANIFEST_HEADER_ID
                        ,
                        VEHICLE = VehiculoSeleccionado
                    },
                Login = InteraccionConUsuarioServicio.ObtenerUsuario()
            });
            ObtenerManifiestos(sender);
        }

        private bool nohayEncabezadoSeleccionadoONohayVehiculoSeleccionado()
        {
            return UiVistaManifiestosEncabezado.FocusedRowHandle < 0 || VehiculoSeleccionado == 0;
        }

        #endregion

        #region Metodos de seleccion Manifiesto Detalle
        private void MarcarManifiestoDetalleSeleccionado()
        {
            try
            {
                for (int i = 0; i < UiVistaManifiestosDetalle.RowCount; i++)
                {
                    var documento = (ManifiestoDetalle)UiVistaManifiestosDetalle.GetRow(i);
                    if (documento == null) continue;
                    if (documento.IS_SELECTED)
                    {
                        UiVistaManifiestosDetalle.SelectRow(i);
                    }
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }
        private void UiVistaManifiestosDetalle_ColumnFilterChanged(object sender, EventArgs e)
        {
            MarcarManifiestoDetalleSeleccionado();
        }
        private void UiVistaManifiestosDetalle_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            MarcarManifiestoDetalleSeleccionado();
        }
        private void UiVistaManifiestosDetalle_MouseUp(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            if (view == null)
                return;
            var hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaDeManifiestoDetalleCompleta = true;
            }
        }

        private void UiVistaManifiestosDetalle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (ManifiestoDetalle)UiVistaManifiestosDetalle.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (!UsuarioSeleccionoListaDeManifiestoDetalleCompleta) return;
                for (var i = 0; i < UiVistaManifiestosDetalle.RowCount; i++)
                {
                    var documento = (ManifiestoDetalle)UiVistaManifiestosDetalle.GetRow(i);
                    if (documento == null) continue;
                    documento.IS_SELECTED = (UiVistaManifiestosDetalle.SelectedRowsCount != 0);
                }
                UsuarioSeleccionoListaDeManifiestoDetalleCompleta = false;
            }
        }
        #endregion

        private void UiContenedorManifiestosEncabezado_DoubleClick(object sender, EventArgs e)
        {
            UsuarioDeseaConsultarElManifiesto();
        }

        private void UsuarioDeseaConsultarElManifiesto()
        {
            try
            {
                var fila = (ManifiestoEncabezado)UiVistaManifiestosEncabezado.GetFocusedRow();
                if (fila == null) return;

                var formularios = Application.OpenForms;
                var frm = formularios.Cast<Form>().FirstOrDefault(formulario => (formulario.Name == "ManifiestoCargaVista"));

                if (frm == null)
                {
                    frm = new ManifiestoCargaVista(fila.MANIFEST_HEADER_ID.ToString()) {MdiParent = MdiParent};
                    frm.Show();
                }
                else
                {
                    ((ManifiestoCargaVista)(frm)).CargarManifiesto(fila.MANIFEST_HEADER_ID.ToString());
                    ((ManifiestoCargaVista) (frm)).Focus();
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta("Error al cargar el manifiesto: " + ex.Message);
            }
        }
    }
}