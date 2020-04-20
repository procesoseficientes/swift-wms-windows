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

namespace MobilityScm.Modelo.Servicios
{
    public class IndiceBodegaServicio : IIndiceBodegaServicio
    {
        #region Propiedades

        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        #endregion

        #region Constructor

        public IndiceBodegaServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        #endregion
        public IList<IndicesBodega> ObtenerIndicesBodegas(InventarioInactivoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@DATE_WAREHOUSE_INDICES",
                    Value = arg.DateWarehouseIndices
                }
                ,
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = arg.Login
                }
                ,
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE_XML",
                    Value = arg.WarehouseXml
                },
                new OAParameter
                {
                    ParameterName = "@MATERIAL_XML",
                    Value = arg.MaterialXml
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<IndicesBodega>(BaseDeDatosServicio.Esquema + ".[OP_WMS_SP_GET_WAREHOUSE_INDICES]", CommandType.StoredProcedure, parameters).ToList();
        }
    }
}
