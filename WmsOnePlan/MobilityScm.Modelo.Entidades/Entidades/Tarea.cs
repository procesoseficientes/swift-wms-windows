using System;
using System.Collections;
using System.Collections.Generic;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class Tarea
    {
        public decimal SERIAL_NUMBER { get; set; }

        public DateTime PICKING_FINISHED_DATE { get; set; }


        public decimal TASK_OR_WAVE_ID
        {
            get
            {
                if (TASK_TYPE == "TAREA_RECEPCION")
                {
                    return SERIAL_NUMBER;
                }
                else
                {
                    return WAVE_PICKING_ID.Value;
                }
            }
        }

        public decimal? WAVE_PICKING_ID { get; set; }

        public decimal PHYSICAL_COUNT_HEADER_ID { get; set; }

        public decimal? TRANS_OWNER { get; set; }

        public string TASK_TYPE { get; set; }

        public string TASK_SUBTYPE { get; set; }

        public string TASK_OWNER { get; set; }

        public string TASK_ASSIGNEDTO { get; set; }

        public string TASK_COMMENTS { get; set; }

        public DateTime ASSIGNED_DATE { get; set; }

        public decimal QUANTITY_PENDING { get; set; }

        public decimal QUANTITY_ASSIGNED { get; set; }

        public int CODIGO_POLIZA_SOURCE { get; set; }
        public string CODIGO_POLIZA_SOURCE2 { get; set; }

        public string CODIGO_POLIZA_TARGET { get; set; }

        public decimal? LICENSE_ID_SOURCE { get; set; }

        public string REGIMEN { get; set; }

        public string IS_COMPLETED { get; set; }

        public int IS_DISCRETIONAL { get; set; }

        public decimal IS_PAUSED { get; set; }

        public decimal? IS_CANCELED { get; set; }

        public string MATERIAL_ID { get; set; }

        public string BARCODE_ID { get; set; }

        public string ALTERNATE_BARCODE { get; set; }

        public string MATERIAL_NAME { get; set; }

        public string WAREHOUSE_SOURCE { get; set; }

        public string WAREHOUSE_TARGET { get; set; }

        public string LOCATION_SPOT_SOURCE { get; set; }

        public string LOCATION_SPOT_TARGET { get; set; }

        public string CLIENT_OWNER { get; set; }

        public string CLIENT_NAME { get; set; }

        public DateTime? ACCEPTED_DATE { get; set; }

        public DateTime? COMPLETED_DATE { get; set; }

        public DateTime? CANCELED_DATETIME { get; set; }

        public string CANCELED_BY { get; set; }

        public string MATERIAL_SHORT_NAME { get; set; }

        public string IS_lOCKED { get; set; }

        public int IS_DISCRETIONARY { get; set; }

        public string TYPE_DISCRETIONARY { get; set; }

        public int? LINE_NUMBER_POLIZA_SOURCE { get; set; }

        public int? LINE_NUMBER_POLIZA_TARGET { get; set; }

        public decimal? DOC_ID_SOURCE { get; set; }

        public decimal? DOC_ID_TARGET { get; set; }

        public int? IS_ACCEPTED { get; set; }

        public string IS_FROM_SONDA { get; set; }

        public string IS_FROM_ERP { get; set; }

        public int? PRIORITY { get; set; }

        public int TASK_ID { get; set; }

        public string CREATE_BY { get; set; }

        public string TASK_ASSIGNED_TO { get; set; }

        public int IS_COMPLETE { get; set; }

        public DateTime? CANCELED_DATE { get; set; }

        public string COMMENTS { get; set; }

        public string NO_DOC { get; set; }
        public int PICKING_DEMAND_HEADER_ID { get; set; }
        public int WMS_DOCUMENT_HEADER_ID { get; set; }
        public string DOC_ID { get; set; }
        public string DOC_ID_GRID { get; set; }
        public int ATTEMPTED_WITH_ERROR { get; set; }
        public int IS_POSTED_ERP { get; set; }
        public string STATUS_POSTED_ERP { get; set; }
        public DateTime POSTED_ERP { get; set; }
        public string POSTED_RESPONSE { get; set; }
        public string ERP_REFERENCE { get; set; }
        public int IS_AUTHORIZED { get; set; }
        public int MAX_ATTEMPTS { get; set; }
        public string CODE_ROUTE { get; set; }
        public int USE_PICKING_LINE { get; set; }
        public int TIME { get; set; }
        public List<TareaDetalleErp> DetalleErp { get; set; }
        public bool IS_SELECTED { get; set; }
        public string IS_PAUSED_DESCRIPTION { get; set; }
        public string IS_AUTHORIZED_DESCRIPTION { get; set; }
        public string OWNER { get; set; }
        public int IN_PICKING_LINE { get; set; }
        public string PRIORITY_DESCRIPTION { get; set; }
        public string SOURCE_TYPE { get; set; }
        public decimal QUANTITY_ASSIGNED_TASK { get; set; }
        public int COMPLETED_DOC_ERP { get; set; }

        public string ORDER_NUMBER { get; set; }
        public Guid PROJECT_ID { get; set; }
        public string PROJECT_CODE { get; set; }
        public string PROJECT_NAME { get; set; }
        public string PROJECT_SHORT_NAME { get; set; }
        public string DOC_NUM { get; set; }
        public string BATCH { get; set; }
        public DateTime? DATE_EXPIRATION { get; set; }
        public string TONE { get; set; }
        public string CALIBER { get; set; }
        public string STATUS_CODE { get; set; }
        public int LICENSE_ID_TARGET { get; set; }
        public string STATUS { get; set; }
    }
}
