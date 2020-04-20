<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvAudit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvAudit))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.btnNuevo = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnExcel = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnPrint = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.cmbAsignar = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemGridLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.RepositoryItemGridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnAssign = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnDiff = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnCancelar = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCOUNT_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCREATED_BY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCREATED_DATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOUNT_TYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colACCURACY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOMPLETED_DATE1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCANCELED_DATE1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPROGRESS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLAST_UPDATED1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.AdvBandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colCOUNT_ID1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCOUNT_REGIMEN = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colASSIGNED_TO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colASSIGNED_DATE = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCOUNTED_DATE = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colMATERIAL_NAME = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colEXPECTED_MATERIAL_ID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSCANNED_MATERIAL_ID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSCANNED_BARCODE = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colINPUTED_QTY = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSNAPSHOT_QTY = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCALCULATED_DIFF = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSERIAL_NUMBER = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colASSIGNED_BY = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCOUNT_TYPE1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCOUNT_CLIENT_OWNER = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCOUNT_CLIENT_NAME = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCOMPLETED_DATE = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCANCELED_DATE = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colEXPECTED_LOCATION_SPOT = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSCANNED_LOCATION_SPOTT = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colEXPECTED_LICENSE_ID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSCANNED_LICENSE_ID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCOMMENTS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colHIT_OR_MISS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PrintableComponentLink2 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnNuevo, Me.btnExcel, Me.btnPrint, Me.btnAssign, Me.cmbAsignar, Me.btnDiff, Me.btnCancelar})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 7
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemGridLookUpEdit1})
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnNuevo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.cmbAsignar), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnAssign, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnDiff, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnCancelar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'btnNuevo
        '
        Me.btnNuevo.Caption = "Nuevo"
        Me.btnNuevo.Id = 0
        Me.btnNuevo.Name = "btnNuevo"
        '
        'btnExcel
        '
        Me.btnExcel.Caption = "Excel"
        Me.btnExcel.Id = 1
        Me.btnExcel.Name = "btnExcel"
        '
        'btnPrint
        '
        Me.btnPrint.Caption = "Imprimir"
        Me.btnPrint.Id = 2
        Me.btnPrint.Name = "btnPrint"
        '
        'cmbAsignar
        '
        Me.cmbAsignar.Edit = Me.RepositoryItemGridLookUpEdit1
        Me.cmbAsignar.Id = 4
        Me.cmbAsignar.Name = "cmbAsignar"
        Me.cmbAsignar.Width = 185
        '
        'RepositoryItemGridLookUpEdit1
        '
        Me.RepositoryItemGridLookUpEdit1.AutoHeight = False
        Me.RepositoryItemGridLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemGridLookUpEdit1.Name = "RepositoryItemGridLookUpEdit1"
        Me.RepositoryItemGridLookUpEdit1.NullValuePrompt = "Seleccione bodeguero..."
        Me.RepositoryItemGridLookUpEdit1.NullValuePromptShowForEmptyValue = True
        Me.RepositoryItemGridLookUpEdit1.View = Me.RepositoryItemGridLookUpEdit1View
        '
        'RepositoryItemGridLookUpEdit1View
        '
        Me.RepositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemGridLookUpEdit1View.Name = "RepositoryItemGridLookUpEdit1View"
        Me.RepositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'btnAssign
        '
        Me.btnAssign.Caption = "Asignar"
        Me.btnAssign.Id = 3
        Me.btnAssign.Name = "btnAssign"
        '
        'btnDiff
        '
        Me.btnDiff.Caption = "Diferencias"
        Me.btnDiff.Id = 5
        Me.btnDiff.Name = "btnDiff"
        '
        'btnCancelar
        '
        Me.btnCancelar.Caption = "Cancelar"
        Me.btnCancelar.Id = 6
        Me.btnCancelar.Name = "btnCancelar"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(838, 24)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 519)
        Me.barDockControlBottom.Size = New System.Drawing.Size(838, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 24)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 495)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(838, 24)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 495)
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.BarManager1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(832, 469)
        Me.GridControl1.TabIndex = 4
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCOUNT_ID, Me.colCREATED_BY, Me.colCREATED_DATE, Me.colCOUNT_TYPE, Me.colACCURACY, Me.colCOMPLETED_DATE1, Me.colCANCELED_DATE1, Me.colPROGRESS, Me.colLAST_UPDATED1})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        '
        'colCOUNT_ID
        '
        Me.colCOUNT_ID.Caption = "CONTEO"
        Me.colCOUNT_ID.FieldName = "COUNT_ID"
        Me.colCOUNT_ID.Name = "colCOUNT_ID"
        Me.colCOUNT_ID.Visible = True
        Me.colCOUNT_ID.VisibleIndex = 0
        '
        'colCREATED_BY
        '
        Me.colCREATED_BY.Caption = "CREADO POR"
        Me.colCREATED_BY.FieldName = "CREATED_BY"
        Me.colCREATED_BY.Name = "colCREATED_BY"
        Me.colCREATED_BY.Visible = True
        Me.colCREATED_BY.VisibleIndex = 1
        '
        'colCREATED_DATE
        '
        Me.colCREATED_DATE.Caption = "CREADO EL"
        Me.colCREATED_DATE.DisplayFormat.FormatString = "g"
        Me.colCREATED_DATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colCREATED_DATE.FieldName = "CREATED_DATE"
        Me.colCREATED_DATE.Name = "colCREATED_DATE"
        Me.colCREATED_DATE.Visible = True
        Me.colCREATED_DATE.VisibleIndex = 2
        '
        'colCOUNT_TYPE
        '
        Me.colCOUNT_TYPE.Caption = "TIPO"
        Me.colCOUNT_TYPE.FieldName = "COUNT_TYPE"
        Me.colCOUNT_TYPE.Name = "colCOUNT_TYPE"
        Me.colCOUNT_TYPE.Visible = True
        Me.colCOUNT_TYPE.VisibleIndex = 3
        '
        'colACCURACY
        '
        Me.colACCURACY.Caption = "VERACIDAD"
        Me.colACCURACY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colACCURACY.FieldName = "ACCURACY"
        Me.colACCURACY.Name = "colACCURACY"
        Me.colACCURACY.Visible = True
        Me.colACCURACY.VisibleIndex = 4
        '
        'colCOMPLETED_DATE1
        '
        Me.colCOMPLETED_DATE1.Caption = "COMPLETADO"
        Me.colCOMPLETED_DATE1.FieldName = "COMPLETED_DATE"
        Me.colCOMPLETED_DATE1.Name = "colCOMPLETED_DATE1"
        Me.colCOMPLETED_DATE1.Visible = True
        Me.colCOMPLETED_DATE1.VisibleIndex = 5
        '
        'colCANCELED_DATE1
        '
        Me.colCANCELED_DATE1.Caption = "CANCELADO"
        Me.colCANCELED_DATE1.FieldName = "CANCELED_DATE"
        Me.colCANCELED_DATE1.Name = "colCANCELED_DATE1"
        Me.colCANCELED_DATE1.Visible = True
        Me.colCANCELED_DATE1.VisibleIndex = 6
        '
        'colPROGRESS
        '
        Me.colPROGRESS.Caption = "AVANCE"
        Me.colPROGRESS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPROGRESS.FieldName = "PROGRESS"
        Me.colPROGRESS.Name = "colPROGRESS"
        Me.colPROGRESS.Visible = True
        Me.colPROGRESS.VisibleIndex = 7
        '
        'colLAST_UPDATED1
        '
        Me.colLAST_UPDATED1.Caption = "ACTUALIZADO_EL"
        Me.colLAST_UPDATED1.FieldName = "LAST_UPDATED"
        Me.colLAST_UPDATED1.Name = "colLAST_UPDATED1"
        Me.colLAST_UPDATED1.Visible = True
        Me.colLAST_UPDATED1.VisibleIndex = 8
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        '
        '
        '
        Me.PrintableComponentLink1.ImageCollection.ImageStream = CType(resources.GetObject("PrintableComponentLink1.ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.PrintableComponentLink1.PrintingSystem = Me.PrintingSystem1
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 24)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(838, 495)
        Me.XtraTabControl1.TabIndex = 9
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.GridControl1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(832, 469)
        Me.XtraTabPage1.Text = "Listado de Conteos"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GridControl2)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(832, 469)
        Me.XtraTabPage2.Text = "Tareas Conteo"
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.AdvBandedGridView1
        Me.GridControl2.MenuManager = Me.BarManager1
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(832, 469)
        Me.GridControl2.TabIndex = 0
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AdvBandedGridView1})
        '
        'AdvBandedGridView1
        '
        Me.AdvBandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.AdvBandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colCOUNT_ID1, Me.colSERIAL_NUMBER, Me.colASSIGNED_TO, Me.colASSIGNED_BY, Me.colCOUNT_TYPE1, Me.colCOUNT_REGIMEN, Me.colCOUNT_CLIENT_OWNER, Me.colCOUNT_CLIENT_NAME, Me.colASSIGNED_DATE, Me.colCOUNTED_DATE, Me.colCOMPLETED_DATE, Me.colCANCELED_DATE, Me.colEXPECTED_LOCATION_SPOT, Me.colSCANNED_LOCATION_SPOTT, Me.colEXPECTED_LICENSE_ID, Me.colSCANNED_LICENSE_ID, Me.colEXPECTED_MATERIAL_ID, Me.colSCANNED_BARCODE, Me.colSCANNED_MATERIAL_ID, Me.colMATERIAL_NAME, Me.colSNAPSHOT_QTY, Me.colINPUTED_QTY, Me.colCALCULATED_DIFF, Me.colCOMMENTS, Me.colHIT_OR_MISS})
        Me.AdvBandedGridView1.GridControl = Me.GridControl2
        Me.AdvBandedGridView1.Name = "AdvBandedGridView1"
        Me.AdvBandedGridView1.OptionsBehavior.Editable = False
        Me.AdvBandedGridView1.OptionsSelection.MultiSelect = True
        Me.AdvBandedGridView1.OptionsView.ShowAutoFilterRow = True
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Tareas del conteo"
        Me.GridBand1.Columns.Add(Me.colCOUNT_ID1)
        Me.GridBand1.Columns.Add(Me.colCOUNT_REGIMEN)
        Me.GridBand1.Columns.Add(Me.colASSIGNED_TO)
        Me.GridBand1.Columns.Add(Me.colASSIGNED_DATE)
        Me.GridBand1.Columns.Add(Me.colCOUNTED_DATE)
        Me.GridBand1.Columns.Add(Me.colMATERIAL_NAME)
        Me.GridBand1.Columns.Add(Me.colEXPECTED_MATERIAL_ID)
        Me.GridBand1.Columns.Add(Me.colSCANNED_MATERIAL_ID)
        Me.GridBand1.Columns.Add(Me.colSCANNED_BARCODE)
        Me.GridBand1.Columns.Add(Me.colINPUTED_QTY)
        Me.GridBand1.Columns.Add(Me.colSNAPSHOT_QTY)
        Me.GridBand1.Columns.Add(Me.colCALCULATED_DIFF)
        Me.GridBand1.MinWidth = 20
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.Width = 900
        '
        'colCOUNT_ID1
        '
        Me.colCOUNT_ID1.Caption = "CONTEO"
        Me.colCOUNT_ID1.FieldName = "COUNT_ID"
        Me.colCOUNT_ID1.Name = "colCOUNT_ID1"
        Me.colCOUNT_ID1.Visible = True
        '
        'colCOUNT_REGIMEN
        '
        Me.colCOUNT_REGIMEN.Caption = "REGIMEN"
        Me.colCOUNT_REGIMEN.FieldName = "COUNT_REGIMEN"
        Me.colCOUNT_REGIMEN.Name = "colCOUNT_REGIMEN"
        Me.colCOUNT_REGIMEN.Visible = True
        '
        'colASSIGNED_TO
        '
        Me.colASSIGNED_TO.Caption = "ASIGNADO A"
        Me.colASSIGNED_TO.FieldName = "ASSIGNED_TO"
        Me.colASSIGNED_TO.Name = "colASSIGNED_TO"
        Me.colASSIGNED_TO.OptionsColumn.ReadOnly = True
        Me.colASSIGNED_TO.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.colASSIGNED_TO.Visible = True
        '
        'colASSIGNED_DATE
        '
        Me.colASSIGNED_DATE.Caption = "ASIGNADO EL"
        Me.colASSIGNED_DATE.DisplayFormat.FormatString = "g"
        Me.colASSIGNED_DATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colASSIGNED_DATE.FieldName = "ASSIGNED_DATE"
        Me.colASSIGNED_DATE.Name = "colASSIGNED_DATE"
        Me.colASSIGNED_DATE.Visible = True
        '
        'colCOUNTED_DATE
        '
        Me.colCOUNTED_DATE.Caption = "CONTADO EL"
        Me.colCOUNTED_DATE.DisplayFormat.FormatString = "g"
        Me.colCOUNTED_DATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colCOUNTED_DATE.FieldName = "COUNTED_DATE"
        Me.colCOUNTED_DATE.Name = "colCOUNTED_DATE"
        Me.colCOUNTED_DATE.Visible = True
        '
        'colMATERIAL_NAME
        '
        Me.colMATERIAL_NAME.Caption = "DESCRIPCION PRODUCTO"
        Me.colMATERIAL_NAME.FieldName = "MATERIAL_NAME"
        Me.colMATERIAL_NAME.Name = "colMATERIAL_NAME"
        Me.colMATERIAL_NAME.Visible = True
        '
        'colEXPECTED_MATERIAL_ID
        '
        Me.colEXPECTED_MATERIAL_ID.Caption = "PRODUCTO ESPERADO"
        Me.colEXPECTED_MATERIAL_ID.FieldName = "EXPECTED_MATERIAL_ID"
        Me.colEXPECTED_MATERIAL_ID.Name = "colEXPECTED_MATERIAL_ID"
        Me.colEXPECTED_MATERIAL_ID.Visible = True
        '
        'colSCANNED_MATERIAL_ID
        '
        Me.colSCANNED_MATERIAL_ID.Caption = "PRODUCTO ESCANEADO"
        Me.colSCANNED_MATERIAL_ID.FieldName = "SCANNED_MATERIAL_ID"
        Me.colSCANNED_MATERIAL_ID.Name = "colSCANNED_MATERIAL_ID"
        Me.colSCANNED_MATERIAL_ID.Visible = True
        '
        'colSCANNED_BARCODE
        '
        Me.colSCANNED_BARCODE.Caption = "CODIGO BARRAS ESCANEADO"
        Me.colSCANNED_BARCODE.FieldName = "SCANNED_BARCODE"
        Me.colSCANNED_BARCODE.Name = "colSCANNED_BARCODE"
        Me.colSCANNED_BARCODE.Visible = True
        '
        'colINPUTED_QTY
        '
        Me.colINPUTED_QTY.Caption = "CANTIDAD CONTADA"
        Me.colINPUTED_QTY.FieldName = "INPUTED_QTY"
        Me.colINPUTED_QTY.Name = "colINPUTED_QTY"
        Me.colINPUTED_QTY.Visible = True
        '
        'colSNAPSHOT_QTY
        '
        Me.colSNAPSHOT_QTY.Caption = "CANTIDAD ESPERADA"
        Me.colSNAPSHOT_QTY.FieldName = "SNAPSHOT_QTY"
        Me.colSNAPSHOT_QTY.Name = "colSNAPSHOT_QTY"
        Me.colSNAPSHOT_QTY.Visible = True
        '
        'colCALCULATED_DIFF
        '
        Me.colCALCULATED_DIFF.Caption = "DIFERENCIA"
        Me.colCALCULATED_DIFF.FieldName = "CALCULATED_DIFF"
        Me.colCALCULATED_DIFF.Name = "colCALCULATED_DIFF"
        Me.colCALCULATED_DIFF.Visible = True
        '
        'colSERIAL_NUMBER
        '
        Me.colSERIAL_NUMBER.Caption = "SERIE"
        Me.colSERIAL_NUMBER.FieldName = "SERIAL_NUMBER"
        Me.colSERIAL_NUMBER.Name = "colSERIAL_NUMBER"
        '
        'colASSIGNED_BY
        '
        Me.colASSIGNED_BY.Caption = "ASIGNADO POR"
        Me.colASSIGNED_BY.FieldName = "ASSIGNED_BY"
        Me.colASSIGNED_BY.Name = "colASSIGNED_BY"
        '
        'colCOUNT_TYPE1
        '
        Me.colCOUNT_TYPE1.Caption = "TIPO"
        Me.colCOUNT_TYPE1.FieldName = "COUNT_TYPE"
        Me.colCOUNT_TYPE1.Name = "colCOUNT_TYPE1"
        '
        'colCOUNT_CLIENT_OWNER
        '
        Me.colCOUNT_CLIENT_OWNER.Caption = "CODIGO CLIENTE"
        Me.colCOUNT_CLIENT_OWNER.FieldName = "COUNT_CLIENT_OWNER"
        Me.colCOUNT_CLIENT_OWNER.Name = "colCOUNT_CLIENT_OWNER"
        '
        'colCOUNT_CLIENT_NAME
        '
        Me.colCOUNT_CLIENT_NAME.Caption = "CLIENTE"
        Me.colCOUNT_CLIENT_NAME.FieldName = "COUNT_CLIENT_NAME"
        Me.colCOUNT_CLIENT_NAME.Name = "colCOUNT_CLIENT_NAME"
        '
        'colCOMPLETED_DATE
        '
        Me.colCOMPLETED_DATE.Caption = "TERMINADO EL"
        Me.colCOMPLETED_DATE.DisplayFormat.FormatString = "g"
        Me.colCOMPLETED_DATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colCOMPLETED_DATE.FieldName = "COMPLETED_DATE"
        Me.colCOMPLETED_DATE.Name = "colCOMPLETED_DATE"
        '
        'colCANCELED_DATE
        '
        Me.colCANCELED_DATE.Caption = "CANCELADO_EL"
        Me.colCANCELED_DATE.DisplayFormat.FormatString = "g"
        Me.colCANCELED_DATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colCANCELED_DATE.FieldName = "CANCELED_DATE"
        Me.colCANCELED_DATE.Name = "colCANCELED_DATE"
        '
        'colEXPECTED_LOCATION_SPOT
        '
        Me.colEXPECTED_LOCATION_SPOT.Caption = "UBICACION ESPERADA"
        Me.colEXPECTED_LOCATION_SPOT.FieldName = "EXPECTED_LOCATIION_SPOT"
        Me.colEXPECTED_LOCATION_SPOT.Name = "colEXPECTED_LOCATION_SPOT"
        '
        'colSCANNED_LOCATION_SPOTT
        '
        Me.colSCANNED_LOCATION_SPOTT.Caption = "UBICACION ESCANEADA"
        Me.colSCANNED_LOCATION_SPOTT.FieldName = "SCANNED_LOCATION_SPOT"
        Me.colSCANNED_LOCATION_SPOTT.Name = "colSCANNED_LOCATION_SPOTT"
        '
        'colEXPECTED_LICENSE_ID
        '
        Me.colEXPECTED_LICENSE_ID.Caption = "LICENCIA ESPERADA"
        Me.colEXPECTED_LICENSE_ID.FieldName = "EXPECTED_LICENSE_ID"
        Me.colEXPECTED_LICENSE_ID.Name = "colEXPECTED_LICENSE_ID"
        '
        'colSCANNED_LICENSE_ID
        '
        Me.colSCANNED_LICENSE_ID.Caption = "LICENCIA ESCANEADA"
        Me.colSCANNED_LICENSE_ID.FieldName = "SCANNED_LICENSE_ID"
        Me.colSCANNED_LICENSE_ID.Name = "colSCANNED_LICENSE_ID"
        '
        'colCOMMENTS
        '
        Me.colCOMMENTS.Caption = "COMENTARIOS"
        Me.colCOMMENTS.FieldName = "COMMENTS"
        Me.colCOMMENTS.Name = "colCOMMENTS"
        '
        'colHIT_OR_MISS
        '
        Me.colHIT_OR_MISS.Caption = "VERACIDAD"
        Me.colHIT_OR_MISS.FieldName = "HIT_OR_MISS"
        Me.colHIT_OR_MISS.Name = "colHIT_OR_MISS"
        '
        'PrintableComponentLink2
        '
        Me.PrintableComponentLink2.Component = Me.GridControl2
        '
        '
        '
        Me.PrintableComponentLink2.ImageCollection.ImageStream = CType(resources.GetObject("PrintableComponentLink2.ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.PrintableComponentLink2.PrintingSystem = Me.PrintingSystem1
        Me.PrintableComponentLink2.PrintingSystemBase = Me.PrintingSystem1
        '
        'frmInvAudit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 519)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmInvAudit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Auditoria de Inventarios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents btnNuevo As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCOUNT_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCREATED_BY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCREATED_DATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOUNT_TYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colACCURACY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnExcel As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnPrint As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents btnAssign As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents PrintableComponentLink2 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents AdvBandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents cmbAsignar As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemGridLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents RepositoryItemGridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCOUNT_ID1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSERIAL_NUMBER As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colASSIGNED_TO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colASSIGNED_BY As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCOUNT_TYPE1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCOUNT_REGIMEN As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCOUNT_CLIENT_OWNER As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCOUNT_CLIENT_NAME As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colASSIGNED_DATE As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCOUNTED_DATE As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCOMPLETED_DATE As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCANCELED_DATE As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colEXPECTED_LOCATION_SPOT As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSCANNED_LOCATION_SPOTT As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colEXPECTED_LICENSE_ID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSCANNED_LICENSE_ID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colEXPECTED_MATERIAL_ID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSCANNED_BARCODE As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSCANNED_MATERIAL_ID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colMATERIAL_NAME As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSNAPSHOT_QTY As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colINPUTED_QTY As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCALCULATED_DIFF As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCOMMENTS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colHIT_OR_MISS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents btnDiff As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnCancelar As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents colCOMPLETED_DATE1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCANCELED_DATE1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPROGRESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLAST_UPDATED1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
