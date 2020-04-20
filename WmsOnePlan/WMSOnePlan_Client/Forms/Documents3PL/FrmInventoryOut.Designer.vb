<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInventoryOut
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInventoryOut))
        Me.LstR = New System.Windows.Forms.ListBox()
        Me.TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        Me.TabNavigationPage1 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.GCEgreso = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TabNavigationPage2 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnUpload = New System.Windows.Forms.Button()
        Me.GLUClientes = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DtaDate = New DevExpress.XtraEditors.DateEdit()
        Me.TabNavigationPage3 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnSKU = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyRequested = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyOnHand = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnResult = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.SaveToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton()
        CType(Me.TabPane1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabPane1.SuspendLayout
        Me.TabNavigationPage1.SuspendLayout
        CType(Me.GCEgreso,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ToolStrip1.SuspendLayout
        Me.TabNavigationPage2.SuspendLayout
        CType(Me.GLUClientes.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DtaDate.Properties.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DtaDate.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabNavigationPage3.SuspendLayout
        CType(Me.GridControl1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ToolStrip2.SuspendLayout
        Me.SuspendLayout
        '
        'LstR
        '
        Me.LstR.FormattingEnabled = true
        Me.LstR.ItemHeight = 20
        Me.LstR.Location = New System.Drawing.Point(1094, 818)
        Me.LstR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LstR.Name = "LstR"
        Me.LstR.Size = New System.Drawing.Size(62, 24)
        Me.LstR.TabIndex = 24
        Me.LstR.Visible = false
        '
        'TabPane1
        '
        Me.TabPane1.Controls.Add(Me.TabNavigationPage1)
        Me.TabPane1.Controls.Add(Me.TabNavigationPage2)
        Me.TabPane1.Controls.Add(Me.TabNavigationPage3)
        Me.TabPane1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabPane1.Location = New System.Drawing.Point(0, 0)
        Me.TabPane1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPane1.Name = "TabPane1"
        Me.TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.TabNavigationPage3, Me.TabNavigationPage1, Me.TabNavigationPage2})
        Me.TabPane1.RegularSize = New System.Drawing.Size(1176, 863)
        Me.TabPane1.SelectedPage = Me.TabNavigationPage2
        Me.TabPane1.Size = New System.Drawing.Size(1176, 863)
        Me.TabPane1.TabIndex = 36
        Me.TabPane1.Text = "TabPane1"
        '
        'TabNavigationPage1
        '
        Me.TabNavigationPage1.Caption = "Datos del Archivo"
        Me.TabNavigationPage1.Controls.Add(Me.GCEgreso)
        Me.TabNavigationPage1.Controls.Add(Me.ToolStrip1)
        Me.TabNavigationPage1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabNavigationPage1.Name = "TabNavigationPage1"
        Me.TabNavigationPage1.Size = New System.Drawing.Size(1158, 812)
        '
        'GCEgreso
        '
        Me.GCEgreso.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.[True]
        Me.GCEgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEgreso.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GCEgreso.Location = New System.Drawing.Point(0, 25)
        Me.GCEgreso.MainView = Me.GridView1
        Me.GCEgreso.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GCEgreso.Name = "GCEgreso"
        Me.GCEgreso.Size = New System.Drawing.Size(1158, 787)
        Me.GCEgreso.TabIndex = 24
        Me.GCEgreso.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GCEgreso
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = true
        Me.GridView1.OptionsView.ShowAutoFilterRow = true
        Me.GridView1.OptionsView.ShowFooter = true
        Me.GridView1.OptionsView.ShowViewCaption = true
        Me.GridView1.ViewCaption = "Prueba"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.toolStripSeparator, Me.SaveToolStripButton, Me.toolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(1158, 25)
        Me.ToolStrip1.TabIndex = 25
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"),System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = Global.WMSOnePlan_Client.My.Resources.Resources.arrow_right
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TabNavigationPage2
        '
        Me.TabNavigationPage2.Caption = "Datos generales"
        Me.TabNavigationPage2.Controls.Add(Me.LabelControl2)
        Me.TabNavigationPage2.Controls.Add(Me.LabelControl1)
        Me.TabNavigationPage2.Controls.Add(Me.BtnUpload)
        Me.TabNavigationPage2.Controls.Add(Me.GLUClientes)
        Me.TabNavigationPage2.Controls.Add(Me.DtaDate)
        Me.TabNavigationPage2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabNavigationPage2.Name = "TabNavigationPage2"
        Me.TabNavigationPage2.Size = New System.Drawing.Size(1158, 812)
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(32, 91)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(114, 19)
        Me.LabelControl2.TabIndex = 31
        Me.LabelControl2.Text = "Fecha de egreso"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(32, 51)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(126, 19)
        Me.LabelControl1.TabIndex = 30
        Me.LabelControl1.Text = "Seleccione Cliente"
        '
        'BtnUpload
        '
        Me.BtnUpload.Location = New System.Drawing.Point(248, 126)
        Me.BtnUpload.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.Size = New System.Drawing.Size(288, 66)
        Me.BtnUpload.TabIndex = 29
        Me.BtnUpload.Text = "Seleccione archivo excel"
        Me.BtnUpload.UseVisualStyleBackColor = true
        Me.BtnUpload.Visible = false
        '
        'GLUClientes
        '
        Me.GLUClientes.EditValue = "Cliente"
        Me.GLUClientes.Location = New System.Drawing.Point(248, 46)
        Me.GLUClientes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GLUClientes.Name = "GLUClientes"
        Me.GLUClientes.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.GLUClientes.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GLUClientes.Properties.NullText = ""
        Me.GLUClientes.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.GLUClientes.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.GLUClientes.Properties.View = Me.GridView2
        Me.GLUClientes.Size = New System.Drawing.Size(610, 26)
        Me.GLUClientes.TabIndex = 28
        Me.GLUClientes.ToolTip = "Seleccione Cliente"
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.GridView2.OptionsView.ShowAutoFilterRow = true
        Me.GridView2.OptionsView.ShowGroupPanel = false
        '
        'DtaDate
        '
        Me.DtaDate.EditValue = Nothing
        Me.DtaDate.Location = New System.Drawing.Point(248, 86)
        Me.DtaDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DtaDate.Name = "DtaDate"
        Me.DtaDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtaDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DtaDate.Properties.Mask.EditMask = "g"
        Me.DtaDate.Size = New System.Drawing.Size(288, 26)
        Me.DtaDate.TabIndex = 27
        Me.DtaDate.ToolTip = "Seleccione fecha"
        '
        'TabNavigationPage3
        '
        Me.TabNavigationPage3.Caption = "Procesar Archivo"
        Me.TabNavigationPage3.Controls.Add(Me.GridControl1)
        Me.TabNavigationPage3.Controls.Add(Me.ToolStrip2)
        Me.TabNavigationPage3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabNavigationPage3.Name = "TabNavigationPage3"
        Me.TabNavigationPage3.Size = New System.Drawing.Size(1158, 812)
        '
        'GridControl1
        '
        Me.GridControl1.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GridControl1.Location = New System.Drawing.Point(0, 25)
        Me.GridControl1.MainView = Me.GridView3
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1158, 787)
        Me.GridControl1.TabIndex = 27
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSKU, Me.GridColumnDescription, Me.GridColumnQtyRequested, Me.GridColumnQtyOnHand, Me.GridColumnResult})
        Me.GridView3.GridControl = Me.GridControl1
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.ReadOnly = true
        Me.GridView3.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView3.OptionsNavigation.EnterMoveNextColumn = true
        Me.GridView3.OptionsView.ShowAutoFilterRow = true
        Me.GridView3.OptionsView.ShowFooter = true
        Me.GridView3.OptionsView.ShowViewCaption = true
        Me.GridView3.ViewCaption = "Preview del proceso"
        '
        'GridColumnSKU
        '
        Me.GridColumnSKU.Caption = "SKU"
        Me.GridColumnSKU.FieldName = "MATERIAL_ID"
        Me.GridColumnSKU.Name = "GridColumnSKU"
        Me.GridColumnSKU.OptionsColumn.ReadOnly = true
        Me.GridColumnSKU.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List
        Me.GridColumnSKU.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", "{0}")})
        Me.GridColumnSKU.Visible = true
        Me.GridColumnSKU.VisibleIndex = 0
        '
        'GridColumnDescription
        '
        Me.GridColumnDescription.Caption = "Descripcion"
        Me.GridColumnDescription.FieldName = "MATERIAL_NAME"
        Me.GridColumnDescription.Name = "GridColumnDescription"
        Me.GridColumnDescription.OptionsColumn.ReadOnly = true
        Me.GridColumnDescription.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.GridColumnDescription.Visible = true
        Me.GridColumnDescription.VisibleIndex = 1
        '
        'GridColumnQtyRequested
        '
        Me.GridColumnQtyRequested.Caption = "Cant.Requerida"
        Me.GridColumnQtyRequested.FieldName = "QTY_REQUESTED"
        Me.GridColumnQtyRequested.Name = "GridColumnQtyRequested"
        Me.GridColumnQtyRequested.OptionsColumn.ReadOnly = true
        Me.GridColumnQtyRequested.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY_REQUESTED", "SUM={0:0.##}")})
        Me.GridColumnQtyRequested.Visible = true
        Me.GridColumnQtyRequested.VisibleIndex = 2
        '
        'GridColumnQtyOnHand
        '
        Me.GridColumnQtyOnHand.Caption = "Cant.Inventario"
        Me.GridColumnQtyOnHand.FieldName = "QTY_ONHAND"
        Me.GridColumnQtyOnHand.Name = "GridColumnQtyOnHand"
        Me.GridColumnQtyOnHand.OptionsColumn.ReadOnly = true
        Me.GridColumnQtyOnHand.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY_ONHAND", "SUM={0:0.##}")})
        Me.GridColumnQtyOnHand.Visible = true
        Me.GridColumnQtyOnHand.VisibleIndex = 3
        '
        'GridColumnResult
        '
        Me.GridColumnResult.Caption = "Resultado"
        Me.GridColumnResult.FieldName = "PROCESS_RESULT"
        Me.GridColumnResult.Name = "GridColumnResult"
        Me.GridColumnResult.OptionsColumn.ReadOnly = true
        Me.GridColumnResult.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.GridColumnResult.Visible = true
        Me.GridColumnResult.VisibleIndex = 4
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton1, Me.toolStripSeparator4, Me.HelpToolStripButton})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.Size = New System.Drawing.Size(1158, 25)
        Me.ToolStrip2.TabIndex = 26
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'SaveToolStripButton1
        '
        Me.SaveToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton1.Image = CType(resources.GetObject("SaveToolStripButton1.Image"),System.Drawing.Image)
        Me.SaveToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton1.Name = "SaveToolStripButton1"
        Me.SaveToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton1.Text = "&Save"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"),System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.HelpToolStripButton.Text = "He&lp"
        '
        'FrmInventoryOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9!, 20!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1176, 863)
        Me.Controls.Add(Me.TabPane1)
        Me.Controls.Add(Me.LstR)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FrmInventoryOut"
        Me.Text = "Egreso Externo"
        CType(Me.TabPane1,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPane1.ResumeLayout(false)
        Me.TabNavigationPage1.ResumeLayout(false)
        Me.TabNavigationPage1.PerformLayout
        CType(Me.GCEgreso,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.TabNavigationPage2.ResumeLayout(false)
        Me.TabNavigationPage2.PerformLayout
        CType(Me.GLUClientes.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DtaDate.Properties.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DtaDate.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabNavigationPage3.ResumeLayout(false)
        Me.TabNavigationPage3.PerformLayout
        CType(Me.GridControl1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView3,System.ComponentModel.ISupportInitialize).EndInit
        Me.ToolStrip2.ResumeLayout(false)
        Me.ToolStrip2.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents LstR As System.Windows.Forms.ListBox
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents TabNavigationPage1 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents GCEgreso As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TabNavigationPage2 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnUpload As Button
    Friend WithEvents GLUClientes As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DtaDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents OpenToolStripButton As ToolStripButton
    Friend WithEvents SaveToolStripButton As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents toolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TabNavigationPage3 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSKU As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyRequested As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyOnHand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnResult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents SaveToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator4 As ToolStripSeparator
    Friend WithEvents HelpToolStripButton As ToolStripButton
End Class
