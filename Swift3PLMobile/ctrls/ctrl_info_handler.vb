Imports System.Text
Imports System.IO
Imports Resco.Controls.AdvancedList
Imports Resco.Controls.MessageBox
Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard
Imports System.Text.RegularExpressions


Public Class ctrl_info_handler
    Public transTypeTemporal As Integer = gTRANS_TYPE.NONE
    Public currentScannerTemporal As Integer = gSCANNER_SERVICES.NO_SCAN_PANTALLA_IMPRESION_SKU
    'Private WithEvents myEditBox As New TextBox
    'Private myEditRowIndex As Integer
    'Private myEditColumnIndex As Integer
    Private myValueChanged As Boolean


    Private Sub AdvancedList_Default_ButtonClick(ByVal sender As Object, ByVal e As Resco.Controls.AdvancedList.CellEventArgs) Handles AdvancedList_Default.ButtonClick
        ' MessageBox.Show("AdvancedList_Default_ButtonClick: " & e.CellIndex)
        Select Case e.CellIndex
            Case 0
                RePrintLabel()
            Case 1
                ReallocPartial()
        End Select
    End Sub
    Private Sub AdvancedList_Default_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AdvancedList_Default.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub txtInputedData_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInputedData.KeyUp
        ProcessLastKey(e)
    End Sub

    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim pResult As String = ""

        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                    Dim xgrid As New SmartGridClass
                    Me.AdvancedList_Default.ShowFooter = False
                    Select Case gCurrentScannerService
                        Case gSCANNER_SERVICES.LEER_POLIZA_CONSULTA
                            If Not xgrid.Populate_Inv_x_Poliza(Me.txtInputedData.Text, pResult) Then
                                Notify(pResult, True)
                            End If
                        Case gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                            If Not xgrid.Populate_Inv_x_License(Me.txtInputedData.Text, pResult) Then
                                Notify(pResult, True)
                                Me.AdvancedList_Default.ShowFooter = False
                            Else
                                Me.AdvancedList_Default.FooterRow.TemplateIndex = 2
                                Me.AdvancedList_Default.FooterRow.SelectedTemplateIndex = 2
                                Me.AdvancedList_Default.ShowFooter = True
                            End If
                        Case gSCANNER_SERVICES.LEER_SKU_CONSULTA
                            If Not xgrid.Populate_Inv_x_SKU(Me.txtInputedData.Text, pResult) Then
                                Notify(pResult, True)
                            End If
                        Case gSCANNER_SERVICES.LEER_UBICACION_CONSULTA
                            If Not xgrid.Populate_Inv_x_Loc(Me.txtInputedData.Text, pResult) Then
                                Notify(pResult, True)
                            End If
                        Case gSCANNER_SERVICES.LEER_LICENCIA_REIMPRESION
                            If IsNumeric(Me.txtInputedData.Text) Then
                                If Not xgrid.Populate_Inv_x_License(Me.txtInputedData.Text, pResult) Then
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
                        Case gTRANS_TYPE.MOSTRAR_SKUS_DESDE_PANTALLA_RECEPCION
                            recargarVariables()
                        Case gTRANS_TYPE.MOSTRAR_SKUS_DESDE_PANTALLA_CREACION_LICENCIA
                            recargarVariables()
                    End Select
                    ShowPanel(CType(xFoundCtrl, UserControl))
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Sub recargarVariables()
        gCurrentPage = "sku_license"
        gCurrentScannerService = currentScannerTemporal
        gCurrentTransactionType = transTypeTemporal
        AdvancedList_Default.DataRows.Clear()
        txtInputedData.Text = ""
        txtInputedData.Visible = True
        panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SCAN/INPUT SKU"
    End Sub

    Sub PrintSKU(ByVal pSKUCode As String, ByVal pSKUName As String, ByVal veces As Int32)
        '
        Try
            Dim xprinter As New ZebraPrinter
            Cursor.Current = Cursors.WaitCursor
            xprinter.PrinterSku(pSKUCode, pSKUName, veces)
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
            xprinter.PrintLicense(True, CInt(Me.txtInputedData.Text), False)

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify(ex.Message, True)

        End Try
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RePrintLabel()
    End Sub

    Private Sub ctrl_info_handler_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)
    End Sub
    Sub ReallocPartial()
        Try
            'get poliza info about this license
            'gRegimen = "FISCAL"

            Dim xservInventory As New WMS_InfoInventory.WMS_InfoInventory
            Dim pResult As String = String.Empty
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
            'call the review poliza info

        Catch ex As Exception
            Notify("ReallocPartial: " + ex.Message, True)
        End Try
    End Sub
    Private Sub AdvancedList_Default_FooterClick(ByVal sender As Object, ByVal e As Resco.Controls.AdvancedList.CellEventArgs) Handles AdvancedList_Default.FooterClick
        MessageBox.Show("AdvancedList_Default_FooterClick: " + e.Cell.Name)
        Select Case e.CellIndex
            Case 0
                RePrintLabel()
            Case 1
                ReallocPartial()
        End Select
    End Sub




    'Private Sub AdvancedList_Default_CellClick(ByVal sender As System.Object, ByVal e As Resco.Controls.AdvancedList.CellEventArgs) Handles AdvancedList_Default.CellClick
    '    myEditBox.Visible = False
    '    If e.DataRow.CurrentTemplateIndex = e.DataRow.SelectedTemplateIndex Then

    '        Select Case e.Cell.CellSource.SourceType

    '            Case Resco.Controls.AdvancedList.CellSourceType.Constant
    '                ' Constant cells can not be modified

    '            Case Else

    '                ' Setting EventArgs for OnValueChanging Event
    '                myEditRowIndex = e.RowIndex
    '                If e.Cell.CellSource.SourceType = Resco.Controls.AdvancedList.CellSourceType.ColumnIndex Then
    '                    myEditColumnIndex = e.Cell.CellSource.ColumnIndex
    '                ElseIf e.Cell.CellSource.SourceType = Resco.Controls.AdvancedList.CellSourceType.ColumnName Then
    '                    myEditColumnIndex = Me.AdvancedList_Default.DataRows(e.RowIndex).FieldNames.GetOrdinal(e.Cell.CellSource.ColumnName)
    '                Else
    '                    myEditColumnIndex = -1
    '                End If

    '                ' Setting new Location and Font of the EditBox
    '                myEditBox.Left = Me.Left + Me.AdvancedList_Default.Templates(e.DataRow.CurrentTemplateIndex).CellTemplates(e.CellIndex).Bounds.Left - 1
    '                myEditBox.Top = Me.Top + Me.AdvancedList_Default.Templates(e.DataRow.CurrentTemplateIndex).CellTemplates(e.CellIndex).Bounds.Top + e.Offset - 1
    '                If Me.AdvancedList_Default.Templates(e.DataRow.CurrentTemplateIndex).CellTemplates(e.CellIndex).Bounds.Width <> -1 Then
    '                    myEditBox.Width = Me.AdvancedList_Default.Templates(e.DataRow.CurrentTemplateIndex).CellTemplates(e.CellIndex).Bounds.Width + 2
    '                Else
    '                    myEditBox.Width = Me.Width - Me.AdvancedList_Default.Templates(e.DataRow.CurrentTemplateIndex).CellTemplates(e.CellIndex).Bounds.Left - 12 + 1
    '                End If
    '                myEditBox.Height = Me.AdvancedList_Default.Templates(e.DataRow.CurrentTemplateIndex).CellTemplates(e.CellIndex).Bounds.Height + 2
    '                myEditBox.Font = CType(e.Cell, Resco.Controls.AdvancedList.TextCell).TextFont

    '                ' If editing Cell has Border, then EditBox should be adjusted to fit the Cell Bounds
    '                If e.Cell.Border <> Resco.Controls.AdvancedList.BorderType.None Then
    '                    myEditBox.Left = myEditBox.Left + 1
    '                    myEditBox.Top = myEditBox.Top + 1
    '                    myEditBox.Width = myEditBox.Width - 2
    '                    myEditBox.Height = myEditBox.Height - 2
    '                End If

    '                ' Setting new value for the EditBox
    '                myEditBox.Text = e.CellData.ToString
    '                myValueChanged = False

    '                ' Making EditBox visible and focused
    '                myEditBox.Visible = True
    '                myEditBox.BringToFront()
    '                myEditBox.Focus()

    '        End Select
    '    End If
    'End Sub

    'Private Sub myEditBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles myEditBox.LostFocus

    '    If myValueChanged Then

    '        ' Creating ValueChangingEventArgs 
    '        'Dim myEventArgs As New ValueChangingEventArgs(AdvancedList_Default.DataRows(myEditRowIndex), myEditColumnIndex, myEditBox.Text)

    '        '' Raising Event
    '        'OnValueChanging(myEventArgs)

    '        '' If event was not canceled then editing datarow can be updated with new value 
    '        'If Not myEventArgs.Cancel Then
    '        '    AdvancedList_Default.DataRows(myEditRowIndex)(myEditColumnIndex) = myEditBox.Text
    '        'End If

    '    End If

    'End Sub

    'Private Sub myEditBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles myEditBox.TextChanged

    '    ' User has changed value in EditBox
    '    myValueChanged = True

    'End Sub

    Private Sub txtInputedData_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInputedData.TextChanged

    End Sub

    Private Sub AdvancedList_Default_RowEntered(ByVal sender As Object, ByVal e As Resco.Controls.AdvancedList.RowEnteredEventArgs) Handles AdvancedList_Default.RowEntered
        Try
            If gCurrentScannerService = gSCANNER_SERVICES.LEER_CATALOGO_SKU_SEC1 Or gCurrentScannerService = gSCANNER_SERVICES.NO_SCAN_PANTALLA_IMPRESION_SKU Then
                Dim pSKU = e.Row("BARCODE_ID").ToString
                Dim pSKU_Name = e.Row("MATERIAL_NAME").ToString

                Dim copias As Integer
                Dim cadenaCopias As String = "1"
                If InputBoxEx.ShowDialog(MessageBoxIcon.Question, "Cantidad a imprimir", cadenaCopias, InputBoxExButtons.OKCancel) = DialogResult.Cancel Then
                    Exit Sub
                End If

                If cadenaCopias = "" Then
                    Notify("Debe ingresar la cantidad a imprimir del artículo", True)
                    Exit Sub
                End If

                If Not IsNumeric(cadenaCopias) Then
                    Notify("Solo puede ingresar números", True)
                    Exit Sub
                End If

                copias = Convert.ToInt32(cadenaCopias)
                If copias < 0 Then
                    Notify("Ingrese un valor mayor a 0", True)
                    Exit Sub
                End If

                Dim pText() As String = {"SI", "NO"}
                If MessageBoxEx.ShowYesCancel("Confirma Impresion de etiqueta para " + pSKU + " " + pSKU_Name, True, pText) Then
                    PrintSKU(pSKU, pSKU_Name, copias)
                End If
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    'Public Sub New()

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    Me.Controls.Add(myEditBox)
    '    myEditBox.Visible = False
    '    AddHandler myEditBox.LostFocus, AddressOf myEditBox_TextChanged

    'End Sub
End Class
