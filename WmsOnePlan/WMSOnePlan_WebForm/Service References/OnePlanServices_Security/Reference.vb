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

Namespace OnePlanServices_Security
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="OnePlanServices_Security.WMS_SecuritySoap")>  _
    Public Interface WMS_SecuritySoap
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/CreateUserLogin", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function CreateUserLogin( _
                    ByVal pLOGIN_ID As String,  _
                    ByVal pROLE_ID As String,  _
                    ByVal pLOGIN_NAME As String,  _
                    ByVal pLOGIN_TYPE As String,  _
                    ByVal pLOGIN_STATUS As String,  _
                    ByVal pLOGIN_PWD As String,  _
                    ByVal pLICENSE_SERIAL As String,  _
                    ByVal pENVIRONMENT As String,  _
                    ByVal pGUI_LAYOUT As String,  _
                    ByVal pCONSOLIDATION_TERMINAL As Integer,  _
                    ByVal pLINE_ID As String,  _
                    ByVal pGENERATE_TASKS As String,  _
                    ByVal pLOADING_GATE As Integer,  _
                    ByVal pWHEREHOUSE_iD As String,  _
                    ByRef pResult As String,  _
                    ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/UpdateUserLogin", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function UpdateUserLogin( _
                    ByVal pLOGIN_ID As String,  _
                    ByVal pROLE_ID As String,  _
                    ByVal pLOGIN_NAME As String,  _
                    ByVal pLOGIN_TYPE As String,  _
                    ByVal pLOGIN_STATUS As String,  _
                    ByVal pLOGIN_PWD As String,  _
                    ByVal pLICENSE_SERIAL As String,  _
                    ByVal pENVIRONMENT As String,  _
                    ByVal pGUI_LAYOUT As String,  _
                    ByVal pCONSOLIDATION_TERMINAL As Integer,  _
                    ByVal pGENERATE_TASKS As Integer,  _
                    ByVal pLINE_ID As String,  _
                    ByVal pLOADING_GATE As Integer,  _
                    ByVal pWHEREHOUSE_iD As String,  _
                    ByRef pResult As String,  _
                    ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/UpdateUserGUI", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function UpdateUserGUI(ByVal pLOGIN_ID As String, ByVal pGUI_LAYOUT As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/DeleteUserLogin", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function DeleteUserLogin(ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/SearchOperators", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function SearchOperators(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/SearchPartialUserLogin", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function SearchPartialUserLogin(ByVal pLOGIN_ID As String, ByVal pROLE_ID As String, ByVal pLOGIN_NAME As String, ByVal pLOGIN_TYPE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/SearchByKeyUserLogin", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function SearchByKeyUserLogin(ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GroupByKeyUserLogin", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GroupByKeyUserLogin(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/AccessLevelGroups", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function AccessLevelGroups(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/CheckPointGroups", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function CheckPointGroups(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/SearchByKeyCheckPoint", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function SearchByKeyCheckPoint(ByVal pPRIV_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/SearchPartialCheckPoint", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function SearchPartialCheckPoint(ByVal pPRIV_ID As String, ByVal pPRIV_NAME As String, ByVal pPRIV_GROUP As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/DeleteCheckPoint", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function DeleteCheckPoint(ByVal pPRIV_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/UpdateCheckPoint", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function UpdateCheckPoint(ByVal pPRIV_ID As String, ByVal pPRIV_NAME As String, ByVal pPRIV_GROUP As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/CreateCheckPoint", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function CreateCheckPoint(ByVal pPRIV_ID As String, ByVal pPRIV_NAME As String, ByVal pPRIV_GROUP As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/SearchByKeyAccessLevel", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function SearchByKeyAccessLevel(ByVal pROLE_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/SearchPartialAccessLevel", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function SearchPartialAccessLevel(ByVal pROLE_ID As String, ByVal pROLE_NAME As String, ByVal pROLE_DESCRIPTION As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/DeleteAccessLevel", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function DeleteAccessLevel(ByVal pROLE_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/UpdateAccessLevel", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function UpdateAccessLevel(ByVal pROLE_ID As String, ByVal pROLE_NAME As String, ByVal pROLE_DESCRIPTION As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/CreateAccessLevel", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function CreateAccessLevel(ByVal pROLE_ID As String, ByVal pROLE_NAME As String, ByVal pROLE_DESCRIPTION As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetCheckPointJoinAccessLevel", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetCheckPointJoinAccessLevel(ByVal pCheckPoint As String, ByVal pAccessLevel As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/SelectCheckPointsJoinAccessLevel", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function SelectCheckPointsJoinAccessLevel(ByVal pAccessLevel As String, ByVal JoinOrNot As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/JoinCheckPointToAccessLevel", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function JoinCheckPointToAccessLevel(ByVal pCheckPoint As String, ByVal pAccessLevel As String, ByVal pAddOrRemove As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/VerifyUserPass", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function VerifyUserPass(ByVal pUserID As String, ByVal pPass As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/VerifyExternalUserPass", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function VerifyExternalUserPass(ByVal pUserID As String, ByVal pPass As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/BringUserMenuBasc", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function BringUserMenuBasc(ByVal pUserID As String, ByVal pEnvironmentName As String) As String
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/VerifyUserPassBasc", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function VerifyUserPassBasc(ByVal pUserID As String, ByVal pPass As String, ByVal pEnvironmentName As String) As String
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetCompanyName", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetCompanyName(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetEnvironments", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetEnvironments(ByVal pPlatform As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetEnvironmentByKey", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetEnvironmentByKey(ByVal pPlatform As String, ByVal pEnvironmentKey As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetCheckPointsTree", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetCheckPointsTree(ByVal pRoleID As String, ByVal pRoleDesc As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IsUserAllowed", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function IsUserAllowed(ByVal pCheckPointID As String, ByVal pAccessLevel As String, ByVal JoinOrNot As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetMobileUserMenu", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetMobileUserMenu(ByVal pRoleID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetBascUserMenu", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetBascUserMenu(ByVal pRoleID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/UpdateUserPwd", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function UpdateUserPwd(ByVal pLOGIN_ID As String, ByVal pLOGIN_PWD As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/RegisterLogIn", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function RegisterLogIn(ByVal pLOGIN_ID As String, ByVal pInOrOut As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/UserCanGenerateTasks", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function UserCanGenerateTasks(ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/GetLastLoginID_OnThisTerminal", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function GetLastLoginID_OnThisTerminal(ByVal pTerminalIP As String, ByRef pResult As String, ByVal pEnvironmentName As String) As String
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/RegisterTerminalLogIn", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function RegisterTerminalLogIn(ByVal pTERMINAL_IP As String, ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/KillBroadcast", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function KillBroadcast(ByVal pBroadCastLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface WMS_SecuritySoapChannel
        Inherits OnePlanServices_Security.WMS_SecuritySoap, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class WMS_SecuritySoapClient
        Inherits System.ServiceModel.ClientBase(Of OnePlanServices_Security.WMS_SecuritySoap)
        Implements OnePlanServices_Security.WMS_SecuritySoap
        
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
        
        Public Function CreateUserLogin( _
                    ByVal pLOGIN_ID As String,  _
                    ByVal pROLE_ID As String,  _
                    ByVal pLOGIN_NAME As String,  _
                    ByVal pLOGIN_TYPE As String,  _
                    ByVal pLOGIN_STATUS As String,  _
                    ByVal pLOGIN_PWD As String,  _
                    ByVal pLICENSE_SERIAL As String,  _
                    ByVal pENVIRONMENT As String,  _
                    ByVal pGUI_LAYOUT As String,  _
                    ByVal pCONSOLIDATION_TERMINAL As Integer,  _
                    ByVal pLINE_ID As String,  _
                    ByVal pGENERATE_TASKS As String,  _
                    ByVal pLOADING_GATE As Integer,  _
                    ByVal pWHEREHOUSE_iD As String,  _
                    ByRef pResult As String,  _
                    ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.CreateUserLogin
            Return MyBase.Channel.CreateUserLogin(pLOGIN_ID, pROLE_ID, pLOGIN_NAME, pLOGIN_TYPE, pLOGIN_STATUS, pLOGIN_PWD, pLICENSE_SERIAL, pENVIRONMENT, pGUI_LAYOUT, pCONSOLIDATION_TERMINAL, pLINE_ID, pGENERATE_TASKS, pLOADING_GATE, pWHEREHOUSE_iD, pResult, pEnvironmentName)
        End Function
        
        Public Function UpdateUserLogin( _
                    ByVal pLOGIN_ID As String,  _
                    ByVal pROLE_ID As String,  _
                    ByVal pLOGIN_NAME As String,  _
                    ByVal pLOGIN_TYPE As String,  _
                    ByVal pLOGIN_STATUS As String,  _
                    ByVal pLOGIN_PWD As String,  _
                    ByVal pLICENSE_SERIAL As String,  _
                    ByVal pENVIRONMENT As String,  _
                    ByVal pGUI_LAYOUT As String,  _
                    ByVal pCONSOLIDATION_TERMINAL As Integer,  _
                    ByVal pGENERATE_TASKS As Integer,  _
                    ByVal pLINE_ID As String,  _
                    ByVal pLOADING_GATE As Integer,  _
                    ByVal pWHEREHOUSE_iD As String,  _
                    ByRef pResult As String,  _
                    ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.UpdateUserLogin
            Return MyBase.Channel.UpdateUserLogin(pLOGIN_ID, pROLE_ID, pLOGIN_NAME, pLOGIN_TYPE, pLOGIN_STATUS, pLOGIN_PWD, pLICENSE_SERIAL, pENVIRONMENT, pGUI_LAYOUT, pCONSOLIDATION_TERMINAL, pGENERATE_TASKS, pLINE_ID, pLOADING_GATE, pWHEREHOUSE_iD, pResult, pEnvironmentName)
        End Function
        
        Public Function UpdateUserGUI(ByVal pLOGIN_ID As String, ByVal pGUI_LAYOUT As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.UpdateUserGUI
            Return MyBase.Channel.UpdateUserGUI(pLOGIN_ID, pGUI_LAYOUT, pResult, pEnvironmentName)
        End Function
        
        Public Function DeleteUserLogin(ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.DeleteUserLogin
            Return MyBase.Channel.DeleteUserLogin(pLOGIN_ID, pResult, pEnvironmentName)
        End Function
        
        Public Function SearchOperators(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.SearchOperators
            Return MyBase.Channel.SearchOperators(pResult, pEnvironmentName)
        End Function
        
        Public Function SearchPartialUserLogin(ByVal pLOGIN_ID As String, ByVal pROLE_ID As String, ByVal pLOGIN_NAME As String, ByVal pLOGIN_TYPE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.SearchPartialUserLogin
            Return MyBase.Channel.SearchPartialUserLogin(pLOGIN_ID, pROLE_ID, pLOGIN_NAME, pLOGIN_TYPE, pResult, pEnvironmentName)
        End Function
        
        Public Function SearchByKeyUserLogin(ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.SearchByKeyUserLogin
            Return MyBase.Channel.SearchByKeyUserLogin(pLOGIN_ID, pResult, pEnvironmentName)
        End Function
        
        Public Function GroupByKeyUserLogin(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.GroupByKeyUserLogin
            Return MyBase.Channel.GroupByKeyUserLogin(pResult, pEnvironmentName)
        End Function
        
        Public Function AccessLevelGroups(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.AccessLevelGroups
            Return MyBase.Channel.AccessLevelGroups(pResult, pEnvironmentName)
        End Function
        
        Public Function CheckPointGroups(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.CheckPointGroups
            Return MyBase.Channel.CheckPointGroups(pResult, pEnvironmentName)
        End Function
        
        Public Function SearchByKeyCheckPoint(ByVal pPRIV_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.SearchByKeyCheckPoint
            Return MyBase.Channel.SearchByKeyCheckPoint(pPRIV_ID, pResult, pEnvironmentName)
        End Function
        
        Public Function SearchPartialCheckPoint(ByVal pPRIV_ID As String, ByVal pPRIV_NAME As String, ByVal pPRIV_GROUP As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.SearchPartialCheckPoint
            Return MyBase.Channel.SearchPartialCheckPoint(pPRIV_ID, pPRIV_NAME, pPRIV_GROUP, pResult, pEnvironmentName)
        End Function
        
        Public Function DeleteCheckPoint(ByVal pPRIV_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.DeleteCheckPoint
            Return MyBase.Channel.DeleteCheckPoint(pPRIV_ID, pResult, pEnvironmentName)
        End Function
        
        Public Function UpdateCheckPoint(ByVal pPRIV_ID As String, ByVal pPRIV_NAME As String, ByVal pPRIV_GROUP As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.UpdateCheckPoint
            Return MyBase.Channel.UpdateCheckPoint(pPRIV_ID, pPRIV_NAME, pPRIV_GROUP, pResult, pEnvironmentName)
        End Function
        
        Public Function CreateCheckPoint(ByVal pPRIV_ID As String, ByVal pPRIV_NAME As String, ByVal pPRIV_GROUP As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.CreateCheckPoint
            Return MyBase.Channel.CreateCheckPoint(pPRIV_ID, pPRIV_NAME, pPRIV_GROUP, pResult, pEnvironmentName)
        End Function
        
        Public Function SearchByKeyAccessLevel(ByVal pROLE_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.SearchByKeyAccessLevel
            Return MyBase.Channel.SearchByKeyAccessLevel(pROLE_ID, pResult, pEnvironmentName)
        End Function
        
        Public Function SearchPartialAccessLevel(ByVal pROLE_ID As String, ByVal pROLE_NAME As String, ByVal pROLE_DESCRIPTION As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.SearchPartialAccessLevel
            Return MyBase.Channel.SearchPartialAccessLevel(pROLE_ID, pROLE_NAME, pROLE_DESCRIPTION, pResult, pEnvironmentName)
        End Function
        
        Public Function DeleteAccessLevel(ByVal pROLE_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.DeleteAccessLevel
            Return MyBase.Channel.DeleteAccessLevel(pROLE_ID, pResult, pEnvironmentName)
        End Function
        
        Public Function UpdateAccessLevel(ByVal pROLE_ID As String, ByVal pROLE_NAME As String, ByVal pROLE_DESCRIPTION As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.UpdateAccessLevel
            Return MyBase.Channel.UpdateAccessLevel(pROLE_ID, pROLE_NAME, pROLE_DESCRIPTION, pResult, pEnvironmentName)
        End Function
        
        Public Function CreateAccessLevel(ByVal pROLE_ID As String, ByVal pROLE_NAME As String, ByVal pROLE_DESCRIPTION As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.CreateAccessLevel
            Return MyBase.Channel.CreateAccessLevel(pROLE_ID, pROLE_NAME, pROLE_DESCRIPTION, pResult, pEnvironmentName)
        End Function
        
        Public Function GetCheckPointJoinAccessLevel(ByVal pCheckPoint As String, ByVal pAccessLevel As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.GetCheckPointJoinAccessLevel
            Return MyBase.Channel.GetCheckPointJoinAccessLevel(pCheckPoint, pAccessLevel, pResult, pEnvironmentName)
        End Function
        
        Public Function SelectCheckPointsJoinAccessLevel(ByVal pAccessLevel As String, ByVal JoinOrNot As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.SelectCheckPointsJoinAccessLevel
            Return MyBase.Channel.SelectCheckPointsJoinAccessLevel(pAccessLevel, JoinOrNot, pResult, pEnvironmentName)
        End Function
        
        Public Function JoinCheckPointToAccessLevel(ByVal pCheckPoint As String, ByVal pAccessLevel As String, ByVal pAddOrRemove As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.JoinCheckPointToAccessLevel
            Return MyBase.Channel.JoinCheckPointToAccessLevel(pCheckPoint, pAccessLevel, pAddOrRemove, pResult, pEnvironmentName)
        End Function
        
        Public Function VerifyUserPass(ByVal pUserID As String, ByVal pPass As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.VerifyUserPass
            Return MyBase.Channel.VerifyUserPass(pUserID, pPass, pResult, pEnvironmentName)
        End Function
        
        Public Function VerifyExternalUserPass(ByVal pUserID As String, ByVal pPass As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.VerifyExternalUserPass
            Return MyBase.Channel.VerifyExternalUserPass(pUserID, pPass, pResult, pEnvironmentName)
        End Function
        
        Public Function BringUserMenuBasc(ByVal pUserID As String, ByVal pEnvironmentName As String) As String Implements OnePlanServices_Security.WMS_SecuritySoap.BringUserMenuBasc
            Return MyBase.Channel.BringUserMenuBasc(pUserID, pEnvironmentName)
        End Function
        
        Public Function VerifyUserPassBasc(ByVal pUserID As String, ByVal pPass As String, ByVal pEnvironmentName As String) As String Implements OnePlanServices_Security.WMS_SecuritySoap.VerifyUserPassBasc
            Return MyBase.Channel.VerifyUserPassBasc(pUserID, pPass, pEnvironmentName)
        End Function
        
        Public Function GetCompanyName(ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.GetCompanyName
            Return MyBase.Channel.GetCompanyName(pResult, pEnvironmentName)
        End Function
        
        Public Function GetEnvironments(ByVal pPlatform As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.GetEnvironments
            Return MyBase.Channel.GetEnvironments(pPlatform, pResult, pEnvironmentName)
        End Function
        
        Public Function GetEnvironmentByKey(ByVal pPlatform As String, ByVal pEnvironmentKey As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.GetEnvironmentByKey
            Return MyBase.Channel.GetEnvironmentByKey(pPlatform, pEnvironmentKey, pResult, pEnvironmentName)
        End Function
        
        Public Function GetCheckPointsTree(ByVal pRoleID As String, ByVal pRoleDesc As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.GetCheckPointsTree
            Return MyBase.Channel.GetCheckPointsTree(pRoleID, pRoleDesc, pResult, pEnvironmentName)
        End Function
        
        Public Function IsUserAllowed(ByVal pCheckPointID As String, ByVal pAccessLevel As String, ByVal JoinOrNot As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.IsUserAllowed
            Return MyBase.Channel.IsUserAllowed(pCheckPointID, pAccessLevel, JoinOrNot, pResult, pEnvironmentName)
        End Function
        
        Public Function GetMobileUserMenu(ByVal pRoleID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.GetMobileUserMenu
            Return MyBase.Channel.GetMobileUserMenu(pRoleID, pResult, pEnvironmentName)
        End Function
        
        Public Function GetBascUserMenu(ByVal pRoleID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As System.Data.DataSet Implements OnePlanServices_Security.WMS_SecuritySoap.GetBascUserMenu
            Return MyBase.Channel.GetBascUserMenu(pRoleID, pResult, pEnvironmentName)
        End Function
        
        Public Function UpdateUserPwd(ByVal pLOGIN_ID As String, ByVal pLOGIN_PWD As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.UpdateUserPwd
            Return MyBase.Channel.UpdateUserPwd(pLOGIN_ID, pLOGIN_PWD, pResult, pEnvironmentName)
        End Function
        
        Public Function RegisterLogIn(ByVal pLOGIN_ID As String, ByVal pInOrOut As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.RegisterLogIn
            Return MyBase.Channel.RegisterLogIn(pLOGIN_ID, pInOrOut, pResult, pEnvironmentName)
        End Function
        
        Public Function UserCanGenerateTasks(ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.UserCanGenerateTasks
            Return MyBase.Channel.UserCanGenerateTasks(pLOGIN_ID, pResult, pEnvironmentName)
        End Function
        
        Public Function GetLastLoginID_OnThisTerminal(ByVal pTerminalIP As String, ByRef pResult As String, ByVal pEnvironmentName As String) As String Implements OnePlanServices_Security.WMS_SecuritySoap.GetLastLoginID_OnThisTerminal
            Return MyBase.Channel.GetLastLoginID_OnThisTerminal(pTerminalIP, pResult, pEnvironmentName)
        End Function
        
        Public Function RegisterTerminalLogIn(ByVal pTERMINAL_IP As String, ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.RegisterTerminalLogIn
            Return MyBase.Channel.RegisterTerminalLogIn(pTERMINAL_IP, pLOGIN_ID, pResult, pEnvironmentName)
        End Function
        
        Public Function KillBroadcast(ByVal pBroadCastLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean Implements OnePlanServices_Security.WMS_SecuritySoap.KillBroadcast
            Return MyBase.Channel.KillBroadcast(pBroadCastLOGIN_ID, pResult, pEnvironmentName)
        End Function
    End Class
End Namespace
