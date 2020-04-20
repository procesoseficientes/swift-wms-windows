Public Class FrmVencimientoPolizas
    Private Sub LlenarGrid()
        Dim xserv As New OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoapClient("WMS_Insurance_DocsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Docs.asmx")
        Dim xset As DataSet
        Dim pRsult As String = ""

        If chkBtnSeguroPoliza.Checked Then
            xset = xserv.GetExpirationInsuranceDoc(dtFechaInicial.EditValue, dtFechaFinal.EditValue, pRsult, PublicLoginInfo.Environment)
            GridControl1.MainView = GridViewPolizaSeguro
        Else
            xset = xserv.GetExpirationPolizaDoc(dtFechaInicial.EditValue, dtFechaFinal.EditValue, pRsult, PublicLoginInfo.Environment)
            GridControl1.MainView = GridViewTipoPoliza
        End If

        If pRsult = "OK" Then
            GridControl1.DataSource = xset.Tables(0)
            GridControl1.Refresh()
        Else
            GridControl1.DataSource = Nothing
            NotifyStatus(pRsult, False, True)
        End If

        
        If chkBtnSeguroPoliza.Checked Then
            GridViewPolizaSeguro.OptionsDetail.AllowZoomDetail = True
            GridViewPolizaSeguro.OptionsDetail.ShowDetailTabs = False
            GridViewPolizaSeguro.ExpandAllGroups()
        Else
            GridViewTipoPoliza.OptionsDetail.AllowZoomDetail = True
            GridViewTipoPoliza.OptionsDetail.ShowDetailTabs = False
            GridViewTipoPoliza.ExpandAllGroups()
        End If

    End Sub

    
    Private Sub chkBtnHoy_CheckedChanged(sender As Object, e As EventArgs) Handles chkBtnHoy.CheckedChanged
        Me.dtFechaInicial.EditValue = Date.Today
        Me.dtFechaFinal.DateTime = Date.Today
    End Sub

    Private Sub chkBtnAyer_CheckedChanged(sender As Object, e As EventArgs) Handles chkBtnAyer.CheckedChanged
        Dim pDiffDate As Date
        pDiffDate = DateAdd(DateInterval.Day, 1, Now)
        Me.dtFechaInicial.DateTime = Now
        Me.dtFechaFinal.DateTime = pDiffDate
    End Sub

    Private Sub chkbtnSemana_CheckedChanged(sender As Object, e As EventArgs) Handles chkbtnSemana.CheckedChanged
        Dim pDiffDate As Date
        pDiffDate = DateAdd(DateInterval.Day, 7, Now)
        Me.dtFechaInicial.DateTime = Now
        Me.dtFechaFinal.DateTime = pDiffDate
    End Sub

    Private Sub chkMes_CheckedChanged(sender As Object, e As EventArgs) Handles chkMes.CheckedChanged
        Dim pDiffDate As Date
        pDiffDate = DateAdd(DateInterval.Month, 1, Now)
        Me.dtFechaInicial.DateTime = Now
        Me.dtFechaFinal.DateTime = pDiffDate
    End Sub

    Private Sub chkTresMeses_CheckedChanged(sender As Object, e As EventArgs) Handles chkTresMeses.CheckedChanged
        Dim pDiffDate As Date
        pDiffDate = DateAdd(DateInterval.Month, 3, Now)
        Me.dtFechaInicial.DateTime = Now
        Me.dtFechaFinal.DateTime = pDiffDate

    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        LlenarGrid()
    End Sub

    Private Sub chkBtnSeguroPoliza_CheckedChanged(sender As Object, e As EventArgs) Handles chkBtnSeguroPoliza.CheckedChanged
        LlenarGrid()
    End Sub

    Private Sub chkBtnTipoPoliza_CheckedChanged(sender As Object, e As EventArgs) Handles chkBtnTipoPoliza.CheckedChanged
        LlenarGrid()
    End Sub
    
    Private Sub btnExel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExel.ItemClick
        PrintGrid()
    End Sub

    Sub PrintGrid()
        Try
            If chkBtnSeguroPoliza.Checked Then
                SaveFileDialog1.DefaultExt = "xlsx"
                SaveFileDialog1.Filter = "Archivos de excel (*.xlsx)|*.xlsx"
                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                    GridViewPolizaSeguro.ExportToXlsx(SaveFileDialog1.FileName)
                End If
            Else
                SaveFileDialog1.DefaultExt = "xlsx"
                SaveFileDialog1.Filter = "Archivos de excel (*.xlsx)|*.xlsx"
                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                    GridViewTipoPoliza.ExportToXlsx(SaveFileDialog1.FileName)
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)

        End Try
    End Sub

    Private Sub btnExpandirTodo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExpandirTodo.ItemClick
        If chkBtnSeguroPoliza.Checked Then
            GridViewPolizaSeguro.ExpandAllGroups()
        Else
            GridViewTipoPoliza.ExpandAllGroups()
        End If
    End Sub

    Private Sub btnContraerTodo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnContraerTodo.ItemClick
        If chkBtnSeguroPoliza.Checked Then
            GridViewPolizaSeguro.CollapseAllGroups()
        Else
            GridViewTipoPoliza.CollapseAllGroups()
        End If
    End Sub

    Private Sub FrmVencimientoPolizas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtFechaInicial.EditValue = Date.Today
        dtFechaFinal.EditValue = Date.Today
    End Sub
End Class