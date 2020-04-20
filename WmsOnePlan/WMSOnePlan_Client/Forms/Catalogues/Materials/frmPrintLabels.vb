Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices

Public Class frmPrintLabels

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        gLabelSize = IIf(Me.RadioGroup1.SelectedIndex = 0, "2X2", "1X3C")
        Me.Close()
    End Sub
    
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        gLabelSize = IIf(Me.RadioGroup1.SelectedIndex = 0, "2X2", "1X3C")
        Me.Close()
    End Sub
End Class

