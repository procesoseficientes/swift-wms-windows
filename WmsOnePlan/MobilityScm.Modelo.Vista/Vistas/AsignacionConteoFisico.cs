using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Vistas
{
    public partial class AsignacionConteoFisico : VistaBase, IAsignacionConteosFisicosVista
    {
        #region Eventos
        public event EventHandler UsuarioDeseaObtenerUsuarios;
        public event EventHandler<ConteoFisicoArgumento> UsuarioDeseaObtenerBodegas;
        public event EventHandler<ConteoFisicoArgumento> UsuarioDeseaObtenerZonas;
        public event EventHandler<ConteoFisicoArgumento> UsuarioDeseaObtenerClientes;
        public event EventHandler<ConteoFisicoArgumento> UsuarioDeseaObtenerUbicaciones;
        public event EventHandler<ConteoFisicoArgumento> UsuarioDeseaObtenerMaterial;
        public event EventHandler<ConteoFisicoArgumento> UsuarioDeseaGrabarConteoFisico;
        public event EventHandler<ConteoFisicoArgumento> UsuarioDeseaObtenerUbicacionesPorFiltro;
        public event EventHandler UsuarioDeseaObtenerPrioridades;
        public event EventHandler VistaCargandosePorPrimeraVez;
        #endregion


        #region Propiedades
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
        public IList<Cliente> Clientes
        {
            get { return (IList<Cliente>)UiListaClientes.Properties.DataSource; }
            set { UiListaClientes.Properties.DataSource = value; }
        }
        public IList<Ubicacion> Ubicaciones
        {
            get { return (IList<Ubicacion>)UiListaUbicaciones.Properties.DataSource; }
            set { UiListaUbicaciones.Properties.DataSource = value; }
        }
        public IList<Sku> Materiales
        {
            get { return (IList<Sku>)UiListaSkus.Properties.DataSource; }
            set { UiListaSkus.Properties.DataSource = value; }
        }

        public IList<MobilityScm.Modelo.Entidades.Configuracion> Prioridad
        {
            get { return (IList<MobilityScm.Modelo.Entidades.Configuracion>)UiListaPrioridad.Properties.DataSource; }
            set { UiListaPrioridad.Properties.DataSource = value; }
        }

        public IList<MobilityScm.Modelo.Entidades.Configuracion> Regimen
        {
            get { return (IList<MobilityScm.Modelo.Entidades.Configuracion>)UiListaRegimen.Properties.DataSource; }
            set { UiListaRegimen.Properties.DataSource = value; }
        }

        public IList<ConteoFisicoDetalle> ConteoDetalles
        {
            get { return (IList<ConteoFisicoDetalle>)UiContenedorVistaConteos.DataSource; }
            set { UiContenedorVistaConteos.DataSource = value; }
        }

        public IList<Zona> Zonas
        {
            get { return (IList<Zona>)UiListaZonas.Properties.DataSource; }
            set { UiListaZonas.Properties.DataSource = value; }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public string Usuario { get; set; }
        private bool UsuarioSeleccionoListaOperadoresCompleta { get; set; }
        private bool UsuarioSeleccionoListaBodegasCompleta { get; set; }
        private bool UsuarioSeleccionoListaZonasCompleta { get; set; }
        private bool UsuarioSeleccionoListaUbicacionesCompleta { get; set; }
        private bool UsuarioSeleccionoListaClientesCompleta { get; set; }
        private bool UsuarioSeleccionoListaSkusCompleta { get; set; }

        public bool IncluirTodasUbicaciones => UiToggleIncluirTodasUbiciaciones.Checked;

        #endregion


        #region Contructor y Eventos de Carga

        public AsignacionConteoFisico()
        {
            InitializeComponent();


            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();

            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();
            Mvx.Ioc.RegisterType<IConteoFisicoServicio, ConteoFisicoServicio>();
            Mvx.Ioc.RegisterType<IMaterialServicio, MaterialServicio>();
            Mvx.Ioc.RegisterType<IUbicacionServicio, UbicacionServicio>();
            Mvx.Ioc.RegisterType<IClienteServicio, ClienteServicio>();
            Mvx.Ioc.RegisterType<IUsuarioServicio, UsuarioServicio>();
            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();

            Mvx.Ioc.RegisterSingleton<IAsignacionConteosFisicosVista, AsignacionConteoFisico>(this);
            Mvx.Ioc.RegisterType<IAsignacionConteoFisicoControlador, AsignacionConteoFisicoControlador>();
            Mvx.Ioc.Resolve<IAsignacionConteoFisicoControlador>();

        }

        private void AsignacionConteoFisico_Load(object sender, EventArgs e)
        {

            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            UsuarioSeleccionoListaOperadoresCompleta = false;
            UsuarioSeleccionoListaBodegasCompleta = false;
            UsuarioSeleccionoListaZonasCompleta = false;
            UsuarioSeleccionoListaUbicacionesCompleta = false;
            UsuarioSeleccionoListaClientesCompleta = false;
            UsuarioSeleccionoListaSkusCompleta = false;
            UiListaRegimen.EditValue = "GENERAL";
            UiListaPrioridad.EditValue = "2";


            UiListaOperadores.Properties.PopupFormWidth = UiListaOperadores.Width;
            UiListaBodegas.Properties.PopupFormWidth = UiListaBodegas.Width;
            UiListaZonas.Properties.PopupFormWidth = UiListaZonas.Width;
            UiListaUbicaciones.Properties.PopupFormWidth = UiListaUbicaciones.Width;
            UiListaClientes.Properties.PopupFormWidth = UiListaClientes.Width + 100;
            UiListaSkus.Properties.PopupFormWidth = UiListaSkus.Width + 100;

            UiLabelCentroDistribucion.Caption = "Centro De Distribucion: "+InteraccionConUsuarioServicio.ObtenerCentroDistribucion();

            CargarOGuardarDisenios(UiContenedorVistaConteos, false, Usuario, GetType().Name);

        }
        #endregion


        #region Eventos de Pantalla
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
                case "REFRESCAR-ZONAS":
                    ObtenerZonas(sender);
                    break;
                case "REFRESCAR-CLIENTES":
                    ObtenerClientes(sender);                
                    break;
                case "REFRESCAR-SKUS":
                    ObtenerMateriales(sender);
                    break;
                case "REFRESCAR-UBICACIONES":
                    ObtenerUbicaciones(sender);
                    break;

            }
        }

        private void ObtenerClientes(object sender)
        {
            if (string.IsNullOrEmpty(PrepararBodegas())) return;
            UsuarioDeseaObtenerClientes?.Invoke(sender, new ConteoFisicoArgumento
            {
                Bodegas= PrepararBodegas()
                ,Regimen = UiListaRegimen.EditValue?.ToString() ?? ""
                ,Zonas = PrepararZonas()
                ,Ubicaciones = PrepararUbicaciones()
            });
        }

        private void UibotonCrearConteo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ConteoDetalles == null || ConteoDetalles.Count <= 0) return;


            UsuarioDeseaGrabarConteoFisico?.Invoke(sender, new ConteoFisicoArgumento
            {
                Tarea = new Tarea
                {
                    CREATE_BY = InteraccionConUsuarioServicio.ObtenerUsuario()
                    ,
                    TASK_TYPE = Enums.GetStringValue(TareasTipo.Conteo)
                    ,
                    TASK_ASSIGNED_TO = InteraccionConUsuarioServicio.ObtenerUsuario()
                    ,
                    REGIMEN = UiListaRegimen.EditValue?.ToString() ?? ""
                    ,
                    PRIORITY = Convert.ToInt16(UiListaPrioridad.EditValue?.ToString() ?? "1")
                    ,
                    COMMENTS = ""
                }
                ,
                ConteoFisicoEncabezado = new ConteoFisicoEncabezado
                {
                    REGIMEN = UiListaRegimen.EditValue?.ToString() ?? ""
                    ,
                    DISTRIBUTION_CENTER = InteraccionConUsuarioServicio.ObtenerCentroDistribucion()
                }
                ,
                ConteoFisicoDetalle = ConteoDetalles.ToList()

            });
            LimpiarControles();
        }

        private void UiListaBodegas_EditValueChanged(object sender, EventArgs e)
        {
            RecargarFiltrosDeBodega(sender);
            ObtenerMateriales(sender);
            ObtenerClientes(sender);
            ObtenerUbicacionesPorFiltros(sender);
        }

        private void UiListaClientes_EditValueChanged(object sender, EventArgs e)
        {
            ObtenerMateriales(sender);
            ObtenerUbicacionesPorFiltros(sender);
        }

        private void UiListaOperadores_EditValueChanged(object sender, EventArgs e)
        {
            LimpiarControlesMenosOperadores();
            ObtenerBodegas(sender);
            ObtenerUbicacionesPorFiltros(sender);
        }

        private void LimpiarControlesMenosOperadores()
        {
            UiContenedorVistaConteos.DataSource = null;
            UiListaSkus.Properties.DataSource = null;
            UiListaUbicaciones.Properties.DataSource = null;
            UiListaZonas.Properties.DataSource = null;
            UiListaBodegas.Properties.DataSource = null;
            UiListaClientes.Properties.DataSource = null;            
        }

        private void UiListaZonas_EditValueChanged(object sender, EventArgs e)
        {
            ObtenerUbicaciones(sender);
            ObtenerUbicacionesPorFiltros(sender);
        }

        private void UiListaUbicaciones_EditValueChanged(object sender, EventArgs e)
        {
            ObtenerUbicacionesPorFiltros(sender);
        }

        private void UiListaSkus_EditValueChanged(object sender, EventArgs e)
        {
            ObtenerUbicacionesPorFiltros(sender);
        }

        private void UiListaRegimen_EditValueChanged(object sender, EventArgs e)
        {
            ObtenerClientes(sender);
            ObtenerMateriales(sender);
            ObtenerUbicacionesPorFiltros(sender);
        }
        private void UiToggleIncluirTodasUbiciaciones_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ObtenerUbicacionesPorFiltros(sender);
        }
        private void UiBotonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaConteos.ExpandAllGroups();
        }
        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaConteos.CollapseAllGroups();
        }
        private void UiBotonLimpiarCampos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarControles();
        }



        #endregion


        #region Metodos
        private void LimpiarControles()
        {
            UiContenedorVistaConteos.DataSource = null;
            UiListaSkus.Properties.DataSource = null;
            UiListaUbicaciones.Properties.DataSource = null;
            UiListaZonas.Properties.DataSource = null;
            UiListaBodegas.Properties.DataSource = null;
            UiListaClientes.Properties.DataSource = null;
            UiListaOperadores.Properties.DataSource = null;
        }

        private void ObtenerUbicaciones(object sender)
        {
            if (string.IsNullOrEmpty(PrepararBodegas())) return;

            UsuarioDeseaObtenerUbicaciones?.Invoke(sender, new ConteoFisicoArgumento
            {
                Bodegas = PrepararBodegas()
                ,
                Zonas = PrepararZonas()
            });
        }

        private void ObtenerMateriales(object sender)
        {
            if (string.IsNullOrEmpty(PrepararBodegas())) return;

            UsuarioDeseaObtenerMaterial?.Invoke(sender, new ConteoFisicoArgumento
            {
                Bodegas = PrepararBodegas()
                ,
                Regimen = UiListaRegimen.EditValue?.ToString() ?? ""
                ,
                Zonas = PrepararZonas()
                ,
                Clientes = PrepararClientes()
                ,
                Ubicaciones = PrepararUbicaciones()
            });
        }

        private string PrepararUbicaciones()
        {
            if (Ubicaciones == null) return null;
            var cadena = new StringBuilder();
            foreach (var objeto in Ubicaciones.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append("|"); }
                cadena.Append(objeto.LOCATION_SPOT);
            }
            return cadena.ToString();
        }

        private string PrepararClientes()
        {
            if (Clientes == null) return null;
            var cadena = new StringBuilder();
            foreach (var objeto in Clientes.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append("|"); }
                cadena.Append(objeto.CLIENT_CODE);
            }
            return cadena.ToString();
        }

        private string PrepararZonas()
        {
            if (Zonas == null) return null;
            var cadena = new StringBuilder();
            foreach (var objeto in Zonas.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append("|"); }
                cadena.Append(objeto.ZONE);
            }
            return cadena.ToString();
        }

        private void ObtenerZonas(object sender)
        {
            if (string.IsNullOrEmpty(PrepararBodegas())) return;

            UsuarioDeseaObtenerZonas?.Invoke(sender, new ConteoFisicoArgumento { Bodegas = PrepararBodegas() });
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
        private void RecargarFiltrosDeBodega(object sender)
        {
            ObtenerZonas(sender);
            ObtenerUbicaciones(sender);
        }

        private void ObtenerUbicacionesPorFiltros(object sender)
        {
            if (string.IsNullOrEmpty(PrepararBodegas())) return;

            UsuarioDeseaObtenerUbicacionesPorFiltro?.Invoke(sender, new ConteoFisicoArgumento
            {
                Bodegas = PrepararBodegas()
                ,
                Regimen = UiListaRegimen.EditValue?.ToString() ?? ""
                ,
                Zonas = PrepararZonas()
                ,
                Clientes = PrepararClientes()
                ,
                Ubicaciones = PrepararUbicaciones()
                ,
                Materiales = PrepararMateriales()
                ,
                UbicacionesVacias = IncluirTodasUbicaciones ? 1 : 0

            });

            if (ConteoDetalles != null && ConteoDetalles.Count > 0)
            {
                var conteos = ConteoDetalles.ToList();
                var usuarios = Usuarios.Where(x => x.IS_SELECTED).ToList();
                var cantidad = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(conteos.Count()) / Convert.ToDecimal(usuarios.Count())));
                var ultimaCantidad = 0;
                var cantidadUsuarios = usuarios.Count;

                for (int j = 0; j < cantidadUsuarios; j++)
                {
                    var pose = ultimaCantidad + cantidad;
                    for (int i = ultimaCantidad; i < pose; i++)
                    {
                        conteos[i].ASSIGNED_TO = usuarios[0].LOGIN_ID;
                        if (i == pose - 1)
                            ultimaCantidad = pose;
                    }
                    usuarios = usuarios.Where(x => x.LOGIN_ID != usuarios[0].LOGIN_ID).ToList();
                    cantidad = usuarios.Count == 0 ? 1 : Convert.ToInt32(Math.Ceiling((Convert.ToDecimal(conteos.Count(x => string.IsNullOrEmpty(x.ASSIGNED_TO))) / Convert.ToDecimal(usuarios.Count()))));

                }
                ConteoDetalles = conteos;
            }



        }

        private string PrepararMateriales()
        {
            if (Materiales == null) return null;
            var cadena = new StringBuilder();
            foreach (var objeto in Materiales.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append("|"); }
                cadena.Append(objeto.MATERIAL_ID);
            }
            return cadena.ToString();
        }

        #endregion


        #region Metodos para manejo de Propiedades en Listas
        private void UiListaOperadores_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaOperadores();
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

            //List<Usuario> usuarios = new List<Usuario>();
            //foreach (var bodega in Bodegas.Where(x => x.IS_SELECTED))
            //{                
            //    usuarios.AddRange(Usuarios.Where(x => x.LOGIN_ID == bodega.ASSIGNED_TO).ToList());
            //}
            //Usuarios = usuarios;
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

        private void UiListaZonas_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaZonas();
        }

        private void UiListaVistaZonas_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiListaVistaZonas.RowCount; i++)
            {
                var documento = (Zona)UiListaVistaZonas.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiListaVistaZonas.SelectRow(i);
                }
            }
        }

        private void UiListaVistaZonas_MouseUp(object sender, MouseEventArgs e)
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

        private void UiListaVistaZonas_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

            if (e.ControllerRow >= 0)
            {
                var documento = (Zona)UiListaVistaZonas.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaZonasCompleta)
                {
                    for (var i = 0; i < UiListaVistaZonas.RowCount; i++)
                    {
                        var documento = (Zona)UiListaVistaZonas.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiListaVistaZonas.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaZonasCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaZonas();
        }
        private string ObtenerTextoAMostrarListaZonas()
        {
            if (Zonas == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in Zonas.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(documento.ZONE);
            }
            return cadena.ToString();
        }

        private void UiListaUbicaciones_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaUbicaciones();
        }

        private void UiListaVistaUbicaciones_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiListaVistaUbicaciones.RowCount; i++)
            {
                var documento = (Ubicacion)UiListaVistaUbicaciones.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiListaVistaUbicaciones.SelectRow(i);
                }
            }
        }

        private void UiListaVistaUbicaciones_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaUbicacionesCompleta = true;
            }
        }

        private void UiListaVistaUbicaciones_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (Ubicacion)UiListaVistaUbicaciones.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaUbicacionesCompleta)
                {
                    for (var i = 0; i < UiListaVistaUbicaciones.RowCount; i++)
                    {
                        var documento = (Ubicacion)UiListaVistaUbicaciones.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiListaVistaUbicaciones.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaUbicacionesCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaUbicaciones();
        }
        private string ObtenerTextoAMostrarListaUbicaciones()
        {
            if (Ubicaciones == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in Ubicaciones.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(documento.SPOT_LABEL);
            }
            return cadena.ToString();
        }

        private void UiListaClientes_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaClientes();
        }

        private void UiListaVistaClientes_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiListaVistaClientes.RowCount; i++)
            {
                var documento = (Cliente)UiListaVistaClientes.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiListaVistaClientes.SelectRow(i);
                }
            }
        }

        private void UiListaVistaClientes_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaClientesCompleta = true;
            }
        }

        private void UiListaVistaClientes_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (Cliente)UiListaVistaClientes.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaClientesCompleta)
                {
                    for (var i = 0; i < UiListaVistaClientes.RowCount; i++)
                    {
                        var documento = (Cliente)UiListaVistaClientes.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiListaVistaClientes.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaClientesCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaClientes();
        }
        private string ObtenerTextoAMostrarListaClientes()
        {
            if (Clientes == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in Clientes.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(documento.CLIENT_NAME);
            }
            return cadena.ToString();
        }

        private void UiListaSkus_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaSkus();
        }

        private void UiListaVistaSkus_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiListaVistaSkus.RowCount; i++)
            {
                var documento = (Sku)UiListaVistaSkus.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiListaVistaSkus.SelectRow(i);
                }
            }
        }

        private void UiListaVistaSkus_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaSkusCompleta = true;
            }
        }

        private void UiListaVistaSkus_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (Sku)UiListaVistaSkus.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaSkusCompleta)
                {
                    for (var i = 0; i < UiListaVistaSkus.RowCount; i++)
                    {
                        var documento = (Sku)UiListaVistaSkus.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiListaVistaSkus.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaSkusCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaSkus();
        }
        private string ObtenerTextoAMostrarListaSkus()
        {
            if (Materiales == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in Materiales.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(documento.MATERIAL_NAME);
            }
            return cadena.ToString();
        }








        #endregion


    }
}
