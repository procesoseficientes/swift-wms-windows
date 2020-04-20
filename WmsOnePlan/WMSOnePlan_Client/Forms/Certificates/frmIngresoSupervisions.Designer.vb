<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngresoSupervisions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngresoSupervisions))
        Me.tbSupervisions = New DevExpress.XtraTab.XtraTabControl()
        Me.tbEncabezado = New DevExpress.XtraTab.XtraTabPage()
        Me.txtCliente = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.memComentario = New DevExpress.XtraEditors.MemoEdit()
        Me.chkInicial = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDireccion = New DevExpress.XtraEditors.TextEdit()
        Me.tbDetalle = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.GridDet = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDet = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnCerrar = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.tbSupervisions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbSupervisions.SuspendLayout()
        Me.tbEncabezado.SuspendLayout()
        CType(Me.txtCliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.memComentario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkInicial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDireccion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDetalle.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GridDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbSupervisions
        '
        Me.tbSupervisions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSupervisions.Location = New System.Drawing.Point(12, 12)
        Me.tbSupervisions.Name = "tbSupervisions"
        Me.tbSupervisions.SelectedTabPage = Me.tbEncabezado
        Me.tbSupervisions.Size = New System.Drawing.Size(757, 469)
        Me.tbSupervisions.TabIndex = 0
        Me.tbSupervisions.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tbEncabezado, Me.tbDetalle})
        '
        'tbEncabezado
        '
        Me.tbEncabezado.Controls.Add(Me.txtCliente)
        Me.tbEncabezado.Controls.Add(Me.LabelControl2)
        Me.tbEncabezado.Controls.Add(Me.btnCancelar)
        Me.tbEncabezado.Controls.Add(Me.btnAceptar)
        Me.tbEncabezado.Controls.Add(Me.memComentario)
        Me.tbEncabezado.Controls.Add(Me.chkInicial)
        Me.tbEncabezado.Controls.Add(Me.LabelControl6)
        Me.tbEncabezado.Controls.Add(Me.LabelControl5)
        Me.tbEncabezado.Controls.Add(Me.LabelControl1)
        Me.tbEncabezado.Controls.Add(Me.txtDireccion)
        Me.tbEncabezado.Name = "tbEncabezado"
        Me.tbEncabezado.Size = New System.Drawing.Size(751, 441)
        Me.tbEncabezado.Text = "Datos Generales"
        '
        'txtCliente
        '
        Me.txtCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCliente.Location = New System.Drawing.Point(117, 19)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Properties.MaxLength = 25
        Me.txtCliente.Size = New System.Drawing.Size(338, 20)
        Me.txtCliente.TabIndex = 13
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 22)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 12
        Me.LabelControl2.Text = "Cliente:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(649, 198)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(568, 198)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 10
        Me.btnAceptar.Text = "Aceptar"
        '
        'memComentario
        '
        Me.memComentario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.memComentario.Location = New System.Drawing.Point(117, 96)
        Me.memComentario.Name = "memComentario"
        Me.memComentario.Properties.MaxLength = 200
        Me.memComentario.Size = New System.Drawing.Size(607, 96)
        Me.memComentario.TabIndex = 8
        '
        'chkInicial
        '
        Me.chkInicial.Location = New System.Drawing.Point(117, 71)
        Me.chkInicial.Name = "chkInicial"
        Me.chkInicial.Properties.Caption = ""
        Me.chkInicial.Size = New System.Drawing.Size(75, 19)
        Me.chkInicial.TabIndex = 7
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 99)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl6.TabIndex = 6
        Me.LabelControl6.Text = "Comentario:"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 74)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(99, 13)
        Me.LabelControl5.TabIndex = 5
        Me.LabelControl5.Text = "Es Inspección Inicial:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 48)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Dirección:"
        '
        'txtDireccion
        '
        Me.txtDireccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDireccion.Location = New System.Drawing.Point(117, 45)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Properties.MaxLength = 50
        Me.txtDireccion.Size = New System.Drawing.Size(338, 20)
        Me.txtDireccion.TabIndex = 0
        '
        'tbDetalle
        '
        Me.tbDetalle.Controls.Add(Me.SplitContainerControl1)
        Me.tbDetalle.Name = "tbDetalle"
        Me.tbDetalle.Size = New System.Drawing.Size(751, 441)
        Me.tbDetalle.Text = "Detalle"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.ToolStrip1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.PropertyGrid1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GridDet)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(751, 441)
        Me.SplitContainerControl1.SplitterPosition = 253
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.SaveToolStripButton, Me.CutToolStripButton, Me.toolStripSeparator})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(253, 25)
        Me.ToolStrip1.TabIndex = 5
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
        'PropertyGrid1
        '
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PropertyGrid1.Location = New System.Drawing.Point(0, 0)
        Me.PropertyGrid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(253, 441)
        Me.PropertyGrid1.TabIndex = 4
        '
        'GridDet
        '
        Me.GridDet.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridDet.Location = New System.Drawing.Point(0, 0)
        Me.GridDet.MainView = Me.GridViewDet
        Me.GridDet.Name = "GridDet"
        Me.GridDet.Size = New System.Drawing.Size(493, 441)
        Me.GridDet.TabIndex = 16
        Me.GridDet.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDet})
        '
        'GridViewDet
        '
        Me.GridViewDet.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.GridViewDet.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODE, Me.colDESCRIPTION, Me.colQTY, Me.colCOST})
        Me.GridViewDet.GridControl = Me.GridDet
        Me.GridViewDet.GroupPanelText = "Organizar por columna"
        Me.GridViewDet.Name = "GridViewDet"
        Me.GridViewDet.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem
        Me.GridViewDet.OptionsView.ShowAutoFilterRow = True
        Me.GridViewDet.OptionsView.ShowFooter = True
        Me.GridViewDet.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GridViewDet.ViewCaption = "Clientes"
        '
        'colCODE
        '
        Me.colCODE.Caption = "Codigo"
        Me.colCODE.FieldName = "CODE"
        Me.colCODE.Name = "colCODE"
        Me.colCODE.OptionsColumn.AllowEdit = False
        Me.colCODE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CODE", "Cantidad = {0}")})
        Me.colCODE.Visible = True
        Me.colCODE.VisibleIndex = 0
        '
        'colDESCRIPTION
        '
        Me.colDESCRIPTION.Caption = "Descripción"
        Me.colDESCRIPTION.FieldName = "DESCRIPTION"
        Me.colDESCRIPTION.Name = "colDESCRIPTION"
        Me.colDESCRIPTION.OptionsColumn.AllowEdit = False
        Me.colDESCRIPTION.Visible = True
        Me.colDESCRIPTION.VisibleIndex = 1
        '
        'colQTY
        '
        Me.colQTY.Caption = "Cantidad"
        Me.colQTY.DisplayFormat.FormatString = "#,#.00#"
        Me.colQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colQTY.FieldName = "QTY"
        Me.colQTY.Name = "colQTY"
        Me.colQTY.OptionsColumn.AllowEdit = False
        Me.colQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY", "Total = {0:#,#.00#}")})
        Me.colQTY.Visible = True
        Me.colQTY.VisibleIndex = 2
        '
        'colCOST
        '
        Me.colCOST.Caption = "Costo"
        Me.colCOST.DisplayFormat.FormatString = "#,#.00#"
        Me.colCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCOST.FieldName = "COST"
        Me.colCOST.Name = "colCOST"
        Me.colCOST.OptionsColumn.AllowEdit = False
        Me.colCOST.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "COST", "Total = {0:#,#.00#}")})
        Me.colCOST.Visible = True
        Me.colCOST.VisibleIndex = 3
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Location = New System.Drawing.Point(691, 482)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.Text = "Cerrar"
        '
        'frmIngresoSupervisions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 514)
        Me.Controls.Add(Me.tbSupervisions)
        Me.Controls.Add(Me.btnCerrar)
        Me.Name = "frmIngresoSupervisions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de Inspecciones"
        CType(Me.tbSupervisions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbSupervisions.ResumeLayout(False)
        Me.tbEncabezado.ResumeLayout(False)
        Me.tbEncabezado.PerformLayout()
        CType(Me.txtCliente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.memComentario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkInicial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDireccion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDetalle.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GridDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbSupervisions As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tbEncabezado As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDireccion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbDetalle As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCerrar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents memComentario As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents chkInicial As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
    Friend WithEvents GridDet As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtCliente As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
