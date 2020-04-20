<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInsuranceDocsRenew
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
        Me.components = New System.ComponentModel.Container()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.dxError = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        Me.tabControles = New DevExpress.XtraTab.XtraTabControl()
        Me.tabGeneral = New DevExpress.XtraTab.XtraTabPage()
        Me.grpGeneral = New DevExpress.XtraEditors.GroupControl()
        Me.menComentario = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.txtAutoriazado = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.grpValidacion = New DevExpress.XtraEditors.GroupControl()
        Me.dtFechaFinal = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.dtFechaInicio = New DevExpress.XtraEditors.DateEdit()
        Me.tabHistorial = New DevExpress.XtraTab.XtraTabPage()
        Me.GridHistorial = New DevExpress.XtraGrid.GridControl()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCERTIFICATE_LOG = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOLD_VALIN_FROM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOLD_VALIN_TO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNEW_VALID_FROM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNEW_VALID_TO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAUTHORIZED_BY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOMMENT = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.dxError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabControles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControles.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        CType(Me.grpGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGeneral.SuspendLayout()
        CType(Me.menComentario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAutoriazado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpValidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpValidacion.SuspendLayout()
        CType(Me.dtFechaFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaFinal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaInicio.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaInicio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabHistorial.SuspendLayout()
        CType(Me.GridHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(601, 350)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(520, 350)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "Aceptar"
        '
        'dxError
        '
        Me.dxError.ContainerControl = Me
        '
        'tabControles
        '
        Me.tabControles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControles.Location = New System.Drawing.Point(12, 12)
        Me.tabControles.Name = "tabControles"
        Me.tabControles.SelectedTabPage = Me.tabGeneral
        Me.tabControles.Size = New System.Drawing.Size(688, 409)
        Me.tabControles.TabIndex = 17
        Me.tabControles.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabGeneral, Me.tabHistorial})
        '
        'tabGeneral
        '
        Me.tabGeneral.Controls.Add(Me.grpGeneral)
        Me.tabGeneral.Controls.Add(Me.btnCancelar)
        Me.tabGeneral.Controls.Add(Me.grpValidacion)
        Me.tabGeneral.Controls.Add(Me.btnAceptar)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Size = New System.Drawing.Size(682, 381)
        Me.tabGeneral.Text = "Informacion General"
        '
        'grpGeneral
        '
        Me.grpGeneral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpGeneral.Controls.Add(Me.menComentario)
        Me.grpGeneral.Controls.Add(Me.LabelControl10)
        Me.grpGeneral.Controls.Add(Me.txtAutoriazado)
        Me.grpGeneral.Controls.Add(Me.LabelControl11)
        Me.grpGeneral.Location = New System.Drawing.Point(3, 73)
        Me.grpGeneral.Name = "grpGeneral"
        Me.grpGeneral.Size = New System.Drawing.Size(676, 271)
        Me.grpGeneral.TabIndex = 7
        Me.grpGeneral.Text = "General"
        '
        'menComentario
        '
        Me.menComentario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.menComentario.Location = New System.Drawing.Point(10, 91)
        Me.menComentario.Name = "menComentario"
        Me.menComentario.Properties.MaxLength = 250
        Me.menComentario.Size = New System.Drawing.Size(647, 164)
        Me.menComentario.TabIndex = 1
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(10, 71)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl10.TabIndex = 2
        Me.LabelControl10.Text = "Motivo:"
        '
        'txtAutoriazado
        '
        Me.txtAutoriazado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAutoriazado.Location = New System.Drawing.Point(10, 45)
        Me.txtAutoriazado.Name = "txtAutoriazado"
        Me.txtAutoriazado.Properties.MaxLength = 25
        Me.txtAutoriazado.Size = New System.Drawing.Size(647, 20)
        Me.txtAutoriazado.TabIndex = 0
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(10, 25)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl11.TabIndex = 0
        Me.LabelControl11.Text = "Autorizado por:"
        '
        'grpValidacion
        '
        Me.grpValidacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpValidacion.Controls.Add(Me.dtFechaFinal)
        Me.grpValidacion.Controls.Add(Me.LabelControl12)
        Me.grpValidacion.Controls.Add(Me.LabelControl13)
        Me.grpValidacion.Controls.Add(Me.dtFechaInicio)
        Me.grpValidacion.Location = New System.Drawing.Point(3, 3)
        Me.grpValidacion.Name = "grpValidacion"
        Me.grpValidacion.Size = New System.Drawing.Size(676, 64)
        Me.grpValidacion.TabIndex = 6
        Me.grpValidacion.Text = "Valido"
        '
        'dtFechaFinal
        '
        Me.dtFechaFinal.EditValue = Nothing
        Me.dtFechaFinal.Location = New System.Drawing.Point(258, 28)
        Me.dtFechaFinal.Name = "dtFechaFinal"
        Me.dtFechaFinal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaFinal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaFinal.Properties.DisplayFormat.FormatString = "MM/dd/yyyy"
        Me.dtFechaFinal.Size = New System.Drawing.Size(110, 20)
        Me.dtFechaFinal.TabIndex = 1
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(233, 31)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl12.TabIndex = 12
        Me.LabelControl12.Text = "a"
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(10, 31)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(97, 13)
        Me.LabelControl13.TabIndex = 8
        Me.LabelControl13.Text = "Fecha de Validez del"
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.EditValue = Nothing
        Me.dtFechaInicio.Location = New System.Drawing.Point(127, 28)
        Me.dtFechaInicio.Name = "dtFechaInicio"
        Me.dtFechaInicio.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaInicio.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaInicio.Size = New System.Drawing.Size(100, 20)
        Me.dtFechaInicio.TabIndex = 0
        '
        'tabHistorial
        '
        Me.tabHistorial.Controls.Add(Me.GridHistorial)
        Me.tabHistorial.Name = "tabHistorial"
        Me.tabHistorial.Size = New System.Drawing.Size(682, 381)
        Me.tabHistorial.Text = "Historial de Prorroga"
        '
        'GridHistorial
        '
        Me.GridHistorial.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridHistorial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridHistorial.Location = New System.Drawing.Point(0, 0)
        Me.GridHistorial.MainView = Me.GridView4
        Me.GridHistorial.Name = "GridHistorial"
        Me.GridHistorial.Size = New System.Drawing.Size(682, 381)
        Me.GridHistorial.TabIndex = 2
        Me.GridHistorial.TabStop = False
        Me.GridHistorial.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        '
        'GridView4
        '
        Me.GridView4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCERTIFICATE_LOG, Me.colOLD_VALIN_FROM, Me.colOLD_VALIN_TO, Me.colNEW_VALID_FROM, Me.colNEW_VALID_TO, Me.colAUTHORIZED_BY, Me.colCOMMENT})
        Me.GridView4.GridControl = Me.GridHistorial
        Me.GridView4.GroupPanelText = "Organizar por columna"
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem
        Me.GridView4.OptionsView.ShowAutoFilterRow = True
        Me.GridView4.OptionsView.ShowFooter = True
        Me.GridView4.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GridView4.ViewCaption = "Clientes"
        '
        'colCERTIFICATE_LOG
        '
        Me.colCERTIFICATE_LOG.Caption = "Codigo"
        Me.colCERTIFICATE_LOG.FieldName = "CERTIFICATE_LOG"
        Me.colCERTIFICATE_LOG.Name = "colCERTIFICATE_LOG"
        Me.colCERTIFICATE_LOG.OptionsColumn.AllowEdit = False
        Me.colCERTIFICATE_LOG.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CODE", "Cantidad = {0}")})
        '
        'colOLD_VALIN_FROM
        '
        Me.colOLD_VALIN_FROM.Caption = "Fecha de Inicio Anterior"
        Me.colOLD_VALIN_FROM.DisplayFormat.FormatString = "dd/MMMM/yyyy"
        Me.colOLD_VALIN_FROM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colOLD_VALIN_FROM.FieldName = "OLD_VALIN_FROM"
        Me.colOLD_VALIN_FROM.Name = "colOLD_VALIN_FROM"
        Me.colOLD_VALIN_FROM.OptionsColumn.AllowEdit = False
        Me.colOLD_VALIN_FROM.Visible = True
        Me.colOLD_VALIN_FROM.VisibleIndex = 0
        '
        'colOLD_VALIN_TO
        '
        Me.colOLD_VALIN_TO.Caption = "Fecha Vencimiento Anterior"
        Me.colOLD_VALIN_TO.DisplayFormat.FormatString = "dd/MMMM/yyyy"
        Me.colOLD_VALIN_TO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colOLD_VALIN_TO.FieldName = "OLD_VALIN_TO"
        Me.colOLD_VALIN_TO.Name = "colOLD_VALIN_TO"
        Me.colOLD_VALIN_TO.OptionsColumn.AllowEdit = False
        Me.colOLD_VALIN_TO.Visible = True
        Me.colOLD_VALIN_TO.VisibleIndex = 1
        '
        'colNEW_VALID_FROM
        '
        Me.colNEW_VALID_FROM.Caption = "Fecha de Inicio"
        Me.colNEW_VALID_FROM.DisplayFormat.FormatString = "dd/MMMM/yyyy"
        Me.colNEW_VALID_FROM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colNEW_VALID_FROM.FieldName = "NEW_VALID_FROM"
        Me.colNEW_VALID_FROM.Name = "colNEW_VALID_FROM"
        Me.colNEW_VALID_FROM.OptionsColumn.AllowEdit = False
        Me.colNEW_VALID_FROM.Visible = True
        Me.colNEW_VALID_FROM.VisibleIndex = 2
        '
        'colNEW_VALID_TO
        '
        Me.colNEW_VALID_TO.Caption = "Fecha de Vencimiento "
        Me.colNEW_VALID_TO.DisplayFormat.FormatString = "dd/MMMM/yyyy"
        Me.colNEW_VALID_TO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colNEW_VALID_TO.FieldName = "NEW_VALID_TO"
        Me.colNEW_VALID_TO.Name = "colNEW_VALID_TO"
        Me.colNEW_VALID_TO.OptionsColumn.AllowEdit = False
        Me.colNEW_VALID_TO.Visible = True
        Me.colNEW_VALID_TO.VisibleIndex = 3
        '
        'colAUTHORIZED_BY
        '
        Me.colAUTHORIZED_BY.Caption = "Autorizado por"
        Me.colAUTHORIZED_BY.FieldName = "AUTHORIZED_BY"
        Me.colAUTHORIZED_BY.Name = "colAUTHORIZED_BY"
        Me.colAUTHORIZED_BY.Visible = True
        Me.colAUTHORIZED_BY.VisibleIndex = 4
        '
        'colCOMMENT
        '
        Me.colCOMMENT.Caption = "Comentario"
        Me.colCOMMENT.FieldName = "COMMENT"
        Me.colCOMMENT.Name = "colCOMMENT"
        Me.colCOMMENT.Visible = True
        Me.colCOMMENT.VisibleIndex = 5
        '
        'FrmInsuranceDocsRenew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 433)
        Me.Controls.Add(Me.tabControles)
        Me.Name = "FrmInsuranceDocsRenew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Renovar Poliza Seguro"
        CType(Me.dxError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabControles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControles.ResumeLayout(False)
        Me.tabGeneral.ResumeLayout(False)
        CType(Me.grpGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGeneral.ResumeLayout(False)
        Me.grpGeneral.PerformLayout()
        CType(Me.menComentario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAutoriazado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpValidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpValidacion.ResumeLayout(False)
        Me.grpValidacion.PerformLayout()
        CType(Me.dtFechaFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaFinal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaInicio.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaInicio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabHistorial.ResumeLayout(False)
        CType(Me.GridHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dxError As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents tabControles As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabGeneral As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents grpGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents menComentario As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAutoriazado As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents grpValidacion As DevExpress.XtraEditors.GroupControl
    Friend WithEvents dtFechaFinal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtFechaInicio As DevExpress.XtraEditors.DateEdit
    Friend WithEvents tabHistorial As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridHistorial As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCERTIFICATE_LOG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOLD_VALIN_FROM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOLD_VALIN_TO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNEW_VALID_FROM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNEW_VALID_TO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAUTHORIZED_BY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOMMENT As DevExpress.XtraGrid.Columns.GridColumn
End Class
