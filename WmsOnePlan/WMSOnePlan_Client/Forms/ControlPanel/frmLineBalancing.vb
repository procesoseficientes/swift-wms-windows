Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices

Public Class frmLineBalancing
    Private Sub LineBalancing()

        With LineBalancing_Class
            .Tamano = ""
            .Descripcion = ""
            .RangoInicial = 0
            .RangoFinal = 0
            .PorcentajeLinea1 = 0
            .PorcentajeLinea2 = 0
            .PorcentajeLinea3 = 0
            Me.PropertyGrid1.SelectedObject = LineBalancing_Class
            Me.PropertyGrid1.Refresh()
        End With

    End Sub
    Public Sub SaveAndRefresh()
        Dim pResult As String = ""
        If LineBalancing_Class.Grabar(pResult) Then
            FilListView()
            Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            Dim pSize As String = xdatarow(0).ToString
            ShowSize(pSize)
        Else
            MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        SaveAndRefresh()
    End Sub
    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click
        Dim pResult As String = ""
        Dim pResponse As DialogResult = DialogResult.No

        pResponse = MessageBox.Show("Confirma eliminacion?", "Confirme accion", MessageBoxButtons.YesNo)
        If pResponse = DialogResult.Yes Then

            Dim xrow As DataRow
            Try
                If GridView1.SelectedRowsCount >= 1 Then

                    For i = 0 To GridView1.RowCount - 1
                        If GridView1.IsRowSelected(i) Then
                            xrow = GridView1.GetDataRow(i)
                            LineBalancing_Class.Tamano = IIf(IsDBNull(xrow("SIZE")), "", xrow("SIZE"))
                            If Not LineBalancing_Class.Delete(pResult) Then
                                Cursor = Cursors.Default
                                MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End If
                    Next
                    FilListView()
                    LineBalancing()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        End If
    End Sub
    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        LineBalancing()
    End Sub

    Private Sub frmLineBalancing_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmLineBalancing_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmLineBalancing_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmLineBalancing_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmLineBalancing_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmLineBalancing_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmLineBalancing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gLastScreenShowed = Me.Name
        FilListView()
    End Sub
    Public Function FilListView()
        Me.Cursor = Cursors.WaitCursor
        SearchByPartial()
        Me.Cursor = Cursors.Default
        Return True
    End Function

    Public Function SearchByPartial()
        Dim i As Integer = 0
        Dim pResult As String = ""
        Dim xdataset As New DataSet
        Dim xgrp As New ListViewGroup

        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")


        Try
            xdataset = xserv.SearchPartialBalancingBySize("", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridControl1.DataSource = xdataset.Tables(0)
                GridControl2.DataSource = xdataset.Tables(0)
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
            Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            Dim pSize As String = xdatarow(0).ToString
            ShowSize(pSize)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GridControl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Try
            If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                Dim pID As String = xdatarow(0).ToString
                ShowSize(pID)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ShowSize(ByVal pid As String)
        LineBalancing()
        Dim pResult As String = ""
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")

        Dim xdata As DataSet = xserv.SearchLineBalancingBySize(pid, pResult, PublicLoginInfo.Environment)
        If pResult = "OK" Then

            With LineBalancing_Class
                .Tamano = pid
                .Descripcion = xdata.Tables(0).Rows(0)("SIZE_DESCRIPTION").ToString
                .RangoInicial = IIf(IsDBNull(xdata.Tables(0).Rows(0)("INITIAL_RANGE")), "0", xdata.Tables(0).Rows(0)("INITIAL_RANGE"))
                .RangoFinal = IIf(IsDBNull(xdata.Tables(0).Rows(0)("FINAL_RANGE")), "0", xdata.Tables(0).Rows(0)("FINAL_RANGE"))
                .PorcentajeLinea1 = IIf(IsDBNull(xdata.Tables(0).Rows(0)("LINE_1_PERCENT")), "0", xdata.Tables(0).Rows(0)("LINE_1_PERCENT"))
                .PorcentajeLinea2 = IIf(IsDBNull(xdata.Tables(0).Rows(0)("LINE_2_PERCENT")), "0", xdata.Tables(0).Rows(0)("LINE_2_PERCENT"))
                .PorcentajeLinea3 = IIf(IsDBNull(xdata.Tables(0).Rows(0)("LINE_3_PERCENT")), "0", xdata.Tables(0).Rows(0)("LINE_3_PERCENT"))
            End With

            PropertyGrid1.SelectedObject = LineBalancing_Class
            
        Else
            Me.GridControl2.DataSource = Nothing
            MessageBox.Show(pResult)
        End If
    End Sub

End Class
