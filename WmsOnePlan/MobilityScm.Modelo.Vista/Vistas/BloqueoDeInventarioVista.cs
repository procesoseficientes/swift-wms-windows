using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.DataProcessing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting.Native;
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
    public partial class BloqueoDeInventarioVista : VistaBase, IBloqueoDeInventarioVista
    {
        #region Eventos
        public event EventHandler<InventarioArgumento> UsuarioDeseaObtenerInventario;
        public event EventHandler<InventarioArgumento> UsuarioDeseaObtenerEstadosDeMaterial;
        public event EventHandler<InventarioArgumento> UsuarioDeseaCambiarElEstadoDelInventario;
        public event EventHandler VistaCargandosePorPrimeraVez;
        #endregion

        #region Propiedades
        public IList<Inventario> Inventario
        {
            get { return (IList<Inventario>)UiVistaBloqueoDeInventario.DataSource; }
            set { UiVistaBloqueoDeInventario.DataSource = value; UiVistaInventario.ExpandAllGroups();}
        }
        public IList<Entidades.Configuracion> EstadosDeMaterial
        {
            get { return (IList<Entidades.Configuracion>)UIListaEstados.Properties.DataSource; }
            set { UIListaEstados.Properties.DataSource = value; }
        }

        public string Usuario { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        private bool UsuarioSeleccionoListaInventarioCompleta { get; set; }

        #endregion

        #region Eventos de Carga
        private void BloqueoDeInventarioVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            UIListaEstados.Properties.PopupFormWidth = UIListaEstados.Width - 10;
            CargarOGuardarDisenios(UiVistaBloqueoDeInventario, false, Usuario, GetType().Name);
        }

        private void BloqueoDeInventarioVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiVistaBloqueoDeInventario, true, Usuario, GetType().Name);
        }

        #endregion

        #region Eventos de Controles

        public BloqueoDeInventarioVista()
        {
            InitializeComponent();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.RegisterType<IInventarioServicio, InventarioServicio>();
            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();
            Mvx.Ioc.RegisterType<IBloqueoDeInventarioControlador, BloqueoDeInventarioControlador>();
            Mvx.Ioc.RegisterSingleton<IBloqueoDeInventarioVista, BloqueoDeInventarioVista>(this);
            Mvx.Ioc.Resolve<IBloqueoDeInventarioControlador>();
        }

        private void UiLista_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                switch (e.Button.Tag.ToString())
                {
                    case "UiBotonRefrescarEstado":
                        UsuarioDeseaObtenerEstadosDeMaterial?.Invoke(null, new InventarioArgumento());
                        break;
                    case "UiBotonCambiarEstado":
                        EstablecerEstadoNuevo();
                        break;
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UsuarioDeseaObtenerInventario?.Invoke(sender, new InventarioArgumento());
        }

        private void UiBotonGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Inventario.ToList().Exists(i => !string.IsNullOrEmpty(i.STATUS_CODE_NEW)))
            {
                UsuarioDeseaCambiarElEstadoDelInventario?.Invoke(sender, new InventarioArgumento());
            }
        }

        private void UiListaVistaEstado_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (EsColumnaDeColorYElValorEsNumerico(e))
            {
                Color color = Color.FromArgb(Convert.ToInt32(e.CellValue));
                LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, color, color, LinearGradientMode.ForwardDiagonal);

                e.Graphics.FillRectangle(brush, e.Bounds);
                brush.Dispose();
                e.Graphics.DrawString("", e.Appearance.Font, Brushes.Black, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.Handled = true;
            }
        }

        private bool EsColumnaDeColorYElValorEsNumerico(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            int output;
            return e.CellValue != null && e.Column.FieldName == "COLOR" && int.TryParse(e.CellValue.ToString(), out output);
        }

        private void UiVistaInventario_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var registro = (Inventario)UiVistaInventario.GetRow(e.ControllerRow);
                registro.IS_SELECTD = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (!UsuarioSeleccionoListaInventarioCompleta) return;
                for (var i = 0; i < UiVistaInventario.RowCount; i++)
                {
                    var registro = (Inventario)UiVistaInventario.GetRow(i);
                    if (registro == null) continue;
                    registro.IS_SELECTD = (UiVistaInventario.SelectedRowsCount != 0);
                }
                UsuarioSeleccionoListaInventarioCompleta = false;
            }
        }

        private void UiVistaInventario_MouseUp(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;
            var hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            UsuarioSeleccionoListaInventarioCompleta = VerificarSiElUsuarioSeleccionoListaDeInventarioCompleta(hitInfo);
        }

        private static bool VerificarSiElUsuarioSeleccionoListaDeInventarioCompleta(GridHitInfo hitInfo)
        {
            return ((hitInfo.HitTest == GridHitTest.Column 
                    || hitInfo.HitTest == GridHitTest.GroupPanelColumn) &&
                    hitInfo.Column.Name.Equals("DX$CheckboxSelectorColumn"));
        }

        private void UiVistaInventario_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            MarcarInventarioSeleccionado();
        }

        private void UiVistaInventario_ColumnFilterChanged(object sender, EventArgs e)
        {
            MarcarInventarioSeleccionado();
        }

        private void UiBotonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaInventario.ExpandAllGroups();
        }

        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaInventario.CollapseAllGroups();
        }

        private void UiBotonExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportalAExcel();
        }

        #endregion

        #region Metodos

        private void MarcarInventarioSeleccionado()
        {
            try
            {
                for (var i = 0; i < UiVistaInventario.RowCount; i++)
                {
                    var registro = (Inventario)UiVistaInventario.GetRow(i);
                    if (registro.IS_SELECTD)
                    {
                        UiVistaInventario.SelectRow(i);
                    }
                    else
                    {
                        UiVistaInventario.UnselectRow(i);
                    }
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void EstablecerEstadoNuevo()
        {
            try
            {
                var codeEstado = UIListaEstados.EditValue.ToString();
                var estado = EstadosDeMaterial.FirstOrDefault(e => e.PARAM_NAME.Equals(codeEstado));
                if (estado == null) return;
                var inventarioParaModificar = Inventario;
                inventarioParaModificar.Where(i=> i.IS_SELECTD).ForEach(i =>
                {
                    i.STATUS_CODE_NEW = estado.PARAM_NAME;
                    i.STATUS_NAME_NEW = estado.PARAM_CAPTION;
                });
                UiVistaBloqueoDeInventario.DataSource = new List<Inventario>();
                Inventario = inventarioParaModificar;
                MarcarInventarioSeleccionado();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void ExportalAExcel()
        {
            if (UiVistaBloqueoDeInventario.DataSource == null) return;
            if (UiVistaInventario.RowCount <= 0) return;

            var dialog = new SaveFileDialog
            {
                DefaultExt = "xlsx",
                Filter = @"Archivos de excel (*.xlsx)|*.xlsx"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;
            UiVistaInventario.ExportToXlsx(dialog.FileName);
        }

        #endregion
    }
}
