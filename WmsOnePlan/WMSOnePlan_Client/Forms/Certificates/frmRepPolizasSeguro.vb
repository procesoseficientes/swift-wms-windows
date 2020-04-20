Imports DevExpress.Data
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid
Imports System.Windows.Forms.VisualStyles

Public Class frmRepPolizasSeguro

    Private PromedioPaso As Boolean = False

    Private Sub LlenarGrid()

        Dim xdatatable As New DataTable
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoapClient("WMS_Insurance_DocsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Docs.asmx")
            xdatatable = xserv.GetRepInsuranceDoscs("repPolizasSeguro", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridPolizasSeguro.DataSource = xdatatable
            Else
                NotifyStatus(pResult, True, True)
            End If
            GridViewPolizasSeguro.BestFitColumns()
        Catch ex As Exception
            xdatatable = Nothing
            MsgBox(pResult & ": " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        xdatatable = Nothing
        pResult = Nothing
    End Sub

    Private Sub frmRepPolizasSeguro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarGrid()
    End Sub

    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnGenerarReporte.Click
        Dim Xrpt As New repPolsSeguros
        Try
            If GridViewPolizasSeguro.SelectedRowsCount >= 1 Then
                ''GenerarReporte()
                Xrpt.Parameters("logoImg").Value = PublicLoginInfo.LOGO 
                Xrpt.DataSource = Nothing
                Xrpt.DataSource = GridPolizasSeguro.DataSource
                Xrpt.DataMember = "repPolizasSeguro"

                Xrpt.FillDataSource()
                Xrpt.ShowPreview()
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
    Private Sub GridViewPolizasSeguro_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GridViewPolizasSeguro.CustomSummaryCalculate
       MonstrarPorcentajeTotal
    End Sub

    Private Sub MonstrarPorcentajeTotal()
        Dim montoSeguro As Decimal = GridViewPolizasSeguro.Columns("MontoAsegurado").SummaryItem.SummaryValue.ToString
        Dim montoInvertario As Decimal = GridViewPolizasSeguro.Columns("MontoInventario").SummaryItem.SummaryValue.ToString

        If Not montoInvertario = 0 Then
            Dim porcentajeTotal As Decimal = ((montoSeguro - montoInvertario) * 100) / montoSeguro
            Dim cadena = String.Format("Total = {0}%", porcentajeTotal.ToString("##,##0.00"))
            GridViewPolizasSeguro.Columns("Porcentaje").SummaryItem.SetSummary(porcentajeTotal.ToString("##,##0.00"), cadena)
        End If
    End Sub

    Private Sub GridPolizasSeguro_Click(sender As Object, e As EventArgs) Handles GridPolizasSeguro.Click
        MonstrarPorcentajeTotal()

    End Sub

    Private Sub GridPolizasSeguro_DragDrop(sender As Object, e As DragEventArgs) Handles GridPolizasSeguro.DragDrop
        MonstrarPorcentajeTotal()
    End Sub
End Class