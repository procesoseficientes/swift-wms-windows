using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class BalanceDeSaldosFiscal
    {
        public string CLIENT_NAME { get; set; }
        public int DOC_ID  { get; set; }
        public string CODIGO_POLIZA  { get; set; }
        public string NUMERO_ORDEN { get; set; }
        public int LICENSE_ID { get; set; }
        public DateTime FECHA_DOCUMENTO { get; set; }
        public string MATERIAL_NAME { get; set; }
        public int LINE_NUMBER { get; set; }
        public decimal BULTOS { get; set; }
        public decimal CUSTOMS_AMOUNT { get; set; }
        public decimal VALOR_CIF { get; set; }
        public decimal IMPUESTO { get; set; }
        public string REGIMEN_DOCUMENTO { get; set; }
        public string GRUPO_REGIMEN { get; set; }
    }
}
