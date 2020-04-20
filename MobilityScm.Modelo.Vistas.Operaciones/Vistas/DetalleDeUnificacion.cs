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
    public partial class DetalleDeUnificacion : UserControl, IControl
    {
        public DetalleDeUnificacion()
        {
            InitializeComponent();
            IsNew = true;
        }

        public static string Ubicacion;
        public static string CodigoMaterial;

        #region IControl Members
        public bool IsNew { get; set; }
        public void UnLoad()
        {
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.DataReady -= BarcodeScanner_DataReady;            
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.Disabled();
            
        }

        public void Load()
        {
            ObtenerDetalle(Ubicacion, CodigoMaterial);
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.DataReady += new EventHandler<MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg>(BarcodeScanner_DataReady);
            VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras.Enabled();
        }

        void BarcodeScanner_DataReady(object sender, MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg e)
        {
            
        }

        private static DetalleDeUnificacion _DetalleDeUnificacion;
        public static DetalleDeUnificacion Create(string ubicacion, string material)
        {
            Ubicacion = ubicacion;
            CodigoMaterial = material;

            if (_DetalleDeUnificacion != null)
            {
                return _DetalleDeUnificacion;
            }

            _DetalleDeUnificacion = new DetalleDeUnificacion();
            return _DetalleDeUnificacion;
        }
        #endregion

        #region Metodos
        private void ObtenerDetalle(string ubicacion, string material)
        {
            try
            {   
                string res = string.Empty;
                var servicio = new WMS_Trans.WMS_Trans(true);
                var dataSet = servicio.ObtenerMaterialesEnUnbicacionParaUnificar(ubicacion, material, ref res, VariablesDeAmbienteOperaciones.Ambiente);
                UiTreeDetalle.Nodes.Clear();

                if (res == Tipos.Ok.OK.ToString())
                {
                    ArmarArbol(dataSet);
                    return;
                }
                else
                {
                    MessageBox.Show(res, "Error");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
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

        private void UsuarioPresionoBoton(object sender, KeyEventArgs e)
        {
            switch (e.ObtenerActionDeBoton(VariablesDeAmbienteOperaciones.Ambiente, VariablesDeAmbienteOperaciones.DireccionDeServicio))
            {
                case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR:
                    this.Back();
                    break;
                default:
                    break;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(Ubicacion))
            {
                MessageBox.Show("Debe de escanear una ubicación para unificarla.", "Error");
                return false;
            }
            return true;
        }

        private DataSet UnificarLicencias()
        {
            try
            {
                string respuesta = "";
                var servicio = new MobilityScm.Modelo.Vistas.Operaciones.WMS_Trans.WMS_Trans(true);
                var resultado = servicio.UnificarLicenciasPorUbicacionYMaterial(Ubicacion, CodigoMaterial, VariablesDeAmbienteOperaciones.Usuario, ref respuesta, VariablesDeAmbienteOperaciones.Ambiente);

                if (respuesta == Tipos.Ok.OK.ToString())
                {
                    return resultado;
                }
                else
                {
                    MessageBox.Show(respuesta, "Error");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return null;
            }
        }

        private void UiTreeDetalle_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void DetalleDeUnificacion_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiPanelBotones_KeyUp(object sender, KeyEventArgs e)
        {
            UsuarioPresionoBoton(sender, e);
        }

        private void UiBotonUnificarLicencias_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (MessageBox.Show("¿Desea unificar esta ubicación?", "Unificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    var licencias = UnificarLicencias();
                    if (licencias != null)
                    {
                        LicenciasUnificacion.Create(licencias).ShowPane();
                    }
                }
            }
        }
        #endregion

    }
}
