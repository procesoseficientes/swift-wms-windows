Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard

Public Class ctrl_browse

    Private Sub ctrl_browse_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)
    End Sub
    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try

            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                    ShowNextPicture()
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    ShowPrevPicture()
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                    Select Case gCurrentScannerService
                        Case gSCANNER_SERVICES.LEER_POLIZA
                            ShowPanel(panelTransHandler)

                    End Select
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
            End Select

            'Select Case e.KeyCode
            '    Case Keys.Enter 'move to next picture

            '    Case Keys.Back

            '    Case Keys.Escape 'close panel and return to last panel


            '    Case Keys.Left 'close panel and return to last panel
            '        Select Case gCurrentScannerService
            '            Case gSCANNER_SERVICES.LEER_POLIZA
            '                ShowPanel(panelTransHandler)

            '        End Select

            'End Select

        Catch ex As Exception
            Notify("ProcessLastKey: " + ex.Message, True)
        End Try

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        ShowNextPicture()
    End Sub
End Class
