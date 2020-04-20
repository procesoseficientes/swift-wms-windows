Public Class frmCerrtificateExtended

    Private _certificadoId As Integer

    Public Sub New(ByVal pCertificadoId As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _certificadoId = pCertificadoId
    End Sub

    Function ValidarControles() As Boolean

        If dtFechaInicio.EditValue Is Nothing Then
            NotifyStatus("Ingrese la fecha de inicio", True, True)
            dtFechaInicio.Focus()
            Return False
        End If

        If dtFechaFinal.EditValue Is Nothing Then
            NotifyStatus("Ingrese la fecha de final", True, True)
            dtFechaFinal.Focus()
            Return False
        End If

        If Date.Parse(dtFechaInicio.EditValue).Date > Date.Parse(dtFechaFinal.EditValue).Date Then
            NotifyStatus("La fecha de inicio es mayor a la fecha final", True, True)
            dtFechaInicio.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtAutoriazado.Text) Then
            NotifyStatus("Ingrese el nombre del autorizado", True, True)
            txtAutoriazado.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub Grabar()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")

            Dim xdata As DataSet = xserv.FillCertificate(_certificadoId, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                Dim oldFechaInicio As New Date
                oldFechaInicio = Date.Parse(xdata.Tables(0).Rows(0)("VALID_FROM").ToString).Date
                Dim oldFechaFinal As New Date
                oldFechaFinal = Date.Parse(xdata.Tables(0).Rows(0)("VALID_TO").ToString).Date
                pResult = ""
                If xserv.CreateCertificateLog(_certificadoId, PublicLoginInfo.LoginID, oldFechaInicio, oldFechaFinal, dtFechaInicio.EditValue, dtFechaFinal.EditValue, txtAutoriazado.Text, menComentario.Text, pResult, PublicLoginInfo.Environment) Then
                    If pResult = "OK" Then
                        pResult = ""
                        If xserv.UpdateCertificateValid(_certificadoId, dtFechaInicio.EditValue, dtFechaFinal.EditValue, PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment) Then
                            If pResult = "OK" Then
                                NotifyStatus("Se actualizo exitosamente", True, False)
                                DialogResult = DialogResult.OK
                                Close()
                            Else
                                NotifyStatus(pResult, True, True)
                            End If
                        Else
                            NotifyStatus(pResult, True, True)
                        End If
                    Else
                        NotifyStatus(pResult, True, True)
                    End If
                Else
                    NotifyStatus(pResult, True, True)
                End If
            Else
                NotifyStatus(pResult, True, True)
            End If
        Catch ex As Exception
            NotifyStatus("Ha ocurrido el siguiente error: " + ex.Message, True, True)
        End Try
    End Sub
    
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If ValidarControles() Then
            Grabar
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
End Class