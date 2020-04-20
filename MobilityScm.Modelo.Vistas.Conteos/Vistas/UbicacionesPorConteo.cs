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

namespace MobilityScm.Modelo.Vistas
{
    public partial class UbicacionesPorConteo : UserControl, IControl
    {

        public static int TaskId { get; set; }

        public UbicacionesPorConteo()
        {
            InitializeComponent();
            IsNew = true;
        }

        #region IControl Members

        public bool IsNew { get; set; }

        public void UnLoad()
        {
            //remove handlers
            VariablesDeAmbiente.BarcodeScanner.DataReady -= BarcodeScanner_DataReady;
            VariablesDeAmbiente.BarcodeScanner.Disabled();
        }
        public void Load()
        {


           
                VariablesDeAmbiente.BarcodeScanner.DataReady += new EventHandler<MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg>(BarcodeScanner_DataReady);
                VariablesDeAmbiente.BarcodeScanner.Enabled();
                _UbicacionesPorConteo.LlenarListaUbicacionesPorConteo();
           
        }

        #endregion


        private static UbicacionesPorConteo _UbicacionesPorConteo;
        public static UbicacionesPorConteo Create(int taskId)
        {
            TaskId = taskId;


            if (_UbicacionesPorConteo != null)
            {

                return _UbicacionesPorConteo;
            }

            _UbicacionesPorConteo = new UbicacionesPorConteo();

            return _UbicacionesPorConteo;
        }

        static void BarcodeScanner_DataReady(object sender, MobilityScm.BarcodeScann.Arguments.BarcodeDataEventArg e)
        {
            try
            {
                WMS_InfoTrans.WMS_InfoTrans client = new MobilityScm.Modelo.WMS_InfoTrans.WMS_InfoTrans(true);
                string pResult = string.Empty;
                DataTable dtResult;
                dtResult = client.ValidateTaskStatus(VariablesDeAmbiente.UserId, 0, Convert.ToInt32(TaskId), 0
                                                        , "", "TAREA_CONTEO", VariablesDeAmbiente.Enviroment, ref  pResult);

                if (pResult == "OK" && (int)dtResult.Rows[0][0] == 1)
                {
                    string ubicacion = e.BarcodeData.Remove(e.BarcodeData.Length - 1, 1);
                    pResult = "OK";
                    WMS_PhisicalCouting.WMS_Phisical_Couting ws = new MobilityScm.Modelo.WMS_PhisicalCouting.WMS_Phisical_Couting(true);

                    DataTable dt = ws.ValidateScannedLocationForCountingTask(
                        VariablesDeAmbiente.UserId, TaskId, ubicacion, ref pResult, VariablesDeAmbiente.Enviroment);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        switch (Convert.ToInt32(dt.Rows[0]["Codigo"].ToString()))
                        {
                            case 2:
                                LicenciaPorConteo.Create(TaskId, ubicacion).ShowPane();
                                break;
                            case -1:
                                MessageBox.Show(dt.Rows[0]["Mensaje"].ToString(), "Error");
                                break;
                            case 0:
                                MessageBox.Show(dt.Rows[0]["Mensaje"].ToString(), "Error");
                                break;
                            case 1:
                                if (MessageBox.Show("Ubicación ya ha sido contada, ¿desea realizar un reconteo?", "MobilitySCM", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    pResult = "OK";
                                    ws.RecountLocation(
                                        VariablesDeAmbiente.UserId, TaskId, ubicacion, ref pResult, VariablesDeAmbiente.Enviroment);
                                    if (pResult != "OK")
                                        MessageBox.Show(pResult, "Error");
                                    else
                                        LicenciaPorConteo.Create(TaskId, ubicacion).ShowPane();
                                }
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró información de ubicación.", "Error");
                    }
                }
                else
                {
                    MessageBox.Show(pResult == "OK" ? dtResult.Rows[0][1].ToString() : pResult, "Error");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }


        }



        #region Metodos

        public void LlenarListaUbicacionesPorConteo()
        {
            try
            {
                var servicio = new MobilityScm.Modelo.WMS_PhisicalCouting.WMS_Phisical_Couting(true);
                var resultado = string.Empty;
                UiListaUbicacionesPorConteo.DataSource = servicio.GetLocationsForCount(VariablesDeAmbiente.UserId, TaskId, ref resultado, VariablesDeAmbiente.Enviroment);
                if (UiListaUbicacionesPorConteo.DataSource == null || ((DataTable)UiListaUbicacionesPorConteo.DataSource).Rows.Count <= 0)
                {
                    this.Back();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        #endregion

        #region Eventos de Controles

        private void UbicacionesPorConteo_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.ObtenerActionDeBoton(VariablesDeAmbiente.Enviroment, VariablesDeAmbiente.WsHost))
            {
                case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR:

                    break;
                case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR:
                    this.Back();
                    break;
                case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR:
                    break;
                case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR:
                    break;
            }
        }

        #endregion



    }
}
