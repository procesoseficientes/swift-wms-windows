
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
using DevExpress.XtraPivotGrid;
using MobilityScm.Modelo.Tipos;

namespace MobilityScm.Modelo.Vistas
{
    public class VistaBaseDeveExpress : XtraForm
    {
        internal void CargarOGuardarDisenios(DevExpress.XtraPivotGrid.PivotGridControl control, bool guardar, string usuario, string nombreVista)
        {
            string direccion;
            if (guardar)
            {


                direccion = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\{control.Name}{nombreVista}{usuario}.xml";
                control.SaveLayoutToXml(direccion);
            }
            else
            {
                direccion = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\{control.Name}{nombreVista}{usuario}.xml";
                if (File.Exists(direccion))
                {
                    control.RestoreLayoutFromXml(direccion);
                }

            }
        }

        internal void CargarOGuardarDisenios(DevExpress.XtraGrid.GridControl control, bool guardar, string usuario, string nombreVista)
        {
            string direccion;
            if (guardar)
            {


                direccion = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\{control.Name}{nombreVista}{usuario}.xml";
                control.MainView.SaveLayoutToXml(direccion);
            }
            else
            {
                direccion = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\{control.Name}{nombreVista}{usuario}.xml";
                if (File.Exists(direccion))
                {
                    control.MainView.RestoreLayoutFromXml(direccion);
                }

            }
        }

        internal void CargarOGuardarDisenios(DevExpress.XtraGrid.Views.Grid.GridView control, bool guardar, string usuario, string nombreVista)
        {
            string direccion;
            if (guardar)
            {


                direccion = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\{control.Name}{nombreVista}{usuario}.xml";
                control.SaveLayoutToXml(direccion);
            }
            else
            {
                direccion = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\{control.Name}{nombreVista}{usuario}.xml";
                if (File.Exists(direccion))
                {
                    control.RestoreLayoutFromXml(direccion);
                }

            }
        }

        internal void CargarOGuardarDisenios(LayoutControl control, bool guardar, string usuario, string nombreVista)
        {
            string direccion;
            if (guardar)
            {


                direccion = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\{control.Name}{nombreVista}{usuario}.xml";
                control.SaveLayoutToXml(direccion);
            }
            else
            {
                direccion = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\{control.Name}{nombreVista}{usuario}.xml";
                if (File.Exists(direccion))
                {
                    control.RestoreLayoutFromXml(direccion);
                }

            }
        }

        internal bool TieneSeleccionadoUnaFilaEnLaVista(GridView vista)
        {
            return vista.FocusedRowHandle >= 0;
        }

        internal object ObtenerFilaSelecciondaDeLaVista(GridView vista)
        {
            return vista.GetFocusedRow();
        }

        public static List<T> GetFilteredData<T>(ColumnView view)
        {
            List<T> resp = new List<T>();
            int currentRowHandle = view.GetVisibleRowHandle(0);
            while (currentRowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                if (view.GetRow(currentRowHandle)?.GetType() == typeof(T))
                {
                    resp.Add((T)view.GetRow(currentRowHandle));
                }

                currentRowHandle = view.GetNextVisibleRow(currentRowHandle);
            }
            return resp;
        }

        #region DeveExpress

        #region SearchLookUpEdit

        public class ObjetoParaGuardarEnVista
        {
            public bool UsuarioSeleccionoListaCompleta { get; set; }

            public string NombreDelControlDeLista { get; set; }
            public string[] ListaDeCamposAMostrar { get; set; }

        }

        internal void ImplementarSeleccionMultipleDeUnaLista(SearchLookUpEdit lista, ObjetoParaGuardarEnVista objeto)
        {
            var vista = lista.Properties.View;
            lista.CustomDisplayText += UiLista_CustomDisplayText;
            objeto.NombreDelControlDeLista = lista.Name;
            ImplementarSeleccionMultipleDeUnaVista(vista, objeto);
        }

        private void UiLista_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            var lista = sender as SearchLookUpEdit;
            if (lista == null)
                return;

            var vista = lista.Properties.View;
            if (string.IsNullOrEmpty(((ObjetoParaGuardarEnVista)vista.Tag).NombreDelControlDeLista)) return;
            e.DisplayText = ObtenerTextoAMostrarEnLaLista(((ObjetoParaGuardarEnVista)vista.Tag).ListaDeCamposAMostrar, vista);
        }

        internal void ImplementarSeleccionMultipleDeUnaVista(GridView vista, ObjetoParaGuardarEnVista objeto = null)
        {
            if (objeto == null)
            {
                objeto = new ObjetoParaGuardarEnVista();
            }
            vista.Tag = objeto;
            vista.MouseUp += Vista_MouseUp;
            vista.SelectionChanged += Vista_SelectionChanged;
            vista.BeforeLeaveRow += Vista_BeforeLeaveRow;
            vista.ColumnFilterChanged += Vista_ColumnFilterChanged;
        }

        private void Vista_MouseUp(object sender, MouseEventArgs e)
        {
            GridView vista = sender as GridView;
            if (vista == null)
                return;

            GridHitInfo hi = vista.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) &&
                hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                ((ObjetoParaGuardarEnVista)vista.Tag).UsuarioSeleccionoListaCompleta = true;
            }
        }

        private void Vista_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var vista = sender as GridView;
            if (vista == null)
                return;
            var objetoParaGuardarEnVista = ((ObjetoParaGuardarEnVista)vista.Tag);
            if (e.ControllerRow >= 0)
            {
                var registro = (dynamic)vista.GetRow(e.ControllerRow);
                registro.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (objetoParaGuardarEnVista.UsuarioSeleccionoListaCompleta)
                {
                    for (var i = 0; i < vista.RowCount; i++)
                    {
                        var registro = (dynamic)vista.GetRow(i);
                        if (registro == null) continue;
                        registro.IS_SELECTED = (vista.SelectedRowsCount != 0);
                    }
                    ((ObjetoParaGuardarEnVista)vista.Tag).UsuarioSeleccionoListaCompleta = false;
                }
            }
            if (objetoParaGuardarEnVista == null) return;
            if (string.IsNullOrEmpty(objetoParaGuardarEnVista.NombreDelControlDeLista)) return;
            var edit = (SearchLookUpEdit)Controls.Find(objetoParaGuardarEnVista.NombreDelControlDeLista, true).FirstOrDefault();
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarEnLaLista(objetoParaGuardarEnVista.ListaDeCamposAMostrar, vista);
        }

        private void Vista_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            var vista = sender as GridView;
            if (vista == null)
                return;
            RecargarSeleccionDeVista(vista);
        }

        private void Vista_ColumnFilterChanged(object sender, EventArgs e)
        {
            var vista = sender as GridView;
            if (vista == null)
                return;
            RecargarSeleccionDeVista(vista);
        }

        private string ObtenerTextoAMostrarEnLaLista(string[] listaDeCamposAMostrar, GridView vista)
        {
            if (listaDeCamposAMostrar == null) return "";

            dynamic registros = vista.DataSource;
            if (registros == null) return "";
            var cadena = new StringBuilder();
            foreach (dynamic resultado in registros)
            {
                if (!resultado.IS_SELECTED) continue;
                if (cadena.Length > 0)
                {
                    cadena.Append(",");
                }

                var contador = 0;
                foreach (var campo in listaDeCamposAMostrar)
                {
                    if (contador > 0)
                    {
                        cadena.Append("|");
                    }
                    cadena.Append(resultado.GetType().GetProperty(campo).GetValue(resultado, null));
                    contador += 1;
                }

            }
            return cadena.ToString();
        }

        private void RecargarSeleccionDeVista(GridView vista)
        {
            for (var i = 0; i < vista.RowCount; i++)
            {
                var registro = (dynamic)vista.GetRow(i);
                if (registro == null) continue;
                if (registro.IS_SELECTED)
                {
                    vista.SelectRow(i);
                }
            }
        }



        #endregion

        #region GridView

        public void ExportarVista(GridView vista, bool preguntarSiDeseaAbrirDocumento, ExportarA tipo)
        {
            if (vista.DataSource == null) return;
            if (vista.RowCount <= 0) return;

            using (var dialogoParaGuardar = new XtraSaveFileDialog())
            {
                dialogoParaGuardar.Title = "Guardar en...";
                switch (tipo)
                {
                    case ExportarA.Excel:
                        dialogoParaGuardar.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
                        break;
                    case ExportarA.Pdf:
                        dialogoParaGuardar.Filter = @"Archivos de pdf (*.pdf)";
                        break;
                    default:
                        dialogoParaGuardar.Filter = @"Archivos de word (*.docx)|*.docx";
                        break;
                }

                if (dialogoParaGuardar.ShowDialog() != DialogResult.OK) return;
                switch (tipo)
                {
                    case ExportarA.Excel:
                        vista.ExportToXlsx(dialogoParaGuardar.FileName);
                        break;
                    case ExportarA.Pdf:
                        vista.ExportToPdf(dialogoParaGuardar.FileName);
                        break;
                    default:
                        vista.ExportToDocx(dialogoParaGuardar.FileName);
                        break;
                }

                if (!preguntarSiDeseaAbrirDocumento) return;
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.Caption = "Documento";
                args.Text = "¿Desea abrir el documento?";
                args.Buttons = new[] { DialogResult.Yes, DialogResult.No };
                args.Icon = System.Drawing.SystemIcons.Question;
                args.DefaultButtonIndex = 1;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                if (XtraMessageBox.Show(args) == DialogResult.Yes)
                    Process.Start(dialogoParaGuardar.FileName);
            }
        }

        internal void MostrarListaDeErroresDialogo(List<string> listaErrores)
        {
            XtraDialog.Show(new LoginUserControl(listaErrores), "Lista de Errores", MessageBoxButtons.OK);
        }

        public class LoginUserControl : XtraUserControl
        {
            public LoginUserControl(List<string> listaErrores)
            {
                var list = new ListBoxControl();
                list.Dock = DockStyle.Fill;
                foreach (var error in listaErrores)
                {
                    list.Items.Add(error);
                }

                this.Controls.Add(list);
                this.Height = 250;
                this.Dock = DockStyle.Top;
            }
        }

        #endregion

        #region Form

        internal void GuardarOCargarDiseniosDeControles(Control control, string usuarioId, bool guardar, string nombreVista)
        {
            var resultadoControles = ObtenerTodosLosControlesPorTipo(control, typeof(GridControl));

            foreach (var resultadoControl in resultadoControles)
            {
                CargarOGuardarDisenios(((GridControl)resultadoControl), guardar, usuarioId, nombreVista);
            }

            resultadoControles = ObtenerTodosLosControlesPorTipo(control, typeof(GridLookUpEdit));

            foreach (var resultadoControl in resultadoControles)
            {
                var gridLookUpEdit = (GridLookUpEdit)resultadoControl;
                CargarOGuardarDisenios((GridView)gridLookUpEdit.Properties.PopupView, guardar, usuarioId, nombreVista);
            }

            resultadoControles = ObtenerTodosLosControlesPorTipo(control, typeof(SearchLookUpEdit));

            foreach (var resultadoControl in resultadoControles)
            {
                var searchLookUpEdit = (SearchLookUpEdit)resultadoControl;
                CargarOGuardarDisenios((GridView)searchLookUpEdit.Properties.PopupView, guardar, usuarioId, nombreVista);
            }

            resultadoControles = ObtenerTodosLosControlesPorTipo(control, typeof(PivotGridControl));

            foreach (var resultadoControl in resultadoControles)
            {
                CargarOGuardarDisenios(((PivotGridControl)resultadoControl), guardar, usuarioId, nombreVista);
            }

            resultadoControles = ObtenerTodosLosControlesPorTipo(control, typeof(LayoutControl));

            foreach (var resultadoControl in resultadoControles)
            {
                CargarOGuardarDisenios(((LayoutControl)resultadoControl), guardar, usuarioId, nombreVista);
            }
        }

        public IEnumerable<Control> ObtenerTodosLosControlesPorTipo(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            var enumerable = controls as Control[] ?? controls.ToArray();
            return enumerable.SelectMany(ctrl => ObtenerTodosLosControlesPorTipo(ctrl, type))
                .Concat(enumerable)
                .Where(c => c.GetType() == type);
        }

        #endregion

        #region ControlesGenerales

        internal void EditarTextoCodigo(TextEdit textoControl, string texto, bool habilitar)
        {
            if (habilitar)
            {
                textoControl.Text = texto;
                textoControl.ReadOnly = false;
                textoControl.BackColor = Color.Transparent;
            }
            else
            {
                textoControl.Text = texto;
                textoControl.ReadOnly = true;
                textoControl.BackColor = Color.LightYellow;
            }
        }

        #endregion

        #endregion
    }
}
