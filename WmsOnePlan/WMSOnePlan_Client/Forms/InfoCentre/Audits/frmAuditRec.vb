Imports System.Globalization
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmAuditRec

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs)


    End Sub
    Public Function RefreshGrid(ByVal sDate As String, ByVal sDateTo As String, ByRef pResult As String, pTYPE As String) As String
        Try
            barBtnViewImg.Enabled = False
            Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            Dim xset As DataSet

            If pTYPE = "D" Then
                xset = xserv.GetAuditLogDispatch(sDate, sDateTo, pResult, PublicLoginInfo.Environment)
                GridControl1.MainView = GridViewDispatch
            Else
                xset = xserv.GetAuditLog(sDate, sDateTo, pResult, PublicLoginInfo.Environment)
                GridControl1.MainView = GridView1
            End If


            If pResult = "OK" Then

                xset.Tables("CONTROL").Columns("MATERIAL_ID").ColumnMapping = MappingType.Hidden
                Try
                    xset.Tables("SERIAL").Columns("AUDIT_ID").ColumnMapping = MappingType.Hidden
                    xset.Tables("SERIAL").Columns("MATERIAL_ID").ColumnMapping = MappingType.Hidden
                Catch ex As Exception

                End Try

                GridControl1.DataSource = xset.Tables(0)
                GridControl1.Refresh()
                GridView1.OptionsDetail.AllowZoomDetail = True
                GridView1.OptionsDetail.ShowDetailTabs = False

                'LoadGridLayout("GRID_AUDITS_RECEPTION", PublicLoginInfo.LoginID, Me.GridView1)
                'LoadGridLayout("GRID_AUDITS_DISPATCH", PublicLoginInfo.LoginID, Me.GridViewDispatch)


            Else

                NotifyStatus(pResult, False, True)
                GridControl1.DataSource = Nothing
            End If
            xserv = Nothing
        Catch ex As Exception

            pResult = ex.Message
            NotifyStatus(pResult, False, True)
            Return "ERROR"
        End Try

        Return ""
    End Function


    Private Sub frmAuditRec_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmAuditRec_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        gLastScreenShowed = Me.Name
        
        SaveGridLayout("INFO_UDIT_REC_FISCAL", PublicLoginInfo.LoginID, Me.GridControl1.MainView)

    End Sub

    Private Sub frmAuditRec_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmAuditRec_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gLastScreenShowed = Me.Name
          SaveGridLayout("INFO_UDIT_REC_FISCAL", PublicLoginInfo.LoginID, Me.GridControl1.MainView)

    End Sub

    Private Sub frmAuditRec_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        gLastScreenShowed = Me.Name
        Try
            Me.txtFechaInicial.DateTime = Now.AddHours(-Now.Hour).AddMinutes(-Now.Minute)
            Me.txtFechaFinal.DateTime = Now
        Catch ex As Exception

        End Try
        LoadGridLayout("GRID_AUDITS_RECEPTION", PublicLoginInfo.LoginID, Me.GridView1)
        LoadGridLayout("GRID_AUDITS_DISPATCH", PublicLoginInfo.LoginID, Me.GridViewDispatch)
    End Sub

    Private Sub GridControl1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs)
        Try
            PrintableComponentLink1.ShowPreview()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridView1_ColumnPositionChanged(sender As Object, e As System.EventArgs) Handles GridView1.ColumnPositionChanged
        Try
            SaveGridLayout("INFO_UDIT_REC_FISCAL", PublicLoginInfo.LoginID, Me.GridControl1.MainView)
            
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridView1_StartSorting(sender As Object, e As System.EventArgs) Handles GridView1.StartSorting
        Try
              SaveGridLayout("INFO_UDIT_REC_FISCAL", PublicLoginInfo.LoginID, Me.GridControl1.MainView)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckButton1.CheckedChanged
        Try
            Me.txtFechaInicial.DateTime = Now.AddHours(-Now.Hour).AddMinutes(-Now.Minute)
            Me.txtFechaFinal.DateTime = Now

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckButton4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckButton4.CheckedChanged
        Try
            Dim pDiffDate As Date
            pDiffDate = DateAdd(DateInterval.Month, -1, Now)
            Me.txtFechaInicial.DateTime = pDiffDate.AddHours(-pDiffDate.Hour).AddMinutes(-pDiffDate.Minute)
        Me.txtFechaFinal.DateTime = Now
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckButton3.CheckedChanged
        Try
            Dim pDiffDate As Date
            pDiffDate = DateAdd(DateInterval.Day, -7, Now)
            Me.txtFechaInicial.DateTime = pDiffDate.AddHours(-pDiffDate.Hour).AddMinutes(-pDiffDate.Minute)
        Me.txtFechaFinal.DateTime = Now
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckButton2.CheckedChanged
        Try
            Dim pDiffDate As Date
            pDiffDate = DateAdd(DateInterval.Day, -1, Now)
            Me.txtFechaInicial.DateTime = pDiffDate.AddHours(-pDiffDate.Hour).AddMinutes(-pDiffDate.Minute)
            Me.txtFechaFinal.DateTime = Now
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckButton5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckButton5.CheckedChanged
        Try
            Dim pDiffDate As Date
            pDiffDate = DateAdd(DateInterval.Month, -3, Now)
            Me.txtFechaInicial.DateTime = pDiffDate.AddHours(-pDiffDate.Hour).AddMinutes(-pDiffDate.Minute)
            Me.txtFechaFinal.DateTime = Now
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click
        ShowData()
    End Sub
    Sub ShowData()
        Try
            Dim pResult As String = ""
            Dim pFechaFormated As String
            Dim pFechaFormatedTo As String

            pFechaFormated = Me.txtFechaInicial.DateTime.ToString("yyyy-MM-dd")
            pFechaFormatedTo = Me.txtFechaFinal.DateTime.ToString("yyyy-MM-dd")

            RefreshGrid(pFechaFormated, pFechaFormatedTo, pResult, IIf(chkBtnAuditRecepcion.Checked, "R", "D"))
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try

    End Sub
    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub chkBtnAuditRecepcion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkBtnAuditRecepcion.CheckedChanged
        ShowData()
    End Sub

    Private Sub chkBtnAuditDespacho_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkBtnAuditDespacho.CheckedChanged
        ShowData()
    End Sub

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs)
        'SaveGridLayout("GRID_AUDITS_RECEPTION", PublicLoginInfo.LoginID, Me.GridView1)
        'SaveGridLayout("GRID_AUDITS_DISPATCH", PublicLoginInfo.LoginID, Me.GridViewDispatch)
    End Sub
    Sub PrintGrid()
        Try
            'GridView1.OptionsPrint.ExpandAllGroups = True
            'GridView1.OptionsPrint.ExpandAllDetails = True
            'GridView1.OptionsPrint.PrintDetails = True
            ''GridView1.OptionsPrint.PrintPreview = True
            'GridView1.OptionsPrint.PrintFilterInfo = True
            'GridView1.OptionsPrint.UsePrintStyles = True

            GridView1.ExpandAllGroups()
            GridView1.ShowPrintPreview()

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)

        End Try
    End Sub
    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs)
        'PrintGrid()
    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs)
        Try
            'If chkBtnAuditDespacho.Checked Then
            '    GridViewDispatch.ExpandAllGroups()
            'Else
            '    GridView1.ExpandAllGroups()
            'End If

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub ToolStripButton6_Click(sender As System.Object, e As System.EventArgs)
        Try
            'GridView1.CollapseAllGroups()
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub barBtnExel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnExel.ItemClick
        PrintGrid()
    End Sub


    Private Sub barBtnExpadir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnExpadir.ItemClick
        If chkBtnAuditDespacho.Checked Then
            GridViewDispatch.ExpandAllGroups()
        Else
            GridView1.ExpandAllGroups()
        End If
    End Sub

    Private Sub barBtnContraer_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnContraer.ItemClick
        If chkBtnAuditDespacho.Checked Then
            GridViewDispatch.CollapseAllGroups()
        Else
            GridView1.CollapseAllGroups()
        End If
    End Sub

    Private Sub barBtnSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnSave.ItemClick
        SaveGridLayout("GRID_AUDITS_RECEPTION", PublicLoginInfo.LoginID, Me.GridView1)
        SaveGridLayout("GRID_AUDITS_DISPATCH", PublicLoginInfo.LoginID, Me.GridViewDispatch)
    End Sub

    Private Sub ViewImg()
        Try
            Dim pGridview As GridView
            pGridview = IIf(chkBtnAuditDespacho.Checked, GridViewDispatch, GridView1)

            If pGridview.SelectedRowsCount = 1 Then
                Dim xdatarow As DataRow = pGridview.GetDataRow(pGridview.FocusedRowHandle)
                Dim acuerdoComercialId As String = xdatarow("CODIGO_POLIZA").ToString
                Dim frm As New FrmImgAudit(acuerdoComercialId)
                Cursor = Cursors.WaitCursor
                frm.ShowDialog()
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub barBtnViewImg_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnViewImg.ItemClick
        ViewImg()
    End Sub


    'Private Sub GridControl1_FocusedViewChanged(sender As Object, e As DevExpress.XtraGrid.ViewFocusEventArgs) Handles GridControl1.FocusedViewChanged
    '    ViewFotos()
    'End Sub


    Private Sub ViewFotos()
        Try
            Dim pGridview As GridView
            pGridview = IIf(chkBtnAuditDespacho.Checked, GridViewDispatch, GridView1)

            If pGridview.RowCount > 0 Then
                If pGridview.SelectedRowsCount = 1 Then
                    Dim xdatarow As DataRow = pGridview.GetDataRow(pGridview.FocusedRowHandle)
                    Dim fotos As String = xdatarow("FOTOS").ToString
                    barBtnViewImg.Enabled = fotos.Equals("SI")
                    Exit Sub
                End If
            End If

            barBtnViewImg.Enabled = False
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged, GridViewDispatch.FocusedRowChanged
        ViewFotos()
    End Sub

    Private Sub txtFechaInicial_EditValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicial.EditValueChanged
        txtFechaInicial.Properties.Mask.Culture = New CultureInfo("es-GT")
        txtFechaInicial.Properties.Mask.EditMask = "dd/MM/yyyy"
        txtFechaInicial.Properties.Mask.UseMaskAsDisplayFormat = True
    End Sub

    Private Sub txtFechaFinal_EditValueChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.EditValueChanged
        txtFechaFinal.Properties.Mask.Culture = New CultureInfo("es-GT")
        txtFechaFinal.Properties.Mask.EditMask = "dd/MM/yyyy"
        txtFechaFinal.Properties.Mask.UseMaskAsDisplayFormat = True
    End Sub
End Class