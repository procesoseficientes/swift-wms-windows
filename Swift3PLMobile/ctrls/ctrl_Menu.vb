Imports MobilityScm.Louncher
Imports MobilityScm.Modelo.Vistas
Imports MobilityScm.Keyboard
Imports MobilityScm.Modelo.Vistas.Operaciones.Vistas
Imports MobilityScm.Modelo.Vistas.Certificacion.Vistas
Imports MobilityScm.Modelo.Vistas.EntregaDeDespacho.Vistas

Public Class ctrl_Menu
    Public pPanelName As String = ""


    Private Sub AdvancedList1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AdvancedList1.KeyUp

        If leftRelocationComplete Then
            leftRelocationComplete = False
            Exit Sub
        End If

        Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
            Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                frmBase.ShowWindowsMenu(True)
                frmBase.Close()
                Application.Exit()
            Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
                BringMenu()
                Notify("Environment: " & GlobalEnviroment, False)
        End Select

    End Sub

    Private Sub AdvancedList1_RowEntered(ByVal sender As Object, ByVal e As Resco.Controls.AdvancedList.RowEnteredEventArgs) Handles AdvancedList1.RowEntered

        Try
            pPanelName = e.Row("OPTION_PANEL").ToString
            gPanelOption = e.Row("OPTION_ID").ToString
            gPanelTitle = e.Row("OPTION_DESC").ToString
            gCurrentTransName = IIf(IsDBNull(e.Row("OPTION_TRANS_TYPE").ToString), "N/A", e.Row("OPTION_TRANS_TYPE").ToString)

            Timer1.Enabled = True
        Catch ex As Exception
            Notify("RowEntered: " + ex.Message, True)
        End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            gLicenseID = ""
            gTaskId = ""
            gLocationSpotTarget = ""
            gCurrentTransactionType = gTRANS_TYPE.NONE
            Select Case gPanelOption
                Case "MMI_RECEP_FISCAL"
                    Timer1.Enabled = False
                    gRegimen = "FISCAL"
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA
                    gCurrentTransactionType = gTRANS_TYPE.RECEPCION_FISCAL
                    ShowPanel(panelTransHandler)

                    LoadPage("poliza", gPanelTitle, True)

                    gCurrentScannerService = -1
                    gCurrentTransactionType = gTRANS_TYPE.RECEPCION_FISCAL
                    ShowPanel(panelMyReception)
                    LoadPage("reception_task", gPanelTitle, False)

                Case "MMI_RECEP_ALMGEN"
                    Timer1.Enabled = False

                    gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                    gCurrentTransactionType = gTRANS_TYPE.RECEPCION_ALMGEN
                    ShowPanel(panelMyReception)
                    gRegimen = "GENERAL"
                    LoadPage("reception_task", gPanelTitle, False)

                Case "MMI_PHOTOS_BASC"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA_EN_FOTOGRAFIA_BASC
                    gCurrentTransactionType = gTRANS_TYPE.NONE

                    SetupScanner()
                    panelTakePicture.lblScanPrompt.Visible = True
                    panelTakePicture.btnEgreso.Visible = False
                    panelTakePicture.btnEgreso.Visible = False
                    panelTakePicture.PictureBox_1.Visible = False

                    ShowPanel(panelTakePicture)

                Case "MMI_TRASLADO_FAG"
                    Timer1.Enabled = False
                    ShowPanelMyPicking()
                    'ShowPanel(panelMyPicking)
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA
                    gCurrentTransactionType = gTRANS_TYPE.TRASLADO_FISCAL_A_GENERAL
                    LoadPage("my_waves_tree", gPanelTitle, False)

                Case "MMI_INICIALIZACION_GEN"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA
                    gCurrentTransactionType = gTRANS_TYPE.INICIALIZACION_GENERAL
                    ShowPanel(panelTransHandler)
                    gRegimen = "GENERAL"
                    LoadPage("init_general", gPanelTitle, True)

                Case "MMI_INICIALIZACION_FIS"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA
                    gCurrentTransactionType = gTRANS_TYPE.INICIALIZACION
                    ShowPanel(panelTransHandler)
                    gRegimen = "FISCAL"
                    LoadPage("poliza", gPanelTitle, True)

                Case "MMI_INV_X_LIC"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                    gCurrentTransactionType = gTRANS_TYPE.NONE
                    ShowPanel(panelInfoHandlerTree) 'cambio H

                    Dim nameXml As String = "info_inv_x_lic_tree"

                    If (handheld.ToUpper() = "MOTOROLA WINCE") Then
                        nameXml = "info_inv_x_lic_tree_MC92"
                    End If

                    LoadPage(nameXml, gPanelTitle, True) 'cambio H

                    panelInfoHandlerTree.AdvancedTree_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SCAN LICENCIA..."
                    panelInfoHandlerTree.AdvancedTree_Default.ShowFooter = True
                    panelInfoHandlerTree.txtInputedData.Enabled = True
                    panelInfoHandlerTree.AdvancedTree_Default.Nodes.Clear()

                Case "MMI_INV_X_POLIZA" 'cambio h
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA_CONSULTA
                    gCurrentTransactionType = gTRANS_TYPE.NONE
                    ShowPanel(panelInfoHandlerTree)
                    Dim nameXml As String = "info_inv_x_poliza_tree"

                    If (handheld.ToUpper() = "MOTOROLA WINCE") Then
                        nameXml = "info_inv_x_poliza_tree_MC92"
                    End If

                    LoadPage(nameXml, gPanelTitle, True)

                    panelInfoHandlerTree.AdvancedTree_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SCAN POLIZA..."
                    panelInfoHandlerTree.AdvancedTree_Default.Nodes.Clear()
                    panelInfoHandlerTree.AdvancedTree_Default.ShowFooter = False


                Case "MMI_INV_X_SKU" 'cambio h
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_CONSULTA
                    gCurrentTransactionType = gTRANS_TYPE.NONE
                    ShowPanel(panelInfoHandlerTree)

                    Dim nameXml As String = "info_inv_x_sku_tree"

                    If (handheld.ToUpper() = "MOTOROLA WINCE") Then
                        nameXml = "info_inv_x_sku_tree_MC92"
                    End If

                    LoadPage(nameXml, gPanelTitle, True)

                    panelInfoHandlerTree.AdvancedTree_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SCAN SKU..."
                    panelInfoHandlerTree.AdvancedTree_Default.Nodes.Clear()
                    panelInfoHandlerTree.AdvancedTree_Default.ShowFooter = False

                Case "MMI_INV_X_LOC" 'cambio h
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_CONSULTA
                    gCurrentTransactionType = gTRANS_TYPE.NONE
                    ShowPanel(panelInfoHandlerTree)

                    Dim nameXml As String = "info_inv_x_loc_tree"

                    If (handheld.ToUpper() = "MOTOROLA WINCE") Then
                        nameXml = "info_inv_x_loc_tree_MC92"
                    End If

                    LoadPage(nameXml, gPanelTitle, True)

                    panelInfoHandlerTree.AdvancedTree_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "scan ubicación..."
                    panelInfoHandlerTree.AdvancedTree_Default.Nodes.Clear()
                    panelInfoHandlerTree.AdvancedTree_Default.ShowFooter = False

                Case "MMI_LICENSE_REPRINT"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_REIMPRESION
                    gCurrentTransactionType = gTRANS_TYPE.NONE
                    ShowPanel(panelInfoHandler)
                    LoadPage("info_reprint_lic", gPanelTitle, True)
                    panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "INGRESE LICENCIA..."

                Case "MMI_DESPACHO_FISCAL"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                    gCurrentTransactionType = gTRANS_TYPE.DESPACHO_FISCAL
                    ShowPanelMyPicking()
                    'ShowPanel(panelMyPicking)
                    LoadPage("my_waves_tree", gPanelTitle, False)

                Case "MMI_DESPACHO_ALMGEN"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                    gCurrentTransactionType = gTRANS_TYPE.DESPACHO_GENERAL
                    ShowPanelMyPicking()
                    'ShowPanel(panelMyPicking)
                    LoadPage("my_waves_tree", gPanelTitle, False)

                Case "MMI_AUDIT_REC_FISCAL"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA_AUDITORIA_REC_FISCAL
                    gCurrentTransactionType = gTRANS_TYPE.AUDITORIA_REC_FISCAL
                    ShowPanel(panelTransHandler)

                    gRegimen = "FISCAL"
                    LoadPage("poliza", gPanelTitle, True)

                Case "MMI_REALLOC_LIC"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_REALLOC
                    gCurrentTransactionType = gTRANS_TYPE.REUBICACION_COMPLETA

                    ShowPanel(panelTransHandler)
                    LoadPage("lic_realloc", gPanelTitle, True)

                Case "MMI_AUDIT_DISPATCH_FISCAL"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA_AUDITORIA_DESP_FISCAL
                    gCurrentTransactionType = gTRANS_TYPE.AUDITORIA_DESP_FISCAL
                    ShowPanel(panelTransHandler)

                    gRegimen = "FISCAL"
                    LoadPage("poliza", gPanelTitle, True)

                Case "MMI_AUDIT_REC_SET_SUMM"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA_EN_AUDIT_SUMM
                    gCurrentTransactionType = gTRANS_TYPE.AUDITORIA_REC_SUMM
                    ShowPanel(panelTransHandler)

                    gRegimen = "FISCAL"
                    LoadPage("poliza", gPanelTitle, True)

                Case "MMI_PRINT_SKU"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_CATALOGO_SKU_SEC1
                    gCurrentTransactionType = gTRANS_TYPE.NONE
                    ShowPanel(panelInfoHandler)
                    LoadPage("skus_s1", gPanelTitle, True)
                    panelInfoHandler.AdvancedList_Default.Templates(0).CellTemplates(0).CellSource.ConstantData = "SCAN/INPUT SKU"
                    Dim xgrid As New SmartGridClass
                    Dim pResult As String = ""

                Case "MMI_CONTEOS"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_CONTEO
                    gCurrentTransactionType = gTRANS_TYPE.CONTEO
                    ShowPanel(panelMyCounting)
                    LoadPage("counting_tasks", gPanelTitle, True)

                Case "MMI_OCCUPANCY"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_OCUPACION
                    gCurrentTransactionType = gTRANS_TYPE.OCCUPANCY
                    ShowPanel(panelTransHandler)
                    LoadPage("occupancy", gPanelTitle, True)

                Case "MMI_EXIT"
                    CloseScanner()
                    frmBase.ShowWindowsMenu(True)
                    frmBase.Close()
                    Application.Exit()

                Case "MMI_ACUSE_RECIBO"
                    Timer1.Enabled = False
                    'SetupScanner()
                    panelAcuseRecibo.txtScanPoliza.Text = ""
                    panelAcuseRecibo.txtNoContenedor.Text = ""
                    panelAcuseRecibo.txtNoMarchamo.Text = ""
                    panelAcuseRecibo.txtPlacaTransporte.Text = ""
                    panelAcuseRecibo.txtFob.Text = ""
                    panelAcuseRecibo.txtCodigoTransporte.Text = ""
                    panelTomarFoto.NumeroDeFotos = 0

                    panelTomarFoto.LimpiarImgVista()
                    panelTomarFoto.Fotos(0) = New Byte() {}
                    panelTomarFoto.Fotos(1) = New Byte() {}
                    panelTomarFoto.Fotos(2) = New Byte() {}

                    panelAcuseRecibo.txtScanPoliza.SetFocus()
                    ShowPanel(panelAcuseRecibo)


                Case "MMI_EXPLODE_MASTER_PACK"
                    Timer1.Enabled = False
                    SetupScanner()
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_PARA_MASTER_PACK
                    panelExplodeMasterPack.LimpiarControles()
                    ShowPanel(panelExplodeMasterPack)

                Case "MMI_PHISICAL_COUTING"
                    gCurrentScannerService = -1
                    Timer1.Enabled = False
                    TareaConteo.Create().ShowPane()
                Case "MMI_LOCATION_CONSULTATION"
                    gCurrentScannerService = -1
                    Timer1.Enabled = False
                    ConsultaDeBodega.Create().ShowPane()

                Case "MMI_MATERIAL_CONSULTATION"
                    gCurrentScannerService = -1
                    Timer1.Enabled = False
                    ConsultaDeMaterial.Create().ShowPane()
                Case "MMI_TASK_REPLENISHMENT"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_CONSULTA
                    gCurrentTransactionType = gTRANS_TYPE.REUBICACION_POR_REABASTECIMIENTO
                    ShowPanelMyPicking()
                    'ShowPanel(panelMyPicking)
                    LoadPage("my_waves_tree", gPanelTitle, False)

                Case "MMI_RECEPTION_BY_DOCUMENT"
                    Timer1.Enabled = False
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_CODIGO_DOCUMENTO_RECEPCION
                    gCurrentTransactionType = gTRANS_TYPE.ESCANEAR_DOCUMENTO_EXTERNO_RECEPCION
                    panelScanDocument.UiEtiquetaTitulo.Text = "Escanear documento recepción"
                    panelScanDocument.UiBotonGenerar.Visible = False
                    panelScanDocument.UiTextoDocumento.Enabled = True
                    panelScanDocument.UiTextoDocumento.Text = ""
                    panelScanDocument.UiTextoDocumento.Tag = ""
                    SetupScanner()
                    ShowPanel(panelScanDocument)
                Case "MMI_IMPLOSION_MASTER_PACK"
                    gCurrentScannerService = -1
                    Timer1.Enabled = False
                    GenerarImplosion.Create().ShowPane()
                Case "MMI_CERTIFICATION"
                    gCurrentScannerService = -1
                    Timer1.Enabled = False
                    CertificacionDeIngreso.Create().ShowPane()
                Case "MMI_UNIFICACION_LICENCIAS"
                    gCurrentScannerService = -1
                    Timer1.Enabled = False
                    gCurrentTransactionType = gTRANS_TYPE.UNIFICAR_LICENCIA
                    EscaneadoDeUnificacion.Create(Nothing, Nothing).ShowPane()

                Case "MMI_CONSULTA_ETIQUETA"
                    gCurrentScannerService = -1
                    Timer1.Enabled = False
                    ConsultaDeEtiquetaPicking.Create().ShowPane()
                Case "MMI_DELIBVERY_DISPATCH"
                    gCurrentScannerService = -1
                    Timer1.Enabled = False
                    EntregaDeDespacho.Create.ShowPane()
            End Select
        Catch ex As Exception
            Notify("TimerTick: " + ex.Message, True)
        End Try
    End Sub

    Sub cambiarPantalla(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, UserControl).Visible = False
        ShowPanel(panelMenu)
    End Sub
    Private Sub ctrl_Menu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        Me.AdvancedList1.Width = panelLogin.Width
        Me.AdvancedList1.Height = panelLogin.Height
    End Sub
    Private Sub ctrl_Menu_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp

        Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
            Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                frmBase.ShowWindowsMenu(True)
                Application.Exit()
        End Select

    End Sub

    Private Sub AdvancedList1_CellClick(ByVal sender As System.Object, ByVal e As Resco.Controls.AdvancedList.CellEventArgs) Handles AdvancedList1.CellClick

    End Sub
End Class
