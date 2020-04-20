using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using ClosedXML.Excel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Vistas
{
    public partial class CosteoVista : VistaBase, ICosteoVista
    {
        #region Eventos
        public event EventHandler<CosteoArgumento> UsuarioDeseaCambiarPrecioUnitario;
        public event EventHandler<CosteoArgumento> UsuarioDeseaCargarExcel;
        public event EventHandler<CosteoArgumento> UsuarioDeseaGrabarCosto;
        public event EventHandler<CosteoArgumento> UsuarioDeseaObtenerPolizaDetallePendiente;
        public event EventHandler<CosteoArgumento> UsuarioDeseaObtenerPolizasEncabezadoPendientes;
        public event EventHandler<CosteoArgumento> UsuarioDeseaObtenerPolizaSeguro;
        public event EventHandler<CosteoArgumento> UsuarioDeseaObtenerAcuerdosComerciales;
        public event EventHandler VistaCargandosePorPrimeraVez;

        #endregion

        #region Propiedades
        public IList<PolizaDetalle> PolizaDetalles
        {
            get { return (IList<PolizaDetalle>)UiGridControlDetalle.DataSource; }
            set { UiGridControlDetalle.DataSource = value; }
        }

        public IList<Poliza> Polizas
        {
            get { return (IList<Poliza>)UiGridEncabezado.DataSource; }
            set { UiGridEncabezado.DataSource = value; }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public bool UsuarioSeleccionoVistaEncabezadoCompleta { get; set; }

        public bool EsConsolidado => UiSwitchConsolidado.Checked;

        public IList<PolizaAsegurada> PolizaAseguradas
        {
            get { return (IList<PolizaAsegurada>)UiListaDePolizasSeguro.DataSource; }
            set { UiListaDePolizasSeguro.DataSource = value; }
        }

        public IList<AcuerdoComercial> AcuerdoComerciales
        {
            get { return (IList<AcuerdoComercial>)UiListaAcuerdoComercial.DataSource; }
            set { UiListaAcuerdoComercial.DataSource = value; }
        }

        public IList<PolizaDetalle> PolizaDetallesParaConsolidado { get; set; }

        public string Usuario { get; set; }

        #endregion

        #region Constructor y Eventos De Inicio

        public CosteoVista()
        {
            InitializeComponent();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<ICosteoServicio, CosteoServicio>();
            Mvx.Ioc.RegisterType<IPolizaAseguradaServicio, PolizaAseguradaServicio>();
            Mvx.Ioc.RegisterType<IAcuerdoComercialServicio, AcuerdoComercialServicio>();

            Mvx.Ioc.RegisterSingleton<ICosteoVista, CosteoVista>(this);
            Mvx.Ioc.RegisterType<ICosteoControlador, CosteoControlador>();
            Mvx.Ioc.Resolve<ICosteoControlador>();
        }

        private void CosteoVista_Load(object sender, EventArgs e)
        {
            UiFechaInicio.EditValue = DateTime.Now.Date + (new TimeSpan(0, 0, 0));
            UiFechaFinal.EditValue = DateTime.Now;
            UiSplitControlPrincipal.SplitterPosition = (this.Width / 2) + (UiSplitControlPrincipal.Panel2.Width / 3);
            PolizaDetallesParaConsolidado = new List<PolizaDetalle>();
            Polizas = new List<Poliza>();
            VistaCargandosePorPrimeraVez?.Invoke(null, null);
            CargarOGuardarDisenios(UiGridEncabezado, false, Usuario, GetType().Name);
            CargarOGuardarDisenios(UiGridControlDetalle, false, Usuario, GetType().Name);
        }

        #endregion

        #region Metodos

        private void LLenarVistaEncabezado()
        {
            try
            {
                PolizaDetalles = new List<PolizaDetalle>();
                var costeoArgumento = new CosteoArgumento
                {
                    FechaInicial = Convert.ToDateTime(UiFechaInicio.EditValue).Date + (new TimeSpan(0, 0, 0))
                   ,
                    FechaFinal = Convert.ToDateTime(UiFechaFinal.EditValue).Date + (new TimeSpan(23, 59, 59))
                   ,
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                };
                UsuarioDeseaObtenerPolizasEncabezadoPendientes?.Invoke(null, costeoArgumento);

            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void RecargarSeleccionEncabezados()
        {
            for (var i = 0; i < UiGridVistaEncabezado.RowCount; i++)
            {
                var documento = (Poliza)UiGridVistaEncabezado.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiGridVistaEncabezado.SelectRow(i);
                }
            }
        }

        private void ObtenerDetalle()
        {
            try
            {
                if (EsConsolidado) return;
                if (UiGridVistaEncabezado.FocusedRowHandle < 0) return;
                var registroActual = Polizas.FirstOrDefault(p => p.IS_SELECTED);
                var registro = (Poliza)UiGridVistaEncabezado.GetRow(UiGridVistaEncabezado.FocusedRowHandle);
                foreach (var poliza in Polizas)
                {
                    poliza.IS_SELECTED = false;
                }
                registro.IS_SELECTED = true;
                if (registroActual == null || registroActual.DOC_ID != registro.DOC_ID)
                    UsuarioDeseaObtenerPolizaDetallePendiente?.Invoke(null, new CosteoArgumento { Poliza = registro });
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void ObtenerRegistrosParaListadosDeVista()
        {
            try
            {
                if (UiGridVistaEncabezado.FocusedRowHandle < 0) return;
                var registro = (Poliza)UiGridVistaEncabezado.GetRow(UiGridVistaEncabezado.FocusedRowHandle);
                if (!registro.TRANS_TYPE.Equals("INICIALIZACION_GENERAL")) return;
                UsuarioDeseaObtenerPolizaSeguro?.Invoke(null, new CosteoArgumento { PolizaAsegurada = new PolizaAsegurada { CLIENT_CODE = registro.CLIENT_CODE } });
                UsuarioDeseaObtenerAcuerdosComerciales?.Invoke(null, new CosteoArgumento { AcuerdoComercial = new AcuerdoComercial { CLIENT_CODE = registro.CLIENT_CODE } });
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private bool ValidarDocumentosDeInicializacion()
        {
            try
            {
                if (!Polizas.Where(p => p.IS_SELECTED && p.TRANS_TYPE.Equals("INICIALIZACION_GENERAL")).Any(poliza => string.IsNullOrEmpty(poliza.POLIZA_ASEGURADA) || poliza.ACUERDO_COMERCIAL_ID == 0))
                    return true;
                InteraccionConUsuarioServicio.MensajeErrorDialogo("Hay documentos sin poliza asegurada o acuerdo Comercial");
                return false;
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
                return false;
            }
        }

        private void CambiarAConsolidado()
        {
            try
            {
                foreach (var poliza in Polizas)
                {
                    poliza.IS_SELECTED = false;
                }
                PolizaDetalles = new List<PolizaDetalle>();
                UiGridVistaEncabezado.OptionsSelection.MultiSelect = EsConsolidado;
                UiBotonPlantillaExcel.Visibility = (EsConsolidado)
                    ? BarItemVisibility.Never
                    : BarItemVisibility.Always;
                UiBotonImportarAExecl.Visibility = (EsConsolidado)
                    ? BarItemVisibility.Never
                    : BarItemVisibility.Always;
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void ObtenerDetallesParaConsolidado()
        {
            try
            {
                UsuarioDeseaObtenerPolizaDetallePendiente?.Invoke(null, null);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void EstablecerPreciosUnitariosDeConsolidado()
        {
            try
            {
                foreach (var polizaDetalle in PolizaDetalles.Where(pd => pd.UNITARY_PRICE > 0))
                {
                    foreach (var polizaCon in PolizaDetallesParaConsolidado.Where(pc => pc.MATERIAL_ID == polizaDetalle.MATERIAL_ID))
                    {
                        polizaCon.UNITARY_PRICE = polizaDetalle.UNITARY_PRICE;
                        polizaCon.CUSTOMS_AMOUNT = polizaCon.QTY * polizaCon.UNITARY_PRICE;
                    }
                }
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void GenerarExcelDetalle()
        {
            var poliza = Polizas.FirstOrDefault(x => x.IS_SELECTED);
            if (poliza == null)
            {
                InteraccionConUsuarioServicio.Mensaje("Debe seleccionar una poliza para generar la plantilla.");
                return;
            }
            SaveFileDialog dialogoGuardar = new SaveFileDialog();
            dialogoGuardar.Filter = "Excel xlsx (*.xlsx)|*.xlsx";
            dialogoGuardar.FilterIndex = 2;
            dialogoGuardar.RestoreDirectory = true;

            if (dialogoGuardar.ShowDialog() == DialogResult.OK)
            {
                path = dialogoGuardar.FileName;

                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Detalle");
                worksheet.Protect("Mobility2016$$");

                worksheet.Cell(2, 2).Value = "Póliza";
                worksheet.Cell(2, 3).Value = poliza.CODIGO_POLIZA;

                worksheet.Cell(2, 2).Style.Font.Bold = true;

                worksheet.Cell(3, 2).Value = "Fecha Generación";
                worksheet.Cell(3, 3).Value = DateTime.Now;
                worksheet.Cell(3, 2).Style.Font.Bold = true;


                int inicioEncabezadoX = 5;
                int inicioEncabezadoY = 2;

                worksheet.Column(inicioEncabezadoY + 0).Width = 20;
                worksheet.Column(inicioEncabezadoY + 1).Width = 60;
                worksheet.Column(inicioEncabezadoY + 2).Width = 20;
                worksheet.Column(inicioEncabezadoY + 3).Width = 20;
                worksheet.Column(inicioEncabezadoY + 4).Width = 10;

                //Encabezado Tabla
                for (int j = 0; j <= UiGridVistaDetalle.Columns.Count - 1; j++)
                {
                    worksheet.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Value = UiGridVistaDetalle.Columns[j].Caption;
                    worksheet.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Font.Bold = true;
                    worksheet.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Fill.BackgroundColor = XLColor.BabyBlueEyes;
                    worksheet.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                }

                //Datos
                for (int i = 0; i <= UiGridVistaDetalle.RowCount - 1; i++)
                {
                    for (int j = 0; j <= UiGridVistaDetalle.Columns.Count - 1; j++)
                    {

                        //Celda de total
                        if (j == 4)
                        {
                            worksheet.Cell(i + 1 + inicioEncabezadoX, j + inicioEncabezadoY).FormulaR1C1 = "=RC[-2]*RC[-1]";
                            worksheet.Cell(i + 1 + inicioEncabezadoX, j + inicioEncabezadoY).Style.NumberFormat.Format = " #,##0.00";
                            worksheet.Cell(i + 1 + inicioEncabezadoX, j + inicioEncabezadoY).DataType = XLCellValues.Number;
                        }
                        else
                        {
                            worksheet.Cell(i + 1 + inicioEncabezadoX, j + inicioEncabezadoY).Value =
                                (UiGridVistaDetalle.GetRowCellValue(i, UiGridVistaDetalle.Columns[j]).ToString());
                            worksheet.Cell(i + 1 + inicioEncabezadoX, j + inicioEncabezadoY)
                                .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                        }

                        if (j == 3) //Celda de costo unitario
                        {
                            worksheet.Cell(i + 1 + inicioEncabezadoX, j + inicioEncabezadoY).DataType = XLCellValues.Number;
                            worksheet.Cell(i + 1 + inicioEncabezadoX, j + inicioEncabezadoY).Style.NumberFormat.Format = " #,##0.00";
                            worksheet.Cell(i + 1 + inicioEncabezadoX, j + inicioEncabezadoY)
                                .Style.Protection.SetLocked(false);
                            // worksheet.Cell(i + 1 + inicioEncabezadoX, j + inicioEncabezadoY).DataValidation.Decimal.Between(0, double.MaxValue - 1);
                        }
                    }
                }

                //Convertir en tabla de excel
                IXLRange rngTable = worksheet.Range(worksheet.Cell(inicioEncabezadoX, inicioEncabezadoY), worksheet.Cell(inicioEncabezadoX + UiGridVistaDetalle.RowCount, inicioEncabezadoY + UiGridVistaDetalle.Columns.Count - 1));
                IXLTable excelTable = rngTable.CreateTable();
                excelTable.ShowTotalsRow = true;

                excelTable.Field(4).TotalsRowFunction = XLTotalsRowFunction.Sum;
                excelTable.Field(3).TotalsRowFunction = XLTotalsRowFunction.Sum;
                excelTable.Field(2).TotalsRowFunction = XLTotalsRowFunction.Sum;
                excelTable.Field(1).TotalsRowFunction = XLTotalsRowFunction.Count;
                excelTable.Field(0).TotalsRowLabel = "Total:";
                excelTable.ShowAutoFilter = false;

                //Guardar Excel
                if ((File.Exists(path)))
                {
                    System.IO.File.Delete(path);
                }
                workbook.SaveAs(path);
                Action<bool> abrirExcel = AbrirExcel;

                InteraccionConUsuarioServicio.Confirmar("Archivo generado exitosamente, ¿Desea abrir el archivo?",
                        abrirExcel); //MessageBox.Show("Archivo generado exitosamente, ¿Desea abrir el archivo?", "Operación exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        private static string path = string.Empty;
        private static void AbrirExcel(bool respuesta)
        {
            Process.Start(path);
        }

        private void CargarPlantillaExcel()
        {

            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Excel xlsx (*.xlsx)|*.xlsx";
            dialogo.FilterIndex = 2;
            dialogo.RestoreDirectory = true;
            string docIdExcel = string.Empty;
            var poliza = Polizas.FirstOrDefault(x => x.IS_SELECTED);
            if (poliza == null)
            {
                InteraccionConUsuarioServicio.Mensaje("Debe seleccionar la póliza para cargar la plantilla.");
                return;
            }

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                var workbook = new XLWorkbook(dialogo.FileName);
                var worksheet = workbook.Worksheet("Detalle");
                DataSet dsHead = new DataSet();
                DataSet dsDet = new DataSet();
                docIdExcel = worksheet.Cell(2, 3).Value.ToString();

                if (!Polizas.ToList().Exists(x => x.CODIGO_POLIZA == docIdExcel))
                {
                    InteraccionConUsuarioServicio.Mensaje("El documento número " + docIdExcel + " no se encuentra en un estado para generar costeo o su costeo ya ha sido guardado. ");
                    return;
                }

                if (poliza.CODIGO_POLIZA != docIdExcel)
                {
                    InteraccionConUsuarioServicio.Mensaje("El documento de excel hace referencia al documento  (" + docIdExcel + "), por favor seleccionelo antes de cargar.");
                    return;
                }

                var excelTable = worksheet.Tables.Table(0);
                bool banderaError = false;
                bool banderaPrimero = true;
                foreach (var excelRow in excelTable.RowsUsed())
                {
                    if (banderaPrimero || excelRow.Cell(1).GetString() == "Total:")
                        banderaPrimero = false;
                    else
                    {
                        decimal costo = default(decimal);
                        if (!decimal.TryParse(excelRow.Cell(4) != null ? excelRow.Cell(4).GetString() : "0", out costo))
                        {
                            banderaError = true;
                            costo = 0;
                        }
                        PolizaDetalles.Where(x => x.MATERIAL_ID == excelRow.Cell(1).GetString()).ForEach(x =>
                         {
                             x.UNITARY_PRICE = costo;
                             x.CUSTOMS_AMOUNT = costo * x.QTY;
                         });
                    }
                }
                if (banderaError)
                {
                    InteraccionConUsuarioServicio.Mensaje(
                        "Uno o varios elementos fallaron en la lectura del excel y les asignó un costo 0.");
                }
                else
                {
                    InteraccionConUsuarioServicio.MensajeExito(" Carga realizada con éxito " + docIdExcel);
                }
            }
            UiGridControlDetalle.RefreshDataSource();
        }



        #endregion

        #region Eventos de Controles

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LLenarVistaEncabezado();
        }

        private void UiGridVistaEncabezado_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (Poliza)UiGridVistaEncabezado.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoVistaEncabezadoCompleta)
                {
                    for (var i = 0; i < UiGridVistaEncabezado.RowCount; i++)
                    {
                        var documento = (Poliza)UiGridVistaEncabezado.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiGridVistaEncabezado.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoVistaEncabezadoCompleta = false;
                }
            }
            if (EsConsolidado)
                ObtenerDetallesParaConsolidado();
        }

        private void UiGridVistaEncabezado_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoVistaEncabezadoCompleta = true;
            }
        }

        private void UiGridVistaEncabezado_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            RecargarSeleccionEncabezados();
        }

        private void UiGridVistaEncabezado_ColumnFilterChanged(object sender, EventArgs e)
        {
            RecargarSeleccionEncabezados();
        }

        private void UiBotonGrabar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiGridVistaEncabezado.Focus();
            UiGridVistaDetalle.Focus();
            if (!Polizas.ToList().Exists(p => p.IS_SELECTED)) return;
            if (!ValidarDocumentosDeInicializacion()) return;
            if (!UiGridVistaDetalle.ValidateEditor()) return;
            if (EsConsolidado)
            {
                EstablecerPreciosUnitariosDeConsolidado();
            }
            UsuarioDeseaGrabarCosto?.Invoke(null, null);
        }

        private void UiGridVistaDetalle_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
        }

        private void UiGridVistaDetalle_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            var view = sender as GridView;
            if (view == null || view.FocusedColumn.FieldName != "UNITARY_PRICE") return;
            var registro = (PolizaDetalle)UiGridVistaDetalle.GetRow(view.FocusedRowHandle);
            if (Convert.ToDecimal(e.Value.ToString()) < 0)
            {
                e.Valid = false;
                e.ErrorText = "Cantidad inválida.";
            }
            else
            {
                registro.CUSTOMS_AMOUNT = registro.QTY * Convert.ToDecimal(e.Value.ToString());
            }
        }

        private void UiGridVistaEncabezado_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null) return;
            var texto = e.Value.ToString();
            switch (e.Column.Name)
            {
                case "UiColPolizaAseguradaEncabezada":
                    var polizasSeguro = Polizas.FirstOrDefault(x => x.POLIZA_ASEGURADA == texto);
                    if (polizasSeguro != null) texto = polizasSeguro.POLIZA_ASEGURADA_DESCRIPCION;
                    break;
                case "UiColAcuerdoComercial":
                    var acuerdoComercial = Polizas.FirstOrDefault(x => x.ACUERDO_COMERCIAL_ID == int.Parse(texto));
                    if (acuerdoComercial != null) texto = acuerdoComercial.ACUERDO_COMERCIAL_NOMBRE;
                    break;
            }
            e.DisplayText = texto;


        }

        private void UiListaDePolizasSeguro_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (UiGridVistaEncabezado.FocusedRowHandle < 0) return;
            var registro = (Poliza)UiGridVistaEncabezado.GetRow(UiGridVistaEncabezado.FocusedRowHandle);
            e.Cancel = !registro.TRANS_TYPE.Equals("INICIALIZACION_GENERAL");

        }

        private void UiGridVistaEncabezado_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ObtenerDetalle();
            ObtenerRegistrosParaListadosDeVista();
        }

        private void UiListaDePolizasSeguro_EditValueChanged(object sender, EventArgs e)
        {
            if (UiGridVistaEncabezado.FocusedRowHandle < 0) return;
            var polizaSegurdo = ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue.ToString();
            var registro = (Poliza)UiGridVistaEncabezado.GetRow(UiGridVistaEncabezado.FocusedRowHandle);
            var firstOrDefault = PolizaAseguradas.FirstOrDefault(pa => pa.DOC_ID == polizaSegurdo);
            if (firstOrDefault != null)
            {
                registro.POLIZA_ASEGURADA_DESCRIPCION = firstOrDefault.POLIZA_INSURANCE;
            }
        }

        private void UiListaAcuerdoComercial_EditValueChanged(object sender, EventArgs e)
        {
            if (UiGridVistaEncabezado.FocusedRowHandle < 0) return;
            var acuerdoComercial = ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue.ToString();
            var registro = (Poliza)UiGridVistaEncabezado.GetRow(UiGridVistaEncabezado.FocusedRowHandle);
            var firstOrDefault = AcuerdoComerciales.FirstOrDefault(pa => pa.ACUERDO_COMERCIAL == int.Parse(acuerdoComercial));
            if (firstOrDefault != null)
            {
                registro.ACUERDO_COMERCIAL_NOMBRE = firstOrDefault.DESCRIPCION;
            }
        }
        private void UiSwitchConsolidado_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CambiarAConsolidado();
        }

        private void UiBotonPlantillaExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                GenerarExcelDetalle();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonImportarAExecl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                CargarPlantillaExcel();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }

        }

        private void CosteoVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiGridEncabezado, true, Usuario, GetType().Name);
            CargarOGuardarDisenios(UiGridControlDetalle, true, Usuario, GetType().Name);
        }

        #endregion


    }
}
