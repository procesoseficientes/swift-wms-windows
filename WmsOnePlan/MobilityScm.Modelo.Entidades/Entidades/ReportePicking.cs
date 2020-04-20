using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class ReportePicking
    {
        public decimal WAVE_PICKING_ID { get; set; }
        public string DOC_NUM { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_BY_NAME { get; set; }
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME   { get; set; }
        public decimal MATERIAL_COST { get; set; }
        public string WAREHOUSE_NAME { get; set; }
        public decimal QUANTITY_ASSIGNED   { get; set; }
        public string ASSIGNED_TO { get; set; }
        public string ASSIGNED_TO_NAME    { get; set; }
        public string ASSIGNED_DATE { get; set; }
        public string ACCEPTED_DATE   { get; set; }
        public string COMPLETED_DATE { get; set; }
        public string ACCEPTED_CREATED_INTERVAL   { get; set; }
        public int ACCEPTED_CREATED_INTERVAL_MINUTES { get; set; }
        public string PICKING_TIME    { get; set; }
        public int PICKING_TIME_MINUTES { get; set; }
        public string TOTAL_TIME_PICKING  { get; set; }
        public int TOTAL_TIME_PICKING_MINUTES { get; set; }
        public string TOTAL_TIME_FROM_TASK_ASSIGNED   { get; set; }
        public int TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES { get; set; }
        public int TASK_ORDER { get; set; }
    }
}
