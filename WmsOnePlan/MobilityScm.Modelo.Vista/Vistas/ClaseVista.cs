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
using ClosedXML.Excel;
using DevExpress.XtraVerticalGrid.Rows;
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
    public partial class ClaseVista : VistaBase, IClaseVista
    {
        #region Eventos
        public event EventHandler<ClaseArgumento> UsuarioDeseaGuardarClase;
        public event EventHandler<ClaseArgumento> UsuarioDeseaEliminarClase;
        public event EventHandler<ClaseArgumento> UsuarioDeseaAsociarClases;
        public event EventHandler<ClaseArgumento> UsuarioDeseaDesasociarClases;
        public event EventHandler<ClaseArgumento> UsuarioDeseaObtenerClase;
        public event EventHandler<ClaseArgumento> UsuarioDeseaObtenerClases;
        public event EventHandler<ClaseArgumento> UsuarioDeseaObtenerClasesDisponiblesAAsociar;
        public event EventHandler<ClaseArgumento> UsuarioDeseaObtenerTiposDeClases;
        public event EventHandler<ClaseArgumento> UsuarioDeseaCargarClasesPorXml;
        public event EventHandler VistaTerminoDeCargar;
        public event EventHandler VistaCargandosePorPrimeraVez;
        #endregion

        #region Propiedades

        public IList<Clase> Clases
        {
            get
            {
                return (IList<Clase>)UiVistaClase.DataSource;
            }
            set
            {
                UiContenedorVistaClase.DataSource = value;
            }
        }

        public Clase Clase
        {
            get
            {
                return (Clase)UiPropiedadClase.SelectedObject;
            }
            set
            {
                UiPropiedadClase.SelectedObject = value;
            }
        }

        public IList<Entidades.Configuracion> Tipos
        {
            get
            {
                return (IList<Entidades.Configuracion>)PropiedadListaTipo.DataSource;
            }
            set
            {
                PropiedadListaTipo.DataSource = value;
            }
        }

        public IList<Clase> ClasesNoAsociadas
        {
            get
            {
                return (IList<Clase>)UiListaClasesParaRelacionar.Properties.DataSource;
            }
            set
            {
                UiListaClasesParaRelacionar.Properties.DataSource = value;
            }
        }

        public IList<Clase> ClasesAsociadas
        {
            get
            {
                return (IList<Clase>)UiVistaClaseAsociada.DataSource;
            }
            set
            {
                UiContenedorVistaRelacionDeClases.DataSource = value;
            }
        }

        private bool UsuarioSeleccionoListaClasesNoAsociadasCompleta { get; set; }

        private bool UsuarioSeleccionoListaClasesAsociadasCompleta { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        #endregion

        #region Contructor y Eventos de Carga
        public ClaseVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();

            Mvx.Ioc.RegisterType<IClaseServicio, ClaseServicio>();
            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();

            Mvx.Ioc.RegisterSingleton<IClaseVista, ClaseVista>(this);
            Mvx.Ioc.RegisterType<IClaseControlador, ClaseControlador>();
            Mvx.Ioc.Resolve<IClaseControlador>();
        }

        private void ClaseVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            CargarOGuardarDisenios(UiContenedorVistaClase, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            CargarOGuardarDisenios(UiContenedorVistaRelacionDeClases, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }

        private void ClaseVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiContenedorVistaClase, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            CargarOGuardarDisenios(UiContenedorVistaRelacionDeClases, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }
        #endregion

        #region Metodos

        private void LimpiarCampos()
        {
            Clase = new Clase();
            ClasesNoAsociadas  = new List<Clase>();
            ClasesAsociadas = new List<Clase>();
        }

        public void TerminoProceso(object mensaje, dynamic sender)
        {
            InteraccionConUsuarioServicio.MensajeExito(mensaje.ToString(), false);
            LimpiarCampos();
        }

        private string ObtenerTextoParaMostrarEnListaDeClasesPasaAsociar()
        {
            return ClasesNoAsociadas == null ? string.Empty : string.Join(",", ClasesNoAsociadas.Where(cl => cl.IS_SELECTED).Select(cl => cl.CLASS_NAME));
        }

        private void DescargarPlantilla()
        {
            try
            {
                var dialogoGuardar = new SaveFileDialog
                {
                    Filter = @"Excel xlsx (*.xlsx)|*.xlsx"
                    ,
                    FilterIndex = 2
                    ,
                    RestoreDirectory = true
                    ,
                    Title = @"Guardar plantilla"
                };

                if (dialogoGuardar.ShowDialog() != DialogResult.OK) return;
                var path = dialogoGuardar.FileName;
                var workbook = new XLWorkbook();
                var hojaClases = workbook.Worksheets.Add("Clases");

                GenerarHojaDeClase(hojaClases, 1, 1, 500);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                workbook.SaveAs(path);

                var result = MessageBox.Show(@"Archivo generado exitósamente, ¿Desea abrir el archivo?", @"Operación exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Process.Start(path);
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
                var columnas = new[] { "Nombre", "Descripción", "Tipo", "Prioridad" };

                for (var index = 0; index < columnas.Length; ++index)
                {
                    hoja.Cell(inicioEncabezadoX, inicioEncabezadoY + index).Value = columnas[index];
                    hoja.Cell(inicioEncabezadoX, inicioEncabezadoY + index).Style.Font.Bold = true;
                    hoja.Cell(inicioEncabezadoX, inicioEncabezadoY + index).Style.Fill.BackgroundColor = XLColor.BabyBlueEyes;
                    hoja.Cell(inicioEncabezadoX, inicioEncabezadoY + index).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    hoja.Column(index + 1).Width = columnas[index].Length * 3;
                }
                var listaTipos = Tipos;
                for (var index = 0; index < listaTipos.Count; ++index)
                {
                    hoja.Cell("BZ" + (index + 1)).Value = listaTipos[index].PARAM_NAME;
                }

                // Nombre
                hoja.Range($"A2:A{numeroDeFilas}").SetDataType(XLCellValues.Text);
                hoja.Range($"A2:A{numeroDeFilas}").Value = "";
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().IgnoreBlanks = false;
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().InCellDropdown = false;
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().AllowedValues = XLAllowedValues.TextLength;
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().TextLength.Between(1, 50);
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().InputTitle = "Obligatorio";
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().InputMessage = "Debe ingresar un máximo de 50 caracteres. De no tener este campo se ignorará el registro.";
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().ShowInputMessage = true;
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().ErrorTitle = "Obligatorio";
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().ErrorMessage = "Debe ingresar un máximo de 50 caracteres. De no tener este campo se ignorará el registro.";
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().ErrorStyle = XLErrorStyle.Stop;
                hoja.Range($"A2:A{numeroDeFilas}").SetDataValidation().ShowErrorMessage = true;

                // Descripción
                hoja.Range($"B2:B{numeroDeFilas}").SetDataType(XLCellValues.Text);
                hoja.Range($"B2:B{numeroDeFilas}").Value = "";
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().IgnoreBlanks = false;
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().InCellDropdown = false;
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().AllowedValues = XLAllowedValues.TextLength;
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().TextLength.Between(1, 250);
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().InputTitle = "Obligatorio";
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().InputMessage = "Debe ingresar un máximo de 250 caracteres. De no tener este campo se ignorará el registro.";
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().ShowInputMessage = true;
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().ErrorTitle = "Obligatorio";
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().ErrorMessage = "Debe ingresar un máximo de 250 caracteres. De no tener este campo se ignorará el registro.";
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().ErrorStyle = XLErrorStyle.Stop;
                hoja.Range($"B2:B{numeroDeFilas}").SetDataValidation().ShowErrorMessage = true;

                // Tipo
                hoja.Range($"C2:C{numeroDeFilas}").SetDataType(XLCellValues.Text);
                hoja.Range($"C2:C{numeroDeFilas}").Value = listaTipos[0].PARAM_NAME;
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().IgnoreBlanks = false;
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().InCellDropdown = true;
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().AllowedValues = XLAllowedValues.List;
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().List(hoja.Range("BZ1:BZ" + listaTipos.Count));
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().InputTitle = "Obligatorio";
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().InputMessage = "Debe seleccionar una opción.";
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().ShowInputMessage = true;
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().ErrorTitle = "Obligatorio";
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().ErrorMessage = "Debe seleccionar una opción.";
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().ErrorStyle = XLErrorStyle.Stop;
                hoja.Range($"C2:C{numeroDeFilas}").SetDataValidation().ShowErrorMessage = true;

                // Prioridad
                hoja.Range($"D2:D{numeroDeFilas}").SetDataType(XLCellValues.Number);
                hoja.Range($"D2:D{numeroDeFilas}").Value = 1;
                hoja.Range($"D2:D{numeroDeFilas}").SetDataValidation().IgnoreBlanks = false;
                hoja.Range($"D2:D{numeroDeFilas}").SetDataValidation().InCellDropdown = false;
                hoja.Range($"D2:D{numeroDeFilas}").SetDataValidation().AllowedValues = XLAllowedValues.WholeNumber;
                hoja.Range($"D2:D{numeroDeFilas}").SetDataValidation().WholeNumber.EqualOrGreaterThan(0);
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

                var excelTable = rngTable.CreateTable("Material");
                excelTable.ShowAutoFilter = false;
            }
            catch (Exception e)
            {

                InteraccionConUsuarioServicio.Alerta($"Error al formar la hoja de clases: {e.Message}");
            }
        }

        private void CargarPlantilla(object sender)
        {
            try
            {
                var clases = new List<Clase>();

                var dialogo = new OpenFileDialog()
                {
                    Filter = @"Excel xlsx (*.xlsx)|*.xlsx"
                    ,
                    DefaultExt = "xlsx"
                    ,
                    FilterIndex = 2
                    ,
                    RestoreDirectory = true
                    ,
                    Title = @"Cargar plantilla"
                };

                if (dialogo.ShowDialog() != DialogResult.OK) return;
                var workbook = new XLWorkbook(dialogo.FileName);
                IXLWorksheet hoja;
                var existeHoja = false;

                existeHoja = workbook.TryGetWorksheet("Clases", out hoja);

                if (existeHoja)
                {
                    ObtenerListaDeClasesDesdeXlsx(hoja, out clases);
                }

                if (clases.Count == 0)
                {
                    InteraccionConUsuarioServicio.Alerta("El formato del archivo es incorrecto o está vacio.");
                    return;
                }

                UsuarioDeseaCargarClasesPorXml?.Invoke(sender, new ClaseArgumento
                {
                    Clases = clases
                    ,
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                });
            }
            catch (Exception e)
            {
                InteraccionConUsuarioServicio.Alerta($"Error al cargar la plantilla: {e.Message}");
            }
        }

        private void ObtenerListaDeClasesDesdeXlsx(IXLWorksheet hoja, out List<Clase> clases)
        {
            clases = new List<Clase>();
            try
            {
                // Los indices siempre son 1, 2, 3 y 4 porque son las columnas del XLSX generado en la descarga de plantilla, la cual es la aceptada para la carga.
                const int indiceNombres = 1;
                const int indiceDescripciones = 2;
                const int indiceTipos = 3;
                const int indicePrioridad = 4;

                // Obtiene la fila de los encabezados
                var primeraFilaUsada = hoja.FirstRowUsed();
                var fila = primeraFilaUsada.RowUsed();

                // Baja una fila para leer la data
                fila = fila.RowBelow();

                // Recorre las filas hasta que encuentra una que este vacio el nombre.
                while (!fila.Cell(indiceNombres).IsEmpty())
                {
                    // Valida que las columnas tengan data
                    if (fila.Cell(indiceDescripciones).IsEmpty() || fila.Cell(indiceTipos).IsEmpty() || fila.Cell(indiceTipos).IsEmpty()) continue;

                    // Agrega las clases encontradas en el XLSX a la lista de clases
                    clases.Add(new Clase()
                    {
                        CLASS_NAME = fila.Cell(indiceNombres).GetString()
                        ,
                        CLASS_DESCRIPTION = fila.Cell(indiceDescripciones).GetString()
                        ,
                        CLASS_TYPE = fila.Cell(indiceTipos).GetString()
                        ,
                        PRIORITY = int.Parse(fila.Cell(indicePrioridad).GetString())
                    });

                    // Baja una fila para continuar leyendo el XLSX
                    fila = fila.RowBelow();
                }
            }
            catch (Exception e)
            {
                InteraccionConUsuarioServicio.Alerta($"Error al leer la hoja de Clases: {e.Message}");
            }
        }

        #endregion

        #region Eventos de Controles
        private void UiBotonRefrescarClases_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UsuarioDeseaObtenerClases?.Invoke(sender, new ClaseArgumento());
        }

        private void UiBotonExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiDialogoParaGuardar.DefaultExt = "xlsx";
            UiDialogoParaGuardar.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
            UiDialogoParaGuardar.FilterIndex = 2;
            UiDialogoParaGuardar.RestoreDirectory = true;
            UiDialogoParaGuardar.Title = @"Guardar Clases";

            if (UiDialogoParaGuardar.ShowDialog() == DialogResult.OK)
            {
                UiVistaClase.ExportToXlsx(UiDialogoParaGuardar.FileName);
            }
        }

        private void UiBotonNuevaClase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();
        }

        private void UiBotonGrabarClase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!UiPropiedadClase.PostEditor())
            {
                return;
            }

            if (Clase.CLASS_NAME == "" || Clase.CLASS_DESCRIPTION == "" || Clase.CLASS_TYPE == "" || Clase.PRIORITY <= 0)
            {
                MessageBox.Show("Todos los campos son obligatorios ", "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Clase.CREATED_BY = InteraccionConUsuarioServicio.ObtenerUsuario();
            Clase.LAST_UPDATED_BY = InteraccionConUsuarioServicio.ObtenerUsuario();

            UsuarioDeseaGuardarClase?.Invoke(sender,
                new ClaseArgumento
                {
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario(),
                    Clase = Clase
                });

        }

        private void UiBotonEliminarClase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clase.CLASS_ID <= 0) return;
            if (MessageBox.Show(@"¿Confirma eliminación?", @"Confirme acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UsuarioDeseaEliminarClase?.Invoke(sender, new ClaseArgumento { Clase = Clase });
            }
        }

        private void UiBotonDescargarPlantillaClase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DescargarPlantilla();
        }

        private void UiBotonCargarPlantillaClase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CargarPlantilla(sender);
        }

        private void UiBotonAsociarClases_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var clases = ClasesNoAsociadas.Where(c => c.IS_SELECTED).ToList();
            if (clases.Count > 0)
            {
                UsuarioDeseaAsociarClases?.Invoke(sender, new ClaseArgumento { Clases = clases, Clase = Clase });
            }
        }

        private void UiBotonDesasociarClases_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var clases = ClasesAsociadas.Where(c => c.IS_SELECTED).ToList();
            if (clases.Count > 0)
            {
                UsuarioDeseaDesasociarClases?.Invoke(sender, new ClaseArgumento { Clases = clases, Clase = Clase });
            }
        }

        private void UiVistaClase_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var clase = (Clase)UiVistaClase.GetRow(e.FocusedRowHandle);
            UsuarioDeseaObtenerClase?.Invoke(sender, new ClaseArgumento { Clase = clase });
        }

        private void UiVistaClase_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var clase = (Clase)UiVistaClase.GetRow(e.RowHandle);
            if (Clase.CLASS_ID != clase.CLASS_ID)
            {
                UsuarioDeseaObtenerClase?.Invoke(sender, new ClaseArgumento { Clase = clase });
            }
        }

        private void UiPropiedadClase_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            var filaActual = UiPropiedadClase.FocusedRow;
            
            if (e.Value.ToString().Length <= 0)
            {
                e.Valid = false;
                e.ErrorText = "Obligatorio";
                return;
            }
            switch (filaActual.Properties.FieldName)
            {
                case "CLASS_NAME":
                    if (e.Value.ToString().Length > 50)
                    {
                        e.Valid = false;
                        e.ErrorText = "La propiedad no puede tener mas de 50 caracteres.";
                    }
                    break;
                case "PRIORITY":
                    var prioridad = 0;
                    if (!int.TryParse(e.Value.ToString(), out prioridad) || prioridad <= 0)
                    {
                        e.Valid = false;
                        e.ErrorText = "Número inválido.";
                    }
                    break;
                case "CLASS_DESCRIPTION":
                    if (e.Value.ToString().Length > 250)
                    {
                        e.Valid = false;
                        e.ErrorText = "La propiedad no puede tener mas de 250 caracteres.";
                    }
                    break;
            }
        }

        private void propiedadListaTipo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void UiListaClasesParaRelacionar_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoParaMostrarEnListaDeClasesPasaAsociar();
        }

        private void UiVistaClasesParaRelacionar_MouseUp(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            if (view == null)
                return;
            var hi = view.CalcHitInfo(new Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaClasesNoAsociadasCompleta = true;
            }
        }

        private void UiVistaClasesParaRelacionar_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var clase = (Clase)UiVistaClasesParaRelacionar.GetRow(e.ControllerRow);
                clase.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaClasesNoAsociadasCompleta)
                {
                    for (var i = 0; i < UiVistaClasesParaRelacionar.RowCount; i++)
                    {
                        var clase = (Clase)UiVistaClasesParaRelacionar.GetRow(i);
                        if (clase == null) continue;
                        clase.IS_SELECTED = (UiVistaClasesParaRelacionar.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaClasesNoAsociadasCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoParaMostrarEnListaDeClasesPasaAsociar();
        }

        private void UiVistaClaseAsociada_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var clase = (Clase)UiVistaClaseAsociada.GetRow(e.ControllerRow);
                clase.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (!UsuarioSeleccionoListaClasesAsociadasCompleta) return;

                for (var i = 0; i < UiVistaClaseAsociada.RowCount; i++)
                {
                    var clase = (Clase)UiVistaClaseAsociada.GetRow(i);
                    if (clase == null) continue;
                    clase.IS_SELECTED = (UiVistaClaseAsociada.SelectedRowsCount != 0);
                }
                UsuarioSeleccionoListaClasesAsociadasCompleta = false;
            }
        }

        private void UiVistaClaseAsociada_MouseUp(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            if (view == null)
                return;
            var hi = view.CalcHitInfo(new Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaClasesAsociadasCompleta = true;
            }
        }


        #endregion

    }
}

