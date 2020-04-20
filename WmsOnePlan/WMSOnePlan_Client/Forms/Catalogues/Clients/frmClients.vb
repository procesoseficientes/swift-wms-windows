Public Class frmClients

    Private Sub ClearBag_Clients()
        With Bag_Clients_Class
            .Clasificacion = ""
            .Codigo = ""
            .Estatus = 1
            .Nombre = ""
            .Ruta = ""
            Me.PropertyGrid1.SelectedObject = Bag_Clients_Class
            Me.PropertyGrid1.Refresh()
        End With
    End Sub
    Public Sub SaveAndRefresh()
        Dim pResult As String = ""
        If Bag_Clients_Class.Grabar(pResult) Then
            FilListView()
        Else
            MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        SaveAndRefresh()
    End Sub
    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click
        Dim pResult As String = ""
        If Bag_Clients_Class.Delete(pResult) Then
            FilListView()
            ClearBag_Clients()
        Else
            MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        ClearBag_Clients()
        Me.PropertyGrid1.SelectedObject = Bag_Clients_Class
        Me.PropertyGrid1.Focus()
    End Sub

    Private Sub frmBins_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FilListView()
        'FillPropGrid()
    End Sub
    Public Function FillPropGrid()

        Return True
    End Function
    Public Function FilListView()
        Me.Cursor = Cursors.WaitCursor
        SearchByPartial()
        Me.Cursor = Cursors.Default
        Return True
    End Function
    Public Function SearchByPartial()
        Dim i As Integer = 0
        Dim xserv As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")

        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Dim xgrp As New ListViewGroup

        Try
            xdataset = xserv.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridControl1.DataSource = xdataset.Tables(0)
            Else
                NotifyStatus(pResult, False, True)
            End If
        Catch ex As Exception
            xdataset = Nothing
            xserv = Nothing

            MessageBox.Show(ex.Message)
        End Try
        xdataset = Nothing
        xserv = Nothing
        Return True
    End Function
    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click
        Try
            If GridView1.FocusedRowHandle >= 0 Then
                Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                Dim pClient As String = xdatarow(0).ToString
                ShowClient(pClient)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GridControl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Try
            If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                Dim pClient As String = xdatarow(0).ToString
                ShowClient(pClient)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ShowClient(ByVal pClient As String)
        ClearBag_Clients()
        Dim pResult As String = ""
        Dim xserv As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")

        Dim xdata As DataSet = xserv.SearchByKeyClients(pClient, pResult, PublicLoginInfo.Environment)
        If pResult = "OK" Then
            With Bag_Clients_Class

                .Codigo = pClient
                .Clasificacion = xdata.Tables(0).Rows(0)("CLIENT_CLASS").ToString
                .Estatus = xdata.Tables(0).Rows(0)("CLIENT_STATUS").ToString
                .Nombre = xdata.Tables(0).Rows(0)("CLIENT_NAME").ToString
                .Ruta = xdata.Tables(0).Rows(0)("CLIENT_ROUTE").ToString
                .CodigoERP = xdata.Tables(0).Rows(0)("CLIENT_ERP_CODE").ToString

            End With
            PropertyGrid1.SelectedObject = Bag_Clients_Class

        Else
            MessageBox.Show(pResult)
        End If
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        GridView1.ExpandAllGroups()
        GridView1.ShowPrintPreview()
        'Me.GridControl1.ExportToPdf("c:\work\clientes.pdf")
    End Sub
End Class