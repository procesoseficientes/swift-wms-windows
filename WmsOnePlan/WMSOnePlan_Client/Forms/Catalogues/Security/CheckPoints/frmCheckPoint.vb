Public Class frmCheckPoint

    Private Sub frmCheckPoint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SearchByPartial()
    End Sub
    Private Sub ClearBag_CheckPoint()
        With Bag_CheckPoint_Class
            .Codigo = ""
            .Nombre = ""
            .Grupo = ""
            Me.PropertyGrid1.SelectedObject = Bag_CheckPoint_Class
            Me.PropertyGrid1.Refresh()
        End With
    End Sub
    Private Sub PropertyGrid1_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged
        Select Case e.ChangedItem.Label
            Case "Codigo"
                Bag_CheckPoint_Class.Codigo = e.ChangedItem.Value
            Case "Nombre"
                Bag_CheckPoint_Class.Nombre = e.ChangedItem.Value
            Case "Grupo"
                Bag_CheckPoint_Class.Grupo = e.ChangedItem.Value
        End Select

    End Sub
    Public Sub SaveAndRefresh()
        Dim pResult As String = ""
        If Bag_CheckPoint_Class.Grabar(pResult) Then
            FilListView()
        Else
            MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Public Function FilListView()
        Me.Cursor = Cursors.WaitCursor
        SearchByPartial()
        Me.Cursor = Cursors.Default
        Return True
    End Function

    Public Function SearchByPartial()
        Dim i As Integer = 0
        Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
        Dim xdatarow As DataRow
        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Dim xgrp As New ListViewGroup

        'create default groups
        lstview_searchresults.Items.Clear()
        FillGroup()

        Try
            xdataset = xserv.SearchPartialCheckPoint(Me.txtSearch.Text.ToUpper, Me.txtSearch.Text.ToUpper, Me.txtSearch.Text.ToUpper, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdatarow In xdataset.Tables(0).Rows
                    With lstview_searchresults
                        .Items.Add(xdatarow("PRIV_ID").ToString, xdatarow("PRIV_ID").ToString, 0)
                        .Items(.Items.Count - 1).SubItems.Add(xdatarow("PRIV_NAME").ToString)

                        .Items(.Items.Count - 1).Group = .Groups(xdatarow("PRIV_GROUP").ToString)
                    End With
                Next xdatarow
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

    Public Function FillGroup()
        'Me.PropertyGrid_Settings.PropertyTabs.AddTabType()
        Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Dim xdr As DataRow
        lstview_searchresults.Groups.Clear()
        xdataset = xserv.CheckPointGroups(pResult, PublicLoginInfo.Environment)
        If pResult = "OK" Then
            For Each xdr In xdataset.Tables(0).Rows
                With lstview_searchresults
                    .Groups.Add(xdr(0).ToString, xdr(0).ToString)
                End With
            Next
        End If
        xdataset = Nothing
        xserv = Nothing
        Return True


    End Function

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        SaveAndRefresh()
    End Sub

    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click

        Dim pResult As String = ""
        If Bag_CheckPoint_Class.Delete(pResult) Then
            FilListView()
            ClearBag_CheckPoint()
        Else
            MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        ClearBag_CheckPoint()
    End Sub

    
    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        SearchByPartial()
    End Sub

    Private Sub lstview_searchresults_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lstview_searchresults.ItemSelectionChanged
        Try

            With Bag_CheckPoint_Class
                .Grupo = e.Item.Group.Name
                .Codigo = e.Item.SubItems(0).Text
                .Nombre = e.Item.SubItems(1).Text
            End With

            Me.PropertyGrid1.SelectedObject = Bag_CheckPoint_Class
            Me.PropertyGrid1.Refresh()

        Catch ex As Exception

        End Try
    End Sub

    
    Private Sub lstview_searchresults_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstview_searchresults.SelectedIndexChanged

    End Sub
End Class