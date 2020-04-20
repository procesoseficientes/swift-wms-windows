Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Collections
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Net
Imports MobilityScm.BarcodeScann.Arguments
Imports MobilityScm.BarcodeScann
Imports Resco
Imports Resco.Controls.AdvancedTree
Imports Resco.Controls.MessageBox
Imports USICF
Imports MobilityScm.Views
Imports MobilityScm.Keyboard
Imports System.ComponentModel
Imports MobilityScm.Vertical.Servicios
Imports MobilityScm.Bluetooth
Imports Resco.Controls

Module GlobalModule

    Public xScanner As BarcodeScanner


    Public _CurrentPanel As Control = Nothing
    Public panelLogin As ctrl_Login
    Public panelMenu As ctrl_Menu
    Public panelTakePicture As ctrl_Picture
    Public panelMyPicking As myPicking
    Public panelMyPickingMC92 As myPickingMC92
    Public panelMyReception As MyReception
    Public panelSetupPrinter As ctrl_setup_printer
    Public panelRecepFiscal As ctrl_RecepFiscal
    Public panelBrowsePics As ctrl_browse
    Public panelRecFiscalStep1 As ctrl_RECFIS_Step1
    Public panelRecFiscalLogisInfo As ctrl_RECFIS_LogisInfo
    Public panelRecFiscalStep2 As ctrl_RECFIS_Step2
    Public panelInfo_InvXLic As ctrl_inv_x_lic
    Public panelTransHandler As ctrl_trans_handler
    Public panelInfoHandler As ctrl_info_handler
    Public panelInfoHandlerTree As ctrl_info_handler_tree
    Public panelMyCounting As myCounting
    Public panelTypeChange As ctrl_type_charge
    Public panelAcuseRecibo As ctrl_acuse_recibo
    Public panelTomarFoto As TomarFoto
    Public panelMaterialXSerialNumbers As MaterialXSerialNumbers
    Public panelExplodeMasterPack As ExplodeMasterPack
    Public panelExplodeMasterPackDetail As ExplodeMasterPackDetail
    Public panelSerialNumberProcess As SerialNumberProcess
    Public panelScanDocument As ctrl_ScanDocument
    Public panelDetalleDevoluciones As DetalleDevoluciones
    Public panelUbicacionesSugeridas As UbicacionesSugeridas

    Public gPanelTitle As String = ""
    Public gCurrentReference As String = ""
    Public Global_WS_HOST As String = ""

    'Public m_PrinterConnection As Connection_Bluetooth32Feet
    'Public xImager As New Imaging2
    'Public xScanner As New Barcode2

    Public GlobalWarehouse As String = ""
    Public GlobalEnviroment As String = ""
    Public GlobalUserID As String = ""
    Public gRegimen As String = ""
    Public gRol As String = ""
    Public firstPrint As Boolean = True
    Public gLicenseID As String
    Public gIsPrinterConnected = False
    Public gCommercialAggrement As String = ""
    Public gPoliza As String = ""
    Public gTaskId As String = Nothing
    Public gOrden As String = Nothing
    Public gComments As String
    Public gClientOwner As String
    Public gWavePickingId As Integer
    Public gNewClientOwner As String
    Public gCurrentWavePicking As Integer
    Public gCurrentSerialNumber As Integer
    Public gCurrentSKUPicking As String
    Public gCurrentLocationPicking As String
    Public gCurrentLicenseID As Integer = 0
    Public gCurrentCodigoPoliza As String = ""
    Public gCurrentCodigoPolizaSource As String = ""
    Public gCurrentQtyToAlloc As Double = 0
    Public gSourceLocation As String = ""
    Public gDocumentType As String = String.Empty
    Public gLastPanelName As String
    Public gCurrentPage As String = ""
    Public gCurrentTransName As String = ""
    Public gCurrentScannerService As gSCANNER_SERVICES
    Public gCurrentTransactionType As gTRANS_TYPE = gTRANS_TYPE.NONE
    Public gTransaccionAnterior As gTRANS_TYPE = gTRANS_TYPE.NONE
    Public gDeviceAddress As String = ""
    Public gDeviceName As String = ""
    Public gPanelOption As String = ""
    Public gIsNewSKU As Boolean = False
    Public imageDataInBytes As Byte() = Nothing
    Public xset_gallery As DataSet
    Public gGallery_index As Integer = 0
    Public gMyLastLicense As Integer = 0
    Public gSourceLicense As Integer = 0

    Public gHasLogisticInfo As Boolean = False
    Public gPendingSKU As Boolean = False
    Public cmbLocalToT As New Resco.Controls.DetailView.ItemAdvancedComboBox
    Public IsVeryFirstPicture As Boolean = True
    Public pMethodAudit As String = ""

    Public currentSSID As String = ""
    Public currentSQText As String
    Public currentSS As Integer = 0
    Public currentWLANStatus As String = ""
    Public currentAdapterMACAddr As String = ""
    Public keyboardAction As gKEYBOARDACTION

    Public gBatchRequested As String = ""
    Public gIsSerie As String = ""
    Public gTipo As String = ""
    Public gRegiP As String = ""
    Public gTipoP As String = ""

    Public gValPoliza As Boolean = False
    Public gCambiarPantPoliza As Boolean = False
    Public gHandheld As String = ""

    Public gNumeroOrden As String = ""
    Public gLocationSpotTarget As String = ""
    Public gTaskSubType As String = ""
    Public gMaterialId As String = ""
    Public gMaterialBarCode As String = ""
    Public leftRelocationComplete As Boolean = False
    Public gMaterialIdPicking As String = ""
    Public gUsedMt2 As Decimal = 0
    Public gCurrentLocation As String = ""
    Public gCurrentLabel As Integer = 0
    ''Put the string value of your enum in the Description metatag.
    '' (Dont forget to Import System.ComponentModel)
    Public handheld As String = String.Empty
    Public gMuestraBotonSugerenciaReubicacion = False

    Public bluetooth As New MobilityScm.Bluetooth.Bluetooth

    Public Enum ResultadoOperacionTipo
        Fallo = -1
        Parcial = 0
        Exito = 1
        Duplicado = 3
        SobrepasaValidacion = 2
    End Enum

    Public Enum SiNo
        NO = 0
        SI = 1
    End Enum

    Public Enum gKEYBOARDACTION
        SHOW = 1
        HIDDE = 2
    End Enum


    Public Enum gBUTTON_POSITION
        FIRST_BUTTON = 1
        MIDDLE_1 = 2
        MIDDLE_2 = 3
        LAST_BUTTON = 4
        ALL = 5
    End Enum



    Public Enum gSCANNER_SERVICES
        LEER_POLIZA_EN_FOTOGRAFIA_BASC = 0
        LEER_POLIZA_EN_RECEPCION_FISCAL = 1
        LEER_POLIZA_EN_RECEPCION_ALMGEN = 2
        LEER_SKU_EN_RECEPCION_FISCAL = 3
        LEER_SKU_EN_RECEPCION_ALMGEN = 4
        LEER_SERIAL_EN_LOGIS_INFO = 5
        LEER_UBICACION_RECEP_FISCAL = 6
        LEER_NUEVO_SKU = 7
        LEER_UBICACION_TRASLADO_FISCAL_ALMGEN = 8
        LEER_POLIZA_EN_TRASLADO_GENERAL = 9
        LEER_POLIZA = 10
        LEER_SKU_EN_INICIALIZACION = 11
        LEER_LICENCIA_CONSULTA = 12
        LEER_POLIZA_CONSULTA = 13
        LEER_SKU_CONSULTA = 14
        LEER_UBICACION_CONSULTA = 15
        LEER_UBICACION_INICIALIZACION = 16
        LEER_LICENCIA_REIMPRESION = 17
        LEER_UBICACION_DESPACHO_FISCAL = 18
        LEER_LICENCIA_DESPACHO_FISCAL = 19
        LEER_SKU_DESPACHO_FISCAL = 20
        LEER_POLIZA_AUDITORIA_REC_FISCAL = 21
        LEER_SKU_AUDITORIA_REC_FISCAL = 22
        LEER_SERIE_AUDITORIA_REC_FISCAL = 23
        LEER_LICENCIA_REALLOC = 24
        LEER_UBICACION_REALLOC = 25
        LEER_POLIZA_AUDITORIA_DESP_FISCAL = 26
        LEER_SKU_AUDITORIA_DESP_FISCAL = 27
        LEER_SERIE_AUDITORIA_DESP_FISCAL = 28
        LEER_POLIZA_EN_AUDIT_SUMM = 29
        LEER_SKU_TRASLADO_ALMGEN = 30
        LEER_LIC_TRASLADO_ALMGEN = 31
        LEER_SKU_REALLOC_PARTIAL = 32
        LEER_UBICACION_RECEP_ALMGEN = 33
        LEER_SKU_DESPACHO_ALMGEN = 34
        LEER_UBICACION_DESPACHO_ALMGEN = 35
        LEER_LICENCIA_DESPACHO_ALMGEN = 36
        LEER_USER_PWD = 37
        MENU = 38
        LEER_CATALOGO_SKU_SEC1 = 39
        LEER_CATALOGO_SKU_WHPL = 40
        LEER_UBICACION_CONTEO = 41
        LEER_LICENCIA_CONTEO = 42
        LEER_SKU_CONTEO = 43
        LEER_UBICACION_OCUPACION = 44
        LEER_CLIENTE_INICIALIZACION = 45
        LEER_NUMERO_SERIE_RECEPCION = 46
        LEER_LICENCIA_PARA_MASTER_PACK = 47
        LEER_UBICACION_SALIDA_DESPACHO = 48
        LEER_SKU_PARA_MASTER_PACK = 49
        LEER_UBICACION_PARA_REUBICACION_POR_REABASTECIMIENTO = 50
        lEER_NUMERO_SERIE_DESPACHO = 51
        LEER_NUMERO_SERIE_REUBICACION_PARCIAL = 52
        LEER_CODIGO_DOCUMENTO_RECEPCION = 53
        LEER_ETIQUETA_REUBICACION = 54
        NO_SCAN_PANTALLA_IMPRESION_SKU = 55
    End Enum
    Public Enum gTRANS_TYPE
        NONE = 0
        RECEPCION_FISCAL = 1
        TRASLADO_FISCAL_A_GENERAL = 2
        INICIALIZACION = 3
        DESPACHO_FISCAL = 4
        DESPACHO_GENERAL = 5
        AUDITORIA_REC_FISCAL = 6
        AUDITORIA_DESP_FISCAL = 7
        AUDITORIA_REC_SUMM = 8
        REALLOC_PARTIAL = 9
        INICIALIZACION_GENERAL = 10
        RECEPCION_ALMGEN = 11
        CONTEO = 12
        OCCUPANCY = 13
        INGRESO_SERIES_RECEPCION = 14
        DESPACHO_UBICACION = 15
        REUBICACION_POR_REABASTECIMIENTO = 16
        ESCANEAR_DOCUMENTO_EXTERNO_RECEPCION = 17
        REUBICACION_COMPLETA = 18
        UNIFICAR_LICENCIA = 19
        MOSTRAR_SKUS_DESDE_PANTALLA_CREACION_LICENCIA = 20
        MOSTRAR_SKUS_DESDE_PANTALLA_RECEPCION = 21
    End Enum
    Public Class SmartGridClass
        Sub Populate_SetAuditLabels(ByRef pResult As String)
            Try
                pResult = "OK"
                Dim xset As DataSet
                Dim xserv As New WMS_InfoTrans.WMS_InfoTrans

                xset = xserv.GetAuditLabel("ITEM1", pResult, GlobalEnviroment)
                panelTransHandler.DetailView1.Items("txtQTY1").Label = xset.Tables(0).Rows(0)("PARAM_CAPTION")

                xset = xserv.GetAuditLabel("ITEM2", pResult, GlobalEnviroment)
                panelTransHandler.DetailView1.Items("txtQTY2").Label = xset.Tables(0).Rows(0)("PARAM_CAPTION")

                xset = xserv.GetAuditLabel("ITEM3", pResult, GlobalEnviroment)
                panelTransHandler.DetailView1.Items("txtQTY3").Label = xset.Tables(0).Rows(0)("PARAM_CAPTION")

                xset = xserv.GetAuditLabel("ITEM4", pResult, GlobalEnviroment)
                panelTransHandler.DetailView1.Items("txtQTY4").Label = xset.Tables(0).Rows(0)("PARAM_CAPTION")

            Catch ex As Exception
                pResult = ex.Message
            End Try
        End Sub
        Function Populate_AuditQuery(ByVal pAuditID As Integer, ByRef pResult As String) As Boolean

            Try
                Dim xset As DataSet
                Dim xserv As New WMS_InfoTrans.WMS_InfoTrans

                xset = xserv.GetAuditView(pAuditID, gPanelOption, pResult, GlobalEnviroment)
                panelInfoHandler.AdvancedList_Default.Templates("RowTemplate_Header").CellTemplates(2).CellSource.ConstantData = "--"
                If pResult = "OK" Then
                    If xset.Tables(0).Rows(0)("COUNTING_METHOD") = "INPUT" Then
                        panelInfoHandler.AdvancedList_Default.Templates("RowTemplate_Header").CellTemplates(2).CellSource.ConstantData = "QTY"
                        panelInfoHandler.AdvancedList_Default.Templates("RowTemplate_Row").CellTemplates(3).Visible = False
                        panelInfoHandler.AdvancedList_Default.Templates("RowTemplate_Row").CellTemplates(2).Visible = True
                    Else
                        panelInfoHandler.AdvancedList_Default.Templates("RowTemplate_Header").CellTemplates(2).CellSource.ConstantData = "SERIE"
                        panelInfoHandler.AdvancedList_Default.Templates("RowTemplate_Row").CellTemplates(2).Visible = False
                        panelInfoHandler.AdvancedList_Default.Templates("RowTemplate_Row").CellTemplates(3).Visible = True
                    End If

                    'panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "LICENCIA: " & pLicense
                    panelInfoHandler.AdvancedList_Default.DataSource = xset.Tables(0)
                    Return True
                Else
                    'panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SCAN LICENCIA..."
                    panelInfoHandler.AdvancedList_Default.DataSource = Nothing
                    Return False
                End If


            Catch ex As Exception
                Notify("PopulateAuditQuery:" + ex.Message, True)
                Return False
            End Try
        End Function
        Function Populate_AuditSumm(ByVal pAuditID As Integer, ByRef pResult As String) As Boolean
            Try
                Dim xset As DataSet
                Dim xserv As New WMS_InfoTrans.WMS_InfoTrans

                xset = xserv.GetAuditView(pAuditID, gPanelOption, pResult, GlobalEnviroment)
                If pResult = "OK" Then
                    'panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "LICENCIA: " & pLicense
                    panelInfoHandler.AdvancedList_Default.DataSource = xset.Tables(0)
                    Return True
                Else
                    'panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SCAN LICENCIA..."
                    panelInfoHandler.AdvancedList_Default.DataSource = Nothing
                    Return False
                End If


            Catch ex As Exception
                Notify("PopulateAuditSum: " + ex.Message, True)
                Return False
            End Try
        End Function

        Function Populate_Inv_x_License_Tree(ByVal pLicense As Integer, ByRef pResult As String) As Boolean
            Try
                panelInfoHandlerTree.AdvancedTree_Default.Nodes.Clear()
                Dim xset As DataSet
                'ojo
                Dim xserv As New WMS_InfoInventory.WMS_InfoInventory
                gCurrentLicenseID = CInt(pLicense)

                xset = xserv.GET_INV_X_LIC(pLicense, GlobalUserID, "*", pResult, GlobalEnviroment)
                gUsedMt2 = 0
                If pResult = "OK" Then
                    gUsedMt2 = IIf(IsDBNull(xset.Tables("GET_INV_X_LIC").Rows(0)("USED_MT2")), 0, xset.Tables("GET_INV_X_LIC").Rows(0)("USED_MT2"))
                    gCurrentLocation = IIf(IsDBNull(xset.Tables("GET_INV_X_LIC").Rows(0)("CURRENT_LOCATION")), "", xset.Tables("GET_INV_X_LIC").Rows(0)("CURRENT_LOCATION"))
                    panelInfoHandlerTree.AdvancedTree_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "LICENCIA: " & pLicense
                    For Each SkuRow As DataRow In xset.Tables("GET_INV_X_LIC").Rows
                        'create a new node
                        Dim SkuNode As BoundNode
                        SkuNode = New BoundNode(1, 1, SkuRow)
                        panelInfoHandlerTree.AdvancedTree_Default.Nodes.Add(SkuNode) ' add it to advancedtree

                        Dim series() As DataRow
                        series = SkuRow.GetChildRows("SERIES_X_SKU")
                        If series.Length = 0 Then
                            SkuNode.HidePlusMinus = True
                        End If
                        SkuNode.Collapse()

                        For Each serieRow As DataRow In series

                            ' create a node for the series
                            Dim serieNode As BoundNode
                            serieNode = New BoundNode(2, 2, serieRow)
                            SkuNode.Nodes.Add(serieNode)   ' add it to advancedtree
                            serieNode.HidePlusMinus = True
                        Next


                    Next


                    gSourceLicense = pLicense
                    gSourceLocation = IIf(IsDBNull(xset.Tables(0).Rows(0)("CURRENT_LOCATION")), "", xset.Tables(0).Rows(0)("CURRENT_LOCATION"))
                    gCurrentCodigoPoliza = IIf(IsDBNull(xset.Tables(0).Rows(0)("CODIGO_POLIZA")), "", xset.Tables(0).Rows(0)("CODIGO_POLIZA"))
                    gPoliza = gCurrentCodigoPoliza
                    gLicenseID = pLicense
                    gRegimen = xset.Tables(0).Rows(0)("REGIMEN")
                    '    gSourceLicense = pLicense
                    '    gSourceLocation = xset.Tables(0).Rows(0)("CURRENT_LOCATION")
                    '    gCurrentCodigoPoliza = xset.Tables(0).Rows(0)("CODIGO_POLIZA")
                    '    gPoliza = gCurrentCodigoPoliza
                    '    gLicenseID = pLicense
                    '    gRegimen = xset.Tables(0).Rows(0)("REGIMEN")
                    'End If

                    Return True
                Else

                    panelInfoHandlerTree.AdvancedTree_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SCAN LICENCIA..."
                    panelInfoHandlerTree.AdvancedTree_Default.Nodes.Clear()
                    'panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SCAN LICENCIA..."
                    'panelInfoHandler.AdvancedList_Default.DataSource = Nothing

                    Return False
                End If


            Catch ex As Exception
                Notify("PopulateInvXLicTree: " + ex.Message, True)
                Return False
                'Throw New System.Exception(ex.Message)
            End Try
        End Function

        Function Populate_Inv_x_Return(ByVal pTask As Integer, ByRef pResult As String) As Boolean
            Try
                Dim resultado As DataSet
                Dim servicio As New WMS_InfoTrans.WMS_InfoTrans

                resultado = servicio.ObtenerDetalleDeRecepcionPorDevolucionPorTarea(pTask, GlobalEnviroment, pResult)
                If pResult = "OK" Then

                    panelInfoHandler.AdvancedList_Default.DataRows.Clear()
                    panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "Devolucion"

                    panelInfoHandler.AdvancedList_Default.HeaderRow.TemplateIndex = 0
                    panelInfoHandler.AdvancedList_Default.TemplateIndex = 1
                    panelInfoHandler.AdvancedList_Default.SelectedTemplateIndex = 2

                    panelInfoHandler.AdvancedList_Default.DataSource = resultado.Tables(0)
                    Return True
                Else
                    panelInfoHandler.AdvancedList_Default.DataSource = Nothing
                    Return False
                End If
            Catch ex As Exception
                Notify("Populate_Inv_x_Return: " + ex.Message, True)
                Return False
            End Try
        End Function

        Function Populate_Inv_x_License(ByVal pLicense As Integer, ByRef pResult As String) As Boolean
            Try
                Dim xset As DataSet
                'ojo
                Dim xserv As New WMS_InfoInventory.WMS_InfoInventory
                gCurrentLicenseID = CInt(pLicense)

                xset = xserv.GET_INV_X_LIC(pLicense, GlobalUserID, "*", pResult, GlobalEnviroment)
                If pResult = "OK" Then

                    panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "LICENCIA: " & pLicense
                    panelInfoHandler.AdvancedList_Default.DataSource = xset.Tables(0)
                    panelInfoHandler.AdvancedList_Default.SelectedTemplateIndex = 1

                    gSourceLicense = pLicense
                    gSourceLocation = IIf(IsDBNull(xset.Tables(0).Rows(0)("CURRENT_LOCATION")), "", xset.Tables(0).Rows(0)("CURRENT_LOCATION"))
                    gCurrentCodigoPoliza = IIf(IsDBNull(xset.Tables(0).Rows(0)("CODIGO_POLIZA")), "", xset.Tables(0).Rows(0)("CODIGO_POLIZA"))
                    gPoliza = gCurrentCodigoPoliza
                    gLicenseID = pLicense
                    gRegimen = xset.Tables(0).Rows(0)("REGIMEN")
                    '    gSourceLicense = pLicense
                    '    gSourceLocation = xset.Tables(0).Rows(0)("CURRENT_LOCATION")
                    '    gCurrentCodigoPoliza = xset.Tables(0).Rows(0)("CODIGO_POLIZA")
                    '    gPoliza = gCurrentCodigoPoliza
                    '    gLicenseID = pLicense
                    '    gRegimen = xset.Tables(0).Rows(0)("REGIMEN")
                    'End If

                    Return True
                Else

                    panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SCAN LICENCIA..."
                    panelInfoHandler.AdvancedList_Default.DataSource = Nothing

                    Return False
                End If


            Catch ex As Exception
                Notify("PopulateInvXLic: " + ex.Message, True)

                Return False


                'Throw New System.Exception(ex.Message)
            End Try
        End Function


        Function Populate_Inv_x_Poliza(ByVal pPoliza As String, ByRef pResult As String) As Boolean
            Try
                Dim xset As DataSet

                Dim xserv As New WMS_InfoInventory.WMS_InfoInventory


                xset = xserv.GET_INV_X_POLIZA(pPoliza, pResult, GlobalEnviroment)
                If pResult = "OK" Then
                    panelInfoHandler.AdvancedList_Default.DataRows.Clear()
                    panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "POLIZA: " + pPoliza
                    panelInfoHandler.txtInputedData.Text = pPoliza

                    panelInfoHandler.AdvancedList_Default.HeaderRow.TemplateIndex = 0
                    panelInfoHandler.AdvancedList_Default.TemplateIndex = 1
                    panelInfoHandler.AdvancedList_Default.SelectedTemplateIndex = 2
                    panelInfoHandler.txtInputedData.SelectAll()
                    panelInfoHandler.txtInputedData.Focus()

                    panelInfoHandler.AdvancedList_Default.DataSource = xset.Tables(0)
                    Return True

                Else
                    panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SCAN POLIZA..."
                    panelInfoHandler.AdvancedList_Default.DataSource = Nothing
                    panelInfoHandler.txtInputedData.Text = ""
                    panelInfoHandler.txtInputedData.Focus()
                    Return False
                End If


            Catch ex As Exception
                Notify(ex.Message, True)
                Return False
                'Throw New System.Exception(ex.Message)
            End Try
        End Function

        Function Populate_Inv_x_Poliza_Tree(ByVal pPoliza As String, ByRef pResult As String) As Boolean
            Try
                panelInfoHandlerTree.AdvancedTree_Default.Nodes.Clear()
                Dim xset As DataSet
                'ojo
                Dim xserv As New WMS_InfoInventory.WMS_InfoInventory

                xset = xserv.GET_INV_X_POLIZA(pPoliza, pResult, GlobalEnviroment)
                If pResult = "OK" Then

                    panelInfoHandlerTree.AdvancedTree_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "POLIZA: " & pPoliza
                    panelInfoHandlerTree.txtInputedData.Text = pPoliza
                    panelInfoHandlerTree.txtInputedData.SelectAll()
                    panelInfoHandlerTree.txtInputedData.Focus()
                    For Each SkuRow As DataRow In xset.Tables("GET_INV_X_POLIZA").Rows
                        'create a new node
                        Dim SkuNode As BoundNode
                        SkuNode = New BoundNode(1, 1, SkuRow)
                        panelInfoHandlerTree.AdvancedTree_Default.Nodes.Add(SkuNode) ' add it to advancedtree

                        Dim series() As DataRow
                        series = SkuRow.GetChildRows("SERIES_X_SKU")
                        If series.Length = 0 Then
                            SkuNode.HidePlusMinus = True
                        End If
                        SkuNode.Collapse()

                        For Each serieRow As DataRow In series

                            ' create a node for the series
                            Dim serieNode As BoundNode
                            serieNode = New BoundNode(2, 2, serieRow)
                            SkuNode.Nodes.Add(serieNode)   ' add it to advancedtree
                            serieNode.HidePlusMinus = True
                        Next
                    Next
                    Return True
                Else
                    panelInfoHandlerTree.AdvancedTree_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SCAN POLIZA..."
                    panelInfoHandlerTree.AdvancedTree_Default.Nodes.Clear()
                    panelInfoHandlerTree.txtInputedData.Text = ""
                    panelInfoHandlerTree.txtInputedData.Focus()

                    Return False
                End If


            Catch ex As Exception
                Notify("PopulateInvXPolizaTree: " + ex.Message, True)
                Return False
                'Throw New System.Exception(ex.Message)
            End Try
        End Function

        Function Populate_Inv_x_SKU(ByVal pSKU As String, ByRef pResult As String) As Boolean
            Try
                If String.IsNullOrEmpty(pSKU) Or pSKU.Equals("...") Then
                    Return True
                End If
                Dim xset As DataSet

                Dim xserv As New WMS_InfoInventory.WMS_InfoInventory

                xset = xserv.GET_INV_X_SKU(pSKU, GlobalUserID, pResult, GlobalEnviroment)
                If pResult = "OK" Then
                    panelInfoHandler.AdvancedList_Default.DataRows.Clear()
                    panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SKU: " + pSKU

                    panelInfoHandler.AdvancedList_Default.HeaderRow.TemplateIndex = 0
                    panelInfoHandler.AdvancedList_Default.TemplateIndex = 1
                    panelInfoHandler.AdvancedList_Default.SelectedTemplateIndex = 2

                    panelInfoHandler.AdvancedList_Default.DataSource = xset.Tables(0)
                    'panelInfoHandler.AdvancedList_Default.DataRows(0).Selected = True
                    Return True


                Else
                    panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SCAN SKU..."
                    panelInfoHandler.AdvancedList_Default.DataSource = Nothing
                    Return False
                End If

                Return True
            Catch ex As Exception
                Notify("PopulateInvXSKU: " + ex.Message, True)

                Return False
            End Try
        End Function

        Function Populate_Inv_x_SKU_Tree(ByVal pSKU As String, ByRef pResult As String) As Boolean
            Try
                If String.IsNullOrEmpty(pSKU) Or pSKU.Equals("...") Then
                    Return True
                End If
                panelInfoHandlerTree.AdvancedTree_Default.Nodes.Clear()
                Dim xset As DataSet
                'ojo
                Dim xserv As New WMS_InfoInventory.WMS_InfoInventory

                xset = xserv.GET_INV_X_SKU(pSKU, GlobalUserID, pResult, GlobalEnviroment)
                If pResult = "OK" Then

                    panelInfoHandlerTree.AdvancedTree_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SKU: " + pSKU
                    panelInfoHandlerTree.txtInputedData.Text = pSKU
                    panelInfoHandlerTree.txtInputedData.SelectAll()
                    panelInfoHandlerTree.txtInputedData.Focus()
                    For Each SkuRow As DataRow In xset.Tables("GET_INV_X_SKU").Rows
                        'create a new node
                        Dim SkuNode As BoundNode
                        SkuNode = New BoundNode(1, 1, SkuRow)
                        panelInfoHandlerTree.AdvancedTree_Default.Nodes.Add(SkuNode) ' add it to advancedtree

                        Dim series() As DataRow
                        series = SkuRow.GetChildRows("SERIES_X_SKU")
                        If series.Length = 0 Then
                            SkuNode.HidePlusMinus = True
                        End If
                        SkuNode.Collapse()

                        For Each serieRow As DataRow In series

                            ' create a node for the series
                            Dim serieNode As BoundNode
                            serieNode = New BoundNode(2, 2, serieRow)
                            SkuNode.Nodes.Add(serieNode)   ' add it to advancedtree
                            serieNode.HidePlusMinus = True
                        Next
                    Next
                    Return True
                Else
                    panelInfoHandlerTree.AdvancedTree_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SCAN SKU..."
                    panelInfoHandlerTree.AdvancedTree_Default.Nodes.Clear()
                    Return False

                End If


            Catch ex As Exception
                Notify("PopulateInvXSKU_Tree: " + ex.Message, True)
                Return False
                'Throw New System.Exception(ex.Message)
            End Try
        End Function

        Function Populate_Inv_x_Loc(ByVal pLOC As String, ByRef pResult As String) As Boolean
            Try
                Dim xset As DataSet
                Dim xserv As New WMS_InfoInventory.WMS_InfoInventory
                'ojo
                xset = xserv.GET_INV_X_LOC(pLOC, GlobalUserID, pResult, GlobalEnviroment)
                If pResult = "OK" Then
                    panelInfoHandler.AdvancedList_Default.DataRows.Clear()
                    panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "Ubicación: " + pLOC

                    panelInfoHandler.AdvancedList_Default.HeaderRow.TemplateIndex = 0
                    panelInfoHandler.AdvancedList_Default.TemplateIndex = 1
                    panelInfoHandler.AdvancedList_Default.SelectedTemplateIndex = 2

                    panelInfoHandler.AdvancedList_Default.DataSource = xset.Tables(0)
                    Return True
                Else
                    panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "Scan Ubicación:"
                    panelInfoHandler.AdvancedList_Default.DataSource = Nothing
                    Return False
                End If

                Return True
            Catch ex As Exception
                Notify("Populate_Inv_x_Loc.CATCH:" + ex.Message, True)
                Return False
            End Try
        End Function

        Function Populate_Inv_x_Loc_Tree(ByVal pLOC As String, ByRef pResult As String) As Boolean
            Try

                panelInfoHandlerTree.AdvancedTree_Default.Nodes.Clear()
                Dim xset As DataSet
                'ojo
                Dim xserv As New WMS_InfoInventory.WMS_InfoInventory

                xset = xserv.GET_INV_X_LOC(pLOC, GlobalUserID, pResult, GlobalEnviroment)
                If pResult = "OK" Then

                    panelInfoHandlerTree.AdvancedTree_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "Ubicación: " + pLOC
                    panelInfoHandlerTree.txtInputedData.Text = pLOC
                    panelInfoHandlerTree.txtInputedData.SelectAll()
                    panelInfoHandlerTree.txtInputedData.Focus()
                    For Each SkuRow As DataRow In xset.Tables("GET_INV_X_LOC").Rows
                        'create a new node
                        Dim SkuNode As BoundNode
                        SkuNode = New BoundNode(1, 1, SkuRow)
                        panelInfoHandlerTree.AdvancedTree_Default.Nodes.Add(SkuNode) ' add it to advancedtree

                        Dim series() As DataRow
                        series = SkuRow.GetChildRows("SERIES_X_SKU")
                        If series.Length = 0 Then
                            SkuNode.HidePlusMinus = True
                        End If
                        SkuNode.Collapse()

                        For Each serieRow As DataRow In series

                            ' create a node for the series
                            Dim serieNode As BoundNode
                            serieNode = New BoundNode(2, 2, serieRow)
                            SkuNode.Nodes.Add(serieNode)   ' add it to advancedtree
                            serieNode.HidePlusMinus = True
                        Next
                    Next
                    Return True
                Else
                    panelInfoHandlerTree.AdvancedTree_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "Scan Ubicación:"
                    panelInfoHandlerTree.AdvancedTree_Default.Nodes.Clear()
                    Return False

                End If


            Catch ex As Exception
                Notify("Populate_Inv_x_Loc_Tree: " + ex.Message, True)
                Return False
                'Throw New System.Exception(ex.Message)
            End Try
        End Function

        Function popularArbolUbicaciones(ByVal license As Integer, ByRef pResult As String) As Boolean
            Dim xserv As New WMS_Materials.WMS_Materials
            Dim xdTable As DataTable

            Try
                panelUbicacionesSugeridas.UIVistaUbicacionesSugeridas.Rows.Clear()
                xdTable = xserv.GetSuggestedLocations(license, GlobalUserID, GlobalEnviroment, pResult)
                If xdTable Is Nothing AndAlso xdTable.Rows.Count = 0 Then
                    pResult = "No hay ubicaciones sugeridas para esta licencia"
                    Return False
                End If
                panelUbicacionesSugeridas.UIVistaUbicacionesSugeridas.DataSource = xdTable
                Return True
            Catch ex As Exception
                pResult = ex.Message
                Return False
            End Try
        End Function

        Function mostrarPantallaSkusPorTareaRecepcion(ByVal taskId As Integer, ByRef pResult As String) As Boolean
            Dim xserv As New WMS_Materials.WMS_Materials
            Dim xdTable As DataTable

            Try
                xdTable = xserv.GetMaterialsReceptionDocumentByTask(taskId, GlobalEnviroment, pResult)
                If xdTable Is Nothing Then
                    Return False
                End If
                cargarPantalla(xdTable)
                Return True
            Catch ex As Exception
                pResult = ex.Message
                Return False
            End Try
        End Function

        Private Sub cargarPantalla(ByVal dataSource As DataTable)
            panelInfoHandler.transTypeTemporal = gCurrentTransactionType
            panelInfoHandler.currentScannerTemporal = gCurrentScannerService
            gCurrentScannerService = gSCANNER_SERVICES.NO_SCAN_PANTALLA_IMPRESION_SKU
            gCurrentTransactionType = gTRANS_TYPE.MOSTRAR_SKUS_DESDE_PANTALLA_CREACION_LICENCIA
            ShowPanel(panelInfoHandler)
            LoadPage("skus_s1", "Recepcion", True)
            panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "IMPRIMIR SKU RECEPCION"
            panelInfoHandler.txtInputedData.Visible = False
            panelInfoHandler.AdvancedList_Default.DataRows.Clear()

            panelInfoHandler.AdvancedList_Default.HeaderRow.TemplateIndex = 0
            panelInfoHandler.AdvancedList_Default.TemplateIndex = 1
            panelInfoHandler.AdvancedList_Default.SelectedTemplateIndex = 2

            panelInfoHandler.AdvancedList_Default.DataSource = dataSource
        End Sub

        Function Populate_SKUs_S1(ByVal pSKU As String, ByRef pResult As String) As Boolean
            Try
                If String.IsNullOrEmpty(pSKU) Or pSKU.Equals("...") Then
                    Return True
                End If

                Dim xset As DataSet
                Dim xserv As New WMS_Materials.WMS_Materials

                xset = xserv.GetMaterialsSector1(pSKU, pSKU, pResult, GlobalEnviroment)
                If pResult = "OK" Then
                    panelInfoHandler.AdvancedList_Default.DataRows.Clear()
                    'panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "Ubicación: " + pLOC

                    panelInfoHandler.AdvancedList_Default.HeaderRow.TemplateIndex = 0
                    panelInfoHandler.AdvancedList_Default.TemplateIndex = 1
                    panelInfoHandler.AdvancedList_Default.SelectedTemplateIndex = 2

                    panelInfoHandler.AdvancedList_Default.DataSource = xset.Tables(0)
                    Return True
                Else
                    panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SCAN/INPUT SKU:"
                    panelInfoHandler.AdvancedList_Default.DataSource = Nothing
                    Return False
                End If

                Return True
            Catch ex As Exception
                Notify(ex.Message, True)
                Return False
            End Try
        End Function

    End Class


    Public Class TypeSkuReception
        Public InsertSku As String = "INSERT"
        Public UpdateSku As String = "UPDATE"
        Public AddSku As String = "ADD"
    End Class

    Public typeSku As TypeSkuReception = New TypeSkuReception()

    Public Sub SaveSKULicense()
        Try
            Dim xserv As New WMS_Polizas.WMS_Polizas
            Dim pSKUS_counted As Integer = 0
            Dim pVolumen As Double = 0, pPeso As Double = 0, pSerie As String = ""

            Dim pResult As String = ""

            If gHasLogisticInfo Then
                pVolumen = panelRecFiscalLogisInfo.txtVolumen.Text
                pPeso = panelRecFiscalLogisInfo.txtPeso.Text
                pSerie = panelRecFiscalLogisInfo.txtSerie.Text
                gComments = panelRecFiscalLogisInfo.txtComments.Text
            End If

            Dim xserv1 As New WMS_InfoInventory.WMS_InfoInventory
            Dim xset1 As DataSet

            Select Case gCurrentTransactionType
                Case gTRANS_TYPE.DESPACHO_FISCAL
                    xset1 = xserv1.GET_INV_X_LIC(gSourceLicense, GlobalUserID, panelTransHandler.DetailView1.Items("txtScannedSKU").Text, pResult, GlobalEnviroment)
                    If pResult = "OK" Then
                        Dim pQtyInputed As Double = CDbl(panelTransHandler.DetailView1.Items("txtCantidad").Text)
                        Dim pQtyOnHand As Double = xset1.Tables(0).Rows(0)("QTY")

                        If pQtyInputed > pQtyOnHand Then
                            pResult = "ERROR, Licencia: " & gSourceLicense & " No tiene suficiente inventario(" & pQtyOnHand & ") del SKU: " + panelTransHandler.DetailView1.Items("txtScannedSKU").Text + " para rebajar " & pQtyInputed
                            Notify(pResult, True)
                            Exit Sub
                        End If
                    Else
                        Notify(pResult, True)
                        panelTransHandler.DetailView1.Items("lblSKUName").Visible = True
                        panelTransHandler.DetailView1.Items("lblSKUName").Text = pResult
                        gPendingSKU = True
                        Exit Sub
                    End If


                Case gTRANS_TYPE.REALLOC_PARTIAL
                    Dim xservInfo As New WMS_InfoInventory.WMS_InfoInventory
                    Dim xserMa As New WMS_Materials.WMS_Materials
                    Dim xset As DataSet = xserMa.SearchByBarCode(panelTransHandler.DetailView1.Items("txtScannedSKU").Text, gClientOwner, pResult, GlobalEnviroment)
                    Dim dt As DataTable
                    dt = xservInfo.ValidateLicenceAndSkuToRealloc(gSourceLicense, xset.Tables(0).Rows(0)("MATERIAL_ID").ToString, GlobalEnviroment, pResult) 'XSET1 = xservInfo.GET_INV_X_LIC(gSourceLicense, pBarcode, pResult, GlobalEnviroment)
                    'xset1 = xserv1.GET_INV_X_LIC(gSourceLicense, panelTransHandler.DetailView1.Items("txtScannedSKU").Text, pResult, GlobalEnviroment)
                    If dt.Columns.Count > 1 Then
                        Dim pQtyInputed As Double = CDbl(panelTransHandler.DetailView1.Items("txtCantidad").Text)
                        Dim pQtyOnHand As Double = dt.Rows(0)("QTY")

                        If pQtyInputed > pQtyOnHand Then
                            pResult = "ERROR, Licencia: " & gSourceLicense & " No tiene suficiente inventario(" & pQtyOnHand & ") del SKU: " + panelTransHandler.DetailView1.Items("txtScannedSKU").Text + " para rebajar " & pQtyInputed
                            Notify(pResult, True)
                            Exit Sub
                        End If
                    Else
                        pResult = dt.Rows(0)(0).ToString()
                        Notify(pResult, True)
                        panelTransHandler.DetailView1.Items("lblSKUName").Visible = True
                        panelTransHandler.DetailView1.Items("lblSKUName").Text = pResult
                        gPendingSKU = True
                        Exit Sub
                    End If
                Case gTRANS_TYPE.INICIALIZACION_GENERAL
                    'gCurrentCodigoPoliza = "" 'gLicenseID
                    'gPoliza = gCurrentCodigoPoliza
            End Select

            Dim nameStatus As String = CType(panelTransHandler.DetailView1.Items("UiListaEstado"), Resco.Controls.DetailView.ItemAdvancedComboBox).Value

            If String.IsNullOrEmpty(nameStatus) Then
                Notify("Tiene que seleccionar un estado.", True)
                Exit Sub
            End If

            Dim tone As String = String.Empty, caliber As String = String.Empty
            If ValidatedPropertyVisible(panelTransHandler.DetailView1.Items("UiTextTone").Visible) Then
                tone = panelTransHandler.DetailView1.Items("UiTextTone").Text.Trim
                If String.IsNullOrEmpty(tone) Then
                    Notify("Tiene que ingresar el tono.", True)
                    panelTransHandler.DetailView1.Items("UiTextTone").SetFocus()
                    Exit Sub
                End If
            End If

            If ValidatedPropertyVisible(panelTransHandler.DetailView1.Items("UiTextCaliber").Visible) Then
                caliber = panelTransHandler.DetailView1.Items("UiTextCaliber").Text.Trim
                If String.IsNullOrEmpty(caliber) Then
                    Notify("Tiene que ingresar el calibre.", True)
                    panelTransHandler.DetailView1.Items("UiTextCaliber").SetFocus()
                    Exit Sub
                End If
            End If

            If CDbl(panelTransHandler.DetailView1.Items("txtCantidad").Text) <= 0 Then
                Notify("La cantidad tiene que ser mayor a cero.", True)
                panelTransHandler.DetailView1.Items("txtCantidad").SetFocus()
                Exit Sub
            End If

            If ValidatedQtyVin() Then
                Notify("La cantidad no puede ser mayor a uno, cuando el producto es carro.", True)
                panelTransHandler.DetailView1.Items("txtCantidad").SetFocus()
                Exit Sub
            End If

            Dim xdate As Date = CType(panelTransHandler.DetailView1.Items("dtFechaExpiracion"), Resco.Controls.DetailView.ItemDateTime).DateTime

            xserv.AgregaSKU_Licencia(CInt(gLicenseID), panelTransHandler.DetailView1.Items("txtScannedSKU").Text, CDbl(panelTransHandler.DetailView1.Items("txtCantidad").Text), GlobalUserID, 0, 0, pSerie, IIf(gComments = "", gCurrentReference, gComments), gCommercialAggrement, pSKUS_counted, IIf(gIsNewSKU, "FOR_REVIEW", "PROCESSED"), pResult, GlobalEnviroment, xdate, panelTransHandler.DetailView1.Items("txtNumLote").Text, panelTransHandler.DetailView1.Items("UiTextoVinRecepcion").Text, nameStatus, typeSku.InsertSku, tone, caliber)

            If pResult.ToUpper.Equals("SKU_REPETIDO") Then
                Dim typeSkuRecp As String = typeSku.InsertSku

                If MessageConfirmationWithTextChanged("El material ya existe, ¿Desea?", "Actualizar", "Agregar") Then
                    typeSkuRecp = typeSku.UpdateSku
                Else
                    typeSkuRecp = typeSku.AddSku
                End If

                xserv.AgregaSKU_Licencia(CInt(gLicenseID), panelTransHandler.DetailView1.Items("txtScannedSKU").Text, CDbl(panelTransHandler.DetailView1.Items("txtCantidad").Text), GlobalUserID, 0, 0, pSerie, IIf(gComments = "", gCurrentReference, gComments), gCommercialAggrement, pSKUS_counted, IIf(gIsNewSKU, "FOR_REVIEW", "PROCESSED"), pResult, GlobalEnviroment, xdate, panelTransHandler.DetailView1.Items("txtNumLote").Text, panelTransHandler.DetailView1.Items("UiTextoVinRecepcion").Text, nameStatus, typeSkuRecp, tone, caliber)
            End If


            If pResult = "OK" Then
                With panelTransHandler.DetailView1
                    Try
                        RemoveHandler CType(panelTransHandler.DetailView1.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf qty_entered
                    Catch
                    End Try


                    .Items("txtCantidad").Text = ""
                    .Items("txtCantidad").Tag = ""
                    .Items("txtScannedSKU").Text = ""
                    .Items("lblSKUName").Text = ""
                    .Items("txtCantidad").Visible = False
                    .Items("txtNumLote").Visible = False
                    .Items("UiTextoVinRecepcion").Visible = False
                    .Items("dtFechaExpiracion").Visible = False
                    .Items("UiTextTone").Visible = False
                    .Items("UiTextCaliber").Visible = False
                    .Focus()
                    .Items("txtScannedSKU").SetFocus()

                    panelTransHandler.btn_middle_1.Text = "SKUs(" & pSKUS_counted & ")"

                    panelTransHandler.Refresh()
                    gPendingSKU = False

                    Select Case gCurrentTransactionType
                        Case gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_TRASLADO_FISCAL_ALMGEN
                            panelRecFiscalStep2.lblTitle.Text = "Poliza: " & gPoliza & "/Orden: " & gNumeroOrden & " Licencia: " & gLicenseID
                            panelRecFiscalStep2.LBL_LOCATION.Text = "Scan Ubi.(Traslado):"
                            panelRecFiscalStep2.btnStatus.Visible = False
                            panelRecFiscalStep2.UIVistaUbicacionesSugeridas.Visible = False
                            panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = False
                            ShowPanel(panelRecFiscalStep2)

                        Case gTRANS_TYPE.REALLOC_PARTIAL
                            'Dim xserM As New WMS_Materials.WMS_Materials

                            'Dim ds As DataSet
                            'pResult = ""
                            'ds = xserM.GetTotalFactorVolumeLicense(gLicenseID, pResult, GlobalEnviroment)

                            'panelRecFiscalStep2.txtMT2.Text = "0"
                            'If pResult = "OK" Then
                            '    If Not ds.Tables(0).Rows.Count = 0 Then
                            '        panelRecFiscalStep2.txtMT2.Text = ds.Tables(0).Rows(0)(0).ToString()
                            '    End If
                            'Else
                            '    Notify(pResult, True)
                            'End If
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_TRASLADO_FISCAL_ALMGEN
                            Dim location As String = ""
                            location = GetLicenseByStatus()
                            panelRecFiscalStep2.lblTitle.Text = "Poliza: " & gPoliza & "/Orden: " & gNumeroOrden & " Licencia: " & gLicenseID
                            panelRecFiscalStep2.LBL_LOCATION.Text = IIf(String.IsNullOrEmpty(location), "Scan Ubicación (Reubic.Parcial)", "Scan Ubicación (" + location + ")")
                            panelRecFiscalStep2.LBL_LOCATION.Tag = location
                            panelRecFiscalStep2.btnStatus.Visible = False
                            panelRecFiscalStep2.UIVistaUbicacionesSugeridas.Visible = False
                            panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = gMuestraBotonSugerenciaReubicacion
                            ShowPanel(panelRecFiscalStep2)

                    End Select



                End With
            Else
                Notify(pResult, True)
                panelTransHandler.DetailView1.Items("lblSKUName").Visible = True
                panelTransHandler.DetailView1.Items("lblSKUName").Text = pResult
                gPendingSKU = True
            End If

        Catch ex As Exception
            panelTransHandler.DetailView1.Items("lblSKUName").Text = ex.Message
            panelTransHandler.DetailView1.Items("lblSKUName").Control.BackColor = Color.Red
            panelTransHandler.DetailView1.Items("lblSKUName").Control.ForeColor = Color.White
            gPendingSKU = True
        End Try
    End Sub

    Private Function ValidatedQtyVin() As Boolean
        Return (panelTransHandler.DetailView1.Items("UiTextoVinRecepcion").Visible AndAlso CDbl(panelTransHandler.DetailView1.Items("txtCantidad").Text) > 1)
    End Function

    Private Function ValidatedPropertyVisible(ByVal propertyVisble As Boolean) As Boolean
        Return propertyVisble
    End Function

    Private Function GetLicenseByStatus() As String
        Dim location As String = ""
        Dim webServiceInfoTrans As New WMS_InfoTrans.WMS_InfoTrans
        Dim dtValidated As DataTable
        Dim resultValidated As String = ""
        dtValidated = webServiceInfoTrans.ValidateStatusInMaterialsLicense(gLicenseID, GlobalEnviroment, resultValidated)

        If resultValidated.ToUpper.Equals("OK") Then
            If LicenseStatusHasValidLocation(dtValidated(0)("DbData").ToString) Then
                location = dtValidated(0)("DbData").ToString
            End If
        End If

        Return location
    End Function
    'License Status Has Valid Location
    Private Function LicenseStatusHasValidLocation(ByVal ubicacion As String) As Boolean
        Return Not String.IsNullOrEmpty(ubicacion)
    End Function

    Public Sub ShowNextPicture()
        Dim imgByteArray() As Byte

        If gGallery_index >= (xset_gallery.Tables(0).Rows.Count - 1) Then
            gGallery_index = 0
        Else
            If Not IsVeryFirstPicture Then
                gGallery_index += 1
            Else
                IsVeryFirstPicture = False
            End If
        End If

        imgByteArray = CType(xset_gallery.Tables(0).Rows(gGallery_index)("IMAGEN"), Byte())

        Dim stream As New System.IO.MemoryStream(imgByteArray)
        Dim bmp As New Bitmap(stream)
        stream.Close()

        panelBrowsePics.PictureBox1.Image = bmp
        panelBrowsePics.lblPictureInfo.Text = gGallery_index + 1 & "/" & xset_gallery.Tables(0).Rows.Count & " " + xset_gallery.Tables(0).Rows(gGallery_index)("UPLOADED_BY") + " " + xset_gallery.Tables(0).Rows(gGallery_index)("UPLOADED_DATE").ToString


    End Sub
    Public Sub ShowPrevPicture()
        Dim imgByteArray() As Byte


        If gGallery_index = 0 Then
            gGallery_index = (xset_gallery.Tables(0).Rows.Count - 1)
        Else
            gGallery_index = gGallery_index - 1
        End If

        imgByteArray = CType(xset_gallery.Tables(0).Rows(gGallery_index)("IMAGEN"), Byte())

        Dim stream As New System.IO.MemoryStream(imgByteArray)
        Dim bmp As New Bitmap(stream)
        stream.Close()

        panelBrowsePics.PictureBox1.Image = bmp
        panelBrowsePics.lblPictureInfo.Text = gGallery_index + 1 & "/" & xset_gallery.Tables(0).Rows.Count & " " + xset_gallery.Tables(0).Rows(gGallery_index)("UPLOADED_BY") + " " + xset_gallery.Tables(0).Rows(gGallery_index)("UPLOADED_DATE").ToString



    End Sub
    Public Sub CloseScanner()

        Try

            xScanner.Disabled()

        Catch ex As Exception
            'MessageBox.Show("WTF? " + ex.Message)
        End Try


    End Sub



    Public Sub SetupScanner(ByVal formParent As frmBase)
        Try
            xScanner = Nothing
            xScanner = New BarcodeScanner()
            xScanner.SetupScanner(formParent)
            xScanner.Disabled()
            gHandheld = xScanner.Handheld
            RemoveHandler xScanner.DataReady, AddressOf BarcodeIsScanned
            AddHandler xScanner.DataReady, AddressOf BarcodeIsScanned

        Catch ex As Exception
            'Notify(ex.Message, True)
        End Try
    End Sub

    Public Sub SetupScanner()
        xScanner.Enabled()
    End Sub

    Public Sub ShowPanel(ByVal panel As Control)
        Cursor.Current = Cursors.WaitCursor
        If Not panel.Equals(_CurrentPanel) Then
            If _CurrentPanel IsNot Nothing Then

                If _CurrentPanel.Name <> "ctrl_setup_printer" Then
                    gLastPanelName = _CurrentPanel.Name
                End If
                _CurrentPanel.Visible = False
            End If
            _CurrentPanel = panel
            _CurrentPanel.Visible = True
            _CurrentPanel.Focus()
        End If
        Cursor.Current = Cursors.Default
    End Sub
    Public Function ProcessLicense(ByVal pTransType As String, ByVal pLicense As String, ByVal pQty As Double, ByVal pSKU_BC As String, ByVal pSKU As String, ByVal pComments As String, ByVal pCurrentLocation As String, ByVal pNewLocation As String, ByVal pClientOwner As String, ByVal pStatus As String, ByVal pTransMT2 As Decimal, ByVal pVin As String, ByVal pSerial As String, ByVal pLote As String, ByVal pFechaLote As Date, ByRef pResult As String) As Boolean
        Try
            'cambio
            'crear registro en transacciones
            Dim xserv As New WMS_Trans.WMS_Trans

            Select Case gCurrentTransactionType
                Case gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL
                    If gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_TRASLADO_FISCAL_ALMGEN Then
                        'Return xserv.AllocLicense(CInt(pLicense), pNewLocation, GlobalUserID, pResult, GlobalEnviroment)
                        Return xserv.RegisterTrans(gCommercialAggrement, GlobalUserID, "RECEP_GENERAL_X_TRASLADO", pComments, pSKU_BC, pSKU, gSourceLicense, CInt(pLicense), gSourceLocation, pNewLocation, pClientOwner, pQty, "", "", "", gPoliza, CInt(pLicense), pStatus, gCurrentWavePicking, gCurrentSerialNumber, pTransMT2, "", 0, pVin, gTaskId, pSerial, pLote, pFechaLote, pResult, GlobalEnviroment)
                    Else
                        Return xserv.RegisterTrans(gCommercialAggrement, GlobalUserID, pTransType, pComments, pSKU_BC, pSKU, gSourceLicense, CInt(pLicense), pCurrentLocation, pNewLocation, pClientOwner, pQty, "", "", "", gPoliza, CInt(pLicense), pStatus, 0, 0, pTransMT2, "", 0, pVin, gTaskId, pSerial, pLote, pFechaLote, pResult, GlobalEnviroment)
                    End If
                Case gTRANS_TYPE.REALLOC_PARTIAL
                    Return xserv.RegisterTrans(gCommercialAggrement, GlobalUserID, "REUBICACION_PARCIAL", pComments, pSKU_BC, pSKU, gSourceLicense, CInt(pLicense), gSourceLocation, pNewLocation, pClientOwner, pQty, "", "", "", gPoliza, CInt(pLicense), pStatus, 0, 0, pTransMT2, "", 0, pVin, gTaskId, pSerial, pLote, pFechaLote, pResult, GlobalEnviroment)
                Case Else
                    Return xserv.RegisterTrans(gCommercialAggrement, GlobalUserID, pTransType, pComments, pSKU_BC, pSKU, "0", CInt(pLicense), pCurrentLocation, pNewLocation, pClientOwner, pQty, "", "", "", gPoliza, CInt(pLicense), pStatus, 0, 0, pTransMT2, "", 0, pVin, gTaskId, pSerial, pLote, pFechaLote, pResult, GlobalEnviroment)
            End Select

        Catch ex As Exception
            pResult = "ProcessLicense: " + ex.Message
            Return False
        End Try
    End Function
    Sub sku_name_entered(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If CType(panelTransHandler.DetailView1.Items("lblSKUName"), Resco.Controls.DetailView.ItemTextBox).Control.Focused Then
                Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                    Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                        If Len(panelTransHandler.DetailView1.Items("lblSKUName").Text) >= 1 Then
                            CType(panelTransHandler.DetailView1.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).SetFocus()

                            Try
                                RemoveHandler CType(panelTransHandler.DetailView1.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf qty_entered
                                RemoveHandler CType(panelTransHandler.DetailView1.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf sku_name_entered

                            Catch ex As Exception

                            End Try
                            AddHandler CType(panelTransHandler.DetailView1.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf qty_entered

                        End If
                    Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                        ShowPanel(panelMenu)
                End Select



            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub qty_entered(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try

            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                    Select Case gCurrentScannerService

                        Case gSCANNER_SERVICES.LEER_SKU_DESPACHO_FISCAL
                            If CType(panelTransHandler.DetailView1.Items("txtQTY"), Resco.Controls.DetailView.ItemTextBox).Control.Focused Then
                                ProcessSKU()
                            End If
                        Case gSCANNER_SERVICES.LEER_SKU_AUDITORIA_REC_FISCAL
                            If CType(panelTransHandler.DetailView1.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.Focused Then

                                Dim xproc As New AuditClass

                                If pMethodAudit = "INPUT" Then
                                    xproc.ProcessTransInput()
                                Else
                                    xproc.ProcessTransScanning("")
                                End If


                            End If
                        Case gSCANNER_SERVICES.LEER_SKU_AUDITORIA_DESP_FISCAL
                            If CType(panelTransHandler.DetailView1.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.Focused Then

                                Dim xproc As New AuditClass

                                If pMethodAudit = "INPUT" Then
                                    xproc.ProcessTransInput()
                                Else
                                    xproc.ProcessTransScanning("")
                                End If
                            End If

                        Case Else


                            If Not ValidarIngresoRecepcion() Then
                                Return
                            End If

                            If CType(panelTransHandler.DetailView1.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.Focused Then
                                If Not IsNumeric(panelTransHandler.DetailView1.Items("txtCantidad").Text) Then
                                    CType(panelTransHandler.DetailView1.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).SetFocus()
                                Else
                                    Try
                                        'gCommercialAggrement = Mid(panelTransHandler.DetailView1.Items("cmbToT").Text, 1, (InStr(panelTransHandler.DetailView1.Items("cmbToT").Text, "-") - 1))

                                        'gCommercialAggrement = panelTransHandler.DetailView1.Items("cmbToT").Text
                                    Catch ex As Exception
                                        'gCommercialAggrement = ""
                                    End Try

                                    If gCurrentTransactionType <> gTRANS_TYPE.INICIALIZACION_GENERAL Then
                                        If gCommercialAggrement = "" Then
                                            Notify("Debe Seleccionar un acuerdo comercial", True)
                                            PopulateToTCmb()
                                        Else
                                            ProcessSKU()
                                        End If
                                    Else
                                        ProcessSKU()
                                    End If

                                End If
                            End If

                    End Select

                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    If gCurrentTransactionType = gTRANS_TYPE.DESPACHO_FISCAL And gCurrentTransactionType = gTRANS_TYPE.DESPACHO_GENERAL Then
                        If gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_DESPACHO_FISCAL Then
                            'gRegimen = "FISCAL"
                            gPoliza = gCurrentCodigoPoliza

                            ShowPanel(panelTransHandler)
                            LoadPage("poliza", gPanelTitle, False)
                            ReviewPoliza(gCurrentCodigoPoliza, gNumeroOrden, False, "")
                        Else
                            ShowPanel(panelMenu)
                        End If
                    End If
            End Select

        Catch ex As Exception
            'Notify("QtyEntered: " + ex.Message, True)

        End Try
    End Sub


    Function ValidarIngresoRecepcion() As Boolean
        If CType(panelTransHandler.DetailView1.Items("txtNumLote"), Resco.Controls.DetailView.ItemTextBox).Visible Then
            If String.IsNullOrEmpty(CType(panelTransHandler.DetailView1.Items("txtNumLote"), Resco.Controls.DetailView.ItemTextBox).Text) Then
                Notify("Ingrese el Lote", True)
                CType(panelTransHandler.DetailView1.Items("txtNumLote"), Resco.Controls.DetailView.ItemTextBox).SetFocus()
                Return False
            End If
        End If
        If CType(panelTransHandler.DetailView1.Items("UiTextoVinRecepcion"), Resco.Controls.DetailView.ItemTextBox).Visible Then
            Dim vin As String = ""
            vin = CType(panelTransHandler.DetailView1.Items("UiTextoVinRecepcion"), Resco.Controls.DetailView.ItemTextBox).Text

            If String.IsNullOrEmpty(CType(panelTransHandler.DetailView1.Items("UiTextoVinRecepcion"), Resco.Controls.DetailView.ItemTextBox).Text) Then
                Notify("Ingrese el Vin", True)
                CType(panelTransHandler.DetailView1.Items("UiTextoVinRecepcion"), Resco.Controls.DetailView.ItemTextBox).SetFocus()
                Return False
            End If
        End If
        Return True
    End Function

    Class DespachoFiscal
        Sub ProcessTrans()
            ProcessSKU()
        End Sub
    End Class
    Class AuditClass
        Sub ProcessTransInput()
            Try

                Dim xserv As New WMS_Trans.WMS_Trans
                Dim pResult As String = ""
                Dim pCurrentAuditID As Integer = CInt(panelTransHandler.DetailView1.Items("Header1").Tag)
                Dim pBarCode As String = panelTransHandler.DetailView1.Items("txtScannedSKU").Text
                Dim pBatch As String = panelTransHandler.DetailView1.Items("txtNumLote").Text
                Dim xdate As Date = CType(panelTransHandler.DetailView1.Items("dtFechaExpiracion"), Resco.Controls.DetailView.ItemDateTime).DateTime

                Dim pQTY As Integer = 0
                pQTY = CInt(panelTransHandler.DetailView1.Items("txtCantidad").Text)

                If xserv.AuditCount(pCurrentAuditID, "INPUT", gPoliza, pBarCode, pQTY, "", GlobalUserID, gPanelOption, pBatch, xdate, pResult, GlobalEnviroment) Then
                    panelTransHandler.DetailView1.Items("txtScannedSKU").Text = "..."
                    panelTransHandler.DetailView1.Items("txtScannedSKU").Label = "Scan SKU"
                    panelTransHandler.DetailView1.Items("lblSKUName").Text = "..."
                    panelTransHandler.DetailView1.Items("txtCantidad").Text = ""
                Else
                    panelTransHandler.DetailView1.Items("lblSKUName").ErrorMessage = pResult
                    Notify(pResult, True)
                End If

            Catch ex As Exception
                Notify(ex.Message, True)

            End Try
        End Sub
        Sub ProcessTransScanning(ByVal pSerialID As String)
            ProcessSKU("SCANNING", pSerialID)
        End Sub
    End Class
    Sub ProcessSKU(Optional ByVal pMethod As String = "INPUT", Optional ByVal pSERIAL_ID As String = "")
        Try

            Select Case gCurrentScannerService
                Case gSCANNER_SERVICES.LEER_SERIE_AUDITORIA_REC_FISCAL
                    Dim xserv As New WMS_Trans.WMS_Trans
                    Dim pResult As String = ""
                    Dim pCurrentAuditID As Integer = CInt(panelTransHandler.DetailView1.Items("Header1").Tag)
                    Dim pBarCode As String = panelTransHandler.DetailView1.Items("txtScannedSKU").Text

                    If xserv.AuditCount(pCurrentAuditID, pMethod, gPoliza, pBarCode, 0, pSERIAL_ID, GlobalUserID, gPanelOption, "", Date.Now, pResult, GlobalEnviroment) Then
                        panelTransHandler.DetailView1.Items("txtScannedSKU").Text = "..."
                        panelTransHandler.DetailView1.Items("txtScannedSKU").Label = "Scan SKU"
                        panelTransHandler.DetailView1.Items("lblSKUName").Text = "..."
                        panelTransHandler.DetailView1.Items("txtSerie").Text = ""
                        panelTransHandler.DetailView1.Items("txtSerie").ErrorMessage = Nothing
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_AUDITORIA_REC_FISCAL
                    Else
                        panelTransHandler.DetailView1.Items("txtSerie").ErrorMessage = pResult
                        Notify(pResult, True)
                    End If
                Case gSCANNER_SERVICES.LEER_SERIE_AUDITORIA_DESP_FISCAL
                    Dim xserv As New WMS_Trans.WMS_Trans
                    Dim pResult As String = ""
                    Dim pCurrentAuditID As Integer = CInt(panelTransHandler.DetailView1.Items("Header1").Tag)
                    Dim pBarCode As String = panelTransHandler.DetailView1.Items("txtScannedSKU").Text

                    If xserv.AuditCount(pCurrentAuditID, pMethod, gPoliza, pBarCode, 0, pSERIAL_ID, GlobalUserID, gPanelOption, "", Date.Now, pResult, GlobalEnviroment) Then
                        panelTransHandler.DetailView1.Items("txtScannedSKU").Text = "..."
                        panelTransHandler.DetailView1.Items("txtScannedSKU").Label = "Scan SKU"
                        panelTransHandler.DetailView1.Items("lblSKUName").Text = "..."
                        panelTransHandler.DetailView1.Items("txtSerie").Text = ""
                        panelTransHandler.DetailView1.Items("txtSerie").ErrorMessage = Nothing
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_AUDITORIA_DESP_FISCAL
                    Else
                        panelTransHandler.DetailView1.Items("txtSerie").ErrorMessage = pResult
                        Notify(pResult, True)
                    End If

                Case gSCANNER_SERVICES.LEER_SKU_DESPACHO_FISCAL
                    Dim xserv As New WMS_Trans.WMS_Trans
                    Dim pResult As String = ""

                    Try
                        gCurrentQtyToAlloc = CDbl(panelTransHandler.DetailView1.Items("txtQTY").Text)
                    Catch ex As Exception
                        Notify("ERROR,gCurrentQtyToAlloc:" & ex.Message, True)
                        Exit Sub
                    End Try

                    Try
                        gSourceLocation = panelTransHandler.DetailView1.Items("UbicacionOrigen").Text
                    Catch ex As Exception
                        Notify("ERROR,gSourceLocation:" & ex.Message, True)
                        Exit Sub
                    End Try

                    If (gCurrentQtyToAlloc <= CDbl(panelTransHandler.DetailView1.Items("txtQTY").Tag)) Then

                        Dim tipoUbicaion As String = ""
                        Dim mt2 As Decimal = 0
                        If panelTransHandler.DetailView1.Items("txtMt2").Visible Then
                            If IsNumeric(panelTransHandler.DetailView1.Items("txtMt2").Text) Then
                                If Decimal.Parse(panelTransHandler.DetailView1.Items("txtMt2").Text) > Decimal.Parse(panelTransHandler.DetailView1.Items("txtMt2").Tag) Then
                                    Notify(String.Format("Metros no puede sobrepasar a {0}", panelTransHandler.DetailView1.Items("txtMt2").Tag), True)
                                    Exit Sub
                                Else
                                    tipoUbicaion = "PISO"
                                    mt2 = Decimal.Parse(panelTransHandler.DetailView1.Items("txtMt2").Text)
                                End If
                            Else
                                Notify("Metros Cuadrados es campo numerico", True)
                                Exit Sub
                            End If
                        End If
                        'cambio
                        If xserv.RegisterTrans("0", GlobalUserID, gCurrentTransName, "PICKING " + IIf(gCurrentTransactionType = gTRANS_TYPE.DESPACHO_FISCAL, "DESPACHO FISCAL", "TRASLADO GENERAL"), Replace(panelTransHandler.DetailView1.Items("CodigoBarras").Tag, " ", ""), gCurrentSKUPicking, gCurrentLicenseID, 0, gSourceLocation, "0", gClientOwner, gCurrentQtyToAlloc, "N/A", "N/A", gCurrentTransName, gCurrentCodigoPoliza, gCurrentLicenseID, "N/A", gCurrentWavePicking, gCurrentSerialNumber, 0, tipoUbicaion, mt2, "", gTaskId, "", "", Nothing, pResult, GlobalEnviroment) Then
                            ''gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                            ''gCurrentTransactionType = gTRANS_TYPE.NONE


                            'If gCurrentTransactionType = gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL Then
                            '    gRegimen = "FISCAL"
                            '    gPoliza = gCurrentCodigoPoliza
                            '    gSourceLicense = gCurrentLicenseID

                            '    LoadPage("poliza", gPanelTitle, False)
                            '    ReviewPoliza(gCurrentCodigoPoliza, False, pResult)
                            'Else
                            '    ShowPanel(panelMyPicking)
                            '    LoadPage("my_waves_tree", gPanelTitle, False)
                            'End If

                            panelTypeChange._typeTrans = "DESPACHO_FISCAL"

                            If gCurrentTransactionType = gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL Then
                                gRegimen = "FISCAL"
                                gPoliza = gCurrentCodigoPoliza
                                gSourceLicense = gCurrentLicenseID
                                panelTypeChange._typeTrans = "DESPACHO_TRASLADO_FISCAL_A_GENERAL"
                            End If

                            Dim result As String = ""
                            Dim serv As New WMS_InfoTrans.WMS_InfoTrans
                            Dim dt As DataSet
                            dt = serv.GET_TYPE_CHARGE_MOVIL(gCurrentLicenseID, panelTypeChange._typeTrans, result, GlobalEnviroment)
                            If pResult = "OK" And Not dt Is Nothing Then
                                panelTypeChange._licenseId = gCurrentLicenseID
                                panelTypeChange.AdvancedList_Default.DataSource = dt.Tables(0)
                                'panelTypeChange._typeTrans = "DESPACHO_FISCAL"
                                panelTypeChange.AdvancedList_Default.Templates("RowTemplate_Header").CellTemplates(0).CellSource.ConstantData = "Tipos de Cobro/Licencia " + gCurrentLicenseID.ToString()
                                ShowPanel(panelTypeChange)
                            Else
                                If gCurrentTransactionType = gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL Then
                                    LoadPage("poliza", gPanelTitle, False)
                                    ReviewPoliza(gCurrentCodigoPoliza, "", False, pResult)
                                Else

                                    ShowPanelMyPicking()
                                    'ShowPanel(panelMyPicking)
                                    LoadPage("my_waves_tree", gPanelTitle, False)
                                End If

                                'ShowPanel(panelMyPicking)
                                'LoadPage("my_waves_tree", gPanelTitle, False)
                            End If

                        Else
                            Notify("ProcessSKU: (" + GlobalEnviroment + ")" + pResult, True)
                            'LoadPage("my_waves_tree", "Despacho Fiscal", False)
                        End If
                    Else
                        'Notify("Cantidad [" + panelTransHandler.DetailView1.Items("txtQTY").Text + "] excede la tarea de picking [" + panelTransHandler.DetailView1.Items("txtQTY").Tag + "]", True)
                        Notify("Cantidad excede la cantidad en tarea de picking", True)
                        'panelTransHandler.DetailView1.Items("txtQTY").Text = panelTransHandler.DetailView1.Items("txtQTY").Tag
                        'panelTransHandler.DetailView1.Items("txtQTY").SetFocus()
                    End If

                Case gSCANNER_SERVICES.LEER_SKU_DESPACHO_ALMGEN

                    Dim xserbInfoTrans As New WMS_InfoTrans.WMS_InfoTrans
                    Dim pResult As String = String.Empty
                    Dim dResult As DataTable
                    dResult = xserbInfoTrans.ValidateTaskStatus(GlobalUserID, 0, 0, gCurrentWavePicking, gMaterialId, "TAREA_PICKING", GlobalEnviroment, pResult)
                    If pResult = "OK" AndAlso Not dResult.Rows(0)(1).ToString.Contains("cancelada") Then
                        Dim xserv As New WMS_Trans.WMS_Trans
                        pResult = ""
                        gCurrentQtyToAlloc = CDbl(panelTransHandler.DetailView1.Items("txtQTY").Text)
                        gSourceLocation = panelTransHandler.DetailView1.Items("UbicacionOrigen").Text

                        If gCurrentQtyToAlloc <= 0 Then
                            Notify("La cantidad tiene que ser mayor a cero.", True)
                            Exit Sub
                        End If

                        If (gCurrentQtyToAlloc <= CDbl(panelTransHandler.DetailView1.Items("txtQTY").Tag)) Then
                            Dim tipoUbicaion As String = ""
                            Dim mt2 As Decimal = 0
                            If panelTransHandler.DetailView1.Items("txtMt2").Visible Then
                                If IsNumeric(panelTransHandler.DetailView1.Items("txtMt2").Text) Then
                                    If Decimal.Parse(panelTransHandler.DetailView1.Items("txtMt2").Text) > Decimal.Parse(panelTransHandler.DetailView1.Items("txtMt2").Tag) Then
                                        Notify(String.Format("Metros no puede sobrepasar a {0}", panelTransHandler.DetailView1.Items("txtMt2").Tag), True)
                                        Exit Sub
                                    Else
                                        tipoUbicaion = "PISO"
                                        mt2 = Decimal.Parse(panelTransHandler.DetailView1.Items("txtMt2").Text)
                                    End If
                                Else
                                    Notify("Metros Cuadrados es campo numerico", True)
                                    Exit Sub
                                End If
                            End If

                            If gCurrentTransactionType = gTRANS_TYPE.REUBICACION_POR_REABASTECIMIENTO Then
                                'ojo'
                                Dim pLastLicense As Integer = 0
                                If gTaskSubType.Equals("REUBICACION_BUFFER") Or gTaskSubType.Equals("ENTREGA_NO_INMEDIATA") Then
                                    Dim xservPolizas As New WMS_Polizas.WMS_Polizas
                                    If xservPolizas.CrearLicencia(gCurrentCodigoPolizaSource, GlobalUserID, pLastLicense, gClientOwner, gRegimen, If(gTaskId Is Nothing OrElse gTaskId = "", -1, CInt(gTaskId)), pResult, GlobalEnviroment) Then
                                        If pResult.Contains("Tarea ya fue asinada a otro operador") Then
                                            Exit Sub
                                        End If
                                        panelRecFiscalStep2.UiBotonImprimirLicencia.Visible = True
                                    End If
                                End If

                                gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_PARA_REUBICACION_POR_REABASTECIMIENTO
                                panelRecFiscalStep2.lblTitle.Text = "Ubicación: " & gLocationSpotTarget & "/ Licencia: " & pLastLicense
                                panelRecFiscalStep2.lblTitle.Tag = pLastLicense
                                panelRecFiscalStep2.LBL_LOCATION.Text = "Scan Ubi.(...):"
                                panelRecFiscalStep2.LBL_LOCATION.Tag = gLocationSpotTarget
                                panelRecFiscalStep2.btnStatus.Visible = False
                                panelRecFiscalStep2.UIVistaUbicacionesSugeridas.Visible = False
                                panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = False
                                ShowPanel(panelRecFiscalStep2)
                            Else
                                If xserv.RegisterTrans("0", GlobalUserID, gCurrentTransName, "PICKING DESPACHO ALM.GENERAL", Replace(panelTransHandler.DetailView1.Items("CodigoBarras").Tag, " ", ""), gCurrentSKUPicking, gCurrentLicenseID, 0, gSourceLocation, "0", gClientOwner, gCurrentQtyToAlloc, "N/A", "N/A", gCurrentTransName, gCurrentCodigoPoliza, gCurrentLicenseID, "N/A", gCurrentWavePicking, gCurrentSerialNumber, 0, tipoUbicaion, mt2, "", gTaskId, "", "", Nothing, pResult, GlobalEnviroment) Then

                                    Dim barcode = panelTransHandler.DetailView1.Items("CodigoBarras").Tag
                                    Dim license = panelTransHandler.DetailView1.Items("LicenciaOrigen").Tag
                                    Dim result As String = String.Empty
                                    If Not xserv.UpdatePickingLabel(gCurrentLabel, gClientOwner, license, barcode, gCurrentQtyToAlloc, gCurrentCodigoPoliza, gSourceLocation, gLocationSpotTarget, GlobalUserID, gCurrentSerialNumber, gCurrentWavePicking, result, GlobalEnviroment) Then
                                        Notify(result, True)
                                    End If

                                    panelTransHandler.DetailView1.Items("txtQTY").Enabled = True
                                    result = ""
                                    Dim serv As New WMS_InfoTrans.WMS_InfoTrans
                                    Dim dt As DataSet
                                    dt = serv.GET_TYPE_CHARGE_MOVIL(gCurrentLicenseID, "DESPACHO_GENERAL", result, GlobalEnviroment)
                                    If pResult = "OK" And Not dt Is Nothing Then
                                        panelTypeChange._licenseId = gCurrentLicenseID
                                        panelTypeChange.AdvancedList_Default.DataSource = dt.Tables(0)
                                        panelTypeChange._typeTrans = "DESPACHO_GENERAL"
                                        panelTypeChange.AdvancedList_Default.Templates("RowTemplate_Header").CellTemplates(0).CellSource.ConstantData = "Tipos de Cobro/Licencia " + gCurrentLicenseID.ToString()
                                        ShowPanel(panelTypeChange)
                                    Else
                                        UsuarioFinalizaoDetalleDePicking()
                                    End If
                                Else
                                    Notify("ProcessSKU: (" + GlobalEnviroment + ")" + pResult, True)
                                    LoadPage("my_waves_tree", "Despacho Fiscal", False)
                                End If
                            End If
                        Else
                            Notify("Cantidad [" + panelTransHandler.DetailView1.Items("txtQTY").Text + "] excede la tarea de picking [" + panelTransHandler.DetailView1.Items("txtQTY").Tag.ToString + "]", True)
                            panelTransHandler.DetailView1.Items("txtQTY").Text = panelTransHandler.DetailView1.Items("txtQTY").Tag
                            panelTransHandler.DetailView1.Items("txtQTY").SetFocus()
                        End If
                    Else
                        Notify(IIf(pResult = "OK", dResult.Rows(0)(1).ToString(), pResult), True)
                    End If



                Case Else
                    If panelTransHandler.DetailView1.Items("txtScannedSKU").Tag = "1" Then
                        'call logistics info
                        panelRecFiscalLogisInfo.lblTitle.Text = panelTransHandler.DetailView1.Items("txtScannedSKU").Text + " - " + panelTransHandler.DetailView1.Items("lblSKUName").Text
                        panelRecFiscalLogisInfo.txtVolumen.SelectAll()
                        panelRecFiscalLogisInfo.txtVolumen.Focus()

                        ShowPanel(panelRecFiscalLogisInfo)
                    Else
                        'create trans
                        Try
                            If gIsNewSKU Then
                                gCurrentScannerService = gSCANNER_SERVICES.LEER_NUEVO_SKU

                                CloseScanner()
                                StartAcquisition()

                                panelTakePicture.lblScanPrompt.Text = "NUEVO SKU: "
                                panelTakePicture.lblScannedPolicy.Text = panelTransHandler.DetailView1.Items("txtScannedSKU").Text
                                panelTakePicture.lblScanPrompt.Visible = True
                                panelTakePicture.btnEgreso.Visible = False
                                panelTakePicture.btnEgreso.Visible = False

                                ShowPanel(panelTakePicture)
                            Else
                                gHasLogisticInfo = False

                                SaveSKULicense()
                            End If

                        Catch ex As Exception
                            gPendingSKU = True
                        End Try
                    End If
            End Select

        Catch ex As Exception
            Notify("ProcessSKU: " + ex.Message, True)

        End Try
    End Sub

    Sub LabelScanned(ByVal etiquetaEscaneada As String, ByRef pResult As String)

        Select Case gCurrentScannerService
            Case gSCANNER_SERVICES.LEER_ETIQUETA_REUBICACION
                Dim xserv1 As New WMS_InfoTrans.WMS_InfoTrans
                Dim etiquetaTabla As DataTable
                etiquetaTabla = xserv1.ValidarEtiqueta(etiquetaEscaneada, GlobalEnviroment, pResult)
                If pResult = "OK" Then
                    If etiquetaTabla.Rows(0)("LABEL_STATUS") = "DELIVERED" Then
                        Notify("El despacho ya a sido entregado", True)
                        Return
                    End If
                    panelTransHandler.DetailView1.Items("txtLicencia").Text = etiquetaEscaneada
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_REALLOC
                    panelTransHandler.DetailView1.Items("txtUbicacion").Text = ""
                    panelTransHandler.DetailView1.Items("txtUbicacion").ErrorMessage = Nothing
                    CType(panelTransHandler.DetailView1.Items("txtUbicacion"), Resco.Controls.DetailView.ItemTextBox).SetFocus()
                    Cursor.Current = Cursors.Default
                Else
                    Notify(pResult, True)
                End If
        End Select


    End Sub
    Sub LicensedScanned(ByVal ScanData As String, ByRef pResult As String)
        Try
            Dim xset As DataSet
            Dim xserv As New WMS_Materials.WMS_Materials
            Dim pBarcode As String = ""
            Dim pLicenseScanned As String = ""
            If InStr(ScanData.ToUpper, "-") <= 0 Then
                Cursor.Current = Cursors.Default
                pResult = "ERROR, Licencia con formato invalido. Verifique."
                Notify(pResult, True)

                If gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_DESPACHO_FISCAL Then
                    Cursor.Current = Cursors.Default
                    panelTransHandler.DetailView1.Items("LicenciaOrigen").ErrorMessage = pResult
                End If
                Exit Sub
            End If

            pLicenseScanned = Mid(ScanData.ToUpper, 1, InStr(ScanData.ToUpper, "-") - 1)

            Select Case gCurrentScannerService
                Case gSCANNER_SERVICES.LEER_LIC_TRASLADO_ALMGEN
                    'validar si existe licencia y si esta asociada a la poliza origen
                    If panelTransHandler.DetailView1.Items("txtLicencia").Text = pLicenseScanned Then
                        panelTransHandler.DetailView1.Items("txtLicencia").Text = pLicenseScanned
                        panelTransHandler.DetailView1.Items("txtLicencia").TextForeColor = Color.Gold
                        panelTransHandler.DetailView1.Items("txtLicencia").ErrorMessage = Nothing
                        Cursor.Current = Cursors.Default
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_TRASLADO_ALMGEN
                    Else
                        Dim xserv1 As New WMS_InfoTrans.WMS_InfoTrans

                        xset = xserv1.IsContainedOnWave(GlobalUserID, gCurrentLocationPicking, gCurrentWavePicking, gCurrentSKUPicking, CInt(pLicenseScanned), gCurrentCodigoPolizaSource, "LICENCIA", pResult, GlobalEnviroment)
                        Cursor.Current = Cursors.Default
                        If pResult = "OK" Then
                            panelTransHandler.DetailView1.Items("txtLicencia").TextForeColor = Color.Gold
                            panelTransHandler.DetailView1.Items("txtLicencia").ErrorMessage = Nothing
                            'asignar maximo a sacar en esa ubicacion / licencia

                            Cursor.Current = Cursors.Default
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_TRASLADO_ALMGEN
                            Exit Sub
                        Else
                            pResult = " Licencia " & pLicenseScanned & " es invalida"
                            panelTransHandler.DetailView1.Items("txtLicencia").Control.ForeColor = Color.White
                            panelTransHandler.DetailView1.Items("txtLicencia").ErrorMessage = pResult

                            Cursor.Current = Cursors.Default
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_LIC_TRASLADO_ALMGEN
                            Exit Sub
                        End If


                    End If

                Case gSCANNER_SERVICES.LEER_LICENCIA_REALLOC


                    Dim xservInventory As New WMS_InfoInventory.WMS_InfoInventory
                    pResult = String.Empty
                    xservInventory.ValidateLicenseLocationForRealloc(CInt(pLicenseScanned), pResult, GlobalEnviroment)
                    If pResult <> "OK" Then
                        Notify(pResult, True)
                        Return
                    End If

                    xservInventory.ValidateIfStatusOfLicenseAllowsRealloc(CInt(pLicenseScanned), Nothing, GlobalEnviroment, pResult)
                    If pResult <> "OK" Then
                        Notify(pResult, True)
                        Return
                    End If


                    panelTransHandler.DetailView1.Items("txtLicencia").Text = pLicenseScanned
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_REALLOC
                    panelTransHandler.DetailView1.Items("txtUbicacion").Text = ""
                    panelTransHandler.DetailView1.Items("txtUbicacion").ErrorMessage = Nothing

                    CType(panelTransHandler.DetailView1.Items("txtUbicacion"), Resco.Controls.DetailView.ItemTextBox).SetFocus()
                    gCurrentLicenseID = CInt(pLicenseScanned)
                    Cursor.Current = Cursors.Default

                Case gSCANNER_SERVICES.LEER_LICENCIA_DESPACHO_FISCAL
                    'buscar ubicacion leida dentro de las posibles ubicaciones que permite el wavepicking
                    Cursor.Current = Cursors.WaitCursor


                    If ScanData.ToUpper = panelTransHandler.DetailView1.Items("LicenciaOrigen").Tag Then

                        panelTransHandler.DetailView1.Items("LicenciaOrigen").Text = pLicenseScanned
                        Cursor.Current = Cursors.Default

                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_DESPACHO_FISCAL
                        panelTransHandler.DetailView1.Items("LicenciaOrigen").TextForeColor = Color.Gold
                        panelTransHandler.DetailView1.Items("LicenciaOrigen").ErrorMessage = Nothing

                    Else
                        Dim xserv1 As New WMS_InfoTrans.WMS_InfoTrans

                        panelTransHandler.DetailView1.Items("LicenciaOrigen").Text = pLicenseScanned

                        xset = xserv1.IsContainedOnWave(GlobalUserID, gCurrentLocationPicking, gCurrentWavePicking, gCurrentSKUPicking, CInt(pLicenseScanned), gCurrentCodigoPolizaSource, "LICENCIA", pResult, GlobalEnviroment)
                        Cursor.Current = Cursors.Default

                        If pResult = "OK" Then
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_DESPACHO_FISCAL
                            panelTransHandler.DetailView1.Items("LicenciaOrigen").TextForeColor = Color.Gold
                            panelTransHandler.DetailView1.Items("LicenciaOrigen").ErrorMessage = Nothing
                            panelTransHandler.DetailView1.Items("LicenciaOrigen").Tag = pLicenseScanned
                            gCurrentSerialNumber = xset.Tables(0).Rows(0)("SERIAL_NUMBER")
                            gCurrentLicenseID = pLicenseScanned
                        Else
                            Cursor.Current = Cursors.Default
                            panelTransHandler.DetailView1.Items("LicenciaOrigen").TextForeColor = Color.White
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_DESPACHO_FISCAL
                            panelTransHandler.DetailView1.Items("LicenciaOrigen").ErrorMessage = pResult
                            'gCurrentSerialNumber = 0
                            Notify(pResult, True)
                            Exit Sub
                        End If

                    End If

                Case gSCANNER_SERVICES.LEER_LICENCIA_DESPACHO_ALMGEN
                    'buscar ubicacion leida dentro de las posibles ubicaciones que permite el wavepicking
                    Cursor.Current = Cursors.WaitCursor

                    If pLicenseScanned.ToUpper = panelTransHandler.DetailView1.Items("LicenciaOrigen").Tag Then

                        panelTransHandler.DetailView1.Items("LicenciaOrigen").Text = pLicenseScanned
                        Cursor.Current = Cursors.Default

                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_DESPACHO_ALMGEN
                        panelTransHandler.DetailView1.Items("LicenciaOrigen").TextForeColor = Color.Gold
                        panelTransHandler.DetailView1.Items("LicenciaOrigen").ErrorMessage = Nothing

                    ElseIf Not MaterialHandleBatch(gBatchRequested) AndAlso Not MobilityScm.Modelo.Tipos.Enums.GetStringValue(MobilityScm.Modelo.Tipos.SubTipoTarea.InventarioPreparado) = gTaskSubType Then
                        Dim serviceTrans As New WMS_Trans.WMS_Trans
                        Dim result As String = String.Empty

                        Dim dt As DataTable = serviceTrans.ValidateIfPickingLicenseIsAvailable(gCurrentWavePicking, gCurrentLocationPicking, gMaterialIdPicking, pLicenseScanned, GlobalUserID, result, GlobalEnviroment)

                        If String.IsNullOrEmpty(result) Then
                            If dt.Rows.Count > 0 Then
                                panelTransHandler.DetailView1.Items("LicenciaOrigen").Label = "Scan Licencia()"
                                gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_DESPACHO_ALMGEN
                                panelTransHandler.DetailView1.Items("LicenciaOrigen").Text = pLicenseScanned
                                panelTransHandler.DetailView1.Items("LicenciaOrigen").TextForeColor = Color.Gold
                                panelTransHandler.DetailView1.Items("LicenciaOrigen").ErrorMessage = Nothing
                                panelTransHandler.DetailView1.Items("LicenciaOrigen").Tag = pLicenseScanned
                                gCurrentSerialNumber = 0
                                gCurrentLicenseID = pLicenseScanned
                                Cursor.Current = Cursors.Default
                            Else
                                Cursor.Current = Cursors.Default
                                panelTransHandler.DetailView1.Items("LicenciaOrigen").TextForeColor = Color.White
                                gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_DESPACHO_ALMGEN
                                panelTransHandler.DetailView1.Items("LicenciaOrigen").ErrorMessage = pResult
                                Notify("No hay inventario disponible en esta licencia", True)
                                Exit Sub
                            End If
                        Else
                            Cursor.Current = Cursors.Default
                            panelTransHandler.DetailView1.Items("LicenciaOrigen").TextForeColor = Color.White
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_DESPACHO_ALMGEN
                            panelTransHandler.DetailView1.Items("LicenciaOrigen").ErrorMessage = pResult
                            Notify(result, True)
                            Exit Sub
                        End If

                    Else
                        Dim xserv1 As New WMS_InfoTrans.WMS_InfoTrans

                        panelTransHandler.DetailView1.Items("LicenciaOrigen").Text = pLicenseScanned
                        'gCurrentSKUPicking
                        xset = xserv1.IsContainedOnWave(GlobalUserID, gCurrentLocationPicking, gCurrentWavePicking, gMaterialIdPicking, CInt(pLicenseScanned), gCurrentCodigoPolizaSource, "LICENCIA", pResult, GlobalEnviroment)
                        Cursor.Current = Cursors.Default

                        If pResult = "OK" Then
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_DESPACHO_ALMGEN
                            panelTransHandler.DetailView1.Items("LicenciaOrigen").TextForeColor = Color.Gold
                            panelTransHandler.DetailView1.Items("LicenciaOrigen").ErrorMessage = Nothing
                            panelTransHandler.DetailView1.Items("LicenciaOrigen").Tag = pLicenseScanned
                            gCurrentSerialNumber = xset.Tables(0).Rows(0)("SERIAL_NUMBER")
                            gCurrentLicenseID = pLicenseScanned
                            panelTransHandler.DetailView1.Items("txtQTY").Text = xset.Tables(0).Rows(0)("QUANTITY_PENDING").ToString
                            panelTransHandler.DetailView1.Items("txtQTY").Tag = xset.Tables(0).Rows(0)("QUANTITY_PENDING").ToString

                        Else
                            Cursor.Current = Cursors.Default
                            panelTransHandler.DetailView1.Items("LicenciaOrigen").TextForeColor = Color.White
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_DESPACHO_ALMGEN
                            panelTransHandler.DetailView1.Items("LicenciaOrigen").ErrorMessage = pResult
                            'gCurrentSerialNumber = 0
                            Notify(pResult, True)
                            Exit Sub
                        End If

                    End If

                Case Else
                    Cursor.Current = Cursors.Default

            End Select


        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify("LicensedScanned: " + ex.Message, True)


        End Try
    End Sub
    Private Sub qty_entered_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ProcessSKU()
        Catch ex As Exception

        End Try
    End Sub

    Sub SkuScanned(ByVal skuScanData As String, ByRef pResult As String)
        Try
            Dim xset As DataSet
            Dim xserv As New WMS_Materials.WMS_Materials
            Dim xservInfo As New WMS_InfoInventory.WMS_InfoInventory

            Dim pBarcode As String = ""

            Select Case gCurrentScannerService

                Case gSCANNER_SERVICES.LEER_SKU_AUDITORIA_DESP_FISCAL
                    Cursor.Current = Cursors.WaitCursor
                    pBarcode = skuScanData.Replace(" ", "")

                    xset = xserv.SearchByBarCode(pBarcode, gClientOwner, pResult, GlobalEnviroment)
                    panelTransHandler.DetailView1.Items("txtScannedSKU").Text = pBarcode


                    If pResult = "OK" Then
                        Dim xservInfoTrans As New WMS_InfoTrans.WMS_InfoTrans
                        Dim xsetTr As DataSet
                        pResult = ""
                        xsetTr = xservInfoTrans.SearchSkuAuditoriaDesp(pBarcode, gPoliza, pResult, GlobalEnviroment)
                        If pResult = "OK" Then
                            gPendingSKU = True
                            gIsNewSKU = False
                            With panelTransHandler.DetailView1

                                .Items("lblSKUName").Text = xset.Tables(0).Rows(0)("SHORT_NAME").ToString
                                .Items("lblSKUName").Visible = True
                                .Items("lblSKUName").Tag = "0"
                                .Items("txtCantidad").Visible = True
                                CType(.Items("lblSKUName"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = True

                                If gCurrentPage = "sku_license_audit_scanning" Then 'Or gCurrentPage = "info_audit_query" Then
                                    panelTransHandler.DetailView1.Items("txtSerie").Visible = True
                                    panelTransHandler.DetailView1.Items("txtSerie").Text = ""
                                    CType(.Items("txtSerie"), Resco.Controls.DetailView.ItemTextBox).SetFocus()
                                    gCurrentScannerService = gSCANNER_SERVICES.LEER_SERIE_AUDITORIA_DESP_FISCAL

                                    RemoveHandler CType(.Items("txtSerie"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf serie_entered
                                    AddHandler CType(.Items("txtSerie"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf serie_entered

                                Else
                                    CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = IIf(.Items("txtCantidad").Tag = "1", True, False)

                                    .Items("txtCantidad").Enabled = True
                                    .Items("txtCantidad").Text = "1"
                                    .Items("txtCantidad").Tag = "0"

                                    CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).SetFocus()
                                    Try
                                        RemoveHandler CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf qty_entered
                                    Catch ex As Exception

                                    End Try
                                    AddHandler CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf qty_entered
                                    If xset.Tables(0).Rows(0)("BATCH_REQUESTED") = 1 Then
                                        .Items("dtFechaExpiracion").Visible = True
                                        .Items("txtNumLote").Visible = True
                                        .Items("txtNumLote").SetFocus()
                                    Else
                                        .Items("dtFechaExpiracion").Visible = False
                                        .Items("txtNumLote").Visible = False
                                        .Items("txtNumLote").Text = ""
                                        .Items("txtCantidad").SetFocus()
                                    End If

                                    If xset.Tables(0).Rows(0)("IS_CAR") = 1 Then
                                        .Items("UiTextoVinRecepcion").Visible = True
                                        .Items("UiTextoVinRecepcion").Text = ""
                                        .Items("UiTextoVinRecepcion").SetFocus()
                                    Else
                                        .Items("UiTextoVinRecepcion").Visible = False
                                        .Items("UiTextoVinRecepcion").SetFocus()
                                        .Items("UiTextoVinRecepcion").Text = ""
                                        .Items("txtCantidad").SetFocus()
                                    End If
                                End If
                            End With
                        Else
                            Notify(pResult, True)
                            gPendingSKU = False
                            gIsNewSKU = True
                        End If
                    Else
                        With panelTransHandler.DetailView1
                            If .Items("UiTextoVinRecepcion").Visible And gPendingSKU Then
                                .Items("UiTextoVinRecepcion").Text = pBarcode
                            Else
                                Notify(pBarcode + " SKU No existe", True)
                                gPendingSKU = False
                                gIsNewSKU = True
                            End If
                        End With
                    End If
                    Cursor.Current = Cursors.Default
                Case gSCANNER_SERVICES.LEER_SKU_AUDITORIA_REC_FISCAL
                    Cursor.Current = Cursors.WaitCursor
                    pBarcode = skuScanData.Replace(" ", "")

                    xset = xserv.SearchByBarCode(pBarcode, gClientOwner, pResult, GlobalEnviroment)
                    panelTransHandler.DetailView1.Items("txtScannedSKU").Text = pBarcode

                    If pResult = "OK" Then
                        gPendingSKU = True
                        gIsNewSKU = False
                        With panelTransHandler.DetailView1

                            .Items("lblSKUName").Text = xset.Tables(0).Rows(0)("SHORT_NAME").ToString
                            .Items("lblSKUName").Visible = True
                            .Items("lblSKUName").Tag = "0"

                            CType(.Items("lblSKUName"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = True

                            If gCurrentPage = "sku_license_audit_scanning" Then 'Or gCurrentPage = "info_audit_query" Then
                                panelTransHandler.DetailView1.Items("txtSerie").Visible = True
                                panelTransHandler.DetailView1.Items("txtSerie").Text = ""
                                CType(.Items("txtSerie"), Resco.Controls.DetailView.ItemTextBox).SetFocus()
                                gCurrentScannerService = gSCANNER_SERVICES.LEER_SERIE_AUDITORIA_REC_FISCAL
                            Else
                                CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = IIf(.Items("txtCantidad").Tag = "1", True, False)

                                .Items("txtCantidad").Enabled = True
                                .Items("txtCantidad").Text = "1"
                                .Items("txtCantidad").Tag = "0"
                                .Items("txtCantidad").Visible = True
                                CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).SetFocus()
                                Try
                                    RemoveHandler CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf qty_entered
                                Catch ex As Exception

                                End Try
                                AddHandler CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf qty_entered

                                .Items("dtFechaExpiracion").Visible = False
                                .Items("txtNumLote").Visible = False
                                .Items("txtNumLote").Text = ""
                                .Items("txtCantidad").SetFocus()
                            End If

                        End With

                    Else
                        Notify(pBarcode + " SKU No existe", True)
                        gPendingSKU = False
                        gIsNewSKU = True

                    End If

                    Cursor.Current = Cursors.Default

                Case gSCANNER_SERVICES.LEER_SKU_EN_RECEPCION_FISCAL, gSCANNER_SERVICES.LEER_SKU_EN_INICIALIZACION
                    Cursor.Current = Cursors.WaitCursor
                    pBarcode = skuScanData.Replace(" ", "")

                    Dim dt As DataTable = xserv.ObtenerMaterialPorCodigoDeBarraYLicencia(pBarcode, gClientOwner, gLicenseID, gTaskId, pResult, GlobalEnviroment)

                    If pResult = "OK" Then
                        gNewClientOwner = dt.Rows(0)("CLIENT_OWNER").ToString()
                        panelTransHandler.DetailView1.Items("txtScannedSKU").Text = pBarcode
                        gPendingSKU = True
                        gIsNewSKU = False
                        With panelTransHandler.DetailView1

                            .Items("lblSKUName").Text = dt.Rows(0)("SHORT_NAME").ToString
                            .Items("lblSKUName").Visible = True
                            .Items("lblSKUName").Tag = "0"

                            CType(.Items("lblSKUName"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = True

                            If gCurrentPage = "sku_license_audit_scanning" Or gCurrentPage = "info_audit_query" Then
                                panelTransHandler.DetailView1.Items("txtSerie").Visible = True
                                panelTransHandler.DetailView1.Items("txtSerie").Text = ""
                                CType(.Items("txtSerie"), Resco.Controls.DetailView.ItemTextBox).SetFocus()
                                gCurrentScannerService = gSCANNER_SERVICES.LEER_SERIE_AUDITORIA_REC_FISCAL

                            Else
                                CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = IIf(.Items("txtCantidad").Tag = "1", True, False)

                                .Items("txtCantidad").Enabled = True
                                .Items("txtCantidad").Text = "1"
                                .Items("txtCantidad").Tag = "0"
                                .Items("txtCantidad").Visible = True
                                CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).SetFocus()
                                Try
                                    RemoveHandler CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf qty_entered
                                Catch ex As Exception

                                End Try
                                AddHandler CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf qty_entered
                            End If

                            .Items("dtFechaExpiracion").Visible = False
                            .Items("txtNumLote").Text = ""
                            .Items("txtNumLote").Visible = False
                            .Items("UiTextoVinRecepcion").Text = ""
                            .Items("UiTextoVinRecepcion").Visible = False
                            .Items("UiTextTone").Text = ""
                            .Items("UiTextTone").Visible = False
                            .Items("UiTextCaliber").Text = ""
                            .Items("UiTextCaliber").Visible = False

                            If dt.Rows(0)("SERIAL_NUMBER_REQUESTS") = 1 Then
                                .Items("txtCantidad").SetFocus()
                                gCurrentScannerService = gSCANNER_SERVICES.LEER_NUMERO_SERIE_RECEPCION
                                panelMaterialXSerialNumbers.CargarInformacion(dt.Rows(0)("MATERIAL_ID"), dt.Rows(0)("SHORT_NAME"), dt.Rows(0)("BATCH_REQUESTED") = 1)
                                ShowPanel(panelMaterialXSerialNumbers)
                            Else
                                .Items("txtCantidad").SetFocus()
                                If ApplyProperty(dt.Rows(0)("BATCH_REQUESTED")) Then
                                    Dim dateExpiration As Date = Now
                                    Dim webServiceSetting As New WMS_Settings.WMS_Settings
                                    Dim dtSetting As DataSet
                                    Dim resultValidated As String = ""
                                    dtSetting = webServiceSetting.GetParam_ByParamKey("SISTEMA", "RECEPCION", "AÑOS_A_AGREGAR_A_FECHA_DE_VENCIMIENTO_DE_LOTE", resultValidated, GlobalEnviroment)

                                    If resultValidated.ToUpper.Equals("OK") Then
                                        If ExistsGeneralParameter(dtSetting) Then
                                            dateExpiration = Date.Now.AddYears(dtSetting.Tables(0).Rows(0)("NUMERIC_VALUE"))
                                        End If
                                    End If

                                    .Items("dtFechaExpiracion").Visible = True
                                    .Items("dtFechaExpiracion").Value = dateExpiration
                                    .Items("txtNumLote").Visible = True
                                    .Items("txtNumLote").SetFocus()
                                End If

                                If ApplyProperty(dt.Rows(0)("HANDLE_TONE")) Then
                                    .Items("UiTextTone").Visible = True
                                    .Items("UiTextTone").SetFocus()
                                End If

                                If ApplyProperty(dt.Rows(0)("HANDLE_CALIBER")) Then
                                    .Items("UiTextCaliber").Visible = True
                                    .Items("UiTextCaliber").SetFocus()
                                End If

                                If ApplyProperty(dt.Rows(0)("IS_CAR")) Then
                                    .Items("UiTextoVinRecepcion").Visible = True
                                    .Items("UiTextoVinRecepcion").SetFocus()
                                End If
                                .Items("txtCantidad").Tag = ""

                            End If
                        End With
                    Else
                        With panelTransHandler.DetailView1
                            If .Items("UiTextoVinRecepcion").Visible And gPendingSKU Then
                                .Items("UiTextoVinRecepcion").Text = pBarcode
                            Else
                                pResult = pResult + " para cliente "
                                If gClientOwner <> gNewClientOwner Then
                                    pResult = pResult + gNewClientOwner
                                Else
                                    pResult = pResult + gClientOwner
                                End If

                                Notify(pResult, True)
                                gPendingSKU = False
                                gIsNewSKU = True
                            End If
                        End With
                    End If

                    Cursor.Current = Cursors.Default

                Case gSCANNER_SERVICES.LEER_SKU_DESPACHO_FISCAL
                    'buscar ubicacion leida dentro de las posibles ubicaciones que permite el wavepicking
                    Cursor.Current = Cursors.WaitCursor
                    pBarcode = skuScanData.Replace(" ", "")

                    Dim pLicenseScanned As Integer
                    pLicenseScanned = panelTransHandler.DetailView1.Items("LicenciaOrigen").Tag


                    Dim xserv1 As New WMS_InfoTrans.WMS_InfoTrans

                    xset = xserv1.IsContainedOnWave(GlobalUserID, gCurrentLocationPicking, gCurrentWavePicking, pBarcode, pLicenseScanned, gCurrentCodigoPolizaSource, "SKU", pResult, GlobalEnviroment)
                    Cursor.Current = Cursors.Default

                    If pResult = "OK" Then

                        panelTransHandler.DetailView1.Items("CodigoBarras").Label = "Scan SKU(" + pBarcode + ")"
                        panelTransHandler.DetailView1.Items("CodigoBarras").Tag = pBarcode

                        Cursor.Current = Cursors.Default

                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_DESPACHO_FISCAL
                        panelTransHandler.DetailView1.Items("CodigoBarras").TextForeColor = Color.Gold
                        panelTransHandler.DetailView1.Items("CodigoBarras").ErrorMessage = Nothing

                        If (xset.Tables(0).Rows(0)("QTY_AVAILABLE") < xset.Tables(0).Rows(0)("QUANTITY_PENDING")) Then
                            panelTransHandler.DetailView1.Items("txtQTY").Text = xset.Tables(0).Rows(0)("QTY_AVAILABLE")
                            panelTransHandler.DetailView1.Items("txtQTY").Tag = xset.Tables(0).Rows(0)("QTY_AVAILABLE")
                            gCurrentQtyToAlloc = xset.Tables(0).Rows(0)("QTY_AVAILABLE")

                        Else
                            panelTransHandler.DetailView1.Items("txtQTY").Text = xset.Tables(0).Rows(0)("QUANTITY_PENDING")
                            panelTransHandler.DetailView1.Items("txtQTY").Tag = xset.Tables(0).Rows(0)("QUANTITY_PENDING")
                            gCurrentQtyToAlloc = xset.Tables(0).Rows(0)("QUANTITY_PENDING")

                        End If

                        panelTransHandler.btn_last.Visible = False
                        CType(panelTransHandler.DetailView1.Items("txtQTY"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = False

                    Else
                        Cursor.Current = Cursors.Default
                        panelTransHandler.DetailView1.Items("CodigoBarras").TextForeColor = Color.White
                        panelTransHandler.DetailView1.Items("CodigoBarras").ErrorMessage = pResult
                        CType(panelTransHandler.DetailView1.Items("txtQTY"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = True
                        Notify(pResult, True)
                        Exit Sub
                    End If

                    With panelTransHandler.DetailView1
                        .Items("txtQTY").Visible = True
                        .Items("txtQTY").Enabled = True

                        .Items("txtMt2").Visible = False

                        If xset.Tables(0).Rows(0)("TIPO") = "PISO" Then
                            If IsNumeric(xset.Tables(0).Rows(0)("MT2AVAILABLE").ToString()) Then
                                If Decimal.Parse(xset.Tables(0).Rows(0)("MT2AVAILABLE").ToString()) > 0 Then
                                    .Items("txtMt2").Visible = True
                                    .Items("txtMt2").Text = xset.Tables(0).Rows(0)("MT2AVAILABLE").ToString()
                                    .Items("txtMt2").Tag = xset.Tables(0).Rows(0)("MT2AVAILABLE").ToString()
                                End If
                            End If
                        End If
                        panelTransHandler.btn_last.Text = "Aceptar"
                        panelTransHandler.btn_last.Visible = True

                        Try
                            RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)

                        Catch ex As Exception

                        End Try

                        AddHandler panelTransHandler.btn_last.Click, AddressOf qty_entered_click
                    End With

                Case gSCANNER_SERVICES.LEER_SKU_DESPACHO_ALMGEN
                    'buscar ubicacion leida dentro de las posibles ubicaciones que permite el wavepicking
                    Cursor.Current = Cursors.WaitCursor
                    pBarcode = skuScanData.Replace(" ", "")

                    Dim xserv1 As New WMS_InfoTrans.WMS_InfoTrans
                    Dim pLicenseScanned As Integer
                    pLicenseScanned = panelTransHandler.DetailView1.Items("LicenciaOrigen").Tag


                    If Not MaterialHandleBatch(gBatchRequested) Then
                        Dim serviceTrans As New WMS_Trans.WMS_Trans
                        Dim result As String = String.Empty

                        Dim dt As DataTable = serviceTrans.ValidateIfPickingLicenseIsAvailable(gCurrentWavePicking, gCurrentLocationPicking, pBarcode, pLicenseScanned, GlobalUserID, result, GlobalEnviroment)

                        If String.IsNullOrEmpty(result) Then
                            If dt.Rows.Count > 0 Then
                                panelTransHandler.DetailView1.Items("CodigoBarras").Label = "Scan SKU(" + pBarcode + ")"
                                panelTransHandler.DetailView1.Items("CodigoBarras").Tag = pBarcode

                                Cursor.Current = Cursors.Default

                                gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_DESPACHO_ALMGEN
                                panelTransHandler.DetailView1.Items("CodigoBarras").TextForeColor = Color.Gold
                                panelTransHandler.DetailView1.Items("CodigoBarras").ErrorMessage = Nothing

                                Dim quantity As Integer = panelTransHandler.DetailView1.Items("txtQTY").Tag
                                Dim qty As Decimal = dt.Rows(0)("QTY")
                                Dim quantityPending As Decimal = dt.Rows(0)("QUANTITY_PENDING")

                                If (qty < quantityPending) Then
                                    panelTransHandler.DetailView1.Items("txtQTY").Text = qty
                                    panelTransHandler.DetailView1.Items("txtQTY").Tag = qty

                                Else
                                    panelTransHandler.DetailView1.Items("txtQTY").Text = quantityPending
                                    panelTransHandler.DetailView1.Items("txtQTY").Tag = quantityPending
                                End If

                                gCurrentQtyToAlloc = quantity

                                panelTransHandler.btn_last.Visible = False
                                CType(panelTransHandler.DetailView1.Items("txtQTY"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = False
                            Else

                                Cursor.Current = Cursors.Default
                                panelTransHandler.DetailView1.Items("CodigoBarras").TextForeColor = Color.White
                                panelTransHandler.DetailView1.Items("CodigoBarras").ErrorMessage = pResult
                                CType(panelTransHandler.DetailView1.Items("txtQTY"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = True
                                Notify("Material no disponible para el picking", True)
                                Exit Sub

                            End If
                        Else
                            Cursor.Current = Cursors.Default
                            panelTransHandler.DetailView1.Items("CodigoBarras").TextForeColor = Color.White
                            panelTransHandler.DetailView1.Items("CodigoBarras").ErrorMessage = pResult
                            CType(panelTransHandler.DetailView1.Items("txtQTY"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = True
                            Notify(pResult, True)
                            Exit Sub
                        End If

                        With panelTransHandler.DetailView1
                            .Items("txtQTY").Visible = True
                            .Items("txtQTY").Enabled = True

                            .Items("txtMt2").Visible = False

                            If dt.Rows(0)("SPOT_TYPE") = "PISO" Then
                                If IsNumeric(dt.Rows(0)("USED_MT2").ToString()) Then
                                    If Decimal.Parse(dt.Rows(0)("USED_MT2").ToString()) > 0 Then
                                        .Items("txtMt2").Visible = True
                                        .Items("txtMt2").Text = dt.Rows(0)("USED_MT2").ToString()
                                        .Items("txtMt2").Tag = dt.Rows(0)("USED_MT2").ToString()
                                    End If
                                End If
                            End If
                            panelTransHandler.btn_last.Text = "Aceptar"
                            panelTransHandler.btn_last.Visible = True

                            Try
                                RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)

                            Catch ex As Exception

                            End Try

                            AddHandler panelTransHandler.btn_last.Click, AddressOf qty_entered_click
                        End With

                        If panelTransHandler.DetailView1.Items("UiTxtToneSku").Visible Then
                            panelTransHandler.DetailView1.Items("UiTxtToneSku").Label = "Tono:"
                            panelTransHandler.DetailView1.Items("UiTxtToneSku").Text = IIf(IsDBNull(dt.Rows(0)("TONE")), "", dt.Rows(0)("TONE"))
                        End If
                        If panelTransHandler.DetailView1.Items("UiTxtCaliberSku").Visible Then
                            panelTransHandler.DetailView1.Items("UiTxtCaliberSku").Label = "Calibre:"
                            panelTransHandler.DetailView1.Items("UiTxtCaliberSku").Text = IIf(IsDBNull(dt.Rows(0)("CALIBER")), "", dt.Rows(0)("CALIBER"))
                        End If

                        panelTransHandler.DetailView1.Items("txtQTY").Enabled = True
                        If dt.Rows(0)("SERIAL_NUMBER_REQUESTS") = SiNo.SI Then
                            panelSerialNumberProcess.tipoTarea = "DESPACHO_GENERAL"
                            panelTransHandler.DetailView1.Items("txtQTY").Enabled = False
                            panelTransHandler.btn_last.Visible = False
                            panelSerialNumberProcess.MostrarBotonConsultaDeSeries(dt.Rows(0)("IS_DISCRETIONARY") = SiNo.SI, dt.Rows(0)("QUANTITY_PENDING"), dt.Rows(0)("MATERIAL_ID"))
                            gCurrentScannerService = gSCANNER_SERVICES.lEER_NUMERO_SERIE_DESPACHO
                            ShowPanel(panelSerialNumberProcess)
                        End If
                    Else

                        Dim xserbInfoTrans As New WMS_InfoTrans.WMS_InfoTrans
                        pResult = String.Empty
                        Dim result As DataTable
                        result = xserbInfoTrans.ValidateTaskStatus(GlobalUserID, 0, 0, gCurrentWavePicking, gMaterialId, "TAREA_PICKING", GlobalEnviroment, pResult)
                        If pResult = "OK" AndAlso Not result.Rows(0)(1).ToString.Contains("cancelada") Then
                            xset = xserv1.IsContainedOnWave(GlobalUserID, gCurrentLocationPicking, gCurrentWavePicking, pBarcode, pLicenseScanned, gCurrentCodigoPolizaSource, "SKU", pResult, GlobalEnviroment)
                            Cursor.Current = Cursors.Default

                            If pResult = "OK" Then

                                panelTransHandler.DetailView1.Items("CodigoBarras").Label = "Scan SKU(" + pBarcode + ")"
                                panelTransHandler.DetailView1.Items("CodigoBarras").Tag = pBarcode

                                Cursor.Current = Cursors.Default

                                gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_DESPACHO_ALMGEN
                                panelTransHandler.DetailView1.Items("CodigoBarras").TextForeColor = Color.Gold
                                panelTransHandler.DetailView1.Items("CodigoBarras").ErrorMessage = Nothing
                                panelTransHandler.btn_last.Visible = False
                                CType(panelTransHandler.DetailView1.Items("txtQTY"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = False
                            Else
                                Cursor.Current = Cursors.Default
                                panelTransHandler.DetailView1.Items("CodigoBarras").TextForeColor = Color.White
                                panelTransHandler.DetailView1.Items("CodigoBarras").ErrorMessage = pResult
                                CType(panelTransHandler.DetailView1.Items("txtQTY"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = True
                                Notify(pResult, True)
                                Exit Sub
                            End If

                            With panelTransHandler.DetailView1
                                .Items("txtQTY").Visible = True
                                .Items("txtQTY").Enabled = True

                                .Items("txtMt2").Visible = False
                                If xset.Tables(0).Rows(0)("TIPO") = "PISO" Then
                                    If IsNumeric(xset.Tables(0).Rows(0)("MT2AVAILABLE").ToString()) Then
                                        If Decimal.Parse(xset.Tables(0).Rows(0)("MT2AVAILABLE").ToString()) > 0 Then
                                            .Items("txtMt2").Visible = True
                                            .Items("txtMt2").Text = xset.Tables(0).Rows(0)("MT2AVAILABLE").ToString()
                                            .Items("txtMt2").Tag = xset.Tables(0).Rows(0)("MT2AVAILABLE").ToString()
                                        End If
                                    End If
                                End If

                                panelTransHandler.btn_last.Text = "Aceptar"
                                panelTransHandler.btn_last.Visible = True

                                Try
                                    RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
                                Catch ex As Exception

                                End Try

                                AddHandler panelTransHandler.btn_last.Click, AddressOf qty_entered_click
                            End With
                            panelTransHandler.DetailView1.Items("txtQTY").Enabled = True
                            If xset.Tables("IsLocationContainedOnWave").Rows(0)("SERIAL_NUMBER_REQUESTS") = SiNo.SI Then
                                panelSerialNumberProcess.tipoTarea = "DESPACHO_GENERAL"
                                panelTransHandler.DetailView1.Items("txtQTY").Enabled = False
                                panelTransHandler.btn_last.Visible = False
                                panelSerialNumberProcess.MostrarBotonConsultaDeSeries(xset.Tables("IsLocationContainedOnWave").Rows(0)("IS_DISCRETIONARY") = SiNo.SI, xset.Tables("IsLocationContainedOnWave").Rows(0)("QUANTITY_PENDING"), xset.Tables("IsLocationContainedOnWave").Rows(0)("MATERIAL_ID"))
                                gCurrentScannerService = gSCANNER_SERVICES.lEER_NUMERO_SERIE_DESPACHO
                                ShowPanel(panelSerialNumberProcess)
                            End If
                        Else
                            Notify(IIf(pResult = "OK", result.Rows(0)(1).ToString(), pResult), True)
                        End If
                    End If

                Case gSCANNER_SERVICES.LEER_SKU_REALLOC_PARTIAL
                    pBarcode = skuScanData.Replace(" ", "")
                    xset = xserv.SearchByBarCode(pBarcode, gClientOwner, pResult, GlobalEnviroment)
                    panelTransHandler.DetailView1.Items("txtScannedSKU").Text = pBarcode

                    If pResult = "OK" Then
                        Dim dt As DataTable
                        pResult = String.Empty
                        Dim a As String = "OK"

                        xservInfo.ValidateIfStatusOfLicenseAllowsRealloc(CInt(gSourceLicense), xset.Tables(0).Rows(0)("MATERIAL_ID").ToString, GlobalEnviroment, pResult)
                        If pResult <> "OK" Then
                            Notify(pResult, True)
                            Return
                        End If

                        dt = xservInfo.ValidateLicenceAndSkuToRealloc(gSourceLicense, xset.Tables(0).Rows(0)("MATERIAL_ID").ToString, GlobalEnviroment, pResult)
                        If dt.Columns.Count > 1 Then
                            With panelTransHandler.DetailView1

                                .Items("dtFechaExpiracion").Visible = False
                                .Items("txtNumLote").Text = ""
                                .Items("txtNumLote").Visible = False
                                .Items("UiTextoVinRecepcion").Text = ""
                                .Items("UiTextoVinRecepcion").Visible = False
                                .Items("UiTextTone").Text = ""
                                .Items("UiTextTone").Visible = False
                                .Items("UiTextCaliber").Text = ""
                                .Items("UiTextCaliber").Visible = False


                                .Items("lblSKUName").Text = xset.Tables(0).Rows(0)("SHORT_NAME").ToString
                                .Items("lblSKUName").Visible = True
                                .Items("lblSKUName").Tag = IIf(IsDBNull(xset.Tables(0).Rows(0)("REQUIRES_LOGISTICS_INFO").ToString), "0", xset.Tables(0).Rows(0)("REQUIRES_LOGISTICS_INFO").ToString)
                                CType(.Items("lblSKUName"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = True

                                .Items("txtNumLote").Value = dt.Rows(0)("BATCH").ToString
                                .Items("dtFechaExpiracion").Value = IIf(IsDBNull(dt.Rows(0)("DATE_EXPIRATION")), Date.Today.Date, dt.Rows(0)("DATE_EXPIRATION").ToString)
                                .Items("UiTextoVinRecepcion").Value = IIf(IsDBNull(dt.Rows(0)("VIN")), "", dt.Rows(0)("VIN").ToString)
                                .Items("UiTextTone").Value = IIf(IsDBNull(dt.Rows(0)("TONE")), "", dt.Rows(0)("TONE").ToString)
                                .Items("UiTextCaliber").Value = IIf(IsDBNull(dt.Rows(0)("CALIBER")), "", dt.Rows(0)("CALIBER").ToString)
                                .Items("txtCantidad").Value = dt.Rows(0)("QTY").ToString
                                .Items("txtCantidad").Tag = dt.Rows(0)("QTY").ToString
                                .Items("txtCantidad").Visible = True
                                CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).SetFocus()

                                Try
                                    RemoveHandler CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf qty_entered
                                Catch ex As Exception

                                End Try
                                AddHandler CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf qty_entered


                                If ApplyProperty(xset.Tables(0).Rows(0)("BATCH_REQUESTED")) Then
                                    .Items("dtFechaExpiracion").Visible = True
                                    .Items("txtNumLote").Visible = True
                                    .Items("txtNumLote").SetFocus()
                                End If

                                If ApplyProperty(xset.Tables(0).Rows(0)("HANDLE_TONE")) Then
                                    .Items("UiTextTone").Visible = True
                                    .Items("UiTextTone").SetFocus()
                                End If

                                If ApplyProperty(xset.Tables(0).Rows(0)("HANDLE_CALIBER")) Then
                                    .Items("UiTextCaliber").Visible = True
                                    .Items("UiTextCaliber").SetFocus()
                                End If

                                If ApplyProperty(xset.Tables(0).Rows(0)("IS_CAR")) Then
                                    .Items("UiTextoVinRecepcion").Visible = True
                                    .Items("UiTextoVinRecepcion").Text = ""
                                    .Items("UiTextoVinRecepcion").SetFocus()
                                End If

                                If xset.Tables(0).Rows(0)("SERIAL_NUMBER_REQUESTS") = SiNo.SI Then
                                    panelSerialNumberProcess.tipoTarea = "REUBICACION_PARCIAL"
                                    panelSerialNumberProcess.MostrarBotonConsultaDeSeries(False, 0, xset.Tables(0).Rows(0)("MATERIAL_ID").ToString)
                                    gCurrentScannerService = gSCANNER_SERVICES.LEER_NUMERO_SERIE_REUBICACION_PARCIAL
                                    ShowPanel(panelSerialNumberProcess)
                                End If

                            End With

                        Else
                            pResult = dt.Rows(0)(0).ToString()
                            With panelTransHandler.DetailView1
                                If .Items("UiTextoVinRecepcion").Visible And gPendingSKU Then
                                    .Items("UiTextoVinRecepcion").Text = pBarcode
                                Else
                                    Notify(pResult, True)
                                End If
                            End With
                        End If
                    Else
                        Notify(pResult, True)
                    End If


                Case gSCANNER_SERVICES.LEER_SKU_TRASLADO_ALMGEN
                    pBarcode = skuScanData.Replace(" ", "")

                    If pBarcode = panelTransHandler.DetailView1.Items("txtScannedSKU").Text Then
                        pResult = "OK"
                        panelTransHandler.DetailView1.Items("CodigoBarras").TextForeColor = Color.Gold
                        panelTransHandler.DetailView1.Items("CodigoBarras").ErrorMessage = Nothing
                        panelTransHandler.btn_last.Visible = False
                        Dim xserv1 As New WMS_InfoTrans.WMS_InfoTrans

                        Dim xset1 As DataSet = xserv1.IsContainedOnWave(GlobalUserID, gCurrentLocationPicking, gCurrentWavePicking, pBarcode, gCurrentLicenseID, gCurrentCodigoPolizaSource, "SKU", pResult, GlobalEnviroment)

                        If pResult = "OK" Then
                            panelTransHandler.DetailView1.Items("CodigoBarras").TextForeColor = Color.Gold
                            panelTransHandler.DetailView1.Items("CodigoBarras").ErrorMessage = Nothing

                            If (xset1.Tables(0).Rows(0)("QTY_AVAILABLE") < xset1.Tables(0).Rows(0)("QUANTITY_PENDING")) Then
                                panelTransHandler.DetailView1.Items("txtQTY").Text = xset1.Tables(0).Rows(0)("QTY_AVAILABLE")
                                panelTransHandler.DetailView1.Items("txtQTY").Tag = xset1.Tables(0).Rows(0)("QTY_AVAILABLE")
                                gCurrentQtyToAlloc = xset1.Tables(0).Rows(0)("QTY_AVAILABLE")

                            Else
                                panelTransHandler.DetailView1.Items("txtQTY").Text = xset1.Tables(0).Rows(0)("QUANTITY_PENDING")
                                panelTransHandler.DetailView1.Items("txtQTY").Tag = xset1.Tables(0).Rows(0)("QUANTITY_PENDING")
                                gCurrentQtyToAlloc = xset1.Tables(0).Rows(0)("QUANTITY_PENDING")

                            End If

                        Else
                            pResult = " SKU " & pBarcode & " es Invalido en dicha licencia/ubicacion o no existe."
                            panelTransHandler.DetailView1.Items("CodigoBarras").Control.ForeColor = Color.White
                            panelTransHandler.DetailView1.Items("CodigoBarras").ErrorMessage = pResult

                            Cursor.Current = Cursors.Default
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_TRASLADO_ALMGEN
                        End If


                        CType(panelTransHandler.DetailView1.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).SetFocus()

                        Exit Sub
                    Else
                        pResult = "SKU " & pBarcode & " es distinto al SKU de la tarea"
                        Notify(pResult, True)
                        panelTransHandler.DetailView1.Items("CodigoBarras").TextForeColor = Color.White
                        panelTransHandler.DetailView1.Items("CodigoBarras").ErrorMessage = pResult
                        Exit Sub

                    End If

                Case Else
                    If gMyLastLicense <> 0 Then

                        Cursor.Current = Cursors.WaitCursor
                        pBarcode = skuScanData.Replace(" ", "")

                        xset = xserv.SearchByBarCode(pBarcode, gClientOwner, pResult, GlobalEnviroment)

                        If pResult = "OK" Then
                            panelTransHandler.DetailView1.Items("txtScannedSKU").Text = pBarcode
                            gPendingSKU = True
                            gIsNewSKU = False
                            With panelTransHandler.DetailView1
                                .Items("lblSKUName").Text = xset.Tables(0).Rows(0)("SHORT_NAME").ToString
                                .Items("lblSKUName").Visible = True
                                .Items("lblSKUName").Tag = IIf(IsDBNull(xset.Tables(0).Rows(0)("REQUIRES_LOGISTICS_INFO").ToString), "0", xset.Tables(0).Rows(0)("REQUIRES_LOGISTICS_INFO").ToString)
                                CType(.Items("lblSKUName"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = True

                                .Items("txtCantidad").Enabled = True
                                .Items("txtCantidad").Visible = True
                                .Items("txtCantidad").Text = "1"
                                .Items("txtCantidad").Tag = IIf(IsDBNull(xset.Tables(0).Rows(0)("SCAN_BY_ONE").ToString), "0", xset.Tables(0).Rows(0)("SCAN_BY_ONE").ToString)

                                CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = IIf(.Items("txtCantidad").Tag = "1", True, False)
                                CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).SetFocus()
                                Try
                                    RemoveHandler CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf qty_entered
                                Catch ex As Exception

                                End Try
                                AddHandler CType(.Items("txtCantidad"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf qty_entered
                                .Items("txtCantidad").SetFocus()

                                If xset.Tables(0).Rows(0)("BATCH_REQUESTED") = 1 Then
                                    .Items("dtFechaExpiracion").Visible = True
                                    .Items("txtNumLote").Visible = True
                                    .Items("txtNumLote").SetFocus()
                                Else
                                    .Items("dtFechaExpiracion").Visible = False
                                    .Items("txtNumLote").Visible = False
                                    .Items("txtNumLote").Text = ""
                                End If

                                If xset.Tables(0).Rows(0)("IS_CAR") = 1 Then
                                    .Items("UiTextoVinRecepcion").Visible = True
                                    .Items("UiTextoVinRecepcion").Text = ""
                                    .Items("UiTextoVinRecepcion").SetFocus()
                                Else
                                    .Items("UiTextoVinRecepcion").Visible = False
                                    .Items("UiTextoVinRecepcion").Text = ""
                                End If
                            End With

                        Else
                            With panelTransHandler.DetailView1
                                If .Items("UiTextoVinRecepcion").Visible Then
                                    .Items("UiTextoVinRecepcion").Text = pBarcode
                                Else
                                    panelTransHandler.DetailView1.Items("txtScannedSKU").Text = ""
                                    gPendingSKU = False
                                    gIsNewSKU = True

                                    With panelTransHandler.DetailView1
                                        .Items("txtScannedSKU").Text = "..."
                                        .Items("lblSKUName").Text = ""
                                        .Items("lblSKUName").Tag = "..."
                                        .Items("lblSKUName").Visible = False
                                        .Items("txtCantidad").Visible = True
                                        .Items("txtCantidad").Enabled = False
                                        .Items("txtCantidad").Visible = True


                                        CType(.Items("lblSKUName"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = False
                                        CType(.Items("lblSKUName"), Resco.Controls.DetailView.ItemTextBox).Enabled = True
                                        CType(.Items("lblSKUName"), Resco.Controls.DetailView.ItemTextBox).SetFocus()

                                        Try
                                            RemoveHandler CType(.Items("lblSKUName"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf sku_name_entered
                                            RemoveHandler CType(.Items("lblSKUName"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf qty_entered

                                        Catch ex As Exception

                                        End Try

                                        AddHandler CType(.Items("lblSKUName"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf sku_name_entered

                                        .Items("txtCantidad").Tag = "0"

                                        Beep()
                                        Notify(pResult, True)
                                    End With
                                End If
                            End With
                        End If

                    End If

                    Cursor.Current = Cursors.Default

            End Select

        Catch ex As WebException
            Notify("SkuScanned: " + ex.Message, True)
        End Try
    End Sub

    Private Function ApplyProperty(ByVal value As Integer) As Boolean
        Return value = 1
    End Function

    Sub LocationScanned(ByVal pValidar As Boolean, ByVal pTransMT2 As Decimal, ByVal ScanData As String, ByRef pResult As String)
        Try
            Dim xserv As New WMS_InfoTrans.WMS_InfoTrans
            Dim serviceInfoInventory As New WMS_InfoInventory.WMS_InfoInventory
            Dim pSKUs_processed As Integer = 0
            Dim pSKUs_not_processed As Integer = 0
            Dim xset As DataSet
            Dim location As String = ""
            Dim locationExists As Boolean = False
            panelRecFiscalStep2.UIVistaUbicacionesSugeridas.Visible = False


            Select Case gCurrentScannerService

                Case gSCANNER_SERVICES.LEER_UBICACION_REALLOC

                    Cursor.Current = Cursors.Default

                    Dim nameStatus As String = CType(panelTransHandler.DetailView1.Items("UiComboBoxStates"), Resco.Controls.DetailView.ItemAdvancedComboBox).Value

                    If String.IsNullOrEmpty(nameStatus) And Convert.ToBoolean(panelTransHandler.DetailView1.Items("UiCheckEtiqueta").Value) = False Then
                        Notify("Tiene que seleccionar un estado.", True)
                        Exit Sub
                    End If

                    location = GetLocationByStatus(nameStatus)

                    If Not String.IsNullOrEmpty(location) And Convert.ToBoolean(panelTransHandler.DetailView1.Items("UiCheckEtiqueta").Value) = False Then
                        locationExists = serviceInfoInventory.ValidateIfLocationExists(GlobalEnviroment, location)
                        If locationExists Then
                            If location <> ScanData Then
                                Notify("Ubicación de destino inválida favor dirigirse a: " & location, True)
                                Exit Sub
                            End If
                        End If
                    End If

                    If Convert.ToBoolean(panelTransHandler.DetailView1.Items("UiCheckEtiqueta").Value) = False Then

                        Dim dtValidateVolume As Data.DataTable = serviceInfoInventory.ValidateLocationVolume(ScanData, CInt(panelTransHandler.DetailView1.Items("txtLicencia").Text), GlobalEnviroment, pResult)
                        If String.IsNullOrEmpty(pResult) Then
                            If dtValidateVolume.Rows.Count > 0 Then
                                If dtValidateVolume.Rows(0)("Resultado") = ResultadoOperacionTipo.SobrepasaValidacion Then
                                    Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = False
                                    Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green
                                    Dim pText() As String = {"SI", "NO"}
                                    Cursor.Current = Cursors.Default
                                    If Not MessageBoxEx.ShowYesCancel(dtValidateVolume.Rows(0)("Mensaje"), True, pText) Then
                                        Exit Sub
                                    End If
                                End If
                            End If
                        Else
                            Notify(pResult, True)
                        End If

                        Dim dtValidationWigth As Data.DataTable = serviceInfoInventory.ValidateLocationMaxWeigth(ScanData, CInt(panelTransHandler.DetailView1.Items("txtLicencia").Text), GlobalEnviroment, pResult)
                        If String.IsNullOrEmpty(pResult) Then
                            If dtValidationWigth.Rows.Count > 0 Then
                                If dtValidationWigth.Rows(0)("RESULT").Equals("SI") Then
                                    Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = False
                                    Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green
                                    Dim pText() As String = {"SI", "NO"}
                                    Cursor.Current = Cursors.Default
                                    If Not MessageBoxEx.ShowYesCancel("El peso de la licencia sobrepasa el peso de la ubicacion. Desea continuar?", True, pText) Then
                                        Exit Sub
                                    End If
                                End If
                            End If
                        Else
                            Notify(pResult, True)
                        End If

                        If Not panelTransHandler.DetailView1.Items("txtUbicacion").Tag = ScanData Then
                            panelTransHandler.DetailView1.Items("txtMt2").Visible = False
                            panelTransHandler.DetailView1.Items("txtMt2").Tag = 0
                            panelTransHandler.DetailView1.Items("txtMt2").Text = "0"

                            Dim dtL As DataSet
                            dtL = xserv.GET_LOCATION(ScanData, pResult, GlobalEnviroment)

                            If pResult = "OK" Then
                                If dtL.Tables(0).Rows.Count > 0 Then
                                    If dtL.Tables(0).Rows(0)("SPOT_TYPE").ToString().Equals("PISO") Then
                                        Dim mt2Dispo As Decimal = Decimal.Parse(dtL.Tables(0).Rows(0)("MAX_MT2_OCCUPANCY").ToString()) - Decimal.Parse(dtL.Tables(0).Rows(0)("MT2_USED").ToString())
                                        If mt2Dispo <= 0 Then
                                            Notify("La ubicacion " + ScanData + " ya esta llena", True)
                                            Return
                                        End If
                                        panelTransHandler.DetailView1.Items("txtUbicacion").Text = "Scan de Nuevo " + ScanData
                                        panelTransHandler.DetailView1.Items("txtUbicacion").Tag = ScanData
                                        panelTransHandler.DetailView1.Items("txtMt2").Tag = mt2Dispo
                                        panelTransHandler.DetailView1.Items("txtMt2").Text = "0"
                                        panelTransHandler.DetailView1.Items("txtMt2").Visible = True
                                        panelTransHandler.DetailView1.Items("txtMt2").SetFocus()
                                        Return
                                    End If
                                End If
                            Else
                                Notify(pResult, True)
                                Return
                            End If
                        End If

                        If panelTransHandler.DetailView1.Items("txtMt2").Visible Then
                            If IsNumeric(panelTransHandler.DetailView1.Items("txtMt2").Text) Then
                                If Decimal.Parse(panelTransHandler.DetailView1.Items("txtMt2").Text) <= Decimal.Parse(panelTransHandler.DetailView1.Items("txtMt2").Tag) Then
                                    If Not Decimal.Parse(panelTransHandler.DetailView1.Items("txtMt2").Text) > 0 Then
                                        Notify("Debe ser mayor a 0", True)
                                        panelTransHandler.DetailView1.Items("txtMt2").SetFocus()
                                        Return
                                    End If
                                Else
                                    Notify("Sobrepasa la capacidad:" + panelTransHandler.DetailView1.Items("txtMt2").Tag.ToString(), True)
                                    panelTransHandler.DetailView1.Items("txtMt2").SetFocus()
                                    Return
                                End If
                            Else
                                Notify("El campo metros cuadrados es numerico.", True)
                                panelTransHandler.DetailView1.Items("txtMt2").SetFocus()
                                Return
                            End If
                        Else
                        End If

                        panelTransHandler.DetailView1.Items("txtUbicacion").Text = ScanData
                        Dim xserv1 As New WMS_Trans.WMS_Trans
                        If xserv1.LicenseReAlloc(CInt(panelTransHandler.DetailView1.Items("txtLicencia").Text), ScanData.ToUpper.ToString, GlobalUserID, Decimal.Parse(panelTransHandler.DetailView1.Items("txtMt2").Text), pResult, GlobalEnviroment, nameStatus) Then
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_REALLOC
                            panelTransHandler.DetailView1.Items("txtUbicacion").Text = ""
                            panelTransHandler.DetailView1.Items("txtUbicacion").ErrorMessage = Nothing
                            panelTransHandler.DetailView1.Items("txtLicencia").Label = "Scan Licencia(" + panelTransHandler.DetailView1.Items("txtLicencia").Text + ")"
                            panelTransHandler.DetailView1.Items("txtLicencia").Text = ""
                            CType(panelTransHandler.DetailView1.Items("txtLicencia"), Resco.Controls.DetailView.ItemTextBox).SetFocus()

                            panelTransHandler.DetailView1.Items("txtMt2").Visible = False
                            panelTransHandler.DetailView1.Items("txtMt2").Tag = 0
                            panelTransHandler.DetailView1.Items("txtMt2").Text = "0"
                            panelTransHandler.DetailView1.Items("txtUbicacion").Tag = ""

                            Dim result As String = ""
                            Dim serv As New WMS_InfoTrans.WMS_InfoTrans
                            Dim dt As DataSet

                            dt = serv.GET_TYPE_CHARGE_MOVIL(gCurrentLicenseID, "REUBICACION_LICENCIA", result, GlobalEnviroment)
                            If result = "OK" And Not dt Is Nothing Then
                                panelTypeChange._licenseId = Integer.Parse(gCurrentLicenseID)
                                panelTypeChange.AdvancedList_Default.DataSource = dt.Tables(0)
                                panelTypeChange._typeTrans = "REUBICACION_LICENCIA"
                                panelTypeChange.AdvancedList_Default.Templates("RowTemplate_Header").CellTemplates(0).CellSource.ConstantData = "Tipos de Cobro/Licencia " + gCurrentLicenseID.ToString()
                                ShowPanel(panelTypeChange)
                            Else
                                ShowPanel(panelTransHandler)
                                LoadPage("lic_realloc", gPanelTitle, True)

                                gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_REALLOC
                                gCurrentTransactionType = gTRANS_TYPE.REUBICACION_COMPLETA
                                panelTransHandler.DetailView1.Items("txtLicencia").Label = "Scan Licencia..."
                                panelTransHandler.DetailView1.Items("UiCheckEtiqueta").Value = False
                            End If



                        Else
                            Notify("LocationScanned: " + pResult, True)
                            panelTransHandler.DetailView1.Items("txtUbicacion").ErrorMessage = pResult
                        End If
                    Else
                        'Reubicar Etiqueta 
                        pResult = String.Empty
                        serviceInfoInventory.ReubicarEtiquetaDeDespacho(panelTransHandler.DetailView1.Items("txtLicencia").Text, ScanData, GlobalEnviroment, pResult)

                        If pResult <> "Proceso Exitoso" Then
                            Notify("LocationScanned: " + pResult, True)
                        Else
                            ShowPanel(panelTransHandler)
                            LoadPage("lic_realloc", gPanelTitle, True)
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_ETIQUETA_REUBICACION
                            gCurrentTransactionType = gTRANS_TYPE.REUBICACION_COMPLETA
                            panelTransHandler.DetailView1.Items("txtLicencia").Label = "Scan Etiqueta..."
                            panelTransHandler.DetailView1.Items("UiCheckEtiqueta").Value = True
                        End If
                    End If

                Case gSCANNER_SERVICES.LEER_UBICACION_DESPACHO_FISCAL
                    panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = False
                    'buscar ubicacion leida dentro de las posibles ubicaciones que permite el wavepicking
                    Cursor.Current = Cursors.WaitCursor
                    If ScanData.ToUpper = panelTransHandler.DetailView1.Items("UbicacionOrigen").Tag Then
                        panelTransHandler.DetailView1.Items("UbicacionOrigen").Text = ScanData.ToUpper
                        Cursor.Current = Cursors.Default
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_DESPACHO_FISCAL

                        panelTransHandler.DetailView1.Items("UbicacionOrigen").TextForeColor = Color.Gold
                        panelTransHandler.DetailView1.Items("UbicacionOrigen").ErrorMessage = Nothing
                        gCurrentLocationPicking = ScanData.ToUpper

                    Else
                        panelTransHandler.DetailView1.Items("UbicacionOrigen").Text = ScanData.ToUpper
                        xset = xserv.IsContainedOnWave(GlobalUserID, ScanData.ToUpper, gCurrentWavePicking, gCurrentSKUPicking, gCurrentLicenseID, gCurrentCodigoPolizaSource, "UBICACION", pResult, GlobalEnviroment)
                        Cursor.Current = Cursors.Default

                        If pResult = "OK" Then
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_DESPACHO_FISCAL
                            panelTransHandler.DetailView1.Items("UbicacionOrigen").TextForeColor = Color.Gold
                            panelTransHandler.DetailView1.Items("UbicacionOrigen").ErrorMessage = Nothing
                            gCurrentLocationPicking = ScanData.ToUpper

                            panelTransHandler.DetailView1.Items("LicenciaOrigen").Label = "Scan Licencia()"
                            panelTransHandler.DetailView1.Items("LicenciaOrigen").Tag = ""

                        Else
                            Cursor.Current = Cursors.Default
                            panelTransHandler.DetailView1.Items("UbicacionOrigen").TextForeColor = Color.White
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_DESPACHO_FISCAL

                            panelTransHandler.DetailView1.Items("UbicacionOrigen").ErrorMessage = pResult
                            gCurrentLocationPicking = ""
                            Notify("LocationScanned: " + pResult, True)
                            Exit Sub
                        End If

                    End If

                Case gSCANNER_SERVICES.LEER_UBICACION_DESPACHO_ALMGEN
                    panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = False
                    Cursor.Current = Cursors.WaitCursor
                    If ScanData.ToUpper = panelTransHandler.DetailView1.Items("UbicacionOrigen").Tag Then
                        panelTransHandler.DetailView1.Items("UbicacionOrigen").Text = ScanData.ToUpper
                        Cursor.Current = Cursors.Default
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_DESPACHO_ALMGEN

                        panelTransHandler.DetailView1.Items("UbicacionOrigen").TextForeColor = Color.Gold
                        panelTransHandler.DetailView1.Items("UbicacionOrigen").ErrorMessage = Nothing
                        gCurrentLocationPicking = ScanData.ToUpper
                    ElseIf Not MaterialHandleBatch(gBatchRequested) AndAlso Not MobilityScm.Modelo.Tipos.Enums.GetStringValue(MobilityScm.Modelo.Tipos.SubTipoTarea.InventarioPreparado) = gTaskSubType Then
                        Dim serviceTrans As New WMS_Trans.WMS_Trans
                        Dim result As String = String.Empty

                        Dim dt As DataTable = serviceTrans.ValidateIfPickingLicenseIsAvailable(gCurrentWavePicking, ScanData.ToUpper, gMaterialIdPicking, 0, GlobalUserID, result, GlobalEnviroment)

                        If String.IsNullOrEmpty(result) Then
                            If dt.Rows.Count > 0 Then
                                panelTransHandler.DetailView1.Items("UbicacionOrigen").Label = "Scan Ubicación()"
                                panelTransHandler.DetailView1.Items("UbicacionOrigen").Text = ScanData.ToUpper

                                gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_DESPACHO_ALMGEN

                                panelTransHandler.DetailView1.Items("UbicacionOrigen").TextForeColor = Color.Gold
                                panelTransHandler.DetailView1.Items("UbicacionOrigen").ErrorMessage = Nothing
                                gCurrentLocationPicking = ScanData.ToUpper

                                panelTransHandler.DetailView1.Items("LicenciaOrigen").Label = "Scan Licencia()"
                                panelTransHandler.DetailView1.Items("LicenciaOrigen").Tag = ""

                                Cursor.Current = Cursors.Default
                            Else
                                Cursor.Current = Cursors.Default
                                panelTransHandler.DetailView1.Items("UbicacionOrigen").TextForeColor = Color.White
                                gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_DESPACHO_ALMGEN
                                panelTransHandler.DetailView1.Items("UbicacionOrigen").ErrorMessage = pResult
                                gCurrentLocationPicking = ""
                                Notify("No hay inventario disponible en esta ubicacion", True)
                                Exit Sub
                            End If
                        Else
                            Cursor.Current = Cursors.Default
                            panelTransHandler.DetailView1.Items("UbicacionOrigen").TextForeColor = Color.White
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_DESPACHO_ALMGEN

                            panelTransHandler.DetailView1.Items("UbicacionOrigen").ErrorMessage = pResult
                            gCurrentLocationPicking = ""
                            Notify(result, True)
                            Exit Sub
                        End If

                    Else
                        pResult = "Debe escanear la ubicación solicitada."
                        panelTransHandler.DetailView1.Items("UbicacionOrigen").Text = ScanData.ToUpper
                        Cursor.Current = Cursors.Default
                        panelTransHandler.DetailView1.Items("UbicacionOrigen").TextForeColor = Color.White
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_DESPACHO_ALMGEN
                        panelTransHandler.DetailView1.Items("UbicacionOrigen").ErrorMessage = pResult
                        gCurrentLocationPicking = ""
                        Notify(pResult, True)
                        Exit Sub
                    End If

                Case gSCANNER_SERVICES.LEER_UBICACION_OCUPACION
                    panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = False
                    Cursor.Current = Cursors.WaitCursor
                    Dim xserv1 As New WMS_InfoInventory.WMS_InfoInventory
                    PopulateOccupancyLevelsCmb()

                    panelTransHandler.DetailView1.Items("txtLocation").Text = UCase(ScanData)

                    xset = xserv1.GetLocation(ScanData, pResult, GlobalEnviroment)
                    If pResult = "OK" Then
                        panelTransHandler.DetailView1.Items("lblWarehouse").ErrorMessage = ""

                        panelTransHandler.DetailView1.Items("txtLocation").TextForeColor = Color.White
                        panelTransHandler.DetailView1.Items("lblWarehouse").Text = xset.Tables(0).Rows(0)("ZONE") & " / MAX.CAP.: " & xset.Tables(0).Rows(0)("MAX_MT2_OCCUPANCY") & " MT2."
                        panelTransHandler.DetailView1.Items("lblWarehouse").Tag = xset.Tables(0).Rows(0)("ZONE")

                    Else
                        Notify(pResult, True)

                        panelTransHandler.DetailView1.Items("lblWarehouse").Tag = ""
                        panelTransHandler.DetailView1.Items("lblWarehouse").ErrorMessage = pResult
                        panelTransHandler.DetailView1.Items("lblWarehouse").Text = ""

                    End If

                    Cursor.Current = Cursors.Default
                Case gSCANNER_SERVICES.LEER_UBICACION_SALIDA_DESPACHO
                    panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = False
                    Dim xservInfo As New WMS_InfoTrans.WMS_InfoTrans
                    Dim dt As DataSet
                    dt = xservInfo.GET_LOCATION(ScanData, pResult, GlobalEnviroment)
                    If pResult = "OK" Then
                        panelRecFiscalStep2.btnStatus.Tag = "0"
                        panelRecFiscalStep2.LBL_LOCATION.Text = ScanData
                        panelRecFiscalStep2.btnStatus.Visible = True
                        panelRecFiscalStep2.btnStatus.Text = "OK"

                    Else
                        panelRecFiscalStep2.LBL_LOCATION.Text = "..."
                        panelRecFiscalStep2.btnStatus.Visible = False
                        Notify(pResult, True)
                        Return
                    End If
                Case gSCANNER_SERVICES.LEER_UBICACION_PARA_REUBICACION_POR_REABASTECIMIENTO
                    panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = False
                    'ojo
                    If panelRecFiscalStep2.LBL_LOCATION.Tag.ToString.Equals(ScanData) OrElse gTaskSubType = MobilityScm.Modelo.Tipos.Enums.GetStringValue(MobilityScm.Modelo.Tipos.SubTipoTarea.EntregaNoInmediata) Then
                        Dim dt As DataSet
                        Dim xservInfo As New WMS_InfoTrans.WMS_InfoTrans
                        dt = xservInfo.GET_LOCATION(ScanData, pResult, GlobalEnviroment)

                        If pResult = "OK" Then
                            If dt.Tables(0).Rows.Count > 0 Then
                                Dim xervTrans As New WMS_Trans.WMS_Trans
                                pResult = ""

                                Dim tipoUbicaion As String = ""
                                Dim mt2 As Decimal = 0
                                If panelTransHandler.DetailView1.Items("txtMt2").Visible Then
                                    tipoUbicaion = "PISO"
                                    mt2 = Decimal.Parse(panelTransHandler.DetailView1.Items("txtMt2").Text)
                                End If
                                Dim newLicense As Integer = 0
                                newLicense = panelRecFiscalStep2.lblTitle.Tag

                                If gTaskSubType = MobilityScm.Modelo.Tipos.Enums.GetStringValue(MobilityScm.Modelo.Tipos.SubTipoTarea.EntregaNoInmediata) Then
                                    If Not xervTrans.RegisterTransRelocateForNoImmediatePicking(GlobalUserID, gCurrentSKUPicking, gMaterialBarCode, gCurrentLicenseID, gSourceLocation, gCurrentQtyToAlloc, gCurrentWavePicking, mt2, tipoUbicaion, ScanData, GlobalEnviroment, newLicense, pResult) Then
                                        Notify(pResult, True)
                                        Exit Sub
                                    End If
                                Else
                                    If Not xervTrans.RegisterTransReallocForReplenishment(GlobalUserID, gCurrentSKUPicking, gMaterialBarCode, gCurrentLicenseID, gSourceLocation, gCurrentQtyToAlloc, gCurrentWavePicking, mt2, tipoUbicaion, ScanData, GlobalEnviroment, newLicense, pResult) Then
                                        Notify(pResult, True)
                                        Exit Sub
                                    End If
                                End If

                                If Not pResult.ToUpper.Equals("OK") Then
                                    Notify(pResult, True)
                                    Exit Sub
                                End If
                                panelRecFiscalStep2.lblTitle.Tag = newLicense
                                panelRecFiscalStep2.UiBotonImprimirLicencia.Visible = True
                                panelRecFiscalStep2.lblTitle.Text = "Ubicación: " & gLocationSpotTarget & "/ Licencia: " & newLicense
                                panelRecFiscalStep2.LBL_LOCATION.Text = "Ubicación " + ScanData
                                panelRecFiscalStep2.btnStatus.Tag = "0"
                                panelRecFiscalStep2.btnStatus.Text = "OK"
                                panelRecFiscalStep2.btnStatus.Visible = True
                            Else
                                Notify("Ubicación inválida", True)
                            End If
                        Else
                            Notify("Ubicación inválida", True)
                        End If
                    Else
                        Notify("Ubicación inválida", True)
                    End If

                Case Else

                    If Not String.IsNullOrEmpty(panelRecFiscalStep2.LBL_LOCATION.Tag) AndAlso Not panelRecFiscalStep2.LBL_LOCATION.Tag.Equals(ScanData) Then
                        Notify("La ubicación " + ScanData + " no es igual a la establecida " + panelRecFiscalStep2.LBL_LOCATION.Tag + " del estado.", True)
                        Exit Sub
                    End If

                    Dim dtValidateVolume As Data.DataTable = serviceInfoInventory.ValidateLocationVolume(ScanData, gLicenseID, GlobalEnviroment, pResult)
                    If String.IsNullOrEmpty(pResult) Then
                        If dtValidateVolume.Rows.Count > 0 Then
                            If dtValidateVolume.Rows(0)("Resultado") = ResultadoOperacionTipo.SobrepasaValidacion Then
                                Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = False
                                Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green
                                Dim pText() As String = {"SI", "NO"}
                                Cursor.Current = Cursors.Default
                                If Not MessageBoxEx.ShowYesCancel(dtValidateVolume.Rows(0)("Mensaje"), True, pText) Then
                                    Exit Sub
                                End If
                            End If
                        End If
                    Else
                        Notify(pResult, True)
                    End If

                    Dim dtValidationWigth As Data.DataTable = serviceInfoInventory.ValidateLocationMaxWeigth(ScanData, gLicenseID, GlobalEnviroment, pResult)
                    If String.IsNullOrEmpty(pResult) Then
                        If dtValidationWigth.Rows.Count > 0 Then
                            If dtValidationWigth.Rows(0)("RESULT").Equals("SI") Then
                                Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = False
                                Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green
                                Dim pText() As String = {"SI", "NO"}
                                Cursor.Current = Cursors.Default
                                If Not MessageBoxEx.ShowYesCancel("El peso de la licencia sobrepasa el peso de la ubicación. Desea continuar?", True, pText) Then
                                    panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = gMuestraBotonSugerenciaReubicacion
                                    Exit Sub
                                End If
                            End If
                        End If
                    Else
                        Notify(pResult, True)
                    End If

                    xset = xserv.GET_LICENSE_DETAIL(gLicenseID, pResult, GlobalEnviroment)
                    If pResult = "OK" Then

                        Dim ingresaMt2 As Boolean = False
                        If pValidar Then
                            Dim dt As DataSet
                            pResult = ""

                            Dim xservInfo As New WMS_InfoTrans.WMS_InfoTrans
                            Dim xservInventory As New WMS_InfoInventory.WMS_InfoInventory

                            If gCurrentTransactionType <> gTRANS_TYPE.REALLOC_PARTIAL Then
                                xservInventory.ValidateLocationForStorage(ScanData, GlobalUserID, gTaskId, gLicenseID, pResult, GlobalEnviroment)
                                If pResult <> "OK" Then
                                    Notify(pResult, True)
                                    Return
                                End If
                            End If

                            dt = xservInfo.GET_LOCATION(ScanData, pResult, GlobalEnviroment)

                            If pResult = "OK" Then
                                If dt.Tables(0).Rows.Count > 0 Then
                                    If dt.Tables(0).Rows(0)("SPOT_TYPE").ToString().Equals("PISO") Then
                                        Dim mt2Dispo As Decimal = 0
                                        If gCurrentLocation = ScanData Then
                                            mt2Dispo = gUsedMt2
                                        Else
                                            mt2Dispo = Decimal.Parse(dt.Tables(0).Rows(0)("MAX_MT2_OCCUPANCY").ToString()) - Decimal.Parse(dt.Tables(0).Rows(0)("MT2_USED").ToString())
                                        End If

                                        panelRecFiscalStep2.LBL_LOCATION.Tag = ScanData
                                        panelRecFiscalStep2.LBL_LOCATION.Text = "Ubicación " + ScanData
                                        panelRecFiscalStep2.lblMT2.Visible = True
                                        panelRecFiscalStep2.txtMT2.Visible = True
                                        panelRecFiscalStep2.txtMT2.Text = mt2Dispo
                                        panelRecFiscalStep2.txtMT2.Tag = mt2Dispo
                                        panelRecFiscalStep2.btnStatus.Tag = "0"
                                        panelRecFiscalStep2.btnStatus.Text = "OK"
                                        panelRecFiscalStep2.btnStatus.Visible = True
                                        ingresaMt2 = True
                                    End If
                                End If
                            Else
                                Notify(pResult, True)
                                Return
                            End If

                        End If

                        If Not ingresaMt2 Then


                            pSKUs_processed = 0
                            pSKUs_not_processed = 0

                            If gCurrentTransactionType = gTRANS_TYPE.INICIALIZACION_GENERAL Then
                                gPoliza = String.Empty
                            End If

                            For Each xrow As DataRow In xset.Tables(0).Rows
                                Dim fechaLote As Date = Nothing
                                If Not xrow("DATE_EXPIRATION") Is DBNull.Value Then
                                    fechaLote = xrow("DATE_EXPIRATION")
                                End If
                                Dim lote As String = Nothing
                                If Not xrow("BATCH") Is DBNull.Value Then
                                    lote = xrow("BATCH")
                                End If

                                If ProcessLicense(gCurrentTransName, xrow("LICENSE_ID"), xrow("QTY"), xrow("BARCODE_ID").ToString, xrow("MATERIAL_ID").ToString, xrow("COMMENTS"), "", ScanData, gClientOwner, xrow("STATUS").ToString, pTransMT2, xrow("VIN"), xrow("SERIAL"), lote, fechaLote, pResult) Then
                                    pSKUs_processed += 1
                                Else
                                    pSKUs_not_processed += 1
                                End If
                            Next

                            If pSKUs_not_processed >= 1 Then
                                panelRecFiscalStep2.btnStatus.Tag = "1"
                                Notify("LocationScanned(1): " + pResult + " " & pSKUs_not_processed & " SKUs no procesados.", True)
                                panelRecFiscalStep2.btnStatus.Visible = False
                                panelRecFiscalStep2.LBL_LOCATION.Tag = ""
                                panelRecFiscalStep2.LBL_LOCATION.Text = ""
                                panelRecFiscalStep2.txtMT2.Visible = False
                                panelRecFiscalStep2.txtMT2.Tag = 0
                                panelRecFiscalStep2.txtMT2.Text = "0"
                            Else
                                panelRecFiscalStep2.LBL_LOCATION.Text = "Ubicación " + ScanData
                                panelRecFiscalStep2.btnStatus.Tag = "0"
                                panelRecFiscalStep2.btnStatus.Text = "OK"
                                panelRecFiscalStep2.btnStatus.Visible = True
                            End If
                        End If
                    Else
                        Notify("LocationScanned:" + pResult, True)
                    End If
            End Select

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify(ex.Message, True)
        Finally

        End Try
    End Sub
    'Sub BarcodeIsScanned(ByVal scanDataCollection As ScanDataCollection)
    'Sub BarcodeIsScanned(ByVal scanDataCollection As String)
    Function MaterialHandleBatch(ByVal value As Integer) As Boolean
        Return value = 1
    End Function



    Sub BarcodeIsScanned(ByVal sender As Object, ByVal e As BarcodeDataEventArg)
        'ojo
        Try
            Dim pResult As String = ""
            Dim xset As DataSet
            'Dim scanData As ScanData = scanDataCollection.GetFirst
            Dim scanData As String = e.BarcodeData.Substring(0, e.BarcodeData.Length - 1)


            Select Case gCurrentScannerService

                Case gSCANNER_SERVICES.LEER_USER_PWD

                    If panelLogin.txtUserID.Text.Length >= 1 Then
                        panelLogin.txtPass.Text = scanData
                        panelLogin.LogInUser()
                    Else
                        Notify("Ingrese el usuario", True)
                        panelLogin.txtUserID.Focus()
                    End If

                Case gSCANNER_SERVICES.LEER_LIC_TRASLADO_ALMGEN
                    LicensedScanned(scanData, pResult)

                Case gSCANNER_SERVICES.LEER_ETIQUETA_REUBICACION
                    LabelScanned(scanData, pResult)

                Case gSCANNER_SERVICES.LEER_LICENCIA_DESPACHO_ALMGEN
                    LicensedScanned(scanData, pResult)

                Case gSCANNER_SERVICES.LEER_POLIZA_EN_AUDIT_SUMM
                    gPoliza = Right(scanData, 9)
                    ReviewPoliza(gPoliza, "", True, pResult)


                Case gSCANNER_SERVICES.LEER_SERIE_AUDITORIA_DESP_FISCAL

                    Dim xproc As New AuditClass
                    panelTransHandler.DetailView1.Items("txtSerie").Visible = True
                    panelTransHandler.DetailView1.Items("txtSerie").Text = scanData
                    panelTransHandler.DetailView1.Items("txtSerie").Label = "Scan Serie(" + scanData + "):"

                    xproc.ProcessTransScanning(scanData)


                Case gSCANNER_SERVICES.LEER_SKU_AUDITORIA_DESP_FISCAL
                    SkuScanned(scanData, pResult)

                Case gSCANNER_SERVICES.LEER_LICENCIA_REALLOC
                    LicensedScanned(scanData, pResult)

                Case gSCANNER_SERVICES.LEER_UBICACION_REALLOC
                    'validar que ubicacion esta en la lista de ubicaciones validas para el wavepicking
                    LocationScanned(True, 0, scanData, pResult)

                Case gSCANNER_SERVICES.LEER_UBICACION_TRASLADO_FISCAL_ALMGEN
                    'validar que ubicacion esta en la lista de ubicaciones validas para el wavepicking

                    'If IsNumeric(panelRecFiscalStep2.txtMT2.Text) Then
                    'If Decimal.Parse(panelRecFiscalStep2.txtMT2.Text) > 0 Then
                    LocationScanned(True, 0, scanData, pResult)
                    'End If
                    'End If

                Case gSCANNER_SERVICES.LEER_UBICACION_DESPACHO_ALMGEN
                    LocationScanned(True, 0, scanData, pResult)

                Case gSCANNER_SERVICES.LEER_SERIE_AUDITORIA_REC_FISCAL

                    Dim xproc As New AuditClass
                    panelTransHandler.DetailView1.Items("txtSerie").Visible = True
                    panelTransHandler.DetailView1.Items("txtSerie").Text = scanData
                    panelTransHandler.DetailView1.Items("txtSerie").Label = "Scan Serie(" + scanData + "):"

                    xproc.ProcessTransScanning(scanData)

                Case gSCANNER_SERVICES.LEER_SKU_AUDITORIA_REC_FISCAL
                    SkuScanned(scanData, pResult)

                Case gSCANNER_SERVICES.LEER_POLIZA_AUDITORIA_REC_FISCAL
                    gPoliza = Right(scanData, 9)
                    ReviewPoliza(gPoliza, "", True, pResult)

                Case gSCANNER_SERVICES.LEER_POLIZA_AUDITORIA_DESP_FISCAL
                    gPoliza = Right(scanData, 9)
                    ReviewPoliza(gPoliza, "", True, pResult)

                Case gSCANNER_SERVICES.LEER_UBICACION_DESPACHO_FISCAL
                    LocationScanned(True, 0, scanData, pResult)

                Case gSCANNER_SERVICES.LEER_LICENCIA_DESPACHO_FISCAL
                    LicensedScanned(scanData, pResult)

                Case gSCANNER_SERVICES.LEER_SKU_DESPACHO_FISCAL
                    'validar que ubicacion esta en la lista de ubicaciones validas para el wavepicking
                    SkuScanned(scanData, pResult)

                Case gSCANNER_SERVICES.LEER_SKU_DESPACHO_ALMGEN
                    'validar que ubicacion esta en la lista de ubicaciones validas para el wavepicking
                    SkuScanned(scanData, pResult)

                Case gSCANNER_SERVICES.LEER_UBICACION_INICIALIZACION

                    'If IsNumeric(panelRecFiscalStep2.txtMT2.Text) Then

                    'If Decimal.Parse(panelRecFiscalStep2.txtMT2.Text) > 0 Then
                    LocationScanned(True, 0, scanData, pResult)
                    panelRecFiscalStep2.LBL_LOCATION.Text = "UBICACION : " + scanData
                    panelRecFiscalStep2.btnStatus.Tag = pResult
                    'End If

                    'End If
                Case gSCANNER_SERVICES.LEER_UBICACION_RECEP_FISCAL
                    LocationScanned(True, 0, scanData, pResult)

                Case gSCANNER_SERVICES.LEER_UBICACION_RECEP_ALMGEN
                    LocationScanned(True, 0, scanData, pResult)

                    panelRecFiscalStep2.LBL_LOCATION.Text = "UBICACION : " + scanData
                    panelRecFiscalStep2.btnStatus.Tag = pResult

                Case gSCANNER_SERVICES.LEER_SERIAL_EN_LOGIS_INFO
                    panelRecFiscalLogisInfo.txtSerie.Text = scanData

                    '**** RECEPCION FISCAL *****
                Case gSCANNER_SERVICES.LEER_SKU_EN_RECEPCION_FISCAL
                    SkuScanned(scanData, pResult)
                    Cursor.Current = Cursors.Default

                Case gSCANNER_SERVICES.LEER_SKU_EN_INICIALIZACION
                    'Dim code As String
                    'code = scanData.Split("/")(1)
                    SkuScanned(scanData, pResult)
                    Cursor.Current = Cursors.Default


                Case gSCANNER_SERVICES.LEER_POLIZA
                    gPoliza = Right(scanData, 9)
                    ReviewPoliza(gPoliza, "", True, pResult)

                Case gSCANNER_SERVICES.LEER_POLIZA_EN_FOTOGRAFIA_BASC
                    panelTakePicture.lblScannedPolicy.Text = Right(scanData, 9)

                    Cursor.Current = Cursors.WaitCursor
                    Dim xserv As New WMS_InfoTrans.WMS_InfoTrans
                    xset = xserv.Get_OP_WMS_POLIZA_HEADER(panelTakePicture.lblScannedPolicy.Text, "", gRegiP, gTipoP, GlobalUserID, True, pResult, GlobalEnviroment)

                    If pResult = "OK" Then

                        StartAcquisition()
                    Else
                        Cursor.Current = Cursors.Default
                        Notify(pResult, True)
                    End If
                    Cursor.Current = Cursors.Default
                    panelTakePicture.Focus()


                Case gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                    Dim xgrid As New SmartGridClass

                    panelInfoHandlerTree.txtInputedData.Text = Mid(scanData, 1, InStr(scanData, "-") - 1) 'cambio H
                    gCurrentLicenseID = CInt(panelInfoHandlerTree.txtInputedData.Text)

                    'If Not xgrid.Populate_Inv_x_License(CInt(panelInfoHandler.txtInputedData.Text), pResult) Then  cambio H
                    If Not xgrid.Populate_Inv_x_License_Tree(CInt(panelInfoHandlerTree.txtInputedData.Text), pResult) Then
                        Notify(pResult, True)
                    Else
                        'panelInfoHandler.AdvancedList_Default.SelectedTemplateIndex = 1
                        'panelInfoHandler.AdvancedList_Default.FooterRow.TemplateIndex = 2
                        'panelInfoHandler.AdvancedList_Default.FooterRow.SelectedTemplateIndex = 2
                        panelInfoHandlerTree.AdvancedTree_Default.ShowFooter = True
                    End If

                    Cursor.Current = Cursors.Default

                Case gSCANNER_SERVICES.LEER_LICENCIA_REIMPRESION
                    Dim xgrid As New SmartGridClass
                    panelInfoHandler.txtInputedData.Text = Mid(scanData, 1, InStr(scanData, "-") - 1)

                    If Not xgrid.Populate_Inv_x_License(CInt(panelInfoHandler.txtInputedData.Text), pResult) Then
                        Notify(pResult, True)

                    End If
                    Cursor.Current = Cursors.Default


                Case gSCANNER_SERVICES.LEER_CATALOGO_SKU_SEC1
                    Dim xgrid As New SmartGridClass
                    panelInfoHandler.txtInputedData.Text = scanData

                    If Not xgrid.Populate_SKUs_S1(panelInfoHandler.txtInputedData.Text, pResult) Then
                        Notify(pResult, True)
                    End If

                    Cursor.Current = Cursors.Default

                Case gSCANNER_SERVICES.LEER_POLIZA_CONSULTA

                    Dim xgrid As New SmartGridClass
                    panelInfoHandlerTree.txtInputedData.Text = scanData 'cambio H

                    'If Not xgrid.Populate_Inv_x_Poliza(Right(scanData, 9), pResult) Then 'cambio H
                    If Not xgrid.Populate_Inv_x_Poliza_Tree(Right(scanData, 9), pResult) Then
                        Notify(pResult, True)

                    End If
                    Cursor.Current = Cursors.Default

                Case gSCANNER_SERVICES.LEER_SKU_CONSULTA

                    Dim xgrid As New SmartGridClass
                    panelInfoHandlerTree.txtInputedData.Text = scanData  'cambio H
                    If Not xgrid.Populate_Inv_x_SKU_Tree(scanData, pResult) Then
                        Notify(pResult, True)

                    End If
                    Cursor.Current = Cursors.Default

                Case gSCANNER_SERVICES.LEER_UBICACION_CONSULTA

                    Dim xgrid As New SmartGridClass
                    panelInfoHandlerTree.txtInputedData.Text = scanData 'cambio H
                    If Not xgrid.Populate_Inv_x_Loc_Tree(scanData, pResult) Then
                        Notify(pResult, True)

                    End If
                    Cursor.Current = Cursors.Default

                Case gSCANNER_SERVICES.LEER_SKU_REALLOC_PARTIAL
                    SkuScanned(scanData, pResult)
                    Cursor.Current = Cursors.Default


                Case gSCANNER_SERVICES.LEER_UBICACION_OCUPACION
                    Dim xgrid As New SmartGridClass
                    LocationScanned(True, 0, scanData, pResult)
                    Cursor.Current = Cursors.Default
                Case gSCANNER_SERVICES.LEER_CLIENTE_INICIALIZACION
                    gClientOwner = panelTransHandler.DetailView1.Items("ScannedClient").Text
                    panelTransHandler.btn_first.Visible = False
                    panelTransHandler.btn_middle_1.Visible = False
                    panelTransHandler.btn_middle_2.Visible = False
                    panelTransHandler.btn_last.Visible = True
                    panelTransHandler.btn_last.Text = "Inicializar General"
                    panelTransHandler.DetailView1.Items("ScannedClient").Text = scanData
                    gClientOwner = panelTransHandler.DetailView1.Items("ScannedClient").Text
                    ReviewClient(scanData, False, pResult)
                Case gSCANNER_SERVICES.LEER_NUMERO_SERIE_RECEPCION
                    panelMaterialXSerialNumbers.UsuarioEscaneoNumeroDeSerie(scanData)
                Case gSCANNER_SERVICES.LEER_LICENCIA_PARA_MASTER_PACK
                    panelExplodeMasterPack.UiTextoIngresoLicencia.Text = Mid(scanData.ToUpper, 1, InStr(scanData.ToUpper, "-") - 1)
                    panelExplodeMasterPack.UiTextoIngresoLicencia.Tag = Mid(scanData.ToUpper, 1, InStr(scanData.ToUpper, "-") - 1)
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_PARA_MASTER_PACK
                    panelExplodeMasterPack.LimpiarControles()
                Case gSCANNER_SERVICES.LEER_UBICACION_SALIDA_DESPACHO
                    LocationScanned(False, 0, scanData, pResult)
                Case gSCANNER_SERVICES.LEER_SKU_PARA_MASTER_PACK
                    panelExplodeMasterPack.VerificarLicencia(scanData.ToUpper)
                Case gSCANNER_SERVICES.LEER_UBICACION_PARA_REUBICACION_POR_REABASTECIMIENTO
                    LocationScanned(True, 0, scanData, pResult)
                Case gSCANNER_SERVICES.lEER_NUMERO_SERIE_DESPACHO
                    panelSerialNumberProcess.IngresarDeSerie(scanData)
                Case gSCANNER_SERVICES.LEER_NUMERO_SERIE_REUBICACION_PARCIAL
                    gCurrentWavePicking = 0
                    panelSerialNumberProcess.IngresarDeSerie(scanData)
                Case gSCANNER_SERVICES.LEER_CODIGO_DOCUMENTO_RECEPCION
                    panelScanDocument.DocumentScanned(scanData)

            End Select
        Catch ex As Exception

            Cursor.Current = Cursors.Default


        End Try

    End Sub

    Sub btnSetSummary(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadPage("audit_summ", gPanelTitle, False)

    End Sub
    Sub btnReviewSummary(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadPage("audit_summ", gPanelTitle, False)

    End Sub
    Public Sub ReviewClient(ByVal pCode As String, ByVal pReviewImages As Boolean, ByRef pResult As String)

        Cursor.Current = Cursors.WaitCursor

        Dim xserv As New WMS_InfoTrans.WMS_InfoTrans
        Dim xClientsServ As New WMS_Clients.WMS_Clients
        'ojo
        Dim dsClientes As New DataSet
        dsClientes = xClientsServ.SearchPartialClients(pCode, "", pResult, GlobalEnviroment)
        If pResult = "OK" Then
            Cursor.Current = Cursors.Default
            gLicenseID = ""
            gClientOwner = dsClientes.Tables(0).Rows(0)("CLIENT_CODE")
            panelTransHandler.DetailView1.Items("ScannedClient").Text = gClientOwner
            panelTransHandler.DetailView1.Items("ClientName").Text = dsClientes.Tables(0).Rows(0)("CLIENT_NAME")
            panelTransHandler.DetailView1.Items("txtReferencia").SetFocus()
            panelTransHandler.btn_last.Visible = True
            RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
            AddHandler panelTransHandler.btn_last.Click, AddressOf btnContinueInit

        Else
            gLicenseID = ""
            Cursor.Current = Cursors.Default
            panelTransHandler.DetailView1.Items("ClientName").ErrorMessage = pResult
            Notify(pResult, True)
            panelTransHandler.btn_last.Visible = False
            RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
            AddHandler panelTransHandler.btn_last.Click, AddressOf btnContinueInit


        End If

    End Sub

    Public Sub ReviewPoliza(ByVal pPoliza As String, ByVal pNumeroOrden As String, ByVal pReviewImages As Boolean, ByRef pResult As String)

        Cursor.Current = Cursors.WaitCursor

        Dim xserv As New WMS_InfoTrans.WMS_InfoTrans
        Dim xset As DataSet
        'cambio
        Try
            xset = xserv.Get_OP_WMS_POLIZA_HEADER(pPoliza.ToUpper, pNumeroOrden, gRegiP, gTipoP, GlobalUserID, (Not gCurrentTransactionType = gTRANS_TYPE.REALLOC_PARTIAL), pResult, GlobalEnviroment)
            panelTransHandler.DetailView1.Items("ScannedPoliza").Text = pPoliza
            panelTransHandler.DetailView1.Items("txtNumeroOrden").Text = pNumeroOrden
            panelTransHandler.UiPanelControlVisualizaSku.Visible = False

            If gValPoliza Then
                gValPoliza = False
                If pResult = "OK" Then
                    MessageBoxEx.Settings.AutoDefaultResult = False
                    MessageBoxEx.Settings.Background = Color.Green
                    Dim pText() As String = {"SI", "NO"}
                    Cursor.Current = Cursors.Default
                    gPoliza = xset.Tables(0).Rows(0)("CODIGO_POLIZA").ToString
                    gNumeroOrden = xset.Tables(0).Rows(0)("NUMERO_ORDEN").ToString
                    pPoliza = gPoliza
                    panelTransHandler.DetailView1.Items("ScannedPoliza").Text = gPoliza
                    If MessageBoxEx.ShowYesCancel(String.Format("Cambio el código de poliza({0})/número orden({1}). Desea continuar?", pPoliza, gNumeroOrden), True, pText) Then
                        Cursor.Current = Cursors.WaitCursor
                        gCambiarPantPoliza = True
                        If gCurrentTransactionType = gTRANS_TYPE.AUDITORIA_REC_FISCAL Then
                            panelTransHandler.DetailView1.Items("txtContenedor").Visible = True
                            With panelTransHandler
                                CType(.DetailView1.Items("txtContenedor"), Resco.Controls.DetailView.ItemTextBox).Enabled = False

                                If xset.Tables(0).Rows(0)("CONTENEDOR_EN_CONTEO").ToString <> "N/A" Then
                                    panelTransHandler.DetailView1.Items("txtContenedor").Text = xset.Tables(0).Rows(0)("CONTENEDOR_EN_CONTEO").ToString
                                    CType(.DetailView1.Items("txtContenedor"), Resco.Controls.DetailView.ItemTextBox).Enabled = False

                                Else
                                    panelTransHandler.DetailView1.Items("txtContenedor").Text = ""
                                    CType(.DetailView1.Items("txtContenedor"), Resco.Controls.DetailView.ItemTextBox).Enabled = True
                                    panelTransHandler.DetailView1.Items("txtContenedor").SetFocus()
                                End If
                            End With
                        End If
                        Return
                    End If
                End If
            End If


            If pResult = "OK" Then

                'CloseScanner()
                panelTransHandler.btn_first.Visible = False
                panelTransHandler.btn_middle_1.Visible = False
                panelTransHandler.btn_middle_2.Visible = False
                panelTransHandler.btn_last.Visible = False

                With panelTransHandler
                    .DetailView1.Items("ClientName").Label = "Cliente"
                    .DetailView1.Items("ClientName").TextForeColor = Color.White
                    .DetailView1.Items("ClientName").Visible = True
                    .DetailView1.Items("Regimen").Visible = True

                    .DetailView1.Items("ScannedPoliza").Text = xset.Tables(0).Rows(0)("CODIGO_POLIZA").ToString
                    gNumeroOrden = xset.Tables(0).Rows(0)("NUMERO_ORDEN").ToString
                    .DetailView1.Items("txtNumeroOrden").Text = gNumeroOrden

                    .DetailView1.Items("ClientName").Text = xset.Tables(0).Rows(0)("CLIENT_NAME").ToString
                    .DetailView1.Items("ClientName").Tag = xset.Tables(0).Rows(0)("CLIENT_CODE").ToString
                    .DetailView1.Items("Regimen").Text = xset.Tables(0).Rows(0)("WAREHOUSE_REGIMEN").ToString

                    gClientOwner = .DetailView1.Items("ClientName").Tag
                    gCommercialAggrement = xset.Tables(0).Rows(0)("ACUERDO_COMERCIAL").ToString

                    gMyLastLicense = 0
                    gLicenseID = ""
                    .btn_last.Tag = "0"

                    Select Case gCurrentTransactionType

                        Case gTRANS_TYPE.AUDITORIA_REC_SUMM
                            Try
                                .btn_first.Visible = True
                                .btn_middle_1.Visible = False
                                .btn_middle_2.Visible = False
                                .btn_last.Visible = True

                                .btn_first.Text = "Crear Resumen"
                                RemoveAllHandlers(gBUTTON_POSITION.FIRST_BUTTON)
                                AddHandler .btn_first.Click, AddressOf btnSetSummary

                                .btn_last.Text = "Ultimo Resumen"
                                RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
                                AddHandler .btn_last.Click, AddressOf btnReviewSummary

                            Catch ex As Exception

                            End Try


                        Case gTRANS_TYPE.AUDITORIA_DESP_FISCAL
                            Try
                                'ojo
                                .btn_first.Text = "Scanning Series"
                                RemoveAllHandlers(gBUTTON_POSITION.FIRST_BUTTON)
                                AddHandler .btn_first.Click, AddressOf btnAuditScanning

                                .btn_last.Text = "Input Conteo"
                                RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
                                RemoveHandler .btn_last.Click, AddressOf btnReception_Click
                                AddHandler .btn_last.Click, AddressOf btnAuditInput


                                .btn_first.Visible = True
                                .btn_middle_1.Visible = False
                                .btn_middle_2.Visible = False
                                .btn_last.Visible = True

                            Catch ex As Exception

                            End Try


                        Case gTRANS_TYPE.AUDITORIA_REC_FISCAL
                            panelTransHandler.DetailView1.Items("txtContenedor").Visible = False
                            gRegimen = xset.Tables(0).Rows(0)("WAREHOUSE_REGIMEN").ToString
                            Try

                                panelTransHandler.btn_first.Visible = True
                                panelTransHandler.btn_middle_1.Visible = False
                                panelTransHandler.btn_middle_2.Visible = False
                                panelTransHandler.btn_last.Visible = True

                                .btn_first.Text = "Scanning Series"
                                Try
                                    RemoveAllHandlers(gBUTTON_POSITION.FIRST_BUTTON)
                                Catch ex As Exception

                                End Try

                                AddHandler .btn_first.Click, AddressOf btnAuditScanning

                                .btn_last.Text = "Input Conteo"
                                Try
                                    RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
                                Catch ex As Exception

                                End Try

                                AddHandler .btn_last.Click, AddressOf btnAuditInput

                                panelTransHandler.DetailView1.Items("txtContenedor").Visible = True

                                CType(.DetailView1.Items("txtContenedor"), Resco.Controls.DetailView.ItemTextBox).Enabled = False


                                If xset.Tables(0).Rows(0)("CONTENEDOR_EN_CONTEO").ToString <> "N/A" Then
                                    panelTransHandler.DetailView1.Items("txtContenedor").Text = xset.Tables(0).Rows(0)("CONTENEDOR_EN_CONTEO").ToString
                                    CType(.DetailView1.Items("txtContenedor"), Resco.Controls.DetailView.ItemTextBox).Enabled = False

                                Else
                                    panelTransHandler.DetailView1.Items("txtContenedor").Text = ""
                                    CType(.DetailView1.Items("txtContenedor"), Resco.Controls.DetailView.ItemTextBox).Enabled = True
                                    panelTransHandler.DetailView1.Items("txtContenedor").SetFocus()

                                End If

                            Catch ex As Exception
                                'Notify(ex.Message, True)
                            End Try


                        Case gTRANS_TYPE.RECEPCION_ALMGEN
                            If xset.Tables(0).Rows(0)("WAREHOUSE_REGIMEN").ToString <> "GENERAL" Then
                                pResult = "ERROR, Poliza no se encuentra en regimen GENERAL"

                                panelTransHandler.btn_first.Visible = False
                                panelTransHandler.btn_middle_1.Visible = False
                                panelTransHandler.btn_middle_2.Visible = False
                                panelTransHandler.btn_last.Visible = False

                                panelTransHandler.DetailView1.Items("ClientName").Text = pResult
                                panelTransHandler.DetailView1.Items("ClientName").TextForeColor = Color.Red
                                panelTransHandler.DetailView1.Items("ClientName").Label = "ERROR:"
                                gClientOwner = "0"
                                Cursor.Current = Cursors.Default
                                gCurrentReference = pPoliza

                                Exit Sub
                            Else
                                If pReviewImages Then
                                    xset_gallery = xserv.Get_OP_WMS_IMAGENES_POLIZA(pPoliza, pResult, GlobalEnviroment)
                                    If pResult = "OK" Then
                                        .btn_first.Text = "Imagenes BASC(" + xset_gallery.Tables(0).Rows.Count.ToString + ")"

                                        RemoveAllHandlers(gBUTTON_POSITION.FIRST_BUTTON)
                                        AddHandler .btn_first.Click, AddressOf view_photo_gallery
                                    Else
                                        RemoveAllHandlers(gBUTTON_POSITION.FIRST_BUTTON)
                                        .btn_first.Text = "Imagenes BASC(0)"
                                    End If
                                End If
                                RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
                                RemoveHandler panelTransHandler.btn_last.Click, AddressOf btnCompleteTask_Click
                                RemoveHandler panelTransHandler.btn_last.Click, AddressOf btnPrintReadyLabel_Click
                                AddHandler .btn_last.Click, AddressOf btnReception_Click

                                .btn_first.Visible = False
                                .btn_middle_1.Visible = False
                                .btn_middle_2.Visible = False
                                .btn_last.Text = "Iniciar recepción ALMGEN"
                                .btn_last.Visible = True

                            End If

                        Case gTRANS_TYPE.RECEPCION_FISCAL
                            If xset.Tables(0).Rows(0)("WAREHOUSE_REGIMEN").ToString <> "FISCAL" Then
                                pResult = "ERROR, Poliza no se encuentra en regimen FISCAL"
                                panelTransHandler.btn_first.Visible = False
                                panelTransHandler.btn_middle_1.Visible = False
                                panelTransHandler.btn_middle_2.Visible = False
                                panelTransHandler.btn_last.Visible = False
                                panelTransHandler.DetailView1.Items("ClientName").Text = pResult
                                panelTransHandler.DetailView1.Items("ClientName").TextForeColor = Color.Red
                                panelTransHandler.DetailView1.Items("ClientName").Label = "ERROR:"
                                gClientOwner = "0"
                                Cursor.Current = Cursors.Default
                                Exit Sub
                            Else
                                If pReviewImages Then
                                    xset_gallery = xserv.Get_OP_WMS_IMAGENES_POLIZA(pPoliza, pResult, GlobalEnviroment)
                                    If pResult = "OK" Then
                                        .btn_first.Text = "Imagenes BASC(" + xset_gallery.Tables(0).Rows.Count.ToString + ")"

                                        RemoveAllHandlers(gBUTTON_POSITION.FIRST_BUTTON)
                                        AddHandler .btn_first.Click, AddressOf view_photo_gallery
                                    Else
                                        RemoveAllHandlers(gBUTTON_POSITION.FIRST_BUTTON)
                                        .btn_first.Text = "Imagenes BASC(0)"
                                    End If
                                End If
                                .btn_last.Text = "Iniciar recepción"
                                RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
                                RemoveHandler panelTransHandler.btn_last.Click, AddressOf btnCompleteTask_Click
                                RemoveHandler panelTransHandler.btn_last.Click, AddressOf btnPrintReadyLabel_Click
                                AddHandler .btn_last.Click, AddressOf btnReception_Click

                                .btn_first.Visible = False
                                .btn_middle_1.Visible = False
                                .btn_middle_2.Visible = False
                                .btn_last.Visible = True

                            End If
                        Case gTRANS_TYPE.INICIALIZACION
                            panelTransHandler.btn_first.Visible = False
                            panelTransHandler.btn_middle_1.Visible = False
                            panelTransHandler.btn_middle_2.Visible = False
                            panelTransHandler.btn_last.Visible = True

                            .btn_last.Text = "Inicializar"
                            RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
                            AddHandler .btn_last.Click, AddressOf btnContinueInit


                        Case gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL
                            If xset.Tables(0).Rows(0)("WAREHOUSE_REGIMEN").ToString <> "FISCAL" Then
                                pResult = "ERROR, Poliza no se encuentra en regimen GENERAL"
                                panelTransHandler.btn_first.Visible = False
                                panelTransHandler.btn_middle_1.Visible = False
                                panelTransHandler.btn_middle_2.Visible = False
                                panelTransHandler.btn_last.Visible = False
                                panelTransHandler.DetailView1.Items("ClientName").Text = pResult
                                panelTransHandler.DetailView1.Items("ClientName").TextForeColor = Color.Red
                                panelTransHandler.DetailView1.Items("ClientName").Label = "ERROR:"
                                gClientOwner = "0"
                            Else
                                .btn_first.Visible = False
                                .btn_middle_1.Visible = False
                                .btn_middle_2.Visible = False
                                .btn_last.Visible = True

                                .btn_last.Text = "Iniciar Traslado"
                                RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
                                AddHandler .btn_last.Click, AddressOf btnContinueInit

                            End If
                        Case gTRANS_TYPE.REALLOC_PARTIAL
                            .btn_first.Visible = False
                            .btn_middle_1.Visible = False
                            .btn_middle_2.Visible = False
                            .btn_last.Visible = True

                            .btn_last.Text = "Iniciar Reubi. Parcial"


                            Dim xset1 As New DataSet
                            Dim xserv1 As New WMS_InfoInventory.WMS_InfoInventory
                            xset1 = xserv1.GetInventory_ByLicense(gCurrentLicenseID, pResult, GlobalEnviroment)
                            If pResult = "OK" Then
                                .DetailView1.Items("ClientName").Text = xset1.Tables(0).Rows(0)("CLIENT_NAME").ToString
                                .DetailView1.Items("ClientName").Tag = xset1.Tables(0).Rows(0)("CLIENT_OWNER").ToString
                                .DetailView1.Items("Regimen").Text = xset1.Tables(0).Rows(0)("REGIMEN").ToString

                                gClientOwner = xset1.Tables(0).Rows(0)("CLIENT_OWNER").ToString
                                gCommercialAggrement = xset1.Tables(0).Rows(0)("TERMS_OF_TRADE").ToString

                            Else
                                Notify("ReviewPoliza: " + pResult, True)
                            End If

                            'override the info
                            .DetailView1.Items("ClientName").Label = "Cliente(" & gClientOwner & ")"
                            .DetailView1.Items("ClientName").TextForeColor = Color.White
                            .DetailView1.Items("ClientName").Visible = True
                            .DetailView1.Items("Regimen").Visible = True
                            .DetailView1.Items("ScannedPoliza").Text = pPoliza

                            gMyLastLicense = 0
                            gLicenseID = ""
                            .btn_last.Tag = "0"

                            RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
                            AddHandler .btn_last.Click, AddressOf btnContinueInit

                    End Select

                End With
            Else

                panelTransHandler.DetailView1.Items("Regimen").Visible = False
                Select Case gCurrentTransactionType
                    Case gTRANS_TYPE.INICIALIZACION
                        gMyLastLicense = 0
                        gLicenseID = ""
                        panelTransHandler.btn_last.Tag = "0"
                        panelTransHandler.btn_last.Text = "Inicializar"
                        Cursor.Current = Cursors.Default
                        'gClientOwner = "1"
                        Notify(pResult, True)

                        gClientOwner = ""
                        Cursor.Current = Cursors.Default
                        panelTransHandler.btn_first.Visible = False
                        panelTransHandler.btn_middle_1.Visible = False
                        panelTransHandler.btn_middle_2.Visible = False
                        panelTransHandler.btn_last.Visible = False
                        With panelTransHandler
                            .DetailView1.Items("ClientName").Visible = False
                            .DetailView1.Items("Regimen").Visible = False
                            .DetailView1.Items("txtContenedor").Visible = False
                        End With

                        RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
                        AddHandler panelTransHandler.btn_last.Click, AddressOf btnContinueInit
                    Case gTRANS_TYPE.AUDITORIA_DESP_FISCAL
                        gClientOwner = ""
                        Cursor.Current = Cursors.Default
                        panelTransHandler.btn_first.Visible = False
                        panelTransHandler.btn_middle_1.Visible = False
                        panelTransHandler.btn_middle_2.Visible = False
                        panelTransHandler.btn_last.Visible = False
                        With panelTransHandler
                            .DetailView1.Items("ClientName").Visible = False
                            .DetailView1.Items("Regimen").Visible = False
                        End With
                        Notify("ReviewPoliza:" + pResult, True)

                    Case gTRANS_TYPE.AUDITORIA_REC_FISCAL
                        gClientOwner = ""
                        Cursor.Current = Cursors.Default
                        panelTransHandler.btn_first.Visible = False
                        panelTransHandler.btn_middle_1.Visible = False
                        panelTransHandler.btn_middle_2.Visible = False
                        panelTransHandler.btn_last.Visible = False
                        With panelTransHandler
                            .DetailView1.Items("ClientName").Visible = False
                            .DetailView1.Items("Regimen").Visible = False
                            .DetailView1.Items("txtContenedor").Visible = False
                        End With
                        Notify("ReviewPoliza(AUDITORIA_REC_FISCAL): " + pResult, True)

                    Case gTRANS_TYPE.REALLOC_PARTIAL
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                        gNumeroOrden = ""
                        panelTransHandler.Visible = False
                        ShowPanel(panelInfoHandlerTree)
                        Notify("Error al consultar póliza: " + pResult, True)
                        gLastPanelName = "ctrl_Menu"

                        Return

                    Case Else
                        gClientOwner = ""
                        Cursor.Current = Cursors.Default
                        panelTransHandler.btn_first.Visible = False
                        panelTransHandler.btn_middle_1.Visible = False
                        panelTransHandler.btn_middle_2.Visible = False
                        panelTransHandler.btn_last.Visible = False
                        With panelTransHandler
                            .DetailView1.Items("ClientName").Visible = False
                            .DetailView1.Items("Regimen").Visible = False
                        End With
                        Notify("ReviewPoliza, else: " + pResult, True)
                End Select
            End If

            Cursor.Current = Cursors.Default
            panelTransHandler.Visible = True
            panelTransHandler.Refresh()
            panelTransHandler.Focus()

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify("ReviewPoliza:" + ex.Message, True)
        End Try

    End Sub
    Function GetDefaultCustomer()
        Try
            Return ""
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Sub view_photo_gallery(ByVal sender As System.Object, ByVal e As System.EventArgs)
        panelTakePicture.lblScannedPolicy.Tag = gPoliza
        panelTakePicture.lblScannedPolicy.Text = gPoliza.ToString
        panelTakePicture.lblScanPrompt.Text = ""
        ShowGallery(gPoliza)
    End Sub
    Sub SetupCmbToT()
        With cmbLocalToT
            .Text = gCommercialAggrement
            .ListGridLines = True
            .NewLine = True
            .Height = 32

            .FullScreenList = True
            .TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            .TextForeColor = Color.White
            .DroppedDown = False
            .ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
            .LabelWidth = 0
            .LabelHeight = 0
            .Label = ""

        End With


    End Sub

    Private Sub btnReception_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Cursor.Current = Cursors.WaitCursor


            If Not panelTransHandler.DetailView1.Items("ScannedPoliza").Text.Equals(gPoliza) Or Not panelTransHandler.DetailView1.Items("txtNumeroOrden").Text.Equals(gNumeroOrden) Then
                gValPoliza = True
                gCambiarPantPoliza = False
                ReviewPoliza(panelTransHandler.DetailView1.Items("ScannedPoliza").Text, panelTransHandler.DetailView1.Items("txtNumeroOrden").Text, True, "")
                If Not gCambiarPantPoliza Then
                    Return
                End If
            End If

            If gMyLastLicense <> 0 Then

                LoadPage("sku_license", panelTransHandler.btn_last.Text, False)

                With panelTransHandler
                    .DetailView1.Items("txtScannedSKU").Visible = True
                    .DetailView1.Items("Header1").Label = "Licencia en curso: " & gMyLastLicense
                    .DetailView1.Items("Header1").Tag = gMyLastLicense.ToString

                    .btn_first.Visible = False
                    .DetailView1.Items("lblSKUName").Text = ""
                    .DetailView1.Items("txtScannedSKU").Text = "..."
                    .DetailView1.Items("txtScannedSKU").Tag = ""

                    .btn_middle_1.Text = "SKUs(" & .btn_last.Tag & ")"

                    .DetailView1.Items("txtCantidad").Visible = False
                    .DetailView1.Items("UiTextoVinRecepcion").Visible = False
                    .DetailView1.Items("dtFechaExpiracion").Visible = False
                    .DetailView1.Items("txtNumLote").Visible = False
                    .DetailView1.Items("UiTextTone").Visible = False
                    .DetailView1.Items("UiTextCaliber").Visible = False

                    RemoveHandler panelTransHandler.btn_middle_1.Click, AddressOf btnRecords_Click
                    RemoveHandler panelTransHandler.btn_middle_1.Click, AddressOf btnResetAudit_Click

                    AddHandler panelTransHandler.btn_middle_1.Click, AddressOf btnRecords_Click

                    PopulateToTCmb()

                End With
            Else
                Try
                    'gCurrentReference = panelTransHandler.DetailView1.Items("txtReferencia").Text
                Catch ex As Exception

                End Try


                LoadPage("sku_license", "Crear licencia", False)
                panelTransHandler.btn_first.Text = "Generar nueva licencia"
                panelTransHandler.btn_first.Visible = True

                panelTransHandler.btn_middle_1.Visible = False
                panelTransHandler.btn_middle_2.Visible = False
                panelTransHandler.btn_last.Visible = False

                RemoveHandler panelTransHandler.btn_first.Click, AddressOf btnQueryAudit_Click
                RemoveHandler panelTransHandler.btn_first.Click, AddressOf btnAuditScanning
                RemoveHandler panelTransHandler.btn_first.Click, AddressOf view_photo_gallery
                RemoveHandler panelTransHandler.btn_first.Click, AddressOf btnGen_Gen_licence_Click
                AddHandler panelTransHandler.btn_first.Click, AddressOf btnGen_Gen_licence_Click

                If gPanelOption = "MMI_RECEP_FISCAL" OrElse gPanelOption = "MMI_RECEP_ALMGEN" OrElse gPanelOption = "MMI_RECEPTION_BY_DOCUMENT" Then
                    panelTransHandler.btn_last.Visible = True
                    panelTransHandler.btn_last.Text = "Completar tarea"
                    RemoveAllHandlers(gBUTTON_POSITION.MIDDLE_1)
                    RemoveHandler panelTransHandler.btn_middle_1.Click, AddressOf btnVerSkus_Click
                    Dim xserv As New WMS_Materials.WMS_Materials
                    Dim xdTable As DataTable
                    Dim pResult As String = "OK"
                    xdTable = xserv.GetMaterialsReceptionDocumentByTask(gTaskId, GlobalEnviroment, pResult)
                    If Not xdTable Is Nothing Then
                        panelTransHandler.btn_middle_1.Text = "Ver Skus"
                        panelTransHandler.btn_middle_1.Visible = True
                        AddHandler panelTransHandler.btn_middle_1.Click, AddressOf btnVerSkus_Click
                    End If
                    RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
                    AddHandler panelTransHandler.btn_last.Click, AddressOf btnCompleteTask_Click
                End If
            End If
            CloseScanner()
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Notify("btnReception_Click: " + ex.Message, True)
        End Try
    End Sub
    Private Sub PopulateOccupancyLevelsCmb()
        Try
            Dim xserv As New WMS_Settings.WMS_Settings
            Dim xset As DataSet
            Dim pResult As String = ""


            xset = xserv.GetOccupancyLeveles(pResult, GlobalEnviroment)
            If pResult = "OK" Then
                With panelTransHandler
                    With CType(.DetailView1.Items("cmbOccupancyLevel"), Resco.Controls.DetailView.ItemAdvancedComboBox)
                        .DisplayMember = "PARAM_CAPTION"
                        .ValueMember = "NUMERIC_VALUE"
                        .DataSource = xset.Tables(0)
                        .SelectedIndex = 0
                    End With
                End With
            Else
                Beep()
                Notify("PopulateOccupancyLevelsCmb:" + pResult, True)
            End If

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub PopulateToTCmb()
        Try
            Dim xserv As New WMS_InfoTrans.WMS_InfoTrans
            Dim xset As DataSet
            Dim pResult As String = ""


            xset = xserv.GetClient_CommercialAggrements(gClientOwner, pResult, GlobalEnviroment)
            If pResult = "OK" Then
                Dim xitem As Resco.Controls.AdvancedComboBox.ListItem
                Dim existeAcuerdo = False

                With panelTransHandler
                    With CType(.DetailView1.Items("cmbToT"), Resco.Controls.DetailView.ItemAdvancedComboBox)
                        .Text = gCommercialAggrement
                        .DisplayMember = "DESCRIPCION"
                        .ValueMember = "ACUERDO_COMERCIAL"
                        .DataSource = xset.Tables(0)

                        For Each xitem In .Items
                            If xitem("ACUERDO_COMERCIAL") = gCommercialAggrement Then
                                xitem.Selected = True
                                existeAcuerdo = True
                            End If
                        Next
                        If Not existeAcuerdo Then
                            .SelectedIndex = 0
                        End If
                        .Enabled = False
                    End With

                End With

            Else
                Beep()
                Notify("PopulateToTCmb:" + pResult, True)
            End If

        Catch ex As Exception
            Notify("PopulateToTCmb.catch: " + ex.Message, True)
        End Try
    End Sub
    Sub BindData(ByVal xset As DataSet)
        Try
            For Each WaiveRow As DataRow In xset.Tables("MY_WAVES").Rows

                'create a new node
                Dim WaiveNode As BoundNode
                WaiveNode = New BoundNode(0, 0, WaiveRow)

                If (handheld.ToUpper() = "MOTOROLA WINCE") Then
                    panelMyPickingMC92.AdvancedTree1.Nodes.Add(WaiveNode)    ' add it to advancedtree
                Else
                    panelMyPicking.AdvancedTree1.Nodes.Add(WaiveNode)    ' add it to advancedtree
                End If

                Dim skus() As DataRow
                skus = WaiveRow.GetChildRows("SKUS_X_WAVE")
                If skus.Length = 0 Then
                    WaiveNode.HidePlusMinus = True
                End If
                WaiveNode.Collapse()

                ' traverse through the orders
                For Each skusRow As DataRow In skus

                    ' create a node for the order
                    Dim skusNode As BoundNode
                    skusNode = New BoundNode(1, 1, skusRow)
                    WaiveNode.Nodes.Add(skusNode)   ' add it to advancedtree

                    Dim orderDetails() As DataRow
                    orderDetails = skusRow.GetChildRows("LOCATIONS_X_SKUS")
                    If orderDetails.Length = 0 Then
                        skusNode.HidePlusMinus = True
                    End If



                    For Each orderdetailRow As DataRow In orderDetails

                        ' create a node for the orderdetail
                        Dim orderdetailNode As BoundNode
                        orderdetailNode = New BoundNode(2, 2, orderdetailRow)

                        orderdetailNode.HidePlusMinus = True
                        'skusNode.Nodes.Insert(0, orderdetailNode)
                        skusNode.Nodes.Add(orderdetailNode)   ' add it to advancedtree

                    Next
                Next

            Next

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify(ex.Message, True)
        End Try
    End Sub

    Sub BindDataByLocation(ByVal xset As DataSet)
        Try
            For Each WaveRow As DataRow In xset.Tables("LOCATION").Rows
                'create a new node
                Dim WaveNode As BoundNode = New BoundNode(0, 0, WaveRow)

                If (handheld.ToUpper() = "MOTOROLA WINCE") Then
                    panelMyPickingMC92.AdvancedTree1.Nodes.Add(WaveNode)    ' add it to advancedtree
                Else
                    panelMyPicking.AdvancedTree1.Nodes.Add(WaveNode)    ' add it to advancedtree
                End If


                Dim skus() As DataRow
                skus = WaveRow.GetChildRows("LOCATION_X_MATERIAL")
                If skus.Length = 0 Then
                    WaveNode.HidePlusMinus = True
                End If
                WaveNode.Collapse()

                ' traverse through the orders
                For Each skusRow As DataRow In skus

                    ' create a node for the order
                    Dim skusNode As BoundNode = New BoundNode(1, 1, skusRow)
                    WaveNode.Nodes.Add(skusNode)   ' add it to advancedtree

                    Dim orderDetails() As DataRow = skusRow.GetChildRows("MATERIAL_X_TASK")
                    If orderDetails.Length = 0 Then
                        skusNode.HidePlusMinus = True
                    End If

                    For Each orderdetailRow As DataRow In orderDetails

                        ' create a node for the orderdetail
                        Dim orderdetailNode As BoundNode = New BoundNode(2, 2, orderdetailRow)
                        orderdetailNode.HidePlusMinus = True
                        'skusNode.Nodes.Insert(0, orderdetailNode)
                        skusNode.Nodes.Add(orderdetailNode)   ' add it to advancedtree
                    Next
                Next
            Next
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify(ex.Message, True)
        End Try
    End Sub

    Public Sub GetMyCounting()
        Try
            Dim xserv As New WMS_InfoTrans.WMS_InfoTrans

            Dim xset As DataSet
            Dim pResult As String = ""
            Cursor.Current = Cursors.WaitCursor
            xset = xserv.GetMyTasks(GlobalUserID, "GENERAL", pResult, GlobalEnviroment)
            CleanNodes()
            If pResult = "OK" Then
                BindData(xset)
                Cursor.Current = Cursors.Default
            Else
                Beep()
                Cursor.Current = Cursors.Default
                'MessageBox.Show(pResult, "WMS OnePlan(r)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify(ex.Message + " " + Global_WS_HOST + " " + GlobalEnviroment, True)
        End Try
    End Sub

    Public Sub GetTaskByLocation(ByVal typeTask As String)
        Try
            Dim service As New WMS_InfoTrans.WMS_InfoTrans
            Dim dataSet As DataSet
            Dim pResult As String = ""
            Cursor.Current = Cursors.WaitCursor
            dataSet = service.GetTaskByLocation(GlobalUserID, typeTask, pResult, GlobalEnviroment)

            If (handheld.ToUpper() = "MOTOROLA WINCE") Then
                panelMyPickingMC92.AdvancedTree1.Nodes.Clear()
            Else
                panelMyPicking.AdvancedTree1.Nodes.Clear()
            End If

            CleanNodes()
            If pResult = "OK" Then
                BindDataByLocation(dataSet)
                Cursor.Current = Cursors.Default
            Else
                Beep()
                Cursor.Current = Cursors.Default
            End If
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify(ex.Message + " " + Global_WS_HOST + " " + GlobalEnviroment, True)
        End Try
    End Sub

    Public Sub GetMyWavesTree(ByVal pRegimen As String)
        Try
            Dim xserv As New WMS_InfoTrans.WMS_InfoTrans

            Dim xset As DataSet
            Dim pResult As String = ""
            Cursor.Current = Cursors.WaitCursor

            xset = xserv.GetMyTasks(GlobalUserID, pRegimen, pResult, GlobalEnviroment)
            CleanNodes()
            If pResult = "OK" Then
                BindData(xset)
                Cursor.Current = Cursors.Default
            Else
                Beep()
                Cursor.Current = Cursors.Default
                Notify("pRegimen:" + pResult, True)
            End If

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify(ex.Message + " " + Global_WS_HOST + " " + GlobalEnviroment, True)
        End Try
    End Sub

    Public Function GetXmlPathByPickingVisualizationType(ByVal visualizationType As Integer) As String
        Dim typeTask As String = ""
        Select Case gCurrentTransactionType
            Case gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL
                typeTask = "DI"
            Case gTRANS_TYPE.DESPACHO_FISCAL
                typeTask = "*"
            Case gTRANS_TYPE.DESPACHO_GENERAL
                typeTask = "DESPACHO_ALMGEN"
            Case gTRANS_TYPE.REUBICACION_POR_REABASTECIMIENTO
                typeTask = "REUBICACION_POR_REABASTECIMIENTO"
        End Select

        gLocationSpotTarget = String.Empty
        Dim path As String = String.Empty
        Select Case visualizationType
            Case CInt(MobilityScm.Modelo.Tipos.TipoVisualizacionTareasPicking.PorTarea)
                path = GetPickingXmlPath(MobilityScm.Modelo.Tipos.Enums.GetStringValue(MobilityScm.Modelo.Tipos.TipoVisualizacionTareasPicking.PorTarea))
                GetMyWavesTree(typeTask)
            Case CInt(MobilityScm.Modelo.Tipos.TipoVisualizacionTareasPicking.PorUbicacion)
                path = GetPickingXmlPath(MobilityScm.Modelo.Tipos.Enums.GetStringValue(MobilityScm.Modelo.Tipos.TipoVisualizacionTareasPicking.PorUbicacion))
                GetTaskByLocation(typeTask)
        End Select

        Return path
    End Function

    Function GetPickingXmlPath(ByVal type As String) As String
        Return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString + _
                "\ctrls\rtdfiles\" + type + ".xml"
    End Function

    Function StartCounting(ByVal pMethod As String, ByVal pPoliza As String, ByVal pContenedor As String, ByRef pAuditIDCreated As Integer, ByRef pResult As String) As Boolean
        Try
            Dim xserv As New WMS_Trans.WMS_Trans
            Dim pType As String = ""

            Return xserv.AuditStartCounting(GlobalUserID, pPoliza, pContenedor, pMethod, pAuditIDCreated, gPanelOption, pResult, GlobalEnviroment)

        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function
    Public Function RemoveAllHandlers(ByVal pButtonID As gBUTTON_POSITION)
        Try
            With panelTransHandler
                Select Case pButtonID
                    Case gBUTTON_POSITION.FIRST_BUTTON
                        RemoveHandler .btn_first.Click, AddressOf view_photo_gallery
                        RemoveHandler .btn_first.Click, AddressOf btnGen_Gen_licence_Click
                        RemoveHandler .btn_first.Click, AddressOf btnQueryAudit_Click
                        RemoveHandler .btn_first.Click, AddressOf btnAuditScanning
                        RemoveHandler .btn_first.Click, AddressOf btnSetSummary
                        RemoveHandler .btn_first.Click, AddressOf btnReviewSummary
                        RemoveHandler .btn_first.Click, AddressOf UiButtonPrintStatus_Click

                    Case gBUTTON_POSITION.MIDDLE_1
                        RemoveHandler panelTransHandler.btn_middle_1.Click, AddressOf btnRecords_Click
                        RemoveHandler panelTransHandler.btn_middle_1.Click, AddressOf btnResetAudit_Click
                        RemoveHandler panelTransHandler.btn_middle_1.Click, AddressOf btnPrintReadyLabel_Click

                    Case gBUTTON_POSITION.MIDDLE_2
                        RemoveHandler .btn_middle_2.Click, AddressOf btnRePrintLicense_Click
                        RemoveHandler .btn_middle_2.Click, AddressOf btnResetAuditBarcode_Click

                    Case gBUTTON_POSITION.LAST_BUTTON
                        RemoveHandler .btn_last.Click, AddressOf btnTakePicture_Click
                        RemoveHandler .btn_last.Click, AddressOf qty_entered_click
                        RemoveHandler .btn_last.Click, AddressOf btnAuditInput
                        RemoveHandler .btn_last.Click, AddressOf btnContinueInit
                        RemoveHandler .btn_last.Click, AddressOf btnReception_Click
                        RemoveHandler panelTransHandler.btn_last.Click, AddressOf btnCompleteTask_Click
                        RemoveHandler panelTransHandler.btn_last.Click, AddressOf btnPrintReadyLabel_Click

                    Case gBUTTON_POSITION.ALL
                        RemoveAllHandlers(gBUTTON_POSITION.FIRST_BUTTON)
                        RemoveAllHandlers(gBUTTON_POSITION.MIDDLE_1)
                        RemoveAllHandlers(gBUTTON_POSITION.MIDDLE_2)
                        RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
                End Select
            End With
        Catch ex As Exception

        End Try
        Return True
    End Function
    Private Sub btnAuditScanning(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim pAuditCreated As Integer = 0
            Dim pContenedor As String = ""

            gCambiarPantPoliza = False
            If Not panelTransHandler.DetailView1.Items("ScannedPoliza").Text.Equals(gPoliza) Or Not panelTransHandler.DetailView1.Items("txtNumeroOrden").Text.Equals(gNumeroOrden) Then
                gValPoliza = True
                ReviewPoliza(panelTransHandler.DetailView1.Items("ScannedPoliza").Text, panelTransHandler.DetailView1.Items("txtNumeroOrden").Text, True, "")
                If Not gCambiarPantPoliza Then
                    Return
                End If
            End If

            If gCurrentTransactionType = gTRANS_TYPE.AUDITORIA_REC_FISCAL Then
                pContenedor = panelTransHandler.DetailView1.Items("txtContenedor").Text

                If Len(pContenedor) <= 0 Then
                    Notify("Debe ingresar el Contenedor", True)
                    panelTransHandler.DetailView1.Items("txtContenedor").SetFocus()
                    Exit Sub
                End If
            End If

            If gCambiarPantPoliza Then
                gIsSerie = "SI"
                Dim pResult As String = ""
                pMethodAudit = "SCANNING"

                If StartCounting(pMethodAudit, gPoliza, pContenedor, pAuditCreated, pResult) Then
                    CloseScanner()

                    LoadPage("sku_license_audit_scanning", "", False)

                    Select Case gCurrentTransactionType
                        Case gTRANS_TYPE.AUDITORIA_DESP_FISCAL
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_AUDITORIA_DESP_FISCAL
                        Case gTRANS_TYPE.AUDITORIA_REC_FISCAL
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_AUDITORIA_REC_FISCAL
                    End Select

                    RedrawCounting()
                    With panelTransHandler
                        .DetailView1.Items("txtScannedSKU").Visible = True
                        .DetailView1.Items("txtSerie").Visible = False
                        .DetailView1.Items("Header1").Label = "Auditoria Scanning (" & pAuditCreated & ")"
                        .DetailView1.Items("Header1").Tag = pAuditCreated

                    End With
                Else
                    Notify(pResult, True)
                End If
                Exit Sub
            End If

            Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = False
            Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green
            Dim pText() As String = {"SI", "NO"}
            Cursor.Current = Cursors.Default
            If MessageBoxEx.ShowYesCancel("Confirma iniciar conteo tipo SCANNING?", True, pText) Then
                gIsSerie = "SI"
                Dim pResult As String = ""
                pMethodAudit = "SCANNING"

                If StartCounting(pMethodAudit, gPoliza, pContenedor, pAuditCreated, pResult) Then
                    CloseScanner()

                    LoadPage("sku_license_audit_scanning", "", False)

                    Select Case gCurrentTransactionType
                        Case gTRANS_TYPE.AUDITORIA_DESP_FISCAL
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_AUDITORIA_DESP_FISCAL
                        Case gTRANS_TYPE.AUDITORIA_REC_FISCAL
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_AUDITORIA_REC_FISCAL
                    End Select

                    RedrawCounting()
                    With panelTransHandler
                        .DetailView1.Items("txtScannedSKU").Visible = True
                        .DetailView1.Items("txtSerie").Visible = False
                        .DetailView1.Items("Header1").Label = "Auditoria Scanning (" & pAuditCreated & ")"
                        .DetailView1.Items("Header1").Tag = pAuditCreated

                    End With
                Else
                    Notify(pResult, True)
                End If

            End If
        Catch ex As Exception
            Notify("btnAuditScanning: " + ex.Message, True)
        End Try


    End Sub
    Sub RedrawCounting()
        Try
            With panelTransHandler

                .DetailView1.Items("lblSKUName").Text = ""
                .DetailView1.Items("txtScannedSKU").Text = "..."
                .DetailView1.Items("txtScannedSKU").Tag = ""

                .DetailView1.Items("txtScannedSKU").Text = "..."
                .DetailView1.Items("txtScannedSKU").Tag = ""

                .btn_first.Text = "Consulta Conteo"
                .btn_first.Visible = True
                .btn_middle_1.Text = "Limpiar Conteo"
                .btn_middle_1.Visible = True
                .btn_middle_2.Text = "Limpiar SKU"
                .btn_middle_2.Visible = False

                .btn_last.Visible = False
                .btn_last.Text = ""
                .btn_last.Visible = True
                .btn_last.Text = "Foto"

                Try
                    RemoveAllHandlers(gBUTTON_POSITION.ALL)

                Catch ex As Exception

                End Try
                AddHandler panelTransHandler.btn_first.Click, AddressOf btnQueryAudit_Click
                AddHandler panelTransHandler.btn_middle_1.Click, AddressOf btnResetAudit_Click
                AddHandler panelTransHandler.btn_middle_2.Click, AddressOf btnResetAuditBarcode_Click
                AddHandler panelTransHandler.btn_last.Click, AddressOf btnTakePicture_Click

            End With


        Catch ex As Exception

        End Try
    End Sub
    Sub btnSetAuditSumm(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = False
        Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green
        Dim pText() As String = {"SI", "NO"}

        If MessageBoxEx.ShowYesCancel("Confirma el resumen?", True, pText) Then
            Try
                Dim xserv As New WMS_Trans.WMS_Trans
                Dim pResult As String = ""
                Dim pQty1 As Double = 0
                Dim pQty2 As Double = 0
                Dim pQty3 As Double = 0
                Dim pQty4 As Double = 0

                pQty1 = CDbl(panelTransHandler.DetailView1.Items("txtQTY1").Text)
                pQty2 = CDbl(panelTransHandler.DetailView1.Items("txtQTY2").Text)
                pQty3 = CDbl(panelTransHandler.DetailView1.Items("txtQTY3").Text)
                pQty4 = CDbl(panelTransHandler.DetailView1.Items("txtQTY4").Text)

                If xserv.SetReceptionAuditSummary(gCurrentCodigoPoliza, pQty1, pQty2, pQty3, pQty4, GlobalUserID, pResult, GlobalEnviroment) Then
                    Notify("Actualizado Correctamente", False)
                    ShowPanel(panelMenu)
                Else
                    Notify(pResult, True)
                    panelTransHandler.DetailView1.Items("txtQTY1").SetFocus()
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub
    Private Sub btnAuditInput(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Dim pAuditCreated As Integer = 0
            gCambiarPantPoliza = False
            If Not panelTransHandler.DetailView1.Items("ScannedPoliza").Text.Equals(gPoliza) Or Not panelTransHandler.DetailView1.Items("txtNumeroOrden").Text.Equals(gNumeroOrden) Then
                gValPoliza = True
                ReviewPoliza(panelTransHandler.DetailView1.Items("ScannedPoliza").Text, panelTransHandler.DetailView1.Items("txtNumeroOrden").Text, True, "")
                If Not gCambiarPantPoliza Then
                    Return
                End If
            End If

            Dim pContenedor As String = panelTransHandler.DetailView1.Items("txtContenedor").Text

            If gCurrentTransactionType = gTRANS_TYPE.AUDITORIA_REC_FISCAL Then
                If Len(pContenedor) <= 0 Then
                    Notify("Debe ingresar el Contenedor", True)
                    Exit Sub
                End If

            End If

            If gCambiarPantPoliza Then
                gIsSerie = "NO"
                Dim pResult As String = ""
                pMethodAudit = "INPUT"

                If StartCounting(pMethodAudit, gPoliza, pContenedor, pAuditCreated, pResult) Then
                    CloseScanner()
                    'ShowPanel(panelTransHandler)
                    LoadPage("sku_license", panelTransHandler.btn_last.Text, False)
                    RedrawCounting()
                    Select Case gCurrentTransactionType
                        Case gTRANS_TYPE.AUDITORIA_DESP_FISCAL
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_AUDITORIA_DESP_FISCAL
                        Case gTRANS_TYPE.AUDITORIA_REC_FISCAL
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_AUDITORIA_REC_FISCAL
                    End Select

                    With panelTransHandler
                        .DetailView1.Items("txtScannedSKU").Visible = True
                        .DetailView1.Items("Header1").Label = "Auditoria INPUT (" & pAuditCreated & ")"
                        .DetailView1.Items("Header1").Tag = pAuditCreated
                    End With

                Else
                    Notify(pResult, True)
                End If
                Exit Sub
            End If

            Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = False
            Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green
            Dim pText() As String = {"SI", "NO"}

            If MessageBoxEx.ShowYesCancel("Confirma iniciar conteo tipo INPUT?", True, pText) Then

                gIsSerie = "NO"
                Dim pResult As String = ""
                pMethodAudit = "INPUT"

                If StartCounting(pMethodAudit, gPoliza, pContenedor, pAuditCreated, pResult) Then
                    CloseScanner()
                    'ShowPanel(panelTransHandler)
                    LoadPage("sku_license", panelTransHandler.btn_last.Text, False)
                    RedrawCounting()
                    Select Case gCurrentTransactionType
                        Case gTRANS_TYPE.AUDITORIA_DESP_FISCAL
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_AUDITORIA_DESP_FISCAL
                        Case gTRANS_TYPE.AUDITORIA_REC_FISCAL
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_AUDITORIA_REC_FISCAL
                    End Select

                    With panelTransHandler
                        .DetailView1.Items("txtScannedSKU").Visible = True
                        .DetailView1.Items("Header1").Label = "Auditoria INPUT (" & pAuditCreated & ")"
                        .DetailView1.Items("Header1").Tag = pAuditCreated
                    End With

                Else
                    Notify(pResult, True)
                End If

            End If
        Catch ex As Exception
            Notify("btnAuditInput: " + ex.Message, True)
        End Try

    End Sub
    Sub StartSkuLicense()
        Try
            If gMyLastLicense <> 0 Then
                CloseScanner()
                Select Case gCurrentTransactionType

                    Case gTRANS_TYPE.INICIALIZACION
                        LoadPage("sku_license", panelTransHandler.btn_last.Text, False)
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_INICIALIZACION
                    Case gTRANS_TYPE.INICIALIZACION_GENERAL
                        LoadPage("sku_license", panelTransHandler.btn_last.Text, False)
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_INICIALIZACION

                    Case gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL
                        LoadPage("sku_license", panelTransHandler.btn_last.Text, False)
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_LIC_TRASLADO_ALMGEN
                        panelTransHandler.DetailView1.Items("txtCantidad").Text = gCurrentQtyToAlloc.ToString

                    Case gTRANS_TYPE.REALLOC_PARTIAL
                        LoadPage("sku_license", panelTransHandler.btn_last.Text, False)
                        'gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_INICIALIZACION

                End Select

                With panelTransHandler
                    .DetailView1.Items("txtScannedSKU").Visible = True
                    .DetailView1.Items("Header1").Label = "Licencia en curso: " & gMyLastLicense
                    .DetailView1.Items("Header1").Tag = gMyLastLicense.ToString

                    .btn_first.Visible = False
                    .DetailView1.Items("lblSKUName").Text = ""
                    .DetailView1.Items("txtScannedSKU").Text = "..."
                    .DetailView1.Items("txtScannedSKU").Tag = ""

                    .btn_middle_1.Text = "SKUs(" & .btn_last.Tag & ")"

                    RemoveAllHandlers(gBUTTON_POSITION.MIDDLE_1)

                    AddHandler panelTransHandler.btn_middle_1.Click, AddressOf btnRecords_Click


                    Dim xserv As New WMS_InfoTrans.WMS_InfoTrans
                    Dim xset As DataSet
                    Dim pResult As String = ""
                    xset = xserv.GetClient_CommercialAggrements(gClientOwner, pResult, GlobalEnviroment)

                    If pResult = "OK" Then
                        Dim xitem As Resco.Controls.AdvancedComboBox.ListItem
                        With CType(.DetailView1.Items("cmbToT"), Resco.Controls.DetailView.ItemAdvancedComboBox)
                            .Text = gCommercialAggrement
                            .DisplayMember = "DESCRIPCION"
                            .ValueMember = "ACUERDO_COMERCIAL"
                            .DataSource = xset.Tables(0)

                            For Each xitem In .Items
                                If xitem("ACUERDO_COMERCIAL") = gCommercialAggrement Then
                                    xitem.Selected = True
                                End If
                            Next

                        End With
                    Else
                        Beep()
                        Notify(pResult, True)
                    End If


                End With
            Else

                Select Case gCurrentTransactionType

                    Case gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL
                        LoadPage("sku_license", panelTransHandler.btn_last.Text, False)
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_LIC_TRASLADO_ALMGEN

                        panelTransHandler.btn_first.Text = "Generar nueva licencia"
                        panelTransHandler.btn_first.Visible = True
                        panelTransHandler.btn_middle_1.Visible = False
                        panelTransHandler.btn_middle_2.Visible = False
                        panelTransHandler.btn_last.Visible = False

                        RemoveAllHandlers(gBUTTON_POSITION.FIRST_BUTTON)
                        AddHandler panelTransHandler.btn_first.Click, AddressOf btnGen_Gen_licence_Click

                    Case Else
                        LoadPage("sku_license", "Crear licencia", False)
                        panelTransHandler.btn_first.Text = "Generar nueva licencia"
                        panelTransHandler.btn_first.Visible = True
                        panelTransHandler.btn_middle_1.Visible = False
                        panelTransHandler.btn_middle_2.Visible = False
                        panelTransHandler.btn_last.Visible = False

                        RemoveAllHandlers(gBUTTON_POSITION.FIRST_BUTTON)
                        AddHandler panelTransHandler.btn_first.Click, AddressOf btnGen_Gen_licence_Click
                        CloseScanner()

                End Select

                If gPanelOption = "MMI_RECEP_FISCAL" OrElse gPanelOption = "MMI_RECEP_ALMGEN" OrElse gPanelOption = "MMI_RECEPTION_BY_DOCUMENT" Then
                    panelTransHandler.btn_last.Visible = True
                    panelTransHandler.btn_last.Text = "Completar tarea"
                    RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
                    AddHandler panelTransHandler.btn_last.Click, AddressOf btnCompleteTask_Click

                    RemoveAllHandlers(gBUTTON_POSITION.MIDDLE_1)
                    RemoveHandler panelTransHandler.btn_middle_1.Click, AddressOf btnVerSkus_Click
                    Dim xserv As New WMS_Materials.WMS_Materials
                    Dim xdTable As DataTable
                    Dim pResult As String = "OK"
                    xdTable = xserv.GetMaterialsReceptionDocumentByTask(gTaskId, GlobalEnviroment, pResult)
                    If Not xdTable Is Nothing Then
                        panelTransHandler.btn_middle_1.Text = "Ver Skus"
                        panelTransHandler.btn_middle_1.Visible = True
                        AddHandler panelTransHandler.btn_middle_1.Click, AddressOf btnVerSkus_Click
                    End If
                End If

            End If

        Catch ex As Exception
            Notify("btnReception_Click: " + ex.Message, True)
        End Try
    End Sub
    Private Sub btnContinueInit(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If gCurrentTransactionType = gTRANS_TYPE.INICIALIZACION_GENERAL Then
            gPoliza = "" 'IIf(panelTransHandler.DetailView1.Items.Count = 6, panelTransHandler.DetailView1.Items("txtReferencia").Text, "")
            gCurrentReference = IIf(panelTransHandler.DetailView1.Items.Count = 6, panelTransHandler.DetailView1.Items("txtReferencia").Text, "")
            gCommercialAggrement = ""

            panelTransHandler.DetailView1.Items("txtReferencia").Visible = False
            panelTransHandler.DetailView1.Items("txtReferencia").Enabled = False
            panelTransHandler.DetailView1.Refresh()
        Else
            If Not panelTransHandler.DetailView1.Items("ScannedPoliza").Text.Equals(gPoliza) Or Not panelTransHandler.DetailView1.Items("txtNumeroOrden").Text.Equals(gNumeroOrden) Then
                gValPoliza = True
                gCambiarPantPoliza = False
                ReviewPoliza(panelTransHandler.DetailView1.Items("ScannedPoliza").Text, panelTransHandler.DetailView1.Items("txtNumeroOrden").Text, True, "")
                If Not gCambiarPantPoliza Then
                    Return
                End If
            End If
        End If

        StartSkuLicense()
    End Sub
    Private Sub btnSaveSkuOnLic(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If gCurrentTransactionType = gTRANS_TYPE.INICIALIZACION_GENERAL Then

        'End If
        'StartSkuLicense()
    End Sub

    Private Sub btnMostrarUbicacionesSugeridas(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim xgrid As New SmartGridClass
        Dim pResult As String = "OK"
        Dim license As String
        Try
            license = panelTransHandler.DetailView1.Items("txtLicencia").Text
            If license = "" Or license = "..." Then
                Notify("Primero debe escanear la licencia", True)
                Exit Sub
            End If

            If Not xgrid.popularArbolUbicaciones(CInt(license), pResult) Then
                Notify(pResult, True)
                Exit Sub
            End If
            ShowPanel(panelUbicacionesSugeridas)
        Catch ex As Exception
            Notify(pResult, True)
        End Try
    End Sub

    Private Sub mostrarPantallaSkusPorDocumento()
        Dim xgrid As New SmartGridClass
        Dim pResult As String = "OK"
        Try
            If Not xgrid.mostrarPantallaSkusPorTareaRecepcion(CInt(gTaskId), pResult) Then
                If pResult <> "OK" Then
                    Notify(pResult, True)
                End If
                Exit Sub
            End If
        Catch ex As Exception
            Notify(pResult, True)
        End Try
    End Sub

    Private Sub btnVerSkus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrarPantallaSkusPorDocumento()
    End Sub

    Sub ShowGallery(ByVal pPoliza As String)
        Try
            IsVeryFirstPicture = True
            ShowNextPicture()
            ShowPanel(panelBrowsePics)

        Catch ex As Exception
            Notify("ShowGallery: " + ex.Message, True)
        End Try
    End Sub
    Sub btnTakePicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'CloseScanner()
        'StartAcquisition()
        ''SetupScanner()
        'panelTakePicture.lblScannedPolicy.Text = Right(gPoliza, 9)
        'panelTakePicture.lblScanPrompt.Visible = True
        'panelTakePicture.btnEgreso.Visible = False
        'panelTakePicture.btnEgreso.Visible = False
        'panelTakePicture.PictureBox_1.Visible = True

        'ShowPanel(panelTakePicture)
        'panelTakePicture.Focus()
        CloseScanner()
        ShowPanel(panelTomarFoto)
        panelTomarFoto.Handheld = gHandheld
        RemoveHandler panelTomarFoto.Controls(0).KeyUp, AddressOf TomarFoto_KeyUp
        RemoveHandler panelTomarFoto.Controls(1).KeyUp, AddressOf TomarFoto_KeyUp
        AddHandler panelTomarFoto.Controls(0).KeyUp, AddressOf TomarFoto_KeyUp
        AddHandler panelTomarFoto.Controls(1).KeyUp, AddressOf TomarFoto_KeyUp

    End Sub
    Private Sub TomarFoto_KeyUp(ByVal sender As System.Object, ByVal e As Windows.Forms.KeyEventArgs)
        Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
            Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                SaveImageByPoliza()
                SetupScanner()
                ShowPanel(panelTransHandler)
        End Select

    End Sub

    Private Sub SaveImageByPoliza()
        Try
            If panelTomarFoto.NumeroDeFotos = 0 Then
                Return
            End If

            Dim pResult As String = ""
            Dim xserv As New WMS_Polizas.WMS_Polizas

            If Not panelTomarFoto.FotoNumeroUno Is Nothing Then
                If Not xserv.AgregarImagenAPoliza(gPoliza, panelTomarFoto.FotoNumeroUno, GlobalUserID, CInt(panelTransHandler.DetailView1.Items("Header1").Tag), IIf(gPanelOption = "MMI_AUDIT_REC_FISCAL", "RECEPTION", "DISPATCH"), pResult, GlobalEnviroment) Then
                    Cursor.Current = Cursors.Default
                    Notify("SaveFotografia: " + pResult, True)
                    Return
                End If
                If Not panelTomarFoto.FotoNumeroDos Is Nothing Then
                    If Not xserv.AgregarImagenAPoliza(gPoliza, panelTomarFoto.FotoNumeroDos, GlobalUserID, CInt(panelTransHandler.DetailView1.Items("Header1").Tag), IIf(gPanelOption = "MMI_AUDIT_REC_FISCAL", "RECEPTION", "DISPATCH"), pResult, GlobalEnviroment) Then
                        Cursor.Current = Cursors.Default
                        Notify("SaveFotografia: " + pResult, True)
                        Return
                    End If
                    If Not panelTomarFoto.FotoNumeroTres Is Nothing Then
                        If Not xserv.AgregarImagenAPoliza(gPoliza, panelTomarFoto.FotoNumeroTres, GlobalUserID, CInt(panelTransHandler.DetailView1.Items("Header1").Tag), IIf(gPanelOption = "MMI_AUDIT_REC_FISCAL", "RECEPTION", "DISPATCH"), pResult, GlobalEnviroment) Then
                            Cursor.Current = Cursors.Default
                            Notify("SaveFotografia: " + pResult, True)
                            Return
                        End If
                    End If
                End If
            End If

            panelTomarFoto.LimpiarImgVista()
            panelTomarFoto.NumeroDeFotos = 0
            panelTomarFoto.Fotos(0) = Nothing
            panelTomarFoto.Fotos(1) = Nothing
            panelTomarFoto.Fotos(2) = Nothing
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify("btnFotografia: " + ex.Message, True)
        End Try
    End Sub

    Private Sub btnFinishAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim Xserv As New WMS_Trans.WMS_Trans
            Dim pResult As String = ""
            Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = False
            Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green
            Dim pText() As String = {"SI", "NO"}
            If MessageBoxEx.ShowYesCancel("Confirma Finalizar el Conteo?", True, pText) Then
                Cursor.Current = Cursors.WaitCursor
                If Xserv.AuditFinishCounting(CInt(panelTransHandler.DetailView1.Items("Header1").Tag), GlobalUserID, gPanelOption, pResult, GlobalEnviroment) Then
                    Cursor.Current = Cursors.Default
                    ShowPanel(panelMenu)
                Else
                    Cursor.Current = Cursors.Default
                    Notify("btnFinishAudit_Click: " + pResult, True)
                End If

            End If

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify("btnFinishAudit_Click: " + ex.Message, True)
        End Try
    End Sub
    Private Sub btnResetAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim Xserv As New WMS_Trans.WMS_Trans
            Dim pResult As String = ""

            Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = False
            Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green
            Dim pText() As String = {"SI", "NO"}
            If MessageBoxEx.ShowYesCancel("Confirma Resetear el Conteo Completo?", True, pText) Then
                Cursor.Current = Cursors.WaitCursor
                If Xserv.AuditResetCounting(CInt(panelTransHandler.DetailView1.Items("Header1").Tag), "*", gPanelOption, pResult, GlobalEnviroment) Then
                    Cursor.Current = Cursors.Default
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA

                    ShowPanel(panelInfoHandler)
                    LoadPage("info_audit_query", "", False)
                    panelInfoHandler.AdvancedList_Default.ShowFooter = False
                    Dim xgrid As New SmartGridClass
                    If Not xgrid.Populate_AuditQuery(CInt(panelTransHandler.DetailView1.Items("Header1").Tag), pResult) Then
                        Notify(pResult, True)
                    End If

                    Cursor.Current = Cursors.Default

                End If

            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnResetAuditBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim Xserv As New WMS_Trans.WMS_Trans
            Dim pResult As String = ""

            Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = False
            Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green
            Dim pText() As String = {"SI", "NO"}

            If MessageBoxEx.ShowYesCancel("Confirma Resetear SKU?", True, pText) Then
                Cursor.Current = Cursors.WaitCursor

                If Xserv.AuditResetCounting(CInt(panelTransHandler.DetailView1.Items("Header1").Tag), panelTransHandler.DetailView1.Items("txtScannedSKU").Text, gPanelOption, pResult, GlobalEnviroment) Then
                    Cursor.Current = Cursors.Default
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA

                    ShowPanel(panelInfoHandler)
                    LoadPage("info_audit_query", "", False)
                    panelInfoHandler.AdvancedList_Default.ShowFooter = False
                    Dim xgrid As New SmartGridClass
                    If Not xgrid.Populate_AuditQuery(CInt(panelTransHandler.DetailView1.Items("Header1").Tag), pResult) Then
                        Notify(pResult, True)
                    End If

                    Cursor.Current = Cursors.Default
                Else
                    Notify(pResult, True)
                End If
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub btnQueryAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Cursor.Current = Cursors.WaitCursor
            ShowPanel(panelInfoHandler)

            LoadPage("info_audit_query", "...", False)
            Cursor.Current = Cursors.WaitCursor
            panelInfoHandler.AdvancedList_Default.ShowFooter = False
            Dim xgrid As New SmartGridClass
            Dim pResult As String = ""
            If Not xgrid.Populate_AuditQuery(CInt(panelTransHandler.DetailView1.Items("Header1").Tag), pResult) Then
                Notify(pResult, True)
            End If

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            Notify("btnQueryAudit_Click: " + ex.Message, True)
        End Try
    End Sub


    Private Sub btnRecords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim xserv As New WMS_Materials.WMS_Materials
        Dim xdTable As DataTable
        Dim presult As String = "OK"
        Try
            If gCurrentTransactionType = gTRANS_TYPE.REALLOC_PARTIAL Then
                'cuando es reubicacion parcial operamos la funcionalidad anterior
                mostrarRegistrosRecepcion()
                Exit Sub
            End If

            xdTable = xserv.GetMaterialsReceptionDocumentByTask(gTaskId, GlobalEnviroment, presult)
            If xdTable Is Nothing Then
                'cuando no hay materiales mostramos inmediatamente los materiales en recepcion
                mostrarRegistrosRecepcion()
            Else
                'si encontramos materiales mostramos panel para que el usuario elija si quiere
                'ver materiales recepcionados o materiales por documento
                panelTransHandler.UiPanelControlVisualizaSku.Visible = True
                RemoveHandler panelTransHandler.UiBotonVerSkus.Click, AddressOf btnSeleccionarOpcionSkusRecepcionGeneral
                AddHandler panelTransHandler.UiBotonVerSkus.Click, AddressOf btnSeleccionarOpcionSkusRecepcionGeneral
            End If
        Catch ex As Exception
            presult = ex.Message
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub btnSeleccionarOpcionSkusRecepcionGeneral(ByVal sender As System.Object, ByVal e As System.EventArgs)
        panelTransHandler.UiPanelControlVisualizaSku.Visible = False
        If panelTransHandler.UiRadioRecepcionados.Checked Then
            mostrarRegistrosRecepcion()
        Else
            mostrarPantallaSkusPorDocumento()
        End If
    End Sub

    Private Sub mostrarRegistrosRecepcion()
        Try

            Dim xservInfoTrans As New WMS_InfoTrans.WMS_InfoTrans
            Dim pResult As String = ""
            Dim xgrid As New SmartGridClass
            Dim result = xservInfoTrans.ObtenerTipoDeRecepcion(gTaskId, GlobalEnviroment, pResult)

            gCurrentScannerService = -1
            If result = "INVOICE" Then
                panelDetalleDevoluciones.CargarListaDetalle(gTaskId)
                ShowPanel(panelDetalleDevoluciones)
            Else

                ShowPanel(panelInfoHandlerTree)
                LoadPage("info_inv_x_lic_tree", "Inv x Lic", False)
                If Not xgrid.Populate_Inv_x_License_Tree(gMyLastLicense, pResult) Then

                End If

                panelInfoHandlerTree.AdvancedTree_Default.ShowFooter = False
                panelInfoHandlerTree.txtInputedData.Enabled = False
            End If

            Cursor.Current = Cursors.Default
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGen_Gen_licence_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Dim pResult As String = ""
            Dim pLastLicense As Integer = 0

            PopulateToTCmb()
            PopulateToTCmbWithStates()
            'cambio

            If gCurrentTransactionType = gTRANS_TYPE.RECEPCION_ALMGEN OrElse gCurrentTransactionType = gTRANS_TYPE.RECEPCION_FISCAL Then
                Dim xserbInfoTrans As New WMS_InfoTrans.WMS_InfoTrans
                Dim result As DataTable
                result = xserbInfoTrans.ValidateTaskStatus(GlobalUserID, gTaskId, 0, 0, 0, "TAREA_RECEPCION", GlobalEnviroment, pResult)
                If pResult <> "OK" OrElse result.Rows(0)(0) <> 1 Then
                    Notify(IIf(pResult = "OK", result.Rows(0)(1).ToString(), pResult), True)
                    Return
                End If
            End If

            gCurrentCodigoPoliza = ""

            pResult = String.Empty
            If GenerateLicense(pLastLicense, IIf(gCurrentTransactionType = gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL, "GENERAL", gRegimen), pResult) Then

                panelTransHandler.DetailView1.Items("Header1").Label = "Nueva Licencia: " + pLastLicense.ToString
                panelTransHandler.DetailView1.Items("Header1").Tag = pLastLicense.ToString
                gMyLastLicense = pLastLicense
                gLicenseID = pLastLicense.ToString


                panelTransHandler.btn_first.Visible = True
                panelTransHandler.btn_middle_1.Visible = True
                panelTransHandler.btn_middle_2.Visible = True
                panelTransHandler.btn_last.Visible = True


                Select Case gCurrentTransactionType
                    Case gTRANS_TYPE.INICIALIZACION
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_INICIALIZACION
                    Case gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_INICIALIZACION
                        SkuScanned(gCurrentSKUPicking, pResult)
                        panelTransHandler.DetailView1.Items("txtCantidad").Text = gCurrentQtyToAlloc.ToString
                    Case gTRANS_TYPE.REALLOC_PARTIAL
                        panelTransHandler.btn_last.Visible = False
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_REALLOC_PARTIAL
                    Case gTRANS_TYPE.INICIALIZACION_GENERAL
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_INICIALIZACION
                    Case Else
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_RECEPCION_FISCAL
                End Select



                panelTransHandler.btn_first.Text = "Imprimir Estado"
                RemoveAllHandlers(gBUTTON_POSITION.FIRST_BUTTON)
                AddHandler panelTransHandler.btn_first.Click, AddressOf UiButtonPrintStatus_Click

                panelTransHandler.btn_middle_1.Text = "SKUS(0)"
                RemoveHandler panelTransHandler.btn_middle_1.Click, AddressOf btnVerSkus_Click
                RemoveAllHandlers(gBUTTON_POSITION.MIDDLE_1)
                AddHandler panelTransHandler.btn_middle_1.Click, AddressOf btnRecords_Click

                panelTransHandler.btn_middle_2.Text = "Imprimir licencia"
                RemoveAllHandlers(gBUTTON_POSITION.MIDDLE_2)
                AddHandler panelTransHandler.btn_middle_2.Click, AddressOf btnRePrintLicense_Click

                panelTransHandler.btn_last.Text = "Imprimir Etiqueta"
                RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
                AddHandler panelTransHandler.btn_last.Click, AddressOf btnPrintReadyLabel_Click

            Else
                Notify(pResult, True)
                gCurrentLicenseID = 0
                gMyLastLicense = 0
                gLicenseID = 0
            End If
            SetupScanner()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub UiButtonPrintStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim pResult As String = ""
        Dim xprinter As New ZebraPrinter
        Try
            If gDeviceAddress = "" Then
                Notify("Debe seleccionar la impresora móvil", True)
                ShowPanel(panelSetupPrinter)
                Exit Sub
            End If
            Dim nameStatus As String = CType(panelTransHandler.DetailView1.Items("UiListaEstado"), Resco.Controls.DetailView.ItemAdvancedComboBox).Value

            If String.IsNullOrEmpty(nameStatus) Then
                Notify("Tiene que seleccionar un estado.", True)
                Exit Sub
            End If


            xprinter.PrintStatusByMaterial(nameStatus, GlobalUserID, If(gTaskId Is Nothing Or gTaskId = "", -1, CInt(gTaskId)), gClientOwner)

        Catch ex As Exception
            Notify("Error al imprimir estado: " + ex.Message & vbNewLine & ex.StackTrace, True)

        End Try
    End Sub

    Public Function GenerateLicense(ByRef pLastLicense As Integer, ByVal pREGIMEN As String, ByRef pResult As String) As Boolean
        Try

            Dim xserv As New WMS_Polizas.WMS_Polizas
            'Return xserv.CrearLicencia(gCurrentReference, GlobalUserID, pLastLicense, gClientOwner, pREGIMEN, pResult, GlobalEnviroment)
            Dim exito As Boolean = xserv.CrearLicencia(gPoliza, GlobalUserID, pLastLicense, gClientOwner, pREGIMEN, If(gTaskId Is Nothing Or gTaskId = "", -1, CInt(gTaskId)), pResult, GlobalEnviroment)

            If pResult.Contains("Tarea ya fue asinada a otro operador") Then

                Select Case gPanelOption
                    Case "MMI_RECEP_FISCAL"
                        gTaskId = Nothing
                        gRegimen = "FISCAL"
                        gCurrentScannerService = -1
                        gCurrentTransactionType = gTRANS_TYPE.RECEPCION_FISCAL
                        ShowPanel(panelMyReception)
                        LoadPage("reception_task", gPanelTitle, False)
                    Case "MMI_RECEP_ALMGEN"
                        gTaskId = Nothing
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                        gCurrentTransactionType = gTRANS_TYPE.RECEPCION_ALMGEN
                        ShowPanel(panelMyReception)
                        gRegimen = "GENERAL"
                        LoadPage("reception_task", gPanelTitle, False)
                End Select
            End If
            Return exito

        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub StartAcquisition()
        'Dim xResult As IMGResults

        Try
            'panelTakePicture.lblScanPrompt.Visible = False
            'panelTakePicture.btnIngreso.Visible = True
            'panelTakePicture.btnEgreso.Visible = True
            'panelTakePicture.PictureBox_1.Visible = True

            'xImager.Enabled()
            'xImager.Config.Activators.FreezeTimeout = -1
            'xImager.StartAcquisition(panelTakePicture.PictureBox_1)

            'xResult = xImager.CaptureImage()

        Catch ex As Exception

        End Try
    End Sub

    'Public Sub myOnCapture(ByVal imageData As ImageData)
    Public Sub myOnCapture(ByVal imageData As Object)

        Try
            'If imageData.Results = IMGResults.SUCCESS Then

            '    xImager.CaptureCancel()
            '    xImager.StopViewfinder()
            '    xImager.StopAcquisition()

            '    Cursor.Current = Cursors.WaitCursor
            '    imageDataInBytes = imageData.MemoryStream.GetBuffer()

            '    panelTakePicture.PictureBox_1.Image = imageData.GetBitmap()
            '    panelTakePicture.PictureBox_1.Dock = DockStyle.Fill

            '    Cursor.Current = Cursors.Default

            'Else
            '    MessageBox.Show(imageData.Results.ToString())
            '    xImager.CaptureImage()
            'End If

        Catch ex As Exception

        End Try

    End Sub
    Function OpenPrinterConnection(ByVal pDeviceAddress As String) As Boolean
        Try
            If Not gIsPrinterConnected Then
                'm_PrinterConnection = Connection_Bluetooth32Feet.CreateClient(pDeviceAddress)
                'm_PrinterConnection.Open()
            End If
            gIsPrinterConnected = False 'm_PrinterConnection.IsOpen
            'Return m_PrinterConnection.IsOpen
            Return False

        Catch ex As Exception
            ' MessageBoxEx.Show("OpenPrinterConnection: " + ex.Message, "WMS OnePlan(r)", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return False
        End Try

    End Function
    Private Sub btnRePrintLicense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PrintLicence(False)

    End Sub

    Private Sub btnPrintReadyLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Dim xprinter As New ZebraPrinter
            Dim pResult As String = ""
            Dim service As New WMS_InfoTrans.WMS_InfoTrans
            Dim tablaConsulta As DataTable
            Select Case gCurrentTransactionType
                Case gTRANS_TYPE.RECEPCION_ALMGEN, gTRANS_TYPE.RECEPCION_FISCAL
                    tablaConsulta = service.GetReceptionTag(gTaskId, GlobalUserID, GlobalEnviroment, pResult)
                    xprinter.ImprimirEtiquetaOperacion(tablaConsulta.Rows(0)("TASK_SUBTYPE").ToString(), tablaConsulta.Rows(0)("WAREHOUSE_SOURCE").ToString(), _
                                                       tablaConsulta.Rows(0)("LOGIN_NAME").ToString(), Convert.ToDateTime(tablaConsulta.Rows(0)("DATE_TIME")), _
                                                       tablaConsulta.Rows(0)("CLIENT_NAME").ToString(), tablaConsulta.Rows(0)("CLIENT_CODE").ToString(), _
                                                       tablaConsulta.Rows(0)("TASK_ID").ToString(), tablaConsulta.Rows(0)("CODIGO_POLIZA").ToString(), "L-" + gLicenseID)
                Case gTRANS_TYPE.INICIALIZACION, gTRANS_TYPE.INICIALIZACION_GENERAL
                    xprinter.ImprimirEtiquetaOperacion("INICIALIZACION", String.Empty, _
                                         GlobalUserID, service.GetServerDateTime(), gClientOwner, gClientOwner, String.Empty, "INIALMGEN", gLicenseID)
                Case gTRANS_TYPE.DESPACHO_FISCAL, gTRANS_TYPE.DESPACHO_GENERAL
                    pResult = String.Empty
                    tablaConsulta = service.GetLabel(gCurrentLabel, GlobalEnviroment, pResult)
                    If String.IsNullOrEmpty(pResult) Then
                        xprinter.PrintLabel(tablaConsulta.Rows(0)("CLIENT_CODE").ToString(), tablaConsulta.Rows(0)("CLIENT_NAME").ToString(), _
                                                       tablaConsulta.Rows(0)("REGIMEN").ToString(), gCurrentLabel, tablaConsulta.Rows(0)("STATE_CODE").ToString(), tablaConsulta.Rows(0)("WAVE_PICKING_ID").ToString())
                    Else
                        Notify(pResult, True)
                    End If
            End Select
        Catch ex As Exception
            Notify("PrintReadyLabel: " + ex.Message & vbNewLine & ex.StackTrace, True)
        End Try
    End Sub

    Private Sub btnCompleteTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Dim pText() As String = {"SI", "NO"}
            Dim pResult As String = String.Empty

            If gCurrentTransactionType = gTRANS_TYPE.RECEPCION_ALMGEN OrElse gCurrentTransactionType = gTRANS_TYPE.RECEPCION_FISCAL Then
                Dim xserbInfoTrans As New WMS_InfoTrans.WMS_InfoTrans
                Dim result As DataTable
                result = xserbInfoTrans.ValidateTaskStatus(GlobalUserID, gTaskId, 0, 0, 0, "TAREA_RECEPCION", GlobalEnviroment, pResult)
                If pResult <> "OK" OrElse result.Rows(0)(0) <> 1 Then
                    Notify(IIf(pResult = "OK", result.Rows(0)(1).ToString(), pResult), True)
                    Return
                End If
            End If


            If MessageBoxEx.ShowYesCancel(String.Format("Estará finalizando la tarea de recepcíón para el codigo de poliza({0})/número orden({1}). Desea continuar?", gPoliza, gNumeroOrden), True, pText) Then
                Cursor.Current = Cursors.WaitCursor
                CloseScanner()
                ShowPanel(panelMenu)

                Dim xserv As New WMS_Trans.WMS_Trans
                xserv.ActualizarEstadoTareaDeRecepcion(gPoliza, GlobalUserID, gRegimen, "COMPLETED", Convert.ToUInt32(gTaskId), GlobalEnviroment, pResult)

                If pResult <> "OK" Then
                    Notify(pResult, True)
                End If
                Select Case gPanelOption
                    Case "MMI_RECEP_FISCAL"
                        gTaskId = Nothing
                        gRegimen = "FISCAL"
                        gCurrentScannerService = -1
                        gCurrentTransactionType = gTRANS_TYPE.RECEPCION_FISCAL
                        ShowPanel(panelMyReception)
                        LoadPage("reception_task", gPanelTitle, False)
                    Case "MMI_RECEP_ALMGEN"
                        gTaskId = Nothing
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                        gCurrentTransactionType = gTRANS_TYPE.RECEPCION_ALMGEN
                        ShowPanel(panelMyReception)
                        gRegimen = "GENERAL"
                        LoadPage("reception_task", gPanelTitle, False)
                End Select
                'RemoveHandler panelTransHandler.btn_last.Click, AddressOf btnCompleteTask_Click
                gTaskId = Nothing
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
        Cursor.Current = Cursors.Default


    End Sub

    Public Function PrintLicence(ByVal isRePrinted As Boolean) As Boolean
        Dim pResult As String = ""
        Dim xprinter As New ZebraPrinter
        Try
            If gDeviceAddress = "" Then
                Notify("Debe seleccionar la impresora movil", True)
                ShowPanel(panelSetupPrinter)
                Exit Function
            End If
            xprinter.PrintLicense(isRePrinted, 0, True)
            Return True
        Catch ex As Exception

            Notify("(1)PrintLicence: " + ex.Message & vbNewLine & ex.StackTrace, True)
            Return False
        End Try

    End Function
    Sub PrintSKULabel(ByVal pSKU As String, ByVal pSKUName As String)
        Try

            If OpenPrinterConnection(gDeviceAddress) Then
                Dim pResult As String = ""

                Dim xx1 As New WMS_Settings.WMS_Settings
                Dim xset1 As New DataSet
                Dim pVerticalMultiplier As Integer = 0
                Dim pHorizontalMultiplier As Integer = 0
                Dim pLeftMargin As Integer = 0

                xset1 = xx1.GetLabelsSetup("SKU", pResult, GlobalEnviroment)


                If pResult = "OK" Then
                    pVerticalMultiplier = xset1.Tables(0).Rows(0)("BC_VERTICAL_MULTIPLIER")
                    pHorizontalMultiplier = xset1.Tables(0).Rows(0)("BC_HORIZONTAL_MULTIPLIER")
                    pLeftMargin = xset1.Tables(0).Rows(0)("BC_LEFT_MARGIN")
                Else
                    Notify(pResult, "ERROR")
                    pVerticalMultiplier = 30
                    pHorizontalMultiplier = 4
                    pLeftMargin = 25
                End If
                xset1 = Nothing

                'Dim docEZ As New DocumentEZ("MF185")
                'Dim xfnt As ONeil.Printer.ParametersEZ

                'xfnt = New ParametersEZ
                'xfnt.Font = "MF107"
                'xfnt.HorizontalMultiplier = 2
                'xfnt.VerticalMultiplier = 3

                'docEZ.WriteText(pSKU, 0, 100, xfnt)

                'xfnt = New ParametersEZ
                'xfnt.Font = "MF107"
                ''xfnt.HorizontalMultiplier = 0
                'xfnt.VerticalMultiplier = 1

                'docEZ.WriteText(Mid(pSKUName, 1, 30), 75, 50, xfnt)
                'docEZ.WriteText(Mid(pSKUName, 31, 60), 120, 50, xfnt)

                'docEZ.WriteHorizontalLine(200, 50, 550, 4)

                'Dim paramEZ = New ParametersEZ
                'paramEZ.HorizontalMultiplier = pHorizontalMultiplier
                'paramEZ.VerticalMultiplier = pVerticalMultiplier
                'paramEZ.Font = "MF185"

                'docEZ.WriteBarCode("BC128", pSKU, 270, pLeftMargin, paramEZ)

                'm_PrinterConnection.Write(docEZ.GetDocumentData())
            Else
                Notify("ERROR, Revise la conexion hacia la impresora movil: " + gDeviceAddress, True)
            End If

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify("PrintLicence: " + ex.Message, True)

        End Try
    End Sub
    Public Function PrintLicence(ByVal pLicenseID As Integer, ByVal isRePrinted As Boolean) As Boolean
        Try

            If OpenPrinterConnection(gDeviceAddress) Then
                Dim pResult As String = ""
                Dim xserv As New WMS_InfoTrans.WMS_InfoTrans
                Dim xserv1 As New WMS_InfoInventory.WMS_InfoInventory
                Dim xset As DataSet
                xset = xserv1.GET_INV_X_LIC(pLicenseID, GlobalUserID, "*", pResult, GlobalEnviroment)

                If pResult = "OK" Then
                    'Dim docEZ As New DocumentEZ("MF185")
                    'Dim xfnt As ONeil.Printer.ParametersEZ

                    'xfnt = New ParametersEZ
                    'xfnt.Font = "MF185"
                    'xfnt.VerticalMultiplier = 50
                    'xfnt.HorizontalMultiplier = 2
                    Dim xPos As Integer = 0

                    ''docEZ.WriteText(My.Resources.LICENSE_OWNER, xPos, 270)
                    ''xPos = 50
                    'docEZ.WriteText(" REGIMEN  : " & xset.Tables(0).Rows(0)("REGIMEN"), xPos, 100)

                    If xset.Tables(0).Rows(0)("REGIMEN") = "FISCAL" Then
                        xPos += 30
                        'docEZ.WriteText(" POLIZA   : " & xset.Tables(0).Rows(0)("CODIGO_POLIZA").ToString, xPos, 100)
                        xPos += 50
                    Else
                        xPos += 40
                    End If

                    'xfnt.VerticalMultiplier = 5
                    'xfnt.HorizontalMultiplier = 4
                    'docEZ.WriteText(pLicenseID, xPos, 100, xfnt)
                    xPos += 100

                    'docEZ.WriteHorizontalLine(xPos, 100, 500, 4)
                    xPos += 40
                    'docEZ.WriteBarCode("BC128", pLastLicense.ToString + "-" + gPoliza.ToString, 200, 150, xfnt)

                    Dim xx1 As New WMS_Settings.WMS_Settings
                    Dim xset1 As New DataSet
                    Dim pVerticalMultiplier As Integer = 0
                    Dim pHorizontalMultiplier As Integer = 0
                    Dim pLeftMargin As Integer = 0

                    If xset.Tables(0).Rows(0)("REGIMEN") = "GENERAL" Then
                        xset1 = xx1.GetLabelsSetup("LIC_ALMGEN", pResult, GlobalEnviroment)
                    Else
                        xset1 = xx1.GetLabelsSetup("LIC_FISCAL", pResult, GlobalEnviroment)
                    End If

                    If pResult = "OK" Then
                        pVerticalMultiplier = xset1.Tables(0).Rows(0)("BC_VERTICAL_MULTIPLIER")
                        pHorizontalMultiplier = xset1.Tables(0).Rows(0)("BC_HORIZONTAL_MULTIPLIER")
                        pLeftMargin = xset1.Tables(0).Rows(0)("BC_LEFT_MARGIN")
                    Else
                        Notify(pResult, "ERROR")
                        pVerticalMultiplier = 30
                        pHorizontalMultiplier = 4
                        pLeftMargin = 25
                    End If
                    xset1 = Nothing

                    'xfnt.Font = "MF185"
                    'xfnt.VerticalMultiplier = pVerticalMultiplier
                    'xfnt.HorizontalMultiplier = pHorizontalMultiplier

                    If xset.Tables(0).Rows(0)("REGIMEN") = "GENERAL" Then
                        'xfnt.IsInverse = True
                        'docEZ.WriteBarCode("BC128", pLicenseID & "-" & xset.Tables(0).Rows(0)("CODIGO_POLIZA").ToString, xPos, pLeftMargin, xfnt)
                    Else
                        'docEZ.WriteBarCodePDF417(gLicenseID & "-" & gCurrentCodigoPoliza, xPos, 100, 6, 1, xfnt)
                        xPos += 50
                    End If

                    If isRePrinted Then
                        'xfnt = New ParametersEZ
                        'xfnt.Font = "MF107"
                        'xfnt.VerticalMultiplier = 1
                        'xfnt.HorizontalMultiplier = 1
                        'xfnt.IsInverse = True
                        If xset.Tables(0).Rows(0)("REGIMEN") = "GENERAL" Then
                            xPos += 165
                        Else
                            xPos += 135
                        End If

                        'docEZ.WriteText("*** RE-IMPRESO ***", xPos, 100, xfnt)
                    End If
                    xPos += 50
                    'docEZ.WriteText(" FEC/HORA : " & xserv.GetServerDateTime(), xPos, 100)
                    xPos += 50

                    'm_PrinterConnection.Write(docEZ.GetDocumentData())
                Else
                    Notify("No existe informacion para esa licencia: " & pLicenseID, True)
                End If
            Else
                Cursor.Current = Cursors.Default
                'Notify("Printer connection failed", True)
                ShowPanel(panelSetupPrinter)

            End If
            Return True
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify("PrintLicence: " + ex.Message, True)
            Return False
        End Try
    End Function

    Sub poliza_entered(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        Try
            If CType(panelTransHandler.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Control.Focused Then

                Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                    Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                        Dim pResult As String = ""
                        gPoliza = panelTransHandler.DetailView1.Items("ScannedPoliza").Text
                        gNumeroOrden = ""
                        panelTransHandler.btn_first.Visible = False
                        panelTransHandler.btn_middle_1.Visible = False
                        panelTransHandler.btn_middle_2.Visible = False
                        panelTransHandler.btn_last.Visible = True
                        ReviewPoliza(gPoliza, gNumeroOrden, False, pResult)

                    Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                        ShowPanel(panelMenu)
                End Select

            End If
        Catch ex As Exception

        End Try

    End Sub

    Sub numero_orden_entered(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        Try
            If CType(panelTransHandler.DetailView1.Items("txtNumeroOrden"), Resco.Controls.DetailView.ItemTextBox).Control.Focused Then

                Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                    Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                        Dim pResult As String = ""
                        gPoliza = ""
                        gNumeroOrden = panelTransHandler.DetailView1.Items("txtNumeroOrden").Text
                        panelTransHandler.btn_first.Visible = False
                        panelTransHandler.btn_middle_1.Visible = False
                        panelTransHandler.btn_middle_2.Visible = False
                        panelTransHandler.btn_last.Visible = True
                        ReviewPoliza(gPoliza, gNumeroOrden, False, pResult)
                    Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                        ShowPanel(panelMenu)
                End Select
            End If
        Catch ex As Exception

        End Try

    End Sub

    Sub serie_entered(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try

            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                    Dim xproc As New AuditClass
                    Dim pScanData As String
                    panelTransHandler.DetailView1.Items("txtSerie").Visible = True
                    pScanData = panelTransHandler.DetailView1.Items("txtSerie").Text
                    panelTransHandler.DetailView1.Items("txtSerie").Label = "Scan Serie(" + pScanData + "):"

                    xproc.ProcessTransScanning(pScanData)

            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Sub client_entered(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        Try
            If CType(panelTransHandler.DetailView1.Items("ScannedClient"), Resco.Controls.DetailView.ItemTextBox).Control.Focused Then
                Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                    Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                        Dim pResult As String = ""
                        gClientOwner = panelTransHandler.DetailView1.Items("ScannedClient").Text
                        panelTransHandler.btn_first.Visible = False
                        panelTransHandler.btn_middle_1.Visible = False
                        panelTransHandler.btn_middle_2.Visible = False
                        panelTransHandler.btn_last.Visible = True
                        panelTransHandler.btn_last.Text = "Inicializar General"

                        ReviewClient(gClientOwner, False, pResult)

                    Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                        ShowPanel(panelMenu)
                End Select
            End If
        Catch ex As Exception
            'Notify(ex.Message, True)
        End Try


    End Sub

    Public Sub LoadPage(ByVal pPageID As String, ByVal pPanelTitle As String, ByVal pValidateExist As Boolean)
        Dim pPageIDPath As String = ""
        Try

            Dim pValidated As Boolean = True

            pPageIDPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString + _
                    "\ctrls\rtdfiles\" + pPageID + ".xml"

            If pValidateExist Then
                If Not File.Exists(pPageIDPath) Then
                    pValidateExist = False
                    pValidated = False
                End If
            End If

            If pValidated Then
                Cursor.Current = Cursors.WaitCursor
                panelTransHandler.UiPanelControlVisualizaSku.Visible = False
                Select Case pPageID
                    Case "audit_summ"
                        gCurrentPage = pPageID
                        panelTransHandler.DetailView1.Items("Header1").Label = pPanelTitle

                        panelTransHandler.Visible = True
                        panelTransHandler.DetailView1.Visible = True
                        LoadDetailViewFromXml(pPageIDPath)

                        With panelTransHandler
                            .btn_last.Visible = True
                            RemoveAllHandlers(gBUTTON_POSITION.FIRST_BUTTON)
                            AddHandler .btn_first.Click, AddressOf btnSetAuditSumm

                            Dim xgrid As New SmartGridClass
                            Dim pResult As String = ""
                            xgrid.Populate_SetAuditLabels(pResult)

                            .btn_first.Visible = False
                            .btn_middle_1.Visible = False
                            .btn_middle_2.Visible = False

                        End With

                    Case "my_waves_tree"
                        Dim typeTask As String = ""
                        Select Case gCurrentTransactionType
                            Case gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL
                                typeTask = "DI"
                            Case gTRANS_TYPE.DESPACHO_FISCAL
                                typeTask = "*"
                            Case gTRANS_TYPE.DESPACHO_GENERAL
                                typeTask = "DESPACHO_ALMGEN"
                            Case gTRANS_TYPE.REUBICACION_POR_REABASTECIMIENTO
                                typeTask = "REUBICACION_POR_REABASTECIMIENTO"
                        End Select
                        gLocationSpotTarget = String.Empty

                        MyPickingLoadXml()
                        'panelMyPicking.AdvancedTree1.LoadXml(GetXmlPathByPickingVisualizationType(panelMyPicking.TipoVisualizacion.Items.SelectedItem.Index))

                        panelTransHandler.DetailView1.Items("Header1").Label = pPanelTitle
                        gCurrentPage = pPageID

                    Case "reception_task"
                        panelMyReception.GetMyReceptionTasks(gRegimen)
                        gRegiP = gRegimen
                        gTipoP = "INGRESO"
                        gCurrentPage = pPageID
                    Case "wave_picking"


                        gCurrentPage = pPageID
                        gTipoP = "EGRESO"
                        panelTransHandler.DetailView1.Items("Header1").Label = pPanelTitle

                        panelTransHandler.Visible = True
                        panelTransHandler.DetailView1.Visible = True
                        LoadDetailViewFromXml(pPageIDPath)

                        With panelTransHandler
                            .DetailView1.Items("Header1").Label = pPanelTitle
                            .DetailView1.Items("txtMt2").Tag = "0"
                            .DetailView1.Items("txtMt2").Text = "0"
                            .DetailView1.Items("txtMt2").Visible = False
                            .btn_last.Visible = False
                            .btn_first.Visible = False
                            .btn_middle_1.Visible = False
                            .btn_middle_2.Visible = False
                        End With


                        If gTRANS_TYPE.REUBICACION_POR_REABASTECIMIENTO <> gCurrentTransactionType Then
                            panelTransHandler.btn_middle_1.Visible = True
                            panelTransHandler.btn_middle_1.Text = "Imprimir Etiqueta"
                            RemoveAllHandlers(gBUTTON_POSITION.MIDDLE_1)
                            AddHandler panelTransHandler.btn_middle_1.Click, AddressOf btnPrintReadyLabel_Click
                        End If
                    Case "counting_tasks"
                        gCurrentPage = pPageID
                        panelTransHandler.DetailView1.Items("Header1").Label = pPanelTitle

                        panelTransHandler.Visible = True
                        panelTransHandler.DetailView1.Visible = True
                        LoadDetailViewFromXml(pPageIDPath)

                        With panelTransHandler
                            .DetailView1.Items("Header1").Label = pPanelTitle
                            .btn_last.Visible = False
                            .btn_first.Visible = False
                            .btn_middle_1.Visible = False
                            .btn_middle_2.Visible = False
                        End With
                        GetMyCounting()

                    Case "init_general"

                        gMyLastLicense = 0
                        panelTransHandler.Visible = False
                        panelTransHandler.DetailView1.Visible = False


                        LoadDetailViewFromXml(pPageIDPath)
                        With panelTransHandler
                            .DetailView1.Items("Header1").Label = pPanelTitle
                            .DetailView1.Items("txtReferencia").Visible = True
                            .DetailView1.Items("txtReferencia").Text = ""

                            .DetailView1.Items("ClientName").Visible = True
                            .DetailView1.Items("ClientName").Text = ""
                            .btn_first.Visible = False
                            .btn_middle_1.Visible = False
                            .btn_middle_2.Visible = False
                            .btn_last.Visible = False
                            .DetailView1.Items("Regimen").Visible = True
                            .Refresh()

                            CType(.DetailView1.Items("ScannedClient"), Resco.Controls.DetailView.ItemTextBox).Enabled = True
                            CType(.DetailView1.Items("ScannedClient"), Resco.Controls.DetailView.ItemTextBox).Label = "Scan/Ingrese Cod.Cliente"
                            .DetailView1.Items("ScannedClient").Text = "C"
                            .DetailView1.Items("ScannedClient").SetFocus()

                            RemoveHandler CType(.DetailView1.Items("ScannedClient"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf client_entered
                            AddHandler CType(.DetailView1.Items("ScannedClient"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf client_entered

                        End With
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_CLIENTE_INICIALIZACION
                        gCurrentPage = pPageID
                        panelTransHandler.Visible = True
                        panelTransHandler.DetailView1.Visible = True
                        leftRelocationComplete = True
                    Case "poliza"
                        panelTransHandler.Visible = False
                        panelTransHandler.DetailView1.Visible = False


                        LoadDetailViewFromXml(pPageIDPath)
                        With panelTransHandler
                            .DetailView1.Items("Header1").Label = pPanelTitle
                            .DetailView1.Items("txtContenedor").Visible = False
                            .DetailView1.Items("txtContenedor").Text = ""

                            .DetailView1.Items("ClientName").Visible = False
                            .DetailView1.Items("ClientName").Text = ""
                            .btn_first.Visible = False
                            .btn_middle_1.Visible = False
                            .btn_middle_2.Visible = False
                            .btn_last.Visible = False
                            .DetailView1.Items("Regimen").Visible = False
                            .Refresh()


                            gRegiP = ""
                            gTipoP = ""

                            Select Case gPanelOption
                                Case "MMI_INICIALIZACION"
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = False
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Enabled = True
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Label = "Scan/Ingrese Poliza"
                                    .DetailView1.Items("ScannedPoliza").Text = ""
                                    .DetailView1.Items("ScannedPoliza").SetFocus()
                                    RemoveHandler CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf poliza_entered
                                    AddHandler CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf poliza_entered
                                    .DetailView1.Items("txtNumeroOrden").SetFocus()
                                    RemoveHandler CType(.DetailView1.Items("txtNumeroOrden"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf numero_orden_entered
                                    AddHandler CType(.DetailView1.Items("txtNumeroOrden"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf numero_orden_entered

                                Case "MMI_AUDIT_REC_FISCAL"
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = False
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Enabled = True
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Label = "Scan/Ingrese Poliza"
                                    .DetailView1.Items("ScannedPoliza").Text = ""
                                    .DetailView1.Items("ScannedPoliza").SetFocus()
                                    RemoveHandler CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf poliza_entered
                                    AddHandler CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf poliza_entered
                                    .DetailView1.Items("txtNumeroOrden").SetFocus()
                                    RemoveHandler CType(.DetailView1.Items("txtNumeroOrden"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf numero_orden_entered
                                    AddHandler CType(.DetailView1.Items("txtNumeroOrden"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf numero_orden_entered

                                    gTipoP = "INGRESO"
                                    leftRelocationComplete = True
                                Case "MMI_RECEP_FISCAL"
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = False
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Enabled = True
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Label = "Scan/Ingrese Poliza"
                                    .DetailView1.Items("ScannedPoliza").Text = ""
                                    .DetailView1.Items("ScannedPoliza").SetFocus()
                                    RemoveHandler CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf poliza_entered
                                    AddHandler CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf poliza_entered
                                    .DetailView1.Items("txtNumeroOrden").SetFocus()
                                    RemoveHandler CType(.DetailView1.Items("txtNumeroOrden"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf numero_orden_entered
                                    AddHandler CType(.DetailView1.Items("txtNumeroOrden"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf numero_orden_entered
                                    gRegiP = "FISCAL"
                                    gTipoP = "INGRESO"
                                Case "MMI_RECEP_ALMGEN", "MMI_RECEPTION_BY_DOCUMENT"
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = False
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Enabled = True
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Label = "Scan/Ingrese Poliza"
                                    .DetailView1.Items("ScannedPoliza").Text = ""
                                    .DetailView1.Items("ScannedPoliza").SetFocus()
                                    RemoveHandler CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf poliza_entered
                                    AddHandler CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf poliza_entered
                                    .DetailView1.Items("txtNumeroOrden").SetFocus()
                                    RemoveHandler CType(.DetailView1.Items("txtNumeroOrden"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf numero_orden_entered
                                    AddHandler CType(.DetailView1.Items("txtNumeroOrden"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf numero_orden_entered

                                    gRegiP = "GENERAL"
                                    gTipoP = "INGRESO"
                                Case "MMI_INV_X_LIC"
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = False
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Enabled = True
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Label = "Scan/Ingrese Poliza"
                                    .DetailView1.Items("ScannedPoliza").Text = ""
                                    .DetailView1.Items("ScannedPoliza").SetFocus()
                                    gTipoP = "INGRESO"
                                    gRegiP = gRegimen

                                Case "MMI_INICIALIZACION_FIS"
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = False
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Enabled = True
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Label = "Scan/Ingrese Poliza"
                                    .DetailView1.Items("ScannedPoliza").Text = ""
                                    .DetailView1.Items("ScannedPoliza").SetFocus()
                                    RemoveHandler CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf poliza_entered
                                    AddHandler CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf poliza_entered

                                    .DetailView1.Items("txtNumeroOrden").SetFocus()
                                    RemoveHandler CType(.DetailView1.Items("txtNumeroOrden"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf numero_orden_entered
                                    AddHandler CType(.DetailView1.Items("txtNumeroOrden"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf numero_orden_entered
                                    gRegiP = "FISCAL"
                                    gTipoP = "INGRESO"
                                    leftRelocationComplete = True
                                Case Else
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).ReadOnly = False
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Enabled = True
                                    CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Label = "Scan/Ingrese Poliza"
                                    .DetailView1.Items("ScannedPoliza").Text = ""
                                    .DetailView1.Items("ScannedPoliza").SetFocus()
                                    RemoveHandler CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf poliza_entered
                                    AddHandler CType(.DetailView1.Items("ScannedPoliza"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf poliza_entered
                                    .DetailView1.Items("txtNumeroOrden").SetFocus()
                                    RemoveHandler CType(.DetailView1.Items("txtNumeroOrden"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf numero_orden_entered
                                    AddHandler CType(.DetailView1.Items("txtNumeroOrden"), Resco.Controls.DetailView.ItemTextBox).Control.KeyUp, AddressOf numero_orden_entered
                                    gTipoP = "EGRESO"
                                    leftRelocationComplete = True
                            End Select

                            Dim infoTransService As New WMS_InfoTrans.WMS_InfoTrans
                            panelTransHandler.btn_first.Visible = False
                            panelTransHandler.btn_middle_1.Visible = False
                            panelTransHandler.btn_middle_2.Visible = False
                            panelTransHandler.btn_last.Visible = False
                            .DetailView1.Items("ClientName").Visible = True
                            .DetailView1.Items("Regimen").Visible = True

                        End With

                        gCurrentPage = pPageID
                        panelTransHandler.Visible = True
                        panelTransHandler.DetailView1.Visible = True

                    Case "sku_license"
                        panelTransHandler.Visible = False
                        panelTransHandler.DetailView1.Visible = False

                        LoadDetailViewFromXml(pPageIDPath)
                        With panelTransHandler
                            .DetailView1.Items("Header1").Label = pPanelTitle
                            .DetailView1.Items("txtScannedSKU").Text = "..."
                            .DetailView1.Items("lblSKUName").Visible = False
                            .DetailView1.Items("lblSKUName").Text = ""
                            .DetailView1.Items("dtFechaExpiracion").Value = Date.Today.Date
                            .DetailView1.Items("UiTextoVinRecepcion").Text = ""

                            .DetailView1.Items("txtCantidad").Visible = False
                            .DetailView1.Items("UiTextoVinRecepcion").Visible = False
                            .DetailView1.Items("dtFechaExpiracion").Visible = False
                            .DetailView1.Items("txtNumLote").Visible = False
                            .DetailView1.Items("UiTextTone").Visible = False
                            .DetailView1.Items("UiTextCaliber").Visible = False

                            .btn_first.Visible = True

                            .btn_middle_1.Visible = True
                            .btn_middle_2.Visible = True



                            Select Case gCurrentTransactionType
                                Case gTRANS_TYPE.AUDITORIA_REC_FISCAL

                                    .DetailView1.Items("txtNumLote").Visible = False
                                    .DetailView1.Items("dtFechaExpiracion").Visible = False
                                    .DetailView1.Items("UiTextoVinRecepcion").Visible = False
                                    .DetailView1.Items("UiTextTone").Visible = False
                                    .DetailView1.Items("UiTextCaliber").Visible = False
                                    .btn_middle_2.Text = "Imprimir Licencia"
                                    RemoveAllHandlers(gBUTTON_POSITION.MIDDLE_2)
                                    AddHandler .btn_middle_2.Click, AddressOf btnRePrintLicense_Click
                                Case gTRANS_TYPE.INICIALIZACION_GENERAL
                                    .btn_last.Text = "OK"
                                    .btn_last.Visible = True
                                    RemoveAllHandlers(gBUTTON_POSITION.LAST_BUTTON)
                                    AddHandler .btn_last.Click, AddressOf btnSaveSkuOnLic
                            End Select



                            .Refresh()
                        End With
                        gCurrentPage = pPageID
                        panelTransHandler.Visible = True
                        panelTransHandler.DetailView1.Visible = True

                    Case "sku_license_audit_scanning"
                        panelTransHandler.Visible = False
                        panelTransHandler.DetailView1.Visible = False

                        LoadDetailViewFromXml(pPageIDPath)
                        With panelTransHandler
                            .DetailView1.Items("Header1").Label = pPanelTitle
                            .DetailView1.Items("txtScannedSKU").Text = "..."
                            .DetailView1.Items("lblSKUName").Visible = False
                            .DetailView1.Items("lblSKUName").Text = ""
                            .Refresh()
                        End With
                        gCurrentPage = pPageID
                        panelTransHandler.Visible = True
                        panelTransHandler.DetailView1.Visible = True

                    Case "complete_license"
                        gCurrentPage = pPageID

                    Case "info_inv_x_lic"
                        Cursor.Current = Cursors.Default
                        panelInfoHandler.AdvancedList_Default.LoadXml(pPageIDPath)
                        gCurrentPage = pPageID
                        panelInfoHandler.Visible = True
                        panelInfoHandler.AdvancedList_Default.Visible = True
                        panelInfoHandler.txtInputedData.Text = ""
                        panelInfoHandler.txtInputedData.Focus()

                    Case "info_inv_x_lic_tree", "info_inv_x_lic_tree_MC92" 'cambio H

                        Cursor.Current = Cursors.Default
                        panelInfoHandlerTree.AdvancedTree_Default.LoadXml(pPageIDPath)

                        Dim handheld As String = String.Empty
                        handheld = UtileriasServicio.UsuarioDeseaObtenerInformacionModelo
                        If (handheld.ToUpper() = "MOTOROLA WINCE") Then
                            ResizeAdvanceTree(panelInfoHandlerTree.AdvancedTree_Default, 0.58)
                        End If

                        gCurrentPage = pPageID
                        panelInfoHandlerTree.Visible = True
                        panelInfoHandlerTree.AdvancedTree_Default.Visible = True
                        panelInfoHandlerTree.txtInputedData.Text = ""
                        panelInfoHandlerTree.txtInputedData.Focus()

                    Case "ivn_x_return"

                        Cursor.Current = Cursors.Default
                        panelInfoHandlerTree.AdvancedTree_Default.LoadXml(pPageIDPath)

                        Dim handheld As String = String.Empty
                        handheld = UtileriasServicio.UsuarioDeseaObtenerInformacionModelo
                        If (handheld.ToUpper() = "MOTOROLA WINCE") Then
                            ResizeAdvanceTree(panelInfoHandlerTree.AdvancedTree_Default, 0.58)
                        End If

                        gCurrentPage = pPageID
                        panelInfoHandlerTree.Visible = True
                        panelInfoHandlerTree.AdvancedTree_Default.Visible = True
                        panelInfoHandlerTree.txtInputedData.Visible = False

                    Case "info_inv_x_poliza"
                        Cursor.Current = Cursors.Default
                        panelInfoHandler.AdvancedList_Default.LoadXml(pPageIDPath)
                        gCurrentPage = pPageID
                        panelInfoHandler.Visible = True
                        panelInfoHandler.AdvancedList_Default.Visible = True
                        panelInfoHandler.txtInputedData.Text = ""
                        panelInfoHandler.txtInputedData.Focus()

                    Case "info_inv_x_poliza_tree", "info_inv_x_poliza_tree_MC92" 'cambio H
                        Cursor.Current = Cursors.Default
                        panelInfoHandlerTree.AdvancedTree_Default.LoadXml(pPageIDPath)
                        gCurrentPage = pPageID
                        panelInfoHandlerTree.Visible = True
                        panelInfoHandlerTree.AdvancedTree_Default.Visible = True
                        panelInfoHandlerTree.txtInputedData.Text = ""
                        panelInfoHandlerTree.txtInputedData.Focus()

                    Case "info_inv_x_sku"
                        Cursor.Current = Cursors.Default
                        panelInfoHandler.AdvancedList_Default.LoadXml(pPageIDPath)
                        gCurrentPage = pPageID
                        panelInfoHandler.Visible = True
                        panelInfoHandler.AdvancedList_Default.Visible = True
                        panelInfoHandler.txtInputedData.Text = ""
                        panelInfoHandler.txtInputedData.Focus()

                    Case "info_inv_x_sku_tree", "info_inv_x_sku_tree_MC92" 'cambio H
                        Cursor.Current = Cursors.Default
                        panelInfoHandlerTree.AdvancedTree_Default.LoadXml(pPageIDPath)
                        gCurrentPage = pPageID
                        panelInfoHandlerTree.Visible = True
                        panelInfoHandlerTree.AdvancedTree_Default.Visible = True
                        panelInfoHandlerTree.txtInputedData.Text = ""
                        panelInfoHandlerTree.txtInputedData.Focus()

                    Case "info_inv_x_loc"
                        Cursor.Current = Cursors.Default
                        panelInfoHandler.AdvancedList_Default.LoadXml(pPageIDPath)
                        gCurrentPage = pPageID
                        panelInfoHandler.Visible = True
                        panelInfoHandler.AdvancedList_Default.Visible = True
                        panelInfoHandler.txtInputedData.Text = ""
                        panelInfoHandler.txtInputedData.Focus()

                    Case "info_inv_x_loc_tree", "info_inv_x_loc_tree_MC92" 'cambio H
                        Cursor.Current = Cursors.Default
                        panelInfoHandlerTree.AdvancedTree_Default.LoadXml(pPageIDPath)
                        gCurrentPage = pPageID
                        panelInfoHandlerTree.Visible = True
                        panelInfoHandlerTree.AdvancedTree_Default.Visible = True
                        panelInfoHandlerTree.txtInputedData.Text = ""
                        panelInfoHandlerTree.txtInputedData.Focus()

                    Case "info_audit_query"
                        Cursor.Current = Cursors.Default
                        panelInfoHandler.AdvancedList_Default.LoadXml(pPageIDPath)
                        gCurrentPage = pPageID
                        panelInfoHandler.Visible = True
                        panelInfoHandler.AdvancedList_Default.Visible = True
                        panelInfoHandler.txtInputedData.Text = ""
                        panelInfoHandler.txtInputedData.Focus()

                    Case "realloc_to_gen"
                        panelTransHandler.Visible = True
                        panelTransHandler.DetailView1.Visible = True
                        LoadDetailViewFromXml(pPageIDPath)

                        With panelTransHandler
                            .DetailView1.Items("Header1").Label = pPanelTitle
                            .btn_last.Visible = False
                            .btn_first.Visible = False
                            .btn_middle_1.Visible = False
                            .btn_middle_2.Visible = False
                        End With
                    Case "lic_realloc"
                        panelTransHandler.Visible = True
                        panelTransHandler.DetailView1.Visible = True
                        LoadDetailViewFromXml(pPageIDPath)
                        PopulateUiComboBoxStates()
                        panelTransHandler.Focus()
                        With panelTransHandler
                            .DetailView1.Items("Header1").Label = pPanelTitle
                            .DetailView1.Items("txtMt2").Tag = 0
                            .DetailView1.Items("txtMt2").Text = "0"
                            .DetailView1.Items("txtMt2").Visible = False
                            .btn_last.Visible = False
                            .btn_first.Visible = gMuestraBotonSugerenciaReubicacion
                            .btn_first.Text = "Ubi. Sugeridas"
                            .btn_middle_1.Visible = False
                            .btn_middle_2.Visible = False
                            .DetailView1.Items("UiComboBoxStates").Visible = True
                            .DetailView1.Items("txtLicencia").SetFocus()
                            RemoveAllHandlers(gBUTTON_POSITION.FIRST_BUTTON)
                            If gMuestraBotonSugerenciaReubicacion = True Then
                                RemoveAllHandlers(gBUTTON_POSITION.FIRST_BUTTON)
                                RemoveHandler .btn_first.Click, AddressOf btnMostrarUbicacionesSugeridas
                                AddHandler .btn_first.Click, AddressOf btnMostrarUbicacionesSugeridas
                            End If
                        End With

                        leftRelocationComplete = True
                    Case "skus_s1"
                        Cursor.Current = Cursors.Default
                        panelInfoHandler.AdvancedList_Default.LoadXml(pPageIDPath)
                        gCurrentPage = pPageID
                        panelInfoHandler.Visible = True
                        panelInfoHandler.AdvancedList_Default.Visible = True
                        panelInfoHandler.txtInputedData.Text = ""
                        panelInfoHandler.txtInputedData.Focus()
                    Case "occupancy"
                        panelTransHandler.Visible = False
                        panelTransHandler.DetailView1.Visible = False
                        panelTransHandler.Refresh()
                        LoadDetailViewFromXml(pPageIDPath)
                        With panelTransHandler
                            .DetailView1.Items("Header1").Label = pPanelTitle
                            .DetailView1.Items("lblWarehouse").Text = "..."
                            .DetailView1.Items("txtLocation").Visible = True
                            .DetailView1.Items("txtLocation").Text = ""
                            .Refresh()
                        End With
                        gCurrentPage = pPageID
                        panelTransHandler.Visible = True
                        panelTransHandler.DetailView1.Visible = True
                        panelTransHandler.Refresh()

                End Select
                Select Case gCurrentTransactionType
                    Case gTRANS_TYPE.RECEPCION_FISCAL
                        Select Case gCurrentPage
                            Case "poliza"
                                gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA
                            Case "sku_license"
                                gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_RECEPCION_FISCAL
                        End Select
                    Case gTRANS_TYPE.DESPACHO_FISCAL
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_DESPACHO_FISCAL
                    Case gTRANS_TYPE.AUDITORIA_REC_FISCAL
                        'gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_AUDITORIA_REC_FISCAL
                    Case gTRANS_TYPE.REALLOC_PARTIAL
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_REALLOC_PARTIAL

                End Select
                Cursor.Current = Cursors.Default
                CloseScanner()
                SetupScanner()
            End If

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify("LoadPage: " + ex.Message, True)
        End Try
    End Sub

    Public Sub ResizePanel(ByVal panel As Control, ByVal factor As Double)
        panel.Height = panel.Height * factor
        panel.Top = panel.Location.Y * factor
        Try
            ' panel.Font = New Font(panel.Name, panel.Font.Size * factor, panel.Font.Style)
        Catch
        End Try

        For index As Integer = 0 To panel.Controls.Count - 1
            ResizePanel(panel.Controls(index), factor)
        Next
    End Sub

    Public Sub ResizeAdvanceTree(ByVal tree As Resco.Controls.AdvancedTree.AdvancedTree, ByVal factor As Double)
        For index As Integer = 0 To tree.Templates.Count - 1
            For jndex As Integer = 0 To tree.Templates(index).CellTemplates.Count - 1
                Try
                    If TypeOf tree.Templates(index).CellTemplates(jndex) Is Resco.Controls.AdvancedTree.TextCell Then
                        Dim tc As Resco.Controls.AdvancedTree.TextCell = tree.Templates(index).CellTemplates(jndex)
                        tc.Size = New System.Drawing.Size(tc.Size.Width, tc.Size.Height * factor)
                        tc.Location = New System.Drawing.Point(tc.Location.X, tc.Location.Y * factor)
                        '  tc.TextFont = New System.Drawing.Font(tc.TextFont.Name, (tc.TextFont.Size) * factor, tc.TextFont.Style)
                    ElseIf TypeOf tree.Templates(index).CellTemplates(jndex) Is Resco.Controls.AdvancedTree.ButtonCell Then
                        Dim tc As Resco.Controls.AdvancedTree.ButtonCell = tree.Templates(index).CellTemplates(jndex)
                        tc.Size = New System.Drawing.Size(tc.Size.Width * factor, tc.Size.Height * factor)
                        tc.Location = New System.Drawing.Point(tc.Location.X * factor, tc.Location.Y * factor)
                    End If
                Catch
                End Try
            Next
        Next
    End Sub

    Public Sub ResizeAdvanceList(ByVal lista As AdvancedList.AdvancedList, ByVal factor As Double)
        For index As Integer = 0 To lista.Templates.Count - 1
            For jndex As Integer = 0 To lista.Templates(index).CellTemplates.Count - 1
                Try
                    Dim tc As AdvancedList.TextCell = lista.Templates(index).CellTemplates(jndex)
                    '  tc.TextFont = New System.Drawing.Font(tc.TextFont.Name, tc.TextFont.Size * factor, tc.TextFont.Style)
                Catch
                End Try
            Next
        Next
    End Sub

    Sub Notify(ByVal pMessage As String, ByVal IsError As Boolean)
        Cursor.Current = Cursors.Default

        MessageBoxEx.Settings.AutoDefaultButton = True
        MessageBoxEx.Settings.Background = IIf(IsError, Color.Red, Color.White)
        MessageBoxEx.Settings.Foreground = IIf(IsError, Color.White, Color.Black)
        MessageBoxEx.Settings.TopMost = True

        MessageBoxEx.Show(pMessage)

    End Sub
    Public Sub BringMenu()
        panelMenu.Tag = GlobalWarehouse
        Dim pResult As String = ""
        Dim xDS As New DataSet
        Cursor.Current = Cursors.WaitCursor
        Try
            'GetMobileUserMenu
            Dim xservSecurity As New WMS_Security.WMS_Security
            'xservSecurity.Url = Global_WS_HOST + "/Catalogues/WMS_Security.asmx"
            panelMenu.AdvancedList1.DataRows.Clear()

            xDS = xservSecurity.GetMobileUserMenu(gRol, pResult, GlobalEnviroment)
            If pResult = "OK" Then
                Dim strNames(3) As String
                strNames(0) = "OPTION_ID"
                strNames(1) = "OPTION_DESC"
                strNames(2) = "OPTION_PANEL"
                strNames(3) = "OPTION_TRANS_TYPE"

                Dim xmapping As New Resco.Controls.AdvancedList.Mapping(strNames)
                Dim xrow As Resco.Controls.AdvancedList.Row = Nothing

                For Each xdatarow As DataRow In xDS.Tables(0).Rows

                    xrow = New Resco.Controls.AdvancedList.Row(xdatarow("MPC_1"), xdatarow("MPC_2"), xmapping)
                    xrow("OPTION_ID") = xdatarow("CHECK_ID")
                    xrow(xdatarow("ACCESS").ToString) = xdatarow("Description")
                    xrow("OPTION_PANEL") = xdatarow("MPC_3").ToString
                    xrow("OPTION_TRANS_TYPE") = xdatarow("MPC_5").ToString

                    panelMenu.AdvancedList1.DataRows.Add(xrow)

                Next
                Cursor.Current = Cursors.Default
            Else
                Notify("ERROR, " + pResult, True)
            End If
        Catch ex As Exception
            Notify("ERROR, " + ex.Message, True)
            Cursor.Current = Cursors.Default
        End Try
        gCurrentScannerService = gSCANNER_SERVICES.MENU
        ShowPanel(panelMenu)
    End Sub
    Public Sub handlekeyboard(ByVal keyaction As gKEYBOARDACTION)
        Try
            If keyaction = gKEYBOARDACTION.SHOW Then
                frmBase.KeyboardPro1.Show(True)
            Else
                frmBase.KeyboardPro1.Show(False)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function MensajeDeConfirmacion(ByVal mensaje As String) As Boolean
        Dim pText() As String = {"SI", "NO"}
        If MessageBoxEx.ShowYesCancel(mensaje, True, pText) Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Function MessageConfirmationWithTextChanged(ByVal mensaje As String, ByVal si As String, ByVal no As String) As Boolean
        Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = False
        Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green
        Dim pText() As String = {si, no}
        Return MessageBoxEx.ShowYesCancel(mensaje, True, pText)

    End Function

    Public ResizeFactorX As Double = 0
    Public ResizeFactorY As Double = 0

    Public Sub ResizeDetailView(ByVal view As Resco.Controls.DetailView.DetailView, ByVal factorX As Double, ByVal factorY As Double)
        view.Height = view.Height * factorY
        For index As Integer = 0 To view.Items.Count - 1

            'view.Items(index).Height = view.Items(index).Height * factor

            Try
                view.Items(index).TextFont = New Font(view.Items(index).TextFont.Name, view.Items(index).TextFont.Size * ResizeFactorX, view.Items(index).TextFont.Style)
            Catch ex As Exception

            End Try
        Next
    End Sub
    Public Sub LoadDetailViewFromXml(ByVal pPageIDPath As String)
        panelTransHandler.DetailView1.LoadXml(pPageIDPath)

        'panelTransHandler.Height = panelTransHandler.Height * ResizeFactor
        ResizeDetailView(panelTransHandler.DetailView1, ResizeFactorX, ResizeFactorY)
    End Sub

    Public Sub UsuarioFinalizaoDetalleDePicking()
        Try
            If String.IsNullOrEmpty(gLocationSpotTarget) Then
                ShowPanelMyPicking()
                'ShowPanel(panelMyPicking)
                LoadPage("my_waves_tree", gPanelTitle, False)
            Else

                Dim servicioInfoTrans As New WMS_InfoTrans.WMS_InfoTrans
                Dim dt As Data.DataTable
                Dim resultado As String
                dt = servicioInfoTrans.GetTaskPending(gCurrentWavePicking, GlobalUserID, resultado, GlobalEnviroment)
                If Not String.IsNullOrEmpty(resultado) Then
                    Notify(resultado, True)
                Else
                    If dt.Rows.Count = 0 Then
                        gTransaccionAnterior = gCurrentTransactionType
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_SALIDA_DESPACHO
                        panelRecFiscalStep2.lblTitle.Text = "Scan Ubicación: " + gLocationSpotTarget
                        panelRecFiscalStep2.LBL_LOCATION.Text = "..."
                        panelRecFiscalStep2.btnStatus.Visible = False
                        gCurrentTransactionType = gTRANS_TYPE.DESPACHO_UBICACION
                        panelRecFiscalStep2.UIVistaUbicacionesSugeridas.Visible = False
                        panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = False
                        ShowPanel(panelRecFiscalStep2)
                    Else
                        ShowPanelMyPicking()
                        'ShowPanel(panelMyPicking)
                        LoadPage("my_waves_tree", gPanelTitle, False)
                    End If
                End If
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Public Sub RegresarAPantallaDePickingDesdeSerie(ByVal cantidadDeSeriesEscaneadas As Integer)
        Try
            panelTransHandler.DetailView1.Items("txtQTY").Text = cantidadDeSeriesEscaneadas
            If cantidadDeSeriesEscaneadas > 0 Then
                panelTransHandler.btn_last.Visible = True
            End If
            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_DESPACHO_ALMGEN
            ShowPanel(panelTransHandler)
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Public Sub RegresarAPantallaDeUbicacionDesdeSerie(ByVal cantidadDeSeriesEscaneadas As Integer)
        If cantidadDeSeriesEscaneadas > 0 Then
            panelTransHandler.DetailView1.Items("txtCantidad").Text = cantidadDeSeriesEscaneadas
            SaveSKULicense()
        Else
            With panelTransHandler
                .DetailView1.Items("lblSKUName").Text = ""
                .DetailView1.Items("txtScannedSKU").Text = "..."
                .DetailView1.Items("txtScannedSKU").Tag = ""

                .btn_middle_1.Text = "SKUs(" & .btn_last.Tag & ")"

                .DetailView1.Items("txtCantidad").Visible = False
                .DetailView1.Items("UiTextoVinRecepcion").Visible = False
                .DetailView1.Items("dtFechaExpiracion").Visible = False
                .DetailView1.Items("txtNumLote").Visible = False
                .DetailView1.Items("UiTextTone").Visible = False
                .DetailView1.Items("UiTextCaliber").Visible = False
            End With
            panelSerialNumberProcess.LimpiarVariables()
            ShowPanel(panelTransHandler)
            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_REALLOC_PARTIAL
        End If
    End Sub

    Public Sub PopulateUiComboBoxStates()
        Try
            Dim xserv As New WMS_Settings.WMS_Settings
            Dim xset As DataSet
            Dim pResult As String = ""

            xset = xserv.GetParam_ByParamKey("ESTADO", "ESTADOS", "", pResult, GlobalEnviroment)
            If pResult = "OK" Then
                Dim existeAcuerdo = False
                With panelTransHandler
                    With CType(.DetailView1.Items("UiComboBoxStates"), Resco.Controls.DetailView.ItemAdvancedComboBox)
                        .DisplayMember = "PARAM_CAPTION"
                        .ValueMember = "PARAM_NAME"
                        .DataSource = xset.Tables(0)
                        For Each row As DataRow In xset.Tables(0).Rows
                            If ValidatedDefault(row("NUMERIC_VALUE")) Then
                                .Text = row("PARAM_CAPTION")
                                .Value = row("PARAM_NAME")
                                Exit For
                            End If
                        Next
                    End With
                End With
            Else
                Beep()
                Notify("PopulateUiComboBoxStates:" + pResult, True)
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Function ValidatedDefault(ByVal value As Integer) As Boolean
        Return (value = 1)
    End Function


    Public Sub PopulateToTCmbWithStates()
        Try
            Dim xserv As New WMS_Settings.WMS_Settings
            Dim xset As DataSet
            Dim pResult As String = ""

            xset = xserv.GetParam_ByParamKey("ESTADO", "ESTADOS", "", pResult, GlobalEnviroment)
            If pResult = "OK" Then
                Dim existeAcuerdo = False
                With panelTransHandler
                    With CType(.DetailView1.Items("UiListaEstado"), Resco.Controls.DetailView.ItemAdvancedComboBox)
                        .DisplayMember = "PARAM_CAPTION"
                        .ValueMember = "PARAM_NAME"
                        .DataSource = xset.Tables(0)
                        For Each row As DataRow In xset.Tables(0).Rows
                            If ValidatedDefault(row("NUMERIC_VALUE")) Then
                                .Text = row("PARAM_CAPTION")
                                .Value = row("PARAM_NAME")
                                Exit For
                            End If
                        Next
                    End With
                End With
            Else
                Beep()
                Notify("PopulateToTCmb:" + pResult, True)
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Function GetLocationByStatus(ByVal estado As String) As String
        Dim location As String = ""
        Dim webServiceInfoTrans As New WMS_Settings.WMS_Settings
        Dim dtValidated As DataSet
        Dim resultValidated As String = ""

        dtValidated = webServiceInfoTrans.GetParam_ByParamKey("ESTADO", "ESTADOS", estado, resultValidated, GlobalEnviroment)

        If resultValidated.ToUpper.Equals("OK") Then
            If EsUbicacionValida(dtValidated.Tables(0)(0)("SPARE3").ToString) Then
                location = dtValidated.Tables(0)(0)("SPARE3").ToString
            End If
        End If

        Return location
    End Function
    Private Function EsUbicacionValida(ByVal ubicacion As String) As Boolean
        Return Not String.IsNullOrEmpty(ubicacion)
    End Function

    Private Function ExistsGeneralParameter(ByVal dt As DataSet) As Boolean
        If dt.Tables.Count > 0 Then
            Return dt.Tables(0).Rows.Count > 0
        End If
        Return False
    End Function

    Public Sub ShowPanelMyPicking()
        If (handheld.ToUpper() = "MOTOROLA WINCE") Then
            ShowPanel(panelMyPickingMC92)
        Else
            ShowPanel(panelMyPicking)
        End If
    End Sub

    Public Sub CleanNodes()
        If (handheld.ToUpper() = "MOTOROLA WINCE") Then
            panelMyPickingMC92.AdvancedTree1.Nodes.Clear()
        Else
            panelMyPicking.AdvancedTree1.Nodes.Clear()
        End If
    End Sub

    Private Sub MyPickingLoadXml()
        If (handheld.ToUpper() = "MOTOROLA WINCE") Then
            Dim typeTask As String = ""
            Select Case gCurrentTransactionType
                Case gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL
                    typeTask = "DI"
                Case gTRANS_TYPE.DESPACHO_FISCAL
                    typeTask = "*"
                Case gTRANS_TYPE.DESPACHO_GENERAL
                    typeTask = "DESPACHO_ALMGEN"
                Case gTRANS_TYPE.REUBICACION_POR_REABASTECIMIENTO
                    typeTask = "REUBICACION_POR_REABASTECIMIENTO"
            End Select
            GetMyWavesTree(typeTask)
        Else
            panelMyPicking.AdvancedTree1.LoadXml(GetXmlPathByPickingVisualizationType(panelMyPicking.TipoVisualizacion.Items.SelectedItem.Index))
        End If
    End Sub

End Module
