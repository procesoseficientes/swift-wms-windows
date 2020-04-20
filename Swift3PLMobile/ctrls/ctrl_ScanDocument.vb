Imports Resco.Controls.MessageBox
Imports MobilityScm.Keyboard

Public Class ctrl_ScanDocument

    Public Sub DocumentScanned(ByVal document As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim servicio As New WMS_Trans.WMS_Trans
            Dim pResult As String = String.Empty

            Dim exito As Boolean = servicio.ValidateScannedReceptionDocument(document, GlobalUserID, pResult, GlobalEnviroment)

            If exito Then
                gDocumentType = pResult.Split("|").GetValue(0)
                UiTextoDocumento.Tag = pResult.Split("|").GetValue(1)
                UiTextoDocumento.Text = document
                UiTextoDocumento.Enabled = False
                UiBotonGenerar.Visible = True
            Else
                Notify("Validación documento: " + pResult, True)
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Notify("SkuScanned: " + ex.Message, True)
        End Try
    End Sub

    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                    DocumentScanned(UiTextoDocumento.Text)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    ShowPanel(panelMenu)
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub
    Private Sub UiTextoDocumento_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiTextoDocumento.KeyUp
        ProcessLastKey(e)
    End Sub

    Public Sub UsuarioDeseaGenerarDocumento()
        Try

            Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = False
            Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green
            Dim pText() As String = {"SI", "NO"}
            If MessageBoxEx.ShowYesCancel("¿Está seguro que desea generar las tareas para el documento? " + UiTextoDocumento.Text, True, pText) Then
                Cursor.Current = Cursors.WaitCursor
                Dim servicio As New WMS_Trans.WMS_Trans
                Dim pResult As String = String.Empty

                Dim exito As Boolean = servicio.ProcessScannedDocument(gDocumentType, UiTextoDocumento.Tag, GlobalUserID, pResult, GlobalEnviroment)

                If exito Then
                    Select Case gDocumentType
                        Case MobilityScm.Modelo.Tipos.Enums.GetStringValue(MobilityScm.Modelo.Tipos.TipoDocumentoExterno.Manifiesto_Carga)
                            

                            Select Case pResult.Split("|").GetValue(0) 'Valor orden de venta
                                Case MobilityScm.Modelo.Tipos.Enums.GetStringValue(MobilityScm.Modelo.Tipos.TipoDemandaDespacho.OrdenVenta)
                                    gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                                    gCurrentTransactionType = gTRANS_TYPE.RECEPCION_ALMGEN
                                    ShowPanel(panelMyReception)
                                    gRegimen = "GENERAL"
                                    LoadPage("reception_task", gPanelTitle, False)

                                Case MobilityScm.Modelo.Tipos.Enums.GetStringValue(MobilityScm.Modelo.Tipos.TipoDemandaDespacho.SolicitudTraslado)
                                    If pResult.Split("|").Length <> 4 Then
                                        Notify("Error: " + pResult, True)
                                    End If
                                    gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                                    gCurrentTransactionType = gTRANS_TYPE.RECEPCION_ALMGEN
                                    gRegimen = "GENERAL"
                                    gRegiP = gRegimen
                                    gTipoP = "INGRESO"

                                    gPoliza = pResult.Split("|").GetValue(1)
                                    gOrden = pResult.Split("|").GetValue(2)
                                    gTaskId = pResult.Split("|").GetValue(3)
                                    pResult = String.Empty
                                    ShowPanel(panelTransHandler)
                                    LoadPage("poliza", gPanelTitle, True)
                                    ReviewPoliza(gPoliza, gOrden, True, pResult)
                                    gDocumentType = String.Empty
                            End Select
                            

                    End Select
                Else
                    Notify("Validación documento: " + pResult, True)
                End If

            End If
        Catch ex As Exception
            Notify("Generar: " + ex.Message, True)
        End Try
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub UiBotonGenerar_Click(ByVal sender As System.Object, ByVal e As Resco.UIElements.UIMouseEventArgs) Handles UiBotonGenerar.Click
        UsuarioDeseaGenerarDocumento()
    End Sub

    Private Sub UiPanelScanDocument_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiPanelScanDocument.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub UiBotonGenerar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiBotonGenerar.KeyUp
        ProcessLastKey(e)
    End Sub
End Class
