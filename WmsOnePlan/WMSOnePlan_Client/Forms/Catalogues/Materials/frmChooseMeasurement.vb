Public Class frmChooseMeasurement
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        gLabelSize = Me.RadioGroup1.EditValue
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        gLabelSize = Me.RadioGroup1.EditValue
        Me.Close()
    End Sub
End Class