<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddNewLocation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddNewLocation))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.UiButtonSalirUbicacionesRelacionadas = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.lblProd = New System.Windows.Forms.ToolStripLabel()
        Me.lblProdDesc = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Desc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_ZONE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtMinQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.txtMaxQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.ToolStrip1.SuspendLayout
        CType(Me.GridControl1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtMinQty,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtMaxQty,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton, Me.UiButtonSalirUbicacionesRelacionadas, Me.toolStripSeparator, Me.lblProd, Me.lblProdDesc, Me.ToolStripSeparator1, Me.ToolStripProgressBar1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(549, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"),System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'UiButtonSalirUbicacionesRelacionadas
        '
        Me.UiButtonSalirUbicacionesRelacionadas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UiButtonSalirUbicacionesRelacionadas.Image = Global.WMSOnePlan_Client.My.Resources.Resources.UndoSmall
        Me.UiButtonSalirUbicacionesRelacionadas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UiButtonSalirUbicacionesRelacionadas.Name = "UiButtonSalirUbicacionesRelacionadas"
        Me.UiButtonSalirUbicacionesRelacionadas.Size = New System.Drawing.Size(23, 22)
        Me.UiButtonSalirUbicacionesRelacionadas.Text = "Salir"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'lblProd
        '
        Me.lblProd.Image = Global.WMSOnePlan_Client.My.Resources.Resources.ID_EDIT_GOTO_SMALL
        Me.lblProd.Name = "lblProd"
        Me.lblProd.Size = New System.Drawing.Size(32, 22)
        Me.lblProd.Text = "..."
        '
        'lblProdDesc
        '
        Me.lblProdDesc.Name = "lblProdDesc"
        Me.lblProdDesc.Size = New System.Drawing.Size(16, 22)
        Me.lblProdDesc.Text = "..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 22)
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 25)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtMinQty, Me.txtMaxQty})
        Me.GridControl1.Size = New System.Drawing.Size(549, 388)
        Me.GridControl1.TabIndex = 16
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn_ID, Me.GridColumn_Desc, Me.GridColumn_ZONE})
        Me.GridView1.FixedLineWidth = 1
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupCount = 1
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", Nothing, "")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.MultiSelect = true
        Me.GridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem
        Me.GridView1.OptionsView.ShowAutoFilterRow = true
        Me.GridView1.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn_ID, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.GridView1.ViewCaption = "Ubicaciones"
        '
        'GridColumn_ID
        '
        Me.GridColumn_ID.Caption = "Bodega"
        Me.GridColumn_ID.FieldName = "WAREHOUSE_PARENT"
        Me.GridColumn_ID.Name = "GridColumn_ID"
        Me.GridColumn_ID.OptionsColumn.AllowEdit = false
        Me.GridColumn_ID.OptionsColumn.FixedWidth = true
        Me.GridColumn_ID.OptionsColumn.ReadOnly = true
        Me.GridColumn_ID.Width = 50
        '
        'GridColumn_Desc
        '
        Me.GridColumn_Desc.Caption = "Ubicacion"
        Me.GridColumn_Desc.FieldName = "LOCATION_SPOT"
        Me.GridColumn_Desc.Name = "GridColumn_Desc"
        Me.GridColumn_Desc.OptionsColumn.AllowEdit = false
        Me.GridColumn_Desc.OptionsColumn.AllowFocus = false
        Me.GridColumn_Desc.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn_Desc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn_Desc.Visible = true
        Me.GridColumn_Desc.VisibleIndex = 0
        Me.GridColumn_Desc.Width = 100
        '
        'GridColumn_ZONE
        '
        Me.GridColumn_ZONE.Caption = "Zona"
        Me.GridColumn_ZONE.FieldName = "ZONE"
        Me.GridColumn_ZONE.Name = "GridColumn_ZONE"
        Me.GridColumn_ZONE.OptionsColumn.AllowEdit = false
        Me.GridColumn_ZONE.Visible = true
        Me.GridColumn_ZONE.VisibleIndex = 1
        '
        'txtMinQty
        '
        Me.txtMinQty.AutoHeight = false
        Me.txtMinQty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtMinQty.Name = "txtMinQty"
        '
        'txtMaxQty
        '
        Me.txtMaxQty.AutoHeight = false
        Me.txtMaxQty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtMaxQty.Name = "txtMaxQty"
        '
        'frmAddNewLocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 413)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmAddNewLocation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar ubicaciones relacionadas al producto"
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        CType(Me.GridControl1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtMinQty,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtMaxQty,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents UiButtonSalirUbicacionesRelacionadas As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Desc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblProd As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblProdDesc As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents txtMinQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents txtMaxQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumn_ZONE As DevExpress.XtraGrid.Columns.GridColumn
End Class
