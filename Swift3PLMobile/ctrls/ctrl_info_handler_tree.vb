Imports System.Text
Imports System.IO
Imports Resco.Controls.AdvancedList
Imports Resco.Controls.MessageBox
Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard

Public Class ctrl_info_handler_tree

    Private Sub txtInputedData_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInputedData.KeyUp
        ProcessLastKey(e)
    End Sub
    Private Sub txtInputedData_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim pResult As String = ""

        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                    Dim xgrid As New SmartGridClass
                    Me.AdvancedTree_Default.ShowFooter = True
                    Select Case gCurrentScannerService
                        Case gSCANNER_SERVICES.LEER_POLIZA_CONSULTA
                            If Not xgrid.Populate_Inv_x_Poliza_Tree(Me.txtInputedData.Text, pResult) Then
                                Notify(pResult, True)
                            End If
                        Case gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                            If Not xgrid.Populate_Inv_x_License_Tree(Me.txtInputedData.Text, pResult) Then
                                Notify(pResult, True)
                                Me.AdvancedTree_Default.ShowFooter = False
                            Else
                                'Me.AdvancedTree_Default.FooterRow.TemplateIndex = 2  cambio H
                                'Me.AdvancedTree_Default.FooterRow.SelectedTemplateIndex = 2  cambio H
                                Me.AdvancedTree_Default.ShowFooter = True
                            End If
                        Case gSCANNER_SERVICES.LEER_SKU_CONSULTA
                            If Not xgrid.Populate_Inv_x_SKU_Tree(Me.txtInputedData.Text, pResult) Then
                                Notify(pResult, True)
                            End If
                        Case gSCANNER_SERVICES.LEER_UBICACION_CONSULTA
                            If Not xgrid.Populate_Inv_x_Loc_Tree(Me.txtInputedData.Text, pResult) Then
                                Notify(pResult, True)
                            End If
                        Case gSCANNER_SERVICES.LEER_LICENCIA_REIMPRESION
                            If IsNumeric(Me.txtInputedData.Text) Then
                                If Not xgrid.Populate_Inv_x_License_Tree(Me.txtInputedData.Text, pResult) Then
                                    Notify(pResult, True)
                                End If
                            Else
                                Notify("Valor ingresado es incorrecto", True)
                            End If
                        Case gSCANNER_SERVICES.LEER_CATALOGO_SKU_SEC1
                            If Not xgrid.Populate_SKUs_S1(Me.txtInputedData.Text, pResult) Then
                                Notify(pResult, True)
                            End If

                    End Select
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    Dim xctrl As Control, xFoundCtrl As Control = Nothing
                    For Each xctrl In frmBase.Controls
                        If xctrl.Name = gLastPanelName Then
                            xFoundCtrl = xctrl
                            Exit For
                        End If
                    Next
                    Select Case gCurrentTransactionType
                        Case gTRANS_TYPE.NONE
                            xFoundCtrl = panelMenu
                        Case gTRANS_TYPE.REALLOC_PARTIAL
                            xFoundCtrl = panelMenu
                        Case gTRANS_TYPE.RECEPCION_FISCAL
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_RECEPCION_FISCAL
                            gCurrentPage = "sku_license"
                        Case gTRANS_TYPE.INICIALIZACION_GENERAL
                            gCurrentPage = "sku_license"
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_INICIALIZACION
                        Case gTRANS_TYPE.INICIALIZACION
                            gCurrentPage = "sku_license"
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_INICIALIZACION
                        Case gTRANS_TYPE.AUDITORIA_REC_FISCAL
                            If gIsSerie = "SI" Then
                                gCurrentPage = "sku_license_audit_scanning"
                            End If
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_AUDITORIA_REC_FISCAL
                        Case gTRANS_TYPE.AUDITORIA_DESP_FISCAL
                            If gIsSerie = "SI" Then
                                gCurrentPage = "sku_license_audit_scanning"
                            End If
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_AUDITORIA_DESP_FISCAL
                        Case gTRANS_TYPE.RECEPCION_ALMGEN
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_RECEPCION_FISCAL
                            gCurrentPage = "sku_license"
                    End Select
                    ShowPanel(CType(xFoundCtrl, UserControl))
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub ctrl_info_handler_tree_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub AdvancedTree_Default_ButtonClick(ByVal sender As System.Object, ByVal e As Resco.Controls.AdvancedTree.CellEventArgs) Handles AdvancedTree_Default.ButtonClick
        Select Case e.CellIndex
            Case 0
                RePrintLabel()
            Case 1
                ReallocPartial()
        End Select
    End Sub

    Private Sub AdvancedTree_Default_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AdvancedTree_Default.KeyUp
        ProcessLastKey(e)
    End Sub
    Sub PrintSKU(ByVal pSKUCode As String, ByVal pSKUName As String)
        '
        Try
            Dim xprinter As New ZebraPrinter
            Cursor.Current = Cursors.WaitCursor
            xprinter.PrinterSku(pSKUCode, pSKUName, 1)
            'PrintSKULabel(pSKUCode, pSKUName)
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify(ex.Message, True)

        End Try
    End Sub

    Sub RePrintLabel()
        Try
            Cursor.Current = Cursors.WaitCursor
            'PrintLicence(CInt(Me.txtInputedData.Text), True)
            Dim xprinter As New ZebraPrinter

            If Me.txtInputedData.Text = "" Then
                Throw New Exception("Por favor escanee una licencia.")
            End If


            xprinter.PrintLicense(True, CInt(Me.txtInputedData.Text), False)

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify(ex.Message, True)

        End Try
    End Sub

    Sub ReallocPartial()
        Try
            'get poliza info about this license
            'gRegimen = "FISCAL"

            Dim xservInventory As New WMS_InfoInventory.WMS_InfoInventory
            Dim pResult As String = String.Empty

            If Me.txtInputedData.Text = "" Then
                Throw New System.Exception("Por favor escanee una licencia.")
            End If

            xservInventory.ValidateLicenseLocationForRealloc(CInt(Me.txtInputedData.Text), pResult, GlobalEnviroment)
            If pResult <> "OK" Then
                Notify(pResult, True)
                Return
            End If

            gCurrentTransactionType = gTRANS_TYPE.REALLOC_PARTIAL
            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_REALLOC_PARTIAL
            gSourceLicense = CInt(Me.txtInputedData.Text)
            gSourceLocation = ""

            gPoliza = gCurrentCodigoPoliza
            gNumeroOrden = ""
            ShowPanel(panelTransHandler)
            LoadPage("poliza", gPanelTitle, False)
            ReviewPoliza(gCurrentCodigoPoliza, gNumeroOrden, False, "")
            panelSerialNumberProcess.LimpiarVariables()

        Catch ex As Exception
            Notify("ReallocPartial: " + ex.Message, True)
        End Try
    End Sub

    Private Sub AdvancedTree_Default_FooterClick(ByVal sender As System.Object, ByVal e As Resco.Controls.AdvancedTree.CellEventArgs) Handles AdvancedTree_Default.FooterClick

        Try
            MessageBox.Show("AdvancedList_Default_FooterClick: " + e.Cell.Name)
            Select Case e.CellIndex
                Case 0
                    RePrintLabel()
                Case 1
                    ReallocPartial()

            End Select
        Catch ex As Exception
            MessageBox.Show("Error Btn: " + ex.Message)
        End Try

    End Sub

    Private Sub AdvancedTree_Default_NodeEntered(ByVal sender As System.Object, ByVal e As Resco.Controls.AdvancedTree.NodeEnteredEventArgs) Handles AdvancedTree_Default.NodeEntered
        Try
            If gCurrentScannerService = gSCANNER_SERVICES.LEER_CATALOGO_SKU_SEC1 Then
                Dim pSKU = e.Node("BARCODE_ID").ToString
                Dim pSKU_Name = e.Node("MATERIAL_NAME").ToString

                Dim pText() As String = {"SI", "NO"}
                If MessageBoxEx.ShowYesCancel("Confirma Impresion de etiqueta para " + pSKU + " " + pSKU_Name, True, pText) Then
                    Dim pCopies As String = "1"
                    Dim I As Integer = 1
                    For I = 1 To CInt(pCopies)
                        PrintSKU(pSKU, pSKU_Name)
                    Next
                End If
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub
End Class
