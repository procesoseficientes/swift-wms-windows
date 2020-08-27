Imports System.Data
Imports System.IO
Imports DevExpress.XtraReports.UI
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraReports.Parameters
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.Data
Imports System.ComponentModel

Public Class frmInfo_Inventory
    Dim strPath As String
    Dim dtTemp As New DataTable("test")
    Dim dtTempV As New DataTable("test")
    Dim modificarInv As Boolean
    Dim DateOrBacht, toneReq, CaliberReq As Boolean
    Public DataTableDetU As DataTable
    Public DataTableInvUpdate As DataTable = columnsDataTableInvUpdate()
    Public DocCertificateId As Integer = 0
    Private Sub frmInfo_Inventory_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmInfo_Inventory_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        gLastScreenShowed = Me.Name

    End Sub

    Private Sub frmInfo_Inventory_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmInfo_Inventory_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmInfo_Inventory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-GT")
        ' System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es")
        Dim strPath As String
        Try
            'LayoutControl1.SetDefaultLayout()
            gLastScreenShowed = Me.Name

            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInfo_Inventory" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                'LayoutControl1.RestoreLayoutFromXml(strPath)
                strPath = String.Empty
            End If

            Try
                ShowInventory()
            Catch ex As Exception
                MsgBox("error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try

            statusLicense()
            securityAccessPermissions()
            If modificarInv Then
                btnSaveChanges.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                modifyColumns()
            End If

        Catch ex As Exception
            MsgBox("Error al abrir la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub ShowInventory()
        Dim xDataSet As DataSet
        Dim pResult As String = ""
        Try
            Cursor = Cursors.WaitCursor
            Dim xserv As New OnePlanServices_InfoInventory.WMS_InfoInventorySoapClient("WMS_InfoInventorySoap", PublicLoginInfo.WSHost + "/Info/wms_InfoInventory.asmx")

            RibbonForm1.Static_Message.Caption = Now.ToString + " " + pResult
            RibbonForm1.Static_Message.Refresh()
            xDataSet = xserv.GetInventory_ByWarehouse(PublicLoginInfo.LoginID, "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then

                Me.GridControl1.DataSource = xDataSet.Tables(0)
                dtTemp = xDataSet.Tables(0).Copy()
                dtTemp.Rows.Clear()

                loadLayoutTimer.Start()
            Else
                MessageBox.Show(pResult)
                RibbonForm1.Static_Message.Caption = Now.ToString + " " + pResult
                RibbonForm1.Static_Message.Refresh()
            End If

            'GridView1.BestFitColumns()
            Cursor = Cursors.Default
            DataTableInvUpdate.Clear()
            'Habilita las columnas a modificar
            If modificarInv Then
                modifyColumns()
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Timer_Inventory_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Inventory.Tick
        ShowInventory()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim xrpt As New rptInvOnLineDetail
        'Dim xfilter As String = "", xfilter_caption As String = ""
        'Cursor = Cursors.WaitCursor
        Try

            '    Try
            '        xrpt.DataSource = Me.GridControl1.DataSource
            '        If Me.GridView1.ActiveFilterEnabled Then
            '            xrpt.FilterString = "WAREHOUSE_ID='PICKING' AND " + Me.GridView1.ActiveFilterCriteria.ToString
            '            xrpt.Parameters("ParamFilterApplied").Value = Me.GridView1.FilterPanelText.ToString
            '        Else
            '            xrpt.FilterString = "WAREHOUSE_ID='PICKING' "
            '            xrpt.Parameters("ParamFilterApplied").Value = ""
            '        End If

            '        xrpt.RequestParameters = False
            '        xrpt.ShowPreview()
            '        Cursor = Cursors.Default
            '    Catch ex As Exception
            '        xrpt.DataSource = Me.GridControl1.DataSource
            '        xrpt.FilterString = "WAREHOUSE_ID='PICKING' "
            '        xrpt.Parameters("ParamFilterApplied").Value = Me.GridView1.FilterPanelText.ToString

            '        xrpt.RequestParameters = False
            xrpt.Parameters("logoImg").Value = PublicLoginInfo.LOGO
            xrpt.ShowPreview()
            'Cursor = Cursors.Default
            '    End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor = Cursors.Default
        End Try

        Try
            'PrintableComponentLink1.ShowPreview()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '08-11-2012 WM cambiado por que daba error al grabar, revisar porque.
        SaveGridLayout("INV_ONLINE", PublicLoginInfo.LoginID, Me.GridView1)

        ''grabamos el layout de la forma 
        'Try
        '    strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInfo_Inventory_grid1" & PublicLoginInfo.LoginID & ".xml"
        '    If File.Exists(strPath) Then
        '        File.Delete(strPath)

        '        GridView1.RestoreLayoutFromXml(strPath)
        '        strPath = String.Empty
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Timer_Inventory.Enabled = IIf(Me.Timer_Inventory.Enabled, False, True)
        'Me.lblStatusTimer.Text = IIf(Me.Timer_Inventory.Enabled, "Actualzacion automatica", "Actualizacion manual")
        ShowInventory()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            SaveFileDialog1.DefaultExt = "xlsx"
            SaveFileDialog1.Filter = "Documentos de Excel (*.xlsx)|*.xlsx"
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                GridView1.ExportToXlsx(SaveFileDialog1.FileName)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnAutomatica.ItemClick
        Me.Timer_Inventory.Enabled = IIf(Me.Timer_Inventory.Enabled, False, True)
        Me.barBtnAutomatica.Caption = IIf(Me.Timer_Inventory.Enabled, "Actualización automática", "Actualización manual")
        ShowInventory()
    End Sub


    Private Sub barBtnSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnSave.ItemClick
        SaveGridLayout("INV_ONLINE", PublicLoginInfo.LoginID, Me.GridView1)
    End Sub

    Private Sub barBtnPdf_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnPrint.ItemClick
        Try

            LlenarReporte() 'GridView1.ExpandAllGroups()
            'GridView1.ShowPrintPreview()
            ' GenerarReporte()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LlenarReporte()
        Try
            Dim dtTemp As DataTable
            dtTemp = CType(GridControl1.DataSource, DataTable).Copy()
            dtTemp.Rows.Clear()

            For i As Integer = 0 To GridView1.RowCount
                dtTemp.ImportRow(GridView1.GetDataRow(i))
            Next

            Dim rptInventoryOnline As New rptInventoryOnline
            rptInventoryOnline.DataSource = dtTemp
            rptInventoryOnline.DataMember = dtTemp.TableName

            rptInventoryOnline.RequestParameters = False
            rptInventoryOnline.Parameters("logoImg").Value = PublicLoginInfo.LOGO
            rptInventoryOnline.Parameters("UserWMS").Value = PublicLoginInfo.LoginName

            rptInventoryOnline.ShowPreview()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub LlenarReporteVehiculo()
        Try
            Dim dtTempV As DataTable
            dtTempV = CType(GridControl1.DataSource, DataTable).Copy()
            dtTempV.Rows.Clear()

            For i As Integer = 0 To GridView1.RowCount
                dtTempV.ImportRow(GridView1.GetDataRow(i))
            Next

            'Dim rptInventoryOnline As New rptInventoryOnlineVehiculo
            'rptInventoryOnline.DataSource = dtTempV
            'rptInventoryOnline.DataMember = dtTempV.TableName
            'rptInventoryOnline.RequestParameters = False
            'rptInventoryOnline.Parameters("logoImg").Value = PublicLoginInfo.LOGO
            'rptInventoryOnline.Parameters("UserWMS").Value =  PublicLoginInfo.LoginName

            'rptInventoryOnline.ShowPreview()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BarBtnExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarBtnExcel.ItemClick
        SaveFileDialog1.DefaultExt = "xlsx"
        SaveFileDialog1.Filter = "Archivos de excel (*.xlsx)|*.xlsx"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridControl1.ExportToXlsx(SaveFileDialog1.FileName)
            ' GridView1.ExportToXlsx(SaveFileDialog.FileName)
            ' GridViewDocs.ExportToXlsx(SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub GenerarReporte()
        Try
            Dim rptCertificate As New rptInventoryOnline
            Dim param1 As New Parameter()
            param1.Name = "UserWMS"

            param1.Type = GetType(System.Int32)
            param1.Value = 1
            param1.Description = "USERS: "
            param1.Visible = True


            'rptCertificate.FilterString = " [Parameters.UserWMS]"
            rptCertificate.Parameters("logoImg").Value = PublicLoginInfo.LOGO
            rptCertificate.Parameters("prmUsuario").Value = PublicLoginInfo.LoginName
            rptCertificate.Parameters.Add(param1)

            rptCertificate.RequestParameters = False

            Dim label As New XRLabel()
            label.DataBindings.Add(New XRBinding(param1, "Text", "Category: {0}"))
            Dim reportHeader As New ReportHeaderBand()
            reportHeader.Controls.Add(label)
            rptCertificate.Bands.Add(reportHeader)

            Dim pt As New ReportPrintTool(rptCertificate)
            pt.AutoShowParametersPanel = True
            pt.ShowPreviewDialog()



            rptCertificate.DataSource = DataTableDetU
            rptCertificate.DataMember = DataTableDetU.TableName
            rptCertificate.RequestParameters = False

            rptCertificate.Parameters("prmUsuario").Value = PublicLoginInfo.LoginName
            rptCertificate.ShowPreview()

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub frmInfo_Inventory_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim strPath As String
        Try
            gLastScreenShowed = Me.Name

            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInfo_Inventory" & PublicLoginInfo.LoginID & ".xml"

            'LayoutControl1.SaveLayoutToXml(strPath)
            strPath = String.Empty

            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInfo_InventoryGrid" & PublicLoginInfo.LoginID & ".xml"
            GridView1.SaveLayoutToXml(strPath)
            strPath = String.Empty

        Catch ex As Exception
            MsgBox("Error al Cerrar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub

    Private Sub GridView1_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
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

    Private Sub btnRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefresh.ItemClick

        If DataTableInvUpdate.Rows.Count = 0 Then
            ShowInventory()
        Else

            If MsgBox("Tiene cambios pendientes, se eliminaran los cambios no almacenados ¿Desea continuar?", MsgBoxStyle.YesNo, "Inventario en Linea") = MsgBoxResult.Yes Then
                ShowInventory()
            End If

        End If


    End Sub
    Private Sub btnSaveChanges_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSaveChanges.ItemClick
        Dim result As Boolean = False

        If DataTableInvUpdate.Rows.Count = 0 Then
            MsgBox("No hay cambios realizados.", MsgBoxStyle.Information, "Inventario en Linea")
        Else

            For Each row As DataRow In DataTableInvUpdate.Rows
                Dim codigo As Integer
                Dim Fecha, lote, licencia As String
                codigo = row.Item("BATCH_REQUESTED")
                Fecha = row.Item("Fecha_Expiracion")
                lote = row.Item("Numero_Lote")
                licencia = row.Item("Licencia")

                If codigo <> 0 Then

                    If Not Fecha = "" And lote = "" Then
                        MsgBox("Debe agregar lote de la Licencia: " + licencia, MsgBoxStyle.Information, "Inventario en Linea")
                        result = False
                        Exit For
                    ElseIf Not lote = "" And Fecha = "" Then
                        MsgBox("Debe agregar fecha de la Licencia: " + licencia, MsgBoxStyle.Information, "Inventario en Linea")
                        result = False
                        Exit For
                    End If

                End If
                result = True
            Next
            If result = True Then
                Dim inventoryUpdate As New frmInventory_Update
                inventoryUpdate.dataTableInventory = DataTableInvUpdate
                inventoryUpdate.ShowDialog()
            End If
        End If
    End Sub

    Private Sub modifyColumns()
        GridView1.EditingValue = True
        GridView1.OptionsBehavior.Editable = True
        GridView1.OptionsBehavior.ReadOnly = False
        'Columnas que se habilitan en el grid.
        UiColTono.OptionsColumn.ReadOnly = False
        UiColCalibre.OptionsColumn.ReadOnly = False
        colBATCH.OptionsColumn.ReadOnly = False
        UiColNombreEstado.OptionsColumn.ReadOnly = False
        colDATE_EXPIRATION.OptionsColumn.ReadOnly = False
        GridColumn_HANDLE_CALIBER.Visible = False
        GridColumn_HANDLE_TONE.Visible = False
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim estado, lote, tono, calibre, licencia, ubicacion, CodMaterial, Descripcion, invLicencia, pkLine, tonoCaliberID, fecha As String
        Dim f_expiracion As Date
        Dim reqBatch, statusId, handleTone, handleCaliber As Integer

        estado = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, UiColNombreEstado).ToString
        lote = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colBATCH).ToString

        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colDATE_EXPIRATION).ToString = "" Then
            f_expiracion = Nothing
            fecha = Format(f_expiracion, "MM/dd/yyyy")
        Else
            f_expiracion = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colDATE_EXPIRATION).ToString
            fecha = Format(f_expiracion, "MM/dd/yyyy")
        End If

        tono = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, UiColTono).ToString
        calibre = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, UiColCalibre).ToString
        licencia = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridColumn_Linea).ToString
        ubicacion = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridColumn_Ubicacion).ToString
        CodMaterial = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colMATERIAL_ID).ToString
        Descripcion = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridColumn_Descripcion).ToString
        invLicencia = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridColumn_Unidades).ToString
        pkLine = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridColumn_PK_LINE).ToString
        reqBatch = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridColumn_BATCH_REQUESTED).ToString
        statusId = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridColumn_STATUS_ID).ToString
        tonoCaliberID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridColumn_TONE_CALIBER_ID).ToString
        handleTone = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridColumn_HANDLE_TONE).ToString
        handleCaliber = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridColumn_HANDLE_CALIBER).ToString

        If fecha = "01/01/0001" Then fecha = ""
        DateOrBacht = False
        If reqBatch = 0 Then
            If fecha <> "" Or lote <> "" Then
                MsgBox("No se puede agregar Fecha de Exp. o Lote.", MsgBoxStyle.Information, "Inventario en Linea")
                DateOrBacht = True
                fecha = ""
                lote = ""
            End If
        End If

        toneReq = False
        If handleTone = 0 Then
            If tono <> "" Then
                MsgBox("No se puede agregar tono a esta licencia", MsgBoxStyle.Information, "Inventario en Linea")
                toneReq = True
                tono = ""
            End If
        End If

        CaliberReq = False
        If handleCaliber = 0 Then
            If calibre <> "" Then
                MsgBox("No se puede agregar calibre a esta licencia", MsgBoxStyle.Information, "Inventario en Linea")
                CaliberReq = True
                calibre = ""
            End If
        End If

        If DateOrBacht = True Then
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, colDATE_EXPIRATION, Nothing)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, colBATCH, Nothing)
        End If

        If toneReq = True Then GridView1.SetRowCellValue(GridView1.FocusedRowHandle, UiColTono, Nothing)
        If CaliberReq = True Then GridView1.SetRowCellValue(GridView1.FocusedRowHandle, UiColCalibre, Nothing)

        checkDataTableInvUpdate(licencia, ubicacion, CodMaterial, Descripcion, invLicencia, estado, lote, fecha, tono, calibre, pkLine, reqBatch, statusId, tonoCaliberID, handleTone, handleCaliber)

    End Sub

    Function columnsDataTableInvUpdate() As DataTable
        Dim dt As New DataTable
        Dim keys(2) As DataColumn
        Dim columnkey As DataColumn

        columnkey = New DataColumn
        columnkey.DataType = GetType(String)
        columnkey.ColumnName = "Licencia"
        dt.Columns.Add(columnkey)
        keys(0) = columnkey

        columnkey = New DataColumn
        columnkey.DataType = GetType(String)
        columnkey.ColumnName = "Ubicacion"
        dt.Columns.Add(columnkey)
        keys(1) = columnkey

        columnkey = New DataColumn
        columnkey.DataType = GetType(String)
        columnkey.ColumnName = "Codigo_Material"
        dt.Columns.Add(columnkey)
        keys(2) = columnkey

        dt.Columns.Add("Descripcion", GetType(String))
        dt.Columns.Add("inv.Licencia", GetType(String))
        dt.Columns.Add("Estado", GetType(String))
        dt.Columns.Add("Numero_Lote", GetType(String))
        dt.Columns.Add("Fecha_Expiracion", GetType(String))
        dt.Columns.Add("Tono", GetType(String))
        dt.Columns.Add("Calibre", GetType(String))
        dt.Columns.Add("PK_LINE", GetType(Integer))
        dt.Columns.Add("BATCH_REQUESTED", GetType(Integer))
        dt.Columns.Add("STATUS_ID", GetType(Integer))
        dt.Columns.Add("TONE_AND_CALIBER_ID", GetType(String))
        dt.Columns.Add("USER", GetType(String))
        dt.Columns.Add("HANDLE_TONE", GetType(Integer))
        dt.Columns.Add("HANDLE_CALIBER", GetType(Integer))
        dt.Columns.Add("TOTAL_POSITION", GetType(Integer))

        dt.PrimaryKey = keys

        Return dt
    End Function
    Private Sub checkDataTableInvUpdate(licencia As String, ubicacion As String, CodMaterial As String, descripcion As String, invLicencia As String, estado As String, lote As String, f_expiracion As String,
                                        Tono As String, Calibre As String, pkLine As Integer, reqBatch As Integer, statusId As Integer, tonoCaliberID As String, handleTono As Integer, handleCaliber As Integer)

        Dim dr As DataRow
        Dim keys(2) As Object

        keys(0) = licencia
        keys(1) = ubicacion
        keys(2) = CodMaterial

        dr = DataTableInvUpdate.Rows.Find(keys)

        If dr Is Nothing Then
            DataTableInvUpdate.Rows.Add(licencia, ubicacion, CodMaterial, descripcion, invLicencia, estado, lote, f_expiracion, Tono, Calibre, pkLine, reqBatch, statusId, tonoCaliberID, PublicLoginInfo.LoginName, handleTono, handleCaliber)
        Else
            dr("Estado") = estado
            dr("Numero_Lote") = lote
            dr("Fecha_Expiracion") = f_expiracion
            dr("Tono") = Tono
            dr("Calibre") = Calibre
        End If

    End Sub
    Private Sub statusLicense()

        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")

        Dim xdataset As New DataSet
        Dim pResult As String = ""

        Try
            xdataset = xserv.GetParam_PartialSearch("ESTADOS", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                lookupEstados.DataSource = xdataset.Tables(0)
                UiColNombreEstado.ColumnEdit = lookupEstados
            End If
        Catch ex As Exception
            xdataset = Nothing
            xserv = Nothing
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Dim layoutLoadedinSession = False

    Private Sub loadLayoutTimer_Tick(sender As Object, e As EventArgs) Handles loadLayoutTimer.Tick
        If layoutLoadedinSession = False Then
            layoutLoadedinSession = True
            Dim strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInfo_InventoryGrid" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                GridView1.RestoreLayoutFromXml(strPath)
                GridView1.SaveLayoutToXml(strPath)
            End If
        End If
        loadLayoutTimer.Stop()
    End Sub

    Private Sub securityAccessPermissions()

        Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")

        Dim xDataTable As New DataTable
        Dim pResult As String = ""

        Try
            xDataTable = xserv.getSecurityPermits("INFO_INV_ONLINE", "SCREEN_SECURITY", PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                modificarInv = True
            Else
                modificarInv = False
            End If
        Catch ex As Exception
            xDataTable = Nothing
            xserv = Nothing
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged

        If GridView1.FocusedRowHandle.ToString <= -1 Then
            Exit Sub
        End If

        Dim reqBatch, handleTone, handleCaliber As Integer
        Dim row As Integer

        row = GridView1.FocusedRowHandle.ToString
        If row = -2147483646 Then
            reqBatch = 1
            handleCaliber = 1
            handleTone = 1
        Else
            reqBatch = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridColumn_BATCH_REQUESTED).ToString
            handleTone = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridColumn_HANDLE_TONE).ToString
            handleCaliber = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridColumn_HANDLE_CALIBER).ToString
        End If

        If reqBatch = 0 Then
            colBATCH.OptionsColumn.ReadOnly = True
            colDATE_EXPIRATION.OptionsColumn.ReadOnly = True
        Else
            colBATCH.OptionsColumn.ReadOnly = False
            colDATE_EXPIRATION.OptionsColumn.ReadOnly = False
        End If

        If handleTone = 0 Then
            UiColTono.OptionsColumn.ReadOnly = True
        Else
            UiColTono.OptionsColumn.ReadOnly = False
        End If

        If handleCaliber = 0 Then
            UiColCalibre.OptionsColumn.ReadOnly = True
        Else
            UiColCalibre.OptionsColumn.ReadOnly = False
        End If

    End Sub

    Private Sub frmInfo_Inventory_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        SaveGridLayout("INV_ONLINE", PublicLoginInfo.LoginID, Me.GridView1)
    End Sub
End Class