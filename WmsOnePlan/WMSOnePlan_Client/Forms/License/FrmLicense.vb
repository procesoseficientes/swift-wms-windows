Public Class FrmLicense

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If (OfdLicense.ShowDialog() = DialogResult.OK) Then
            Dim key() As String = System.IO.File.ReadAllLines(OfdLicense.FileName)
            Dim decValue = CInt("&H" & key(0)) / 7919
            MsgBox(decValue)
        End If
    End Sub
End Class