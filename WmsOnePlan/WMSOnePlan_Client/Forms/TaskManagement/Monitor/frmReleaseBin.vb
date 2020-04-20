Imports System.Windows.Forms

Public Class frmReleaseBin

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim pResult As String = ""

        Try

            Cursor = Cursors.WaitCursor
            Dim xserv As New OnePlanServices_Bins.WMS_BinsSoapClient("WMS_BinsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_bins.asmx")
            If xserv.ReleaseBin(Me.txtBIN.Value, pResult, PublicLoginInfo.Environment) Then

                '02-Mar-11 J.R. ahora graba en el log Quien libero el bin
                Dim serLog As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/Trans/wms_tasksadmin.asmx")
                If Not serLog.AddLog(PublicLoginInfo.LoginID, "RELEASE BIN", Me.txtBIN.Text, pResult, PublicLoginInfo.Environment) Then
                    MessageBox.Show("No se pudo registrar esta actividad en el Log")
                End If

                Cursor = Cursors.Default
                MessageBox.Show("BIN ha sido liberado con éxito!")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Dispose()
            Else
                Cursor = Cursors.Default
                MessageBox.Show(pResult)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub txtBIN_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBIN.EditValueChanged

    End Sub

    Private Sub txtBIN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBIN.GotFocus
        'Me.txtBI
    End Sub

    Private Sub frmReleaseBin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtBIN.Focus()
    End Sub
End Class
