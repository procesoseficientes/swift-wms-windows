using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public partial class AcuerdoComercialVista : VistaBase, IAcuerdoComercialPorInventarioVista
    {

#region Eventos
        public event EventHandler<AcuerdoComercialArgumento> UsuarioDeseaObtenerAcuerdoComercialPorInventario;
        //public event EventHandler UsuarioDeseaObtenerClientes;
        public event EventHandler VistaCargandosePorPrimeraVez;

        #endregion

        #region Propiedades 

        public IList<AcuerdoComercial> AcuerdosComerciales
        {
            get { return (IList<AcuerdoComercial>) UiVistaInventarioPorAcuerdoComercial.DataSource; }

            set { UiVistaInventarioPorAcuerdoComercial.DataSource = value; }
        }

        public IList<Cliente> Clientes
        {
            get
            {
                return (IList<Cliente>)UiListaDeCliente.Properties.DataSource;
            }

            set
            {
                UiListaDeCliente.Properties.DataSource = value;
            }
        }

        public string Usuario
        {
            get { return null; }

            set { value = null; }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; private set; }

        #endregion

        public AcuerdoComercialVista()
        {
            InitializeComponent();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.RegisterType<IAcuerdoComercialServicio, AcuerdoComercialServicio>();
            Mvx.Ioc.RegisterType<IClienteServicio, ClienteServicio>();
            Mvx.Ioc.RegisterType<IAcuerdoComercialPorInventarioControlador, AcuerdoComercialPorInventarioControlador>();
            Mvx.Ioc.RegisterSingleton<IAcuerdoComercialPorInventarioVista, AcuerdoComercialVista>(this);
            Mvx.Ioc.Resolve<IAcuerdoComercialPorInventarioControlador>();
            switch (WindowState)
            {
                    
            }    
        }
        
        private void AcuerdoComercialVista_Load(object sender, EventArgs e)
        {
            UiFechaInicio.EditValue = DateTime.Today;
            UiFechaFinal.EditValue = DateTime.Today;
            VistaCargandosePorPrimeraVez?.Invoke(sender,e);
            UiListaDeCliente.Properties.PopupFormWidth = UiListaDeCliente.Width;
        }

        #region Metodos
        private string ObtenerClientesSeleccionados()
        {
            var cadenaCliente = new StringBuilder();
            foreach (var cliente in UiListaDeCliente.Properties.View.GetSelectedRows().Select(indice => (Cliente)UiListaDeCliente.Properties.View.GetRow(indice)))
            {
                if (cadenaCliente.Length > 0)
                {
                    cadenaCliente.Append("|");
                }
                cadenaCliente.Append(cliente.CLIENT_CODE);
            }
            return cadenaCliente.ToString();
        }
        #endregion

        #region Eventos de Controles
        private void UiBtnRefrescarVistaPrincipal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Convert.ToDateTime(UiFechaInicio.EditValue) > Convert.ToDateTime(UiFechaFinal.EditValue))
            {
                InteraccionConUsuarioServicio.Mensaje(
                    "La fecha de inicio es mayor a la fecha final, por favor, verifique y vuelva a intentar.");
            }
            else
            {
                var clientes = ObtenerClientesSeleccionados();
                if (string.IsNullOrEmpty(clientes))
                {
                    InteraccionConUsuarioServicio.Mensaje(
                        "No ha seleccionado clientes, por favor, verifique y vuelva a intentar.");
                }
                else
                {
                    UsuarioDeseaObtenerAcuerdoComercialPorInventario?.Invoke(sender, new AcuerdoComercialArgumento
                    {
                        FechaInicio = DateTime.Parse(UiFechaInicio.EditValue.ToString())
                        ,FechaFin = DateTime.Parse(UiFechaFinal.EditValue.ToString())
                        ,IdCliente = clientes
                        ,Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                    });
                }
            }
        }

        private void UiListaDeCliente_Properties_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            StringBuilder cadena = new StringBuilder();
            foreach (var cliente in UiListaDeCliente.Properties.View.GetSelectedRows().Select(indice => (Cliente)UiListaDeCliente.Properties.View.GetRow(indice)))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(cliente.CLIENT_CODE);
            }
            e.DisplayText = cadena.ToString();
        }


        #endregion

        private void UiBtnGenerarReporteExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UiVistaInventarioPorAcuerdoComercial.DataSource == null)
            {
                InteraccionConUsuarioServicio.Mensaje(
                    "No se encontraron datos para generar el reporte, por favor, verifique y vuelva a intentar.");
            }
            else
            {
                var dialog = new SaveFileDialog
                {
                    DefaultExt = "xlsx",
                    Filter = @"Archivos de excel (*.xlsx)|*.xlsx"
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    UiVistaInventarioPorAcuerdoComercial.ExportToXlsx(dialog.FileName);
                }
            }
        }

        private void UiBtnImprimirReporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UiVistaInventarioPorAcuerdoComercial.DataSource == null)
            {
                InteraccionConUsuarioServicio.Mensaje(
                    "No se encontraron datos para generar el reporte, por favor, verifique y vuelva a intentar.");
            }
            else
            {
                var listaDeInventarioPorAcuerdoComercial = new List<AcuerdoComercial>();
                for (var i = 0; i < UiVistaInventarioPorAcuerdoComercial.Views[0].RowCount; i++)
                {
                    listaDeInventarioPorAcuerdoComercial.Add((AcuerdoComercial)UiVistaInventarioPorAcuerdoComercial.Views[0].GetRow(i));
                }
                var reporte = new Reportes.AcuerdoComercialPorInventario
                {
                    DataSource = ListToDataTableClass.ListToDataTable(listaDeInventarioPorAcuerdoComercial),
                    DataMember = "AcuerdoComercial",
                    RequestParameters = false
                };
                reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
                reporte.FillDataSource();

                using (var printTool = new ReportPrintTool(reporte))
                {
                    printTool.ShowRibbonPreviewDialog();
                }
            }
        }

        private void UiListaDeCliente_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag == "REFRESH")
            {
                ((GridLookUpEdit)sender).ClosePopup();
            }
        }

        private void UiListaDeCliente_Properties_CloseUp(object sender, CloseUpEventArgs e)
        {
            var edit = ActiveControl as GridLookUpEdit;
            StringBuilder cadena = new StringBuilder();
            foreach (var cliente in UiListaDeCliente.Properties.View.GetSelectedRows().Select(indice => (Cliente)UiListaDeCliente.Properties.View.GetRow(indice)))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(cliente.CLIENT_CODE);
            }
            edit.Text = cadena.Length == 0 ? "..." : cadena.ToString();
            
        }
    }
}