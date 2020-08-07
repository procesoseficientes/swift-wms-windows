Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Text
Imports DevExpress.CodeParser
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraRichEdit.Fields

''' <summary>
''' Formulario de consulta de reportes de egreso
''' </summary>
Public Class frmConsultaDeIngresoFiscal

#Region "Variables Globales"
    Dim pResult As String
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
    Dim cargaFormulario As Boolean = False
    ReadOnly _xserv3PlPolizas As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim estaSeleccionadoClientesAlCargar As Boolean = False
#End Region




    ''' <summary>
    ''' Método para llenar los combos de régimen y cliente de la pantalla.
    ''' </summary>
    Private Sub fn_llena_combos()
        Cursor = Cursors.WaitCursor
        Try
            Dim i As Integer

            'llenamos el combo de los clientes
            Dim dsClientes As DataSet
            dsClientes = xClientsServ.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                UiListaCliente.Properties.DataSource = dsClientes.Tables(0)
                UiListaCliente.ShowPopup()
                estaSeleccionadoClientesAlCargar = True
                For j As Integer = 0 To DirectCast(UiListaCliente.Properties.DataSource, DataTable).Rows.Count - 1
                    UiListaVistaCliente.SelectRow(j)
                Next
                estaSeleccionadoClientesAlCargar = False
                UiListaCliente.ClosePopup()
                UiListaCliente.Text = ObtenerTextoAMostrarListaCliente()
            Else
                NotifyStatus(pResult, True, True)
            End If
            UiListaCliente.Properties.PopupFormWidth = UiListaCliente.Width - 10

            Dim xSettingServ As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
            'llenamos el combo de los regimenes de almacen
            Dim dsRegimenAlmacen As New DataSet
            dsRegimenAlmacen = xSettingServ.GetParam_ByParamKey("WMS3PL", "WAREHOUSE_REGIMEN", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                UiListaRegimen.Properties.DataSource = dsRegimenAlmacen.Tables(0)
            Else
                NotifyStatus(pResult, True, True)
            End If
            UiListaRegimen.Properties.PopupFormWidth = UiListaRegimen.Width - 10

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    ''' <summary>
    ''' Expandir Grupos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub UiBotonExpandirVista_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonExpandirVista.ItemClick
        UiGridViewEgresos.ExpandAllGroups()
        UiVistaIngresoGeneral.ExpandAllGroups()

    End Sub

    ''' <summary>
    ''' Colapsar grupos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub UiBotonContraerVista_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonContraerVista.ItemClick
        UiGridViewEgresos.CollapseAllGroups()
        UiVistaIngresoGeneral.CollapseAllGroups()
    End Sub


    ''' <summary>
    ''' Cambió Fecha inicio
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub UIFechaInicio_EditValueChanged(sender As Object, e As EventArgs) Handles UIFechaInicio.EditValueChanged
        If Not UiFechaFinal.EditValue Is Nothing Or Not String.IsNullOrEmpty(UiFechaFinal.EditValue) Then
            cargaFormulario = True
        End If
        If cargaFormulario Then
            LlenarVistaIngreso()
        End If
    End Sub

    ''' <summary>
    ''' Cambió fecha final
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub UiFechaFinal_EditValueChanged(sender As Object, e As EventArgs) Handles UiFechaFinal.EditValueChanged
        If Not UIFechaInicio.EditValue Is Nothing Or Not String.IsNullOrEmpty(UIFechaInicio.EditValue) Then
            cargaFormulario = True
        End If
        If cargaFormulario Then
            LlenarVistaIngreso()
        End If
    End Sub

    ''' <summary>
    ''' Usuario desea refrescar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub UiBotonRefrescarVista_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonRefrescarVista.ItemClick
        LlenarVistaIngreso()

    End Sub

    ''' <summary>
    ''' Llenar vista de ingreso
    ''' </summary>
    Private Sub LlenarVistaIngreso()

        Try


            If UIFechaInicio.EditValue Is Nothing Or String.IsNullOrEmpty(UIFechaInicio.EditValue) Then
                NotifyStatus("Seleccione la fecha de inicio", True, True)
                Return
            End If

            If UiFechaFinal.EditValue Is Nothing Or String.IsNullOrEmpty(UiFechaFinal.EditValue) Then
                NotifyStatus("Seleccione la fecha final.", True, True)
                Return
            End If
            cargaFormulario = True
            Dim fechaInicio, fechaFinal As Date
            fechaInicio = UIFechaInicio.EditValue
            fechaFinal = UiFechaFinal.EditValue
            fechaFinal = fechaFinal.AddHours(23).AddMinutes(59).AddSeconds(59)
            If fechaInicio > fechaFinal Then
                NotifyStatus("La fecha de inicio no puede ser mayor a la fecha final.", True, True)
                Return
            End If

            UiError.SetError(UiListaRegimen, "", ErrorType.None)
            UiError.SetError(UiListaCliente, "", ErrorType.None)

            If UiListaRegimen.EditValue Is Nothing Or String.IsNullOrEmpty(UiListaRegimen.EditValue) Then
                UiError.SetError(UiListaRegimen, "Seleccione el regimen.")
                Return
            End If

            If UiListaCliente.EditValue Is Nothing Or String.IsNullOrEmpty(UiListaCliente.EditValue) Then
                UiError.SetError(UiListaCliente, "Seleccione el cliente.")
                Return
            End If

            Dim clienteCliente As String = ObtenerListaClienteSelecionados()
            If String.IsNullOrEmpty(clienteCliente) Then
                UiError.SetError(UiListaCliente, "Seleccione el cliente.")
                Return
            End If


            Cursor = Cursors.WaitCursor
            UiVistaGridEgresos.DataSource = Nothing

            Dim regimen = ""
            pResult = "OK"
            regimen = UiListaRegimen.EditValue
            If (regimen.ToUpper().Equals("FISCAL")) Then
                UiVistaGridEgresos.MainView = UiGridViewEgresos
                UiVistaGridEgresos.DataSource = xserv.ObtnerConsultaDeIngreso(PublicLoginInfo.LoginID, fechaInicio, fechaFinal,
                                                                               clienteCliente,
                                                                               PublicLoginInfo.Environment, pResult)

                If Not pResult.ToUpper().Equals("OK") Then
                    NotifyStatus(pResult, True, True)
                End If
            Else
                UiVistaGridEgresos.MainView = UiVistaIngresoGeneral
                UiVistaGridEgresos.DataSource = xserv.ObtnerConsultaDeIngresoGeneral(PublicLoginInfo.LoginID, fechaInicio, fechaFinal,
                                                                               clienteCliente,
                                                                               PublicLoginInfo.Environment, pResult)
                If Not pResult.ToUpper().Equals("OK") Then
                    NotifyStatus(pResult, True, True)
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
        Cursor = Cursors.Default
    End Sub


    Private Sub UiBotonExportarExcelVista_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonExportarExcelVista.ItemClick
        ExportarVista()
    End Sub

    Private Sub ExportarVista()
        Using saveDialog As New SaveFileDialog
            saveDialog.Filter = $"Excel (2010) (.xlsx)|*.xlsx"
            If Not saveDialog.ShowDialog() = DialogResult.Cancel Then
                Dim exportFilePath As String = saveDialog.FileName
                UiVistaGridEgresos.ExportToXlsx(exportFilePath)
            End If
        End Using
    End Sub

    Private Sub UsuarioDeseaGenerarReporte()
        Try
            If UiGridViewEgresos.DataRowCount > 0 Or UiVistaIngresoGeneral.DataRowCount > 0 Then

                Dim dt As New DataTable("ReporteIngreso")
                UiGridViewEgresos.ExpandAllGroups()
                UiVistaIngresoGeneral.ExpandAllGroups()
                dt = CType(UiVistaGridEgresos.DataSource, DataTable).Copy()
                dt.Rows.Clear()

                If (UiVistaGridEgresos.MainView.Name.Equals("UiGridViewEgresos")) Then
                    For i As Integer = 0 To UiGridViewEgresos.DataRowCount - 1
                        dt.Rows.Add(UiGridViewEgresos.GetDataRow(i).ItemArray)
                    Next
                Else
                    For i As Integer = 0 To UiVistaIngresoGeneral.DataRowCount - 1
                        dt.Rows.Add(UiVistaIngresoGeneral.GetDataRow(i).ItemArray)
                    Next
                End If

                If (UiVistaGridEgresos.MainView.Name.Equals("UiGridViewEgresos")) Then
                    Dim rptApFiscal As New rptIngresoFiscal

                    rptApFiscal.DataSource = dt
                    rptApFiscal.DataMember = "ReporteIngreso"
                    rptApFiscal.RequestParameters = False
                    rptApFiscal.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                    rptApFiscal.Parameters("prmUser").Value = PublicLoginInfo.LoginName
                    rptApFiscal.ShowPreview()
                Else
                    Dim rptApFiscal As New rptConsultaIngreso

                    rptApFiscal.DataSource = dt
                    rptApFiscal.DataMember = "ReporteIngreso"
                    rptApFiscal.RequestParameters = False
                    rptApFiscal.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                    rptApFiscal.Parameters("prmUser").Value = PublicLoginInfo.LoginName
                    rptApFiscal.ShowPreview()

                End If

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub
    Private Function GetFilteredData(ByVal view As ColumnView) As DataView
        If view Is Nothing Then
            Return Nothing
        End If
        If view.ActiveFilter Is Nothing OrElse (Not view.ActiveFilterEnabled) OrElse view.ActiveFilter.Expression = "" Then
            Return TryCast(view.DataSource, DataView)
        End If

        Dim table As DataTable = (CType(view.DataSource, DataView)).Table
        Dim filteredDataView As New DataView(table)
        filteredDataView.RowFilter = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(view.ActiveFilterCriteria)
        Return filteredDataView
    End Function


    Private Sub UiBotonImprimir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonImprimir.ItemClick
        UsuarioDeseaGenerarReporte()
    End Sub

    Private Sub cmbClientes_EditValueChanged(sender As Object, e As EventArgs)
        If cargaFormulario Then
            LlenarVistaIngreso()
        End If
    End Sub

    Private Sub frmConsultaDeIngresoFiscal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UIFechaInicio.EditValue = Date.Today.AddDays(-7)
        UiFechaFinal.EditValue = Date.Today
        fn_llena_combos()
        loadLayout.Start()
    End Sub

    Private Function ObtenerTextoAMostrarListaCliente() As String
        Dim cadena As New StringBuilder()
        Try

            For Each row As DataRow In UiListaCliente.Properties.View.GetSelectedRows().[Select](Function(indice) UiListaCliente.Properties.View.GetDataRow(indice))
                If cadena.Length > 0 Then
                    cadena.Append(",")
                End If
                cadena.Append(row("CLIENT_CODE") + "|" + row("CLIENT_NAME"))
            Next
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
        Return cadena.ToString()
    End Function

    Private Function ObtenerListaClienteSelecionados() As String
        Dim cadena As New StringBuilder()
        Try

            For Each row As DataRow In UiListaCliente.Properties.View.GetSelectedRows().[Select](Function(indice) UiListaCliente.Properties.View.GetDataRow(indice))
                If cadena.Length > 0 Then
                    cadena.Append("|")
                End If
                cadena.Append(row("CLIENT_CODE"))
            Next
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
        Return cadena.ToString()
    End Function

    Private Sub UiListaCliente_CustomDisplayText(sender As Object, e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles UiListaCliente.CustomDisplayText
        e.DisplayText = ObtenerTextoAMostrarListaCliente()
    End Sub

    Private Sub UiListaVistaCliente_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles UiListaVistaCliente.SelectionChanged
        If Not estaSeleccionadoClientesAlCargar Then
            UiListaCliente.Text = ObtenerTextoAMostrarListaCliente()
        End If
    End Sub

    Private Sub UiGridViewEgresos_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles UiGridViewEgresos.CustomDrawCell
        If EscolumnaDeColorYElValorEsNumerico(e) Then
            ColocarColorDeCelda(e)
        End If
    End Sub

    Private Sub UiVistaIngresoGeneral_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles UiVistaIngresoGeneral.CustomDrawCell
        If EscolumnaDeColorYElValorEsNumerico(e) Then
            ColocarColorDeCelda(e)
        End If
    End Sub

    Private Function EscolumnaDeColorYElValorEsNumerico(e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) As Boolean
        Return e.CellValue IsNot Nothing AndAlso e.Column.FieldName = "COLOR" AndAlso IsNumeric(e.CellValue.ToString())
    End Function

    Private Shared Sub ColocarColorDeCelda(e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
        Dim color As Color = Color.FromArgb(Convert.ToInt32(e.CellValue))
        Dim brush As New LinearGradientBrush(e.Bounds, color, color, LinearGradientMode.ForwardDiagonal)

        e.Graphics.FillRectangle(brush, e.Bounds)
        brush.Dispose()
        e.Graphics.DrawString("", e.Appearance.Font, Brushes.Black, New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
        e.Handled = True
    End Sub

    Dim ticks = 0
    Private Sub loadLayout_Tick(sender As Object, e As EventArgs) Handles loadLayout.Tick
        If ticks > 0 Then
            LoadGridLayout("GridReporteIgresos", PublicLoginInfo.LoginID, UiVistaIngresoGeneral)
            loadLayout.Stop()
        Else
            ticks += 1
        End If
    End Sub

    Private Sub btnSaveLayout_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSaveLayout.ItemClick
        SaveGridLayout("GridReporteIgresos", PublicLoginInfo.LoginID, UiVistaIngresoGeneral)
    End Sub

    Private Sub frmConsultaDeIngresoFiscal_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        SaveGridLayout("GridReporteIgresos", PublicLoginInfo.LoginID, UiVistaIngresoGeneral)
    End Sub
End Class