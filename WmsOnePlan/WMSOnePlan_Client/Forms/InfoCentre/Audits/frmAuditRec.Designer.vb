﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuditRec
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
        Me.components = New System.ComponentModel.Container()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim colREGIMEN As DevExpress.XtraGrid.Columns.GridColumn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAuditRec))
        Me.GridViewDispatch = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colAuditID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTipo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPolizaTarget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBarCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPicked = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDiff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDCLIENT_OWNER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDCLIENT_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDFOTOS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRCLIENT_OWNER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRCLIENT_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_SKU = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_DESC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_QTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQTYINV = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDiferencia = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRCOUNTING_METHOD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRFOTOS = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.NavBarControlTransOnLine = New DevExpress.XtraNavBar.NavBarControl()
        Me.NavBarGroupFilter = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarGroupControlContainer1 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.btnGo = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.CheckButton1 = New DevExpress.XtraEditors.CheckButton()
        Me.txtFechaFinal = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFechaInicial = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.CheckButton2 = New DevExpress.XtraEditors.CheckButton()
        Me.CheckButton3 = New DevExpress.XtraEditors.CheckButton()
        Me.CheckButton4 = New DevExpress.XtraEditors.CheckButton()
        Me.CheckButton5 = New DevExpress.XtraEditors.CheckButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.chkBtnAuditDespacho = New DevExpress.XtraEditors.CheckButton()
        Me.chkBtnAuditRecepcion = New DevExpress.XtraEditors.CheckButton()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.barBtnExel = New DevExpress.XtraBars.BarButtonItem()
        Me.barBtnExpadir = New DevExpress.XtraBars.BarButtonItem()
        Me.barBtnContraer = New DevExpress.XtraBars.BarButtonItem()
        Me.barBtnSave = New DevExpress.XtraBars.BarButtonItem()
        Me.barBtnViewImg = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.barBtnPrint = New DevExpress.XtraBars.BarButtonItem()
        colREGIMEN = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GridViewDispatch,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridControl1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView7,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView8,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView5,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView6,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PrintingSystem1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.NavBarControlTransOnLine,System.ComponentModel.ISupportInitialize).BeginInit
        Me.NavBarControlTransOnLine.SuspendLayout
        Me.NavBarGroupControlContainer1.SuspendLayout
        CType(Me.PanelControl3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.PanelControl3.SuspendLayout
        CType(Me.GroupControl1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupControl1.SuspendLayout
        CType(Me.txtFechaFinal.Properties.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtFechaFinal.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtFechaInicial.Properties.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtFechaInicial.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GroupControl2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupControl2.SuspendLayout
        CType(Me.BarManager1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'GridViewDispatch
        '
        Me.GridViewDispatch.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colAuditID, Me.colTipo, Me.colPolizaTarget, Me.colBarCode, Me.colDescription, Me.colPicked, Me.colContado, Me.colDiff, Me.colDCLIENT_OWNER, Me.colDCLIENT_NAME, Me.colDFOTOS})
        Me.GridViewDispatch.CustomizationFormBounds = New System.Drawing.Rectangle(749, 393, 216, 178)
        Me.GridViewDispatch.GridControl = Me.GridControl1
        Me.GridViewDispatch.Name = "GridViewDispatch"
        Me.GridViewDispatch.OptionsView.ShowAutoFilterRow = true
        '
        'colAuditID
        '
        Me.colAuditID.Caption = "ID"
        Me.colAuditID.FieldName = "AUDIT_ID"
        Me.colAuditID.Name = "colAuditID"
        Me.colAuditID.OptionsColumn.AllowEdit = false
        Me.colAuditID.OptionsColumn.ReadOnly = true
        Me.colAuditID.Visible = true
        Me.colAuditID.VisibleIndex = 0
        '
        'colTipo
        '
        Me.colTipo.Caption = "Tipo Conteo"
        Me.colTipo.FieldName = "COUNTING_METHOD"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.OptionsColumn.AllowEdit = false
        Me.colTipo.OptionsColumn.ReadOnly = true
        Me.colTipo.Visible = true
        Me.colTipo.VisibleIndex = 1
        '
        'colPolizaTarget
        '
        Me.colPolizaTarget.Caption = "Poliza"
        Me.colPolizaTarget.FieldName = "CODIGO_POLIZA"
        Me.colPolizaTarget.Name = "colPolizaTarget"
        Me.colPolizaTarget.OptionsColumn.AllowEdit = false
        Me.colPolizaTarget.OptionsColumn.ReadOnly = true
        Me.colPolizaTarget.Visible = true
        Me.colPolizaTarget.VisibleIndex = 2
        '
        'colBarCode
        '
        Me.colBarCode.Caption = "Codigo"
        Me.colBarCode.FieldName = "BARCODE_ID"
        Me.colBarCode.Name = "colBarCode"
        Me.colBarCode.OptionsColumn.AllowEdit = false
        Me.colBarCode.OptionsColumn.ReadOnly = true
        Me.colBarCode.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.colBarCode.Visible = true
        Me.colBarCode.VisibleIndex = 3
        '
        'colDescription
        '
        Me.colDescription.Caption = "Descripción"
        Me.colDescription.FieldName = "MATERIAL_NAME"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.OptionsColumn.AllowEdit = false
        Me.colDescription.OptionsColumn.ReadOnly = true
        Me.colDescription.Visible = true
        Me.colDescription.VisibleIndex = 4
        '
        'colPicked
        '
        Me.colPicked.Caption = "Picking"
        Me.colPicked.FieldName = "PICKED"
        Me.colPicked.Name = "colPicked"
        Me.colPicked.OptionsColumn.AllowEdit = false
        Me.colPicked.Visible = true
        Me.colPicked.VisibleIndex = 5
        '
        'colContado
        '
        Me.colContado.Caption = "Auditado"
        Me.colContado.FieldName = "COUNTED"
        Me.colContado.Name = "colContado"
        Me.colContado.OptionsColumn.AllowEdit = false
        Me.colContado.OptionsColumn.ReadOnly = true
        Me.colContado.Visible = true
        Me.colContado.VisibleIndex = 6
        '
        'colDiff
        '
        Me.colDiff.Caption = "Diferencia"
        Me.colDiff.FieldName = "AUDIT_DIFF"
        Me.colDiff.Name = "colDiff"
        Me.colDiff.OptionsColumn.AllowEdit = false
        Me.colDiff.OptionsColumn.ReadOnly = true
        Me.colDiff.Visible = true
        Me.colDiff.VisibleIndex = 7
        '
        'colDCLIENT_OWNER
        '
        Me.colDCLIENT_OWNER.Caption = "Codigo Cliente"
        Me.colDCLIENT_OWNER.FieldName = "CLIENT_OWNER"
        Me.colDCLIENT_OWNER.Name = "colDCLIENT_OWNER"
        Me.colDCLIENT_OWNER.OptionsColumn.AllowEdit = false
        Me.colDCLIENT_OWNER.Visible = true
        Me.colDCLIENT_OWNER.VisibleIndex = 8
        '
        'colDCLIENT_NAME
        '
        Me.colDCLIENT_NAME.Caption = "Nombre Cliente"
        Me.colDCLIENT_NAME.FieldName = "CLIENT_NAME"
        Me.colDCLIENT_NAME.Name = "colDCLIENT_NAME"
        Me.colDCLIENT_NAME.OptionsColumn.AllowEdit = false
        Me.colDCLIENT_NAME.Visible = true
        Me.colDCLIENT_NAME.VisibleIndex = 9
        '
        'colDFOTOS
        '
        Me.colDFOTOS.Caption = "Contiene Fotos"
        Me.colDFOTOS.FieldName = "FOTOS"
        Me.colDFOTOS.Name = "colDFOTOS"
        Me.colDFOTOS.OptionsColumn.AllowEdit = false
        Me.colDFOTOS.Visible = true
        Me.colDFOTOS.VisibleIndex = 10
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataMember = Nothing
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.LevelTemplate = Me.GridViewDispatch
        GridLevelNode1.RelationName = "DispatchView"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(221, 31)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(715, 369)
        Me.GridControl1.TabIndex = 2
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.GridView7, Me.GridView8, Me.GridView4, Me.GridView5, Me.GridView2, Me.GridView3, Me.GridView6, Me.GridViewDispatch})
        '
        'GridView1
        '
        Me.GridView1.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.GridView1.AppearancePrint.HeaderPanel.BackColor2 = System.Drawing.Color.Silver
        Me.GridView1.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer))
        Me.GridView1.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GridView1.AppearancePrint.HeaderPanel.Options.UseBackColor = true
        Me.GridView1.AppearancePrint.HeaderPanel.Options.UseBorderColor = true
        Me.GridView1.AppearancePrint.HeaderPanel.Options.UseFont = true
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.colRCLIENT_OWNER, Me.colRCLIENT_NAME, Me.GridColumn5, Me.GridColumn3, Me.GridColumn2, Me.GridColumn_SKU, Me.GridColumn_DESC, Me.GridColumn6, Me.GridColumn4, Me.GridColumn_QTY, Me.colQTYINV, Me.colDiferencia, Me.colRCOUNTING_METHOD, colREGIMEN, Me.colRFOTOS})
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(128,Byte),Integer))
        StyleFormatCondition1.Appearance.Options.UseBackColor = true
        StyleFormatCondition1.ApplyToRow = true
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition1.Expression = "[Diferencia] >  0"
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer))
        StyleFormatCondition2.Appearance.Options.UseBackColor = true
        StyleFormatCondition2.ApplyToRow = true
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition2.Expression = "[Diferencia] <  0"
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer))
        StyleFormatCondition3.Appearance.Options.UseBackColor = true
        StyleFormatCondition3.ApplyToRow = true
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition3.Expression = "[Diferencia] = 0"
        Me.GridView1.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2, StyleFormatCondition3})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = true
        Me.GridView1.OptionsPrint.ExpandAllDetails = true
        Me.GridView1.OptionsPrint.PrintDetails = true
        Me.GridView1.OptionsPrint.PrintFilterInfo = true
        Me.GridView1.OptionsPrint.PrintPreview = true
        Me.GridView1.OptionsPrint.PrintSelectedRowsOnly = true
        Me.GridView1.OptionsView.ShowAutoFilterRow = true
        Me.GridView1.OptionsView.ShowFooter = true
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Conteo"
        Me.GridColumn1.FieldName = "AUDIT_ID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = false
        Me.GridColumn1.OptionsColumn.AllowFocus = false
        Me.GridColumn1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.GridColumn1.Visible = true
        Me.GridColumn1.VisibleIndex = 0
        '
        'colRCLIENT_OWNER
        '
        Me.colRCLIENT_OWNER.Caption = "Codigo Cliente"
        Me.colRCLIENT_OWNER.FieldName = "CLIENT_OWNER"
        Me.colRCLIENT_OWNER.Name = "colRCLIENT_OWNER"
        Me.colRCLIENT_OWNER.OptionsColumn.AllowEdit = false
        Me.colRCLIENT_OWNER.OptionsColumn.AllowFocus = false
        Me.colRCLIENT_OWNER.Visible = true
        Me.colRCLIENT_OWNER.VisibleIndex = 1
        '
        'colRCLIENT_NAME
        '
        Me.colRCLIENT_NAME.Caption = "Nombre Cliente"
        Me.colRCLIENT_NAME.FieldName = "CLIENT_NAME"
        Me.colRCLIENT_NAME.Name = "colRCLIENT_NAME"
        Me.colRCLIENT_NAME.OptionsColumn.AllowEdit = false
        Me.colRCLIENT_NAME.OptionsColumn.AllowFocus = false
        Me.colRCLIENT_NAME.Visible = true
        Me.colRCLIENT_NAME.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "NumeroOrden"
        Me.GridColumn5.FieldName = "NUMERO_ORDEN"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = false
        Me.GridColumn5.OptionsColumn.AllowFocus = false
        Me.GridColumn5.OptionsColumn.ReadOnly = true
        Me.GridColumn5.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.GridColumn5.Visible = true
        Me.GridColumn5.VisibleIndex = 4
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Poliza"
        Me.GridColumn3.FieldName = "CODIGO_POLIZA"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = false
        Me.GridColumn3.OptionsColumn.AllowFocus = false
        Me.GridColumn3.Visible = true
        Me.GridColumn3.VisibleIndex = 5
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Estatus"
        Me.GridColumn2.FieldName = "STATUS"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = false
        Me.GridColumn2.OptionsColumn.AllowFocus = false
        Me.GridColumn2.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.GridColumn2.Visible = true
        Me.GridColumn2.VisibleIndex = 7
        '
        'GridColumn_SKU
        '
        Me.GridColumn_SKU.Caption = "SKU"
        Me.GridColumn_SKU.FieldName = "BARCODE_ID"
        Me.GridColumn_SKU.Name = "GridColumn_SKU"
        Me.GridColumn_SKU.OptionsColumn.AllowEdit = false
        Me.GridColumn_SKU.OptionsColumn.AllowFocus = false
        Me.GridColumn_SKU.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.GridColumn_SKU.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GridColumn_SKU.Visible = true
        Me.GridColumn_SKU.VisibleIndex = 8
        '
        'GridColumn_DESC
        '
        Me.GridColumn_DESC.Caption = "Descripción"
        Me.GridColumn_DESC.FieldName = "MATERIAL_NAME"
        Me.GridColumn_DESC.Name = "GridColumn_DESC"
        Me.GridColumn_DESC.OptionsColumn.AllowEdit = false
        Me.GridColumn_DESC.OptionsColumn.AllowFocus = false
        Me.GridColumn_DESC.Visible = true
        Me.GridColumn_DESC.VisibleIndex = 9
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Operador"
        Me.GridColumn6.FieldName = "LAST_UPDATED_BY"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = false
        Me.GridColumn6.OptionsColumn.AllowFocus = false
        Me.GridColumn6.OptionsColumn.ReadOnly = true
        Me.GridColumn6.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.GridColumn6.Visible = true
        Me.GridColumn6.VisibleIndex = 10
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Fecha.Hora"
        Me.GridColumn4.FieldName = "LAST_UPDATED"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = false
        Me.GridColumn4.OptionsColumn.AllowFocus = false
        Me.GridColumn4.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.GridColumn4.Visible = true
        Me.GridColumn4.VisibleIndex = 11
        '
        'GridColumn_QTY
        '
        Me.GridColumn_QTY.Caption = "Contado"
        Me.GridColumn_QTY.FieldName = "COUNTED"
        Me.GridColumn_QTY.Name = "GridColumn_QTY"
        Me.GridColumn_QTY.OptionsColumn.AllowEdit = false
        Me.GridColumn_QTY.OptionsColumn.AllowFocus = false
        Me.GridColumn_QTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn_QTY.Visible = true
        Me.GridColumn_QTY.VisibleIndex = 12
        '
        'colQTYINV
        '
        Me.colQTYINV.Caption = "Cantidad Ingresada"
        Me.colQTYINV.FieldName = "QTYINV"
        Me.colQTYINV.Name = "colQTYINV"
        Me.colQTYINV.OptionsColumn.AllowEdit = false
        Me.colQTYINV.OptionsColumn.AllowFocus = false
        Me.colQTYINV.Visible = true
        Me.colQTYINV.VisibleIndex = 13
        '
        'colDiferencia
        '
        Me.colDiferencia.Caption = "Diferencia"
        Me.colDiferencia.FieldName = "Diferencia"
        Me.colDiferencia.Name = "colDiferencia"
        Me.colDiferencia.OptionsColumn.AllowEdit = false
        Me.colDiferencia.OptionsColumn.AllowFocus = false
        Me.colDiferencia.Visible = true
        Me.colDiferencia.VisibleIndex = 14
        '
        'colRCOUNTING_METHOD
        '
        Me.colRCOUNTING_METHOD.Caption = "Tipo Conteo"
        Me.colRCOUNTING_METHOD.FieldName = "COUNTING_METHOD"
        Me.colRCOUNTING_METHOD.Name = "colRCOUNTING_METHOD"
        Me.colRCOUNTING_METHOD.OptionsColumn.AllowEdit = false
        Me.colRCOUNTING_METHOD.Visible = true
        Me.colRCOUNTING_METHOD.VisibleIndex = 3
        '
        'colREGIMEN
        '
        colREGIMEN.Caption = "Regimen"
        colREGIMEN.FieldName = "WAREHOUSE_REGIMEN"
        colREGIMEN.Name = "colREGIMEN"
        colREGIMEN.OptionsColumn.AllowEdit = false
        colREGIMEN.Visible = true
        colREGIMEN.VisibleIndex = 6
        '
        'colRFOTOS
        '
        Me.colRFOTOS.Caption = "Contiene Fotos"
        Me.colRFOTOS.FieldName = "FOTOS"
        Me.colRFOTOS.Name = "colRFOTOS"
        Me.colRFOTOS.OptionsColumn.AllowEdit = false
        Me.colRFOTOS.Visible = true
        Me.colRFOTOS.VisibleIndex = 15
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
        Me.colBARCODE_ID.Visible = true
        Me.colBARCODE_ID.VisibleIndex = 0
        '
        'colMATERIAL_NAME
        '
        Me.colMATERIAL_NAME.FieldName = "MATERIAL_NAME"
        Me.colMATERIAL_NAME.Name = "colMATERIAL_NAME"
        Me.colMATERIAL_NAME.Visible = true
        Me.colMATERIAL_NAME.VisibleIndex = 1
        '
        'colSCANNED_COUNT
        '
        Me.colSCANNED_COUNT.FieldName = "SCANNED_COUNT"
        Me.colSCANNED_COUNT.Name = "colSCANNED_COUNT"
        Me.colSCANNED_COUNT.Visible = true
        Me.colSCANNED_COUNT.VisibleIndex = 2
        '
        'colINPUTED_COUNT
        '
        Me.colINPUTED_COUNT.FieldName = "INPUTED_COUNT"
        Me.colINPUTED_COUNT.Name = "colINPUTED_COUNT"
        Me.colINPUTED_COUNT.Visible = true
        Me.colINPUTED_COUNT.VisibleIndex = 3
        '
        'colLAST_UPDATED
        '
        Me.colLAST_UPDATED.FieldName = "LAST_UPDATED"
        Me.colLAST_UPDATED.Name = "colLAST_UPDATED"
        Me.colLAST_UPDATED.Visible = true
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
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        Me.PrintableComponentLink1.Landscape = true
        Me.PrintableComponentLink1.PageHeaderFooter = New DevExpress.XtraPrinting.PageHeaderFooter(New DevExpress.XtraPrinting.PageHeaderArea(New String() {"CEALSA", "AUDITORIA DE"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"RECEPCION FISCAL", "[Page # of Pages #]"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"[Date Printed] [Time Printed]"}, New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte)), DevExpress.XtraPrinting.BrickAlignment.Near), New DevExpress.XtraPrinting.PageFooterArea(New String() {"", "[Page # of Pages #]", ""}, New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte)), DevExpress.XtraPrinting.BrickAlignment.Near))
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
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
        Me.NavBarControlTransOnLine.OptionsNavPane.ExpandedWidth = 221
        Me.NavBarControlTransOnLine.Size = New System.Drawing.Size(221, 369)
        Me.NavBarControlTransOnLine.TabIndex = 4
        Me.NavBarControlTransOnLine.Text = "NavBarControl1"
        Me.NavBarControlTransOnLine.View = New DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator()
        '
        'NavBarGroupFilter
        '
        Me.NavBarGroupFilter.Caption = "FiltroInformacion"
        Me.NavBarGroupFilter.ControlContainer = Me.NavBarGroupControlContainer1
        Me.NavBarGroupFilter.Expanded = true
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
        Me.NavBarGroupControlContainer1.Size = New System.Drawing.Size(221, 266)
        Me.NavBarGroupControlContainer1.TabIndex = 0
        '
        'PanelControl3
        '
        Me.PanelControl3.Appearance.BackColor = System.Drawing.Color.White
        Me.PanelControl3.Appearance.Options.UseBackColor = true
        Me.PanelControl3.Controls.Add(Me.btnGo)
        Me.PanelControl3.Controls.Add(Me.GroupControl1)
        Me.PanelControl3.Controls.Add(Me.GroupControl2)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.PanelControl3.LookAndFeel.UseDefaultLookAndFeel = false
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(221, 266)
        Me.PanelControl3.TabIndex = 1
        '
        'btnGo
        '
        Me.btnGo.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnGo.Location = New System.Drawing.Point(3, 264)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(215, 23)
        Me.btnGo.TabIndex = 8
        Me.btnGo.Text = "Aceptar"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.CheckButton1)
        Me.GroupControl1.Controls.Add(Me.txtFechaFinal)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.txtFechaInicial)
        Me.GroupControl1.Controls.Add(Me.LabelControl6)
        Me.GroupControl1.Controls.Add(Me.CheckButton2)
        Me.GroupControl1.Controls.Add(Me.CheckButton3)
        Me.GroupControl1.Controls.Add(Me.CheckButton4)
        Me.GroupControl1.Controls.Add(Me.CheckButton5)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(3, 101)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(215, 163)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Rango de fechas:"
        '
        'CheckButton1
        '
        Me.CheckButton1.AllowFocus = false
        Me.CheckButton1.Appearance.Options.UseTextOptions = true
        Me.CheckButton1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.CheckButton1.Checked = true
        Me.CheckButton1.GroupIndex = 1
        Me.CheckButton1.Location = New System.Drawing.Point(166, 23)
        Me.CheckButton1.Name = "CheckButton1"
        Me.CheckButton1.Size = New System.Drawing.Size(40, 38)
        ToolTipTitleItem1.Text = "TransaccionesEnLinea"
        ToolTipItem1.Appearance.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem1.Appearance.Options.UseImage = true
        ToolTipItem1.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Consultar transacciones desde el dia de ayer hasta la fecha"
        ToolTipTitleItem2.LeftIndent = 6
        ToolTipTitleItem2.Text = "Filtros"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        SuperToolTip1.Items.Add(ToolTipSeparatorItem1)
        SuperToolTip1.Items.Add(ToolTipTitleItem2)
        Me.CheckButton1.SuperTip = SuperToolTip1
        Me.CheckButton1.TabIndex = 8
        Me.CheckButton1.Text = "Hoy"
        '
        'txtFechaFinal
        '
        Me.txtFechaFinal.EditValue = New Date(2014, 7, 4, 8, 43, 55, 0)
        Me.txtFechaFinal.EnterMoveNextControl = true
        Me.txtFechaFinal.Location = New System.Drawing.Point(3, 132)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaFinal.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtFechaFinal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtFechaFinal.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d"
        Me.txtFechaFinal.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtFechaFinal.Properties.CalendarTimeProperties.EditFormat.FormatString = "d"
        Me.txtFechaFinal.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtFechaFinal.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.txtFechaFinal.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText
        Me.txtFechaFinal.Properties.Mask.BeepOnError = true
        Me.txtFechaFinal.Properties.ShowWeekNumbers = true
        Me.txtFechaFinal.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtFechaFinal.Size = New System.Drawing.Size(203, 22)
        Me.txtFechaFinal.TabIndex = 7
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(6, 113)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl5.TabIndex = 6
        Me.LabelControl5.Text = "FechaInicial:"
        '
        'txtFechaInicial
        '
        Me.txtFechaInicial.EditValue = New Date(2014, 7, 4, 8, 43, 48, 0)
        Me.txtFechaInicial.EnterMoveNextControl = true
        Me.txtFechaInicial.Location = New System.Drawing.Point(3, 87)
        Me.txtFechaInicial.Name = "txtFechaInicial"
        Me.txtFechaInicial.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaInicial.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtFechaInicial.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtFechaInicial.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d"
        Me.txtFechaInicial.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtFechaInicial.Properties.CalendarTimeProperties.EditFormat.FormatString = "d"
        Me.txtFechaInicial.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtFechaInicial.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.txtFechaInicial.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText
        Me.txtFechaInicial.Properties.Mask.BeepOnError = true
        Me.txtFechaInicial.Properties.ShowWeekNumbers = true
        Me.txtFechaInicial.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtFechaInicial.Size = New System.Drawing.Size(203, 22)
        Me.txtFechaInicial.TabIndex = 6
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(6, 67)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl6.TabIndex = 4
        Me.LabelControl6.Text = "FechaInicial:"
        '
        'CheckButton2
        '
        Me.CheckButton2.AllowFocus = false
        Me.CheckButton2.Appearance.Options.UseTextOptions = true
        Me.CheckButton2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.CheckButton2.GroupIndex = 1
        Me.CheckButton2.Location = New System.Drawing.Point(125, 23)
        Me.CheckButton2.Name = "CheckButton2"
        Me.CheckButton2.Size = New System.Drawing.Size(40, 38)
        ToolTipTitleItem3.Text = "TransaccionesEnLinea"
        ToolTipItem2.Appearance.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem2.Appearance.Options.UseImage = true
        ToolTipItem2.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Consultar transacciones desde el dia de ayer hasta la fecha"
        ToolTipTitleItem4.LeftIndent = 6
        ToolTipTitleItem4.Text = "Filtros"
        SuperToolTip2.Items.Add(ToolTipTitleItem3)
        SuperToolTip2.Items.Add(ToolTipItem2)
        SuperToolTip2.Items.Add(ToolTipSeparatorItem2)
        SuperToolTip2.Items.Add(ToolTipTitleItem4)
        Me.CheckButton2.SuperTip = SuperToolTip2
        Me.CheckButton2.TabIndex = 5
        Me.CheckButton2.TabStop = false
        Me.CheckButton2.Text = "Desde Ayer"
        '
        'CheckButton3
        '
        Me.CheckButton3.AllowFocus = false
        Me.CheckButton3.Appearance.Options.UseTextOptions = true
        Me.CheckButton3.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.CheckButton3.GroupIndex = 1
        Me.CheckButton3.Location = New System.Drawing.Point(84, 23)
        Me.CheckButton3.Name = "CheckButton3"
        Me.CheckButton3.Size = New System.Drawing.Size(40, 38)
        ToolTipTitleItem5.Text = "TransaccionesEnLinea"
        ToolTipItem3.Appearance.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem3.Appearance.Options.UseImage = true
        ToolTipItem3.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Consultar transacciones desde 1 semana a la fecha"
        ToolTipTitleItem6.LeftIndent = 6
        ToolTipTitleItem6.Text = "Filtros"
        SuperToolTip3.Items.Add(ToolTipTitleItem5)
        SuperToolTip3.Items.Add(ToolTipItem3)
        SuperToolTip3.Items.Add(ToolTipSeparatorItem3)
        SuperToolTip3.Items.Add(ToolTipTitleItem6)
        Me.CheckButton3.SuperTip = SuperToolTip3
        Me.CheckButton3.TabIndex = 4
        Me.CheckButton3.TabStop = false
        Me.CheckButton3.Text = "1 Semana"
        '
        'CheckButton4
        '
        Me.CheckButton4.AllowFocus = false
        Me.CheckButton4.Appearance.Options.UseTextOptions = true
        Me.CheckButton4.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.CheckButton4.GroupIndex = 1
        Me.CheckButton4.Location = New System.Drawing.Point(43, 23)
        Me.CheckButton4.Name = "CheckButton4"
        Me.CheckButton4.Size = New System.Drawing.Size(40, 38)
        ToolTipTitleItem7.Text = "TransaccionesEnLinea"
        ToolTipItem4.Appearance.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem4.Appearance.Options.UseImage = true
        ToolTipItem4.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Consultar transacciones desde 3 meses a la fecha"
        ToolTipTitleItem8.LeftIndent = 6
        ToolTipTitleItem8.Text = "Filtros"
        SuperToolTip4.Items.Add(ToolTipTitleItem7)
        SuperToolTip4.Items.Add(ToolTipItem4)
        SuperToolTip4.Items.Add(ToolTipTitleItem8)
        Me.CheckButton4.SuperTip = SuperToolTip4
        Me.CheckButton4.TabIndex = 3
        Me.CheckButton4.TabStop = false
        Me.CheckButton4.Text = "1   Mes"
        '
        'CheckButton5
        '
        Me.CheckButton5.AllowAllUnchecked = true
        Me.CheckButton5.AllowFocus = false
        Me.CheckButton5.Appearance.Options.UseTextOptions = true
        Me.CheckButton5.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.CheckButton5.GroupIndex = 1
        Me.CheckButton5.Location = New System.Drawing.Point(3, 23)
        Me.CheckButton5.Name = "CheckButton5"
        Me.CheckButton5.Size = New System.Drawing.Size(40, 38)
        ToolTipTitleItem9.Text = "TransaccionesEnLinea"
        ToolTipItem5.Appearance.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem5.Appearance.Options.UseImage = true
        ToolTipItem5.Image = Global.WMSOnePlan_Client.My.Resources.Resources.shapes040
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Consultar transacciones desde 3 meses a la fecha"
        ToolTipTitleItem10.LeftIndent = 6
        ToolTipTitleItem10.Text = "Filtros"
        SuperToolTip5.Items.Add(ToolTipTitleItem9)
        SuperToolTip5.Items.Add(ToolTipItem5)
        SuperToolTip5.Items.Add(ToolTipSeparatorItem4)
        SuperToolTip5.Items.Add(ToolTipTitleItem10)
        Me.CheckButton5.SuperTip = SuperToolTip5
        Me.CheckButton5.TabIndex = 2
        Me.CheckButton5.TabStop = false
        Me.CheckButton5.Text = "3 meses"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.chkBtnAuditDespacho)
        Me.GroupControl2.Controls.Add(Me.chkBtnAuditRecepcion)
        Me.GroupControl2.Controls.Add(Me.LabelControl7)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(3, 3)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(215, 98)
        Me.GroupControl2.TabIndex = 0
        Me.GroupControl2.Text = "Filtrar por:"
        '
        'chkBtnAuditDespacho
        '
        Me.chkBtnAuditDespacho.AllowFocus = false
        Me.chkBtnAuditDespacho.Appearance.Options.UseTextOptions = true
        Me.chkBtnAuditDespacho.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkBtnAuditDespacho.Checked = true
        Me.chkBtnAuditDespacho.GroupIndex = 1
        Me.chkBtnAuditDespacho.Image = Global.WMSOnePlan_Client.My.Resources.Resources.AuditDispatch
        Me.chkBtnAuditDespacho.Location = New System.Drawing.Point(106, 41)
        Me.chkBtnAuditDespacho.Name = "chkBtnAuditDespacho"
        Me.chkBtnAuditDespacho.Size = New System.Drawing.Size(105, 38)
        ToolTipTitleItem11.Text = "Filtar por?"
        ToolTipItem6.Appearance.Image = Global.WMSOnePlan_Client.My.Resources.Resources.AuditDispatch
        ToolTipItem6.Appearance.Options.UseImage = true
        ToolTipItem6.Image = Global.WMSOnePlan_Client.My.Resources.Resources.AuditDispatch
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Auditorias de Despacho"
        ToolTipTitleItem12.LeftIndent = 6
        ToolTipTitleItem12.Text = "Filtros"
        SuperToolTip6.Items.Add(ToolTipTitleItem11)
        SuperToolTip6.Items.Add(ToolTipItem6)
        SuperToolTip6.Items.Add(ToolTipSeparatorItem5)
        SuperToolTip6.Items.Add(ToolTipTitleItem12)
        Me.chkBtnAuditDespacho.SuperTip = SuperToolTip6
        Me.chkBtnAuditDespacho.TabIndex = 1
        Me.chkBtnAuditDespacho.Text = "Auditorias Despacho"
        '
        'chkBtnAuditRecepcion
        '
        Me.chkBtnAuditRecepcion.AllowFocus = false
        Me.chkBtnAuditRecepcion.Appearance.Options.UseTextOptions = true
        Me.chkBtnAuditRecepcion.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkBtnAuditRecepcion.GroupIndex = 1
        Me.chkBtnAuditRecepcion.Image = Global.WMSOnePlan_Client.My.Resources.Resources.AddADigitalSignature_Large
        Me.chkBtnAuditRecepcion.Location = New System.Drawing.Point(3, 41)
        Me.chkBtnAuditRecepcion.Name = "chkBtnAuditRecepcion"
        Me.chkBtnAuditRecepcion.Size = New System.Drawing.Size(97, 38)
        ToolTipTitleItem13.Text = "Filtar por?"
        ToolTipItem7.Appearance.Image = Global.WMSOnePlan_Client.My.Resources.Resources.AddADigitalSignature_Large
        ToolTipItem7.Appearance.Options.UseImage = true
        ToolTipItem7.Image = Global.WMSOnePlan_Client.My.Resources.Resources.AddADigitalSignature_Large
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Auditorias de Recepción"
        ToolTipTitleItem14.LeftIndent = 6
        ToolTipTitleItem14.Text = "Filtar"
        SuperToolTip7.Items.Add(ToolTipTitleItem13)
        SuperToolTip7.Items.Add(ToolTipItem7)
        SuperToolTip7.Items.Add(ToolTipSeparatorItem6)
        SuperToolTip7.Items.Add(ToolTipTitleItem14)
        Me.chkBtnAuditRecepcion.SuperTip = SuperToolTip7
        Me.chkBtnAuditRecepcion.TabIndex = 0
        Me.chkBtnAuditRecepcion.TabStop = false
        Me.chkBtnAuditRecepcion.Text = "Auditorias Recepción"
        '
        'LabelControl7
        '
        Me.LabelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl7.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelControl7.Location = New System.Drawing.Point(3, 18)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(209, 13)
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.barBtnExel, Me.barBtnPrint, Me.barBtnExpadir, Me.barBtnContraer, Me.barBtnSave, Me.barBtnViewImg})
        Me.BarManager1.MaxItemId = 6
        '
        'Bar1
        '
        Me.Bar1.BarName = "Herramientas"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.FloatLocation = New System.Drawing.Point(164, 142)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barBtnExel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barBtnExpadir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barBtnContraer, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barBtnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barBtnViewImg, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.AllowQuickCustomization = false
        Me.Bar1.OptionsBar.DrawDragBorder = false
        Me.Bar1.OptionsBar.UseWholeRow = true
        Me.Bar1.Text = "Herramientas"
        '
        'barBtnExel
        '
        Me.barBtnExel.Caption = "Exel"
        Me.barBtnExel.Glyph = CType(resources.GetObject("barBtnExel.Glyph"),System.Drawing.Image)
        Me.barBtnExel.Id = 0
        Me.barBtnExel.LargeGlyph = CType(resources.GetObject("barBtnExel.LargeGlyph"),System.Drawing.Image)
        Me.barBtnExel.Name = "barBtnExel"
        '
        'barBtnExpadir
        '
        Me.barBtnExpadir.Caption = "Expandir"
        Me.barBtnExpadir.Glyph = CType(resources.GetObject("barBtnExpadir.Glyph"),System.Drawing.Image)
        Me.barBtnExpadir.Id = 2
        Me.barBtnExpadir.LargeGlyph = CType(resources.GetObject("barBtnExpadir.LargeGlyph"),System.Drawing.Image)
        Me.barBtnExpadir.Name = "barBtnExpadir"
        '
        'barBtnContraer
        '
        Me.barBtnContraer.Caption = "Contraer"
        Me.barBtnContraer.Glyph = CType(resources.GetObject("barBtnContraer.Glyph"),System.Drawing.Image)
        Me.barBtnContraer.Id = 3
        Me.barBtnContraer.LargeGlyph = CType(resources.GetObject("barBtnContraer.LargeGlyph"),System.Drawing.Image)
        Me.barBtnContraer.Name = "barBtnContraer"
        '
        'barBtnSave
        '
        Me.barBtnSave.Caption = "Grabar"
        Me.barBtnSave.Glyph = CType(resources.GetObject("barBtnSave.Glyph"),System.Drawing.Image)
        Me.barBtnSave.Id = 4
        Me.barBtnSave.LargeGlyph = CType(resources.GetObject("barBtnSave.LargeGlyph"),System.Drawing.Image)
        Me.barBtnSave.Name = "barBtnSave"
        '
        'barBtnViewImg
        '
        Me.barBtnViewImg.Caption = "Fotografias"
        Me.barBtnViewImg.Glyph = CType(resources.GetObject("barBtnViewImg.Glyph"),System.Drawing.Image)
        Me.barBtnViewImg.Id = 5
        Me.barBtnViewImg.LargeGlyph = CType(resources.GetObject("barBtnViewImg.LargeGlyph"),System.Drawing.Image)
        Me.barBtnViewImg.Name = "barBtnViewImg"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = false
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(936, 31)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = false
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 400)
        Me.barDockControlBottom.Size = New System.Drawing.Size(936, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = false
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 31)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 369)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = false
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(936, 31)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 369)
        '
        'barBtnPrint
        '
        Me.barBtnPrint.Caption = "Print"
        Me.barBtnPrint.Glyph = CType(resources.GetObject("barBtnPrint.Glyph"),System.Drawing.Image)
        Me.barBtnPrint.Id = 1
        Me.barBtnPrint.LargeGlyph = CType(resources.GetObject("barBtnPrint.LargeGlyph"),System.Drawing.Image)
        Me.barBtnPrint.Name = "barBtnPrint"
        '
        'frmAuditRec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 400)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.NavBarControlTransOnLine)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmAuditRec"
        Me.Text = "Consulta Auditorias"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GridViewDispatch,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridControl1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView7,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView8,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView5,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView6,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PrintingSystem1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.NavBarControlTransOnLine,System.ComponentModel.ISupportInitialize).EndInit
        Me.NavBarControlTransOnLine.ResumeLayout(false)
        Me.NavBarGroupControlContainer1.ResumeLayout(false)
        CType(Me.PanelControl3,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelControl3.ResumeLayout(false)
        CType(Me.GroupControl1,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupControl1.ResumeLayout(false)
        Me.GroupControl1.PerformLayout
        CType(Me.txtFechaFinal.Properties.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtFechaFinal.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtFechaInicial.Properties.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtFechaInicial.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GroupControl2,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupControl2.ResumeLayout(false)
        CType(Me.BarManager1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView8 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colBARCODE_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMATERIAL_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSCANNED_COUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colINPUTED_COUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLAST_UPDATED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_SKU As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_DESC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_QTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NavBarControlTransOnLine As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents NavBarGroupFilter As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarGroupControlContainer1 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnGo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CheckButton1 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents txtFechaFinal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFechaInicial As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CheckButton2 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents CheckButton3 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents CheckButton4 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents CheckButton5 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkBtnAuditDespacho As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkBtnAuditRecepcion As DevExpress.XtraEditors.CheckButton
    Friend WithEvents GridViewDispatch As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colAuditID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPolizaTarget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBarCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPicked As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDiff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTipo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents colQTYINV As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDiferencia As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDCLIENT_OWNER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDCLIENT_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRCLIENT_OWNER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRCLIENT_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRCOUNTING_METHOD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents barBtnExel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barBtnPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barBtnExpadir As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barBtnContraer As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barBtnSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barBtnViewImg As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colDFOTOS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRFOTOS As DevExpress.XtraGrid.Columns.GridColumn
End Class

