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

namespace MobilityScm.Modelo.Vistas.Operaciones.Vistas
{
    public partial class DetalleImplosion : UserControl, IControl
    {
        public DetalleImplosion()
        {
            InitializeComponent();
            IsNew = true;   
        }

        private static int Licencia;
        private static string CodigoMasterPack;
        private static decimal Cantidad; 

        #region IControl Members
        public bool IsNew { get; set; }

        public void UnLoad()
        {
        }

        public void Load()
        {
            try
            {
                UiListaDetalle.DataSource = null;

                var servicio = new Wms_Materials.WMS_Materials(true);
                string resultado = string.Empty;
                var tabla = servicio.ObtenerDetalleDeImplosionEnProceso(VariablesDeAmbienteOperaciones.Ambiente, ref resultado, Licencia, CodigoMasterPack, 0);
                if (resultado != "OK")
                {
                    MessageBox.Show(resultado, "Error");
                }

                if (tabla != null && tabla.Rows.Count > 0)
                {
                    UiListaDetalle.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private static DetalleImplosion _DetalleImplosion;
        public static DetalleImplosion Create(int licencia, string codigoMasterPack)
        {
            Licencia = licencia;
            CodigoMasterPack = codigoMasterPack;
            
            if (_DetalleImplosion != null)
            {
                return _DetalleImplosion;
            }

            _DetalleImplosion = new DetalleImplosion();
            return _DetalleImplosion;
        }
        #endregion

        private void UiListaDetalle_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.ObtenerActionDeBoton(VariablesDeAmbienteOperaciones.Ambiente, VariablesDeAmbienteOperaciones.DireccionDeServicio) == MobilityScm.Modelo.Tipos.FuncionBoton.SALIR)
            {
                this.Back();
            }
        }
    }
}
