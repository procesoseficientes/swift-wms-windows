Public Class frmSupervisions

    Private Sub LlenarGrid()

        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Supervisions.WMS_SupervisionsSoapClient("WMS_SupervisionsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Supervisions.asmx")
            xdataset = xserv.GetSupervisions(False, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridSupervisions.DataSource = xdataset.Tables(0)
            End If

            GridViewSupervisions.BestFitColumns()

        Catch ex As Exception
            xdataset = Nothing
            MsgBox(pResult & ": " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        xdataset = Nothing
        pResult = Nothing
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim frm As New frmIngresoSupervisions
        Me.Cursor = Cursors.WaitCursor
        frm.ShowDialog()
        If frm.GraboEnc Then
            LlenarGrid()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmSupervisions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarGrid()
    End Sub

    Private Sub UpdateSupervisions()
        Try
            If GridViewSupervisions.SelectedRowsCount = 1 Then
                Dim xdatarow As DataRow = GridViewSupervisions.GetDataRow(GridViewSupervisions.FocusedRowHandle)
                Dim superId As String = Integer.Parse(xdatarow("SUPER_ID").ToString)
                Dim frm As New frmIngresoSupervisions(superId)
                Me.Cursor = Cursors.WaitCursor
                frm.ShowDialog()
                If frm.GraboEnc Then
                    LlenarGrid()
                End If
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub DeleteSupervisionDetails()
        Dim pResult As String = ""
        Try
            If GridViewSupervisions.SelectedRowsCount = 1 Then
                Dim xdatarow As DataRow = GridViewSupervisions.GetDataRow(GridViewSupervisions.FocusedRowHandle)
                Dim superId As Integer = Integer.Parse(xdatarow("SUPER_ID").ToString)

                Dim xserv As New OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoapClient("WMS_SupervisionsDetailSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_SupervisionsDetail.asmx")

                If xserv.DeleteAllBySuperIdSupervisionsDetail(superId, pResult, PublicLoginInfo.Environment) Then
                    If pResult.Equals("OK") Then
                        ''LlenarGrid()
                        DeleteSupervisions()
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

    Private Sub DeleteSupervisions()
        Dim pResult As String = ""
        Try
            If GridViewSupervisions.SelectedRowsCount = 1 Then
                Dim xdatarow As DataRow = GridViewSupervisions.GetDataRow(GridViewSupervisions.FocusedRowHandle)
                Dim superId As Integer = Integer.Parse(xdatarow("SUPER_ID").ToString)

                Dim xserv As New OnePlanServices_Supervisions.WMS_SupervisionsSoapClient("WMS_SupervisionsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Supervisions.asmx")

                If xserv.DeleteSupervisions(superId, pResult, PublicLoginInfo.Environment) Then
                    If pResult.Equals("OK") Then
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

    Private Sub GridSupervisions_DoubleClick(sender As Object, e As EventArgs) Handles GridSupervisions.DoubleClick
        UpdateSupervisions()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateSupervisions()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Desea borrar el registro ?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DeleteSupervisionDetails()
        End If
    End Sub

    Private Sub btnExporExel_Click(sender As Object, e As EventArgs) Handles btnExporExel.Click
        SaveFileDialog1.DefaultExt = "xlsx"
        SaveFileDialog1.Filter = "Archivos de excel (*.xlsx)|*.xlsx"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridViewSupervisions.ExportToXlsx(SaveFileDialog1.FileName)
        End If
    End Sub

End Class