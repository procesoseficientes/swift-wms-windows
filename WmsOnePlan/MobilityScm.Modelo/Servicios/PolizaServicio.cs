using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;
using MobilityScm.Verticial.Excepciones;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class PolizaServicio: IPolizaServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public PolizaServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public Operacion GuardarPolizaHeader(Poliza poliza)
        {
            BaseDeDatosServicio.BeginTransaction();
            try
            {
                var op = new Operacion();
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@DOC_ID",
                        Value = (poliza.DOC_ID > 0) ? poliza.DOC_ID : 0,
                        Direction = ParameterDirection.InputOutput

                    },
                    new OAParameter
                    {
                        ParameterName = "@retCode",
                        Direction = ParameterDirection.ReturnValue
                    },
                    new OAParameter
                    {
                        ParameterName = "@NUMERO_ORDEN",
                        Value = poliza.NUMERO_ORDEN
                    },
                    new OAParameter
                    {
                        ParameterName = "@ADUANA_ENTRADA_SALIDA",
                        Value = poliza.ADUANA_ENTRADA_SALIDA
                    },
                    new OAParameter
                    {
                        ParameterName = "@NUMERO_DUA",
                        Value = poliza.NUMERO_DUA
                    },
                    new OAParameter
                    {
                        ParameterName = "@FECHA_ACEPTACION_DMY",
                        Value = poliza.FECHA_ACEPTACION_DMY
                    },
                    new OAParameter
                    {
                        ParameterName = "@ADUANA_DESPACHO_DESTINO",
                        Value = poliza.ADUANA_DESPACHO_DESTINO
                    },
                    new OAParameter
                    {
                        ParameterName = "@REGIMEN",
                        Value = poliza.REGIMEN
                    },
                    new OAParameter
                    {
                        ParameterName = "@CLASE",
                        Value = poliza.CLASE
                    },
                    new OAParameter
                    {
                        ParameterName = "@PAIS_PROCEDENCIA",
                        Value = poliza.PAIS_PROCEDENCIA
                    },
                    new OAParameter
                    {
                        ParameterName = "@NATURALEZA_TRANS",
                        Value = poliza.NATURALEZA_TRANS
                    },
                    new OAParameter
                    {
                        ParameterName = "@DEPOSITO_FISCAL_ZF",
                        Value = poliza.DEPOSITO_FISCAL_ZF
                    },
                    new OAParameter
                    {
                        ParameterName = "@MODO",
                        Value = poliza.MODO
                    },
                    new OAParameter
                    {
                        ParameterName = "@FECHA_LLEGADA",
                        Value = DateTime.Parse(poliza.FECHA_LLEGADA.ToString(CultureInfo.InvariantCulture))
                    },
                    new OAParameter
                    {
                        ParameterName = "@TIPO_CAMBIO",
                        Value = poliza.TIPO_CAMBIO
                    },
                    new OAParameter
                    {
                        ParameterName = "@TOTAL_VALOR_ADUANA",
                        Value = poliza.TOTAL_VALOR_ADUANA
                    },
                    new OAParameter
                    {
                        ParameterName = "@TOTAL_NUMERO_LINEAS",
                        Value = poliza.TOTAL_NUMERO_LINEAS
                    },
                    new OAParameter
                    {
                        ParameterName = "@TOTAL_BULTOS",
                        Value = poliza.TOTAL_BULTOS
                    },
                    new OAParameter
                    {
                        ParameterName = "@TOTAL_PESO_BRUTO_KG",
                        Value = poliza.TOTAL_PESO_BRUTO_KG
                    },
                    new OAParameter
                    {
                        ParameterName = "@TOTAL_FOB_USD",
                        Value = poliza.TOTAL_FOB_USD
                    },
                    new OAParameter
                    {
                        ParameterName = "@TOTAL_FLETE_USD",
                        Value = poliza.TOTAL_FLETE_USD
                    },
                    new OAParameter
                    {
                        ParameterName = "@TOTAL_SEGURO_USD",
                        Value = poliza.TOTAL_SEGURO_USD
                    },


                    new OAParameter
                    {
                        ParameterName = "@TOTAL_OTROS_USD",
                        Value = poliza.TOTAL_OTROS_USD
                    },
                    new OAParameter
                    {
                        ParameterName = "@NUMERO_SAT",
                        Value = poliza.NUMERO_SAT
                    },
                    new OAParameter
                    {
                        ParameterName = "@TIPO_IMPORTADOR",
                        Value = poliza.TIPO_IMPORTADOR
                    },
                    new OAParameter
                    {
                        ParameterName = "@ID_TRIB_IMPORTADOR",
                        Value = poliza.ID_TRIB_IMPORTADOR
                    },
                    new OAParameter
                    {
                        ParameterName = "@PAIS_IMPORTADOR",
                        Value = poliza.PAIS_IMPORTADOR
                    },
                    new OAParameter
                    {
                        ParameterName = "@RAZON_SOCIAL_IMPORTADOR",
                        Value = poliza.RAZON_SOCIAL_IMPORTADOR
                    },
                    new OAParameter
                    {
                        ParameterName = "@DOMICILIO_IMPORTADOR",
                        Value = poliza.DOMICILIO_IMPORTADOR
                    },
                    new OAParameter
                    {
                        ParameterName = "@TIPO_REPRESENTANTE",
                        Value = poliza.TIPO_REPRESENTANTE
                    },
                    new OAParameter
                    {
                        ParameterName = "@ID_TRIB_REPRESENTANTE",
                        Value = poliza.ID_TRIB_REPRESENTANTE
                    },
                    new OAParameter
                    {
                        ParameterName = "@PAIS_REPRESENTANTE",
                        Value = poliza.PAIS_REPRESENTANTE
                    },
                    new OAParameter
                    {
                        ParameterName = "@TIPO_DECLARANTE_REPRESENTANTE",
                        Value = poliza.TIPO_DECLARANTE_REPRESENTANTE
                    },
                    new OAParameter
                    {
                        ParameterName = "@RAZON_SOCIAL_REPRESENTANTE",
                        Value = poliza.RAZON_SOCIAL_REPRESENTANTE
                    },
                    new OAParameter
                    {
                        ParameterName = "@DOMICILIO_REPRESENTANTE",
                        Value = poliza.DOMICILIO_REPRESENTANTE
                    },
                    new OAParameter
                    {
                        ParameterName = "@TIPO_CONTENEDOR",
                        Value = poliza.TIPO_CONTENEDOR
                    },
                    new OAParameter
                    {
                        ParameterName = "@NUMERO_CONTENEDOR",
                        Value = poliza.NUMERO_CONTENEDOR
                    },
                    new OAParameter
                    {
                        ParameterName = "@ENTIDAD_CONTENEDOR",
                        Value = poliza.ENTIDAD_CONTENEDOR
                    },
                    new OAParameter
                    {
                        ParameterName = "@NUMERO_MARCHAMO_CONTENEDOR",
                        Value = poliza.NUMERO_MARCHAMO_CONTENEDOR
                    },
                    new OAParameter
                    {
                        ParameterName = "@TOTAL_LIQUIDAR",
                        Value = poliza.TOTAL_LIQUIDAR
                    },
                    new OAParameter
                    {
                        ParameterName = "@TOTAL_OTROS",
                        Value = poliza.TOTAL_OTROS
                    },
                    new OAParameter
                    {
                        ParameterName = "@TOTAL_GENERAL",
                        Value = poliza.TOTAL_GENERAL
                    },
                    new OAParameter
                    {
                        ParameterName = "@CODIGO_POLIZA",
                        Value = poliza.CODIGO_POLIZA
                    },
                    new OAParameter
                    {
                        ParameterName = "@LAST_UPDATED_BY",
                        Value = poliza.LAST_UPDATED_BY
                    },
                    new OAParameter
                    {
                        ParameterName = "@LAST_UPDATED",
                        Value = DateTime.Parse(poliza.LAST_UPDATED.ToString())
                    },
                    new OAParameter
                    {
                        ParameterName = "@STATUS",
                        Value = poliza.STATUS
                    },
                    new OAParameter
                    {
                        ParameterName = "@CLIENT_CODE",
                        Value = poliza.CLIENT_CODE
                    },
                    new OAParameter
                    {
                        ParameterName = "@WAREHOUSE_REGIMEN",
                        Value = poliza.WAREHOUSE_REGIMEN
                    },
                    new OAParameter
                    {
                        ParameterName = "@FECHA_DOCUMENTO",
                        Value = DateTime.Parse(poliza.FECHA_DOCUMENTO.ToString())
                    },
                    new OAParameter
                    {
                        ParameterName = "@ACUERDO_COMERCIAL",
                        Value = poliza.ACUERDO_COMERCIAL
                    },
                    new OAParameter
                    {
                        ParameterName = "@TIPO",
                        Value = poliza.TIPO
                    },
                    new OAParameter
                    {
                        ParameterName = "@POLIZAASEGURADA",
                        Value = poliza.PolizaAsegurada
                    },
                    new OAParameter
                    {
                        ParameterName = "@POLIZAASSIGNEDTO",
                        Value = poliza.PolizaAssognedto
                    },
                    new OAParameter
                    {
                        ParameterName = "@TRANSLATION",
                        Value = poliza.Translation
                    }
                };
                BaseDeDatosServicio.ExecuteNonQuery(BaseDeDatosServicio.Esquema + ".sp_OP_WMS_POLIZA_HEADER", CommandType.StoredProcedure, parameters);

                var strReturn = parameters[1].Value.ToString();
                op.Resultado = strReturn == "0" ? ResultadoOperacionTipo.Error : ResultadoOperacionTipo.Exito;

                if (strReturn == "0")
                {
                    op.Mensaje = "ERROR:" + strReturn;
                    op.Resultado = ResultadoOperacionTipo.Error;
                    return op;
                }
                if (strReturn == "1")
                {
                    op.Mensaje = "inserted";
                    op.DbData = parameters[0].Value.ToString();
                    op.Resultado = ResultadoOperacionTipo.Exito;
                }
                if (strReturn == "2")
                {
                    op.Mensaje  = "updated";
                    op.Resultado = ResultadoOperacionTipo.Exito;
                }
                return op;
            }
            catch (Exception ex)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = -1,
                    Mensaje = ex.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
        }

        public IList<PolizaAsegurada> ObtenerTodasLasPolizasDeSeguro()
        {
            return
                BaseDeDatosServicio.ExecuteQuery<PolizaAsegurada>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ALL_INSURANCE_DOCUMENTS",
                    CommandType.StoredProcedure, null).ToList();
        }
    }
}
