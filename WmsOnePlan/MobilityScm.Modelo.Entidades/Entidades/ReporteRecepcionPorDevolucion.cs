using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class ReporteRecepcionPorDevolucion
    {
        public string INVOICE_DOC_NUM { get; set; }

        public string CLIENT_CODE { get; set; }

        public string CLIENT_NAME { get; set; }

        public string PLATE_NUMBER { get; set; }

        public int IS_POSTED_ERP { get; set; }

        public int TASK_ID { get; set; }

        public string ERP_REFERENCE_DOC_NUM { get; set; }

        public string MATERIAL_ID { get; set; }

        public string MATERIAL_NAME { get; set; }

        public decimal QTY { get; set; }

        public decimal RECEPTION_QTY { get; set; }

        public string ENVIADO => MobilityScm.Modelo.Configuracion.Enums
            .GetEnumValueFromStringValue<Modelo.Estados.EnviadoErpRecepcion>(IS_POSTED_ERP.ToString()).ToString();
    }
}
