<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperatorXModules
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
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOperatorXModules))
        Me.DGC_OperatorsXModule = New DevExpress.XtraGrid.GridControl
        Me.GridView_ModulosYaAsignados = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar3 = New DevExpress.XtraBars.Bar
        Me.Bar4 = New DevExpress.XtraBars.Bar
        Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        CType(Me.DGC_OperatorsXModule, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView_ModulosYaAsignados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGC_OperatorsXModule
        '
        Me.DGC_OperatorsXModule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGC_OperatorsXModule.Location = New System.Drawing.Point(0, 26)
        Me.DGC_OperatorsXModule.MainView = Me.GridView_ModulosYaAsignados
        Me.DGC_OperatorsXModule.Name = "DGC_OperatorsXModule"
        Me.DGC_OperatorsXModule.Size = New System.Drawing.Size(656, 438)
        Me.DGC_OperatorsXModule.TabIndex = 1
        Me.DGC_OperatorsXModule.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView_ModulosYaAsignados, Me.GridView2})
        '
        'GridView_ModulosYaAsignados
        '
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GridView_ModulosYaAsignados.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.GridView_ModulosYaAsignados.Appearance.Empty.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.GridView_ModulosYaAsignados.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.EvenRow.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black
        Me.GridView_ModulosYaAsignados.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GridView_ModulosYaAsignados.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GridView_ModulosYaAsignados.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White
        Me.GridView_ModulosYaAsignados.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.FixedLine.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.FocusedCell.BackColor = System.Drawing.Color.White
        Me.GridView_ModulosYaAsignados.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.GridView_ModulosYaAsignados.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.FocusedCell.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.GridView_ModulosYaAsignados.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView_ModulosYaAsignados.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GridView_ModulosYaAsignados.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GridView_ModulosYaAsignados.Appearance.FooterPanel.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black
        Me.GridView_ModulosYaAsignados.Appearance.GroupButton.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GridView_ModulosYaAsignados.Appearance.GroupButton.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.GridView_ModulosYaAsignados.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GridView_ModulosYaAsignados.Appearance.GroupFooter.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GridView_ModulosYaAsignados.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.GridView_ModulosYaAsignados.Appearance.GroupRow.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.GroupRow.Options.UseBorderColor = True
        Me.GridView_ModulosYaAsignados.Appearance.GroupRow.Options.UseFont = True
        Me.GridView_ModulosYaAsignados.Appearance.GroupRow.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView_ModulosYaAsignados.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GridView_ModulosYaAsignados.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView_ModulosYaAsignados.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.HorzLine.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GridView_ModulosYaAsignados.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.GridView_ModulosYaAsignados.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.OddRow.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.Preview.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.Preview.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.GridView_ModulosYaAsignados.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.GridView_ModulosYaAsignados.Appearance.Row.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.Row.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.RowSeparator.BackColor = System.Drawing.Color.White
        Me.GridView_ModulosYaAsignados.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.GridView_ModulosYaAsignados.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GridView_ModulosYaAsignados.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.GridView_ModulosYaAsignados.Appearance.VertLine.Options.UseBackColor = True
        Me.GridView_ModulosYaAsignados.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GridView_ModulosYaAsignados.GridControl = Me.DGC_OperatorsXModule
        Me.GridView_ModulosYaAsignados.Name = "GridView_ModulosYaAsignados"
        Me.GridView_ModulosYaAsignados.OptionsSelection.MultiSelect = True
        Me.GridView_ModulosYaAsignados.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView_ModulosYaAsignados.OptionsView.EnableAppearanceOddRow = True
        Me.GridView_ModulosYaAsignados.OptionsView.ShowAutoFilterRow = True
        Me.GridView_ModulosYaAsignados.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Linea"
        Me.GridColumn1.FieldName = "LINE_ID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Ubicacion"
        Me.GridColumn4.FieldName = "LOCATION_SPOT"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Operador"
        Me.GridColumn5.FieldName = "LOGIN_ID"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Nombre"
        Me.GridColumn6.FieldName = "LOGIN_NAME"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.DGC_OperatorsXModule
        Me.GridView2.Name = "GridView2"
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar3, Me.Bar4})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnRefresh, Me.BarButtonItem2, Me.BarButtonItem1, Me.BarButtonItem3, Me.BarButtonItem4})
        Me.BarManager1.MaxItemId = 5
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'Bar4
        '
        Me.Bar4.BarName = "Custom 5"
        Me.Bar4.DockCol = 0
        Me.Bar4.DockRow = 0
        Me.Bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar4.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnRefresh), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem2), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem3), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem4)})
        Me.Bar4.Text = "Custom 5"
        '
        'btnRefresh
        '
        Me.btnRefresh.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.refresh1
        Me.btnRefresh.Id = 0
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipItem1.Text = "Actualizar la lista de registros"
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.btnRefresh.SuperTip = SuperToolTip1
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.users
        Me.BarButtonItem2.Id = 1
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipItem2.Text = "Pantalla para asignar Operador por Ubicacion"
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.BarButtonItem2.SuperTip = SuperToolTip2
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.select_all
        Me.BarButtonItem1.Id = 2
        Me.BarButtonItem1.Name = "BarButtonItem1"
        ToolTipItem3.Text = "Seleccionar todos los registros"
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.BarButtonItem1.SuperTip = SuperToolTip3
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.Symbols_Delete_icon
        Me.BarButtonItem3.Id = 3
        Me.BarButtonItem3.Name = "BarButtonItem3"
        ToolTipItem4.Text = "Eliminar registros seleccionados"
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.BarButtonItem3.SuperTip = SuperToolTip4
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.cmd_excel
        Me.BarButtonItem4.Id = 4
        Me.BarButtonItem4.Name = "BarButtonItem4"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(656, 26)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 464)
        Me.barDockControlBottom.Size = New System.Drawing.Size(656, 22)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 26)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 438)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(656, 26)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 438)
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "xls"
        Me.SaveFileDialog1.FileName = "ReporteExcel"
        Me.SaveFileDialog1.RestoreDirectory = True
        '
        'frmOperatorXModules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 486)
        Me.Controls.Add(Me.DGC_OperatorsXModule)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOperatorXModules"
        Me.Text = "Operador por Modulo"
        CType(Me.DGC_OperatorsXModule, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView_ModulosYaAsignados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGC_OperatorsXModule As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView_ModulosYaAsignados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar4 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
