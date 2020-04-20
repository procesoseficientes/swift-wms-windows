Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard

Public Class ctrl_inv_x_lic

    Private Sub SmartGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmartGrid1.Click

    End Sub

    Private Sub SmartGrid1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SmartGrid1.KeyUp
   
        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                    ShowPanel(panelRecFiscalStep1)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub
End Class
