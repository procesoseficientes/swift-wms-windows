Imports System.Data
Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard

Public Class MyReception

    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    ShowPanel(panelMenu)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
                    Cursor.Current = Cursors.WaitCursor
                    GetMyReceptionTasks(gRegimen)
                    Cursor.Current = Cursors.Default
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Public Sub GetMyReceptionTasks(ByVal Regimen As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim xset As DataTable
            Dim pResult As String = ""
            Dim xserv As New WMS_InfoTrans.WMS_InfoTrans
            Cursor.Current = Cursors.WaitCursor
            xset = xserv.ObtenerTareasRecepcionAsignadasUsuario(Regimen, Nothing, GlobalUserID, GlobalEnviroment, pResult)
            UiListaTareas.DataRows.Clear()
            Me.UiListaTareas.DataSource = xset
            Me.UiListaTareas.Refresh()

        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub


    Private Sub MyReception_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub UiListaTareas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiListaTareas.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub UiListaTareas_ButtonClick(ByVal sender As System.Object, ByVal e As Resco.Controls.AdvancedList.CellEventArgs) Handles UiListaTareas.ButtonClick
        Try

            Dim pResult As String = String.Empty
            gPoliza = e.DataRow("POLIZA").ToString
            gTaskId = e.DataRow("TAREA").ToString
            gOrden = e.DataRow("ORDEN").ToString

            Dim xserbInfoTrans As New WMS_InfoTrans.WMS_InfoTrans

            Dim result As DataTable
            result = xserbInfoTrans.ValidateTaskStatus(GlobalUserID, gTaskId, 0, 0, 0, "TAREA_RECEPCION", GlobalEnviroment, pResult)
            If pResult = "OK" AndAlso result.Rows(0)(0) = 1 Then
                pResult = String.Empty
                ShowPanel(panelTransHandler)
                LoadPage("poliza", gPanelTitle, True)
                ReviewPoliza(gPoliza, gOrden, True, pResult)
                Cursor.Current = Cursors.WaitCursor
            Else
                Notify(IIf(pResult = "OK", result.Rows(0)(1).ToString(), pResult), True)
            End If


           
           
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try

    End Sub
End Class
