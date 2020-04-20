Imports DevExpress.Data.Linq
Imports DevExpress.Utils
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraReports.UI

Public Class FrmCertificateDeposit

    Public DataTableDet As DataTable
    Public EsNuevo As Boolean = True
    Public DocCertificateId As Integer = 0
    Public PolizaAseguradora As String = 0

    Private Sub FrmCertificateDeposit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarListaClientes()
        LLenarControles()
        LlenarListaTiposAlmacen()

    End Sub

    Private Sub UiListaCliente_EditValueChanged(sender As Object, e As EventArgs) Handles UiListaCliente.EditValueChanged
        LlenarListaRecepcionEncabezado()
        LlenarVistaCertificadosEncabezdos()
    End Sub

    Private Sub UiListaRecepcion_EditValueChanged(sender As Object, e As EventArgs) Handles UiListaRecepcion.EditValueChanged
        LLenarListaRecepcionDetalle()
    End Sub

    Private Sub UiBotonRefreshRecepcion_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonRefreshRecepcion.ItemClick
        LlenarListaRecepcionEncabezado()

    End Sub

    Private Sub UiFechaInicioRecepcion_EditValueChanged(sender As Object, e As EventArgs) Handles UiFechaInicioRecepcion.EditValueChanged, UiFechaFinalRecepcion.EditValueChanged
        LlenarListaRecepcionEncabezado()
    End Sub

    Private Sub FrmCertificateDeposit_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        UiSplitPrincipal.SplitterPosition = (Width / 2) - 100
    End Sub

    Private Sub UiBotonAgregarCertificado_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonAgregarCertificado.ItemClick
        AgregarDetalle()
    End Sub

    Private Sub UiBotonBorrarDetCet_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonBorrarDetCet.ItemClick
        EliminarDetCertificado()
    End Sub

    Private Sub UiBotonGrabarCertificado_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonGrabarCertificado.ItemClick
        GrabarDocumento()
    End Sub

    Private Sub UiVistaCertificadoEncabezado_DoubleClick(sender As Object, e As EventArgs) Handles UiVistaCertificadoEncabezado.DoubleClick
        SelecionaronCertificadoEncabezados()
        UiPopupReporte.Hide()
        UiPopupEstado.Hide()
    End Sub

    Private Sub UiBotonCambiarEstado_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonCambiarEstado.ItemClick
        CambiarEstadoCertificado()
    End Sub

    Private Sub UiBotonRefreshCertificado_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonRefreshCertificado.ItemClick
        LlenarVistaCertificadosEncabezdos()
    End Sub

    Private Sub UiBotonNuevoCertificado_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonNuevoCertificado.ItemClick
        DesbloquearControles()
    End Sub

    Private Sub UiBotonImprimir_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonImprimir.ItemClick
        MostrarPopup()
    End Sub
    

    Private Sub UiBotonGenerarReporte_Click(sender As Object, e As EventArgs) Handles UiBotonGenerarReporte.Click
        If Not UiListaAlmacenaje.EditValue Is Nothing And Not String.IsNullOrEmpty(UiListaAlmacenaje.Text) Then
            GenerarReporte()
        End If
    End Sub

#Region "Metodos y Funciones"

    Private Sub LlenarVistaCertificadosEncabezdos()
        Try
            If Not UiListaCliente.EditValue = "" Then
                Dim serverCertificate As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")
                Dim pResult As String = ""
                Dim dt As DataTable
                dt = serverCertificate.GetCertificateDepositByClient("GetDocByCliente", UiListaCliente.EditValue, UiFechaInicioRecepcion.EditValue, UiFechaFinalRecepcion.EditValue, pResult, PublicLoginInfo.Environment)
                If pResult = "" Then
                    UiVistaCertificadoEncabezado.DataSource = dt
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LlenarListaClientes()
        Try
            Dim serverClient As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
            Dim pResult As String = ""
            Dim dsClientes As New DataSet
            dsClientes = serverClient.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)
            If pResult.Equals("OK") Then
                UiListaCliente.Properties.DataSource = dsClientes.Tables(0)
                UiListaCliente.Properties.PopulateViewColumns()
                UiListaCliente.Properties.ValueMember = "CLIENT_CODE"
                UiListaCliente.Properties.DisplayMember = "CLIENT_NAME"

                For i = 0 To UiListaCliente.Properties.View.Columns.Count - 1
                    UiListaCliente.Properties.View.Columns(i).Visible = False
                Next
                UiListaCliente.Properties.View.Columns("CLIENT_NAME").Caption = "NOMBRE"
                UiListaCliente.Properties.View.Columns("CLIENT_CODE").Caption = "CODIGO"
                UiListaCliente.Properties.View.Columns("CLIENT_NAME").Visible = True
                UiListaCliente.Properties.View.Columns("CLIENT_CODE").Visible = True
                UiListaCliente.Properties.View.BestFitColumns()

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LlenarListaRecepcionEncabezado()
        Try
            If Not UiListaCliente.EditValue = "" Then
                Dim serverCertificate As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")
                Dim pResult As String = ""
                Dim dt As DataTable
                dt = serverCertificate.GetDocByCliente("GetDocByCliente", UiListaCliente.EditValue, UiFechaInicioRecepcion.EditValue, UiFechaFinalRecepcion.EditValue, pResult, PublicLoginInfo.Environment)
                If pResult = "" Then
                    UiListaRecepcion.Properties.DataSource = dt
                    UiListaRecepcion.Properties.PopulateViewColumns()
                    UiListaRecepcion.Properties.ValueMember = "DOC_ID"
                    UiListaRecepcion.Properties.DisplayMember = "CODIGO_POLIZA"

                    For i = 0 To UiListaRecepcion.Properties.View.Columns.Count - 1
                        UiListaRecepcion.Properties.View.Columns(i).Visible = False
                    Next

                    UiListaRecepcion.Properties.View.Columns("FECHA_DOCUMENTO").Caption = "Fecha de Documento"
                    UiListaRecepcion.Properties.View.Columns("FECHA_DOCUMENTO").DisplayFormat.FormatString = "dd/MM/yyyy"
                    UiListaRecepcion.Properties.View.Columns("FECHA_DOCUMENTO").DisplayFormat.FormatType = FormatType.DateTime
                    UiListaRecepcion.Properties.View.Columns("WAREHOUSE_REGIMEN").Caption = "Regimen"
                    UiListaRecepcion.Properties.View.Columns("CODIGO_POLIZA").Caption = "Codigo Poliza"
                    UiListaRecepcion.Properties.View.Columns("DOC_ID").Caption = "Numero Documento"

                    UiListaRecepcion.Properties.View.Columns("FECHA_DOCUMENTO").Visible = True
                    UiListaRecepcion.Properties.View.Columns("WAREHOUSE_REGIMEN").Visible = True
                    UiListaRecepcion.Properties.View.Columns("CODIGO_POLIZA").Visible = True
                    UiListaRecepcion.Properties.View.Columns("DOC_ID").Visible = True

                    UiListaRecepcion.Properties.View.BestFitColumns()
                Else
                    NotifyStatus(pResult, True, True)
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LLenarListaRecepcionDetalle()
        Try

            If Not UiListaRecepcion.EditValue = Nothing Then

                Dim row As DataRowView = TryCast(UiListaRecepcion.Properties.GetRowByKeyValue(UiListaRecepcion.EditValue), DataRowView)

                Dim serverCertificate As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")
                Dim pResult As String = ""

                Dim dt As DataTable

                If row.Item("WAREHOUSE_REGIMEN").Equals("GENERAL") Then
                    dt = serverCertificate.GetDetailByDocForCertificateAlmge("GetDetailByDocForCertificate", UiListaRecepcion.EditValue, pResult, PublicLoginInfo.Environment)
                Else
                    dt = serverCertificate.GetDetailByDocForCertificate("GetDetailByDocForCertificate", UiListaRecepcion.EditValue, pResult, PublicLoginInfo.Environment)
                End If
                
                If pResult = "" Then
                    UIListaRecepcionDetalle.Properties.DataSource = dt
                Else
                    NotifyStatus(pResult, True, True)
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LLenarControles()
        UiFechaInicioCertificados1.EditValue = Date.Today.AddDays(-15)
        UiFechaFinalCertificados.EditValue = Date.Today

        UiFechaInicioRecepcion.EditValue = Date.Today.AddDays(-2)
        UiFechaFinalRecepcion.EditValue = Date.Today

        UiListaCliente.EditValue = ""
        UiListaRecepcion.EditValue = ""
        UIListaRecepcionDetalle.EditValue = ""
        UiListaEstados.EditValue = "ACTIVO"

        DataTableDet = New DataTable("CertificateDepostiDetail")

        DataTableDet.Columns.Add("CERTIFICATE_DEPOSIT_ID_DETAIL")
        DataTableDet.Columns.Add("CERTIFICATE_DEPOSIT_ID_HEADER")
        DataTableDet.Columns.Add("DOC_ID")
        DataTableDet.Columns.Add("MATERIAL_CODE")
        DataTableDet.Columns.Add("SKU_DESCRIPTION")
        DataTableDet.Columns.Add("LOCATIONS")
        DataTableDet.Columns.Add("BULTOS")
        DataTableDet.Columns.Add("QTY")
        DataTableDet.Columns.Add("CUSTOMS_AMOUNT")

    End Sub

    Private Sub AgregarDetalle()
        Try
            For Each rowHandle As Integer In UIListaRecepcionDetalle.Properties.View.GetSelectedRows()
                Dim estado As String = ""
                estado = UIListaRecepcionDetalle.Properties.View.GetRowCellValue(rowHandle, "STATUS")
                If estado.Equals("ASOCIADO") Then
                    NotifyStatus("El registro ya esta asociado a otro certificado.", False, True)
                    Continue For
                End If

                Dim existe As Boolean = False
                For Each rowDet As DataRow In DataTableDet.Rows
                    Dim doc As String = ""
                    doc = UIListaRecepcionDetalle.Properties.View.GetRowCellValue(rowHandle, "DOC_ID")
                    Dim materialCode As String = ""
                    materialCode = UIListaRecepcionDetalle.Properties.View.GetRowCellValue(rowHandle, "MATERIAL_CODE")
                    If rowDet("DOC_ID").ToString().Equals(doc) And rowDet("MATERIAL_CODE").Equals(materialCode) Then
                        existe = True
                        Exit For
                    End If
                Next
                If Not existe Then
                    Dim row As DataRow = DataTableDet.NewRow()
                    row("DOC_ID") = UIListaRecepcionDetalle.Properties.View.GetRowCellValue(rowHandle, "DOC_ID")
                    row("MATERIAL_CODE") = UIListaRecepcionDetalle.Properties.View.GetRowCellValue(rowHandle, "MATERIAL_CODE")
                    row("SKU_DESCRIPTION") = UIListaRecepcionDetalle.Properties.View.GetRowCellValue(rowHandle, "SKU_DESCRIPTION")
                    row("LOCATIONS") = UIListaRecepcionDetalle.Properties.View.GetRowCellValue(rowHandle, "LOCATIONS")
                    row("BULTOS") = UIListaRecepcionDetalle.Properties.View.GetRowCellValue(rowHandle, "BULTOS")
                    row("QTY") = UIListaRecepcionDetalle.Properties.View.GetRowCellValue(rowHandle, "QTY")
                    row("CUSTOMS_AMOUNT") = UIListaRecepcionDetalle.Properties.View.GetRowCellValue(rowHandle, "CUSTOMS_AMOUNT")
                    DataTableDet.Rows.Add(row)
                End If

            Next rowHandle

            UiVistaCertificadoDetalle.DataSource = DataTableDet
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub EliminarDetCertificado()
        Try
            If GridView4.SelectedRowsCount >= 1 Then
                For i = 0 To GridView4.RowCount - 1
                    If GridView4.IsRowSelected(i) Then
                        Dim xdatarow As DataRow = GridView4.GetDataRow(i)
                        DataTableDet.Rows.Remove(xdatarow)
                    End If
                Next
                UiVistaCertificadoDetalle.DataSource = DataTableDet
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub GrabarDocumento()
        Try
            If UiFechaValidoInicio.EditValue = Nothing Or UiFechaValidoFinal.EditValue = Nothing Then
                NotifyStatus("Debe ingresar las fechas", True, True)
                Return
            End If
            If Date.Parse(UiFechaValidoInicio.EditValue) > Date.Parse(UiFechaValidoFinal.EditValue) Then
                NotifyStatus("La fecha de Inicio debe ser mayor a la fecha final", True, True)
                Return
            End If

            If DataTableDet.Rows.Count > 0 Then
                Dim serverCertificate As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")
                Dim pResult As String = ""
                DataTableDet.Columns("CERTIFICATE_DEPOSIT_ID_DETAIL").ReadOnly = False
                If EsNuevo Then
                    Dim dtHeader As DataTable
                    dtHeader = serverCertificate.InsertCertificateDepositHeader("InsertCertificateDepositHeader", UiFechaValidoInicio.EditValue, UiFechaValidoFinal.EditValue, PublicLoginInfo.LoginID, "ACTIVO", UiListaCliente.EditValue, pResult, PublicLoginInfo.Environment)
                    DocCertificateId = dtHeader(0)("ID")
                Else
                    If serverCertificate.UpdateCertificateDepositHeder(DocCertificateId, UiFechaValidoInicio.EditValue, UiFechaValidoFinal.EditValue, PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment) Then
                        If pResult = "" Then
                            If serverCertificate.DeleteDetailCertificate(DocCertificateId, pResult, PublicLoginInfo.Environment) Then
                                If Not pResult = "" Then
                                    NotifyStatus(pResult, True, True)
                                    Return
                                End If
                            End If
                        Else
                            NotifyStatus(pResult, True, True)
                            Return
                        End If
                    Else
                        NotifyStatus(pResult, True, True)
                        Return
                    End If

                End If

                If pResult = "" Then
                    For Each row As DataRow In DataTableDet.Rows
                        Dim dtDetail As DataTable
                        dtDetail = serverCertificate.InsertCertificateDepositDetail("InsertCertificateDepositDetail", DocCertificateId, row("DOC_ID"), row("MATERIAL_CODE"), row("SKU_DESCRIPTION"), row("LOCATIONS"), row("BULTOS"), row("QTY"), row("CUSTOMS_AMOUNT"), pResult, PublicLoginInfo.Environment)
                        If pResult = "" Then
                            row("CERTIFICATE_DEPOSIT_ID_DETAIL") = dtDetail(0)("ID")
                            EsNuevo = False
                            LlenarVistaCertificadosEncabezdos()
                            LLenarListaRecepcionDetalle()
                        Else
                            NotifyStatus(pResult, True, True)
                            Exit For
                        End If
                    Next

                    UiVistaCertificadoDetalle.DataSource = DataTableDet
                    LlenarListaRecepcionEncabezado()

                    pResult = ""
                    If Not serverCertificate.InsertarLogCertificado(DocCertificateId, PublicLoginInfo.LoginID, "...", pResult, PublicLoginInfo.Environment) Then
                        NotifyStatus(pResult, True, True)
                    End If
                    NotifyStatus("Se grabo exitosamente.", True, False)
                Else
                    NotifyStatus(pResult, True, True)
                End If
            Else
                NotifyStatus("El certificado tiene que tener detalle", True, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub SelecionaronCertificadoEncabezados()
        Try
            If gridView5.SelectedRowsCount = 1 Then
                DesbloquearControles()
                Dim xdatarow As DataRow = gridView5.GetDataRow(gridView5.FocusedRowHandle)
                Dim docId As String = Integer.Parse(xdatarow("CERTIFICATE_DEPOSIT_ID_HEADER").ToString)
                Dim estado As String = xdatarow("STATUS").ToString
                Dim picking As String = xdatarow("PICKING").ToString

                UiFechaValidoInicio.EditValue = xdatarow("VALID_FROM")
                UiFechaValidoFinal.EditValue = xdatarow("VALID_TO")

                DocCertificateId = docId

                Dim serverCertificate As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")
                Dim pResult As String = ""
                Dim dt As DataTable
                dt = serverCertificate.GetCertificateDepositDetail("GetCertificateDepositDetail", docId, pResult, PublicLoginInfo.Environment)
                If pResult = "" Then
                    DataTableDet = dt
                    UiVistaCertificadoDetalle.DataSource = DataTableDet
                    EsNuevo = False
                    If estado.Equals("ANULAR") Or picking.Equals("SI") Then
                        BloquearControles()
                    End If
                Else
                    NotifyStatus(pResult, True, True)
                End If

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub CambiarEstadoCertificado()
        Try
            If MessageBox.Show("Confirma cambiar el estado", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If gridView5.SelectedRowsCount = 1 Then
                    Dim xdatarow As DataRow = gridView5.GetDataRow(gridView5.FocusedRowHandle)
                    Dim docId As String = Integer.Parse(xdatarow("CERTIFICATE_DEPOSIT_ID_HEADER").ToString)

                    Dim serverCertificate As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")
                    Dim pResult As String = ""
                    Dim comentario As String = IIf(String.IsNullOrEmpty(UiMemoComentarioEstado.Text), "...", UiMemoComentarioEstado.Text)

                    If serverCertificate.SetStatusCertificateDeposit(docId, UiListaEstados.EditValue, PublicLoginInfo.LoginID, comentario, pResult, PublicLoginInfo.Environment) Then
                        LlenarVistaCertificadosEncabezdos()
                        DesbloquearControles()
                        NotifyStatus("Se grabo exitosamente.", True, False)
                    Else
                        NotifyStatus(pResult, True, True)
                    End If
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LimpiarControles()
        Try

            DataTableDet = New DataTable("CertificateDepostiDetail")
            DataTableDet.Columns.Add("CERTIFICATE_DEPOSIT_ID_DETAIL")
            DataTableDet.Columns.Add("CERTIFICATE_DEPOSIT_ID_HEADER")
            DataTableDet.Columns.Add("DOC_ID")
            DataTableDet.Columns.Add("MATERIAL_CODE")
            DataTableDet.Columns.Add("SKU_DESCRIPTION")
            DataTableDet.Columns.Add("LOCATIONS")
            DataTableDet.Columns.Add("BULTOS")
            DataTableDet.Columns.Add("QTY")
            DataTableDet.Columns.Add("CUSTOMS_AMOUNT")

            EsNuevo = True
            UiFechaValidoInicio.EditValue = Nothing
            UiFechaValidoFinal.EditValue = Nothing
            UiVistaCertificadoDetalle.DataSource = DataTableDet
            LlenarListaRecepcionEncabezado()

            UIListaRecepcionDetalle.Properties.DataSource = Nothing
            UiListaRecepcion.EditValue = Nothing

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub BloquearControles()
        Try

            UiBotonAgregarCertificado.Visibility = BarItemVisibility.Never
            UiBotonBorrarDetCet.Visibility = BarItemVisibility.Never
            UiBotonBorrarDetCet.Visibility = BarItemVisibility.Never
            UiBotonGrabarCertificado.Visibility = BarItemVisibility.Never
            UiListaRecepcion.Enabled = False
            UIListaRecepcionDetalle.Enabled = False
            UiFechaValidoInicio.Enabled = False
            UiFechaValidoFinal.Enabled = False
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub DesbloquearControles()
        Try

            UiBotonAgregarCertificado.Visibility = BarItemVisibility.Always
            UiBotonBorrarDetCet.Visibility = BarItemVisibility.Always
            UiBotonBorrarDetCet.Visibility = BarItemVisibility.Always
            UiBotonGrabarCertificado.Visibility = BarItemVisibility.Always
            EsNuevo = True
            UiListaRecepcion.Enabled = True
            UIListaRecepcionDetalle.Enabled = True
            UiFechaValidoInicio.Enabled = True
            UiFechaValidoFinal.Enabled = True
            LimpiarControles()
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub ObtenerPolizaAseguradora()
        Try
            PolizaAseguradora = ""
            Dim xdataset As New DataSet
            Dim pResult As String = ""
            Dim xserv As New OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoapClient("WMS_Insurance_DocsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Docs.asmx")
            'traemos por default del webservice las polizas que su estado es 1 o dos o sea que no han sido procesadas por la sat o que no ha sido impreso el acuse
            xdataset = xserv.GetInsuranceDocsCliente(UiListaCliente.EditValue.ToString, pResult, PublicLoginInfo.Environment)



            If pResult = "OK" Then
                If xdataset.Tables(0).Rows.Count > 0 Then
                    PolizaAseguradora = xdataset.Tables(0)(0)("POLIZA_INSURANCE")
                End If
            Else
                NotifyStatus(pResult, False, True)
                Dim xSettingServ As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
                Dim dsPolizas As DataSet
                dsPolizas = xSettingServ.GetParam_ByParamKey("POLIZAS", "POLIZAS_SEGUROS", "", pResult, PublicLoginInfo.Environment)

                If dsPolizas.Tables(0).Rows.Count > 0 Then
                    PolizaAseguradora = dsPolizas.Tables(0)(0)("TEXT_VALUE")
                End If

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub MostrarPopup()
        Try
            If Not EsNuevo Then
                UiPopupReporte.Show()
                ObtenerPolizaAseguradora()
                UiEtiquetaCertificadoId.Text = DocCertificateId
                UiEtiquetaEndoso.Text = PolizaAseguradora
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub


    Private Sub LimpiarControlesPopup()
        Try
            UiEtiquetaCertificadoId.Text = ""
            UiEtiquetaEndoso.Text = ""
            UiCheckIndividual.Checked = False
            UiTextoNota.Text = ""
            UiSpinImpuesto.EditValue = Nothing
            UiEtiquetaFechaVencimiento.EditValue = Nothing
            UiFechaEmision.EditValue = Nothing
            UiTextoEndoso.Text = ""
            UiSpinSerie.Text = ""
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub GenerarReporte()
        Try
            Dim rptCertificate As New rptCertificateDeposit



            rptCertificate.DataSource = DataTableDet
            rptCertificate.DataMember = DataTableDet.TableName
            rptCertificate.RequestParameters = False

            Dim rowAlmacen As Object = UiListaAlmacenaje.GetSelectedDataRow()
            rptCertificate.Parameters("logoImg").Value = PublicLoginInfo.LOGO 
            rptCertificate.Parameters("prmTipoDesignacionIndividual").Value = IIf(UiCheckIndividual.Checked, "X", " ")
            rptCertificate.Parameters("prmNombreCliente").Value = UiListaCliente.Text
            rptCertificate.Parameters("prmNotaDetalle").Value = UiTextoNota.Text
            rptCertificate.Parameters("prmImpuesto").Value = UiSpinImpuesto.EditValue
            rptCertificate.Parameters("prmTranslado").Value = ""
            rptCertificate.Parameters("prmSeguro").Value = UiTextoEndoso.Text 'PolizaAseguradora
            rptCertificate.Parameters("prmFechaVencimiento").Value = UiEtiquetaFechaVencimiento.EditValue
            rptCertificate.Parameters("prmSerie").Value = UiSpinSerie.EditValue
            rptCertificate.Parameters("prmUsuario").Value = String.Format("{0}/{1}/{2}", PublicLoginInfo.LoginName, Date.Today, DocCertificateId)
            rptCertificate.Parameters("prmTipoDesignacionGenerica").Value = IIf(UiCheckInGenerico.Checked, "X", " ")
            rptCertificate.Parameters("prmFechaEmitida").Value = UiFechaEmision.EditValue

            rptCertificate.Parameters("sujetoAPagos").Value = IIf(UiCheckSujetoAPagos.Checked, "SI", "No")
            rptCertificate.Parameters("almacen").Value = rowAlmacen("PARAM_NAME")
            rptCertificate.Parameters("sitio").Value = rowAlmacen("SPARE1")
            rptCertificate.Parameters("domicilio").Value = rowAlmacen("SPARE2")
            
            rptCertificate.ShowPreview()
            
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LlenarListaTiposAlmacen()
        Try
            Dim ds As DataSet
            Dim pResult As String = ""
            Dim xSettingServ As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
            ds = xSettingServ.GetParam_ByParamKey("ALMACENAMIENTO", "ALMACENES", "", pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                UiListaAlmacenaje.Properties.DataSource = ds.Tables(0)
                UiListaAlmacenaje.Properties.PopulateViewColumns()
                UiListaAlmacenaje.Properties.ValueMember = "TEXT_VALUE"
                UiListaAlmacenaje.Properties.DisplayMember = "PARAM_CAPTION"

                For i = 0 To UiListaAlmacenaje.Properties.View.Columns.Count - 1
                    UiListaAlmacenaje.Properties.View.Columns(i).Visible = False
                Next

                UiListaAlmacenaje.Properties.View.Columns("PARAM_NAME").Caption = "Almacen"
                UiListaAlmacenaje.Properties.View.Columns("SPARE2").Caption = "Domicilio"
                UiListaAlmacenaje.Properties.View.Columns("SPARE1").Caption = "Sitio"

                UiListaAlmacenaje.Properties.View.Columns("TEXT_VALUE").Caption = "Codigo"

                UiListaAlmacenaje.Properties.View.Columns("PARAM_NAME").Visible = True
                UiListaAlmacenaje.Properties.View.Columns("SPARE2").Visible = True
                UiListaAlmacenaje.Properties.View.Columns("SPARE1").Visible = True
                UiListaAlmacenaje.Properties.View.Columns("TEXT_VALUE").Visible = True
                UiListaAlmacenaje.Properties.View.BestFitColumns()
            Else
                UiListaAlmacenaje.Properties.DataSource = Nothing
                NotifyStatus(pResult, True, True)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
#End Region

    Private Sub UiBotonCancelarReporte_Click(sender As Object, e As EventArgs) Handles UiBotonCancelarReporte.Click
        _UiPopupReporte.Hide()
        LimpiarControlesPopup()
    End Sub

    Private Sub UiListaAlmacenaje_Properties_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles UiListaAlmacenaje.ButtonClick
        If e.Button.Tag = "REFRESH" Then
            LlenarListaTiposAlmacen()
        End If
    End Sub

    Private Sub UiCheckInGenerico_CheckedChanged(sender As Object, e As EventArgs) Handles UiCheckInGenerico.CheckedChanged
        If UiCheckInGenerico.Checked Then
            UiCheckIndividual.Checked = False
        End If
    End Sub

    Private Sub UiCheckIndividual_CheckedChanged(sender As Object, e As EventArgs) Handles UiCheckIndividual.CheckedChanged
        If UiCheckIndividual.Checked Then
            UiCheckInGenerico.Checked = False
        End If
    End Sub
  
    Private Sub UsuarioSeleccionoListaDeEstados()
        Try
            Dim estado As String = UiListaEstados.EditValue
            If estado = "ANULAR" Then
                UiPopupEstado.Show()
            Else
                UiPopupEstado.Hide()
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UiListaEstados_EditValueChanged(sender As Object, e As EventArgs) Handles UiListaEstados.EditValueChanged
        UsuarioSeleccionoListaDeEstados()
    End Sub
End Class