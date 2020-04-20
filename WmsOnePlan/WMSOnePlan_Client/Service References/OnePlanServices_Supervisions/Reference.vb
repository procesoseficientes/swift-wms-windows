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

Namespace OnePlanServices_Supervisions
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="OnePlanServices_Supervisions.WMS_SupervisionsSoap")>  _
    Public Interface WMS_SupervisionsSoap
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/CreateSupervisions", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function CreateSupervisions(ByRef pSuperId As Integer, ByVal pClientOwhen As String, ByVal pAuditAddress As String, ByVal pComents As String, ByVal pIsInitial As Integer, ByRef pAuditedBy As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/Updatesupervision", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function Updatesupervision(ByVal pSuperId As Integer, ByVal pClientOwhen As String, ByVal pAuditAddress As String, ByVal pComents As String, ByVal pIsInitial As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/UpdateStatusSupervision", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function UpdateStatusSupervision(ByVal pSuperId As Integer, ByVal pAsignado As Boolean, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/DeleteSupervisions", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function DeleteSupervisions(ByVal pSuperId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetSupervisions", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetSupervisions(ByVal pAddConStatus As Boolean, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/FillSupervisions", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function FillSupervisions(ByVal pSuperId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface WMS_SupervisionsSoapChannel
        Inherits OnePlanServices_Supervisions.WMS_SupervisionsSoap, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class WMS_SupervisionsSoapClient
        Inherits System.ServiceModel.ClientBase(Of OnePlanServices_Supervisions.WMS_SupervisionsSoap)
        Implements OnePlanServices_Supervisions.WMS_SupervisionsSoap
        
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
        
        Public Function CreateSupervisions(ByRef pSuperId As Integer, ByVal pClientOwhen As String, ByVal pAuditAddress As String, ByVal pComents As String, ByVal pIsInitial As Integer, ByRef pAuditedBy As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Supervisions.WMS_SupervisionsSoap.CreateSupervisions
            Return MyBase.Channel.CreateSupervisions(pSuperId, pClientOwhen, pAuditAddress, pComents, pIsInitial, pAuditedBy, pResult, pEnvironmentName)
        End Function
        
        Public Function Updatesupervision(ByVal pSuperId As Integer, ByVal pClientOwhen As String, ByVal pAuditAddress As String, ByVal pComents As String, ByVal pIsInitial As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Supervisions.WMS_SupervisionsSoap.Updatesupervision
            Return MyBase.Channel.Updatesupervision(pSuperId, pClientOwhen, pAuditAddress, pComents, pIsInitial, pResult, pEnvironmentName)
        End Function
        
        Public Function UpdateStatusSupervision(ByVal pSuperId As Integer, ByVal pAsignado As Boolean, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Supervisions.WMS_SupervisionsSoap.UpdateStatusSupervision
            Return MyBase.Channel.UpdateStatusSupervision(pSuperId, pAsignado, pResult, pEnvironmentName)
        End Function
        
        Public Function DeleteSupervisions(ByVal pSuperId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Supervisions.WMS_SupervisionsSoap.DeleteSupervisions
            Return MyBase.Channel.DeleteSupervisions(pSuperId, pResult, pEnvironmentName)
        End Function
        
        Public Function GetSupervisions(ByVal pAddConStatus As Boolean, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Supervisions.WMS_SupervisionsSoap.GetSupervisions
            Return MyBase.Channel.GetSupervisions(pAddConStatus, pResult, pEnvironmentName)
        End Function
        
        Public Function FillSupervisions(ByVal pSuperId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Supervisions.WMS_SupervisionsSoap.FillSupervisions
            Return MyBase.Channel.FillSupervisions(pSuperId, pResult, pEnvironmentName)
        End Function
    End Class
End Namespace
