using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
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
    public partial class ConsultaDePaseDeSalidaVista : VistaBase, IConsultaDePaseDeSalidaVista
    {

        #region MyRegion

        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerPasesDeSalida;
        public event EventHandler VistaCargandosePorPrimeraVez;

        #endregion

        #region Propiedades

        public IList<PaseDeSalida> PasesDeSalida {
            get { return (IList<PaseDeSalida>)UiContenedorVistaPaseDeSalida.DataSource; }

            set { UiContenedorVistaPaseDeSalida.DataSource = value; }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        #endregion

        #region Constructor E Inicializacion

        public ConsultaDePaseDeSalidaVista()
        {
            InitializeComponent();

            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.RegisterType<IPaseDeSalidaServicio, PaseDeSalidaServicio>();
            Mvx.Ioc.RegisterType<IConsulaDePaseDeSalidaControlador, ConsultaDePaseDeSalidaControlador>();
            Mvx.Ioc.RegisterSingleton<IConsultaDePaseDeSalidaVista, ConsultaDePaseDeSalidaVista>(this);
            Mvx.Ioc.Resolve<IConsulaDePaseDeSalidaControlador>();
        }


        private void ConsultaDePaseDeSalidaVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            CargarOGuardarDisenios(UiContenedorVistaPaseDeSalida, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }

        #endregion

        #region Metodos

        public void InicializarCampos()
        {
            UiFechaInicialConsultaPasesDeSalida.EditValue = DateTime.Today + (new TimeSpan(00, 00, 00));
            UiFechaFinalConsultaPasesDeSalida.EditValue = DateTime.Today + (new TimeSpan(23, 59, 59));
        }

        private void ValidarCamposDeUsuario()
        {
            if (DateTime.Parse(UiFechaInicialConsultaPasesDeSalida.EditValue.ToString()) >= DateTime.Parse(UiFechaFinalConsultaPasesDeSalida.EditValue.ToString()))
            {
                throw new Exception("La fecha de inicio no debe ser mayor o igual a la fecha final.");
            }
        }


        #endregion

        #region Eventos De Controles
        
        private void UiBtnExportarVistaPasesDeSalidaAExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (UiVistaPaseDeSalida.DataSource == null || UiVistaPaseDeSalida.RowCount <= 0) return;

                var dialog = new SaveFileDialog
                {
                    DefaultExt = "xlsx",
                    Filter = @"Archivos de excel (*.xlsx)|*.xlsx"
                };

                if (dialog.ShowDialog() != DialogResult.OK) return;
                UiVistaPaseDeSalida.ExportToXlsx(dialog.FileName);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void UiBtnExpandirGruposVistaPasesDeSalida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiVistaPaseDeSalida.ExpandAllGroups();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void UiBtnContraerGruposVistaPasesDeSalida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiVistaPaseDeSalida.CollapseAllGroups();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void UiBtnRefrescarVistaPasesDeSalida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                ValidarCamposDeUsuario();

                UsuarioDeseaObtenerPasesDeSalida?.Invoke(sender, new PaseDeSalidaArgumento
                {
                    FechaInicio = Convert.ToDateTime(UiFechaInicialConsultaPasesDeSalida.EditValue.ToString())
                    ,FechaFin = Convert.ToDateTime(UiFechaFinalConsultaPasesDeSalida.EditValue.ToString())
                    ,Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                    ,DISTRIBUTION_CENTER_ID = InteraccionConUsuarioServicio.ObtenerCentroDistribucion()
                });

            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }
        private void ConsultaDePaseDeSalidaVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiContenedorVistaPaseDeSalida, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }


        #endregion

        private void UiContenedorVistaPaseDeSalida_DoubleClick(object sender, EventArgs e)
        {
            UsuarioDeseaConsultarPaseDeSalida();
        }

        private void UsuarioDeseaConsultarPaseDeSalida()
        {
            try
            {
                var fila = (PaseDeSalida)UiVistaPaseDeSalida.GetFocusedRow();
                if (fila == null) return;

                var formularios = Application.OpenForms;
                var frm = formularios.Cast<Form>().FirstOrDefault(formulario => (formulario.Name == "PaseDeSalidaVista"));

                if (frm == null)
                {
                    frm = new PaseDeSalidaVista() { MdiParent = MdiParent };
                    frm.Show();
                    ((PaseDeSalidaVista)(frm)).ObtenerPaseDeSalida((int)fila.PASS_ID);
                }
                else
                {
                    ((PaseDeSalidaVista)(frm)).ObtenerPaseDeSalida((int)fila.PASS_ID);
                    ((PaseDeSalidaVista)(frm)).Focus();
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta("Error al cargar el manifiesto: " + ex.Message);
            }
        }
    }
}