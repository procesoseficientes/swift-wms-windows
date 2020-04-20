﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System.Data

Namespace OnePlanServices_Insurance_Docs
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoap")>  _
    Public Interface WMS_Insurance_DocsSoap
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/CreateInsuranceDocs", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function CreateInsuranceDocs(ByVal pCompanyId As String, ByVal pCLientCode As String, ByVal pPoliza As String, ByRef pFechaVenInicio As Date, ByRef pFechaVenFihnal As Date, ByRef pMonto As Decimal, ByRef pCobertura As String, ByRef pCreateBy As String, ByVal pInsuranceOwhen As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/UpdateInsuranceDocs", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function UpdateInsuranceDocs(ByVal pCompanyId As Integer, ByRef pMonto As Decimal, ByRef pCobertura As String, ByRef pLastUpdateBy As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/DeleteInsuranceDocs", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function DeleteInsuranceDocs(ByVal pCompanyId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetInsuranceDocs", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetInsuranceDocs(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/FillInsuranceDocs", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function FillInsuranceDocs(ByVal pDocId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetRepInsuranceDoscs", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetRepInsuranceDoscs(ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetInsuranceDocsCliente", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetInsuranceDocsCliente(ByVal pClientCode As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/CreateInsuranceDocsLog", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function CreateInsuranceDocsLog(ByVal pDocId As Integer, ByVal pUserId As String, ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByVal pComentario As String, ByVal pAutorizado As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetInsuranceDocsLog", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetInsuranceDocsLog(ByVal pInsuranceDocId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetExpirationPolizaDoc", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetExpirationPolizaDoc(ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetExpirationInsuranceDoc", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetExpirationInsuranceDoc(ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface WMS_Insurance_DocsSoapChannel
        Inherits OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoap, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class WMS_Insurance_DocsSoapClient
        Inherits System.ServiceModel.ClientBase(Of OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoap)
        Implements OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoap
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function CreateInsuranceDocs(ByVal pCompanyId As String, ByVal pCLientCode As String, ByVal pPoliza As String, ByRef pFechaVenInicio As Date, ByRef pFechaVenFihnal As Date, ByRef pMonto As Decimal, ByRef pCobertura As String, ByRef pCreateBy As String, ByVal pInsuranceOwhen As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoap.CreateInsuranceDocs
            Return MyBase.Channel.CreateInsuranceDocs(pCompanyId, pCLientCode, pPoliza, pFechaVenInicio, pFechaVenFihnal, pMonto, pCobertura, pCreateBy, pInsuranceOwhen, pResult, pEnvironmentName)
        End Function
        
        Public Function UpdateInsuranceDocs(ByVal pCompanyId As Integer, ByRef pMonto As Decimal, ByRef pCobertura As String, ByRef pLastUpdateBy As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoap.UpdateInsuranceDocs
            Return MyBase.Channel.UpdateInsuranceDocs(pCompanyId, pMonto, pCobertura, pLastUpdateBy, pResult, pEnvironmentName)
        End Function
        
        Public Function DeleteInsuranceDocs(ByVal pCompanyId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoap.DeleteInsuranceDocs
            Return MyBase.Channel.DeleteInsuranceDocs(pCompanyId, pResult, pEnvironmentName)
        End Function
        
        Public Function GetInsuranceDocs(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoap.GetInsuranceDocs
            Return MyBase.Channel.GetInsuranceDocs(pResult, pEnvironmentName)
        End Function
        
        Public Function FillInsuranceDocs(ByVal pDocId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoap.FillInsuranceDocs
            Return MyBase.Channel.FillInsuranceDocs(pDocId, pResult, pEnvironmentName)
        End Function
        
        Public Function GetRepInsuranceDoscs(ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable Implements OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoap.GetRepInsuranceDoscs
            Return MyBase.Channel.GetRepInsuranceDoscs(pNameTable, pResult, pEnvironmentName)
        End Function
        
        Public Function GetInsuranceDocsCliente(ByVal pClientCode As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoap.GetInsuranceDocsCliente
            Return MyBase.Channel.GetInsuranceDocsCliente(pClientCode, pResult, pEnvironmentName)
        End Function
        
        Public Function CreateInsuranceDocsLog(ByVal pDocId As Integer, ByVal pUserId As String, ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByVal pComentario As String, ByVal pAutorizado As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoap.CreateInsuranceDocsLog
            Return MyBase.Channel.CreateInsuranceDocsLog(pDocId, pUserId, pFechaInicio, pFechaFinal, pComentario, pAutorizado, pResult, pEnvironmentName)
        End Function
        
        Public Function GetInsuranceDocsLog(ByVal pInsuranceDocId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoap.GetInsuranceDocsLog
            Return MyBase.Channel.GetInsuranceDocsLog(pInsuranceDocId, pResult, pEnvironmentName)
        End Function
        
        Public Function GetExpirationPolizaDoc(ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoap.GetExpirationPolizaDoc
            Return MyBase.Channel.GetExpirationPolizaDoc(pFechaInicio, pFechaFinal, pResult, pEnvironmentName)
        End Function
        
        Public Function GetExpirationInsuranceDoc(ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoap.GetExpirationInsuranceDoc
            Return MyBase.Channel.GetExpirationInsuranceDoc(pFechaInicio, pFechaFinal, pResult, pEnvironmentName)
        End Function
    End Class
End Namespace
