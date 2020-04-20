Imports System.Net.Mail
Imports System.Configuration
Imports System.Data
Imports System.IO


Public Class frmGarita

    'Private Sub btnDocumento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnDocumento.KeyPress
    '    Dim dblDoc_id As Double
    '    Dim pResult As String = ""
    '    Dim xdatasethead As New DataSet
    '    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    '    txtAduana.Text = String.Empty
    '    txtContenedor.Text = String.Empty
    '    lblFecha.Text = "."
    '    If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
    '        If btnDocumento.Text.Length > 0 Then
    '            lblFecha.Text = FormatDateTime(Now, DateFormat.LongDate).ToString
    '            Dim xServPol As New WMS_Polizas.WMS_PolizasSoapClient("WMS_PolizasSoap", PublicLoginInfo.WSHost + "/trans/WMS_Polizas.asmx")
    '            Dim dtParsePoliza As New DataSet()
    '            If Double.TryParse(btnDocumento.EditValue, dblDoc_id) Then
    '                xDataSetHead = xserv.get_Poliza_Header(" Where DOC_ID = " & dblDoc_id.ToString(), PublicLoginInfo.Environment, pResult)

    '                If pResult = "OK" Then
    '                    If xdatasethead.Tables(0).Rows.Count > 0 Then
    '                        txtAduana.Text = xdatasethead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("NUMERO_DUA").ToString
    '                        txtContenedor.Text = xdatasethead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("NUMERO_CONTENEDOR").ToString
    '                    End If
    '                End If
    '            Else
    '                dtParsePoliza = xServPol.ParsePoliza(btnDocumento.EditValue, pResult)
    '                If dtParsePoliza.Tables(0).Rows.Count > 0 Then

    '                    txtAduana.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_3")

    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub frmGarita_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'End Sub

    Private Sub btnDocumento_KeyUp(sender As Object, e As KeyEventArgs) Handles btnDocumento.KeyUp
        If e.KeyCode = Keys.Enter Then
            GetQuotaLetter()
        End If
    End Sub

    Private Sub Limpiar()
        txtDocId.Text = ""
        txtPolizas.Text = ""
        txtAduana.Text = ""
        txtContenedor.Text = ""
        btnEnSitio.Visible = False
    End Sub

    Private Sub GetQuotaLetter()
        Try
            Limpiar()
            If btnDocumento.Text = "" Then
                Return
            End If

            Dim docId As Integer = 0

            If Not Integer.TryParse(btnDocumento.Text, docId) Then
                NotifyStatus("El campo solo acepta caracteres numéricos", True, True)
                Return
            End If


            Dim result As String = ""
            Dim xServInfoTrans As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
            Dim dt As DataSet = xServInfoTrans.GetQuotaLatterGarita(docId, result, PublicLoginInfo.Environment)
            If result = "OK" Then
                txtDocId.Text = dt.Tables(0).Rows(0)("DOC_ID").ToString()
                txtPolizas.Text = dt.Tables(0).Rows(0)("POLIZAS").ToString()
                txtAduana.Text = dt.Tables(0).Rows(0)("NOMBRE_ADUANA").ToString()
                txtContenedor.Text = dt.Tables(0).Rows(0)("CONTAINER_NUMBER").ToString()
                btnEnSitio.Visible = True
            Else
                NotifyStatus(result, True, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnDocumento_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles btnDocumento.ButtonClick
        GetQuotaLetter()
    End Sub

    Private Sub btnEnSitio_Click(sender As Object, e As EventArgs) Handles btnEnSitio.Click
        CambiarEstadoCartaCupo()
    End Sub

    Private Sub CambiarEstadoCartaCupo()
        Try
            Dim result As String = ""
            Dim xServTrans As New OnePlanServices_Trans.WMS_TransSoapClient("WMS_TransSoap", PublicLoginInfo.WSHost + "/Trans/WMS_Trans.asmx")
            If xServTrans.UpdateStatusQuotaLetter(Integer.Parse(txtDocId.Text), "EN_SITIO", PublicLoginInfo.LoginID, result, PublicLoginInfo.Environment) Then
                If result = "OK" Then
                    result = ""
                    Dim xServUser As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Security.asmx")
                    Dim dtUser As DataSet = xServUser.GetUsersNotifyLetterQuota(result, PublicLoginInfo.Environment)
                    If result = "OK" Then
                        'CREACIÓN DE VARIABLES
                        Dim mail = New MailMessage()
                        Dim smtpServer = New SmtpClient(ConfigurationManager.AppSettings("SMTP"))

                        smtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings("PORT"))
                        smtpServer.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings("SSL"))
                        smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network
                        smtpServer.UseDefaultCredentials = False
                        smtpServer.Credentials = New System.Net.NetworkCredential(ConfigurationManager.AppSettings("EMAIL"), ConfigurationManager.AppSettings("PASS"))

                        mail.From = New MailAddress(ConfigurationManager.AppSettings("FROM"), "Administrador del Sistema")
                        For Each row As DataRow In dtUser.Tables(0).Rows
                            mail.To.Add(row("EMAIL").ToString())
                        Next

                        mail.Subject = "Carta de Cupo"
                        'MENSAJE
                        mail.Subject = "Carta de Cupo"
                        mail.Body = String.Format("La carta de cupo numero: <strong>{0}</strong>. Fue aceptada en garita", txtDocId.Text)
                        'AJUSTES DE ENVIO
                        mail.IsBodyHtml = True
                        smtpServer.Send(mail)
                        Limpiar()
                    Else
                        NotifyStatus(result, False, True)
                    End If
                    'Limpiar()
                Else
                    NotifyStatus(result, False, True)
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
    End Class