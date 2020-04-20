<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryDocs
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.btnExcel = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnPrint = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnPrintPolizaLabel = New DevExpress.XtraBars.BarButtonItem()
        Me.btnUpdate = New DevExpress.XtraBars.BarButtonItem()
        Me.lblUpdate = New DevExpress.XtraBars.BarStaticItem()
        Me.btnSaveLayout = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colWAREHOUSE_REGIMEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODIGO_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNUMERO_DUA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENT_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmbCLIENTE = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.RepositoryItemGridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCONSIGNATARIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBULTOS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCUSTOMS_AMOUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDAI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIVA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSKU_DESC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNET_WEIGTH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colWEIGTH_UNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmbUNIDAD_PESO = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colVOLUME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVOLUME_UNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmbUnidadVolumen = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colUNIDAD_CANTIDAD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMBUNIDADCANTIDAD = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colNUMERO_ORDEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA_DOCUMENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BarLargeButtonItem1 = New DevExpress.XtraBars.BarLargeButtonItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCLIENTE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUNIDAD_PESO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUnidadVolumen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMBUNIDADCANTIDAD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnExcel, Me.btnPrint, Me.btnUpdate, Me.lblUpdate, Me.btnPrintPolizaLabel, Me.btnSaveLayout})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 6
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnExcel), New DevExpress.XtraBars.LinkPersistInfo(Me.btnPrint), New DevExpress.XtraBars.LinkPersistInfo(Me.btnPrintPolizaLabel), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnUpdate, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.lblUpdate), New DevExpress.XtraBars.LinkPersistInfo(Me.btnSaveLayout)})
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'btnExcel
        '
        Me.btnExcel.Caption = "&Excel"
        Me.btnExcel.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right
        Me.btnExcel.Id = 0
        Me.btnExcel.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.iconExcel
        Me.btnExcel.Name = "btnExcel"
        '
        'btnPrint
        '
        Me.btnPrint.Caption = "&Imprimir"
        Me.btnPrint.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right
        Me.btnPrint.Id = 1
        Me.btnPrint.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.file_extension_pdf
        Me.btnPrint.Name = "btnPrint"
        '
        'btnPrintPolizaLabel
        '
        Me.btnPrintPolizaLabel.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.printer
        Me.btnPrintPolizaLabel.Id = 4
        Me.btnPrintPolizaLabel.Name = "btnPrintPolizaLabel"
        ToolTipItem1.Text = "Imprimir Etiqueta"
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.btnPrintPolizaLabel.SuperTip = SuperToolTip1
        '
        'btnUpdate
        '
        Me.btnUpdate.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.DisplayForReview_Small
        Me.btnUpdate.Id = 2
        Me.btnUpdate.Name = "btnUpdate"
        '
        'lblUpdate
        '
        Me.lblUpdate.Caption = "Actualizacion Manual"
        Me.lblUpdate.Id = 3
        Me.lblUpdate.Name = "lblUpdate"
        Me.lblUpdate.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'btnSaveLayout
        '
        Me.btnSaveLayout.Caption = "Grabar"
        Me.btnSaveLayout.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.SaveAsSmall
        Me.btnSaveLayout.Id = 5
        Me.btnSaveLayout.Name = "btnSaveLayout"
        ToolTipItem2.Text = "Grabar el diseño del grid"
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.btnSaveLayout.SuperTip = SuperToolTip2
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(788, 40)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 407)
        Me.barDockControlBottom.Size = New System.Drawing.Size(788, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 40)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 367)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(788, 40)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 367)
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 40)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.BarManager1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cmbCLIENTE, Me.cmbUnidadVolumen, Me.cmbUNIDAD_PESO, Me.CMBUNIDADCANTIDAD})
        Me.GridControl1.Size = New System.Drawing.Size(788, 367)
        Me.GridControl1.TabIndex = 4
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colWAREHOUSE_REGIMEN, Me.colCODIGO_POLIZA, Me.colNUMERO_DUA, Me.colCLIENT_CODE, Me.colCONSIGNATARIO, Me.colBULTOS, Me.colQTY, Me.colCUSTOMS_AMOUNT, Me.colDAI, Me.colIVA, Me.colSKU_DESC, Me.colNET_WEIGTH, Me.colWEIGTH_UNIT, Me.colVOLUME, Me.colVOLUME_UNIT, Me.colUNIDAD_CANTIDAD, Me.colNUMERO_ORDEN, Me.colFECHA_DOCUMENTO, Me.colTOTAL})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL", Me.colTOTAL, "(TOTAL = {0:n2})")})
        Me.GridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'colWAREHOUSE_REGIMEN
        '
        Me.colWAREHOUSE_REGIMEN.Caption = "REGIMEN ALMACEN"
        Me.colWAREHOUSE_REGIMEN.FieldName = "WAREHOUSE_REGIMEN"
        Me.colWAREHOUSE_REGIMEN.Name = "colWAREHOUSE_REGIMEN"
        Me.colWAREHOUSE_REGIMEN.Visible = True
        Me.colWAREHOUSE_REGIMEN.VisibleIndex = 0
        '
        'colCODIGO_POLIZA
        '
        Me.colCODIGO_POLIZA.Caption = "CODIGO POLIZA/DOCUMENTO"
        Me.colCODIGO_POLIZA.FieldName = "CODIGO_POLIZA"
        Me.colCODIGO_POLIZA.Name = "colCODIGO_POLIZA"
        Me.colCODIGO_POLIZA.Visible = True
        Me.colCODIGO_POLIZA.VisibleIndex = 1
        '
        'colNUMERO_DUA
        '
        Me.colNUMERO_DUA.Caption = "NUMERO DUA"
        Me.colNUMERO_DUA.FieldName = "NUMERO_DUA"
        Me.colNUMERO_DUA.Name = "colNUMERO_DUA"
        '
        'colCLIENT_CODE
        '
        Me.colCLIENT_CODE.Caption = "CLIENTE"
        Me.colCLIENT_CODE.ColumnEdit = Me.cmbCLIENTE
        Me.colCLIENT_CODE.FieldName = "CLIENT_CODE"
        Me.colCLIENT_CODE.Name = "colCLIENT_CODE"
        Me.colCLIENT_CODE.Visible = True
        Me.colCLIENT_CODE.VisibleIndex = 2
        '
        'cmbCLIENTE
        '
        Me.cmbCLIENTE.AutoHeight = False
        Me.cmbCLIENTE.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbCLIENTE.Name = "cmbCLIENTE"
        Me.cmbCLIENTE.View = Me.RepositoryItemGridLookUpEdit1View
        '
        'RepositoryItemGridLookUpEdit1View
        '
        Me.RepositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemGridLookUpEdit1View.Name = "RepositoryItemGridLookUpEdit1View"
        Me.RepositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colCONSIGNATARIO
        '
        Me.colCONSIGNATARIO.Caption = "CONSIGNATARIO"
        Me.colCONSIGNATARIO.ColumnEdit = Me.cmbCLIENTE
        Me.colCONSIGNATARIO.FieldName = "CONSIGNATARIO_CODIGO"
        Me.colCONSIGNATARIO.Name = "colCONSIGNATARIO"
        '
        'colBULTOS
        '
        Me.colBULTOS.Caption = "BULTOS"
        Me.colBULTOS.DisplayFormat.FormatString = "{0:n0}"
        Me.colBULTOS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colBULTOS.FieldName = "BULTOS"
        Me.colBULTOS.Name = "colBULTOS"
        Me.colBULTOS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BULTOS", "(Bultos = {0:n2})")})
        Me.colBULTOS.Visible = True
        Me.colBULTOS.VisibleIndex = 5
        '
        'colQTY
        '
        Me.colQTY.Caption = "CANTIDAD"
        Me.colQTY.DisplayFormat.FormatString = "{0:n2}"
        Me.colQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colQTY.FieldName = "QTY"
        Me.colQTY.Name = "colQTY"
        Me.colQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY", "(Cantidad = {0:n2})")})
        Me.colQTY.Visible = True
        Me.colQTY.VisibleIndex = 4
        '
        'colCUSTOMS_AMOUNT
        '
        Me.colCUSTOMS_AMOUNT.Caption = "VALOR ADUANA"
        Me.colCUSTOMS_AMOUNT.FieldName = "CUSTOMS_AMOUNT"
        Me.colCUSTOMS_AMOUNT.Name = "colCUSTOMS_AMOUNT"
        Me.colCUSTOMS_AMOUNT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CUSTOMS_AMOUNT", "(Aduana = {0:n2})")})
        Me.colCUSTOMS_AMOUNT.Visible = True
        Me.colCUSTOMS_AMOUNT.VisibleIndex = 6
        '
        'colDAI
        '
        Me.colDAI.Caption = "DAI"
        Me.colDAI.DisplayFormat.FormatString = "{0:n2}"
        Me.colDAI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDAI.FieldName = "DAI"
        Me.colDAI.Name = "colDAI"
        Me.colDAI.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DAI", "(DAI = {0:n2})")})
        Me.colDAI.Visible = True
        Me.colDAI.VisibleIndex = 7
        '
        'colIVA
        '
        Me.colIVA.Caption = "IVA"
        Me.colIVA.DisplayFormat.FormatString = "{0:n2}"
        Me.colIVA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colIVA.FieldName = "IVA"
        Me.colIVA.Name = "colIVA"
        Me.colIVA.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IVA", "(IVA = {0:n2})")})
        Me.colIVA.Visible = True
        Me.colIVA.VisibleIndex = 8
        '
        'colSKU_DESC
        '
        Me.colSKU_DESC.Caption = "PRODUCTO"
        Me.colSKU_DESC.FieldName = "SKU_DESCRIPTION"
        Me.colSKU_DESC.Name = "colSKU_DESC"
        Me.colSKU_DESC.Visible = True
        Me.colSKU_DESC.VisibleIndex = 3
        '
        'colNET_WEIGTH
        '
        Me.colNET_WEIGTH.Caption = "PESO NETO"
        Me.colNET_WEIGTH.FieldName = "NET_WEIGTH"
        Me.colNET_WEIGTH.Name = "colNET_WEIGTH"
        '
        'colWEIGTH_UNIT
        '
        Me.colWEIGTH_UNIT.Caption = "UNIDAD DE PESO"
        Me.colWEIGTH_UNIT.ColumnEdit = Me.cmbUNIDAD_PESO
        Me.colWEIGTH_UNIT.FieldName = "WEIGTH_UNIT"
        Me.colWEIGTH_UNIT.Name = "colWEIGTH_UNIT"
        '
        'cmbUNIDAD_PESO
        '
        Me.cmbUNIDAD_PESO.AutoHeight = False
        Me.cmbUNIDAD_PESO.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbUNIDAD_PESO.Name = "cmbUNIDAD_PESO"
        Me.cmbUNIDAD_PESO.View = Me.GridView3
        '
        'GridView3
        '
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'colVOLUME
        '
        Me.colVOLUME.Caption = "VOLUMEN"
        Me.colVOLUME.FieldName = "VOLUME"
        Me.colVOLUME.Name = "colVOLUME"
        '
        'colVOLUME_UNIT
        '
        Me.colVOLUME_UNIT.Caption = "UNIDAD DE VOLUMEN"
        Me.colVOLUME_UNIT.ColumnEdit = Me.cmbUnidadVolumen
        Me.colVOLUME_UNIT.FieldName = "VOLUME_UNIT"
        Me.colVOLUME_UNIT.Name = "colVOLUME_UNIT"
        '
        'cmbUnidadVolumen
        '
        Me.cmbUnidadVolumen.AutoHeight = False
        Me.cmbUnidadVolumen.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbUnidadVolumen.Name = "cmbUnidadVolumen"
        Me.cmbUnidadVolumen.View = Me.GridView2
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'colUNIDAD_CANTIDAD
        '
        Me.colUNIDAD_CANTIDAD.Caption = "UNIDAD CANTIDAD"
        Me.colUNIDAD_CANTIDAD.ColumnEdit = Me.CMBUNIDADCANTIDAD
        Me.colUNIDAD_CANTIDAD.FieldName = "QTY_UNIT"
        Me.colUNIDAD_CANTIDAD.Name = "colUNIDAD_CANTIDAD"
        '
        'CMBUNIDADCANTIDAD
        '
        Me.CMBUNIDADCANTIDAD.AutoHeight = False
        Me.CMBUNIDADCANTIDAD.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CMBUNIDADCANTIDAD.Name = "CMBUNIDADCANTIDAD"
        Me.CMBUNIDADCANTIDAD.View = Me.GridView4
        '
        'GridView4
        '
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'colNUMERO_ORDEN
        '
        Me.colNUMERO_ORDEN.Caption = "NumeroOrden"
        Me.colNUMERO_ORDEN.FieldName = "NUMERO_ORDEN"
        Me.colNUMERO_ORDEN.Name = "colNUMERO_ORDEN"
        Me.colNUMERO_ORDEN.OptionsColumn.AllowEdit = False
        Me.colNUMERO_ORDEN.OptionsColumn.ReadOnly = True
        '
        'colFECHA_DOCUMENTO
        '
        Me.colFECHA_DOCUMENTO.Caption = "FECHA DOCUMENTO"
        Me.colFECHA_DOCUMENTO.DisplayFormat.FormatString = "d"
        Me.colFECHA_DOCUMENTO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colFECHA_DOCUMENTO.FieldName = "FECHA_DOCUMENTO"
        Me.colFECHA_DOCUMENTO.Name = "colFECHA_DOCUMENTO"
        Me.colFECHA_DOCUMENTO.OptionsColumn.AllowEdit = False
        Me.colFECHA_DOCUMENTO.OptionsColumn.ReadOnly = True
        '
        'colTOTAL
        '
        Me.colTOTAL.Caption = "TOTAL"
        Me.colTOTAL.DisplayFormat.FormatString = "{0:n2}"
        Me.colTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colTOTAL.FieldName = "TOTAL"
        Me.colTOTAL.Name = "colTOTAL"
        Me.colTOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL", "(TOTAL = {0:n2})")})
        Me.colTOTAL.Visible = True
        Me.colTOTAL.VisibleIndex = 9
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'Timer1
        '
        Me.Timer1.Interval = 10000
        '
        'BarLargeButtonItem1
        '
        Me.BarLargeButtonItem1.Caption = "&Imprimir"
        Me.BarLargeButtonItem1.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right
        Me.BarLargeButtonItem1.Id = 1
        Me.BarLargeButtonItem1.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.print_large
        Me.BarLargeButtonItem1.Name = "BarLargeButtonItem1"
        '
        'frmInventoryDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 407)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmInventoryDocs"
        Me.Text = "Inventario por Documentos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCLIENTE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUNIDAD_PESO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUnidadVolumen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMBUNIDADCANTIDAD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnExcel As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnPrint As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents colWAREHOUSE_REGIMEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODIGO_POLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNUMERO_DUA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENT_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbCLIENTE As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents RepositoryItemGridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCONSIGNATARIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBULTOS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCUSTOMS_AMOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDAI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIVA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSKU_DESC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNET_WEIGTH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colWEIGTH_UNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVOLUME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVOLUME_UNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbUNIDAD_PESO As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbUnidadVolumen As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colUNIDAD_CANTIDAD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBUNIDADCANTIDAD As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colNUMERO_ORDEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA_DOCUMENTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnUpdate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblUpdate As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents btnPrintPolizaLabel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarLargeButtonItem1 As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents colTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnSaveLayout As DevExpress.XtraBars.BarButtonItem
End Class
