Imports DevExpress.XtraReports.UI

Public Class FrmConsultAcuerdoCliente

    Private Sub LlenarGrid()
        Dim xdatatable As DataTable
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            xdatatable = xserv.GetAcuerdoCliente("GetAcuerdoComercial", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridAcuerdoCliente.DataSource = xdatatable
            Else
                NotifyStatus(pResult, False, True)
            End If
            GridViewAcuerdoCliente.BestFitColumns()
            GridViewAcuerdoCliente.ExpandAllGroups()
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub FrmConsultAcuerdoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarGrid()
    End Sub

    Private Sub btnExporExel_Click(sender As Object, e As EventArgs) Handles btnExporExel.Click
        SaveFileDialog1.DefaultExt = "xlsx"
        SaveFileDialog1.Filter = "Archivos de excel (*.xlsx)|*.xlsx"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridViewAcuerdoCliente.ExportToXlsx(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnExportPdf_Click(sender As Object, e As EventArgs) Handles btnExportPdf.Click
        SaveFileDialog1.DefaultExt = "xlsx"
        SaveFileDialog1.Filter = "Archivos de pdf (*.pdf)|*.pdf"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridViewAcuerdoCliente.ExportToPdf(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub GenerarReporte(ByVal pClienteId As String, ByVal pAcuerdoComercialId As Integer)
        Dim Xrpt As New repAcuerdoComercial
        Dim xdatatable As DataTable
        Dim pResult As String = ""
        Try
            Dim nombreDataTable As String = "repAcuerdoComercial"
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            xdatatable = xserv.GetReporteAcuerdoCliente(pClienteId, pAcuerdoComercialId, nombreDataTable, pResult, PublicLoginInfo.Environment)
            If Not xdatatable.Rows.Count = 0 Then
                ''GenerarReporte()
                Xrpt.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                Xrpt.DataSource = Nothing
                Xrpt.DataSource = xdatatable
                Xrpt.DataMember = nombreDataTable

                Xrpt.FillDataSource()
                Xrpt.ShowPreview()
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UpdateTypeChange()
        Try
            If GridViewAcuerdoCliente.SelectedRowsCount = 1 Then
                Dim xdatarow As DataRow = GridViewAcuerdoCliente.GetDataRow(GridViewAcuerdoCliente.FocusedRowHandle)
                Dim clienteid As String = xdatarow("CLIENT_ID").ToString
                Dim acuerdoComercialId As Integer = Integer.Parse(xdatarow("ACUERDO_COMERCIAL_ID").ToString)
                GenerarReporte(clienteid, acuerdoComercialId)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnGenerarReporte.Click
        UpdateTypeChange()
    End Sub

    Private Sub GridAcuerdoCliente_DoubleClick(sender As Object, e As EventArgs) Handles GridAcuerdoCliente.DoubleClick
        UpdateTypeChange()
    End Sub
End Class