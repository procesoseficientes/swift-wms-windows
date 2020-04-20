Imports System.IO
Imports System.Data
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraRichEdit.Import.OpenXml

Public Class frmPaseSalidaCertificado
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
    Dim xInfoTrans As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
    Dim xSettingServ As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
    Dim pResult As String
    Dim iPass As Integer
    Dim dsPolPass As New DataSet

    Private Sub frmPaseSalida_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            fn_llena_combos()

        Catch ex As Exception
            MsgBox("error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmPaseSalida_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim strPath As String
        Try
            gLastScreenShowed = Me.Name

            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmPasesalidaLayout" & PublicLoginInfo.LoginID & ".xml"

            LayoutControl1.SaveLayoutToXml(strPath)
            strPath = String.Empty


            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmPasesalidaGridDespachos" & PublicLoginInfo.LoginID & ".xml"

            GridViewDespachos.SaveLayoutToXml(strPath)
            strPath = String.Empty


        Catch ex As Exception
            MsgBox("Error al Cerrar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub

    Private Sub frmPaseSalida_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strPath As String
        Try
            LayoutControl1.SetDefaultLayout()

            gLastScreenShowed = Me.Name

            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmPasesalidaLayout" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                LayoutControl1.RestoreLayoutFromXml(strPath)
                strPath = String.Empty
            End If

            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmPasesalidaGridDespachos" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                GridViewDespachos.RestoreLayoutFromXml(strPath)
                strPath = String.Empty
            End If
            LlenarListaTiposEmpaque()
            LlenarListaTiposAlmacen()
        Catch ex As Exception
            MsgBox("Error al abrir la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub

    Private Sub fn_llena_combos()
        Try
            Dim i As Integer
            'llenamos el combo de los clientes
            Dim dsClientes As New DataSet
            dsClientes = xClientsServ.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                If Not IsNothing(dsClientes) Then
                    cmbClientes.Properties.DataSource = dsClientes.Tables(0)
                    cmbClientes.Properties.PopulateViewColumns()
                    cmbClientes.Properties.ValueMember = "CLIENT_CODE"
                    cmbClientes.Properties.DisplayMember = "CLIENT_NAME"

                    For i = 0 To cmbClientes.Properties.View.Columns.Count - 1
                        cmbClientes.Properties.View.Columns(i).Visible = False
                    Next

                    cmbClientes.Properties.View.Columns("CLIENT_CODE").Caption = "CODIGO"
                    cmbClientes.Properties.View.Columns("CLIENT_NAME").Caption = "NOMBRE"
                    cmbClientes.Properties.View.Columns("CLIENT_CODE").Visible = True
                    cmbClientes.Properties.View.Columns("CLIENT_NAME").Visible = True
                    cmbClientes.Properties.View.BestFitColumns()

                End If
            Else
                MsgBox(pResult)
            End If
            pResult = String.Empty
            Dim dsUsuarios As New DataSet
            dsUsuarios = xserv.get_all_active_logins(PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                If Not IsNothing(dsUsuarios) Then
                    'llenamos el combo de autorizado porcmbAutoriza.Properties.DataSource = dsUsuarios.Tables(0)
                    cmbAutoriza.Properties.DataSource = dsUsuarios.Tables(0)
                    cmbAutoriza.Properties.PopulateViewColumns()
                    cmbAutoriza.Properties.ValueMember = "LOGIN_ID"
                    cmbAutoriza.Properties.DisplayMember = "LOGIN_NAME"

                    For i = 0 To cmbAutoriza.Properties.View.Columns.Count - 1
                        cmbAutoriza.Properties.View.Columns(i).Visible = False
                    Next
                    cmbAutoriza.Properties.View.Columns("LOGIN_ID").Caption = "USUARIO"
                    cmbAutoriza.Properties.View.Columns("LOGIN_NAME").Caption = "NOMBRE"
                    cmbAutoriza.Properties.View.Columns("LOGIN_ID").Visible = True
                    cmbAutoriza.Properties.View.Columns("LOGIN_NAME").Visible = True

                    'llenamos el combo de entregado
                    cmbEntregado.Properties.DataSource = dsUsuarios.Tables(0)
                    cmbEntregado.Properties.PopulateViewColumns()
                    cmbEntregado.Properties.ValueMember = "LOGIN_ID"
                    cmbEntregado.Properties.DisplayMember = "LOGIN_NAME"

                    For i = 0 To cmbEntregado.Properties.View.Columns.Count - 1
                        cmbEntregado.Properties.View.Columns(i).Visible = False
                    Next
                    cmbEntregado.Properties.View.Columns("LOGIN_ID").Caption = "USUARIO"
                    cmbEntregado.Properties.View.Columns("LOGIN_NAME").Caption = "NOMBRE"
                    cmbEntregado.Properties.View.Columns("LOGIN_ID").Visible = True
                    cmbEntregado.Properties.View.Columns("LOGIN_NAME").Visible = True
                End If
            Else
                MsgBox(pResult)
            End If

            pResult = String.Empty
            Dim dsPilotos As New DataSet
            dsPilotos = xserv.get_passes_params("VEHICLE_DRIVER", PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                If dsPilotos.Tables(0).Rows.Count >= 1 Then
                    For i = 0 To dsPilotos.Tables(0).Rows.Count - 1
                        cmbPILOTO.Properties.Items.Add(dsPilotos.Tables(0).Rows(i)("VEHICLE_DRIVER").ToString)
                    Next
                End If
            Else
                MsgBox(pResult)
            End If

            pResult = String.Empty
            Dim dsPlates As New DataSet
            dsPlates = xserv.get_passes_params("VEHICLE_PLATE", PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                If dsPlates.Tables(0).Rows.Count >= 1 Then
                    For i = 0 To dsPlates.Tables(0).Rows.Count - 1
                        cmbPlacas.Properties.Items.Add(dsPlates.Tables(0).Rows(i)("VEHICLE_PLATE").ToString)
                    Next
                End If
            Else
                MsgBox(pResult)
            End If

            pResult = String.Empty
            Dim dsTransportes As New DataSet
            dsTransportes = xserv.get_passes_params("CARRIER", PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                If dsTransportes.Tables(0).Rows.Count >= 1 Then
                    For i = 0 To dsTransportes.Tables(0).Rows.Count - 1
                        cmbTRANSPORTISTA.Properties.Items.Add(dsTransportes.Tables(0).Rows(i)("CARRIER").ToString)
                    Next
                End If
            Else
                MsgBox(pResult)
            End If

            pResult = String.Empty
            Dim dsTIPOT As New DataSet
            dsTIPOT = xserv.get_passes_params("VEHICLE_ID", PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                If dsTIPOT.Tables(0).Rows.Count >= 1 Then
                    For i = 0 To dsTIPOT.Tables(0).Rows.Count - 1
                        cmbTIPOTRANSPORTE.Properties.Items.Add(dsTIPOT.Tables(0).Rows(i)("VEHICLE_ID").ToString)
                    Next
                End If
            Else
                MsgBox(pResult)
            End If

            pResult = String.Empty
            Dim dsDD As New DataSet
            dsDD = xserv.get_passes_params("DRIVER_ID", PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                If dsDD.Tables(0).Rows.Count >= 1 Then
                    For i = 0 To dsDD.Tables(0).Rows.Count - 1
                        cmbLICENCIA.Properties.Items.Add(dsDD.Tables(0).Rows(i)("DRIVER_ID").ToString)
                    Next
                End If
            Else
                MsgBox(pResult)
            End If
            LLenarComboDespacho()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LLenarComboDespacho()
        Try
            'llenamos el combo de los despachos
            Dim dsDispatch As DataSet
            Dim xInfoTrans As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")

            dsDispatch = xInfoTrans.GetFinishedDispatchAudit(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                If Not IsNothing(dsDispatch) Then
                    cmbDespachos.Properties.DataSource = dsDispatch.Tables(0)
                    cmbDespachos.Properties.PopulateViewColumns()
                    cmbDespachos.Properties.ValueMember = "AUDIT_ID"
                    cmbDespachos.Properties.DisplayMember = "AUDIT_ID"

                    For i = 0 To cmbDespachos.Properties.View.Columns.Count - 1
                        cmbDespachos.Properties.View.Columns(i).Visible = False
                    Next

                    cmbDespachos.Properties.View.Columns("CODIGO_POLIZA").Caption = "POLIZA"
                    cmbDespachos.Properties.View.Columns("NUMERO_ORDEN").Caption = "NUMERO DE ORDEN"
                    cmbDespachos.Properties.View.Columns("AUDIT_ID").Caption = "AUDITORIA"
                    cmbDespachos.Properties.View.Columns("LAST_UPDATED_BY").Caption = "AUDITOR"
                    cmbDespachos.Properties.View.Columns("CODIGO_POLIZA").Visible = True
                    cmbDespachos.Properties.View.Columns("NUMERO_ORDEN").Visible = True
                    cmbDespachos.Properties.View.Columns("AUDIT_ID").Visible = True
                    cmbDespachos.Properties.View.Columns("LAST_UPDATED_BY").Visible = True
                    cmbDespachos.Properties.View.BestFitColumns()

                End If
                cmbDespachos.EditValue = Nothing
            Else
                NotifyStatus(pResult, False, True)
            End If

            'Llenamos el combo de poliza
            Dim dsPolizas As DataSet

            dsPolizas = xInfoTrans.GetPassByPolizaAvailable(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                If Not IsNothing(dsPolizas) Then
                    GridLookPoliza.Properties.DataSource = dsPolizas.Tables(0)
                    GridLookPoliza.Properties.PopulateViewColumns()
                    GridLookPoliza.Properties.ValueMember = "CODIGO_POLIZA"
                    GridLookPoliza.Properties.DisplayMember = "NUMERO_ORDEN"

                    For i = 0 To GridLookPoliza.Properties.View.Columns.Count - 1
                        GridLookPoliza.Properties.View.Columns(i).Visible = False
                    Next

                    GridLookPoliza.Properties.View.Columns("CODIGO_POLIZA").Caption = "POLIZA"
                    GridLookPoliza.Properties.View.Columns("NUMERO_ORDEN").Caption = "NUMERO DE ORDEN"
                    GridLookPoliza.Properties.View.Columns("CODIGO_POLIZA").Visible = True
                    GridLookPoliza.Properties.View.Columns("NUMERO_ORDEN").Visible = True
                    GridLookPoliza.Properties.View.BestFitColumns()

                End If
                cmbDespachos.EditValue = Nothing
            Else
                NotifyStatus(pResult, False, True)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub


    Private Sub BarLargeButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarLargeButtonItem1.ItemClick
        'Try
        '    ' PrintableComponentLink1.ShowPreview()
        '    'Dim frP As New xrptPase
        '    Dim rptPaseSalida As New rptPaseSalida
        '    'Dim frS As New xrptSalida
        '    Dim dsPases As New DataSet
        '    Dim pResult As String = String.Empty
        '    If checkPoliza.Checked Then
        '        dsPases = xserv.print_pass_by_poliza(Val(btnPassid.EditValue), "0", PublicLoginInfo.Environment, pResult)
        '    Else
        '        dsPases = xserv.print_pass(Val(btnPassid.EditValue), Val(GridViewDespachos.GetRowCellValue(0, "AUDIT_ID")), PublicLoginInfo.Environment, pResult)
        '    End If

        '    If pResult = "OK" Then
        '        frS.Parameters("logoImg").Value = PublicLoginInfo.LOGO 
        '        'frP.DataSource = dsPases
        '        'rptPaseSalida.DataMember = "SALIDA_VEHICULO"
        '        rptPaseSalida.DataSource = dsPases
        '        'frP.ShowPreview()
        '        rptPaseSalida.ShowPreview()
        '    Else
        '        MsgBox("Error al generar la impresion " & pResult)
        '    End If


        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        If UiPopupGenerarReporte.Visible Then
            UiPopupGenerarReporte.Hide()
        Else
            If GridViewPolizas.RowCount <> 0 Then
                UiPopupGenerarReporte.Show()
                'CargarInformacionComprobante()
            End If
        End If

    End Sub

    Private Sub fn_load_data()
        Try

            Dim stWhere As String
            Dim dsPass As New DataSet
            cmbDespachos.Enabled = False

            Integer.TryParse(btnPassid.EditValue, iPass)

            If iPass = 0 Then
                stWhere = String.Empty
            Else

                stWhere = " Where PASS_ID = " & iPass.ToString & " "

                dsPass = xserv.get_all_passes(stWhere, PublicLoginInfo.Environment, pResult)
                If pResult = "OK" Then
                    If dsPass.Tables(0).Rows.Count = 1 Then
                        cmbDespachos.Enabled = True
                        checkPoliza.Enabled = True
                        cmbClientes.EditValue = dsPass.Tables(0).Rows(0)("CLIENT_CODE").ToString
                        btnPassid.EditValue = Val(dsPass.Tables(0).Rows(0)("PASS_ID").ToString)
                        cmbPlacas.EditValue = dsPass.Tables(0).Rows(0)("VEHICLE_PLATE").ToString
                        cmbPILOTO.EditValue = dsPass.Tables(0).Rows(0)("VEHICLE_DRIVER").ToString
                        cmbTIPOTRANSPORTE.EditValue = dsPass.Tables(0).Rows(0)("VEHICLE_ID").ToString
                        cmbLICENCIA.EditValue = dsPass.Tables(0).Rows(0)("DRIVER_ID").ToString
                        cmbAutoriza.EditValue = dsPass.Tables(0).Rows(0)("AUTORIZED_BY")
                        cmbEntregado.EditValue = dsPass.Tables(0).Rows(0)("HANDLER")
                        cmbTRANSPORTISTA.EditValue = dsPass.Tables(0).Rows(0)("CARRIER")
                        txtObs.Text = dsPass.Tables(0).Rows(0)("TXT")
                        rgCARGA.EditValue = dsPass.Tables(0).Rows(0)("LOADUNLOAD")
                        txtCargadoCon.Text = dsPass.Tables(0).Rows(0)("LOADWITH")

                        ShowPassDetail(iPass)

                        'If Val(dsPass.Tables(0).Rows(0)("AUDIT_ID")) > 0 Then
                        '    cmbDespachos.EditValue = Val(dsPass.Tables(0).Rows(0)("AUDIT_ID"))
                        'End If
                        LlenarGrid()
                        If dsPass.Tables(0).Rows(0)("ISEMPTY").ToString = "S" Then
                            ckVacio.EditValue = "Y"
                        Else
                            ckVacio.EditValue = "N"
                        End If

                        'pResult = String.Empty

                        'If Val(dsPass.Tables(0).Rows(0)("AUDIT_ID")) > 0 Then
                        '    dsPolPass = xInfoTrans.GetAuditView(Val(dsPass.Tables(0).Rows(0)("AUDIT_ID")), "MMI_AUDIT_DISPATCH_FISCAL", pResult, PublicLoginInfo.Environment)

                        '    If pResult = "OK" Then
                        '        GridDespachos.DataSource = dsPolPass.Tables(0)
                        '    Else
                        '        MsgBox(pResult)
                        '    End If
                        'End If
                    Else
                        MsgBox("numero de pase no existe o esta mal grabado")
                    End If
                Else
                    MsgBox(pResult)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSave.ItemClick
        Try
            Dim _clientcode, _clientname, _isempty, _vplate, _vdriver, _vid, _did As String
            Dim _aby, _handler, _carrier, _txt, _loadu, _lwit As String
            Dim _audit_id As Integer = 0

            If IsNothing(cmbAutoriza.EditValue) Then
                MsgBox("Debe seleccionar quien autoriza")
                cmbAutoriza.Focus()
                Exit Sub
            End If
            If IsNothing(cmbEntregado.EditValue) Then
                MsgBox("Debe seleccionar quien entrega")
                cmbEntregado.Focus()
                Exit Sub
            End If

            If IsNothing(cmbClientes.EditValue) Then
                _clientcode = String.Empty
                _clientname = String.Empty
            Else
                _clientcode = cmbClientes.EditValue
                _clientname = cmbClientes.Properties.GetDisplayTextByKeyValue(cmbClientes.EditValue)
            End If
            If IsNothing(cmbTRANSPORTISTA.EditValue) Then
                _carrier = String.Empty
            Else
                _carrier = cmbTRANSPORTISTA.EditValue
            End If
            If IsNothing(cmbTIPOTRANSPORTE.EditValue) Then
                _vid = String.Empty
            Else
                _vid = cmbTIPOTRANSPORTE.EditValue
            End If
            If IsNothing(cmbAutoriza.EditValue) Then
                _aby = String.Empty
            Else
                _aby = cmbAutoriza.EditValue
            End If
            If IsNothing(cmbEntregado.EditValue) Then
                _handler = String.Empty
            Else
                _handler = cmbEntregado.EditValue
            End If
            If IsNothing(cmbLICENCIA.EditValue) Then
                _did = String.Empty
            Else
                _did = cmbLICENCIA.EditValue
            End If
            If IsNothing(cmbPILOTO.EditValue) Then
                _vdriver = String.Empty
            Else
                _vdriver = cmbPILOTO.EditValue
            End If
            If IsNothing(cmbPlacas.EditValue) Then
                _vplate = String.Empty
            Else
                _vplate = cmbPlacas.EditValue
            End If
            If IsNothing(txtObs.Text) Then
                _txt = String.Empty
            Else
                _txt = txtObs.Text
            End If
            If IsNothing(txtCargadoCon.Text) Then
                _lwit = String.Empty
            Else
                _lwit = txtCargadoCon.Text
            End If

            If rgCARGA.EditValue = Nothing Then
                NotifyStatus("Seleccione un tipo de carga", True, True)
                rgCARGA.Focus()
                Exit Sub
            End If
            _loadu = rgCARGA.EditValue
            If ckVacio.Checked = True Then
                _isempty = "Y"
            Else
                _isempty = "N"
            End If

            '_audit_id = Val(cmbDespachos.EditValue)

            pResult = String.Empty
            xserv.set_pass(_clientcode, _clientname, PublicLoginInfo.LoginID, _isempty, _vplate, _vdriver, _vid, _did, _aby, _handler, _carrier, _txt, _loadu, _lwit, _
                           0, PublicLoginInfo.Environment, pResult, iPass)

            If pResult = "OK" Then
                btnPassid.EditValue = iPass
                cmbDespachos.Enabled = True
                checkPoliza.Enabled = True
                NotifyStatus(" Se ha grabado el pase numero " + iPass.ToString, True, False)
            Else
                cmbDespachos.Enabled = False
                checkPoliza.Enabled = False
                NotifyStatus(pResult, True, True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cmbClientes_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClientes.EditValueChanged

    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Try
            Dim dsDummy As New DataSet
            Dim dtDummy As New DataTable
            Dim dcDummy As DataColumn
            Dim _clientcode, _clientname As String

            If IsNothing(cmbClientes.EditValue) Then
                _clientcode = String.Empty
                _clientname = String.Empty
            Else
                _clientcode = cmbClientes.EditValue
                _clientname = cmbClientes.Properties.GetDisplayTextByKeyValue(cmbClientes.EditValue)
            End If

            dtDummy.TableName = "OP_WMS3PL_PASSES"

            dcDummy = New DataColumn
            dcDummy.Caption = "PASE"
            dcDummy.ColumnName = "PASS_ID"
            dcDummy.DataType = Type.GetType("System.Int64")
            dtDummy.Columns.Add(dcDummy)

            dcDummy = New DataColumn
            dcDummy.Caption = "POLIZA"
            dcDummy.ColumnName = "CODIGO_POLIZA"
            dcDummy.DataType = Type.GetType("System.String")
            dtDummy.Columns.Add(dcDummy)

            dcDummy = New DataColumn
            dcDummy.Caption = "DOCUMENTO"
            dcDummy.ColumnName = "DOC_ID"
            dcDummy.DataType = Type.GetType("System.Int64")
            dtDummy.Columns.Add(dcDummy)

            dcDummy = New DataColumn
            dcDummy.Caption = "NUMERO ORDEN"
            dcDummy.ColumnName = "NUMERO_ORDEN"
            dcDummy.DataType = Type.GetType("System.String")
            dtDummy.Columns.Add(dcDummy)

            dcDummy = New DataColumn
            dcDummy.Caption = "DUA"
            dcDummy.ColumnName = "NUMERO_DUA"
            dcDummy.DataType = Type.GetType("System.String")
            dtDummy.Columns.Add(dcDummy)

            dcDummy = New DataColumn
            dcDummy.Caption = "NOMBRE"
            dcDummy.ColumnName = "CLIENT_NAME"
            dcDummy.DataType = Type.GetType("System.String")
            dtDummy.Columns.Add(dcDummy)

            dcDummy = New DataColumn
            dcDummy.Caption = "CLIENTE"
            dcDummy.ColumnName = "CLIENT_CODE"
            dcDummy.DataType = Type.GetType("System.String")
            dtDummy.Columns.Add(dcDummy)

            Dim drDummy As DataRow
            drDummy = dtDummy.NewRow()

            drDummy.Item("CODIGO_POLIZA") = cmbDespachos.Properties.View.GetFocusedRowCellValue("CODIGO_POLIZA")
            drDummy.Item("DOC_ID") = cmbDespachos.Properties.View.GetFocusedRowCellValue("DOC_ID")
            drDummy.Item("NUMERO_ORDEN") = cmbDespachos.Properties.View.GetFocusedRowCellValue("NUMERO_ORDEN")
            drDummy.Item("NUMERO_DUA") = cmbDespachos.Properties.View.GetFocusedRowCellValue("NUMERO_DUA")
            drDummy.Item("PASS_ID") = iPass
            drDummy.Item("CLIENT_CODE") = _clientcode
            drDummy.Item("CLIENT_NAME") = _clientname

            If Not IsNothing(dsPolPass) Then
                If dsPolPass.Tables.Count > 0 Then
                    If dsPolPass.Tables("OP_WMS3PL_PASSES").Columns.Count > 0 Then
                        Dim drPo As DataRow
                        Dim ir As Integer = 0

                        'ir = dsPolPass.Tables("OP_WMS3PL_PASSES").Rows(0)
                        drPo = dsPolPass.Tables("OP_WMS3PL_PASSES").NewRow()
                        drPo.Item("CODIGO_POLIZA") = drDummy.Item("CODIGO_POLIZA")
                        drPo.Item("DOC_ID") = drDummy.Item("DOC_ID")
                        drPo.Item("NUMERO_ORDEN") = drDummy.Item("NUMERO_ORDEN")
                        drPo.Item("NUMERO_DUA") = drDummy.Item("NUMERO_DUA")
                        drPo.Item("PASS_ID") = drDummy.Item("PASS_ID")
                        drPo.Item("CLIENT_CODE") = _clientcode
                        drPo.Item("CLIENT_NAME") = _clientname

                        dsPolPass.Tables("OP_WMS3PL_PASSES").Rows.Add(drPo)
                        GridDespachos.Refresh()
                    End If
                Else
                    dtDummy.Rows.Add(drDummy)
                    dsPolPass.Tables.Add(dtDummy)
                End If
            Else
                dsDummy.Tables.Add(dtDummy)
                dtDummy.Rows.Add(drDummy)
                dsPolPass = dsDummy
            End If
            GridDespachos.DataSource = dsPolPass.Tables(0)
            GridDespachos.Refresh()
            dsDummy.Dispose()
            dtDummy.Dispose()
            dcDummy.Dispose()
            drDummy = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnFind_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnFind.ItemClick
        Try
            If Val(btnPassid.EditValue) > 0 Then
                fn_load_data()
            Else
                MsgBox("Debe colocar el numero de pase a reimprimir")
                btnPassid.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub fn_limpia()
        Try
            xserv.delete_pass_detail(Val(btnPassid.EditValue), PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                cmbClientes.EditValue = Nothing
                btnPassid.EditValue = Nothing
                ckVacio.EditValue = Nothing
                cmbTRANSPORTISTA.EditValue = Nothing
                cmbTIPOTRANSPORTE.EditValue = Nothing
                cmbPlacas.EditValue = Nothing
                cmbPILOTO.EditValue = Nothing
                cmbLICENCIA.EditValue = Nothing
                rgCARGA.EditValue = Nothing
                txtCargadoCon.Text = ""
                txtObs.Text = ""
                cmbAutoriza.EditValue = Nothing
                cmbEntregado.EditValue = Nothing
                cmbDespachos.EditValue = Nothing
                GridDespachos.DataSource = Nothing
                GridDespachos.Refresh()
            Else
                NotifyStatus(pResult, True, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnClean_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClean.ItemClick
        fn_limpia()
    End Sub

    Sub ShowPassDetail(ByVal iPass As Integer)
        Try
            If Not iPass = 0 And Not cmbDespachos.EditValue = Nothing Then
                pResult = String.Empty
                xserv.set_pass_detail(iPass, Val(cmbDespachos.EditValue), PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)
                If pResult = "OK" Then
                    cmbDespachos.EditValue = Nothing
                    LLenarComboDespacho()
                    LlenarGrid()
                    checkPoliza.Enabled = False
                    GridLookPoliza.Enabled = False
                Else
                    NotifyStatus(pResult, True, True)
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
    Private Sub cmbDespachos_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDespachos.EditValueChanged
        ShowPassDetail(Val(btnPassid.EditValue))
    End Sub
    Private Sub btnPassid_Properties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPassid.Click
        ShowPassDetail(Val(btnPassid.EditValue))
    End Sub

    Private Sub btnPassid_ButtonPressed(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles btnPassid.ButtonPressed
        Try
            btnFind.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnPassid_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles btnPassid.EditValueChanged

    End Sub

    Private Sub GridDespachos_KeyUp(sender As Object, e As KeyEventArgs) Handles GridDespachos.KeyUp

        If e.KeyCode = Keys.Delete Then
            Dim a As String = ""
            If GridViewDespachos.SelectedRowsCount > 0 Then
                DeleteDetail()
            End If

            If GridViewPolizas.SelectedRowsCount > 0 Then
                DeleteDetailByPoliza()
            End If

        End If
    End Sub
    Private Sub DeleteDetail()
        Try
            For i = 0 To GridViewDespachos.RowCount - 1
                If GridViewDespachos.IsRowSelected(i) Then
                    Dim xdatarow As DataRow = GridViewDespachos.GetDataRow(i)
                    pResult = ""
                    If xserv.delete_pass_audits_detail(iPass, Val(xdatarow("AUDIT_ID")), PublicLoginInfo.Environment, pResult) Then
                        If Not pResult = "OK" Then
                            NotifyStatus(pResult, True, True)
                            Exit Sub
                        Else
                            LLenarComboDespacho()
                            LlenarGrid()

                            checkPoliza.Enabled = True
                            If GridViewDespachos.RowCount > 0 Then
                                checkPoliza.Enabled = False
                                GridLookPoliza.Enabled = False
                            End If

                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LlenarGrid()
        Try
            pResult = ""
            dsPolPass = xInfoTrans.GetAuditView(Val(btnPassid.EditValue), "MMI_AUDIT_DISPATCH_FISCAL_DETAIL_CERTIFICATE", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridDespachos.MainView = GridViewDespachos
                GridDespachos.DataSource = dsPolPass.Tables(0)
                GridViewDespachos.ExpandAllGroups()
                checkPoliza.Checked = False
                checkPoliza.Enabled = False
                GridLookPoliza.Enabled = False
                cmbDespachos.Enabled = True
            Else
                GridDespachos.DataSource = Nothing
            End If
            If GridViewDespachos.RowCount > 0 Then
                Return
            End If
            Dim dsDetPoliza As DataSet
            dsDetPoliza = xInfoTrans.GetPassByPolizaAssigned(Val(btnPassid.EditValue), pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each col As System.Data.DataColumn In dsDetPoliza.Tables(0).Columns
                    col.ReadOnly = False
                Next
                dsDetPoliza.Tables(0).Columns("PACKING").MaxLength = 50

                GridDespachos.MainView = GridViewPolizas
                GridDespachos.DataSource = dsDetPoliza.Tables(0)

                GridViewPolizas.ExpandAllGroups()
                checkPoliza.Checked = True
                checkPoliza.Enabled = False
                cmbDespachos.Enabled = False
                GridLookPoliza.Enabled = True
            Else
                GridDespachos.DataSource = Nothing
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub checkPoliza_CheckedChanged(sender As Object, e As EventArgs) Handles checkPoliza.CheckedChanged
        If checkPoliza.Checked Then
            GridLookPoliza.Enabled = True
            cmbDespachos.Enabled = False
        Else
            GridLookPoliza.Enabled = False
            cmbDespachos.Enabled = True
        End If
    End Sub

    Private Sub GridLookPoliza_EditValueChanged(sender As Object, e As EventArgs) Handles GridLookPoliza.EditValueChanged
        Try
            ShowPassDetailByPoliza(Val(btnPassid.EditValue))
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Sub ShowPassDetailByPoliza(ByVal iPass As Integer)
        Try
            If Not iPass = 0 And Not GridLookPoliza.EditValue = Nothing Then
                pResult = String.Empty
                xserv.set_pass_detail_by_poliza(iPass, GridLookPoliza.EditValue, PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)
                If pResult = "OK" Then
                    GridLookPoliza.EditValue = Nothing
                    LLenarComboDespacho()
                    LlenarGrid()
                    checkPoliza.Enabled = False
                    cmbDespachos.Enabled = False
                Else
                    NotifyStatus(pResult, True, True)
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub DeleteDetailByPoliza()
        Try
            For i = 0 To GridViewPolizas.RowCount - 1
                If GridViewPolizas.IsRowSelected(i) Then
                    Dim xdatarow As DataRow = GridViewPolizas.GetDataRow(i)
                    pResult = ""
                    If xserv.delete_pass_detail_by_poliza(iPass, xdatarow("CODIGO_POLIZA"), PublicLoginInfo.Environment, pResult) Then
                        If Not pResult = "OK" Then
                            NotifyStatus(pResult, True, True)
                            Exit Sub
                        Else
                            LLenarComboDespacho()
                            LlenarGrid()
                            checkPoliza.Enabled = True
                            If GridViewPolizas.RowCount > 0 Then
                                checkPoliza.Enabled = False
                                cmbDespachos.Enabled = False
                            End If
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UiListaEmpaqueComprobante_Properties_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles UiListaEmpaqueComprobante.Properties.ButtonClick
        If e.Button.Tag = "REFRESH" Then
            LlenarListaTiposEmpaque()
        ElseIf e.Button.Tag = "ASSOCIATE" Then
            If Not UiListaEmpaqueComprobante.EditValue Is Nothing And Not String.IsNullOrEmpty(UiListaEmpaqueComprobante.Text) Then
                CambiarTipoEmpaque()
            End If
        End If

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
                UiListaEmpaqueComprobante.Properties.View.Columns("PARAM_NAME").Caption = "Descripcion"
                UiListaEmpaqueComprobante.Properties.View.Columns("TEXT_VALUE").Caption = "CODIGO"
                UiListaEmpaqueComprobante.Properties.View.Columns("PARAM_NAME").Visible = True
                UiListaEmpaqueComprobante.Properties.View.Columns("TEXT_VALUE").Visible = True
                UiListaEmpaqueComprobante.Properties.View.BestFitColumns()
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
            For i As Integer = 0 To GridViewPolizas.SelectedRowsCount() - 1
                If (GridViewPolizas.GetSelectedRows()(i) >= 0) Then
                    Dim Row As DataRow = CType(GridViewPolizas.GetDataRow(GridViewPolizas.GetSelectedRows()(i)), DataRow)
                    Row("PACKING") = UiListaEmpaqueComprobante.Text
                End If
            Next

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LlenarListaTiposAlmacen()
        Try
            Dim ds As DataSet
            Dim pResult As String = ""

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

    Private Sub UiBotonCerrarComprobante_Click(sender As Object, e As EventArgs) Handles UiBotonCerrarComprobante.Click
        UiPopupGenerarReporte.Hide()
    End Sub

    Private Sub GenerarReporte()
        Try
            Dim reporte As XtraReport

            If UiSwitchMontos.IsOn Then
                reporte = New rptPaseSalidaConCertificadoConMonto
            Else
                reporte = New rptPaseSalidaConCertificado
            End If

            'Dim view1 As DevExpress.XtraGrid.Views.Grid.GridView = CType(UiListaEmpaqueComprobante.Properties.View, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim rowAlmacen As Object = UiListaAlmacenaje.GetSelectedDataRow()

            'Dim reporte As New rptPaseSalidaConCertificadoConMonto

            reporte.DataSource = CType(GridDespachos.DataSource, DataTable)
            reporte.DataMember = CType(GridDespachos.DataSource, DataTable).TableName
            reporte.RequestParameters = False
            reporte.Parameters("logoImg").Value = PublicLoginInfo.LOGO 
            reporte.Parameters("codigoCliente").Value = cmbClientes.EditValue
            reporte.Parameters("nombreCliente").Value = cmbClientes.Text
            reporte.Parameters("domicilio").Value = rowAlmacen("SPARE2")
            reporte.Parameters("nombrePiloto").Value = cmbTRANSPORTISTA.Text
            reporte.Parameters("placaVehiculo").Value = cmbPlacas.Text
            reporte.Parameters("marcaVehiculo").Value = UiTextoModeloVehiculo.Text
            reporte.Parameters("colorVehiculo").Value = UiTextoColorVehiculo.Text()
            reporte.Parameters("usuario").Value = PublicLoginInfo.LoginName
            reporte.Parameters("fecha").Value = Date.Today
            reporte.Parameters("numPase").Value = btnPassid.Text
            reporte.Parameters("entregarCliente").Value = UiTextoEntregarACliente.Text
            reporte.ShowPreview()

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UiBotonGenerarReporteComprobante_Click(sender As Object, e As EventArgs) Handles UiBotonGenerarReporteComprobante.Click
        If Not UiListaAlmacenaje.EditValue Is Nothing And Not String.IsNullOrEmpty(UiListaAlmacenaje.Text) Then
            GenerarReporte()
        End If
    End Sub

    Private Sub UiListaAlmacenaje_Properties_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles UiListaAlmacenaje.Properties.ButtonClick
        If e.Button.Tag = "REFRESH" Then
            LlenarListaTiposAlmacen()
        End If
    End Sub
End Class