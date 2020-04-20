Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard
Public Class myCounting
    Private Sub myCounting_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)
    End Sub
    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)

        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    ShowPanel(panelMenu)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_UBICACION_CONTEO
                    gCurrentTransactionType = gTRANS_TYPE.CONTEO
                    Cursor.Current = Cursors.WaitCursor
                    ShowPanel(panelMyCounting)
                    LoadPage("counting_tasks", gPanelTitle, False)
                    Cursor.Current = Cursors.Default
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub
End Class
