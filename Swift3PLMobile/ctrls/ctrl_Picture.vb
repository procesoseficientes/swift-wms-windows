Imports System.Xml
Imports System.Data
Imports System.IO
Imports System.Text
Imports System
Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard

Public Class ctrl_Picture
    Public gLastPict As String = ""
    Function SavePic(ByVal pPoliza As String, ByRef pResult As String) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim xserv As New WMS_Polizas.WMS_Polizas

            If (gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA_EN_FOTOGRAFIA_BASC) Or (gCurrentTransactionType = gTRANS_TYPE.AUDITORIA_DESP_FISCAL Or gCurrentTransactionType = gTRANS_TYPE.AUDITORIA_REC_FISCAL) Then
                If Not xserv.AgregarImagenAPoliza(pPoliza, imageDataInBytes, GlobalUserID, CInt(panelTransHandler.DetailView1.Items("Header1").Tag), IIf(gPanelOption = "MMI_AUDIT_REC_FISCAL", "RECEPTION", "DISPATCH"), pResult, GlobalEnviroment) Then
                    Cursor.Current = Cursors.Default
                    Return False
                End If
            End If

            Cursor.Current = Cursors.Default
            panelTakePicture.lblStatus.Text = "Guardada " + Now.ToString
            Return True

        Catch ex As Exception
            pResult = ex.Message
            Cursor.Current = Cursors.Default
        End Try
    End Function

 

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

       
    End Sub

    Private Sub ctrl_Picture_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        Try
            'gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA_EN_FOTOGRAFIA_BASC

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ctrl_Picture_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub ctrl_Picture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click

    End Sub

    Private Sub TouchRadioButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngreso.Click

    End Sub
    Sub SaveAndContinue()
        Dim pResult As String = ""
        Cursor.Current = Cursors.WaitCursor
        Select Case gCurrentScannerService

            Case gSCANNER_SERVICES.LEER_POLIZA_EN_FOTOGRAFIA_BASC
                If SavePic(Me.lblScannedPolicy.Text, pResult) Then
                    Me.lblStatus.Text = "Imagen grabada " & Now.ToString
                    panelTakePicture.PictureBox_1.Dock = DockStyle.None
                Else
                    Cursor.Current = Cursors.Default
                    MessageBox.Show(pResult)
                End If
                StartAcquisition()

            Case gSCANNER_SERVICES.LEER_NUEVO_SKU
                Cursor.Current = Cursors.Default
                
                If gIsNewSKU Then
                    Dim xserv As New WMS_Materials.WMS_Materials
                    xserv.QuickSKU_Mantainance(gClientOwner, panelTransHandler.DetailView1.Items("lblSKUName").Text, panelTransHandler.DetailView1.Items("txtScannedSKU").Text, GlobalUserID, imageDataInBytes, pResult, GlobalEnviroment)
                    gComments = ""
                    If pResult = "OK" Then
                        SaveSKULicense()
                    End If
                End If

                Cursor.Current = Cursors.Default
                panelTakePicture.lblStatus.Text = "GRABADO..."
                Select Case gCurrentTransactionType
                    Case gTRANS_TYPE.INICIALIZACION
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_INICIALIZACION
                    Case gTRANS_TYPE.RECEPCION_FISCAL
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_RECEPCION_FISCAL
                End Select
                SetupScanner()
                ShowPanel(panelTransHandler)
        End Select
        If gCurrentTransactionType = gTRANS_TYPE.AUDITORIA_DESP_FISCAL Or gCurrentTransactionType = gTRANS_TYPE.AUDITORIA_REC_FISCAL Then
            If SavePic(Me.lblScannedPolicy.Text, pResult) Then
                Me.lblStatus.Text = "Imagen grabada " & Now.ToString
                panelTakePicture.PictureBox_1.Dock = DockStyle.None
            Else
                Cursor.Current = Cursors.Default
                MessageBox.Show(pResult)
            End If
            StartAcquisition()
        End If
        Cursor.Current = Cursors.Default
    End Sub
    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)

        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                    StartAcquisition()

                    'BUTTON DO
                    If Not gCurrentTransactionType = gTRANS_TYPE.AUDITORIA_DESP_FISCAL Or gCurrentTransactionType = gTRANS_TYPE.AUDITORIA_REC_FISCAL Then
                        Me.lblScanPrompt.Visible = True
                        Me.lblScannedPolicy.Text = "..."
                        Me.btnEgreso.Visible = False
                        Me.btnIngreso.Visible = False
                        Me.PictureBox_1.Visible = False
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA_EN_FOTOGRAFIA_BASC
                        SetupScanner()
                    End If

                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    ShowPanel(panelMenu)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                    Try

                        Select Case gCurrentScannerService
                            Case gSCANNER_SERVICES.LEER_POLIZA_EN_FOTOGRAFIA_BASC
                                ShowPanel(panelMenu)
                            Case gSCANNER_SERVICES.LEER_NUEVO_SKU
                                SetupScanner()
                                gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_RECEPCION_FISCAL
                                ShowPanel(panelRecFiscalStep1)
                        End Select

                        Select Case gCurrentTransactionType
                            Case gTRANS_TYPE.AUDITORIA_DESP_FISCAL
                                SetupScanner()
                                ShowPanel(panelTransHandler)
                                Exit Sub
                            Case gTRANS_TYPE.AUDITORIA_REC_FISCAL
                                SetupScanner()
                                ShowPanel(panelTransHandler)
                                Exit Sub
                        End Select

                    Catch ex As Exception
                    End Try
                    ShowPanel(panelMenu)

                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
                    SaveAndContinue()
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try

    End Sub

    Private Sub TouchRadioButton1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnIngreso.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub TouchRadioButton2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnEgreso.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub PictureBox_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox_1.Click

    End Sub
End Class
