Imports MobilityScm.Keyboard
Public Class ExplodeMasterPackDetail

    Private Sub ExplodeMasterPackDetail_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub ListaDetalleComponente_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiListaDetalleComponente.KeyUp
        ProcessLastKey(e)
    End Sub

    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    ShowPanel(panelExplodeMasterPack)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Public Sub CargarDetalleComponentes(ByVal licencia As Integer, ByVal materialId As String)
        Try
            Dim serviceTrans As New WMS_Trans.WMS_Trans
            Dim dt As New Data.DataTable
            Dim resultado As String
            dt = serviceTrans.GetDetailMasterPackByLicense(licencia, materialId, GlobalEnviroment, resultado)
            UiListaDetalleComponente.DataSource = dt
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

End Class
