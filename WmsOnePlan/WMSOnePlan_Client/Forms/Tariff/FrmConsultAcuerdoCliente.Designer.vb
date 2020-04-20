<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsultAcuerdoCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultAcuerdoCliente))
        Me.GridAcuerdoCliente = New DevExpress.XtraGrid.GridControl()
        Me.GridViewAcuerdoCliente = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCLIENT_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colACUERDO_COMERCIAL_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colACUERDO_COMERCIAL_NOMBRE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.tstOpciones = New System.Windows.Forms.ToolStrip()
        Me.btnExporExel = New System.Windows.Forms.ToolStripButton()
        Me.btnExportPdf = New System.Windows.Forms.ToolStripButton()
        Me.btnGenerarReporte = New System.Windows.Forms.ToolStripButton()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.GridAcuerdoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAcuerdoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridAcuerdoCliente
        '
        Me.GridAcuerdoCliente.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridAcuerdoCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridAcuerdoCliente.Location = New System.Drawing.Point(0, 22)
        Me.GridAcuerdoCliente.MainView = Me.GridViewAcuerdoCliente
        Me.GridAcuerdoCliente.Name = "GridAcuerdoCliente"
        Me.GridAcuerdoCliente.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridAcuerdoCliente.Size = New System.Drawing.Size(1111, 518)
        Me.GridAcuerdoCliente.TabIndex = 9
        Me.GridAcuerdoCliente.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewAcuerdoCliente})
        '
        'GridViewAcuerdoCliente
        '
        Me.GridViewAcuerdoCliente.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCLIENT_CODE, Me.GridColumn1, Me.colACUERDO_COMERCIAL_ID, Me.colACUERDO_COMERCIAL_NOMBRE})
        Me.GridViewAcuerdoCliente.GridControl = Me.GridAcuerdoCliente
        Me.GridViewAcuerdoCliente.GroupCount = 2
        Me.GridViewAcuerdoCliente.Name = "GridViewAcuerdoCliente"
        Me.GridViewAcuerdoCliente.OptionsBehavior.Editable = False
        Me.GridViewAcuerdoCliente.OptionsView.ShowAutoFilterRow = True
        Me.GridViewAcuerdoCliente.OptionsView.ShowFooter = True
        Me.GridViewAcuerdoCliente.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colCLIENT_CODE, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colCLIENT_CODE
        '
        Me.colCLIENT_CODE.Caption = "Codigo Cliente"
        Me.colCLIENT_CODE.FieldName = "CLIENT_CODE"
        Me.colCLIENT_CODE.Name = "colCLIENT_CODE"
        Me.colCLIENT_CODE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CLIENT_ID", "Cantidad {0}")})
        Me.colCLIENT_CODE.Visible = True
        Me.colCLIENT_CODE.VisibleIndex = 0
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Nombre Cliente"
        Me.GridColumn1.FieldName = "CLIENT_NAME"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'colACUERDO_COMERCIAL_ID
        '
        Me.colACUERDO_COMERCIAL_ID.Caption = "Codigo Acuerdo Comercial"
        Me.colACUERDO_COMERCIAL_ID.FieldName = "ACUERDO_COMERCIAL_ID"
        Me.colACUERDO_COMERCIAL_ID.Name = "colACUERDO_COMERCIAL_ID"
        Me.colACUERDO_COMERCIAL_ID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ACUERDO_COMERCIAL_ID", "Cantidad {0}")})
        Me.colACUERDO_COMERCIAL_ID.Visible = True
        Me.colACUERDO_COMERCIAL_ID.VisibleIndex = 0
        '
        'colACUERDO_COMERCIAL_NOMBRE
        '
        Me.colACUERDO_COMERCIAL_NOMBRE.Caption = "Nombre Acuerdo Comercial"
        Me.colACUERDO_COMERCIAL_NOMBRE.FieldName = "ACUERDO_COMERCIAL_NOMBRE"
        Me.colACUERDO_COMERCIAL_NOMBRE.Name = "colACUERDO_COMERCIAL_NOMBRE"
        Me.colACUERDO_COMERCIAL_NOMBRE.Visible = True
        Me.colACUERDO_COMERCIAL_NOMBRE.VisibleIndex = 1
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'tstOpciones
        '
        Me.tstOpciones.AutoSize = False
        Me.tstOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExporExel, Me.btnExportPdf, Me.btnGenerarReporte})
        Me.tstOpciones.Location = New System.Drawing.Point(0, 0)
        Me.tstOpciones.Name = "tstOpciones"
        Me.tstOpciones.Size = New System.Drawing.Size(1111, 22)
        Me.tstOpciones.TabIndex = 8
        Me.tstOpciones.Text = "ToolStrip1"
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
        'btnExportPdf
        '
        Me.btnExportPdf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExportPdf.Image = CType(resources.GetObject("btnExportPdf.Image"), System.Drawing.Image)
        Me.btnExportPdf.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportPdf.Name = "btnExportPdf"
        Me.btnExportPdf.Size = New System.Drawing.Size(23, 19)
        Me.btnExportPdf.Text = "Exportar a PDF"
        '
        'btnGenerarReporte
        '
        Me.btnGenerarReporte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGenerarReporte.Image = Global.WMSOnePlan_Client.My.Resources.Resources.printer
        Me.btnGenerarReporte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGenerarReporte.Name = "btnGenerarReporte"
        Me.btnGenerarReporte.Size = New System.Drawing.Size(23, 19)
        Me.btnGenerarReporte.Text = "Generar Reporte"
        '
        'FrmConsultAcuerdoCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1111, 540)
        Me.Controls.Add(Me.GridAcuerdoCliente)
        Me.Controls.Add(Me.tstOpciones)
        Me.Name = "FrmConsultAcuerdoCliente"
        Me.Text = "Consulta de Acuerdos Comerciales por Cliente"
        CType(Me.GridAcuerdoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAcuerdoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstOpciones.ResumeLayout(False)
        Me.tstOpciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridAcuerdoCliente As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAcuerdoCliente As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCLIENT_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colACUERDO_COMERCIAL_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colACUERDO_COMERCIAL_NOMBRE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents tstOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents btnExporExel As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnExportPdf As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGenerarReporte As System.Windows.Forms.ToolStripButton
End Class
