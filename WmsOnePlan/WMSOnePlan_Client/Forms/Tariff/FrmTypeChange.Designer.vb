<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTypeChange
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
        Me.GridTypeChange = New DevExpress.XtraGrid.GridControl()
        Me.GridViewTypeChange = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTYPE_CHARGE_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCHARGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colWAREHOUSE_WEATHER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colREGIMEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOMMENT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDAY_TRIP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSERVICE_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTO_MOVIL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.tstOpciones = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnUpdate = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnExporExel = New System.Windows.Forms.ToolStripButton()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.GridTypeChange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTypeChange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridTypeChange
        '
        Me.GridTypeChange.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridTypeChange.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridTypeChange.Location = New System.Drawing.Point(0, 22)
        Me.GridTypeChange.MainView = Me.GridViewTypeChange
        Me.GridTypeChange.Name = "GridTypeChange"
        Me.GridTypeChange.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridTypeChange.Size = New System.Drawing.Size(699, 380)
        Me.GridTypeChange.TabIndex = 5
        Me.GridTypeChange.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewTypeChange})
        '
        'GridViewTypeChange
        '
        Me.GridViewTypeChange.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTYPE_CHARGE_ID, Me.colCHARGE, Me.colDESCRIPTION, Me.colWAREHOUSE_WEATHER, Me.colREGIMEN, Me.colCOMMENT, Me.colDAY_TRIP, Me.colSERVICE_NAME, Me.colTO_MOVIL})
        Me.GridViewTypeChange.GridControl = Me.GridTypeChange
        Me.GridViewTypeChange.GroupCount = 1
        Me.GridViewTypeChange.Name = "GridViewTypeChange"
        Me.GridViewTypeChange.OptionsBehavior.Editable = False
        Me.GridViewTypeChange.OptionsView.ShowAutoFilterRow = True
        Me.GridViewTypeChange.OptionsView.ShowFooter = True
        Me.GridViewTypeChange.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colCHARGE, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colTYPE_CHARGE_ID
        '
        Me.colTYPE_CHARGE_ID.Caption = "Codigo"
        Me.colTYPE_CHARGE_ID.FieldName = "TYPE_CHARGE_ID"
        Me.colTYPE_CHARGE_ID.Name = "colTYPE_CHARGE_ID"
        Me.colTYPE_CHARGE_ID.OptionsColumn.AllowEdit = False
        Me.colTYPE_CHARGE_ID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CERTIFICATE_ID", "Cantidad = {0}")})
        '
        'colCHARGE
        '
        Me.colCHARGE.Caption = "Tipo"
        Me.colCHARGE.FieldName = "CHARGE"
        Me.colCHARGE.Name = "colCHARGE"
        Me.colCHARGE.OptionsColumn.AllowEdit = False
        Me.colCHARGE.Visible = True
        Me.colCHARGE.VisibleIndex = 0
        '
        'colDESCRIPTION
        '
        Me.colDESCRIPTION.Caption = "Descripcion"
        Me.colDESCRIPTION.FieldName = "DESCRIPTION"
        Me.colDESCRIPTION.Name = "colDESCRIPTION"
        Me.colDESCRIPTION.OptionsColumn.AllowEdit = False
        Me.colDESCRIPTION.Visible = True
        Me.colDESCRIPTION.VisibleIndex = 0
        '
        'colWAREHOUSE_WEATHER
        '
        Me.colWAREHOUSE_WEATHER.Caption = "Clima"
        Me.colWAREHOUSE_WEATHER.FieldName = "WAREHOUSE_WEATHER"
        Me.colWAREHOUSE_WEATHER.Name = "colWAREHOUSE_WEATHER"
        Me.colWAREHOUSE_WEATHER.OptionsColumn.AllowEdit = False
        Me.colWAREHOUSE_WEATHER.Visible = True
        Me.colWAREHOUSE_WEATHER.VisibleIndex = 1
        '
        'colREGIMEN
        '
        Me.colREGIMEN.Caption = "Regimen"
        Me.colREGIMEN.FieldName = "REGIMEN"
        Me.colREGIMEN.Name = "colREGIMEN"
        Me.colREGIMEN.OptionsColumn.AllowEdit = False
        Me.colREGIMEN.Visible = True
        Me.colREGIMEN.VisibleIndex = 2
        '
        'colCOMMENT
        '
        Me.colCOMMENT.Caption = "Comentario"
        Me.colCOMMENT.FieldName = "COMMENT"
        Me.colCOMMENT.Name = "colCOMMENT"
        Me.colCOMMENT.OptionsColumn.AllowEdit = False
        Me.colCOMMENT.Visible = True
        Me.colCOMMENT.VisibleIndex = 3
        '
        'colDAY_TRIP
        '
        Me.colDAY_TRIP.Caption = "Jornada"
        Me.colDAY_TRIP.FieldName = "DAY_TRIP"
        Me.colDAY_TRIP.Name = "colDAY_TRIP"
        Me.colDAY_TRIP.Visible = True
        Me.colDAY_TRIP.VisibleIndex = 4
        '
        'colSERVICE_NAME
        '
        Me.colSERVICE_NAME.Caption = "Tipo Servicio"
        Me.colSERVICE_NAME.FieldName = "SERVICE_NAME"
        Me.colSERVICE_NAME.Name = "colSERVICE_NAME"
        Me.colSERVICE_NAME.Visible = True
        Me.colSERVICE_NAME.VisibleIndex = 5
        '
        'colTO_MOVIL
        '
        Me.colTO_MOVIL.Caption = "Para Movil"
        Me.colTO_MOVIL.CustomizationCaption = "Para Movil"
        Me.colTO_MOVIL.FieldName = "MOVIL"
        Me.colTO_MOVIL.Name = "colTO_MOVIL"
        Me.colTO_MOVIL.Visible = True
        Me.colTO_MOVIL.VisibleIndex = 6
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'tstOpciones
        '
        Me.tstOpciones.AutoSize = False
        Me.tstOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnUpdate, Me.btnDelete, Me.btnExporExel})
        Me.tstOpciones.Location = New System.Drawing.Point(0, 0)
        Me.tstOpciones.Name = "tstOpciones"
        Me.tstOpciones.Size = New System.Drawing.Size(699, 22)
        Me.tstOpciones.TabIndex = 4
        Me.tstOpciones.Text = "ToolStrip1"
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
        'FrmTypeChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 402)
        Me.Controls.Add(Me.GridTypeChange)
        Me.Controls.Add(Me.tstOpciones)
        Me.Name = "FrmTypeChange"
        Me.Text = "Tipo de Cobro"
        CType(Me.GridTypeChange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTypeChange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstOpciones.ResumeLayout(False)
        Me.tstOpciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridTypeChange As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewTypeChange As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colTYPE_CHARGE_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCHARGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colWAREHOUSE_WEATHER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colREGIMEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOMMENT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents tstOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExporExel As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents colDAY_TRIP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSERVICE_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTO_MOVIL As DevExpress.XtraGrid.Columns.GridColumn
End Class
