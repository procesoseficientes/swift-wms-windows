<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainConsolidate
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition
        Me.colPendiente = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.btnDailyReport = New DevExpress.XtraEditors.SimpleButton
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.lblRuta = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCustAddress = New System.Windows.Forms.Label
        Me.lblCaja = New DevExpress.XtraEditors.LabelControl
        Me.lblSector = New DevExpress.XtraEditors.LabelControl
        Me.lblCustInfo = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.lblPorcentajeCuadre = New DevExpress.XtraEditors.LabelControl
        Me.lblPedidoID = New DevExpress.XtraEditors.LabelControl
        Me.btnPrintLastInvoice = New DevExpress.XtraEditors.SimpleButton
        Me.btnPrintLastLabel = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton
        Me.btnDiffs = New DevExpress.XtraEditors.SimpleButton
        Me.btnCloseBox = New DevExpress.XtraEditors.SimpleButton
        Me.btnCloseDoc = New DevExpress.XtraEditors.SimpleButton
        Me.SplitPrincipalDetallePedido = New DevExpress.XtraEditors.SplitContainerControl
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl
        Me.GC_ScannedDetail = New DevExpress.XtraGrid.GridControl
        Me.GV_ScannedDetail = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl
        Me.txtScanLine = New DevExpress.XtraEditors.TextEdit
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.lblTimerStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.SplitInternoDetaille = New System.Windows.Forms.SplitContainer
        Me.GC_DetallePedido = New DevExpress.XtraGrid.GridControl
        Me.GV_DetallePedido = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.colCodigo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colCantidadPedido = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colCantidadScaned = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colCantidadPicked = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colPercPicked = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PickingProgress = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
        Me.TabsAuxiliares = New DevExpress.XtraTab.XtraTabControl
        Me.XtraTabPage_PendingBins = New DevExpress.XtraTab.XtraTabPage
        Me.GridControl_Bins = New DevExpress.XtraGrid.GridControl
        Me.GV_Bins = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.XtraTabPage_Boxes = New DevExpress.XtraTab.XtraTabPage
        Me.GC_Boxes = New DevExpress.XtraGrid.GridControl
        Me.GV_Boxes = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.colCaja = New DevExpress.XtraGrid.Columns.GridColumn
        Me.XtraTabPage_Picking = New DevExpress.XtraTab.XtraTabPage
        Me.XtraTabPage_Que = New DevExpress.XtraTab.XtraTabPage
        Me.Timer_Bins = New System.Windows.Forms.Timer(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar
        Me.cmbLines = New DevExpress.XtraBars.BarEditItem
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.Bar4 = New DevExpress.XtraBars.Bar
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SplitPrincipalDetallePedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPrincipalDetallePedido.SuspendLayout()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.GC_ScannedDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GV_ScannedDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.txtScanLine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SplitInternoDetaille.Panel1.SuspendLayout()
        Me.SplitInternoDetaille.Panel2.SuspendLayout()
        Me.SplitInternoDetaille.SuspendLayout()
        CType(Me.GC_DetallePedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GV_DetallePedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PickingProgress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabsAuxiliares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabsAuxiliares.SuspendLayout()
        Me.XtraTabPage_PendingBins.SuspendLayout()
        CType(Me.GridControl_Bins, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GV_Bins, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage_Boxes.SuspendLayout()
        CType(Me.GC_Boxes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GV_Boxes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colPendiente
        '
        Me.colPendiente.AppearanceHeader.Options.UseTextOptions = True
        Me.colPendiente.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colPendiente.Caption = "Unidades Pendientes"
        Me.colPendiente.FieldName = "QTY_PENDING"
        Me.colPendiente.Name = "colPendiente"
        Me.colPendiente.OptionsColumn.AllowEdit = False
        Me.colPendiente.OptionsColumn.AllowFocus = False
        Me.colPendiente.OptionsColumn.ReadOnly = True
        Me.colPendiente.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.colPendiente.Visible = True
        Me.colPendiente.VisibleIndex = 4
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.White
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Controls.Add(Me.btnDailyReport)
        Me.PanelControl1.Controls.Add(Me.PanelControl5)
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Controls.Add(Me.btnPrintLastInvoice)
        Me.PanelControl1.Controls.Add(Me.btnPrintLastLabel)
        Me.PanelControl1.Controls.Add(Me.SimpleButton4)
        Me.PanelControl1.Controls.Add(Me.btnDiffs)
        Me.PanelControl1.Controls.Add(Me.btnCloseBox)
        Me.PanelControl1.Controls.Add(Me.btnCloseDoc)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 31)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1036, 93)
        Me.PanelControl1.TabIndex = 7
        '
        'btnDailyReport
        '
        Me.btnDailyReport.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.btnDailyReport.Appearance.Options.UseTextOptions = True
        Me.btnDailyReport.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnDailyReport.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnDailyReport.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDailyReport.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Prepare_Large
        Me.btnDailyReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnDailyReport.Location = New System.Drawing.Point(924, 2)
        Me.btnDailyReport.Name = "btnDailyReport"
        Me.btnDailyReport.Size = New System.Drawing.Size(55, 89)
        Me.btnDailyReport.TabIndex = 25
        Me.btnDailyReport.Text = "Reporte Diario (F5)"
        '
        'PanelControl5
        '
        Me.PanelControl5.Appearance.BackColor = System.Drawing.Color.White
        Me.PanelControl5.Appearance.Options.UseBackColor = True
        Me.PanelControl5.Controls.Add(Me.LabelControl5)
        Me.PanelControl5.Controls.Add(Me.LabelControl4)
        Me.PanelControl5.Controls.Add(Me.lblRuta)
        Me.PanelControl5.Controls.Add(Me.LabelControl3)
        Me.PanelControl5.Controls.Add(Me.LabelControl2)
        Me.PanelControl5.Controls.Add(Me.LabelControl1)
        Me.PanelControl5.Controls.Add(Me.Label1)
        Me.PanelControl5.Controls.Add(Me.lblCustAddress)
        Me.PanelControl5.Controls.Add(Me.lblCaja)
        Me.PanelControl5.Controls.Add(Me.lblSector)
        Me.PanelControl5.Controls.Add(Me.lblCustInfo)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl5.Location = New System.Drawing.Point(486, 2)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(487, 89)
        Me.PanelControl5.TabIndex = 18
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Segoe Condensed", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(282, 23)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(43, 22)
        Me.LabelControl5.TabIndex = 26
        Me.LabelControl5.Text = "Caja#:"
        Me.LabelControl5.Visible = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(2, 51)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(77, 23)
        Me.LabelControl4.TabIndex = 25
        Me.LabelControl4.Text = "Dirección:"
        '
        'lblRuta
        '
        Me.lblRuta.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.lblRuta.Appearance.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.Location = New System.Drawing.Point(200, 23)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(44, 23)
        Me.lblRuta.TabIndex = 12
        Me.lblRuta.Text = "#Ruta"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(156, 23)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(40, 23)
        Me.LabelControl3.TabIndex = 11
        Me.LabelControl3.Text = "Ruta:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(2, 2)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(57, 23)
        Me.LabelControl2.TabIndex = 10
        Me.LabelControl2.Text = "Cliente:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(2, 23)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(54, 23)
        Me.LabelControl1.TabIndex = 9
        Me.LabelControl1.Text = "Sector:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(373, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 8
        '
        'lblCustAddress
        '
        Me.lblCustAddress.BackColor = System.Drawing.SystemColors.Control
        Me.lblCustAddress.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustAddress.Location = New System.Drawing.Point(78, 51)
        Me.lblCustAddress.Name = "lblCustAddress"
        Me.lblCustAddress.Size = New System.Drawing.Size(295, 37)
        Me.lblCustAddress.TabIndex = 7
        Me.lblCustAddress.Text = "Dirección"
        '
        'lblCaja
        '
        Me.lblCaja.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.lblCaja.Appearance.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaja.Location = New System.Drawing.Point(331, 22)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(42, 23)
        Me.lblCaja.TabIndex = 6
        Me.lblCaja.Text = "#Caja"
        Me.lblCaja.Visible = False
        '
        'lblSector
        '
        Me.lblSector.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.lblSector.Appearance.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSector.Location = New System.Drawing.Point(61, 23)
        Me.lblSector.Name = "lblSector"
        Me.lblSector.Size = New System.Drawing.Size(58, 23)
        Me.lblSector.TabIndex = 5
        Me.lblSector.Text = "#Sector"
        '
        'lblCustInfo
        '
        Me.lblCustInfo.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.lblCustInfo.Appearance.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.lblCustInfo.Location = New System.Drawing.Point(61, 1)
        Me.lblCustInfo.Name = "lblCustInfo"
        Me.lblCustInfo.Size = New System.Drawing.Size(53, 23)
        Me.lblCustInfo.TabIndex = 4
        Me.lblCustInfo.Text = "0000-..."
        '
        'PanelControl2
        '
        Me.PanelControl2.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.PanelControl2.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.PanelControl2.Appearance.Options.UseBackColor = True
        Me.PanelControl2.Appearance.Options.UseBorderColor = True
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.PanelControl2.Controls.Add(Me.lblPorcentajeCuadre)
        Me.PanelControl2.Controls.Add(Me.lblPedidoID)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl2.Location = New System.Drawing.Point(281, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(205, 89)
        Me.PanelControl2.TabIndex = 22
        '
        'lblPorcentajeCuadre
        '
        Me.lblPorcentajeCuadre.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.lblPorcentajeCuadre.Appearance.Font = New System.Drawing.Font("Arial Narrow", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentajeCuadre.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPorcentajeCuadre.Location = New System.Drawing.Point(2, 29)
        Me.lblPorcentajeCuadre.Name = "lblPorcentajeCuadre"
        Me.lblPorcentajeCuadre.Size = New System.Drawing.Size(105, 24)
        Me.lblPorcentajeCuadre.TabIndex = 5
        Me.lblPorcentajeCuadre.Text = "0% Cuadrado"
        '
        'lblPedidoID
        '
        Me.lblPedidoID.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.lblPedidoID.Appearance.Font = New System.Drawing.Font("Arial Narrow", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoID.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPedidoID.Location = New System.Drawing.Point(2, 2)
        Me.lblPedidoID.Name = "lblPedidoID"
        Me.lblPedidoID.Size = New System.Drawing.Size(166, 27)
        Me.lblPedidoID.TabIndex = 4
        Me.lblPedidoID.Text = "Pedido: (Ninguno)"
        '
        'btnPrintLastInvoice
        '
        Me.btnPrintLastInvoice.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.btnPrintLastInvoice.Appearance.Options.UseTextOptions = True
        Me.btnPrintLastInvoice.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnPrintLastInvoice.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnPrintLastInvoice.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPrintLastInvoice.Image = Global.WMSOnePlan_Client.My.Resources.Resources.print_large
        Me.btnPrintLastInvoice.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnPrintLastInvoice.Location = New System.Drawing.Point(226, 2)
        Me.btnPrintLastInvoice.Name = "btnPrintLastInvoice"
        Me.btnPrintLastInvoice.Size = New System.Drawing.Size(55, 89)
        Me.btnPrintLastInvoice.TabIndex = 24
        Me.btnPrintLastInvoice.Text = "Imprimir Ult. Fact. (F11)"
        '
        'btnPrintLastLabel
        '
        Me.btnPrintLastLabel.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.btnPrintLastLabel.Appearance.Options.UseTextOptions = True
        Me.btnPrintLastLabel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnPrintLastLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnPrintLastLabel.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPrintLastLabel.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes080
        Me.btnPrintLastLabel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnPrintLastLabel.Location = New System.Drawing.Point(167, 2)
        Me.btnPrintLastLabel.Name = "btnPrintLastLabel"
        Me.btnPrintLastLabel.Size = New System.Drawing.Size(59, 89)
        Me.btnPrintLastLabel.TabIndex = 23
        Me.btnPrintLastLabel.Text = "Reposicion Etiqueta (F10)"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Appearance.Options.UseTextOptions = True
        Me.SimpleButton4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SimpleButton4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton4.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.SimpleButton4.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton4.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes085
        Me.SimpleButton4.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.SimpleButton4.Location = New System.Drawing.Point(979, 2)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(55, 89)
        Me.SimpleButton4.TabIndex = 21
        Me.SimpleButton4.Text = "Salir (F3)"
        '
        'btnDiffs
        '
        Me.btnDiffs.Appearance.Options.UseTextOptions = True
        Me.btnDiffs.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnDiffs.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnDiffs.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Clipboard
        Me.btnDiffs.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnDiffs.Location = New System.Drawing.Point(112, 2)
        Me.btnDiffs.Name = "btnDiffs"
        Me.btnDiffs.Size = New System.Drawing.Size(55, 89)
        Me.btnDiffs.TabIndex = 14
        Me.btnDiffs.Text = "Siguiente Pedido (F4)"
        '
        'btnCloseBox
        '
        Me.btnCloseBox.Appearance.Options.UseTextOptions = True
        Me.btnCloseBox.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnCloseBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCloseBox.Image = Global.WMSOnePlan_Client.My.Resources.Resources.comp_beos011
        Me.btnCloseBox.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnCloseBox.Location = New System.Drawing.Point(57, 2)
        Me.btnCloseBox.Name = "btnCloseBox"
        Me.btnCloseBox.Size = New System.Drawing.Size(55, 89)
        Me.btnCloseBox.TabIndex = 13
        Me.btnCloseBox.Text = "Cerrar Caja    (F8)"
        Me.btnCloseBox.Visible = False
        '
        'btnCloseDoc
        '
        Me.btnCloseDoc.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.btnCloseDoc.Appearance.Options.UseTextOptions = True
        Me.btnCloseDoc.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnCloseDoc.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnCloseDoc.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCloseDoc.Image = Global.WMSOnePlan_Client.My.Resources.Resources.MarkAsFinal_Large
        Me.btnCloseDoc.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnCloseDoc.Location = New System.Drawing.Point(2, 2)
        Me.btnCloseDoc.Name = "btnCloseDoc"
        Me.btnCloseDoc.Size = New System.Drawing.Size(55, 89)
        Me.btnCloseDoc.TabIndex = 8
        Me.btnCloseDoc.Text = "Cerrar Pedido (F9)"
        '
        'SplitPrincipalDetallePedido
        '
        Me.SplitPrincipalDetallePedido.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.SplitPrincipalDetallePedido.Appearance.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitPrincipalDetallePedido.Appearance.Options.UseBackColor = True
        Me.SplitPrincipalDetallePedido.Appearance.Options.UseFont = True
        Me.SplitPrincipalDetallePedido.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitPrincipalDetallePedido.AppearanceCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.SplitPrincipalDetallePedido.AppearanceCaption.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Gears
        Me.SplitPrincipalDetallePedido.AppearanceCaption.Options.UseFont = True
        Me.SplitPrincipalDetallePedido.AppearanceCaption.Options.UseImage = True
        Me.SplitPrincipalDetallePedido.CaptionLocation = DevExpress.Utils.Locations.Right
        Me.SplitPrincipalDetallePedido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitPrincipalDetallePedido.Location = New System.Drawing.Point(0, 124)
        Me.SplitPrincipalDetallePedido.Name = "SplitPrincipalDetallePedido"
        Me.SplitPrincipalDetallePedido.Panel1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitPrincipalDetallePedido.Panel1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.SplitPrincipalDetallePedido.Panel1.Appearance.Options.UseFont = True
        Me.SplitPrincipalDetallePedido.Panel1.ShowCaption = True
        Me.SplitPrincipalDetallePedido.Panel1.Text = "Información Asociada"
        Me.SplitPrincipalDetallePedido.Panel2.Appearance.BackColor = System.Drawing.Color.Silver
        Me.SplitPrincipalDetallePedido.Panel2.Appearance.BackColor2 = System.Drawing.Color.Black
        Me.SplitPrincipalDetallePedido.Panel2.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.SplitPrincipalDetallePedido.Panel2.Appearance.Options.UseBackColor = True
        Me.SplitPrincipalDetallePedido.Panel2.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitPrincipalDetallePedido.Panel2.AppearanceCaption.Options.UseFont = True
        Me.SplitPrincipalDetallePedido.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.SplitPrincipalDetallePedido.Panel2.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.SplitPrincipalDetallePedido.Panel2.Controls.Add(Me.SplitContainerControl2)
        Me.SplitPrincipalDetallePedido.Panel2.ShowCaption = True
        Me.SplitPrincipalDetallePedido.Panel2.Text = "Scanning del producto:"
        Me.SplitPrincipalDetallePedido.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
        Me.SplitPrincipalDetallePedido.Size = New System.Drawing.Size(1036, 392)
        Me.SplitPrincipalDetallePedido.SplitterPosition = 144
        Me.SplitPrincipalDetallePedido.TabIndex = 8
        Me.SplitPrincipalDetallePedido.Text = "SplitContainerControl1"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainerControl2.Appearance.Options.UseBackColor = True
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.PanelControl4)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.PanelControl3)
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.StatusStrip1)
        Me.SplitContainerControl2.Panel1.ShowCaption = True
        Me.SplitContainerControl2.Panel1.Text = "Ingreso desde scanner"
        Me.SplitContainerControl2.Panel2.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainerControl2.Panel2.AppearanceCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.SplitContainerControl2.Panel2.AppearanceCaption.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Gears
        Me.SplitContainerControl2.Panel2.AppearanceCaption.Options.UseFont = True
        Me.SplitContainerControl2.Panel2.AppearanceCaption.Options.UseImage = True
        Me.SplitContainerControl2.Panel2.AppearanceCaption.Options.UseTextOptions = True
        Me.SplitContainerControl2.Panel2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SplitContainerControl2.Panel2.AppearanceCaption.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Show
        Me.SplitContainerControl2.Panel2.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.SplitContainerControl2.Panel2.AppearanceCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.SplitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SplitContainerControl2.Panel2.CaptionLocation = DevExpress.Utils.Locations.Right
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.SplitInternoDetaille)
        Me.SplitContainerControl2.Panel2.ShowCaption = True
        Me.SplitContainerControl2.Panel2.Text = "Detalle del pedido original"
        Me.SplitContainerControl2.ShowCaption = True
        Me.SplitContainerControl2.Size = New System.Drawing.Size(1032, 367)
        Me.SplitContainerControl2.SplitterPosition = 739
        Me.SplitContainerControl2.TabIndex = 0
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'PanelControl4
        '
        Me.PanelControl4.Appearance.BackColor = System.Drawing.Color.White
        Me.PanelControl4.Appearance.Options.UseBackColor = True
        Me.PanelControl4.Controls.Add(Me.GC_ScannedDetail)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl4.Location = New System.Drawing.Point(0, 43)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(739, 302)
        Me.PanelControl4.TabIndex = 3
        '
        'GC_ScannedDetail
        '
        Me.GC_ScannedDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GC_ScannedDetail.Location = New System.Drawing.Point(2, 2)
        Me.GC_ScannedDetail.MainView = Me.GV_ScannedDetail
        Me.GC_ScannedDetail.Name = "GC_ScannedDetail"
        Me.GC_ScannedDetail.Size = New System.Drawing.Size(735, 298)
        Me.GC_ScannedDetail.TabIndex = 0
        Me.GC_ScannedDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GV_ScannedDetail})
        '
        'GV_ScannedDetail
        '
        Me.GV_ScannedDetail.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue
        Me.GV_ScannedDetail.Appearance.EvenRow.Options.UseBackColor = True
        Me.GV_ScannedDetail.Appearance.Row.Font = New System.Drawing.Font("Segoe Condensed", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GV_ScannedDetail.Appearance.Row.Options.UseFont = True
        Me.GV_ScannedDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GV_ScannedDetail.GridControl = Me.GC_ScannedDetail
        Me.GV_ScannedDetail.Name = "GV_ScannedDetail"
        Me.GV_ScannedDetail.OptionsCustomization.AllowColumnMoving = False
        Me.GV_ScannedDetail.OptionsCustomization.AllowColumnResizing = False
        Me.GV_ScannedDetail.OptionsCustomization.AllowFilter = False
        Me.GV_ScannedDetail.OptionsCustomization.AllowGroup = False
        Me.GV_ScannedDetail.OptionsCustomization.AllowRowSizing = True
        Me.GV_ScannedDetail.OptionsCustomization.AllowSort = False
        Me.GV_ScannedDetail.OptionsLayout.Columns.AddNewColumns = False
        Me.GV_ScannedDetail.OptionsLayout.Columns.StoreAllOptions = True
        Me.GV_ScannedDetail.OptionsLayout.Columns.StoreAppearance = True
        Me.GV_ScannedDetail.OptionsLayout.StoreAllOptions = True
        Me.GV_ScannedDetail.OptionsLayout.StoreAppearance = True
        Me.GV_ScannedDetail.OptionsView.ShowColumnHeaders = False
        Me.GV_ScannedDetail.OptionsView.ShowFooter = True
        Me.GV_ScannedDetail.OptionsView.ShowGroupPanel = False
        Me.GV_ScannedDetail.OptionsView.ShowHorzLines = False
        Me.GV_ScannedDetail.OptionsView.ShowPreviewLines = False
        Me.GV_ScannedDetail.OptionsView.ShowVertLines = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Codigo"
        Me.GridColumn1.FieldName = "MATERIAL_CODE"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.AllowFocus = False
        Me.GridColumn1.OptionsColumn.FixedWidth = True
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Descripcion"
        Me.GridColumn2.FieldName = "MATERIAL_DESCRIPTION"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.AllowFocus = False
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 400
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Cantidad"
        Me.GridColumn3.FieldName = "QUANTITY_UNITS"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.AllowFocus = False
        Me.GridColumn3.OptionsColumn.FixedWidth = True
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'PanelControl3
        '
        Me.PanelControl3.Appearance.BackColor = System.Drawing.Color.White
        Me.PanelControl3.Appearance.Options.UseBackColor = True
        Me.PanelControl3.Controls.Add(Me.txtScanLine)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(739, 43)
        Me.PanelControl3.TabIndex = 2
        '
        'txtScanLine
        '
        Me.txtScanLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtScanLine.Location = New System.Drawing.Point(2, 2)
        Me.txtScanLine.Name = "txtScanLine"
        Me.txtScanLine.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtScanLine.Properties.Appearance.Font = New System.Drawing.Font("Segoe Condensed", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScanLine.Properties.Appearance.Options.UseBackColor = True
        Me.txtScanLine.Properties.Appearance.Options.UseFont = True
        Me.txtScanLine.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightYellow
        Me.txtScanLine.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Black
        Me.txtScanLine.Properties.AppearanceFocused.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.txtScanLine.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.txtScanLine.Size = New System.Drawing.Size(735, 38)
        Me.txtScanLine.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus, Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1, Me.lblTimerStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 345)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(739, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Image = Global.WMSOnePlan_Client.My.Resources.Resources.ico_error
        Me.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(32, 17)
        Me.lblStatus.Text = "..."
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(85, 17)
        Me.ToolStripStatusLabel1.Text = "FRM@LINEA_2"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'lblTimerStatus
        '
        Me.lblTimerStatus.Name = "lblTimerStatus"
        Me.lblTimerStatus.Size = New System.Drawing.Size(16, 17)
        Me.lblTimerStatus.Text = "..."
        '
        'SplitInternoDetaille
        '
        Me.SplitInternoDetaille.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitInternoDetaille.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitInternoDetaille.Location = New System.Drawing.Point(0, 0)
        Me.SplitInternoDetaille.Name = "SplitInternoDetaille"
        Me.SplitInternoDetaille.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitInternoDetaille.Panel1
        '
        Me.SplitInternoDetaille.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitInternoDetaille.Panel1.Controls.Add(Me.GC_DetallePedido)
        '
        'SplitInternoDetaille.Panel2
        '
        Me.SplitInternoDetaille.Panel2.Controls.Add(Me.TabsAuxiliares)
        Me.SplitInternoDetaille.Size = New System.Drawing.Size(262, 363)
        Me.SplitInternoDetaille.SplitterDistance = 224
        Me.SplitInternoDetaille.TabIndex = 4
        '
        'GC_DetallePedido
        '
        Me.GC_DetallePedido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GC_DetallePedido.Font = New System.Drawing.Font("Segoe Condensed", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GC_DetallePedido.Location = New System.Drawing.Point(0, 0)
        Me.GC_DetallePedido.MainView = Me.GV_DetallePedido
        Me.GC_DetallePedido.Name = "GC_DetallePedido"
        Me.GC_DetallePedido.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.PickingProgress})
        Me.GC_DetallePedido.Size = New System.Drawing.Size(260, 222)
        Me.GC_DetallePedido.TabIndex = 2
        Me.GC_DetallePedido.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GV_DetallePedido})
        '
        'GV_DetallePedido
        '
        Me.GV_DetallePedido.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GV_DetallePedido.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GV_DetallePedido.Appearance.FooterPanel.Options.UseFont = True
        Me.GV_DetallePedido.Appearance.FooterPanel.Options.UseForeColor = True
        Me.GV_DetallePedido.Appearance.GroupFooter.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GV_DetallePedido.Appearance.GroupFooter.Options.UseFont = True
        Me.GV_DetallePedido.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GV_DetallePedido.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GV_DetallePedido.ColumnPanelRowHeight = 35
        Me.GV_DetallePedido.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCodigo, Me.colDescription, Me.colCantidadPedido, Me.colCantidadScaned, Me.colCantidadPicked, Me.colPercPicked, Me.colPendiente})
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.YellowGreen
        StyleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.LightGreen
        StyleFormatCondition1.Appearance.Font = New System.Drawing.Font("Segoe Condensed", 9.75!, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        StyleFormatCondition1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        StyleFormatCondition1.Appearance.Options.UseBackColor = True
        StyleFormatCondition1.Appearance.Options.UseFont = True
        StyleFormatCondition1.ApplyToRow = True
        StyleFormatCondition1.Column = Me.colPendiente
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition1.Tag = "0"
        StyleFormatCondition1.Value1 = 0
        StyleFormatCondition1.Value2 = "0"
        Me.GV_DetallePedido.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1})
        Me.GV_DetallePedido.GridControl = Me.GC_DetallePedido
        Me.GV_DetallePedido.Name = "GV_DetallePedido"
        Me.GV_DetallePedido.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GV_DetallePedido.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GV_DetallePedido.OptionsSelection.UseIndicatorForSelection = False
        Me.GV_DetallePedido.OptionsView.ShowAutoFilterRow = True
        Me.GV_DetallePedido.OptionsView.ShowFooter = True
        Me.GV_DetallePedido.OptionsView.ShowGroupPanel = False
        '
        'colCodigo
        '
        Me.colCodigo.AppearanceCell.Font = New System.Drawing.Font("Segoe Condensed", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCodigo.Caption = "Codigo"
        Me.colCodigo.FieldName = "MATERIAL_ID"
        Me.colCodigo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.OptionsColumn.AllowEdit = False
        Me.colCodigo.OptionsColumn.AllowFocus = False
        Me.colCodigo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colCodigo.OptionsColumn.AllowIncrementalSearch = False
        Me.colCodigo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.colCodigo.OptionsColumn.AllowMove = False
        Me.colCodigo.OptionsColumn.AllowSize = False
        Me.colCodigo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[True]
        Me.colCodigo.OptionsColumn.ReadOnly = True
        Me.colCodigo.OptionsFilter.AllowAutoFilter = False
        Me.colCodigo.OptionsFilter.AllowFilter = False
        Me.colCodigo.OptionsFilter.ImmediateUpdateAutoFilter = False
        Me.colCodigo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.colCodigo.Visible = True
        Me.colCodigo.VisibleIndex = 0
        Me.colCodigo.Width = 47
        '
        'colDescription
        '
        Me.colDescription.AppearanceCell.Font = New System.Drawing.Font("Segoe Condensed", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colDescription.AppearanceHeader.Options.UseTextOptions = True
        Me.colDescription.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colDescription.Caption = "Descripcion"
        Me.colDescription.FieldName = "MATERIAL_NAME"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.OptionsColumn.AllowEdit = False
        Me.colDescription.OptionsColumn.AllowFocus = False
        Me.colDescription.OptionsColumn.ReadOnly = True
        Me.colDescription.Visible = True
        Me.colDescription.VisibleIndex = 1
        Me.colDescription.Width = 186
        '
        'colCantidadPedido
        '
        Me.colCantidadPedido.AppearanceCell.Font = New System.Drawing.Font("Segoe Condensed", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCantidadPedido.AppearanceHeader.Options.UseTextOptions = True
        Me.colCantidadPedido.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colCantidadPedido.Caption = "Unidades Pedidas"
        Me.colCantidadPedido.FieldName = "ERP_QTY"
        Me.colCantidadPedido.Name = "colCantidadPedido"
        Me.colCantidadPedido.OptionsColumn.AllowEdit = False
        Me.colCantidadPedido.OptionsColumn.AllowFocus = False
        Me.colCantidadPedido.OptionsColumn.ReadOnly = True
        Me.colCantidadPedido.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.colCantidadPedido.Visible = True
        Me.colCantidadPedido.VisibleIndex = 2
        Me.colCantidadPedido.Width = 45
        '
        'colCantidadScaned
        '
        Me.colCantidadScaned.AppearanceCell.Font = New System.Drawing.Font("Segoe Condensed", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCantidadScaned.AppearanceCell.Options.UseFont = True
        Me.colCantidadScaned.AppearanceHeader.Options.UseTextOptions = True
        Me.colCantidadScaned.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colCantidadScaned.Caption = "Unidades Escaneadas"
        Me.colCantidadScaned.FieldName = "QTY_CONS"
        Me.colCantidadScaned.Name = "colCantidadScaned"
        Me.colCantidadScaned.OptionsColumn.AllowEdit = False
        Me.colCantidadScaned.OptionsColumn.AllowFocus = False
        Me.colCantidadScaned.OptionsColumn.ReadOnly = True
        Me.colCantidadScaned.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.colCantidadScaned.Visible = True
        Me.colCantidadScaned.VisibleIndex = 3
        Me.colCantidadScaned.Width = 50
        '
        'colCantidadPicked
        '
        Me.colCantidadPicked.AppearanceCell.Font = New System.Drawing.Font("Segoe Condensed", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCantidadPicked.Caption = "Pick"
        Me.colCantidadPicked.FieldName = "QTY_PICKED"
        Me.colCantidadPicked.Name = "colCantidadPicked"
        Me.colCantidadPicked.OptionsColumn.AllowEdit = False
        Me.colCantidadPicked.OptionsColumn.AllowFocus = False
        Me.colCantidadPicked.OptionsColumn.FixedWidth = True
        Me.colCantidadPicked.OptionsColumn.ReadOnly = True
        Me.colCantidadPicked.Width = 40
        '
        'colPercPicked
        '
        Me.colPercPicked.AppearanceCell.Font = New System.Drawing.Font("Segoe Condensed", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colPercPicked.Caption = "%Pick"
        Me.colPercPicked.ColumnEdit = Me.PickingProgress
        Me.colPercPicked.FieldName = "PERC_PICK"
        Me.colPercPicked.Name = "colPercPicked"
        '
        'PickingProgress
        '
        Me.PickingProgress.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PickingProgress.Name = "PickingProgress"
        Me.PickingProgress.NullText = "0"
        Me.PickingProgress.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
        Me.PickingProgress.ShowTitle = True
        Me.PickingProgress.Step = 5
        '
        'TabsAuxiliares
        '
        Me.TabsAuxiliares.AppearancePage.Header.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.TabsAuxiliares.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabsAuxiliares.Location = New System.Drawing.Point(0, 0)
        Me.TabsAuxiliares.Name = "TabsAuxiliares"
        Me.TabsAuxiliares.SelectedTabPage = Me.XtraTabPage_PendingBins
        Me.TabsAuxiliares.Size = New System.Drawing.Size(260, 133)
        Me.TabsAuxiliares.TabIndex = 3
        Me.TabsAuxiliares.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage_PendingBins, Me.XtraTabPage_Boxes, Me.XtraTabPage_Picking, Me.XtraTabPage_Que})
        '
        'XtraTabPage_PendingBins
        '
        Me.XtraTabPage_PendingBins.Appearance.Header.Image = Global.WMSOnePlan_Client.My.Resources.Resources.bold
        Me.XtraTabPage_PendingBins.Appearance.Header.Options.UseImage = True
        Me.XtraTabPage_PendingBins.AutoScroll = True
        Me.XtraTabPage_PendingBins.Controls.Add(Me.GridControl_Bins)
        Me.XtraTabPage_PendingBins.Name = "XtraTabPage_PendingBins"
        Me.XtraTabPage_PendingBins.PageVisible = False
        Me.XtraTabPage_PendingBins.Size = New System.Drawing.Size(254, 107)
        Me.XtraTabPage_PendingBins.Text = "Bins pendientes"
        '
        'GridControl_Bins
        '
        Me.GridControl_Bins.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl_Bins.Location = New System.Drawing.Point(0, 0)
        Me.GridControl_Bins.MainView = Me.GV_Bins
        Me.GridControl_Bins.Name = "GridControl_Bins"
        Me.GridControl_Bins.Size = New System.Drawing.Size(254, 107)
        Me.GridControl_Bins.TabIndex = 1
        Me.GridControl_Bins.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GV_Bins})
        '
        'GV_Bins
        '
        Me.GV_Bins.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn4, Me.GridColumn5})
        Me.GV_Bins.GridControl = Me.GridControl_Bins
        Me.GV_Bins.Name = "GV_Bins"
        Me.GV_Bins.OptionsView.ShowGroupPanel = False
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Bin"
        Me.GridColumn4.FieldName = "BIN_ID"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.AllowFocus = False
        Me.GridColumn4.OptionsColumn.AllowSize = False
        Me.GridColumn4.OptionsColumn.FixedWidth = True
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        Me.GridColumn4.Width = 57
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "UltimoOperador"
        Me.GridColumn5.FieldName = "LOGIN_NAME"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.AllowFocus = False
        Me.GridColumn5.OptionsColumn.AllowSize = False
        Me.GridColumn5.OptionsColumn.FixedWidth = True
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 190
        '
        'XtraTabPage_Boxes
        '
        Me.XtraTabPage_Boxes.Controls.Add(Me.GC_Boxes)
        Me.XtraTabPage_Boxes.Name = "XtraTabPage_Boxes"
        Me.XtraTabPage_Boxes.Size = New System.Drawing.Size(254, 107)
        Me.XtraTabPage_Boxes.Text = "Cajas Generadas"
        '
        'GC_Boxes
        '
        Me.GC_Boxes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GC_Boxes.Location = New System.Drawing.Point(0, 0)
        Me.GC_Boxes.MainView = Me.GV_Boxes
        Me.GC_Boxes.Name = "GC_Boxes"
        Me.GC_Boxes.Size = New System.Drawing.Size(254, 107)
        Me.GC_Boxes.TabIndex = 0
        Me.GC_Boxes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GV_Boxes})
        '
        'GV_Boxes
        '
        Me.GV_Boxes.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCaja})
        Me.GV_Boxes.GridControl = Me.GC_Boxes
        Me.GV_Boxes.Name = "GV_Boxes"
        Me.GV_Boxes.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GV_Boxes.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GV_Boxes.OptionsView.ShowAutoFilterRow = True
        Me.GV_Boxes.OptionsView.ShowGroupPanel = False
        '
        'colCaja
        '
        Me.colCaja.Caption = "Caja"
        Me.colCaja.FieldName = "BOX_ID"
        Me.colCaja.Name = "colCaja"
        Me.colCaja.OptionsColumn.AllowEdit = False
        Me.colCaja.OptionsColumn.AllowFocus = False
        Me.colCaja.OptionsColumn.ReadOnly = True
        Me.colCaja.OptionsFilter.AllowFilter = False
        Me.colCaja.Visible = True
        Me.colCaja.VisibleIndex = 0
        '
        'XtraTabPage_Picking
        '
        Me.XtraTabPage_Picking.Name = "XtraTabPage_Picking"
        Me.XtraTabPage_Picking.PageVisible = False
        Me.XtraTabPage_Picking.Size = New System.Drawing.Size(254, 107)
        Me.XtraTabPage_Picking.Text = "Picking Asociado"
        '
        'XtraTabPage_Que
        '
        Me.XtraTabPage_Que.Name = "XtraTabPage_Que"
        Me.XtraTabPage_Que.PageVisible = False
        Me.XtraTabPage_Que.Size = New System.Drawing.Size(254, 107)
        Me.XtraTabPage_Que.Text = "Pedidos en cola"
        '
        'Timer_Bins
        '
        Me.Timer_Bins.Interval = 5000
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.Offset = 142
        Me.Bar1.Text = "Tools"
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2, Me.Bar4})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.cmbLines})
        Me.BarManager1.MaxItemId = 2
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.BarManager1.StatusBar = Me.Bar4
        '
        'Bar2
        '
        Me.Bar2.BarName = "Tools"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.FloatLocation = New System.Drawing.Point(42, 121)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, Me.cmbLines, "", False, True, True, 82)})
        Me.Bar2.Text = "Tools"
        Me.Bar2.Visible = False
        '
        'cmbLines
        '
        Me.cmbLines.Caption = "Consolidando en: "
        Me.cmbLines.Edit = Me.RepositoryItemComboBox1
        Me.cmbLines.EditValue = "LINEA_2"
        Me.cmbLines.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.Right_Small
        Me.cmbLines.Id = 0
        Me.cmbLines.Name = "cmbLines"
        Me.cmbLines.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Items.AddRange(New Object() {"LINEA_1", "LINEA_2", "LINEA_3"})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'Bar4
        '
        Me.Bar4.BarName = "Status bar"
        Me.Bar4.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar4.DockCol = 0
        Me.Bar4.DockRow = 0
        Me.Bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar4.OptionsBar.AllowQuickCustomization = False
        Me.Bar4.OptionsBar.DrawDragBorder = False
        Me.Bar4.OptionsBar.UseWholeRow = True
        Me.Bar4.Text = "Status bar"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1036, 31)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 516)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1036, 23)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 31)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 485)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1036, 31)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 485)
        '
        'frmMainConsolidate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1036, 539)
        Me.Controls.Add(Me.SplitPrincipalDetallePedido)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmMainConsolidate"
        Me.Text = "frmMainConsolidate"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        Me.PanelControl5.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.SplitPrincipalDetallePedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPrincipalDetallePedido.ResumeLayout(False)
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.GC_ScannedDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GV_ScannedDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.txtScanLine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitInternoDetaille.Panel1.ResumeLayout(False)
        Me.SplitInternoDetaille.Panel2.ResumeLayout(False)
        Me.SplitInternoDetaille.ResumeLayout(False)
        CType(Me.GC_DetallePedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GV_DetallePedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PickingProgress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabsAuxiliares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabsAuxiliares.ResumeLayout(False)
        Me.XtraTabPage_PendingBins.ResumeLayout(False)
        CType(Me.GridControl_Bins, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GV_Bins, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage_Boxes.ResumeLayout(False)
        CType(Me.GC_Boxes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GV_Boxes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnCloseDoc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitPrincipalDetallePedido As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GC_ScannedDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GV_ScannedDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtScanLine As DevExpress.XtraEditors.TextEdit
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblTimerStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitInternoDetaille As System.Windows.Forms.SplitContainer
    Friend WithEvents GC_DetallePedido As DevExpress.XtraGrid.GridControl
    Friend WithEvents GV_DetallePedido As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCodigo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCantidadPedido As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCantidadScaned As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCantidadPicked As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPercPicked As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PickingProgress As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents colPendiente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TabsAuxiliares As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage_PendingBins As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl_Bins As DevExpress.XtraGrid.GridControl
    Friend WithEvents GV_Bins As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabPage_Boxes As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage_Picking As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage_Que As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btnCloseBox As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDiffs As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblSector As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCustInfo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Timer_Bins As System.Windows.Forms.Timer
    Friend WithEvents GC_Boxes As DevExpress.XtraGrid.GridControl
    Friend WithEvents GV_Boxes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCaja As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblCaja As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCustAddress As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblPorcentajeCuadre As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPedidoID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents cmbLines As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Bar4 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnPrintLastLabel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPrintLastInvoice As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblRuta As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnDailyReport As DevExpress.XtraEditors.SimpleButton
End Class
