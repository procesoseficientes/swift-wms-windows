<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInsuranceDocs
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInsuranceDocs))
        Me.colAMOUNTINV = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridDocs = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDocs = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPOLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOMPANY_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAMOUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAMOUNTDIF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVALIN_TO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENT_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOVERAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colINSURANCE_OWHEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.txtMonto = New DevExpress.XtraEditors.SpinEdit()
        Me.txtDescuento = New DevExpress.XtraEditors.SpinEdit()
        Me.txtDiferencia = New DevExpress.XtraEditors.SpinEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.btnBNuevo = New DevExpress.XtraBars.BarButtonItem()
        Me.btnBEditar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnBBorrar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnBRenovar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnBExel = New DevExpress.XtraBars.BarButtonItem()
        Me.btnBPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar5 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.LayoutControl1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.LayoutControl1.SuspendLayout
        CType(Me.GridDocs,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridViewDocs,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemCheckEdit1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtMonto.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtDescuento.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtDiferencia.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.LayoutControlGroup1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.LayoutControlItem3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.EmptySpaceItem1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SplitterItem1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SimpleSeparator1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.LayoutControlItem1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.LayoutControlItem2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.LayoutControlItem4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PrintingSystem1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.BarManager1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'colAMOUNTINV
        '
        Me.colAMOUNTINV.Caption = "Monto Inventario"
        Me.colAMOUNTINV.DisplayFormat.FormatString = "#,0.00#"
        Me.colAMOUNTINV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAMOUNTINV.FieldName = "AMOUNTINV"
        Me.colAMOUNTINV.Name = "colAMOUNTINV"
        Me.colAMOUNTINV.OptionsColumn.AllowEdit = false
        Me.colAMOUNTINV.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AMOUNTINV", "(Total = {0:n2})")})
        Me.colAMOUNTINV.Visible = true
        Me.colAMOUNTINV.VisibleIndex = 3
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridDocs)
        Me.LayoutControl1.Controls.Add(Me.txtMonto)
        Me.LayoutControl1.Controls.Add(Me.txtDescuento)
        Me.LayoutControl1.Controls.Add(Me.txtDiferencia)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 31)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(418, 243, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(919, 518)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridDocs
        '
        Me.GridDocs.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridDocs.Location = New System.Drawing.Point(161, 14)
        Me.GridDocs.MainView = Me.GridViewDocs
        Me.GridDocs.Name = "GridDocs"
        Me.GridDocs.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridDocs.Size = New System.Drawing.Size(746, 492)
        Me.GridDocs.TabIndex = 0
        Me.GridDocs.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDocs})
        '
        'GridViewDocs
        '
        Me.GridViewDocs.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPOLIZA, Me.colCOMPANY_NAME, Me.colAMOUNT, Me.colAMOUNTINV, Me.colAMOUNTDIF, Me.colVALIN_TO, Me.colCLIENT_NAME, Me.colCOVERAGE, Me.colDOC_ID, Me.colINSURANCE_OWHEN})
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        StyleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer))
        StyleFormatCondition1.Appearance.Options.UseBackColor = true
        StyleFormatCondition1.ApplyToRow = true
        StyleFormatCondition1.Column = Me.colAMOUNTINV
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition1.Expression = "([AMOUNT] / 2) > [AMOUNTINV]"
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        StyleFormatCondition2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer))
        StyleFormatCondition2.Appearance.Options.UseBackColor = true
        StyleFormatCondition2.ApplyToRow = true
        StyleFormatCondition2.Column = Me.colAMOUNTINV
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition2.Expression = "([AMOUNT] / 2) <  [AMOUNTINV]"
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        StyleFormatCondition3.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(128,Byte),Integer))
        StyleFormatCondition3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        StyleFormatCondition3.Appearance.Options.UseBackColor = true
        StyleFormatCondition3.Appearance.Options.UseFont = true
        StyleFormatCondition3.ApplyToRow = true
        StyleFormatCondition3.Column = Me.colAMOUNTINV
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition3.Expression = "[AMOUNTINV] >= [AMOUNT]"
        Me.GridViewDocs.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2, StyleFormatCondition3})
        Me.GridViewDocs.GridControl = Me.GridDocs
        Me.GridViewDocs.GroupCount = 1
        Me.GridViewDocs.Name = "GridViewDocs"
        Me.GridViewDocs.OptionsBehavior.Editable = false
        Me.GridViewDocs.OptionsView.ShowAutoFilterRow = true
        Me.GridViewDocs.OptionsView.ShowFooter = true
        Me.GridViewDocs.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colINSURANCE_OWHEN, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colPOLIZA
        '
        Me.colPOLIZA.Caption = "Poliza"
        Me.colPOLIZA.FieldName = "POLIZA_INSURANCE"
        Me.colPOLIZA.Name = "colPOLIZA"
        Me.colPOLIZA.OptionsColumn.AllowEdit = false
        Me.colPOLIZA.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "poliza", "(Cantidad = {0})")})
        Me.colPOLIZA.Visible = true
        Me.colPOLIZA.VisibleIndex = 0
        '
        'colCOMPANY_NAME
        '
        Me.colCOMPANY_NAME.Caption = "Compania"
        Me.colCOMPANY_NAME.FieldName = "COMPANY_NAME"
        Me.colCOMPANY_NAME.Name = "colCOMPANY_NAME"
        Me.colCOMPANY_NAME.OptionsColumn.AllowEdit = false
        Me.colCOMPANY_NAME.Visible = true
        Me.colCOMPANY_NAME.VisibleIndex = 1
        '
        'colAMOUNT
        '
        Me.colAMOUNT.Caption = "Monto Asegurado"
        Me.colAMOUNT.DisplayFormat.FormatString = "#,0.00#"
        Me.colAMOUNT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAMOUNT.FieldName = "AMOUNT"
        Me.colAMOUNT.Name = "colAMOUNT"
        Me.colAMOUNT.OptionsColumn.AllowEdit = false
        Me.colAMOUNT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AMOUNT", "(Total = {0:n2})")})
        Me.colAMOUNT.Visible = true
        Me.colAMOUNT.VisibleIndex = 2
        '
        'colAMOUNTDIF
        '
        Me.colAMOUNTDIF.Caption = "Diferencia"
        Me.colAMOUNTDIF.DisplayFormat.FormatString = "#,0.00#"
        Me.colAMOUNTDIF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAMOUNTDIF.FieldName = "AMOUNTDIF"
        Me.colAMOUNTDIF.Name = "colAMOUNTDIF"
        Me.colAMOUNTDIF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AMOUNTDIF", "(Total = {0:n2})")})
        Me.colAMOUNTDIF.Visible = true
        Me.colAMOUNTDIF.VisibleIndex = 4
        '
        'colVALIN_TO
        '
        Me.colVALIN_TO.Caption = "Fecha de Vencimiento"
        Me.colVALIN_TO.DisplayFormat.FormatString = "dd/MMMM/yyyy"
        Me.colVALIN_TO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colVALIN_TO.FieldName = "VALIN_TO"
        Me.colVALIN_TO.Name = "colVALIN_TO"
        Me.colVALIN_TO.OptionsColumn.AllowEdit = false
        Me.colVALIN_TO.Visible = true
        Me.colVALIN_TO.VisibleIndex = 5
        '
        'colCLIENT_NAME
        '
        Me.colCLIENT_NAME.Caption = "Cliente"
        Me.colCLIENT_NAME.FieldName = "CLIENT_NAME"
        Me.colCLIENT_NAME.Name = "colCLIENT_NAME"
        Me.colCLIENT_NAME.OptionsColumn.AllowEdit = false
        Me.colCLIENT_NAME.Visible = true
        Me.colCLIENT_NAME.VisibleIndex = 6
        '
        'colCOVERAGE
        '
        Me.colCOVERAGE.Caption = "Cobertura"
        Me.colCOVERAGE.FieldName = "COVERAGE"
        Me.colCOVERAGE.Name = "colCOVERAGE"
        Me.colCOVERAGE.OptionsColumn.AllowEdit = false
        Me.colCOVERAGE.Visible = true
        Me.colCOVERAGE.VisibleIndex = 7
        '
        'colDOC_ID
        '
        Me.colDOC_ID.Caption = "Codigo"
        Me.colDOC_ID.FieldName = "DOC_ID"
        Me.colDOC_ID.Name = "colDOC_ID"
        Me.colDOC_ID.OptionsColumn.AllowEdit = false
        '
        'colINSURANCE_OWHEN
        '
        Me.colINSURANCE_OWHEN.Caption = "Tipo de Seguro"
        Me.colINSURANCE_OWHEN.FieldName = "INSURANCE_OWHEN"
        Me.colINSURANCE_OWHEN.Name = "colINSURANCE_OWHEN"
        Me.colINSURANCE_OWHEN.OptionsColumn.AllowEdit = false
        Me.colINSURANCE_OWHEN.Visible = true
        Me.colINSURANCE_OWHEN.VisibleIndex = 7
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = false
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'txtMonto
        '
        Me.txtMonto.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMonto.Location = New System.Drawing.Point(102, 12)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow
        Me.txtMonto.Properties.Appearance.Options.UseBackColor = true
        Me.txtMonto.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtMonto.Properties.DisplayFormat.FormatString = "#,#.00#"
        Me.txtMonto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtMonto.Properties.EditFormat.FormatString = "#,#.00#"
        Me.txtMonto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtMonto.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.txtMonto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.txtMonto.Properties.ReadOnly = true
        Me.txtMonto.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMonto.Size = New System.Drawing.Size(50, 20)
        Me.txtMonto.StyleController = Me.LayoutControl1
        Me.txtMonto.TabIndex = 2
        '
        'txtDescuento
        '
        Me.txtDescuento.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDescuento.Location = New System.Drawing.Point(102, 36)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow
        Me.txtDescuento.Properties.Appearance.Options.UseBackColor = true
        Me.txtDescuento.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDescuento.Properties.DisplayFormat.FormatString = "#,#.00#"
        Me.txtDescuento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDescuento.Properties.EditFormat.FormatString = "#,#.00#"
        Me.txtDescuento.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDescuento.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.txtDescuento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.txtDescuento.Properties.ReadOnly = true
        Me.txtDescuento.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDescuento.Size = New System.Drawing.Size(50, 20)
        Me.txtDescuento.StyleController = Me.LayoutControl1
        Me.txtDescuento.TabIndex = 3
        '
        'txtDiferencia
        '
        Me.txtDiferencia.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDiferencia.Location = New System.Drawing.Point(102, 60)
        Me.txtDiferencia.Name = "txtDiferencia"
        Me.txtDiferencia.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow
        Me.txtDiferencia.Properties.Appearance.Options.UseBackColor = true
        Me.txtDiferencia.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDiferencia.Properties.DisplayFormat.FormatString = "#,#.00#"
        Me.txtDiferencia.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDiferencia.Properties.EditFormat.FormatString = "#,#.00#"
        Me.txtDiferencia.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDiferencia.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.txtDiferencia.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.txtDiferencia.Properties.ReadOnly = true
        Me.txtDiferencia.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDiferencia.Size = New System.Drawing.Size(50, 20)
        Me.txtDiferencia.StyleController = Me.LayoutControl1
        Me.txtDiferencia.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = false
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.EmptySpaceItem1, Me.SplitterItem1, Me.SimpleSeparator1, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(919, 518)
        Me.LayoutControlGroup1.TextVisible = false
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.GridDocs
        Me.LayoutControlItem3.CustomizationFormText = "Grid Autorizaciones"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(149, 2)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(750, 496)
        Me.LayoutControlItem3.Text = "Grid Autorizaciones"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = false
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = false
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 72)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(144, 426)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = true
        Me.SplitterItem1.CustomizationFormText = "SplitterItem1"
        Me.SplitterItem1.Location = New System.Drawing.Point(144, 0)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(5, 498)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = false
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(149, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(750, 2)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtMonto
        Me.LayoutControlItem1.CustomizationFormText = "Monto:"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(144, 24)
        Me.LayoutControlItem1.Text = "Monto Seguro:"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(87, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtDescuento
        Me.LayoutControlItem2.CustomizationFormText = "Descuento:"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(144, 24)
        Me.LayoutControlItem2.Text = "Monto Inventario:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(87, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtDiferencia
        Me.LayoutControlItem4.CustomizationFormText = "Diferencia:"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(144, 24)
        Me.LayoutControlItem4.Text = "Diferencia:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(87, 13)
        '
        'Bar1
        '
        Me.Bar1.BarName = "Herramientas"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.Text = "Herramientas"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Herramientas"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.Text = "Herramientas"
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar3, Me.Bar5})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnBNuevo, Me.btnBEditar, Me.btnBBorrar, Me.btnBExel, Me.btnBPrint, Me.btnBRenovar, Me.btnRefresh})
        Me.BarManager1.MaxItemId = 7
        Me.BarManager1.StatusBar = Me.Bar5
        '
        'Bar3
        '
        Me.Bar3.BarName = "Herramientas"
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar3.FloatLocation = New System.Drawing.Point(292, 152)
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnBNuevo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnBEditar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnBBorrar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnBRenovar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnBExel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnBPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = false
        Me.Bar3.Text = "Herramientas"
        '
        'btnBNuevo
        '
        Me.btnBNuevo.Caption = "Nuevo"
        Me.btnBNuevo.Glyph = CType(resources.GetObject("btnBNuevo.Glyph"),System.Drawing.Image)
        Me.btnBNuevo.Id = 0
        Me.btnBNuevo.LargeGlyph = CType(resources.GetObject("btnBNuevo.LargeGlyph"),System.Drawing.Image)
        Me.btnBNuevo.Name = "btnBNuevo"
        '
        'btnBEditar
        '
        Me.btnBEditar.Caption = "Editar"
        Me.btnBEditar.Glyph = CType(resources.GetObject("btnBEditar.Glyph"),System.Drawing.Image)
        Me.btnBEditar.Id = 1
        Me.btnBEditar.LargeGlyph = CType(resources.GetObject("btnBEditar.LargeGlyph"),System.Drawing.Image)
        Me.btnBEditar.Name = "btnBEditar"
        '
        'btnBBorrar
        '
        Me.btnBBorrar.Caption = "Eliminar"
        Me.btnBBorrar.Glyph = CType(resources.GetObject("btnBBorrar.Glyph"),System.Drawing.Image)
        Me.btnBBorrar.Id = 2
        Me.btnBBorrar.LargeGlyph = CType(resources.GetObject("btnBBorrar.LargeGlyph"),System.Drawing.Image)
        Me.btnBBorrar.Name = "btnBBorrar"
        '
        'btnBRenovar
        '
        Me.btnBRenovar.Caption = "Renovar"
        Me.btnBRenovar.Glyph = CType(resources.GetObject("btnBRenovar.Glyph"),System.Drawing.Image)
        Me.btnBRenovar.Id = 5
        Me.btnBRenovar.LargeGlyph = CType(resources.GetObject("btnBRenovar.LargeGlyph"),System.Drawing.Image)
        Me.btnBRenovar.Name = "btnBRenovar"
        '
        'btnBExel
        '
        Me.btnBExel.Caption = "Exel"
        Me.btnBExel.Glyph = CType(resources.GetObject("btnBExel.Glyph"),System.Drawing.Image)
        Me.btnBExel.Id = 3
        Me.btnBExel.LargeGlyph = CType(resources.GetObject("btnBExel.LargeGlyph"),System.Drawing.Image)
        Me.btnBExel.Name = "btnBExel"
        '
        'btnBPrint
        '
        Me.btnBPrint.Caption = "Imprimir"
        Me.btnBPrint.Glyph = CType(resources.GetObject("btnBPrint.Glyph"),System.Drawing.Image)
        Me.btnBPrint.Id = 4
        Me.btnBPrint.LargeGlyph = CType(resources.GetObject("btnBPrint.LargeGlyph"),System.Drawing.Image)
        Me.btnBPrint.Name = "btnBPrint"
        '
        'btnRefresh
        '
        Me.btnRefresh.Caption = "Refresh"
        Me.btnRefresh.Glyph = CType(resources.GetObject("btnRefresh.Glyph"),System.Drawing.Image)
        Me.btnRefresh.Id = 6
        Me.btnRefresh.LargeGlyph = CType(resources.GetObject("btnRefresh.LargeGlyph"),System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        '
        'Bar5
        '
        Me.Bar5.BarName = "Barra de estado"
        Me.Bar5.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar5.DockCol = 0
        Me.Bar5.DockRow = 0
        Me.Bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar5.OptionsBar.AllowQuickCustomization = false
        Me.Bar5.OptionsBar.DrawDragBorder = false
        Me.Bar5.OptionsBar.UseWholeRow = true
        Me.Bar5.Text = "Barra de estado"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = false
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(919, 31)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = false
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 549)
        Me.barDockControlBottom.Size = New System.Drawing.Size(919, 23)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = false
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 31)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 518)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = false
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(919, 31)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 518)
        '
        'frmInsuranceDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 572)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmInsuranceDocs"
        Me.Text = "Polizas de Seguro"
        CType(Me.LayoutControl1,System.ComponentModel.ISupportInitialize).EndInit
        Me.LayoutControl1.ResumeLayout(false)
        CType(Me.GridDocs,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridViewDocs,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemCheckEdit1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtMonto.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtDescuento.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtDiferencia.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.LayoutControlGroup1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.LayoutControlItem3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.EmptySpaceItem1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SplitterItem1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SimpleSeparator1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.LayoutControlItem1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.LayoutControlItem2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.LayoutControlItem4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PrintingSystem1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.BarManager1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridDocs As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDocs As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPOLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOMPANY_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAMOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVALIN_TO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents colCLIENT_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents colCOVERAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents colINSURANCE_OWHEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtMonto As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtDescuento As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtDiferencia As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents colAMOUNTINV As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents btnBNuevo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnBEditar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnBBorrar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnBRenovar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnBExel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnBPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar5 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colAMOUNTDIF As DevExpress.XtraGrid.Columns.GridColumn
End Class
