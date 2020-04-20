Imports DevExpress.XtraReports.UI

Public Class frmInsuranceDocs

    Private Sub frmInsuranceDocs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarGrid()
    End Sub

    Private Sub LlenarGrid()

        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoapClient("WMS_Insurance_DocsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Docs.asmx")
            xdataset = xserv.GetInsuranceDocs(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridDocs.DataSource = xdataset.Tables(0)
            End If

            GridViewDocs.BestFitColumns()
            GridViewDocs.ExpandAllGroups()
            If Not GridDocs.DataSource Is Nothing Then
                txtMonto.EditValue = GridViewDocs.Columns("AMOUNT").SummaryItem.SummaryValue.ToString
                txtDescuento.EditValue = GridViewDocs.Columns("AMOUNTINV").SummaryItem.SummaryValue.ToString
            End If

            txtDiferencia.EditValue = (Decimal.Parse(txtMonto.Text) - Decimal.Parse(txtDescuento.Text)).ToString

            If Decimal.Parse(txtDiferencia.Text) < 0 Then
                txtDiferencia.BackColor = Color.Red
                txtDiferencia.ForeColor = Color.White
            Else
                txtDiferencia.BackColor = Color.LightYellow
                txtDiferencia.ForeColor = Color.Black
            End If

        Catch ex As Exception
            xdataset = Nothing
            MsgBox(pResult & ": " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        xdataset = Nothing
        pResult = Nothing
    End Sub

    Private Sub UpdateDoc()
        Try
            If GridViewDocs.SelectedRowsCount = 1 Then
                Dim xdatarow As DataRow = GridViewDocs.GetDataRow(GridViewDocs.FocusedRowHandle)
                Dim docId As String = Integer.Parse(xdatarow("DOC_ID").ToString)
                If Not docId = 0 Then
                    Dim frm As New frmIngresoInsuranceDocs(docId)
                    Me.Cursor = Cursors.WaitCursor
                    frm.ShowDialog()
                    If frm.DialogResult = DialogResult.OK Then
                        LlenarGrid()
                    End If
                    Me.Cursor = Cursors.Default
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub DeletePoliza()
        Dim pResult As String = ""
        Try
            If GridViewDocs.SelectedRowsCount = 1 Then
                Dim xdatarow As DataRow = GridViewDocs.GetDataRow(GridViewDocs.FocusedRowHandle)
                Dim docId As Integer = Integer.Parse(xdatarow("DOC_ID").ToString)

                Dim xserv As New OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoapClient("WMS_Insurance_DocsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Docs.asmx")

                If xserv.DeleteInsuranceDocs(docId, pResult, PublicLoginInfo.Environment) Then
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

    Private Sub GridDocs_DoubleClick(sender As Object, e As EventArgs) Handles GridDocs.DoubleClick
        UpdateDoc()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Desea borrar el registro ?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DeletePoliza()
        End If
    End Sub

    Private Sub GenerarReporte()
        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoapClient("WMS_Insurance_DocsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Docs.asmx")
            xdataset = xserv.GetInsuranceDocs(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then

                Dim ds As New dsReportsInsurance

                Try
                    For i As Integer = 0 To xdataset.Tables(0).Rows.Count - 1

                        Dim dr As DataRow
                        dr = ds.repPolizasSeguro.NewRow
                        dr("POLIZA_INSURANCE") = xdataset.Tables(0).Rows(i)("POLIZA_INSURANCE")
                        dr("COMPANY_NAME") = xdataset.Tables(0).Rows(i)("COMPANY_NAME")
                        dr("AMOUNT") = xdataset.Tables(0).Rows(i)("AMOUNT")
                        dr("VALIN_TO") = xdataset.Tables(0).Rows(i)("VALIN_TO")
                        dr("CLIENT_NAME") = xdataset.Tables(0).Rows(i)("CLIENT_NAME")
                        dr("DOC_ID") = xdataset.Tables(0).Rows(i)("DOC_ID")
                        dr("COVERAGE") = xdataset.Tables(0).Rows(i)("COVERAGE")
                        ds.repPolizasSeguro.Rows.Add(dr)
                    Next
                    
                    Dim Xrpt As New repPolizasSeguros
                    Xrpt.DataSource = Nothing
                    Xrpt.DataSource = ds
                    Xrpt.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                    Xrpt.DataMember = "repPolizasSeguro"
                    'Xrpt.FillDataSource()
                    Xrpt.ShowPreview()
                Catch ex As Exception
                    NotifyStatus(ex.Message, True, True)
                End Try
                
            End If
        Catch ex As Exception
            xdataset = Nothing
            MsgBox(pResult & ": " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        xdataset = Nothing
        pResult = Nothing
    End Sub
 
  
    Private Sub btnBNuevo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnBNuevo.ItemClick
        Dim frm As New frmIngresoInsuranceDocs
        Me.Cursor = Cursors.WaitCursor
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.OK Then
            LlenarGrid()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnBEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnBEditar.ItemClick
        UpdateDoc()
    End Sub

    Private Sub btnBBorrar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnBBorrar.ItemClick
        If MessageBox.Show("Desea borrar el registro ?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DeletePoliza()
        End If
    End Sub

    Private Sub btnBRenovar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnBRenovar.ItemClick
        Try
            If GridViewDocs.SelectedRowsCount = 1 Then
                Dim xdatarow As DataRow = GridViewDocs.GetDataRow(GridViewDocs.FocusedRowHandle)
                Dim insuranceId As String = Integer.Parse(xdatarow("DOC_ID").ToString)
                If Not insuranceId = 0 Then
                    Dim frm As New FrmInsuranceDocsRenew(insuranceId)
                    Me.Cursor = Cursors.WaitCursor
                    frm.ShowDialog()
                    If frm.DialogResult = DialogResult.OK Then
                        LlenarGrid()
                    End If
                    Me.Cursor = Cursors.Default
                End If
                
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnBExel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnBExel.ItemClick
        SaveFileDialog1.DefaultExt = "xlsx"
        SaveFileDialog1.Filter = "Archivos de excel (*.xlsx)|*.xlsx"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridViewDocs.ExportToXlsx(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnBPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnBPrint.ItemClick
        Dim Xrpt As New repPolizasSeguros
        Try
            If GridViewDocs.SelectedRowsCount >= 1 Then
                ''GenerarReporte()
                Xrpt.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                Xrpt.DataSource = Nothing
                Xrpt.DataSource = GridDocs.DataSource
                Xrpt.DataMember = "GetInsuranceDocs"

                Xrpt.FillDataSource()
                Xrpt.ShowPreview()
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefresh.ItemClick
        LlenarGrid()
    End Sub
End Class