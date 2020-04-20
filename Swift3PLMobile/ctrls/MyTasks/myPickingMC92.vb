Imports System.Data
Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard
Imports Resco.Controls.MessageBox

Public Class myPickingMC92


    Private Sub myPicking_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub AdvancedTree1_ButtonClick(ByVal sender As Object, ByVal e As Resco.Controls.AdvancedTree.CellEventArgs) Handles AdvancedTree1.ButtonClick

        Try
            Dim pWaveID As String = e.Cell(e.Node, 0).ToString
            gCurrentSerialNumber = e.Cell(e.Node, 1)
            Dim pBarCodeID As String = e.Cell(e.Node, 2).ToString
            Dim pMaterialId As String = e.Cell(e.Node, 8).ToString
            gCurrentCodigoPolizaSource = e.Cell(e.Node, 3).ToString
            gLocationSpotTarget = IIf(IsDBNull(e.Cell(e.Node, 7)), "", e.Cell(e.Node, 7))
            gTaskSubType = IIf(IsDBNull(e.Cell(e.Node, 9)), "", e.Cell(e.Node, 9))

            gMaterialId = pMaterialId
            gMaterialBarCode = pBarCodeID
            If e.Cell.DesignName = "UiBotonCancelarLinea" Then
                Dim pText() As String = {"SI", "NO"}
                If MessageBoxEx.ShowYesCancel("¿Desea finalizar la linea con diferencias? Material: " + pMaterialId, True, pText) Then

                    Dim pResult As String = String.Empty
                    Dim xserv As New WMS_Trans.WMS_Trans
                    xserv.CancelPickingDetailLine(pWaveID, GlobalUserID, pMaterialId, GlobalEnviroment, pResult)

                    ShowPanelMyPicking()
                    'ShowPanel(panelMyPicking)
                    LoadPage("my_waves_tree", gPanelTitle, False)

                End If

            Else
                Cursor.Current = Cursors.WaitCursor
                Dim xserbInfoTrans As New WMS_InfoTrans.WMS_InfoTrans
                Dim pResult As String = String.Empty
                Dim result As DataTable
                result = xserbInfoTrans.ValidateTaskStatus(GlobalUserID, 0, 0, pWaveID, pMaterialId, "TAREA_PICKING", GlobalEnviroment, pResult)
                If pResult = "OK" AndAlso result.Rows(0)(0) = 1 Then
                    ShowTasks(pWaveID, pBarCodeID)
                    pResult = String.Empty
                    Dim xserv As New WMS_Trans.WMS_Trans
                    xserv.ActualizarEstadoTareaDeRecepcion(gCurrentCodigoPolizaSource, GlobalUserID, gRegimen, "ACCEPTED", gCurrentSerialNumber, GlobalEnviroment, pResult)

                    If pResult <> "OK" Then
                        Notify(pResult, True)
                    End If
                Else
                    Notify(IIf(pResult = "OK", result.Rows(0)(1).ToString(), pResult), True)
                End If

            End If


        Catch ex As Exception
            Notify(ex.Message, True)
        End Try

    End Sub
    Sub ShowTasks(ByVal pWaveID As String, ByVal pBarCodeID As String)
        Try
            gCurrentWavePicking = CInt(pWaveID)
            gCurrentSKUPicking = pBarCodeID
            Select Case gCurrentTransactionType
                Case gTRANS_TYPE.DESPACHO_FISCAL
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_DESPACHO_FISCAL
                    gRegimen = "FISCAL"
                Case gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_DESPACHO_FISCAL
                    gRegimen = "FISCAL"

                Case gTRANS_TYPE.DESPACHO_GENERAL
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_DESPACHO_ALMGEN
                    gRegimen = "GENERAL"
                Case gTRANS_TYPE.REUBICACION_POR_REABASTECIMIENTO
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_DESPACHO_ALMGEN
                    gRegimen = "GENERAL"
            End Select

            ShowPanel(panelTransHandler)

            Select Case gCurrentTransactionType
                Case gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL
                    LoadPage("wave_picking", gPanelTitle, False) '"Picking para Traslado", False)
                    gRegimen = "FISCAL"
                Case gTRANS_TYPE.DESPACHO_FISCAL
                    LoadPage("wave_picking", gPanelTitle, False) '"Picking Fiscal", False)
                    gRegimen = "FISCAL"
                Case gTRANS_TYPE.DESPACHO_GENERAL
                    LoadPage("wave_picking", gPanelTitle, False) '"Picking Alm.Gen", False)
                    gRegimen = "GENERAL"
                Case gTRANS_TYPE.REUBICACION_POR_REABASTECIMIENTO
                    LoadPage("wave_picking", gPanelTitle, False) '"Picking Alm.Gen", False)
                    gRegimen = "GENERAL"
            End Select

            Cursor.Current = Cursors.WaitCursor

            Dim pResult As String = gRegimen
            Dim xset As DataSet
            Dim xserv As New WMS_InfoTrans.WMS_InfoTrans
            xset = xserv.GetMyFirstTask(GlobalUserID, gCurrentWavePicking, gCurrentCodigoPolizaSource, gCurrentSKUPicking, gLocationSpotTarget, pResult, GlobalEnviroment)

            If pResult = "OK" Then
                gMaterialIdPicking = xset.Tables(0).Rows(0)("MATERIAL_ID")
                If gCurrentTransactionType = gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL Then
                    gTaskId = xset.Tables(0).Rows(0)("SERIAL_NUMBER")
                End If
                panelTransHandler.DetailView1.Items("UbicacionOrigen").Text = ""
                panelTransHandler.DetailView1.Items("UbicacionOrigen").Label = "Scan Ubicación(" + xset.Tables(0).Rows(0)("LOCATION_SPOT_SOURCE") + "):"
                panelTransHandler.DetailView1.Items("UbicacionOrigen").Tag = Trim(xset.Tables(0).Rows(0)("LOCATION_SPOT_SOURCE"))
                panelTransHandler.DetailView1.Items("UbicacionOrigen").ErrorMessage = Nothing

                panelTransHandler.DetailView1.Items("LicenciaOrigen").Text = ""
                panelTransHandler.DetailView1.Items("LicenciaOrigen").Label = "Scan Licencia(" & xset.Tables(0).Rows(0)("LICENSE_ID_SOURCE") & "):"
                panelTransHandler.DetailView1.Items("LicenciaOrigen").Tag = CStr(xset.Tables(0).Rows(0)("LICENSE_ID_SOURCE"))
                panelTransHandler.DetailView1.Items("LicenciaOrigen").ErrorMessage = Nothing

                gCurrentLicenseID = xset.Tables(0).Rows(0)("LICENSE_ID_SOURCE")
                gCurrentCodigoPoliza = xset.Tables(0).Rows(0)("CODIGO_POLIZA_TARGET")
                gCurrentSerialNumber = xset.Tables(0).Rows(0)("SERIAL_NUMBER")

                panelTransHandler.DetailView1.Items("CodigoBarras").Text = xset.Tables(0).Rows(0)("MATERIAL_NAME")
                panelTransHandler.DetailView1.Items("CodigoBarras").Label = "Scan SKU(" & xset.Tables(0).Rows(0)("BARCODE_ID") & "):"
                panelTransHandler.DetailView1.Items("CodigoBarras").ErrorMessage = Nothing

                'CType(panelTransHandler.DetailView1.Items("txtQTY"), Resco.Controls.DetailView.ItemNumeric).Minimum = 1
                'CType(panelTransHandler.DetailView1.Items("txtQTY"), Resco.Controls.DetailView.ItemNumeric).Maximum = xset.Tables(0).Rows(0)("QUANTITY_PENDING")

                panelTransHandler.DetailView1.Items("txtQTY").Label = "Cantidad:"

                panelTransHandler.DetailView1.Items("txtQTY").Text = xset.Tables(0).Rows(0)("QUANTITY_PENDING").ToString
                panelTransHandler.DetailView1.Items("txtQTY").Tag = xset.Tables(0).Rows(0)("QUANTITY_PENDING").ToString
                gBatchRequested = xset.Tables(0).Rows(0)("BATCH_REQUESTED").ToString

                gClientOwner = xset.Tables(0).Rows(0)("CLIENT_OWNER").ToString

                If (xset.Tables(0).Rows(0)("TONE") = String.Empty) Then
                    panelTransHandler.DetailView1.Items("UiTxtToneSku").Visible = False
                Else
                    panelTransHandler.DetailView1.Items("UiTxtToneSku").Label = "Tono:"
                    panelTransHandler.DetailView1.Items("UiTxtToneSku").Text = xset.Tables(0).Rows(0)("TONE").ToString
                    panelTransHandler.DetailView1.Items("UiTxtToneSku").Tag = xset.Tables(0).Rows(0)("TONE").ToString
                End If

                If (xset.Tables(0).Rows(0)("CALIBER") = String.Empty) Then
                    panelTransHandler.DetailView1.Items("UiTxtCaliberSku").Visible = False
                Else
                    panelTransHandler.DetailView1.Items("UiTxtCaliberSku").Label = "Calibre:"
                    panelTransHandler.DetailView1.Items("UiTxtCaliberSku").Text = xset.Tables(0).Rows(0)("CALIBER")
                    panelTransHandler.DetailView1.Items("UiTxtCaliberSku").Tag = xset.Tables(0).Rows(0)("CALIBER")
                End If

                panelSerialNumberProcess.LimpiarVariables()
                Dim serverTrans As New WMS_Trans.WMS_Trans
                Dim result As String = String.Empty
                Dim label As String = String.Empty
                label = serverTrans.InsertPickingLabel(GlobalUserID, gCurrentWavePicking, gClientOwner, result, GlobalEnviroment)

                If Not SuccessfulProcess(label) Then
                    gCurrentLabel = Integer.Parse(label)
                Else
                    Notify(result, True)
                End If
            Else
                Cursor.Current = Cursors.Default
                MessageBox.Show("gRegimen:" + gRegimen + " " + pResult, "OnePlan(r) WMS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            End If

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub AdvancedTree1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AdvancedTree1.KeyUp
        ProcessLastKey(e)
    End Sub
    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    ShowPanel(panelMenu)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
                    ''refresh tree

                    'gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                    'gCurrentTransactionType = gTRANS_TYPE.NONE
                    Cursor.Current = Cursors.WaitCursor

                    ShowPanelMyPicking()
                    'ShowPanel(panelMyPicking)
                    LoadPage("my_waves_tree", gPanelTitle, False)
                    Cursor.Current = Cursors.Default
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Function SuccessfulProcess(ByVal value As String) As Boolean
        Return String.IsNullOrEmpty(value)
    End Function

    Private Sub AdvancedTree1_CellClick(ByVal sender As System.Object, ByVal e As Resco.Controls.AdvancedTree.CellEventArgs) Handles AdvancedTree1.CellClick

    End Sub
End Class
