Public Class FrmAcuerdoComercial

    Private Sub LlenarGrid()
        Dim xdatatable As New DataTable
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            xdatatable = xserv.GetTarifarioHeaer(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridAcuerdoComercial.DataSource = xdatatable
            Else
                NotifyStatus(pResult, False, True)
            End If
            GridViewAcuerdoComercial.BestFitColumns()
            GridViewAcuerdoComercial.ExpandAllGroups()
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub


    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim frm As New FrmIngresoAcuerdoComercial
        Cursor = Cursors.WaitCursor
        frm.ShowDialog()
        If frm.IsoCambios Then
            LlenarGrid()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FrmAcuerdoComercial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarGrid()
    End Sub

    Private Sub UpdateTypeChange()
        Try
            If GridViewAcuerdoComercial.SelectedRowsCount = 1 Then
                Dim xdatarow As DataRow = GridViewAcuerdoComercial.GetDataRow(GridViewAcuerdoComercial.FocusedRowHandle)
                Dim acuerdoComercialId As String = Integer.Parse(xdatarow("ACUERDO_COMERCIAL_ID").ToString)
                Dim frm As New FrmIngresoAcuerdoComercial(acuerdoComercialId)
                Cursor = Cursors.WaitCursor
                frm.ShowDialog()
                If frm.IsoCambios Then
                    LlenarGrid()
                End If
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateTypeChange()
    End Sub

    Private Sub GridAcuerdoComercial_DoubleClick(sender As Object, e As EventArgs) Handles GridAcuerdoComercial.DoubleClick
        UpdateTypeChange()
    End Sub

    Private Sub DeleteAcuerdoComercial()
        Dim pResult As String = ""
        Try
            If GridViewAcuerdoComercial.SelectedRowsCount = 1 Then
                If MessageBox.Show("Desea borrar el registro?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim xdatarow As DataRow = GridViewAcuerdoComercial.GetDataRow(GridViewAcuerdoComercial.FocusedRowHandle)
                    Dim acuerdoComercialId As Integer = Integer.Parse(xdatarow("ACUERDO_COMERCIAL_ID").ToString)

                    Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")

                    If xserv.DeleteTarificadorHeader(acuerdoComercialId, pResult, PublicLoginInfo.Environment) Then
                        If pResult.Equals("OK") Then
                            LlenarGrid()
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
        DeleteAcuerdoComercial()
    End Sub

    Private Sub btnExporExel_Click(sender As Object, e As EventArgs) Handles btnExporExel.Click
        SaveFileDialog1.DefaultExt = "xlsx"
        SaveFileDialog1.Filter = "Archivos de excel (*.xlsx)|*.xlsx"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridViewAcuerdoComercial.ExportToXlsx(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnPorCliente_Click(sender As Object, e As EventArgs) Handles btnPorCliente.Click
        Dim frm As New FrmAcuerdoXCliente
        Cursor = Cursors.WaitCursor
        frm.ShowDialog()
        Cursor = Cursors.Default
    End Sub


End Class