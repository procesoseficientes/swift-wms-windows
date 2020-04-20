Imports System.Windows.Forms

Public Class frmChangeTotalBoxes

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.txtTotalCajasNuevo.Text.Trim = "" Then
            Me.txtTotalCajasNuevo.Focus()
            Exit Sub
        End If
        If MessageBox.Show("Esta segudo de cambiar el total de cajas?", "Cambio de Total Cajas", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Try

                Dim xserv As New OnePlanServices_Consolidation.WMS_ConsolidationSoapClient("WMS_ConsolidationSoap", PublicLoginInfo.WSHost + "/trans/WMS_Consolidation.asmx")
                Dim pResult As String = ""
                xserv.UpdateHeaderByDocument(Me.lblPedidoNumero.Text, Me.txtTotalCajasNuevo.Text, PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)
                If pResult = "OK" Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show(pResult)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtTotalCajasNuevo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalCajasNuevo.KeyUp
        If e.KeyCode = Keys.Enter Then
            OK_Button_Click(sender, e)
        ElseIf e.KeyCode = Keys.Escape Then
            Cancel_Button_Click(sender, e)
        End If
    End Sub

    Private Sub txtTotalCajasNuevo_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtTotalCajasNuevo.MaskInputRejected

    End Sub

    Private Sub frmChangeTotalBoxes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtTotalCajasNuevo.Focus()
    End Sub
End Class
