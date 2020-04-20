Imports System.Data
Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard
Imports Resco.Controls.MessageBox

Public Class ctrl_RECFIS_Step2

    Private Sub btnStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatus.Click
        Dim pResult As String = ""
        If Me.btnStatus.Tag = "1" Then
            Me.btnStatus.Visible = False
        Else
            If txtMT2.Visible Then
                If IsNumeric(panelRecFiscalStep2.txtMT2.Text) Then
                    Dim result As String = String.Empty
                    LocationScanned(False, Decimal.Parse(panelRecFiscalStep2.txtMT2.Text), panelRecFiscalStep2.LBL_LOCATION.Tag, result)
                    panelRecFiscalStep2.btnStatus.Tag = "1"
                    panelRecFiscalStep2.btnStatus.Text = "OK"
                    panelRecFiscalStep2.btnStatus.Visible = False
                    If Not result = "OK" Then
                        Notify(result, True)
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            Else
                If Not gCurrentTransactionType = gTRANS_TYPE.DESPACHO_UBICACION Then
                    panelRecFiscalStep2.btnStatus.Tag = "1"
                    panelRecFiscalStep2.btnStatus.Text = "OK"
                    panelRecFiscalStep2.btnStatus.Visible = False
                End If
            End If

            Select Case gCurrentTransactionType

                Case gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL
                    ShowPanelMyPicking()
                    'ShowPanel(panelMyPicking)
                    LoadPage("my_waves_tree", gPanelTitle, False)
                Case gTRANS_TYPE.RECEPCION_FISCAL
                    CloseScanner()
                    Dim result As String = ""
                    Dim serv As New WMS_InfoTrans.WMS_InfoTrans
                    Dim dt As DataSet
                    dt = serv.GET_TYPE_CHARGE_MOVIL(gLicenseID, "RECEPCION_FISCAL", result, GlobalEnviroment)
                    If result = "OK" And Not dt Is Nothing Then
                        panelTypeChange._licenseId = Integer.Parse(gLicenseID)
                        panelTypeChange.AdvancedList_Default.DataSource = dt.Tables(0)
                        panelTypeChange._typeTrans = "RECEPCION_FISCAL"
                        panelTypeChange.AdvancedList_Default.Templates("RowTemplate_Header").CellTemplates(0).CellSource.ConstantData = "Tipos de Cobro/Licencia " + gLicenseID
                        ShowPanel(panelTypeChange)
                    Else
                        gLicenseID = 0
                        gCurrentLicenseID = 0
                        gMyLastLicense = 0

                        ShowPanel(panelTransHandler)

                        gCurrentTransactionType = 1
                        StartSkuLicense()
                    End If

                Case gTRANS_TYPE.INICIALIZACION
                    CloseScanner()
                    ShowPanel(panelTransHandler)

                    gLicenseID = 0
                    gCurrentLicenseID = 0
                    gMyLastLicense = 0
                    gCurrentTransactionType = 3
                    StartSkuLicense()

                Case gTRANS_TYPE.REALLOC_PARTIAL
                    Dim result As String = ""
                    Dim serv As New WMS_InfoTrans.WMS_InfoTrans
                    Dim dt As DataSet
                    dt = serv.GET_TYPE_CHARGE_MOVIL(gLicenseID, "REUBICACION_PARCIAL", result, GlobalEnviroment)
                    If result = "OK" And Not dt Is Nothing Then
                        panelTypeChange._licenseId = Integer.Parse(gLicenseID)
                        panelTypeChange.AdvancedList_Default.DataSource = dt.Tables(0)
                        panelTypeChange._typeTrans = "REUBICACION_PARCIAL"
                        panelTypeChange.AdvancedList_Default.Templates("RowTemplate_Header").CellTemplates(0).CellSource.ConstantData = "Tipos de Cobro/Licencia " + gLicenseID
                        ShowPanel(panelTypeChange)
                    Else
                        ShowPanel(panelMenu)
                    End If

                Case gTRANS_TYPE.INICIALIZACION_GENERAL
                    CloseScanner()

                    gLicenseID = 0
                    gCurrentLicenseID = 0
                    gMyLastLicense = 0

                    ShowPanel(panelTransHandler)

                    gCurrentTransactionType = 10
                    StartSkuLicense()


                Case gTRANS_TYPE.RECEPCION_ALMGEN
                    CloseScanner()
                    Dim result As String = ""
                    Dim serv As New WMS_InfoTrans.WMS_InfoTrans
                    Dim dt As DataSet
                    dt = serv.GET_TYPE_CHARGE_MOVIL(gLicenseID, "RECEPCION_ALMGEN_GENERAL", result, GlobalEnviroment)
                    If result = "OK" And Not dt Is Nothing Then
                        panelTypeChange._licenseId = Integer.Parse(gLicenseID)
                        panelTypeChange.AdvancedList_Default.DataSource = dt.Tables(0)
                        panelTypeChange._typeTrans = "RECEPCION_ALMGEN_GENERAL"
                        panelTypeChange.AdvancedList_Default.Templates("RowTemplate_Header").CellTemplates(0).CellSource.ConstantData = "Tipos de Cobro/Licencia " + gLicenseID
                        ShowPanel(panelTypeChange)
                    Else
                        gLicenseID = 0
                        gCurrentLicenseID = 0
                        gMyLastLicense = 0

                        ShowPanel(panelTransHandler)

                        gCurrentTransactionType = 11
                        StartSkuLicense()
                    End If
                Case gTRANS_TYPE.DESPACHO_UBICACION
                    TerminarProcesoDeDesapacho()
                Case gTRANS_TYPE.REUBICACION_POR_REABASTECIMIENTO
                    UiBotonImprimirLicencia.Visible = False
                    ShowPanelMyPicking()
                    'ShowPanel(panelMyPicking)
                    LoadPage("my_waves_tree", gPanelTitle, False)
            End Select
            txtMT2.Text = ""
            lblMT2.Visible = False
            txtMT2.Visible = False


        End If
    End Sub

    Private Sub ctrl_RECFIS_Step2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp, txtMT2.KeyUp, btnStatus.KeyUp
        ProcessLastKey(e)
    End Sub

    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    If Not gCurrentTransactionType = gTRANS_TYPE.DESPACHO_UBICACION And Not gCurrentTransactionType = gTRANS_TYPE.REALLOC_PARTIAL Then
                        UsuarioDeseaSalirDePantalla()
                    End If
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub UsuarioDeseaSalirDePantalla()
        Try
            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_RECEPCION_FISCAL
            ShowPanel(panelTransHandler)
        Catch ex As Exception
            Notify("Error al salir de pantalla: " + ex.Message, True)
        End Try
    End Sub

    Private Sub TerminarProcesoDeDesapacho()
        Try
            If Not gLocationSpotTarget.Equals(LBL_LOCATION.Text) Then
                Dim pText() As String = {"SI", "NO"}
                If Not MessageBoxEx.ShowYesCancel("La ubicacion destino es diferente al asignado desea continuar ?", True, pText) Then
                    Return
                End If
            End If

            Dim servicioTrans As New WMS_Trans.WMS_Trans
            Dim resultado As String
            If servicioTrans.UpdateLocationTargerTask(gCurrentWavePicking, GlobalUserID, LBL_LOCATION.Text, GlobalEnviroment, resultado) Then
                If resultado.Equals("OK") Then
                    gCurrentTransactionType = gTransaccionAnterior
                    ShowPanelMyPicking()
                    'ShowPanel(panelMyPicking)
                    LoadPage("my_waves_tree", gPanelTitle, False)
                Else
                    Notify(resultado, True)
                End If
            Else
                Notify(resultado, True)
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub UiBotonImprimirLicencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiBotonImprimirLicencia.Click
        UsuarioDeseaImprimirLicencia()
    End Sub

    Private Sub UsuarioDeseaImprimirLicencia()
        Try
            If String.IsNullOrEmpty(panelRecFiscalStep2.lblTitle.Tag) Then
                Exit Sub
            End If

            If panelRecFiscalStep2.lblTitle.Tag < 0 Then
                Exit Sub
            End If

            Dim xprinter As New ZebraPrinter
            gLicenseID = panelRecFiscalStep2.lblTitle.Tag
            xprinter.PrintLicense(False, panelRecFiscalStep2.lblTitle.Tag, False)

        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub UIbtnUbicacionesSugeridas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UIbtnUbicacionesSugeridas.Click
        If UIVistaUbicacionesSugeridas.Visible Then
            'cerramos el grid si al darle click al boton esta visible
            UIVistaUbicacionesSugeridas.Visible = False
            Exit Sub
        End If
        Dim xserv As New WMS_Materials.WMS_Materials
        Dim xdTable As DataTable
        Dim pResult As String = "OK"
        Dim license As Integer = 0
        Try
            license = gLicenseID

            xdTable = xserv.GetSuggestedLocations(license, GlobalUserID, GlobalEnviroment, pResult)
            UIVistaUbicacionesSugeridas.DataSource = xdTable
            UIVistaUbicacionesSugeridas.Visible = True
        Catch ex As Exception
            UIVistaUbicacionesSugeridas.Visible = False
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub UIbtnUbicacionesSugeridas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UIbtnUbicacionesSugeridas.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub UIVistaUbicacionesSugeridas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UIVistaUbicacionesSugeridas.KeyUp
        ProcessLastKey(e)
    End Sub
End Class
