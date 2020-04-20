<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVencimientoPolizas
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim StyleFormatCondition4 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition5 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition6 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim ToolTipSeparatorItem1 As DevExpress.Utils.ToolTipSeparatorItem = New DevExpress.Utils.ToolTipSeparatorItem()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim ToolTipSeparatorItem2 As DevExpress.Utils.ToolTipSeparatorItem = New DevExpress.Utils.ToolTipSeparatorItem()
        Dim ToolTipTitleItem4 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem5 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim ToolTipSeparatorItem3 As DevExpress.Utils.ToolTipSeparatorItem = New DevExpress.Utils.ToolTipSeparatorItem()
        Dim ToolTipTitleItem6 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem7 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim ToolTipTitleItem8 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim SuperToolTip5 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem9 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem5 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim ToolTipSeparatorItem4 As DevExpress.Utils.ToolTipSeparatorItem = New DevExpress.Utils.ToolTipSeparatorItem()
        Dim ToolTipTitleItem10 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVencimientoPolizas))
        Dim SuperToolTip6 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem11 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem6 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim ToolTipSeparatorItem5 As DevExpress.Utils.ToolTipSeparatorItem = New DevExpress.Utils.ToolTipSeparatorItem()
        Dim ToolTipTitleItem12 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim SuperToolTip7 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem13 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem7 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim ToolTipSeparatorItem6 As DevExpress.Utils.ToolTipSeparatorItem = New DevExpress.Utils.ToolTipSeparatorItem()
        Dim ToolTipTitleItem14 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Me.GridViewPolizaSeguro = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSPOLIZA_INSURANCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSCODIGO_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSNUMERO_ORDEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSCLIENT_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSACUERDO_COMERCIAL_NOMBRE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSFECHA_LLEGADA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSVALIN_TO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSDAYS_REMAINING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridViewTipoPoliza = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTCODIGO_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTNUMERO_ORDEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTCLIENT_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTACUERDO_COMERCIAL_NOMBRE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTFECHA_LLEGADA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTREGIMEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTVALIN_TO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTDAYS_REMAINING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView8 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colBARCODE_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMATERIAL_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSCANNED_COUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colINPUTED_COUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLAST_UPDATED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NavBarControlTransOnLine = New DevExpress.XtraNavBar.NavBarControl()
        Me.NavBarGroupFilter = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarGroupControlContainer1 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.btnGo = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.chkBtnHoy = New DevExpress.XtraEditors.CheckButton()
        Me.dtFechaFinal = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.dtFechaInicial = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.chkBtnAyer = New DevExpress.XtraEditors.CheckButton()
        Me.chkbtnSemana = New DevExpress.XtraEditors.CheckButton()
        Me.chkMes = New DevExpress.XtraEditors.CheckButton()
        Me.chkTresMeses = New DevExpress.XtraEditors.CheckButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.chkBtnSeguroPoliza = New DevExpress.XtraEditors.CheckButton()
        Me.chkBtnTipoPoliza = New DevExpress.XtraEditors.CheckButton()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.btnExel = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExpandirTodo = New DevExpress.XtraBars.BarButtonItem()
        Me.btnContraerTodo = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.GridViewPolizaSeguro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTipoPoliza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NavBarControlTransOnLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavBarControlTransOnLine.SuspendLayout()
        Me.NavBarGroupControlContainer1.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.dtFechaFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaFinal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaInicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaInicial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridViewPolizaSeguro
        '
        Me.GridViewPolizaSeguro.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSPOLIZA_INSURANCE, Me.colSDOC_ID, Me.colSCODIGO_POLIZA, Me.colSNUMERO_ORDEN, Me.colSCLIENT_NAME, Me.colSACUERDO_COMERCIAL_NOMBRE, Me.colSFECHA_LLEGADA, Me.colSVALIN_TO, Me.colSDAYS_REMAINING})
        Me.GridViewPolizaSeguro.CustomizationFormBounds = New System.Drawing.Rectangle(749, 393, 216, 178)
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        StyleFormatCondition1.Appearance.Options.UseBackColor = True
        StyleFormatCondition1.ApplyToRow = True
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition1.Expression = "[DAYS_REMAINING] <= 60"
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        StyleFormatCondition2.Appearance.Options.UseBackColor = True
        StyleFormatCondition2.ApplyToRow = True
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition2.Expression = "[DAYS_REMAINING] <= 8"
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        StyleFormatCondition3.Appearance.Options.UseBackColor = True
        StyleFormatCondition3.ApplyToRow = True
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition3.Expression = "[DAYS_REMAINING] > 60"
        Me.GridViewPolizaSeguro.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2, StyleFormatCondition3})
        Me.GridViewPolizaSeguro.GridControl = Me.GridControl1
        Me.GridViewPolizaSeguro.Name = "GridViewPolizaSeguro"
        Me.GridViewPolizaSeguro.OptionsView.ShowAutoFilterRow = True
        '
        'colSPOLIZA_INSURANCE
        '
        Me.colSPOLIZA_INSURANCE.Caption = "Poliza de Seguro"
        Me.colSPOLIZA_INSURANCE.FieldName = "POLIZA_INSURANCE"
        Me.colSPOLIZA_INSURANCE.Name = "colSPOLIZA_INSURANCE"
        Me.colSPOLIZA_INSURANCE.OptionsColumn.AllowEdit = False
        Me.colSPOLIZA_INSURANCE.Visible = True
        Me.colSPOLIZA_INSURANCE.VisibleIndex = 0
        '
        'colSDOC_ID
        '
        Me.colSDOC_ID.Caption = "Numero de Documento"
        Me.colSDOC_ID.FieldName = "DOC_ID"
        Me.colSDOC_ID.Name = "colSDOC_ID"
        Me.colSDOC_ID.OptionsColumn.AllowEdit = False
        Me.colSDOC_ID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.colSDOC_ID.Visible = True
        Me.colSDOC_ID.VisibleIndex = 1
        '
        'colSCODIGO_POLIZA
        '
        Me.colSCODIGO_POLIZA.Caption = "Codigo de Poliza"
        Me.colSCODIGO_POLIZA.FieldName = "CODIGO_POLIZA"
        Me.colSCODIGO_POLIZA.Name = "colSCODIGO_POLIZA"
        Me.colSCODIGO_POLIZA.OptionsColumn.AllowEdit = False
        Me.colSCODIGO_POLIZA.Visible = True
        Me.colSCODIGO_POLIZA.VisibleIndex = 2
        '
        'colSNUMERO_ORDEN
        '
        Me.colSNUMERO_ORDEN.Caption = "Numero de Orden"
        Me.colSNUMERO_ORDEN.FieldName = "NUMERO_ORDEN"
        Me.colSNUMERO_ORDEN.Name = "colSNUMERO_ORDEN"
        Me.colSNUMERO_ORDEN.OptionsColumn.AllowEdit = False
        Me.colSNUMERO_ORDEN.Visible = True
        Me.colSNUMERO_ORDEN.VisibleIndex = 3
        '
        'colSCLIENT_NAME
        '
        Me.colSCLIENT_NAME.Caption = "Cliente"
        Me.colSCLIENT_NAME.FieldName = "CLIENT_NAME"
        Me.colSCLIENT_NAME.Name = "colSCLIENT_NAME"
        Me.colSCLIENT_NAME.OptionsColumn.AllowEdit = False
        Me.colSCLIENT_NAME.Visible = True
        Me.colSCLIENT_NAME.VisibleIndex = 4
        '
        'colSACUERDO_COMERCIAL_NOMBRE
        '
        Me.colSACUERDO_COMERCIAL_NOMBRE.Caption = "Acuerdo Comercial"
        Me.colSACUERDO_COMERCIAL_NOMBRE.FieldName = "ACUERDO_COMERCIAL_NOMBRE"
        Me.colSACUERDO_COMERCIAL_NOMBRE.Name = "colSACUERDO_COMERCIAL_NOMBRE"
        Me.colSACUERDO_COMERCIAL_NOMBRE.OptionsColumn.AllowEdit = False
        Me.colSACUERDO_COMERCIAL_NOMBRE.Visible = True
        Me.colSACUERDO_COMERCIAL_NOMBRE.VisibleIndex = 5
        '
        'colSFECHA_LLEGADA
        '
        Me.colSFECHA_LLEGADA.Caption = "Fecha de Ingreso"
        Me.colSFECHA_LLEGADA.FieldName = "FECHA_LLEGADA"
        Me.colSFECHA_LLEGADA.Name = "colSFECHA_LLEGADA"
        Me.colSFECHA_LLEGADA.OptionsColumn.AllowEdit = False
        Me.colSFECHA_LLEGADA.Visible = True
        Me.colSFECHA_LLEGADA.VisibleIndex = 6
        '
        'colSVALIN_TO
        '
        Me.colSVALIN_TO.Caption = "Fecha de Vencimiento"
        Me.colSVALIN_TO.FieldName = "VALIN_TO"
        Me.colSVALIN_TO.Name = "colSVALIN_TO"
        Me.colSVALIN_TO.OptionsColumn.AllowEdit = False
        Me.colSVALIN_TO.Visible = True
        Me.colSVALIN_TO.VisibleIndex = 7
        '
        'colSDAYS_REMAINING
        '
        Me.colSDAYS_REMAINING.Caption = "Dias Restantes"
        Me.colSDAYS_REMAINING.FieldName = "DAYS_REMAINING"
        Me.colSDAYS_REMAINING.Name = "colSDAYS_REMAINING"
        Me.colSDAYS_REMAINING.OptionsColumn.AllowEdit = False
        Me.colSDAYS_REMAINING.Visible = True
        Me.colSDAYS_REMAINING.VisibleIndex = 8
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataMember = Nothing
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.LevelTemplate = Me.GridViewPolizaSeguro
        GridLevelNode1.RelationName = "DispatchView"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(227, 31)
        Me.GridControl1.MainView = Me.GridViewTipoPoliza
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(687, 461)
        Me.GridControl1.TabIndex = 10
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewTipoPoliza, Me.GridView7, Me.GridView8, Me.GridView4, Me.GridView5, Me.GridView2, Me.GridView3, Me.GridView6, Me.GridViewPolizaSeguro})
        '
        'GridViewTipoPoliza
        '
        Me.GridViewTipoPoliza.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridViewTipoPoliza.AppearancePrint.HeaderPanel.BackColor2 = System.Drawing.Color.Silver
        Me.GridViewTipoPoliza.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GridViewTipoPoliza.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridViewTipoPoliza.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GridViewTipoPoliza.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GridViewTipoPoliza.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GridViewTipoPoliza.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTDOC_ID, Me.colTCODIGO_POLIZA, Me.colTNUMERO_ORDEN, Me.colTCLIENT_NAME, Me.colTACUERDO_COMERCIAL_NOMBRE, Me.colTFECHA_LLEGADA, Me.colTREGIMEN, Me.colTVALIN_TO, Me.colTDAYS_REMAINING})
        StyleFormatCondition4.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        StyleFormatCondition4.Appearance.Options.UseBackColor = True
        StyleFormatCondition4.ApplyToRow = True
        StyleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition4.Expression = "[DAYS_REMAINING] <=  60"
        StyleFormatCondition5.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        StyleFormatCondition5.Appearance.Options.UseBackColor = True
        StyleFormatCondition5.ApplyToRow = True
        StyleFormatCondition5.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition5.Expression = "[DAYS_REMAINING] <= 8"
        StyleFormatCondition6.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        StyleFormatCondition6.Appearance.Options.UseBackColor = True
        StyleFormatCondition6.ApplyToRow = True
        StyleFormatCondition6.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition6.Expression = "[DAYS_REMAINING] > 60"
        Me.GridViewTipoPoliza.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition4, StyleFormatCondition5, StyleFormatCondition6})
        Me.GridViewTipoPoliza.GridControl = Me.GridControl1
        Me.GridViewTipoPoliza.Name = "GridViewTipoPoliza"
        Me.GridViewTipoPoliza.OptionsBehavior.ReadOnly = True
        Me.GridViewTipoPoliza.OptionsPrint.ExpandAllDetails = True
        Me.GridViewTipoPoliza.OptionsPrint.PrintDetails = True
        Me.GridViewTipoPoliza.OptionsPrint.PrintFilterInfo = True
        Me.GridViewTipoPoliza.OptionsPrint.PrintPreview = True
        Me.GridViewTipoPoliza.OptionsPrint.PrintSelectedRowsOnly = True
        Me.GridViewTipoPoliza.OptionsView.ShowAutoFilterRow = True
        Me.GridViewTipoPoliza.OptionsView.ShowFooter = True
        '
        'colTDOC_ID
        '
        Me.colTDOC_ID.Caption = "Numero de Documento"
        Me.colTDOC_ID.FieldName = "DOC_ID"
        Me.colTDOC_ID.Name = "colTDOC_ID"
        Me.colTDOC_ID.OptionsColumn.AllowEdit = False
        Me.colTDOC_ID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.colTDOC_ID.Visible = True
        Me.colTDOC_ID.VisibleIndex = 0
        '
        'colTCODIGO_POLIZA
        '
        Me.colTCODIGO_POLIZA.Caption = "Codigo de Poliza"
        Me.colTCODIGO_POLIZA.FieldName = "CODIGO_POLIZA"
        Me.colTCODIGO_POLIZA.Name = "colTCODIGO_POLIZA"
        Me.colTCODIGO_POLIZA.OptionsColumn.AllowEdit = False
        Me.colTCODIGO_POLIZA.Visible = True
        Me.colTCODIGO_POLIZA.VisibleIndex = 1
        '
        'colTNUMERO_ORDEN
        '
        Me.colTNUMERO_ORDEN.Caption = "Numero de Orden"
        Me.colTNUMERO_ORDEN.FieldName = "NUMERO_ORDEN"
        Me.colTNUMERO_ORDEN.Name = "colTNUMERO_ORDEN"
        Me.colTNUMERO_ORDEN.OptionsColumn.AllowEdit = False
        Me.colTNUMERO_ORDEN.Visible = True
        Me.colTNUMERO_ORDEN.VisibleIndex = 2
        '
        'colTCLIENT_NAME
        '
        Me.colTCLIENT_NAME.Caption = "Cliente"
        Me.colTCLIENT_NAME.FieldName = "CLIENT_NAME"
        Me.colTCLIENT_NAME.Name = "colTCLIENT_NAME"
        Me.colTCLIENT_NAME.OptionsColumn.AllowEdit = False
        Me.colTCLIENT_NAME.Visible = True
        Me.colTCLIENT_NAME.VisibleIndex = 3
        '
        'colTACUERDO_COMERCIAL_NOMBRE
        '
        Me.colTACUERDO_COMERCIAL_NOMBRE.Caption = "Acuerdo Comercial"
        Me.colTACUERDO_COMERCIAL_NOMBRE.FieldName = "ACUERDO_COMERCIAL_NOMBRE"
        Me.colTACUERDO_COMERCIAL_NOMBRE.Name = "colTACUERDO_COMERCIAL_NOMBRE"
        Me.colTACUERDO_COMERCIAL_NOMBRE.OptionsColumn.AllowEdit = False
        Me.colTACUERDO_COMERCIAL_NOMBRE.Visible = True
        Me.colTACUERDO_COMERCIAL_NOMBRE.VisibleIndex = 4
        '
        'colTFECHA_LLEGADA
        '
        Me.colTFECHA_LLEGADA.Caption = "Fecha de Ingreso"
        Me.colTFECHA_LLEGADA.FieldName = "FECHA_LLEGADA"
        Me.colTFECHA_LLEGADA.Name = "colTFECHA_LLEGADA"
        Me.colTFECHA_LLEGADA.OptionsColumn.AllowEdit = False
        Me.colTFECHA_LLEGADA.Visible = True
        Me.colTFECHA_LLEGADA.VisibleIndex = 5
        '
        'colTREGIMEN
        '
        Me.colTREGIMEN.Caption = "Regimen"
        Me.colTREGIMEN.FieldName = "REGIMEN"
        Me.colTREGIMEN.Name = "colTREGIMEN"
        Me.colTREGIMEN.OptionsColumn.AllowEdit = False
        Me.colTREGIMEN.Visible = True
        Me.colTREGIMEN.VisibleIndex = 6
        '
        'colTVALIN_TO
        '
        Me.colTVALIN_TO.Caption = "Fecha de Vencimiento"
        Me.colTVALIN_TO.FieldName = "VALIN_TO"
        Me.colTVALIN_TO.Name = "colTVALIN_TO"
        Me.colTVALIN_TO.OptionsColumn.AllowEdit = False
        Me.colTVALIN_TO.Visible = True
        Me.colTVALIN_TO.VisibleIndex = 7
        '
        'colTDAYS_REMAINING
        '
        Me.colTDAYS_REMAINING.Caption = "Dias Restantes"
        Me.colTDAYS_REMAINING.FieldName = "DAYS_REMAINING"
        Me.colTDAYS_REMAINING.Name = "colTDAYS_REMAINING"
        Me.colTDAYS_REMAINING.OptionsColumn.AllowEdit = False
        Me.colTDAYS_REMAINING.Visible = True
        Me.colTDAYS_REMAINING.VisibleIndex = 8
        '
        'GridView7
        '
        Me.GridView7.GridControl = Me.GridControl1
        Me.GridView7.Name = "GridView7"
        '
        'GridView8
        '
        Me.GridView8.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colBARCODE_ID, Me.colMATERIAL_NAME, Me.colSCANNED_COUNT, Me.colINPUTED_COUNT, Me.colLAST_UPDATED})
        Me.GridView8.GridControl = Me.GridControl1
        Me.GridView8.Name = "GridView8"
        '
        'colBARCODE_ID
        '
        Me.colBARCODE_ID.FieldName = "BARCODE_ID"
        Me.colBARCODE_ID.Name = "colBARCODE_ID"
        Me.colBARCODE_ID.Visible = True
        Me.colBARCODE_ID.VisibleIndex = 0
        '
        'colMATERIAL_NAME
        '
        Me.colMATERIAL_NAME.FieldName = "MATERIAL_NAME"
        Me.colMATERIAL_NAME.Name = "colMATERIAL_NAME"
        Me.colMATERIAL_NAME.Visible = True
        Me.colMATERIAL_NAME.VisibleIndex = 1
        '
        'colSCANNED_COUNT
        '
        Me.colSCANNED_COUNT.FieldName = "SCANNED_COUNT"
        Me.colSCANNED_COUNT.Name = "colSCANNED_COUNT"
        Me.colSCANNED_COUNT.Visible = True
        Me.colSCANNED_COUNT.VisibleIndex = 2
        '
        'colINPUTED_COUNT
        '
        Me.colINPUTED_COUNT.FieldName = "INPUTED_COUNT"
        Me.colINPUTED_COUNT.Name = "colINPUTED_COUNT"
        Me.colINPUTED_COUNT.Visible = True
        Me.colINPUTED_COUNT.VisibleIndex = 3
        '
        'colLAST_UPDATED
        '
        Me.colLAST_UPDATED.FieldName = "LAST_UPDATED"
        Me.colLAST_UPDATED.Name = "colLAST_UPDATED"
        Me.colLAST_UPDATED.Visible = True
        Me.colLAST_UPDATED.VisibleIndex = 4
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.GridControl1
        Me.GridView4.Name = "GridView4"
        '
        'GridView5
        '
        Me.GridView5.GridControl = Me.GridControl1
        Me.GridView5.Name = "GridView5"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.Name = "GridView2"
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GridControl1
        Me.GridView3.Name = "GridView3"
        '
        'GridView6
        '
        Me.GridView6.GridControl = Me.GridControl1
        Me.GridView6.Name = "GridView6"
        '
        'NavBarControlTransOnLine
        '
        Me.NavBarControlTransOnLine.ActiveGroup = Me.NavBarGroupFilter
        Me.NavBarControlTransOnLine.ContentButtonHint = Nothing
        Me.NavBarControlTransOnLine.Controls.Add(Me.NavBarGroupControlContainer1)
        Me.NavBarControlTransOnLine.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavBarControlTransOnLine.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.NavBarGroupFilter})
        Me.NavBarControlTransOnLine.Location = New System.Drawing.Point(0, 31)
        Me.NavBarControlTransOnLine.Name = "NavBarControlTransOnLine"
        Me.NavBarControlTransOnLine.OptionsNavPane.ExpandedWidth = 227
        Me.NavBarControlTransOnLine.Size = New System.Drawing.Size(227, 461)
        Me.NavBarControlTransOnLine.TabIndex = 5
        Me.NavBarControlTransOnLine.Text = "NavBarControl1"
        Me.NavBarControlTransOnLine.View = New DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator()
        '
        'NavBarGroupFilter
        '
        Me.NavBarGroupFilter.Caption = "FiltroInformacion"
        Me.NavBarGroupFilter.ControlContainer = Me.NavBarGroupControlContainer1
        Me.NavBarGroupFilter.Expanded = True
        Me.NavBarGroupFilter.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Small
        Me.NavBarGroupFilter.GroupClientHeight = 80
        Me.NavBarGroupFilter.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavBarGroupFilter.Name = "NavBarGroupFilter"
        Me.NavBarGroupFilter.SmallImage = Global.WMSOnePlan_Client.My.Resources.Resources.Small_Find
        '
        'NavBarGroupControlContainer1
        '
        Me.NavBarGroupControlContainer1.Controls.Add(Me.PanelControl3)
        Me.NavBarGroupControlContainer1.Name = "NavBarGroupControlContainer1"
        Me.NavBarGroupControlContainer1.Size = New System.Drawing.Size(227, 358)
        Me.NavBarGroupControlContainer1.TabIndex = 0
        '
        'PanelControl3
        '
        Me.PanelControl3.Appearance.BackColor = System.Drawing.Color.White
        Me.PanelControl3.Appearance.Options.UseBackColor = True
        Me.PanelControl3.Controls.Add(Me.btnGo)
        Me.PanelControl3.Controls.Add(Me.GroupControl1)
        Me.PanelControl3.Controls.Add(Me.GroupControl2)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.PanelControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(227, 358)
        Me.PanelControl3.TabIndex = 1
        '
        'btnGo
        '
        Me.btnGo.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnGo.Location = New System.Drawing.Point(3, 264)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(221, 23)
        Me.btnGo.TabIndex = 8
        Me.btnGo.Text = "Aceptar"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.chkBtnHoy)
        Me.GroupControl1.Controls.Add(Me.dtFechaFinal)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.dtFechaInicial)
        Me.GroupControl1.Controls.Add(Me.LabelControl6)
        Me.GroupControl1.Controls.Add(Me.chkBtnAyer)
        Me.GroupControl1.Controls.Add(Me.chkbtnSemana)
        Me.GroupControl1.Controls.Add(Me.chkMes)
        Me.GroupControl1.Controls.Add(Me.chkTresMeses)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(3, 101)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(221, 163)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Rango de fechas:"
        '
        'chkBtnHoy
        '
        Me.chkBtnHoy.AllowFocus = False
        Me.chkBtnHoy.Appearance.Options.UseTextOptions = True
        Me.chkBtnHoy.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkBtnHoy.Checked = True
        Me.chkBtnHoy.GroupIndex = 1
        Me.chkBtnHoy.Location = New System.Drawing.Point(2, 23)
        Me.chkBtnHoy.Name = "chkBtnHoy"
        Me.chkBtnHoy.Size = New System.Drawing.Size(40, 38)
        ToolTipTitleItem1.Text = "TransaccionesEnLinea"
        ToolTipItem1.Appearance.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem1.Appearance.Options.UseImage = True
        ToolTipItem1.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Consultar transacciones desde el dia de ayer hasta la fecha"
        ToolTipTitleItem2.LeftIndent = 6
        ToolTipTitleItem2.Text = "Filtros"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        SuperToolTip1.Items.Add(ToolTipSeparatorItem1)
        SuperToolTip1.Items.Add(ToolTipTitleItem2)
        Me.chkBtnHoy.SuperTip = SuperToolTip1
        Me.chkBtnHoy.TabIndex = 8
        Me.chkBtnHoy.Text = "Hoy"
        '
        'dtFechaFinal
        '
        Me.dtFechaFinal.EditValue = New Date(2014, 7, 4, 8, 43, 55, 0)
        Me.dtFechaFinal.EnterMoveNextControl = True
        Me.dtFechaFinal.Location = New System.Drawing.Point(3, 132)
        Me.dtFechaFinal.Name = "dtFechaFinal"
        Me.dtFechaFinal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaFinal.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.dtFechaFinal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtFechaFinal.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d"
        Me.dtFechaFinal.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtFechaFinal.Properties.CalendarTimeProperties.EditFormat.FormatString = "d"
        Me.dtFechaFinal.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtFechaFinal.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.dtFechaFinal.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText
        Me.dtFechaFinal.Properties.Mask.BeepOnError = True
        Me.dtFechaFinal.Properties.ShowWeekNumbers = True
        Me.dtFechaFinal.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.dtFechaFinal.Size = New System.Drawing.Size(203, 20)
        Me.dtFechaFinal.TabIndex = 7
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(6, 113)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl5.TabIndex = 6
        Me.LabelControl5.Text = "Fecha Final:"
        '
        'dtFechaInicial
        '
        Me.dtFechaInicial.EditValue = New Date(2014, 7, 4, 8, 43, 48, 0)
        Me.dtFechaInicial.EnterMoveNextControl = True
        Me.dtFechaInicial.Location = New System.Drawing.Point(3, 87)
        Me.dtFechaInicial.Name = "dtFechaInicial"
        Me.dtFechaInicial.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaInicial.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.dtFechaInicial.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtFechaInicial.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d"
        Me.dtFechaInicial.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtFechaInicial.Properties.CalendarTimeProperties.EditFormat.FormatString = "d"
        Me.dtFechaInicial.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtFechaInicial.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.dtFechaInicial.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText
        Me.dtFechaInicial.Properties.Mask.BeepOnError = True
        Me.dtFechaInicial.Properties.ShowWeekNumbers = True
        Me.dtFechaInicial.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.dtFechaInicial.Size = New System.Drawing.Size(203, 20)
        Me.dtFechaInicial.TabIndex = 6
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(6, 67)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl6.TabIndex = 4
        Me.LabelControl6.Text = "Fecha Inicial:"
        '
        'chkBtnAyer
        '
        Me.chkBtnAyer.AllowFocus = False
        Me.chkBtnAyer.Appearance.Options.UseTextOptions = True
        Me.chkBtnAyer.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkBtnAyer.GroupIndex = 1
        Me.chkBtnAyer.Location = New System.Drawing.Point(45, 23)
        Me.chkBtnAyer.Name = "chkBtnAyer"
        Me.chkBtnAyer.Size = New System.Drawing.Size(37, 38)
        ToolTipTitleItem3.Text = "TransaccionesEnLinea"
        ToolTipItem2.Appearance.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem2.Appearance.Options.UseImage = True
        ToolTipItem2.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Consultar transacciones desde el dia de ayer hasta la fecha"
        ToolTipTitleItem4.LeftIndent = 6
        ToolTipTitleItem4.Text = "Filtros"
        SuperToolTip2.Items.Add(ToolTipTitleItem3)
        SuperToolTip2.Items.Add(ToolTipItem2)
        SuperToolTip2.Items.Add(ToolTipSeparatorItem2)
        SuperToolTip2.Items.Add(ToolTipTitleItem4)
        Me.chkBtnAyer.SuperTip = SuperToolTip2
        Me.chkBtnAyer.TabIndex = 5
        Me.chkBtnAyer.TabStop = False
        Me.chkBtnAyer.Text = "Mañana"
        '
        'chkbtnSemana
        '
        Me.chkbtnSemana.AllowFocus = False
        Me.chkbtnSemana.Appearance.Options.UseTextOptions = True
        Me.chkbtnSemana.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkbtnSemana.GroupIndex = 1
        Me.chkbtnSemana.Location = New System.Drawing.Point(86, 24)
        Me.chkbtnSemana.Name = "chkbtnSemana"
        Me.chkbtnSemana.Size = New System.Drawing.Size(40, 38)
        ToolTipTitleItem5.Text = "TransaccionesEnLinea"
        ToolTipItem3.Appearance.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem3.Appearance.Options.UseImage = True
        ToolTipItem3.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Consultar transacciones desde 1 semana a la fecha"
        ToolTipTitleItem6.LeftIndent = 6
        ToolTipTitleItem6.Text = "Filtros"
        SuperToolTip3.Items.Add(ToolTipTitleItem5)
        SuperToolTip3.Items.Add(ToolTipItem3)
        SuperToolTip3.Items.Add(ToolTipSeparatorItem3)
        SuperToolTip3.Items.Add(ToolTipTitleItem6)
        Me.chkbtnSemana.SuperTip = SuperToolTip3
        Me.chkbtnSemana.TabIndex = 4
        Me.chkbtnSemana.TabStop = False
        Me.chkbtnSemana.Text = "1 Semana"
        '
        'chkMes
        '
        Me.chkMes.AllowFocus = False
        Me.chkMes.Appearance.Options.UseTextOptions = True
        Me.chkMes.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkMes.GroupIndex = 1
        Me.chkMes.Location = New System.Drawing.Point(131, 23)
        Me.chkMes.Name = "chkMes"
        Me.chkMes.Size = New System.Drawing.Size(40, 38)
        ToolTipTitleItem7.Text = "TransaccionesEnLinea"
        ToolTipItem4.Appearance.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem4.Appearance.Options.UseImage = True
        ToolTipItem4.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Consultar transacciones desde 3 meses a la fecha"
        ToolTipTitleItem8.LeftIndent = 6
        ToolTipTitleItem8.Text = "Filtros"
        SuperToolTip4.Items.Add(ToolTipTitleItem7)
        SuperToolTip4.Items.Add(ToolTipItem4)
        SuperToolTip4.Items.Add(ToolTipTitleItem8)
        Me.chkMes.SuperTip = SuperToolTip4
        Me.chkMes.TabIndex = 3
        Me.chkMes.TabStop = False
        Me.chkMes.Text = "1   Mes"
        '
        'chkTresMeses
        '
        Me.chkTresMeses.AllowAllUnchecked = True
        Me.chkTresMeses.AllowFocus = False
        Me.chkTresMeses.Appearance.Options.UseTextOptions = True
        Me.chkTresMeses.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkTresMeses.GroupIndex = 1
        Me.chkTresMeses.Location = New System.Drawing.Point(175, 23)
        Me.chkTresMeses.Name = "chkTresMeses"
        Me.chkTresMeses.Size = New System.Drawing.Size(40, 38)
        ToolTipTitleItem9.Text = "TransaccionesEnLinea"
        ToolTipItem5.Appearance.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem5.Appearance.Options.UseImage = True
        ToolTipItem5.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Consultar transacciones desde 3 meses a la fecha"
        ToolTipTitleItem10.LeftIndent = 6
        ToolTipTitleItem10.Text = "Filtros"
        SuperToolTip5.Items.Add(ToolTipTitleItem9)
        SuperToolTip5.Items.Add(ToolTipItem5)
        SuperToolTip5.Items.Add(ToolTipSeparatorItem4)
        SuperToolTip5.Items.Add(ToolTipTitleItem10)
        Me.chkTresMeses.SuperTip = SuperToolTip5
        Me.chkTresMeses.TabIndex = 2
        Me.chkTresMeses.TabStop = False
        Me.chkTresMeses.Text = "3 Meses"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.chkBtnSeguroPoliza)
        Me.GroupControl2.Controls.Add(Me.chkBtnTipoPoliza)
        Me.GroupControl2.Controls.Add(Me.LabelControl7)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(3, 3)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(221, 98)
        Me.GroupControl2.TabIndex = 0
        Me.GroupControl2.Text = "Filtrar por:"
        '
        'chkBtnSeguroPoliza
        '
        Me.chkBtnSeguroPoliza.AllowFocus = False
        Me.chkBtnSeguroPoliza.Appearance.Options.UseTextOptions = True
        Me.chkBtnSeguroPoliza.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkBtnSeguroPoliza.Checked = True
        Me.chkBtnSeguroPoliza.GroupIndex = 1
        Me.chkBtnSeguroPoliza.Image = CType(resources.GetObject("chkBtnSeguroPoliza.Image"), System.Drawing.Image)
        Me.chkBtnSeguroPoliza.Location = New System.Drawing.Point(106, 41)
        Me.chkBtnSeguroPoliza.Name = "chkBtnSeguroPoliza"
        Me.chkBtnSeguroPoliza.Size = New System.Drawing.Size(105, 38)
        ToolTipTitleItem11.Text = "Filtar por?"
        ToolTipItem6.Appearance.Image = CType(resources.GetObject("resource.Image"), System.Drawing.Image)
        ToolTipItem6.Appearance.Options.UseImage = True
        ToolTipItem6.Image = CType(resources.GetObject("ToolTipItem6.Image"), System.Drawing.Image)
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Polizas de Seguro"
        ToolTipTitleItem12.LeftIndent = 6
        ToolTipTitleItem12.Text = "Filtros"
        SuperToolTip6.Items.Add(ToolTipTitleItem11)
        SuperToolTip6.Items.Add(ToolTipItem6)
        SuperToolTip6.Items.Add(ToolTipSeparatorItem5)
        SuperToolTip6.Items.Add(ToolTipTitleItem12)
        Me.chkBtnSeguroPoliza.SuperTip = SuperToolTip6
        Me.chkBtnSeguroPoliza.TabIndex = 1
        Me.chkBtnSeguroPoliza.Text = "Polizas de Seguro"
        '
        'chkBtnTipoPoliza
        '
        Me.chkBtnTipoPoliza.AllowFocus = False
        Me.chkBtnTipoPoliza.Appearance.Options.UseTextOptions = True
        Me.chkBtnTipoPoliza.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkBtnTipoPoliza.GroupIndex = 1
        Me.chkBtnTipoPoliza.Image = CType(resources.GetObject("chkBtnTipoPoliza.Image"), System.Drawing.Image)
        Me.chkBtnTipoPoliza.Location = New System.Drawing.Point(3, 41)
        Me.chkBtnTipoPoliza.Name = "chkBtnTipoPoliza"
        Me.chkBtnTipoPoliza.Size = New System.Drawing.Size(97, 38)
        ToolTipTitleItem13.Text = "Filtar por?"
        ToolTipItem7.Appearance.Image = CType(resources.GetObject("resource.Image1"), System.Drawing.Image)
        ToolTipItem7.Appearance.Options.UseImage = True
        ToolTipItem7.Image = CType(resources.GetObject("ToolTipItem7.Image"), System.Drawing.Image)
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Auditorias de Recepción"
        ToolTipTitleItem14.LeftIndent = 6
        ToolTipTitleItem14.Text = "Filtar"
        SuperToolTip7.Items.Add(ToolTipTitleItem13)
        SuperToolTip7.Items.Add(ToolTipItem7)
        SuperToolTip7.Items.Add(ToolTipSeparatorItem6)
        SuperToolTip7.Items.Add(ToolTipTitleItem14)
        Me.chkBtnTipoPoliza.SuperTip = SuperToolTip7
        Me.chkBtnTipoPoliza.TabIndex = 0
        Me.chkBtnTipoPoliza.TabStop = False
        Me.chkBtnTipoPoliza.Text = "Tipo de Poliza"
        '
        'LabelControl7
        '
        Me.LabelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl7.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelControl7.Location = New System.Drawing.Point(2, 21)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(217, 13)
        Me.LabelControl7.TabIndex = 11
        Me.LabelControl7.Text = "TipoTransacciones:"
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1, Me.btnExel, Me.btnExpandirTodo, Me.btnContraerTodo})
        Me.BarManager1.MaxItemId = 4
        '
        'Bar1
        '
        Me.Bar1.BarName = "Herramientas"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.FloatLocation = New System.Drawing.Point(39, 171)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnExel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnExpandirTodo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnContraerTodo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.AllowQuickCustomization = False
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Herramientas"
        '
        'btnExel
        '
        Me.btnExel.Caption = "Exel"
        Me.btnExel.Glyph = CType(resources.GetObject("btnExel.Glyph"), System.Drawing.Image)
        Me.btnExel.Id = 1
        Me.btnExel.LargeGlyph = CType(resources.GetObject("btnExel.LargeGlyph"), System.Drawing.Image)
        Me.btnExel.Name = "btnExel"
        '
        'btnExpandirTodo
        '
        Me.btnExpandirTodo.Caption = "Expandir Todo"
        Me.btnExpandirTodo.Glyph = CType(resources.GetObject("btnExpandirTodo.Glyph"), System.Drawing.Image)
        Me.btnExpandirTodo.Id = 2
        Me.btnExpandirTodo.LargeGlyph = CType(resources.GetObject("btnExpandirTodo.LargeGlyph"), System.Drawing.Image)
        Me.btnExpandirTodo.Name = "btnExpandirTodo"
        '
        'btnContraerTodo
        '
        Me.btnContraerTodo.Caption = "Contraer Todo"
        Me.btnContraerTodo.Glyph = CType(resources.GetObject("btnContraerTodo.Glyph"), System.Drawing.Image)
        Me.btnContraerTodo.Id = 3
        Me.btnContraerTodo.LargeGlyph = CType(resources.GetObject("btnContraerTodo.LargeGlyph"), System.Drawing.Image)
        Me.btnContraerTodo.Name = "btnContraerTodo"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(914, 31)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 492)
        Me.barDockControlBottom.Size = New System.Drawing.Size(914, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 31)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 461)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(914, 31)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 461)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Exel"
        Me.BarButtonItem1.Glyph = CType(resources.GetObject("BarButtonItem1.Glyph"), System.Drawing.Image)
        Me.BarButtonItem1.Id = 0
        Me.BarButtonItem1.LargeGlyph = CType(resources.GetObject("BarButtonItem1.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'FrmVencimientoPolizas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 492)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.NavBarControlTransOnLine)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FrmVencimientoPolizas"
        Me.Text = "Vencimiento de Polizas Fiscal"
        CType(Me.GridViewPolizaSeguro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTipoPoliza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NavBarControlTransOnLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavBarControlTransOnLine.ResumeLayout(False)
        Me.NavBarGroupControlContainer1.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.dtFechaFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaFinal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaInicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaInicial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NavBarControlTransOnLine As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents NavBarGroupFilter As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarGroupControlContainer1 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnGo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkBtnHoy As DevExpress.XtraEditors.CheckButton
    Friend WithEvents dtFechaFinal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtFechaInicial As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkBtnAyer As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkbtnSemana As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkMes As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkTresMeses As DevExpress.XtraEditors.CheckButton
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkBtnSeguroPoliza As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkBtnTipoPoliza As DevExpress.XtraEditors.CheckButton
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPolizaSeguro As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colSPOLIZA_INSURANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSCODIGO_POLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSNUMERO_ORDEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSCLIENT_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSACUERDO_COMERCIAL_NOMBRE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSFECHA_LLEGADA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSVALIN_TO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSDAYS_REMAINING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridViewTipoPoliza As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colTDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTCODIGO_POLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTNUMERO_ORDEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTCLIENT_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTACUERDO_COMERCIAL_NOMBRE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTFECHA_LLEGADA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTREGIMEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTVALIN_TO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTDAYS_REMAINING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView8 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colBARCODE_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMATERIAL_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSCANNED_COUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colINPUTED_COUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLAST_UPDATED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExpandirTodo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnContraerTodo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
