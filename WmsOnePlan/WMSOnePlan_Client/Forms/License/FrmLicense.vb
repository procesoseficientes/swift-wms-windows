Imports System.Configuration
Public Class FrmLicense

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If (OfdLicense.ShowDialog() = DialogResult.OK) Then
            Dim key() As String = System.IO.File.ReadAllLines(OfdLicense.FileName)
            Dim decValue = CInt("&H" & key(0)) / 7919
            My.Settings.LicenseKey = key(0)
            BsiLicenseQty.Caption = decValue
        End If
    End Sub

    Private Sub FrmLicense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim key = My.Settings.LicenseKey
        If Not String.IsNullOrWhiteSpace(key) Then
            Dim decValue = CInt("&H" & key) / 7919
            BsiLicenseQty.Caption = decValue
        End If
        SearchByPartial()
    End Sub
    Public Function SearchByPartial()
        Dim i As Integer = 0
        Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", My.Settings.WSHOST + "/Catalogues/wms_security.asmx")
        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Dim xgrp As New ListViewGroup

        'create default groups

        Try
            xdataset = xserv.SearchPartialUserLogin("", "", "", "", pResult, "GRUPO_ALZA_QA")
            If pResult = "OK" Then
                Me.GridControl1.DataSource = xdataset.Tables(0)
                Me.GridView1.ExpandAllGroups()
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

    Public Function LicenseUser(loginId As String)
        Dim i As Integer = 0
        Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", My.Settings.WSHOST + "/Catalogues/wms_security.asmx")
        Dim xresult As Boolean
        Dim pResult As String = ""
        Dim xgrp As New ListViewGroup

        'create default groups

        Try
            xresult = xserv.UpdateLicense(loginId, Cypher(loginId), pResult, "")
            If pResult = "OK" Then
                MsgBox("Usuario licenciado")
            End If
        Catch ex As Exception
            xresult = Nothing
            xserv = Nothing

            MessageBox.Show(ex.Message)
        End Try
        xserv = Nothing
        Return True
    End Function

    Private Sub GridView1_Click(sender As Object, e As EventArgs) Handles GridView1.Click
        BtnAgregar.Enabled = True
        BtnQuitar.Enabled = False
    End Sub

    Private Sub ListBoxControl2_Click(sender As Object, e As EventArgs) Handles ListBoxControl2.Click
        BtnAgregar.Enabled = False
        BtnQuitar.Enabled = True
    End Sub

    'Funciones de cifrado
    Public Function Cypher(input As String) As String
        Dim asciis As Byte() = System.Text.Encoding.ASCII.GetBytes(input)
        Dim str = ""
        For i As Int32 = 0 To asciis.Length - 1
            str += Hex(CByte(asciis(i) + 1)) & "G"
        Next
        Return str
    End Function

    Public Function Decypher(input As String) As String
        Dim hexs = input.Split("G")
        Dim str = ""
        For i As Int32 = 0 To hexs.Length - 1
            If Not String.IsNullOrEmpty(hexs(i)) Then
                str += Chr(CInt("&H" & hexs(i)) - 1)
            End If
        Next
        Return str
    End Function
End Class