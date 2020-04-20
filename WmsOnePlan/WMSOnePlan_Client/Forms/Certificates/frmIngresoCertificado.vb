Public Class frmIngresoCertificado

    Private Property CertificadoId As Integer = 0
    Private Property TieneBono As Boolean = False
    Private Property SupervisionId As Integer = 0

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        LlenarControles()
        LlenarCmbGridInspeccion()
        cmbEstado.Enabled = False
        tabHistorial.Visible = False
    End Sub

    Public Sub New(ByVal pCertificadoId As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LlenarControles()
        CertificadoId = pCertificadoId
        ObtenerDatosCertificado()
        LlenarGridHistorial()
        cmbInspeccion.Enabled = False
        dtFechaInicio.Enabled = False
        dtFechaFinal.Enabled = False
    End Sub

    Private Sub LlenarControles()
        LlenarCmbGriClient()
        LlenarCmbGridCompania()
        LlenarCmbGritBodega()
        LlenarCmbGriTipoMoneda()
        cmbEstado.SelectedIndex = 0
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    End Sub

    Private Sub ObtenerDatosCertificado()
        Try
            Dim pResult As String = ""
            Dim xserv As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")

            Dim xdata As DataSet = xserv.FillCertificate(CertificadoId, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                SupervisionId = xdata.Tables(0).Rows(0)("SUPERVISION_ID").ToString
                LlenarCmbGridInspeccion()
                cmbInspeccion.EditValue = SupervisionId
                cmbBodega.EditValue = xdata.Tables(0).Rows(0)("3PL_WAREHOUSE").ToString
                cmbEstado.EditValue = xdata.Tables(0).Rows(0)("CERTIFICATE_STATUS").ToString
                dtFechaInicio.EditValue = Date.Parse(xdata.Tables(0).Rows(0)("VALID_FROM").ToString).Date
                dtFechaFinal.EditValue = Date.Parse(xdata.Tables(0).Rows(0)("VALID_TO").ToString).Date
                cmbCliente.EditValue = xdata.Tables(0).Rows(0)("CLIENT_CODE").ToString

                If Integer.Parse(xdata.Tables(0).Rows(0)("HAS_BOND").ToString) = 1 Then
                    ObtenerDatosBono()

                End If
            Else
                MessageBox.Show(pResult)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LlenarGridHistorial()
        Try
            Dim pResult As String = ""
            Dim xserv As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")

            Dim xdataset As DataSet
            xdataset = xserv.GetCertificateLOG(CertificadoId, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                GridHistorial.DataSource = xdataset.Tables(0)
            Else
                NotifyStatus(pResult, False, True)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try

    End Sub

    Private Sub ObtenerDatosBono()
        Try
            Dim pResult As String = ""
            Dim xserv As New OnePlanServices_Bonds.WMS_BondsSoapClient("WMS_BondsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Bonds.asmx")

            Dim xdata As DataSet = xserv.FillBond(CertificadoId, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                cmbCompania.EditValue = xdata.Tables(0).Rows(0)("INSURANCES_COMPANY_ID").ToString
                txtNumeroBono.Text = xdata.Tables(0).Rows(0)("BOND_ID").ToString
                ceMonto.EditValue = xdata.Tables(0).Rows(0)("AMOUNT").ToString
                cmbTipoMoneda.EditValue = xdata.Tables(0).Rows(0)("CURRENCY").ToString
                TieneBono = True
                gcBono.Visible = True
                btnGrabar.Enabled = False
                btnGrabarMasBono.Enabled = False
            Else
                MessageBox.Show(pResult)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LlenarCmbGriClient()

        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
            'traemos por default del webservice las polizas que su estado es 1 o dos o sea que no han sido procesadas por la sat o que no ha sido impreso el acuse
            xdataset = xserv.GetViewClients(pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then

                cmbCliente.Properties.DataSource = xdataset.Tables(0)
                cmbCliente.Properties.PopulateViewColumns()
                cmbCliente.Properties.ValueMember = "CLIENT_CODE"
                cmbCliente.Properties.DisplayMember = "CLIENT_NAME"

                For i = 0 To cmbCliente.Properties.View.Columns.Count - 1
                    cmbCliente.Properties.View.Columns(i).Visible = False
                Next

                cmbCliente.Properties.View.Columns("CLIENT_NAME").Caption = "NOMBRE"
                cmbCliente.Properties.View.Columns("CLIENT_CODE").Caption = "CODIGO"
                cmbCliente.Properties.View.Columns("CLIENT_NAME").Visible = True
                cmbCliente.Properties.View.Columns("CLIENT_CODE").Visible = True
                cmbCliente.Properties.View.Columns("CLIENT_NAME").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                cmbCliente.Properties.View.BestFitColumns()

            End If
        Catch ex As Exception
            xdataset = Nothing
            NotifyStatus(ex.Message, True, True)
        End Try
        xdataset = Nothing
        pResult = Nothing
    End Sub

    Private Sub LlenarCmbGriTipoMoneda()

        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")
            'traemos por default del webservice las polizas que su estado es 1 o dos o sea que no han sido procesadas por la sat o que no ha sido impreso el acuse
            xdataset = xserv.SelectCurrency(pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then

                cmbTipoMoneda.Properties.DataSource = xdataset.Tables(0)
                cmbTipoMoneda.Properties.PopulateViewColumns()
                cmbTipoMoneda.Properties.ValueMember = "PARAM_NAME"
                cmbTipoMoneda.Properties.DisplayMember = "PARAM_CAPTION"

                For i = 0 To cmbTipoMoneda.Properties.View.Columns.Count - 1
                    cmbTipoMoneda.Properties.View.Columns(i).Visible = False
                Next

                cmbTipoMoneda.Properties.View.Columns("PARAM_CAPTION").Caption = "Descipción"
                cmbTipoMoneda.Properties.View.Columns("PARAM_NAME").Caption = "Nombre"
                cmbTipoMoneda.Properties.View.Columns("PARAM_CAPTION").Visible = True
                cmbTipoMoneda.Properties.View.Columns("PARAM_NAME").Visible = True
                cmbTipoMoneda.Properties.View.Columns("PARAM_CAPTION").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                cmbTipoMoneda.Properties.View.BestFitColumns()

            End If
        Catch ex As Exception
            xdataset = Nothing
            NotifyStatus(ex.Message, True, True)
        End Try
        xdataset = Nothing
        pResult = Nothing
    End Sub

    Private Sub LlenarCmbGridInspeccion()
        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Supervisions.WMS_SupervisionsSoapClient("WMS_SupervisionsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Supervisions.asmx")
            xdataset = xserv.GetSupervisions(True, pResult, PublicLoginInfo.Environment)

            If Not SupervisionId = 0 Then
                If pResult = "OK" Or pResult = "ERROR, No encontraron registros." Then
                    Try
                        pResult = ""
                        Dim xservS As New OnePlanServices_Supervisions.WMS_SupervisionsSoapClient("WMS_SupervisionsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Supervisions.asmx")

                        Dim xdata As DataSet = xservS.FillSupervisions(SupervisionId, pResult, PublicLoginInfo.Environment)

                        If pResult = "OK" Then
                            xdataset.Tables(0).Rows.Add(xdata.Tables(0).Rows(0)("SUPER_ID").ToString, "", "", xdata.Tables(0).Rows(0)("CLIENT_OWHEN").ToString)
                        Else
                            MessageBox.Show(pResult)
                        End If
                    Catch ex As Exception
                        NotifyStatus(ex.Message, True, True)
                    End Try
                End If
            End If

            If pResult = "OK" Then
                cmbInspeccion.Properties.DataSource = xdataset.Tables(0)
                cmbInspeccion.Properties.PopulateViewColumns()
                cmbInspeccion.Properties.ValueMember = "SUPER_ID"
                cmbInspeccion.Properties.DisplayMember = "CLIENT_OWHEN"

                For i = 0 To cmbInspeccion.Properties.View.Columns.Count - 1
                    cmbInspeccion.Properties.View.Columns(i).Visible = False
                Next

                cmbInspeccion.Properties.View.Columns("CLIENT_OWHEN").Caption = "NOMBRE"
                cmbInspeccion.Properties.View.Columns("SUPER_ID").Caption = "CODIGO"
                cmbInspeccion.Properties.View.Columns("CLIENT_OWHEN").Visible = True
                cmbInspeccion.Properties.View.Columns("SUPER_ID").Visible = True
                cmbInspeccion.Properties.View.Columns("CLIENT_OWHEN").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                cmbInspeccion.Properties.View.BestFitColumns()

            End If
        Catch ex As Exception
            xdataset = Nothing
            NotifyStatus(ex.Message, True, True)
        End Try
        xdataset = Nothing
        pResult = Nothing
    End Sub

    Private Sub LlenarCmbGridCompania()

        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Insurance_Companies.WMS_Insurance_CompaniesSoapClient("WMS_Insurance_CompaniesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Companies.asmx")
            'traemos por default del webservice las polizas que su estado es 1 o dos o sea que no han sido procesadas por la sat o que no ha sido impreso el acuse
            xdataset = xserv.GetInsuranceCompany(pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then

                cmbCompania.Properties.DataSource = xdataset.Tables(0)
                cmbCompania.Properties.PopulateViewColumns()
                cmbCompania.Properties.ValueMember = "COMPANY_ID"
                cmbCompania.Properties.DisplayMember = "COMPANY_NAME"

                For i = 0 To cmbCompania.Properties.View.Columns.Count - 1
                    cmbCompania.Properties.View.Columns(i).Visible = False
                Next

                cmbCompania.Properties.View.Columns("COMPANY_NAME").Caption = "NOMBRE"
                cmbCompania.Properties.View.Columns("COMPANY_ID").Caption = "CODIGO"
                cmbCompania.Properties.View.Columns("COMPANY_NAME").Visible = True
                cmbCompania.Properties.View.Columns("COMPANY_ID").Visible = True
                cmbCompania.Properties.View.BestFitColumns()

            End If
        Catch ex As Exception
            xdataset = Nothing
            NotifyStatus(ex.Message, True, True)
        End Try
        xdataset = Nothing
        pResult = Nothing
    End Sub

    Private Sub LlenarCmbGritBodega()

        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")

            xdataset = xserv.SelectWarehousesEnabled(pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then

                cmbBodega.Properties.DataSource = xdataset.Tables(0)
                cmbBodega.Properties.PopulateViewColumns()
                cmbBodega.Properties.ValueMember = "WAREHOUSE_ID"
                cmbBodega.Properties.DisplayMember = "NAME"

                For i = 0 To cmbBodega.Properties.View.Columns.Count - 1
                    cmbBodega.Properties.View.Columns(i).Visible = False
                Next

                cmbBodega.Properties.View.Columns("NAME").Caption = "NOMBRE"
                cmbBodega.Properties.View.Columns("WAREHOUSE_ID").Caption = "CODIGO"
                cmbBodega.Properties.View.Columns("NAME").Visible = True
                cmbBodega.Properties.View.Columns("WAREHOUSE_ID").Visible = True
                cmbBodega.Properties.View.BestFitColumns()

            End If
        Catch ex As Exception
            xdataset = Nothing
            NotifyStatus(ex.Message, True, True)
        End Try
        xdataset = Nothing
        pResult = Nothing
    End Sub

    Public Function LlenarGriSupervisionsDet(ByVal pInspeccionId As Integer)
        GridDet.DataSource = Nothing
        Dim i As Integer = 0
        Dim pResult As String = ""
        Dim xdataset As New DataSet
        Dim xgrp As New ListViewGroup

        Dim xserv As New OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoapClient("WMS_SupervisionsDetailSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_SupervisionsDetail.asmx")

        Try
            xdataset = xserv.GetSupervisionsDetail(pInspeccionId, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridDet.DataSource = xdataset.Tables(0)
            End If
        Catch ex As Exception
            xdataset = Nothing
            xserv = Nothing

            MessageBox.Show(ex.Message)
        End Try
        xdataset = Nothing
        xserv = Nothing
        Return True
    End Function

    Private Sub cmbInspeccion_EditValueChanged(sender As Object, e As EventArgs) Handles cmbInspeccion.EditValueChanged
        Try
            If Not cmbInspeccion.EditValue = Nothing Then
                LlenarGriSupervisionsDet(Integer.Parse(cmbInspeccion.EditValue))
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Function ValidarFormulario(ByVal pValidarControlesBono As Boolean) As Boolean
        Try
            If cmbInspeccion.EditValue = Nothing Then
                NotifyStatus("Seleccione una Inspección", True, True)
                cmbInspeccion.Focus()
                Return False
            End If

            If cmbBodega.EditValue = Nothing Then
                NotifyStatus("Seleccione una Bodega", True, True)
                cmbBodega.Focus()
                Return False
            End If

            If dtFechaInicio.EditValue Is Nothing Then
                NotifyStatus("Ingrese la fecha de inicio", True, True)
                dtFechaInicio.Focus()
                Return False
            End If

            If dtFechaFinal.EditValue Is Nothing Then
                NotifyStatus("Ingrese la fecha de final", True, True)
                dtFechaFinal.Focus()
                Return False
            End If

            If Date.Parse(dtFechaInicio.EditValue).Date > Date.Parse(dtFechaFinal.EditValue).Date Then
                NotifyStatus("La fecha de inicio es mayor a la fecha final", True, True)
                dtFechaInicio.Focus()
                Return False
            End If

            If cmbCliente.EditValue = Nothing Then
                NotifyStatus("Seleccione un Cliente", True, True)
                cmbCliente.Focus()
                Return False
            End If
            If pValidarControlesBono Then
                If cmbCompania.EditValue = Nothing Then
                    NotifyStatus("Seleccione un Compañia", True, True)
                    cmbCompania.Focus()
                    Return False
                End If
                If String.IsNullOrEmpty(txtNumeroBono.Text) Then
                    NotifyStatus("Ingrese el Numero de Bono", True, True)
                    txtNumeroBono.Focus()
                    Return False
                End If

                If cmbTipoMoneda.EditValue = Nothing Then
                    NotifyStatus("Seleccione un tipo de moneda", True, True)
                    ceMonto.Focus()
                    Return False
                End If

                If ceMonto.EditValue = Nothing Then
                    NotifyStatus("Ingrese el Monto", True, True)
                    ceMonto.Focus()
                    Return False
                End If

                If ceMonto.EditValue <= 0 Then
                    NotifyStatus("El Monto debe ser mayor a cero", True, True)
                    ceMonto.Focus()
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
            Return False
        End Try
    End Function

    Private Sub CrearCertificado()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")

            Dim pCertificadoId As Integer
            Dim grabo As New Boolean
            grabo = xserv.CreateCertificate(gcBono.Visible, pCertificadoId, PublicLoginInfo.LoginID, cmbInspeccion.EditValue, cmbBodega.EditValue, dtFechaInicio.EditValue, dtFechaFinal.EditValue, cmbCliente.EditValue, pResult, PublicLoginInfo.Environment)
            If grabo Then
                If grabo Then
                    If pResult = "OK" Then
                        If gcBono.Visible Then
                            CreateBond(pCertificadoId)
                        Else
                            NotifyStatus("Se grabo existosamente", True, False)
                            Me.DialogResult = DialogResult.OK
                            Close()
                        End If

                    Else
                        NotifyStatus(pResult, True, True)
                    End If
                Else
                    NotifyStatus(pResult, True, True)
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub CreateBond(ByVal pCertificadoId As Integer)
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Bonds.WMS_BondsSoapClient("WMS_BondsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Bonds.asmx")

            Dim grabo As New Boolean
            grabo = xserv.CreateBond(pCertificadoId, txtNumeroBono.Text, ceMonto.EditValue, cmbCompania.EditValue, cmbTipoMoneda.EditValue,
                                     pResult, PublicLoginInfo.Environment)
            If grabo Then
                If grabo Then
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
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UpdateStatusSupervision(ByVal pSuperId As Integer, ByVal pAsignado As Boolean)
        Try
            Dim pResult As String = ""
            Try
                Dim xserv As New OnePlanServices_Supervisions.WMS_SupervisionsSoapClient("WMS_SupervisionsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Supervisions.asmx")

                Dim grabo As New Boolean
                grabo = xserv.UpdateStatusSupervision(pSuperId, pAsignado, pResult, PublicLoginInfo.Environment)

                If grabo Then
                    If grabo Then
                        If pResult = "OK" Then

                        Else
                            NotifyStatus(pResult, True, True)
                        End If
                    Else
                        NotifyStatus(pResult, True, True)
                    End If
                End If
            Catch ex As Exception
                NotifyStatus(ex.Message, True, True)
            End Try
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UpdateCertificado()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")

            Dim grabo As New Boolean
            grabo = xserv.UpdateCertificate(CertificadoId, PublicLoginInfo.LoginID, cmbInspeccion.EditValue, cmbBodega.EditValue, cmbEstado.Text,
                                            dtFechaInicio.EditValue, dtFechaFinal.EditValue, cmbCliente.EditValue, IIf(gcBono.Visible, 1, 0),
                                            pResult, PublicLoginInfo.Environment)
            If grabo Then
                If grabo Then
                    If pResult = "OK" Then
                        If gcBono.Visible Then
                            If TieneBono Then
                                UpdateBond()
                            Else
                                CreateBond(CertificadoId)
                            End If
                        Else
                            DeleteBond()
                        End If

                    Else
                        NotifyStatus(pResult, True, True)
                    End If
                Else
                    NotifyStatus(pResult, True, True)
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UpdateBond()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Bonds.WMS_BondsSoapClient("WMS_BondsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Bonds.asmx")

            Dim grabo As New Boolean
            grabo = xserv.UpdateBond(CertificadoId, txtNumeroBono.Text, ceMonto.EditValue, cmbCompania.EditValue, cmbTipoMoneda.EditValue,
                                     pResult, PublicLoginInfo.Environment)
            If grabo Then
                If grabo Then
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
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub DeleteBond()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Bonds.WMS_BondsSoapClient("WMS_BondsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Bonds.asmx")

            Dim grabo As New Boolean
            grabo = xserv.DeleteBond(CertificadoId, pResult, PublicLoginInfo.Environment)
            If grabo Then
                If grabo Then
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
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub Grabar(ByVal pBono As Boolean)
        Try
            If ValidarFormulario(pBono) Then
                If CertificadoId = 0 Then
                    CrearCertificado()
                    UpdateStatusSupervision(cmbInspeccion.EditValue, True)
                Else
                    UpdateCertificado()
                    If Not SupervisionId = cmbInspeccion.EditValue Then
                        UpdateStatusSupervision(SupervisionId, False)
                        UpdateStatusSupervision(cmbInspeccion.EditValue, True)
                    End If
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnGrabarMasBono_Click(sender As Object, e As EventArgs) Handles btnGrabarMasBono.Click
        gcBono.Visible = True
        btnGrabar.Enabled = False
        btnGrabarMasBono.Enabled = False
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Grabar(False)
    End Sub

    Private Sub btnGrabarBono_Click(sender As Object, e As EventArgs) Handles btnGrabarBono.Click
        Grabar(True)
    End Sub

    Private Sub btnCancelarBono_Click(sender As Object, e As EventArgs) Handles btnCancelarBono.Click
        gcBono.Visible = False
        btnGrabar.Enabled = True
        btnGrabarMasBono.Enabled = True
    End Sub
End Class