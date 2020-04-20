using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Configuracion;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class CumplimientoDeEntregaServicio: ICumplimientoDeEntregaServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public CumplimientoDeEntregaServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<CumplimientoDeEntrega> ObtenerCumplimientoDeEntregas(CumplimientoDeEntregaArgumento cumplimientoDeEntregaArgumento)
        {
            DbParameter[] parameters =
               {
                new OAParameter
                {
                    ParameterName = "@VEHICLE_CODES",
                    Value = cumplimientoDeEntregaArgumento.CodigosDeVehiculos
                }
                ,
                new OAParameter
                {
                    ParameterName = "@PILOT_CODES",
                    Value = cumplimientoDeEntregaArgumento.CodigosDePilotos
                }
                ,
                new OAParameter
                {
                    ParameterName = "@START_DATE",
                    Value = cumplimientoDeEntregaArgumento.FechaInicial
                }
                ,
                new OAParameter
                {
                    ParameterName = "@END_DATE",
                    Value = cumplimientoDeEntregaArgumento.FechaFinal
                }
            };
            return
                BaseDeDatosServicio.ExecuteQuery<CumplimientoDeEntrega>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_DELIVERY_COMPLIANCE_REPORT",
                    CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<TareaDeCumplimientoDeEntrega> ObtenerTrackingManifiesto(CumplimientoDeEntregaArgumento argumento)
        {
            var i = 0;
            var entregas =
                argumento.CumplimientosDeEntregas
                    .Where(x => x.MANIFEST_HEADER_ID == argumento.IdManifiestoCarga)
                    .OrderBy(e => e.SEQUENCE);

            var resultado = (entregas.GroupBy(detalle => detalle.TASK_ID)
                .Select(grupo => new TareaDeCumplimientoDeEntrega
                {
                    PILOT_CODE = grupo.Max(x => x.PILOT_CODE),
                    VEHICLE_CODE = grupo.Max(x => x.VEHICLE_CODE),
                    ASSIGNED_STAMP = grupo.Min(x => x.ASSIGNED_STAMP),
                    CLIENT_CODE = grupo.Max(x => x.CLIENT_CODE),
                    CLIENT_NAME = grupo.Max(x => x.CLIENT_NAME),
                    STATUS = grupo.Max(x => x.STATUS),
                    DELAY = grupo.Max(x => x.DELAY ?? 0),
                    GPS =  grupo.Max(x => x.POSTED_GPS) == null || grupo.Max(x => x.POSTED_GPS)?.ToString().Trim() == "0,0" ?
                    grupo.Max(x => x.EXPECTED_GPS) : grupo.Max(x => x.POSTED_GPS),
                    MANIFEST_HEADER_ID = argumento.IdManifiestoCarga,
                    PERCENTAGE = grupo.Max(x => x.PERCENTAGE),
                    PILOT_NAME = grupo.Max(x => x.PILOT_NAME),
                    REASON = grupo.Max(x => x.REASON),
                    SEQUENCE = ++i,
                    TASK_STATUS = grupo.Max(x => x.TASK_STATUS),
                    VEHICLE_PLATE_NUMBER = grupo.Max(x => x.VEHICLE_PLATE_NUMBER),
                    TASK_ID = grupo.Key,
                    DOCUMENT_QTY = grupo.Select(g => g.DOC_NUM).Distinct().Count(),
                    ACCEPTED_STAMP = grupo.Min(x => x.ACCEPTED_STAMP) == null ? DateTime.MinValue : grupo.Min(x => x.ACCEPTED_STAMP.Value),
                    COMPLETED_STAMP = grupo.Max(x => x.COMPLETED_STAMP) == null ? DateTime.MinValue : grupo.Min(x => x.COMPLETED_STAMP.Value),
                    EstadoTarea =  grupo.All(x=>x.PICKING_DEMAND_STATUS ==  Enums.GetStringValue(EstadoEntregaDocumento.Cancelado)) ? (int)EstadoTareaDeEntrega.Cancelada 
                    : grupo.All(x => x.PICKING_DEMAND_STATUS == Enums.GetStringValue(EstadoEntregaDocumento.Entregado)) ? (int)EstadoTareaDeEntrega.Completa
                    : grupo.All(x => x.PICKING_DEMAND_STATUS == Enums.GetStringValue(EstadoEntregaDocumento.Pendiente)) ? (int)EstadoTareaDeEntrega.Pendiente
                    : (int)EstadoTareaDeEntrega.Parcial,
                    PICKING_DEMAND_STATUS = grupo.All(x => x.PICKING_DEMAND_STATUS == Enums.GetStringValue(EstadoEntregaDocumento.Cancelado)) ? EstadoTareaDeEntrega.Cancelada
                    : grupo.All(x => x.PICKING_DEMAND_STATUS == Enums.GetStringValue(EstadoEntregaDocumento.Entregado)) ? EstadoTareaDeEntrega.Completa
                    : grupo.All(x => x.PICKING_DEMAND_STATUS == Enums.GetStringValue(EstadoEntregaDocumento.Pendiente)) ? EstadoTareaDeEntrega.Pendiente
                    : EstadoTareaDeEntrega.Parcial,
                    DELIVERY_NOTE_ID = grupo.Max(x => x.DELIVERY_NOTE_ID),
                })
            ).ToList();


            var siguiente = resultado.Where(x => x.EstadoTarea == (int)EstadoTareaDeEntrega.Pendiente).OrderBy(y => y.SEQUENCE).FirstOrDefault();
            if (siguiente != null)
                siguiente.EstadoTarea = (int)EstadoTareaDeEntrega.Siguiente;

            return resultado;
        }

        public IList<CumplimientoDeEntrega> ObtenerImagenesDeLaEntrega(CumplimientoDeEntregaArgumento cumplimientoDeEntregaArgumento)
        {
            DbParameter[] parameters =
               {
                new OAParameter
                {
                    ParameterName = "@DELIVERY_NOTE_ID",
                    Value = cumplimientoDeEntregaArgumento.DeliveryNoteId
                }
            };
            return
                BaseDeDatosServicio.ExecuteQuery<CumplimientoDeEntrega>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_IMAGE_OF_THE_DELIVERY",
                    CommandType.StoredProcedure, parameters).ToList();
        }

    }
}
