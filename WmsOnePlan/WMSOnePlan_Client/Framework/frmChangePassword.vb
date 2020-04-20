Public Class frmChangePassword

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub chkShowPass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowPass.CheckedChanged
        If chkShowPass.CheckState = CheckState.Checked Then
            Me.txtPass1.Properties.PasswordChar = ""
            Me.txtPass2.Properties.PasswordChar = ""
        Else
            Me.txtPass1.Properties.PasswordChar = "*"
            Me.txtPass2.Properties.PasswordChar = "*"
        End If
    End Sub

    Private Sub txtPass2_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPass2.EditValueChanged

    End Sub

    Private Sub txtPass2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPass2.Leave
        
    End Sub

    Private Sub GroupControl1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupControl1.Paint

    End Sub

    Private Sub frmChangePassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblUserID.Text = PublicLoginInfo.LoginID
        Me.lblUserName.Text = PublicLoginInfo.LoginName
        Me.txtPass1.Focus()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim pResult As String = ""
        Try
            Cursor = Cursors.WaitCursor
            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")


            If Me.txtPass1.Text <> Me.txtPass2.Text Then
                MessageBox.Show("Confirmacion de Password no coincide", "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtPass1.Focus()
                Exit Sub
            End If

            If xserv.UpdateUserPwd(PublicLoginInfo.LoginID, Me.txtPass1.Text, pResult, PublicLoginInfo.Environment) Then
                Cursor = Cursors.Default
                MessageBox.Show("Password Cambiado", "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Cursor = Cursors.Default
                MessageBox.Show(pResult, "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class