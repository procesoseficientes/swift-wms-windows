using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
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
    public partial class ConsultaConteoFisico : VistaBase, IConsultaDeConteoFisicoVista
    {

        #region Eventos
        public event EventHandler<ConteoFisicoArgumento> UsuarioDeseaObtenerConteosFisicos;
        public event EventHandler UsuarioDeseaObtenerUsuarios;
        public event EventHandler UsuarioDeseaObtenerBodegas;
        public event EventHandler VistaCargandosePorPrimeraVez;
        #endregion

        #region Propiedades
        public IList<ConteoFisico> ConteosFisicos
        {
            get { return (IList<ConteoFisico>)UiContenedorConteosFisicos.DataSource; }
            set { UiContenedorConteosFisicos.DataSource = value; }
        }
        public IList<Usuario> Usuarios
        {
            get { return (IList<Usuario>)UiListaOperadores.Properties.DataSource; }
            set { UiListaOperadores.Properties.DataSource = value; }
        }
        public IList<Bodega> Bodegas
        {
            get { return (IList<Bodega>)UiListaBodegas.Properties.DataSource; }
            set { UiListaBodegas.Properties.DataSource = value; }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public string Usuario { get; set; }
        private bool UsuarioSeleccionoListaOperadoresCompleta { get; set; }
        private bool UsuarioSeleccionoListaBodegasCompleta { get; set; }
        #endregion

        #region Contructor y Eventos de Carga
        public ConsultaConteoFisico()
        {
            InitializeComponent();


            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();

            Mvx.Ioc.RegisterType<IConteoFisicoServicio, ConteoFisicoServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();
            Mvx.Ioc.RegisterType<IUsuarioServicio, UsuarioServicio>();
            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();

            Mvx.Ioc.RegisterSingleton<IConsultaDeConteoFisicoVista, ConsultaConteoFisico>(this);
            Mvx.Ioc.RegisterType<IConsultaDeConteoFisicoControlador, ConsultaDeConteoFisicoControlador>();
            Mvx.Ioc.Resolve<IConsultaDeConteoFisicoControlador>();
        }
        private void ConsultaConteoFisico_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            UsuarioSeleccionoListaOperadoresCompleta = false;
            UsuarioSeleccionoListaBodegasCompleta = false;

            UiFechaInicio.EditValue = DateTime.Now;
            UiFechaFinal.EditValue = DateTime.Now;

            CargarOGuardarDisenios(UiContenedorConteosFisicos, false, Usuario, GetType().Name);
        }
        #endregion
        #region Eventos de Pagina
        private void UiComboBoxFechaDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime fecha = new DateTime(); // DateAdd(DateInterval.Month, -3, Now)
            if (UiComboBoxFechaDesde.EditValue != null && UiComboBoxFechaDesde.EditValue.ToString() == "3 Meses")
                fecha = DateTime.Now.AddMonths(-3);
            if (UiComboBoxFechaDesde.EditValue != null && UiComboBoxFechaDesde.EditValue.ToString() == "1 Mes")
                fecha = DateTime.Now.AddMonths(-1);
            if (UiComboBoxFechaDesde.EditValue != null && UiComboBoxFechaDesde.EditValue.ToString() == "1 Semana")
                fecha = DateTime.Now.AddDays(-7);
            if (UiComboBoxFechaDesde.EditValue != null && UiComboBoxFechaDesde.EditValue.ToString() == "Desde Ayer")
                fecha = DateTime.Now.AddDays(-1);
            if (UiComboBoxFechaDesde.EditValue != null && (UiComboBoxFechaDesde.EditValue.ToString() == "Hoy" || UiComboBoxFechaDesde.EditValue.ToString() == ""))
                fecha = DateTime.Now;

            UiFechaInicio.EditValue = fecha;
            UiFechaFinal.EditValue = DateTime.Now;


        }

        private void ConsultaConteoFisico_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiContenedorConteosFisicos, true, Usuario, GetType().Name);
        }

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UsuarioDeseaObtenerConteosFisicos?.Invoke(sender, new ConteoFisicoArgumento
            {
                FechaInicial = (DateTime)UiFechaInicio.EditValue
               ,
                FechaFinal = (DateTime)UiFechaFinal.EditValue
               ,
                Operadores = PrepararOperadores()
               ,
                Bodegas = PrepararBodegas()
                ,
                Login = InteraccionConUsuarioServicio.ObtenerUsuario()
            });
        }
        private void UiLista_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;
            switch (e.Button.Tag.ToString())
            {
                case "REFRESCAR-OPERADORES":
                    UsuarioDeseaObtenerUsuarios?.Invoke(sender, new ConteoFisicoArgumento());
                    break;
                case "REFRESCAR-BODEGAS":
                    ObtenerBodegas(sender);
                    break;
            }
        }

        private void UiButtonAceptar_Click(object sender, EventArgs e)
        {
            UsuarioDeseaObtenerConteosFisicos?.Invoke(sender, new ConteoFisicoArgumento
            {
                FechaInicial = (DateTime)UiFechaInicio.EditValue
                ,
                FechaFinal = (DateTime)UiFechaFinal.EditValue
                ,
                Operadores = PrepararOperadores()
                ,
                Bodegas = PrepararBodegas()
                ,
                Login = InteraccionConUsuarioServicio.ObtenerUsuario()
            });
        }

        private void UiBotonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaConteosFisicos.ExpandAllGroups();
        }

        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaConteosFisicos.CollapseAllGroups();
        }

        private void UiBotonExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportalAExcel();
        }

        private void UiBotonReporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ConteosFisicos != null && ConteosFisicos.Count > 0)
            {
                try
                {
                    IList<ConteoFisico> conteosCompletos = ConteosFisicos.ToList().Where(conteo => conteo.TASK_STATUS == "COMPLETED").ToList();
                    if(conteosCompletos.Count > 0)
                    {
                        var reporte = new Reportes.ConsultaConteoFiciso
                        {
                            DataSource = ListToDataTableClass.ListToDataTable(conteosCompletos.ToList()),
                            DataMember = "PHYSICAL_COUNTS",
                            RequestParameters = false
                        };

                        reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
                        reporte.FillDataSource();

                        using (var printTool = new ReportPrintTool(reporte))
                        {
                            printTool.ShowRibbonPreviewDialog();
                        }
                    }
                    else
                    {
                        InteraccionConUsuarioServicio.Mensaje("Para generar el reporte debe tener tareas de conteo Completadas");
                    }
                    
                }
                catch (Exception ex)
                {
                    InteraccionConUsuarioServicio.Mensaje("Excepción al exportar reporte de conteos físicos -->" + ex.Message);
                }
            }
            else
            {
                InteraccionConUsuarioServicio.Mensaje("No hay información de conteos para exportar el reporte");
            }
        }

        #endregion

        #region Metodos

        private void ExportalAExcel()
        {
            if (UiContenedorConteosFisicos.DataSource == null) return;
            if (UiVistaConteosFisicos.RowCount <= 0) return;

            var dialog = new SaveFileDialog
            {
                DefaultExt = "xlsx",
                Filter = @"Archivos de excel (*.xlsx)|*.xlsx"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;
            UiVistaConteosFisicos.ExportToXlsx(dialog.FileName);
        }

        private void ObtenerBodegas(object sender)
        {
            if (string.IsNullOrEmpty(PrepararOperadores())) return;

            UsuarioDeseaObtenerBodegas?.Invoke(sender, new ConteoFisicoArgumento
            {
                Operadores = PrepararOperadores()
                ,
                Login = InteraccionConUsuarioServicio.ObtenerUsuario()
            });
        }
        private string PrepararOperadores()
        {
            if (Usuarios == null) return null;
            var cadena = new StringBuilder();
            foreach (var objeto in Usuarios.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append("|"); }
                cadena.Append(objeto.LOGIN_ID);
            }
            return cadena.ToString();
        }
        private string PrepararBodegas()
        {
            if (Bodegas == null) return null;
            var cadena = new StringBuilder();
            foreach (var objeto in Bodegas.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append("|"); }
                cadena.Append(objeto.WAREHOUSE_ID);
            }
            return cadena.ToString();
        }
        #endregion
        #region Metodos para manejo de Propiedades en Listas
        private void UiListaOperadores_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaOperadores();
        }

        private void UiListaVistaOperadores_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiListaVistaOperadores.RowCount; i++)
            {
                var documento = (Usuario)UiListaVistaOperadores.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiListaVistaOperadores.SelectRow(i);
                }
            }
        }

        private void UiListaVistaOperadores_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaOperadoresCompleta = true;
            }
        }

        private void UiListaVistaOperadores_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (Usuario)UiListaVistaOperadores.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaOperadoresCompleta)
                {
                    for (var i = 0; i < UiListaVistaOperadores.RowCount; i++)
                    {
                        var documento = (Usuario)UiListaVistaOperadores.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiListaVistaOperadores.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaOperadoresCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaOperadores();
        }

        private string ObtenerTextoAMostrarListaOperadores()
        {
            if (Usuarios == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in Usuarios.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(documento.LOGIN_NAME);
            }
            return cadena.ToString();
        }

        private void UiListaBodegas_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaBodegas();
        }

        private void UiListaVistaBodegas_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiListaVistaBodegas.RowCount; i++)
            {
                var documento = (Bodega)UiListaVistaBodegas.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiListaVistaBodegas.SelectRow(i);
                }
            }
        }

        private void UiListaVistaBodegas_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaBodegasCompleta = true;
            }
        }

        private void UiListaVistaBodegas_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (Bodega)UiListaVistaBodegas.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaBodegasCompleta)
                {
                    for (var i = 0; i < UiListaVistaBodegas.RowCount; i++)
                    {
                        var documento = (Bodega)UiListaVistaBodegas.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiListaVistaBodegas.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaBodegasCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaBodegas();
        }
        private string ObtenerTextoAMostrarListaBodegas()
        {
            if (Bodegas == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in Bodegas.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(documento.WAREHOUSE_ID);
            }
            return cadena.ToString();
        }



        #endregion

        
    }
}
