Public Class frmOccupancy

    Private Sub frmOccupancy_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        
          SaveGridLayout("GRID_OCCUPANCY", PublicLoginInfo.LoginID, Me.GridControl1.MainView)


    End Sub

    Private Sub frmOccupancy_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        gLastScreenShowed = Me.Name

    End Sub

    Private Sub frmOccupancy_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave
        gLastScreenShowed = Me.Name

    End Sub

    Private Sub frmOccupancy_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        gLastScreenShowed = Me.Name
        
        LoadGridLayout("GRID_OCCUPANCY", PublicLoginInfo.LoginID, Me.GridControl1.MainView)
        Me.txtFechaInicial.DateTime = DateTime.Today' Format(Now, "MM/dd/yyyy 00:00:00") + " AM"
        Me.txtFechaFinal.DateTime = DateTime.Today' "MM/dd/yyyy") + " 11:59:59 PM"

    End Sub

    Private Sub frmOccupancy_LostFocus(sender As Object, e As System.EventArgs) Handles Me.LostFocus
        gLastScreenShowed = Me.Name

    End Sub

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs)
        Try
            SaveGridLayout("GRID_OCCUPANCY", PublicLoginInfo.LoginID, Me.GridControl1.MainView)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckButton1.CheckedChanged
        Try
            Me.txtFechaInicial.DateTime = DateTime.Today'Format(Now.Date, "MM/dd/yyyy")
            Me.txtFechaFinal.DateTime = DateTime.Today'Format(Now.Date, "MM/dd/yyyy")

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

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click
        ShowData()
    End Sub
    Sub ShowData()
        Try
            Dim pResult As String = ""
            Dim pFechaFormated As String
            Dim pFechaFormatedTo As String

            pFechaFormated = Me.txtFechaInicial.DateTime.ToShortDateString
            pFechaFormatedTo = Me.txtFechaFinal.DateTime.ToShortDateString

            RefreshGrid(pFechaFormated, pFechaFormatedTo, pResult)
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try

    End Sub
    Public Function RefreshGrid(ByVal sDate As String, ByVal sDateTo As String, ByRef pResult As String) As String
        Try
            Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            Dim xset As DataSet = Nothing

            xset = xserv.GetOccupancyLevel(sDate, sDateTo, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then

                GridControl1.DataSource = xset.Tables(0)
                GridControl1.Refresh()
                GridView1.OptionsDetail.AllowZoomDetail = True
                GridView1.OptionsDetail.ShowDetailTabs = False

            Else

                NotifyStatus(pResult, False, True)
                GridControl1.DataSource = Nothing
            End If
            xserv = Nothing
        Catch ex As Exception
            pResult = ex.Message
            Return "ERROR"
        End Try

        Return ""
    End Function
    Sub PrintGrid()
        Try

            GridView1.OptionsPrint.PrintHeader = True
            GridView1.OptionsPrint.ExpandAllGroups = True
            GridView1.OptionsPrint.ExpandAllDetails = True
            GridView1.OptionsPrint.PrintDetails = True

            GridView1.OptionsPrint.PrintFilterInfo = True
            GridView1.OptionsPrint.UsePrintStyles = True

            GridView1.ExpandAllGroups()
            GridView1.ShowPrintPreview()

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)

        End Try
    End Sub
    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs)
        PrintGrid()
    End Sub

    Private Sub barBtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnPrint.ItemClick
        GridView1.ExpandAllGroups()
        GridView1.ShowPrintPreview()
    End Sub
    
    Private Sub barBtnExpandir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnExpandir.ItemClick
        GridView1.ExpandAllGroups()
    End Sub
    
    Private Sub barBtnContraer_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnContraer.ItemClick
        GridView1.CollapseAllGroups()
    End Sub

    Private Sub barBtnSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnSave.ItemClick
        Try
             SaveGridLayout("GRID_OCCUPANCY", PublicLoginInfo.LoginID, Me.GridControl1.MainView)
            
        Catch ex As Exception

        End Try
    End Sub
End Class