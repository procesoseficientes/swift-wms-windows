Public Class frmAuditRec

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs)
        

    End Sub
    Public Function RefreshGrid(ByVal sDate As String, ByVal sDateTo As String, ByRef pResult As String, pTYPE As String) As String
        Try
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

                LoadGridLayout("GRID_AUDITS_RECEPTION", PublicLoginInfo.LoginID, Me.GridView1)
                LoadGridLayout("GRID_AUDITS_DISPATCH", PublicLoginInfo.LoginID, Me.GridViewDispatch)


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
        GridControl1.MainView.SaveLayoutToRegistry("INFO_UDIT_REC_FISCAL")

    End Sub

    Private Sub frmAuditRec_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmAuditRec_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmAuditRec_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        gLastScreenShowed = Me.Name
        Try
            Me.txtFechaInicial.DateTime = Format(Now, "MM/dd/yyyy 00:00:00") + " AM"
            Me.txtFechaFinal.DateTime = Format(Now.Date, "MM/dd/yyyy") + " 11:59:59 PM"
        Catch ex As Exception

        End Try
        

    End Sub

    Private Sub GridControl1_Click(sender As System.Object, e As System.EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs)
        Try
            PrintableComponentLink1.ShowPreview()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridView1_ColumnPositionChanged(sender As Object, e As System.EventArgs) Handles GridView1.ColumnPositionChanged
        Try
            GridControl1.MainView.SaveLayoutToRegistry("INFO_UDIT_REC_FISCAL")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridView1_StartSorting(sender As Object, e As System.EventArgs) Handles GridView1.StartSorting
        Try
            GridControl1.MainView.SaveLayoutToRegistry("INFO_UDIT_REC_FISCAL")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckButton1.CheckedChanged
        Try
            Me.txtFechaInicial.DateTime = Format(Now.Date, "MM/dd/yyyy 00:00:00") + " AM"
            Me.txtFechaFinal.DateTime = Format(Now.Date, "MM/dd/yyyy") + " 11:59:59 PM"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckButton4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckButton4.CheckedChanged
        Try
            Dim pDiffDate As Date
            pDiffDate = DateAdd(DateInterval.Month, -1, Now)
            Me.txtFechaInicial.DateTime = pDiffDate
            Me.txtFechaFinal.DateTime = Now
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub CheckButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckButton3.CheckedChanged
        Try
            Dim pDiffDate As Date
            pDiffDate = DateAdd(DateInterval.Day, -7, Now)
            Me.txtFechaInicial.DateTime = pDiffDate
            Me.txtFechaFinal.DateTime = Now
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub CheckButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckButton2.CheckedChanged
        Try
            Dim pDiffDate As Date
            pDiffDate = DateAdd(DateInterval.Day, -1, Now)
            Me.txtFechaInicial.DateTime = pDiffDate
            Me.txtFechaFinal.DateTime = Now
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub CheckButton5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckButton5.CheckedChanged
        Try
            Dim pDiffDate As Date
            pDiffDate = DateAdd(DateInterval.Month, -3, Now)
            Me.txtFechaInicial.DateTime = pDiffDate
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

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        SaveGridLayout("GRID_AUDITS_RECEPTION", PublicLoginInfo.LoginID, Me.GridView1)
        SaveGridLayout("GRID_AUDITS_DISPATCH", PublicLoginInfo.LoginID, Me.GridViewDispatch)
    End Sub
    Sub PrintGrid()
        Try
            GridView1.OptionsPrint.ExpandAllGroups = True
            GridView1.OptionsPrint.ExpandAllDetails = True
            GridView1.OptionsPrint.PrintDetails = True
            'GridView1.OptionsPrint.PrintPreview = True
            GridView1.OptionsPrint.PrintFilterInfo = True
            GridView1.OptionsPrint.UsePrintStyles = True

            GridView1.ExpandAllGroups()
            GridView1.ShowPrintPreview()

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)

        End Try
    End Sub
    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        PrintGrid()
    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        Try
            GridView1.ExpandAllGroups()
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub ToolStripButton6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton6.Click
        Try
            GridView1.CollapseAllGroups()
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub
End Class