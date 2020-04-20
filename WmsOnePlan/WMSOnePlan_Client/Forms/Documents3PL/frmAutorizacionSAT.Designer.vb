<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutorizacionSAT
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
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.colSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnReyected = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAproved = New DevExpress.XtraEditors.SimpleButton()
        Me.btnStby = New DevExpress.XtraEditors.SimpleButton()
        Me.GridAutorizaciones = New DevExpress.XtraGrid.GridControl()
        Me.GridViewAutorizaciones = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPOLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENT_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENT_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCREATED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSENT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRECEIVED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSAT_RESULT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.btnPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnFind = New DevExpress.XtraBars.BarButtonItem()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.VGridStats = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.rowAproved = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowReyected = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowPending = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.btnSend = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.btnSelect = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.btnUnSelect = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridAutorizaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAutorizaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VGridStats, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colSTATUS
        '
        Me.colSTATUS.Caption = "ESTADO"
        Me.colSTATUS.FieldName = "STATUS"
        Me.colSTATUS.Name = "colSTATUS"
        Me.colSTATUS.Visible = True
        Me.colSTATUS.VisibleIndex = 4
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnNew)
        Me.LayoutControl1.Controls.Add(Me.btnUnSelect)
        Me.LayoutControl1.Controls.Add(Me.btnSelect)
        Me.LayoutControl1.Controls.Add(Me.btnReyected)
        Me.LayoutControl1.Controls.Add(Me.btnAproved)
        Me.LayoutControl1.Controls.Add(Me.btnStby)
        Me.LayoutControl1.Controls.Add(Me.GridAutorizaciones)
        Me.LayoutControl1.Controls.Add(Me.btnSend)
        Me.LayoutControl1.Controls.Add(Me.VGridStats)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 22)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(418, 243, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(948, 372)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnReyected
        '
        Me.btnReyected.Location = New System.Drawing.Point(12, 164)
        Me.btnReyected.Name = "btnReyected"
        Me.btnReyected.Size = New System.Drawing.Size(153, 22)
        Me.btnReyected.StyleController = Me.LayoutControl1
        Me.btnReyected.TabIndex = 10
        Me.btnReyected.Text = "Rechazados"
        '
        'btnAproved
        '
        Me.btnAproved.Location = New System.Drawing.Point(12, 138)
        Me.btnAproved.Name = "btnAproved"
        Me.btnAproved.Size = New System.Drawing.Size(153, 22)
        Me.btnAproved.StyleController = Me.LayoutControl1
        Me.btnAproved.TabIndex = 9
        Me.btnAproved.Text = "Autorizados"
        '
        'btnStby
        '
        Me.btnStby.Location = New System.Drawing.Point(12, 190)
        Me.btnStby.Name = "btnStby"
        Me.btnStby.Size = New System.Drawing.Size(153, 22)
        Me.btnStby.StyleController = Me.LayoutControl1
        Me.btnStby.TabIndex = 8
        Me.btnStby.Text = "Pendientes"
        '
        'GridAutorizaciones
        '
        Me.GridAutorizaciones.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridAutorizaciones.Location = New System.Drawing.Point(174, 40)
        Me.GridAutorizaciones.MainView = Me.GridViewAutorizaciones
        Me.GridAutorizaciones.MenuManager = Me.BarManager1
        Me.GridAutorizaciones.Name = "GridAutorizaciones"
        Me.GridAutorizaciones.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridAutorizaciones.Size = New System.Drawing.Size(762, 320)
        Me.GridAutorizaciones.TabIndex = 6
        Me.GridAutorizaciones.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewAutorizaciones})
        '
        'GridViewAutorizaciones
        '
        Me.GridViewAutorizaciones.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPOLIZA, Me.colDOC_ID, Me.colCLIENT_CODE, Me.colCLIENT_NAME, Me.colSTATUS, Me.colCREATED, Me.colSENT, Me.colRECEIVED, Me.colSAT_RESULT})
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        StyleFormatCondition2.Appearance.Options.UseBackColor = True
        StyleFormatCondition2.Column = Me.colSTATUS
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition2.Value1 = CType(1, Short)
        Me.GridViewAutorizaciones.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition2})
        Me.GridViewAutorizaciones.GridControl = Me.GridAutorizaciones
        Me.GridViewAutorizaciones.Name = "GridViewAutorizaciones"
        Me.GridViewAutorizaciones.OptionsBehavior.Editable = False
        Me.GridViewAutorizaciones.OptionsSelection.MultiSelect = True
        Me.GridViewAutorizaciones.OptionsView.ShowAutoFilterRow = True
        Me.GridViewAutorizaciones.OptionsView.ShowGroupPanel = False
        '
        'colPOLIZA
        '
        Me.colPOLIZA.Caption = "POLIZA"
        Me.colPOLIZA.FieldName = "POLIZA"
        Me.colPOLIZA.Name = "colPOLIZA"
        Me.colPOLIZA.Visible = True
        Me.colPOLIZA.VisibleIndex = 0
        '
        'colDOC_ID
        '
        Me.colDOC_ID.Caption = "NUMERO DOCUMENTO"
        Me.colDOC_ID.FieldName = "DOC_ID"
        Me.colDOC_ID.Name = "colDOC_ID"
        Me.colDOC_ID.Visible = True
        Me.colDOC_ID.VisibleIndex = 1
        '
        'colCLIENT_CODE
        '
        Me.colCLIENT_CODE.Caption = "CODIGO CONSOLIDADOR"
        Me.colCLIENT_CODE.FieldName = "CLIENT_CODE"
        Me.colCLIENT_CODE.Name = "colCLIENT_CODE"
        Me.colCLIENT_CODE.Visible = True
        Me.colCLIENT_CODE.VisibleIndex = 2
        '
        'colCLIENT_NAME
        '
        Me.colCLIENT_NAME.Caption = "NOMBRE CONSOLIDADOR"
        Me.colCLIENT_NAME.FieldName = "CLIENT_NAME"
        Me.colCLIENT_NAME.Name = "colCLIENT_NAME"
        Me.colCLIENT_NAME.Visible = True
        Me.colCLIENT_NAME.VisibleIndex = 3
        '
        'colCREATED
        '
        Me.colCREATED.Caption = "Fecha de Creación"
        Me.colCREATED.DisplayFormat.FormatString = "dd/MM/yyyy  HH:mm"
        Me.colCREATED.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colCREATED.FieldName = "CREATED"
        Me.colCREATED.Name = "colCREATED"
        Me.colCREATED.Visible = True
        Me.colCREATED.VisibleIndex = 5
        '
        'colSENT
        '
        Me.colSENT.Caption = "ENVIADO"
        Me.colSENT.FieldName = "SENT"
        Me.colSENT.Name = "colSENT"
        Me.colSENT.Visible = True
        Me.colSENT.VisibleIndex = 6
        '
        'colRECEIVED
        '
        Me.colRECEIVED.Caption = "RECIBIDA"
        Me.colRECEIVED.FieldName = "RECEIVED"
        Me.colRECEIVED.Name = "colRECEIVED"
        Me.colRECEIVED.Visible = True
        Me.colRECEIVED.VisibleIndex = 7
        '
        'colSAT_RESULT
        '
        Me.colSAT_RESULT.Caption = "RESULTADO SAT"
        Me.colSAT_RESULT.FieldName = "SAT_RESULT"
        Me.colSAT_RESULT.Name = "colSAT_RESULT"
        Me.colSAT_RESULT.Visible = True
        Me.colSAT_RESULT.VisibleIndex = 8
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnPrint, Me.btnFind})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 2
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnPrint)})
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'btnPrint
        '
        Me.btnPrint.Caption = "&Imprimir Acuse"
        Me.btnPrint.Id = 0
        Me.btnPrint.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P))
        Me.btnPrint.Name = "btnPrint"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(948, 22)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 394)
        Me.barDockControlBottom.Size = New System.Drawing.Size(948, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 22)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 372)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(948, 22)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 372)
        '
        'btnFind
        '
        Me.btnFind.Caption = "&Buscar"
        Me.btnFind.Id = 1
        Me.btnFind.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B))
        Me.btnFind.Name = "btnFind"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'VGridStats
        '
        Me.VGridStats.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.VGridStats.Location = New System.Drawing.Point(12, 12)
        Me.VGridStats.Name = "VGridStats"
        Me.VGridStats.RowHeaderWidth = 81
        Me.VGridStats.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowAproved, Me.rowReyected, Me.rowPending})
        Me.VGridStats.Size = New System.Drawing.Size(153, 122)
        Me.VGridStats.TabIndex = 7
        '
        'rowAproved
        '
        Me.rowAproved.Name = "rowAproved"
        Me.rowAproved.Properties.Caption = "Autorizados"
        Me.rowAproved.Properties.FieldName = "rowAproved"
        '
        'rowReyected
        '
        Me.rowReyected.Name = "rowReyected"
        Me.rowReyected.Properties.Caption = "Rechazados"
        Me.rowReyected.Properties.FieldName = "rowReyected"
        '
        'rowPending
        '
        Me.rowPending.Name = "rowPending"
        Me.rowPending.Properties.Caption = "Pendientes"
        Me.rowPending.Properties.FieldName = "rowPending"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.LayoutControlItem8, Me.SplitterItem1, Me.SimpleSeparator1, Me.LayoutControlItem9})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(948, 372)
        Me.LayoutControlGroup1.Text = "Root"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.GridAutorizaciones
        Me.LayoutControlItem3.CustomizationFormText = "Grid Autorizaciones"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(162, 28)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(766, 324)
        Me.LayoutControlItem3.Text = "Grid Autorizaciones"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextToControlDistance = 0
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.VGridStats
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(157, 126)
        Me.LayoutControlItem4.Text = "LayoutControlItem4"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextToControlDistance = 0
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnStby
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 178)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(157, 26)
        Me.LayoutControlItem5.Text = "LayoutControlItem5"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextToControlDistance = 0
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnAproved
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem6"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 126)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(157, 26)
        Me.LayoutControlItem6.Text = "LayoutControlItem6"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextToControlDistance = 0
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.btnReyected
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 152)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(157, 26)
        Me.LayoutControlItem7.Text = "LayoutControlItem7"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextToControlDistance = 0
        Me.LayoutControlItem7.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 204)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(157, 148)
        Me.EmptySpaceItem1.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.CustomizationFormText = "SplitterItem1"
        Me.SplitterItem1.Location = New System.Drawing.Point(157, 0)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(5, 352)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(162, 26)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(766, 2)
        Me.SimpleSeparator1.Text = "SimpleSeparator1"
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.btnNew
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem9"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(736, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(192, 26)
        Me.LayoutControlItem9.Text = "LayoutControlItem9"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextToControlDistance = 0
        Me.LayoutControlItem9.TextVisible = False
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(748, 12)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(188, 22)
        Me.btnNew.StyleController = Me.LayoutControl1
        Me.btnNew.TabIndex = 13
        Me.btnNew.Text = "Nuevo"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnSend
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(544, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(192, 26)
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(556, 12)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(188, 22)
        Me.btnSend.StyleController = Me.LayoutControl1
        Me.btnSend.TabIndex = 5
        Me.btnSend.Text = "&Re-Enviar"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.btnSelect
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(352, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(192, 26)
        Me.LayoutControlItem1.Text = "LayoutControlItem1"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(364, 12)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(188, 22)
        Me.btnSelect.StyleController = Me.LayoutControl1
        Me.btnSelect.TabIndex = 11
        Me.btnSelect.Text = "&Marcar Todo"
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.btnUnSelect
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem8"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(162, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(190, 26)
        Me.LayoutControlItem8.Text = "LayoutControlItem8"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextToControlDistance = 0
        Me.LayoutControlItem8.TextVisible = False
        '
        'btnUnSelect
        '
        Me.btnUnSelect.Location = New System.Drawing.Point(174, 12)
        Me.btnUnSelect.Name = "btnUnSelect"
        Me.btnUnSelect.Size = New System.Drawing.Size(186, 22)
        Me.btnUnSelect.StyleController = Me.LayoutControl1
        Me.btnUnSelect.TabIndex = 12
        Me.btnUnSelect.Text = "&Desmarcar Todo"
        '
        'frmAutorizacionSAT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 394)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmAutorizacionSAT"
        Me.Text = "Autorizaciones  SAT"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridAutorizaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAutorizaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VGridStats, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridAutorizaciones As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAutorizaciones As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnFind As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents VGridStats As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnStby As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnReyected As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAproved As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents rowAproved As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowReyected As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowPending As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents colPOLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENT_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENT_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSENT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRECEIVED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSAT_RESULT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colCREATED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnUnSelect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSelect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSend As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
End Class
