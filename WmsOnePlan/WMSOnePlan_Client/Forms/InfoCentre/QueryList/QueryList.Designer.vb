<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QueryList
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QueryList))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Me.BarManagerQuery = New DevExpress.XtraBars.BarManager()
        Me.BarraPrincipalConsultas = New DevExpress.XtraBars.Bar()
        Me.UiComboConsultas = New DevExpress.XtraBars.BarEditItem()
        Me.ListaConsultas = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.UiContenedorFechaInicio = New DevExpress.XtraBars.BarEditItem()
        Me.UiFechaInicio = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.UiContenedorFechaFinal = New DevExpress.XtraBars.BarEditItem()
        Me.UIFechaFinal = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.botonRefrescar = New DevExpress.XtraBars.BarButtonItem()
        Me.botonExcel = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonGrabarLayout = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonExpandir = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonContraer = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.GridConsultas = New DevExpress.XtraGrid.GridControl()
        Me.Consulta = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UiComboBodega = New DevExpress.XtraBars.BarEditItem()
        Me.UiDialogoParaGuardar = New System.Windows.Forms.SaveFileDialog()
        CType(Me.BarManagerQuery,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ListaConsultas,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiFechaInicio,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiFechaInicio.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UIFechaFinal,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UIFechaFinal.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridConsultas,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Consulta,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'BarManagerQuery
        '
        Me.BarManagerQuery.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.BarraPrincipalConsultas})
        Me.BarManagerQuery.DockControls.Add(Me.barDockControlTop)
        Me.BarManagerQuery.DockControls.Add(Me.barDockControlBottom)
        Me.BarManagerQuery.DockControls.Add(Me.barDockControlLeft)
        Me.BarManagerQuery.DockControls.Add(Me.barDockControlRight)
        Me.BarManagerQuery.Form = Me
        Me.BarManagerQuery.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.botonRefrescar, Me.botonExcel, Me.UiComboConsultas, Me.UiBotonGrabarLayout, Me.UiBotonExpandir, Me.UiBotonContraer, Me.UiContenedorFechaInicio, Me.UiContenedorFechaFinal})
        Me.BarManagerQuery.MaxItemId = 9
        Me.BarManagerQuery.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.ListaConsultas, Me.UiFechaInicio, Me.UIFechaFinal})
        '
        'BarraPrincipalConsultas
        '
        Me.BarraPrincipalConsultas.BarName = "Tools"
        Me.BarraPrincipalConsultas.DockCol = 0
        Me.BarraPrincipalConsultas.DockRow = 0
        Me.BarraPrincipalConsultas.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.BarraPrincipalConsultas.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(CType((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle Or DevExpress.XtraBars.BarLinkUserDefines.Width),DevExpress.XtraBars.BarLinkUserDefines), Me.UiComboConsultas, "", false, true, true, 157, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(CType((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle Or DevExpress.XtraBars.BarLinkUserDefines.Width),DevExpress.XtraBars.BarLinkUserDefines), Me.UiContenedorFechaInicio, "", false, true, true, 105, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(CType((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle Or DevExpress.XtraBars.BarLinkUserDefines.Width),DevExpress.XtraBars.BarLinkUserDefines), Me.UiContenedorFechaFinal, "", false, true, true, 89, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.botonRefrescar), New DevExpress.XtraBars.LinkPersistInfo(Me.botonExcel), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonGrabarLayout, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonExpandir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonContraer, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.BarraPrincipalConsultas.OptionsBar.AllowQuickCustomization = false
        Me.BarraPrincipalConsultas.OptionsBar.DisableClose = true
        Me.BarraPrincipalConsultas.OptionsBar.DisableCustomization = true
        Me.BarraPrincipalConsultas.OptionsBar.DrawBorder = false
        Me.BarraPrincipalConsultas.OptionsBar.DrawDragBorder = false
        Me.BarraPrincipalConsultas.OptionsBar.UseWholeRow = true
        Me.BarraPrincipalConsultas.Text = "Tools"
        '
        'UiComboConsultas
        '
        Me.UiComboConsultas.AutoFillWidth = true
        Me.UiComboConsultas.Caption = "Consultas"
        Me.UiComboConsultas.Edit = Me.ListaConsultas
        Me.UiComboConsultas.Glyph = CType(resources.GetObject("UiComboConsultas.Glyph"),System.Drawing.Image)
        Me.UiComboConsultas.Id = 3
        Me.UiComboConsultas.LargeGlyph = CType(resources.GetObject("UiComboConsultas.LargeGlyph"),System.Drawing.Image)
        Me.UiComboConsultas.Name = "UiComboConsultas"
        '
        'ListaConsultas
        '
        Me.ListaConsultas.AutoHeight = false
        Me.ListaConsultas.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ListaConsultas.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.ListaConsultas.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Código"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "Nombre")})
        Me.ListaConsultas.DisplayMember = "NAME"
        Me.ListaConsultas.Name = "ListaConsultas"
        Me.ListaConsultas.NullText = "..."
        Me.ListaConsultas.ValueMember = "ID"
        '
        'UiContenedorFechaInicio
        '
        Me.UiContenedorFechaInicio.Caption = "Fecha inicio:"
        Me.UiContenedorFechaInicio.Edit = Me.UiFechaInicio
        Me.UiContenedorFechaInicio.Glyph = CType(resources.GetObject("UiContenedorFechaInicio.Glyph"),System.Drawing.Image)
        Me.UiContenedorFechaInicio.Id = 7
        Me.UiContenedorFechaInicio.LargeGlyph = CType(resources.GetObject("UiContenedorFechaInicio.LargeGlyph"),System.Drawing.Image)
        Me.UiContenedorFechaInicio.Name = "UiContenedorFechaInicio"
        Me.UiContenedorFechaInicio.Size = New System.Drawing.Size(175, 0)
        '
        'UiFechaInicio
        '
        Me.UiFechaInicio.AutoHeight = false
        Me.UiFechaInicio.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiFechaInicio.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiFechaInicio.Name = "UiFechaInicio"
        '
        'UiContenedorFechaFinal
        '
        Me.UiContenedorFechaFinal.Caption = "Fecha final:"
        Me.UiContenedorFechaFinal.Edit = Me.UIFechaFinal
        Me.UiContenedorFechaFinal.Glyph = CType(resources.GetObject("UiContenedorFechaFinal.Glyph"),System.Drawing.Image)
        Me.UiContenedorFechaFinal.Id = 8
        Me.UiContenedorFechaFinal.LargeGlyph = CType(resources.GetObject("UiContenedorFechaFinal.LargeGlyph"),System.Drawing.Image)
        Me.UiContenedorFechaFinal.Name = "UiContenedorFechaFinal"
        Me.UiContenedorFechaFinal.Size = New System.Drawing.Size(175, 0)
        '
        'UIFechaFinal
        '
        Me.UIFechaFinal.AutoHeight = false
        Me.UIFechaFinal.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UIFechaFinal.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UIFechaFinal.Name = "UIFechaFinal"
        '
        'botonRefrescar
        '
        Me.botonRefrescar.Caption = "Refresh"
        Me.botonRefrescar.Glyph = CType(resources.GetObject("botonRefrescar.Glyph"),System.Drawing.Image)
        Me.botonRefrescar.Id = 1
        Me.botonRefrescar.LargeGlyph = CType(resources.GetObject("botonRefrescar.LargeGlyph"),System.Drawing.Image)
        Me.botonRefrescar.Name = "botonRefrescar"
        Me.botonRefrescar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'botonExcel
        '
        Me.botonExcel.AllowRightClickInMenu = false
        Me.botonExcel.Caption = "Excel"
        Me.botonExcel.Id = 2
        Me.botonExcel.ImageUri.Uri = "ExportToXLS"
        Me.botonExcel.Name = "botonExcel"
        Me.botonExcel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipTitleItem1.Text = "Enviar a Excel"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        Me.botonExcel.SuperTip = SuperToolTip1
        '
        'UiBotonGrabarLayout
        '
        Me.UiBotonGrabarLayout.Caption = "Grabar"
        Me.UiBotonGrabarLayout.Glyph = CType(resources.GetObject("UiBotonGrabarLayout.Glyph"),System.Drawing.Image)
        Me.UiBotonGrabarLayout.Id = 4
        Me.UiBotonGrabarLayout.LargeGlyph = CType(resources.GetObject("UiBotonGrabarLayout.LargeGlyph"),System.Drawing.Image)
        Me.UiBotonGrabarLayout.Name = "UiBotonGrabarLayout"
        '
        'UiBotonExpandir
        '
        Me.UiBotonExpandir.Caption = "Expandir"
        Me.UiBotonExpandir.Glyph = CType(resources.GetObject("UiBotonExpandir.Glyph"),System.Drawing.Image)
        Me.UiBotonExpandir.Id = 5
        Me.UiBotonExpandir.LargeGlyph = CType(resources.GetObject("UiBotonExpandir.LargeGlyph"),System.Drawing.Image)
        Me.UiBotonExpandir.Name = "UiBotonExpandir"
        '
        'UiBotonContraer
        '
        Me.UiBotonContraer.Caption = "Contraer"
        Me.UiBotonContraer.Glyph = CType(resources.GetObject("UiBotonContraer.Glyph"),System.Drawing.Image)
        Me.UiBotonContraer.Id = 6
        Me.UiBotonContraer.LargeGlyph = CType(resources.GetObject("UiBotonContraer.LargeGlyph"),System.Drawing.Image)
        Me.UiBotonContraer.Name = "UiBotonContraer"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = false
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1077, 31)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = false
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 490)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1077, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = false
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 31)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 459)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = false
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1077, 31)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 459)
        '
        'GridConsultas
        '
        Me.GridConsultas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridConsultas.Location = New System.Drawing.Point(0, 31)
        Me.GridConsultas.MainView = Me.Consulta
        Me.GridConsultas.MenuManager = Me.BarManagerQuery
        Me.GridConsultas.Name = "GridConsultas"
        Me.GridConsultas.Size = New System.Drawing.Size(1077, 459)
        Me.GridConsultas.TabIndex = 4
        Me.GridConsultas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Consulta})
        '
        'Consulta
        '
        Me.Consulta.GridControl = Me.GridConsultas
        Me.Consulta.Name = "Consulta"
        Me.Consulta.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.Consulta.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.Consulta.OptionsBehavior.Editable = false
        Me.Consulta.OptionsSelection.MultiSelect = true
        Me.Consulta.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.Consulta.OptionsView.ShowAutoFilterRow = true
        Me.Consulta.OptionsView.ShowFooter = true
        '
        'UiComboBodega
        '
        Me.UiComboBodega.Caption = "Bodega"
        Me.UiComboBodega.Edit = Nothing
        Me.UiComboBodega.Glyph = CType(resources.GetObject("UiComboBodega.Glyph"),System.Drawing.Image)
        Me.UiComboBodega.Id = 4
        Me.UiComboBodega.LargeGlyph = CType(resources.GetObject("UiComboBodega.LargeGlyph"),System.Drawing.Image)
        Me.UiComboBodega.Name = "UiComboBodega"
        Me.UiComboBodega.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'QueryList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 490)
        Me.Controls.Add(Me.GridConsultas)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "QueryList"
        Me.Text = "Consultas Personalizadas"
        CType(Me.BarManagerQuery,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ListaConsultas,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiFechaInicio.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiFechaInicio,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UIFechaFinal.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UIFechaFinal,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridConsultas,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Consulta,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents BarManagerQuery As DevExpress.XtraBars.BarManager
    Friend WithEvents BarraPrincipalConsultas As DevExpress.XtraBars.Bar
    Friend WithEvents botonRefrescar As DevExpress.XtraBars.BarButtonItem
    Public WithEvents botonExcel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents GridConsultas As DevExpress.XtraGrid.GridControl
    Friend WithEvents Consulta As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UiComboConsultas As DevExpress.XtraBars.BarEditItem
    Friend WithEvents ListaConsultas As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private WithEvents UiComboBodega As DevExpress.XtraBars.BarEditItem
    Friend WithEvents UiDialogoParaGuardar As SaveFileDialog
    Friend WithEvents UiBotonGrabarLayout As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonExpandir As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonContraer As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiContenedorFechaInicio As DevExpress.XtraBars.BarEditItem
    Friend WithEvents UiFechaInicio As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents UiContenedorFechaFinal As DevExpress.XtraBars.BarEditItem
    Friend WithEvents UIFechaFinal As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
End Class
