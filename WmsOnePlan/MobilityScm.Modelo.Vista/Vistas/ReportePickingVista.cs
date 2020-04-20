using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MobilityScm.Modelo.Vistas
{
    public partial class ReportePickingVista : VistaBaseDeveExpress, IReportePickingVista
    {
        #region Eventos
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler UsuarioDeseaRefrescarReporte;
        #endregion

        #region Propiedades
        public IList<ReportePicking> DetalleReportePicking
        {
            get { return (IList<ReportePicking>)UiDetallePicking.DataSource; }
            set
            {
                UiDetallePicking.DataSource = value;
            }
        }

        public DateTime FechaInicial
        {
            get { return Convert.ToDateTime(UiFechaInicial.EditValue); }
            set
            {
                UiFechaInicial.EditValue = value;
            }
        }

        public DateTime FechaFinal {
            get { return Convert.ToDateTime(UiFechaFinal.EditValue); }
            set
            {
                UiFechaFinal.EditValue = value;
            }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        #endregion

        public ReportePickingVista()
        {
            InitializeComponent();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<ISeguridadServicio, SeguridadServicio>();
            Mvx.Ioc.RegisterType<IPickingServicio, PickingServicio>();

            Mvx.Ioc.RegisterSingleton<IReportePickingVista, ReportePickingVista>(this);
            Mvx.Ioc.RegisterType<IReportePickingControlador, ReportePickingControlador>();
            Mvx.Ioc.Resolve<IReportePickingControlador>();
        }

        private void ReportePickingVista_Load(object sender, EventArgs e)
        {
            UiFechaInicial.EditValue = DateTime.Now.Date + (new TimeSpan(0, 0, 0));
            UiFechaFinal.EditValue = DateTime.Now.Date + (new TimeSpan(23, 59, 59));
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            llenarCombo();
            this.comboPivotGuardados.SelectedIndexChanged += ComboPivotGuardados_SelectedIndexChanged;
            DevExpress.XtraPivotGrid.PivotGridField.DefaultDecimalFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            DevExpress.XtraPivotGrid.PivotGridField.DefaultDecimalFormat.FormatString = "N1";
        }

        private void ComboPivotGuardados_SelectedIndexChanged(object sender, EventArgs e)
        {
            recargarPivotGrid(this.UiEditComboGuardados.EditValue.ToString());
        }

        private void llenarCombo()
        {
            this.comboPivotGuardados.Items.Clear();
            string nombreBase = $@"{UiPivotReportePicking.Name}{InteraccionConUsuarioServicio.ObtenerUsuario()}";
            string direccion = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}";
            DirectoryInfo directoryInfo = new DirectoryInfo(direccion);
            foreach (var fi in directoryInfo.GetFiles("*"+ nombreBase + "*"))
            {
                this.comboPivotGuardados.Items.Add(fi.Name.Replace(".xml","").Replace(nombreBase,""));
            }
            if (this.comboPivotGuardados.Items.Count > 0)
            { 
                this.UiEditComboGuardados.EditValue = this.comboPivotGuardados.Items[0].ToString();
                recargarPivotGrid(this.comboPivotGuardados.Items[0].ToString());
            }else
            {
                this.UiEditComboGuardados.EditValue = null;
            }
        }

        private void UiBotonExportarData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiDialogoParaGuardar.DefaultExt = "xlsx";
                UiDialogoParaGuardar.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
                UiDialogoParaGuardar.FilterIndex = 2;
                UiDialogoParaGuardar.RestoreDirectory = true;
                UiDialogoParaGuardar.Title = @"Exportar Data Reporte de Picking";
                if (UiDialogoParaGuardar.ShowDialog() == DialogResult.OK)
                {
                    UiViewDetallePicking.ExportToXlsx(UiDialogoParaGuardar.FileName);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void UiBotonGuardarConfiguracionPivot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UiEditComboGuardados.EditValue != null && !UiEditComboGuardados.EditValue.ToString().Equals(""))
            {
                if (ConfirmacionSobreescrituraConfiguracionXml()) { 
                    string nombreArchivo = UiEditComboGuardados.EditValue.ToString();
                    GrabarXmlPivotGridReportePicking(nombreArchivo);
                }
            }
        }

        private void UiBotonGuardarComoNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UiEditNombreArchivo.EditValue != null && !UiEditNombreArchivo.EditValue.ToString().Trim().Equals(""))
            {
                GrabarXmlPivotGridReportePicking(UiEditNombreArchivo.EditValue.ToString());
                llenarCombo();
            }
        }

        private void recargarPivotGrid(string nombreArchivo)
        {
            try
            {
                string direccion = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\{UiPivotReportePicking.Name}{InteraccionConUsuarioServicio.ObtenerUsuario()}{nombreArchivo}.xml";
                UiPivotReportePicking.RestoreLayoutFromXml(direccion);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje("Error al intentar recargar layout del reporte de picking =>" + ex.Message);
            }
        }

        private void GrabarXmlPivotGridReportePicking(string nombreArchivo)
        {
            try { 
                string direccion = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\{UiPivotReportePicking.Name}{InteraccionConUsuarioServicio.ObtenerUsuario()}{nombreArchivo}.xml";
                UiPivotReportePicking.SaveLayoutToXml(direccion);
            }catch(Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje("Error al intentar grabar layout del reporte de picking =>" + ex.Message);
            }
        }

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UsuarioDeseaRefrescarReporte?.Invoke(sender, e);
        }

        private void UiBotonEliminarXmlPivot_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(UiEditComboGuardados.EditValue!=null && !UiEditComboGuardados.EditValue.ToString().Equals(""))
            {
                if (ConfirmacionEliminacionArchivoConfiguracion())
                {
                    try
                    {
                        string nombreArchivo = UiEditComboGuardados.EditValue.ToString();
                        string direccion = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\{UiPivotReportePicking.Name}{InteraccionConUsuarioServicio.ObtenerUsuario()}{nombreArchivo}.xml";
                        File.Delete(direccion);
                        llenarCombo();
                    }
                    catch (Exception ex)
                    {
                        InteraccionConUsuarioServicio.Mensaje(ex.Message);
                    }
                }
            }else
            {
                InteraccionConUsuarioServicio.Mensaje("Debe seleccionar un elemento para eliminar");
            }
        }

        private bool ConfirmacionSobreescrituraConfiguracionXml()
        {
            return XtraMessageBox.Show("Desea sobreescribir la configuración seleccionada?", "Swift 3PL", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private bool ConfirmacionEliminacionArchivoConfiguracion()
        {
            return XtraMessageBox.Show("Desea eliminar el archivo de configuración de tabla pivote para el reporte de picking?", "Swift 3PL", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void UiBotonExportarPivotTable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiDialogoParaGuardar.DefaultExt = "xlsx";
                UiDialogoParaGuardar.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
                UiDialogoParaGuardar.FilterIndex = 2;
                UiDialogoParaGuardar.RestoreDirectory = true;
                UiDialogoParaGuardar.Title = @"Exportar Tabla Pivote Reporte de Picking";
                if (UiDialogoParaGuardar.ShowDialog() == DialogResult.OK)
                {
                    var pivotExportOptions = new DevExpress.XtraPivotGrid.PivotXlsxExportOptions();
                    pivotExportOptions.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                    UiPivotReportePicking.ExportToXlsx(UiDialogoParaGuardar.FileName, pivotExportOptions);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }
    }
}
