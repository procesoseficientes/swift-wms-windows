Imports System.IO
Imports System.Text
Imports System.Web.UI.WebControls.Expressions
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraReports.UI

''' <summary>
''' Formulario de consulta de reportes de egreso
''' </summary>
Public Class FrmConsultaDeEgreso

#Region "Variables Globales"
    Dim pResult As String
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
    Dim xSettingServ As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
    Dim cargaFormulario As Boolean = False
    ReadOnly _xserv3PlPolizas As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim estaSeleccionadoClientesAlCargar = False
    
#End Region

    ''' <summary>
    ''' Iniciar carga de formulario
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FrmConsultaDeEgreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UIFechaInicio.EditValue = Date.Today.AddDays(-7)
        UiFechaFinal.EditValue = Date.Today
        fn_llena_combos()
        cmbClientes.ShowPopup()
        estaSeleccionadoClientesAlCargar = True
        For i As Integer = 0 To DirectCast(cmbClientes.Properties.DataSource, DataTable).Rows.Count - 1
            GridView3.SelectRow(i)
        Next
        estaSeleccionadoClientesAlCargar = False
        cmbClientes.ClosePopup()
        cmbClientes.Text = ObtenerTextoAMostrarListaCliente()
    End Sub

    ''' <summary>
    ''' Método para llenar los combos de régimen y cliente de la pantalla.
    ''' </summary>
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
            Else
                MsgBox(pResult)
            End If
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

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Expandir Grupos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub UiBotonExpandirVista_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonExpandirVista.ItemClick
        UiGridViewEgresos.ExpandAllGroups()
    End Sub

    ''' <summary>
    ''' Colapsar grupos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub UiBotonContraerVista_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonContraerVista.ItemClick
        UiGridViewEgresos.CollapseAllGroups()
    End Sub


    Private Sub UIFechaInicio_EditValueChanged(sender As Object, e As EventArgs) Handles UIFechaInicio.EditValueChanged
        'If Not UiFechaFinal.EditValue Is Nothing Or Not String.IsNullOrEmpty(UiFechaFinal.EditValue) Then
        '    cargaFormulario = True
        'End If
        'If cargaFormulario Then
        '    LlenarVistaEgresos()
        'End If
    End Sub

    Private Sub UiFechaFinal_EditValueChanged(sender As Object, e As EventArgs) Handles UiFechaFinal.EditValueChanged
        'If Not UIFechaInicio.EditValue Is Nothing Or Not String.IsNullOrEmpty(UIFechaInicio.EditValue) Then
        '    cargaFormulario = True
        'End If
        'If cargaFormulario Then
        '    LlenarVistaEgresos()
        'End If
    End Sub

    Private Sub UiBotonRefrescarVista_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonRefrescarVista.ItemClick
        LlenarVistaEgresos()
    End Sub

    Private Sub LlenarVistaEgresos()
        
        Try
            If UIFechaInicio.EditValue Is Nothing Or String.IsNullOrEmpty(UIFechaInicio.EditValue) Then
                NotifyStatus("Seleccione la fecha de inicio", True, True)
                Return
            End If

            If UiFechaFinal.EditValue Is Nothing Or String.IsNullOrEmpty(UiFechaFinal.EditValue) Then
                NotifyStatus("Seleccione la fecha final.", True, True)
                Return
            End If

            If cmbRegimen.EditValue Is Nothing Then
                NotifyStatus("Seleccione un regimen", True, True)
                Return
            End If

            Dim clientesSeleccionados As String = ObtenerListaClienteSelecionados()

            If (String.IsNullOrEmpty(clientesSeleccionados)) Then
                NotifyStatus("Seleccione un cliente", True, True)
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
            Cursor = Cursors.WaitCursor
            Dim pResult As String = ""

            UiVistaGridEgresos.DataSource = xserv.ObtnerConsultaDeEgresos(PublicLoginInfo.LoginID, fechaInicio, fechaFinal,
                                                                           clientesSeleccionados,
                                                                          If(cmbRegimen.EditValue Is Nothing, Nothing, cmbRegimen.EditValue.ToString()),
                                                                           PublicLoginInfo.Environment, pResult)

            If Not String.IsNullOrEmpty(pResult) Then
                NotifyStatus(pResult, True, True)
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
            saveDialog.Filter = "Excel (2010) (.xlsx)|*.xlsx"
            If Not saveDialog.ShowDialog() = DialogResult.Cancel Then
                Dim exportFilePath As String = saveDialog.FileName
                UiVistaGridEgresos.ExportToXlsx(exportFilePath)
            End If
        End Using
    End Sub

    Private Sub UsuarioDeseaGenerarReporte()
        Try
            If UiGridViewEgresos.DataRowCount > 0 Then
                Dim dt As DataTable '= GetFilteredData(UiVistaGridEgresos.MainView).ToTable()

                dt = CType(UiVistaGridEgresos.DataSource, DataTable).Copy()
                dt.Rows.Clear()

                For i As Integer = 0 To UiGridViewEgresos.DataRowCount - 1
                    dt.Rows.Add(UiGridViewEgresos.GetDataRow(i).ItemArray)
                Next

                'Dim documento As Integer
                'documento = UiGridViewEgresos.GetFocusedRow("DOC_ID")
                Dim grupoRegimen As String
                grupoRegimen = IIf(IsDBNull(dt.Rows(0)("GRUPO_REGIMEN")), "", dt.Rows(0)("GRUPO_REGIMEN"))

                Dim documentoRegimen As String
                documentoRegimen = IIf(IsDBNull(dt.Rows(0)("REGIMEN_DOCUMENTO")), "", dt.Rows(0)("REGIMEN_DOCUMENTO"))

                'For i = 0 To dt.Rows.Count - 1
                '    Dim fila = dt.Rows(i)
                '    If (fila("DOC_ID") <> documento) Then
                '        fila.Delete()
                '    End If
                'Next


                Dim rptApFiscal As New rptConsultaEgresos
                rptApFiscal.DataSource = dt
                rptApFiscal.RequestParameters = False
                rptApFiscal.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                rptApFiscal.Parameters("prmUsers").Value = PublicLoginInfo.LoginName
                rptApFiscal.Parameters("prmGrupoRegimen").Value = grupoRegimen
                rptApFiscal.Parameters("prmDocumentoRegimen").Value = documentoRegimen
                rptApFiscal.Parameters("ValorUnitario").Value = iif(cmbRegimen.EditValue.equals("FISCAL"), "Valor Impuestos","Valor Unitario")
                rptApFiscal.Parameters("ValorTotal").Value = iif(cmbRegimen.EditValue.equals("FISCAL"), "Valor Cif","Total")
                rptApFiscal.ShowPreview()
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
    Private Sub CargarVista()

    End Sub
    Private Sub cmbRegimen_EditValueChanged(sender As Object, e As EventArgs) Handles cmbRegimen.EditValueChanged
        'If cargaFormulario Then
        '    LlenarVistaEgresos()
        'End If
    End Sub

    Private Sub UiVistaGridEgresos_Click(sender As Object, e As EventArgs) Handles UiVistaGridEgresos.Click

    End Sub

    Private Sub cmbClientes_EditValueChanged(sender As Object, e As EventArgs) Handles cmbClientes.EditValueChanged
        If cargaFormulario Then
            'LlenarVistaEgresos()
        End If
    End Sub

    Private Sub UiBotonLimpiarCliente_Click(sender As Object, e As EventArgs)

        cmbClientes.EditValue = Nothing
    End Sub

    Private Sub UiBotonLimpiarRegimen_Click(sender As Object, e As EventArgs)
        cmbRegimen.EditValue = Nothing
    End Sub

    Private Sub cmbClientes_CustomDisplayText(sender As Object, e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles cmbClientes.CustomDisplayText
        e.DisplayText = ObtenerTextoAMostrarListaCliente()
    End Sub

    Private Sub GridView3_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView3.SelectionChanged
        If Not estaSeleccionadoClientesAlCargar Then
            cmbClientes.Text = ObtenerTextoAMostrarListaCliente()
        End If
    End Sub

    Private Function ObtenerTextoAMostrarListaCliente() As String
        Dim cadena As New StringBuilder()
        Try

            For Each row As DataRow In cmbClientes.Properties.View.GetSelectedRows().[Select](Function(indice) cmbClientes.Properties.View.GetDataRow(indice))
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

            For Each row As DataRow In cmbClientes.Properties.View.GetSelectedRows().[Select](Function(indice) cmbClientes.Properties.View.GetDataRow(indice))
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
End Class