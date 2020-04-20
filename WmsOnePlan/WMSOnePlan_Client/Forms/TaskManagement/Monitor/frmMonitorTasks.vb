Imports System
Imports System.IO
Imports System.Reflection
Imports System.Web.UI.WebControls
Imports System.Windows.Controls
Imports DevExpress.CodeParser
Imports DevExpress.Pdf
Imports DevExpress.Utils
Imports DevExpress.XtraGrid
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraEditors
Imports DevExpress.XtraCharts
Imports DevExpress.XtraCharts.Native
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraPrinting
Imports MobilityScm.Modelo.Tipos

Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.Drawing
Imports DevExpress.XtraPrinting.Native

Public Class frmMonitorTasks
    Public pGlobalTaskView As String = "VIEW_TASK"
    Public pGlobalDateFilter As String = "BY_CALENDAR"
    Public pPendingView As String = "PENDING"
    Private dblPorcentajeLlegarMinimo As Double

    '22-Jun-11 J.R.
    Private intAsignados As Integer = 0
    Private intNoAsignados As Integer = 0
    Private _rangoPrevioDeFechas As DatesCollection
    Private _graficasGenerdas As Boolean
    Dim listaOperadoresReubicacion As DataTable

    Public Sub New()


        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


    End Sub


    Private Sub frmMonitorTasks_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        gLastScreenShowed = "frmMonitorTasks"
        RibbonForm1.DefaultLookAndFeel1.LookAndFeel.SetSkinStyle(PublicLoginInfo.GUI)

    End Sub

    Private Sub frmMonitorTasks_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        gLastScreenShowed = "frmMonitorTasks"
        SaveGridLayout("GRID_TASK_MONITOR", PublicLoginInfo.LoginID, Me.GridView2)

    End Sub

    Private Sub frmMonitorTasks_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        gLastScreenShowed = "frmMonitorTasks"
    End Sub

    Private Sub frmMonitorTasks_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        gLastScreenShowed = "frmMonitorTasks"
    End Sub

    Private Sub frmMonitorTasks_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        SaveGridLayout("GRID_TASK_MONITOR", PublicLoginInfo.LoginID, Me.GridView2)

    End Sub

    Private Sub frmMonitorTasks_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Cambio
        NavBarControlTaskOnLine.Groups("NavBarGroup_Replenish").Visible = False
        btnCrearTareas.Enabled = False
        Me.txtFechaInicial.DateTime = Now.Date
        Me.txtFechaFinal.DateTime = Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
        '---
        ShowAllUsers("GRID")
        ShowAllTaskTypes()
        Dim gTaskMonitor_LastLeftMenu As String

        gTaskMonitor_LastLeftMenu = GetSetting("ONE_PLAN", "USER_CONFIG", "LAST_LEFTMENU", "NavBarGroup_PendingDemand")
        gTaskMonitor_LastLeftMenu = IIf(gTaskMonitor_LastLeftMenu = "", "NavBarGroup_PendingDemand", gTaskMonitor_LastLeftMenu)
        'Me.txtFechaInicial.DateTime = Format(Now, "MM/dd/yyyy")
        'Me.txtFechaFinal.DateTime = Format(Now.Date, "MM/dd/yyyy")

        gLastScreenShowed = "frmMonitorTasks"
        LoadGridLayout("GRID_TASK_MONITOR", PublicLoginInfo.LoginID)
        LlenarListaOperadoresParaPickingDetalle()
        LlenarListaOperadoresParaUbicacionDetalle()
    End Sub



    Sub ShowAllTaskTypes()
        Dim pResult As String = ""
        Dim xserver As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xdata As DataSet = xserver.GetParam_ByParamKey("SISTEMA", "TASK_TYPES", "", pResult, PublicLoginInfo.Environment)
        Dim xrow As DataRow
        Dim j As Integer = 0
        Dim i As Integer = 0
        If pResult = "OK" Then
            grdTaskType.DataSource = xdata.Tables(0)

            For Each xrow In xdata.Tables(0).Rows
                Dim xitem As New DevExpress.XtraEditors.Controls.CheckedListBoxItem

                xitem.Description = xrow("PARAM_NAME").ToString
                xitem.Value = xrow("PARAM_NAME").ToString
                xitem.CheckState = CheckState.Indeterminate
                cmbTaskTypes_Filter.Properties.Items.Add(xitem)

                'cmbTrans.Properties.Items.Add(xrow("PARAM_NAME").ToString, xrow("PARAM_NAME").ToString, CheckState.Unchecked, True)
            Next
        End If
        Dim pLastTrans As String = GetSetting("OP_WMS", "INFO_TASKS_ONLINE", "CMBTRANS", "N/A")
        Dim pLastTransArray() As String = pLastTrans.Split(",")
        Try
            For i = 0 To pLastTransArray.Length - 1
                For j = 0 To cmbTaskTypes_Filter.Properties.Items.Count - 1
                    If cmbTaskTypes_Filter.Properties.Items(j).Value.ToString.Trim = pLastTransArray(i).ToString.Trim Then
                        cmbTaskTypes_Filter.Properties.Items(j).CheckState = CheckState.Checked
                    End If
                Next j
            Next i
            cmbTaskTypes.Refresh()

            LoadGridLayout("TASKS_ONLINE", PublicLoginInfo.LoginID)
        Catch ex As Exception

        End Try

    End Sub


    Function PrepareStr(ByVal pType As String) As String

        Dim ptmp As String = ""

        If pType = "USERS" Then
            Try
                For J = 0 To cmbUsersOnTask_Filter.Properties.Items.Count - 1
                    If cmbUsersOnTask_Filter.Properties.Items(J).CheckState = CheckState.Checked Then
                        If string.IsNullOrEmpty(ptmp) Then
                            ptmp = cmbUsersOnTask_Filter.Properties.Items(J).Value.ToString
                        Else
                            ptmp = ptmp + "|" + cmbUsersOnTask_Filter.Properties.Items(J).Value.ToString
                        End If

                    End If
                Next J

            Catch ex As Exception
                ptmp = ""
            End Try
        Else

            Try
                For J = 0 To cmbTaskTypes_Filter.Properties.Items.Count - 1
                    If cmbTaskTypes_Filter.Properties.Items(J).CheckState = CheckState.Checked Then

                        If string.IsNullOrEmpty(ptmp) Then
                            ptmp = cmbTaskTypes_Filter.Properties.Items(J).Value.ToString
                        Else
                            ptmp = ptmp + "|" + cmbTaskTypes_Filter.Properties.Items(J).Value.ToString
                        End If

                    End If
                Next J

            Catch ex As Exception
                ptmp = ""
            End Try

        End If
        If ptmp <> "" Then
            Try
                Return ptmp
            Catch ex As Exception
                Return ""
            End Try
        Else
            Return ""
        End If
    End Function

    Sub ShowAllUsers(ByVal pTarget As String)

        Dim pResult = "OK"
        'Dim xserver As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
        'Dim xdata As DataSet = xserver.SearchPartialUserLogin("", "", "", "", pResult, PublicLoginInfo.Environment)
        'Dim xdata As DataSet = xserver.SearchOperators(pResult, PublicLoginInfo.Environment)
        Dim webServiceInfoTrans As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
        Dim xdata As DataTable = webServiceInfoTrans.GetOperatorAssignedToDistributionCenterByUser(PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)

        Dim xrow As DataRow

        If pTarget = "" Or pTarget = "GRID" Then
            If pResult = "OK" Then


                For Each xrow In xdata.Rows

                    Dim xitem As New DevExpress.XtraEditors.Controls.CheckedListBoxItem

                    xitem.Description = xrow("LOGIN_NAME").ToString
                    xitem.Value = xrow("LOGIN_ID").ToString
                    xitem.CheckState = CheckState.Checked
                    cmbUsersOnTask_Filter.Properties.Items.Add(xitem)

                    usersListView.Items.Add(xrow("LOGIN_ID").ToString, xrow("LOGIN_NAME").ToString, 0)
                    '12-Jul-20 J.R. se agrego un listado de usuarios en monitor reabastecimiento para poder crear tareas con dragdrop
                    usersListView2.Items.Add(xrow("LOGIN_ID").ToString, xrow("LOGIN_NAME").ToString, 0)

                Next

                Dim pLastUsers As String = GetSetting("OP_WMS", "INFO_TASKS_ONLINE", "CMBUSERS", "N/A")
                Dim pLastUsersArray() As String = pLastUsers.Split(",")
                Try
                    For i = 0 To pLastUsersArray.Length - 1
                        For J = 0 To cmbUsersOnTask_Filter.Properties.Items.Count - 1
                            If cmbUsersOnTask_Filter.Properties.Items(J).Description.ToString.Trim = pLastUsersArray(i).ToString.Trim Then
                                cmbUsersOnTask_Filter.Properties.Items(J).CheckState = CheckState.Checked
                                Exit For
                            End If
                        Next J
                    Next i

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try


            End If
        Else
            If pResult = "OK" Then
                LookUpUsers.DataSource = xdata
                LookUpUsers.DisplayMember = "LOGIN_NAME"
                LookUpUsers.ValueMember = "LOGIN_ID"
            End If
        End If

    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.GridView2.ShowCustomization()
    End Sub

    Private Sub Timer_Inventory_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Inventory.Tick
        RefreshDataView(pGlobalTaskView, pGlobalDateFilter, calender_filter.Selection)
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            SaveGridLayout("TASKS_ONLINE", PublicLoginInfo.LoginID, Me.GridView2)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim xrpt As New rptTransOnLine
        Dim xfilter As String = "", xfilter_caption As String = ""
        Cursor = Cursors.WaitCursor
        Try

            Try
                xrpt.DataSource = Me.uiTareas.DataSource
                xrpt.FilterString = "WAREHOUSE_ID='PICKING' AND " + Me.GridView2.ActiveFilterCriteria.ToString
                xrpt.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                xrpt.Parameters("ParamFilterApplied").Value = "Usuarios:[" + cmbUsersTask_Combo.ToString + "]Trans:[" + Me.cmbTaskTypes_Combo.ToString + "] " + " FechaInicial[" + Me.txtFechaInicial.DateTime.ToString + "] FechaFinal[" + Me.txtFechaFinal.DateTime.ToString + "] " + Me.GridView2.FilterPanelText.ToString

                xrpt.RequestParameters = False
                xrpt.ShowPreview()
                Cursor = Cursors.Default
            Catch ex As Exception
                xrpt.DataSource = Me.uiTareas.DataSource
                xrpt.FilterString = "WAREHOUSE_ID='PICKING' "
                xrpt.Parameters("ParamFilterApplied").Value = "Usuarios:[" + cmbUsersTask_Combo.ToString + "]Trans:[" + Me.cmbTaskTypes_Combo.ToString + "] " + " FechaInicial[" + Me.txtFechaInicial.DateTime.ToString + "] FechaFinal[" + Me.txtFechaFinal.DateTime.ToString + "] " + Me.GridView2.FilterPanelText.ToString

                xrpt.RequestParameters = False
                xrpt.ShowPreview()
                Cursor = Cursors.Default
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub usersListView_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles usersListView.ItemDrag
        Dim txtDrag As String
        Dim startPos, endPos As Integer


        startPos = InStr(e.Item.ToString, "{") + 1
        endPos = InStr(e.Item.ToString, "}")
        txtDrag = Mid(e.Item.ToString, startPos, endPos - startPos) + "|" + usersListView.FocusedItem.Name

        usersListView.DoDragDrop(txtDrag, DragDropEffects.Copy)

    End Sub


    '12-Jul-10 J.R. se agrego para crear tareas reabastecimiento haciendo dragdrop a los usuarios
    Private Sub usersListView2_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles usersListView2.ItemDrag
        Dim txtDrag As String
        Dim startPos, endPos As Integer


        startPos = InStr(e.Item.ToString, "{") + 1
        endPos = InStr(e.Item.ToString, "}")
        txtDrag = Mid(e.Item.ToString, startPos, endPos - startPos) + "|" + usersListView2.FocusedItem.Name

        usersListView2.DoDragDrop(txtDrag, DragDropEffects.Copy)

    End Sub

    Private Sub LookUpUsers_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles LookUpUsers.EditValueChanging

        If GridView2.IsFilterRow(GridView2.FocusedRowHandle) Then
            Exit Sub
        End If

        Dim pResult As String = ""


        Dim xrow As DataRow
        xrow = GridView2.GetDataRow(Me.GridView2.FocusedRowHandle)
        If xrow("TASK_TYPE") <> "TAREA_RECEPCION" Then
            e.Cancel = True
            Exit Sub
        End If

        If IsDBNull(xrow("IS_COMPLETED")) Then
            xrow("IS_COMPLETED") = "INCOMPLETA"
        End If
        If Not xrow("IS_COMPLETED") = "COMPLETA" Then


            If e.OldValue = "" OrElse MessageBox.Show("Confirma que desea re-asignar la tarea?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, False) = DialogResult.Yes Then

                Try

                    Dim pNewTaskUser As String = DirectCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue
                    Dim pNewAssignedUser As String = e.NewValue
                    'Dim pTaskID As Long = xrow("SERIAL_NUMBER")
                    'Dim wavePicking As Integer = xrow("WAVE_PICKING_ID")
                    'Dim materialId As String = xrow("MATERIAL_ID")
                    Dim wavePicking As Integer = 0
                    Dim materialId As String = ""
                    Dim serialNumber As String = 0

                    If xrow("WAVE_PICKING_ID").ToString = "" Or xrow("TASK_TYPE") = "TAREA_RECEPCION" Then
                        serialNumber = xrow("SERIAL_NUMBER")
                    Else
                        wavePicking = xrow("WAVE_PICKING_ID")
                        materialId = xrow("MATERIAL_ID")
                    End If


                    If Not ChangeTask_AssignedUser(serialNumber, wavePicking, materialId, pNewAssignedUser, pResult) Then
                        MessageBox.Show(pResult)
                        e.Cancel = True
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If

    End Sub
    Function ChangeTask_AssignedUser(ByVal serialNumber As Integer, ByVal wavePicking As Integer, ByVal materialId As String, ByVal newAssignedUser As String, ByRef pResult As String) As Boolean
        Try
            Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/trans/wms_tasksadmin.asmx")
            If Not xserv.UpdateAssignedTaskUser(serialNumber, wavePicking, materialId, newAssignedUser, pResult, PublicLoginInfo.Environment) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function
    Private Sub SetLayoutData(ByVal Data As String)
        If Data Is Nothing OrElse Data.Length = 0 Then Exit Sub

        Dim s As New IO.MemoryStream()
        Dim w As New IO.StreamWriter(s)
        w.AutoFlush = True

        Dim tmpPos As Integer = InStr(Data, "ActiveFilterString") + 20
        Dim tmpData As String = ""

        tmpData = Mid(Data, tmpPos + 1, Len(Data))
        tmpData = Replace(tmpData, """", "'")

        Data = Mid(Data, 1, tmpPos) + tmpData

        w.Write(Data)
        s.Position = 0
        Try

            GridView2.RestoreLayoutFromStream(s)
        Catch ex As Exception
            Throw New Exception("Wrong data format", ex)
        End Try
    End Sub
    Sub LoadGridLayout(ByVal pGridViewName As String, ByVal pUserID As String)
        Try 'save the layout
            Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
            Dim pResult As String = "", pLayoutString As String = ""
            Dim xData As DataSet
            Dim pStream As New MemoryStream

            xData = xserv.SearchByKeyGridLayouts(pGridViewName, pUserID, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then 'then restore a layout.
                SetLayoutData(xData.Tables(0).Rows(0)("LAYOUT_XML"))
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub TaskStatusCombo_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs)


        If GridView2.IsFilterRow(GridView2.FocusedRowHandle) Then
            e.Cancel = False
            Exit Sub
        Else
            If e.NewValue = 2 Then
                e.Cancel = True
                Exit Sub
            End If
        End If


        Dim pResult As String = ""
        Try
            If MessageBox.Show("Confirma que desea cambiar el estado de la tarea?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, False) = DialogResult.Yes Then

                Try
                    Dim pNewTaskStatus As String = e.NewValue

                    Dim xrow As DataRow
                    xrow = GridView2.GetDataRow(Me.GridView2.FocusedRowHandle)
                    'Dim pTaskID As Long = xrow("SERIAL_NUMBER")
                    Dim wavePicking As Integer = xrow("WAVE_PICKING_ID")
                    Dim materialId As String = xrow("MATERIAL_ID")

                    If Not ChangeTask_Status(wavePicking, pNewTaskStatus, pResult) Then
                        MessageBox.Show(pResult)
                        e.Cancel = True
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                e.Cancel = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End Try

    End Sub

    Function ChangeTask_Status(ByVal wavePicking As Integer, ByVal pNewTaskStatus As Integer, ByRef pResult As String) As Boolean
        Try
            Cursor = Cursors.WaitCursor
            Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/trans/wms_tasksadmin.asmx")
            If Not xserv.UpdateStatusTaskUser(wavePicking, pNewTaskStatus, pResult, PublicLoginInfo.Environment) Then
                Cursor = Cursors.Default
                Return False
            Else
                Cursor = Cursors.Default
                Return True
            End If
        Catch ex As Exception
            Cursor = Cursors.Default

            pResult = ex.Message
            Return False
        End Try
    End Function

    Private Sub cmdPauseTasks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPauseTasks.Click
        Try
            If GridView2.SelectedRowsCount >= 1 Then
                Cursor = Cursors.WaitCursor
                ChangeStatus_SelectedTask(1)
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function ChangeStatus_SelectedTask(ByVal pNewStat As Integer) As String
        Dim pResult As String = ""
        'ojo
        If MessageBox.Show("Confirma que desea cambiar el estado de " & GridView2.SelectedRowsCount & " tareas?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, False) = DialogResult.Yes Then

            Try
                Dim pNewTaskStatus As Integer = pNewStat

                Dim xrow As DataRow
                Dim xcount As Integer = 0

                For i = 0 To GridView2.RowCount - 1
                    If xcount <= GridView2.SelectedRowsCount Then

                        If GridView2.IsRowSelected(i) Then

                            xrow = GridView2.GetDataRow(i)

                            If xrow("IS_ACCEPTED").ToString = "0" Then

                                If xrow("TASK_TYPE") = "TAREA_RECEPCION" Then
                                    Dim serialNumber As Long = xrow("SERIAL_NUMBER")
                                    If Not xrow("IS_PAUSED") = 2 Then
                                        If Not ChangeTask_Status_BySerialNumber(pNewTaskStatus, serialNumber, pResult) Then
                                            MessageBox.Show(pResult)
                                            Return ""
                                        Else
                                            GridView2.SetRowCellValue(i, "IS_PAUSED", pNewStat)
                                        End If
                                        xcount = xcount + 1
                                    End If

                                ElseIf xrow("TASK_TYPE") = "TAREA_PICKING" Then
                                    Dim wavePicking As Integer = xrow("WAVE_PICKING_ID")
                                    If Not xrow("IS_PAUSED") = 2 And xrow("USE_PICKING_LINE") <> 1 Then
                                        If Not ChangeTask_Status(wavePicking, pNewTaskStatus, pResult) Then
                                            MessageBox.Show(pResult)
                                            Return ""
                                        Else
                                            GridView2.SetRowCellValue(i, "IS_PAUSED", pNewStat)
                                        End If
                                        xcount = xcount + 1
                                    Else
                                        xcount = xcount + 1
                                    End If

                                ElseIf xrow("TASK_TYPE") = "TAREA_CONTEO_FISICO" Then
                                    If xrow("IS_COMPLETED") = "INCOMPLETA" Then
                                        Dim status As String = If(pNewStat = 1, "PAUSAR", "REANUDAR")
                                        Dim taskId As Integer = xrow("TASK_ID")
                                        If Not ChangeTask_Status_By_Task_id(taskId, status, pResult) Then
                                            MessageBox.Show(pResult)
                                            Return ""
                                        Else
                                            GridView2.SetRowCellValue(i, "IS_PAUSED", pNewStat)
                                        End If
                                        xcount = xcount + 1
                                    Else
                                        xcount = xcount + 1
                                    End If
                                End If
                            Else
                                MessageBox.Show("La tarea no se puede cambiar de estado, por que ya fue aceptada")
                            End If

                        End If
                    Else
                        Exit For
                    End If

                Next


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Return ""
        End If

        Return ""
    End Function

    Private Function ChangeTask_Status_By_Task_id(taskId As Integer, status As String, pResult As String) As Boolean
        Try
            Cursor = Cursors.WaitCursor
            Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/trans/wms_tasksadmin.asmx")
            If Not xserv.UpdateTaskByTaskId(taskId, status, pResult, PublicLoginInfo.Environment) Then
                Cursor = Cursors.Default
                Return False
            Else
                Cursor = Cursors.Default
                Return True
            End If
        Catch ex As Exception
            Cursor = Cursors.Default

            pResult = ex.Message
            Return False
        End Try
    End Function


    Private Sub cmdPlayTasks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPlayTasks.Click
        Try
            If GridView2.SelectedRowsCount >= 1 Then
                Cursor = Cursors.WaitCursor
                ChangeStatus_SelectedTask(0)
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Try

            If UiVistaDetallePicking.SelectedRowsCount >= 1 Then
                Cursor = Cursors.WaitCursor
                Delete_SelectedTask_Detail()
                Cursor = Cursors.Default
            End If

            If GridView2.SelectedRowsCount >= 1 And UiVistaDetallePicking.SelectedRowsCount = 0 Then
                Cursor = Cursors.WaitCursor
                UiContenedorDetalle.DataSource = Nothing
                Delete_SelectedTask()
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function Delete_SelectedTask_Detail() As String
        If MessageBox.Show("Confirma eliminación de " & UiVistaDetallePicking.SelectedRowsCount & " detalles de una tarea?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, False) = DialogResult.Yes Then
            Dim xserver As New OnePlanServices_Trans.WMS_TransSoapClient("WMS_TransSoap", PublicLoginInfo.WSHost + "/trans/wms_trans.asmx")

            Dim fila As DataRow
            Dim contador As Integer = 0
            Dim filasSeleccionadas As Integer = UiVistaDetallePicking.SelectedRowsCount
            For i = 0 To UiVistaDetallePicking.RowCount - 1

                If contador < filasSeleccionadas Then
                    If UiVistaDetallePicking.IsRowSelected(i) Then
                        fila = UiVistaDetallePicking.GetDataRow(i)
                        Dim wavePickingId As Integer = fila("WAVE_PICKING_ID")
                        Dim materialId As String = fila("MATERIAL_ID")
                        Dim pResult = ""
                        If (fila("IS_COMPLETED") = "INCOMPLETA" Or fila("IS_COMPLETED") = "ACEPTADA") And fila("USE_PICKING_LINE") <> 1 Then

                            If Not xserver.CancelPickingDetailLine(wavePickingId, PublicLoginInfo.LoginID, materialId, PublicLoginInfo.Environment, pResult) Then
                                If Not String.IsNullOrEmpty(pResult) Then
                                    NotifyStatus(pResult, True, True)
                                End If
                            End If
                            contador = contador + 1
                            btnGo_DateRange_Click(Nothing, Nothing)
                        Else
                            contador = contador + 1
                        End If
                    End If
                Else
                    Exit For
                End If
            Next

        Else
            Return ""
        End If
        Return ""
    End Function

    Public Function Delete_SelectedTask() As String
        Dim pResult As String = ""

        If MessageBox.Show("Confirma eliminación de " & GridView2.SelectedRowsCount & " tareas?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, False) = DialogResult.Yes Then

            Try
                Dim xrow As DataRow
                Dim xcount As Integer = 0
                Dim filasSeleccionadas As Integer = GridView2.SelectedRowsCount
                CleanUpResults()
                For i = 0 To GridView2.RowCount - 1
                    If xcount < filasSeleccionadas Then

                        If GridView2.IsRowSelected(i) Then

                            xrow = GridView2.GetDataRow(i)

                            If xrow("IS_ACCEPTED").ToString = "0" Then


                                If xrow("TASK_TYPE") = "TAREA_RECEPCION" Then
                                    If xrow("IS_PAUSED") <= 1 Then
                                        Dim serialNumber As Long = xrow("SERIAL_NUMBER")
                                        If Not DeleteTaskBySerialNumber(serialNumber, pResult) Then

                                        Else
                                            pGlobalDateFilter = "BY_DATERANGE"


                                        End If
                                        xcount = xcount + 1
                                    Else
                                        xcount = xcount + 1
                                    End If
                                End If
                                If xrow("TASK_TYPE") = "TAREA_PICKING" Then
                                    Dim pTaskID As Long = xrow("WAVE_PICKING_ID")

                                    If xrow("IS_PAUSED") <= 1 And xrow("USE_PICKING_LINE") <> 1 Then
                                        If Not DeleteTask(pTaskID, pResult) Then
                                            If Not String.IsNullOrEmpty(pResult) Then
                                                NotifyStatus(pResult, True, True)
                                            End If

                                        Else
                                            pGlobalDateFilter = "BY_DATERANGE"

                                        End If
                                        xcount = xcount + 1
                                    Else
                                        xcount = xcount + 1
                                    End If

                                End If

                                If xrow("TASK_TYPE") = "TAREA_CONTEO_FISICO" Then
                                    Dim taskID As Long = xrow("TASK_ID")
                                    If xrow("IS_COMPLETED") = "INCOMPLETA" Then
                                        If Not DeleteCountingTask(taskID, pResult) Then
                                            If Not String.IsNullOrEmpty(pResult) Then
                                                NotifyStatus(pResult, True, True)
                                            End If

                                        Else
                                            pGlobalDateFilter = "BY_DATERANGE"


                                        End If
                                        xcount = xcount + 1
                                    Else
                                        xcount = xcount + 1
                                    End If

                                End If
                            Else
                                MessageBox.Show("La tarea no se puede cambiar de estado, por que ya fue aceptada")
                            End If


                        End If
                    Else
                        Exit For
                    End If

                Next
                RefreshDataView("VIEW_TASK", pGlobalTaskView, calender_filter.Selection)
                Me.GridView2.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Return ""
        End If

        Return ""
    End Function

    Private Function DeleteCountingTask(taskId As Integer, pResult As String) As Boolean
        Try
            Cursor = Cursors.WaitCursor
            Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/trans/wms_tasksadmin.asmx")
            If Not xserv.DeleteCountingTask(taskId, PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment) Then
                Cursor = Cursors.Default
                Return False
            Else
                Cursor = Cursors.Default
                Return True
            End If
        Catch ex As Exception
            Cursor = Cursors.Default

            pResult = ex.Message
            Return False
        End Try
    End Function

    Function DeleteTask(ByVal pTaskID As Long, ByRef pResult As String) As Boolean
        Try
            Cursor = Cursors.WaitCursor
            Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/trans/wms_tasksadmin.asmx")
            If Not xserv.DeleteTask(pTaskID, PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment) Then
                Cursor = Cursors.Default
                Return False
            Else
                Cursor = Cursors.Default
                Return True
            End If
        Catch ex As Exception
            Cursor = Cursors.Default

            pResult = ex.Message
            Return False
        End Try
    End Function

    Private Sub NavBarControlTaskOnLine_ActiveGroupChanged(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarGroupEventArgs)
        Select Case e.Group.Name
            Case "NavBarGroup_PendingDemand"

                AdjustToolbarItems(True)

                'PendingDemandToolBar.Visible = True
                'PendingDemandToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top

                '25-Abr-11 J.R. mostrar pedidos pendientes de picking
                'pGlobalTaskView = "VIEW_DEMAND"
                'Me.uiTareas.MainView = GridViewDemandPending
                Try

                    If TreeList_Demand.FocusedNode.Id = "3" Then
                        pGlobalTaskView = "VIEW_PENDINGPICKING"
                        Me.uiTareas.MainView = GridViewPendingPicking
                    Else
                        pGlobalTaskView = "VIEW_DEMAND"
                        Me.uiTareas.MainView = GridViewDemandPending
                    End If

                    'If TreeView_Demand.SelectedNode.Name = "Node_PendPick" Then
                    '    pGlobalTaskView = "VIEW_PENDINGPICKING"
                    '    Me.uiTareas.MainView = GridViewPendingPicking
                    'Else
                    '    pGlobalTaskView = "VIEW_DEMAND"
                    '    Me.uiTareas.MainView = GridViewDemandPending
                    'End If
                Catch ex As Exception
                    pGlobalTaskView = "VIEW_DEMAND"
                    Me.uiTareas.MainView = GridViewDemandPending
                End Try

                'RefreshDataView(pGlobalTaskView, pGlobalDateFilter)
                SaveSetting("ONE_PLAN", "USER_CONFIG", "LAST_LEFTMENU", e.Group.Name)

            Case "NavBarGroupNewTask"
                AdjustToolbarItems(False)
                'PendingDemandToolBar.Visible = False
                'PendingDemandToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.None
                pGlobalTaskView = "VIEW_TASK"
                Me.uiTareas.MainView = GridView2
                ' RefreshDataView(pGlobalTaskView, pGlobalDateFilter)
                SaveSetting("ONE_PLAN", "USER_CONFIG", "LAST_LEFTMENU", e.Group.Name)

            Case "NavBarGroupUsers"
                AdjustToolbarItems(False)
                'PendingDemandToolBar.Visible = False
                'PendingDemandToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
                pGlobalTaskView = "VIEW_TASK"
                Me.uiTareas.MainView = GridView2
                'RefreshDataView(pGlobalTaskView, pGlobalDateFilter)
                SaveSetting("ONE_PLAN", "USER_CONFIG", "LAST_LEFTMENU", e.Group.Name)

            Case "NavBarGroup_Replenish"

                AdjustToolbarItems(False)
                'PendingDemandToolBar.Visible = False
                'PendingDemandToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.None
                pGlobalTaskView = "VIEW_REPLENISHMENT"
                Me.uiTareas.MainView = GridViewReplenishment
                'RefreshDataView(pGlobalTaskView, pGlobalDateFilter)
                SaveSetting("ONE_PLAN", "USER_CONFIG", "LAST_LEFTMENU", e.Group.Name)

                Dim xservSettings As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
                Dim xdsSettings As New DataSet
                Dim pResult As String = ""

                Try
                    xdsSettings = xservSettings.GetParam_ByParamKey("SISTEMA", "REABASTECIMIENTO", "PORCENTAJE_LLEGAR_MINIMO", pResult, PublicLoginInfo.Environment)
                    If pResult = "OK" Then
                        dblPorcentajeLlegarMinimo = xdsSettings.Tables(0).Rows(0)("NUMERIC_VALUE")
                    Else
                        dblPorcentajeLlegarMinimo = 10
                    End If
                Catch ex As Exception
                    dblPorcentajeLlegarMinimo = 0
                End Try

            Case "NavBarGroup_DocsReport"
                '11-Mar-11 J.R. Reporte de pedidos recibidos vs consolidados

                AdjustToolbarItems(False)
                'PendingDemandToolBar.Visible = False
                'PendingDemandToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.None
                pGlobalTaskView = "VIEW_DOCSREPORT"
                Me.uiTareas.MainView = GridViewDocsReport
                'RefreshDataView(pGlobalTaskView, pGlobalDateFilter)
                SaveSetting("ONE_PLAN", "USER_CONFIG", "LAST_LEFTMENU", e.Group.Name)


        End Select

    End Sub
    Public Sub AdjustToolbarItems(ByVal pVisible As Boolean)
        btnCrearTareas.Visibility = IIf(pVisible, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        btnExpandAll.Visibility = IIf(pVisible, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        btnCollapseAll.Visibility = IIf(pVisible, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        btnSelectAll.Visibility = IIf(pVisible, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        btnUnSelectAll.Visibility = IIf(pVisible, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
    End Sub
    Private Sub BarItem_NewPickingA_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs)
        Dim xfrm As New frmCreatePickingD
        xfrm.ShowDialog()

    End Sub

    Private Sub btnGo_Calendar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            pGlobalDateFilter = "BY_CALENDAR"
            RefreshDataView(pGlobalTaskView, "BY_CALENDAR", calender_filter.Selection)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function RefreshDataView(ByVal pService_Type As String, ByVal pDateFilter_Type As String, ByVal rangoFechas As DatesCollection)
        _rangoPrevioDeFechas = rangoFechas
        Dim ps_GridView As New Basic_TaskView
        Dim pResult As String = ""

        '29Jun10 J.R. se puso este catch porque luego de asignar tareas se hace un refresh perocuando el grid quedaba en blanco (filtrado) daba error
        Try

            Cursor = Cursors.WaitCursor


            If pService_Type = "VIEW_TASK" Then
                ps_GridView.lstUsers = PrepareStr("USERS")
                ps_GridView.lstTasksTypes = PrepareStr("TASKS")

                '09-Jul-10 J.R. se agrego para mostrar list de usuarios en opcion de replenishment 
            ElseIf pService_Type = "VIEW_REPLENISHMENT" Then
                '   ps_GridView.lstUsers = PrepareStr("USER")
            End If
            Me.uiTareas.DataSource = Nothing

            ps_GridView.objDataGrid = Me.uiTareas
            ps_GridView.pServiceType = pService_Type
            ps_GridView.pDateFilterType = pDateFilter_Type

            Select Case pDateFilter_Type
                Case "BY_CALENDAR"
                    For i = 0 To rangoFechas.Count - 1
                        ps_GridView.pDates = ps_GridView.pDates + "'" + Format(rangoFechas.Item(i).Date, "yyyy-MM-dd") + "',"
                    Next
                    ps_GridView.pDates = Mid(ps_GridView.pDates, 1, Len(ps_GridView.pDates) - 1)
                Case Else
                    ps_GridView.pSinceDate = Me.txtFechaInicial.DateTime
                    ps_GridView.pToDate = Me.txtFechaFinal.DateTime
                    If ps_GridView.pSinceDate > ps_GridView.pToDate Then
                        Cursor = Cursors.Default
                        MessageBox.Show("Fecha inicial debe ser menor o igual a la Fecha final")
                        Return ""
                    End If

            End Select

            ps_GridView.pDemandView = pPendingView
            ps_GridView.RefreshGrid(pResult)

            If pResult = "OK" Then
                If pService_Type = "VIEW_TASK" Then
                    GridView2.ExpandAllGroups()
                    LoadGridLayout("TASK_ONLINE", PublicLoginInfo.LoginID)
                    '22-Jun-11 J.R. mejorar tiempo de respuesta
                    'GridView2.BestFitColumns()

                    '07-Jul-10 J.R. para mostrar informacion de replenishment en el grid
                ElseIf pService_Type = "VIEW_REPLENISHMENT" Then

                    LoadGridLayout("REPLENISHMENT_ONLINE", PublicLoginInfo.LoginID)

                    '13-Jul-10 J.R. se agrego para manejar el limite por configuracion pero no funciona, chequear
                    GridViewReplenishment.FormatConditions(1).Value1 = dblPorcentajeLlegarMinimo
                    GridViewReplenishment.FormatConditions(1).Value2 = ""

                    GridViewReplenishment.BestFitColumns()

                ElseIf pService_Type = "VIEW_DOCSREPORT" Then

                    'LoadGridLayout("REPLENISHMENT_ONLINE", PublicLoginInfo.LoginID)
                    GridViewDocsReport.BestFitColumns()

                Else

                    LoadGridLayout("DEMANDLIST_ONLINE", PublicLoginInfo.LoginID)
                    GridViewDemandPending.BestFitColumns()

                    If pPendingView = "PENDING" Then

                        Me.TreeList_Demand.Nodes(0).SetValue(1, GridViewDemandPending.DataRowCount)

                    ElseIf pPendingView = "VOIDED" Then
                        Me.TreeList_Demand.Nodes(2).SetValue(1, GridViewDemandPending.DataRowCount)
                    Else
                        Me.TreeList_Demand.Nodes(1).SetValue(1, GridViewDemandPending.DataRowCount)
                    End If
                    Me.TreeList_Demand.Refresh()
                    'Me.TreeView_Demand.Refresh()
                End If

                ShowAllUsers("CMBUSERS")
                RibbonForm1.Static_Message.Caption = "..."
            Else
                RibbonForm1.Static_Message.Caption = pResult
                RibbonForm1.Static_Message.Refresh()
            End If


            Cursor = Cursors.Default

            If pResult = "OK" Then
                If pService_Type = "VIEW_TASK" Then
                    SaveSetting("OP_WMS", "INFO_TASKS_ONLINE", "CMBUSERS", cmbUsersOnTask_Filter.Text)
                    SaveSetting("OP_WMS", "INFO_TASKS_ONLINE", "CMBTRANS", cmbTaskTypes_Filter.Text)
                End If
            Else
                Cursor = Cursors.Default
            End If
            Return ""

            MostrarBotonErp()
        Catch ex As Exception  '29Jun10 J.R. se puso este catch porque luego de asignar tareas se hace un refresh perocuando el grid quedaba en blanco (filtrado) daba error

            Cursor = Cursors.Default
            Return ""

        End Try

    End Function

    Private Sub btnGo_DateRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo_DateRange.Click
        Try
            pGlobalDateFilter = "BY_DATERANGE"
            UiContenedorDetalle.DataSource = Nothing
            RefreshDataView(pGlobalTaskView, "BY_DATERANGE", calender_filter.Selection)
            _graficasGenerdas = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub chkBtn3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBtn3.CheckedChanged
        Dim pDiffDate As Date
        pDiffDate = DateAdd(DateInterval.Month, -3, Now)

        Me.txtFechaInicial.DateTime = pDiffDate
        Me.txtFechaFinal.DateTime = Now.Date
        Try
            pGlobalDateFilter = "BY_DATERANGE"
            'RefreshDataView(pGlobalTaskView, "BY_DATERANGE")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkBtn1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBtn1.CheckedChanged
        Dim pDiffDate As Date
        pDiffDate = DateAdd(DateInterval.Month, -1, Now)

        Try
            EstablecerFechas(pDiffDate)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EstablecerFechas(fechaInicial As Date, Optional ByVal fechaFinal As Date = Nothing)
        Try
            txtFechaInicial.DateTime = fechaInicial
            txtFechaFinal.DateTime = IIf(fechaFinal = Nothing, DateTime.Now, fechaFinal)
            pGlobalDateFilter = "BY_DATERANGE"
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Mobility SCM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub chkBtnW_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBtnW.CheckedChanged
        EstablecerFechas(DateAdd(DateInterval.Day, -7, Now))
    End Sub

    Private Sub chkBtnY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBtnY.CheckedChanged
        EstablecerFechas(DateAdd(DateInterval.Day, -1, Now))
    End Sub

    Private Sub btnToday_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToday.CheckedChanged
        EstablecerFechas(DateTime.Now, Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
    End Sub

    Private Sub btnAutoRefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        RefreshDataView(pGlobalTaskView, pGlobalDateFilter, calender_filter.Selection)
    End Sub

    Private Sub btnSetAutoFresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSetAutoFresh.ItemClick
        Timer_Inventory.Enabled = IIf(Timer_Inventory.Enabled, False, True)

        btnSetAutoFresh.Caption = IIf(Me.Timer_Inventory.Enabled, "Actualización automatica", "Actualizacion manual")
        RefreshDataView(pGlobalTaskView, pGlobalDateFilter, calender_filter.Selection)
    End Sub

    Private Sub btnSetPauseRefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSetPauseRefresh.ItemClick
        Timer_Inventory.Enabled = IIf(Timer_Inventory.Enabled, False, True)
        btnSetAutoFresh.Caption = IIf(Me.Timer_Inventory.Enabled, "Actualización automatica", "Actualizacion manual")

    End Sub



    Private Sub NavBarControlTaskOnLine_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs)
        Select Case e.Link.ItemName
            Case "NavBarItemMonitorTask"
                RefreshDataView("VIEW_TASK", pGlobalDateFilter, calender_filter.Selection)
        End Select
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


    Public Sub MergePdfFilesDevExpress(destXlsxFileName As String, sheetNames As String(), ParamArray sourceXlsxFileNames As String())
        Dim pdfDocumentProcessor As New PdfDocumentProcessor()
        pdfDocumentProcessor.LoadDocument(sourceXlsxFileNames(0))

        For i As Integer = LBound(sourceXlsxFileNames) + 1 To UBound(sourceXlsxFileNames) Step 1
            Dim sourceXlsxFile As String = sourceXlsxFileNames(i)
            pdfDocumentProcessor.AppendDocument(sourceXlsxFile)
        Next
        pdfDocumentProcessor.SaveDocument(destXlsxFileName)
    End Sub




    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSendToExcel.ItemClick
        Dim pFileName As String = ""

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            pFileName = SaveFileDialog1.FileName


            Dim sheetNames() As String = {"Tareas", "Tareas Por Operador", "Tiempo Promedio"}

            GridView2.ExportToXls(pFileName + GridView2.Name + ".xls")
            If _graficasGenerdas Then
                CType(UiChartControlTasks, IChartContainer).Chart.ExportToXls(pFileName + UiChartControlTasks.Name + ".xls")
                CType(UiChartControlTimeTaskByUsers, IChartContainer).Chart.ExportToXls(pFileName + UiChartControlTimeTaskByUsers.Name + ".xls")
                Dim arrArchivosXls() As String = {pFileName + GridView2.Name + ".xls", pFileName + UiChartControlTasks.Name + ".xls", pFileName + UiChartControlTimeTaskByUsers.Name + ".xls"}
                MergeXlsxFilesDevExpress(pFileName, sheetNames, arrArchivosXls)
            Else
                Dim arrArchivosXls() As String = {pFileName + GridView2.Name + ".xls"}
                MergeXlsxFilesDevExpress(pFileName, sheetNames, arrArchivosXls)
            End If

        End If

    End Sub

    Private Sub TreeView_Demand_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)
    End Sub

    Private Sub TreeView_Demand_Click(ByVal sender As Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub TreeView_Demand_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs)

        '25-Abr-11 J.R. mostrar pedidos pendientes de picking
        Dim strTipoView As String = "VIEW_DEMAND"

        Select Case e.Node.Name
            Case "Node_Pending"
                pPendingView = "PENDING"
                Me.btnCrearTareas.Enabled = True
                Me.uiTareas.MainView = GridViewDemandPending  '25-Abr-11 J.R. mostrar pedidos pendientes de picking
            Case "Node_Root"
                pPendingView = "PENDING"
                Me.btnCrearTareas.Enabled = True
                Me.uiTareas.MainView = GridViewDemandPending  '25-Abr-11 J.R. mostrar pedidos pendientes de picking
            Case "Node_Voided"
                pPendingView = "VOIDED"
                Me.btnCrearTareas.Enabled = False
                Me.uiTareas.MainView = GridViewDemandPending  '25-Abr-11 J.R. mostrar pedidos pendientes de picking
            Case "Node_PendPick"
                pPendingView = "PENDPICK"
                Me.btnCrearTareas.Enabled = False
                strTipoView = "VIEW_PENDINGPICKING"
                Me.uiTareas.MainView = GridViewPendingPicking
            Case Else
                pPendingView = "ASSIGNED"
                Me.btnCrearTareas.Enabled = False
                Me.uiTareas.MainView = GridViewDemandPending  '25-Abr-11 J.R. mostrar pedidos pendientes de picking
        End Select

        '25-Abr-11 J.R. mostrar pedidos pendientes de picking
        'RefreshDataView("VIEW_DEMAND", pGlobalDateFilter)
        RefreshDataView(strTipoView, pGlobalDateFilter, calender_filter.Selection)

    End Sub

    Private Sub btnCrearTareas_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCrearTareas.ItemClick

        Dim xrow As DataRow
        Dim pResult As String = ""
        Try

            If MessageBox.Show("Confirma el procesamiento de " & GridViewDemandPending.SelectedRowsCount & " Pedido(s) a la Linea pre-asignada?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) = DialogResult.Yes Then
                CleanUpResults()

                For i = 0 To GridViewDemandPending.RowCount - 1
                    If GridViewDemandPending.IsMasterRow(i) Then

                        If GridViewDemandPending.IsRowSelected(i) Then

                            xrow = GridViewDemandPending.GetDataRow(i)

                            If Not IsDBNull(xrow("ASSIGNED_TO_LINE")) Then
                                If xrow("ASSIGNED_TO_LINE").ToString.Trim <> "" Then

                                    If Not CreateTasks(xrow("ERP_DOCUMENT"), xrow("ASSIGNED_TO_LINE"), pResult) Then
                                        '22-Jun-11 J.R
                                        'AddMessageToResult("ERROR", "ERROR," + xrow("ERP_DOCUMENT") + " " + xrow("CLIENT_NAME"), pResult)
                                        AddMessageToResult("ERROR", "ERROR Pedido:", xrow("ERP_DOCUMENT").ToString, xrow("CLIENT_NAME").ToString, pResult)
                                        intNoAsignados += 1
                                    Else
                                        '22-Jun-11 J.R
                                        'AddMessageToResult("SUCCESS", "OK, Pedido: " + xrow("ERP_DOCUMENT") + " " + xrow("CLIENT_NAME"), "")
                                        AddMessageToResult("SUCCESS", "OK Pedido->", xrow("ERP_DOCUMENT").ToString, xrow("CLIENT_NAME").ToString, "")
                                        intAsignados += 1
                                        '28Jun10 J.R. no funcionaba porque este delete hacia que el for pelara cable y ya no seguia procesando pedidos
                                        'GridViewDemandPending.DeleteRow(i)
                                    End If

                                End If
                            End If
                        End If

                    End If
                Next


                '28Jun10 J.R. se puso este refresh porque el delete de arriba no funcionaba porque este delete hacia que el for pelara cable y ya no seguia procesando pedidos
                RefreshDataView("VIEW_DEMAND", pGlobalDateFilter, calender_filter.Selection)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '14-Abr-11 J.R. Se agrego parametro pLineaID, ahora el boton asignar asume que cada pedido ya tiene linea asignada, cuando se usa el dropdown, se fuerza la asignacion a la linea clickeada
    Public Function CreateTasks(ByVal pDoc As String, ByVal pLineaID As String, ByRef pResult As String) As Boolean
        Try
            Dim xserver As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/trans/WMS_TasksAdmin.asmx")
            'FRM
            '10Ag2010 
            'Ya no crear tarea, sino que simplemente marcar el documento como disponible para picking ALLOWED_TO_PICK.
            'If Not xserver.CreatePickingFromDemand("PICKING", cmbLineas.EditValue.ToString, pDoc, PublicLoginInfo.LoginID, "", pResult, PublicLoginInfo.Environment) Then

            '14-Abr-11 J.R.
            'If Not xserver.MarkAllowedToPicking("PICKING", cmbLineas.EditValue.ToString, pDoc, PublicLoginInfo.LoginID, "", pResult, PublicLoginInfo.Environment) Then
            If Not xserver.MarkAllowedToPicking("PICKING", pLineaID, pDoc, PublicLoginInfo.LoginID, "", pResult, PublicLoginInfo.Environment) Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return False
        End Try
    End Function

    '12-Jul-10 J.R. para crear tareas de replenishment
    Public Function CreateTasksReplenishment(ByVal pUser As String, ByVal pRow As DataRow, ByRef pResult As String) As Boolean
        Try
            Dim xserver As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/trans/WMS_TasksAdmin.asmx")

            'If Not xserver.CreateReplenishment(xrow("WAREHOUSE_PARENT").ToString, cmbLineas.EditValue.ToString, pDoc, PublicLoginInfo.LoginID, "", pResult, PublicLoginInfo.Environment) Then
            '********14-Jul-10 J.R. se puso STORAGE_PICKING hard coded pero deberia venir de algun lado, revisar!!!
            If Not xserver.CreateReplenishment("STORAGE_PICKING", pRow("WAREHOUSE_PARENT").ToString, PublicLoginInfo.LoginID, pUser, pRow("MATERIAL_ID").ToString, pRow("MATERIAL_ID").ToString, "", pRow("LOCATION_SPOT").ToString, pRow("QUANTITY_TO_REPLENISH").ToString, pRow("QUANTITY_TO_REPLENISH").ToString, "", pResult, PublicLoginInfo.Environment) Then
                '22-Jun-11 J.R
                'AddMessageToResult("ERROR", "No se pudo crear tarea Reabastecimiento para Producto:" + pRow("MATERIAL_ID") + " en Ubicacion: " + pRow("LOCATION_SPOT"), pResult)
                AddMessageToResult("ERROR", "No se pudo crear tarea Reabastecimiento para Producto:" + pRow("MATERIAL_ID") + " en Ubicacion: " + pRow("LOCATION_SPOT"), "", "", pResult)
                Return False
            Else
                '22-Jun-11 J.R
                'AddMessageToResult("SUCCESS", "Tarea Reabastecimiento creada para Producto:" + pRow("MATERIAL_ID") + " en Ubicacion: " + pRow("LOCATION_SPOT"), pResult)
                AddMessageToResult("SUCCESS", "Tarea Reabastecimiento creada para Producto:" + pRow("MATERIAL_ID") + " en Ubicacion: " + pRow("LOCATION_SPOT"), "", "", pResult)
                pResult = "OK"
                Return True
            End If

        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return False
        End Try
    End Function

    Private Sub GridViewDemandPending_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)

    End Sub

    Private Sub GridViewDemandPending_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub btnExpandAll_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExpandAll.ItemClick

        Try
            GridView2.ExpandAllGroups()
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub btnCollapseAll_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCollapseAll.ItemClick
        Try
            GridView2.CollapseAllGroups()
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub btnSelectAll_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSelectAll.ItemClick
        GridView2.SelectAll()
    End Sub

    Private Sub btnUnSelectAll_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnUnSelectAll.ItemClick

        Try
            Cursor = Cursors.WaitCursor
            For i = 0 To GridView2.RowCount - 1
                GridView2.UnselectRow(i)
            Next i
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridViewDemandPending_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            If GridViewDemandPending.IsMasterRow(GridViewDemandPending.FocusedRowHandle) Then
                GridViewDemandPending.SetMasterRowExpanded(GridViewDemandPending.FocusedRowHandle, Not GridViewDemandPending.GetMasterRowExpanded(GridViewDemandPending.FocusedRowHandle))
            End If
        End If

    End Sub



    Private Sub GridViewDemandPending_MasterRowExpanded(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs)
        Dim detailView As DevExpress.XtraGrid.Views.Grid.GridView
        detailView = GridViewDemandPending.GetDetailView(e.RowHandle, e.RelationIndex)

        detailView.Columns("Documento").OptionsColumn.ReadOnly = True
        detailView.Columns("Documento").Visible = False

        detailView.Columns("Codigo").OptionsColumn.ReadOnly = True

        detailView.Columns("Description").OptionsColumn.ReadOnly = True
        detailView.Columns("Description").OptionsColumn.AllowFocus = False
        detailView.Columns("Description").Width = 180

        detailView.Columns("Cantidad").OptionsColumn.ReadOnly = True
        detailView.Columns("Cantidad").OptionsColumn.AllowFocus = False

        detailView.Columns("InvLinea_1").OptionsColumn.ReadOnly = True
        detailView.Columns("InvLinea_1").OptionsColumn.AllowFocus = False
        detailView.Columns("InvLinea_1").OptionsFilter.AllowAutoFilter = False
        detailView.Columns("InvLinea_1").OptionsFilter.AllowFilter = False

        detailView.Columns("InvLinea_2").OptionsColumn.ReadOnly = True
        detailView.Columns("InvLinea_2").OptionsColumn.AllowFocus = False
        detailView.Columns("InvLinea_2").OptionsFilter.AllowAutoFilter = False
        detailView.Columns("InvLinea_2").OptionsFilter.AllowFilter = False

        detailView.Columns("InvLinea_3").OptionsColumn.ReadOnly = True
        detailView.Columns("InvLinea_3").OptionsColumn.AllowFocus = False
        detailView.Columns("InvLinea_3").OptionsFilter.AllowAutoFilter = False
        detailView.Columns("InvLinea_3").OptionsFilter.AllowFilter = False

        detailView.Columns("InvLinea_1").Visible = False
        detailView.Columns("InvLinea_2").Visible = True
        detailView.Columns("InvLinea_3").Visible = False

    End Sub
    Sub AddMessageToResult(ByVal pType As String, ByVal pCaption As String, ByVal pPedidoNumero As String, ByVal pCliente As String, ByVal pTextDetail As String)
        'Dim xItem As ListViewItem

        'xItem = New ListViewItem
        'xItem.ImageKey = pType
        'xItem.Text = pTextMessage
        'xItem.SubItems.Add(Now.ToString)
        'xItem.SubItems.Add(pTextDetail)

        'Me.lstview_resultmessages.Items.Add(xItem)
        Dim xarray(5) As String
        xarray(0) = pType
        'xarray(1) = pTextMessage
        'xarray(2) = Now.ToString
        'xarray(3) = pTextDetail
        xarray(1) = pCaption
        xarray(2) = pPedidoNumero
        xarray(3) = pCliente
        xarray(4) = Now.ToString
        xarray(5) = pTextDetail

        MessagesTable.Rows.Add(xarray)
    End Sub


    Private Sub GridView2_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim xrow As DataRow
        Try
            xrow = GridView2.GetDataRow(Me.GridView2.FocusedRowHandle)
            If CInt(xrow("NIVEL_AVANCE")) = 100 Then
                e.Cancel = True
            End If
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub GridControl1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles uiTareas.DragDrop
        Dim xrow As DataRow
        Dim pResult As String = ""
        Try

            '12-Jul-10 Se agrego este if para diferenciar cuando el dragdrop es en el grid de Tareas y cuando es en el de replenishment
            If Me.uiTareas.DefaultView.Name = "GridViewReplenishment" Then

                If GridViewReplenishment.SelectedRowsCount > 0 Then

                    CleanUpResults()
                    For i = 0 To GridViewReplenishment.RowCount
                        If GridViewReplenishment.IsRowSelected(i) Then
                            xrow = GridViewReplenishment.GetDataRow(i)
                            'If Not xrow("NIVEL_AVANCE") = 100 Then

                            Dim PNewUser As String = Mid(e.Data.GetData(DataFormats.Text), InStr(e.Data.GetData(DataFormats.Text), "|") + 1, Len(e.Data.GetData(DataFormats.Text)))

                            If Not CreateTasksReplenishment(PNewUser, xrow, pResult) Then
                                'MessageBox.Show(pResult)
                            Else
                                GridViewReplenishment.SetRowCellValue(i, "TASK_ASSIGNEDTO", PNewUser)
                            End If
                            'End If
                        End If
                    Next
                    RefreshDataView("VIEW_REPLENISHMENT", pGlobalDateFilter, calender_filter.Selection)

                End If

            Else

                For i = 0 To GridView2.RowCount
                    If GridView2.IsRowSelected(i) Then
                        xrow = GridView2.GetDataRow(i)
                        If xrow("TASK_TYPE") = "TAREA_RECEPCION" Then
                            If IsDBNull(xrow("IS_COMPLETED")) Then
                                xrow("IS_COMPLETED") = "INCOMPLETA"
                            End If
                            If Not xrow("IS_COMPLETED") = "COMPLETA" Then

                                Dim PNewUser As String = Mid(e.Data.GetData(DataFormats.Text), InStr(e.Data.GetData(DataFormats.Text), "|") + 1, Len(e.Data.GetData(DataFormats.Text)))

                                Dim serialNumber As String = 0

                                serialNumber = xrow("SERIAL_NUMBER")

                                If Not ChangeTask_AssignedUser(serialNumber, 0, String.Empty, PNewUser, pResult) Then
                                    MessageBox.Show(pResult)
                                Else
                                    GridView2.SetRowCellValue(i, "TASK_ASSIGNEDTO", PNewUser)
                                End If
                            End If
                        End If
                    End If
                Next

            End If  '12-Jul-10 Se agrego este if para diferenciar cuando el dragdrop es en el grid de Tareas y cuando es en el de replenishment

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GridControl1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles uiTareas.DragEnter
        If e.Data.GetDataPresent(GetType(String)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        If uiTareas.MainView.Name = "GridView2" Then
            Me.GridView2.ShowCustomization()
        ElseIf uiTareas.MainView.Name = "GridViewDemandPending" Then
            Me.GridViewDemandPending.ShowCustomization()

            '13-Jul-10 J.R. para mostrar columnas escondidas del grid y que el usuario decida cuales mostrar 
        Else
            Me.GridViewReplenishment.ShowCustomization()
        End If

    End Sub

    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uiTareas.Click

    End Sub

    Private Sub GridViewDemandPending_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub GridControl_Results_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GridViewResults_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        e.Cancel = True
    End Sub

    Private Sub btnResultsCleanUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CleanUpResults()
    End Sub

    Sub CleanUpResults()
        MessagesTable.Rows.Clear()
        'Me.GridControl_Results.DataSource = Nothing
        'Me.GridControl_Results.Refresh()

        ''22-Jun-11 J.R.
        'intAsignados = 0
        'intNoAsignados = 0
        'Me.tlblOK.Text = "Asignados:"
        'Me.tlblError.Text = "No Asignados:"
    End Sub

    Private Sub btnResultsToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim pFileName As String = ""

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            pFileName = SaveFileDialog1.FileName
            'Me.GridViewResults.ExportToXls(pFileName)
        End If

    End Sub

    '13-Jul-10 J.R. para formatear el grid de replenishment
    Private Sub CustomCondition()
        Dim cn As StyleFormatCondition
        'cn = New StyleFormatCondition(FormatConditionEnum.LessOrEqual, GridViewReplenishment.Columns("GridColumn_PERCENTAGE_TO_LIMIT"), 0, 10)
        cn = New StyleFormatCondition()
        GridViewReplenishment.FormatConditions.Add(cn)
        cn.Column = GridViewReplenishment.Columns("GridColumn_PERCENTAGE_TO_LIMIT")
        cn.Condition = FormatConditionEnum.LessOrEqual
        cn.Value1 = 10
        cn.Appearance.BackColor = Color.Yellow

        'cn = New StyleFormatCondition(FormatConditionEnum.LessOrEqual, GridViewReplenishment.Columns("GridColumn_PERCENTAGE_TO_LIMIT"), 0, 0)
        'cn.Column = GridViewReplenishment.Columns("GridColumn_PERCENTAGE_TO_LIMIT")
        'cn.Appearance.BackColor = Color.Red
        'cn.Appearance.ForeColor = Color.White
        'GridViewReplenishment.FormatConditions.Add(cn)


        'StyleFormatCondition cn;
        'cn.Appearance.BackColor = Color.Yellow;
        'gridView1.FormatConditions.Add(cn);
        'cn = new StyleFormatCondition(FormatConditionEnum.GreaterOrEqual, gridView1.Columns["UnitPrice"], null, 40);
        'cn.Appearance.BackColor = Color.Red;
        'cn.Appearance.ForeColor = Color.White;
        'gridView1.FormatConditions.Add(cn);

    End Sub

    Private Sub NavBarGroupControlContainer5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnStartCampaign_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim pResult As String = ""

        Try

            If MessageBox.Show("Esta es la operación de inicio de campaña, toda la informacion de la campaña anterior (transacciones, tareas, etc.) se trasladará a Histórico." & vbNewLine & "Desea Continuar?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) = DialogResult.Yes Then
                Cursor = Cursors.WaitCursor

                Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/trans/wms_tasksadmin.asmx")
                If xserv.CleanUpDataForNewCampaign(PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment) Then
                    Cursor = Cursors.Default
                    MessageBox.Show("Proceso completado con éxito!")
                Else
                    Cursor = Cursors.Default
                    MessageBox.Show(pResult)
                End If

            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnReleaseBin_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        If MessageBox.Show("Esta seguro que desea LIBERAR un Bin?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) = DialogResult.Yes Then

            'frmReleaseBin.ShowDialog()

        End If
    End Sub

    Private Sub btnVoid_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

        Dim xrow As DataRow
        Dim pResult As String = ""
        Dim intSinAnular As Integer = 0
        Dim intAnulados As Integer = 0

        Try

            If GridViewDemandPending.SelectedRowsCount = 0 Then

                MessageBox.Show("Para anular un pedido debe seleccionarlo/marcarlo primero")

            Else

                Dim xtexto As String = ""
                If pPendingView = "ASSIGNED" Then
                    xtexto = vbNewLine + "Las pedidos asignados cuyo picking ya inició no se pueden eliminar desde aqui, el menu de 'Acciones sobre las Tareas' le permite anular tareas de picking."
                End If

                If MessageBox.Show("Confirma la Anulacion de " & GridViewDemandPending.SelectedRowsCount & " Pedido(s)?" + xtexto, "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) = DialogResult.Yes Then

                    Dim clonedTable As DataTable = GetTableOfSelectedRows(GridViewDemandPending)

                    For Each xrow In clonedTable.Rows

                        Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/trans/wms_tasksadmin.asmx")
                        If xserv.MarkDocumentAsVoid(xrow("ERP_DOCUMENT"), pResult, PublicLoginInfo.Environment) Then
                            intAnulados += 1
                        Else
                            intSinAnular += 1
                        End If

                    Next

                    RefreshDataView("VIEW_DEMAND", pGlobalDateFilter, calender_filter.Selection)

                    'If GridViewDemandPending.SelectedRowsCount = intContaAnulados Then
                    If intSinAnular = 0 Then
                        MessageBox.Show(intAnulados.ToString + " pedidos fueron anulados.")
                    Else
                        MessageBox.Show(intAnulados.ToString + " pedidos fueron anulados, " + intSinAnular.ToString + " pedidos NO fueron anulados, por favor reviselos.")
                    End If

                    'CleanUpResults()
                    'BarStaticItem_Status.Caption = "0%"
                    'For i = 0 To GridViewDemandPending.RowCount - 1
                    '    GridViewDemandPending.GetSelectedRows()
                    '    If GridViewDemandPending.IsMasterRow(i) Then
                    '        If GridViewDemandPending.IsRowSelected(i) Then
                    '            xrow = GridViewDemandPending.GetDataRow(i)
                    '            BarStaticItem_Status.Caption = (i / (GridViewDemandPending.SelectedRowsCount - 1) * 100)
                    '            If Not CreateTasks(xrow("ERP_DOCUMENT"), pResult) Then
                    '                AddMessageToResult("ERROR", "ERROR," + xrow("ERP_DOCUMENT") + " " + xrow("CLIENT_NAME"), pResult)
                    '            Else
                    '                AddMessageToResult("SUCCESS", "OK, Pedido: " + xrow("ERP_DOCUMENT") + " " + xrow("CLIENT_NAME"), "")
                    '                '28Jun10 J.R. no funcionaba porque este delete hacia que el for pelara cable y ya no seguia procesando pedidos
                    '                'GridViewDemandPending.DeleteRow(i)
                    '            End If

                    '        End If
                    '    End If
                    'Next
                    'BarStaticItem_Status.Caption = "100%"
                    ''28Jun10 J.R. se puso este refresh porque el delete de arriba no funcionaba porque este delete hacia que el for pelara cable y ya no seguia procesando pedidos
                    'RefreshDataView("VIEW_DEMAND", pGlobalDateFilter)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub GridViewPendingPicking_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = ChrW(Keys.Enter) Then
            If GridViewPendingPicking.IsMasterRow(GridViewPendingPicking.FocusedRowHandle) Then
                GridViewPendingPicking.SetMasterRowExpanded(GridViewPendingPicking.FocusedRowHandle, Not GridViewPendingPicking.GetMasterRowExpanded(GridViewPendingPicking.FocusedRowHandle))
            End If
        End If

    End Sub

    Private Sub GridViewPendingPicking_MasterRowExpanded(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs)
        Dim detailView As DevExpress.XtraGrid.Views.Grid.GridView
        detailView = GridViewPendingPicking.GetDetailView(e.RowHandle, e.RelationIndex)

        detailView.Columns("SECTORLINEA").OptionsColumn.ReadOnly = True
        detailView.Columns("SECTORLINEA").Visible = False

        detailView.Columns("Sector").OptionsColumn.ReadOnly = True
        detailView.Columns("Linea").OptionsColumn.ReadOnly = True
        detailView.Columns("Documento").OptionsColumn.ReadOnly = True
        detailView.Columns("CodigoCliente").OptionsColumn.ReadOnly = True
        detailView.Columns("NombreCliente").OptionsColumn.ReadOnly = True
        detailView.Columns("Unidades").OptionsColumn.ReadOnly = True

        detailView.Columns("Unidades").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far

        detailView.Columns("CodigoCliente").Caption = "Codigo Cliente"
        detailView.Columns("NombreCliente").Caption = "Nombre"

        detailView.Columns("Sector").Width = 30
        detailView.Columns("Linea").Width = 35
        detailView.Columns("Documento").Width = 40
        detailView.Columns("CodigoCliente").Width = 40
        detailView.Columns("NombreCliente").Width = 100
        detailView.Columns("Unidades").Width = 35

        'detailView.Columns("Description").OptionsColumn.ReadOnly = True
        'detailView.Columns("Description").OptionsColumn.AllowFocus = False
        'detailView.Columns("Description").Width = 180

        'detailView.Columns("Cantidad").OptionsColumn.ReadOnly = True
        'detailView.Columns("Cantidad").OptionsColumn.AllowFocus = False

        'detailView.Columns("InvLinea_1").OptionsColumn.ReadOnly = True
        'detailView.Columns("InvLinea_1").OptionsColumn.AllowFocus = False
        'detailView.Columns("InvLinea_1").OptionsFilter.AllowAutoFilter = False
        'detailView.Columns("InvLinea_1").OptionsFilter.AllowFilter = False

        'detailView.Columns("InvLinea_2").OptionsColumn.ReadOnly = True
        'detailView.Columns("InvLinea_2").OptionsColumn.AllowFocus = False
        'detailView.Columns("InvLinea_2").OptionsFilter.AllowAutoFilter = False
        'detailView.Columns("InvLinea_2").OptionsFilter.AllowFilter = False

        'detailView.Columns("InvLinea_3").OptionsColumn.ReadOnly = True
        'detailView.Columns("InvLinea_3").OptionsColumn.AllowFocus = False
        'detailView.Columns("InvLinea_3").OptionsFilter.AllowAutoFilter = False
        'detailView.Columns("InvLinea_3").OptionsFilter.AllowFilter = False

        'detailView.Columns("InvLinea_1").Visible = False
        'detailView.Columns("InvLinea_2").Visible = True
        'detailView.Columns("InvLinea_3").Visible = False

    End Sub

    Private Sub btnRestore_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

        Dim xrow As DataRow
        Dim pResult As String = ""
        Dim intSinAnular As Integer = 0
        Dim intAnulados As Integer = 0

        Try

            If GridViewDemandPending.SelectedRowsCount = 0 Then

                MessageBox.Show("Para restaurar un pedido anulado debe seleccionarlo/marcarlo primero")

            Else

                Dim xtexto As String = ""
                'If pPendingView = "ASSIGNED" Then
                '    xtexto = vbNewLine + "Las pedidos asignados cuyo picking ya inició no se pueden eliminar desde aqui, el menu de 'Acciones sobre las Tareas' le permite anular tareas de picking."
                'End If

                If MessageBox.Show("Confirma la Restauracion de " & GridViewDemandPending.SelectedRowsCount & " Pedido(s)?" + xtexto, "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) = DialogResult.Yes Then

                    Dim clonedTable As DataTable = GetTableOfSelectedRows(GridViewDemandPending)

                    For Each xrow In clonedTable.Rows

                        Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/trans/wms_tasksadmin.asmx")
                        If xserv.RestoreDocumentFromVoid(xrow("ERP_DOCUMENT"), pResult, PublicLoginInfo.Environment) Then
                            intAnulados += 1
                        Else
                            intSinAnular += 1
                        End If

                    Next

                    RefreshDataView("VIEW_DEMAND", pGlobalDateFilter, calender_filter.Selection)

                    'If GridViewDemandPending.SelectedRowsCount = intContaAnulados Then
                    If intSinAnular = 0 Then
                        MessageBox.Show(intAnulados.ToString + " pedidos fueron restaurados.")
                    Else
                        MessageBox.Show(intAnulados.ToString + " pedidos fueron restaurados, " + intSinAnular.ToString + " pedidos NO pudieron ser restaurados.")
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmbLineas_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub NavBarGroupControlContainer3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TreeList_Demand_FocusedNodeChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs)

    End Sub

    Private Sub TreeList_Demand_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        '25-Abr-11 J.R. mostrar pedidos pendientes de picking
        Dim strTipoView As String = "VIEW_DEMAND"

        Select Case TreeList_Demand.FocusedNode.Id
            Case 0
                pPendingView = "PENDING"
                Me.btnCrearTareas.Enabled = True
                Me.uiTareas.MainView = GridViewDemandPending  '25-Abr-11 J.R. mostrar pedidos pendientes de picking
            Case 1
                pPendingView = "PENDING"
                Me.btnCrearTareas.Enabled = True
                Me.uiTareas.MainView = GridViewDemandPending  '25-Abr-11 J.R. mostrar pedidos pendientes de picking
            Case 2
                pPendingView = "VOIDED"
                Me.btnCrearTareas.Enabled = False
                Me.uiTareas.MainView = GridViewDemandPending  '25-Abr-11 J.R. mostrar pedidos pendientes de picking
            Case 3
                pPendingView = "PENDPICK"
                Me.btnCrearTareas.Enabled = False
                strTipoView = "VIEW_PENDINGPICKING"
                Me.uiTareas.MainView = GridViewPendingPicking
            Case Else
                pPendingView = "ASSIGNED"
                Me.btnCrearTareas.Enabled = False
                Me.uiTareas.MainView = GridViewDemandPending  '25-Abr-11 J.R. mostrar pedidos pendientes de picking
        End Select

        '25-Abr-11 J.R. mostrar pedidos pendientes de picking
        'RefreshDataView("VIEW_DEMAND", pGlobalDateFilter)
        RefreshDataView(strTipoView, pGlobalDateFilter, calender_filter.Selection)

    End Sub

    Private Sub btnTareaARevisar_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim pResult As String = ""
        MarkToAudit(pResult)

    End Sub
    Sub MarkToAudit(ByRef pResult As String)
        If GridViewDemandPending.SelectedRowsCount >= 1 Then
            If MessageBox.Show("Esta seguro de marcar " + Me.GridViewDemandPending.SelectedRowsCount.ToString + " pedidos para revision completa?", "Swift 3PL", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Try
                    Dim xrow As DataRow
                    Dim xcount As Integer = 0
                    Cursor = Cursors.WaitCursor
                    For i = 0 To Me.GridViewDemandPending.RowCount - 1
                        If xcount <= GridViewDemandPending.SelectedRowsCount Then
                            If GridViewDemandPending.IsRowSelected(i) Then
                                xrow = GridViewDemandPending.GetDataRow(i)
                                Dim pERP_DOC As String = xrow("ERP_DOCUMENT")

                                If Not xrow("NEEDS_TO_AUDIT") = 1 Then

                                    'MessageBox.Show(xrow("ERP_DOCUMENT").ToString)
                                    ChangeTask_NeedsToAudit(pERP_DOC, pResult)
                                    If pResult <> "OK" Then
                                        Cursor = Cursors.Default
                                        MessageBox.Show(pResult)

                                        Exit Sub
                                    End If
                                    xcount = xcount + 1
                                Else
                                    xcount = xcount + 1
                                End If
                            End If
                        Else
                            Exit For
                        End If
                    Next
                    Cursor = Cursors.Default

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If

        End If

    End Sub
    Function ChangeTask_NeedsToAudit(ByVal pTaskID As Integer, ByRef pResult As String) As Boolean
        Try
            Dim xserver As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/trans/WMS_TasksAdmin.asmx")
            Return xserver.MarkToAudit(pTaskID, pResult, "DESARROLLO")

        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

    Private Sub usersListView_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles usersListView.SelectedIndexChanged

    End Sub

    Private Sub btnPrintGrid_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrintGrid.ItemClick
        Dim Xrpt As New XtraReport_Wave

        Dim xcount As Integer = 0
        Dim xrow As DataRow

        Try
            For i = 0 To GridView2.RowCount - 1
                If xcount <= GridView2.SelectedRowsCount Then
                    If GridView2.IsRowSelected(i) Then
                        xrow = GridView2.GetDataRow(i)
                        'Xrpt.FilterString = "WAVE_PICKING_ID = " & xrow("WAVE_PICKING_ID")
                        'NotifyStatus(Xrpt.FilterString, True, False)
                        Xrpt.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                        Xrpt.ShowPreview()
                        'Xrpt.ApplyFiltering()

                        Exit For
                    End If
                Else
                    Exit For
                End If

            Next
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try

    End Sub

    Function ChangeTask_Status_BySerialNumber(ByVal pNewTaskStatus As Integer, ByVal pTaskID As Long, ByRef pResult As String) As Boolean
        Try
            Cursor = Cursors.WaitCursor
            Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/trans/wms_tasksadmin.asmx")
            If Not xserv.UpdateStatusTaskUserBySerialNumber(pTaskID, pNewTaskStatus, pResult, PublicLoginInfo.Environment) Then
                Cursor = Cursors.Default
                Return False
            Else
                Cursor = Cursors.Default
                Return True
            End If
        Catch ex As Exception
            Cursor = Cursors.Default

            pResult = ex.Message
            Return False
        End Try
    End Function

    Function DeleteTaskBySerialNumber(ByVal serialNumber As Integer, ByRef pResult As String) As Boolean
        Try
            Cursor = Cursors.WaitCursor
            Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/trans/wms_tasksadmin.asmx")
            If Not xserv.DeleteTaskBySerialNumber(serialNumber, PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment) Then
                Cursor = Cursors.Default
                Return False
            Else
                Cursor = Cursors.Default
                Return True
            End If
        Catch ex As Exception
            Cursor = Cursors.Default

            pResult = ex.Message
            Return False
        End Try
    End Function

    Private Sub UiTabControlTasks_Click(sender As Object, e As EventArgs) Handles UiTabControlTasks.Click
        If uiTareas.DataSource IsNot Nothing AndAlso UiTabControlTasks.SelectedTabPageIndex = 1 Then

            Dim resultado As String
            Dim servicio As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            Dim data = servicio.GetOperatorsGraphicsTask(PrepareStr("USERS"), PrepareStr("TASKS"), txtFechaInicial.DateTime, txtFechaFinal.DateTime, PublicLoginInfo.LoginID, resultado, PublicLoginInfo.Environment)
            If Not String.IsNullOrEmpty(resultado) Then
                NotifyStatus(resultado, True, True)
            Else
                GenerarGraficas(data)
                _graficasGenerdas = True
            End If
        End If
    End Sub

    Private Sub GenerarGraficas(dt As DataTable)
        Try
            GenerarPie(dt)
            GenerarLinear(dt)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerarLinear(data As DataTable)
        Try
            'Add title to the chart.
            Dim title As New ChartTitle()
            title.Text = "Tiempo Promedio Tareas Por Operador - Minutos"
            UiChartControlTimeTaskByUsers.Titles.Clear()
            UiChartControlTimeTaskByUsers.Titles.Add(title)

            ' Add the series to the chart.
            UiChartControlTimeTaskByUsers.Series.Clear()

            'Dim data = CType(uiTareas.DataSource, DataTable)

            Dim data2 = data.Copy()
            data2.Clear()
            For Each row As DataRow In data.Select("TIME>0")
                Dim nRow = data2.NewRow()
                nRow.ItemArray = row.ItemArray
                data2.Rows.Add(nRow)
            Next
            Dim view As DataView = data2.DefaultView
            Dim usuario As DataRowView
            For Each opers In view.ToTable("Operadores", True, "TASK_ASSIGNEDTO").Select("TASK_ASSIGNEDTO<>''")

                If opers("TASK_ASSIGNEDTO") <> "" Then
                    usuario = LookUpUsers.GetDataSourceRowByKeyValue(opers("TASK_ASSIGNEDTO"))
                    ' Create a line series.
                    Dim serie As New Series(usuario("LOGIN_NAME"), ViewType.Line)
                    UiChartControlTimeTaskByUsers.Series.Add(serie)
                End If
            Next

            For Each tipos In view.ToTable("TipoTarea", True, "TASK_TYPE").Rows
                For Each serie As Series In UiChartControlTimeTaskByUsers.Series
                    Dim operador = LookUpUsers.GetKeyValueByDisplayText(serie.Name)
                    Dim promedio = data2.DefaultView.ToTable("TiemposPorOper", False, "TIME", "TASK_ASSIGNEDTO", "TASK_TYPE").Compute("AVG(TIME)", "TASK_ASSIGNEDTO='" + operador + "' AND TASK_TYPE='" + tipos("TASK_TYPE") + "'")
                    If (Not IsDBNull(promedio)) Then
                        serie.Points.Add(New SeriesPoint(tipos("TASK_TYPE"), promedio))
                    Else
                        serie.Points.Add(New SeriesPoint(tipos("TASK_TYPE"), 0))
                    End If
                Next
            Next

            UiChartControlTimeTaskByUsers.Dock = DockStyle.Fill

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerarPie(dt As DataTable)
        Try
            Dim primaryKey(1) As DataColumn
            Dim column As DataColumn
            Dim tableSource As New DataTable("SOURCE")

            'Create the first Column
            column = New DataColumn()
            column.DataType = Type.GetType("System.String")
            column.ColumnName = "Operador"
            tableSource.Columns.Add(column)
            primaryKey(0) = column

            'Create the second Column
            column = New DataColumn()
            column.DataType = Type.GetType("System.Int32")
            column.ColumnName = "Tareas"
            tableSource.Columns.Add(column)

            'Create the PrimaryKey in the Table
            tableSource.PrimaryKey = primaryKey

            'Populate the task by user in grid control
            'For i = 0 to uiTareas.DataSource.Rows.Count - 1

            For Each row As DataRow In dt.Select("TASK_ASSIGNEDTO<>''")

                Dim foundRow As DataRow
                Dim foundRow2 As DataRowView
                If row("TASK_ASSIGNEDTO") <> "" Then
                    foundRow2 = LookUpUsers.GetDataSourceRowByKeyValue(row("TASK_ASSIGNEDTO"))

                    foundRow = tableSource.Rows.Find(foundRow2("LOGIN_NAME"))
                    If foundRow Is Nothing Then
                        'Item Not Found
                        tableSource.Rows.Add(New Object() {foundRow2("LOGIN_NAME"), 1})
                    Else
                        'Item Found
                        foundRow("Tareas") = foundRow("Tareas") + 1
                    End If
                End If
            Next

            ' Create a pie series.
            Dim seriePie As New Series("Tareas Por Operador", ViewType.Pie)

            ' Populate the series with points.
            For j = 0 To tableSource.Rows.Count - 1
                seriePie.Points.Add(New SeriesPoint(tableSource.Rows(j).Item("Operador"), tableSource.Rows(j).Item("Tareas")))
            Next j

            'Add title to the chart.
            Dim title As New ChartTitle()
            title.Text = "Tareas Por Operador"
            UiChartControlTasks.Titles.Clear()
            UiChartControlTasks.Titles.Add(title)

            ' Add the series to the chart.
            UiChartControlTasks.Series.Clear()
            UiChartControlTasks.Series.Add(seriePie)

            ' Adjust the point options of the series label.
            Dim label = CType(seriePie.Label, PieSeriesLabel)
            label.PointOptions.PointView = PointView.ArgumentAndValues
            label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent
            label.PointOptions.ValueNumericOptions.Precision = 2

            ' Detect overlapping of series labels.
            label.ResolveOverlappingMode = ResolveOverlappingMode.Default

            ' Add the chart to the form.
            UiChartControlTasks.Dock = DockStyle.Fill

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub uiDistribuirTareasATodosLosOperadores_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles uiDistribuirTareasATodosLosOperadores.ItemClick
        Dim op = AsignarTareasPendientesATodosLosOperadores()
        If (op.Resultado = ResultadoOperacionTipo.Error) Then
            NotifyStatus(op.Mensaje, False, True)
        Else
            RefrescarVista()
        End If
    End Sub

    Private Sub uiDistribuirTareasATodosLosOperadoresSinTarea_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles uiDistribuirTareasATodosLosOperadoresSinTarea.ItemClick
        Dim op = AsignarTareasPendientesATodosLosOperadoresSinTareas()
        If (op.Resultado = ResultadoOperacionTipo.Error) Then
            NotifyStatus(op.Mensaje, False, True)
        Else
            RefrescarVista()
        End If
    End Sub

    Private Sub RefrescarVista()
        pGlobalDateFilter = "BY_DATERANGE"
        RefreshDataView(pGlobalTaskView, "BY_DATERANGE", _rangoPrevioDeFechas)

        If uiTareas.DataSource IsNot Nothing AndAlso UiTabControlTasks.SelectedTabPageIndex = 1 Then
            Dim resultado As String
            Dim servicio As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            Dim data = servicio.GetOperatorsGraphicsTask(PrepareStr("USERS"), PrepareStr("TASKS"), txtFechaInicial.DateTime, txtFechaFinal.DateTime, PublicLoginInfo.LoginID, resultado, PublicLoginInfo.Environment)
            If Not String.IsNullOrEmpty(resultado) Then
                NotifyStatus(resultado, True, True)
            Else
                GenerarGraficas(data)
            End If
        End If
    End Sub

    Private Sub LookUpUsers_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpUsers.EditValueChanged

    End Sub
    Dim txt As TextEditViewInfo
    Private Sub GridView2_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles GridView2.CustomDrawCell
        'If e.Column.FieldName.Contains("DX$CheckboxSelectorColum") Then
        '    Dim cell As GridCellInfo = CType(e.Cell, GridCellInfo)
        '    cell.ViewInfo.Editable = False
        '    Dim gvi As GridViewInfo = TryCast(TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetViewInfo(), GridViewInfo)
        '    Dim ci As GridCellInfo = TryCast(gvi.RowsInfo.FindRow(e.RowHandle), GridDataRowInfo).Cells(e.Column)
        '    Dim ch As New GridEditorContainerHelper(Me.uiTareas)
        '    Dim mi As System.Reflection.MethodInfo = GetType(GridViewInfo).GetMethod("RequestCellEditViewInfo")
        '    If mi IsNot Nothing Then
        '        Dim bvi As BaseEditViewInfo = TryCast(mi.Invoke(gvi, New Object() {ci}), BaseEditViewInfo)
        '        If TypeOf bvi Is CheckEditViewInfo Then

        '            TryCast(bvi, CheckEditViewInfo).CheckInfo.State = DevExpress.Utils.Drawing.ObjectState.Disabled
        '            ch.DrawCellEdit(New GridViewDrawArgs(e.Cache, gvi, e.Bounds), e.Column.RealColumnEdit, bvi, bvi.AppearanceDisabled, ci.CellValueRect.Location)
        '            e.Handled = True
        '        End If
        '    End If

        'End If

    End Sub

    Private Sub GridView2_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView2.SelectionChanged
        Try
            MostrarBotonErp()
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub



    Private Sub UiButtonEnviarERP_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiButtonEnviarERP.ItemClick
        If (MessageBox.Show("Confirma que desea enviar a ERP? Unicamente se enviarán tareas de recepción con estado válido para el envio.", "Swift 3PL", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly,
                                                                                    False) = DialogResult.Yes) Then
            UsuarioDeseaEnviarSeleccionAERP()
        End If

    End Sub

    Private Sub UsuarioDeseaEnviarSeleccionAERP()
        Try
            Dim lista As New List(Of Integer)

            Dim xrow As DataRow
            For index = 0 To GridView2.SelectedRowsCount - 1
                xrow = GridView2.GetDataRow(GridView2.GetSelectedRows()(index))

                If xrow("TASK_TYPE").ToString = "TAREA_PICKING" AndAlso lista.Contains(xrow("WAVE_PICKING_ID")) = False Then

                    If xrow("TASK_TYPE").ToString = "TAREA_PICKING" AndAlso (xrow("IS_POSTED_ERP").ToString <> "1").ToString _
                        AndAlso (xrow("IS_FROM_ERP").ToString = "Si" Or xrow("IS_FROM_SONDA").ToString = "Si") _
                        AndAlso xrow("IS_COMPLETED") = "COMPLETA" AndAlso xrow("REGIMEN") = "GENERAL" Then

                        Dim servicio As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
                        Dim pResult As String = ""
                        Dim exito = servicio.AuthorizeErpPickingDocument(Convert.ToInt32(xrow("WMS_DOCUMENT_HEADER_ID").ToString), PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)
                        lista.Add(xrow("WAVE_PICKING_ID"))
                        If Not exito Then
                            MsgBox("Error al enviar a ERP: " & pResult, MsgBoxStyle.Critical, "Error")
                        End If
                    End If
                End If
                If xrow("TASK_TYPE").ToString = "TAREA_RECEPCION" AndAlso (xrow("IS_POSTED_ERP").ToString <> "1").ToString _
                AndAlso xrow("IS_FROM_ERP").ToString = "Si" AndAlso xrow("IS_COMPLETED") = "COMPLETA" Then
                    Dim servicio As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
                    Dim pResult As String = ""
                    Dim exito = servicio.AuthorizeErpReceptionDocument(Convert.ToInt32(xrow("WMS_DOCUMENT_HEADER_ID").ToString), PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult) '"ERP_RECEPTION_DOCUMENT_HEADER_ID"
                    If Not exito Then
                        MsgBox("Error al enviar a ERP: " & pResult, MsgBoxStyle.Critical, "Error")
                    End If
                End If


            Next
            RefrescarVista()
        Catch ex As Exception
            MsgBox("Error al enviar a ERP: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub NavBarControlTaskOnLine_Click(sender As Object, e As EventArgs) Handles NavBarControlTaskOnLine.Click

    End Sub

    Private Sub btnGo_Calendar_Click_1(sender As Object, e As EventArgs) Handles btnGo_Calendar.Click
        Try
            pGlobalDateFilter = "BY_DATERANGE"
            UiContenedorDetalle.DataSource = Nothing
            RefreshDataView(pGlobalTaskView, "BY_DATERANGE", calender_filter.Selection)
            _graficasGenerdas = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LlenarVistaDetalleRecepcion(serialNumber As Integer, mostrarColumnasComparacion As Boolean)
        Try
            UiContenedorDetalle.MainView = UiVistaDetalleRecepcion
            Dim resultado As String
            Dim servicio As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            UiContenedorDetalle.DataSource = servicio.GetTaskDetailForReception(serialNUmber:=serialNumber, pEnvironmentName:=PublicLoginInfo.Environment, pResult:=resultado)
            If Not String.IsNullOrEmpty(resultado) Then
                NotifyStatus(resultado, True, True)
            End If

            UiColCantidadDocumentoRecepcion.Visible = mostrarColumnasComparacion
            UiColDiferenciaCantidadRecepcion.Visible = mostrarColumnasComparacion
            UiColCantidadDocumentoRecepcion.OptionsColumn.ShowInCustomizationForm = mostrarColumnasComparacion
            UiColDiferenciaCantidadRecepcion.OptionsColumn.ShowInCustomizationForm = mostrarColumnasComparacion

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LlenarVistaDetallePicking(wavePickingId As Integer, mostrarColumnasComparacion As Boolean)
        Try
            UiContenedorDetalle.MainView = UiVistaDetallePicking
            Dim resultado As String
            Dim servicio As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            UiContenedorDetalle.DataSource = servicio.GetTaskDetailForPicking(wavePickingId:=wavePickingId, login:=PublicLoginInfo.LoginID, pEnvironmentName:=PublicLoginInfo.Environment, pResult:=resultado)
            If Not String.IsNullOrEmpty(resultado) Then
                NotifyStatus(resultado, True, True)
            End If

            UiColCantidadDocumento.Visible = mostrarColumnasComparacion
            UiColCantidadDocumento.OptionsColumn.ShowInCustomizationForm = mostrarColumnasComparacion
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LlenarListaOperadoresParaPickingDetalle()
        Try
            Dim resultado = "OK"
            'Dim servicioSeguridad As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
            'Dim ds As DataSet = servicioSeguridad.SearchOperators(pResult:=resultado, pEnvironmentName:=PublicLoginInfo.Environment)
            Dim webServiceInfoTrans As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            Dim dt As DataTable = webServiceInfoTrans.GetOperatorAssignedToDistributionCenterByUser(PublicLoginInfo.LoginID, PublicLoginInfo.Environment, resultado)

            If Not resultado.Equals("OK") Then
                NotifyStatus(resultado, True, True)
            Else
                UiListaOperadoresParaPickingDetalle.DataSource = dt
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
    Private Function LlenarListaOperadoresParaUbicacionDetalle() As Object
        Try
            Dim resultado = "OK"
            'Dim servicioSeguridad As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
            'Dim ds As DataSet = servicioSeguridad.SearchOperators(pResult:=resultado, pEnvironmentName:=PublicLoginInfo.Environment)
            Dim webServiceInfoTrans As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            Dim dt As DataTable = webServiceInfoTrans.GetCanReallocOperatorAssignedToDistributionCenterByUser(PublicLoginInfo.LoginID, PublicLoginInfo.Environment, resultado)

            If Not resultado.Equals("OK") Then
                NotifyStatus(resultado, True, True)
            Else
                listaOperadoresReubicacion = dt
                UiListaOperadoresParaReubicacionDetalle.DataSource = dt
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Function
    Private Sub UiListaOperadoresParaPickingDetalle_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles UiListaOperadoresParaPickingDetalle.EditValueChanging
        If UiVistaDetallePicking.IsFilterRow(UiVistaDetallePicking.FocusedRowHandle) Then
            Exit Sub
        End If

        Dim pResult As String = ""


        Dim fila As DataRow
        fila = UiVistaDetallePicking.GetDataRow(Me.UiVistaDetallePicking.FocusedRowHandle)
        If IsDBNull(fila("IS_COMPLETED")) Then
            fila("IS_COMPLETED") = "INCOMPLETA"
        End If
        If Not fila("IS_COMPLETED") = "COMPLETA" Then


            If e.OldValue = "" OrElse MessageBox.Show("Confirma que desea re-asignar la tarea?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, False) = DialogResult.Yes Then

                Try

                    Dim pNewAssignedUser As String = e.NewValue

                    Dim wavePicking As Integer = 0
                    Dim materialId As String = ""
                    Dim serialNumber As String = 0


                    wavePicking = fila("WAVE_PICKING_ID")
                    materialId = fila("MATERIAL_ID")

                    If Not ChangeTask_AssignedUser(serialNumber, wavePicking, materialId, pNewAssignedUser, pResult) Then
                        MessageBox.Show(pResult)
                        e.Cancel = True
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub UiContenedorDetalle_DragEnter(sender As Object, e As DragEventArgs) Handles UiContenedorDetalle.DragEnter
        If e.Data.GetDataPresent(GetType(String)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub UiContenedorDetalle_DragDrop(sender As Object, e As DragEventArgs) Handles UiContenedorDetalle.DragDrop
        Dim fila As DataRow
        Dim resultado As String = ""
        Try

            If Me.UiContenedorDetalle.DefaultView.Name = "UiVistaDetalleCounting" Then
                For i = 0 To UiVistaDetalleCounting.RowCount
                    If UiVistaDetalleCounting.IsRowSelected(i) Then
                        fila = UiVistaDetalleCounting.GetDataRow(i)
                        If IsDBNull(fila("STATUS")) Then
                            fila("STATUS") = "COMPLETED"
                        End If
                        If fila("STATUS") = "CREATED" Then

                            Dim PNewUser As String = Mid(e.Data.GetData(DataFormats.Text), InStr(e.Data.GetData(DataFormats.Text), "|") + 1, Len(e.Data.GetData(DataFormats.Text)))

                            Dim physicalCountDetailId As Integer
                            physicalCountDetailId = fila("PHYSICAL_COUNT_DETAIL_ID")

                            If Not CambiarOperadorATareaDeConteo(physicalCountDetailId, PNewUser, resultado) Then
                                NotifyStatus(resultado, False, True)
                            Else
                                UiVistaDetalleCounting.SetRowCellValue(i, "ASSIGNED_TO", PNewUser)
                            End If
                        End If

                    End If
                Next
            End If

            If Me.UiContenedorDetalle.DefaultView.Name = "UiVistaDetallePicking" Then

                For i = 0 To UiVistaDetallePicking.RowCount
                    If UiVistaDetallePicking.IsRowSelected(i) Then
                        fila = UiVistaDetallePicking.GetDataRow(i)
                        If IsDBNull(fila("IS_COMPLETED")) Then
                            fila("IS_COMPLETED") = "INCOMPLETA"
                        End If
                        If Not fila("IS_COMPLETED") = "COMPLETA" And fila("USE_PICKING_LINE") <> 1 Then

                            Dim PNewUser As String = Mid(e.Data.GetData(DataFormats.Text), InStr(e.Data.GetData(DataFormats.Text), "|") + 1, Len(e.Data.GetData(DataFormats.Text)))

                            Dim wavePicking As Integer = 0
                            Dim materialId As String = ""
                            Dim serialNumber As String = 0

                            wavePicking = fila("WAVE_PICKING_ID")
                            materialId = fila("MATERIAL_ID")


                            If Not ChangeTask_AssignedUser(serialNumber, wavePicking, materialId, PNewUser, resultado) Then
                                NotifyStatus(resultado, False, True)
                            Else
                                UiVistaDetallePicking.SetRowCellValue(i, "TASK_ASSIGNEDTO", PNewUser)
                            End If
                        End If

                    End If
                Next
            End If

            If Me.UiContenedorDetalle.DefaultView.Name = "UiVistaDetalleReubicacion" Then

                For i = 0 To UiVistaDetalleReubicacion.RowCount
                    If UiVistaDetalleReubicacion.IsRowSelected(i) Then
                        fila = UiVistaDetalleReubicacion.GetDataRow(i)
                        If IsDBNull(fila("IS_COMPLETED")) Then
                            fila("IS_COMPLETED") = "INCOMPLETA"
                        End If
                        If Not fila("IS_COMPLETED") = "COMPLETA" Then

                            Dim PNewUser As String = Mid(e.Data.GetData(DataFormats.Text), InStr(e.Data.GetData(DataFormats.Text), "|") + 1, Len(e.Data.GetData(DataFormats.Text)))
                            Dim wavePicking As Integer = 0
                            Dim materialId As String = ""
                            Dim serialNumber As String = 0

                            wavePicking = fila("WAVE_PICKING_ID")
                            materialId = fila("MATERIAL_ID")

                            For j = 0 To listaOperadoresReubicacion.Rows.Count - 1
                                If PNewUser = (listaOperadoresReubicacion.Rows.Item(j)).ItemArray(0).ToString() Then
                                    If Not ChangeTask_AssignedUser(serialNumber, wavePicking, materialId, PNewUser, resultado) Then
                                        NotifyStatus(resultado, False, True)
                                    Else
                                        UiVistaDetalleReubicacion.SetRowCellValue(i, "TASK_ASSIGNEDTO", PNewUser)
                                    End If
                                End If
                            Next

                        End If

                    End If
                Next
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function CambiarOperadorATareaDeConteo(ByVal physicalCountDetailId As String, ByVal newAssignedUser As String, ByRef pResult As String) As Boolean
        Try
            Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            If Not xserv.UpdateAssignedOperatorToCountDetail(physicalCountDetailId, newAssignedUser, pResult, PublicLoginInfo.Environment) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function


    Private Sub LlenarVistaConteo(taskId As Integer)
        Try
            UiContenedorDetalle.MainView = UiVistaDetalleCounting
            Dim resultado As String
            Dim servicio As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            UiContenedorDetalle.DataSource = servicio.GetTaskDetailForCount(taskId, PublicLoginInfo.LoginID, PublicLoginInfo.Environment, resultado)
            If Not String.IsNullOrEmpty(resultado) Then
                NotifyStatus(resultado, True, True)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub GridView2_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView2.RowClick
        If (e.RowHandle >= 0) Then
            Dim fila As DataRow
            fila = GridView2.GetDataRow(e.RowHandle)
            Select Case fila("TASK_TYPE")
                Case "TAREA_RECEPCION"
                    Dim mostrarColumnasComparacion = fila("IS_FROM_SONDA").ToString().ToUpper().Equals("SI") Or (fila("IS_FROM_ERP").ToString().ToUpper().Equals("SI"))
                    LlenarVistaDetalleRecepcion(fila("SERIAL_NUMBER"), mostrarColumnasComparacion)
                    Exit Select
                Case "TAREA_PICKING"
                    Dim mostrarColumnasComparacion = fila("IS_FROM_SONDA").ToString().ToUpper().Equals("SI") Or (fila("IS_FROM_ERP").ToString().ToUpper().Equals("SI"))
                    LlenarVistaDetallePicking(fila("WAVE_PICKING_ID"), mostrarColumnasComparacion)
                    Exit Select
                Case "TAREA_CONTEO_FISICO"
                    LlenarVistaConteo(fila("TASK_ID"))
                    Exit Select
                Case "TAREA_REUBICACION"
                    LlenarVistaDetalleReubicacion(fila("WAVE_PICKING_ID"))
                    Exit Select
            End Select
        End If
    End Sub

    Private Sub LlenarVistaDetalleReubicacion(wavePickingId As Integer)
        Try
            UiContenedorDetalle.MainView = UiVistaDetalleReubicacion
            Dim resultado As String
            Dim servicio As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            UiContenedorDetalle.DataSource = servicio.GetTaskDetailForRealloc(wavePickingId, PublicLoginInfo.LoginID, PublicLoginInfo.Environment, resultado)
            If Not String.IsNullOrEmpty(resultado) Then
                NotifyStatus(resultado, True, True)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub



    Private Sub MostrarBotonErp()
        Try
            UiButtonEnviarERP.Visibility = BarItemVisibility.Never
            Dim lista As New List(Of Integer)

            Dim xrow As DataRow
            For index = 0 To GridView2.SelectedRowsCount - 1
                xrow = GridView2.GetDataRow(GridView2.GetSelectedRows()(index))

                If xrow("TASK_TYPE").ToString = "TAREA_PICKING" AndAlso lista.Contains(xrow("WAVE_PICKING_ID")) = False Then

                    If xrow("TASK_TYPE").ToString = "TAREA_PICKING" AndAlso (xrow("IS_POSTED_ERP").ToString <> "1").ToString _
                        AndAlso (xrow("IS_FROM_ERP").ToString = "Si" Or xrow("IS_FROM_SONDA").ToString = "Si") _
                        AndAlso xrow("IS_COMPLETED") = "COMPLETA" AndAlso xrow("REGIMEN") = "GENERAL" Then
                        UiButtonEnviarERP.Visibility = BarItemVisibility.Always
                        Exit For

                    End If
                End If
                If xrow("TASK_TYPE").ToString = "TAREA_RECEPCION" AndAlso (xrow("IS_POSTED_ERP").ToString <> "1").ToString _
                AndAlso xrow("IS_FROM_ERP").ToString = "Si" AndAlso xrow("IS_COMPLETED") = "COMPLETA" Then
                    UiButtonEnviarERP.Visibility = BarItemVisibility.Always
                    Exit For
                End If

            Next
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub


    Private Sub GridView2_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs) Handles GridView2.CustomColumnDisplayText
        If (e.Value IsNot Nothing) Then
            e.DisplayText = e.Value.ToString()
        End If
    End Sub

    Private Sub UiListaOperadoresParaReubicacionDetalle_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles UiListaOperadoresParaReubicacionDetalle.EditValueChanging
        If UiVistaDetalleReubicacion.IsFilterRow(UiVistaDetalleReubicacion.FocusedRowHandle) Then
            Exit Sub
        End If

        Dim pResult As String = ""


        Dim fila As DataRow
        fila = UiVistaDetalleReubicacion.GetDataRow(Me.UiVistaDetalleReubicacion.FocusedRowHandle)
        If IsDBNull(fila("IS_COMPLETED")) Then
            fila("IS_COMPLETED") = "INCOMPLETA"
        End If
        If Not fila("IS_COMPLETED") = "COMPLETA" Then


            If e.OldValue = "" OrElse MessageBox.Show("Confirma que desea re-asignar la tarea?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, False) = DialogResult.Yes Then

                Try

                    Dim pNewAssignedUser As String = e.NewValue

                    Dim wavePicking As Integer = 0
                    Dim materialId As String = ""
                    Dim serialNumber As String = 0


                    wavePicking = fila("WAVE_PICKING_ID")
                    materialId = fila("MATERIAL_ID")

                    If Not ChangeTask_AssignedUser(serialNumber, wavePicking, materialId, pNewAssignedUser, pResult) Then
                        MessageBox.Show(pResult)
                        e.Cancel = True
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub
End Class