Public Class frmAuditDisp 

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        FilterInfo()
    End Sub
    Sub FilterInfo()
        Dim pResult As String = ""
        Dim pFechaFormated As String
        Dim pFechaFormatedTo As String

        Dim pYear As String = Year(Me.DateEdit1.Text).ToString
        Dim pMonth As String = Month(Me.DateEdit1.Text).ToString
        Dim pDay As String = CDate(Me.DateEdit1.Text).Day.ToString
        pFechaFormated = pYear + "-" + pMonth + "-" + pDay

        Dim pYearTo As String = Year(Me.DateEdit2.Text).ToString
        Dim pMonthTo As String = Month(Me.DateEdit2.Text).ToString
        Dim pDayTo As String = CDate(Me.DateEdit2.Text).Day.ToString
        pFechaFormatedTo = pYearTo + "-" + pMonthTo + "-" + pDayTo

        RefreshGrid(pFechaFormated, pFechaFormatedTo, pResult)
    End Sub
    Public Function RefreshGrid(ByVal sDate As String, ByVal sDateTo As String, ByRef pResult As String) As String
        Try
            Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            Cursor.Current = Cursors.WaitCursor
            Dim xset As DataSet = xserv.GetAuditLogDispatch(sDate, sDateTo, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then

                SaveSetting("ONEPLAN_WMS", "AUDIT_DISPATCH", "SINCE_DATE", sDate.ToString)
                SaveSetting("ONEPLAN_WMS", "AUDIT_DISPATCH", "TO_DATE", sDateTo.ToString)

                xset.Tables("CONTROL").Columns("MATERIAL_ID").ColumnMapping = MappingType.Hidden
                xset.Tables("SERIAL").Columns("AUDIT_ID").ColumnMapping = MappingType.Hidden
                xset.Tables("SERIAL").Columns("MATERIAL_ID").ColumnMapping = MappingType.Hidden

                GridControl1.DataSource = xset.Tables(0)
                GridControl1.Refresh()
                GridView1.OptionsDetail.AllowZoomDetail = True
                GridView1.OptionsDetail.ShowDetailTabs = False

                'GridControl1.MainView.RestoreLayoutFromRegistry("INFO_UDIT_DISP_FISCAL")

            Else
                Cursor.Current = Cursors.Default
                NotifyStatus(pResult + "/RefreshGrid()", True, True)
                GridControl1.DataSource = Nothing
            End If
            Cursor.Current = Cursors.Default
            xserv = Nothing
        Catch ex As Exception
            pResult = ex.Message
            Return "ERROR"
        End Try

        Return ""
    End Function

    Private Sub frmAuditDisp_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmAuditDisp_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave
        gLastScreenShowed = Me.Name
        GridControl1.MainView.SaveLayoutToRegistry("INFO_UDIT_DISP_FISCAL")
    End Sub

    Private Sub frmAuditDisp_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim pSinceDate = GetSetting("ONEPLAN_WMS", "AUDIT_DISPATCH", "SINCE_DATE", Now.Date.ToString)
        Dim pToDate = GetSetting("ONEPLAN_WMS", "AUDIT_DISPATCH", "TO_DATE", Now.Date.ToString)

        Me.DateEdit1.Text = pSinceDate
        Me.DateEdit2.Text = pToDate
        FilterInfo()

    End Sub

    Private Sub frmAuditDisp_LostFocus(sender As Object, e As System.EventArgs) Handles Me.LostFocus
        gLastScreenShowed = Me.Name
        GridControl1.MainView.SaveLayoutToRegistry("INFO_UDIT_DISP_FISCAL")
    End Sub

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton1.Click
        Try
            PrintableComponentLink1.ShowPreview()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridControl1_Click(sender As System.Object, e As System.EventArgs) Handles GridControl1.Click

    End Sub
End Class