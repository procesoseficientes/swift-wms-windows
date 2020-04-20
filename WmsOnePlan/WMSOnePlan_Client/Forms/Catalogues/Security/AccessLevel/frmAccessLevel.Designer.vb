<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccessLevel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccessLevel))
        Dim StyleFormatCondition1 As DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition = New DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition
        Me.TreeListColumn_IsGranted = New DevExpress.XtraTreeList.Columns.TreeListColumn
        Me.IsGrantedCheckButton = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.SmallIconsList = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lstview_searchresults = New System.Windows.Forms.ListView
        Me.col_PrivID = New System.Windows.Forms.ColumnHeader
        Me.col_PrivName = New System.Windows.Forms.ColumnHeader
        Me.col_Description = New System.Windows.Forms.ColumnHeader
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid
        Me.TreeListCheckPoints = New DevExpress.XtraTreeList.TreeList
        Me.TreeListColumnDescripcion = New DevExpress.XtraTreeList.Columns.TreeListColumn
        Me.TreeListColumnCheckID = New DevExpress.XtraTreeList.Columns.TreeListColumn
        Me.txtSearchCheckPoint = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.IsGrantedCheckButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.TreeListCheckPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TreeListColumn_IsGranted
        '
        Me.TreeListColumn_IsGranted.ColumnEdit = Me.IsGrantedCheckButton
        Me.TreeListColumn_IsGranted.FieldName = "IS_GRANTED"
        Me.TreeListColumn_IsGranted.Name = "TreeListColumn_IsGranted"
        Me.TreeListColumn_IsGranted.Visible = True
        Me.TreeListColumn_IsGranted.VisibleIndex = 1
        '
        'IsGrantedCheckButton
        '
        Me.IsGrantedCheckButton.AccessibleDescription = "IsGranted"
        Me.IsGrantedCheckButton.AutoHeight = False
        Me.IsGrantedCheckButton.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Value
        Me.IsGrantedCheckButton.Name = "IsGrantedCheckButton"
        Me.IsGrantedCheckButton.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.IsGrantedCheckButton.ValueChecked = 1
        Me.IsGrantedCheckButton.ValueUnchecked = Nothing
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.SaveToolStripButton, Me.CutToolStripButton, Me.toolStripSeparator, Me.PrintToolStripButton, Me.toolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(409, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NewToolStripButton.Text = "&New"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Symbols_Delete_icon
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CutToolStripButton.Text = "C&ut"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'SmallIconsList
        '
        Me.SmallIconsList.ImageStream = CType(resources.GetObject("SmallIconsList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.SmallIconsList.TransparentColor = System.Drawing.Color.Transparent
        Me.SmallIconsList.Images.SetKeyName(0, "small_edit.png")
        Me.SmallIconsList.Images.SetKeyName(1, "about.png")
        Me.SmallIconsList.Images.SetKeyName(2, "CLSDFOLD.BMP")
        Me.SmallIconsList.Images.SetKeyName(3, "OPENFOLD.BMP")
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstview_searchresults)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Size = New System.Drawing.Size(785, 386)
        Me.SplitContainer1.SplitterDistance = 372
        Me.SplitContainer1.TabIndex = 8
        '
        'lstview_searchresults
        '
        Me.lstview_searchresults.AllowColumnReorder = True
        Me.lstview_searchresults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstview_searchresults.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_PrivID, Me.col_PrivName, Me.col_Description})
        Me.lstview_searchresults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstview_searchresults.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstview_searchresults.FullRowSelect = True
        Me.lstview_searchresults.GridLines = True
        Me.lstview_searchresults.HideSelection = False
        Me.lstview_searchresults.Location = New System.Drawing.Point(0, 44)
        Me.lstview_searchresults.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lstview_searchresults.MultiSelect = False
        Me.lstview_searchresults.Name = "lstview_searchresults"
        Me.lstview_searchresults.Size = New System.Drawing.Size(372, 342)
        Me.lstview_searchresults.SmallImageList = Me.SmallIconsList
        Me.lstview_searchresults.TabIndex = 19
        Me.lstview_searchresults.UseCompatibleStateImageBehavior = False
        Me.lstview_searchresults.View = System.Windows.Forms.View.Details
        '
        'col_PrivID
        '
        Me.col_PrivID.Text = "Codigo"
        Me.col_PrivID.Width = 141
        '
        'col_PrivName
        '
        Me.col_PrivName.Text = "Nombre"
        Me.col_PrivName.Width = 200
        '
        'col_Description
        '
        Me.col_Description.Text = "Descripcion"
        Me.col_Description.Width = 250
        '
        'txtSearch
        '
        Me.txtSearch.AcceptsReturn = True
        Me.txtSearch.AcceptsTab = True
        Me.txtSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtSearch.Font = New System.Drawing.Font("Segoe Condensed", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(0, 23)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(372, 21)
        Me.txtSearch.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Segoe Condensed", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(372, 23)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Niveles de Acceso"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.PropertyGrid1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.TreeListCheckPoints)
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtSearchCheckPoint)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer2.Size = New System.Drawing.Size(409, 361)
        Me.SplitContainer2.SplitterDistance = 105
        Me.SplitContainer2.TabIndex = 4
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PropertyGrid1.Location = New System.Drawing.Point(0, 0)
        Me.PropertyGrid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(409, 105)
        Me.PropertyGrid1.TabIndex = 3
        '
        'TreeListCheckPoints
        '
        Me.TreeListCheckPoints.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TreeListColumnDescripcion, Me.TreeListColumnCheckID, Me.TreeListColumn_IsGranted})
        Me.TreeListCheckPoints.CustomizationFormBounds = New System.Drawing.Rectangle(1054, 526, 216, 178)
        Me.TreeListCheckPoints.Dock = System.Windows.Forms.DockStyle.Fill
        StyleFormatCondition1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        StyleFormatCondition1.Appearance.Options.UseFont = True
        StyleFormatCondition1.ApplyToRow = True
        StyleFormatCondition1.Column = Me.TreeListColumn_IsGranted
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition1.Value1 = 1
        Me.TreeListCheckPoints.FormatConditions.AddRange(New DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition() {StyleFormatCondition1})
        Me.TreeListCheckPoints.KeyFieldName = "CHECK_ID"
        Me.TreeListCheckPoints.Location = New System.Drawing.Point(0, 44)
        Me.TreeListCheckPoints.Name = "TreeListCheckPoints"
        Me.TreeListCheckPoints.OptionsBehavior.PopulateServiceColumns = True
        Me.TreeListCheckPoints.ParentFieldName = "PARENT"
        Me.TreeListCheckPoints.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.IsGrantedCheckButton})
        Me.TreeListCheckPoints.Size = New System.Drawing.Size(409, 208)
        Me.TreeListCheckPoints.TabIndex = 28
        '
        'TreeListColumnDescripcion
        '
        Me.TreeListColumnDescripcion.Caption = "Opcion"
        Me.TreeListColumnDescripcion.FieldName = "DESCRIPTION"
        Me.TreeListColumnDescripcion.Name = "TreeListColumnDescripcion"
        Me.TreeListColumnDescripcion.OptionsColumn.AllowEdit = False
        Me.TreeListColumnDescripcion.OptionsColumn.ReadOnly = True
        Me.TreeListColumnDescripcion.Visible = True
        Me.TreeListColumnDescripcion.VisibleIndex = 0
        Me.TreeListColumnDescripcion.Width = 185
        '
        'TreeListColumnCheckID
        '
        Me.TreeListColumnCheckID.Caption = "CHECKPOINT"
        Me.TreeListColumnCheckID.FieldName = "CHECK_ID"
        Me.TreeListColumnCheckID.Name = "TreeListColumnCheckID"
        Me.TreeListColumnCheckID.OptionsColumn.AllowEdit = False
        Me.TreeListColumnCheckID.OptionsColumn.ReadOnly = True
        Me.TreeListColumnCheckID.OptionsColumn.ShowInCustomizationForm = False
        '
        'txtSearchCheckPoint
        '
        Me.txtSearchCheckPoint.AcceptsReturn = True
        Me.txtSearchCheckPoint.AcceptsTab = True
        Me.txtSearchCheckPoint.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtSearchCheckPoint.Font = New System.Drawing.Font("Segoe Condensed", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchCheckPoint.Location = New System.Drawing.Point(0, 23)
        Me.txtSearchCheckPoint.Name = "txtSearchCheckPoint"
        Me.txtSearchCheckPoint.Size = New System.Drawing.Size(409, 21)
        Me.txtSearchCheckPoint.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Segoe Condensed", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(409, 23)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Checkpoints Asignados"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmAccessLevel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 386)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAccessLevel"
        Me.Text = "Security: Niveles de Acceso"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.IsGrantedCheckButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.TreeListCheckPoints, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SmallIconsList As System.Windows.Forms.ImageList
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
    Friend WithEvents lstview_searchresults As System.Windows.Forms.ListView
    Friend WithEvents col_PrivID As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_PrivName As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents col_Description As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtSearchCheckPoint As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TreeListCheckPoints As DevExpress.XtraTreeList.TreeList
    Friend WithEvents TreeListColumnDescripcion As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TreeListColumnCheckID As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TreeListColumn_IsGranted As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents IsGrantedCheckButton As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
