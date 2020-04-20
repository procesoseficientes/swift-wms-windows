Imports System.Data
Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard

Public Class ctrl_type_charge


    Private _idTypeCarge As Integer = 0
    Public _typeTrans As String = ""
    Public _licenseId As Integer = 0


    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        pnlCantidad.Visible = False
        txtQTY.Text = ""
        AdvancedList_Default.Focus()
        'AdvancedList_Default.SelectedTemplateIndex = -1
    End Sub

    Private Sub AdvancedList_Default_ButtonClick_1(ByVal sender As System.Object, ByVal e As Resco.Controls.AdvancedList.CellEventArgs) Handles AdvancedList_Default.ButtonClick
        _idTypeCarge = Integer.Parse(e.DataRow("TYPE_CHARGE_ID"))

        pnlCantidad.Visible = True
        If Not Integer.Parse(e.DataRow("QTY")) = 0 Then
            txtQTY.Text = e.DataRow("QTY")
        End If

        txtQTY.Focus()
    End Sub

    Private Sub Grabar()
        Cursor.Current = Cursors.Default
        Dim result As String = ""
        Try

            Dim serv As New WMS_Trans.WMS_Trans

            If serv.CreateTypeChangeXLicense(_licenseId, _idTypeCarge, Integer.Parse(txtQTY.Text), GlobalUserID, _typeTrans, result, GlobalEnviroment) Then
                If result = "OK" Then
                    Dim servInfo As New WMS_InfoTrans.WMS_InfoTrans
                    Dim dt As DataSet
                    result = ""
                    dt = servInfo.GET_TYPE_CHARGE_MOVIL(_licenseId, _typeTrans, result, GlobalEnviroment)
                    If result = "OK" And Not dt Is Nothing Then
                        Me.AdvancedList_Default.DataSource = Nothing
                        Me.AdvancedList_Default.DataSource = dt.Tables(0)
                        pnlCantidad.Visible = False
                        txtQTY.Text = ""
                        AdvancedList_Default.Focus()
                    Else
                        Notify(result, True)
                    End If
                End If
            Else
                Notify(result, True)
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify(ex.Message - result, True)
        End Try

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Grabar()
    End Sub


    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)

        Dim result As String = ""
        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    Select Case _typeTrans
                        Case "TRASLADO_FISCAL_A_GENERAL"
                            ShowPanelMyPicking()
                            'ShowPanel(panelMyPicking)
                            LoadPage("my_waves_tree", gPanelTitle, False)
                        Case "RECEPCION_FISCAL"
                            'ShowPanel(panelTransHandler)
                            'LoadPage("poliza", panelTransHandler.DetailView1.Items("Header1").Label, False)
                            'ReviewPoliza(gPoliza, True, result)
                            gLicenseID = 0
                            gCurrentLicenseID = 0
                            gMyLastLicense = 0

                            ShowPanel(panelTransHandler)

                            gCurrentTransactionType = 1
                            StartSkuLicense()
                        Case "RECEPCION_ALMGEN_GENERAL"
                            'ShowPanel(panelTransHandler)
                            'LoadPage("poliza", gPanelTitle, False)
                            'ReviewPoliza(gPoliza, True, result)
                            gLicenseID = 0
                            gCurrentLicenseID = 0
                            gMyLastLicense = 0
                            ShowPanel(panelTransHandler)

                            gCurrentTransactionType = 11
                            StartSkuLicense()
                        Case "DESPACHO_GENERAL"
                            UsuarioFinalizaoDetalleDePicking()
                            'ShowPanel(panelMyPicking)
                            'LoadPage("my_waves_tree", gPanelTitle, False)
                        Case "DESPACHO_FISCAL"
                            UsuarioFinalizaoDetalleDePicking()
                            'ShowPanel(panelMyPicking)
                            'LoadPage("my_waves_tree", gPanelTitle, False)
                        Case "DESPACHO_TRASLADO_FISCAL_A_GENERAL"
                            LoadPage("poliza", gPanelTitle, False)
                            ReviewPoliza(gCurrentCodigoPoliza, gNumeroOrden, False, result)
                        Case "REUBICACION_LICENCIA"
                            gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_REALLOC
                            gCurrentTransactionType = gTRANS_TYPE.REUBICACION_COMPLETA
                            ShowPanel(panelTransHandler)
                            LoadPage("lic_realloc", gPanelTitle, True)
                        Case "REUBICACION_PARCIAL"
                            ShowPanel(panelMenu)
                    End Select
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub ctrl_type_charge_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub AdvancedList_Default_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AdvancedList_Default.KeyUp
        ProcessLastKey(e)
    End Sub
End Class
