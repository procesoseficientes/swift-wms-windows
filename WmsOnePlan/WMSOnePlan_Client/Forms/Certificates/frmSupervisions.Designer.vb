<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupervisions
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
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.GridSupervisions = New DevExpress.XtraGrid.GridControl()
        Me.GridViewSupervisions = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSUPER_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAUDIT_ADDRESS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOMMENTS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIS_INITIAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENT_OWHEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnUpdate = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnExporExel = New System.Windows.Forms.ToolStripButton()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.GridSupervisions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewSupervisions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridSupervisions
        '
        Me.GridSupervisions.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridSupervisions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridSupervisions.Location = New System.Drawing.Point(0, 22)
        Me.GridSupervisions.MainView = Me.GridViewSupervisions
        Me.GridSupervisions.Name = "GridSupervisions"
        Me.GridSupervisions.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridSupervisions.Size = New System.Drawing.Size(815, 388)
        Me.GridSupervisions.TabIndex = 5
        Me.GridSupervisions.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewSupervisions})
        '
        'GridViewSupervisions
        '
        Me.GridViewSupervisions.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSUPER_ID, Me.colAUDIT_ADDRESS, Me.colCOMMENTS, Me.colIS_INITIAL, Me.colCLIENT_OWHEN})
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        StyleFormatCondition1.Appearance.Options.UseBackColor = True
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition1.Value1 = CType(1, Short)
        Me.GridViewSupervisions.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1})
        Me.GridViewSupervisions.GridControl = Me.GridSupervisions
        Me.GridViewSupervisions.Name = "GridViewSupervisions"
        Me.GridViewSupervisions.OptionsBehavior.Editable = False
        Me.GridViewSupervisions.OptionsView.ShowAutoFilterRow = True
        Me.GridViewSupervisions.OptionsView.ShowFooter = True
        '
        'colSUPER_ID
        '
        Me.colSUPER_ID.Caption = "Codigo"
        Me.colSUPER_ID.FieldName = "SUPER_ID"
        Me.colSUPER_ID.Name = "colSUPER_ID"
        '
        'colAUDIT_ADDRESS
        '
        Me.colAUDIT_ADDRESS.Caption = "Dirección"
        Me.colAUDIT_ADDRESS.FieldName = "AUDIT_ADDRESS"
        Me.colAUDIT_ADDRESS.Name = "colAUDIT_ADDRESS"
        Me.colAUDIT_ADDRESS.Visible = True
        Me.colAUDIT_ADDRESS.VisibleIndex = 1
        '
        'colCOMMENTS
        '
        Me.colCOMMENTS.Caption = "Comentario"
        Me.colCOMMENTS.FieldName = "COMMENTS"
        Me.colCOMMENTS.Name = "colCOMMENTS"
        Me.colCOMMENTS.Visible = True
        Me.colCOMMENTS.VisibleIndex = 3
        '
        'colIS_INITIAL
        '
        Me.colIS_INITIAL.Caption = "Inspección Inicial"
        Me.colIS_INITIAL.FieldName = "IS_INITIAL"
        Me.colIS_INITIAL.Name = "colIS_INITIAL"
        Me.colIS_INITIAL.Visible = True
        Me.colIS_INITIAL.VisibleIndex = 2
        '
        'colCLIENT_OWHEN
        '
        Me.colCLIENT_OWHEN.Caption = "Cliente"
        Me.colCLIENT_OWHEN.FieldName = "CLIENT_OWHEN"
        Me.colCLIENT_OWHEN.Name = "colCLIENT_OWHEN"
        Me.colCLIENT_OWHEN.Visible = True
        Me.colCLIENT_OWHEN.VisibleIndex = 0
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnUpdate, Me.btnDelete, Me.btnExporExel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(815, 22)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNew.Image = Global.WMSOnePlan_Client.My.Resources.Resources.SaveAsPlainText
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(23, 19)
        Me.btnNew.Text = "Nuevo"
        '
        'btnUpdate
        '
        Me.btnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUpdate.Image = Global.WMSOnePlan_Client.My.Resources.Resources.SaveAsSmall
        Me.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(23, 19)
        Me.btnUpdate.Text = "Editar"
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDelete.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Symbols_Delete_icon
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(23, 19)
        Me.btnDelete.Text = "Borrar"
        '
        'btnExporExel
        '
        Me.btnExporExel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExporExel.Image = Global.WMSOnePlan_Client.My.Resources.Resources.export_excel
        Me.btnExporExel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExporExel.Name = "btnExporExel"
        Me.btnExporExel.Size = New System.Drawing.Size(23, 19)
        Me.btnExporExel.Text = "Exportar a Exel"
        '
        'frmSupervisions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 410)
        Me.Controls.Add(Me.GridSupervisions)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmSupervisions"
        Me.Text = "Inspecciones"
        CType(Me.GridSupervisions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewSupervisions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridSupervisions As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewSupervisions As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colSUPER_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAUDIT_ADDRESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOMMENTS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIS_INITIAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExporExel As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents colCLIENT_OWHEN As DevExpress.XtraGrid.Columns.GridColumn
End Class
