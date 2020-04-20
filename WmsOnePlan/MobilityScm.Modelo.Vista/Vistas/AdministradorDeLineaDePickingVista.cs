using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Vistas
{
    public partial class AdministradorDeLineaDePickingVista : VistaBase, IAdministradorDeLineaDePickingVista
    {
        #region Eventos
        public event EventHandler VistaTerminoDeCargar;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler<ConsultaArgumento> UsuarioDeseaConsultarCaja;
        public event EventHandler<CajaArgumento> UsuarioDeseaActualizarCaja;
        #endregion

        #region Propiedades
        public IList<Caja> Cajas
        {
            get { return (IList<Caja>)UiContenedorPrincipal.DataSource; }
            set { UiContenedorPrincipal.DataSource = value; }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        #endregion

        #region Contructor y Eventos de Carga
        public AdministradorDeLineaDePickingVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();

            Mvx.Ioc.RegisterType<ILineaDePickingServicio, LineaDePickingServicio>();

            Mvx.Ioc.RegisterSingleton<IAdministradorDeLineaDePickingVista, AdministradorDeLineaDePickingVista>(this);
            Mvx.Ioc.RegisterType<IAdministradorDeLineaDePickingControlador, AdministradorDeLineaDePickingControlador>();
            Mvx.Ioc.Resolve<IAdministradorDeLineaDePickingControlador>();
        }

        private void AdministradorDeLineaDePickingVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            CargarOGuardarDisenios(UiContenedorPrincipal, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }

        private void AdministradorDeLineaDePickingVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiContenedorPrincipal, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }
        #endregion

        #region Metodos
        public void TerminoProceso(object mensaje, dynamic sender)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Eventos de Controles
        private void UiBotonGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var cajasAModificar = Cajas.Where(x => x.MODIFIED).ToList();
                if (cajasAModificar.Count <= 0)
                {
                    InteraccionConUsuarioServicio.Mensaje("No hay registros para modificar.");
                    return;
                }
                UsuarioDeseaActualizarCaja?.Invoke(sender, new CajaArgumento
                {
                    Cajas = cajasAModificar
                    , Login =  InteraccionConUsuarioServicio.ObtenerUsuario()
                });
                InteraccionConUsuarioServicio.MensajeExito("Modificación finalizada exitosamente.");
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void UiBotonExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiDialogoParaGuardar.DefaultExt = "xlsx";
                UiDialogoParaGuardar.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
                UiDialogoParaGuardar.FilterIndex = 2;
                UiDialogoParaGuardar.RestoreDirectory = true;
                UiDialogoParaGuardar.Title = @"Guardar Administrador de Linea de Picking";
                if (UiDialogoParaGuardar.ShowDialog() == DialogResult.OK)
                {
                    UiVistaPrincipal.ExportToXlsx(UiDialogoParaGuardar.FileName);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaPrincipal.CollapseAllGroups();
        }

        private void UiBotonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaPrincipal.ExpandAllGroups();
        }

        private void UiControlTextoNumeroDeCaja_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.KeyCode == Keys.Enter)
                {
                    var numeroDeCaja = (sender as TextEdit).Text;
                    UsuarioDeseaConsultarCaja?.Invoke(sender, new ConsultaArgumento { IdParametro = numeroDeCaja });
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void UiVistaPrincipal_ShowingEditor(object sender, CancelEventArgs e)
        {
            int implosion = Convert.ToInt32(UiVistaPrincipal.GetRowCellValue(UiVistaPrincipal.FocusedRowHandle, "WAS_IMPLODED"));
            if (implosion == (int)Estados.SiNo.Si)
                e.Cancel = true;

            string estado = UiVistaPrincipal.GetRowCellValue(UiVistaPrincipal.FocusedRowHandle, "STATUS").ToString();

            if (EnumsOperations.GetEnumValueFromStringValue<Estados.EstadoCajaLineaPicking>(estado) == EstadoCajaLineaPicking.Despachado)
                e.Cancel = true;
        }

        private void UiVistaPrincipal_ValidatingEditor(object sender,
            DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn == colQUANTITY)
            {
                decimal cantidad = Convert.ToDecimal(e.Value);
                if (cantidad < 0)
                {
                    e.Valid = false;
                    e.ErrorText = "Cantidad inválida.";
                    return;
                }

                decimal cantidadOrginal = Convert.ToDecimal(UiVistaPrincipal.GetRowCellValue(UiVistaPrincipal.FocusedRowHandle, "QUANTITY_ORIGINAL").ToString());
                if (cantidadOrginal < cantidad)
                {
                    e.Valid = false;
                    e.ErrorText = "No puede sobrepasar la cantidad original de la canasta.";
                    return;
                }
                if (cantidadOrginal != cantidad)
                {
                    view.SetRowCellValue(UiVistaPrincipal.FocusedRowHandle, "MODIFIED", true);
                }
                else
                {
                    view.SetRowCellValue(UiVistaPrincipal.FocusedRowHandle, "MODIFIED", false);
                }
            }
        }

        #endregion


    }
}
