Public Class FrmRectificarPoliza

    Public _pendienteDeRectificacion As Integer = 0
    ReadOnly serverSetting As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
    ReadOnly serverTresPl As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Sub New(ByVal pendienteDeRectificacion As Integer, ByVal docId As Integer, ByVal codigoPoliza As String, ByVal numeroOrden As String,
            ByVal comentario As String, ByVal clasePoliza As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UiEtiquetaNumeroDocumento.Text = docId.ToString()
        UiEtiquetaNumeroOrden.Text = numeroOrden
        UiEtiqeutaPoliza.Text = codigoPoliza
        If pendienteDeRectificacion = 0 Then
            Dim pResult As String
            Dim dsParametros = serverSetting.GetParam_ByParamKey("EGRESOS", "CLASES_POLIZAS", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                UiEtiquetaClasePoliza.Text = dsParametros.Tables(0).Rows(0)("TEXT_VALUE")
            Else
                NotifyStatus(pResult, True, True)

            End If
        Else
            UiEtiquetaClasePoliza.Text = clasePoliza
            UiMemoComentario.Text = comentario
            UiMemoComentario.Enabled = False
            UiBotonAceptar.Enabled = False
        End If
    End Sub

    Private Sub UiBotonAceptar_Click(sender As Object, e As EventArgs) Handles UiBotonAceptar.Click
        If String.IsNullOrEmpty(UiEtiquetaClasePoliza.Text) Then
            NotifyStatus("No se encontro ninguna clase para rectificar.", True, True)
        Else
            UsuarioDeseaAceptarLaRectificacion()
        End If
    End Sub


    Private Sub UiBotonCancelar_Click(sender As Object, e As EventArgs) Handles UiBotonCancelar.Click
        Me.Close()
    End Sub

    Private Sub UsuarioDeseaAceptarLaRectificacion()
        Try
            If MessageBox.Show("Desea continuar, esto sera irreversible?", "Rectificación", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim resultado As String = ""
                resultado = serverTresPl.EstablecerPolizaPendienteRetificacion(Integer.Parse(UiEtiquetaNumeroDocumento.Text), UiEtiqeutaPoliza.Text, UiMemoComentario.Text, UiEtiquetaClasePoliza.Text, PublicLoginInfo.LoginID, PublicLoginInfo.Environment)
                If resultado.Equals("OK") Then
                    _pendienteDeRectificacion = 1
                    Me.Close()
                Else
                    NotifyStatus(resultado, True, True)
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
End Class