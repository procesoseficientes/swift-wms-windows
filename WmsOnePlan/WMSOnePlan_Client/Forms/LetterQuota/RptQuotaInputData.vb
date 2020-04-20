Imports DevExpress.XtraReports.UI

Public Class RptQuotaInputData
   

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
       
    End Sub
    Private Sub Imprimir()
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

                rpt.Tables(0).Rows.Add(rptRow)
                Dim rptView As New RptQuotaLetterAutorizada
                rptView.DataSource = rpt.Tables(0)
                rptView.DataMember = "Quota_Letter"
                rptView.FillDataSource()
                rptView.ShowPreview()
                'End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub


    Private Function GridView1() As Object
        Throw New NotImplementedException
    End Function


    Private Sub LblPoliza_Click(sender As Object, e As EventArgs) Handles LblPoliza.Click

    End Sub
    Private Sub LblMedida_Click(sender As Object, e As EventArgs) Handles LblMedida.Click

    End Sub
    Private Sub LblFirma_Click(sender As Object, e As EventArgs) Handles LblFirma.Click

    End Sub
    Private Sub TxtPoliza_TextChanged(sender As Object, e As EventArgs) Handles TxtPoliza.TextChanged

    End Sub
    Private Sub TxtMedida_TextChanged(sender As Object, e As EventArgs) Handles TxtMedida.TextChanged

    End Sub
    Private Sub TxtFirma_TextChanged(sender As Object, e As EventArgs) Handles TxtFirma.TextChanged

    End Sub
End Class