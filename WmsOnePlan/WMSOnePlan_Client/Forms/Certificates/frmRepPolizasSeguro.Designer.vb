<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepPolizasSeguro
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
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition4 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.colTotalPorcentaje = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridPolizasSeguro = New DevExpress.XtraGrid.GridControl()
        Me.GridViewPolizasSeguro = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colNumPoliza = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCodigoCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNombreCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFechaVencimiento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMontoAsegurado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMontoInventario = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPorcentaje = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGenerarReporte = New System.Windows.Forms.ToolStripButton()
        CType(Me.GridPolizasSeguro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPolizasSeguro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'colTotalPorcentaje
        '
        Me.colTotalPorcentaje.Caption = "TotalPorcentaje"
        Me.colTotalPorcentaje.FieldName = "TotalPorcentaje"
        Me.colTotalPorcentaje.Name = "colTotalPorcentaje"
        '
        'GridPolizasSeguro
        '
        Me.GridPolizasSeguro.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridPolizasSeguro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridPolizasSeguro.Location = New System.Drawing.Point(0, 22)
        Me.GridPolizasSeguro.MainView = Me.GridViewPolizasSeguro
        Me.GridPolizasSeguro.Name = "GridPolizasSeguro"
        Me.GridPolizasSeguro.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridPolizasSeguro.Size = New System.Drawing.Size(849, 407)
        Me.GridPolizasSeguro.TabIndex = 7
        Me.GridPolizasSeguro.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPolizasSeguro})
        '
        'GridViewPolizasSeguro
        '
        Me.GridViewPolizasSeguro.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colNumPoliza, Me.colCodigoCliente, Me.colNombreCliente, Me.colFechaVencimiento, Me.colMontoAsegurado, Me.colMontoInventario, Me.ColPorcentaje, Me.colTotalPorcentaje})
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        StyleFormatCondition3.Appearance.Options.UseBackColor = True
        StyleFormatCondition3.ApplyToRow = True
        StyleFormatCondition3.Column = Me.colTotalPorcentaje
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition3.Expression = "[Porcentaje] <= 15"
        StyleFormatCondition3.Value1 = "1"
        StyleFormatCondition4.Appearance.BackColor = System.Drawing.Color.SeaShell
        StyleFormatCondition4.Appearance.ForeColor = System.Drawing.Color.Red
        StyleFormatCondition4.Appearance.Options.UseBackColor = True
        StyleFormatCondition4.Appearance.Options.UseForeColor = True
        StyleFormatCondition4.ApplyToRow = True
        StyleFormatCondition4.Column = Me.colTotalPorcentaje
        StyleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition4.Expression = "[Porcentaje] <= 0"
        StyleFormatCondition4.Value1 = CType(1, Short)
        Me.GridViewPolizasSeguro.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition3, StyleFormatCondition4})
        Me.GridViewPolizasSeguro.GridControl = Me.GridPolizasSeguro
        Me.GridViewPolizasSeguro.Name = "GridViewPolizasSeguro"
        Me.GridViewPolizasSeguro.OptionsBehavior.Editable = False
        Me.GridViewPolizasSeguro.OptionsView.ShowAutoFilterRow = True
        Me.GridViewPolizasSeguro.OptionsView.ShowFooter = True
        '
        'colNumPoliza
        '
        Me.colNumPoliza.Caption = "Numero de Poliza"
        Me.colNumPoliza.FieldName = "NumPoliza"
        Me.colNumPoliza.Name = "colNumPoliza"
        Me.colNumPoliza.OptionsColumn.AllowEdit = False
        Me.colNumPoliza.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "NumPoliza", "Cantidad = {0}")})
        Me.colNumPoliza.Visible = True
        Me.colNumPoliza.VisibleIndex = 0
        '
        'colCodigoCliente
        '
        Me.colCodigoCliente.Caption = "Codigo de Cliente"
        Me.colCodigoCliente.FieldName = "CodigoCliente"
        Me.colCodigoCliente.Name = "colCodigoCliente"
        Me.colCodigoCliente.OptionsColumn.AllowEdit = False
        Me.colCodigoCliente.Visible = True
        Me.colCodigoCliente.VisibleIndex = 1
        '
        'colNombreCliente
        '
        Me.colNombreCliente.Caption = "Nombre del Cliente"
        Me.colNombreCliente.FieldName = "NombreCliente"
        Me.colNombreCliente.Name = "colNombreCliente"
        Me.colNombreCliente.OptionsColumn.AllowEdit = False
        Me.colNombreCliente.Visible = True
        Me.colNombreCliente.VisibleIndex = 2
        '
        'colFechaVencimiento
        '
        Me.colFechaVencimiento.Caption = "Fecha de Vencimiento"
        Me.colFechaVencimiento.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.colFechaVencimiento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colFechaVencimiento.FieldName = "FechaVencimiento"
        Me.colFechaVencimiento.Name = "colFechaVencimiento"
        Me.colFechaVencimiento.OptionsColumn.AllowEdit = False
        Me.colFechaVencimiento.Visible = True
        Me.colFechaVencimiento.VisibleIndex = 3
        '
        'colMontoAsegurado
        '
        Me.colMontoAsegurado.Caption = "Monto Asegurado"
        Me.colMontoAsegurado.DisplayFormat.FormatString = "#,#.00#"
        Me.colMontoAsegurado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colMontoAsegurado.FieldName = "MontoAsegurado"
        Me.colMontoAsegurado.Name = "colMontoAsegurado"
        Me.colMontoAsegurado.OptionsColumn.AllowEdit = False
        Me.colMontoAsegurado.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoAsegurado", "Total = {0}")})
        Me.colMontoAsegurado.Visible = True
        Me.colMontoAsegurado.VisibleIndex = 4
        '
        'colMontoInventario
        '
        Me.colMontoInventario.Caption = "Monto Inventario"
        Me.colMontoInventario.DisplayFormat.FormatString = "#,#.00#"
        Me.colMontoInventario.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colMontoInventario.FieldName = "MontoInventario"
        Me.colMontoInventario.Name = "colMontoInventario"
        Me.colMontoInventario.OptionsColumn.AllowEdit = False
        Me.colMontoInventario.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoInventario", "Total = {0}")})
        Me.colMontoInventario.Visible = True
        Me.colMontoInventario.VisibleIndex = 5
        '
        'ColPorcentaje
        '
        Me.ColPorcentaje.Caption = "Porcentaje Asegurado"
        Me.ColPorcentaje.DisplayFormat.FormatString = "#,#.00#"
        Me.ColPorcentaje.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPorcentaje.FieldName = "Porcentaje"
        Me.ColPorcentaje.Name = "ColPorcentaje"
        Me.ColPorcentaje.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Porcentaje", "Total = {0}%")})
        Me.ColPorcentaje.UnboundExpression = "[MontoAsegurado] / [MontoInvalido]"
        Me.ColPorcentaje.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.ColPorcentaje.Visible = True
        Me.ColPorcentaje.VisibleIndex = 6
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGenerarReporte})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(849, 22)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGenerarReporte
        '
        Me.btnGenerarReporte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGenerarReporte.Image = Global.WMSOnePlan_Client.My.Resources.Resources.printer
        Me.btnGenerarReporte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGenerarReporte.Name = "btnGenerarReporte"
        Me.btnGenerarReporte.Size = New System.Drawing.Size(23, 19)
        Me.btnGenerarReporte.Text = "ToolStripButton1"
        '
        'frmRepPolizasSeguro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 429)
        Me.Controls.Add(Me.GridPolizasSeguro)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmRepPolizasSeguro"
        Me.Text = "Reporte de Polizas de Seguro"
        CType(Me.GridPolizasSeguro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPolizasSeguro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridPolizasSeguro As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPolizasSeguro As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGenerarReporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents colNumPoliza As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCodigoCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNombreCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFechaVencimiento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMontoAsegurado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMontoInventario As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPorcentaje As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTotalPorcentaje As DevExpress.XtraGrid.Columns.GridColumn
End Class
