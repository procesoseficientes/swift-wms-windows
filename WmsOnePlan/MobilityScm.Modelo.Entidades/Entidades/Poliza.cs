using System;

namespace MobilityScm.Modelo.Entidades
{
    public class Poliza
    {

        public Poliza()
        {
            NUMERO_ORDEN = "";
            ADUANA_ENTRADA_SALIDA = "";
            NUMERO_DUA = "";
            FECHA_ACEPTACION_DMY = "";
            ADUANA_DESPACHO_DESTINO = "";
            REGIMEN = "";
            CLASE = "";
            PAIS_PROCEDENCIA = "";
            NATURALEZA_TRANS = "";
            DEPOSITO_FISCAL_ZF = "";
            MODO = 0;
            FECHA_LLEGADA = DateTime.Now;
            TIPO_CAMBIO = 0;
            TOTAL_VALOR_ADUANA = 0;
            TOTAL_NUMERO_LINEAS = 0;
            TOTAL_BULTOS = 0;
            TOTAL_PESO_BRUTO_KG = 0;
            TOTAL_FOB_USD = 0;
            TOTAL_FLETE_USD = 0;
            TOTAL_SEGURO_USD = 0;
            TOTAL_OTROS_USD = 0;
            NUMERO_SAT = "";
            TIPO_IMPORTADOR = "";
            ID_TRIB_IMPORTADOR = "";
            PAIS_IMPORTADOR = "";
            RAZON_SOCIAL_IMPORTADOR = "";
            DOMICILIO_IMPORTADOR = "";
            TIPO_REPRESENTANTE = "";
            ID_TRIB_REPRESENTANTE = "";
            PAIS_REPRESENTANTE = "";
            TIPO_DECLARANTE_REPRESENTANTE = "";
            RAZON_SOCIAL_REPRESENTANTE = "";
            DOMICILIO_REPRESENTANTE = "";
            TIPO_CONTENEDOR = 0;
            NUMERO_CONTENEDOR = "";
            ENTIDAD_CONTENEDOR = "";
            NUMERO_MARCHAMO_CONTENEDOR = "";
            TOTAL_LIQUIDAR = 0;
            TOTAL_OTROS = 0;
            TOTAL_GENERAL = 0;
            CODIGO_POLIZA = "0";
            LAST_UPDATED = DateTime.Now;
            STATUS = "CREATED";
            WAREHOUSE_REGIMEN = "GENERAL";
            FECHA_DOCUMENTO = DateTime.Now;
            ACUERDO_COMERCIAL = "";
            TIPO = "EGRESO";
            PolizaAsegurada = "";
            PolizaAssognedto = "";
            Translation = "NO";
        }
        public string NUMERO_ORDEN { get; set; }
        public string ADUANA_ENTRADA_SALIDA { get; set; }
        public string NUMERO_DUA { get; set; }
        public string FECHA_ACEPTACION_DMY { get; set; }
        public string ADUANA_DESPACHO_DESTINO { get; set; }
        public string REGIMEN { get; set; }
        public string CLASE { get; set; }
        public string PAIS_PROCEDENCIA { get; set; }
        public string NATURALEZA_TRANS { get; set; }
        public string DEPOSITO_FISCAL_ZF { get; set; }
        public int MODO { get; set; }
        public DateTime FECHA_LLEGADA { get; set; }
        public double TIPO_CAMBIO { get; set; }
        public double TOTAL_VALOR_ADUANA { get; set; }
        public double TOTAL_NUMERO_LINEAS { get; set; }
        public int TOTAL_BULTOS { get; set; }
        public double TOTAL_PESO_BRUTO_KG { get; set; }
        public double TOTAL_FOB_USD { get; set; }
        public double TOTAL_FLETE_USD { get; set; }
        public double TOTAL_SEGURO_USD { get; set; }
        public double TOTAL_OTROS_USD { get; set; }
        public string NUMERO_SAT { get; set; }
        public string TIPO_IMPORTADOR { get; set; }
        public string ID_TRIB_IMPORTADOR { get; set; }
        public string PAIS_IMPORTADOR { get; set; }
        public string RAZON_SOCIAL_IMPORTADOR { get; set; }
        public string DOMICILIO_IMPORTADOR { get; set; }
        public string TIPO_REPRESENTANTE { get; set; }
        public string ID_TRIB_REPRESENTANTE { get; set; }
        public string PAIS_REPRESENTANTE { get; set; }
        public string TIPO_DECLARANTE_REPRESENTANTE { get; set; }
        public string RAZON_SOCIAL_REPRESENTANTE { get; set; }
        public string DOMICILIO_REPRESENTANTE { get; set; }
        public int TIPO_CONTENEDOR { get; set; }
        public string NUMERO_CONTENEDOR { get; set; }
        public string ENTIDAD_CONTENEDOR { get; set; }
        public string NUMERO_MARCHAMO_CONTENEDOR { get; set; }
        public double TOTAL_LIQUIDAR { get; set; }
        public double TOTAL_OTROS { get; set; }
        public double TOTAL_GENERAL { get; set; }
        public string CODIGO_POLIZA { get; set; }
        public string LAST_UPDATED_BY { get; set; }
        public DateTime LAST_UPDATED { get; set; }
        public string STATUS { get; set; }
        public string CLIENT_CODE { get; set; }
        public string WAREHOUSE_REGIMEN { get; set; }
        public DateTime FECHA_DOCUMENTO { get; set; }
        public string ACUERDO_COMERCIAL { get; set; }
        public string TIPO { get; set; }
        public string EnvironmentName { get; set; }
        public string Result { get; set; }
        public int DOC_ID { get; set; }
        public string PolizaAsegurada { get; set; }
        public string PolizaAssognedto { get; set; }
        public string Translation { get; set; }
        public int EXTERNAL_SOURCE_ID { get; set; }
        public string SALES_ORDER_ID { get; set; }
        public string POLIZA_ASEGURADA { get; set; }
        public string TRANS_TYPE { get; set; }
        public string CLIENT_NAME { get; set; }
        public bool IS_SELECTED { get; set; }
        public string POLIZA_ASEGURADA_DESCRIPCION { get; set; }
        public string ACUERDO_COMERCIAL_NOMBRE { get; set; }
        public int ACUERDO_COMERCIAL_ID { get; set; }

        public int IS_BLOCKED { get; set; }
        public string UNLOCK_DOCUMENT { get; set; }
        public string UNLOCK_COMMENT { get; set; }
        public string UNLOCK_USER { get; set; }
        public string REGIMEN_GROUP { get; set; }
        public DateTime EXPIRATION_DATE { get; set; }
        public int DAYS_FOR_LOCKING { get; set; }
        public int TIME_BLOCKED { get; set; }
        public int QTY { get; set; }
        public decimal TOTAL_VALUE { get; set; }
        public string BLOCKED_STATUS { get; set; }
        public string DESCRIPTION_STATUS { get; set; }
        public DateTime? UNLOCK_DATE { get; set; }

        public long? TICKET_NUMBER { get; set; }
        public DateTime? TICKET_DATE { get; set; }
    }
}