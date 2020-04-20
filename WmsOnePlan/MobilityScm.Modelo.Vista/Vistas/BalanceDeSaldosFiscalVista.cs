using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class BalanceDeSaldosFiscalVista : VistaBase, IBalanceDeSaldosFiscalVista
    {
        #region Eventos

        public event EventHandler<BalanceDeSaldosFiscalArgumento> UsuarioDeseaObtenerBalanceDeSaldosFiscal;
        public event EventHandler VistaCargandosePorPrimeraVez;

        #endregion

        #region Propiedades

        public IList<BalanceDeSaldosFiscal> BalanceDeSaldosFiscal
        {
            get { return (IList<BalanceDeSaldosFiscal>)UiVistasBalance.DataSource; }

            set { UiVistasBalance.DataSource = value; }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; private set; }

        #endregion

        #region Contructor y Eventos de Inicializacion

        public BalanceDeSaldosFiscalVista()
        {
            InitializeComponent();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.RegisterType<IBalanceDeSaldosFiscalServicio, BalanceDeSaldosFiscalServicio>();
            Mvx.Ioc.RegisterType<IBalanceDeSaldosFiscalControlador, BalanceDeSaldosFiscalControlador>();
            Mvx.Ioc.RegisterSingleton<IBalanceDeSaldosFiscalVista, BalanceDeSaldosFiscalVista>(this);
            Mvx.Ioc.Resolve<IBalanceDeSaldosFiscalControlador>();
        }

        private void BalanceDeSaldosFiscalVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
        }

        #endregion

        #region Eventos de Controles

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UsuarioDeseaObtenerBalanceDeSaldosFiscal?.Invoke(null, null);
        }

        private void UiBotonExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistasBalance.ShowPrintPreview();
        }

        private void UiBotonImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GenerarReporte();
        }

        private void UiBotonExpadir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaBalanceDeSaldos.ExpandAllGroups();
        }

        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaBalanceDeSaldos.CollapseAllGroups();
        }

        #endregion

        #region Metodos

        private void GenerarReporte()
        {
            try
            {
                var listaBalanceTemporal = new List<BalanceDeSaldosFiscal>();
                for (var i = 0; i < UiVistaBalanceDeSaldos.RowCount; i++)
                {
                    if (!UiVistaBalanceDeSaldos.IsGroupRow(i))
                        listaBalanceTemporal.Add((BalanceDeSaldosFiscal)UiVistaBalanceDeSaldos.GetRow(i));
                }
                var listaBalanceParaReporte =
                    listaBalanceTemporal.GroupBy(
                        b =>
                            new
                            {
                                b.CLIENT_NAME,
                                b.DOC_ID,
                                b.CODIGO_POLIZA,
                                b.NUMERO_ORDEN,
                                b.FECHA_DOCUMENTO,
                                b.MATERIAL_NAME,
                                b.LINE_NUMBER,
                                b.REGIMEN_DOCUMENTO,
                                b.GRUPO_REGIMEN
                            }).Select(b => new BalanceDeSaldosFiscal
                            {
                                CLIENT_NAME = b.Key.CLIENT_NAME
                                ,DOC_ID = b.Key.DOC_ID
                                ,CODIGO_POLIZA = b.Key.CODIGO_POLIZA
                                ,NUMERO_ORDEN = b.Key.NUMERO_ORDEN
                                ,FECHA_DOCUMENTO = b.Key.FECHA_DOCUMENTO
                                ,MATERIAL_NAME = b.Key.MATERIAL_NAME
                                ,LINE_NUMBER = b.Key.LINE_NUMBER
                                ,REGIMEN_DOCUMENTO = b.Key.REGIMEN_DOCUMENTO
                                ,GRUPO_REGIMEN = b.Key.GRUPO_REGIMEN
                                ,BULTOS = b.Sum(bt=> bt.BULTOS)
                                ,VALOR_CIF = b.Sum(bt => bt.VALOR_CIF)
                                ,IMPUESTO = b.Sum(bt => bt.IMPUESTO)
                            }).ToList();

                var reporte = new Reportes.BalanceDeSaldosFiscal()
                {
                    DataSource = ListToDataTableClass.ListToDataTable(listaBalanceParaReporte),
                    DataMember = "BalanceDeSaldosFiscal",
                    RequestParameters = false
                };
                reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
                reporte.Parameters["NombreEmpresa"].Value = InteraccionConUsuarioServicio.ObtenerNombreEmpresa(); 
                reporte.FillDataSource();

                using (var printTool = new ReportPrintTool(reporte))
                {
                    printTool.ShowRibbonPreviewDialog();
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }



        #endregion

        
    }
}
