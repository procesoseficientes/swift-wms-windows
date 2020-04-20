Imports System.Data
Imports DevExpress.XtraCharts.UI

Public Class frmAddNewLocation

    Private Sub frmAddNewLocation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshData()
    End Sub
    Sub RefreshData()
        Try
            Dim pResult As String = ""
            Dim xdata As DataSet
            'Cursor = Cursors.WaitCursor
            Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
            xdata = xserv.GetLocationsAvailableToRelate(lblProd.Text, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                Me.GridControl1.DataSource = xdata.Tables(0)
                GridView1.ExpandAllGroups()
            End If
            'Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Try
            Dim xcount As Integer = 0
            Dim pResult As String = ""
            Dim xdata As DataSet = Nothing
            Dim xrow As DataRow

            If Me.GridView1.IsFilterRow(Me.GridView1.FocusedRowHandle) Then
                Cursor = Cursors.Default
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor

            Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")

            ToolStripProgressBar1.Value = 0

            For i = 0 To GridView1.RowCount - 1

                ToolStripProgressBar1.Value = (xcount / GridView1.SelectedRowsCount) * 100

                If xcount <= (GridView1.SelectedRowsCount - 1) Then
                    If GridView1.IsRowSelected(i) Then
                        xrow = GridView1.GetDataRow(i)

                        If Not xserv.CreateMaterial_Join_SpotLocations(lblProd.Text, xrow("WAREHOUSE_PARENT").ToString, xrow("LOCATION_SPOT"), PublicLoginInfo.LoginID, 0, 0, pResult, PublicLoginInfo.Environment) Then
                            Cursor = Cursors.Default
                            MessageBox.Show(pResult, "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Close()
                        End If
                        xcount = xcount + 1
                    End If
                Else
                    Exit For
                End If
            Next
            ToolStripProgressBar1.Value = 100
            Cursor = Cursors.Default

            MessageBox.Show("Proceso finalizado", "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshData()

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UiButtonSalirUbicacionesRelacionadas_Click(sender As Object, e As EventArgs) Handles UiButtonSalirUbicacionesRelacionadas.Click
        Me.Close()
    End Sub
End Class