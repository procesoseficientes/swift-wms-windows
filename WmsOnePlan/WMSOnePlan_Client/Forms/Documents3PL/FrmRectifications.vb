Imports System.IO
Imports System.Web.UI.WebControls.Expressions
Imports DevExpress.XtraReports.UI

Public Class FrmRectifications
    Dim cargaFormulario As Boolean = False
    ReadOnly _xserv3PlPolizas As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Private Sub FrmRectifications_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UIFechaInicio.EditValue = Date.Today.AddDays(-7)
        UiFechaFinal.EditValue = Date.Today
        cargaFormulario = True
        LlenarVistaRectificaciones()
    End Sub

    Private Sub UiBotonExpandirVista_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonExpandirVista.ItemClick
        UIVistaRectificacion.ExpandAllGroups()
    End Sub

    Private Sub UiBotonContraerVista_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonContraerVista.ItemClick
        UIVistaRectificacion.CollapseAllGroups()
    End Sub


    Private Sub UIFechaInicio_EditValueChanged(sender As Object, e As EventArgs) Handles UIFechaInicio.EditValueChanged
        If cargaFormulario Then
            LlenarVistaRectificaciones()
        End If
    End Sub

    Private Sub UiFechaFinal_EditValueChanged(sender As Object, e As EventArgs) Handles UiFechaFinal.EditValueChanged
        If cargaFormulario Then
            LlenarVistaRectificaciones()
        End If
    End Sub

    Private Sub UiBotonRefrescarVista_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonRefrescarVista.ItemClick
        LlenarVistaRectificaciones()
    End Sub

    Private Sub LlenarVistaRectificaciones()
        Try
            If UIFechaInicio.EditValue Is Nothing Or String.IsNullOrEmpty(UIFechaInicio.EditValue) Then
                NotifyStatus("Seleccione la fecha de inicio", True, True)
                Return
            End If

            If UiFechaFinal.EditValue Is Nothing Or String.IsNullOrEmpty(UiFechaFinal.EditValue) Then
                NotifyStatus("Seleccione la fecha final.", True, True)
                Return
            End If

            Dim fechaInicio, fechaFinal As Date
            fechaInicio = UIFechaInicio.EditValue
            fechaFinal = UiFechaFinal.EditValue
            fechaFinal = fechaFinal.AddHours(23)
            If fechaInicio > fechaFinal Then
                NotifyStatus("La fecha de inicio no puede ser mayor a la fecha final.", True, True)
                Return
            End If
            Dim pResult As String = ""
            UiVistasRectificaciones.DataSource = _xserv3PlPolizas.ObtenerRectificaciones(fechaInicio, fechaFinal, pResult, PublicLoginInfo.Environment)
            If Not String.IsNullOrEmpty(pResult) Then
                NotifyStatus(pResult, True, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub


    Private Sub UiBotonExportarExcelVista_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonExportarExcelVista.ItemClick
        ExportarVista()
    End Sub

    Private Sub ExportarVista()
        Using saveDialog As New SaveFileDialog
            saveDialog.Filter = "Excel (2010) (.xlsx)|*.xlsx"
            If Not saveDialog.ShowDialog() = DialogResult.Cancel Then
                Dim exportFilePath As String = saveDialog.FileName
                UiVistasRectificaciones.ExportToXlsx(exportFilePath)
            End If
        End Using
    End Sub

    Private Sub UsuarioDeseaGenerarReporte()
        Try
            If UIVistaRectificacion.RowCount > 0 Then
                Dim dt As DataTable = CType(UIVistaRectificacion.DataSource, DataView).ToTable()
                Dim rptApFiscal As New rptRectification
                rptApFiscal.Parameters("logoImg").Value = PublicLoginInfo.LOGO 
                rptApFiscal.DataMember = "OP_WMS_GET_RECTIFICATIONS"
                rptApFiscal.DataSource = dt
                rptApFiscal.ShowPreview()
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub UiBotonImprimir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonImprimir.ItemClick
        UsuarioDeseaGenerarReporte()
    End Sub
End Class