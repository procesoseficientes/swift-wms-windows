using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
    public partial class EmpresaDeTransporteVista : VistaBase, IEmpresaDeTransporteVista
    {
        #region Eventos

        public event EventHandler<EmpresaDeTransporteArgumento> UsuarioDeseaActualizarEmpresaDeTransporte;
        public event EventHandler<EmpresaDeTransporteArgumento> UsuarioDeseaCrearEmpresaDeTransporte;
        public event EventHandler<EmpresaDeTransporteArgumento> UsuarioDeseaEliminarEmpresaDeTransporte;
        public event EventHandler<EmpresaDeTransporteArgumento> UsuarioDeseaObtenerEmpresasDeTransporte;
        public event EventHandler VistaCargandosePorPrimeraVez;

        #endregion

        #region Propiedades

        public EmpresaDeTransporte EmpresaDeTransporte
        {
            get { return (EmpresaDeTransporte) UiGridDePropiedades.SelectedObject; }
            set { UiGridDePropiedades.SelectedObject = value; UiGridDePropiedades.Refresh();}
        }

        public IList<EmpresaDeTransporte> EmpresasDeTransporte
        {
            get { return (IList<EmpresaDeTransporte>) UiVistaPrincipal.DataSource; }
            set
            {
                UiVistasPrincipal.DataSource = value;
                UiVistaPrincipal.ExpandAllGroups();
            }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; private set; }

        #endregion

        #region Contructor E Inicializacion

        public EmpresaDeTransporteVista()
        {
            InitializeComponent();

            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.RegisterType<IEmpresaDeTransporteServicio, EmpresaDeTransporteServicio>();
            
            Mvx.Ioc.RegisterType<IEmpresaDeTransporteControlador, EmpresaDeTransporteControlador>();
            Mvx.Ioc.RegisterSingleton<IEmpresaDeTransporteVista, EmpresaDeTransporteVista>(this);
            Mvx.Ioc.Resolve<IEmpresaDeTransporteControlador>();

        }

        private void EmpresaDeTransporteVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            CargarOGuardarDisenios(UiVistasPrincipal, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }


        #endregion

        #region Eventos de Cotroles

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseaObtenerEmpresasDeTransporte?.Invoke(null, new EmpresaDeTransporteArgumento {EmpresaDeTransporte = new EmpresaDeTransporte()});
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }


        private void UiBotonExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (UiVistasPrincipal.DataSource == null) return;
                if (UiVistaPrincipal.RowCount <= 0) return;

                var dialog = new SaveFileDialog
                {
                    DefaultExt = "xlsx",
                    Filter = @"Archivos de excel (*.xlsx)|*.xlsx"
                };

                if (dialog.ShowDialog() != DialogResult.OK) return;
                UiVistasPrincipal.ExportToXlsx(dialog.FileName);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiVistaPrincipal.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiVistaPrincipal.CollapseAllGroups();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                EmpresaDeTransporte = new EmpresaDeTransporte();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonGrabar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseaGrabarLaEmpresa();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonBorrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseEliminarLaEmpres();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }
        
        private void UiVistaPrincipal_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                EstablecerEmpresaDeTrasporte();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }
        #endregion

        #region Metodos

        private void UsuarioDeseaGrabarLaEmpresa()
        {
            try
            {
                UiVistaPrincipal.Focus();
                if (ValidarCampos())
                {
                    var empresaDeTransporte = EmpresaDeTransporte;
                    EmpresaDeTransporte.LAST_UPDATE_BY = InteraccionConUsuarioServicio.ObtenerUsuario();
                    if (!ExisteEmpresaDeTransporte(empresaDeTransporte.TRANSPORT_COMPANY_CODE))
                    {
                        UsuarioDeseaCrearEmpresaDeTransporte?.Invoke(null, new EmpresaDeTransporteArgumento { EmpresaDeTransporte = empresaDeTransporte });
                    }
                    else
                    {
                        UsuarioDeseaActualizarEmpresaDeTransporte?.Invoke(null, new EmpresaDeTransporteArgumento { EmpresaDeTransporte = empresaDeTransporte });
                    }
                    
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UsuarioDeseEliminarLaEmpres()
        {
            try
            {
                var empresaDeTransporte = EmpresaDeTransporte;
                if (ExisteEmpresaDeTransporte(empresaDeTransporte.TRANSPORT_COMPANY_CODE))
                {
                    UsuarioDeseaEliminarEmpresaDeTransporte?.Invoke(null, new EmpresaDeTransporteArgumento { EmpresaDeTransporte = empresaDeTransporte });
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }


        private bool ValidarCampos()
        {
            try
            {
                var empresaDeTransporte = (EmpresaDeTransporte)UiGridDePropiedades.SelectedObject;

                if (ValidarCampoVacio(empresaDeTransporte.NAME))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese el nombre");
                    UiGridDePropiedades.Focus();
                    return false;
                }
                if (ValidarCampoVacio(empresaDeTransporte.ADDRESS))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese la dirección");
                    UiGridDePropiedades.Focus();
                    return false;
                }
                if (ValidarCampoVacio(empresaDeTransporte.TELEPHONE))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese el telefono");
                    UiGridDePropiedades.Focus();
                    return false;
                }
                if (ValidarCampoVacio(empresaDeTransporte.CONTACT))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese el contacto");
                    UiGridDePropiedades.Focus();
                    return false;
                }
                if (ValidarCampoVacio(empresaDeTransporte.MAIL))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese el correo electronico");
                    UiGridDePropiedades.Focus();
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
                return false;
            }
        }

        private bool ValidarCampoVacio(string valor)
        {
            return string.IsNullOrEmpty(valor);
        }

        private bool ExisteEmpresaDeTransporte(int? valor)
        {
            return valor != null && valor != 0;
        }

        private void EstablecerEmpresaDeTrasporte()
        {
            try
            {
                if (UiVistaPrincipal.FocusedRowHandle >= 0)
                {
                    EmpresaDeTransporte  = (EmpresaDeTransporte)UiVistaPrincipal.GetFocusedRow();
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }


        #endregion

    }
}
