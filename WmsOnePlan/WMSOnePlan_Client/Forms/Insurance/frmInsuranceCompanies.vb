Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices

Public Class frmInsuranceCompanies
    Private Property EsNuevo As New Boolean

    Private Sub ClearBag_InsuranceCompanies()

        With Bag_Insurance_Companies
            .Codigo = ""
            .Nombre = ""
            .FechaCreacion = ""
            .UsuarioCreacion = ""

            Me.PropertyGrid1.SelectedObject = Bag_Insurance_Companies
            Me.PropertyGrid1.Refresh()
        End With
    End Sub

    Public Function SearchByPartial()
        Dim i As Integer = 0
        Dim pResult As String = ""
        Dim xdataset As New DataSet
        Dim xgrp As New ListViewGroup

        Dim xserv As New OnePlanServices_Insurance_Companies.WMS_Insurance_CompaniesSoapClient("WMS_Insurance_CompaniesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Companies.asmx")

        Try
            xdataset = xserv.GetInsuranceCompany(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridControl1.DataSource = xdataset.Tables(0)
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

    Public Function FilListView()
        Me.Cursor = Cursors.WaitCursor
        SearchByPartial()
        Me.Cursor = Cursors.Default
        Return True
    End Function

    Private Sub frmInsuranceCompanies_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FilListView()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        Try
            Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            Dim pBIN As String = xdatarow("COMPANY_ID").ToString
            ShowMaterial(pBIN)
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try

    End Sub

    Sub ShowMaterial(ByVal pid As String)
        EsNuevo = False
        ClearBag_InsuranceCompanies()
        Dim pResult As String = ""
        Dim xserv As New OnePlanServices_Insurance_Companies.WMS_Insurance_CompaniesSoapClient("WMS_Insurance_CompaniesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Companies.asmx")

        Dim xdata As DataSet = xserv.FillInsuranceCompany(pid, pResult, PublicLoginInfo.Environment)
        If pResult = "OK" Then
            With Bag_Insurance_Companies
                .Codigo = xdata.Tables(0).Rows(0)("COMPANY_ID").ToString
                .Nombre = xdata.Tables(0).Rows(0)("COMPANY_NAME").ToString
                .FechaCreacion = xdata.Tables(0).Rows(0)("CREATED_DATE").ToString
                .UsuarioCreacion = xdata.Tables(0).Rows(0)("CREATED_BY").ToString
            End With
            PropertyGrid1.SelectedObject = Bag_Insurance_Companies
        Else
            MessageBox.Show(pResult)
        End If
    End Sub

    Public Sub SaveAndRefresh()
        Dim pResult As String = ""
        If EsNuevo Then
            If Bag_Insurance_Companies.Create(pResult) Then
                FilListView()
                ClearBag_InsuranceCompanies()
            Else
                MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            If Bag_Insurance_Companies.Update(pResult) Then
                FilListView()
                ClearBag_InsuranceCompanies()
            Else
                MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub DeleteAndRefresh()
        Dim pResult As String = ""
        If Bag_Insurance_Companies.Delete(pResult) Then
            FilListView()
            ClearBag_InsuranceCompanies()
        Else
            MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub NewToolStripButton_Click(sender As Object, e As EventArgs) Handles NewToolStripButton.Click
        EsNuevo = True
        ClearBag_InsuranceCompanies()
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        SaveAndRefresh()
    End Sub


    Private Sub CutToolStripButton_Click(sender As Object, e As EventArgs) Handles CutToolStripButton.Click
        DeleteAndRefresh()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        SaveFileDialog1.DefaultExt = "xlsx"
        SaveFileDialog1.Filter = "Archivos de excel (*.xlsx)|*.xlsx"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridView1.ExportToXlsx(SaveFileDialog1.FileName)
        End If
    End Sub
End Class