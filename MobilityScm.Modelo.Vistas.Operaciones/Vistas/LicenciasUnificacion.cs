using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobilityScm.Louncher;
using MobilityScm.Keyboard;
using MobilityScm.Modelo.Estados;
using MobilityScm.Print.Zebra;
using Resco.Controls.AdvancedTree;

namespace MobilityScm.Modelo.Vistas.Operaciones.Vistas
{
    public partial class LicenciasUnificacion : UserControl, IControl
    {
        public LicenciasUnificacion()
        {
            InitializeComponent();
            IsNew = true;
        }

        public static string Ubicacion;
        public static string CodigoMaterial;
        public static string Usuario;

        public static DataSet Licencias;

        #region IControl Members
        public bool IsNew { get; set; }
        public void UnLoad()
        {
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.DataReady -= BarcodeScanner_DataReady;
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.Disabled();
        }

        public void Load()
        {
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.DataReady += new EventHandler<MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg>(BarcodeScanner_DataReady);
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.Enabled();
            UiTreeDetalle.Nodes.Clear();
            ArmarArbol(Licencias);
        }

        void BarcodeScanner_DataReady(object sender, MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg e)
        {

        }

        private static LicenciasUnificacion _LicenciasUnificacion;
        public static LicenciasUnificacion Create(DataSet licencias)
        {
            Licencias = licencias;

            if (_LicenciasUnificacion != null)
            {
                return _LicenciasUnificacion;
            }

            _LicenciasUnificacion = new LicenciasUnificacion();
            return _LicenciasUnificacion;
        }
        #endregion

        #region Metodos
        private void UsuarioPresionoBoton(object sender, KeyEventArgs e)
        {
            switch (e.ObtenerActionDeBoton(VariablesDeAmbienteOperaciones.Ambiente, VariablesDeAmbienteOperaciones.DireccionDeServicio))
            {
                case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR:
                    int pantallasARegresar = 1;
                    if (UiTreeDetalle.Nodes.Count > 0)
                    {
                        pantallasARegresar = DetalleDeUnificacion.Ubicacion != null ? 2 : 1;
                        EscaneadoDeUnificacion.Ubicacion = null;
                        DetalleDeUnificacion.Ubicacion = null;
                    }

                    this.Back(pantallasARegresar);
                    break;
                default:
                    break;
            }
        }

        private void ArmarArbol(DataSet ds)
        {
            try
            {
                foreach (DataRow lic in ds.Tables[0].Rows)
                {
                    BoundNode nodoLic = new BoundNode(0, 0, lic);
                    UiTreeDetalle.Nodes.Add(nodoLic);
                    var materiales = lic.GetChildRows(Tipos.RelacionDataSetUnificacion.LICENCIA_A_MATERIAL.ToString());

                    if (materiales.Length == 0)
                    {
                        nodoLic.HidePlusMinus = true;
                    }
                    nodoLic.Collapse();

                    foreach (DataRow material in materiales)
                    {
                        BoundNode nodoMat = new BoundNode(1, 1, material);
                        nodoLic.Nodes.Add(nodoMat);

                        var detalles = material.GetChildRows(Tipos.RelacionDataSetUnificacion.INFORMACION_MATERIAL.ToString());
                        if (detalles.Length == 0)
                        {
                            nodoLic.HidePlusMinus = true;
                        }

                        foreach (DataRow det in detalles)
                        {
                            BoundNode nodoDet = new BoundNode(2, 2, det);
                            nodoDet.HidePlusMinus = true;
                            nodoMat.Nodes.Add(nodoDet);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
        }
        #endregion

        #region Eventos de Controles
        private void LicenciasUnificacion_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiTreeDetalle_KeyUp_1(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiTreeDetalle_ButtonClick(object sender, CellEventArgs e)
        {
            var resultado = "";
            var licencia = e.Cell[e.Node, 0].ToString();
            var servicio = new MobilityScm.Modelo.Vistas.Operaciones.WMS_InfoTrans.WMS_InfoTrans(true);
            string result = string.Empty;
            string regimen = servicio.ObtenerValorProyectoEnBaseALicencia(int.Parse(licencia), VariablesDeAmbienteOperaciones.Ambiente);

            PrintModule.ImprimirLicencia(false, int.Parse(licencia), regimen, VariablesDeAmbienteOperaciones.Empresa, VariablesDeAmbienteOperaciones.Usuario, ref resultado, VariablesDeAmbienteOperaciones.DireccionDeImpresora);
        }
        #endregion

    }
}
