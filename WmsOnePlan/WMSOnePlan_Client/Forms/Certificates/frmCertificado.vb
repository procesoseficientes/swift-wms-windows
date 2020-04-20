Public Class frmCertificado

    Private Sub LlenarGrid()

        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")
            xdataset = xserv.GetCertificate(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridCertificate.DataSource = xdataset.Tables(0)
            Else
                NotifyStatus(pResult, True, True)
            End If
            GridViewCertificate.BestFitColumns()

        Catch ex As Exception
            xdataset = Nothing
            MsgBox(pResult & ": " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        xdataset = Nothing
        pResult = Nothing
    End Sub

    Private Sub UpdateCertificate()
        Try
            If GridViewCertificate.SelectedRowsCount = 1 Then
                Dim xdatarow As DataRow = GridViewCertificate.GetDataRow(GridViewCertificate.FocusedRowHandle)
                Dim certificadoId As String = Integer.Parse(xdatarow("CERTIFICATE_ID").ToString)
                Dim frm As New frmIngresoCertificado(certificadoId)
                Me.Cursor = Cursors.WaitCursor
                frm.ShowDialog()
                If frm.DialogResult = DialogResult.OK Then
                    LlenarGrid()
                End If
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub frmCertificado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarGrid()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim frm As New frmIngresoCertificado
        Me.Cursor = Cursors.WaitCursor
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.OK Then
            LlenarGrid()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridCertificate_DoubleClick(sender As Object, e As EventArgs) Handles GridCertificate.DoubleClick
        UpdateCertificate()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateCertificate()
    End Sub

    Private Sub DeleteBond(ByVal pCertificateId)
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Bonds.WMS_BondsSoapClient("WMS_BondsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Bonds.asmx")

            Dim grabo As New Boolean
            grabo = xserv.DeleteBond(pCertificateId, pResult, PublicLoginInfo.Environment)
            If grabo Then
                If grabo Then
                    If pResult = "OK" Then
                        LlenarGrid()
                    Else
                        NotifyStatus(pResult, True, True)
                    End If
                Else
                    NotifyStatus(pResult, True, True)
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub DeleteCertificate()
        Dim pResult As String = ""
        Try
            If GridViewCertificate.SelectedRowsCount = 1 Then
                If MessageBox.Show("Desea borrar el registro?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim xdatarow As DataRow = GridViewCertificate.GetDataRow(GridViewCertificate.FocusedRowHandle)
                    Dim certificateId As Integer = Integer.Parse(xdatarow("CERTIFICATE_ID").ToString)

                    Dim xserv As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")

                    If xserv.DeleteCertificate(certificateId, pResult, PublicLoginInfo.Environment) Then
                        If pResult.Equals("OK") Then
                            DeleteBond(certificateId)
                        Else
                            NotifyStatus(pResult, True, True)
                        End If
                    Else
                        NotifyStatus(pResult, True, True)
                    End If
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteCertificate()
    End Sub

    Private Sub btnExporExel_Click(sender As Object, e As EventArgs) Handles btnExporExel.Click
        SaveFileDialog1.DefaultExt = "xlsx"
        SaveFileDialog1.Filter = "Archivos de excel (*.xlsx)|*.xlsx"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridViewCertificate.ExportToXlsx(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnProrroga_Click(sender As Object, e As EventArgs) Handles btnProrroga.Click
        Try
            If GridViewCertificate.SelectedRowsCount = 1 Then
                Dim xdatarow As DataRow = GridViewCertificate.GetDataRow(GridViewCertificate.FocusedRowHandle)
                Dim certificadoId As String = Integer.Parse(xdatarow("CERTIFICATE_ID").ToString)
                Dim frm As New frmCerrtificateExtended(certificadoId)
                Me.Cursor = Cursors.WaitCursor
                frm.ShowDialog()
                If frm.DialogResult = DialogResult.OK Then
                    LlenarGrid()
                End If
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
End Class