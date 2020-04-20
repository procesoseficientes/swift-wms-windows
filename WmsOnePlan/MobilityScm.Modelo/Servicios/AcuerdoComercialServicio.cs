using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using Telerik.OpenAccess.Data.Common;
using MobilityScm.Vertical.Entidades;
using MobilityScm.Modelo.Tipos;

namespace MobilityScm.Modelo.Servicios
{
    public class AcuerdoComercialServicio : IAcuerdoComercialServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public AcuerdoComercialServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<AcuerdoComercial> ObtenerAcuerdosComerciales(AcuerdoComercialArgumento acuerdoComercialArgumento)
        {
            DbParameter[] parameters =
           {
               new OAParameter
               {
                   ParameterName = "@CLIENT_ID",
                   Value = acuerdoComercialArgumento.IdCliente
               }
               ,
               new OAParameter
               {
                   ParameterName = "@START_DATE",
                   Value = acuerdoComercialArgumento.FechaInicio
               }
               ,
               new OAParameter
               {
                   ParameterName = "@END_DATE",
                   Value = acuerdoComercialArgumento.FechaFin
               },
               new OAParameter
               {
                   ParameterName = "@LOGIN",
                   Value = acuerdoComercialArgumento.Login
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<AcuerdoComercial>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_TERMS_OF_TRADE_BY_INVENTORY", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<AcuerdoComercial> ObtenerAcuerdosComercialesPorCliente(AcuerdoComercial acuerdoComercial)
        {
            DbParameter[] parameters =
           {
               new OAParameter
               {
                   ParameterName = "@CLIENT_CODE",
                   Value = acuerdoComercial.CLIENT_CODE
               }
               
           };
            return BaseDeDatosServicio.ExecuteQuery<AcuerdoComercial>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_TRADE_AGREEMENT_BY_CLIENT", CommandType.StoredProcedure, parameters).ToList();
        }
    }
}
