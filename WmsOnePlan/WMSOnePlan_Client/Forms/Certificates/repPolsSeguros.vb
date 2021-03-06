﻿Imports System.IO

Public Class repPolsSeguros

    Inherits DevExpress.XtraReports.UI.XtraReport
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub repPolsSeguros_DataSourceDemanded(sender As Object, e As EventArgs) Handles MyBase.DataSourceDemanded 
        

        Try
            Dim logo = DirectCast(Parameters("logoImg").Value, String)
            logo = logo.Replace("data:image/png;base64,", "")
            logo = logo.Replace("data:image/jpeg;base64,", "")

            Dim data As Byte() = Convert.FromBase64String(logo)
            Dim stream = New MemoryStream(data, 0, data.Length)
            Dim image1 As Image = Image.FromStream(stream)
            UiImagenLogo.Image = image1
        Catch ex As Exception
            'ScriptManager.RegisterStartupScript(this, GetType(), "ErrorText", "CallError('Error: " + ex.Message + "');", true);
            Dim data As Byte() = Convert.FromBase64String("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")
            Dim stream = New MemoryStream(data, 0, data.Length)
            Dim image1 As Image = Image.FromStream(stream)
            UiImagenLogo.Image = image1
        End Try
    End Sub
End Class