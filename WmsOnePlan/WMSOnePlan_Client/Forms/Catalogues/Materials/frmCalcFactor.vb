Public Class frmCalcFactor


    Private Sub txtAlto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAlto.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.txtLargo.Focus()
        End If
    End Sub
    Private Sub txtLargo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLargo.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.txtAncho.Focus()
        End If

    End Sub
    Private Sub txtAncho_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAncho.KeyUp
        If e.KeyCode = Keys.Enter Then
            CalcFactor()
        End If

    End Sub
    Sub CalcFactor()
        Try
            Bag_Materials_Class.FactorVolumen = (CDbl(txtAlto.Text) * CDbl(txtLargo.Text) * CDbl(txtAncho.Text)) / 1000

            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        CalcFactor()
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Close()
    End Sub
End Class