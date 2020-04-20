<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAprobacionRecepcion
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
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAprobacionRecepcion))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.colNEWSKUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colESTADO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.GridRECEPCIONES = New DevExpress.XtraGrid.GridControl()
        Me.GridViewRECEPCIONES = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colRECEPCION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRECEPTOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPOLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTRANS_DESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMATERIAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNUMERO_ORDEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNUMERO_DUA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.bnPrintRec = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnPrint = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnAsociar = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.BarLargeButtonItem1 = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnDel = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnSKU = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnRazonamiento = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnActualizacion = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GridPOLIZADET = New DevExpress.XtraGrid.GridControl()
        Me.GridViewPOLIZADET = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colLINEAPOLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESCRIPCIONPOLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBULTOSPOLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCANTIDADPOLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GridRECDET = New DevExpress.XtraGrid.GridControl()
        Me.GridViewRECDET = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSKU_TRAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESCSKU_TRAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCANTIDAD_TRAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GridMATCH = New DevExpress.XtraGrid.GridControl()
        Me.GridViewMATCH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTRANS_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLINENO_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDOC_IDPTM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSKU_DESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMATERIAL_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMATERIAL_DESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQTY_TRANS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQTY_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBULTOS_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLAST_UPDATED_BY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLAST_UPDATED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODIGO_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.PrintableComponentLink2 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.GridRECEPCIONES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewRECEPCIONES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GridPOLIZADET, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPOLIZADET, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridRECDET, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewRECDET, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridMATCH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewMATCH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colNEWSKUS
        '
        Me.colNEWSKUS.Caption = "PRODUCTOS NUEVOS"
        Me.colNEWSKUS.FieldName = "STATUS"
        Me.colNEWSKUS.Name = "colNEWSKUS"
        Me.colNEWSKUS.Visible = True
        Me.colNEWSKUS.VisibleIndex = 5
        '
        'colESTADO
        '
        Me.colESTADO.Caption = "ESTADO"
        Me.colESTADO.FieldName = "STATUS"
        Me.colESTADO.Name = "colESTADO"
        Me.colESTADO.Visible = True
        Me.colESTADO.VisibleIndex = 3
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Items.AddRange(New Object() {"P", "A"})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 40)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1197, 613)
        Me.XtraTabControl1.TabIndex = 0
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2, Me.XtraTabPage3})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.GridRECEPCIONES)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1191, 585)
        Me.XtraTabPage1.Text = "Listado de Recepciones"
        '
        'GridRECEPCIONES
        '
        Me.GridRECEPCIONES.AllowDrop = True
        Me.GridRECEPCIONES.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridRECEPCIONES.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridRECEPCIONES.Location = New System.Drawing.Point(0, 0)
        Me.GridRECEPCIONES.MainView = Me.GridViewRECEPCIONES
        Me.GridRECEPCIONES.MenuManager = Me.BarManager1
        Me.GridRECEPCIONES.Name = "GridRECEPCIONES"
        Me.GridRECEPCIONES.Size = New System.Drawing.Size(1191, 585)
        Me.GridRECEPCIONES.TabIndex = 0
        Me.GridRECEPCIONES.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewRECEPCIONES})
        '
        'GridViewRECEPCIONES
        '
        Me.GridViewRECEPCIONES.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colRECEPCION, Me.colRECEPTOR, Me.colPOLIZA, Me.colCLIENTE, Me.colTRANS_DESCRIPTION, Me.colNEWSKUS, Me.colMATERIAL, Me.colNUMERO_ORDEN, Me.colNUMERO_DUA})
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        StyleFormatCondition3.Appearance.Options.UseBackColor = True
        StyleFormatCondition3.Column = Me.colNEWSKUS
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition3.Value1 = "FOR_REVIEW"
        Me.GridViewRECEPCIONES.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition3})
        Me.GridViewRECEPCIONES.GridControl = Me.GridRECEPCIONES
        Me.GridViewRECEPCIONES.Name = "GridViewRECEPCIONES"
        Me.GridViewRECEPCIONES.OptionsView.ShowAutoFilterRow = True
        '
        'colRECEPCION
        '
        Me.colRECEPCION.Caption = "RECEPCION"
        Me.colRECEPCION.FieldName = "SERIAL_NUMBER"
        Me.colRECEPCION.Name = "colRECEPCION"
        Me.colRECEPCION.Visible = True
        Me.colRECEPCION.VisibleIndex = 0
        '
        'colRECEPTOR
        '
        Me.colRECEPTOR.Caption = "RECEPTOR"
        Me.colRECEPTOR.FieldName = "LOGIN_NAME"
        Me.colRECEPTOR.Name = "colRECEPTOR"
        Me.colRECEPTOR.Visible = True
        Me.colRECEPTOR.VisibleIndex = 1
        '
        'colPOLIZA
        '
        Me.colPOLIZA.Caption = "POLIZA/DOCUMENTO"
        Me.colPOLIZA.FieldName = "CODIGO_POLIZA"
        Me.colPOLIZA.Name = "colPOLIZA"
        Me.colPOLIZA.Visible = True
        Me.colPOLIZA.VisibleIndex = 2
        '
        'colCLIENTE
        '
        Me.colCLIENTE.Caption = "CLIENTE"
        Me.colCLIENTE.FieldName = "CLIENT_NAME"
        Me.colCLIENTE.Name = "colCLIENTE"
        Me.colCLIENTE.Visible = True
        Me.colCLIENTE.VisibleIndex = 3
        '
        'colTRANS_DESCRIPTION
        '
        Me.colTRANS_DESCRIPTION.Caption = "TIPO TRANSACCION"
        Me.colTRANS_DESCRIPTION.FieldName = "TRANS_DESCRIPTION"
        Me.colTRANS_DESCRIPTION.Name = "colTRANS_DESCRIPTION"
        Me.colTRANS_DESCRIPTION.Visible = True
        Me.colTRANS_DESCRIPTION.VisibleIndex = 4
        '
        'colMATERIAL
        '
        Me.colMATERIAL.Caption = "CODIGO PRODUCTO"
        Me.colMATERIAL.FieldName = "MATERIAL_CODE"
        Me.colMATERIAL.Name = "colMATERIAL"
        '
        'colNUMERO_ORDEN
        '
        Me.colNUMERO_ORDEN.Caption = "NUMERO ORDEN"
        Me.colNUMERO_ORDEN.FieldName = "NUMERO_ORDEN"
        Me.colNUMERO_ORDEN.Name = "colNUMERO_ORDEN"
        Me.colNUMERO_ORDEN.Visible = True
        Me.colNUMERO_ORDEN.VisibleIndex = 6
        '
        'colNUMERO_DUA
        '
        Me.colNUMERO_DUA.Caption = "NUMERO DUA"
        Me.colNUMERO_DUA.FieldName = "NUMERO_DUA"
        Me.colNUMERO_DUA.Name = "colNUMERO_DUA"
        Me.colNUMERO_DUA.Visible = True
        Me.colNUMERO_DUA.VisibleIndex = 7
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bnPrintRec, Me.btnPrint, Me.btnAsociar, Me.BarLargeButtonItem1, Me.btnDel, Me.btnSKU, Me.btnRazonamiento, Me.btnActualizacion})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 8
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.bnPrintRec, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnAsociar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarLargeButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnDel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnSKU, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnRazonamiento, "", False, True, False, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnActualizacion, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'bnPrintRec
        '
        Me.bnPrintRec.Caption = "Imprimir Recepcion"
        Me.bnPrintRec.Id = 0
        Me.bnPrintRec.Name = "bnPrintRec"
        Me.bnPrintRec.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnPrint
        '
        Me.btnPrint.Caption = "Imprimir"
        Me.btnPrint.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right
        Me.btnPrint.Glyph = CType(resources.GetObject("btnPrint.Glyph"), System.Drawing.Image)
        Me.btnPrint.Id = 1
        Me.btnPrint.Name = "btnPrint"
        '
        'btnAsociar
        '
        Me.btnAsociar.Caption = "&Asociar"
        Me.btnAsociar.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right
        Me.btnAsociar.Id = 2
        Me.btnAsociar.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A))
        Me.btnAsociar.LargeGlyph = CType(resources.GetObject("btnAsociar.LargeGlyph"), System.Drawing.Image)
        Me.btnAsociar.Name = "btnAsociar"
        '
        'BarLargeButtonItem1
        '
        Me.BarLargeButtonItem1.Caption = "Excel"
        Me.BarLargeButtonItem1.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right
        Me.BarLargeButtonItem1.Id = 3
        Me.BarLargeButtonItem1.LargeGlyph = CType(resources.GetObject("BarLargeButtonItem1.LargeGlyph"), System.Drawing.Image)
        Me.BarLargeButtonItem1.Name = "BarLargeButtonItem1"
        '
        'btnDel
        '
        Me.btnDel.Caption = "Eliminar"
        Me.btnDel.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right
        Me.btnDel.Id = 4
        Me.btnDel.LargeGlyph = CType(resources.GetObject("btnDel.LargeGlyph"), System.Drawing.Image)
        Me.btnDel.Name = "btnDel"
        '
        'btnSKU
        '
        Me.btnSKU.Caption = "&Productos"
        Me.btnSKU.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right
        Me.btnSKU.Id = 5
        Me.btnSKU.LargeGlyph = CType(resources.GetObject("btnSKU.LargeGlyph"), System.Drawing.Image)
        Me.btnSKU.Name = "btnSKU"
        '
        'btnRazonamiento
        '
        Me.btnRazonamiento.Caption = "&Razonamiento"
        Me.btnRazonamiento.Id = 6
        Me.btnRazonamiento.Name = "btnRazonamiento"
        '
        'btnActualizacion
        '
        Me.btnActualizacion.Caption = "Actualizacion Manual"
        Me.btnActualizacion.Glyph = CType(resources.GetObject("btnActualizacion.Glyph"), System.Drawing.Image)
        Me.btnActualizacion.Id = 7
        Me.btnActualizacion.Name = "btnActualizacion"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1197, 40)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 653)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1197, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 40)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 613)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1197, 40)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 613)
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.SplitContainerControl2)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1191, 585)
        Me.XtraTabPage2.Text = "Cuadre"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Horizontal = False
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.SplitContainerControl1)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.LabelControl3)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.GridMATCH)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(1191, 585)
        Me.SplitContainerControl2.SplitterPosition = 354
        Me.SplitContainerControl2.TabIndex = 1
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GridPOLIZADET)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.LabelControl2)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GridRECDET)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1191, 354)
        Me.SplitContainerControl1.SplitterPosition = 588
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(3, 3)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Lineas de la Poliza"
        '
        'GridPOLIZADET
        '
        Me.GridPOLIZADET.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPOLIZADET.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridPOLIZADET.Location = New System.Drawing.Point(0, 22)
        Me.GridPOLIZADET.MainView = Me.GridViewPOLIZADET
        Me.GridPOLIZADET.MenuManager = Me.BarManager1
        Me.GridPOLIZADET.Name = "GridPOLIZADET"
        Me.GridPOLIZADET.Size = New System.Drawing.Size(588, 332)
        Me.GridPOLIZADET.TabIndex = 0
        Me.GridPOLIZADET.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPOLIZADET})
        '
        'GridViewPOLIZADET
        '
        Me.GridViewPOLIZADET.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colLINEAPOLIZA, Me.colDESCRIPCIONPOLIZA, Me.colBULTOSPOLIZA, Me.colCANTIDADPOLIZA, Me.colDOC_ID})
        Me.GridViewPOLIZADET.GridControl = Me.GridPOLIZADET
        Me.GridViewPOLIZADET.Name = "GridViewPOLIZADET"
        Me.GridViewPOLIZADET.OptionsCustomization.AllowGroup = False
        Me.GridViewPOLIZADET.OptionsSelection.MultiSelect = True
        Me.GridViewPOLIZADET.OptionsView.ShowAutoFilterRow = True
        Me.GridViewPOLIZADET.OptionsView.ShowGroupPanel = False
        '
        'colLINEAPOLIZA
        '
        Me.colLINEAPOLIZA.Caption = "LINEA"
        Me.colLINEAPOLIZA.FieldName = "LINE_NUMBER"
        Me.colLINEAPOLIZA.Name = "colLINEAPOLIZA"
        Me.colLINEAPOLIZA.OptionsColumn.AllowEdit = False
        Me.colLINEAPOLIZA.Visible = True
        Me.colLINEAPOLIZA.VisibleIndex = 0
        '
        'colDESCRIPCIONPOLIZA
        '
        Me.colDESCRIPCIONPOLIZA.Caption = "DESCRIPCION"
        Me.colDESCRIPCIONPOLIZA.FieldName = "SKU_DESCRIPTION"
        Me.colDESCRIPCIONPOLIZA.Name = "colDESCRIPCIONPOLIZA"
        Me.colDESCRIPCIONPOLIZA.OptionsColumn.AllowEdit = False
        Me.colDESCRIPCIONPOLIZA.Visible = True
        Me.colDESCRIPCIONPOLIZA.VisibleIndex = 1
        '
        'colBULTOSPOLIZA
        '
        Me.colBULTOSPOLIZA.Caption = "BULTOS"
        Me.colBULTOSPOLIZA.FieldName = "BULTOS"
        Me.colBULTOSPOLIZA.Name = "colBULTOSPOLIZA"
        Me.colBULTOSPOLIZA.Visible = True
        Me.colBULTOSPOLIZA.VisibleIndex = 2
        '
        'colCANTIDADPOLIZA
        '
        Me.colCANTIDADPOLIZA.Caption = "CANTIDAD"
        Me.colCANTIDADPOLIZA.FieldName = "QTY"
        Me.colCANTIDADPOLIZA.Name = "colCANTIDADPOLIZA"
        Me.colCANTIDADPOLIZA.Visible = True
        Me.colCANTIDADPOLIZA.VisibleIndex = 3
        '
        'colDOC_ID
        '
        Me.colDOC_ID.Caption = "DOCUMENTO"
        Me.colDOC_ID.FieldName = "DOC_ID"
        Me.colDOC_ID.Name = "colDOC_ID"
        Me.colDOC_ID.OptionsColumn.AllowEdit = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(0, 3)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Recepcionado"
        '
        'GridRECDET
        '
        Me.GridRECDET.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridRECDET.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridRECDET.Location = New System.Drawing.Point(0, 22)
        Me.GridRECDET.MainView = Me.GridViewRECDET
        Me.GridRECDET.MenuManager = Me.BarManager1
        Me.GridRECDET.Name = "GridRECDET"
        Me.GridRECDET.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.GridRECDET.Size = New System.Drawing.Size(598, 332)
        Me.GridRECDET.TabIndex = 0
        Me.GridRECDET.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewRECDET})
        '
        'GridViewRECDET
        '
        Me.GridViewRECDET.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSKU_TRAN, Me.colDESCSKU_TRAN, Me.colCANTIDAD_TRAN, Me.colESTADO})
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Green
        StyleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.White
        StyleFormatCondition1.Appearance.Options.UseBackColor = True
        StyleFormatCondition1.Appearance.Options.UseForeColor = True
        StyleFormatCondition1.ApplyToRow = True
        StyleFormatCondition1.Column = Me.colESTADO
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition1.Tag = ""
        StyleFormatCondition1.Value1 = "MATCH"
        Me.GridViewRECDET.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1})
        Me.GridViewRECDET.GridControl = Me.GridRECDET
        Me.GridViewRECDET.Name = "GridViewRECDET"
        Me.GridViewRECDET.OptionsCustomization.AllowGroup = False
        Me.GridViewRECDET.OptionsSelection.MultiSelect = True
        Me.GridViewRECDET.OptionsView.ShowAutoFilterRow = True
        Me.GridViewRECDET.OptionsView.ShowGroupPanel = False
        Me.GridViewRECDET.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'colSKU_TRAN
        '
        Me.colSKU_TRAN.Caption = "CODIGO PRODUCTO"
        Me.colSKU_TRAN.FieldName = "MATERIAL_CODE"
        Me.colSKU_TRAN.Name = "colSKU_TRAN"
        Me.colSKU_TRAN.OptionsColumn.AllowEdit = False
        Me.colSKU_TRAN.Visible = True
        Me.colSKU_TRAN.VisibleIndex = 0
        '
        'colDESCSKU_TRAN
        '
        Me.colDESCSKU_TRAN.Caption = "DESCRIPCION SKU"
        Me.colDESCSKU_TRAN.FieldName = "MATERIAL_DESCRIPTION"
        Me.colDESCSKU_TRAN.Name = "colDESCSKU_TRAN"
        Me.colDESCSKU_TRAN.OptionsColumn.AllowEdit = False
        Me.colDESCSKU_TRAN.Visible = True
        Me.colDESCSKU_TRAN.VisibleIndex = 1
        '
        'colCANTIDAD_TRAN
        '
        Me.colCANTIDAD_TRAN.Caption = "CANTIDAD RECIBIDA"
        Me.colCANTIDAD_TRAN.FieldName = "QUANTITY_UNITS"
        Me.colCANTIDAD_TRAN.Name = "colCANTIDAD_TRAN"
        Me.colCANTIDAD_TRAN.Visible = True
        Me.colCANTIDAD_TRAN.VisibleIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(11, 1)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl3.TabIndex = 1
        Me.LabelControl3.Text = "Asociados"
        '
        'GridMATCH
        '
        Me.GridMATCH.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMATCH.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridMATCH.Location = New System.Drawing.Point(0, 20)
        Me.GridMATCH.MainView = Me.GridViewMATCH
        Me.GridMATCH.MenuManager = Me.BarManager1
        Me.GridMATCH.Name = "GridMATCH"
        Me.GridMATCH.Size = New System.Drawing.Size(1191, 206)
        Me.GridMATCH.TabIndex = 0
        Me.GridMATCH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewMATCH})
        '
        'GridViewMATCH
        '
        Me.GridViewMATCH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTRANS_ID, Me.colLINENO_POLIZA, Me.colDOC_IDPTM, Me.colSKU_DESCRIPTION, Me.colMATERIAL_CODE, Me.colMATERIAL_DESCRIPTION, Me.colQTY_TRANS, Me.colQTY_POLIZA, Me.colBULTOS_POLIZA, Me.colLAST_UPDATED_BY, Me.colLAST_UPDATED, Me.colCODIGO_POLIZA})
        Me.GridViewMATCH.GridControl = Me.GridMATCH
        Me.GridViewMATCH.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GridViewMATCH.Name = "GridViewMATCH"
        Me.GridViewMATCH.OptionsBehavior.Editable = False
        Me.GridViewMATCH.OptionsView.ShowFooter = True
        Me.GridViewMATCH.OptionsView.ShowGroupPanel = False
        Me.GridViewMATCH.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'colTRANS_ID
        '
        Me.colTRANS_ID.Caption = "RECEPCION"
        Me.colTRANS_ID.FieldName = "TRANS_ID"
        Me.colTRANS_ID.Name = "colTRANS_ID"
        Me.colTRANS_ID.Visible = True
        Me.colTRANS_ID.VisibleIndex = 0
        '
        'colLINENO_POLIZA
        '
        Me.colLINENO_POLIZA.Caption = "LINEA POLIZA"
        Me.colLINENO_POLIZA.FieldName = "LINENO_POLIZA"
        Me.colLINENO_POLIZA.Name = "colLINENO_POLIZA"
        Me.colLINENO_POLIZA.Visible = True
        Me.colLINENO_POLIZA.VisibleIndex = 1
        '
        'colDOC_IDPTM
        '
        Me.colDOC_IDPTM.Caption = "DOCUMENTO"
        Me.colDOC_IDPTM.FieldName = "DOC_ID"
        Me.colDOC_IDPTM.Name = "colDOC_IDPTM"
        Me.colDOC_IDPTM.Visible = True
        Me.colDOC_IDPTM.VisibleIndex = 2
        '
        'colSKU_DESCRIPTION
        '
        Me.colSKU_DESCRIPTION.Caption = "DESCRIPCION POLIZA"
        Me.colSKU_DESCRIPTION.FieldName = "SKU_DESCRIPTION"
        Me.colSKU_DESCRIPTION.Name = "colSKU_DESCRIPTION"
        Me.colSKU_DESCRIPTION.Visible = True
        Me.colSKU_DESCRIPTION.VisibleIndex = 3
        '
        'colMATERIAL_CODE
        '
        Me.colMATERIAL_CODE.Caption = "CODIGO PRODUCTO"
        Me.colMATERIAL_CODE.FieldName = "MATERIAL_CODE"
        Me.colMATERIAL_CODE.Name = "colMATERIAL_CODE"
        Me.colMATERIAL_CODE.Visible = True
        Me.colMATERIAL_CODE.VisibleIndex = 4
        '
        'colMATERIAL_DESCRIPTION
        '
        Me.colMATERIAL_DESCRIPTION.Caption = "DESCRIPCION INVENTARIO"
        Me.colMATERIAL_DESCRIPTION.FieldName = "MATERIAL_DESCRIPTION"
        Me.colMATERIAL_DESCRIPTION.Name = "colMATERIAL_DESCRIPTION"
        Me.colMATERIAL_DESCRIPTION.Visible = True
        Me.colMATERIAL_DESCRIPTION.VisibleIndex = 5
        '
        'colQTY_TRANS
        '
        Me.colQTY_TRANS.Caption = "CANTIDAD_TRANSACCION"
        Me.colQTY_TRANS.FieldName = "QTY_TRANS"
        Me.colQTY_TRANS.Name = "colQTY_TRANS"
        Me.colQTY_TRANS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY_TRANS", "(Trans = {0:c2})")})
        Me.colQTY_TRANS.Visible = True
        Me.colQTY_TRANS.VisibleIndex = 6
        '
        'colQTY_POLIZA
        '
        Me.colQTY_POLIZA.Caption = "CANTIDAD POLIZA"
        Me.colQTY_POLIZA.FieldName = "QTY_POLIZA"
        Me.colQTY_POLIZA.Name = "colQTY_POLIZA"
        Me.colQTY_POLIZA.Visible = True
        Me.colQTY_POLIZA.VisibleIndex = 7
        '
        'colBULTOS_POLIZA
        '
        Me.colBULTOS_POLIZA.Caption = "BULTOS POLIZA"
        Me.colBULTOS_POLIZA.FieldName = "BULTOS_POLIZA"
        Me.colBULTOS_POLIZA.Name = "colBULTOS_POLIZA"
        Me.colBULTOS_POLIZA.Visible = True
        Me.colBULTOS_POLIZA.VisibleIndex = 8
        '
        'colLAST_UPDATED_BY
        '
        Me.colLAST_UPDATED_BY.Caption = "ACTUALIZADO POR"
        Me.colLAST_UPDATED_BY.FieldName = "LAST_UPDATED_BY"
        Me.colLAST_UPDATED_BY.Name = "colLAST_UPDATED_BY"
        Me.colLAST_UPDATED_BY.Visible = True
        Me.colLAST_UPDATED_BY.VisibleIndex = 9
        '
        'colLAST_UPDATED
        '
        Me.colLAST_UPDATED.Caption = "ACTUALIZADA EL"
        Me.colLAST_UPDATED.FieldName = "LAST_UPDATED"
        Me.colLAST_UPDATED.Name = "colLAST_UPDATED"
        '
        'colCODIGO_POLIZA
        '
        Me.colCODIGO_POLIZA.Caption = "CODIGO POLIZA"
        Me.colCODIGO_POLIZA.FieldName = "CODIGO_POLIZA"
        Me.colCODIGO_POLIZA.Name = "colCODIGO_POLIZA"
        Me.colCODIGO_POLIZA.Visible = True
        Me.colCODIGO_POLIZA.VisibleIndex = 10
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.PageVisible = False
        Me.XtraTabPage3.Size = New System.Drawing.Size(1191, 585)
        Me.XtraTabPage3.Text = "Licencias"
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1, Me.PrintableComponentLink2})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridMATCH
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'PrintableComponentLink2
        '
        Me.PrintableComponentLink2.Component = Me.GridRECEPCIONES
        Me.PrintableComponentLink2.Landscape = True
        Me.PrintableComponentLink2.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.PrintableComponentLink2.PrintingSystemBase = Me.PrintingSystem1
        '
        'Timer1
        '
        Me.Timer1.Interval = 10000
        '
        'frmAprobacionRecepcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1197, 653)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmAprobacionRecepcion"
        Me.Text = "Aprobacion Recepcion Fiscal"
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.GridRECEPCIONES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewRECEPCIONES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GridPOLIZADET, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPOLIZADET, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridRECDET, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewRECDET, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridMATCH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewMATCH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridRECEPCIONES As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewRECEPCIONES As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents colRECEPCION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRECEPTOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPOLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTRANS_DESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNEWSKUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridPOLIZADET As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPOLIZADET As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridRECDET As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewRECDET As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colLINEAPOLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESCRIPCIONPOLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBULTOSPOLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCANTIDADPOLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents bnPrintRec As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnPrint As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnAsociar As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents colSKU_TRAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESCSKU_TRAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCANTIDAD_TRAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents colESTADO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents colDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GridMATCH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewMATCH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colTRANS_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLINENO_POLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDOC_IDPTM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSKU_DESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMATERIAL_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMATERIAL_DESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colQTY_TRANS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colQTY_POLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBULTOS_POLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLAST_UPDATED_BY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLAST_UPDATED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODIGO_POLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarLargeButtonItem1 As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents PrintableComponentLink2 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnDel As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnSKU As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents colMATERIAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnRazonamiento As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnActualizacion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents colNUMERO_ORDEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNUMERO_DUA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
