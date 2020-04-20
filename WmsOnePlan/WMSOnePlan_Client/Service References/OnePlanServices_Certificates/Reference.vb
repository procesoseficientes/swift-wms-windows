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

Namespace OnePlanServices_Certificates
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="OnePlanServices_Certificates.WMS_CertificatesSoap")>  _
    Public Interface WMS_CertificatesSoap
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/CreateCertificate", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function CreateCertificate(ByVal pAddBond As Boolean, ByRef pCertificateId As Integer, ByVal pCreationBy As String, ByVal pSupervisionId As Integer, ByVal p3plWarenHouse As String, ByVal pValidFrom As Date, ByVal pValidTo As Date, ByVal pClientCode As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/UpdateCertificate", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function UpdateCertificate(ByRef pCertificateId As Integer, ByVal pLastUpdateBy As String, ByVal pSupervisionId As Integer, ByVal p3plWarenHouse As String, ByVal pCertificateStatus As String, ByVal pValidFrom As Date, ByVal pValidTo As Date, ByVal pClientCode As String, ByVal pHasBond As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/DeleteCertificate", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function DeleteCertificate(ByVal pCertificateId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/UpdateCertificateValid", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function UpdateCertificateValid(ByRef pCertificateId As Integer, ByVal pValidFrom As Date, ByVal pValidTo As Date, ByVal pLastUpdateBy As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetCertificate", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetCertificate(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/FillCertificate", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function FillCertificate(ByVal pCertificateId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetRepCertificateBond", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetRepCertificateBond(ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/CreateCertificateLog", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function CreateCertificateLog(ByRef pCertificateId As Integer, ByVal pUpdateBy As String, ByVal pOldValidFrom As Date, ByVal pOldValidTo As Date, ByVal pNewdValidFrom As Date, ByVal pNewValidTo As Date, ByVal pAuthorizedBy As String, ByVal pComment As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetCertificateLOG", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetCertificateLOG(ByRef pCertificateId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/SelectCurrency", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function SelectCurrency(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetKardexCertificate", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetKardexCertificate(ByVal pUsers As String, ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetKardexConsultation", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetKardexConsultation(ByVal pCertificateId As Integer, ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/InsertKardex", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function InsertKardex(ByVal pCertificateId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/UpdatedKardex", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function UpdatedKardex(ByVal pKardexId As Integer, ByVal pCurrentBalace As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetKardexTxns", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetKardexTxns(ByVal pCertificateId As Integer, ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/InsertKardexTxns", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function InsertKardexTxns(ByVal pCertificateId As Integer, ByVal pTxDate As Date, ByVal pTxReceipts As Decimal, ByVal pTxDispactil As Decimal, ByVal pTxLastBalace As Decimal, ByVal pTxCurrentBalance As Decimal, ByVal pSku As String, ByVal pSkuDescription As String, ByVal pCost As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetDocByCliente", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetDocByCliente(ByVal pNameTable As String, ByVal pClienteId As String, ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetDetailByDocForCertificateAlmge", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetDetailByDocForCertificateAlmge(ByVal pNameTable As String, ByVal pDocId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetDetailByDocForCertificate", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetDetailByDocForCertificate(ByVal pNameTable As String, ByVal pDocId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetCertificateDepositByClient", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetCertificateDepositByClient(ByVal pNameTable As String, ByVal pClienteId As String, ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/InsertCertificateDepositHeader", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function InsertCertificateDepositHeader(ByVal pNameTable As String, ByVal pValidoInicio As Date, ByVal pValidoFinal As Date, ByVal login As String, ByVal status As String, ByVal pClienteId As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/InsertCertificateDepositDetail", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function InsertCertificateDepositDetail(ByVal pNameTable As String, ByVal certificateIdHedaer As Integer, ByVal docId As Integer, ByVal materialCode As String, ByVal skuDescripcion As String, ByVal locations As String, ByVal bultos As Integer, ByVal qty As Decimal, ByVal monto As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetCertificateDepositDetail", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetCertificateDepositDetail(ByVal pNameTable As String, ByVal certificateIdHedaer As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/SetStatusCertificateDeposit", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function SetStatusCertificateDeposit(ByVal certificateDeposit As Integer, ByVal status As String, ByVal login As String, ByVal comentario As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/DeleteDetailCertificate", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function DeleteDetailCertificate(ByVal certificateDeposit As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/UpdateCertificateDepositHeder", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function UpdateCertificateDepositHeder(ByVal certificateDeposit As Integer, ByVal pValidoInicio As Date, ByVal pValidoFinal As Date, ByVal login As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/InsertarLogCertificado", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function InsertarLogCertificado(ByVal certificadoDepositoId As Integer, ByVal login As String, ByVal comentario As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface WMS_CertificatesSoapChannel
        Inherits OnePlanServices_Certificates.WMS_CertificatesSoap, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class WMS_CertificatesSoapClient
        Inherits System.ServiceModel.ClientBase(Of OnePlanServices_Certificates.WMS_CertificatesSoap)
        Implements OnePlanServices_Certificates.WMS_CertificatesSoap
        
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
        
        Public Function CreateCertificate(ByVal pAddBond As Boolean, ByRef pCertificateId As Integer, ByVal pCreationBy As String, ByVal pSupervisionId As Integer, ByVal p3plWarenHouse As String, ByVal pValidFrom As Date, ByVal pValidTo As Date, ByVal pClientCode As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Certificates.WMS_CertificatesSoap.CreateCertificate
            Return MyBase.Channel.CreateCertificate(pAddBond, pCertificateId, pCreationBy, pSupervisionId, p3plWarenHouse, pValidFrom, pValidTo, pClientCode, pResult, pEnvironmentName)
        End Function
        
        Public Function UpdateCertificate(ByRef pCertificateId As Integer, ByVal pLastUpdateBy As String, ByVal pSupervisionId As Integer, ByVal p3plWarenHouse As String, ByVal pCertificateStatus As String, ByVal pValidFrom As Date, ByVal pValidTo As Date, ByVal pClientCode As String, ByVal pHasBond As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Certificates.WMS_CertificatesSoap.UpdateCertificate
            Return MyBase.Channel.UpdateCertificate(pCertificateId, pLastUpdateBy, pSupervisionId, p3plWarenHouse, pCertificateStatus, pValidFrom, pValidTo, pClientCode, pHasBond, pResult, pEnvironmentName)
        End Function
        
        Public Function DeleteCertificate(ByVal pCertificateId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Certificates.WMS_CertificatesSoap.DeleteCertificate
            Return MyBase.Channel.DeleteCertificate(pCertificateId, pResult, pEnvironmentName)
        End Function
        
        Public Function UpdateCertificateValid(ByRef pCertificateId As Integer, ByVal pValidFrom As Date, ByVal pValidTo As Date, ByVal pLastUpdateBy As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Certificates.WMS_CertificatesSoap.UpdateCertificateValid
            Return MyBase.Channel.UpdateCertificateValid(pCertificateId, pValidFrom, pValidTo, pLastUpdateBy, pResult, pEnvironmentName)
        End Function
        
        Public Function GetCertificate(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Certificates.WMS_CertificatesSoap.GetCertificate
            Return MyBase.Channel.GetCertificate(pResult, pEnvironmentName)
        End Function
        
        Public Function FillCertificate(ByVal pCertificateId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Certificates.WMS_CertificatesSoap.FillCertificate
            Return MyBase.Channel.FillCertificate(pCertificateId, pResult, pEnvironmentName)
        End Function
        
        Public Function GetRepCertificateBond(ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Certificates.WMS_CertificatesSoap.GetRepCertificateBond
            Return MyBase.Channel.GetRepCertificateBond(pNameTable, pResult, pEnvironmentName)
        End Function
        
        Public Function CreateCertificateLog(ByRef pCertificateId As Integer, ByVal pUpdateBy As String, ByVal pOldValidFrom As Date, ByVal pOldValidTo As Date, ByVal pNewdValidFrom As Date, ByVal pNewValidTo As Date, ByVal pAuthorizedBy As String, ByVal pComment As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Certificates.WMS_CertificatesSoap.CreateCertificateLog
            Return MyBase.Channel.CreateCertificateLog(pCertificateId, pUpdateBy, pOldValidFrom, pOldValidTo, pNewdValidFrom, pNewValidTo, pAuthorizedBy, pComment, pResult, pEnvironmentName)
        End Function
        
        Public Function GetCertificateLOG(ByRef pCertificateId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Certificates.WMS_CertificatesSoap.GetCertificateLOG
            Return MyBase.Channel.GetCertificateLOG(pCertificateId, pResult, pEnvironmentName)
        End Function
        
        Public Function SelectCurrency(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Certificates.WMS_CertificatesSoap.SelectCurrency
            Return MyBase.Channel.SelectCurrency(pResult, pEnvironmentName)
        End Function
        
        Public Function GetKardexCertificate(ByVal pUsers As String, ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable Implements OnePlanServices_Certificates.WMS_CertificatesSoap.GetKardexCertificate
            Return MyBase.Channel.GetKardexCertificate(pUsers, pNameTable, pResult, pEnvironmentName)
        End Function
        
        Public Function GetKardexConsultation(ByVal pCertificateId As Integer, ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable Implements OnePlanServices_Certificates.WMS_CertificatesSoap.GetKardexConsultation
            Return MyBase.Channel.GetKardexConsultation(pCertificateId, pNameTable, pResult, pEnvironmentName)
        End Function
        
        Public Function InsertKardex(ByVal pCertificateId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Certificates.WMS_CertificatesSoap.InsertKardex
            Return MyBase.Channel.InsertKardex(pCertificateId, pResult, pEnvironmentName)
        End Function
        
        Public Function UpdatedKardex(ByVal pKardexId As Integer, ByVal pCurrentBalace As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Certificates.WMS_CertificatesSoap.UpdatedKardex
            Return MyBase.Channel.UpdatedKardex(pKardexId, pCurrentBalace, pResult, pEnvironmentName)
        End Function
        
        Public Function GetKardexTxns(ByVal pCertificateId As Integer, ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable Implements OnePlanServices_Certificates.WMS_CertificatesSoap.GetKardexTxns
            Return MyBase.Channel.GetKardexTxns(pCertificateId, pFechaInicio, pFechaFinal, pNameTable, pResult, pEnvironmentName)
        End Function
        
        Public Function InsertKardexTxns(ByVal pCertificateId As Integer, ByVal pTxDate As Date, ByVal pTxReceipts As Decimal, ByVal pTxDispactil As Decimal, ByVal pTxLastBalace As Decimal, ByVal pTxCurrentBalance As Decimal, ByVal pSku As String, ByVal pSkuDescription As String, ByVal pCost As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Certificates.WMS_CertificatesSoap.InsertKardexTxns
            Return MyBase.Channel.InsertKardexTxns(pCertificateId, pTxDate, pTxReceipts, pTxDispactil, pTxLastBalace, pTxCurrentBalance, pSku, pSkuDescription, pCost, pResult, pEnvironmentName)
        End Function
        
        Public Function GetDocByCliente(ByVal pNameTable As String, ByVal pClienteId As String, ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable Implements OnePlanServices_Certificates.WMS_CertificatesSoap.GetDocByCliente
            Return MyBase.Channel.GetDocByCliente(pNameTable, pClienteId, pFechaInicio, pFechaFinal, pResult, pEnvironmentName)
        End Function
        
        Public Function GetDetailByDocForCertificateAlmge(ByVal pNameTable As String, ByVal pDocId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable Implements OnePlanServices_Certificates.WMS_CertificatesSoap.GetDetailByDocForCertificateAlmge
            Return MyBase.Channel.GetDetailByDocForCertificateAlmge(pNameTable, pDocId, pResult, pEnvironmentName)
        End Function
        
        Public Function GetDetailByDocForCertificate(ByVal pNameTable As String, ByVal pDocId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable Implements OnePlanServices_Certificates.WMS_CertificatesSoap.GetDetailByDocForCertificate
            Return MyBase.Channel.GetDetailByDocForCertificate(pNameTable, pDocId, pResult, pEnvironmentName)
        End Function
        
        Public Function GetCertificateDepositByClient(ByVal pNameTable As String, ByVal pClienteId As String, ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable Implements OnePlanServices_Certificates.WMS_CertificatesSoap.GetCertificateDepositByClient
            Return MyBase.Channel.GetCertificateDepositByClient(pNameTable, pClienteId, pFechaInicio, pFechaFinal, pResult, pEnvironmentName)
        End Function
        
        Public Function InsertCertificateDepositHeader(ByVal pNameTable As String, ByVal pValidoInicio As Date, ByVal pValidoFinal As Date, ByVal login As String, ByVal status As String, ByVal pClienteId As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable Implements OnePlanServices_Certificates.WMS_CertificatesSoap.InsertCertificateDepositHeader
            Return MyBase.Channel.InsertCertificateDepositHeader(pNameTable, pValidoInicio, pValidoFinal, login, status, pClienteId, pResult, pEnvironmentName)
        End Function
        
        Public Function InsertCertificateDepositDetail(ByVal pNameTable As String, ByVal certificateIdHedaer As Integer, ByVal docId As Integer, ByVal materialCode As String, ByVal skuDescripcion As String, ByVal locations As String, ByVal bultos As Integer, ByVal qty As Decimal, ByVal monto As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable Implements OnePlanServices_Certificates.WMS_CertificatesSoap.InsertCertificateDepositDetail
            Return MyBase.Channel.InsertCertificateDepositDetail(pNameTable, certificateIdHedaer, docId, materialCode, skuDescripcion, locations, bultos, qty, monto, pResult, pEnvironmentName)
        End Function
        
        Public Function GetCertificateDepositDetail(ByVal pNameTable As String, ByVal certificateIdHedaer As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataTable Implements OnePlanServices_Certificates.WMS_CertificatesSoap.GetCertificateDepositDetail
            Return MyBase.Channel.GetCertificateDepositDetail(pNameTable, certificateIdHedaer, pResult, pEnvironmentName)
        End Function
        
        Public Function SetStatusCertificateDeposit(ByVal certificateDeposit As Integer, ByVal status As String, ByVal login As String, ByVal comentario As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Certificates.WMS_CertificatesSoap.SetStatusCertificateDeposit
            Return MyBase.Channel.SetStatusCertificateDeposit(certificateDeposit, status, login, comentario, pResult, pEnvironmentName)
        End Function
        
        Public Function DeleteDetailCertificate(ByVal certificateDeposit As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Certificates.WMS_CertificatesSoap.DeleteDetailCertificate
            Return MyBase.Channel.DeleteDetailCertificate(certificateDeposit, pResult, pEnvironmentName)
        End Function
        
        Public Function UpdateCertificateDepositHeder(ByVal certificateDeposit As Integer, ByVal pValidoInicio As Date, ByVal pValidoFinal As Date, ByVal login As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Certificates.WMS_CertificatesSoap.UpdateCertificateDepositHeder
            Return MyBase.Channel.UpdateCertificateDepositHeder(certificateDeposit, pValidoInicio, pValidoFinal, login, pResult, pEnvironmentName)
        End Function
        
        Public Function InsertarLogCertificado(ByVal certificadoDepositoId As Integer, ByVal login As String, ByVal comentario As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Certificates.WMS_CertificatesSoap.InsertarLogCertificado
            Return MyBase.Channel.InsertarLogCertificado(certificadoDepositoId, login, comentario, pResult, pEnvironmentName)
        End Function
    End Class
End Namespace
