Imports System.IO
Imports System.Data
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
Imports DevExpress.XtraRichEdit.Commands.Internal
Imports System.Drawing.Drawing2D
Imports MobilityScm.Modelo.Vistas
Imports MobilityScm.Modelo.Tipos
Imports System.ComponentModel

Public Class frmInfo_InvConsolidate

    Private Sub frmInfo_InvConsolidate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strPath As String

        'LayoutControl1.SetDefaultLayout()
        gLastScreenShowed = Me.Name

        'grabamos el layout de la forma 
        strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInfo_InvConsolidateLayout" & PublicLoginInfo.LoginID & ".xml"
        If File.Exists(strPath) Then
            'LayoutControl1.RestoreLayoutFromXml(strPath)
            strPath = String.Empty
        End If

        'grabamos el layout del grid
        strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInfo_InvConsolidateGridView1" & PublicLoginInfo.LoginID & ".xml"
        If File.Exists(strPath) Then
            GridView1.RestoreLayoutFromXml(strPath)
            strPath = String.Empty
        End If
        'grabamos el layout del grid
        strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInfo_InvConsolidateGridView2" & PublicLoginInfo.LoginID & ".xml"
        If File.Exists(strPath) Then
            GridView2.RestoreLayoutFromXml(strPath)
            strPath = String.Empty
        End If

        ShowInventory()
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

    Private Sub SetLayoutData(ByVal Data As String)
        If Data Is Nothing OrElse Data.Length = 0 Then Exit Sub

        Dim s As New IO.MemoryStream()
        Dim w As New IO.StreamWriter(s)
        w.AutoFlush = True

        Dim tmpPos As Integer = InStr(Data, "ActiveFilterString") + 20
        Dim tmpData As String = ""

        tmpData = Mid(Data, tmpPos + 1, Len(Data))
        'tmpData = Replace(tmpData, """", "'")

        Data = Mid(Data, 1, tmpPos) + tmpData

        w.Write(Data)
        s.Position = 0
        Try

            GridView1.RestoreLayoutFromStream(s)
        Catch ex As Exception
            Throw New Exception("Wrong data format", ex)
        End Try
    End Sub


    Sub ShowInventory()
        Dim xDataSet As DataSet
        Dim pResult As String = ""
        Try
            Cursor = Cursors.WaitCursor
            Dim xserv As New OnePlanServices_InfoInventory.WMS_InfoInventorySoapClient("WMS_InfoInventorySoap", PublicLoginInfo.WSHost + "/Info/wms_InfoInventory.asmx")

            xDataSet = xserv.GetInventory_GroupByMaterial(PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                Me.GridControl1.DataSource = xDataSet.Tables(0)
            End If
            LoadGridLayout("INV_CONSOLIDATE", PublicLoginInfo.LoginID)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Timer_Inventory_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Inventory.Tick
        ShowInventory()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SaveGridLayout("INV_CONSOLIDATE", "FRD")
    End Sub
    Public Function ConverStringToStream(ByVal pString As String, ByRef memoryStream As MemoryStream) As Boolean
        Try
            Dim streamWriter As New StreamWriter(memoryStream)
            streamWriter.Write(pString)
            memoryStream.Position = 0
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function ConvertStreamToString(ByVal pStream As Stream) As String
        Dim xreader As New StreamReader(pStream)
        Dim xString = xreader.ReadToEnd()
        Return xString
    End Function
    Sub SaveGridLayout(ByVal pGridViewName As String, ByVal pUserID As String)
        Try 'save the layout
            Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
            Dim pResult As String = "", pLayoutString As String = "", pLayoutAppString As String = ""
            Dim xData As DataSet
            Dim pStream As New MemoryStream
            Dim pStreamApperance As New MemoryStream

            xData = xserv.SearchByKeyGridLayouts(pGridViewName, pUserID, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then 'update

                GridView1.SaveLayoutToStream(pStream, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                pStream.Position = 0

                pLayoutString = ConvertStreamToString(pStream)
                'pLayoutString = Replace(pLayoutString, "'", """")

                GridView1.Appearance.SaveLayoutToStream(pStreamApperance)
                pLayoutAppString = ConvertStreamToString(pStreamApperance)
                'pLayoutAppString = Replace(pLayoutAppString, "'", """")

                xserv.SetGridLayout(pGridViewName, pUserID, pLayoutString, pResult, PublicLoginInfo.Environment)

                If pResult <> "OK" Then
                    MessageBox.Show("ERROR SAVING GRID LAYOUT: " + pResult)
                End If
            Else ' create
                GridView1.SaveLayoutToStream(pStream)
                pStream.Position = 0
                pLayoutString = ConvertStreamToString(pStream)
                pLayoutString = Replace(pLayoutString, "'", """")

                GridView1.Appearance.SaveLayoutToStream(pStreamApperance)
                pLayoutAppString = ConvertStreamToString(pStreamApperance)
                'pLayoutAppString = Replace(pLayoutAppString, "'", """")


                xserv.CreateGridLayouts(pGridViewName, pUserID, pLayoutString, pLayoutAppString, pResult, PublicLoginInfo.Environment)
                If pResult <> "OK" Then
                    MessageBox.Show(pResult)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Timer_Inventory.Enabled = IIf(Me.Timer_Inventory.Enabled, False, True)
        'Me.lblStatusTimer.Text = IIf(Me.Timer_Inventory.Enabled, "Actualzacion automatica", "Actualizacion manual")

    End Sub
    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click
        Try
            If GridView1.FocusedRowHandle >= 0 Then
                Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                If xdatarow IsNot Nothing Then
                    Dim pID As String = xdatarow("MATERIAL_ID").ToString
                    ShowInventoryDetail(pID)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GridControl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Try
            If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                Dim pID As String = xdatarow(0).ToString
                ShowInventoryDetail(pID)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ShowInventoryDetail(ByVal pMaterialID As String)
        Dim pResult As String = ""
        Dim xserv As New OnePlanServices_InfoInventory.WMS_InfoInventorySoapClient("WMS_InfoInventorySoap", PublicLoginInfo.WSHost + "/Info/wms_InfoInventory.asmx")

        Dim xdata As DataSet = xserv.GetInventory_ByMaterial(pMaterialID, pResult, PublicLoginInfo.Environment)
        If pResult = "OK" Then
            Me.GridControl2.DataSource = xdata.Tables(0)
        Else
            Me.GridControl2.DataSource = Nothing
        End If
        Me.GridControl2.Refresh()
        GridView2.ExpandAllGroups()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub barBtnAcualizacion_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnAcualizacion.ItemClick
        Me.Timer_Inventory.Enabled = IIf(Me.Timer_Inventory.Enabled, False, True)
        Me.barBtnAcualizacion.Caption = IIf(Me.Timer_Inventory.Enabled, "Actualzacion Automatica", "Actualizacion Manual")
    End Sub

    Private Sub barBtnSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnSave.ItemClick
        SaveGridLayout("INV_CONSOLIDATE", "FRD")
    End Sub

    Private Sub barBtnPdf_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnPrint.ItemClick
        Try

            If GridView2.RowCount > 0 Then
                Dim link As New PrintableComponentLink(New PrintingSystem())
                link.Component = GridControl2
                AddHandler link.CreateMarginalHeaderArea, AddressOf Link_CreateMarginalHeaderArea
                link.CreateDocument()
                link.ShowPreview()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Link_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)

        Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim texto As String = ""
        texto += "Codigo Producto: " + xdatarow("MATERIAL_ID").ToString()
        texto += Environment.NewLine
        texto += "Descripción del Producto: " + xdatarow("MATERIAL_NAME").ToString()
        texto += Environment.NewLine
        texto += "Inv. Disponible: " + xdatarow("AVAILABLE").ToString()
        texto += " Reservado: " + xdatarow("RESERVED").ToString()
        texto += " Fisico: " + xdatarow("QTY").ToString()


        Dim brick As PageInfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, texto, Color.Black, New RectangleF(0, 0, 100, 60), BorderSide.None)
        brick.LineAlignment = BrickAlignment.Center
        brick.Alignment = BrickAlignment.Center
        brick.AutoWidth = True
    End Sub

    Private Sub MultiFileExportToExcel()

        Using saveDialog = New SaveFileDialog()
            saveDialog.Filter = "Excel (.xlsx)|*.xlsx"
            If saveDialog.ShowDialog() = DialogResult.OK Then
                Dim printingSystem = New PrintingSystemBase()
                Dim compositeLink = New CompositeLinkBase()
                compositeLink.PrintingSystemBase = printingSystem

                Dim link1 = New PrintableComponentLinkBase()
                link1.Component = GridControl1
                Dim link2 = New PrintableComponentLinkBase()
                link2.Component = GridControl2

                compositeLink.Links.Add(link1)
                compositeLink.Links.Add(link2)

                Dim options = New XlsxExportOptions()
                options.ExportMode = XlsxExportMode.SingleFilePageByPage

                compositeLink.CreatePageForEachLink()
                compositeLink.ExportToXlsx(saveDialog.FileName, options)
            End If
        End Using
    End Sub

    Private Function EscolumnaDeColorYElValorEsNumerico(e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) As Boolean
        Return e.CellValue IsNot Nothing AndAlso e.Column.FieldName = "COLOR" AndAlso IsNumeric(e.CellValue.ToString())
    End Function

    Private Sub GridView2_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridView2.CustomDrawCell
        If EscolumnaDeColorYElValorEsNumerico(e) Then
            Dim color As Color = Color.FromArgb(Convert.ToInt32(e.CellValue))
            Dim brush As New LinearGradientBrush(e.Bounds, color, color, LinearGradientMode.ForwardDiagonal)
            e.Graphics.FillRectangle(brush, e.Bounds)
            brush.Dispose()
            e.Graphics.DrawString("", e.Appearance.Font, Brushes.Black, New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
            e.Handled = True
        End If
    End Sub

    Private Sub UiBtnExportarConsolidado_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBtnExportarConsolidado.ItemClick
        Dim vista As VistaBaseDeveExpress = New VistaBaseDeveExpress()
        Try
            vista.ExportarVista(GridView1, True, ExportarA.Excel)
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UiBtnExportarDetalle_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBtnExportarDetalle.ItemClick
        Dim vista As VistaBaseDeveExpress = New VistaBaseDeveExpress()
        Try
            vista.ExportarVista(GridView2, True, ExportarA.Excel)
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub frmInfo_InvConsolidate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim strPath As String
        Try
            gLastScreenShowed = Me.Name

            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInfo_InvConsolidateLayout" & PublicLoginInfo.LoginID & ".xml"

            'LayoutControl1.SaveLayoutToXml(strPath)
            strPath = String.Empty

            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInfo_InvConsolidateGridView1" & PublicLoginInfo.LoginID & ".xml"

            GridView1.SaveLayoutToXml(strPath)
            strPath = String.Empty

            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInfo_InvConsolidateGridView2" & PublicLoginInfo.LoginID & ".xml"

            GridView2.SaveLayoutToXml(strPath)
            strPath = String.Empty

        Catch ex As Exception
            MsgBox("Error al Cerrar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class