<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngresoCertificado
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
        Me.gcBono = New DevExpress.XtraEditors.GroupControl()
        Me.cmbTipoMoneda = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.btnCancelarBono = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNumeroBono = New DevExpress.XtraEditors.TextEdit()
        Me.btnGrabarBono = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbCompania = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ceMonto = New DevExpress.XtraEditors.CalcEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.dtFechaFinal = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbCliente = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridViewCliente = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.dtFechaInicio = New DevExpress.XtraEditors.DateEdit()
        Me.btnGrabarMasBono = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbBodega = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmbInspeccion = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnGrabar = New DevExpress.XtraEditors.SimpleButton()
        Me.GridDet = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDet = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmbEstado = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.tabControles = New DevExpress.XtraTab.XtraTabControl()
        Me.tabGeneral = New DevExpress.XtraTab.XtraTabPage()
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
        CType(Me.gcBono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcBono.SuspendLayout()
        CType(Me.cmbTipoMoneda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumeroBono.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCompania.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ceMonto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaFinal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaInicio.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaInicio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbBodega.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbInspeccion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEstado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabControles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControles.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        Me.tabHistorial.SuspendLayout()
        CType(Me.GridHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gcBono
        '
        Me.gcBono.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gcBono.Controls.Add(Me.cmbTipoMoneda)
        Me.gcBono.Controls.Add(Me.LabelControl4)
        Me.gcBono.Controls.Add(Me.btnCancelarBono)
        Me.gcBono.Controls.Add(Me.txtNumeroBono)
        Me.gcBono.Controls.Add(Me.btnGrabarBono)
        Me.gcBono.Controls.Add(Me.cmbCompania)
        Me.gcBono.Controls.Add(Me.ceMonto)
        Me.gcBono.Controls.Add(Me.LabelControl3)
        Me.gcBono.Controls.Add(Me.LabelControl2)
        Me.gcBono.Controls.Add(Me.LabelControl1)
        Me.gcBono.Location = New System.Drawing.Point(-5, 566)
        Me.gcBono.Name = "gcBono"
        Me.gcBono.Size = New System.Drawing.Size(697, 168)
        Me.gcBono.TabIndex = 10
        Me.gcBono.Text = "Datos del Bono"
        Me.gcBono.Visible = False
        '
        'cmbTipoMoneda
        '
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(103, 80)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbTipoMoneda.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbTipoMoneda.Properties.NullText = ""
        Me.cmbTipoMoneda.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.cmbTipoMoneda.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cmbTipoMoneda.Properties.View = Me.GridView5
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(187, 20)
        Me.cmbTipoMoneda.TabIndex = 7
        '
        'GridView5
        '
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsView.ShowAutoFilterRow = True
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 83)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Moneda:"
        '
        'btnCancelarBono
        '
        Me.btnCancelarBono.Location = New System.Drawing.Point(588, 132)
        Me.btnCancelarBono.Name = "btnCancelarBono"
        Me.btnCancelarBono.Size = New System.Drawing.Size(100, 23)
        Me.btnCancelarBono.TabIndex = 4
        Me.btnCancelarBono.Text = "Cancelar Bono"
        '
        'txtNumeroBono
        '
        Me.txtNumeroBono.Location = New System.Drawing.Point(103, 54)
        Me.txtNumeroBono.Name = "txtNumeroBono"
        Me.txtNumeroBono.Properties.MaxLength = 20
        Me.txtNumeroBono.Size = New System.Drawing.Size(187, 20)
        Me.txtNumeroBono.TabIndex = 1
        '
        'btnGrabarBono
        '
        Me.btnGrabarBono.Location = New System.Drawing.Point(480, 132)
        Me.btnGrabarBono.Name = "btnGrabarBono"
        Me.btnGrabarBono.Size = New System.Drawing.Size(100, 23)
        Me.btnGrabarBono.TabIndex = 3
        Me.btnGrabarBono.Text = "Grabar"
        '
        'cmbCompania
        '
        Me.cmbCompania.Location = New System.Drawing.Point(103, 28)
        Me.cmbCompania.Name = "cmbCompania"
        Me.cmbCompania.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbCompania.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbCompania.Properties.NullText = ""
        Me.cmbCompania.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.cmbCompania.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cmbCompania.Properties.View = Me.GridView1
        Me.cmbCompania.Size = New System.Drawing.Size(582, 20)
        Me.cmbCompania.TabIndex = 0
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ceMonto
        '
        Me.ceMonto.Location = New System.Drawing.Point(103, 106)
        Me.ceMonto.Name = "ceMonto"
        Me.ceMonto.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ceMonto.Size = New System.Drawing.Size(187, 20)
        Me.ceMonto.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 109)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = "Monto:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 57)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(83, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Numero de Bono:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 31)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(80, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Entidad Emisora:"
        '
        'dtFechaFinal
        '
        Me.dtFechaFinal.EditValue = Nothing
        Me.dtFechaFinal.Location = New System.Drawing.Point(243, 69)
        Me.dtFechaFinal.Name = "dtFechaFinal"
        Me.dtFechaFinal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaFinal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaFinal.Properties.DisplayFormat.FormatString = "MM/dd/yyyy"
        Me.dtFechaFinal.Size = New System.Drawing.Size(110, 20)
        Me.dtFechaFinal.TabIndex = 3
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(231, 72)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(6, 13)
        Me.LabelControl5.TabIndex = 10
        Me.LabelControl5.Text = "a"
        '
        'cmbCliente
        '
        Me.cmbCliente.Location = New System.Drawing.Point(115, 95)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbCliente.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbCliente.Properties.NullText = ""
        Me.cmbCliente.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.cmbCliente.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cmbCliente.Properties.View = Me.GridViewCliente
        Me.cmbCliente.Size = New System.Drawing.Size(535, 20)
        Me.cmbCliente.TabIndex = 4
        '
        'GridViewCliente
        '
        Me.GridViewCliente.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridViewCliente.Name = "GridViewCliente"
        Me.GridViewCliente.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewCliente.OptionsView.ShowAutoFilterRow = True
        Me.GridViewCliente.OptionsView.ShowGroupPanel = False
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.EditValue = Nothing
        Me.dtFechaInicio.Location = New System.Drawing.Point(115, 69)
        Me.dtFechaInicio.Name = "dtFechaInicio"
        Me.dtFechaInicio.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaInicio.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaInicio.Properties.DisplayFormat.FormatString = "MM/dd/yyyy"
        Me.dtFechaInicio.Size = New System.Drawing.Size(110, 20)
        Me.dtFechaInicio.TabIndex = 2
        '
        'btnGrabarMasBono
        '
        Me.btnGrabarMasBono.Location = New System.Drawing.Point(475, 537)
        Me.btnGrabarMasBono.Name = "btnGrabarMasBono"
        Me.btnGrabarMasBono.Size = New System.Drawing.Size(100, 23)
        Me.btnGrabarMasBono.TabIndex = 4
        Me.btnGrabarMasBono.Text = "Añadir Bono"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(587, 537)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 23)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(85, 13)
        Me.LabelControl6.TabIndex = 4
        Me.LabelControl6.Text = "Inspección Inicial:"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(11, 98)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl8.TabIndex = 6
        Me.LabelControl8.Text = "Cliente:"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(11, 72)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(97, 13)
        Me.LabelControl9.TabIndex = 7
        Me.LabelControl9.Text = "Fecha de Validez del"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(11, 46)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl10.TabIndex = 8
        Me.LabelControl10.Text = "Estado:"
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(11, 20)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(90, 13)
        Me.LabelControl11.TabIndex = 9
        Me.LabelControl11.Text = "Bodega Habilitada:"
        '
        'cmbBodega
        '
        Me.cmbBodega.Location = New System.Drawing.Point(115, 17)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbBodega.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbBodega.Properties.NullText = ""
        Me.cmbBodega.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.cmbBodega.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cmbBodega.Properties.View = Me.GridView2
        Me.cmbBodega.Size = New System.Drawing.Size(535, 20)
        Me.cmbBodega.TabIndex = 0
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'cmbInspeccion
        '
        Me.cmbInspeccion.Location = New System.Drawing.Point(116, 12)
        Me.cmbInspeccion.Name = "cmbInspeccion"
        Me.cmbInspeccion.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbInspeccion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbInspeccion.Properties.NullText = ""
        Me.cmbInspeccion.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.cmbInspeccion.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cmbInspeccion.Properties.View = Me.GridView3
        Me.cmbInspeccion.Size = New System.Drawing.Size(567, 20)
        Me.cmbInspeccion.TabIndex = 0
        '
        'GridView3
        '
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowAutoFilterRow = True
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(359, 537)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(100, 23)
        Me.btnGrabar.TabIndex = 3
        Me.btnGrabar.Text = "Grabar"
        '
        'GridDet
        '
        Me.GridDet.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridDet.Location = New System.Drawing.Point(12, 38)
        Me.GridDet.MainView = Me.GridViewDet
        Me.GridDet.Name = "GridDet"
        Me.GridDet.Size = New System.Drawing.Size(671, 228)
        Me.GridDet.TabIndex = 1
        Me.GridDet.TabStop = False
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
        Me.colQTY.DisplayFormat.FormatString = "#,#.##"
        Me.colQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colQTY.FieldName = "QTY"
        Me.colQTY.Name = "colQTY"
        Me.colQTY.OptionsColumn.AllowEdit = False
        Me.colQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY", "Total = {0}")})
        Me.colQTY.Visible = True
        Me.colQTY.VisibleIndex = 2
        '
        'colCOST
        '
        Me.colCOST.Caption = "Costo"
        Me.colCOST.DisplayFormat.FormatString = "#,#.##"
        Me.colCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCOST.FieldName = "COST"
        Me.colCOST.Name = "colCOST"
        Me.colCOST.OptionsColumn.AllowEdit = False
        Me.colCOST.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "COST", "Total = {0}")})
        Me.colCOST.Visible = True
        Me.colCOST.VisibleIndex = 3
        '
        'cmbEstado
        '
        Me.cmbEstado.Location = New System.Drawing.Point(115, 43)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbEstado.Properties.Items.AddRange(New Object() {"Activo", "Vencido", "Anulado", "En remate", "Cancelado"})
        Me.cmbEstado.Size = New System.Drawing.Size(157, 20)
        Me.cmbEstado.TabIndex = 1
        '
        'tabControles
        '
        Me.tabControles.Location = New System.Drawing.Point(12, 272)
        Me.tabControles.Name = "tabControles"
        Me.tabControles.SelectedTabPage = Me.tabGeneral
        Me.tabControles.Size = New System.Drawing.Size(671, 259)
        Me.tabControles.TabIndex = 2
        Me.tabControles.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabGeneral, Me.tabHistorial})
        '
        'tabGeneral
        '
        Me.tabGeneral.Controls.Add(Me.cmbBodega)
        Me.tabGeneral.Controls.Add(Me.cmbEstado)
        Me.tabGeneral.Controls.Add(Me.LabelControl8)
        Me.tabGeneral.Controls.Add(Me.dtFechaInicio)
        Me.tabGeneral.Controls.Add(Me.LabelControl11)
        Me.tabGeneral.Controls.Add(Me.cmbCliente)
        Me.tabGeneral.Controls.Add(Me.dtFechaFinal)
        Me.tabGeneral.Controls.Add(Me.LabelControl9)
        Me.tabGeneral.Controls.Add(Me.LabelControl10)
        Me.tabGeneral.Controls.Add(Me.LabelControl5)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Size = New System.Drawing.Size(665, 231)
        Me.tabGeneral.Text = "Informacion General"
        '
        'tabHistorial
        '
        Me.tabHistorial.Controls.Add(Me.GridHistorial)
        Me.tabHistorial.Name = "tabHistorial"
        Me.tabHistorial.Size = New System.Drawing.Size(665, 231)
        Me.tabHistorial.Text = "Historial de Prorroga"
        '
        'GridHistorial
        '
        Me.GridHistorial.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridHistorial.Location = New System.Drawing.Point(3, 14)
        Me.GridHistorial.MainView = Me.GridView4
        Me.GridHistorial.Name = "GridHistorial"
        Me.GridHistorial.Size = New System.Drawing.Size(659, 214)
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
        'frmIngresoCertificado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 746)
        Me.Controls.Add(Me.tabControles)
        Me.Controls.Add(Me.GridDet)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.cmbInspeccion)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.gcBono)
        Me.Controls.Add(Me.btnGrabarMasBono)
        Me.MaximizeBox = False
        Me.Name = "frmIngresoCertificado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso Certificado"
        CType(Me.gcBono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcBono.ResumeLayout(False)
        Me.gcBono.PerformLayout()
        CType(Me.cmbTipoMoneda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumeroBono.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCompania.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ceMonto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaFinal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCliente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaInicio.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaInicio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbBodega.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbInspeccion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEstado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabControles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControles.ResumeLayout(False)
        Me.tabGeneral.ResumeLayout(False)
        Me.tabGeneral.PerformLayout()
        Me.tabHistorial.ResumeLayout(False)
        CType(Me.GridHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gcBono As DevExpress.XtraEditors.GroupControl
    Friend WithEvents dtFechaInicio As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnGrabarMasBono As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbCliente As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridViewCliente As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents dtFechaFinal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ceMonto As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents btnGrabarBono As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbCompania As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbBodega As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbInspeccion As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnGrabar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtNumeroBono As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridDet As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbEstado As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents btnCancelarBono As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tabControles As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabHistorial As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabGeneral As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridHistorial As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCERTIFICATE_LOG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOLD_VALIN_FROM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOLD_VALIN_TO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNEW_VALID_FROM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNEW_VALID_TO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAUTHORIZED_BY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOMMENT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbTipoMoneda As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
