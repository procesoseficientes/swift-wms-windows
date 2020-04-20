Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Imports System.IO
Imports DevExpress.XtraPrinting.Native

Public Class frmInfoTransOnLine

    Sub ShowAllUsers()

        Dim pResult As String = ""
        Dim xserver As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
        Dim xdata As DataTable = xserver.GetOperatorAssignedToDistributionCenterByUser(PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)

        Dim xrow As DataRow

        If xdata.Rows.Count > 0 Then
            For Each xrow In xdata.Rows
                cmbUsers.Properties.Items.Add(xrow("LOGIN_ID").ToString, xrow("LOGIN_NAME").ToString, CheckState.Unchecked, True)
            Next
        End If


        Dim pLastUsers As String = GetSetting("OP_WMS", "INFO_TRANS_ONLINE", "CMBUSERS", "N/A")
        Dim pLastUsersArray() As String = pLastUsers.Split(",")
        Try
            For i = 0 To pLastUsersArray.Length - 1
                For J = 0 To cmbUsers.Properties.Items.Count - 1
                    If cmbUsers.Properties.Items(J).Description.ToString.Trim = pLastUsersArray(i).ToString.Trim Then
                        cmbUsers.Properties.Items(J).CheckState = CheckState.Checked
                        Exit For
                    End If
                Next J
            Next i


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub frmInfoTransOnLine_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmInfoTransOnLine_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmInfoTransOnLine_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmInfoTransOnLine_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmInfoTransOnLine_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gLastScreenShowed = Me.Name

        SaveGridLayout("GRID_TRANS_ONLINE", PublicLoginInfo.LoginID, Me.GridView1)

    End Sub

    Private Sub frmInfoTransOnLine_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    End Sub

    Private Sub frmInfoTransOnLine_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            gLastScreenShowed = Me.Name
            ShowAllUsers()
            ShowAllTrans()
            LoadGridLayout("GRID_TRANS_ONLINE", PublicLoginInfo.LoginID, Me.GridView1)

            Me.txtFechaInicial.DateTime = Now.AddHours(-Now.Hour).AddMinutes(-Now.Minute)
            Me.txtFechaFinal.DateTime = Now

            'Me.txtFechaInicial.DateTime = Format(Now, "MM/dd/yyyy 00:00:00") + " AM"
            'Me.txtFechaFinal.DateTime = Format(Now.Date, "MM/dd/yyyy") + " 11:59:59 PM"

        Catch ex As Exception

        End Try
    End Sub
    Sub ShowAllTrans()
        Dim pResult As String = ""
        Dim xserver As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xdata As DataSet = xserver.GetParam_ByParamKey("SISTEMA", "TRANS_TYPES", "", pResult, PublicLoginInfo.Environment)
        Dim xrow As DataRow
        Dim j As Integer = 0
        Dim i As Integer = 0
        If pResult = "OK" Then
            For Each xrow In xdata.Tables(0).Rows
                cmbTrans.Properties.Items.Add(xrow("PARAM_NAME").ToString, xrow("PARAM_NAME").ToString, CheckState.Unchecked, True)
            Next
        End If
        Dim pLastTrans As String = GetSetting("OP_WMS", "INFO_TRANS_ONLINE", "CMBTRANS", "N/A")
        Dim pLastTransArray() As String = pLastTrans.Split(",")
        Try
            For i = 0 To pLastTransArray.Length - 1
                For j = 0 To cmbTrans.Properties.Items.Count - 1
                    If cmbTrans.Properties.Items(j).Value.ToString.Trim = pLastTransArray(i).ToString.Trim Then
                        cmbTrans.Properties.Items(j).CheckState = CheckState.Checked
                        Exit For
                    End If
                Next j
            Next i
            LoadGridLayout("TRANS_ONLINE", PublicLoginInfo.LoginID, Me.GridView1)
        Catch ex As Exception

        End Try

    End Sub



    Private Sub chkBtn3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBtn3.CheckedChanged
        Dim pDiffDate As Date
        pDiffDate = DateAdd(DateInterval.Month, -3, Now)
        Me.txtFechaInicial.DateTime = pDiffDate.AddHours(-pDiffDate.Hour).AddMinutes(-pDiffDate.Minute)
        Me.txtFechaFinal.DateTime = Now
    End Sub

    Private Sub chkBtn1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBtn1.CheckedChanged
        Dim pDiffDate As Date
        pDiffDate = DateAdd(DateInterval.Month, -1, Now)
        Me.txtFechaInicial.DateTime = pDiffDate.AddHours(-pDiffDate.Hour).AddMinutes(-pDiffDate.Minute)
        Me.txtFechaFinal.DateTime = Now

    End Sub

    Private Sub chkBtnW_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBtnW.CheckedChanged
        Dim pDiffDate As Date
        pDiffDate = DateAdd(DateInterval.Day, -7, Now)
        Me.txtFechaInicial.DateTime = pDiffDate.AddHours(-pDiffDate.Hour).AddMinutes(-pDiffDate.Minute)
        Me.txtFechaFinal.DateTime = Now

    End Sub

    Private Sub chkBtnY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBtnY.CheckedChanged
        Dim pDiffDate As Date
        pDiffDate = DateAdd(DateInterval.Day, -1, Now)
        Me.txtFechaInicial.DateTime = pDiffDate.AddHours(-pDiffDate.Hour).AddMinutes(-pDiffDate.Minute)
        Me.txtFechaFinal.DateTime = Now

    End Sub
    Function PrepareStr(ByVal pType As String) As String

        Dim ptmp As String = ""

        If pType = "USERS" Then
            For J = 0 To cmbUsers.Properties.Items.Count - 1
                If cmbUsers.Properties.Items(J).CheckState = CheckState.Checked Then
                    'ptmp = ptmp + "'" + cmbUsers.Properties.Items(J).Value.ToString + "',"
                    If string.IsNullOrEmpty(ptmp) Then
                        ptmp = cmbUsers.Properties.Items(J).Value.ToString
                    Else
                        ptmp = ptmp + "|" + cmbUsers.Properties.Items(J).Value.ToString
                    End If
                End If
            Next J
        Else
            For J = 0 To cmbTrans.Properties.Items.Count - 1
                If cmbTrans.Properties.Items(J).CheckState = CheckState.Checked Then
                    If string.IsNullOrEmpty(ptmp) Then
                        ptmp = cmbTrans.Properties.Items(J).Value.ToString
                    Else
                        ptmp = ptmp + "|" + cmbTrans.Properties.Items(J).Value.ToString
                    End If
                    'ptmp = ptmp + "'" + cmbTrans.Properties.Items(J).Value.ToString + "',"
                End If
            Next J
        End If
        If ptmp <> "" Then
            Return ptmp
        Else
            Cursor = Cursors.Default
            MessageBox.Show("Debe seleccionar al menos un operador/tipo transacción (" + pType + ")", "OnePlan(r) WMS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return ""
        End If
    End Function
    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click

        Try
            RefreshTransView()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Function RefreshTransView()
        Dim ps_GridView As New Basic_TrasView
        Dim pResult As String = ""
        Try
            Cursor = Cursors.WaitCursor

            ps_GridView.lstUsers = PrepareStr("USERS")
            ps_GridView.lstTransTypes = PrepareStr("TRANS")

            ps_GridView.pSinceDate = Me.txtFechaInicial.DateTime
            ps_GridView.pToDate = Me.txtFechaFinal.DateTime

            ps_GridView.objDataGrid = Me.GridControl1

            If ps_GridView.pSinceDate > ps_GridView.pToDate Then
                Cursor = Cursors.Default
                MessageBox.Show("Fecha inicial debe ser menor o igual a la Fecha final")
                Return ""
            End If

            ps_GridView.RefreshGrid(pResult)
            '21-Jun-11 J.R. hacia que el proceso tardara demasiado
            'GridView1.BestFitColumns()
            Cursor = Cursors.Default

            If pResult = "OK" Then
                SaveSetting("OP_WMS", "INFO_TRANS_ONLINE", "CMBUSERS", Me.cmbUsers.Text)
                SaveSetting("OP_WMS", "INFO_TRANS_ONLINE", "CMBTRANS", Me.cmbTrans.Text)
            Else
                Cursor = Cursors.Default
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "OnePlan(r) WMS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
        Return ""
    End Function
    Private Sub btnToday_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToday.CheckedChanged
        Try
            Me.txtFechaInicial.DateTime = Now.AddHours(-Now.Hour).AddMinutes(-Now.Minute)
            '            Format(Date.Today, "MM/dd/yyyy 00:00:00") + " AM"
            Me.txtFechaFinal.DateTime = Now         ' Format(Date.Today, "MM/dd/yyyy") + " 11:59:59 PM"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.GridView1.ShowCustomization()
    End Sub

    Private Sub Timer_Inventory_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Inventory.Tick
        RefreshTransView()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer_Inventory.Enabled = IIf(Timer_Inventory.Enabled, False, True)
        'Me.lblStatusTimer.Text = IIf(Me.Timer_Inventory.Enabled, "Actualzacion automatica", "Actualizacion manual")
        RefreshTransView()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim pFileName As String = ""

            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                pFileName = SaveFileDialog1.FileName
                Me.GridView1.ExportToXls(pFileName)

            End If
            '            SaveGridLayout("TRANS_ONLINE", PublicLoginInfo.LoginID, Me.GridView1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub PrintableComponentLink1_CreateReportHeaderArea(ByVal sender As System.Object, ByVal e As CreateAreaEventArgs)
        Dim reportHeader As String
        Try

            reportHeader = "Filtros: " + Me.GridView1.FilterPanelText.ToString
            reportHeader = reportHeader & vbNewLine & "Del: [" + Format(Me.txtFechaInicial.DateTime, "dd/MMM/yyyy hh:mm:ss tt") + "]  Al: [" + Format(Me.txtFechaFinal.DateTime, "dd/MMM/yyyy hh:mm:ss tt") + "]"
            'reportHeader = reportHeader & vbNewLine & "Del: [" + Me.txtFechaInicial.DateTime.ToString + "]  Al: [" + Me.txtFechaFinal.DateTime.ToString + "]"
            reportHeader = reportHeader & vbNewLine & "Transacciones: [" + Me.cmbTrans.Text + "]"
            reportHeader = reportHeader & vbNewLine & "Usuarios: [" + Me.cmbUsers.Text + "]"

            'reportHeader = reportHeader & vbNewLine & "Usuarios:[" + Me.cmbUsers.Text + "] Trans:[" + Me.cmbTrans.Text + "] " + " FechaInicial[" + Me.txtFechaInicial.DateTime.ToString + "] FechaFinal[" + Me.txtFechaFinal.DateTime.ToString + "] " + Me.GridView1.FilterPanelText.ToString
            'reportHeader = lblPedidoID.Text & vbNewLine & "Cliente: " & lblCustInfo.Text & vbNewLine & "Sector/Ruta: " & lblSector.Text & "/" & lblRuta.Text
            e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Near)
            e.Graph.Font = New Font("Arial", 8, FontStyle.Italic)
            Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 200)
            e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor = Cursors.Default
        End Try
    End Sub


    Sub Link_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
        Dim Brick As PageInfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "", Color.Black, New RectangleF(0, 0, 100, 20), BorderSide.None)
        Brick.LineAlignment = BrickAlignment.Center
        Brick.Alignment = BrickAlignment.Center
        Brick.AutoWidth = True
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim xrpt As New rptTransOnLine
        'Dim xfilter As String = "", xfilter_caption As String = ""

        Dim numLineas As Integer = GridView1.Columns(0).SummaryText
        If numLineas > 1000 Then
            MessageBox.Show("Demasiadas lineas en el reporte, utilice filtros.")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Try
            Dim ps As New PrintingSystem()
            ' Create a link that will print a control.
            Dim link As New PrintableComponentLink(ps)
            ' Specify the control to be printed.
            link.Component = GridControl1


            Dim leftColumn As String = ""
            Dim middleColumn As String = "Reporte de Transacciones"
            Dim rightColumn As String = "Pagina: [Page # of Pages #]"

            Dim phf As PageHeaderFooter = TryCast(link.PageHeaderFooter, PageHeaderFooter)

            phf.Header.Content.Clear()
            phf.Header.Content.AddRange(New String() {"", middleColumn, ""})
            phf.Header.LineAlignment = BrickAlignment.Far
            phf.Footer.Content.AddRange(New String() {"", "", rightColumn})
            phf.Footer.LineAlignment = BrickAlignment.Center


            ' Subscribe to the CreateReportHeaderArea event used to generate the report header.
            AddHandler link.CreateReportHeaderArea, AddressOf PrintableComponentLink1_CreateReportHeaderArea
            link.Landscape = True
            link.CreateDocument()
            link.ShowPreview()

            Cursor = Cursors.Default



        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Cursor = Cursors.WaitCursor
            Me.GridView1.ExpandAllGroups()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Cursor = Cursors.WaitCursor
            Me.GridView1.CollapseAllGroups()
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub GridView1_EndGrouping(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.EndGrouping
        Try

            If Me.GridView1.GroupCount > 0 Then
                Me.lblTotalGrupo.Text = "Total " + Me.GridView1.GroupedColumns(0).Caption + ": " + Me.GridView1.RowCount.ToString
            Else
                Me.lblTotalGrupo.Text = "Total grupo: "
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GridControl1_Click(sender As System.Object, e As System.EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim xrow As DataRow
        Dim pResult As String = ""
        Try
            Dim xserver As New OnePlanServices_Trans.WMS_TransSoapClient("WMS_TransSoap", PublicLoginInfo.WSHost + "/trans/wms_trans.asmx")

            xrow = Me.GridView1.GetDataRow(Me.GridView1.FocusedRowHandle)
            Dim xtran As Integer = xrow("SERIAL")
            Dim msgstr As String = "Ingrese el peso para el SKU: " & vbNewLine & xrow("MATERIAL_BARCODE") & "-" & xrow("MATERIAL_DESCRIPTION") & vbNewLine & "CLIENTE: " & xrow("CLIENT_NAME")
            Dim input_result As String = ""
            input_result = InputBox(msgstr, "Actualización de Peso", "1")
            If input_result <> "" Then
                If IsNumeric(input_result) Then
                    If xserver.SetTransWeigth(xrow("SERIAL"), CDbl(input_result), PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment) Then
                        RefreshTransView()
                    Else
                        NotifyStatus(pResult, True, True)
                    End If
                Else
                    NotifyStatus("Ingrese un valor valido", True, True)
                End If
            Else
                NotifyStatus("Ingrese un valor valido", True, True)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try

    End Sub

    Private Sub barBtnActualizacion_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnActualizacion.ItemClick
        Timer_Inventory.Enabled = IIf(Timer_Inventory.Enabled, False, True)
        barBtnActualizacion.Caption = IIf(Me.Timer_Inventory.Enabled, "Actualzacion automatica", "Actualizacion manual")
        RefreshTransView()
    End Sub

    Private Sub barBtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnPrint.ItemClick
        GridView1.ExpandAllGroups()
        GridView1.ShowPrintPreview()
    End Sub

    Private Sub barBtnColumnas_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnColumnas.ItemClick
        Me.GridView1.ShowCustomization()
    End Sub

    Private Sub barBtnExpandir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnExpandir.ItemClick
        Try
            Cursor = Cursors.WaitCursor
            Me.GridView1.ExpandAllGroups()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub barBtnContraer_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnContraer.ItemClick
        Try
            Cursor = Cursors.WaitCursor
            Me.GridView1.CollapseAllGroups()
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub barBtnSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnSave.ItemClick
        SaveGridLayout("GRID_TRANS_ONLINE", PublicLoginInfo.LoginID, Me.GridView1)       
    End Sub

    Private Sub barBtnPrintType_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnPrintType.ItemClick
        GenerarReporte()
    End Sub


    Private Sub GenerarReporte()
        Try
            If GridView1.RowCount > 0 Then
                If GridView1.SelectedRowsCount = 1 Then
                    Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                    Select Case xdatarow("TRANS_TYPE").ToString()
                        Case "INGRESO_GENERAL"
                            lblCodigoPolizaRepIngGeneral.Text = xdatarow("CODIGO_POLIZA").ToString()
                            menObservacinesRepIngGeneral.Text = ""
                            popObservacionesIngGeneral.Visible = True
                        Case "DESPACHO_GENERAL"
                            GenerarRepDesGeneral(xdatarow("CODIGO_POLIZA").ToString())
                    End Select
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub GenerarRepIngGeneral()
        Try

            Dim result As String = ""
            Dim xserver As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
            Dim dtset As DataSet
            dtset = xserver.GetTaskIngGeneral(lblCodigoPolizaRepIngGeneral.Text, result, PublicLoginInfo.Environment)

            If result = "OK" Then
                Dim rptNIngreso As New rptIngresoGeneral
                rptNIngreso.DataMember = "repTransIngGeneral"
                rptNIngreso.DataSource = dtset
                rptNIngreso.RequestParameters = False
                rptNIngreso.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                rptNIngreso.Parameters("prmObservaciones").Value = menObservacinesRepIngGeneral.Text
                rptNIngreso.Parameters("prmUser").Value = PublicLoginInfo.LoginName
                rptNIngreso.ShowPreview()
                popObservacionesIngGeneral.Visible = False
            Else
                NotifyStatus(result, False, True)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnCancelarRepIngGeneral_Click(sender As Object, e As EventArgs) Handles btnCancelarRepIngGeneral.Click
        popObservacionesIngGeneral.Visible = False
    End Sub

    Private Sub btnAceptarRepIngGeneral_Click(sender As Object, e As EventArgs) Handles btnAceptarRepIngGeneral.Click
        GenerarRepIngGeneral()
    End Sub

    Private Sub GenerarRepDesGeneral(ByVal pCodigoPoliza As String)
        Try
            Dim rptPolEgreso As New rptPolizaEgreso
            Dim dt As DataSet
            Dim result As String = String.Empty
            Dim serverInfoTrans As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
            dt = serverInfoTrans.GetRepPolizaEgreso(pCodigoPoliza, result, PublicLoginInfo.Environment)

            If result = "OK" Then
                rptPolEgreso.DataMember = "repPolEgreso"
                rptPolEgreso.DataSource = dt
                rptPolEgreso.RequestParameters = False
                rptPolEgreso.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                rptPolEgreso.Parameters("prmUser").Value = PublicLoginInfo.LoginName
                rptPolEgreso.ShowPreview()
            Else
                MsgBox(result)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try

    End Sub

    Private Sub BarButtonExportarExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonExportarExcel.ItemClick
        Dim pFileName As String = ""

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            pFileName = SaveFileDialog1.FileName
            Dim sheetNames() As String = {"Transacciones", "Tareas Por Operador", "Tiempo Promedio"}
            GridControl1.ExportToXls(pFileName + GridControl1.Name + ".xls")
            Dim arrArchivosXls() As String = {pFileName + GridControl1.Name + ".xls"}
            MergeXlsxFilesDevExpress(pFileName, sheetNames, arrArchivosXls)


        End If
    End Sub

    Public Sub MergeXlsxFilesDevExpress(destXlsxFileName As String, sheetNames As String(), ParamArray sourceXlsxFileNames As String())
        Dim destWorkBook As New DevExpress.Spreadsheet.Workbook()
        destWorkBook.CreateNewDocument()
        For i As Integer = LBound(sourceXlsxFileNames) To UBound(sourceXlsxFileNames) Step 1
            Dim sourceXlsxFile As String = sourceXlsxFileNames(i)
            Dim sourceWorkBook As New DevExpress.Spreadsheet.Workbook()
            sourceWorkBook.LoadDocument(sourceXlsxFile)
            Dim sheet = sourceWorkBook.Worksheets(0)
            Dim temp As DevExpress.Spreadsheet.Worksheet = destWorkBook.Worksheets.Add()
            temp.CopyFrom(sheet)
            temp.Name = sheetNames(i)
            sourceWorkBook.Dispose()
            File.Delete(sourceXlsxFile)
        Next
        destWorkBook.Worksheets.RemoveAt(0)
        destWorkBook.SaveDocument(destXlsxFileName)
        destWorkBook.Dispose()
    End Sub
End Class