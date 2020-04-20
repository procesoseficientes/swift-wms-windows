Imports System.Data
Imports System.Drawing.Drawing2D
Imports System.IO
Imports MobilityScm.Modelo.Tipos
Imports MobilityScm.Modelo.Vistas

Public Class frmInvViews
    Dim gViewName As String = ""

    Private Sub NavBarControl1_Click(sender As System.Object, e As System.EventArgs) Handles NavBarControl1.Click

    End Sub
    Sub ShowInventory(ByRef xgridview As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim xDataSet As DataSet
        Dim pResult As String = ""
        Try
            Cursor = Cursors.WaitCursor
            Dim xserv As New OnePlanServices_InfoInventory.WMS_InfoInventorySoapClient("WMS_InfoInventorySoap", PublicLoginInfo.WSHost + "/Info/wms_InfoInventory.asmx")

            RibbonForm1.Static_Message.Caption = Now.ToString + " " + pResult
            RibbonForm1.Static_Message.Refresh()
            xDataSet = xserv.GetInventory_View(PublicLoginInfo.LoginID, gViewName, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                Me.GridControl1.DataSource = xDataSet.Tables(0)
                GridControl1.MainView = xgridview
            Else
                MessageBox.Show(pResult)
                RibbonForm1.Static_Message.Caption = Now.ToString + " " + pResult
                RibbonForm1.Static_Message.Refresh()
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            RibbonForm1.Static_Message.Caption = Now.ToString + " " + ex.Message
            RibbonForm1.Static_Message.Refresh()
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub NavBarItem_InvXWH_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem_InvXWH.LinkClicked
        Try
            gViewName = "BY_WAREHOUSE"
            ShowInventory(GridView2)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmInvViews_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmInvViews_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gLastScreenShowed = Me.Name
        Try
            gLastScreenShowed = Me.Name

            SaveGridLayout("INV_ONLINE_" + gViewName, PublicLoginInfo.LoginID, Me.GridView2)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmInvViews_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        gLastScreenShowed = Me.Name
        Try

        Catch ex As Exception

        End Try


    End Sub

    Private Sub frmInvViews_LostFocus(sender As Object, e As System.EventArgs) Handles Me.LostFocus
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub NavBarItem_InvXRegimen_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem_InvXRegimen.LinkClicked
        Try
            gViewName = "BY_REGIMEN"
            ShowInventory(GridView3)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NavBarItem_InvXAcCom_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem_InvXAcCom.LinkClicked
        Try
            gViewName = "BY_TOT"
            ShowInventory(GridView4)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NavBarItem_InvXCliente_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem_InvXCliente.LinkClicked
        Try
            gViewName = "BY_CLIENT"
            ShowInventory(GridView5)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub barBtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnPrint.ItemClick
        Select Case gViewName
            Case "BY_WAREHOUSE"
                GridView2.ExpandAllGroups()
                GridView2.ShowPrintPreview()
            Case "BY_REGIMEN"
                GridView3.ExpandAllGroups()
                GridView3.ShowPrintPreview()
            Case "BY_TOT"
                GridView4.ExpandAllGroups()
                GridView4.ShowPrintPreview()
            Case "BY_CLIENT"
                GridView5.ExpandAllGroups()
                GridView5.ShowPrintPreview()
            Case "BY_PROJECT"
                GridView6.ExpandAllGroups()
                GridView6.ShowPrintPreview()
        End Select
    End Sub

    Private Sub GridView2_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridView2.CustomDrawCell
        If EscolumnaDeColorYElValorEsNumerico(e) Then
            ColocarColorDeCelda(e)
        End If
    End Sub

    Private Sub GridView5_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridView5.CustomDrawCell
        If EscolumnaDeColorYElValorEsNumerico(e) Then
            ColocarColorDeCelda(e)
        End If
    End Sub

    Private Sub GridView4_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridView4.CustomDrawCell
        If EscolumnaDeColorYElValorEsNumerico(e) Then
            ColocarColorDeCelda(e)
        End If
    End Sub

    Private Sub GridView3_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridView3.CustomDrawCell
        If EscolumnaDeColorYElValorEsNumerico(e) Then
            ColocarColorDeCelda(e)
        End If
    End Sub
    Private Shared Function EscolumnaDeColorYElValorEsNumerico(e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) As Boolean
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

    Private Sub NavBarItem_InvXProyecto_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem_InvXProyecto.LinkClicked
        Try
            gViewName = "BY_PROJECT"
            ShowInventory(GridView6)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridView6_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridView6.CustomDrawCell
        If EscolumnaDeColorYElValorEsNumerico(e) Then
            ColocarColorDeCelda(e)
        End If
    End Sub

    Private Sub UiBtnExportarExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBtnExportarExcel.ItemClick
        Select Case gViewName
            Case "BY_PROJECT"
                Dim vista As VistaBaseDeveExpress = New VistaBaseDeveExpress()
                Try
                    GridView6.ExpandAllGroups()
                    vista.ExportarVista(GridView6, True, ExportarA.Excel)
                Catch ex As Exception
                    NotifyStatus(ex.Message, True, True)
                End Try
        End Select
    End Sub
End Class