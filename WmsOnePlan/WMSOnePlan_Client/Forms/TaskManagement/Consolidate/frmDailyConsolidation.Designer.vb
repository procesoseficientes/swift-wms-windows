<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDailyConsolidation
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.btnImprimir = New DevExpress.XtraEditors.SimpleButton
        Me.lblUsuario = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.btnGo = New DevExpress.XtraEditors.SimpleButton
        Me.txtFecha = New DevExpress.XtraEditors.DateEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.grdPedido = New DevExpress.XtraGrid.Columns.GridColumn
        Me.grdUnidades = New DevExpress.XtraGrid.Columns.GridColumn
        Me.grdProductos = New DevExpress.XtraGrid.Columns.GridColumn
        Me.grdInicio = New DevExpress.XtraGrid.Columns.GridColumn
        Me.grdFin = New DevExpress.XtraGrid.Columns.GridColumn
        Me.grdMins = New DevExpress.XtraGrid.Columns.GridColumn
        Me.grdCajas = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtFecha.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(536, 322)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.btnImprimir)
        Me.GroupControl1.Controls.Add(Me.lblUsuario)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.btnGo)
        Me.GroupControl1.Controls.Add(Me.txtFecha)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(694, 73)
        Me.GroupControl1.TabIndex = 20
        '
        'btnImprimir
        '
        Me.btnImprimir.Appearance.Font = New System.Drawing.Font("Segoe Condensed", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Appearance.Options.UseFont = True
        Me.btnImprimir.Location = New System.Drawing.Point(334, 22)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(95, 23)
        Me.btnImprimir.TabIndex = 15
        Me.btnImprimir.Text = "Imprimir"
        '
        'lblUsuario
        '
        Me.lblUsuario.Appearance.Font = New System.Drawing.Font("Segoe Condensed", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(53, 48)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(35, 14)
        Me.lblUsuario.TabIndex = 14
        Me.lblUsuario.Text = "Usuario:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe Condensed", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 48)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 14)
        Me.LabelControl1.TabIndex = 13
        Me.LabelControl1.Text = "Usuario:"
        '
        'btnGo
        '
        Me.btnGo.Appearance.Font = New System.Drawing.Font("Segoe Condensed", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGo.Appearance.Options.UseFont = True
        Me.btnGo.Location = New System.Drawing.Point(233, 22)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(95, 23)
        Me.btnGo.TabIndex = 12
        Me.btnGo.Text = "Generar Reporte"
        '
        'txtFecha
        '
        Me.txtFecha.EditValue = Nothing
        Me.txtFecha.EnterMoveNextControl = True
        Me.txtFecha.Location = New System.Drawing.Point(85, 25)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Properties.Appearance.Font = New System.Drawing.Font("Segoe Condensed", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Properties.Appearance.Options.UseFont = True
        Me.txtFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.txtFecha.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtFecha.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.txtFecha.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtFecha.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText
        Me.txtFecha.Properties.Mask.BeepOnError = True
        Me.txtFecha.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.txtFecha.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.txtFecha.Properties.ShowWeekNumbers = True
        Me.txtFecha.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtFecha.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtFecha.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.txtFecha.Properties.VistaTimeProperties.DisplayFormat.FormatString = "d"
        Me.txtFecha.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtFecha.Properties.VistaTimeProperties.EditFormat.FormatString = "d"
        Me.txtFecha.Properties.VistaTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtFecha.Size = New System.Drawing.Size(142, 20)
        Me.txtFecha.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe Condensed", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(12, 28)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(67, 14)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Día de Reporte:"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 73)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(694, 290)
        Me.GridControl1.TabIndex = 22
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.ViewCaption.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.GridView1.Appearance.ViewCaption.Options.UseFont = True
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.grdPedido, Me.grdUnidades, Me.grdProductos, Me.grdInicio, Me.grdFin, Me.grdMins, Me.grdCajas})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupPanelText = "Organizar por columna"
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ERP_LEGACY_ID", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UNIDADES", Nothing, "")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsPrint.PrintPreview = True
        Me.GridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowViewCaption = True
        Me.GridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GridView1.ViewCaption = "InventarioOnLine"
        '
        'grdPedido
        '
        Me.grdPedido.Caption = "Pedido"
        Me.grdPedido.FieldName = "ERP_LEGACY_ID"
        Me.grdPedido.Name = "grdPedido"
        Me.grdPedido.OptionsColumn.AllowEdit = False
        Me.grdPedido.OptionsColumn.AllowFocus = False
        Me.grdPedido.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        Me.grdPedido.Visible = True
        Me.grdPedido.VisibleIndex = 0
        '
        'grdUnidades
        '
        Me.grdUnidades.Caption = "Unidades"
        Me.grdUnidades.FieldName = "UNIDADES"
        Me.grdUnidades.Name = "grdUnidades"
        Me.grdUnidades.OptionsColumn.AllowEdit = False
        Me.grdUnidades.OptionsColumn.AllowFocus = False
        Me.grdUnidades.OptionsColumn.ReadOnly = True
        Me.grdUnidades.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.grdUnidades.Visible = True
        Me.grdUnidades.VisibleIndex = 1
        Me.grdUnidades.Width = 55
        '
        'grdProductos
        '
        Me.grdProductos.Caption = "Productos"
        Me.grdProductos.FieldName = "PRODUCTOS"
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.OptionsColumn.AllowEdit = False
        Me.grdProductos.OptionsColumn.FixedWidth = True
        Me.grdProductos.OptionsColumn.ReadOnly = True
        Me.grdProductos.Visible = True
        Me.grdProductos.VisibleIndex = 2
        Me.grdProductos.Width = 60
        '
        'grdInicio
        '
        Me.grdInicio.Caption = "Inicio"
        Me.grdInicio.DisplayFormat.FormatString = "dd/MMM/yyyy hh:mm:ss tt"
        Me.grdInicio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.grdInicio.FieldName = "INICIO"
        Me.grdInicio.Name = "grdInicio"
        Me.grdInicio.OptionsColumn.AllowEdit = False
        Me.grdInicio.OptionsColumn.ReadOnly = True
        Me.grdInicio.Visible = True
        Me.grdInicio.VisibleIndex = 3
        Me.grdInicio.Width = 180
        '
        'grdFin
        '
        Me.grdFin.Caption = "Fin"
        Me.grdFin.DisplayFormat.FormatString = "dd/MMM/yyyy hh:mm:ss tt"
        Me.grdFin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.grdFin.FieldName = "FIN"
        Me.grdFin.Name = "grdFin"
        Me.grdFin.OptionsColumn.AllowEdit = False
        Me.grdFin.OptionsColumn.ReadOnly = True
        Me.grdFin.Visible = True
        Me.grdFin.VisibleIndex = 4
        Me.grdFin.Width = 180
        '
        'grdMins
        '
        Me.grdMins.Caption = "Minutos"
        Me.grdMins.DisplayFormat.FormatString = "###,##0"
        Me.grdMins.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.grdMins.FieldName = "MINS"
        Me.grdMins.Name = "grdMins"
        Me.grdMins.OptionsColumn.AllowEdit = False
        Me.grdMins.OptionsColumn.ReadOnly = True
        Me.grdMins.Visible = True
        Me.grdMins.VisibleIndex = 5
        Me.grdMins.Width = 60
        '
        'grdCajas
        '
        Me.grdCajas.Caption = "Cajas"
        Me.grdCajas.DisplayFormat.FormatString = "###,##0"
        Me.grdCajas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.grdCajas.FieldName = "CAJAS"
        Me.grdCajas.Name = "grdCajas"
        Me.grdCajas.OptionsColumn.AllowEdit = False
        Me.grdCajas.OptionsColumn.AllowFocus = False
        Me.grdCajas.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdCajas.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdCajas.OptionsColumn.ReadOnly = True
        Me.grdCajas.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.grdCajas.Visible = True
        Me.grdCajas.VisibleIndex = 6
        Me.grdCajas.Width = 66
        '
        'frmDailyConsolidation
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(694, 363)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDailyConsolidation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reporte de Consolidacion Diaria"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtFecha.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdPedido As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdUnidades As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdProductos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdInicio As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdFin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdMins As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdCajas As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnGo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblUsuario As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnImprimir As DevExpress.XtraEditors.SimpleButton

End Class
