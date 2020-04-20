Imports MobilityScm.Keyboard
Public Class UbicacionesSugeridas

    Private Sub AdvancedTree_Default_FooterClick(ByVal sender As System.Object, ByVal e As Resco.Controls.AdvancedTree.CellEventArgs)

    End Sub
    Private Sub AdvancedTree_Default_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub
    Private Sub AdvancedTree_Default_NodeEntered(ByVal sender As System.Object, ByVal e As Resco.Controls.AdvancedTree.NodeEnteredEventArgs)

    End Sub
    Private Sub AdvancedTree_Default_ButtonClick(ByVal sender As System.Object, ByVal e As Resco.Controls.AdvancedTree.CellEventArgs)

    End Sub

    Private Sub Ubicaciones_Sugeridas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ProcessLastKey(e)
    End Sub

    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
            Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                ShowPanel(panelTransHandler)
        End Select
    End Sub

    Private Sub UIVistaUbicacionesSugeridas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UIVistaUbicacionesSugeridas.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub UiTitleUbicacionesSugeridas__KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ProcessLastKey(e)
    End Sub

    Private Sub UiTitleUbicacionesSugeridas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiTitleUbicacionesSugeridas.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub panelLabelTitle_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles panelLabelTitle.KeyUp
        ProcessLastKey(e)
    End Sub
End Class
