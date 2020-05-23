Imports System.IO
Imports System.Data
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmGeneraOla
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
    Dim xSettingServ As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
    Dim xSecurity As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_Security.asmx")
    Dim xServTrans As New OnePlanServices_Trans.WMS_TransSoapClient("WMS_TransSoap", PublicLoginInfo.WSHost + "/Trans/WMS_Trans.asmx")
    Dim xServPoliza As New WMS_Polizas.WMS_PolizasSoapClient("WMS_PolizasSoap", PublicLoginInfo.WSHost + "/Trans/WMS_Polizas.asmx")
    Dim pResult As String
    Dim dsTasks As New DataSet
    Dim dtTasks As New DataTable
    'Dim dsskusMatch As New DataSet
    Dim dsPendings As New DataSet
    Dim _olaPicking As Integer = 0


    Private Sub frmGeneraOla_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            'fn_llena_combos()

        Catch ex As Exception
            MsgBox("error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmGeneraOla_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'limpiamos los datasets
        Try
            If Not IsNothing(dsTasks) Then
                dsTasks.Dispose()
            End If
            xserv = Nothing
            xClientsServ = Nothing
            xSettingServ = Nothing
            xSecurity = Nothing

            pResult = String.Empty
        Catch ex As Exception
            MsgBox("Error al Limpiar" & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmGeneraOla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim strPath As String
        Try
            gLastScreenShowed = Me.Name

            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmGeneraOlaLayout" & PublicLoginInfo.LoginID & ".xml"

            'LayoutControl1.SaveLayoutToXml(strPath)
            strPath = String.Empty


            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmGeneraOlaGridPending" & PublicLoginInfo.LoginID & ".xml"

            GridViewPending.SaveLayoutToXml(strPath)
            strPath = String.Empty


            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmGeneraOlaGridAssign" & PublicLoginInfo.LoginID & ".xml"

            GridViewAssigned.SaveLayoutToXml(strPath)
            strPath = String.Empty

        Catch ex As Exception
            MsgBox("Error al Cerrar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub


    Private Sub frmGeneraOla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strPath As String
        _olaPicking = 0
        Try
            fn_llena_combos()
            'LayoutControl1.SetDefaultLayout()

            gLastScreenShowed = Me.Name

            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmGeneraOlaLayout" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                'LayoutControl1.RestoreLayoutFromXml(strPath)
                strPath = String.Empty
            End If

            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmGeneraOlaGridPending" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                GridViewPending.RestoreLayoutFromXml(strPath)
                strPath = String.Empty
            End If
            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmGeneraOlaGridAssign" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                GridViewAssigned.RestoreLayoutFromXml(strPath)
                strPath = String.Empty
            End If
        Catch ex As Exception
            MsgBox("Error al abrir la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub

    Private Sub fn_llena_combos()
        Try
            Dim i As Integer
            'llenamos el combo de los regimenes de almacen
            Dim dsRegimenAlmacen As New DataSet
            dsRegimenAlmacen = xSettingServ.GetParam_ByParamKey("WMS3PL", "WAREHOUSE_REGIMEN", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                cmbRegimen.Properties.DataSource = dsRegimenAlmacen.Tables(0)
                cmbRegimen.Properties.PopulateViewColumns()
                cmbRegimen.Properties.ValueMember = "PARAM_NAME"
                cmbRegimen.Properties.DisplayMember = "PARAM_CAPTION"

                For i = 0 To cmbRegimen.Properties.View.Columns.Count - 1
                    cmbRegimen.Properties.View.Columns(i).Visible = False
                Next
                cmbRegimen.Properties.View.Columns("PARAM_NAME").Caption = "REGIMEN ALMACEN"
                cmbRegimen.Properties.View.Columns("PARAM_CAPTION").Caption = "DESCRIPCION REGIMEN ALMACEN"
                cmbRegimen.Properties.View.Columns("PARAM_NAME").Visible = True
                cmbRegimen.Properties.View.Columns("PARAM_CAPTION").Visible = True
                cmbRegimen.Properties.View.BestFitColumns()
                cmbRegimen.EditValue = "FISCAL"
            Else
                MsgBox(pResult)
            End If
            'llenamos el combo de los clientes
            Dim dsClientes As New DataSet
            dsClientes = xClientsServ.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                If Not IsNothing(dsClientes) Then
                    cmbCliente.Properties.DataSource = dsClientes.Tables(0)
                    cmbCliente.Properties.PopulateViewColumns()
                    cmbCliente.Properties.ValueMember = "CLIENT_CODE"
                    cmbCliente.Properties.DisplayMember = "CLIENT_NAME"

                    For i = 0 To cmbCliente.Properties.View.Columns.Count - 1
                        cmbCliente.Properties.View.Columns(i).Visible = False
                    Next

                    cmbCliente.Properties.View.Columns("CLIENT_CODE").Caption = "CODIGO"
                    cmbCliente.Properties.View.Columns("CLIENT_NAME").Caption = "NOMBRE"
                    cmbCliente.Properties.View.Columns("CLIENT_CODE").Visible = True
                    cmbCliente.Properties.View.Columns("CLIENT_NAME").Visible = True
                    cmbCliente.Properties.View.BestFitColumns()

                End If
                cmbCliente.EditValue = "1"
            Else
                MsgBox(pResult)
            End If

            Dim dsUsuarios As New DataSet
            dsUsuarios = xSecurity.SearchOperators(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                If Not IsNothing(dsUsuarios) Then
                    cmbUsuarios.Properties.DataSource = dsUsuarios.Tables(0)
                    cmbUsuarios.Properties.PopulateViewColumns()
                    cmbUsuarios.Properties.ValueMember = "LOGIN_ID"
                    cmbUsuarios.Properties.DisplayMember = "LOGIN_NAME"

                    For i = 0 To cmbUsuarios.Properties.View.Columns.Count - 1
                        cmbUsuarios.Properties.View.Columns(i).Visible = False
                    Next
                    cmbUsuarios.Properties.View.Columns("LOGIN_ID").Caption = "USUARIO"
                    cmbUsuarios.Properties.View.Columns("LOGIN_NAME").Caption = "NOMBRE"
                    cmbUsuarios.Properties.View.Columns("LOGIN_ID").Visible = True
                    cmbUsuarios.Properties.View.Columns("LOGIN_NAME").Visible = True
                End If
            Else
                MsgBox(pResult)
            End If
            cmbUsuarios.EditValue = "1"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnPendings_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Try
            If IsNothing(cmbRegimen.EditValue) Then
                NotifyStatus("debe seleccionar un regimen", False, True)
                cmbRegimen.Focus()
                Exit Sub
            End If
            If IsNothing(cmbCliente.EditValue) Then
                NotifyStatus("Debe seleccionar un cliente", False, True)
                cmbCliente.Focus()
                Exit Sub
            End If
            If IsNothing(cmbUsuarios.EditValue) Then
                NotifyStatus("Debe seleccionar un bodeguero", False, True)
                cmbUsuarios.Focus()
                Exit Sub
            End If

            dsPendings = xserv.get_pending_picking(" where client_code = '" & cmbCliente.EditValue & "' and warehouse_regimen = '" & cmbRegimen.EditValue & "'", PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                If Not IsNothing(dsPendings) Then
                    If dsPendings.Tables.Count > 0 Then
                        GridPending.DataSource = dsPendings.Tables(0)
                        GridViewPending.BestFitColumns()
                    End If
                End If
            Else
                MsgBox(pResult)
            End If
            'dsPendings = Nothing
            pResult = String.Empty
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub btnAsignar_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Try
            Dim dr As DataRow
            Dim QTYA As Double

            Double.TryParse(GridViewAssigned.GetFocusedRowCellValue("QTY_TRANS"), QTYA)

            If GridViewAssigned.SelectedRowsCount > 0 Then

                If Decimal.Parse(QTYA.ToString()) > Decimal.Parse(GridViewPending.GetFocusedRowCellValue("QTY").ToString) Then
                    NotifyStatus("La cantidad sobrepasa lo solicitado", True, True)
                    Return
                End If

                If Decimal.Parse(QTYA.ToString()) > Decimal.Parse(GridViewAssigned.GetFocusedRowCellValue("AVAILABLE").ToString) Then
                    NotifyStatus("La cantidad sobrepasa los disponible", True, True)
                    Return
                End If

                dr = dsTasks.Tables(0).NewRow
                dr.Item("TASK_TYPE") = "TAREA_PICKING"
                dr.Item("TASK_SUBTYPE") = "DESPACHO_FISCAL"
                dr.Item("TASK_OWNER") = PublicLoginInfo.LoginID
                dr.Item("TASK_ASSIGNEDTO") = cmbUsuarios.EditValue.ToString()
                dr.Item("ASSIGNED_DATE") = FormatDateTime(Date.Now, DateFormat.GeneralDate)
                dr.Item("QUANTITY_PENDING") = QTYA.ToString()
                dr.Item("QUANTITY_ASSIGNED") = QTYA.ToString()
                dr.Item("CODIGO_POLIZA_SOURCE") = GridViewPending.GetFocusedRowCellValue("CODIGO_POLIZA_ORIGEN").ToString
                dr.Item("CODIGO_POLIZA_TARGET") = GridViewPending.GetFocusedRowCellValue("CODIGO_POLIZA").ToString
                dr.Item("REGIMEN") = cmbRegimen.EditValue
                dr.Item("MATERIAL_ID") = GridViewAssigned.GetFocusedRowCellValue("MATERIAL_CODE").ToString
                dr.Item("BARCODE_ID") = GridViewAssigned.GetFocusedRowCellValue("BARCODE_ID").ToString
                dr.Item("ALTERNATE_BARCODE") = GridViewAssigned.GetFocusedRowCellValue("ALTERNATE_BARCODE").ToString
                dr.Item("CLIENT_OWNER") = cmbCliente.EditValue
                dr.Item("CLIENT_NAME") = cmbCliente.Properties.GetDisplayValueByKeyValue(cmbCliente.EditValue)
                dr.Item("MATERIAL_NAME") = GridViewAssigned.GetFocusedRowCellValue("MATERIAL_NAME")
                dr.Item("DOC_ID") = GridViewPending.GetFocusedRowCellValue("DOC_ID")
                dr.Item("LINE_NUMBER") = GridViewPending.GetFocusedRowCellValue("LINE_NUMBER")
                dtTasks.Rows.Add(dr)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridPending_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridPending.KeyUp
        Try
            If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                Dim xdatarow As DataRow = GridViewPending.GetDataRow(GridViewPending.FocusedRowHandle)

                FN_LEE(Val(xdatarow("DOC_ID")), Val(xdatarow("ORIGIN_LINE_NUMBER")))
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FN_LEE(ByVal pDOC_ID As Integer, ByVal pLINE As Integer)

        Try

            pResult = String.Empty
            If GridViewPending.SelectedRowsCount > 0 Then
                Dim dt As DataTable = xserv.GetInventoryFiscalByLicence(pDOC_ID, pLINE, pResult, PublicLoginInfo.Environment)
                If String.IsNullOrEmpty(pResult) Then
                    If Not IsNothing(dt) Then
                        If dt.Rows.Count > 0 Then
                            dt.Columns.Add("grabo")
                            For Each dr As DataRow In dt.Rows
                                dr("grabo") = "NO"
                            Next
                            dt.Columns("QTY_TRANS").ReadOnly = False

                            GridAssigned.DataSource = dt
                            GridAssigned.Refresh()
                            GridViewAssigned.BestFitColumns()
                            NotifyStatus("Inventario fiscal por licencia cargado exitosamente", False, False)
                        Else
                            GridAssigned.DataSource = Nothing
                            GridAssigned.Refresh()
                        End If
                    Else
                        GridAssigned.DataSource = Nothing
                        GridAssigned.Refresh()
                        NotifyStatus(pResult, False, True)
                    End If
                Else
                    GridAssigned.DataSource = Nothing
                    GridAssigned.Refresh()
                    NotifyStatus(pResult, False, True)
                End If

            End If

        Catch ex As Exception
            RibbonForm1.Static_Message.Caption = ex.Message
        End Try
    End Sub

    Private Sub GridPending_Click(sender As System.Object, e As System.EventArgs) Handles GridPending.Click
        Try
            Dim xdatarow As DataRow = GridViewPending.GetDataRow(GridViewPending.FocusedRowHandle)
            ''MessageBox.Show(xdatarow("ORIGIN_LINE_NUMBER"))
            FN_LEE(Val(xdatarow("DOC_ID")), Val(xdatarow("ORIGIN_LINE_NUMBER")))
            ''FN_LEE(Val(xdatarow("ORIGIN_DOC_ID")), Val(xdatarow("ORIGIN_LINE_NUMBER")))

        Catch ex As Exception
            RibbonForm1.Static_Message.Caption = ex.Message
        End Try

    End Sub


    Private Sub cmbCliente_EditValueChanged(sender As Object, e As EventArgs) Handles cmbCliente.EditValueChanged, cmbRegimen.EditValueChanged
        Try
            If Validar() Then
                LlenarGridPendientes()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridAssigned_KeyUp(sender As Object, e As KeyEventArgs) Handles GridAssigned.KeyUp

    End Sub

    Private Sub ValidarParaGenerarPicking()
        Try
            If GridViewPending.FocusedRowHandle < 0 Then
                Return
            End If
            If Not String.IsNullOrEmpty(GridViewAssigned.GetColumnError(GridViewAssigned.Columns("QTY_TRANS"))) Then
                GridViewAssigned.Focus()
                Return
            End If

            dxError.SetError(cmbUsuarios, "", ErrorType.None)
            If cmbUsuarios.EditValue = Nothing Or cmbUsuarios.EditValue = "1" Then
                dxError.SetError(cmbUsuarios, "Seleccione un Operador")
                Return
            End If
            Dim qtyAsig As Decimal = GridViewPending.GetFocusedRowCellValue("QTY").ToString()
            Dim aqtIng As Double = GridViewAssigned.Columns("QTY_TRANS").SummaryItem.SummaryValue

            If aqtIng <= 0 Then
                NotifyStatus("La cantidad tiene que ser mayor a cero.", True, True)
                Return
            End If


            If aqtIng > qtyAsig Then
                NotifyStatus(String.Format("No puede despachar mas de los solicitado, que es: ({0})", qtyAsig), True, True)
                Return
            Else
                GridViewAssigned.SetColumnError(UiColCantidadTransaccion, "", errorType:=ErrorType.None)
                Grabar()
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub Grabar()
        Try
            'Dim wpi As Integer = 0
            Dim qty As Decimal = 0
            For Each fila As DataRow In CType(GridAssigned.DataSource, DataTable).Rows
                If fila("QTY_TRANS") <= 0 Then
                    Continue For
                End If
                pResult = ""
                xserv.InsertTaskFical("TAREA_PICKING", IIf(cmbRegimen.EditValue.ToString() = "FISCAL", "DESPACHO_FISCAL", "DESPACHO_GENERAL"), PublicLoginInfo.LoginID,
                                   cmbUsuarios.EditValue.ToString(), fila("QTY_TRANS"),
                                   fila("QTY_TRANS"), GridViewPending.GetFocusedRowCellValue("CODIGO_POLIZA_ORIGEN").ToString,
                                   GridViewPending.GetFocusedRowCellValue("CODIGO_POLIZA").ToString, cmbRegimen.EditValue,
                                    fila("MATERIAL_ID").ToString, fila("BARCODE_ID").ToString,
                                    fila("BARCODE_ID").ToString, fila("MATERIAL_NAME"),
                                    cmbCliente.EditValue, cmbCliente.Properties.GetDisplayValueByKeyValue(cmbCliente.EditValue),
                                    GridViewPending.GetFocusedRowCellValue("ORIGIN_LINE_NUMBER").ToString(), GridViewPending.GetFocusedRowCellValue("LINE_NUMBER").ToString, fila("LICENSE_ID"),
                                    PublicLoginInfo.Environment, pResult, _olaPicking, GridViewPending.GetFocusedRowCellValue("TRANSLATION").ToString)
                qty += fila("QTY_TRANS")
                If Not pResult.ToUpper.Equals("OK") Then
                    NotifyStatus(pResult, True, True)
                    Return
                End If
            Next
            If pResult = "OK" Then
                If GridViewPending.GetFocusedRowCellValue("TRANSLATION").ToString.Equals("SI") Then
                    Dim regimen As DataSet
                    Dim result As String = String.Empty
                    regimen = xSettingServ.GetParam_ByParamKey("ALMACENAMIENTO", "TIPOS_ALMACENAJE", GridViewPending.GetFocusedRowCellValue("REGIMEN").ToString, result, PublicLoginInfo.Environment)

                    If Not regimen Is Nothing Then
                        If result = "OK" Then
                            'qty = Integer.Parse(GridViewAssigned.GetFocusedRowCellValue("QTY_TRANS"))
                            GenerarTareaRecepcionAuto(_olaPicking, GridViewAssigned.GetFocusedRowCellValue("MATERIAL_CODE").ToString, qty, qty)
                        End If
                    End If
                End If
                'dim dtTask as dataset = ser

                btnOLaPicking.Caption = String.Format("Nueva Ola de Picking(Actual {0})", _olaPicking)

                pResult = String.Empty
                xserv.set_picking_status(GridViewPending.GetFocusedRowCellValue("DOC_ID"), GridViewPending.GetFocusedRowCellValue("LINE_NUMBER"), "ASSIGNED", PublicLoginInfo.Environment, pResult)
                If Not pResult = "OK" Then
                    NotifyStatus(pResult, True, True)
                Else
                    _olaPicking = 0
                    LlenarGridPendientes()
                    NotifyStatus("Orden generada exitosamente", True, False)
                End If
            Else
                NotifyStatus(pResult, True, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Public Sub GenerarTareaRecepcionAuto(ByVal pOlaPicking As Integer, ByVal pMaterialId As String, ByRef pQty As Integer, ByVal pQtyP As Integer)
        Try
            Dim result = String.Empty
            Dim dtTask As DataTable

            dtTask = xserv.GetTaskPicking(pOlaPicking, pMaterialId, pQtyP, PublicLoginInfo.Environment, result)

            Dim qytP, qtyN, licenseP, licenseN, lincese, qtyT As Integer

            qytP = 0
            qtyN = 0
            licenseP = 0
            licenseN = 0
            lincese = 0
            qtyT = 0

            For Each row As DataRow In dtTask.Rows

                If row("EXIST_POLIZA").ToString = 0 Then
                    NotifyStatus("No se encontro el documento general", True, True)
                    Return
                End If

                Dim qty As Integer = 0
                qty = row("LICENSE_QTY").ToString - pQty

                If qty = 0 Then
                    lincese = row("LICENSE_ID_SOURCE").ToString
                    qtyT = row("LICENSE_QTY").ToString
                    Exit For
                ElseIf qty > 0 Then
                    If qytP = 0 Or qty < qytP Then
                        qytP = qty
                        licenseP = row("LICENSE_ID_SOURCE").ToString
                        qtyT = row("LICENSE_QTY").ToString
                    End If
                Else
                    If qtyN = 0 Or qty > qtyN Then
                        qtyN = qty
                        licenseN = row("LICENSE_ID_SOURCE").ToString
                        qtyT = row("LICENSE_QTY").ToString
                    End If
                End If
            Next

            Dim pickingTotal As Boolean = False

            If lincese = 0 Then
                If Not qytP = 0 And qytP > (qtyN * -1) Then
                    lincese = licenseP
                    qtyT = pQty
                Else
                    lincese = licenseN
                End If
            Else
                pickingTotal = True
            End If

            result = String.Empty

            For Each row As DataRow In dtTask.Rows
                If lincese = row("LICENSE_ID_SOURCE").ToString() Then
                    xServTrans.RegisterTrans("0", PublicLoginInfo.LoginID, "TRASLADO_GENERAL", "PICKING TRASLADO GENERAL", row("BARCODE_ID").ToString(),
                                         row("MATERIAL_ID").ToString(), lincese, 0, row("LOCATION_SPOT_SOURCE").ToString(), 0, "", qtyT, "N/A", "N/A",
                                         "TRASLADO_GENERAL", row("CODIGO_POLIZA_TARGET").ToString(), lincese, "N/A", pOlaPicking,
                                         row("BATCH").ToString(), 0, row("SPOT_TYPE").ToString(), Decimal.Parse(row("USED_MT2").ToString()), "", 0, "", "", Date.Now, result, PublicLoginInfo.Environment)
                    If Not result = "OK" Then
                        NotifyStatus(result, True, True)
                        Return
                    End If

                    If pickingTotal Then
                        pQty = 0
                    Else
                        pQty = pQty - qtyT
                    End If
                    result = String.Empty
                    Dim licenseCreada As Integer = 0
                    xServPoliza.CrearLicencia(row("CODIGO_POLIZA_TARGET").ToString(), PublicLoginInfo.LoginID, licenseCreada, row("CLIENT_OWNER").ToString(), "GENERAL", 0, result, PublicLoginInfo.Environment)
                    If Not result = "OK" Then
                        NotifyStatus(result, True, True)
                        Return
                    End If
                    result = String.Empty
                    xServPoliza.AgregaSKU_Licencia(licenseCreada, row("BARCODE_ID").ToString(), qtyT, PublicLoginInfo.LoginID, 0, 0, "", "",
                                                   row("ACUERDO_COMERCIAL_ID").ToString(), 0,
                                                   "PROCESSED", result,
                                                   PublicLoginInfo.Environment, row("DATE_EXPIRATION").ToString(), row("BATCH").ToString(), "", "", "NEW", "", "")
                    If Not result = "OK" Then
                        NotifyStatus(result, True, True)
                        Return
                    End If

                    result = String.Empty
                    xServTrans.RegisterTrans(row("ACUERDO_COMERCIAL_ID").ToString(), PublicLoginInfo.LoginID, "RECEP_GENERAL_X_TRASLADO", "",
                                             row("BARCODE_ID").ToString(), row("MATERIAL_ID").ToString(), lincese, licenseCreada,
                                             row("LOCATION_SPOT_SOURCE").ToString(), row("LOCATION_SPOT_SOURCE").ToString(), row("CLIENT_OWNER").ToString(),
                                             qtyT, "", "", "", row("CODIGO_POLIZA_TARGET").ToString(), licenseCreada, "PROCESSED", pOlaPicking,
                                             row("BATCH").ToString(), 0, "", 0, "", 0, "", "", Date.Now, result, PublicLoginInfo.Environment)
                    If Not result = "OK" Then
                        NotifyStatus(result, True, True)
                        Return
                    End If

                    result = String.Empty
                    xserv.set_General_Egreso_DISCRETIONARY(PublicLoginInfo.LoginID, cmbUsuarios.EditValue.ToString(),
                                                            qtyT, 0, row("MATERIAL_ID").ToString(),
                                                            row("BARCODE_ID").ToString(), row("ALTERNATE_BARCODE").ToString(),
                                                            row("MATERIAL_NAME").ToString(), row("CLIENT_OWNER").ToString(),
                                                            row("CLIENT_NAME").ToString(), PublicLoginInfo.Environment, result,
                                                            0, licenseCreada, "POR TRASLADO DE FISCAL A GENERAL", Nothing, Nothing, Nothing, Nothing, Nothing)
                    If Not result = "OK" Then
                        NotifyStatus(result, True, True)
                        Return
                    End If

                    Exit For
                End If
            Next

            If pQty > 0 Then
                GenerarTareaRecepcionAuto(pOlaPicking, pMaterialId, pQty, pQtyP)
            Else
                MessageBox.Show("Tarea de recepción generada")
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, False)
        End Try
    End Sub

    Private Sub frmGeneraOla_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        SplitContainerControl1.SplitterPosition = Me.Width / 2
    End Sub


    Private Function Validar() As Boolean
        Dim paso As Boolean = True
        dxError.SetError(cmbRegimen, "", ErrorType.None)
        dxError.SetError(cmbCliente, "", ErrorType.None)
        dxError.SetError(cmbUsuarios, "", ErrorType.None)

        'If cmbRegimen.EditValue = "1" Or cmbCliente.EditValue = "1" Then
        '    Return False
        'End If

        If cmbRegimen.EditValue = Nothing Then
            dxError.SetError(cmbRegimen, "Seleccione el regimen")
            paso = False
        End If

        If cmbCliente.EditValue = Nothing Then
            dxError.SetError(cmbCliente, "Seleccione el cliente")
            paso = False
        End If

        Return paso
    End Function

    Private Sub LlenarGridPendientes()
        Try
            dsPendings = xserv.get_pending_picking(" where client_code = '" & cmbCliente.EditValue & "' and warehouse_regimen = '" & cmbRegimen.EditValue & "'", PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                If Not IsNothing(dsPendings) Then
                    If dsPendings.Tables(0).Rows.Count > 0 Then
                        GridPending.DataSource = dsPendings.Tables(0)
                        GridViewPending.BestFitColumns()
                        GridAssigned.DataSource = Nothing
                        GridAssigned.Refresh()
                    Else
                        GridPending.DataSource = Nothing
                        GridPending.Refresh()
                        GridAssigned.DataSource = Nothing
                        GridAssigned.Refresh()
                        NotifyStatus("No se encontraron registros", False, True)
                    End If
                End If
                GridViewPending.ExpandAllGroups()

            Else
                GridPending.DataSource = Nothing
                GridPending.Refresh()
                GridAssigned.DataSource = Nothing
                GridAssigned.Refresh()
                NotifyStatus(pResult, False, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub cmbCliente_Leave(sender As Object, e As EventArgs) Handles cmbCliente.Leave, cmbUsuarios.Leave, cmbRegimen.Leave
        dxError.SetError(sender, "", ErrorType.None)
    End Sub

    Private Sub btnRefesh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefesh.ItemClick
        If Validar() Then
            LlenarGridPendientes()
        End If
    End Sub

    Private Sub btnOLaPicking_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOLaPicking.ItemClick
        _olaPicking = 0
        btnOLaPicking.Caption = String.Format("Nueva Ola de Picking(Actual {0})", _olaPicking)
    End Sub

    Private Sub UiBotonGrabar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonGrabar.ItemClick
        cmbUsuarios.Focus()
        ValidarParaGenerarPicking()
    End Sub



    Private Sub GridViewAssigned_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridViewAssigned.ValidateRow
        Try
            Dim view As GridView = CType(sender, GridView)
            Dim colDisponible As GridColumn = view.Columns("AVAILABLE")
            Dim colDespachar As GridColumn = view.Columns("QTY_TRANS")
            Dim cantidadDispoonible As Decimal = CType(view.GetRowCellValue(e.RowHandle, colDisponible), Decimal)
            Dim cantidadADespachar As Decimal = CType(view.GetRowCellValue(e.RowHandle, colDespachar), Decimal)
            If cantidadADespachar > cantidadDispoonible Then
                e.Valid = False
                view.SetColumnError(colDespachar, "La cantidad es mayor a la disponible")
            Else
                e.Valid = True
                view.SetColumnError(colDespachar, "", errorType:=ErrorType.None)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub GridViewAssigned_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles GridViewAssigned.InvalidRowException
        e.ExceptionMode = ExceptionMode.NoAction
    End Sub

    Private Sub DistribuirAutomaticamente()
        Try
            If GridViewPending.FocusedRowHandle < 0 Then
                Return
            End If
            Dim qtyAsig As Decimal = GridViewPending.GetFocusedRowCellValue("QTY").ToString()

            For Each fila As DataRow In CType(GridAssigned.DataSource, DataTable).Rows
                If qtyAsig > 0 Then
                    If fila("AVAILABLE") >= qtyAsig Then
                        fila("QTY_TRANS") = qtyAsig
                        qtyAsig = 0
                    ElseIf fila("AVAILABLE") < qtyAsig Then
                        qtyAsig = qtyAsig - fila("AVAILABLE")
                        fila("QTY_TRANS") = fila("AVAILABLE")
                    End If
                Else
                    fila("QTY_TRANS") = 0
                End If
            Next
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UiBotonDistribuirAutomaticamente_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonDistribuirAutomaticamente.ItemClick
        DistribuirAutomaticamente()
    End Sub

    Private Sub GridViewAssigned_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles GridViewAssigned.CustomDrawCell
        If EscolumnaDeColorYElValorEsNumerico(e) Then

            Dim color As Color = Color.FromArgb(Convert.ToInt32(e.CellValue))
            Dim brush As New LinearGradientBrush(e.Bounds, color, color, LinearGradientMode.ForwardDiagonal)

            e.Graphics.FillRectangle(brush, e.Bounds)
            brush.Dispose()
            e.Graphics.DrawString("", e.Appearance.Font, Brushes.Black, New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
            e.Handled = True
        End If
    End Sub

    Private Function EscolumnaDeColorYElValorEsNumerico(e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) As Boolean
        Return e.CellValue IsNot Nothing AndAlso e.Column.FieldName = "COLOR" AndAlso IsNumeric(e.CellValue.ToString())
    End Function
End Class