Imports System.Data
Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard
Public Class ctrl_RECFIS_Step1

    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                    If Me.txtQTY.Focused Then
                        ProcessSKU()
                    End If
                    If Me.txtSKU_Desc.Focused Then
                        Me.txtQTY.SelectAll()
                        Me.txtQTY.Focus()
                    End If
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                    Cursor.Current = Cursors.Default
                    CloseScanner()
                    If gMyLastLicense <> 0 Then
                        panelRecepFiscal.btnStart.Text = "Continuar con licencia: " & gMyLastLicense
                    Else
                        panelRecepFiscal.btnStart.Text = "Iniciar recepcion"
                    End If
                    ShowPanel(panelRecepFiscal)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
                    If gPendingSKU Then
                        ProcessSKU()
                    End If

                    If gHasLogisticInfo Then
                        gComments = panelRecFiscalLogisInfo.txtComments.Text
                    Else
                        gComments = ""
                    End If

                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_RECEP_FISCAL
                    panelRecFiscalStep2.lblTitle.Text = "Poliza: " & gPoliza & " Licencia: " & gLicenseID
                    panelRecFiscalStep2.LBL_LOCATION.Text = "ESCANEAR UBICACION"
                    panelRecFiscalStep2.btnStatus.Visible = False
                    panelRecFiscalStep2.UIVistaUbicacionesSugeridas.Visible = False
                    panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = gMuestraBotonSugerenciaReubicacion
                    ShowPanel(panelRecFiscalStep2)

            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Sub ProcessSKU()
        Try

            If Me.lblSKU.Tag = "1" Then
                'call logistics info
                panelRecFiscalLogisInfo.lblTitle.Text = Me.lblSKU.Text + " - " + Me.txtSKU_Desc.Text
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
                        panelTakePicture.lblScannedPolicy.Text = Me.lblSKU.Text
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
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ctrl_RECFIS_Step1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub btnCamara_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnCamara.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub btnGen_Print_licence_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnGen_Print_licence.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub txtQTY_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQTY.KeyUp

        ProcessLastKey(e)

    End Sub



    Private Sub btnScanLicense_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ProcessLastKey(e)
    End Sub

    Private Sub btnRePrintLicense_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnRePrintLicense.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub btnRecords_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnRecords.KeyUp
        ProcessLastKey(e)
    End Sub
    Public Function GenerateLicense(ByRef pLastLicense As Integer, ByVal pREGIMEN As String, ByRef pResult As String) As Boolean
        Try
            Dim xserv As New WMS_Polizas.WMS_Polizas

            Return xserv.CrearLicencia(Me.Tag, GlobalUserID, pLastLicense, gClientOwner, pREGIMEN, If(gTaskId Is Nothing, -1, CInt(gTaskId)), pResult, GlobalEnviroment)
        Catch ex As Exception
            Return False
        End Try
    End Function
    
    Private Sub btnGen_Print_licence_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGen_Print_licence.Click
        Try
            Dim pResult As String = ""
            Dim pLastLicense As Integer = 0

            If gMyLastLicense <> 0 Then
                Me.LBL_LICENSE.Text = "Licencia en curso: " + gMyLastLicense.ToString
                Me.LBL_LICENSE.Tag = gMyLastLicense.ToString
                Me.LBL_LICENSE.Refresh()

            Else
                If GenerateLicense(pLastLicense, gRegimen, pResult) Then

                    Me.LBL_LICENSE.Text = "Nueva licencia: " + pLastLicense.ToString
                    Me.LBL_LICENSE.Tag = pLastLicense.ToString
                    gMyLastLicense = pLastLicense
                    Me.LBL_LICENSE.Refresh()
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_RECEPCION_FISCAL

                    Panel_SKU.Visible = True
                    btnGen_Print_licence.Visible = False

                Else
                    Panel_SKU.Visible = False

                    MessageBox.Show(pResult)
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRePrintLicense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRePrintLicense.Click
        PrintLicence(True)
    End Sub

    Private Sub txtSKU_Desc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSKU_Desc.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub txtSKU_Desc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSKU_Desc.TextChanged

    End Sub

    Private Sub btnRecords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecords.Click
        Try
            Dim xset As DataSet
            Dim pResult As String = ""
            Dim xserv As New WMS_InfoInventory.WMS_InfoInventory

            xset = xserv.GetInventory_ByLicense(CInt(Me.LBL_LICENSE.Tag), pResult, GlobalEnviroment)
            If pResult = "OK" Then
                panelInfo_InvXLic.SmartGrid1.DataSource = xset.Tables(0)
            Else
                panelInfo_InvXLic.SmartGrid1.DataSource = Nothing
            End If
            ShowPanel(panelInfo_InvXLic)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel_SKU_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel_SKU.GotFocus

    End Sub

    Private Sub cmbCommercialAggrements_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCommercialAggrements.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub cmbCommercialAggrements_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCommercialAggrements.SelectedIndexChanged
        Try
            gCommercialAggrement = cmbCommercialAggrements.Items(cmbCommercialAggrements.SelectedIndex)("ACUERDO_COMERCIAL")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
