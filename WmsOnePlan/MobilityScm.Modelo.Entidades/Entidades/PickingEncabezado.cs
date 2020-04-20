using System;
using System.Collections.Generic;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class Picking
    {
        public string TASK_OWNER { get; set; }
        public int PICKING_HEADER { get; set; }

        public string CLASSIFICATION_PICKING { get; set; }

        public string CODE_CLIENT { get; set; }

        public string CODE_USER { get; set; }

        public string REFERENCE { get; set; }

        public string DOC_SAP_RECEPTION { get; set; }

        public string STATUS { get; set; }

        public DateTime LAST_UPDATE { get; set; }

        public string LAST_UPDATE_BY { get; set; }

        public string COMMENTS { get; set; }

        public DateTime SCHEDULE_FOR { get; set; }

        public int SEQ { get; set; }

        public string FF { get; set; }

        public string FF_STATUS { get; set; }

        public string CODE_WAREHOUSE_SOURCE { get; set; }

        public string CODE_SELLER { get; set; }

        public string CODE_ROUTE { get; set; }

        //public IList<PickingDetalle> Detalles { get; set; }

        public int SOURCE_DOC { get; set; }

        public string ERP_REFERENCE { get; set; }
        public object TASK_ASSIGNEDTO { get; set; }
        public object QUANTITY_ASSIGNED { get; set; }
        public object CODIGO_POLIZA_TARGET { get; set; }
        public object MATERIAL_ID { get; set; }
        public object BARCODE_ID { get; set; }
        public object ALTERNATE_BARCODE { get; set; }
        public object MATERIAL_NAME { get; set; }
        public object CLIENT_OWNER { get; set; }
        public string CLIENT_NAME { get; set; }
        public int IS_FROM_SONDA { get; set; }
        public int IS_FROM_ERP { get; set; }

        public int WAVE_PICKING_ID { get; set; }
        public DateTime ASSIGNED_DATE { get; set; }
        public string WAREHOUSE_SOURCE { get; set; }
        public string CLIENT_CODE { get; set; }

        public bool IS_SELECTED { get; set; }

        public int WAS_IMPLODED { get; set; }
        public int QTY_IMPLODED { get; set; }

        public string ERP_REFERENCE_DOC_NUM { get; set; }

        public string ADDRESS_CUSTOMER { get; set; }

        public int STATE_CODE { get; set; }

        public int? PICKING_DEMAND_HEADER_ID { get; set; }

        public string TONE { get; set; }

        public string CALIBER { get; set; }

        public int IN_PICKING_LINE { get; set; }

        public string STATE { get; set; }

        public int TYPE_DEMAND_CODE { get; set; }

        public string TYPE_DEMAND_NAME { get; set; }

        public string ORDER_NUMBER { get; set; }

        public string LOCATION_SPOT_TARGET { get; set; }
    }
}
