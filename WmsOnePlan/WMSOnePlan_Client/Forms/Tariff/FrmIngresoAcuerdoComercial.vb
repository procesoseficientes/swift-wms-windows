Imports System.Web.UI.WebControls.Expressions
Imports System.Configuration
Imports DevExpress.XtraEditors.DXErrorProvider
Imports System.Net.Mail
Imports DevExpress.Office.Drawing

Public Class FrmIngresoAcuerdoComercial

    Private Property AcuerdoComercialId As Integer = 0
    Private Property SerialId As Integer = 0
    Public Property IsoCambios As Boolean = 0
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LlenarCmbGriTipoMoneda()
        LlenarCmbUsuario()
        LlenarCmbTipoMedida()
        lblDiasFechas.Visible = False
        lblEstado.Visible = False
    End Sub

    Public Sub New(ByVal pAcuerdoComercialId As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        AcuerdoComercialId = pAcuerdoComercialId
        LlenarCmbGriTipoMoneda()
        LlenarCmbUsuario()
        LlenarCmbTipoMedida()
        CargarControles()

    End Sub

#Region "Encabezado"

    Private Sub CargarControles()
        Dim xdatatable As New DataTable
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            xdatatable = xserv.FillTarificadoHeader(AcuerdoComercialId, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                txtNombre.Text = xdatatable.Rows(0)("ACUERDO_COMERCIAL_NOMBRE")
                dtFechaIncio.EditValue = Date.Parse(xdatatable.Rows(0)("VALID_FROM").ToString())
                dtFechaIncio.Enabled = False
                dtFechaFinal.EditValue = Date.Parse(xdatatable.Rows(0)("VALID_TO").ToString())
                dtFechaFinal.Enabled = False
                lblDiasFechas.Text = String.Format("Acuerdo Valido para {0} dias", DateDiff(DateInterval.Day, Date.Parse(dtFechaIncio.EditValue.ToString()), Date.Parse(dtFechaFinal.EditValue.ToString())))
                cmbClima.Text = xdatatable.Rows(0)("WAREHOUSE_WEATHER")
                cmbClima.Enabled = False
                cmbRegimen.Text = xdatatable.Rows(0)("REGIMEN")
                cmbRegimen.Enabled = False
                cmbMoneda.Text = xdatatable.Rows(0)("CURRENCY")

                lblEstado.Text = IIf(xdatatable.Rows(0)("STATUS").Equals("0"), "Acuerdo Inactivo", "Acuerdo Activo")

                menComentarioEnc.Text = xdatatable.Rows(0)("COMMENTS")
                cmbUsuario.EditValue = xdatatable.Rows(0)("AUTHORIZER")
                grupDetalle.Enabled = True
                LlenarCmbTipoCobro()
                LlenarGrid()
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub CreateTarifarioHeader()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            If xserv.CreateTarificadorHeader(AcuerdoComercialId, txtNombre.Text, Date.Parse(dtFechaIncio.EditValue), Date.Parse(dtFechaFinal.EditValue), 0,
                                             cmbMoneda.EditValue, "ACTIVE", cmbClima.EditValue,
                                             menComentarioEnc.Text, cmbRegimen.EditValue, cmbUsuario.EditValue, pResult, PublicLoginInfo.Environment) Then
                If pResult = "OK" Then
                    NotifyStatus("Se grabo exitosamente", True, False)
                    dtFechaIncio.Enabled = False
                    dtFechaFinal.Enabled = False
                    cmbClima.Enabled = False
                    cmbRegimen.Enabled = False
                    grupDetalle.Enabled = True
                    IsoCambios = True
                    LlenarCmbTipoCobro()
                    lblDiasFechas.Visible = True
                    lblEstado.Visible = True

                    lblDiasFechas.Text = String.Format("Acuerdo Valido para {0} dias", DateDiff(DateInterval.Day, Date.Parse(dtFechaIncio.EditValue.ToString()), Date.Parse(dtFechaFinal.EditValue.ToString())))
                    lblEstado.Text = "Acuerdo Comercial Activo"

                    SetEmail()
                Else
                    NotifyStatus(pResult, False, True)
                End If
            Else
                NotifyStatus(pResult, False, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UpdateTarifarioHeader()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            If xserv.UpdateTarificadorHeader(AcuerdoComercialId, txtNombre.Text, Date.Parse(dtFechaIncio.EditValue), Date.Parse(dtFechaFinal.EditValue), 0,
                                             cmbMoneda.EditValue, "ACTIVE", PublicLoginInfo.LoginID, cmbClima.EditValue,
                                             menComentarioEnc.Text, cmbRegimen.EditValue, cmbUsuario.EditValue, pResult, PublicLoginInfo.Environment) Then
                If pResult = "OK" Then
                    IsoCambios = True
                    NotifyStatus("Se grabo exitosamente", True, False)
                Else
                    NotifyStatus(pResult, False, True)
                End If
            Else
                NotifyStatus(pResult, False, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnGrabarEnc_Click(sender As Object, e As EventArgs) Handles btnGrabarEnc.Click
        If ValidarControlesENc() Then
            If AcuerdoComercialId = 0 Then
                CreateTarifarioHeader()
            Else
                UpdateTarifarioHeader()
            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Function ValidarControlesENc() As Boolean
        Dim validar As Boolean = True
        If String.IsNullOrEmpty(txtNombre.Text) Then
            dxError.SetError(txtNombre, "Ingrese el nombre")
            validar = False
        End If

        If dtFechaIncio.EditValue = Nothing Then
            dxError.SetError(dtFechaIncio, "Ingrese la fecha de inicio")
            validar = False
        End If

        If dtFechaFinal.EditValue = Nothing Then
            dxError.SetError(dtFechaFinal, "Ingrese la fecha de final")
            validar = False
        End If

        If Not dtFechaIncio.EditValue = Nothing And Not dtFechaFinal.EditValue = Nothing Then
            If Date.Parse(dtFechaIncio.EditValue.ToString()) > Date.Parse(dtFechaFinal.EditValue.ToString()) Then
                dxError.SetError(dtFechaFinal, "La fecha de inicio no puede ser mayor a la fecha final")
                validar = False
            End If
        End If

        Return validar
    End Function

    Private Sub txtNombre_Leave(sender As Object, e As EventArgs) Handles txtNombre.Leave, dtFechaIncio.Leave, dtFechaFinal.Leave, txtTransaccion.Leave, spinPrecioUn.Leave, spinLimite.Leave, cmbTipoCobro.Leave, cmbMoneda.Leave
        dxError.SetError(sender, "", errorType:=ErrorType.None)
    End Sub

    Private Sub LlenarCmbUsuario()

        Dim xdatatable As DataTable
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
            'traemos por default del webservice las polizas que su estado es 1 o dos o sea que no han sido procesadas por la sat o que no ha sido impreso el acuse
            xdatatable = xserv.SearchByAuthorizerUserLogin("1", pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then

                cmbUsuario.Properties.DataSource = xdatatable
                cmbUsuario.Properties.PopulateViewColumns()
                cmbUsuario.Properties.ValueMember = "LOGIN_ID"
                cmbUsuario.Properties.DisplayMember = "LOGIN_NAME"

                For i = 0 To cmbUsuario.Properties.View.Columns.Count - 1
                    cmbUsuario.Properties.View.Columns(i).Visible = False
                Next

                cmbUsuario.Properties.View.Columns("LOGIN_NAME").Caption = "DESCRIPTION"
                cmbUsuario.Properties.View.Columns("LOGIN_ID").Caption = "CHARGE"
                cmbUsuario.Properties.View.Columns("LOGIN_NAME").Visible = True
                cmbUsuario.Properties.View.Columns("LOGIN_ID").Visible = True
                'cmbUsuario.Properties.View.Columns("LOGIN_ID").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                cmbUsuario.Properties.View.BestFitColumns()

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub SetEmail()
        Try
            If ConfigurationManager.AppSettings("EnviioEmail") = "SI" Then
                Dim xdataset As DataSet
                Dim pResult As String = ""
                Dim email As String = ""
                Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
                xdataset = xserv.SearchByKeyUserLogin(cmbUsuario.EditValue, pResult, PublicLoginInfo.Environment)
                If pResult = "OK" Then
                    Dim xdatarow As DataRow
                    xdatarow = xdataset.Tables(0).Rows(0)
                    email = IIf(IsDBNull(xdatarow("EMAIL")), "", xdatarow("EMAIL"))
                End If

                Dim mail As New MailMessage()
                Dim smtpServer As New SmtpClient(ConfigurationManager.AppSettings("smtp"))
                smtpServer.Port = 587

                smtpServer.EnableSsl = True
                smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network
                smtpServer.UseDefaultCredentials = False
                smtpServer.Credentials = New Net.NetworkCredential(ConfigurationManager.AppSettings("Email"), ConfigurationManager.AppSettings("pwsEmail"))
                mail.From = New MailAddress("admin@mobilityscm.com")
                mail.To.Add(email)
                mail.Subject = "Autorización de Acuerdo Comercial"
                mail.Body = String.Format("Para el acuerdo comercial: {0}", _txtNombre.Text)
                smtpServer.Send(mail)

                NotifyStatus("Se envio el email correctamente", False, False)

                MsgBox("Sent Successfully")
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub



#End Region

#Region "Detalle"

    Private Sub LlenarGrid()
        Dim xdatatable As New DataTable
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            xdatatable = xserv.GetTarifarioDetail(AcuerdoComercialId, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridDet.DataSource = xdatatable
            Else
                NotifyStatus(pResult, False, True)
            End If
            GridViewDet.BestFitColumns()
            GridViewDet.ExpandAllGroups()
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub CreateTarifarioDetail()
        Dim pResult As String = ""
        Try
            Dim frecuencia As Integer = 0
            If cmbFrecuencia.SelectedIndex = 1 Then
                frecuencia = 1
            ElseIf cmbFrecuencia.SelectedIndex = 2 Then
                frecuencia = 7
            ElseIf cmbFrecuencia.SelectedIndex = 3 Then
                frecuencia = 15
            ElseIf cmbFrecuencia.SelectedIndex = 4 Then
                frecuencia = 30
            End If

            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            If xserv.CreateTarificadorDetail(AcuerdoComercialId, 0, cmbTipoCobro.EditValue, spinPrecioUn.EditValue,
                                             "", menComentarioDet.Text, frecuencia, spinLimite.EditValue,
                                             IIf(cmbMedida.EditValue.Equals("N/A"), "N/A", cmbTipoMedida.EditValue), txtTransaccion.Text, cmbMedida.EditValue,
                                             pResult, PublicLoginInfo.Environment) Then
                If pResult = "OK" Then
                    grupDetalle.Enabled = True
                    IsoCambios = True
                    LlenarGrid()
                    LimpiarControlesDet()
                Else
                    NotifyStatus(pResult, False, True)
                End If
            Else
                NotifyStatus(pResult, False, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UpdateTarifarioDetail()
        Dim pResult As String = ""
        Try
            Dim frecuencia As Integer = 0
            If cmbFrecuencia.SelectedIndex = 1 Then
                frecuencia = 1
            ElseIf cmbFrecuencia.SelectedIndex = 2 Then
                frecuencia = 7
            ElseIf cmbFrecuencia.SelectedIndex = 3 Then
                frecuencia = 15
            ElseIf cmbFrecuencia.SelectedIndex = 4 Then
                frecuencia = 30
            End If

            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            If xserv.UpdateTarificadorDetail(AcuerdoComercialId, 0, SerialId, cmbTipoCobro.EditValue, spinPrecioUn.EditValue,
                                             "", PublicLoginInfo.LoginID, menComentarioDet.Text, frecuencia, spinLimite.EditValue,
                                             IIf(cmbMedida.EditValue.Equals("N/A"), "N/A", cmbTipoMedida.EditValue), txtTransaccion.Text, cmbMedida.EditValue,
                                             pResult, PublicLoginInfo.Environment) Then
                If pResult = "OK" Then
                    SerialId = 0
                    LlenarGrid()
                    LimpiarControlesDet()
                Else
                    NotifyStatus(pResult, False, True)
                End If
            Else
                NotifyStatus(pResult, False, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub SelectDet()
        ClearIconError()
        Try
            If GridViewDet.SelectedRowsCount = 1 Then
                Dim xdatarow As DataRow = GridViewDet.GetDataRow(GridViewDet.FocusedRowHandle)
                SerialId = Integer.Parse(xdatarow("SERIAL_ID").ToString)

                cmbTipoCobro.EditValue = IIf(IsDBNull(xdatarow("TYPE_CHARGE_ID")), "", xdatarow("TYPE_CHARGE_ID"))
                spinPrecioUn.EditValue = IIf(IsDBNull(xdatarow("UNIT_PRICE")), 0, xdatarow("UNIT_PRICE"))

                menComentarioDet.Text = IIf(IsDBNull(xdatarow("COMMENTS")), "", xdatarow("COMMENTS"))

                If Not IsDBNull(xdatarow("BILLING_FRECUENCY")) Then
                    If xdatarow("BILLING_FRECUENCY") = 1 Then
                        cmbFrecuencia.SelectedIndex = 1
                    ElseIf xdatarow("BILLING_FRECUENCY") = 7 Then
                        cmbFrecuencia.SelectedIndex = 2
                    ElseIf xdatarow("BILLING_FRECUENCY") = 15 Then
                        cmbFrecuencia.SelectedIndex = 3
                    ElseIf xdatarow("BILLING_FRECUENCY") = 30 Then
                        cmbFrecuencia.SelectedIndex = 4
                    Else
                        cmbFrecuencia.SelectedIndex = 0
                    End If
                End If

                spinLimite.EditValue = IIf(IsDBNull(xdatarow("LIMIT_TO")), 0, xdatarow("LIMIT_TO"))
                cmbMedida.Text = IIf(IsDBNull(xdatarow("TYPE_MEASURE")), "", xdatarow("TYPE_MEASURE"))
                LlenarCmbTipoMedida()
                cmbTipoMedida.EditValue = IIf(IsDBNull(xdatarow("U_MEASURE")), "", xdatarow("U_MEASURE"))
                txtTransaccion.Text = IIf(IsDBNull(xdatarow("TX_SOURCE")), "", xdatarow("TX_SOURCE"))

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnUpdateDet_Click(sender As Object, e As EventArgs) Handles btnUpdateDet.Click
        SelectDet()
    End Sub

    Private Sub GridDet_DoubleClick(sender As Object, e As EventArgs) Handles GridDet.DoubleClick
        SelectDet()
    End Sub

    Private Sub btnGrabarDet_Click(sender As Object, e As EventArgs) Handles btnGrabarDet.Click
        If ValidarControlesDet() Then
            If SerialId = 0 Then
                CreateTarifarioDetail()
            Else
                UpdateTarifarioDetail()
            End If
        End If
    End Sub

    Private Sub btnNewDet_Click(sender As Object, e As EventArgs) Handles btnNewDet.Click
        ClearIconError()
        LimpiarControlesDet()
    End Sub

    Private Sub LlenarCmbTipoCobro()

        Dim xdatatable As New DataTable
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            'traemos por default del webservice las polizas que su estado es 1 o dos o sea que no han sido procesadas por la sat o que no ha sido impreso el acuse
            xdatatable = xserv.GetTypeChangeXRegimenClima(cmbRegimen.EditValue, cmbClima.EditValue, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then

                cmbTipoCobro.Properties.DataSource = xdatatable
                cmbTipoCobro.Properties.PopulateViewColumns()
                cmbTipoCobro.Properties.ValueMember = "TYPE_CHARGE_ID"
                cmbTipoCobro.Properties.DisplayMember = "DESCRIPTION"

                For i = 0 To cmbTipoCobro.Properties.View.Columns.Count - 1
                    cmbTipoCobro.Properties.View.Columns(i).Visible = False
                Next

                cmbTipoCobro.Properties.View.Columns("COMMENT").Caption = "Comentario"
                cmbTipoCobro.Properties.View.Columns("DESCRIPTION").Caption = "DESCRIPTION"
                cmbTipoCobro.Properties.View.Columns("CHARGE").Caption = "CHARGE"
                cmbTipoCobro.Properties.View.Columns("COMMENT").Visible = True
                cmbTipoCobro.Properties.View.Columns("DESCRIPTION").Visible = True
                cmbTipoCobro.Properties.View.Columns("CHARGE").Visible = True
                'cmbTipoCobro.Properties.View.Columns("CHARGE").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                cmbTipoCobro.Properties.View.BestFitColumns()

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub DeleteDet()
        Dim pResult As String = ""
        Try
            If GridViewDet.SelectedRowsCount = 1 Then
                If MessageBox.Show("Desea borrar el registro?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim xdatarow As DataRow = GridViewDet.GetDataRow(GridViewDet.FocusedRowHandle)
                    Dim serialId As Integer = Integer.Parse(xdatarow("SERIAL_ID").ToString)

                    Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")

                    If xserv.DeleteTarificadorDetail(AcuerdoComercialId, serialId, pResult, PublicLoginInfo.Environment) Then
                        If pResult.Equals("OK") Then
                            LlenarGrid()
                        Else
                            NotifyStatus(pResult, True, True)
                        End If
                    Else
                        NotifyStatus(pResult, True, True)
                    End If
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnDeleteDet_Click(sender As Object, e As EventArgs) Handles btnDeleteDet.Click
        DeleteDet()
    End Sub

    Private Sub LimpiarControlesDet()
        cmbTipoCobro.EditValue = ""
        SerialId = 0
        spinPrecioUn.EditValue = 0
        cmbFrecuencia.SelectedIndex = 0
        spinLimite.EditValue = 0
        cmbMedida.SelectedIndex = 0
        txtTransaccion.Text = ""
        menComentarioDet.Text = ""
    End Sub

    Private Function ValidarControlesDet() As Boolean
        Dim validar As Boolean = True
        If cmbTipoCobro.EditValue = Nothing Then
            dxError.SetError(cmbTipoCobro, "Seleccione un tipo de cobro")
            validar = False
        End If

        If spinPrecioUn.EditValue <= 0 Then
            dxError.SetError(spinPrecioUn, "No puede ser menor o igual a cero")
            validar = False
        End If

        If spinLimite.EditValue < 0 Then
            dxError.SetError(spinLimite, "No puede ser menor cero")
            validar = False
        End If

        If cmbMedida.EditValue = Nothing Then
            dxError.SetError(cmbMoneda, "Seleccione la medida")
            validar = False
        Else
            If Not cmbMedida.EditValue.Equals("N/A") Then
                If cmbTipoMedida.EditValue = Nothing Then
                    dxError.SetError(cmbTipoMedida, "Seleccione el tipo de medida")
                    validar = False
                End If
            End If
        End If

        Return validar
    End Function

    Private Sub ClearIconError()
        dxError.SetError(cmbTipoCobro, "", ErrorType.None)
        dxError.SetError(spinPrecioUn, "", ErrorType.None)
        dxError.SetError(spinLimite, "", ErrorType.None)
        dxError.SetError(cmbMoneda, "", ErrorType.None)
        dxError.SetError(cmbTipoMedida, "", ErrorType.None)

    End Sub

    Private Sub LlenarCmbGriTipoMoneda()

        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")
            'traemos por default del webservice las polizas que su estado es 1 o dos o sea que no han sido procesadas por la sat o que no ha sido impreso el acuse
            xdataset = xserv.SelectCurrency(pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then

                cmbMoneda.Properties.DataSource = xdataset.Tables(0)
                cmbMoneda.Properties.PopulateViewColumns()
                cmbMoneda.Properties.ValueMember = "PARAM_NAME"
                cmbMoneda.Properties.DisplayMember = "PARAM_CAPTION"

                For i = 0 To cmbMoneda.Properties.View.Columns.Count - 1
                    cmbMoneda.Properties.View.Columns(i).Visible = False
                Next

                cmbMoneda.Properties.View.Columns("PARAM_CAPTION").Caption = "Descipción"
                cmbMoneda.Properties.View.Columns("PARAM_NAME").Caption = "Nombre"
                cmbMoneda.Properties.View.Columns("PARAM_CAPTION").Visible = True
                cmbMoneda.Properties.View.Columns("PARAM_NAME").Visible = True
                cmbMoneda.Properties.View.Columns("PARAM_CAPTION").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                cmbMoneda.Properties.View.BestFitColumns()

            End If
        Catch ex As Exception
            xdataset = Nothing
            NotifyStatus(ex.Message, True, True)
        End Try
        xdataset = Nothing
        pResult = Nothing
    End Sub

    Private Sub LlenarCmbTipoMedida()
        Dim xdatatable As New DataTable
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            'traemos por default del webservice las polizas que su estado es 1 o dos o sea que no han sido procesadas por la sat o que no ha sido impreso el acuse
            xdatatable = xserv.SelectMedidas("SISTEMA", cmbMedida.EditValue, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then

                cmbTipoMedida.Properties.DataSource = xdatatable
                cmbTipoMedida.Properties.PopulateViewColumns()
                cmbTipoMedida.Properties.ValueMember = "PARAM_NAME"
                cmbTipoMedida.Properties.DisplayMember = "PARAM_CAPTION"

                For i = 0 To cmbTipoMedida.Properties.View.Columns.Count - 1
                    cmbTipoMedida.Properties.View.Columns(i).Visible = False
                Next

                cmbTipoMedida.Properties.View.Columns("PARAM_CAPTION").Caption = "Descipción"
                cmbTipoMedida.Properties.View.Columns("PARAM_NAME").Caption = "Nombre"
                cmbTipoMedida.Properties.View.Columns("PARAM_CAPTION").Visible = True
                cmbTipoMedida.Properties.View.Columns("PARAM_NAME").Visible = True
                cmbTipoMedida.Properties.View.Columns("PARAM_CAPTION").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                cmbTipoMedida.Properties.View.BestFitColumns()

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub cmbMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMedida.SelectedIndexChanged
        If cmbMedida.SelectedIndex = 0 Then
            cmbTipoMedida.EditValue = ""
            cmbTipoMedida.Enabled = False
        Else
            LlenarCmbTipoMedida()
            cmbTipoMedida.Enabled = True
        End If
    End Sub

#End Region

End Class