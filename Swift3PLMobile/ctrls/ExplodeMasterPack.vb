Imports MobilityScm.Keyboard
Public Class ExplodeMasterPack

    Private Sub UiVistaMasterPack_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiVistaMasterPack.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub ExplodeMasterPack_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub UiBotonExplocionMaterPack_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiBotonExplocionMaterPack.KeyUp, UiBotonDetalleMasterPack.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub UiBotonExplocionMaterPack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiBotonExplocionMaterPack.Click
        If MensajeDeConfirmacion(String.Format("Desea Continuar el proceso")) Then
            UsuarioDeseExplatarElMasterPack()
        End If
    End Sub

    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    ShowPanel(panelMenu)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Public Sub VerificarLicencia(ByVal material As String)
        Try
            Dim serviceTrans As New WMS_Trans.WMS_Trans
            Dim dt As New Data.DataTable
            Dim resultado As String = ""
            Dim licencia As Integer = panelExplodeMasterPack.UiTextoIngresoLicencia.Tag

            dt = serviceTrans.GetMasterPackByLicense(licencia, material, GlobalEnviroment, resultado)

            If Not resultado.Equals("OK") Then
                Notify(resultado, True)
                LimpiarControles()
            Else
                Dim fila As Data.DataRow
                fila = dt.Rows(0)
                UiTextoIngresoLicencia.Tag = panelExplodeMasterPack.UiTextoIngresoLicencia.Tag
                UiTextoIngresoLicencia.Text = panelExplodeMasterPack.UiTextoIngresoLicencia.Tag
                UiTextoDescripcionCodigo.Text = fila("MATERIAL_ID")
                UiTextoDescripcionMaterial.Text = fila("MATERIAL_NAME")
                UiTextoCantidadMaterial.Text = fila("QTY")
                UiBotonExplocionMaterPack.Visible = True
                UiBotonDetalleMasterPack.Visible = True
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub UsuarioDeseExplatarElMasterPack()
        Try
            If Not UiTextoIngresoLicencia.Tag = 0 Then
                Dim serviceTrans As New WMS_Trans.WMS_Trans
                Dim resultado As String
                If serviceTrans.ExplodeMasterPack(UiTextoIngresoLicencia.Tag, UiTextoDescripcionCodigo.Text, GlobalUserID, GlobalEnviroment, resultado) Then
                    If Not resultado.Equals("OK") Then
                        Notify(resultado, True)
                    Else
                        LimpiarControles()
                    End If
                Else
                    Notify(resultado, True)
                End If
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Public Sub LimpiarControles()
        UiTextoCantidadMaterial.Text = ""
        UiTextoDescripcionCodigo.Text = ""
        UiTextoDescripcionMaterial.Text = ""
        UiBotonExplocionMaterPack.Visible = False
        UiBotonDetalleMasterPack.Visible = False
    End Sub

    Private Sub UiBotonDetalleMasterPack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiBotonDetalleMasterPack.Click
        panelExplodeMasterPackDetail.CargarDetalleComponentes(UiTextoIngresoLicencia.Tag, UiTextoDescripcionCodigo.Text)
        ShowPanel(panelExplodeMasterPackDetail)
    End Sub


    Private Sub UiTextoIngresoLicencia_GotFocus(ByVal sender As System.Object, ByVal e As Resco.Controls.DetailView.ItemEventArgs) Handles UiTextoIngresoLicencia.GotFocus
        gCurrentScannerService = gSCANNER_SERVICES.LEER_LICENCIA_PARA_MASTER_PACK
        UiTextoIngresoLicencia.Text = ""
        UiTextoIngresoLicencia.Tag = "0"
    End Sub
End Class
