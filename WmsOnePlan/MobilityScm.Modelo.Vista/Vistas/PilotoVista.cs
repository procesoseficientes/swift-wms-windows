using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
using Enums = MobilityScm.Modelo.Tipos.Enums;

namespace MobilityScm.Modelo.Vistas
{
    public partial class PilotoVista : VistaBase, IPilotoVista
    {
        #region Eventos

        public event EventHandler<PilotoArgumento> UsuarioDeseaObtenerPilotos;
        public event EventHandler UsuarioDeseaObtenerRoles;
        public event EventHandler<PilotoArgumento> UsuarioDeseaObtenerUsuariosPorRol;
        public event EventHandler<PilotoArgumento> UsuarioDeseaCrearPiloto;
        public event EventHandler<PilotoArgumento> UsuarioDeseaActualizarPiloto;
        public event EventHandler<PilotoArgumento> UsuarioDeseaEliminarPiloto;
        public event EventHandler<PilotoArgumento> UsuarioDeseaAsociarPilotoAUsuarioDelSistema;
        public event EventHandler<PilotoArgumento> UsuarioDeseaDesasociarPilotoDeUsuarioDelSistema;


        public event EventHandler VistaCargandosePorPrimeraVez;

        #endregion

        #region  Propiedades

        public Piloto Piloto
        {
            get { return (Piloto)UiGridDePropiedadesPilotos.SelectedObject; }

            set
            {
                UiGridDePropiedadesPilotos.SelectedObject = value;
                UiGridDePropiedadesPilotos.Refresh();
            }
        }

        public IList<Piloto> Pilotos
        {
            get { return (IList<Piloto>)UiVistasPrincipal.DataSource; }

            set
            {
                UiVistasPrincipal.DataSource = value;
                UiVistasPrincipal.Refresh();
                UiVistaPilotos.ExpandAllGroups();
            }
        }

        public IList<RolDeUsuario> RolesDeUsuario
        {
            get { return (IList<RolDeUsuario>)UiListaRol.DataSource; }

            set
            {
                UiListaRol.DataSource = value;
                if (value.Count <= 0) return;
                Piloto.ROLE_ID = value[0].ROLE_ID;
                UiGridDePropiedadesPilotos.Refresh();
                ObtenerUsuariosPorRol();
            }
        }

        public IList<UsuarioPorPiloto> UsuariosPorPilotos
        {
            get; set;
        }

        //SE COMENTA YA QUE SE UTILIZARAN LOS USUARIOS DE SONDA.
        //public IList<Usuario> UsuariosPorRol
        //{
        //    get { return (IList<Usuario>)UiListaUsuario.DataSource; }

        //    set
        //    {
        //        UiListaUsuario.DataSource = value;
        //        if (value.Count <= 0) return;
        //        Piloto.USER_CODE = value[0].LOGIN_ID;
        //        UiGridDePropiedadesPilotos.Refresh();
        //    }
        //}

        public IList<Usuario> UsuariosExternos
        {
            get { return (IList<Usuario>) UiListaUsuario.DataSource;}
            set
            {
                UiListaUsuario.DataSource = value;
                if (value.Count <= 0) return;
                UiGridDePropiedadesPilotos.Refresh();
            }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; private set; }

        public IList<Parametro> Parametros { get; set; }
        #endregion

        #region Contructor y Inicializacion

        public PilotoVista()
        {
            InitializeComponent();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.RegisterType<IPilotoServicio, PilotoServicio>();
            Mvx.Ioc.RegisterType<IUsuarioServicio, UsuarioServicio>();
            Mvx.Ioc.RegisterType<IPilotoControlador, PilotoControlador>();
            Mvx.Ioc.RegisterSingleton<IPilotoVista, PilotoVista>(this);
            Mvx.Ioc.Resolve<IPilotoControlador>();
        }

        private void PilotoVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            CargarOGuardarDisenios(UiVistasPrincipal, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);

            var parametroIntegracion = Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.IntegracionNEXT) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.Next));
            var mostrarBarraOpciones = (parametroIntegracion != null && int.Parse(parametroIntegracion.VALUE) == (int)SiNo.Si);

            if (mostrarBarraOpciones)
            {
                UiBarraEditor.Visible = false;
            }

        }

        private void PilotoVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiVistasPrincipal, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }


        #endregion

        #region Eventos de Controles

        private void UiListaRol_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (BotonSeleccionadoNoTieneEtiqueta(e)) return;
                switch (e.Button.Tag.ToString())
                {
                    case "UiBotonRrefrescarListaRol":
                        UsuarioDeseaObtenerRoles?.Invoke(sender, e);
                        break;
                    case "UiBotonRrefrescarListaUsuario":
                        ObtenerUsuariosPorRol();
                        break;
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private static bool BotonSeleccionadoNoTieneEtiqueta(DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            return e.Button.Tag == null;
        }

        private void UiListaRol_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                UiVistasPrincipal.Focus();
                ObtenerUsuariosPorRol();
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
                VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonGrabar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GrabarPiloto();
        }

        private void UiBotonBorrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BorrarPiloto();
        }

        private void UiBotonGuardarSoloUsuario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AsociarODesasociarUsarioAPiloto(true);
        }
        private void UiBotonDesvincularUsuario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AsociarODesasociarUsarioAPiloto(false);
        }

        private void UiVistasPrincipal_Click(object sender, EventArgs e)
        {
            EstabacerPilotoSeleccionado();
        }

        private void UiBotonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiVistaPilotos.ExpandAllGroups();
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
                UiVistaPilotos.CollapseAllGroups();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonExportarAExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiDialogoParaGuardar.DefaultExt = "xlsx";
                UiDialogoParaGuardar.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
                UiDialogoParaGuardar.FilterIndex = 2;
                UiDialogoParaGuardar.RestoreDirectory = true;
                UiDialogoParaGuardar.Title = @"Guardar Clases";

                if (UiDialogoParaGuardar.ShowDialog() == DialogResult.OK)
                {
                    UiVistaPilotos.ExportToXlsx(UiDialogoParaGuardar.FileName);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseaObtenerPilotos?.Invoke(null, new PilotoArgumento { Piloto = new Piloto() });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        #endregion

        #region Metodos

        private bool SeleccionoRolId(string valor)
        {
            return !string.IsNullOrEmpty(valor);
        }

        private bool ExistePiloto(int? valor)
        {
            return valor != null && valor != 0;
        }

        //private void ObtenerUsuariosPorRol()
        //{
        //    try
        //    {
        //        if (!SeleccionoRolId(Piloto.ROLE_ID)) return;
        //        var codigoUsuario = string.Empty;
        //        if (ExistePiloto(Piloto.PILOT_CODE))
        //        {
        //            var firstOrDefault = Pilotos.ToList().FirstOrDefault(p => p.PILOT_CODE == Piloto.PILOT_CODE);
        //            if (firstOrDefault != null)
        //            {
        //                codigoUsuario = firstOrDefault.USER_CODE;
        //            }
        //        }
        //        UsuarioDeseaObtenerUsuariosPorRol?.Invoke(null, new PilotoArgumento { RolDeUsuario = new RolDeUsuario { ROLE_ID = Piloto.ROLE_ID, USER_CODE = codigoUsuario } });
        //    }
        //    catch (Exception ex)
        //    {
        //        InteraccionConUsuarioServicio.Alerta(ex.Message);
        //    }
        //}

        private void ObtenerUsuariosPorRol()
        {
            try
            {
                //if (!SeleccionoRolId(Piloto.ROLE_ID)) return;
                var codigoUsuario = string.Empty;
                if (ExistePiloto(Piloto.PILOT_CODE))
                {
                    var firstOrDefault = Pilotos.ToList().FirstOrDefault(p => p.PILOT_CODE == Piloto.PILOT_CODE);
                    if (firstOrDefault != null)
                    {
                        codigoUsuario = firstOrDefault.USER_CODE;
                    }
                }
                UsuarioDeseaObtenerUsuariosPorRol?.Invoke(null, new PilotoArgumento { RolDeUsuario = new RolDeUsuario { ROLE_ID = Piloto.ROLE_ID, USER_CODE = codigoUsuario } });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void GrabarPiloto()
        {
            try
            {
                if (!ValidarDatosGenerales()) return;
                UiVistasPrincipal.Focus();
                var usuarioPorPiloto = new UsuarioPorPiloto
                {
                    PILOT_CODE = Piloto.PILOT_CODE,
                    USER_CODE = Piloto.USER_CODE
                };
                Piloto.LAST_UPDATE_BY = InteraccionConUsuarioServicio.ObtenerUsuario();
                if (!ExistePiloto(Piloto.PILOT_CODE))
                {

                    UsuarioDeseaCrearPiloto?.Invoke(null, new PilotoArgumento { Piloto = Piloto, UsuarioPorPiloto = usuarioPorPiloto });
                }
                else
                {
                    UsuarioDeseaActualizarPiloto?.Invoke(null, new PilotoArgumento { Piloto = Piloto, UsuarioPorPiloto = usuarioPorPiloto });
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void BorrarPiloto()
        {
            try
            {
                if (ExistePiloto(Piloto.PILOT_CODE))
                {
                    UsuarioDeseaEliminarPiloto?.Invoke(null, new PilotoArgumento { Piloto = Piloto });
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void AsociarODesasociarUsarioAPiloto(bool asociar)
        {
            try
            {
                UiVistasPrincipal.Focus();
                if (!ExistePiloto(Piloto.PILOT_CODE)) return;
                var usuarioPorPiloto = new UsuarioPorPiloto
                {
                    PILOT_CODE = Piloto.PILOT_CODE,
                    USER_CODE = Piloto.USER_CODE
                    ,
                    LAST_UPDATE_BY = InteraccionConUsuarioServicio.ObtenerUsuario()
                };
                if (asociar)
                {
                    UsuarioDeseaAsociarPilotoAUsuarioDelSistema?.Invoke(null, new PilotoArgumento { UsuarioPorPiloto = usuarioPorPiloto });
                }
                else
                {
                    UsuarioDeseaDesasociarPilotoDeUsuarioDelSistema?.Invoke(null, new PilotoArgumento { UsuarioPorPiloto = usuarioPorPiloto });
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void EstabacerPilotoSeleccionado()
        {
            try
            {
                if (!TieneSeleccionadoUnaFilaEnLaVista(UiVistaPilotos)) return;
                Piloto = ((Piloto)ObtenerFilaSelecciondaDeLaVista(UiVistaPilotos)).ShallowCopy();
                if (string.IsNullOrEmpty(Piloto.ROLE_ID))
                {
                    if (RolesDeUsuario == null || RolesDeUsuario.Count <= 0) return;
                    Piloto.ROLE_ID = RolesDeUsuario[0].ROLE_ID;
                }
                UsuarioDeseaObtenerUsuariosPorRol?.Invoke(null, new PilotoArgumento { RolDeUsuario = new RolDeUsuario { ROLE_ID = Piloto.ROLE_ID, USER_CODE = Piloto.USER_CODE } });
                UiGridDePropiedadesPilotos.Refresh();

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }


        private bool ValidarDatosGenerales()
        {
            try
            {
                UiVistasPrincipal.Focus();
                if (string.IsNullOrEmpty(Piloto.NAME))
                {
                    InteraccionConUsuarioServicio.Alerta("Ingrese el nombre.");
                    UiGridDePropiedadesPilotos.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(Piloto.LAST_NAME))
                {
                    InteraccionConUsuarioServicio.Alerta("Ingrese el apellido.");
                    UiGridDePropiedadesPilotos.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(Piloto.IDENTIFICATION_DOCUMENT_NUMBER))
                {
                    InteraccionConUsuarioServicio.Alerta("Ingrese el numero de identificacón.");
                    UiGridDePropiedadesPilotos.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(Piloto.LICENSE_NUMBER))
                {
                    InteraccionConUsuarioServicio.Alerta("Ingrese el numero de licencia.");
                    UiGridDePropiedadesPilotos.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(Piloto.LICESE_TYPE))
                {
                    InteraccionConUsuarioServicio.Alerta("Ingrese el tipo de licencia.");
                    UiGridDePropiedadesPilotos.Focus();
                    return false;
                }
                if (Piloto.LICENSE_EXPIRATION_DATE == null)
                {
                    InteraccionConUsuarioServicio.Alerta("Ingrese la fecha de vencimiento.");
                    UiGridDePropiedadesPilotos.Focus();
                    return false;
                }
                else
                {
                    if (Piloto.LICENSE_EXPIRATION_DATE <= DateTime.Now)
                    {
                        InteraccionConUsuarioServicio.Alerta("La fecha tiene que ser mayor a la fecha actual.");
                        UiGridDePropiedadesPilotos.Focus();
                        return false;
                    }
                }

                if (string.IsNullOrEmpty(Piloto.ADDRESS))
                {
                    InteraccionConUsuarioServicio.Alerta("Ingrese la dirección.");
                    UiGridDePropiedadesPilotos.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(Piloto.TELEPHONE))
                {
                    InteraccionConUsuarioServicio.Alerta("Ingrese el telefono.");
                    UiGridDePropiedadesPilotos.Focus();
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

        #endregion


    }
}
