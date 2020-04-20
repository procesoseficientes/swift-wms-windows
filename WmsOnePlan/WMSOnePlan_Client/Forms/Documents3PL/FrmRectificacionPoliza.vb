Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository

Public Class FrmRectificacionPoliza

    Public _pendienteDeRectificacion As Integer = 0
    Public _clasePoliza As String = ""
    ReadOnly serverTresPl As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    ReadOnly serverSetting As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")

    Sub New(ByVal pendienteDeRectificacion As Integer, ByVal docId As Integer, ByVal codigoPoliza As String, ByVal numeroOrden As String, ByVal docIdRectificacion As Integer, ByVal comentario As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UiEtiquetaNumeroDocumento.Text = docId.ToString()
        UiEtiquetaNumeroOrden.Text = numeroOrden
        UiEtiqeutaPoliza.Text = codigoPoliza
        LlenarListaPolizasParaRectificar()

        If pendienteDeRectificacion = 0 Then
            Dim pResult As String
            Dim dsParametros = serverSetting.GetParam_ByParamKey("EGRESOS", "CLASES_POLIZAS", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                _clasePoliza = dsParametros.Tables(0).Rows(0)("TEXT_VALUE")
            Else
                NotifyStatus(pResult, True, True)
            End If
        Else
            UiListaPolizasParaRectificar.EditValue = docIdRectificacion
            UiMemoComentario.Text = comentario
            UiListaPolizasParaRectificar.Enabled = False
            UiMemoComentario.Enabled = False
            UiBotonAceptar.Enabled = False
        End If

    End Sub

    Private Sub LlenarListaPolizasParaRectificar()
        Try
            Dim pResult As String = ""
            Dim dt As New DataTable
            dt = serverTresPl.ObtenerPolizasPendientesDeRectificacion(pResult, PublicLoginInfo.Environment)
            If pResult = "" Then
                If Not IsNothing(dt) Then
                    UiListaPolizasParaRectificar.Properties.DataSource = dt
                    UiListaPolizasParaRectificar.Properties.PopulateViewColumns()
                    UiListaPolizasParaRectificar.Properties.ValueMember = "DOC_ID"
                    'UiListaPolizasParaRectificar.Properties.DisplayMember = "DOC_ID;CODIGO_POLIZA;NUMERO_ORDEN"

                    For i = 0 To UiListaPolizasParaRectificar.Properties.View.Columns.Count - 1
                        UiListaPolizasParaRectificar.Properties.View.Columns(i).Visible = False
                    Next
                    UiListaPolizasParaRectificar.Properties.View.Columns("COMENTARIO_RECTIFICACION").Caption = "Comentario"
                    UiListaPolizasParaRectificar.Properties.View.Columns("CLIENT_NAME").Caption = "Nombre Cliente"
                    UiListaPolizasParaRectificar.Properties.View.Columns("CLIENT_CODE").Caption = "Código Cliente"
                    UiListaPolizasParaRectificar.Properties.View.Columns("NUMERO_ORDEN").Caption = "Numero de Orden"
                    UiListaPolizasParaRectificar.Properties.View.Columns("CODIGO_POLIZA").Caption = "Codigo de Poliza"
                    UiListaPolizasParaRectificar.Properties.View.Columns("DOC_ID").Caption = "Numero de Documento"
                    UiListaPolizasParaRectificar.Properties.View.Columns("COMENTARIO_RECTIFICACION").Visible = True
                    UiListaPolizasParaRectificar.Properties.View.Columns("CLIENT_NAME").Visible = True
                    UiListaPolizasParaRectificar.Properties.View.Columns("CLIENT_CODE").Visible = True
                    UiListaPolizasParaRectificar.Properties.View.Columns("NUMERO_ORDEN").Visible = True
                    UiListaPolizasParaRectificar.Properties.View.Columns("CODIGO_POLIZA").Visible = True
                    UiListaPolizasParaRectificar.Properties.View.Columns("DOC_ID").Visible = True
                End If
            Else
                MsgBox(pResult)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UiBotonAceptar_Click(sender As Object, e As EventArgs) Handles UiBotonAceptar.Click
        If UiListaPolizasParaRectificar.EditValue = Nothing Or String.IsNullOrEmpty(UiListaPolizasParaRectificar.EditValue) Then
            NotifyStatus("Seleccione una poliza", True, True)
        Else
            UsuarioDeseaAceptarLaRectificacion()
        End If
    End Sub

    Private Sub UiBotonCancelar_Click(sender As Object, e As EventArgs) Handles UiBotonCancelar.Click
        Me.Close()
    End Sub

    Private Sub UiListaPolizasParaRectificar_CustomDisplayText(sender As Object, e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles UiListaPolizasParaRectificar.CustomDisplayText
        Try
            Dim edit As New GridLookUpEdit
            edit = CType(sender, GridLookUpEdit)
            Dim theIndex As Integer = edit.Properties.GetIndexByKeyValue(edit.EditValue)
            If edit.Properties.View.IsDataRow(theIndex) Then
                Dim row As DataRow = edit.Properties.View.GetDataRow(theIndex)
                e.DisplayText = row("DOC_ID").ToString() + "; " + row("CODIGO_POLIZA").ToString() + "; " + row("NUMERO_ORDEN").ToString()
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UiListaPolizasParaRectificar_Properties_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles UiListaPolizasParaRectificar.Properties.ButtonClick
        If e.Button.Tag = "REFRESH" Then
            LlenarListaPolizasParaRectificar()
        End If
    End Sub

    Private Sub UiListaPolizasParaRectificar_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles UiListaPolizasParaRectificar.QueryPopUp
        Dim editor As GridLookUpEdit = CType(sender, GridLookUpEdit)
        Dim properties As RepositoryItemGridLookUpEdit = editor.Properties
        properties.PopupFormSize = New Size(editor.Width + 250, properties.PopupFormSize.Height)
    End Sub

    Private Sub UsuarioDeseaAceptarLaRectificacion()
        Try
            If MessageBox.Show("Desea continuar, esto sera irreversible?", "Rectificación", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim resultado As String = ""
                resultado = serverTresPl.EstablecerPolizaRetificacion(UiListaPolizasParaRectificar.EditValue, Integer.Parse(UiEtiquetaNumeroDocumento.Text), UiMemoComentario.Text, _clasePoliza, PublicLoginInfo.LoginID, PublicLoginInfo.Environment)
                If resultado.Equals("OK") Then
                    _pendienteDeRectificacion = UiListaPolizasParaRectificar.EditValue
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