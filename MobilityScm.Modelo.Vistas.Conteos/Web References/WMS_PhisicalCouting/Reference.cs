﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8745
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.8745.
// 
namespace MobilityScm.Modelo.WMS_PhisicalCouting {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    using System.Data;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WMS_Phisical_CoutingSoap", Namespace="http://tempuri.org/")]
    public partial class WMS_Phisical_Couting : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public WMS_Phisical_Couting() {
            this.Url = "http://localhost:8088/WMSOnePlan_BusinessServices/Catalogues/WMS_Phisical_Couting" +
                ".asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetMyCountingTask", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetMyCountingTask(string login, ref string result, string pEnvironmentName) {
            object[] results = this.Invoke("GetMyCountingTask", new object[] {
                        login,
                        result,
                        pEnvironmentName});
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetMyCountingTask(string login, string result, string pEnvironmentName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetMyCountingTask", new object[] {
                        login,
                        result,
                        pEnvironmentName}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataTable EndGetMyCountingTask(System.IAsyncResult asyncResult, out string result) {
            object[] results = this.EndInvoke(asyncResult);
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetLocationsForCount", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetLocationsForCount(string login, int taskId, ref string result, string pEnvironmentName) {
            object[] results = this.Invoke("GetLocationsForCount", new object[] {
                        login,
                        taskId,
                        result,
                        pEnvironmentName});
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetLocationsForCount(string login, int taskId, string result, string pEnvironmentName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetLocationsForCount", new object[] {
                        login,
                        taskId,
                        result,
                        pEnvironmentName}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataTable EndGetLocationsForCount(System.IAsyncResult asyncResult, out string result) {
            object[] results = this.EndInvoke(asyncResult);
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetNextMaterialForCount", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetNextMaterialForCount(string login, int taskId, string location, ref string result, string pEnvironmentName) {
            object[] results = this.Invoke("GetNextMaterialForCount", new object[] {
                        login,
                        taskId,
                        location,
                        result,
                        pEnvironmentName});
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetNextMaterialForCount(string login, int taskId, string location, string result, string pEnvironmentName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetNextMaterialForCount", new object[] {
                        login,
                        taskId,
                        location,
                        result,
                        pEnvironmentName}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataTable EndGetNextMaterialForCount(System.IAsyncResult asyncResult, out string result) {
            object[] results = this.EndInvoke(asyncResult);
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/InsertCountExecution", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool InsertCountExecution(string login, int taskId, string location, int licenseId, string materialId, decimal qtyScanned, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] System.Nullable<System.DateTime> expirationDet, string batch, string serial, ref string result, string pEnvironmentName) {
            object[] results = this.Invoke("InsertCountExecution", new object[] {
                        login,
                        taskId,
                        location,
                        licenseId,
                        materialId,
                        qtyScanned,
                        expirationDet,
                        batch,
                        serial,
                        result,
                        pEnvironmentName});
            result = ((string)(results[1]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginInsertCountExecution(string login, int taskId, string location, int licenseId, string materialId, decimal qtyScanned, System.Nullable<System.DateTime> expirationDet, string batch, string serial, string result, string pEnvironmentName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("InsertCountExecution", new object[] {
                        login,
                        taskId,
                        location,
                        licenseId,
                        materialId,
                        qtyScanned,
                        expirationDet,
                        batch,
                        serial,
                        result,
                        pEnvironmentName}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndInsertCountExecution(System.IAsyncResult asyncResult, out string result) {
            object[] results = this.EndInvoke(asyncResult);
            result = ((string)(results[1]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RecountLocation", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable RecountLocation(string login, int taskId, string location, ref string result, string pEnvironmentName) {
            object[] results = this.Invoke("RecountLocation", new object[] {
                        login,
                        taskId,
                        location,
                        result,
                        pEnvironmentName});
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginRecountLocation(string login, int taskId, string location, string result, string pEnvironmentName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("RecountLocation", new object[] {
                        login,
                        taskId,
                        location,
                        result,
                        pEnvironmentName}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataTable EndRecountLocation(System.IAsyncResult asyncResult, out string result) {
            object[] results = this.EndInvoke(asyncResult);
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/FinishLocation", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable FinishLocation(string login, int taskId, string location, ref string result, string pEnvironmentName) {
            object[] results = this.Invoke("FinishLocation", new object[] {
                        login,
                        taskId,
                        location,
                        result,
                        pEnvironmentName});
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginFinishLocation(string login, int taskId, string location, string result, string pEnvironmentName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("FinishLocation", new object[] {
                        login,
                        taskId,
                        location,
                        result,
                        pEnvironmentName}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataTable EndFinishLocation(System.IAsyncResult asyncResult, out string result) {
            object[] results = this.EndInvoke(asyncResult);
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ValidateScannedLocationForCountingTask", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable ValidateScannedLocationForCountingTask(string login, int taskId, string location, ref string result, string pEnvironmentName) {
            object[] results = this.Invoke("ValidateScannedLocationForCountingTask", new object[] {
                        login,
                        taskId,
                        location,
                        result,
                        pEnvironmentName});
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginValidateScannedLocationForCountingTask(string login, int taskId, string location, string result, string pEnvironmentName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ValidateScannedLocationForCountingTask", new object[] {
                        login,
                        taskId,
                        location,
                        result,
                        pEnvironmentName}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataTable EndValidateScannedLocationForCountingTask(System.IAsyncResult asyncResult, out string result) {
            object[] results = this.EndInvoke(asyncResult);
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ValidateScannedMaterialForCountingTask", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable ValidateScannedMaterialForCountingTask(string login, int taskId, string location, int licence, string materialId, string batch, string serial, ref string result, string pEnvironmentName) {
            object[] results = this.Invoke("ValidateScannedMaterialForCountingTask", new object[] {
                        login,
                        taskId,
                        location,
                        licence,
                        materialId,
                        batch,
                        serial,
                        result,
                        pEnvironmentName});
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginValidateScannedMaterialForCountingTask(string login, int taskId, string location, int licence, string materialId, string batch, string serial, string result, string pEnvironmentName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ValidateScannedMaterialForCountingTask", new object[] {
                        login,
                        taskId,
                        location,
                        licence,
                        materialId,
                        batch,
                        serial,
                        result,
                        pEnvironmentName}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataTable EndValidateScannedMaterialForCountingTask(System.IAsyncResult asyncResult, out string result) {
            object[] results = this.EndInvoke(asyncResult);
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetScannedMaterial", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetScannedMaterial(int licence, string barcodeId, ref string result, string pEnvironmentName) {
            object[] results = this.Invoke("GetScannedMaterial", new object[] {
                        licence,
                        barcodeId,
                        result,
                        pEnvironmentName});
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetScannedMaterial(int licence, string barcodeId, string result, string pEnvironmentName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetScannedMaterial", new object[] {
                        licence,
                        barcodeId,
                        result,
                        pEnvironmentName}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataTable EndGetScannedMaterial(System.IAsyncResult asyncResult, out string result) {
            object[] results = this.EndInvoke(asyncResult);
            result = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ValidateScannedLicence", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ValidateScannedLicence(int licence, ref string result, string pEnvironmentName) {
            object[] results = this.Invoke("ValidateScannedLicence", new object[] {
                        licence,
                        result,
                        pEnvironmentName});
            result = ((string)(results[1]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginValidateScannedLicence(int licence, string result, string pEnvironmentName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ValidateScannedLicence", new object[] {
                        licence,
                        result,
                        pEnvironmentName}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndValidateScannedLicence(System.IAsyncResult asyncResult, out string result) {
            object[] results = this.EndInvoke(asyncResult);
            result = ((string)(results[1]));
            return ((bool)(results[0]));
        }
    }
}
