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
    public partial class TareaConteo : UserControl, IControl
    {

        public TareaConteo()
        {
            InitializeComponent();
            IsNew = true;
        }

        #region IControl Members

        public bool IsNew { get; set; }

        public void UnLoad()
        {
            //remove handlers
        }

        public void Load()
        {
            _TareaConteo.LlenarListaTareasConteo();
        }

        #endregion

        private static TareaConteo _TareaConteo;
        public static TareaConteo Create()
        {
            if (_TareaConteo != null)
            {
                _TareaConteo.LlenarListaTareasConteo();
                return _TareaConteo;
            }

            _TareaConteo = new TareaConteo();
            return _TareaConteo;
        }

        #region Metodos

        public void LlenarListaTareasConteo()
        {
            try
            {
                var servicio = new MobilityScm.Modelo.WMS_PhisicalCouting.WMS_Phisical_Couting(true);
                var resultado = string.Empty;
                UiListaTareas.DataSource = servicio.GetMyCountingTask(VariablesDeAmbiente.UserId, ref resultado, VariablesDeAmbiente.Enviroment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        #endregion

        #region Eventos de Controles

        private void UiListaTareas_ButtonClick(object sender, Resco.Controls.AdvancedList.CellEventArgs e)
        {
            var taskId = e.DataRow["TASK_ID"].ToString();

            try
            {
                WMS_InfoTrans.WMS_InfoTrans client = new MobilityScm.Modelo.WMS_InfoTrans.WMS_InfoTrans(true);
                string pResult = string.Empty;
                DataTable dtResult;
                dtResult = client.ValidateTaskStatus(VariablesDeAmbiente.UserId, 0, Convert.ToInt32(taskId), 0
                                                        , "", "TAREA_CONTEO", VariablesDeAmbiente.Enviroment, ref  pResult);

                if (pResult == "OK" && (int)dtResult.Rows[0][0] == 1)
                {
                    UbicacionesPorConteo.Create(int.Parse(taskId)).ShowPane();
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

        private void TareaConteo_KeyUp(object sender, KeyEventArgs e)
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
                    LlenarListaTareasConteo();
                    break;
            }
        }

        #endregion


    }
}
