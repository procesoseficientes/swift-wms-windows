Public Class frmAccessLevel

    Private Sub ClearBag_AccessLevel()
        With Bag_AccessLevel_Class
            .Codigo = ""
            .Nombre = ""
            .Descripcion = ""
            Me.PropertyGrid1.SelectedObject = Bag_AccessLevel_Class
            Me.PropertyGrid1.Refresh()
        End With
    End Sub
    Private Sub PropertyGrid1_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs)
        Select Case e.ChangedItem.Label
            Case "Codigo"
                Bag_AccessLevel_Class.Codigo = e.ChangedItem.Value
            Case "Nombre"
                Bag_AccessLevel_Class.Nombre = e.ChangedItem.Value
            Case "Descripcion"
                Bag_AccessLevel_Class.Descripcion = e.ChangedItem.Value
        End Select
        SaveAndRefresh()
    End Sub
    Public Sub SaveAndRefresh()
        Dim pResult As String = ""
        If Bag_AccessLevel_Class.Grabar(pResult) Then
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
        If Bag_CheckPoint_Class.Delete(pResult) Then
            FilListView()
            ClearBag_AccessLevel()
        Else
            MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        ClearBag_AccessLevel()
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
        Cursor = Cursors.WaitCursor
        lstview_searchresults.Items.Clear()
        Dim SearchTxt = txtSearch.Text

        Try
            xdataset = xserv.SearchPartialAccessLevel(SearchTxt, SearchTxt, SearchTxt, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdatarow In xdataset.Tables(0).Rows
                    With lstview_searchresults
                        .Items.Add(xdatarow("ROLE_ID").ToString, xdatarow("ROLE_ID").ToString, 0)
                        .Items(.Items.Count - 1).SubItems.Add(xdatarow("ROLE_NAME").ToString)
                        .Items(.Items.Count - 1).SubItems.Add(xdatarow("ROLE_DESCRIPTION").ToString)
                    End With
                Next xdatarow
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            xdataset = Nothing
            xserv = Nothing
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
        xdataset = Nothing
        xserv = Nothing
        Return True
    End Function

    Private Sub frmAccessLevel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SearchByPartial()

    End Sub

    Private Sub lstview_searchresults_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstview_searchresults.ColumnClick
        lstview_searchresults.Sorting = SortOrder.Ascending
        lstview_searchresults.Sort()
    End Sub

    Private Sub lstview_searchresults_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lstview_searchresults.ItemSelectionChanged
        Try
            Cursor = Cursors.WaitCursor
            With Bag_AccessLevel_Class
                .Codigo = e.Item.SubItems(0).Text
                .Nombre = e.Item.SubItems(1).Text
                .Descripcion = e.Item.SubItems(2).Text
                ShowCheckPointTree(.Codigo.ToString, "")
                'ShowCheckPointsList(.Codigo.ToString)
            End With


            Me.PropertyGrid1.SelectedObject = Bag_AccessLevel_Class
            Me.PropertyGrid1.Refresh()

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        SearchByPartial()

    End Sub

    Private Sub lstview_searchresults_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstview_searchresults.SelectedIndexChanged

    End Sub

    Public Function GetCheckPointDesc(ByVal pCheckPointID As String) As String
        Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
        Dim pResult As String = ""
        Dim xDataSet As DataSet
        xDataSet = xserv.SearchByKeyCheckPoint(pCheckPointID, pResult, PublicLoginInfo.Environment)
        If pResult = "OK" Then
            Return xDataSet.Tables(0).Rows(0)("PRIV_NAME")
        Else
            Return "N/A"
        End If

    End Function

    Private Sub txtSearchCheckPoint_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchCheckPoint.TextChanged
        ShowCheckPointTree(Bag_AccessLevel_Class.Codigo.ToString, Me.txtSearchCheckPoint.Text.ToUpper)
    End Sub

    Public Sub ShowCheckPointTree(ByVal pRoleID As String, ByVal pCheckDesc As String)
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
        Dim xds As New DataSet
        Dim pResult As String = ""
        Try
            xds = xserv.GetCheckPointsTree(pRoleID, pCheckDesc, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                Me.TreeListCheckPoints.DataSource = xds.Tables(0)
            Else
                NotifyStatus(pResult, False, True)
                Me.TreeListCheckPoints.DataSource = Nothing
            End If
            Me.TreeListCheckPoints.ExpandAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub IsGrantedCheckButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles IsGrantedCheckButton.CheckedChanged
        Dim pResult As String = ""
        Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
        Cursor = Cursors.WaitCursor


        If Not xserv.JoinCheckPointToAccessLevel(Me.TreeListCheckPoints.FocusedNode(1).ToString, Bag_AccessLevel_Class.Codigo, IIf(DirectCast(sender, DevExpress.XtraEditors.CheckEdit).Checked, "ADD", "REMOVE"), pResult, PublicLoginInfo.Environment) Then
            Cursor = Cursors.Default
            MessageBox.Show(pResult)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TreeListCheckPoints_FocusedNodeChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles TreeListCheckPoints.FocusedNodeChanged

    End Sub
End Class