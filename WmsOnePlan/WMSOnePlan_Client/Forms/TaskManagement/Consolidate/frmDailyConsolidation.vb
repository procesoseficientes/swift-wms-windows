Imports System.Windows.Forms
Imports System.Data

Imports System.IO
Imports System.Drawing.Printing
Imports System.Configuration.ConfigurationManager
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports DevExpress.XtraPrinting


'Private Sub PrintableComponentLink1_CreateReportHeaderArea(ByVal sender As System.Object, ByVal e As CreateAreaEventArgs)
'    Dim reportHeader As String = "Customers Report"
'    '13-Mar-11 J.R. mejoras pantalla consolidacion
'    'reportHeader = lblPedidoID.Text & vbNewLine & "Cliente: " & lblCustInfo.Text & vbNewLine & "Sector/Ruta: " & lblSector.Text
'    reportHeader = lblPedidoID.Text & vbNewLine & "Cliente: " & lblCustInfo.Text & vbNewLine & "Sector/Ruta: " & lblSector.Text & "/" & lblRuta.Text
'    e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Near)
'    e.Graph.Font = New Font("Tahoma", 14, FontStyle.Bold)
'    Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 75)
'    e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None)
'End Sub

'Sub PrintableComponentLink_CreateReportHeader(ByVal sender As System.Object, ByVal e As CreateAreaEventArgs)

'End Sub
'Sub Link_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
'   Dim Brick As PageInfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "", Color.DarkBlue, _
'      New
'RectangleF(0, 0, 100, 20), BorderSide.None)
'    Brick.LineAlignment = BrickAlignment.Center
'    Brick.Alignment = BrickAlignment.Center
'    Brick.AutoWidth = True
'End Sub


Public Class frmDailyConsolidation

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        Dim pResult As String = ""

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            Dim xdata As DataSet = xserv.GetConsolidationByDay(Me.txtFecha.DateTime, Me.lblUsuario.Text, pResult, PublicLoginInfo.Environment)
            'Dim xdata As DataSet = xserv.GetConsolidationByDay(Me.txtFecha.DateTime, "JCUC", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridControl1.DataSource = xdata.Tables(0)
                GridControl1.Refresh()
            Else
                GridControl1.DataSource = Nothing
            End If

            'Me.Label1.Text = "Pedidos Consolidados: " + Format(Me.txtFecha.DateTime, "dd/MMM/yyyy")
            'Me.GridControl1.Text = "Pedidos Consolidados: " + Format(Me.txtFecha.DateTime, "dd/MMM/yyyy")
            Me.GridView1.ViewCaption = "Pedidos Consolidados: " + Format(Me.txtFecha.DateTime, "dd/MMM/yyyy") & "  -  " & "Usuario: " + Me.lblUsuario.Text

            xserv = Nothing
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            pResult = ex.Message
        End Try

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        'Dim xrpt As New rptInvConsolidate
        'Dim rptReport As New rptDailyConsolidation
        'rptReport = Me.GridControl1.DataSource
        'rptReport()
        'GridControl1.Print()

        ' Create a PrintingSystem component.
        Dim ps As New PrintingSystem()
        ' Create a link that will print a control.
        Dim link As New PrintableComponentLink(ps)
        ' Specify the control to be printed.
        link.Component = GridControl1


        ' Configura colores
        'GridView1.Columns.Item(0).AppearanceCell.BackColor = Color.White
        'GridView1.Columns.Item(1).AppearanceCell.BackColor = Color.White
        'GV_DetallePedido.Columns.Item(2).AppearanceCell.BackColor = Color.White
        'GV_DetallePedido.Columns.Item(3).AppearanceCell.BackColor = Color.White
        'GV_DetallePedido.Columns.Item(6).AppearanceCell.BackColor = Color.White

        ' Subscribe to the CreateReportHeaderArea event used to generate the report header.
        ''''AddHandler link.CreateReportHeaderArea, AddressOf PrintableComponentLink1_CreateReportHeaderArea
        ' Generate the report.
        link.CreateDocument()
        ' Show the report.
        link.PrintDlg()
        'link.ShowPreview()



    End Sub

    Private Sub GroupControl1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupControl1.Paint

    End Sub

    Private Sub frmDailyConsolidation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.GridView1.ViewCaption = "Pedidos Consolidados"
        Me.txtFecha.Focus()
    End Sub
End Class
