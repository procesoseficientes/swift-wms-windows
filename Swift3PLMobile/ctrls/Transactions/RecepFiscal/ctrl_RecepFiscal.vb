Imports System.Data
Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard
Public Class ctrl_RecepFiscal
    Dim countdown As Boolean = False
    Dim CurrentBarCount As Integer = 0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowPanel(panelMenu)
    End Sub
    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                    SetupScanner()
                    With panelRecepFiscal
                        .LBL_CONTAINER.Visible = False
                        .LBL_CUSTOMER.Visible = False
                        .btnStart.Visible = False
                        .btnViewImages.Visible = False
                        .LBL_001_001.Text = "Escanear poliza:"
                        gMyLastLicense = 0
                    End With
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_POLIZA
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                    CloseScanner()
                    ShowPanel(panelMenu)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
                    CloseScanner()
                    ShowPanel(panelMenu)
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try

        
    End Sub
    Private Sub ctrl_RecepFiscal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)

    End Sub

    Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewImages.Click
        Try
            ShowGallery(Me.LBL_001_001.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub ShowGallery(ByVal pPoliza As String)
        Try
            IsVeryFirstPicture = True
            ShowNextPicture()
            ShowPanel(panelBrowsePics)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnReception_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnStart.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub btnViewImages_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnViewImages.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub btnReception_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

        Try
            panelRecFiscalStep1.lblTitle.Text = "Ingreso Fiscal " + Me.LBL_001_001.Text
            panelRecFiscalStep1.Tag = Me.LBL_001_001.Text
            If gMyLastLicense <> 0 Then
                With panelRecFiscalStep1
                    .Panel_SKU.Visible = True
                    .LBL_LICENSE.Text = "Licencia en curso: " & gMyLastLicense
                    .LBL_LICENSE.Tag = gMyLastLicense.ToString
                    .LBL_LICENSE.Refresh()
                    .btnGen_Print_licence.Visible = False
                    .txtSKU_Desc.Text = ""
                    .lblSKU.Text = "Escanear SKU"
                    .txtQTY.Text = "1"
                    .txtQTY.Tag = "1"
                    .btnRecords.Text = "SKUs(" + Me.btnStart.Tag + ")"
                    Dim xserv As New WMS_InfoTrans.WMS_InfoTrans
                    Dim xset As DataSet
                    Dim pResult As String = ""
                    xset = xserv.GetClient_CommercialAggrements(gClientOwner, pResult, GlobalEnviroment)
                    If pResult = "OK" Then
                        .cmbCommercialAggrements.DisplayMember = "DESCRIPCION"
                        .cmbCommercialAggrements.ValueMember = "ACUERDO_COMERCIAL"
                        .cmbCommercialAggrements.DataSource = xset.Tables(0)
                        .cmbCommercialAggrements.Refresh()
                        For j = 0 To .cmbCommercialAggrements.Items.Count - 1
                            If .cmbCommercialAggrements.Items(j)("ACUERDO_COMERCIAL") = gCommercialAggrement Then
                                .cmbCommercialAggrements.Items(j).Selected = True
                            End If
                        Next
                        gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_RECEPCION_FISCAL
                        SetupScanner()
                        ShowPanel(panelRecFiscalStep1)
                    Else
                        Beep()
                        Notify(pResult, True)
                    End If


                End With
            Else
                panelRecFiscalStep1.btnGen_Print_licence.Visible = True
                SetupScanner()
                ShowPanel(panelRecFiscalStep1)
            End If


        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try


    End Sub
End Class
