using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace MobilityScm.Modelo.Vistas
{
    public partial class CatalogoZonaVista : VistaBase, ICatalogoZonaVista
    {
        #region Eventos
        public event EventHandler UsuarioDeseaConsultarZonas;

        public event EventHandler<ZonaArgumento> UsuarioDeseaAgregarZona;

        public event EventHandler<ZonaArgumento> UsuarioDeseaActualizarZona;

        public event EventHandler<ZonaArgumento> UsuarioDeseaEliminarZona;

        public event EventHandler<ZonaArgumento> UsuarioDeseaConsultarZonasAsociadas;

        public event EventHandler<ZonaArgumento> UsuarioDeseaAsociarZonaDeReabastecimiento;

        public event EventHandler<ZonaArgumento> UsuarioDeseaDesasociarZonaDeReabastecimiento;

        public event EventHandler<ConsultaArgumento> UsuarioDeseaCargarBodegas;

        public event EventHandler UsuarioDeseaCargarLineasDePicking;

        public event EventHandler<ZonaArgumento> UsuarioDeseaConsultarZonasParaAsociar;
        #endregion

        #region Propiedades
        public IList<Zona> Zonas
        {
            get { return (IList<Zona>)UiGridPrincipalZona.DataSource; }
            set { UiGridPrincipalZona.DataSource = value; }
        }

        public IList<Zona> ZonaAsociadas
        {
            get { return (IList<Zona>)UiGridZonasDeReabastecimiento.DataSource; }
            set { UiGridZonasDeReabastecimiento.DataSource = value; }
        }

        public IList<Zona> ZonaAAsociar
        {
            get
            {
                return (IList<Zona>)UiLookUpEditZonasAAsignar.Properties.DataSource;
            }
            set { UiLookUpEditZonasAAsignar.Properties.DataSource = value; }
        }

        public IList<Entidades.Configuracion> LineasDePicking
        {
            get { return (IList<Entidades.Configuracion>)UiLookUpEditLinea.DataSource; }
            set
            {
                UiLookUpEditLinea.DataSource = value;
                UiLookUpEditLinea.PopulateColumns();
                UiLookUpEditLinea.Columns["PARAM_TYPE"].Visible = false;
                UiLookUpEditLinea.Columns["PARAM_GROUP"].Visible = false;
                UiLookUpEditLinea.Columns["PARAM_GROUP_CAPTION"].Visible = false;
                UiLookUpEditLinea.Columns["MONEY_VALUE"].Visible = false;
                UiLookUpEditLinea.Columns["NUMERIC_VALUE"].Visible = false;
                UiLookUpEditLinea.Columns["TEXT_VALUE"].Visible = false;
                UiLookUpEditLinea.Columns["DATE_VALUE"].Visible = false;
                UiLookUpEditLinea.Columns["RANGE_NUM_START"].Visible = false;
                UiLookUpEditLinea.Columns["RANGE_NUM_END"].Visible = false;
                UiLookUpEditLinea.Columns["RANGE_DATE_START"].Visible = false;
                UiLookUpEditLinea.Columns["RANGE_DATE_END"].Visible = false;
                UiLookUpEditLinea.Columns["SPARE1"].Visible = false;
                UiLookUpEditLinea.Columns["SPARE2"].Visible = false;
                UiLookUpEditLinea.Columns["IS_SELECTED"].Visible = false;

                UiLookUpEditLinea.Columns["PARAM_NAME"].Caption = "CODIGO";
                UiLookUpEditLinea.Columns["PARAM_CAPTION"].Caption = "LINEA";

            }
        }

        public IList<Bodega> Bodegas
        {
            get { return (IList<Bodega>)UiLookUpEditBodega.DataSource; }
            set
            {
                UiLookUpEditBodega.DataSource = value;
                UiLookUpEditBodega.PopulateColumns();

                UiLookUpEditBodega.Columns["COMMENTS"].Visible = false;
                UiLookUpEditBodega.Columns["ERP_WAREHOUSE"].Visible = false;
                UiLookUpEditBodega.Columns["ALLOW_PICKING"].Visible = false;
                UiLookUpEditBodega.Columns["DEFAULT_RECEPTION_LOCATION"].Visible = false;
                UiLookUpEditBodega.Columns["SHUNT_NAME"].Visible = false;
                UiLookUpEditBodega.Columns["WAREHOUSE_WEATHER"].Visible = false;
                UiLookUpEditBodega.Columns["WAREHOUSE_STATUS"].Visible = false;
                UiLookUpEditBodega.Columns["IS_3PL_WAREHUESE"].Visible = false;
                UiLookUpEditBodega.Columns["WAHREHOUSE_ADDRESS"].Visible = false;
                UiLookUpEditBodega.Columns["GPS_URL"].Visible = false;
                UiLookUpEditBodega.Columns["DISTRIBUTION_CENTER_ID"].Visible = false;
                UiLookUpEditBodega.Columns["ASSIGNED_TO"].Visible = false;
                UiLookUpEditBodega.Columns["IS_SELECTED"].Visible = false;


                UiLookUpEditBodega.Columns["WAREHOUSE_ID"].Caption = "CODIGO";
                UiLookUpEditBodega.Columns["NAME"].Caption = "BODEGA";

            }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        private readonly Zona _zonaPrincipal;

        private bool UsuarioSeleccionoListaZonasCompleta { get; set; }

        private bool UsuarioSeleccionoListaZonasAsociadas { get; set; }



        #endregion

        #region Eventos de Formulario
        public CatalogoZonaVista()
        {
            InitializeComponent();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();

            Mvx.Ioc.RegisterType<ICatalogoZonaServicio, CatalogoZonaServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();
            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();

            Mvx.Ioc.RegisterSingleton<ICatalogoZonaVista, CatalogoZonaVista>(this);
            Mvx.Ioc.RegisterType<ICatalogoZonaControlador, CatalogoZonaControlador>();
            Mvx.Ioc.Resolve<ICatalogoZonaControlador>();

            _zonaPrincipal = new Zona();
            InitZona();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Zona zonaPrincipal = (Zona)UiViewPrincipalZonas.GetRow(e.FocusedRowHandle);

            LoadZona(zonaPrincipal);
            RefreshZonas(sender);
        }

        private void UiBarButtonNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitZona();
        }

        private void UiBarButtonGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiPropertyGridZona.PostEditor();
            if (_zonaPrincipal.DESCRIPTION == "" || _zonaPrincipal.WAREHOUSE_CODE == "" || _zonaPrincipal.ZONE == "" || _zonaPrincipal.LINE_ID == "")
            {
                MessageBox.Show("Todos los campos son obligatorios ", "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_zonaPrincipal.ZONE_ID > 0)
                    UsuarioDeseaActualizarZona?.Invoke(
                        sender,
                        new ZonaArgumento() { Zona = _zonaPrincipal, ZonaAsociadaId = 0 });
                else
                    UsuarioDeseaAgregarZona?.Invoke(
                            sender,
                            new ZonaArgumento() { Zona = _zonaPrincipal, ZonaAsociadaId = 0 });
            }
        }

        private void UiBarButtonEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Confirma eliminacion?", "Confirme accion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_zonaPrincipal.ZONE_ID > 0)
                    UsuarioDeseaEliminarZona?.Invoke(
                    sender,
                        new ZonaArgumento() { Zona = _zonaPrincipal, ZonaAsociadaId = 0 });
                InitZona();
            }

        }

        private void UiBarButtonAsignar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (int rowHandle in UiViewZonasAAsignar.GetSelectedRows())
                UsuarioDeseaAsociarZonaDeReabastecimiento?.Invoke(
                    sender,
                    new ZonaArgumento() { Zona = _zonaPrincipal, ZonaAsociadaId = ((Zona)UiViewZonasAAsignar.GetRow(rowHandle)).ZONE_ID });
            RefreshZonas(sender);
        }

        private void UiBarButtonDesasignar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (int rowHandle in UiViewZonasDeReabastecimiento.GetSelectedRows())
                UsuarioDeseaDesasociarZonaDeReabastecimiento?.Invoke(
                    sender,
                    new ZonaArgumento() { Zona = _zonaPrincipal, ZonaAsociadaId = ((Zona)UiViewZonasDeReabastecimiento.GetRow(rowHandle)).ZONE_ID });
            RefreshZonas(sender);
        }

        private void CatalogoZonaVista_Load(object sender, EventArgs e)
        {
            UsuarioDeseaConsultarZonas?.Invoke(sender, e);
            UiViewPrincipalZonas.BestFitColumns();
            UsuarioSeleccionoListaZonasCompleta = false;
            UsuarioSeleccionoListaZonasAsociadas = false;
            UsuarioDeseaCargarBodegas?.Invoke(sender, null);
            UsuarioDeseaCargarLineasDePicking?.Invoke(sender, null);
        }



        #endregion

        #region Funciones de comportamiento


        private void RefreshZonas(object sender)
        {
            UsuarioDeseaConsultarZonasParaAsociar?.Invoke(
               sender,
               new ZonaArgumento() { Zona = _zonaPrincipal, ZonaAsociadaId = 0 });
            UsuarioDeseaConsultarZonasAsociadas?.Invoke(
                sender,
                new ZonaArgumento() { Zona = _zonaPrincipal, ZonaAsociadaId = 0 });
        }

        private void InitZona()
        {
            LoadZona(0, string.Empty, 0, string.Empty, false, string.Empty, string.Empty);

            ZonaAsociadas = new List<Zona>();
            ZonaAAsociar = new List<Zona>();
        }

        private void LoadZona(Zona zonaPrincipal)
        {
            if (zonaPrincipal != null)
            {
                LoadZona(zonaPrincipal.ZONE_ID, zonaPrincipal.ZONE, zonaPrincipal.RECEIVE_EXPLODED_MATERIALS,
                zonaPrincipal.DESCRIPTION, zonaPrincipal.IS_SELECTED, zonaPrincipal.LINE_ID, zonaPrincipal.WAREHOUSE_CODE);
            }

        }

        private void LoadZona(int zoneId, string zone, int receiveExplodedMaterials, string description,
            bool isSelected, string lineId, string warehouseCode)
        {
            _zonaPrincipal.ZONE_ID = zoneId;
            _zonaPrincipal.ZONE = zone;
            _zonaPrincipal.RECEIVE_EXPLODED_MATERIALS = receiveExplodedMaterials;
            _zonaPrincipal.DESCRIPTION = description;
            _zonaPrincipal.IS_SELECTED = isSelected;
            _zonaPrincipal.LINE_ID = lineId;
            _zonaPrincipal.WAREHOUSE_CODE = warehouseCode;

            UiPropertyGridZona.SelectedObject = null;
            UiPropertyGridZona.SelectedObject = _zonaPrincipal;
        }

        #endregion

        private void UiLookUpEditZonasAAsignar_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarZonaAAsociar();
        }

        private string ObtenerTextoAMostrarZonaAAsociar()
        {
            if (ZonaAAsociar == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in ZonaAAsociar.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(documento.DESCRIPTION);
            }
            return cadena.ToString();
        }

        private void UiViewZonasAAsignar_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiViewZonasAAsignar.RowCount; i++)
            {
                var documento = (Zona)UiViewZonasAAsignar.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiViewZonasAAsignar.SelectRow(i);
                }
            }
        }

        private void UiViewZonasAAsignar_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaZonasCompleta = true;
            }
        }

        private void UiViewZonasAAsignar_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (Zona)UiViewZonasAAsignar.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaZonasCompleta)
                {
                    for (var i = 0; i < UiViewZonasAAsignar.RowCount; i++)
                    {
                        var documento = (Zona)UiViewZonasAAsignar.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiViewZonasAAsignar.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaZonasCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarZonaAAsociar();
        }

        private void UiViewZonasDeReabastecimiento_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiViewZonasDeReabastecimiento.RowCount; i++)
            {
                var documento = (Zona)UiViewZonasDeReabastecimiento.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiViewZonasDeReabastecimiento.SelectRow(i);
                }
            }
        }

        private void UiViewZonasDeReabastecimiento_MouseUp(object sender, MouseEventArgs e)
        {

            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaZonasAsociadas = true;
            }
        }

        private void UiViewZonasDeReabastecimiento_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (Zona)UiViewZonasDeReabastecimiento.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaZonasAsociadas)
                {
                    for (var i = 0; i < UiViewZonasDeReabastecimiento.RowCount; i++)
                    {
                        var documento = (Zona)UiViewZonasDeReabastecimiento.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiViewZonasDeReabastecimiento.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaZonasAsociadas = false;
                }
            }

        }

        private void UiPropertyGridZona_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            var vGrid = sender as PropertyGridControl;
            if (vGrid.FocusedRow.Name == "UiRowZone")
            {
                e.Valid = e.Value.ToString().All(c => Char.IsLetterOrDigit(c) || c.Equals('_'));
            }
        }

        private void UiPropertyGridZona_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            var vGrid = sender as PropertyGridControl;
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Error";
            e.ErrorText = "Caracteres Invalidos, por favor revise";

            // Destroying the editor and discarding the wrong changes made within the edited cell
            vGrid.HideEditor();
        }
    }
}
