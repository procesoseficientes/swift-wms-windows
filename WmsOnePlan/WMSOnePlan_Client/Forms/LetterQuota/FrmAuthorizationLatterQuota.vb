Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization
Imports DevExpress.XtraReports.UI
Imports System.Net.Mail
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.DXErrorProvider


Public Class FrmAuthorizationLatterQuota
    Public GFirma As String
    Public GMedida As String
    Public GPoliza As String
    Public GCarta As String
    Public GClave As String
    Public GPuesto As String
    Public GCnt As Integer = 0


    Public Sub LlenarGrid()
        If Not dtFechaInicio.EditValue = Nothing And Not dtFechaFinal.EditValue = Nothing Then
            Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
            Dim xdataset As New DataSet
            Dim pResult As String = ""





            Try
                xdataset = xserv.GetQuotaLatter("SOLICITADA", IIf(chkIncluirAutorizados.Checked, "AUTORIZADA", ""),
                                                IIf(chkIncluirEnsSitio.Checked, "EN_SITIO", ""),
                                                Date.Parse(dtFechaInicio.EditValue), Date.Parse(dtFechaFinal.EditValue),
                                                pResult, PublicLoginInfo.Environment)
                If pResult = "OK" Then
                    Me.GridControl1.DataSource = xdataset.Tables(0)
                    Me.GridView1.ExpandAllGroups()
                Else
                    NotifyStatus(pResult, False, True)
                    Me.GridControl1.DataSource = Nothing
                End If
            Catch ex As Exception
                NotifyStatus(ex.Message, True, True)
            End Try
        End If
    End Sub

    Private Sub FrmAuthorizationLatterQuota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture =
        New System.Globalization.CultureInfo("es-GT")
        System.Threading.Thread.CurrentThread.CurrentUICulture =
        New System.Globalization.CultureInfo("es")
        'LlenarGrid()
        dtFechaInicio.EditValue = Date.Today.AddDays(-8)
        dtFechaFinal.EditValue = Date.Today

    End Sub

    Private Sub AutorizarCartasCupo()
        Try
            Dim uboError As Boolean = False
            Dim xrow As DataRow
            If GridView1.SelectedRowsCount >= 1 Then
                Dim xserv As New OnePlanServices_Trans.WMS_TransSoapClient("WMS_TransSoap", PublicLoginInfo.WSHost + "/Trans/WMS_Trans.asmx")
                For i = 0 To GridView1.RowCount - 1
                    If GridView1.IsRowSelected(i) Then
                        Dim result As String = ""
                        xrow = GridView1.GetDataRow(i)
                        If xrow("STATUS") = "SOLICITADA" Then
                            If String.IsNullOrEmpty(xrow("EMAIL").ToString()) Then
                                If XtraMessageBox.Show("No se puede enviar la autorizacion. Debe de asociar un E-mail al usuario, Desea autorizarlo?", "Autorizar", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                                    xserv.UpdateStatusQuotaLetter(Integer.Parse(xrow("DOC_ID").ToString()), "AUTORIZADA", PublicLoginInfo.LoginID, result, PublicLoginInfo.Environment)
                                    If Not result = "OK" Then
                                        NotifyStatus(result, True, True)
                                        uboError = True
                                        Exit Sub
                                    End If
                                End If
                            Else
                                xserv.UpdateStatusQuotaLetter(Integer.Parse(xrow("DOC_ID").ToString()), "AUTORIZADA", PublicLoginInfo.LoginID, result, PublicLoginInfo.Environment)
                                If Not result = "OK" Then
                                    NotifyStatus(result, True, True)
                                    uboError = True
                                    Exit Sub
                                Else
                                    'EMAIL
                                    'CREACIÓN DE VARIABLES
                                    Dim mail = New MailMessage()
                                    Dim smtpServer = New SmtpClient(ConfigurationManager.AppSettings("SMTP"))

                                    smtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings("PORT"))
                                    smtpServer.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings("SSL"))
                                    smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network
                                    smtpServer.UseDefaultCredentials = False
                                    smtpServer.Credentials = New System.Net.NetworkCredential(ConfigurationManager.AppSettings("EMAIL"), ConfigurationManager.AppSettings("PASS"))

                                    mail.From = New MailAddress(ConfigurationManager.AppSettings("FROM"), "Administrador del Sistema")
                                    mail.To.Add(xrow("EMAIL").ToString())

                                    mail.Subject = "Carta de Cupo" 'MENSAJE
                                    mail.Subject = "Carta de Cupo"
                                    mail.Body = String.Format("La carta de cupo numero: <strong>{0}</strong>. Fue autorizada", xrow("DOC_ID").ToString())
                                    'AJUSTES DE ENVIO
                                    mail.IsBodyHtml = True
                                    smtpServer.Send(mail)
                                End If
                            End If

                        End If
                    End If
                Next
                If Not uboError Then
                    LlenarGrid()
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
    Private Sub Print()
        Try
            If GridView1.SelectedRowsCount = 1 Then
                Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                'If xdatarow("STATUS") = "SOLICITADA" Then
                Dim rpt As New dsLatterQuota
                Dim rptRow As DataRow = rpt.Tables(0).NewRow()
                rptRow("DOC_ID") = xdatarow("DOC_ID")
                rptRow("POLIZAS") = xdatarow("POLIZAS")
                rptRow("CLAVE_ADUANA") = xdatarow("CLAVE_ADUANA")
                rptRow("NOMBRE_ADUANA") = xdatarow("NOMBRE_ADUANA")
                rptRow("NO_FACTURA") = xdatarow("NO_FACTURA")
                rptRow("MERCHANDISE_DESCRIPTION") = xdatarow("MERCHANDISE_DESCRIPTION")
                rptRow("MERCHANDISE_QTY") = xdatarow("MERCHANDISE_QTY")
                rptRow("MERCHANDISE_VALUE") = xdatarow("MERCHANDISE_VALUE")
                rptRow("BL_NUMBER") = xdatarow("BL_NUMBER")
                rptRow("CONTAINER_NUMBER") = xdatarow("CONTAINER_NUMBER")
                rptRow("CLAVE_AGENTE_ADUANERO") = xdatarow("CLAVE_AGENTE_ADUANERO")
                rptRow("NOMBRE_AGENTE_ADUANERO") = xdatarow("NOMBRE_AGENTE_ADUANERO")
                rptRow("NOMBRE_CONSIGNATARIO") = xdatarow("NOMBRE_CONSIGNATARIO")
                rptRow("NIT_CONSIGNATARIO") = xdatarow("NIT_CONSIGNATARIO")
                rptRow("DOMICILIO_FISCAL_CONSIGNATARIO") = xdatarow("DOMICILIO_FISCAL_CONSIGNATARIO")
                rptRow("Firma") = xdatarow("Firma")
                rptRow("Unidad_Medida") = xdatarow("Unidad_Medida")
                rptRow("Regimen") = xdatarow("Regimen")
                rptRow("clave_aduana_alsersa") = xdatarow("clave_aduana_alsersa")
                rptRow("POSITION_PERSON") = xdatarow("POSITION_PERSON")

                rpt.Tables(0).Rows.Add(rptRow)

                Dim rptView As New RptQuotaLetterAutorizada
                rptView.DataSource = rpt.Tables(0)
                rptView.DataMember = "Quota_Letter"
                rptView.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                rptView.FillDataSource()
                rptView.ShowPreview()


                'rptView.RequestParameters = False
                'rptView.Parameters("Regimen").Value = GPoliza
                'rptView.Parameters("Medida").Value = GMedida
                'rptView.Parameters("firma").Value = GFirma



                'End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub EnSitioCartasCupo()
        Try
            Dim uboError As Boolean = False
            Dim xrow As DataRow
            If GridView1.SelectedRowsCount >= 1 Then
                Dim xserv As New OnePlanServices_Trans.WMS_TransSoapClient("WMS_TransSoap", PublicLoginInfo.WSHost + "/Trans/WMS_Trans.asmx")
                For i = 0 To GridView1.RowCount - 1
                    If GridView1.IsRowSelected(i) Then
                        Dim result As String = ""
                        xrow = GridView1.GetDataRow(i)
                        If xrow("STATUS") = "AUTORIZADA" Then
                            xserv.UpdateStatusQuotaLetter(Integer.Parse(xrow("DOC_ID").ToString()), "EN_SITIO", PublicLoginInfo.LoginID, result, PublicLoginInfo.Environment)
                            If Not result = "OK" Then
                                NotifyStatus(result, True, True)
                                uboError = True
                                Exit Sub
                            End If
                        End If
                    End If
                Next
                If Not uboError Then
                    LlenarGrid()
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefresh.ItemClick
        LlenarGrid()
    End Sub

    Private Sub btnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrint.ItemClick

        Print()

        'RptQuotaInputData.Show()
    End Sub

    Private Sub btnEnSitio_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEnSitio.ItemClick
        If MessageBox.Show("Confirma en sitio?", "Confirme en sitio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            EnSitioCartasCupo()
        End If
    End Sub

    Private Sub btnAutorizar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAutorizar.ItemClick
        If MessageBox.Show("Confirma autorizacion?", "Confirme autorizacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            AutorizarCartasCupo()
        End If
    End Sub

    Private Sub dtFechaInicio_EditValueChanged_1(sender As Object, e As EventArgs) Handles dtFechaFinal.EditValueChanged
        LlenarGrid()
    End Sub

    Private Sub chkIncluirAutorizados_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles chkIncluirAutorizados.CheckedChanged, chkIncluirEnsSitio.CheckedChanged
        LlenarGrid()
    End Sub

    Private Sub BtnPrintCupo_Click(sender As Object, e As EventArgs) Handles BtnPrintCupo.Click
        Guardar()
    End Sub
    Private Sub validarcampo(ByRef txt As TextBox, ByRef Gvar As String, ByRef Lbl As Label)
        If (txt.Text = "") Then
            MessageBox.Show("Aún no ha ingresado: " + Lbl.Text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' MessageBox.Show("Aún no ha ingresado: " + Lbl.Text) 
        Else
            GCnt = GCnt + 1
            Gvar = txt.Text.ToUpper().ToString()
        End If
    End Sub
    Private Sub Guardar()
        validarcampo(TxtCarta, GCarta, LblCarta)
        validarcampo(TxtPoliza, GPoliza, LblPoliza)
        validarcampo(TxtMedida, GMedida, LblMedida)
        validarcampo(TxtFirma, GFirma, LblFirma)
        validarcampo(UiTextoPuesto, GPuesto, UiEtiquetaPuesto)
        If (GCnt >= 4) Then
            Select Case GPoliza
                Case "TO"
                    GClave = "G4"
                Case "DA"
                    GClave = "AS1"
            End Select
            InsertarParametrosEnBD()
            DataWindow.Visible = False
        End If
    End Sub
    Private Sub InsertarParametrosEnBD()
        Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            xdataset = xserv.UpdateQuotaLatter(GCarta, GPoliza, GMedida, GFirma, GClave, GPuesto, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                Me.GridControl1.DataSource = xdataset.Tables(0)
                Me.GridView1.ExpandAllGroups()
            Else
                NotifyStatus(pResult, False, True)
                Me.GridControl1.DataSource = Nothing
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
        LlenarGrid()
        Reset()

    End Sub
    Private Sub Reset()
        TxtCarta.Text = ""
        TxtPoliza.Text = ""
        TxtMedida.Text = ""
        TxtFirma.Text = ""
        GCarta = ""
        GPoliza = ""
        GMedida = ""
        GFirma = ""
        GCnt = 0
        GPuesto = ""
    End Sub
    Private Sub btnRefresh1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefresh1.ItemClick
        LlenarGrid()
    End Sub


    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        Reset()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        DataWindow.Visible = False
    End Sub

    Private Sub BarBtnParam_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarBtnParam.ItemClick
        DataWindow.Visible = True
        TxtCarta.Text = ""
        TxtPoliza.Text = ""
        TxtMedida.Text = ""
        TxtFirma.Text = ""
        UiTextoPuesto.Text = ""
    End Sub
End Class


