using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using DevExpress.Spreadsheet;
using DevExpress.XtraEditors;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Vistas
{
    public partial class ZonaDePosicionamientoVista : VistaBaseDeveExpress, IZonaDePosicionamientoVista
    {
        #region Eventos

        public event EventHandler<PosicionamientoArgumento> UsuarioDeseaObtenerBodegas;
        public event EventHandler<PosicionamientoArgumento> UsuarioDeseaObtenerZonasDePosicionamiento;
        public event EventHandler<PosicionamientoArgumento> UsuarioDeseaGrabarZonasDePosicionamiento;
        public event EventHandler<PosicionamientoArgumento> UsuarioDeseaObtenerClasesAsociadas;
        public event EventHandler<PosicionamientoArgumento> UsuarioDeseaObtenerClasesDisponibles;
        public event EventHandler<PosicionamientoArgumento> UsuarioDeseaAgregarClases;
        public event EventHandler<PosicionamientoArgumento> UsuarioDeseaQuitarClases;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler<PosicionamientoArgumento> UsuarioDeseaCargarPlantilla;

        #endregion

        #region Propiedades

        public IList<Bodega> Bodegas
        {
            get { return (IList<Bodega>)UiListaBodega.Properties.DataSource; }
            set { UiListaBodega.Properties.DataSource = value; }
        }

        public IList<Clase> ClasesAsociadas
        {
            get { return (IList<Clase>)UiVistaControlClasesAsociadasZP.DataSource; }
            set { UiVistaControlClasesAsociadasZP.DataSource = value; }
        }

        public IList<Clase> ClasesDisponibles
        {
            get { return (IList<Clase>)UiListaClasesDesponiblesZP.Properties.DataSource; }
            set { UiListaClasesDesponiblesZP.Properties.DataSource = value; }
        }

        public IList<ZonaDePosicionamiento> ZonasDePosicionamientos
        {
            get { return (IList<ZonaDePosicionamiento>)UiVistaControlZonasDePosicionamiento.DataSource; }
            set { UiVistaControlZonasDePosicionamiento.DataSource = value; }
        }

        public IList<Parametro> Parametros { get; set; }

        public ZonaDePosicionamiento ZonasDePosicionamientoSeleccionado { get; set; }


        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        #endregion

        #region Constructor y Eventos de Inicio

        public ZonaDePosicionamientoVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IPosicionamientoServicio, PosicionamientoServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();
            Mvx.Ioc.RegisterType<IClaseServicio, ClaseServicio>();
            Mvx.Ioc.RegisterType<IParametroServicio, ParametroServicio>();
            Mvx.Ioc.RegisterSingleton<IZonaDePosicionamientoVista, ZonaDePosicionamientoVista>(this);
            Mvx.Ioc.RegisterType<IZonaDePosicionamientoControlador, ZonaDePosicionamientoControlador>();
            Mvx.Ioc.Resolve<IZonaDePosicionamientoControlador>();
        }

        private void ZonaDePosicionamientoVista_Load(object sender, EventArgs e)
        {
            try
            {
                Bodegas = new List<Bodega>();
                ClasesAsociadas = new List<Clase>();
                ClasesDisponibles = new List<Clase>();
                ZonasDePosicionamientos = new List<ZonaDePosicionamiento>();
                ZonasDePosicionamientoSeleccionado = new ZonaDePosicionamiento();
                VistaCargandosePorPrimeraVez?.Invoke(null, null);

                ImplementarSeleccionMultipleDeUnaLista(UiListaBodega, new ObjetoParaGuardarEnVista { ListaDeCamposAMostrar = (new[] { "WAREHOUSE_ID" }) });
                ImplementarSeleccionMultipleDeUnaLista(UiListaClasesDesponiblesZP, new ObjetoParaGuardarEnVista { ListaDeCamposAMostrar = (new[] { "CLASS_ID", "CLASS_NAME" }) });
                ImplementarSeleccionMultipleDeUnaVista(UiVistaClasesAsociadasZP);

                CargarOGuardarDisenios(UiVistaControlClasesAsociadasZP, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
                CargarOGuardarDisenios(UiVistaControlZonasDePosicionamiento, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
                ManejarFuncionDeSubFamilias(sender);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        #endregion

        #region Eventos de Pagina

        #region Zona De Posicionamiento

        private void UiLista_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (e.Button.Tag == null) return;
                switch (e.Button.Tag.ToString())
                {
                    case "UiBtnRefrescarListaBodegas":
                        UsuarioDeseaObtenerBodegas?.Invoke(null, null);
                        break;
                    case "UiBtnRefrescarListaClasesDisponibles":
                        UsuarioDeseaObtenerClasesDisponibles?.Invoke(null, null);
                        break;
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        private void UiBotonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaZP.ExpandAllGroups();
        }

        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaZP.CollapseAllGroups();
        }

        private void UiBotonExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ExportarVista(UiVistaZP, true, ExportarA.Excel);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiBotonBajarPlantilla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DescargarPlantilla();
        }

        private void UiBotonSubirPlantilla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                CargarPlantilla();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }

        }

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var indice = UiVistaZP.FocusedRowHandle;
                UsuarioDeseaObtenerZonasDePosicionamiento?.Invoke(null, null);
                UiVistaZP.FocusedRowHandle = indice;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiVistaZP_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;
                var indice = e.RowHandle;
                var registro = (ZonaDePosicionamiento)UiVistaZP.GetRow(e.RowHandle);
                registro.MANDATORY = (bool)e.Value;
                UsuarioDeseaGrabarZonasDePosicionamiento?.Invoke(null, new PosicionamientoArgumento { ZonaDePosicionamiento = registro });
                ZonasDePosicionamientoSeleccionado = registro;
                UIEtiquetaZona.Text = ZonasDePosicionamientoSeleccionado.ZONE;
                UsuarioDeseaObtenerClasesAsociadas?.Invoke(null, null);
                UsuarioDeseaObtenerClasesDisponibles?.Invoke(null, null);
                UiVistaZP.FocusedRowHandle = indice;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiVistaZP_Click(object sender, EventArgs e)
        {
            try
            {
                var indice = UiVistaZP.FocusedRowHandle;
                if (indice < 0) return;
                var registro = (ZonaDePosicionamiento)UiVistaZP.GetRow(indice);
                ZonasDePosicionamientoSeleccionado = registro;
                UIEtiquetaZona.Text = ZonasDePosicionamientoSeleccionado.ZONE;
                UsuarioDeseaObtenerClasesAsociadas?.Invoke(null, null);
                UsuarioDeseaObtenerClasesDisponibles?.Invoke(null, null);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        #endregion

        #region Zonas de Posicionamiento por Clases

        private void UiBotonExpandirZC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaClasesAsociadasZP.ExpandAllGroups();
        }

        private void UiBotonContraerZC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaClasesAsociadasZP.CollapseAllGroups();
        }

        private void UiBotonExportalExcelZP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ExportarVista(UiVistaClasesAsociadasZP, true, ExportarA.Excel);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiBotonRefrescarZP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseaObtenerClasesAsociadas?.Invoke(null, null);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }

        }

        private void UiBotonAgregarZP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseaAgregarClases?.Invoke(null, null);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiBotonEliminarZP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseaQuitarClases?.Invoke(null, null);

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        #endregion

        private void DescargarPlantilla()
        {
            try
            {
                using (var dialogoParaGuardar = new XtraSaveFileDialog())
                {
                    dialogoParaGuardar.Title = "Guardar en...";
                    dialogoParaGuardar.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
                    dialogoParaGuardar.FilterIndex = 2;
                    dialogoParaGuardar.RestoreDirectory = true;

                    if (dialogoParaGuardar.ShowDialog() != DialogResult.OK) return;

                    var libroDeTrabajo = new XLWorkbook();
                    var WorkSheetNombre = "Familia";
                    var parametroUseSubFamily = Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.UseMaterialSubFamily) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.MaterialSubFamily));
                    if (parametroUseSubFamily != null && int.Parse(parametroUseSubFamily.VALUE) == (int)SiNo.Si)
                    {
                        WorkSheetNombre = "Sub-familia";
                    }
                    var hoja = libroDeTrabajo.Worksheets.Add(WorkSheetNombre);

                    GenerarHojaDeClase(hoja, 1, 1, 5);

                    if (File.Exists(dialogoParaGuardar.FileName))
                    {
                        File.Delete(dialogoParaGuardar.FileName);
                    }

                    libroDeTrabajo.SaveAs(dialogoParaGuardar.FileName);



                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 3000;
                    args.Caption = "Operación exitosa";
                    args.Text = "Archivo generado exitósamente, ¿Desea abrir el archivo?";
                    args.Buttons = new[] { DialogResult.Yes, DialogResult.No };
                    args.Icon = System.Drawing.SystemIcons.Question;
                    args.DefaultButtonIndex = 0;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    if (XtraMessageBox.Show(args) == DialogResult.Yes)
                        Process.Start(dialogoParaGuardar.FileName);
                }
            }
            catch (Exception e)
            {
                InteraccionConUsuarioServicio.Alerta($"Error al descargar la plantilla: {e.Message}");
            }
        }

        private void GenerarHojaDeClase(IXLWorksheet hoja, int inicioEncabezadoX, int inicioEncabezadoY, int numeroDeFilas)
        {
            try
            {
                string familiaTexto = "Familia";
                var parametroUseSubFamily = Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.UseMaterialSubFamily) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.MaterialSubFamily));
                if (parametroUseSubFamily != null && int.Parse(parametroUseSubFamily.VALUE) == (int)SiNo.Si)
                {
                    familiaTexto = "Sub-familia";
                }

                var columnas = new[] { "Bodega", "Zona", "Mandatorio", familiaTexto };
                for (var index = 0; index < columnas.Length; ++index)
                {
                    hoja.Cell(inicioEncabezadoX, inicioEncabezadoY + index).Value = columnas[index];
                    hoja.Cell(inicioEncabezadoX, inicioEncabezadoY + index).Style.Font.Bold = true;
                    hoja.Cell(inicioEncabezadoX, inicioEncabezadoY + index).Style.Fill.BackgroundColor = XLColor.BabyBlueEyes;
                    hoja.Cell(inicioEncabezadoX, inicioEncabezadoY + index).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    hoja.Column(index + 1).Width = columnas[index].Length * 3;
                }
                var listaTipos = new List<string>();
                listaTipos.Add("No");
                hoja.Cell("BZ" + (1)).Value = "No";
                listaTipos.Add("Si");
                hoja.Cell("BZ" + (2)).Value = "Si";

                // Bodega
                hoja.Range($"A2:A{numeroDeFilas}").SetDataType(XLCellValues.Text);
                hoja.Range($"A2:A{numeroDeFilas}").Value = "";
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().IgnoreBlanks = false;
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().InCellDropdown = false;
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().AllowedValues = XLAllowedValues.TextLength;
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().TextLength.Between(1, 25);
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().InputTitle = "Obligatorio";
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().InputMessage = "Debe ingresar un máximo de 25 caracteres.";
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().ShowInputMessage = true;
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().ErrorTitle = "Obligatorio";
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().ErrorMessage = "Debe ingresar un máximo de 50 caracteres.";
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().ErrorStyle = XLErrorStyle.Stop;
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().ShowErrorMessage = true;

                // Zona
                hoja.Range($"B2:B{numeroDeFilas}").SetDataType(XLCellValues.Text);
                hoja.Range($"B2:B{numeroDeFilas}").Value = "";
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().IgnoreBlanks = false;
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().InCellDropdown = false;
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().AllowedValues = XLAllowedValues.TextLength;
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().TextLength.Between(1, 50);
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().InputTitle = "Obligatorio";
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().InputMessage = "Debe ingresar un máximo de 250 caracteres.";
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().ShowInputMessage = true;
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().ErrorTitle = "Obligatorio";
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().ErrorMessage = "Debe ingresar un máximo de 250 caracteres.";
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().ErrorStyle = XLErrorStyle.Stop;
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().ShowErrorMessage = true;

                // Mandatorio
                hoja.Range($"C2:C{numeroDeFilas}").SetDataType(XLCellValues.Text);
                hoja.Range($"C2:C{numeroDeFilas}").Value = "No";
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().IgnoreBlanks = false;
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().InCellDropdown = false;
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().AllowedValues = XLAllowedValues.List;
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().List(hoja.Range("BZ1:BZ" + listaTipos.Count));
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().InputTitle = "Obligatorio";
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().InputMessage = "Debe seleccionar una opción.";
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().ShowInputMessage = true;
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().ErrorTitle = "Obligatorio";
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().ErrorMessage = "Debe seleccionar una opción.";
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().ErrorStyle = XLErrorStyle.Stop;
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().ShowErrorMessage = true;

                // Familia
                hoja.Range($"D2:D{numeroDeFilas}").SetDataType(XLCellValues.Number);
                hoja.Range($"D2:D{numeroDeFilas}").Value = null;
                hoja.Range($"D2:D{numeroDeFilas}").SetDataValidation().IgnoreBlanks = false;
                hoja.Range($"D2:D{numeroDeFilas}").SetDataValidation().InCellDropdown = false;
                hoja.Range($"D2:D{numeroDeFilas}").SetDataValidation().AllowedValues = XLAllowedValues.WholeNumber;
                hoja.Range($"D2:D{numeroDeFilas}").SetDataValidation().WholeNumber.EqualOrGreaterThan(1);
                hoja.Range($"D2:D{numeroDeFilas}").SetDataValidation().InputTitle = "Obligatorio";
                hoja.Range($"D2:D{numeroDeFilas}").SetDataValidation().InputMessage = "Debe de ingresar un número mayor o igual a cero.";
                hoja.Range($"D2:D{numeroDeFilas}").SetDataValidation().ShowInputMessage = true;
                hoja.Range($"D2:D{numeroDeFilas}").SetDataValidation().ErrorTitle = "Obligatorio";
                hoja.Range($"D2:D{numeroDeFilas}").SetDataValidation().ErrorMessage = "Debe de ingresar un número mayor o igual a cero.";
                hoja.Range($"D2:D{numeroDeFilas}").SetDataValidation().ErrorStyle = XLErrorStyle.Stop;
                hoja.Range($"D2:D{numeroDeFilas}").SetDataValidation().ShowErrorMessage = true;

                var rngTable = hoja.Range(
                    hoja.Cell(inicioEncabezadoX, inicioEncabezadoY),
                    hoja.Cell(inicioEncabezadoX + (numeroDeFilas - 1), inicioEncabezadoY + columnas.Length - 1)
                );

                var excelTable = rngTable.CreateTable("Clases");
                excelTable.ShowAutoFilter = false;
            }
            catch (Exception e)
            {

                InteraccionConUsuarioServicio.Alerta($"Error al formar la hoja de clases: {e.Message}");
            }
        }


        private void CargarPlantilla()
        {
            try
            {
                using (var dialogoParaAbrir = new XtraOpenFileDialog())
                {
                    dialogoParaAbrir.Title = "Cargar ...";
                    dialogoParaAbrir.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
                    dialogoParaAbrir.FilterIndex = 2;
                    dialogoParaAbrir.RestoreDirectory = true;

                    if (dialogoParaAbrir.ShowDialog() != DialogResult.OK) return;
                    var libroDeTrabajo = new XLWorkbook(dialogoParaAbrir.FileName);

                    IXLWorksheet hoja;
                    var existeHoja = false;

                    string familiaTexto = "Familia";
                    var parametroUseSubFamily = Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.UseMaterialSubFamily) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.MaterialSubFamily));
                    if (parametroUseSubFamily != null && int.Parse(parametroUseSubFamily.VALUE) == (int)SiNo.Si)
                    {
                        familiaTexto = "Sub-familia";
                    }
                    existeHoja = libroDeTrabajo.TryGetWorksheet(familiaTexto, out hoja);
                    var listaZonaDePosicionamientos = new List<ZonaDePosicionamiento>();
                    if (existeHoja)
                    {
                        var listaDeErrores = ObtenerListaDeClasesDesdeXlsx(hoja, out listaZonaDePosicionamientos);
                        if (listaDeErrores.Count > 0)
                        {
                            InteraccionConUsuarioServicio.MensajeListaDeErrorDialogo(listaDeErrores);
                            return;
                        }
                    }

                    if (listaZonaDePosicionamientos.Count == 0)
                    {
                        InteraccionConUsuarioServicio.Alerta("El formato del archivo es incorrecto o está vacio.");
                        return;
                    }

                    UsuarioDeseaCargarPlantilla?.Invoke(null, new PosicionamientoArgumento
                    {
                        XmlZonaPosicionamiento = Xml.ConvertListToXml(listaZonaDePosicionamientos)
                    });

                }
            }
            catch (Exception e)
            {
                InteraccionConUsuarioServicio.Alerta($"Error al cargar la plantilla: {e.Message}");
            }
        }

        private List<string> ObtenerListaDeClasesDesdeXlsx(IXLWorksheet hoja, out List<ZonaDePosicionamiento> listaZonaDePosicionamientos)
        {
            var listaDeErrores = new List<string>();
            listaZonaDePosicionamientos = new List<ZonaDePosicionamiento>();
            try
            {
                // Los indices siempre son 1, 2, 3 y 4 porque son las columnas del XLSX generado en la descarga de plantilla, la cual es la aceptada para la carga.
                const int indiceBodegas = 1;
                const int indiceZona = 2;
                const int indiceMandatorio = 3;
                const int indiceFamilia = 4;

                // Almacena los registros de la plantilla en TablaIXL
                IXLTable tableClass = hoja.Table("Clases");

                var cantidadFilas = tableClass.RowCount();

                // Obtiene la fila de los encabezados
                var primeraFilaUsada = tableClass.FirstRowUsed();
                var fila = primeraFilaUsada.RowUsed();

                // Baja una fila para leer la data
                fila = fila.RowBelow();
                var indice = 2;

                // Recorre las filas de la tabla sin contar el encabezado.
                for (int i = 1; i < cantidadFilas; i++)
                {
                    // Valida que las columnas tengan data

                    if (string.IsNullOrEmpty(fila.Cell(indiceBodegas).GetString()) || string.IsNullOrEmpty(fila.Cell(indiceZona).GetString()) || string.IsNullOrEmpty(fila.Cell(indiceMandatorio).GetString()) ||  string.IsNullOrEmpty(fila.Cell(indiceFamilia).GetString()))
                    {
                        var mensaje = $"La fila No.{indice} tiene campos vacios.";
                        listaDeErrores.Add(mensaje);
                    }
                    else
                    {
                        var zonaPosicionamiento = new ZonaDePosicionamiento
                        {

                            WAREHOUSE_CODE = fila.Cell(indiceBodegas).GetString()
                        ,
                            ZONE = fila.Cell(indiceZona).GetString()
                        ,
                            MANDATORY = (fila.Cell(indiceMandatorio).GetString().Equals("Si"))
                        ,
                            FAMILY = int.Parse(fila.Cell(indiceFamilia).GetString())
                        };
                        Console.WriteLine(zonaPosicionamiento);
                        // Agrega las clases encontradas en el XLSX a la lista de clases
                        listaZonaDePosicionamientos.Add(zonaPosicionamiento);
                    }

                    // Baja una fila para continuar leyendo el XLSX
                    fila = fila.RowBelow();
                    indice++;
                }

            }
            catch (Exception e)
            {
                InteraccionConUsuarioServicio.Alerta($"Error al leer la hoja de Familia: {e.Message}");
            }
            return listaDeErrores;
        }

        private void ManejarFuncionDeSubFamilias(object sender)
        {
            var parametroUseSubFamily = Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.UseMaterialSubFamily) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.MaterialSubFamily));
            if (parametroUseSubFamily != null && int.Parse(parametroUseSubFamily.VALUE) == (int)SiNo.Si)
            {
                UiColFamiliasZP.Caption = "Sub-familias asociadas";
                UiCalFamiliaZP.Caption = "Sub-familia";
                UiColCodigoClaseZP.Caption = "Sub-familia";
                labelControl1.Text = "Sub-familias";

                UiListaClasesDesponiblesZP.Location = new System.Drawing.Point(75, 56);
                UiListaClasesDesponiblesZP.Width = 510;
            }            
        }

        #endregion
    }
}