using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Reportes;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;
using DevExpress.XtraReports.UI;

namespace MobilityScm.Modelo.Vistas
{
    public partial class ConsultaDeLineaDePickingVista : VistaBase, IConsultaDeLineaDePickingVista
    {
        #region Eventos
        public event EventHandler VistaTerminoDeCargar;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler<ConsultaArgumento> UsuarioDeseaObtenerCajas;
        #endregion

        #region Propiedades
        public IList<Caja> Cajas
        {
            get { return (IList<Caja>)UiContenedorPrincipal.DataSource; }
            set { UiContenedorPrincipal.DataSource = value; }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        #endregion

        #region Contructor y Eventos de Carga
        public ConsultaDeLineaDePickingVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();

            Mvx.Ioc.RegisterType<ILineaDePickingServicio, LineaDePickingServicio>();

            Mvx.Ioc.RegisterSingleton<IConsultaDeLineaDePickingVista, ConsultaDeLineaDePickingVista>(this);
            Mvx.Ioc.RegisterType<IConsultaDeLineaDePickingControlador, ConsultaDeLineaDePickingControlador>();
            Mvx.Ioc.Resolve<IConsultaDeLineaDePickingControlador>();
        }

        private void ConsultaDeLineaDePickingVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            UiFechaIncial.EditValue = DateTime.Now.Date;
            UiFechaFinal.EditValue = DateTime.Now.Date + (new TimeSpan(23, 59, 59));
            CargarOGuardarDisenios(UiContenedorPrincipal, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }

        private void ConsultaDeLineaDePickingVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiContenedorPrincipal, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }
        #endregion



        #region Metodos
        public void TerminoProceso(object mensaje, dynamic sender)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Eventos de controles
        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseaObtenerCajas?.Invoke(e, new ConsultaArgumento { FechaInicial = (DateTime)UiFechaIncial.EditValue, FechaFinal = (DateTime)UiFechaFinal.EditValue });
                UiVistaPrincipal.ExpandGroupLevel(0);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void UiBotonExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiDialogoParaGuardar.DefaultExt = "xlsx";
                UiDialogoParaGuardar.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
                UiDialogoParaGuardar.FilterIndex = 2;
                UiDialogoParaGuardar.RestoreDirectory = true;
                UiDialogoParaGuardar.Title = @"Guardar Consulta de Linea de Picking";
                if (UiDialogoParaGuardar.ShowDialog() == DialogResult.OK)
                {
                    UiVistaPrincipal.ExportToXlsx(UiDialogoParaGuardar.FileName);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void UiBotonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaPrincipal.ExpandAllGroups();
        }

        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaPrincipal.CollapseAllGroups();
        }

        private void UiBotonReporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (Cajas == null) return;

                UiVistaPrincipal.ExpandAllGroups();
                var listaCajas  = GetFilteredData<Caja>(UiVistaPrincipal);

                var reporte = new Reportes.ConsultaLineaPicking(false)
                {
                    DataSource = ListToDataTableClass.ListToDataTable(listaCajas),
                    RequestParameters = false
                };
                reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
                reporte.FillDataSource();

                using (var printTool = new ReportPrintTool(reporte))
                {
                    printTool.ShowRibbonPreviewDialog();
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }
        #endregion


    }
}
