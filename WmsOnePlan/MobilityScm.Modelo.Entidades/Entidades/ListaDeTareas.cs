using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class ListaDeTareas
    {
        public int id { get; set; }
        public int? wavePickingId { get; set; }
        public int? transOwner { get; set; }
        public string taskType { get; set; }
        public string taskSubtype { get; set; }
        public string taskOwner { get; set; }
        public string taskAssignedTo { get; set; }
        public string taskComments { get; set; }
        public DateTime assignedDate { get; set; }
        public decimal quantityPending { get; set; }
        public decimal quantityAssigned { get; set; }
        public string sourcePolicyCode { get; set; }
        public string targetPolicyCode { get; set; }
        public int? licenseIdSource { get; set; }
        public string regime { get; set; }
        public int? isCompleted { get; set; }
        public int isDiscretional { get; set; }
        public int? isPaused { get; set; }
        public int? isCanceled { get; set; }
        public string materialId { get; set; }
        public string barcodeId { get; set; }
        public string alternateBarcode { get; set; }
        public string materialName { get; set; }
        public string warehouseSource { get; set; }
        public string warehouseTarget { get; set; }
        public string locationSpotSource { get; set; }
        public string locationSpotTarget { get; set; }
        public string clientOwner { get; set; }
        public string clientName { get; set; }
        public DateTime? acceptedDate { get; set; }
        public DateTime? completedDate { get; set; }
        public DateTime? canceledDatetime { get; set; }
        public string canceledBy { get; set; }
        public string materialShortName { get; set; }
        public string isLocked { get; set; }
        public int isDiscretionary { get; set; }
        public string typeDiscretionary { get; set; }
        public int? lineNumberSourcePolicy { get; set; }
        public int? lineNumberTargetPolicy { get; set; }
        public int? docIdSource { get; set; }
        public int? docIdTarget { get; set; }
        public int? isAccepted { get; set; }
        public int? isFromSonda { get; set; }
        public int isFromErp { get; set; }
        public int priority { get; set; }
        public string replenishMaterialIdTarget { get; set; }
        public int fromMasterpack { get; set; }
        public string masterPackCode { get; set; }
        public string owner { get; set; }
        public string sourceType { get; set; }
        public int? transferRequestId { get; set; }
        public string tone { get; set; }
        public string caliber { get; set; }
        public int? licenseIdTarget { get; set; }
        public int inPickingLine { get; set; }
        public int isForDeliveryImmediate { get; set; }
    }
}
