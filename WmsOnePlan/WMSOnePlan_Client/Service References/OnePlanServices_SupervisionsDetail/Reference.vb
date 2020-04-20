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

Namespace OnePlanServices_SupervisionsDetail
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoap")>  _
    Public Interface WMS_SupervisionsDetailSoap
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/CreateSupervisionsDetail", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function CreateSupervisionsDetail(ByRef pSuperId As Integer, ByVal pCode As String, ByVal pDescription As String, ByVal pQty As Decimal, ByRef pCost As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/UpdateSupervisionDetail", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function UpdateSupervisionDetail(ByRef pSuperId As Integer, ByVal pCode As String, ByVal pDescription As String, ByVal pQty As Decimal, ByRef pCost As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/DeleteSupervisionsDetails", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function DeleteSupervisionsDetails(ByVal pSuperId As Integer, ByVal pCode As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/DeleteAllBySuperIdSupervisionsDetail", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function DeleteAllBySuperIdSupervisionsDetail(ByVal pSuperId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetSupervisionsDetail", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetSupervisionsDetail(ByVal pSuperId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/FillSupervisionsDetail", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function FillSupervisionsDetail(ByVal pSuperId As Integer, ByVal pCode As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ExistSupervisionsDetail", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function ExistSupervisionsDetail(ByVal pSuperId As Integer, ByVal pCode As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface WMS_SupervisionsDetailSoapChannel
        Inherits OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoap, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class WMS_SupervisionsDetailSoapClient
        Inherits System.ServiceModel.ClientBase(Of OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoap)
        Implements OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoap
        
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
        
        Public Function CreateSupervisionsDetail(ByRef pSuperId As Integer, ByVal pCode As String, ByVal pDescription As String, ByVal pQty As Decimal, ByRef pCost As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoap.CreateSupervisionsDetail
            Return MyBase.Channel.CreateSupervisionsDetail(pSuperId, pCode, pDescription, pQty, pCost, pResult, pEnvironmentName)
        End Function
        
        Public Function UpdateSupervisionDetail(ByRef pSuperId As Integer, ByVal pCode As String, ByVal pDescription As String, ByVal pQty As Decimal, ByRef pCost As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoap.UpdateSupervisionDetail
            Return MyBase.Channel.UpdateSupervisionDetail(pSuperId, pCode, pDescription, pQty, pCost, pResult, pEnvironmentName)
        End Function
        
        Public Function DeleteSupervisionsDetails(ByVal pSuperId As Integer, ByVal pCode As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoap.DeleteSupervisionsDetails
            Return MyBase.Channel.DeleteSupervisionsDetails(pSuperId, pCode, pResult, pEnvironmentName)
        End Function
        
        Public Function DeleteAllBySuperIdSupervisionsDetail(ByVal pSuperId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoap.DeleteAllBySuperIdSupervisionsDetail
            Return MyBase.Channel.DeleteAllBySuperIdSupervisionsDetail(pSuperId, pResult, pEnvironmentName)
        End Function
        
        Public Function GetSupervisionsDetail(ByVal pSuperId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoap.GetSupervisionsDetail
            Return MyBase.Channel.GetSupervisionsDetail(pSuperId, pResult, pEnvironmentName)
        End Function
        
        Public Function FillSupervisionsDetail(ByVal pSuperId As Integer, ByVal pCode As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoap.FillSupervisionsDetail
            Return MyBase.Channel.FillSupervisionsDetail(pSuperId, pCode, pResult, pEnvironmentName)
        End Function
        
        Public Function ExistSupervisionsDetail(ByVal pSuperId As Integer, ByVal pCode As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoap.ExistSupervisionsDetail
            Return MyBase.Channel.ExistSupervisionsDetail(pSuperId, pCode, pResult, pEnvironmentName)
        End Function
    End Class
End Namespace
