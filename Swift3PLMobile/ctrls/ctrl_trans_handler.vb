Imports System.Data
Imports Resco.Controls.MessageBox
Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard

Public Class ctrl_trans_handler

    Private Sub DetailView1_ItemChanged(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ItemEventArgs) Handles DetailView1.ItemChanged
        Select Case gCurrentTransactionType
            Case gTRANS_TYPE.INICIALIZACION_GENERAL
                If e.item.Name = "cmbToT" Then
                    gCommercialAggrement = e.item.Value
                End If
            Case gTRANS_TYPE.REUBICACION_COMPLETA

                If e.item.Name = "UiCheckEtiqueta" Then
                    If Convert.ToBoolean(e.item.Value) = True Then
                        DetailView1.Items("txtLicencia").Label = "Scan Etiqueta:"
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_ETIQUETA_REUBICACION
                    Else
                        DetailView1.Items("txtLicencia").Label = "Scan Licencia:"
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_REALLOC
                    End If
                End If

        End Select
    End Sub
    Sub ClearUpOccupancy()
        Me.DetailView1.Items("txtLocation").Text = ""
        Me.DetailView1.Items("lblWarehouse").Text = ""
        With CType(Me.DetailView1.Items("cmbOccupancyLevel"), Resco.Controls.DetailView.ItemAdvancedComboBox)
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub DetailView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ProcessLastKey(e)
    End Sub

    Private Function EstadoDeLicenciaTieneUbicacionValida(ByVal ubicacion As String) As Boolean
        Return Not String.IsNullOrEmpty(ubicacion)
    End Function

    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            UiPanelControlVisualizaSku.Visible = False
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR

                    If gCurrentTransactionType = gTRANS_TYPE.INICIALIZACION_GENERAL Or gCurrentTransactionType = gTRANS_TYPE.RECEPCION_ALMGEN Or gCurrentTransactionType = gTRANS_TYPE.RECEPCION_FISCAL Or gCurrentTransactionType = gTRANS_TYPE.REALLOC_PARTIAL Or gCurrentTransactionType = gTRANS_TYPE.INICIALIZACION Then
                        If gLicenseID <> "" Then

                            Dim srv = New WMS_InfoTrans.WMS_InfoTrans()
                            Dim tieneInventario As Boolean = srv.LicenceHasInventory(gLicenseID, GlobalEnviroment)

                            If tieneInventario AndAlso MessageBox.Show("¿Desea salir de la licencia, cancelando todo lo realizado hasta el momento?", _
                                                "MobilitySCM", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                                Return
                            End If

                            Dim trans = New WMS_Trans.WMS_Trans()
                            Dim pResult As String = String.Empty
                            trans.RollBackALicencia(gLicenseID, GlobalEnviroment, pResult)
                        End If
                    End If


                    Select Case gCurrentTransactionType
                        Case gTRANS_TYPE.AUDITORIA_REC_FISCAL
                            CloseScanner()
                            ShowPanel(panelMenu)
                        Case gTRANS_TYPE.AUDITORIA_DESP_FISCAL
                            CloseScanner()
                            ShowPanel(panelMenu)
                        Case gTRANS_TYPE.INICIALIZACION_GENERAL
                            CloseScanner()
                            ShowPanel(panelMenu)
                        Case Else
                            Select Case gCurrentPage
                                Case "sku_license"
                                    Cursor.Current = Cursors.Default
                                    CloseScanner()
                                    If gMyLastLicense <> 0 Then
                                        Me.btn_first.Text = "Continuar con licencia: " & gMyLastLicense
                                    Else
                                        Me.btn_first.Text = "Iniciar recepcion"
                                    End If
                                    CloseScanner()
                                    ShowPanel(panelTransHandler)
                                    LoadPage("poliza", Me.btn_first.Text, False)
                                    ReviewPoliza(gPoliza, gOrden, True, "")
                                Case "poliza"
                                    CloseScanner()
                                    If gTRANS_TYPE.REALLOC_PARTIAL = gCurrentTransactionType Then
                                        gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                                        ShowPanel(panelInfoHandlerTree)
                                        SetupScanner()
                                    ElseIf gTRANS_TYPE.RECEPCION_ALMGEN = gCurrentTransactionType Then
                                        ShowPanel(panelMyReception)
                                        panelMyReception.GetMyReceptionTasks(gRegimen)
                                        Cursor.Current = Cursors.Default
                                    Else
                                        ShowPanel(panelMenu)

                                    End If


                                Case "wave_picking"
                                    If RollbackSeries() Then
                                        DeleteLabel()
                                        ShowPanelMyPicking()
                                        'ShowPanel(panelMyPicking)
                                    End If
                                Case "audit_summ"
                                    LoadPage("poliza", gPanelTitle, False)
                                Case Else
                                    CloseScanner()
                                    ShowPanel(panelMenu)
                            End Select


                    End Select
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
                    Select Case gCurrentTransactionType
                        Case gTRANS_TYPE.AUDITORIA_REC_FISCAL
                            If Not gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA Then
                                CloseCounting()
                                Exit Sub
                            End If
                        Case gTRANS_TYPE.AUDITORIA_DESP_FISCAL
                            If Not gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA Then
                                CloseCounting()
                                Exit Sub
                            End If
                        Case gTRANS_TYPE.OCCUPANCY
                            Dim xserv As New WMS_Trans.WMS_Trans
                            Dim pResult As String = ""
                            Dim pLocation As String = ""
                            Dim pLevel As Double = 0

                            With CType(Me.DetailView1.Items("cmbOccupancyLevel"), Resco.Controls.DetailView.ItemAdvancedComboBox)
                                pLevel = .EditValue
                            End With

                            pLocation = Me.DetailView1.Items("txtLocation").Text

                            Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = False
                            Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green
                            Dim pText() As String = {"SI", "NO"}

                            If MessageBoxEx.ShowYesCancel("Confirma Nivel de ocupación?", True, pText) Then
                                Cursor.Current = Cursors.WaitCursor

                                If Not xserv.RegisterOccupancy(pLocation, GlobalUserID, pLevel, pResult, GlobalEnviroment) Then
                                    Notify(pResult, True)
                                Else
                                    ClearUpOccupancy()
                                End If
                                Cursor.Current = Cursors.Default
                            End If

                    End Select

                    Dim location As String = ""

                    Select Case gCurrentPage
                        Case "sku_license"
                            Select Case gCurrentTransactionType
                                Case gTRANS_TYPE.RECEPCION_FISCAL
                                    If gHasLogisticInfo Then
                                        gComments = panelRecFiscalLogisInfo.txtComments.Text
                                    Else
                                        gComments = ""
                                    End If
                                    If gPendingSKU Then
                                        ProcessSKU()
                                    End If

                                    location = GetLicenseByStatus()


                                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_RECEP_FISCAL
                                    panelRecFiscalStep2.lblTitle.Text = "Poliza: " & gPoliza & "/Orden: " & gNumeroOrden & " Licencia: " & gLicenseID
                                    panelRecFiscalStep2.LBL_LOCATION.Text = IIf(String.IsNullOrEmpty(location), "Scan Ubicación (Recep.Fiscal)", "Scan Ubicación (" + location + ")")
                                    panelRecFiscalStep2.LBL_LOCATION.Tag = location

                                    panelRecFiscalStep2.btnStatus.Visible = False
                                    panelRecFiscalStep2.UIVistaUbicacionesSugeridas.Visible = False
                                    panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = gMuestraBotonSugerenciaReubicacion
                                    ShowPanel(panelRecFiscalStep2)

                                Case gTRANS_TYPE.RECEPCION_ALMGEN
                                    If gHasLogisticInfo Then
                                        gComments = panelRecFiscalLogisInfo.txtComments.Text
                                    Else
                                        gComments = ""
                                    End If
                                    If gPendingSKU Then

                                        If Not ValidarIngresoRecepcion() Then
                                            Return
                                        End If

                                        ProcessSKU()
                                    End If
                                    location = GetLicenseByStatus()


                                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_RECEP_ALMGEN
                                    panelRecFiscalStep2.lblTitle.Text = "Poliza: " & gPoliza & "/Orden: " & gNumeroOrden & " Licencia: " & gLicenseID
                                    panelRecFiscalStep2.LBL_LOCATION.Text = IIf(String.IsNullOrEmpty(location), "Scan Ubicación (Recep.Gen)", "Scan Ubicación (" + location + ")")
                                    panelRecFiscalStep2.LBL_LOCATION.Tag = location
                                    panelRecFiscalStep2.btnStatus.Visible = False
                                    panelRecFiscalStep2.UIVistaUbicacionesSugeridas.Visible = False
                                    panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = gMuestraBotonSugerenciaReubicacion
                                    ShowPanel(panelRecFiscalStep2)
                                Case gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL
                                    If gHasLogisticInfo Then
                                        gComments = panelRecFiscalLogisInfo.txtComments.Text
                                    Else
                                        gComments = ""
                                    End If
                                    If gPendingSKU Then
                                        ProcessSKU()
                                    End If
                                    location = GetLicenseByStatus()

                                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_TRASLADO_FISCAL_ALMGEN
                                    panelRecFiscalStep2.lblTitle.Text = "Poliza: " & gPoliza & "/Orden: " & gNumeroOrden & " Licencia: " & gLicenseID
                                    panelRecFiscalStep2.LBL_LOCATION.Text = IIf(String.IsNullOrEmpty(location), "Scan Ubicación (Traslado):", "Scan Ubicación (" + location + ")")
                                    panelRecFiscalStep2.LBL_LOCATION.Tag = location
                                    panelRecFiscalStep2.btnStatus.Visible = False
                                    panelRecFiscalStep2.UIVistaUbicacionesSugeridas.Visible = False
                                    panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = False
                                    ShowPanel(panelRecFiscalStep2)

                                Case gTRANS_TYPE.INICIALIZACION
                                    If gHasLogisticInfo Then
                                        gComments = panelRecFiscalLogisInfo.txtComments.Text
                                    Else
                                        gComments = ""
                                    End If
                                    If gPendingSKU Then
                                        ProcessSKU()
                                    End If
                                    location = GetLicenseByStatus()

                                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_INICIALIZACION
                                    panelRecFiscalStep2.lblTitle.Text = "Poliza: " & gPoliza & "/Orden: " & gNumeroOrden & " Licencia: " & gLicenseID
                                    panelRecFiscalStep2.LBL_LOCATION.Text = IIf(String.IsNullOrEmpty(location), "Scan Ubicación (Inicialización):", "Scan Ubicación (" + location + ")")
                                    panelRecFiscalStep2.LBL_LOCATION.Tag = location

                                    panelRecFiscalStep2.btnStatus.Visible = False
                                    panelRecFiscalStep2.UIVistaUbicacionesSugeridas.Visible = False
                                    panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = False
                                    ShowPanel(panelRecFiscalStep2)

                                Case gTRANS_TYPE.INICIALIZACION_GENERAL

                                    If gHasLogisticInfo Then
                                        gComments = panelRecFiscalLogisInfo.txtComments.Text
                                    Else
                                        gComments = ""
                                    End If
                                    If gPendingSKU Then
                                        ProcessSKU()
                                    End If
                                    'ojo
                                    'Dim xserM As New WMS_Materials.WMS_Materials

                                    'Dim ds As DataSet
                                    'Dim pResult As String
                                    'ds = xserM.GetTotalFactorVolumeLicense(gLicenseID, pResult, GlobalEnviroment)

                                    'panelRecFiscalStep2.txtMT2.Text = "0"
                                    'If pResult = "OK" Then
                                    '    If Not ds.Tables(0).Rows.Count = 0 Then
                                    '        panelRecFiscalStep2.txtMT2.Text = ds.Tables(0).Rows(0)(0).ToString()
                                    '    End If
                                    'Else
                                    '    Notify(pResult, True)
                                    'End If
                                    location = GetLicenseByStatus()
                                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_INICIALIZACION
                                    panelRecFiscalStep2.lblTitle.Text = "Poliza: " & gPoliza & "/Orden: " & gNumeroOrden & " Licencia: " & gLicenseID
                                    panelRecFiscalStep2.LBL_LOCATION.Text = IIf(String.IsNullOrEmpty(location), "Scan Ubicación (Inicialización):", "Scan Ubicación (" + location + ")")
                                    panelRecFiscalStep2.LBL_LOCATION.Tag = location
                                    panelRecFiscalStep2.btnStatus.Visible = False
                                    panelRecFiscalStep2.UIVistaUbicacionesSugeridas.Visible = False
                                    panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = False
                                    ShowPanel(panelRecFiscalStep2)


                                Case gTRANS_TYPE.DESPACHO_FISCAL
                                    If gHasLogisticInfo Then
                                        gComments = panelRecFiscalLogisInfo.txtComments.Text
                                    Else
                                        gComments = ""
                                    End If
                                    If gPendingSKU Then
                                        ProcessSKU()
                                    End If

                                    gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_DESPACHO_FISCAL
                                    panelRecFiscalStep2.lblTitle.Text = "Poliza: " & gPoliza & "/Orden: " & gNumeroOrden & " Licencia: " & gLicenseID
                                    panelRecFiscalStep2.LBL_LOCATION.Text = "Scan Ubicación (Desp.Fiscal):"
                                    panelRecFiscalStep2.btnStatus.Visible = False
                                    panelRecFiscalStep2.UIVistaUbicacionesSugeridas.Visible = False
                                    panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = False
                                    ShowPanel(panelRecFiscalStep2)

                                Case gTRANS_TYPE.DESPACHO_GENERAL
                                    If gHasLogisticInfo Then
                                        gComments = panelRecFiscalLogisInfo.txtComments.Text
                                    Else
                                        gComments = ""
                                    End If
                                    If gPendingSKU Then
                                        ProcessSKU()
                                    End If

                                    gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_DESPACHO_ALMGEN
                                    panelRecFiscalStep2.lblTitle.Text = "Poliza: " & gPoliza & "/Orden: " & gNumeroOrden & " Licencia: " & gLicenseID
                                    panelRecFiscalStep2.LBL_LOCATION.Text = "Scan Ubicación (Desp.Gen):"
                                    panelRecFiscalStep2.btnStatus.Visible = False
                                    panelRecFiscalStep2.UIVistaUbicacionesSugeridas.Visible = False
                                    panelRecFiscalStep2.UIbtnUbicacionesSugeridas.Visible = False
                                    ShowPanel(panelRecFiscalStep2)
                            End Select

                    End Select
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try

    End Sub

    Private Sub DeleteLabel()
        Try
            Dim serverTrans As New WMS_Trans.WMS_Trans
            Dim result As String = String.Empty
            If Not serverTrans.DeletePickingLabel(gCurrentLabel, result, GlobalEnviroment) Then
                Notify(result, True)
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Function GetLicenseByStatus() As String
        Dim location As String = ""
        Dim webServiceInfoTrans As New WMS_InfoTrans.WMS_InfoTrans
        Dim dtValidated As DataTable
        Dim resultValidated As String = ""
        dtValidated = webServiceInfoTrans.ValidateStatusInMaterialsLicense(gLicenseID, GlobalEnviroment, resultValidated)

        If resultValidated.ToUpper.Equals("OK") Then
            If EstadoDeLicenciaTieneUbicacionValida(dtValidated(0)("DbData").ToString) Then
                location = dtValidated(0)("DbData").ToString
            End If
        End If

        Return location
    End Function

    Sub CloseCounting()
        Try
            Dim Xserv As New WMS_Trans.WMS_Trans
            Dim pResult As String = ""

            Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = False
            Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green
            Dim pText() As String = {"SI", "NO"}

            If MessageBoxEx.ShowYesCancel("Confirma Finalizar Conteo?", True, pText) Then
                Cursor.Current = Cursors.WaitCursor
                If Xserv.AuditFinishCounting(CInt(panelTransHandler.DetailView1.Items("Header1").Tag), GlobalUserID, gPanelOption, pResult, GlobalEnviroment) Then
                    Cursor.Current = Cursors.Default
                    ShowPanel(panelMenu)
                Else
                    Cursor.Current = Cursors.Default
                    Notify(pResult, True)
                End If

            End If

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify("btnFinishAudit_Click: " + ex.Message, True)
        End Try
    End Sub

    Private Function RollbackSeries() As Boolean
        Try
            Dim resultado = String.Empty
            Dim servicioTrans = New WMS_Trans.WMS_Trans
            Dim dt = servicioTrans.RollbackSerialNumbersOnProcess(gCurrentWavePicking, gCurrentLicenseID, panelSerialNumberProcess.materialId, GlobalUserID, panelSerialNumberProcess.tipoTarea, GlobalEnviroment, resultado)
            If String.IsNullOrEmpty(resultado) Then
                Select Case dt.Rows(0)("Resultado")
                    Case ResultadoOperacionTipo.Fallo
                        Notify(dt.Rows(0)("Mensaje"), True)
                    Case ResultadoOperacionTipo.Exito
                        Return True
                End Select
            Else
                Notify(resultado, True)
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
        Return False
    End Function

    Private Sub btn_first_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btn_first.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub btn_last_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btn_last.KeyUp
        ProcessLastKey(e)
    End Sub
    Private Sub btn_middle_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btn_middle_1.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub btn_middle_2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btn_middle_2.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub ctrl_trans_handler_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        Try
            panelTransHandler.DetailView1.Items("ScannedPoliza").Control.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ctrl_trans_handler_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub UiTouchPanel_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiTouchPanel.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub TouchContainer_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ProcessLastKey(e)
    End Sub

    Private Sub DetailView1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DetailView1.KeyPress
        If leftRelocationComplete And e.KeyChar = ChrW(Keys.Tab) Then
            Dim ev As System.Windows.Forms.KeyEventArgs = New System.Windows.Forms.KeyEventArgs(Keys.Tab)
            ProcessLastKey(ev)
        End If
    End Sub



    Private Sub AdvancedList1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AdvancedList1.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub DetailView1_KeyUp_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DetailView1.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub UIbtnUbicacionesSugeridas_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim xserv As New WMS_Materials.WMS_Materials
        Dim xdTable As DataTable
        Dim pResult As String = "OK"
        Dim license As String = ""
        Try
            license = DetailView1.Items("txtLicencia").Text
            If license = "" Then
                Notify("Primero debe escanear la licencia", True)
                Exit Sub
            End If
            xdTable = xserv.GetSuggestedLocations(license, GlobalUserID, GlobalEnviroment, pResult)
            'UIVistaUbicacionesSugeridas.DataSource = xdTable
            'UIVistaUbicacionesSugeridas.Visible = True
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub UiPanelSelectedOperacionSku_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiPanelSelectedOperacionSku.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub UiBotonVerKus_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiBotonVerSkus.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub UiBotonCancelarMostrarSkus_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiBotonCancelarMostrarSkus.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub UiRadioRecepcionados_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiRadioRecepcionados.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub UiRadioDocumento_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiRadioDocumento.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub UiBotonCancelarMostrarSkus_Click(ByVal sender As System.Object, ByVal e As Resco.UIElements.UIMouseEventArgs) Handles UiBotonCancelarMostrarSkus.Click
        UiPanelControlVisualizaSku.Visible = False
    End Sub
End Class
