Imports System.IO
Imports System.Drawing.Printing
Imports System.Configuration.ConfigurationManager
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports DevExpress.XtraPrinting

Public Class frmMainConsolidate
    '01Jul10 J.R. Para imprmir en la etiqueta al cerrar caja
    Dim strBoxID As String
    Dim strQtyProdsInBox As String
    Dim pLabelSize As String
    '13-Ago-10 J.R. inmediatamente despues de escanear el ultimo producto y llegar al 100% manda a cerrar el pedido e imprimir etiqueta. sin esperar el timer
    Dim blnPreguntaCerrarDoc As Boolean

    '    Dim strOrderID As String

    '06-Sep-10 J.R. imprime documentos, exe de Jonathan
    Dim blnYaImprimio As Boolean

    '09-Sep-10 para que acepte por(*) en consolidacion
    Dim dblQty As Double = 0
    Dim strSku As String = ""

    '31/May/11 J.R. Forzar salir para que los consolidadores solo vean su ventana
    Public bForzarSalir As Boolean

    '...
    Private Sub PrintableComponentLink1_CreateReportHeaderArea(ByVal sender As System.Object, ByVal e As CreateAreaEventArgs)
        Dim reportHeader As String = "Customers Report"
        '13-Mar-11 J.R. mejoras pantalla consolidacion
        'reportHeader = lblPedidoID.Text & vbNewLine & "Cliente: " & lblCustInfo.Text & vbNewLine & "Sector/Ruta: " & lblSector.Text
        reportHeader = lblPedidoID.Text & vbNewLine & "Cliente: " & lblCustInfo.Text & vbNewLine & "Sector/Ruta: " & lblSector.Text & "/" & lblRuta.Text
        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Near)
        e.Graph.Font = New Font("Tahoma", 14, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 75)
        e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None)
    End Sub

    Private Sub PrintableComponentLink2_CreateReportHeaderArea(ByVal sender As System.Object, ByVal e As CreateAreaEventArgs)
        Dim reportHeader As String = "Detalle Caja #: " & Me.lblCaja.Text
        'reportHeader = lblPedidoID.Text & vbNewLine & "Cliente: " & lblCustInfo.Text & vbNewLine & "Sector/Ruta: " & lblSector.Text
        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Near)
        e.Graph.Font = New Font("Tahoma", 12, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50)
        e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None)
    End Sub

    Private Sub PrintShipmentAdvice()

        ' Create a PrintingSystem component.
        Dim ps As New PrintingSystem()
        ' Create a link that will print a control.
        Dim link As New PrintableComponentLink(ps)
        ' Specify the control to be printed.
        link.Component = GC_DetallePedido

        ' Configura colores
        GV_DetallePedido.Columns.Item(0).AppearanceCell.BackColor = Color.White
        GV_DetallePedido.Columns.Item(1).AppearanceCell.BackColor = Color.White
        GV_DetallePedido.Columns.Item(2).AppearanceCell.BackColor = Color.White
        GV_DetallePedido.Columns.Item(3).AppearanceCell.BackColor = Color.White
        GV_DetallePedido.Columns.Item(6).AppearanceCell.BackColor = Color.White

        ' Subscribe to the CreateReportHeaderArea event used to generate the report header.
        AddHandler link.CreateReportHeaderArea, AddressOf PrintableComponentLink1_CreateReportHeaderArea
        ' Generate the report.
        link.CreateDocument()
        ' Show the report.
        link.ShowPreview()

        ' Remove comments below to export the report to a PDF file
        ' link.PrintingSystem.ExportToPdf("c:\gridcontrol.pdf")

    End Sub

    Private Sub PrintBoxDetail(ByVal pBoxID As String)

        Dim intShell As Integer
        If Not blnYaImprimio Then
            Dim servSettings As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
            Dim dsRuta As DataSet
            Dim pResult As String = ""
            Dim strFileName As String

            Try

                dsRuta = servSettings.GetParam_ByParamKey("SISTEMA", "RUTAS_ARCHIVOS", "IMPRESION_DETALLE_CAJA", pResult, PublicLoginInfo.Environment)
                If pResult = "OK" Then
                    strFileName = dsRuta.Tables(0).Rows(0)("TEXT_VALUE").ToString
                Else
                    strFileName = "C:\IMPRESIONDETALLE"
                End If

                intShell = Shell(strFileName + " " & pBoxID, AppWinStyle.Hide)
                blnYaImprimio = True

            Catch ex As Exception
                MessageBox.Show("No existe la ruta necesaria para la impresion del detale de la caja, revise Parametros del Sistema." & vbNewLine & ex.Message)
            End Try

        End If

        '06-Sep-10 J.R. antes se llamaba un preview
        'If pBoxID <> "" Then
        '    ' Create a PrintingSystem component.
        '    Dim ps As New PrintingSystem()
        '    ' Create a link that will print a control.
        '    Dim link As New PrintableComponentLink(ps)
        '    ' Specify the control to be printed.
        '    link.Component = GC_Boxes

        '    GV_Boxes.OptionsPrint.ExpandAllDetails = True
        '    GV_Boxes.OptionsPrint.PrintDetails = True
        '    GV_Boxes.ActiveFilterString = "BOX_ID = '" + pBoxID + "'"
        '    'GV_Boxes.Columns("LINE_ID").Visible = False
        '    'GV_Boxes.Columns("BOX_ID").Visible = False
        '    'GV_Boxes.OptionsPrint.PrintHeader = False

        '    ' Subscribe to the CreateReportHeaderArea event used to generate the report header.
        '    AddHandler link.CreateReportHeaderArea, AddressOf PrintableComponentLink2_CreateReportHeaderArea
        '    ' Generate the report.
        '    link.CreateDocument()
        '    ' Show the report.
        '    link.ShowPreview()

        '    GV_Boxes.ClearColumnsFilter()

        '    ' Remove comments below to export the report to a PDF file
        '    ' link.PrintingSystem.ExportToPdf("c:\gridcontrol.pdf")
        'End If

    End Sub

    Private Sub SimpleButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmMainConsolidate_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        gLastScreenShowed = "frmMainConsolidate"
    End Sub

    Private Sub frmMainConsolidate_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        gLastScreenShowed = "frmMainConsolidate"
        LogOut()
        If bForzarSalir Then End
    End Sub

    Private Sub frmMainConsolidate_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        gLastScreenShowed = "frmMainConsolidate"
        LogOut()
        If bForzarSalir Then End
    End Sub
    Sub LogOut()
        Dim pResult As String = ""
        Try
            Dim pUri As String = AppSettings("WSHOST").ToString + "/Catalogues/WMS_Security.asmx"
            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", pUri)
            xserv.RegisterLogIn(PublicLoginInfo.LoginID, "CHECK_OUT", pResult, PublicLoginInfo.Environment)
            SaveSetting("ONE_PLAN", "USER_CONFIG", "LAST_SCREEN", gLastScreenShowed)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub frmMainConsolidate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        '05Jun10 J.R. Para hacer funcionar las F's
        If e.KeyCode = Keys.F9 Then 'Cerrar Pedido
            btnCloseDoc_Click(sender, e)
        ElseIf e.KeyCode = Keys.F8 Then 'Cerrar Caja
            '30-Jun-11 J.R. ya no se cierra caja de esta forma
            'btnCloseBox_Click(sender, e)
        ElseIf e.KeyCode = Keys.F4 Then 'Diferencias 08-Sep-10 J.R. no muestra diferencias sino que trae el sig.pedido porque se deshabilito el timer
            btnDiffs_Click(sender, e)
        ElseIf e.KeyCode = Keys.F3 Then 'Salir
            SimpleButton4_Click(sender, e)
        ElseIf e.KeyCode = Keys.F10 Then 'Ultima Etiqueta
            btnPrintLastLabel_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Then 'Ultima Factura
            btnPrintLastInvoice_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then 'Reporte Consolidacion por Dia
            btnDailyReport_Click(sender, e)
        End If

    End Sub

    Private Sub frmMainConsolidate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RefreshCurrentDocInDispatch()
        ShowCurrentBinsInDispatch()
        ShowCurrentTransInDispatch()
        Dim pResult As String = ""
        '04-Nov-10 Par que funcione con multiples lineas
        'Call ShowBoxesCurrentDoc("LINEA_2", "")
        Call ShowBoxesCurrentDoc(Me.cmbLines.EditValue.ToString, "")
        PublicLoginInfo.Linea = GetUserLine(pResult)

    End Sub
    Sub ShowCurrentBinsInDispatch()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Bins.WMS_BinsSoapClient("WMS_BinsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Bins.asmx")
            '04-Nov-10 Par que funcione con multiples lineas
            'Dim xdata As DataSet = xserv.GetBinInventoryByDocInDispatch("LINEA_2", PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)
            Dim xdata As DataSet = xserv.GetBinInventoryByDocInDispatch(Me.cmbLines.EditValue.ToString, PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                GridControl_Bins.DataSource = xdata.Tables(0)
            Else
                GridControl_Bins.DataSource = Nothing
                Me.lblStatus.Image = My.Resources.ico_error
                Me.lblStatus.Text = pResult
                Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas
                Me.StatusStrip1.Refresh()
            End If

        Catch ex As Exception
            Me.lblStatus.Image = My.Resources.ico_error
            Me.lblStatus.Text = ex.Message
            Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas
            'Me.StatusStrip1.Refresh()

        End Try

    End Sub

    Sub RefreshCurrentDocInDispatch()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")

            '04-Nov-10 Par que funcione con multiples lineas
            'Dim xdata As DataSet = xserv.GetCurrentDocOnDispatchInfo("LINEA_2", PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)
            Dim xdata As DataSet = xserv.GetCurrentDocOnDispatchInfo(Me.cmbLines.EditValue.ToString, PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)

            If pResult = "OK" Then

                Me.GC_DetallePedido.DataSource = xdata.Tables(0)
                Me.lblStatus.Text = "Pedido en curso: " + xdata.Tables(0).Rows(0)("ERP_DOCUMENT")
                Me.lblStatus.Image = My.Resources.check
                Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas
                Me.StatusStrip1.Refresh()
                Me.lblPedidoID.Text = "Pedido: " + xdata.Tables(0).Rows(0)("ERP_DOCUMENT")
                Me.lblPedidoID.Tag = xdata.Tables(0).Rows(0)("ERP_DOCUMENT")

                Me.lblCustInfo.Text = xdata.Tables(0).Rows(0)("CLIENT_ID") + " / " + xdata.Tables(0).Rows(0)("CLIENT_NAME")
                Me.lblCustInfo.Tag = xdata.Tables(0).Rows(0)("CLIENT_ID")

                '13-Mar-11 J.R. mejoras pantalla consolidacion
                'Me.lblSector.Text = xdata.Tables(0).Rows(0)("CLIENT_REGION") + " / " + xdata.Tables(0).Rows(0)("CLIENT_ROUTE")
                Me.lblSector.Text = xdata.Tables(0).Rows(0)("CLIENT_REGION")
                Me.lblRuta.Text = xdata.Tables(0).Rows(0)("CLIENT_ROUTE")

                '01Jul10 J.R. para mostrar el #de caja
                Me.lblCaja.Text = xdata.Tables(0).Rows(0)("BOX_ID")
                Me.lblCaja.Tag = xdata.Tables(0).Rows(0)("QTY_PRODUCTS_IN_BOX")
                Me.lblCustAddress.Text = xdata.Tables(0).Rows(0)("CLIENT_ADDRESS")

                Me.lblTimerStatus.Text = "Ultima actualizacion: " + Now.ToString

                Me.txtScanLine.Enabled = True

                Me.txtScanLine.Focus()

                GC_DetallePedido.Refresh()
                xserv = Nothing

                '09-Sep-10
                ShowPercDocInDispatch()
                '09-Sep-10

                '04-Nov-10 Par que funcione con multiples lineas
                'ShowBoxesCurrentDoc("LINEA_2", pResult)
                ShowBoxesCurrentDoc(Me.cmbLines.EditValue.ToString, pResult)

                '09-Sep-10
                ShowCurrentTransInDispatch()
                '15-Ago-2010 J.R. para quitar un Qry menos
                'ShowCurrentBinsInDispatch()

            Else
                lblCustInfo.Text = "000-..."
                Me.lblCustAddress.Text = ""
                Me.lblStatus.Image = My.Resources.ico_error
                Me.lblStatus.Text = pResult
                Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas
                Me.StatusStrip1.Refresh()
                GC_DetallePedido.DataSource = Nothing
                Me.lblPorcentajeCuadre.Text = "0%"
                Me.lblPorcentajeCuadre.Tag = 0
                Me.lblPedidoID.Text = "Pedido: (Ninguno)"
                Me.txtScanLine.Enabled = False
            End If


        Catch ex As Exception

            Me.lblStatus.Image = My.Resources.ico_error
            Me.lblStatus.Text = ex.Message
            Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas
            Me.StatusStrip1.Refresh()

        End Try

    End Sub

    Sub ShowCurrentDocInDispatch()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")

            '04-Nov-10 Par que funcione con multiples lineas
            'Dim xdata As DataSet = xserv.GetCurrentDocOnDispatchInfo("LINEA_2", PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)
            Dim xdata As DataSet = xserv.GetCurrentDocOnDispatchInfo(Me.cmbLines.EditValue.ToString, PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)

            If pResult = "OK" Then
                
                Me.GC_DetallePedido.DataSource = xdata.Tables(0)
                Me.lblStatus.Text = "Pedido en curso: " + xdata.Tables(0).Rows(0)("ERP_DOCUMENT")
                Me.lblStatus.Image = My.Resources.check
                Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas
                Me.StatusStrip1.Refresh()
                Me.lblPedidoID.Text = "Pedido: " + xdata.Tables(0).Rows(0)("ERP_DOCUMENT")
                Me.lblPedidoID.Tag = xdata.Tables(0).Rows(0)("ERP_DOCUMENT")

                PrintDocs(Me.lblPedidoID.Tag)


                Me.lblCustInfo.Text = xdata.Tables(0).Rows(0)("CLIENT_ID") + " / " + xdata.Tables(0).Rows(0)("CLIENT_NAME")
                Me.lblCustInfo.Tag = xdata.Tables(0).Rows(0)("CLIENT_ID")

                '13-Mar-11 J.R. mejoras pantalla consolidacion
                'Me.lblSector.Text = xdata.Tables(0).Rows(0)("CLIENT_REGION") + " / " + xdata.Tables(0).Rows(0)("CLIENT_ROUTE")
                Me.lblSector.Text = xdata.Tables(0).Rows(0)("CLIENT_REGION")
                Me.lblRuta.Text = xdata.Tables(0).Rows(0)("CLIENT_ROUTE")

                '01Jul10 J.R. para mostrar el #de caja
                Me.lblCaja.Text = xdata.Tables(0).Rows(0)("BOX_ID")
                Me.lblCaja.Tag = xdata.Tables(0).Rows(0)("QTY_PRODUCTS_IN_BOX")
                Me.lblCustAddress.Text = xdata.Tables(0).Rows(0)("CLIENT_ADDRESS")

                Me.lblTimerStatus.Text = "Ultima actualizacion: " + Now.ToString

                Me.txtScanLine.Enabled = True

                Me.txtScanLine.Focus()

                GC_DetallePedido.Refresh()
                xserv = Nothing

                '09-Sep-10
                ShowPercDocInDispatch()
                '09-Sep-10

                '04-Nov-10 Par que funcione con multiples lineas
                'ShowBoxesCurrentDoc("LINEA_2", pResult)
                ShowBoxesCurrentDoc(Me.cmbLines.EditValue.ToString, pResult)

                '09-Sep-10
                ShowCurrentTransInDispatch()
                '15-Ago-2010 J.R. para quitar un Qry menos
                'ShowCurrentBinsInDispatch()

            Else
                lblCustInfo.Text = "000-..."
                Me.lblCustAddress.Text = ""
                Me.lblStatus.Image = My.Resources.ico_error
                Me.lblStatus.Text = pResult
                Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas
                Me.StatusStrip1.Refresh()
                GC_DetallePedido.DataSource = Nothing
                Me.lblPorcentajeCuadre.Text = "0%"
                Me.lblPorcentajeCuadre.Tag = 0
                Me.lblPedidoID.Text = "Pedido: (Ninguno)"
                Me.txtScanLine.Enabled = False
            End If


        Catch ex As Exception

            Me.lblStatus.Image = My.Resources.ico_error
            Me.lblStatus.Text = ex.Message
            Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas
            Me.StatusStrip1.Refresh()

        End Try

    End Sub

    Sub ShowPercDocInDispatch()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            '04-Nov-10 Par que funcione con multiples lineas
            'Dim pPerc As Double = xserv.GetPerc_DocOnDispatch("LINEA_2", PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)
            Dim pPerc As Double = xserv.GetPerc_DocOnDispatch(Me.cmbLines.EditValue.ToString, PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)

            If pResult = "OK" Then
                Me.lblPorcentajeCuadre.Text = Format(pPerc, "#.00") + "% Cuadrado"
                Me.lblPorcentajeCuadre.Tag = pPerc
                Me.lblPorcentajeCuadre.Refresh()

                GC_DetallePedido.Refresh()
                xserv = Nothing
            Else
                Me.lblPorcentajeCuadre.Text = "0% Cuadrado"
                Me.lblPorcentajeCuadre.Refresh()
            End If
            If pPerc >= 0 And pPerc <= 49 Then
                Me.lblPorcentajeCuadre.ForeColor = Color.Red
                Me.lblPorcentajeCuadre.BackColor = Color.Black
            Else
                If pPerc >= 50 And pPerc <= 90 Then
                    Me.lblPorcentajeCuadre.ForeColor = Color.Yellow
                    Me.lblPorcentajeCuadre.BackColor = Color.Black
                Else
                    If pPerc >= 91 And pPerc <= 98 Then
                        Me.lblPorcentajeCuadre.ForeColor = Color.Blue
                        Me.lblPorcentajeCuadre.BackColor = Color.White
                    Else
                        If pPerc = 100 Then
                            Me.lblPorcentajeCuadre.ForeColor = Color.Green
                            Me.lblPorcentajeCuadre.BackColor = Color.White
                            Me.lblStatus.Image = My.Resources.check
                            Me.lblStatus.Text = "Cuadre finalizado"
                            Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas

                            Me.StatusStrip1.Refresh()
                        End If
                    End If
                End If
            End If


        Catch ex As Exception

            Me.lblStatus.Image = My.Resources.ico_error
            Me.lblStatus.Text = ex.Message
            Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas
            Me.StatusStrip1.Refresh()

        End Try

    End Sub

    Sub ShowCurrentTransInDispatch()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            '04-Nov-10 Par que funcione con multiples lineas
            'Dim xdata As DataTable = xserv.GetTransDet_DocOnDispatch("LINEA_2", PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)
            Dim xdata As DataTable = xserv.GetTransDet_DocOnDispatch(Me.cmbLines.EditValue.ToString, PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)

            If pResult = "OK" Then
                If xdata.Rows.Count >= 1 Then
                    GC_ScannedDetail.DataSource = xdata
                Else  '04-Nov-10 Par que funcione con multiples lineas, no habia Else
                    GC_ScannedDetail.DataSource = Nothing
                End If
            Else
                GC_ScannedDetail.DataSource = Nothing
                Me.lblStatus.Image = My.Resources.ico_error
                Me.lblStatus.Text = pResult
                Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas
                Me.StatusStrip1.Refresh()
            End If
        Catch ex As Exception
            Me.lblStatus.Image = My.Resources.ico_error
            Me.lblStatus.Text = ex.Message
            Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas
        End Try

    End Sub

    Function CheckScanned(ByRef pResult As String) As Boolean
        Try
            Dim strScanLine() As String

            If InStr(Me.txtScanLine.Text.Trim.ToUpper, "*", CompareMethod.Text) Then
                strScanLine = txtScanLine.Text.ToUpper.Split("*")
                strSku = strScanLine(1)
                dblQty = CDbl("0" & strScanLine(0))
            Else
                strSku = Me.txtScanLine.Text
                dblQty = 1
            End If
            '09-Sep-10 J.R. para que acepte Por(*)

            If dblQty > 0 Then
                Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
                '09-Sep-10 J.R. para que acepte Por(x)
                'Dim pAllow As Double = xserv.AllowMaterialScann_DocOnDispatch("LINEA_2", Me.txtScanLine.Text, 1, PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)
                '04-Nov-10 Par que funcione con multiples lineas
                'Dim pAllow As Double = xserv.AllowMaterialScann_DocOnDispatch("LINEA_2", strSku, dblQty, PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)
                Dim pAllow As Double = xserv.AllowMaterialScann_DocOnDispatch(Me.cmbLines.EditValue.ToString, strSku, dblQty, PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)

                If pAllow = 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                pResult = "Cantidad ingresada es incorrecta"
                Return False
            End If
            Return True
        Catch ex As Exception
            pResult = ex.Message
        End Try
    End Function

    Private Sub GC_DetallePedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GC_DetallePedido.Click

    End Sub

    Private Sub GV_Bins_MasterRowExpanded(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles GV_Bins.MasterRowExpanded
        Dim detailView As DevExpress.XtraGrid.Views.Grid.GridView

        Try
            detailView = GV_Bins.GetDetailView(e.RowHandle, e.RelationIndex)

            detailView.Columns(0).OptionsColumn.ReadOnly = True
            detailView.Columns(0).Visible = False

            detailView.Columns(1).OptionsColumn.ReadOnly = True
            detailView.Columns(1).OptionsColumn.AllowFocus = False
            detailView.Columns(1).OptionsColumn.AllowEdit = False
            detailView.Columns(1).Width = 50

            detailView.Columns(2).OptionsColumn.ReadOnly = True
            detailView.Columns(2).OptionsColumn.AllowFocus = False
            detailView.Columns(2).OptionsColumn.AllowEdit = False
            detailView.Columns(2).Width = 180

            detailView.Columns(3).OptionsColumn.ReadOnly = True
            detailView.Columns(3).OptionsColumn.AllowFocus = False
            detailView.Columns(3).OptionsColumn.AllowEdit = False
            detailView.Columns(3).Width = 50

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub txtScanLine_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScanLine.GotFocus

    End Sub

    Private Sub txtScanLine_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtScanLine.KeyPress
        Dim pResult As String = ""
        If e.KeyChar = ChrW(Keys.Enter) Then
            If CheckScanned(pResult) Then
                If SaveTrans(pResult) Then

                    RefreshCurrentDocInDispatch()

                    '09-Sep-10
                    'Call ShowBoxesCurrentDoc("LINEA_2", pResult)
                    Me.txtScanLine.Text = ""
                    Me.txtScanLine.Focus()

                    Try
                        '22-Oct-2010 J.R. Para mejorar tiempo de Consolidadores se comentario
                        'PrintDocuments()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try

                    '13-Ago-10 J.R. inmediatamente despues de escanear el ultimo producto y llegar al 100% manda a cerrar el pedido e imprimir etiqueta. sin esperar el timer
                    If lblPorcentajeCuadre.Tag >= 100 Then
                        blnPreguntaCerrarDoc = False
                        btnCloseDoc_Click(sender, e)
                        blnPreguntaCerrarDoc = True
                    End If

                End If
            Else
                Try
                    My.Computer.Audio.Play("error_sound.wav", AudioPlayMode.WaitToComplete)
                Catch ex As Exception
                    Me.lblStatus.Text = pResult
                    Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas
                    Me.StatusStrip1.Refresh()
                End Try

                MessageBox.Show("PRODUCTO NO ESTA EN LA LISTA DE PICKING O LA CANTIDAD INGRESADA ES INCORRECTA", "OnePlan WMS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                RefreshCurrentDocInDispatch()

                Me.txtScanLine.Text = ""
                Me.lblStatus.Image = My.Resources.ico_error
                Me.lblStatus.Text = pResult
                Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas
                Me.StatusStrip1.Refresh()
            End If
        End If
    End Sub

    Private Sub txtScanLine_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtScanLine.KeyUp
        If e.KeyCode = Keys.F5 Then
            'ShowCurrentDocInDispatch()
            RefreshCurrentDocInDispatch()
        Else
            If e.KeyCode = Keys.F9 Then
                btnCloseDoc_Click(sender, e)
            Else
                If e.KeyCode = Keys.F7 Then
                    RefreshCurrentDocInDispatch()
                Else
                    If e.KeyCode = Keys.F3 Then
                        If MessageBox.Show("Desea Salir?", "OnePlan WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) = Windows.Forms.DialogResult.Yes Then
                            Me.Close()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Timer_Bins_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer_Bins.Tick
        Me.lblTimerStatus.Text = "Buscando BINS pendientes por consolidar..."
        ShowCurrentDocInDispatch()
        '05-Ago-10 J.R. si llega al 100% automaticamente manda a cerrar pedido
        If lblPorcentajeCuadre.Tag >= 100 Then
            btnCloseDoc_Click(sender, e)
        End If

        Me.lblTimerStatus.Text = "Ultima busqueda de bins " + Now.ToString
    End Sub
    Public Function SaveTrans(ByRef pResult As String) As Boolean
        Try

            Dim xserv As New OnePlanServices_Consolidation.WMS_ConsolidationSoapClient("WMS_ConsolidationSoap", PublicLoginInfo.WSHost + "/trans/WMS_Consolidation.asmx")

            '09-Sep-10 J.R. para que acepte Por(*)
            'If xserv.RegisterConsolidate(Me.lblPedidoID.Tag, lblCustInfo.Tag, "PICKING", Me.txtScanLine.Text, 1, PublicLoginInfo.LoginID, "LINEA_2", PublicLoginInfo.Environment, pResult) Then
            '04-Nov-10 Par que funcione con multiples lineas
            'If xserv.RegisterConsolidate(Me.lblPedidoID.Tag, lblCustInfo.Tag, "PICKING", strSku, dblQty, PublicLoginInfo.LoginID, "LINEA_2", PublicLoginInfo.Environment, pResult) Then
            If xserv.RegisterConsolidate(Me.lblPedidoID.Tag, lblCustInfo.Tag, "PICKING", strSku, dblQty, PublicLoginInfo.LoginID, Me.cmbLines.EditValue.ToString, PublicLoginInfo.Environment, pResult) Then
                strSku = ""
                dblQty = 0
                Return True
            Else
                strSku = ""
                dblQty = 0
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

    End Function

    Public Function ShowBoxesCurrentDoc(ByVal pLine As String, ByRef pResult As String) As Boolean
        Try
            Dim pData As New DataSet
            Dim xserv As New OnePlanServices_Consolidation.WMS_ConsolidationSoapClient("WMS_ConsolidationSoap", PublicLoginInfo.WSHost + "/trans/WMS_Consolidation.asmx")

            pData = xserv.GetBoxes_CurrentDispatchDoc(pLine, PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                btnCloseBox.Tag = pData.Tables(0).Rows(0)("BOX_ID")
                btnCloseBox.ToolTip = "Caja Actual: " + pData.Tables(0).Rows(0)("BOX_ID")
                Me.GC_Boxes.DataSource = pData.Tables(0)
                Me.GV_Boxes.ExpandAllGroups()
            Else
                Me.GC_Boxes.DataSource = Nothing
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

    End Function

    Private Sub GridControl_Bins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl_Bins.Click

    End Sub

    Private Sub GC_Boxes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GC_Boxes.Click
    End Sub

    Private Sub GV_Boxes_MasterRowExpanded(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles GV_Boxes.MasterRowExpanded
        Dim detailView As DevExpress.XtraGrid.Views.Grid.GridView

        Try
            detailView = GV_Boxes.GetDetailView(e.RowHandle, e.RelationIndex)

            detailView.Columns(0).OptionsColumn.ReadOnly = True 'linea
            detailView.Columns(0).Visible = False

            detailView.Columns(1).OptionsColumn.ReadOnly = True 'caja
            detailView.Columns(1).Visible = False

            detailView.Columns(2).OptionsColumn.ReadOnly = True 'codigo
            detailView.Columns(2).OptionsColumn.AllowFocus = False
            detailView.Columns(2).OptionsColumn.AllowEdit = False
            detailView.Columns(2).Caption = "Codigo"
            detailView.Columns(2).Width = 50

            detailView.Columns(3).OptionsColumn.ReadOnly = True 'descripcion
            detailView.Columns(3).OptionsColumn.AllowFocus = False
            detailView.Columns(3).OptionsColumn.AllowEdit = False
            detailView.Columns(3).Caption = "Nombre"
            detailView.Columns(3).Width = 130

            detailView.Columns(4).OptionsColumn.ReadOnly = True 'cantidad
            detailView.Columns(4).OptionsColumn.AllowFocus = False
            detailView.Columns(4).OptionsColumn.AllowEdit = False
            detailView.Columns(4).Width = 50

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
        Dim pResult As String = ""

        '01Jul10 J.R. Para imprmir en la etiqueta al cerrar caja
        strBoxID = Me.lblCaja.Text
        strQtyProdsInBox = Me.lblCaja.Tag

        Try

            '08-Sep-10 J.R. deshabilitar timer para evitar demasiadas llamadas al server
            'Me.Timer_Bins.Enabled = False

            'PrintLabels()
            If CloseCurrentBox(pResult) Then
                PrintLabels()
                MessageBox.Show("Caja cerrada")
                '04-Nov-10 Par que funcione con multiples lineas
                'ShowBoxesCurrentDoc("LINEA_2", pResult)
                ShowBoxesCurrentDoc(Me.cmbLines.EditValue.ToString, pResult)
            Else
                Me.lblStatus.Image = My.Resources.ico_error
                Me.lblStatus.Text = pResult
                Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas
            End If

            '08-Sep-10 J.R. deshabilitar timer para evitar demasiadas llamadas al server
            'Me.Timer_Bins.Enabled = True

        Catch ex As Exception
            MessageBox.Show(pResult)
        End Try
    End Sub
    Public Function CloseCurrentBox(ByRef pResult As String) As Boolean
        Try
            Dim xserv As New OnePlanServices_Consolidation.WMS_ConsolidationSoapClient("WMS_ConsolidationSoap", PublicLoginInfo.WSHost + "/trans/WMS_Consolidation.asmx")
            '04-Nov-10 Par que funcione con multiples lineas
            'If xserv.CloseCurrentBox_DocOnDispatch("LINEA_2", PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult) Then
            If xserv.CloseCurrentBox_DocOnDispatch(Me.cmbLines.EditValue.ToString, PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult) Then
                pResult = "OK"
                '08-Sep-10 A solicitud de Alvaro, se desactivo puesto que lo encuentra innecesario en vista de que ya se imprime la nota de envio y alli va el contenido total del pedido
                'PrintBoxDetail(strBoxID)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

    '30Jun11 J.R. Ahora recibe numero de etiquetas y hace un ciclo que va imprimiendolas, no se graba detalle de prod x caja, ademas se cambio a funcion
    '30Jun10 J.R. Impresion de Etiquetas en cierre de Caja y pedido al consolidar
    'Sub PrintLabels(Optional ByVal pBoxID As String = "", Optional ByVal pNumeroEtiquetas As Integer = 0)
    Function PrintLabels(Optional ByVal pBoxID As String = "", Optional ByVal pNumeroEtiquetas As Integer = 0) As Boolean

        Dim j As Integer = 0
        Try

            Dim pd As New PrintDialog()

            '01/Oct/10 J.R. Obtiene # copias segun parametro
            Dim nCopias As Integer
            Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
            Dim xds As New DataSet
            Dim pResult As String = ""


            Dim strRegion As String = ""
            Dim strRoute As String = ""
            Dim strClientId As String = ""
            Dim strAddress1 As String = ""
            Dim strAddress2 As String = ""
            Dim strAddress3 As String = ""
            Dim strBoxNumber As String = ""

            '03-Jul-11 J.R. el numero de cajas se graba en una tabla aparte
            Dim intNumCajasPedido As Integer = 0

            xds = xserv.GetParam_ByParamKey("SISTEMA", "GENERAL", "COPIAS_CIERRE_CAJA", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                nCopias = xds.Tables(0).Rows(0)("NUMERIC_VALUE")
            Else
                nCopias = 1
            End If

            pd.PrinterSettings = New PrinterSettings()
            pd.PrinterSettings.Copies = nCopias

            '14-Mar-11 J.R. Para reimpresion de etiqueta
            If pBoxID = "" Then

                If (pd.ShowDialog() = DialogResult.OK) Then

                    '01/Oct/10 J.R. para mejorar performance se envia el # copias a PrintGroupLabel
                    'For j = 1 To pd.PrinterSettings.Copies

                    '13-Mar-11 J.R. mejoras pantalla consolidacion
                    'Dim strRegion As String = Mid(Me.lblSector.Text, 1, InStr(Me.lblSector.Text, "/", CompareMethod.Text) - 2)
                    'Dim strRoute As String = Mid(Me.lblSector.Text, InStr(Me.lblSector.Text, "/", CompareMethod.Text) + 2)
                    strRegion = Me.lblSector.Text
                    strRoute = Me.lblRuta.Text
                    strClientId = Mid(Me.lblCustInfo.Text, InStr(Me.lblCustInfo.Text, "/", CompareMethod.Text) + 2)
                    strAddress1 = Mid(Me.lblCustAddress.Text, 1, 35) '35 chars para que quepa en la etiqueta
                    strAddress2 = Mid(Me.lblCustAddress.Text, 36, 35) '35 chars para que quepa en la etiqueta
                    strAddress3 = Mid(Me.lblCustAddress.Text, 71, 35) '35 chars para que quepa en la etiqueta

                    '30Jun11 J.R. Ahora recibe numero de etiquetas y hace un ciclo que va imprimiendolas, no se graba detalle de prod x caja
                    If pNumeroEtiquetas > 0 Then

                        For i = 1 To pNumeroEtiquetas  '30Jun11 J.R. Ahora recibe numero de etiquetas y hace un ciclo que va imprimiendolas, no se graba detalle de prod x caja

                            '01-Dic-10 J.R. Para imprimir el numero de caja en grande
                            'strBoxNumber = Mid(strBoxID, InStr(strBoxID, "-", CompareMethod.Text))
                            '30Jun11 J.R. Ahora recibe numero de etiquetas y hace un ciclo que va imprimiendolas, no se graba detalle de prod x caja
                            strBoxNumber = i

                            '01-Mar-11 J.R. se agrego un replace para quitar el guion que lleva el #caja
                            '06-Jul-10 J.R. Falta corregir Date
                            'PrintGroupLabel(strBoxID, lblCustInfo.Tag, strClientId, strRoute, strRegion, strQtyProdsInBox, lblPedidoID.Tag, strAddress1, strAddress2, strAddress3, Format(Now, "dd/MMM/yyyy hh:mmtt"), "Usuario: " + PublicLoginInfo.LoginID, Replace(strBoxNumber, "-", ""), pd.PrinterSettings.PrinterName, pd.PrinterSettings.Copies)
                            '30Jun11 J.R. Ahora recibe numero de etiquetas y hace un ciclo que va imprimiendolas, no se graba detalle de prod x caja
                            PrintGroupLabel(Me.lblPedidoID.Tag + "-" + strBoxNumber, lblCustInfo.Tag, strClientId, strRoute, strRegion, 0, lblPedidoID.Tag, strAddress1, strAddress2, strAddress3, Format(Now, "dd/MMM/yyyy hh:mmtt"), "" + PublicLoginInfo.LoginID, strBoxNumber + "/" + pNumeroEtiquetas.ToString, pd.PrinterSettings.PrinterName, pd.PrinterSettings.Copies, pResult)
                            If pResult <> "OK" Then
                                MessageBox.Show(pResult, "WMS OnePlan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Function
                            End If

                        Next '30Jun11 J.R. Ahora recibe numero de etiquetas y hace un ciclo que va imprimiendolas, no se graba detalle de prod x caja

                    End If  '30Jun11 J.R. Ahora recibe numero de etiquetas y hace un ciclo que va imprimiendolas, no se graba detalle de prod x caja

                    'Next

                    Return True '30-Jun-11 J.R.

                Else
                    Return False '30-Jun-11 J.R.
                End If

            Else
                '14-Mar-11 J.R. Para reimpresion de etiqueta
                Dim xservBox As New OnePlanServices_Consolidation.WMS_ConsolidationSoapClient("WMS_ConsolidationSoap", PublicLoginInfo.WSHost + "/trans/WMS_Consolidation.asmx")
                Dim xdsBox As New DataSet

                Dim strNumPedido As String = ""
                Dim split1() As String = pBoxID.Split("|")
                strNumPedido = split1(0).ToString.Trim

                '03-Jul-11 J.R.
                'xdsBox = xservBox.GetInfoFromBox(pBoxID, pResult, PublicLoginInfo.Environment)
                xdsBox = xservBox.GetInfoFromBox(strNumPedido, pResult, PublicLoginInfo.Environment)
                If pResult = "OK" Then

                    strRegion = IIf(IsDBNull(xdsBox.Tables(0).Rows(0)("CLIENT_REGION")), "", xdsBox.Tables(0).Rows(0)("CLIENT_REGION"))
                    strRoute = IIf(IsDBNull(xdsBox.Tables(0).Rows(0)("CLIENT_ROUTE")), "", xdsBox.Tables(0).Rows(0)("CLIENT_ROUTE"))
                    strClientId = IIf(IsDBNull(xdsBox.Tables(0).Rows(0)("CLIENT_NAME")), "", xdsBox.Tables(0).Rows(0)("CLIENT_NAME"))
                    strAddress1 = Mid(IIf(IsDBNull(xdsBox.Tables(0).Rows(0)("CLIENT_ADDRESS")), "", xdsBox.Tables(0).Rows(0)("CLIENT_ADDRESS")), 1, 35) '35 chars para que quepa en la etiqueta
                    strAddress2 = Mid(IIf(IsDBNull(xdsBox.Tables(0).Rows(0)("CLIENT_ADDRESS")), "", xdsBox.Tables(0).Rows(0)("CLIENT_ADDRESS")), 36, 35) '35 chars para que quepa en la etiqueta
                    strAddress3 = Mid(IIf(IsDBNull(xdsBox.Tables(0).Rows(0)("CLIENT_ADDRESS")), "", xdsBox.Tables(0).Rows(0)("CLIENT_ADDRESS")), 71, 35) '35 chars para que quepa en la etiqueta
                    '03-Jul-11 J.R.
                    intNumCajasPedido = xdsBox.Tables(0).Rows(0)("NUMCAJAS")
                    '03-Jul-11 J.R.
                    'Dim strCodigoCliente As String = IIf(IsDBNull(xdsBox.Tables(0).Rows(0)("CLIENT_OWNER")), "", xdsBox.Tables(0).Rows(0)("CLIENT_OWNER"))
                    Dim strCodigoCliente As String = IIf(IsDBNull(xdsBox.Tables(0).Rows(0)("CLIENT_ID")), "", xdsBox.Tables(0).Rows(0)("CLIENT_ID"))
                    Dim strPedido As String = IIf(IsDBNull(xdsBox.Tables(0).Rows(0)("ERP_DOCUMENT")), "", xdsBox.Tables(0).Rows(0)("ERP_DOCUMENT"))
                    '03-Jul-11 J.R.
                    'Dim strQtyProdsInBox_2 As String = IIf(IsDBNull(xdsBox.Tables(0).Rows(0)("QTY_PRODUCTS_IN_BOX")), "0", xdsBox.Tables(0).Rows(0)("QTY_PRODUCTS_IN_BOX"))
                    Dim strQtyProdsInBox_2 As String = "0"

                    '03-Jul-11 J.R.
                    Dim split2() As String = split1(1).Split(",")
                    Dim intNumeroCaja As Integer
                    For i = 0 To split2.Length - 1
                        intNumeroCaja = CInt(split2(i).ToString)
                        If intNumeroCaja <> 0 Then

                            '03-Jul-11 J.R.
                            'PrintGroupLabel(pBoxID, strCodigoCliente, strClientId, strRoute, strRegion, strQtyProdsInBox_2, strPedido, strAddress1, strAddress2, strAddress3, Format(Now, "dd/MMM/yyyy hh:mmtt"), "Usuario: " + PublicLoginInfo.LoginID, Replace(strBoxNumber, "-", ""), pd.PrinterSettings.PrinterName, pd.PrinterSettings.Copies)
                            PrintGroupLabel(strNumPedido + "-" + intNumeroCaja.ToString, strCodigoCliente, strClientId, strRoute, strRegion, strQtyProdsInBox_2, strPedido, strAddress1, strAddress2, strAddress3, Format(Now, "dd/MMM/yyyy hh:mmtt"), PublicLoginInfo.LoginID, intNumeroCaja.ToString + "/" + intNumCajasPedido.ToString, pd.PrinterSettings.PrinterName, pd.PrinterSettings.Copies, pResult)
                            If pResult <> "OK" Then
                                MessageBox.Show(pResult, "WMS OnePlan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Function
                            End If
                            'PrintGroupLabel(Me.lblPedidoID.Tag + "-" + strBoxNumber, lblCustInfo.Tag, strClientId, strRoute, strRegion, 0, lblPedidoID.Tag, strAddress1, strAddress2, strAddress3, Format(Now, "dd/MMM/yyyy hh:mmtt"), "Usuario: " + PublicLoginInfo.LoginID, strBoxNumber + "/" + pNumeroEtiquetas.ToString, pd.PrinterSettings.PrinterName, pd.PrinterSettings.Copies)

                        End If
                    Next

                    ''01-Dic-10 J.R. Para imprimir el numero de caja en grande
                    'strBoxNumber = Mid(pBoxID, InStr(pBoxID, "-", CompareMethod.Text))

                    Return True '30-Jun-11 J.R.

                Else
                    Return False '30-Jun-11 J.R.
                    MessageBox.Show(pResult)
                End If


            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False '30-Jun-11 J.R.
        End Try

    End Function

    '01-Dic-10 J.R. se agrego parametro 14 (pBoxNum) para imprimir en grande el numero de caja)
    '30Jun10 J.R. Impresion de Etiquetas en cierre de Caja y pedido al consolidar
    '                           F2                       F3                           F4                        F5                      F6                          F7                            F8                        F9                         F10                        F11                          12                         13                       14
    Sub PrintGroupLabel(ByVal pBoxId As String, ByVal pClientId As String, ByVal pClientName As String, ByVal pRoute As String, ByVal pSector As String, ByVal pQtyProdsInBox As String, ByVal pOrderID As String, ByVal pAddress1 As String, ByVal pAddress2 As String, ByVal pAddress3 As String, ByVal pClosingDate As String, ByVal pUserID As String, ByVal pBoxNum As String, ByVal pPrinterName As String, ByVal pCopias As Integer, ByRef pResult As String)

        Dim pStr As String = ""

        HeadPartOne(pStr, pResult)
        If pResult = "OK" Then
            HeadPartTwo(pBoxId, pClientId, pClientName, pRoute, pSector, pQtyProdsInBox, pOrderID, pAddress1, pAddress2, pAddress3, pClosingDate, pUserID, pBoxNum, pLabelSize, pStr)
            For i = 1 To pCopias
                RawPrinterHelper_Consol1.SendStringToPrinter(pPrinterName, pStr)
            Next
        Else
            MessageBox.Show(pResult)
        End If

    End Sub

    Sub HeadPartOne(ByRef pStr As String, ByRef pResult As String)

        pStr = RetriveZPLCommand(pResult)

        'pStr = "^XA"
        'pStr = pStr + " ^DFR:4X6.GRF"
        'pStr = pStr + " ^FS"
        'pStr = pStr + " ^q500"

        'pStr = pStr + " ^LH20,80^PW14000" 'sets home position and label width (6 inches)

        'pStr = pStr + "^FO15,10^A0N,80,50^FN4^FS(NOMBRE)"

        'pStr = pStr + "^FO15,90^AAN,20,15^FN9^FS(direccion1)"
        'pStr = pStr + " ^FO15,125^AAN,20,10^FN10^FS"
        'pStr = pStr + " ^FO15,155^AAN,20,10^FN11^FS^FO15,190^GB740,0,5^FS"

        'pStr = pStr + " ^FO15,220^A0N,80,50^FN8^FS(pedido)"
        'pStr = pStr + " ^FO15,300^A0N,80,50^FN5^FS(ruta)"
        'pStr = pStr + " ^FO15,380^A0N,80,50^FN6^FS(sector)"

        'pStr = pStr + " ^FO130,950^AAN,30,20^FN12^FS^FO15,520^GB740,0,5^F^FS^FO450,190^GB0,3(fecha cierre)"

        'pStr = pStr + GetBarcodeFormat("CAJA_CONSOLIDACION")
        ''pStr = pStr + " ^FO40,330^A0B,36,25^FN3^FS(clientid)"

        ''pStr = pStr + " ^FO30,650^AAN,27,10^FN7^FS(items)"
        'pStr = pStr + " ^FO300,920^AAN,30,20^FN13^FS(usuario)"
        'pStr = pStr + "^FO590,250^A0N,250,90^FN14^FS(numcaja)"



    End Sub
    Function RetriveZPLCommand(ByRef pResult As String) As String
        Try
            Dim xdata As DataSet

            Dim pUsuarioLinea As String = ""

            Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
            'pUsuarioLinea = GetUserLine(pResult)
            Dim pLabelType As String = xserv.GetLabelID_In_Line(PublicLoginInfo.Linea, pResult, PublicLoginInfo.Environment)
            pLabelSize = pLabelType
            If pResult = "OK" Then
                xdata = xserv.GetLabelsSetup(pLabelType, pResult, PublicLoginInfo.Environment)
                If pResult = "OK" Then
                    Return xdata.Tables(0).Rows(0)("ZPL_COMMANDS")
                Else
                    Return ""
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return ""
    End Function
    Public Function GetUserLine(ByRef pResult As String) As String

        Dim xdata As DataSet
        Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
        Try

            xdata = xserv.SearchByKeyUserLogin(PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then 'Update the record
                Return xdata.Tables(0).Rows(0)("LINE_ID").ToString
            Else
                Return ""
            End If

        Catch ex As Exception
            pResult = ex.Message
            Return ""
        End Try
    End Function

    '30Jun10 J.R. Impresion de Etiquetas en cierre de Caja y pedido al consolidar
    '                       F2                       F3                           F4                        F5                      F6                          F7                            F8                        F9                         F10                        F11                          12                         13                       14
    Sub HeadPartTwo(ByVal pBoxId As String, ByVal pClientId As String, ByVal pClientName As String, ByVal pRoute As String, ByVal pSector As String, ByVal pQtyProdsInBox As String, ByVal pOrderID As String, ByVal pAddress1 As String, ByVal pAddress2 As String, ByVal pAddress3 As String, ByVal pClosingDate As String, ByVal pUserID As String, ByVal pBoxNum As String, ByVal LabelSize As String, ByRef pStr As String)

        pStr = pStr + " ^XZ"
        pStr = pStr + " ^XA"


        pStr = pStr + " ^XFR:" + LabelSize + ".GRF"

        pStr = pStr + " ^FN2^FD" + pBoxId + "^FS"
        'pStr = pStr + " ^FN3^FD" + pClientId + "^FS"
        pStr = pStr + " ^FN4^FD" + pClientName + "^FS"
        pStr = pStr + " ^FN5^FD" + "Ruta: " + pRoute + "^FS"
        pStr = pStr + " ^FN6^FD" + "Sector:" + pSector + "^FS"

        pStr = pStr + " ^FN8^FD" + pOrderID + "^FS"
        pStr = pStr + " ^FN9^FD" + pAddress1 + "^FS"
        pStr = pStr + " ^FN10^FD" + pAddress2 + "^FS"
        pStr = pStr + " ^FN11^FD" + pAddress3 + "^FS"
        pStr = pStr + " ^FN12^FD" + pClosingDate + "^FS"
        pStr = pStr + " ^FN13^FD" + pUserID + "^FS"
        pStr = pStr + " ^FN14^FD" + pBoxNum + "^FS"
        pStr = pStr + " ^XZ"

    End Sub

    '30Jun10 J.R. Impresion de Etiquetas en cierre de Caja y pedido al consolidar
    Public Function GetBarcodeFormat(ByVal pSize As String)
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xds As New DataSet
        Dim pResult As String = ""
        Try
            xds = xserv.GetParam_ByParamKey("SISTEMA", "TIPO_ETIQUETAS", pSize, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                Return xds.Tables(0).Rows(0)("SPARE1")
            Else
                Return "^FO01,140^BY3^B3N,N,200,N,N^FN4^FS"
            End If
        Catch ex As Exception
            Return "Money Twins"
        End Try
    End Function

    Private Sub btnCloseDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseDoc.Click

        Dim pResult As String = ""

        '13-Ago-10 J.R. inmediatamente despues de escanear el ultimo producto y llegar al 100% manda a cerrar el pedido e imprimir etiqueta. sin esperar el timer
        Dim blnCierra As Boolean

        Try

            If lblPorcentajeCuadre.Tag >= 100 Then

                Dim strNumeroEtiquetas As String
                strNumeroEtiquetas = InputBox("Cuantos Bultos empacó?", "Generación de etiquetas V2", "")
                If IsNumeric(strNumeroEtiquetas) Then
                    If PrintLabels("", CInt(strNumeroEtiquetas)) Then
                        pResult = "OK"
                        Dim xserv As New OnePlanServices_Consolidation.WMS_ConsolidationSoapClient("WMS_ConsolidationSoap", PublicLoginInfo.WSHost + "/trans/WMS_Consolidation.asmx")


                        If Not xserv.UpdateHeaderByDocument(Me.lblPedidoID.Tag, CInt(strNumeroEtiquetas), PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult) Then
                            MessageBox.Show("No se pudo asignar cantidad de cajas." & vbNewLine & pResult)
                        Else
                            'PrintDocs(lblPedidoID.Tag)
                        End If

                    End If
                Else
                    MessageBox.Show("No se pudo asignar cantidad de cajas. Se ingreso un numero incorrecto. Inténtelo de nuevo")
                    blnPreguntaCerrarDoc = True
                    'MessageBox.Show(CInt(strNumeroEtiquetas))
                End If

                '08-Sep-10 J.R. deshabilitar timer para evitar demasiadas llamadas al server
                'Me.Timer_Bins.Enabled = False

                If blnPreguntaCerrarDoc Then
                    blnCierra = MessageBox.Show("Desea Cerrar la Consolidación del pedido?", "OnePlan WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes
                Else
                    blnCierra = True
                End If

                If blnCierra Then

                    '01Jul10 J.R. Para imprmir en la etiqueta al cerrar caja
                    strBoxID = Me.lblCaja.Text
                    strQtyProdsInBox = Me.lblCaja.Tag

                    '01Jul10 J.R. Para imprmir en la etiqueta al cerrar caja
                    Dim blnCerrarDoc As Boolean
                    If Me.lblCaja.Text = "" Then
                        blnCerrarDoc = True
                    Else
                        blnCerrarDoc = CloseCurrentBox(pResult)
                        If blnCerrarDoc Then
                            PrintLabels()
                        Else
                            Me.lblStatus.Image = My.Resources.ico_error
                            Me.lblStatus.Text = pResult
                            Me.ToolStripStatusLabel1.Text = "@" + Me.cmbLines.EditValue.ToString  '04-Nov-10 Par que funcione con multiples lineas
                        End If
                    End If

                    If blnCerrarDoc Then
                        If CloseDispatch(pResult) Then

                            '07-Sep-10 J.R. ya lo hace Jonhy
                            'PrintShipmentAdvice()

                            GC_Boxes.DataSource = Nothing
                            GC_ScannedDetail.DataSource = Nothing
                            GridControl_Bins.DataSource = Nothing

                            'ShowCurrentDocInDispatch()
                            RefreshCurrentDocInDispatch()

                            ShowCurrentTransInDispatch()
                            MessageBox.Show("Pedido Consolidado Exitosamente!")
                            '04-Nov-10 Par que funcione con multiples lineas
                            'ShowBoxesCurrentDoc("LINEA_2", pResult)
                            ShowBoxesCurrentDoc(Me.cmbLines.EditValue.ToString, pResult)

                        Else
                            MessageBox.Show(pResult)
                        End If
                    End If


                End If

                '08-Sep-10 J.R. deshabilitar timer para evitar demasiadas llamadas al server
                'Me.Timer_Bins.Enabled = True

            Else
                MessageBox.Show("No se puede cerrar la consolidacion para el pedido, porque aun no esta al 100%", "OnePlan WMS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception

            '08-Sep-10 J.R. deshabilitar timer para evitar demasiadas llamadas al server
            'Me.Timer_Bins.Enabled = True
            MessageBox.Show(pResult)

        End Try
    End Sub
    Public Function CloseDispatch(ByRef pResult As String) As String
        Try
            Dim xserv As New OnePlanServices_Consolidation.WMS_ConsolidationSoapClient("WMS_ConsolidationSoap", PublicLoginInfo.WSHost + "/trans/WMS_Consolidation.asmx")
            '04-Nov-10 Par que funcione con multiples lineas
            'If xserv.CloseCtrlDoc("LINEA_2", PublicLoginInfo.LoginID, Me.lblPedidoID.Tag, PublicLoginInfo.Environment, pResult) Then
            If xserv.CloseCtrlDoc(Me.cmbLines.EditValue.ToString, PublicLoginInfo.LoginID, Me.lblPedidoID.Tag, PublicLoginInfo.Environment, pResult) Then

                pResult = "OK"
                blnYaImprimio = False '06-Sep-10 J.R. imprime documentos, exe de Jonathan
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

    Sub PrintDocuments(Optional ByVal pDocID As String = "")
        Dim intShell As Integer
        If Not blnYaImprimio Then
            Dim servSettings As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
            Dim dsRuta As DataSet
            Dim pResult As String = ""
            Dim strFileName As String

            Try

                dsRuta = servSettings.GetParam_ByParamKey("SISTEMA", "RUTAS_ARCHIVOS", "IMPRESION_FACTURAS", pResult, PublicLoginInfo.Environment)
                If pResult = "OK" Then
                    strFileName = dsRuta.Tables(0).Rows(0)("TEXT_VALUE").ToString
                Else
                    strFileName = "C:\IMPRESIONFACTURAS"
                End If

                '14-Mar-11 J.R. Para reimpresion de etiqueta
                If pDocID = "" Then
                    intShell = Shell(strFileName + " " & Me.lblPedidoID.Tag, AppWinStyle.Hide)
                    blnYaImprimio = True
                Else
                    intShell = Shell(strFileName + " " & pDocID, AppWinStyle.Hide)
                End If

            Catch ex As Exception
                MessageBox.Show("No existe la ruta necesaria para la impresion de Facturas, revise Parametros del Sistema." & vbNewLine & ex.Message)
            End Try

        End If
        'intShell = Shell("X:\Print.Exe " & Me.lblPedidoID.Tag, AppWinStyle.Hide)
    End Sub

    Private Sub btnDiffs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiffs.Click
        ShowCurrentDocInDispatch()
    End Sub

    Private Sub SimpleButton4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton4.Click
        Me.Close()
    End Sub

    Private Sub btnPrintInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strInvoiceID As String '
        strInvoiceID = InputBox("Ingrese numero de factura que desea imprimir:", "Impresion Factura")
        If strInvoiceID.Trim.Length > 0 Then
            '22-Oct-2010 J.R. Para mejorar tiempo de Consolidadores se comentario
            PrintDocuments()
        End If
    End Sub

    Private Sub cmbLines_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLines.EditValueChanged
        ShowCurrentDocInDispatch()
    End Sub

    Private Sub PanelControl5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelControl5.Paint

    End Sub
    Sub PrintDocs(ByVal pDoc As String)
        
        PrintDocuments(pDoc)

    End Sub
    Private Sub btnPrintLastInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintLastInvoice.Click

        PrintLast.RB_Invoice.Checked = True
        PrintLast.TextBox1.Text = lblPedidoID.Tag
        PrintLast.grpFactura.Visible = True
        PrintLast.grpPedido.Visible = False
        PrintLast.grpPedido.Left = 365
        PrintLast.ShowDialog()
        PrintLast.Dispose()

    End Sub

    Private Sub btnPrintLastLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintLastLabel.Click
        PrintLast.RB_Label.Checked = True
        PrintLast.TextBox1.Text = lblCaja.Text
        PrintLast.grpFactura.Visible = False
        PrintLast.grpPedido.Visible = True
        PrintLast.grpFactura.Left = 365

        PrintLast.txtPedido.Text = lblPedidoID.Tag
        PrintLast.lblCliente.Text = lblCustInfo.Text
        PrintLast.lblSector.Text = lblSector.Text
        PrintLast.lblRuta.Text = lblRuta.Text

        PrintLast.ShowDialog()
        PrintLast.Dispose()
    End Sub

    Private Sub btnDailyReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDailyReport.Click
        frmDailyConsolidation.lblUsuario.Text = PublicLoginInfo.LoginID
        frmDailyConsolidation.txtFecha.DateTime = Today
        frmDailyConsolidation.ShowDialog()
        frmDailyConsolidation.Dispose()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GetLoginStatus()
    End Sub
    Sub GetLoginStatus()
        Dim pResult As String = ""
        Dim xdata As DataSet
        Try

            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")

            xdata = xserv.SearchByKeyUserLogin(PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                If xdata.Tables(0).Rows(0)("IS_LOGGED") = "0" Then
                    Application.Exit()
                Else
                    lblStatus.Text = "Conectado como: " + PublicLoginInfo.LoginID

                End If
            Else
                MessageBox.Show(pResult)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtScanLine_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanLine.EditValueChanged

    End Sub
End Class

Public Class RawPrinterHelper_Consol1
    ' Structure and API declarions:
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Structure DOCINFOW
        <MarshalAs(UnmanagedType.LPWStr)> Public pDocName As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pDataType As String
    End Structure

    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterW", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function OpenPrinter(ByVal src As String, ByRef hPrinter As IntPtr, ByVal pd As Long) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterW", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32, ByRef pDI As DOCINFOW) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="WritePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, ByRef dwWritten As Int32) As Boolean
    End Function

    ' SendBytesToPrinter()
    ' When the function is given a printer name and an unmanaged array of  
    ' bytes, the function sends those bytes to the print queue.
    ' Returns True on success or False on failure.
    Public Shared Function SendBytesToPrinter(ByVal szPrinterName As String, ByVal pBytes As IntPtr, ByVal dwCount As Int32) As Boolean
        Dim hPrinter As IntPtr      ' The printer handle.
        Dim dwError As Int32        ' Last error - in case there was trouble.
        Dim di As DOCINFOW = Nothing
          ' Describes your document (name, port, data type).
        Dim dwWritten As Int32      ' The number of bytes written by WritePrinter().
        Dim bSuccess As Boolean     ' Your success code.

        ' Set up the DOCINFO structure.
        With di
            .pDocName = "My Visual Basic .NET RAW Document"
            .pDataType = "RAW"
        End With
        ' Assume failure unless you specifically succeed.
        bSuccess = False
        If OpenPrinter(szPrinterName, hPrinter, 0) Then
            If StartDocPrinter(hPrinter, 1, di) Then
                If StartPagePrinter(hPrinter) Then
                    ' Write your printer-specific bytes to the printer.
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                    EndPagePrinter(hPrinter)
                End If
                EndDocPrinter(hPrinter)
            End If
            ClosePrinter(hPrinter)
        End If
        ' If you did not succeed, GetLastError may give more information
        ' about why not.
        If bSuccess = False Then
            dwError = Marshal.GetLastWin32Error()
        End If
        Return bSuccess
    End Function ' SendBytesToPrinter()

    ' SendFileToPrinter()
    ' When the function is given a file name and a printer name, 
    ' the function reads the contents of the file and sends the
    ' contents to the printer.
    ' Presumes that the file contains printer-ready data.
    ' Shows how to use the SendBytesToPrinter function.
    ' Returns True on success or False on failure.
    Public Shared Function SendFileToPrinter(ByVal szPrinterName As String, ByVal szFileName As String) As Boolean
        ' Open the file.
        Dim fs As New FileStream(szFileName, FileMode.Open)
        ' Create a BinaryReader on the file.
        Dim br As New BinaryReader(fs)
        ' Dim an array of bytes large enough to hold the file's contents.
        Dim bytes(fs.Length) As Byte
        Dim bSuccess As Boolean
        ' Your unmanaged pointer.
        Dim pUnmanagedBytes As IntPtr

        ' Read the contents of the file into the array.
        bytes = br.ReadBytes(fs.Length)
        ' Allocate some unmanaged memory for those bytes.
        pUnmanagedBytes = Marshal.AllocCoTaskMem(fs.Length)
        ' Copy the managed byte array into the unmanaged array.
        Marshal.Copy(bytes, 0, pUnmanagedBytes, fs.Length)
        ' Send the unmanaged bytes to the printer.
        bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, fs.Length)
        ' Free the unmanaged memory that you allocated earlier.
        Marshal.FreeCoTaskMem(pUnmanagedBytes)
        Return bSuccess
    End Function ' SendFileToPrinter()

    ' When the function is given a string and a printer name,
    ' the function sends the string to the printer as raw bytes.
    Public Shared Function SendStringToPrinter(ByVal szPrinterName As String, ByVal szString As String)
        Dim pBytes As IntPtr
        Dim dwCount As Int32
        ' How many characters are in the string?
        dwCount = szString.Length()
        ' Assume that the printer is expecting ANSI text, and then convert
        ' the string to ANSI text.
        pBytes = Marshal.StringToCoTaskMemAnsi(szString)
        ' Send the converted ANSI string to the printer.
        SendBytesToPrinter(szPrinterName, pBytes, dwCount)
        Marshal.FreeCoTaskMem(pBytes)
        Return ""
    End Function
End Class

Public Class RawPrinterHelper_Consol2
    ' Structure and API declarions:
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Structure DOCINFOW
        <MarshalAs(UnmanagedType.LPWStr)> Public pDocName As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pDataType As String
    End Structure

    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterW", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function OpenPrinter(ByVal src As String, ByRef hPrinter As IntPtr, ByVal pd As Long) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterW", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32, ByRef pDI As DOCINFOW) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="WritePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, ByRef dwWritten As Int32) As Boolean
    End Function

    ' SendBytesToPrinter()
    ' When the function is given a printer name and an unmanaged array of  
    ' bytes, the function sends those bytes to the print queue.
    ' Returns True on success or False on failure.
    Public Shared Function SendBytesToPrinter(ByVal szPrinterName As String, ByVal pBytes As IntPtr, ByVal dwCount As Int32) As Boolean
        Dim hPrinter As IntPtr      ' The printer handle.
        Dim dwError As Int32        ' Last error - in case there was trouble.
        Dim di As DOCINFOW = Nothing         ' Describes your document (name, port, data type).
        Dim dwWritten As Int32      ' The number of bytes written by WritePrinter().
        Dim bSuccess As Boolean     ' Your success code.

        ' Set up the DOCINFO structure.
        With di
            .pDocName = "My Visual Basic .NET RAW Document"
            .pDataType = "RAW"
        End With
        ' Assume failure unless you specifically succeed.
        bSuccess = False
        If OpenPrinter(szPrinterName, hPrinter, 0) Then
            If StartDocPrinter(hPrinter, 1, di) Then
                If StartPagePrinter(hPrinter) Then
                    ' Write your printer-specific bytes to the printer.
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                    EndPagePrinter(hPrinter)
                End If
                EndDocPrinter(hPrinter)
            End If
            ClosePrinter(hPrinter)
        End If
        ' If you did not succeed, GetLastError may give more information
        ' about why not.
        If bSuccess = False Then
            dwError = Marshal.GetLastWin32Error()
        End If
        Return bSuccess
    End Function ' SendBytesToPrinter()

    ' SendFileToPrinter()
    ' When the function is given a file name and a printer name, 
    ' the function reads the contents of the file and sends the
    ' contents to the printer.
    ' Presumes that the file contains printer-ready data.
    ' Shows how to use the SendBytesToPrinter function.
    ' Returns True on success or False on failure.
    Public Shared Function SendFileToPrinter(ByVal szPrinterName As String, ByVal szFileName As String) As Boolean
        ' Open the file.
        Dim fs As New FileStream(szFileName, FileMode.Open)
        ' Create a BinaryReader on the file.
        Dim br As New BinaryReader(fs)
        ' Dim an array of bytes large enough to hold the file's contents.
        Dim bytes(fs.Length) As Byte
        Dim bSuccess As Boolean
        ' Your unmanaged pointer.
        Dim pUnmanagedBytes As IntPtr

        ' Read the contents of the file into the array.
        bytes = br.ReadBytes(fs.Length)
        ' Allocate some unmanaged memory for those bytes.
        pUnmanagedBytes = Marshal.AllocCoTaskMem(fs.Length)
        ' Copy the managed byte array into the unmanaged array.
        Marshal.Copy(bytes, 0, pUnmanagedBytes, fs.Length)
        ' Send the unmanaged bytes to the printer.
        bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, fs.Length)
        ' Free the unmanaged memory that you allocated earlier.
        Marshal.FreeCoTaskMem(pUnmanagedBytes)
        Return bSuccess
    End Function ' SendFileToPrinter()

    ' When the function is given a string and a printer name,
    ' the function sends the string to the printer as raw bytes.
    Public Shared Function SendStringToPrinter(ByVal szPrinterName As String, ByVal szString As String)
        Dim pBytes As IntPtr
        Dim dwCount As Int32
        ' How many characters are in the string?
        dwCount = szString.Length()
        ' Assume that the printer is expecting ANSI text, and then convert
        ' the string to ANSI text.
        pBytes = Marshal.StringToCoTaskMemAnsi(szString)
        ' Send the converted ANSI string to the printer.
        SendBytesToPrinter(szPrinterName, pBytes, dwCount)
        Marshal.FreeCoTaskMem(pBytes)
        Return ""
    End Function

End Class

Public Class RawPrinterHelper_Consol3
    ' Structure and API declarions:
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Structure DOCINFOW
        <MarshalAs(UnmanagedType.LPWStr)> Public pDocName As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pDataType As String
    End Structure

    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterW", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function OpenPrinter(ByVal src As String, ByRef hPrinter As IntPtr, ByVal pd As Long) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterW", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32, ByRef pDI As DOCINFOW) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="WritePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, ByRef dwWritten As Int32) As Boolean
    End Function

    ' SendBytesToPrinter()
    ' When the function is given a printer name and an unmanaged array of  
    ' bytes, the function sends those bytes to the print queue.
    ' Returns True on success or False on failure.
    Public Shared Function SendBytesToPrinter(ByVal szPrinterName As String, ByVal pBytes As IntPtr, ByVal dwCount As Int32) As Boolean
        Dim hPrinter As IntPtr      ' The printer handle.
        Dim dwError As Int32        ' Last error - in case there was trouble.
        Dim di As DOCINFOW = Nothing          ' Describes your document (name, port, data type).
        Dim dwWritten As Int32      ' The number of bytes written by WritePrinter().
        Dim bSuccess As Boolean     ' Your success code.

        ' Set up the DOCINFO structure.
        With di
            .pDocName = "My Visual Basic .NET RAW Document"
            .pDataType = "RAW"
        End With
        ' Assume failure unless you specifically succeed.
        bSuccess = False
        If OpenPrinter(szPrinterName, hPrinter, 0) Then
            If StartDocPrinter(hPrinter, 1, di) Then
                If StartPagePrinter(hPrinter) Then
                    ' Write your printer-specific bytes to the printer.
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                    EndPagePrinter(hPrinter)
                End If
                EndDocPrinter(hPrinter)
            End If
            ClosePrinter(hPrinter)
        End If
        ' If you did not succeed, GetLastError may give more information
        ' about why not.
        If bSuccess = False Then
            dwError = Marshal.GetLastWin32Error()
        End If
        Return bSuccess
    End Function ' SendBytesToPrinter()

    ' SendFileToPrinter()
    ' When the function is given a file name and a printer name, 
    ' the function reads the contents of the file and sends the
    ' contents to the printer.
    ' Presumes that the file contains printer-ready data.
    ' Shows how to use the SendBytesToPrinter function.
    ' Returns True on success or False on failure.
    Public Shared Function SendFileToPrinter(ByVal szPrinterName As String, ByVal szFileName As String) As Boolean
        ' Open the file.
        Dim fs As New FileStream(szFileName, FileMode.Open)
        ' Create a BinaryReader on the file.
        Dim br As New BinaryReader(fs)
        ' Dim an array of bytes large enough to hold the file's contents.
        Dim bytes(fs.Length) As Byte
        Dim bSuccess As Boolean
        ' Your unmanaged pointer.
        Dim pUnmanagedBytes As IntPtr

        ' Read the contents of the file into the array.
        bytes = br.ReadBytes(fs.Length)
        ' Allocate some unmanaged memory for those bytes.
        pUnmanagedBytes = Marshal.AllocCoTaskMem(fs.Length)
        ' Copy the managed byte array into the unmanaged array.
        Marshal.Copy(bytes, 0, pUnmanagedBytes, fs.Length)
        ' Send the unmanaged bytes to the printer.
        bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, fs.Length)
        ' Free the unmanaged memory that you allocated earlier.
        Marshal.FreeCoTaskMem(pUnmanagedBytes)
        Return bSuccess
    End Function ' SendFileToPrinter()

    ' When the function is given a string and a printer name,
    ' the function sends the string to the printer as raw bytes.
    Public Shared Function SendStringToPrinter(ByVal szPrinterName As String, ByVal szString As String)
        Dim pBytes As IntPtr
        Dim dwCount As Int32
        ' How many characters are in the string?
        dwCount = szString.Length()
        ' Assume that the printer is expecting ANSI text, and then convert
        ' the string to ANSI text.
        pBytes = Marshal.StringToCoTaskMemAnsi(szString)
        ' Send the converted ANSI string to the printer.
        SendBytesToPrinter(szPrinterName, pBytes, dwCount)
        Marshal.FreeCoTaskMem(pBytes)
        Return ""
    End Function

End Class