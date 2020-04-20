Imports System.IO
Imports System.Data
Imports DevExpress.XtraReports.UI
Imports MobilityScm.Modelo.Entidades
Imports MobilityScm.Modelo.Tipos
Imports MobilityScm.Utilerias
Imports MobilityScm.Vertical.Entidades
Imports WMSOnePlan_Client.OnePlan3PLServices_Polizas
Imports WMSOnePlan_Client.OnePlanServices_Security

Public Class frmDocumentoIngresoGeneral
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim xct As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
    Dim xSettingServ As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
    Dim pResult As String = String.Empty

    Private Sub fn_graba_head()
        Try

            'creamos variables para todos los campos que se deben validar o convertir de alguna manera.
            Dim _status, _acuerdoComercial, _regimenAlmacen, _codigPoliza As String
            Dim _fechaLlegada, _fechaDocumento As Date
            Dim _totalValorAduana, _tipoCambio, _totalPesoBrutokg, _totalFobUsd, _totalFleteUsd As Double
            Dim _totalSeguroUsd, _totalOtrosUsd, _totalLiquidar, _totalOtros, _totalGeneral As Double
            Dim _lastUpdated As Date
            Dim _docId, _numero_lineas, _modo, _totalBultos, _tipoContenedor As Integer

            'asignacion de las variables
            If Not IsNothing(cmbAcuerdo.EditValue) Then
                _acuerdoComercial = cmbAcuerdo.EditValue

            Else
                MsgBox("Debe ingresar un acuerdo comercial", MsgBoxStyle.Information, "Error")
                cmbAcuerdo.Focus()
                Return
            End If
            _regimenAlmacen = cmbRegimen.EditValue.ToString
            If _regimenAlmacen = "[Seleccione Regimen...]" Or _regimenAlmacen = "" Then
                MsgBox("Debe ingresar un regimen", MsgBoxStyle.Information, "Error")
                cmbRegimen.Focus()
                Return
            End If

            If cmbPolizaAsegurada.EditValue = Nothing Then
                MsgBox("Debe seleccionar una poliza asegurada", MsgBoxStyle.Information, "Error")
                cmbPolizaAsegurada.Focus()
                Return
            End If

            If lookupPrioridad.EditValue = Nothing Then
                MsgBox("Debe seleccionar prioridad", MsgBoxStyle.Information, "Error")
                lookupPrioridad.Focus()
                Return
            End If

            If lookupTipoRecepcion.EditValue = Nothing Then
                MsgBox("Debe seleccionar Tipo de recepción", MsgBoxStyle.Information, "Error")
                lookupTipoRecepcion.Focus()
                Return
            End If

            If ValidateEnterTicket() Then
                If String.IsNullOrEmpty(txtTicketNumber.Text) Then
                    MsgBox("Debe ingresar el No. ticket", MsgBoxStyle.Information, "Error")
                    Return
                End If

                If (Not GetTicketById()) Then Return
            End If

            If txtStatus.Text.Length <= 0 Then
                _status = "Created"
            Else
                _status = txtStatus.Text
            End If

            DateTime.TryParse(dtDocumento.EditValue.ToString, _fechaDocumento)
            DateTime.TryParse(dtDocumento.EditValue.ToString, _fechaLlegada)


            'seteamos todos los valores numericos
            Double.TryParse(txtDocid.Text, _docId)

            _lastUpdated = Date.Now()

            If cmbClientes.Text.Length <= 0 Then
                MsgBox("Error: Debe asignar un cliente al documento", MsgBoxStyle.Critical, "Error")
                Return
            End If

            If cmbBodegueros.Text.Length <= 0 Then
                MsgBox("Error: Debe asignar un operador al documento", MsgBoxStyle.Critical, "Error")
                Return
            End If


            If txtCodigoPoliza.Text.Length > 0 Then
                _codigPoliza = txtCodigoPoliza.Text
            Else
                _codigPoliza = "0"
            End If


            'grabamos el encabezado
            pResult = String.Empty
            Dim crearTarea As Boolean = xserv.set_Poliza_Header(txtNumeroOrden.Text, "", "", "", "", "", "", "",
                                    "", "", _modo, _fechaLlegada, _tipoCambio,
                                    _totalValorAduana, _numero_lineas, _totalBultos, _totalPesoBrutokg, _totalFobUsd, _totalFleteUsd,
                                    _totalSeguroUsd, _totalOtrosUsd, "", "", "", "", "", "", "", "", "", "", "", "", _tipoContenedor, "",
                                    "", "", _totalLiquidar, _totalOtros, _totalGeneral, _codigPoliza, PublicLoginInfo.LoginID, _lastUpdated,
                                    _status, cmbClientes.EditValue, _regimenAlmacen, _fechaDocumento, _acuerdoComercial, "INGRESO", PublicLoginInfo.Environment, pResult, _docId, cmbPolizaAsegurada.EditValue, cmbBodegueros.EditValue.ToString(), "NO", IIf(String.IsNullOrEmpty(txtTicketNumber.Text), Nothing, txtTicketNumber.Text))

            If crearTarea Then
                dim listaDeOperadores = new List(Of String) 

                If txtCodigoPoliza.Text.Length <= 0 Then
                    _codigPoliza = _docId
                End If

                Dim table As DataTable

                If pResult = "inserted" Then
                    table = xserv.InsertarTareaDeRecepcion(lookupTipoRecepcion.EditValue, PublicLoginInfo.LoginID, cmbBodegueros.EditValue.ToString(),
                                                           "Tarea de Recepcion General", _regimenAlmacen, cmbClientes.EditValue, cmbClientes.Text,
                                                          _docId, PublicLoginInfo.Environment, pResult, _codigPoliza, IIf(UiSwitchErp.Checked, 1, 0), lookupPrioridad.EditValue, lookupTipoRecepcion.EditValue)
                    If table Is Nothing Then
                        MsgBox(pResult, MsgBoxStyle.Critical, "Error")
                    Else
                        listaDeOperadores.Add(cmbBodegueros.EditValue.ToString())
                        EnviarTareasAApi(listaDeOperadores)
                        UiTextoNumeroRecepcion.EditValue = table.Rows(0)("DbData")
                        NotifyStatus("Proceso exitoso, número de tarea: " + table.Rows(0)("DbData").ToString(), True, false)
                    End If
                Else
                    If MessageBox.Show("Usted esta creando una nueva tarea de ingreso a un documento ya existente. ¿Desea continuar con esta acción?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
                        table = xserv.InsertarTareaDeRecepcion(lookupTipoRecepcion.EditValue, PublicLoginInfo.LoginID, cmbBodegueros.EditValue.ToString(), "Tarea de Recepcion General",
                                                              _regimenAlmacen, cmbClientes.EditValue, cmbClientes.Text, _docId,
                                                              PublicLoginInfo.Environment, pResult, _codigPoliza, IIf(UiSwitchErp.Checked, 1, 0), lookupPrioridad.EditValue, lookupTipoRecepcion.EditValue)
                        If table Is Nothing Then
                            MsgBox(pResult, MsgBoxStyle.Critical, "Error")
                        Else
                            listaDeOperadores.Add(cmbBodegueros.EditValue.ToString())
                            EnviarTareasAApi(listaDeOperadores)
                            UiTextoNumeroRecepcion.EditValue = table.Rows(0)("DbData")
                            NotifyStatus("Proceso exitoso, número de tarea: " + table.Rows(0)("DbData").ToString(), True, false)
                        End If
                    End If
                End If
                txtDocid.Text = _docId
            Else
                NotifyStatus(pResult, True, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        Finally
            pResult = ""
        End Try
    End Sub

    Private Sub btnSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSave.ItemClick
        Try
            fn_graba_head()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub fn_llena_combos()

        Try
            'llenamos el combo de los regimenes de almacen
            Dim dsRegimenAlmacen As New DataSet
            dsRegimenAlmacen = xSettingServ.GetParam_ByParamKey("WMS3PL", "WAREHOUSE_REGIMEN", "", pResult, PublicLoginInfo.Environment)
            cmbRegimen.Properties.DataSource = dsRegimenAlmacen.Tables(0)
            cmbRegimen.Properties.PopulateViewColumns()
            cmbRegimen.Properties.ValueMember = "PARAM_NAME"
            cmbRegimen.Properties.DisplayMember = "PARAM_CAPTION"

            For i = 0 To cmbRegimen.Properties.View.Columns.Count - 1
                cmbRegimen.Properties.View.Columns(i).Visible = False
            Next
            cmbRegimen.Properties.View.Columns("PARAM_NAME").Caption = $"Régimen Almacén"
            cmbRegimen.Properties.View.Columns("PARAM_CAPTION").Caption = $"Descripción Régimen Almacén"
            cmbRegimen.Properties.View.Columns("PARAM_NAME").Visible = True
            cmbRegimen.Properties.View.Columns("PARAM_CAPTION").Visible = True
            cmbRegimen.Properties.View.BestFitColumns()

            'llenamos el combo de tipos de recepcion
            Dim dsTipoRecepcion As New DataSet
            dsTipoRecepcion = xSettingServ.GetParam_ByParamKey("SISTEMA", "TIPO_RECEPCION_RFC", "", pResult, PublicLoginInfo.Environment)
            lookupTipoRecepcion.Properties.DataSource = dsTipoRecepcion.Tables(0)
            lookupTipoRecepcion.Properties.PopulateViewColumns()
            lookupTipoRecepcion.Properties.ValueMember = "PARAM_NAME"
            lookupTipoRecepcion.Properties.DisplayMember = "PARAM_CAPTION"
            For i = 0 To lookupTipoRecepcion.Properties.View.Columns.Count - 1
                lookupTipoRecepcion.Properties.View.Columns(i).Visible = False
            Next

            lookupTipoRecepcion.Properties.View.Columns("PARAM_NAME").Caption = $"Tipo Recepción"
            lookupTipoRecepcion.Properties.View.Columns("PARAM_CAPTION").Caption = $"Descripción Tipo Recepción"
            lookupTipoRecepcion.Properties.View.Columns("PARAM_NAME").Visible = True
            lookupTipoRecepcion.Properties.View.Columns("PARAM_CAPTION").Visible = True
            lookupTipoRecepcion.Properties.View.BestFitColumns()
            lookupTipoRecepcion.EditValue = Nothing

            'llenamos el combo de prioridad
            Dim dsPrioridad As New DataSet
            dsPrioridad = xSettingServ.GetParam_ByParamKey("SISTEMA", "PRIORITY", "", pResult, PublicLoginInfo.Environment)
            lookupPrioridad.Properties.DataSource = dsPrioridad.Tables(0)
            lookupPrioridad.Properties.PopulateViewColumns()
            lookupPrioridad.Properties.ValueMember = "NUMERIC_VALUE"
            lookupPrioridad.Properties.DisplayMember = "PARAM_CAPTION"

            For i = 0 To lookupPrioridad.Properties.View.Columns.Count - 1
                lookupPrioridad.Properties.View.Columns(i).Visible = False
            Next

            lookupPrioridad.Properties.View.Columns("NUMERIC_VALUE").Caption = $"Prioridad"
            lookupPrioridad.Properties.View.Columns("PARAM_CAPTION").Caption = $"Descripción Prioridad"
            lookupPrioridad.Properties.View.Columns("NUMERIC_VALUE").Visible = True
            lookupPrioridad.Properties.View.Columns("PARAM_CAPTION").Visible = True
            lookupPrioridad.Properties.View.BestFitColumns()
            lookupPrioridad.EditValue = 1

            'llenamos el combo de los clientes
            Dim dsClientes As New DataSet
            dsClientes = xClientsServ.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)
            If Not IsNothing(dsClientes) Then
                cmbClientes.Properties.DataSource = dsClientes.Tables(0)
                cmbClientes.Properties.PopulateViewColumns()
                cmbClientes.Properties.ValueMember = "CLIENT_CODE"
                cmbClientes.Properties.DisplayMember = "CLIENT_NAME"

                UiGridLookUpClientesComprobante.Properties.DataSource = dsClientes.Tables(0)
                UiGridLookUpClientesComprobante.Properties.PopulateViewColumns()
                UiGridLookUpClientesComprobante.Properties.ValueMember = "CLIENT_CODE"
                UiGridLookUpClientesComprobante.Properties.DisplayMember = "CLIENT_NAME"

                For i = 0 To cmbClientes.Properties.View.Columns.Count - 1
                    cmbClientes.Properties.View.Columns(i).Visible = False
                    UiGridLookUpClientesComprobante.Properties.View.Columns(i).Visible = False
                Next

                cmbClientes.Properties.View.Columns("CLIENT_NAME").Caption = $"Nombre"
                cmbClientes.Properties.View.Columns("CLIENT_CODE").Caption = $"Código"
                cmbClientes.Properties.View.Columns("CLIENT_NAME").Visible = True
                cmbClientes.Properties.View.Columns("CLIENT_CODE").Visible = True
                cmbClientes.Properties.View.BestFitColumns()

                UiGridLookUpClientesComprobante.Properties.View.Columns("CLIENT_NAME").Caption = $"Nombre"
                UiGridLookUpClientesComprobante.Properties.View.Columns("CLIENT_CODE").Caption = $"Código"
                UiGridLookUpClientesComprobante.Properties.View.Columns("CLIENT_NAME").Visible = True
                UiGridLookUpClientesComprobante.Properties.View.Columns("CLIENT_CODE").Visible = True
                UiGridLookUpClientesComprobante.Properties.View.BestFitColumns()
            End If

            'cmbClientes.EditValue = "1"
            cmbRegimen.EditValue = "GENERAL"
            dtDocumento.EditValue = FormatDateTime(Now, DateFormat.GeneralDate)
            LlenarComboOperador()
        Catch ex As Exception
            MsgBox("Error al llenar combos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub frmDocumentoIngresoGeneral_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dim strPath As String
            gLastScreenShowed = Me.Name
            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoGeneralLayout" & PublicLoginInfo.LoginID & ".xml"
            LayoutControl1.SaveLayoutToXml(strPath)
        Catch ex As Exception
            MsgBox("Error al Cerrar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmDocumentoIngresoGeneral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strPath As String
        Try

            'Verificamos si se muestra el campo de ticket
            If ValidateEnterTicket() Then
                layoutTicket.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                layoutTicket.ContentVisible = True
            Else
                layoutTicket.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                layoutTicket.ContentVisible = False
            End If

            'verificamos el layout de la forma
            'strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoGeneralLayout" & PublicLoginInfo.LoginID & ".xml"
            'If File.Exists(strPath) Then
            '    LayoutControl1.RestoreLayoutFromXml(strPath)
            'End If

            fn_llena_combos()

        Catch ex As Exception
            MsgBox("Error al Cargar la Forma : " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub fn_limpia_datos()
        Try
            cmbClientes.EditValue = Nothing
            cmbRegimen.EditValue = Nothing
            txtScanPoliza.EditValue = String.Empty
            txtCodigoPoliza.Text = String.Empty
            txtDocid.Text = String.Empty
            txtNumeroOrden.Text = String.Empty
            txtStatus.Text = String.Empty
            cmbAcuerdo.EditValue = Nothing
            txtTicketNumber.Text = String.Empty
            cmbBodegueros.EditValue = Nothing
            cmbPolizaAsegurada.EditValue = Nothing

            cmbRegimen.EditValue = "GENERAL"
            dtDocumento.EditValue = Date.Now()
            lookupPrioridad.EditValue = 1
            lookupTipoRecepcion.EditValue = Nothing
            txtCodigoPoliza.Enabled = True
            txtNumeroOrden.Enabled = True
            dtDocumento.Enabled = True
            cmbClientes.Enabled = True
            cmbAcuerdo.Enabled = True
            cmbPolizaAsegurada.Enabled = True
            cmbBodegueros.Enabled = True
            lookupPrioridad.Enabled = True
            txtTicketNumber.Enabled = True

            UiTextoNumeroRecepcion.EditValue = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClean_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClean.ItemClick
        fn_limpia_datos()
    End Sub

    Private Sub btnEscanear_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEscanear.ItemClick
        Try
            Dim dblDoc As Double

            If txtScanPoliza.EditValue.ToString.Length > 0 Then
                If Double.TryParse(txtScanPoliza.EditValue, dblDoc) Then
                    fn_llena_doc(dblDoc)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbClientes_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClientes.EditValueChanged
        Try
            'cmbAcuerdo.Properties.DataSource = Nothing
            Dim dsTerms As New DataSet
            Dim dsCT As New DataSet
            If Not IsNothing(cmbClientes.EditValue) Then
                UiGridLookUpClientesComprobante.EditValue = cmbClientes.EditValue
                If cmbClientes.EditValue.ToString.Length > 0 Then
                    dsCT = xct.GetClient_CommercialAggrements(cmbClientes.EditValue.ToString, pResult, PublicLoginInfo.Environment)
                    If pResult = "OK" Then
                        If dsCT.Tables(0).Rows.Count > 0 Then
                            'llenamos el combo de los acuerdos comerciales
                            cmbAcuerdo.Properties.DataSource = dsCT.Tables(0)
                            cmbAcuerdo.Properties.PopulateViewColumns()
                            cmbAcuerdo.Properties.ValueMember = "ACUERDO_COMERCIAL"
                            cmbAcuerdo.Properties.DisplayMember = "DESCRIPCION"

                            cmbAcuerdo.Properties.View.Columns("CLIENT_CODE").Visible = False
                            cmbAcuerdo.Properties.View.BestFitColumns()

                            'seteamos el acuerdo por default
                            dsTerms = xserv.get_cust_term_of_trade(cmbClientes.EditValue, PublicLoginInfo.Environment, pResult)
                            If pResult = "OK" Then
                                If dsTerms.Tables(0).Rows.Count > 0 Then
                                    If dsTerms.Tables(0).Rows(0)("CLIENT_CA").ToString.Length > 0 Then
                                        cmbAcuerdo.EditValue = dsTerms.Tables(0).Rows(0)("CLIENT_CA").ToString

                                    End If
                                End If
                                pResult = String.Empty
                            Else
                                NotifyStatus("Error: " & pResult, False, True)
                                'MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                                pResult = String.Empty
                            End If
                        Else
                            MsgBox("El cliente no posee acuerdos comerciales")
                        End If
                    Else
                        Dim tb As New DataTable
                        tb.Columns.Add("ACUERDO_COMERCIAL")
                        tb.Columns.Add("DESCRIPCION")
                        tb.Columns.Add("CLIENT_CODE")
                        cmbAcuerdo.Text = ""
                        cmbAcuerdo.Properties.DataSource = tb
                        cmbAcuerdo.Properties.PopulateViewColumns()
                        cmbAcuerdo.Properties.ValueMember = "ACUERDO_COMERCIAL"
                        cmbAcuerdo.Properties.DisplayMember = "DESCRIPCION"

                        cmbAcuerdo.Properties.View.Columns("CLIENT_CODE").Visible = False
                        cmbAcuerdo.Properties.View.BestFitColumns()
                        NotifyStatus(pResult, False, True)
                        'MsgBox(pResult)
                    End If
                    LlenarCmbPolizasSeguro()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub fn_llena_doc(ByVal dblDoc_id As Double)
        Dim dsData As New DataSet
        pResult = String.Empty
        dsData = xserv.get_Poliza_Header(" Where WAREHOUSE_REGIMEN = 'GENERAL' AND TIPO = 'INGRESO' AND DOC_ID = " + dblDoc_id.ToString(), PublicLoginInfo.Environment, pResult)
        If pResult = "OK" Then
            If Not IsNothing(dsData) Then
                If dsData.Tables(0).Rows.Count = 1 Then
                    txtDocid.Text = dsData.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("DOC_ID").ToString()
                    txtNumeroOrden.Text = dsData.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("NUMERO_ORDEN").ToString
                    dtDocumento.EditValue = dsData.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("FECHA_DOCUMENTO").ToString
                    cmbRegimen.EditValue = dsData.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("WAREHOUSE_REGIMEN").ToString
                    txtStatus.Text = dsData.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("STATUS").ToString
                    txtCodigoPoliza.Text = dsData.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("CODIGO_POLIZA").ToString
                    cmbClientes.EditValue = dsData.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("CLIENT_CODE").ToString
                    UiGridLookUpClientesComprobante.EditValue = dsData.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("CLIENT_CODE").ToString
                    cmbAcuerdo.EditValue = dsData.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("ACUERDO_COMERCIAL").ToString
                    cmbPolizaAsegurada.EditValue = dsData.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("POLIZA_ASEGURADA").ToString
                    cmbBodegueros.EditValue = dsData.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("POLIZA_ASSIGNEDTO").ToString
                    UiFechaInicioComprobante.EditValue = dsData.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("LAST_UPDATED").ToString
                    UiFechaFinalComprobante.EditValue = dsData.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("LAST_UPDATED").ToString
                    txtTicketNumber.Text = dsData.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TICKET_NUMBER").ToString

                    LlenarListaDocumentosIngresoComprobante()
                    UiListaDocumentosIngresoComprobante.EditValue = dsData.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("CODIGO_POLIZA").ToString

                    txtCodigoPoliza.Enabled = False
                    txtNumeroOrden.Enabled = False
                    dtDocumento.Enabled = False
                    cmbClientes.Enabled = False
                    cmbAcuerdo.Enabled = False
                    cmbPolizaAsegurada.Enabled = False
                    cmbBodegueros.Enabled = False
                    lookupPrioridad.Enabled = False
                    txtTicketNumber.Enabled = False

                End If
            End If
        Else
            MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
            Return
        End If
    End Sub

    Private Sub btnPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrint.ItemClick
        Dim Xrpt As New XtraReport_PolizaHeaderDetail
        Try


            If txtDocid.Text.Length >= 1 Then
                Xrpt.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                Xrpt.DataSource = fn_create_report_table().Tables(0)
                Xrpt.DataMember = "OP_WMS_VIEW_INVENTORY_X_DOCS"
                Xrpt.FillDataSource()
                ' xrow = GridView1.GetFocusedDataRow
                'Xrpt.FilterString = "NUMERO_ORDEN = '" + xrow("NUMERO_ORDEN") + "'"
                'Xrpt.FillDataSource()
                Xrpt.ShowPreview()

            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try

    End Sub
    Private Function fn_create_report_table() As DataSet
        Dim dsT As New DataSet
        dsT = Nothing
        Try

            Dim drRow As DataRow
            pResult = String.Empty

            dsT = xserv.get_inventory_bydocs(String.Format(" Where VID.DOC_ID = {0}", txtDocid.Text), PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                If dsT.Tables(0).Rows.Count > 0 Then
                    'drRow = dsT.Tables(0).NewRow
                    'drRow.Item("NUMERO_ORDEN") = txtDocid.Text
                    'drRow.Item("WAREHOUSE_REGIMEN") = "REGIMEN"
                    'drRow.Item("CODIGO_POLIZA") = IIf(txtCodigoPoliza.Text.Length > 0, txtCodigoPoliza.Text, txtDocid.Text)
                    'dsT.Tables(0).Rows.Add(drRow)
                Else
                    NotifyStatus("No se encontraron detalles.", True, True)
                End If
            Else
                MsgBox(pResult)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return dsT
    End Function

    Private Sub LlenarComboOperador()
        Try
            Dim xSecurity As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_Security.asmx")
            Dim dsUsuarios As New DataTable
            dsUsuarios = xct.GetOperatorAssignedToDistributionCenterByUser(PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                If Not IsNothing(dsUsuarios) Then
                    cmbBodegueros.Properties.DataSource = dsUsuarios
                    cmbBodegueros.Properties.PopulateViewColumns()
                    cmbBodegueros.Properties.ValueMember = "LOGIN_ID"
                    cmbBodegueros.Properties.DisplayMember = "LOGIN_NAME"

                    For i = 0 To cmbBodegueros.Properties.View.Columns.Count - 1
                        cmbBodegueros.Properties.View.Columns(i).Visible = False
                    Next
                    cmbBodegueros.Properties.View.Columns("LOGIN_NAME").Caption = $"Nombre"
                    cmbBodegueros.Properties.View.Columns("LOGIN_ID").Caption = $"Usuario"
                    cmbBodegueros.Properties.View.Columns("LOGIN_NAME").Visible = True
                    cmbBodegueros.Properties.View.Columns("LOGIN_ID").Visible = True
                End If
            Else
                MsgBox(pResult)
            End If

            cmbBodegueros.EditValue = "1"
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LlenarCmbPolizasSeguro()
        Try
            Dim xdataset As New DataSet
            Dim pResult As String = ""
            Dim xserv As New OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoapClient("WMS_Insurance_DocsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Docs.asmx")
            'traemos por default del webservice las polizas que su estado es 1 o dos o sea que no han sido procesadas por la sat o que no ha sido impreso el acuse
            xdataset = xserv.GetInsuranceDocsCliente(cmbClientes.EditValue.ToString, pResult, PublicLoginInfo.Environment)

            cmbPolizaAsegurada.Properties.View.Columns.Clear()

            If pResult = "OK" Then

                cmbPolizaAsegurada.Properties.DataSource = xdataset.Tables(0)
                cmbPolizaAsegurada.Properties.PopulateViewColumns()
                cmbPolizaAsegurada.Properties.ValueMember = "DOC_ID"
                cmbPolizaAsegurada.Properties.DisplayMember = "POLIZA_INSURANCE"

                For i = 0 To cmbPolizaAsegurada.Properties.View.Columns.Count - 1
                    cmbPolizaAsegurada.Properties.View.Columns(i).Visible = False
                Next
                cmbPolizaAsegurada.Properties.View.Columns("POLIZA_INSURANCE").Caption = $"Póliza"
                cmbPolizaAsegurada.Properties.View.Columns("DOC_ID").Caption = $"Código"
                cmbPolizaAsegurada.Properties.View.Columns("POLIZA_INSURANCE").Visible = True
                cmbPolizaAsegurada.Properties.View.Columns("DOC_ID").Visible = True
                cmbPolizaAsegurada.Properties.View.BestFitColumns()
            Else
                If Not pResult = "ERROR, No se encontraron registros." Then
                    NotifyStatus(pResult, False, True)
                End If

                Dim dsPolizas As DataSet
                    dsPolizas = xSettingServ.GetParam_ByParamKey("POLIZAS", "POLIZAS_SEGUROS", "", pResult, PublicLoginInfo.Environment)
                    cmbPolizaAsegurada.Properties.DataSource = dsPolizas.Tables(0)
                    cmbPolizaAsegurada.Properties.PopulateViewColumns()
                    cmbPolizaAsegurada.Properties.ValueMember = "TEXT_VALUE"
                    cmbPolizaAsegurada.Properties.DisplayMember = "PARAM_CAPTION"

                    For i = 0 To cmbPolizaAsegurada.Properties.View.Columns.Count - 1
                        cmbPolizaAsegurada.Properties.View.Columns(i).Visible = False
                    Next
                    cmbPolizaAsegurada.Properties.View.Columns("PARAM_NAME").Caption = $"Póliza"

                    cmbPolizaAsegurada.Properties.View.Columns("TEXT_VALUE").Caption = $"Código"
                    cmbPolizaAsegurada.Properties.View.Columns("PARAM_NAME").Visible = True

                    cmbPolizaAsegurada.Properties.View.Columns("TEXT_VALUE").Visible = True
                    cmbPolizaAsegurada.Properties.View.BestFitColumns()
                End If
        Catch ex As Exception
            MsgBox(pResult & ": " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub UiBarBotonComprobanteMostrar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBarBotonComprobanteMostrar.ItemClick
        If UiPopupComprobante.Visible Then
            UiPopupComprobante.Hide()
        Else
            UiPopupComprobante.Show()
            CargarInformacionComprobante()
        End If
    End Sub

    Private Sub UiBotonCerrarComprobante_Click(sender As Object, e As EventArgs) Handles UiBotonCerrarComprobante.Click
        UiPopupComprobante.Hide()
    End Sub

    Private Sub CargarInformacionComprobante()
        Try
            UiGridLookUpClientesComprobante.EditValue = cmbClientes.EditValue
            UiTextoMotorista.Text = ""
            UiTextoMarca.Text = ""
            UiTextoPlaca.Text = ""
            UiTextoColor.Text = ""
            UiMemoObservaciones.Text = ""
            UiListaEmpaqueComprobante.EditValue = Nothing
            UiListaEmpaqueComprobante.Properties.DataSource = Nothing
            LlenarListaDocumentosIngresoComprobante()
            LlenarListaTiposEmpaque()
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
    Private Sub LlenarListaDocumentosIngresoComprobante()
        Try
            If IsNothing(UiFechaInicioComprobante.EditValue) Or IsNothing(UiFechaFinalComprobante.EditValue) Then
                Return
            End If

            If Date.Parse(UiFechaInicioComprobante.EditValue) > Date.Parse(UiFechaFinalComprobante.EditValue) Then
                NotifyStatus("La fecha de inicio tiene que se mayor a la fecha final", True, True)
                Return
            End If

            Dim dt As DataTable
            Dim pResult As String = ""

            dt = xserv.GetDocIncomeByClient("DocIncomeByClient", UiGridLookUpClientesComprobante.EditValue,
                                                         DateTime.Parse(UiFechaInicioComprobante.EditValue), DateTime.Parse(UiFechaFinalComprobante.EditValue),
                                                         pResult, PublicLoginInfo.Environment)
            If pResult = "" Then
                UiListaDocumentosIngresoComprobante.Properties.DataSource = dt
                UiListaDocumentosIngresoComprobante.Properties.PopulateViewColumns()
                UiListaDocumentosIngresoComprobante.Properties.ValueMember = "DOC_ID"
                UiListaDocumentosIngresoComprobante.Properties.DisplayMember = "CODIGO_POLIZA"

                For i = 0 To UiListaDocumentosIngresoComprobante.Properties.View.Columns.Count - 1
                    UiListaDocumentosIngresoComprobante.Properties.View.Columns(i).Visible = False
                Next

                UiListaDocumentosIngresoComprobante.Properties.View.Columns("LAST_UPDATED").Caption = $"Fecha Creación"
                UiListaDocumentosIngresoComprobante.Properties.View.Columns("FECHA_LLEGADA").Caption = $"Fecha Llegada"
                UiListaDocumentosIngresoComprobante.Properties.View.Columns("NUMERO_DUA").Caption = $"Número Dua"
                UiListaDocumentosIngresoComprobante.Properties.View.Columns("NUMERO_ORDEN").Caption = $"Número Orden"
                UiListaDocumentosIngresoComprobante.Properties.View.Columns("CODIGO_POLIZA").Caption = $"Código Póliza"
                UiListaDocumentosIngresoComprobante.Properties.View.Columns("DOC_ID").Caption = $"Código"

                UiListaDocumentosIngresoComprobante.Properties.View.Columns("LAST_UPDATED").Visible = True
                UiListaDocumentosIngresoComprobante.Properties.View.Columns("FECHA_LLEGADA").Visible = True
                UiListaDocumentosIngresoComprobante.Properties.View.Columns("NUMERO_DUA").Visible = True
                UiListaDocumentosIngresoComprobante.Properties.View.Columns("NUMERO_ORDEN").Visible = True
                UiListaDocumentosIngresoComprobante.Properties.View.Columns("CODIGO_POLIZA").Visible = True
                UiListaDocumentosIngresoComprobante.Properties.View.Columns("DOC_ID").Visible = True

                UiListaDocumentosIngresoComprobante.Properties.View.BestFitColumns()

            Else
                UiListaDocumentosIngresoComprobante.Properties.DataSource = Nothing
                NotifyStatus(pResult, True, True)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LlenarListaTiposEmpaque()
        Try
            Dim ds As DataSet
            Dim pResult As String = ""

            ds = xSettingServ.GetParam_ByParamKey("ALMACENAMIENTO", "TIPOS_EMPAQUE", "", pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                UiListaEmpaqueComprobante.Properties.DataSource = ds.Tables(0)
                UiListaEmpaqueComprobante.Properties.PopulateViewColumns()
                UiListaEmpaqueComprobante.Properties.ValueMember = "TEXT_VALUE"
                UiListaEmpaqueComprobante.Properties.DisplayMember = "PARAM_CAPTION"

                For i = 0 To UiListaEmpaqueComprobante.Properties.View.Columns.Count - 1
                    UiListaEmpaqueComprobante.Properties.View.Columns(i).Visible = False
                Next
                UiListaEmpaqueComprobante.Properties.View.Columns("PARAM_NAME").Caption = $"Descripción"
                UiListaEmpaqueComprobante.Properties.View.Columns("TEXT_VALUE").Caption = $"Código"
                UiListaEmpaqueComprobante.Properties.View.Columns("PARAM_NAME").Visible = True
                UiListaEmpaqueComprobante.Properties.View.Columns("TEXT_VALUE").Visible = True
                UiListaEmpaqueComprobante.Properties.View.BestFitColumns()

                UiListaEmpaqueComprobante.EditValue = ds.Tables(0).Rows(0)("TEXT_VALUE").ToString
            Else
                UiListaEmpaqueComprobante.Properties.DataSource = Nothing
                NotifyStatus(pResult, True, True)
            End If


        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LlenarVistaDetalleDocComprobante()
        Try
            Dim dt As DataTable
            Dim pResult As String = ""

            dt = xserv.GetDetailsDocIncomeByClient("DetailsDocIncomeByClient", UiGridLookUpClientesComprobante.EditValue,
                                            UiListaDocumentosIngresoComprobante.Text,
                                            pResult, PublicLoginInfo.Environment)
            If pResult = "" Then
                For Each col As System.Data.DataColumn In dt.Columns
                    col.ReadOnly = False
                Next
                dt.Columns("PACKING").MaxLength = 50
                UiVistasDocumentoComprobante.DataSource = dt
            Else
                UiListaEmpaqueComprobante.Properties.DataSource = Nothing
                NotifyStatus(pResult, True, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub CambiarTipoEmpaque()
        Try
            For i As Integer = 0 To UiVistaDetalleDocumentoComprobante.SelectedRowsCount() - 1
                If (UiVistaDetalleDocumentoComprobante.GetSelectedRows()(i) >= 0) Then
                    Dim Row As DataRow = CType(UiVistaDetalleDocumentoComprobante.GetDataRow(UiVistaDetalleDocumentoComprobante.GetSelectedRows()(i)), DataRow)
                    Row("PACKING") = UiListaEmpaqueComprobante.Text
                End If
            Next

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub GenerarReporte()
        Try
            'Dim reporte As New XtraReport

            'reporte.LoadLayout("rptComprobanteEntradaAldesa.repx")
            Dim reporte As New rptComprobanteEntrada
            'Dim path As String = D:\proyectos\repositorio\mobilityscm\Alsersa\SwiftAlsersa\WMSOnePlan_Client\Reports\Aldesa\rptComprobanteEntradaAldesa.repx
            reporte.DataSource = CType(UiVistasDocumentoComprobante.DataSource, DataTable)
            reporte.DataMember = CType(UiVistasDocumentoComprobante.DataSource, DataTable).TableName
            reporte.RequestParameters = False
            reporte.Parameters("logoImg").Value = PublicLoginInfo.LOGO
            reporte.Parameters("motorista").Value = UiTextoMotorista.Text
            reporte.Parameters("nombreCliente").Value = UiGridLookUpClientesComprobante.Text
            reporte.Parameters("marcaVehiculo").Value = UiTextoMarca.Text
            reporte.Parameters("placaVehiculo").Value = UiTextoPlaca.Text
            reporte.Parameters("colorVehiculo").Value = UiTextoColor.Text
            reporte.Parameters("observaciones").Value = UiMemoObservaciones.Text
            reporte.Parameters("Fecha").Value = Date.Today
            reporte.Parameters("numeroDoc").Value = UiListaDocumentosIngresoComprobante.EditValue
            'reporte.Parameters("123rd").Value = ""

            reporte.ShowPreview()

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UiBotonFiltrarDocIngresosComprobante_Click(sender As Object, e As EventArgs) Handles UiBotonFiltrarDocIngresosComprobante.Click
        LlenarListaDocumentosIngresoComprobante()
    End Sub

    Private Sub UiListaEmpaqueComprobante_Properties_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles UiListaEmpaqueComprobante.ButtonClick
        If e.Button.Tag = "REFRESH" Then
            LlenarListaTiposEmpaque()
        End If
    End Sub

    Private Sub UiListaDocumentosIngresoComprobante_Properties_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles UiListaDocumentosIngresoComprobante.ButtonClick
        If e.Button.Tag = "REFRESH" Then
            LlenarListaDocumentosIngresoComprobante()
        End If
    End Sub

    Private Sub UiListaDocumentosIngresoComprobante_EditValueChanged(sender As Object, e As EventArgs) Handles UiListaDocumentosIngresoComprobante.EditValueChanged
        If Not UiListaDocumentosIngresoComprobante.EditValue Is Nothing And Not String.IsNullOrEmpty(UiListaDocumentosIngresoComprobante.Text) Then
            LlenarVistaDetalleDocComprobante()
        End If
    End Sub

    Private Sub UiBotonCambiarEmpaque_Click(sender As Object, e As EventArgs) Handles UiBotonCambiarEmpaque.Click
        If Not UiListaEmpaqueComprobante.EditValue Is Nothing And Not String.IsNullOrEmpty(UiListaEmpaqueComprobante.Text) Then
            CambiarTipoEmpaque()
        End If
    End Sub

    Private Sub UiBotonGenerarReporteComprobante_Click(sender As Object, e As EventArgs) Handles UiBotonGenerarReporteComprobante.Click
        If UiVistaDetalleDocumentoComprobante.RowCount <> 0 Then
            GenerarReporte()
        End If
    End Sub

    Private Sub UiGridLookUpClientesComprobante_EditValueChanged(sender As Object, e As EventArgs) Handles UiGridLookUpClientesComprobante.EditValueChanged
        cmbClientes.EditValue = UiGridLookUpClientesComprobante.EditValue
    End Sub

    Private Sub EnviarTareasAApi(listaDeOperadores As  List(Of String) )
        Try
            If SeEnvianTareasAlApi() Then
                If listaDeOperadores.Count <= 0 Then Return
                Dim datosDeEnvioDeTareas = New ListaOperadorParaActualizacionDeTarea With {.loginId = $"{PublicLoginInfo.LoginID}@{PublicLoginInfo.Domain}", .password = PublicLoginInfo.Password, .operators = listaDeOperadores, .dbUser = PublicLoginInfo.DbUser, .dbPassword = PublicLoginInfo.DbPassword, .serverIp = PublicLoginInfo.ServerIp}
                Dim op = Rest.ExecutePost(Of Operacion)($"{PublicLoginInfo.Api3PlAddress}{RutasApi.Tareas.EnviarTareas}", datosDeEnvioDeTareas)
                If op.Resultado = ResultadoOperacionTipo.[Error] Then
                    NotifyStatus($"Error al enviar las tareas hacia el dispositivo móvil debido a: {op.Mensaje}", True, True)
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Shared Function SeEnvianTareasAlApi() As Boolean
        Dim securityService = New WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Security.asmx")
        Dim clientMobileIsAndroid = securityService.GetParameterValue("", PublicLoginInfo.Environment, Enums.GetStringValue(GrupoParametro.Sistema), Enums.GetStringValue(IdParametro.TipoDeClienteMovilDe3Pl))
        If String.IsNullOrEmpty(clientMobileIsAndroid) Then
            Return False
        Else
            Return (Convert.ToInt16(clientMobileIsAndroid)) = 1
        End If
    End Function

    Private Shared Function ValidateEnterTicket() As Boolean
        Dim securityService = New WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Security.asmx")
        Dim ingresaTicket = securityService.GetParameterValue("", PublicLoginInfo.Environment, Enums.GetStringValue(GrupoParametro.ValidarIngresoTicket), Enums.GetStringValue(IdParametro.DebeIngresarTicket))
        If String.IsNullOrEmpty(ingresaTicket) Then
            Return False
        Else
            Return (Convert.ToInt16(ingresaTicket)) = 1
        End If
    End Function

    Public Function GetTicketById() As Boolean
        Try
            Dim dtTicket = xserv.GetTicketById(Convert.ToInt64(txtTicketNumber.Text), pResult, PublicLoginInfo.Environment)
            Dim idPolice As Decimal
            Dim dateTicket As DateTime
            Dim statusTicket As String

            If (dtTicket.Rows.Count <= 0) Then
                NotifyStatus("No se encontró el ticket.", True, True)
                txtTicketNumber.Text = String.Empty
                Return False
            End If


            For Each dtRow As DataRow In dtTicket.Rows

                idPolice = Convert.ToInt64(dtRow("POLIZA_DOC_ID"))
                dateTicket = Convert.ToDateTime(dtRow("CREATED_DATE"))
                statusTicket = dtRow("STATUS").ToString()

            Next

            If idPolice > 0 OrElse statusTicket <> "PRINTED" Then
                NotifyStatus("No se puede asignar el ticket porque se encuentra asignado.", True, True)
                txtTicketNumber.Text = String.Empty
                Return False
            End If

            dtDocumento.EditValue = dateTicket
            NotifyStatus("Fecha de llegada: " + dateTicket.ToString(), False, True)
            Return True

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try


    End Function

End Class