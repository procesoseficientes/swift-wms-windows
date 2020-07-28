Imports System.IO
Imports System.Data
Imports System.Web.UI.WebControls.Expressions
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.Charts.Native
Imports DevExpress.CodeParser
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Parameters
Imports MobilityScm.Modelo.Entidades
Imports MobilityScm.Modelo.Tipos
Imports MobilityScm.Utilerias
Imports MobilityScm.Vertical.Entidades
Imports ClosedXML.Excel

Public Class frmEgresoGeneral
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
    Dim xSettingServ As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
    Dim xSecurity As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_Security.asmx")
    Dim xInventory As New OnePlanServices_InfoInventory.WMS_InfoInventorySoapClient("WMS_InfoInventorySoap", PublicLoginInfo.WSHost + "/Info/wms_InfoInventory.asmx")
    Dim xInfoTrans As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
    Dim pResult As String
    Dim dsTasks As New DataSet
    Dim dtTasks As New DataTable
    Public inActual As Double = 0
    Public inActualAux As Double = 0
    Public CodeSku_ As String = ""
    Private dd As Double = 0
    Private pResultPoliza As String = String.Empty
    Dim _olaPicking As Integer = 0
    Public ReadOnly Property UbicacionSeleccionada As String
        Get
            Return If(UiListaUbicacionDeSalida.EditValue?.ToString(), "")
        End Get
    End Property

    Public Property Ubicaciones As IList(Of Ubicacion)
        Get
            Return CType(UiListaUbicacionDeSalida.Properties.DataSource, IList(Of Ubicacion))
        End Get
        Set(ByVal value As IList(Of Ubicacion))
            UiListaUbicacionDeSalida.Properties.DataSource = value
        End Set
    End Property

    Private Sub frmEgresoGeneral_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub frmEgresoGeneral_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'limpiamos los datasets
        Try
            If Not IsNothing(dsTasks) Then
                dsTasks.Dispose()
            End If
            xserv = Nothing
            xClientsServ = Nothing
            xSettingServ = Nothing
            xSecurity = Nothing
            xInventory = Nothing

            pResult = String.Empty
        Catch ex As Exception
            MsgBox("Error al Limpiar" & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmEgresoGeneral_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim strPath As String
        Try
            gLastScreenShowed = Me.Name

            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmEgresoGeneralLayout" & PublicLoginInfo.LoginID & ".xml"

            'LayoutControl1.SaveLayoutToXml(strPath)
            strPath = String.Empty

            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmEgresoGeneralGridInventario" & PublicLoginInfo.LoginID & ".xml"

            GridViewInventario.SaveLayoutToXml(strPath)
            strPath = String.Empty

            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmEgresoGeneralGridEgreso" & PublicLoginInfo.LoginID & ".xml"

            GridViewEgreso.SaveLayoutToXml(strPath)
            strPath = String.Empty

        Catch ex As Exception
            MsgBox("Error al Cerrar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub

    Private Sub frmEgresoGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strPath As String
        _olaPicking = 0
        Try
            'LayoutControl1.SetDefaultLayout()
            gLastScreenShowed = Me.Name

            fn_crea_tabla_tasks()

            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmEgresoGeneralLayout" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                'LayoutControl1.RestoreLayoutFromXml(strPath)
                strPath = String.Empty
            End If

            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmEgresoGeneralGridInventario" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                GridViewInventario.RestoreLayoutFromXml(strPath)
                strPath = String.Empty
            End If
            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmEgresoGeneralGridEgreso" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                GridViewEgreso.RestoreLayoutFromXml(strPath)
                strPath = String.Empty
            End If

            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmEgresoGeneralGridInventarioProyecto" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                GridViewInventorybyProject.RestoreLayoutFromXml(strPath)
                strPath = String.Empty
            End If

            Try

                fn_llena_combos()
                barListaTipo.EditValue = "General"

            Catch ex As Exception
                MsgBox("error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try

            CambiarVistas()
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

                    cmbClientes.Properties.View.Columns("CLIENT_NAME").Caption = "Nombre"
                    cmbClientes.Properties.View.Columns("CLIENT_CODE").Caption = "Código"
                    cmbClientes.Properties.View.Columns("CLIENT_NAME").Visible = True
                    cmbClientes.Properties.View.Columns("CLIENT_CODE").Visible = True
                    cmbClientes.Properties.View.BestFitColumns()

                End If
            Else
                MsgBox(pResult)
            End If

            Dim webServiceInfoTrans As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            Dim dsUsuarios As DataTable = webServiceInfoTrans.GetOperatorAssignedToDistributionCenterByUser(PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)

            If pResult = "OK" Then
                If Not IsNothing(dsUsuarios) Then
                    cmbBodegueros.Properties.DataSource = dsUsuarios
                    cmbBodegueros.Properties.PopulateViewColumns()
                    cmbBodegueros.Properties.ValueMember = "LOGIN_ID"
                    cmbBodegueros.Properties.DisplayMember = "LOGIN_NAME"
                    For i = 0 To cmbBodegueros.Properties.View.Columns.Count - 1
                        cmbBodegueros.Properties.View.Columns(i).Visible = False
                    Next
                    cmbBodegueros.Properties.View.Columns("LOGIN_NAME").Caption = "Nombre"
                    cmbBodegueros.Properties.View.Columns("LOGIN_ID").Caption = "Usuario"
                    cmbBodegueros.Properties.View.Columns("LOGIN_NAME").Visible = True
                    cmbBodegueros.Properties.View.Columns("LOGIN_ID").Visible = True
                    cmbBodegueros.Properties.View.BestFitColumns()


                    Dim cadenaOperadores As String = String.Empty
                    For Each fila As DataRow In dsUsuarios.Rows
                        If (String.IsNullOrEmpty(cadenaOperadores)) Then
                            cadenaOperadores = fila("LOGIN_ID")
                        Else
                            cadenaOperadores += "|" + fila("LOGIN_ID")
                        End If
                    Next

                    UsuarioDeseaCargarBodegas()
                End If
            Else
                MsgBox(pResult)
            End If
            Dim dsTipoDescrecional As DataSet
            dsTipoDescrecional = xSettingServ.GetParam_ByParamKey("EGRESOS", "PICKING_DISCRECIONAL", "", pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                If Not IsNothing(dsUsuarios) Then
                    cmbMotivoDiscrecional.Properties.DataSource = dsTipoDescrecional.Tables(0)
                    cmbMotivoDiscrecional.Properties.PopulateViewColumns()
                    cmbMotivoDiscrecional.Properties.ValueMember = "PARAM_NAME"
                    cmbMotivoDiscrecional.Properties.DisplayMember = "PARAM_CAPTION"

                    For i = 0 To cmbMotivoDiscrecional.Properties.View.Columns.Count - 1
                        cmbMotivoDiscrecional.Properties.View.Columns(i).Visible = False
                    Next
                    cmbMotivoDiscrecional.Properties.View.Columns("PARAM_CAPTION").Caption = "Descripción"
                    cmbMotivoDiscrecional.Properties.View.Columns("PARAM_NAME").Caption = "Tipo"
                    cmbMotivoDiscrecional.Properties.View.Columns("PARAM_CAPTION").Visible = True
                    cmbMotivoDiscrecional.Properties.View.Columns("PARAM_NAME").Visible = True
                    cmbMotivoDiscrecional.Properties.View.BestFitColumns()
                End If
            Else
                MsgBox(pResult)
            End If

            cmbBodegueros.EditValue = "1"
            cmbMotivoDiscrecional.EditValue = "1"
            'dtFechaDocumento.EditValue = FormatDateTime(Date.Now, DateFormat.ShortDate)

            cargarProyectos()
            cargarUbicaciones()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cargarProyectos()
        'llenamos el combo de proyecto
        Dim i As Integer
        Dim dsProject As DataSet
        dsProject = xInventory.getProjectsActive(cmbClientes.EditValue, pResult, PublicLoginInfo.Environment)

        If pResult = "OK" Then
            If Not IsNothing(dsProject) Then
                cmbProyecto.Properties.DataSource = dsProject.Tables(0)
                cmbProyecto.Properties.PopulateViewColumns()
                cmbProyecto.Properties.ValueMember = "ID"
                cmbProyecto.Properties.DisplayMember = "OPPORTUNITY_NAME"

                For i = 0 To cmbProyecto.Properties.View.Columns.Count - 1
                    cmbProyecto.Properties.View.Columns(i).Visible = False
                Next

                cmbProyecto.Properties.View.Columns("ID").Caption = "ID"
                cmbProyecto.Properties.View.Columns("OPPORTUNITY_NAME").Caption = "Nombre"
                cmbProyecto.Properties.View.Columns("OBSERVATIONS").Caption = "Observaciones"
                cmbProyecto.Properties.View.Columns("CLIENT_NAME").Caption = "Cliente"

                cmbProyecto.Properties.View.Columns("ID").Visible = False
                cmbProyecto.Properties.View.Columns("OPPORTUNITY_NAME").Visible = True
                cmbProyecto.Properties.View.Columns("OBSERVATIONS").Visible = True
                cmbProyecto.Properties.View.Columns("CLIENT_NAME").Visible = True

                cmbProyecto.Properties.View.BestFitColumns()

            End If
        End If
    End Sub

    Private Sub cargarUbicaciones()
        'llenamos el combo de proyecto
        Dim i As Integer
        Dim dsLocations As DataSet
        dsLocations = xInventory.getExitLocations(UiListaBodega.EditValue, pResult, PublicLoginInfo.Environment)
        If pResult = "OK" Then
            If Not IsNothing(dsLocations) Then
                UiListaUbicacionDeSalida.Properties.DataSource = dsLocations.Tables(0)
            End If
        End If
    End Sub

    Private Sub UsuarioDeseaCargarBodegas()
        Dim webServiceInfoTrans As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Locations.asmx")
        Dim dtBodegas As DataTable = webServiceInfoTrans.GetAvailableWarehouseByUser(PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)
        UiListaBodega.Properties.ValueMember = "WAREHOUSE_ID"
        UiListaBodega.Properties.DisplayMember = "NAME"
        If pResult = "OK" Then
            UiListaBodega.Properties.DataSource = dtBodegas
        Else
            MsgBox(pResult)
        End If



    End Sub
    Private Sub fn_crea_tabla_tasks()
        Try
            Dim dcData As DataColumn
            Dim i As Int16

            For i = 0 To GridViewEgreso.Columns.Count - 1
                dcData = New DataColumn
                dcData.DataType = Type.GetType("System.String")
                dcData.ColumnName = GridViewEgreso.Columns(i).FieldName
                dtTasks.Columns.Add(dcData)
            Next

            dsTasks.Tables.Add(dtTasks)

            GridEgreso.DataSource = dtTasks
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub fn_llena_inventario(ByVal pCust As String)
        Try
            Cursor = Cursors.WaitCursor

            If barListaTipo.EditValue = "Proyecto" Then
                If IsNothing(cmbProyecto.EditValue) Then Return
            Else
                If pCust = "" Or pCust = "-1" Then
                    Return
                End If
            End If

            Dim dsInv As DataTable
            pResult = String.Empty
            If barListaTipo.EditValue = "Poliza" Then
                dsInv = xserv.GetPolicyWithAvailableInventory(UiListaBodega.EditValue, cmbClientes.EditValue, "GENERAL", pResult, PublicLoginInfo.Environment)
            ElseIf barListaTipo.EditValue = "Proyecto" Then
                If cmbProyecto.EditValue.ToString() = "" OrElse UiListaBodega.EditValue.ToString() = "" Then
                    Return
                End If
                dsInv = xInventory.getInventorybyProject(cmbProyecto.EditValue.ToString(), UiListaBodega.EditValue.ToString(), UiSwitchDiscrecionalProyecto.Checked, pResult, PublicLoginInfo.Environment).Tables(0)
            Else
                dsInv = xserv.GetInventoryGeneralByWarehouse(pCust, UiListaBodega.EditValue, barListaTipo.EditValue = "Discrecional", PublicLoginInfo.Environment, pResult)
            End If

            If pResult = "OK" Or String.IsNullOrEmpty(pResult) Then
                If Not IsNothing(dsInv) Then
                    If dsInv.Rows.Count > 0 Then
                        Select Case barListaTipo.EditValue
                            Case "General"
                                GridInventario.MainView = GridViewInventario
                            Case "Discrecional"
                                GridInventario.MainView = GridViewInvSku
                            Case "Poliza"
                                GridInventario.MainView = UiVistaPolizas
                            Case "Proyecto"
                                GridInventario.MainView = GridViewInventorybyProject
                        End Select
                        GridInventario.DataSource = dsInv
                    Else
                        GridInventario.DataSource = Nothing
                    End If
                Else
                    GridInventario.DataSource = Nothing
                End If

                Select Case barListaTipo.EditValue
                    Case "General"
                        GridViewInventario.BestFitColumns()
                    Case "Discrecional"
                        GridViewInvSku.BestFitColumns()
                    Case "Poliza"
                        UiVistaPolizas.BestFitColumns()
                    Case "Proyecto"
                        GridViewInventorybyProject.BestFitColumns()
                End Select

                dsInv.Dispose()

            Else
                MsgBox(pResult)
            End If
            'GridEgreso.DataSource = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnLeer_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Try
            If IsNothing(cmbClientes.EditValue) Then
                MsgBox("Debe seleccionar un cliente para ver su inventario")
            Else
                SaveGridLayout("GRID_EGRESO_GENERAL", PublicLoginInfo.LoginID, Me.GridViewInventario)
                SaveGridLayout("GRID_EGRESO_GENERAL_EGRESO", PublicLoginInfo.LoginID, Me.GridViewEgreso)
                fn_llena_inventario(cmbClientes.EditValue)
                LoadGridLayout("GRID_EGRESO_GENERAL", PublicLoginInfo.LoginID, Me.GridViewInventario)
                LoadGridLayout("GRID_EGRESO_GENERAL_EGRESO", PublicLoginInfo.LoginID, Me.GridViewEgreso)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAgregar_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub btnSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub
    Private Sub limpia_datos()
        Try
            cmbClientes.EditValue = Nothing
            cmbBodegueros.EditValue = Nothing
            UiListaBodega.EditValue = Nothing
            txtReferencia.Text = ""
            'dtFechaDocumento.EditValue = Date.Now
            GridEgreso.DataSource = Nothing
            GridInventario.DataSource = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridViewEgreso_ValidateRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridViewEgreso.ValidateRow
        Try
            'Dim view As GridView = CType(sender, GridView)
            'Dim inStockCol As GridColumn = view.Columns("UnitsInStock")'Dim onOrderCol As GridColumn = view.Columns("UnitsOnOrder")
            'Get the value of the first column
            'Dim inInv As Double = CType(GridViewEgreso.GetRowCellValue(e.RowHandle, "QUANTITY_ASSIGNED"), Double)
            ''Get the value of the second column
            'Dim inEg As Double = CType(GridViewEgreso.GetRowCellValue(e.RowHandle, "INVENTORY"), Double)
            ''Validity criterion
            'If inEg < inInv Then
            '    e.Valid = False
            '    'Set errors with specific descriptions for the columns
            '    GridViewEgreso.SetColumnError(colQUATITY_ASSIGNED, "no puede despachar mas de la existencia actual")

            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDel_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub UsuarioDeseaVisualizarProductosAEgresar()
        Try
            Dim cliente As String = ""
            If barListaTipo.EditValue = "Proyecto" Then
                If UiListaBodega.EditValue = "" Then Return
                cliente = Nothing
            Else
                If cmbClientes.EditValue = "" OrElse UiListaBodega.EditValue = "" Then
                    Return
                End If
                cliente = cmbClientes.EditValue.ToString
            End If

            Dim xct As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
            Dim dsCt = xct.GetClient_CommercialAggrements(cliente, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                If dsCt.Tables(0).Rows.Count > 0 Then
                    If IsNothing(cmbClientes.EditValue) And IsNothing(UiListaBodega.EditValue) Then
                        MsgBox("Debe seleccionar un cliente o bodega para ver su inventario")
                    Else
                        GridInventarioSkuDisp.DataSource = Nothing
                        SaveGridLayout("GRID_EGRESO_GENERAL", PublicLoginInfo.LoginID, Me.GridViewInventario)
                        SaveGridLayout("GRID_EGRESO_GENERAL_EGRESO", PublicLoginInfo.LoginID, Me.GridViewEgreso)
                        SaveGridLayout("GRID_EGRESO_INV_SKU", PublicLoginInfo.LoginID, Me.GridViewInvSku)
                        SaveGridLayout("GRID_EGRESO_INV_SKU_AVAILABLE", PublicLoginInfo.LoginID, Me.GridViewInvSkuDis)
                        SaveGridLayout("GRID_EGRESO_INVENTARIO_PROYECTO", PublicLoginInfo.LoginID, Me.GridViewInventorybyProject)

                        If barListaTipo.EditValue = "Proyecto" Then
                            fn_llena_inventario("0")
                        Else
                            fn_llena_inventario(cmbClientes.EditValue)
                        End If

                        LoadGridLayout("GRID_EGRESO_GENERAL", PublicLoginInfo.LoginID, Me.GridViewInventario)
                        LoadGridLayout("GRID_EGRESO_GENERAL_EGRESO", PublicLoginInfo.LoginID, Me.GridViewEgreso)
                        LoadGridLayout("GRID_EGRESO_INV_SKU", PublicLoginInfo.LoginID, Me.GridViewInvSku)
                        LoadGridLayout("GRID_EGRESO_INV_SKU_AVAILABLE", PublicLoginInfo.LoginID, Me.GridViewInvSkuDis)
                        LoadGridLayout("GRID_EGRESO_INVENTARIO_PROYECTO", PublicLoginInfo.LoginID, Me.GridViewInventorybyProject)
                    End If
                Else
                    MsgBox("El cliente no posee acuerdos comerciales")
                    cmbClientes.EditValue = Nothing
                End If
            Else
                If barListaTipo.EditValue = "Proyecto" Then
                    fn_llena_inventario("0")
                Else
                    MsgBox(pResult)
                    cmbClientes.EditValue = ""
                    cmbClientes.Text = ""
                End If
            End If
            MostrarBotonCargarPlantilla()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbClientes_EditValueChanged(sender As Object, e As EventArgs) Handles cmbClientes.EditValueChanged
        UsuarioDeseaLimpiarDatosDeOla()
        UsuarioDeseaVisualizarProductosAEgresar()
        cargarProyectos()
    End Sub

    Private Sub frmEgresoGeneral_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        SplitContainerControl1.SplitterPosition = Me.Width / 2
        SplitContainerControl2.SplitterPosition = Me.Height / 2.5
    End Sub

    Private Sub agregarInventarioProyectoAOlaPicking()

        Try
            Dim drRow As DataRow
            Dim dtRow As DataRow
            Dim qty As Double

            Dim cliente As DataRowView
            cliente = cmbProyecto.Properties.GetRowByKeyValue(cmbProyecto.EditValue)

            For index = 0 To GridViewInventorybyProject.SelectedRowsCount - 1
                dtRow = GridViewInventorybyProject.GetDataRow(GridViewInventorybyProject.GetSelectedRows()(index))
                If Double.TryParse(dtRow.Item("QTY_LICENSE").ToString, qty) Then
                    Dim CodeSkuAux As String = dtRow.Item("MATERIAL_ID").ToString + "/" + dtRow.Item("STATUS_CODE").ToString + "-"
                    If (CodeSku_.Contains(CodeSkuAux)) Then
                        MessageBox.Show("Ya se ha ingresado el producto: " + CodeSkuAux, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)


                    ElseIf qty <= 0 Then
                        NotifyStatus("El producto " + CodeSkuAux + " no tiene inventario disponible ", False, False)
                    Else
                        CodeSku_ = CodeSku_ + CodeSkuAux
                        drRow = dtTasks.NewRow

                        drRow.Item("TASK_OWNER") = PublicLoginInfo.LoginID
                        drRow.Item("TASK_ASSIGNEDTO") = cmbBodegueros.EditValue
                        drRow.Item("QUANTITY_ASSIGNED") = qty
                        drRow.Item("INVENTORY") = qty
                        drRow.Item("CODIGO_POLIZA_TARGET") = "0"
                        drRow.Item("MATERIAL_ID") = dtRow.Item("MATERIAL_ID")
                        drRow.Item("BARCODE_ID") = dtRow.Item("BARCODE_ID")
                        drRow.Item("ALTERNATE_BARCODE") = dtRow.Item("ALTERNATE_BARCODE")
                        drRow.Item("MATERIAL_NAME") = dtRow.Item("MATERIAL_NAME")
                        drRow.Item("CLIENT_OWNER") = cliente.Item("CUSTOMER_OWNER")
                        drRow.Item("CLIENT_NAME") = cliente.Item("CLIENT_NAME")
                        drRow.Item("grabo") = "NO"
                        drRow.Item("IS_MASTER_PACK") = 0
                        drRow.Item("PROJECT_ID") = cmbProyecto.EditValue
                        drRow.Item("PROJECT_NAME") = dtRow.Item("OPPORTUNITY_NAME")
                        drRow.Item("STATUS_CODE") = dtRow.Item("STATUS_CODE")
                        dtTasks.Rows.Add(drRow)

                        TabSkusCargados.TabPages.Item(1).PageVisible = False
                        TabSkusCargados.SelectedTabPage = SKUIngresados
                    End If
                End If

            Next

            If 0 < GridViewEgreso.DataRowCount Then
                cmbProyecto.Enabled = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub agregarSkuByProjectDiscretional()
        Dim drRow As DataRow
        Dim qty As Double
        Dim cliente As DataRowView
        cliente = cmbProyecto.Properties.GetRowByKeyValue(cmbProyecto.EditValue)

        Try
            If Double.TryParse(GridViewInventorybyProject.GetFocusedRowCellValue("QTY_LICENSE").ToString, qty) Then
                Dim CodeSkuAux As String

                CodeSkuAux = GridViewInventorybyProject.GetFocusedRowCellValue("LICENSE_ID").ToString() + "/" + GridViewInventorybyProject.GetFocusedRowCellValue("STATUS_CODE").ToString() + "/" + GridViewInventorybyProject.GetFocusedRowCellValue("MATERIAL_ID") + "-"
                If (CodeSku_.Contains(CodeSkuAux)) Then
                    MessageBox.Show("Ya se ha ingresado la licencia No: " + CodeSkuAux, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf qty <= 0 Then
                    NotifyStatus("La licencia " + CodeSkuAux + " no tiene inventario disponible ", False, False)

                Else
                    CodeSku_ = CodeSku_ + CodeSkuAux
                    drRow = dtTasks.NewRow
                    drRow.Item("TASK_OWNER") = PublicLoginInfo.LoginID
                    drRow.Item("TASK_ASSIGNEDTO") = cmbBodegueros.EditValue
                    drRow.Item("QUANTITY_ASSIGNED") = qty
                    drRow.Item("INVENTORY") = qty
                    drRow.Item("CODIGO_POLIZA_TARGET") = "0"
                    drRow.Item("MATERIAL_ID") = GridViewInventorybyProject.GetFocusedRowCellValue("MATERIAL_ID")
                    drRow.Item("BARCODE_ID") = GridViewInventorybyProject.GetFocusedRowCellValue("BARCODE_ID")
                    drRow.Item("ALTERNATE_BARCODE") = GridViewInventorybyProject.GetFocusedRowCellValue("ALTERNATE_BARCODE")
                    drRow.Item("MATERIAL_NAME") = GridViewInventorybyProject.GetFocusedRowCellValue("MATERIAL_NAME")
                    drRow.Item("CLIENT_OWNER") = cliente.Item("CUSTOMER_OWNER")
                    drRow.Item("CLIENT_NAME") = cliente.Item("CLIENT_NAME")
                    drRow.Item("LICENSE_ID") = GridViewInventorybyProject.GetFocusedRowCellValue("LICENSE_ID")
                    drRow.Item("BATCH") = GridViewInventorybyProject.GetFocusedRowCellValue("BATCH")
                    drRow.Item("DATE_EXPIRATION") = GridViewInventorybyProject.GetFocusedRowCellValue("DATE_EXPIRATION")
                    drRow.Item("grabo") = "NO"
                    drRow.Item("TONE") = IIf(IsDBNull(GridViewInventorybyProject.GetFocusedRowCellValue("TONE").ToString()), "", GridViewInventorybyProject.GetFocusedRowCellValue("TONE").ToString)
                    drRow.Item("CALIBER") = IIf(IsDBNull(GridViewInventorybyProject.GetFocusedRowCellValue("CALIBER").ToString()), "", GridViewInventorybyProject.GetFocusedRowCellValue("CALIBER").ToString)
                    drRow.Item("PROJECT_ID") = cliente.Item("ID")
                    drRow.Item("PROJECT_NAME") = cliente.Item("OPPORTUNITY_NAME")
                    drRow.Item("STATUS_CODE") = GridViewInventorybyProject.GetFocusedRowCellValue("STATUS_CODE")

                    dtTasks.Rows.Add(drRow)

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub agregarInventarioSinProyectoGeneral()
        Dim drRow As DataRow
        Dim dtRow As DataRow
        Dim qty As Double
        Try

            For index = 0 To GridViewInventario.SelectedRowsCount - 1
                dtRow = GridViewInventario.GetDataRow(GridViewInventario.GetSelectedRows()(index))
                If Double.TryParse(dtRow.Item("AVAILABLE").ToString, qty) Then
                    Dim CodeSkuAux As String = dtRow.Item("MATERIAL_ID") + "-"
                    qty = qty + Convert.ToDouble(dtRow.Item("CANTIDAD_MP"))
                    If (CodeSku_.Contains(CodeSkuAux)) Then
                        MessageBox.Show("Ya se ha ingresado el producto: " + CodeSkuAux, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)


                    ElseIf qty <= 0 Then
                        NotifyStatus("El producto " + CodeSkuAux + " no tiene inventario disponible ", False, False)
                    Else
                        Dim esMasterPack = dtRow.Item("IS_MASTER_PACK")

                        If esMasterPack = 1 Then
                            Dim pRes = ""
                            Dim available = xserv.CheckMasterPackInventory(dtRow.Item("MATERIAL_ID"), UiListaBodega.EditValue, pRes, PublicLoginInfo.Environment)

                            If available <= 0 Then
                                Dim dsSinInventario = New DataSet()
                                Dim dsDummy = New DataSet()
                                dsSinInventario.Tables.Add(New DataTable())
                                dsSinInventario.Tables(0).TableName = "MATERIAL_HEADER"

                                dsSinInventario.Tables(0).Columns.Add("MATERIAL_ID")
                                dsSinInventario.Tables(0).Columns.Add("QTY")
                                dsSinInventario.Tables(0).Columns.Add("AVAILABLE")
                                dsSinInventario.Tables(0).Columns.Add("QTY_NEEDED")
                                dsSinInventario.Tables(0).Columns.Add("IS_MASTER_PACK")

                                Dim row = dsSinInventario.Tables(0).NewRow()
                                row.Item("MATERIAL_ID") = dtRow.Item("MATERIAL_ID")
                                row.Item("QTY") = qty
                                row.Item("AVAILABLE") = available
                                row.Item("QTY_NEEDED") = available - qty
                                row.Item("IS_MASTER_PACK") = 1
                                dsSinInventario.Tables(0).Rows.Add(row)

                                Dim dt = xserv.GetInventoryNeededForMasterPack(dtRow.Item("MATERIAL_ID"), UiListaBodega.EditValue, qty, pRes, PublicLoginInfo.Environment)
                                dt.Columns(0).Caption = "Código Producto"
                                dt.Columns(0).ReadOnly = True
                                dt.Columns(1).Caption = "Cantidad"
                                dt.Columns(1).ReadOnly = True
                                dt.Columns(2).Caption = "Disponible"
                                dt.Columns(2).ReadOnly = True
                                dt.Columns(3).Caption = "Diferencia"
                                dt.Columns(3).ReadOnly = True
                                dt.Columns(4).Caption = "Código MasterPack"
                                dt.Columns(4).ReadOnly = True

                                dsDummy.Tables.Add(dt)
                                dsDummy.Tables(0).TableName = "MATERIAL_DETAIL"

                                dsSinInventario.Tables.Add(dsDummy.Tables(0).Copy())
                                Dim keyColumn As DataColumn = dsSinInventario.Tables("MATERIAL_HEADER").Columns("MATERIAL_ID")
                                Dim foreignKeyColumn As DataColumn = dsSinInventario.Tables("MATERIAL_DETAIL").Columns("MASTER_PACK_ID")

                                Try
                                    dsSinInventario.Relations.Add("Detalle de Componentes", keyColumn, foreignKeyColumn)
                                Catch ex As Exception
                                    NotifyStatus("ERROR EN DETALLE DE COMPONENTES: " & ex.Message, False, True)
                                End Try

                                GridControlSkuSinInventario.DataSource = dsSinInventario.Tables("MATERIAL_HEADER")

                                TabSkusCargados.TabPages.Item(1).PageVisible = True
                                TabSkusCargados.SelectedTabPage = SKUSinInventario
                                Return
                            End If
                        End If

                        CodeSku_ = CodeSku_ + CodeSkuAux
                        drRow = dtTasks.NewRow

                        drRow.Item("TASK_OWNER") = PublicLoginInfo.LoginID
                        drRow.Item("TASK_ASSIGNEDTO") = cmbBodegueros.EditValue
                        drRow.Item("QUANTITY_ASSIGNED") = qty
                        drRow.Item("INVENTORY") = qty
                        drRow.Item("CODIGO_POLIZA_TARGET") = "0"
                        drRow.Item("MATERIAL_ID") = dtRow.Item("MATERIAL_ID")
                        drRow.Item("BARCODE_ID") = dtRow.Item("BARCODE_ID")
                        drRow.Item("ALTERNATE_BARCODE") = dtRow.Item("ALTERNATE_BARCODE")
                        drRow.Item("MATERIAL_NAME") = dtRow.Item("MATERIAL_NAME")
                        drRow.Item("CLIENT_OWNER") = cmbClientes.EditValue
                        drRow.Item("CLIENT_NAME") = cmbClientes.Properties.GetDisplayTextByKeyValue(cmbClientes.EditValue)
                        drRow.Item("grabo") = "NO"
                        drRow.Item("IS_MASTER_PACK") = dtRow.Item("IS_MASTER_PACK")
                        drRow.Item("STATUS_CODE") = dtRow.Item("STATUS_CODE")
                        dtTasks.Rows.Add(drRow)

                        TabSkusCargados.TabPages.Item(1).PageVisible = False
                        TabSkusCargados.SelectedTabPage = SKUIngresados
                    End If
                End If

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAgrear_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAgrear.ItemClick
        Try
            If ValidarControles() Then

                If barListaTipo.EditValue = "Proyecto" And UiSwitchDiscrecionalProyecto.Checked = False Then
                    agregarInventarioProyectoAOlaPicking()
                ElseIf barListaTipo.EditValue = "Proyecto" And UiSwitchDiscrecionalProyecto.Checked = True Then
                    agregarSkuByProjectDiscretional()
                Else
                    agregarInventarioSinProyectoGeneral()
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub UpdateGridEgreso(ByVal pMaterialId As String, ByVal pInventory As Integer)
        Try
            For Each rw As DataRow In dtTasks.Rows
                If rw("MATERIAL_ID") = pMaterialId Then
                    rw("INVENTORY") = rw("INVENTORY") - pInventory
                End If
            Next
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEliminar.ItemClick
        Try
            If GridViewEgreso.GetFocusedRowCellValue("grabo") = "NO" Then

                If barListaTipo.EditValue = "Discrecional" Then
                    CodeSku_ = CodeSku_.Replace(GridViewEgreso.GetFocusedRowCellValue("LICENSE_ID") + "/" + GridViewEgreso.GetFocusedRowCellValue("MATERIAL_ID") + "-", "")
                Else
                    CodeSku_ = CodeSku_.Replace(GridViewEgreso.GetFocusedRowCellValue("MATERIAL_ID") + "-", "")
                End If


                GridViewEgreso.DeleteSelectedRows()
                dtTasks.AcceptChanges()
            Else
                NotifyStatus("No se puede borrar el registro", False, True)
            End If

            If barListaTipo.EditValue = "Proyecto" Then
                If GridViewEgreso.DataRowCount <= 0 Then
                    cmbProyecto.Enabled = True
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs)
        Try
            'Dim dd As Double = 0
            Dim i As Integer
            Dim WPI As Integer
            If IsNothing(cmbClientes.EditValue) Then
                MsgBox("Debe seleccionar un cliente")
                cmbClientes.Focus()
                Exit Sub
            End If

            If IsNothing(cmbBodegueros.EditValue) Then
                MsgBox("Debe selecccionar un bodeguero al que se le asignaran las tareas")
                cmbBodegueros.Focus()
                Exit Sub
            End If
            pResult = String.Empty

            xserv.set_Poliza_Header("", "", "", "", "", "", "", "", "", "", 0, Date.Now, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", 0, 0, 0, "0",
                                    PublicLoginInfo.LoginID, Date.Now, "CREATED", cmbClientes.EditValue.ToString, "GENERAL", Date.Now, "", "EGRESO", PublicLoginInfo.Environment, pResult, dd, "", "", "NO", Nothing)


            If pResult = "inserted" Or pResult = "updated" Then

                For i = 0 To GridViewEgreso.RowCount - 1
                    pResult = String.Empty

                    'xserv.set_General_Egreso(PublicLoginInfo.LoginID, cmbBodegueros.EditValue.ToString,
                    '                         GridViewEgreso.GetRowCellValue(i, "QUANTITY_ASSIGNED").ToString, dd.ToString, GridViewEgreso.GetRowCellValue(i, "MATERIAL_ID").ToString,
                    '                         GridViewEgreso.GetRowCellValue(i, "BARCODE_ID").ToString, GridViewEgreso.GetRowCellValue(i, "ALTERNATE_BARCODE").ToString,
                    '                        GridViewEgreso.GetRowCellValue(i, "MATERIAL_NAME").ToString, GridViewEgreso.GetRowCellValue(i, "CLIENT_OWNER").ToString,
                    '                        GridViewEgreso.GetRowCellValue(i, "CLIENT_NAME").ToString, PublicLoginInfo.Environment, pResult, WPI)
                    If Not pResult = "OK" Then
                        MsgBox(pResult)
                        Exit For
                    End If
                Next
                limpia_datos()
                fn_llena_combos()
            Else
                MsgBox(pResult)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridEgreso_KeyUp(sender As Object, e As KeyEventArgs) Handles GridEgreso.KeyUp
        'If e.KeyCode = Keys.Enter Then
        '    If GridViewEgreso.GetFocusedRowCellValue("grabo").ToString() = "NO" Then
        '        Dim inInv As Double = GridViewEgreso.GetFocusedRowCellValue("QUANTITY_ASSIGNED").ToString()
        '        Dim inEg As Double = GridViewEgreso.GetFocusedRowCellValue("INVENTORY").ToString()

        '        'If inEg <= inActualAux Then
        '        'inEg = inActualAux
        '        If inEg < inInv Then
        '            GridViewEgreso.SetColumnError(colQUATITY_ASSIGNED, String.Format("No puede despachar mas de la existencia actual({0})", inEg))
        '        ElseIf inInv <= 0 Then
        '            GridViewEgreso.SetColumnError(colQUATITY_ASSIGNED, String.Format("El despacho tiene que ser mayor a 0({0})", inEg))
        '        Else
        '            GridViewEgreso.SetColumnError(colQUATITY_ASSIGNED, "", errorType:=ErrorType.None)
        '            'Grabar()
        '            '   inActual = inEg - inInv
        '            '   inActualAux = inActual
        '        End If
        '        'Else
        '        '    GridViewEgreso.SetColumnError(colQUATITY_ASSIGNED, String.Format("El despacho tiene que ser mayor a 0({0})", inActual))
        '        'End If

        '    End If
        'End If
    End Sub

    Private Sub Grabar()
        If Not dd > 0 Then
            GrabarPolizaHeader()
        End If
        If pResultPoliza = "inserted" Or pResultPoliza = "updated" Then
            GrabarEgresoGeneral()
        End If
    End Sub

    Private Sub GrabarPolizaHeader()
        Try
            Dim clienteRow As DataRowView
            Dim cliente As String = Nothing
            clienteRow = cmbProyecto.Properties.GetRowByKeyValue(cmbProyecto.EditValue)
            If barListaTipo.EditValue = "Proyecto" Then
                If Not IsNothing(cmbProyecto.EditValue) Then
                    cliente = clienteRow.Item("CUSTOMER_OWNER")
                End If
            Else
                cliente = cmbClientes.EditValue.ToString()
            End If
            pResultPoliza = String.Empty
            xserv.set_Poliza_Header(txtReferencia.Text, "", "", "", "", "", "", "", "", "", 0, Date.Now, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", 0, 0, 0, "0",
                                        PublicLoginInfo.LoginID, Date.Now, "CREATED", cliente, "GENERAL", Date.Now, "", "EGRESO", PublicLoginInfo.Environment, pResultPoliza, dd, "", cmbBodegueros.EditValue, "NO", Nothing)

            If pResultPoliza = "inserted" Or pResultPoliza = "updated" Then
                txtPolizaG.Text = dd.ToString()
                txtReferencia.Properties.ReadOnly = True
                barFormTxtPoliza.EditValue = txtPolizaG.Text
                Exit Sub
            Else
                NotifyStatus(pResultPoliza, True, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub GrabarEgresoGeneral()
        Try
            If Not GridViewEgreso.ValidateEditor Then
                Return
            End If
            GridViewEgreso.PostEditor()

            If GridViewEgreso.DataRowCount <= 0 Then
                NotifyStatus("Debe de agregar productos para poder guardar la ola", True, True)
                Return
            End If
            Dim result As String = String.Empty
            Dim listaDeOperadores = New List(Of String)
            If barListaTipo.EditValue = "Discrecional" OrElse barListaTipo.EditValue = "Poliza" OrElse (barListaTipo.EditValue = "Proyecto" And UiSwitchDiscrecionalProyecto.Checked = True) Then

                For i As Integer = 0 To GridViewEgreso.DataRowCount - 1
                    Dim row As DataRow = GridViewEgreso.GetDataRow(i)

                    Dim project As String = row.Item("PROJECT_ID").ToString()
                    If project = "" Then project = Nothing

                    If row.Item("grabo").ToString() <> "SI" Then

                        listaDeOperadores.Add(row.Item("TASK_ASSIGNEDTO").ToString())
                        xserv.set_General_Egreso_DISCRETIONARY(PublicLoginInfo.LoginID, row.Item("TASK_ASSIGNEDTO").ToString(),
                                           row.Item("QUANTITY_ASSIGNED").ToString(), dd.ToString, row.Item("MATERIAL_ID").ToString(),
                                           row.Item("BARCODE_ID").ToString(), row.Item("ALTERNATE_BARCODE").ToString(),
                                           row.Item("MATERIAL_NAME").ToString(), row.Item("CLIENT_OWNER").ToString(),
                                           row.Item("CLIENT_NAME").ToString(), PublicLoginInfo.Environment, result, _olaPicking, row.Item("LICENSE_ID").ToString(),
                                           cmbMotivoDiscrecional.EditValue, IIf(row.Item("SERIAL").ToString() = "", Nothing, row.Item("SERIAL").ToString()),
                                           row.Item("TONE").ToString(), row.Item("CALIBER").ToString(), project, UbicacionSeleccionada)
                        If result <> "OK" Then
                            NotifyStatus(result, True, True)
                            Exit For
                        End If
                        CodeSku_ = CodeSku_.Replace(row.Item("LICENSE_ID").ToString() + "-", "")
                        GridViewEgreso.SetRowCellValue(i, "grabo", "SI")
                    End If

                Next

                '_olaPicking = 0
                btnOlaPicking.Caption = String.Format("Nueva Ola de Picking(Actual {0})", _olaPicking)
            Else
                Dim xml = CType(GridViewEgreso.DataSource, DataView)
                xml.Table.DataSet.DataSetName = "EGRESO"
                xml.Table.DataSet.Tables(0).TableName = "MATERIAL"

                If ValidarInventario(xml.Table.DataSet.GetXml()) Then
                    For i As Integer = 0 To GridViewEgreso.DataRowCount - 1
                        Dim row As DataRow = GridViewEgreso.GetDataRow(i)

                        TabSkusCargados.TabPages.Item(1).PageVisible = False
                        TabSkusCargados.SelectedTabPage = SKUIngresados
                        Dim project As String = row.Item("PROJECT_ID").ToString()
                        If project = "" Then project = Nothing

                        If row.Item("grabo").ToString() <> "SI" Then
                            listaDeOperadores.Add(row.Item("TASK_ASSIGNEDTO").ToString())
                            xserv.set_General_Egreso(PublicLoginInfo.LoginID, row.Item("TASK_ASSIGNEDTO").ToString(),
                                                     row.Item("QUANTITY_ASSIGNED").ToString(), dd.ToString, row.Item("MATERIAL_ID").ToString(),
                                                    row.Item("BARCODE_ID").ToString(), row.Item("ALTERNATE_BARCODE").ToString(),
                                                    row.Item("MATERIAL_NAME").ToString(), row.Item("CLIENT_OWNER").ToString(),
                                                    row.Item("CLIENT_NAME").ToString(), PublicLoginInfo.Environment, result, _olaPicking,
                                                    UiListaBodega.EditValue, IIf(UiSwitchEnviarErp.Checked, 1, 0), project, row.Item("STATUS_CODE").ToString(), UbicacionSeleccionada)
                            If result <> "OK" Then
                                NotifyStatus(result, True, True)
                                Exit For
                            End If
                            CodeSku_ = CodeSku_.Replace(row.Item("MATERIAL_ID").ToString() + "-", "")
                            GridViewEgreso.SetRowCellValue(i, "grabo", "SI")
                        End If
                    Next
                End If

                UiSwitchEnviarErp.Enabled = False
            End If
            UiBtnCargarPlantilla.Enabled = False
            btnOlaPicking.Caption = String.Format("Nueva Ola de Picking(Actual {0})", _olaPicking)
            EnviarTareasAApi(listaDeOperadores)
            GridViewEgreso.RefreshData()
            fn_llena_inventario(cmbClientes.EditValue)
            If barListaTipo.EditValue = "Discrecional" Then
                LlenarGridIventarioSkuDisponible()
            ElseIf barListaTipo.EditValue = "Proyecto" Then
                fn_llena_inventario("Proyecto")
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Function ValidarInventario(xmlDetalle As String) As Boolean
        Dim pRes As String = Nothing
        Dim ds = xserv.CheckGeneralExitInventory(xmlDetalle, UiListaBodega.EditValue, _olaPicking, pRes, PublicLoginInfo.Environment)
        If pRes <> "OK" Then
            NotifyStatus(pRes, False, True)
            Return False
        End If

        If (ds.Tables(0) IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0) Then
            ds.Tables(0).TableName = "MAESTRO"
            If (ds.Tables(1) IsNot Nothing AndAlso ds.Tables(1).Rows.Count > 0) Then
                ds.Tables(1).TableName = "COMPONENTES"

                ds.Tables(1).Columns(0).Caption = "Código Producto"
                ds.Tables(1).Columns(0).ReadOnly = True
                ds.Tables(1).Columns(1).Caption = "Cantidad"
                ds.Tables(1).Columns(1).ReadOnly = True
                ds.Tables(1).Columns(2).Caption = "Disponible"
                ds.Tables(1).Columns(2).ReadOnly = True
                ds.Tables(1).Columns(3).Caption = "Diferencia"
                ds.Tables(1).Columns(3).ReadOnly = True
                ds.Tables(1).Columns(4).Caption = "Código MasterPack"
                ds.Tables(1).Columns(4).ReadOnly = True

                Dim keyColumn As DataColumn = ds.Tables("MAESTRO").Columns("MATERIAL_ID")
                Dim foreignKeyColumn As DataColumn = ds.Tables("COMPONENTES").Columns("MASTER_PACK_ID")
                Try
                    ds.Relations.Add("Detalle de Componentes", keyColumn, foreignKeyColumn)
                Catch ex As Exception
                    NotifyStatus("ERROR EN DETALLE DE COMPONENTES: " & ex.Message, False, True)
                End Try
            End If
            GridControlSkuSinInventario.DataSource = ds.Tables("MAESTRO")

            TabSkusCargados.TabPages.Item(1).PageVisible = True
            TabSkusCargados.SelectedTabPage = SKUSinInventario

            NotifyStatus("No hay inventario disponible.", False, True)
            Return False
        Else
            Return True
        End If
    End Function

    Private Function ValidarControles() As Boolean
        Dim validar As Boolean = True

        If String.Compare(barListaTipo.EditValue, "Proyecto") Then
            dxError.SetError(cmbClientes, "", errorType:=ErrorType.None)

            If cmbClientes.EditValue = Nothing Or cmbClientes.EditValue = "-1" Then
                dxError.SetError(cmbClientes, "Seleccione un cliente")
                validar = False
                NotifyStatus("Seleccione un cliente", False, True)
            End If

        End If
        dxError.SetError(cmbBodegueros, "", errorType:=ErrorType.None)
        'dxError.SetError(dtFechaDocumento, "", errorType:=ErrorType.None)
        If cmbBodegueros.EditValue = Nothing Or cmbBodegueros.EditValue = "1" Then
            dxError.SetError(cmbBodegueros, "Seleccione un operador")
            validar = False
            NotifyStatus("Seleccione un operador", False, True)
        End If

        'If dtFechaDocumento.EditValue = Nothing Then
        '  dxError.SetError(dtFechaDocumento, "Ingrese la fecha de documento")
        '   validar = False
        'End If
        Return validar
    End Function

    Private Sub cmbClientes_Leave(sender As Object, e As EventArgs) Handles cmbClientes.Leave, cmbBodegueros.Leave, cmbMotivoDiscrecional.Leave
        dxError.SetError(sender, "", errorType:=ErrorType.None)
    End Sub

    Private Sub chekPickingDiscrecional_CheckedChanged(sender As Object, e As EventArgs)
        CambiarVistas()
    End Sub

    Private Sub CambiarVistas()
        Try
            Select Case barListaTipo.EditValue
                Case "General"
                    SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Panel1
                    cmbMotivoDiscrecional.Visible = False
                    lblMotivoD.Visible = False
                    barToolInv.Visible = True
                    barToolInvSku.Visible = False
                    cmbProyecto.Visible = False
                    lblProyecto.Visible = False
                    cmbClientes.Enabled = True
                    UiColProjectName.Visible = False
                    UiSwitchDiscrecionalProyecto.Visibility = BarItemVisibility.Never

                    colELICENSE_ID.Visible = False
                    colEBATCH.Visible = False
                    colEDATE_EXPIRATION.Visible = False
                    btnAgrear.Visibility = BarItemVisibility.Always
                    _UiBotonCargarLicencias.Visibility = BarItemVisibility.Never
                Case "Discrecional"
                    SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Both
                    cmbMotivoDiscrecional.Visible = True
                    lblMotivoD.Visible = True
                    barToolInv.Visible = False
                    barToolInvSku.Visible = True
                    colELICENSE_ID.Visible = True
                    colEBATCH.Visible = True
                    colEDATE_EXPIRATION.Visible = True
                    cmbProyecto.Visible = False
                    lblProyecto.Visible = False
                    cmbClientes.Enabled = True
                    UiSwitchDiscrecionalProyecto.Visibility = BarItemVisibility.Never
                Case "Poliza"
                    SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Panel1
                    cmbMotivoDiscrecional.Visible = False
                    lblMotivoD.Visible = False
                    barToolInv.Visible = True
                    barToolInvSku.Visible = False
                    cmbProyecto.Visible = False
                    lblProyecto.Visible = False
                    cmbClientes.Enabled = True
                    UiColProjectName.Visible = False
                    UiSwitchDiscrecionalProyecto.Visibility = BarItemVisibility.Never
                    colELICENSE_ID.Visible = False
                    colEBATCH.Visible = False
                    colEDATE_EXPIRATION.Visible = False
                    btnAgrear.Visibility = BarItemVisibility.Never
                    _UiBotonCargarLicencias.Visibility = BarItemVisibility.Always
                Case "Proyecto"
                    SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Panel1
                    barToolInv.Visible = True
                    cmbProyecto.Visible = True
                    lblProyecto.Visible = True
                    cmbProyecto.Enabled = True
                    cmbMotivoDiscrecional.Visible = False
                    lblMotivoD.Visible = False
                    cmbClientes.Enabled = False
                    UiColProjectName.Visible = True
                    ''NO SE MUESTRAN AL INICIO
                    UiColLICENSE_ID.Visible = False
                    UiColDATE_EXPIRATION.Visible = False
                    UiColBATCH.Visible = False
                    UiColTONE.Visible = False
                    UiColCALIBER.Visible = False
                    UiSwitchDiscrecionalProyecto.Checked = False
                    UiSwitchDiscrecionalProyecto.Visibility = BarItemVisibility.Always

                    colELICENSE_ID.Visible = False
                    colEBATCH.Visible = False
                    colEDATE_EXPIRATION.Visible = False
                    btnAgrear.Visibility = BarItemVisibility.Always
                    _UiBotonCargarLicencias.Visibility = BarItemVisibility.Never
            End Select

            UsuarioDeseaLimpiarDatosDeOla()
            UsuarioDeseaVisualizarProductosAEgresar()
            dtTasks.Clear()

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LlenarGridIventarioSkuDisponible()
        Try
            If barListaTipo.EditValue = "Discrecional" Then
                '  MessageBox.Show("InventarioDisponible")
                If GridViewInvSku.FocusedRowHandle < 0 Then
                    Return
                End If
                Dim xdatarow As DataRow = GridViewInvSku.GetDataRow(GridViewInvSku.FocusedRowHandle)
                Dim codeMaterial As String = xdatarow("MATERIAL_ID").ToString
                GridInventarioSkuDisp.MainView = GridViewInvSkuDis
                'GridInventarioSkuDisp.DataMember = "get_general_inventory_by_sku"
                Dim dsInv As DataTable
                pResult = String.Empty
                dsInv = xserv.get_general_inventory_by_sku(codeMaterial, UiListaBodega.EditValue, PublicLoginInfo.Environment, pResult)

                If pResult = "OK" Then
                    If dsInv.Rows.Count > 0 Then
                        If dsInv.Rows.Count > 0 Then
                            GridInventarioSkuDisp.DataSource = dsInv
                        Else
                            GridInventarioSkuDisp.DataSource = Nothing
                        End If
                    Else
                        GridInventarioSkuDisp.DataSource = Nothing
                    End If
                Else
                    GridInventarioSkuDisp.DataSource = Nothing
                    NotifyStatus(pResult, False, True)
                End If

                GridViewInvSkuDis.BestFitColumns()

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub GridInventario_Click(sender As Object, e As EventArgs) Handles GridInventario.Click
        Try
            LlenarGridIventarioSkuDisponible()
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnAgregarSku_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAgregarSku.ItemClick
        If ValidarControles() Then
            Dim drRow As DataRow
            Dim qty As Double
            If cmbMotivoDiscrecional.EditValue = Nothing Or cmbMotivoDiscrecional.EditValue = "1" Then
                dxError.SetError(cmbMotivoDiscrecional, "Seleccione un motivo")
                NotifyStatus("Seleccione un motivo", False, True)
                Return
            End If
            If GridViewInvSkuDis.FocusedRowHandle < 0 Then
                Return
            End If


            If Double.TryParse(GridViewInvSkuDis.GetFocusedRowCellValue("AVAILABLE").ToString, qty) Then
                ' MessageBox.Show("Cargando")
                Dim CodeSkuAux As String

                CodeSkuAux = GridViewInvSkuDis.GetFocusedRowCellValue("LICENSE_ID").ToString() + "/" + GridViewInvSkuDis.GetFocusedRowCellValue("MATERIAL_ID") + "/" + IIf(IsDBNull(GridViewInvSkuDis.GetFocusedRowCellValue("SERIAL").ToString()), "", GridViewInvSkuDis.GetFocusedRowCellValue("SERIAL").ToString) + "-"
                If (CodeSku_.Contains(CodeSkuAux)) Then
                    MessageBox.Show("Ya se ha ingresado la licencia No: " + CodeSkuAux, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf qty <= 0 Then
                    NotifyStatus("La licencia " + CodeSkuAux + " no tiene inventario disponible ", False, False)

                Else
                    CodeSku_ = CodeSku_ + CodeSkuAux
                    drRow = dtTasks.NewRow
                    drRow.Item("TASK_OWNER") = PublicLoginInfo.LoginID
                    drRow.Item("TASK_ASSIGNEDTO") = cmbBodegueros.EditValue
                    drRow.Item("QUANTITY_ASSIGNED") = qty
                    drRow.Item("INVENTORY") = qty
                    drRow.Item("CODIGO_POLIZA_TARGET") = "0"
                    drRow.Item("MATERIAL_ID") = GridViewInvSkuDis.GetFocusedRowCellValue("MATERIAL_ID")
                    drRow.Item("BARCODE_ID") = GridViewInvSkuDis.GetFocusedRowCellValue("BARCODE_ID")
                    drRow.Item("ALTERNATE_BARCODE") = GridViewInvSkuDis.GetFocusedRowCellValue("ALTERNATE_BARCODE")
                    drRow.Item("MATERIAL_NAME") = GridViewInvSkuDis.GetFocusedRowCellValue("MATERIAL_NAME")
                    drRow.Item("CLIENT_OWNER") = cmbClientes.EditValue
                    drRow.Item("CLIENT_NAME") = cmbClientes.Properties.GetDisplayTextByKeyValue(cmbClientes.EditValue)
                    drRow.Item("LICENSE_ID") = GridViewInvSkuDis.GetFocusedRowCellValue("LICENSE_ID")
                    drRow.Item("BATCH") = GridViewInvSkuDis.GetFocusedRowCellValue("BATCH")
                    drRow.Item("DATE_EXPIRATION") = GridViewInvSkuDis.GetFocusedRowCellValue("DATE_EXPIRATION")
                    drRow.Item("grabo") = "NO"
                    drRow.Item("SERIAL") = IIf(IsDBNull(GridViewInvSkuDis.GetFocusedRowCellValue("SERIAL").ToString()), "", GridViewInvSkuDis.GetFocusedRowCellValue("SERIAL").ToString)
                    drRow.Item("TONE") = IIf(IsDBNull(GridViewInvSkuDis.GetFocusedRowCellValue("TONE").ToString()), "", GridViewInvSkuDis.GetFocusedRowCellValue("TONE").ToString)
                    drRow.Item("CALIBER") = IIf(IsDBNull(GridViewInvSkuDis.GetFocusedRowCellValue("CALIBER").ToString()), "", GridViewInvSkuDis.GetFocusedRowCellValue("CALIBER").ToString)
                    drRow.Item("STATUS_CODE") = GridViewInvSkuDis.GetFocusedRowCellValue("STATUS_CODE")

                    dtTasks.Rows.Add(drRow)

                End If
            End If
        End If
    End Sub

    Private Sub barFormBtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barFormBtnPrint.ItemClick
        If Not barFormTxtPoliza.EditValue Is Nothing Then
            If Not String.IsNullOrEmpty(barFormTxtPoliza.EditValue) Then
                Print(barFormTxtPoliza.EditValue.ToString())
            End If
        End If
    End Sub

    Private Sub Print(ByVal pCodigoPoliza As String)
        Try
            Dim rptPolEgreso As New rptPolizaEgreso
            'Dim frS As New xrptSalida
            Dim dt As DataSet
            Dim result As String = String.Empty
            Dim serverInfoTrans As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
            dt = serverInfoTrans.GetRepPolizaEgreso(pCodigoPoliza, result, PublicLoginInfo.Environment)

            If result = "OK" Then
                rptPolEgreso.DataMember = "repPolEgreso"
                rptPolEgreso.DataSource = dt
                rptPolEgreso.RequestParameters = False
                rptPolEgreso.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                rptPolEgreso.ShowPreview()
            Else
                MsgBox(result)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub barFormBtnRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barFormBtnRefresh.ItemClick
        UsuarioDeseaVisualizarProductosAEgresar()
    End Sub

    Private Sub btnOlaPicking_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOlaPicking.ItemClick
        UsuarioDeseaLimpiarDatosDeOla()
    End Sub

    Private Sub UsuarioDeseaLimpiarDatosDeOla()
        _olaPicking = 0
        btnOlaPicking.Caption = String.Format("Nueva Ola de Picking(Actual {0})", _olaPicking)
        dtTasks.Clear()
        CodeSku_ = String.Empty
        UiSwitchEnviarErp.Enabled = True
        TabSkusCargados.TabPages.Item(1).PageVisible = False
        TabSkusCargados.SelectedTabPage = SKUIngresados
        cmbProyecto.Enabled = True
        txtReferencia.Text = ""
        txtPolizaG.Text = ""
        dd = 0
        txtReferencia.Properties.ReadOnly = False
        UiListaUbicacionDeSalida.EditValue = Nothing
    End Sub

    Private Sub GridEgreso_Click(sender As Object, e As EventArgs) Handles GridEgreso.Click

    End Sub

    Private Sub UiBotonGrabar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonGrabar.ItemClick

        Dim clientMobileIsAndroid = xSecurity.GetParameterValue("", PublicLoginInfo.Environment, Enums.GetStringValue(GrupoParametro.ValidateLocation), Enums.GetStringValue(IdParametro.UseExitLocation))

        If clientMobileIsAndroid IsNot Nothing And clientMobileIsAndroid.Equals("1") And UiListaUbicacionDeSalida.EditValue = Nothing Then
            dxError.SetError(UiListaUbicacionDeSalida, "Seleccione ubicación de salida")

            NotifyStatus("Seleccione ubicación de salida", False, True)
            Return
        End If
        Grabar()
    End Sub

    Private Sub UiListaBodega_EditValueChanged(sender As Object, e As EventArgs) Handles UiListaBodega.EditValueChanged
        UsuarioDeseaLimpiarDatosDeOla()
        If barListaTipo.EditValue = "Proyecto" Then
            fn_llena_inventario("0")
        Else
            UsuarioDeseaVisualizarProductosAEgresar()
        End If
    End Sub

    Private Sub GridViewEgreso_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridViewEgreso.ValidatingEditor
        Dim inInv As Double
        Dim inEg As Double
        Dim view As GridView = sender

        If view IsNot Nothing And view.FocusedColumn.FieldName = "QUANTITY_ASSIGNED" Then

            Dim Row = view.GetDataRow(view.FocusedRowHandle)
            If e.Value = Nothing Then
                Return
            End If
            inInv = e.Value.ToString()
            inEg = Row.Item("INVENTORY").ToString()
            If inEg < inInv Then
                GridViewEgreso.SetColumnError(colQUATITY_ASSIGNED, String.Format("No puede despachar mas de la existencia actual({0})", inEg))
                e.Valid = False
                e.ErrorText = "Cantidad inválida."
            ElseIf inInv <= 0 Then
                GridViewEgreso.SetColumnError(colQUATITY_ASSIGNED, String.Format("El despacho tiene que ser mayor a 0({0})", inEg))
                e.Valid = False
                e.ErrorText = "Cantidad inválida."
            Else
                GridViewEgreso.SetColumnError(colQUATITY_ASSIGNED, "", errorType:=ErrorType.None)
            End If
        End If
    End Sub
    Sub EnviarTareasAApi(listaDeOperadores As List(Of String))
        Try
            listaDeOperadores = listaDeOperadores.Distinct().ToList()
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
    Private Function SeEnvianTareasAlApi() As Boolean
        Dim securityService = xSecurity
        Dim clientMobileIsAndroid = securityService.GetParameterValue("", PublicLoginInfo.Environment, Enums.GetStringValue(GrupoParametro.Sistema), Enums.GetStringValue(IdParametro.TipoDeClienteMovilDe3Pl))
        If String.IsNullOrEmpty(clientMobileIsAndroid) Then
            Return False
        Else
            Return (Convert.ToInt16(clientMobileIsAndroid)) = 1
        End If
    End Function

    Private Sub UiBotonCambiarA_SelectedIndexChanged(sender As Object, e As EventArgs)
        CambiarVistas()
    End Sub

    Private Sub UiBotonCargarLicencias_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonCargarLicencias.ItemClick
        CargarInventarioDePoliza()
    End Sub

    Private Sub CargarInventarioDePoliza()
        Try
            If IsNothing(cmbBodegueros.EditValue) Or cmbBodegueros.EditValue = "1" Then
                NotifyStatus("Debe seleccionar un operador." + pResult, True, True)
                Return
            End If



            dtTasks.Rows.Clear()
            Dim fila = UiVistaPolizas.GetDataRow(UiVistaPolizas.FocusedRowHandle)

            Dim dt = xserv.GetInventoryByPolicy(fila("CODIGO_POLIZA"), pResult, PublicLoginInfo.Environment)

            If String.IsNullOrEmpty(pResult) Then

                For Each filaAgregar As DataRow In dt.Rows

                    Dim drRow As DataRow
                    drRow = dtTasks.NewRow
                    drRow.Item("TASK_OWNER") = PublicLoginInfo.LoginID
                    drRow.Item("TASK_ASSIGNEDTO") = cmbBodegueros.EditValue
                    drRow.Item("QUANTITY_ASSIGNED") = filaAgregar("QTY_DISPATCH")
                    drRow.Item("INVENTORY") = filaAgregar("QTY_AVAILABLE")
                    drRow.Item("CODIGO_POLIZA_TARGET") = "0"
                    drRow.Item("MATERIAL_ID") = filaAgregar("MATERIAL_ID")
                    drRow.Item("BARCODE_ID") = filaAgregar("BARCODE_ID")
                    drRow.Item("ALTERNATE_BARCODE") = filaAgregar("ALTERNATE_BARCODE")
                    drRow.Item("MATERIAL_NAME") = filaAgregar("MATERIAL_NAME")
                    drRow.Item("CLIENT_OWNER") = cmbClientes.EditValue
                    drRow.Item("CLIENT_NAME") = cmbClientes.Properties.GetDisplayTextByKeyValue(cmbClientes.EditValue)
                    drRow.Item("LICENSE_ID") = filaAgregar("LICENSE_ID")
                    drRow.Item("BATCH") = filaAgregar("BATCH")
                    drRow.Item("DATE_EXPIRATION") = filaAgregar("DATE_EXPIRATION")
                    drRow.Item("grabo") = "NO"
                    drRow.Item("SERIAL") = ""
                    drRow.Item("TONE") = filaAgregar("TONE")
                    drRow.Item("CALIBER") = filaAgregar("CALIBER")

                    dtTasks.Rows.Add(drRow)
                Next


            Else
                NotifyStatus("Error al cargar el inventario: " + pResult, True, True)
            End If


        Catch ex As Exception
            NotifyStatus("Error al cargar el inventario: " + ex.Message, True, True)
        End Try
    End Sub

    Private Sub barListaTipo_EditValueChanged(sender As Object, e As EventArgs) Handles barListaTipo.EditValueChanged
        Try
            CambiarVistas()
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub cmbProyecto_EditValueChanged(sender As Object, e As EventArgs) Handles cmbProyecto.EditValueChanged
        If UiListaBodega.EditValue = "" Then
            NotifyStatus("Seleccione la bodega.", False, True)
            Return
        End If
        fn_llena_inventario("0")
    End Sub

    Private Sub UiSwitchDiscrecionalProyecto_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles UiSwitchDiscrecionalProyecto.CheckedChanged

        If UiSwitchDiscrecionalProyecto.Checked Then
            Console.WriteLine("Switch Discrecional")
            ''SE MUESTRAN LAS COLUMNAS
            UiColLICENSE_ID.Visible = True
            UiColDATE_EXPIRATION.Visible = True
            UiColBATCH.Visible = True
            UiColTONE.Visible = True
            UiColCALIBER.Visible = True
            fn_llena_inventario("Proyecto")
            dtTasks.Clear()
        Else
            Console.WriteLine("Switch General")
            ''NO SE MUESTRAN LAS COLUMNAS
            UiColLICENSE_ID.Visible = False
            UiColDATE_EXPIRATION.Visible = False
            UiColBATCH.Visible = False
            UiColTONE.Visible = False
            UiColCALIBER.Visible = False
            fn_llena_inventario("Proyecto")
            dtTasks.Clear()
        End If

    End Sub

    Private Sub cmbProyecto_Properties_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cmbProyecto.Properties.ButtonClick
        Try
            If e.Button.Tag = Nothing Then
                Return
            End If
            If e.Button.Tag = "uiRefrescarInventario" Then
                cargarProyectos()
            End If
        Catch ex As Exception
            NotifyStatus("Error al cargar proyectos: " + ex.Message, False, True)
        End Try
    End Sub

    Private Sub UiBtnDescargarPlantilla_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBtnDescargarPlantilla.ItemClick
        DescargarPlantilla()
    End Sub

    Private Sub UiBtnCargarPlantilla_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBtnCargarPlantilla.ItemClick
        CargarPlantilla()
    End Sub

    Sub DescargarPlantilla()
        Try
            Dim dialogoGuardar As New SaveFileDialog()
            dialogoGuardar.Filter = "Excel xlsx (*.xlsx)|*.xlsx"
            dialogoGuardar.FilterIndex = 2
            dialogoGuardar.RestoreDirectory = True
            dialogoGuardar.Title = "Guardar plantilla"

            If dialogoGuardar.ShowDialog() = DialogResult.OK Then
                Dim path As String = dialogoGuardar.FileName

                Dim workbook = New XLWorkbook()
                Dim hojaDeMaterial As IXLWorksheet = workbook.Worksheets.Add("Material")

                Dim inicioEncabezadoX As Integer = 1
                Dim inicioEncabezadoY As Integer = 1
                Dim numeroDeFilas As Integer = 500

                GenerarHojaDeDatosGenerales(hojaDeMaterial, inicioEncabezadoX, inicioEncabezadoY, numeroDeFilas)
                'Guardar Excel
                If (File.Exists(path)) Then
                    System.IO.File.Delete(path)
                End If
                workbook.SaveAs(path)

                ' Abrir excel
                Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs()
                args.AutoCloseOptions.Delay = 3000
                args.Caption = "Operación exitosa"
                args.Text = "Archivo generado exitósamente, ¿Desea abrir el archivo?"
                args.Buttons = {DialogResult.Yes, DialogResult.No}
                args.Icon = System.Drawing.SystemIcons.Question
                args.DefaultButtonIndex = 0
                args.AutoCloseOptions.ShowTimerOnDefaultButton = True

                If (XtraMessageBox.Show(args) = DialogResult.Yes) Then
                    Process.Start(path)
                End If

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub GenerarHojaDeDatosGenerales(hojaDeMaterial As IXLWorksheet, inicioEncabezadoX As Integer, inicioEncabezadoY As Integer, numeroDeFilas As Integer)
        Try

            Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")

            Dim xdataset As New DataSet
            Dim pResult As String = ""
            xdataset = xserv.GetParam_PartialSearch("ESTADOS", pResult, PublicLoginInfo.Environment)

            Dim columnas = New String() {"Codigo", "Estado", "Cantidad"}

            'Encabezado Tabla
            For j = 0 To columnas.Count - 1
                hojaDeMaterial.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Value = columnas(j)
                hojaDeMaterial.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Font.Bold = True
                hojaDeMaterial.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Fill.BackgroundColor = XLColor.BabyBlueEyes
                hojaDeMaterial.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                hojaDeMaterial.Column(j + 1).Width = (columnas(j).Length * 2)
            Next

            'Se agregan los valores para la validacion de UnidadPeso
            Dim listaDeEstados = xdataset.Tables(0)
            For x As Integer = 0 To listaDeEstados.Rows.Count - 1
                hojaDeMaterial.Cell("BX" + (x + 1).ToString()).Value = listaDeEstados.Rows(x)("PARAM_NAME")
            Next

            'Validacion de datos
            'Codigo
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).Value = ""
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 50)
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un máximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un máximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Estado
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).Value = ""
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = True
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = True
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.List
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().List(hojaDeMaterial.Range("BX1:BX" + listaDeEstados.Rows.Count.ToString()))
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe seleccionar una opcion."
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe seleccionar una opcion."
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Cantidad
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).Value = ""
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 25)
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un máximo de 25 caracteres."
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un máximo de 25 caracteres."
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Convertir en tabla de excel
            Dim rngTable As IXLRange = hojaDeMaterial.Range(
                hojaDeMaterial.Cell(inicioEncabezadoX, inicioEncabezadoY),
                hojaDeMaterial.Cell(inicioEncabezadoX + (numeroDeFilas - 1), inicioEncabezadoY + columnas.Count - 1))
            Dim excelTable = rngTable.CreateTable("Material")
            excelTable.ShowAutoFilter = False
        Catch ex As Exception
            Throw New Exception("Error al formar hoja de DatosGenerales:" + ex.Message)
        End Try
    End Sub

    Sub CargarPlantilla()
        Try
            If UiListaBodega.EditValue Is Nothing Then
                NotifyStatus("Debe seleccionar bodega", False, True)
                Exit Sub
            End If
            If cmbClientes.EditValue Is Nothing Then
                NotifyStatus("Debe seleccionar cliente", False, True)
                Exit Sub
            End If
            If barListaTipo.EditValue Is Nothing Or Not barListaTipo.EditValue = "General" Then
                NotifyStatus("Solo puede cargar plantilla para picking general", False, True)
                Exit Sub
            End If
            dxError.SetError(cmbBodegueros, "", errorType:=ErrorType.None)
            If cmbBodegueros.EditValue = Nothing Or cmbBodegueros.EditValue = "1" Then
                dxError.SetError(cmbBodegueros, "Seleccione un operador")
                NotifyStatus("Seleccione un operador", False, True)
                Exit Sub
            End If
            Dim dialogo As New OpenFileDialog()
            dialogo.Filter = "Excel xlsx (*.xlsx)|*.xlsx"
            dialogo.FilterIndex = 2
            dialogo.RestoreDirectory = True
            dialogo.Title = "Cargar plantilla"

            If dialogo.ShowDialog() = DialogResult.OK Then
                Dim workbook = New XLWorkbook(dialogo.FileName)
                Dim hojaDeMaterial
                Dim existeHojaDeMaterial

                existeHojaDeMaterial = workbook.TryGetWorksheet("Material", hojaDeMaterial)

                If existeHojaDeMaterial Then
                    'GridViewInventario
                    ValidarMaterialesExcel(hojaDeMaterial)
                End If

                Dim pResult As String = ""


                'If pResult = "OK" Then
                '    FilListView(True)
                '    ClearBag_Materials()
                '    NuevoEmpaque()
                '    GridControl2.DataSource = Nothing
                '    XtraTabControl1.SelectedTabPage = UiTabDatosGenerales
                '    NotifyStatus("Carga realizada con éxito", True, False)
                'Else
                '    Dim listaDeErrores(xdata.Tables(1).Rows.Count) As String
                '    For i As Integer = 0 To xdata.Tables(1).Rows.Count - 1
                '        listaDeErrores(i) = ("En la hoja de " + xdata.Tables(1).Rows(i)(1).ToString() + " linea " + (xdata.Tables(1).Rows(i)(2) + 1).ToString() + ": " + xdata.Tables(1).Rows(i)(3).ToString())
                '    Next
                '    If xdata.Tables(1).Rows.Count = 0 Then
                '        NotifyStatus(pResult, False, True)
                '    Else
                '        Dim popup As New popupList("Listado de Errores", listaDeErrores)
                '        popup.ShowDialog()
                '    End If

                'End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub


    Private Sub ValidarMaterialesExcel(hoja As IXLWorksheet)
        Dim drRow As DataRow
        Dim materialesParaInsertar As New DataTable
        Dim tabla = hoja.Table("Material")
        Dim esPrimeraFila As Boolean = True
        Dim qty As Double
        Dim qtyExcel As Double
        Dim lineaExcel As Integer = 1
        Dim listaErrores As ArrayList = New ArrayList()
        Dim objInventario As DataTable = GridInventario.DataSource
        Dim objInventarioAsignado As DataTable = GridEgreso.DataSource
        Dim dcData As DataColumn
        Dim i As Int16

        For i = 0 To GridViewEgreso.Columns.Count - 1
            dcData = New DataColumn
            dcData.DataType = Type.GetType("System.String")
            dcData.ColumnName = GridViewEgreso.Columns(i).FieldName
            materialesParaInsertar.Columns.Add(dcData)
        Next

        For Each fila In tabla.Rows
            Try
                If esPrimeraFila = False Then
                    If fila.Cell(1).Value.ToString() <> "" And fila.Cell(2).Value.ToString() <> "" And fila.Cell(3).Value.ToString() <> "" Then
                        Dim material As String = fila.Cell(1).Value.ToString()
                        Dim estado As String = fila.Cell(2).Value.ToString()
                        Dim cantidad As String = fila.Cell(3).Value.ToString()
                        If Double.TryParse(cantidad.ToString, qtyExcel) Then
                            'GridViewInventario
                            Dim strWhere As String = "MATERIAL_ID ='" + material + "' and STATUS_CODE ='" + estado + "'"
                            Dim search As DataRow() = objInventario.Select(strWhere)
                            If search IsNot Nothing And search.Length > 0 Then
                                Dim dtRow As DataRow = search(0)
                                If Double.TryParse(dtRow.Item("AVAILABLE").ToString, qty) Then
                                    Dim CodeSkuAux As String = dtRow.Item("MATERIAL_ID") + "-"
                                    Dim searchMaterial As DataRow() = materialesParaInsertar.Select(strWhere)
                                    qty = qty + Convert.ToDouble(dtRow.Item("CANTIDAD_MP"))
                                    If (CodeSku_.Contains(CodeSkuAux)) Then
                                        listaErrores.Add("Error en línea " + lineaExcel.ToString() + ": " + "Ya se ha ingresado el producto: " + CodeSkuAux)
                                    ElseIf qty <= 0 Then
                                        listaErrores.Add("Error en línea " + lineaExcel.ToString() + ": " + "El producto " + CodeSkuAux + " no tiene inventario disponible ")
                                    ElseIf qtyExcel > qty Then
                                        listaErrores.Add("Error en línea " + lineaExcel.ToString() + ": " + "Cantidad en archivo sobrepasa al inventario disponible para el producto " + CodeSkuAux)
                                    Else
                                        If searchMaterial IsNot Nothing And searchMaterial.Length > 0 Then
                                            Dim filaEncontrada As DataRow = searchMaterial(0)
                                            'si agregamos previamente la fila solo sumamos cantidades
                                            'tambien verificamos que la suma no sobrepase lo disponible
                                            Dim qtyTotalEnArchivo = qtyExcel + filaEncontrada.Item("QUANTITY_ASSIGNED")
                                            If qtyTotalEnArchivo <= qty Then
                                                'actualizamos la fila
                                                filaEncontrada.Item("QUANTITY_ASSIGNED") = qtyTotalEnArchivo
                                                filaEncontrada.Item("INVENTORY") = qtyTotalEnArchivo
                                            Else
                                                'marcamos error porque la fila que intentamos agregar sobrepasa el inventario disponible
                                                listaErrores.Add("Error en línea " + lineaExcel.ToString() + ": " + "El producto " + CodeSkuAux + " no tiene inventario disponible ")
                                            End If
                                        Else
                                            'cuando es la primera vez que lo encontramos lo agregamos al list de materiales procesados exitosamente
                                            drRow = materialesParaInsertar.NewRow

                                            drRow.Item("TASK_OWNER") = PublicLoginInfo.LoginID
                                            drRow.Item("TASK_ASSIGNEDTO") = cmbBodegueros.EditValue
                                            drRow.Item("QUANTITY_ASSIGNED") = qtyExcel
                                            drRow.Item("INVENTORY") = qtyExcel
                                            drRow.Item("CODIGO_POLIZA_TARGET") = "0"
                                            drRow.Item("MATERIAL_ID") = dtRow.Item("MATERIAL_ID")
                                            drRow.Item("BARCODE_ID") = dtRow.Item("BARCODE_ID")
                                            drRow.Item("ALTERNATE_BARCODE") = dtRow.Item("ALTERNATE_BARCODE")
                                            drRow.Item("MATERIAL_NAME") = dtRow.Item("MATERIAL_NAME")
                                            drRow.Item("CLIENT_OWNER") = cmbClientes.EditValue
                                            drRow.Item("CLIENT_NAME") = cmbClientes.Properties.GetDisplayTextByKeyValue(cmbClientes.EditValue)
                                            drRow.Item("grabo") = "NO"
                                            drRow.Item("IS_MASTER_PACK") = dtRow.Item("IS_MASTER_PACK")
                                            drRow.Item("STATUS_CODE") = dtRow.Item("STATUS_CODE")
                                            materialesParaInsertar.Rows.Add(drRow)

                                            TabSkusCargados.TabPages.Item(1).PageVisible = False
                                            TabSkusCargados.SelectedTabPage = SKUIngresados
                                        End If

                                    End If
                                Else
                                    listaErrores.Add("Error en línea " + lineaExcel.ToString() + ": La cantidad DISPONIBLE solo puede contener números.")
                                End If
                            Else
                                listaErrores.Add("Error en línea " + lineaExcel.ToString() + ": " + "El material: " + material + ", no tiene inventario disponible")
                            End If
                        Else
                            listaErrores.Add("Error en línea " + lineaExcel.ToString() + ": La cantidad solo puede contener números.")
                        End If
                    ElseIf fila.Cell(1).Value = "" And fila.Cell(2).Value = "" And fila.Cell(3).Value = "" Then
                        'no hacemos nada
                    Else
                        If fila.Cell(1).Value = "" Then
                            listaErrores.Add("Error en línea " + lineaExcel.ToString() + ": " + "Debe ingresar el material")
                        ElseIf fila.Cell(2).Value = "" Then
                            listaErrores.Add("Error en línea " + lineaExcel.ToString() + ": " + "Debe ingresar el estado")
                        ElseIf fila.Cell(3).Value = "" Then
                            listaErrores.Add("Error en línea " + lineaExcel.ToString() + ": " + "Debe ingresar la cantidad")
                        End If
                    End If
                Else
                    esPrimeraFila = False
                End If
            Catch ex As Exception
                listaErrores.Add("Error en línea " + lineaExcel.ToString() + ": " + ex.Message)
            End Try
            lineaExcel = lineaExcel + 1
        Next
        If listaErrores.Count = 0 Then
            For Each row In materialesParaInsertar.Rows
                Dim newRow As DataRow = dtTasks.NewRow
                newRow.Item("TASK_OWNER") = row.Item("TASK_OWNER")
                newRow.Item("TASK_ASSIGNEDTO") = row.Item("TASK_ASSIGNEDTO")
                newRow.Item("QUANTITY_ASSIGNED") = row.Item("QUANTITY_ASSIGNED")
                newRow.Item("INVENTORY") = row.Item("INVENTORY")
                newRow.Item("CODIGO_POLIZA_TARGET") = row.Item("CODIGO_POLIZA_TARGET")
                newRow.Item("MATERIAL_ID") = row.Item("MATERIAL_ID")
                newRow.Item("BARCODE_ID") = row.Item("BARCODE_ID")
                newRow.Item("ALTERNATE_BARCODE") = row.Item("ALTERNATE_BARCODE")
                newRow.Item("MATERIAL_NAME") = row.Item("MATERIAL_NAME")
                newRow.Item("CLIENT_OWNER") = row.Item("CLIENT_OWNER")
                newRow.Item("CLIENT_NAME") = row.Item("CLIENT_NAME")
                newRow.Item("grabo") = "NO"
                newRow.Item("IS_MASTER_PACK") = row.Item("IS_MASTER_PACK")
                newRow.Item("STATUS_CODE") = row.Item("STATUS_CODE")
                Dim CodeSkuAux As String = row.Item("MATERIAL_ID") + "-"
                CodeSku_ = CodeSku_ + CodeSkuAux
                dtTasks.Rows.Add(newRow)
            Next
        Else
            Dim popup As New popupList("Listado de Errores", listaErrores.ToArray("".[GetType]()))
            popup.ShowDialog()
        End If
    End Sub

    Private Sub cmbBodegueros_EditValueChanged(sender As Object, e As EventArgs) Handles cmbBodegueros.EditValueChanged
        MostrarBotonCargarPlantilla()
    End Sub

    Sub MostrarBotonCargarPlantilla()
        If UiListaBodega.EditValue IsNot Nothing And cmbClientes.EditValue IsNot Nothing And barListaTipo.EditValue IsNot Nothing And barListaTipo.EditValue = "General" And cmbBodegueros.EditValue IsNot Nothing And cmbBodegueros.EditValue <> "1" Then
            UiBtnCargarPlantilla.Enabled = True
            Exit Sub
        End If
    End Sub

    Private Sub barListaTipo_ItemClick(sender As Object, e As ItemClickEventArgs) Handles barListaTipo.ItemClick
        MostrarBotonCargarPlantilla()
    End Sub

    Private Sub UiLista_Properties_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles UiListaUbicacionDeSalida.Properties.ButtonClick

        Try
            If e.Button.Tag = Nothing Then
                Return
            End If
            If e.Button.Tag = "UiBotonRefrescarUbicacionDeSalida" Then
                cargarUbicaciones()
            End If
        Catch ex As Exception
            NotifyStatus("Error al cargar Ubicaciones: " + ex.Message, False, True)
        End Try

    End Sub
End Class