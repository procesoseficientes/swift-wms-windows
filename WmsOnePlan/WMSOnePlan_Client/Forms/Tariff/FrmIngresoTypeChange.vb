Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.XtraRichEdit.Fields

Public Class FrmIngresoTypeChange

    Private Property TypeChangeId As Integer = 0
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LlenarCmbGridTipoServicio()
    End Sub

    Public Sub New(ByVal pTypeChangeId As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        TypeChangeId = pTypeChangeId
        LlenarCmbGridTipoServicio()
        LlenarControles()
    End Sub

    Private Sub LlenarControles()
        Dim xdatatable As New DataTable
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            xdatatable = xserv.FillTypeChange(TypeChangeId, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                chekRegimenTodos.Checked = False
                chekRegimenGeneral.Enabled = True
                chekRegimenFiscal.Enabled = True
                chekHabilitadad.Enabled = True

                If xdatatable.Rows(0)("CHARGE").ToString().Contains("SECO") Then
                    cmbCobro.SelectedIndex = 0
                ElseIf xdatatable.Rows(0)("CHARGE").ToString().Contains("REFRIGERADO") Then
                    cmbCobro.SelectedIndex = 1
                ElseIf xdatatable.Rows(0)("CHARGE").ToString().Contains("MERCDERIA") Then
                    cmbCobro.SelectedIndex = 2
                ElseIf xdatatable.Rows(0)("CHARGE").ToString().Contains("OTROS") Then
                    cmbCobro.SelectedIndex = 3
                    lblJornada.Enabled = True
                    cmbJornada.Enabled = True
                End If

                If xdatatable.Rows(0)("REGIMEN").ToString().Equals("FISCAL;GENERAL;HABILITADO") Then
                    chekRegimenTodos.Checked = True
                    chekRegimenGeneral.Enabled = False
                    chekRegimenFiscal.Enabled = False
                    chekHabilitadad.Enabled = False
                End If

                Dim regimen As String() = xdatatable.Rows(0)("REGIMEN").ToString().Split(";")
                For i As Integer = 0 To regimen.Length - 1
                    Select Case regimen(i)
                        Case "FISCAL"
                            chekRegimenFiscal.Checked = True
                        Case "GENERAL"
                            chekRegimenGeneral.Checked = True
                        Case "HABILITADO"
                            chekHabilitadad.Checked = True
                    End Select
                Next

                If xdatatable.Rows(0)("DAY_TRIP").ToString().Contains("N/A") Then
                    cmbJornada.SelectedIndex = 0
                ElseIf xdatatable.Rows(0)("DAY_TRIP").ToString().Contains("Diurno") Then
                    cmbJornada.SelectedIndex = 1
                ElseIf xdatatable.Rows(0)("DAY_TRIP").ToString().Contains("Nocturno") Then
                    cmbJornada.SelectedIndex = 2
                ElseIf xdatatable.Rows(0)("DAY_TRIP").ToString().Contains("Fin de Semana/Dias Festivos") Then
                    cmbJornada.SelectedIndex = 3
                End If

                menDescripcion.Text = xdatatable.Rows(0)("DESCRIPTION").ToString()
                menComentario.Text = xdatatable.Rows(0)("COMMENT").ToString()
                cmbTipoServicio.EditValue = xdatatable.Rows(0)("SERVICE_CODE").ToString()
                chkMovil.Checked = xdatatable.Rows(0)("TO_MOVIL").ToString().Equals("1")

            Else
                NotifyStatus(pResult, False, True)
            End If
        Catch ex As Exception
            MsgBox(pResult & ": " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function Validaction() As Boolean
        ClearIconError()

        Dim validar As Boolean = True

        dxError.SetError(chekRegimenTodos, "", ErrorType.None)
        dxError.SetError(menDescripcion, "", ErrorType.None)
        If cmbCobro.EditValue Is Nothing Or String.IsNullOrEmpty(cmbCobro.Text) Then
            dxError.SetError(cmbCobro, "Seleccione un cobro")
            validar = False
        End If

        If Not chekRegimenTodos.Checked And Not chekRegimenGeneral.Checked And Not chekRegimenFiscal.Checked And Not chekHabilitadad.Checked Then
            dxError.SetError(chekRegimenTodos, "Seleccione un regimen")
            validar = False
        End If
        If cmbTipoServicio.EditValue Is Nothing Then
            dxError.SetError(cmbTipoServicio, "Seleccione un tipo de servicio")
            validar = False
        End If

        If String.IsNullOrEmpty(menDescripcion.Text) Then
            dxError.SetError(menDescripcion, "Ingrese la descripción")
            validar = False
        End If
        Return validar
    End Function

    Private Sub CreateTypeChange()
        Try
            Dim pResult As String = ""
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")

            Dim clima As String = ""
            If cmbCobro.SelectedIndex = 0 Then
                clima = "SECO"
            ElseIf cmbCobro.SelectedIndex = 1 Then
                clima = "CONGELADO;REGRIGERADO"
            End If

            Dim regimen As String = ""
            If chekRegimenTodos.Checked Then
                regimen = "FISCAL;GENERAL;HABILITADO"
            Else
                If chekRegimenFiscal.Checked Then
                    regimen = "FISCAL"
                End If
                If chekRegimenGeneral.Checked Then
                    If Not String.IsNullOrEmpty(regimen) Then
                        regimen += ";"
                    End If
                    regimen += "GENERAL"
                End If
                If chekHabilitadad.Checked Then
                    If Not String.IsNullOrEmpty(regimen) Then
                        regimen += ";"
                    End If
                    regimen += "HABILITADO"
                End If
            End If

            If xserv.CreateTypeChange(cmbCobro.EditValue.ToString(), menDescripcion.Text, clima, regimen,
                                      menComentario.Text, IIf(cmbJornada.Enabled, cmbJornada.EditValue.ToString(), "N/A"),
                                      cmbTipoServicio.EditValue, IIf(chkMovil.Checked, 1, 0),
                                      pResult, PublicLoginInfo.Environment) Then
                If pResult = "OK" Then
                    NotifyStatus("Se grabo existosamente", True, False)
                    Me.DialogResult = DialogResult.OK
                    Close()
                Else
                    NotifyStatus(pResult, True, True)
                End If
            Else
                NotifyStatus(pResult, True, True)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UpdateTypeChange()
        Try
            Dim pResult As String = ""
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")

            Dim clima As String = "N/A"
            If cmbCobro.SelectedIndex = 0 Then
                clima = "SECO"
            ElseIf cmbCobro.SelectedIndex = 1 Then
                clima = "CONGELADA;REGRIGERADO"
            End If

            Dim regimen As String = ""
            If chekRegimenTodos.Checked Then
                regimen = "FISCAL;GENERAL;HABILITADO"
            Else
                If chekRegimenFiscal.Checked Then
                    regimen = "FISCAL"
                End If
                If chekRegimenGeneral.Checked Then
                    If Not String.IsNullOrEmpty(regimen) Then
                        regimen += ";"
                    End If
                    regimen += "GENERAL"
                End If
                If chekHabilitadad.Checked Then
                    If Not String.IsNullOrEmpty(regimen) Then
                        regimen += ";"
                    End If
                    regimen += "HABILITADO"
                End If
            End If
            If xserv.UpdateTypeChange(TypeChangeId, cmbCobro.EditValue.ToString(), menDescripcion.Text, clima, regimen,
                                      menComentario.Text, IIf(cmbJornada.Enabled, cmbJornada.EditValue.ToString(), "N/A"),
                                      cmbTipoServicio.EditValue, IIf(chkMovil.Checked, 1, 0),
                                      pResult, PublicLoginInfo.Environment) Then
                If pResult = "OK" Then
                    NotifyStatus("Se grabo existosamente", True, False)
                    Me.DialogResult = DialogResult.OK
                    Close()
                Else
                    NotifyStatus(pResult, True, True)
                End If
            Else
                NotifyStatus(pResult, True, True)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub Grabar()
        If Validaction() Then
            If TypeChangeId = 0 Then
                CreateTypeChange()
            Else
                UpdateTypeChange()
            End If
        End If
    End Sub

    Private Sub btnhCancelar_Click(sender As Object, e As EventArgs) Handles btnhCancelar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Grabar()
    End Sub

    Private Sub chekRegimenTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chekRegimenTodos.CheckedChanged
        If chekRegimenTodos.Checked Then
            chekRegimenGeneral.Enabled = False
            chekRegimenFiscal.Enabled = False
            chekHabilitadad.Enabled = False
        Else
            chekRegimenGeneral.Enabled = True
            chekRegimenFiscal.Enabled = True
            chekHabilitadad.Enabled = True
        End If
    End Sub

    Private Sub cmbCobro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCobro.SelectedIndexChanged
        If cmbCobro.SelectedIndex = 3 Then
            lblJornada.Enabled = True
            cmbJornada.Enabled = True
        Else
            lblJornada.Enabled = False
            cmbJornada.Enabled = False
        End If
    End Sub

    Private Sub LlenarCmbGridTipoServicio()

        Dim xdataset As DataTable
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            'traemos por default del webservice las polizas que su estado es 1 o dos o sea que no han sido procesadas por la sat o que no ha sido impreso el acuse
            xdataset = xserv.GetServices(pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then

                cmbTipoServicio.Properties.DataSource = xdataset
                cmbTipoServicio.Properties.PopulateViewColumns()
                cmbTipoServicio.Properties.ValueMember = "SERVICE_CODE"
                cmbTipoServicio.Properties.DisplayMember = "SERVICE_NAME"

                For i = 0 To cmbTipoServicio.Properties.View.Columns.Count - 1
                    cmbTipoServicio.Properties.View.Columns(i).Visible = False
                Next

                cmbTipoServicio.Properties.View.Columns("SERVICE_NAME").Caption = "Nombre"
                cmbTipoServicio.Properties.View.Columns("SERVICE_CODE").Caption = "Codigo"
                cmbTipoServicio.Properties.View.Columns("SERVICE_NAME").Visible = True
                cmbTipoServicio.Properties.View.Columns("SERVICE_CODE").Visible = True
                cmbTipoServicio.Properties.View.Columns("SERVICE_NAME").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                cmbTipoServicio.Properties.View.BestFitColumns()

            End If
        Catch ex As Exception
            xdataset = Nothing
            NotifyStatus(ex.Message, True, True)
        End Try
        xdataset = Nothing
        pResult = Nothing
    End Sub

    Private Sub ClearIconError()
        dxError.SetError(cmbCobro, "", ErrorType.None)
        dxError.SetError(chekRegimenTodos, "", ErrorType.None)
        dxError.SetError(cmbTipoServicio, "", ErrorType.None)
        dxError.SetError(menDescripcion, "", ErrorType.None)
    End Sub

    Private Sub cmbCobro_Leave(sender As Object, e As EventArgs) Handles cmbCobro.Leave, menDescripcion.Leave, cmbTipoServicio.Leave, chekRegimenTodos.Leave
        dxError.SetError(sender, "", ErrorType.None)
    End Sub
End Class