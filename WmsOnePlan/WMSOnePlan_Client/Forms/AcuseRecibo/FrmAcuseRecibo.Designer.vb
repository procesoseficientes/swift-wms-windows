<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAcuseRecibo
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
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition4 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAcuseRecibo))
        Dim Transition2 As DevExpress.Utils.Animation.Transition = New DevExpress.Utils.Animation.Transition()
        Dim SlideFadeTransition2 As DevExpress.Utils.Animation.SlideFadeTransition = New DevExpress.Utils.Animation.SlideFadeTransition()
        Me.colSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.pctFoto4 = New DevExpress.XtraEditors.PictureEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODIGO_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFOB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODIGO_TRANSPORTISTA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPLACA_TRANSPORTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNUMERO_CONTENEDOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNUMERO_MARCHAMO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFOTO_1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFOTO_2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFOTO_3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEstatusSat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMESSAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryIsLogged = New DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup()
        Me.btnFiltar = New DevExpress.XtraEditors.SimpleButton()
        Me.dtFechaFinal = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.dtFechaInicio = New DevExpress.XtraEditors.DateEdit()
        Me.pnlFotografias = New DevExpress.XtraEditors.GroupControl()
        Me.btnCerrar = New DevExpress.XtraEditors.SimpleButton()
        Me.pctFoto3 = New DevExpress.XtraEditors.PictureEdit()
        Me.pctFoto1 = New DevExpress.XtraEditors.PictureEdit()
        Me.pctFoto2 = New DevExpress.XtraEditors.PictureEdit()
        Me.DataSet_TransHistory1 = New WMSOnePlan_Client.DataSet_TransHistory()
        Me.TransitionManager1 = New DevExpress.Utils.Animation.TransitionManager()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.colNUMBER_OF_ATTEMPTS = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.pctFoto4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryIsLogged, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaFinal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaInicio.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaInicio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlFotografias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFotografias.SuspendLayout()
        CType(Me.pctFoto3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctFoto1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctFoto2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_TransHistory1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colSTATUS
        '
        Me.colSTATUS.Caption = "Estado"
        Me.colSTATUS.FieldName = "STATUS"
        Me.colSTATUS.Name = "colSTATUS"
        Me.colSTATUS.OptionsColumn.AllowEdit = False
        Me.colSTATUS.Visible = True
        Me.colSTATUS.VisibleIndex = 11
        '
        'pctFoto4
        '
        Me.pctFoto4.Location = New System.Drawing.Point(18, 25)
        Me.pctFoto4.Name = "pctFoto4"
        Me.pctFoto4.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.pctFoto4.Size = New System.Drawing.Size(528, 441)
        Me.pctFoto4.TabIndex = 6
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 31)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryIsLogged})
        Me.GridControl1.Size = New System.Drawing.Size(994, 479)
        Me.GridControl1.TabIndex = 18
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDOC_ID, Me.colCODIGO_POLIZA, Me.colFOB, Me.GridColumn1, Me.colCODIGO_TRANSPORTISTA, Me.colPLACA_TRANSPORTE, Me.colNUMERO_CONTENEDOR, Me.colNUMERO_MARCHAMO, Me.colFOTO_1, Me.colFOTO_2, Me.colFOTO_3, Me.colSTATUS, Me.colEstatusSat, Me.colMESSAGE, Me.colNUMBER_OF_ATTEMPTS})
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        StyleFormatCondition3.Appearance.Options.UseBackColor = True
        StyleFormatCondition3.Column = Me.colSTATUS
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition3.Expression = "[STATUS] = 'SATISFACTORIO'"
        StyleFormatCondition4.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        StyleFormatCondition4.Appearance.Options.UseBackColor = True
        StyleFormatCondition4.Column = Me.colSTATUS
        StyleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition4.Expression = "[STATUS] = 'DISCREPANCIA'"
        Me.GridView1.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition3, StyleFormatCondition4})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupPanelText = "Organizar por columna"
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "LOGIN_ID", Nothing, "")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GridView1.ViewCaption = "Clientes"
        '
        'colDOC_ID
        '
        Me.colDOC_ID.Caption = "No. Acuse Recibo"
        Me.colDOC_ID.FieldName = "DOC_ID"
        Me.colDOC_ID.Name = "colDOC_ID"
        Me.colDOC_ID.OptionsColumn.AllowEdit = False
        Me.colDOC_ID.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.colDOC_ID.Visible = True
        Me.colDOC_ID.VisibleIndex = 0
        Me.colDOC_ID.Width = 50
        '
        'colCODIGO_POLIZA
        '
        Me.colCODIGO_POLIZA.Caption = "Declaración"
        Me.colCODIGO_POLIZA.FieldName = "CODIGO_POLIZA"
        Me.colCODIGO_POLIZA.Name = "colCODIGO_POLIZA"
        Me.colCODIGO_POLIZA.OptionsColumn.AllowEdit = False
        Me.colCODIGO_POLIZA.Visible = True
        Me.colCODIGO_POLIZA.VisibleIndex = 1
        '
        'colFOB
        '
        Me.colFOB.Caption = "Fob Dolares"
        Me.colFOB.FieldName = "FOB"
        Me.colFOB.Name = "colFOB"
        Me.colFOB.OptionsColumn.AllowEdit = False
        Me.colFOB.Visible = True
        Me.colFOB.VisibleIndex = 2
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Fecha"
        Me.GridColumn1.FieldName = "DATE"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        '
        'colCODIGO_TRANSPORTISTA
        '
        Me.colCODIGO_TRANSPORTISTA.Caption = "Codigo Transportista"
        Me.colCODIGO_TRANSPORTISTA.FieldName = "CODIGO_TRANSPORTISTA"
        Me.colCODIGO_TRANSPORTISTA.Name = "colCODIGO_TRANSPORTISTA"
        Me.colCODIGO_TRANSPORTISTA.OptionsColumn.AllowEdit = False
        Me.colCODIGO_TRANSPORTISTA.Visible = True
        Me.colCODIGO_TRANSPORTISTA.VisibleIndex = 4
        '
        'colPLACA_TRANSPORTE
        '
        Me.colPLACA_TRANSPORTE.Caption = "Placa Trasnporte"
        Me.colPLACA_TRANSPORTE.CustomizationCaption = "Placa "
        Me.colPLACA_TRANSPORTE.FieldName = "PLACA_TRANSPORTE"
        Me.colPLACA_TRANSPORTE.Name = "colPLACA_TRANSPORTE"
        Me.colPLACA_TRANSPORTE.OptionsColumn.AllowEdit = False
        Me.colPLACA_TRANSPORTE.Visible = True
        Me.colPLACA_TRANSPORTE.VisibleIndex = 5
        '
        'colNUMERO_CONTENEDOR
        '
        Me.colNUMERO_CONTENEDOR.Caption = "No. Contenedor"
        Me.colNUMERO_CONTENEDOR.FieldName = "NUMERO_CONTENEDOR"
        Me.colNUMERO_CONTENEDOR.Name = "colNUMERO_CONTENEDOR"
        Me.colNUMERO_CONTENEDOR.OptionsColumn.AllowEdit = False
        Me.colNUMERO_CONTENEDOR.Visible = True
        Me.colNUMERO_CONTENEDOR.VisibleIndex = 6
        '
        'colNUMERO_MARCHAMO
        '
        Me.colNUMERO_MARCHAMO.Caption = "No. Marchamo"
        Me.colNUMERO_MARCHAMO.FieldName = "NUMERO_MARCHAMO"
        Me.colNUMERO_MARCHAMO.Name = "colNUMERO_MARCHAMO"
        Me.colNUMERO_MARCHAMO.OptionsColumn.AllowEdit = False
        Me.colNUMERO_MARCHAMO.Visible = True
        Me.colNUMERO_MARCHAMO.VisibleIndex = 7
        '
        'colFOTO_1
        '
        Me.colFOTO_1.Caption = "Foto 1"
        Me.colFOTO_1.FieldName = "FOTO_1"
        Me.colFOTO_1.Name = "colFOTO_1"
        Me.colFOTO_1.OptionsColumn.AllowEdit = False
        Me.colFOTO_1.Visible = True
        Me.colFOTO_1.VisibleIndex = 8
        '
        'colFOTO_2
        '
        Me.colFOTO_2.Caption = "Foto 2"
        Me.colFOTO_2.FieldName = "FOTO_2"
        Me.colFOTO_2.Name = "colFOTO_2"
        Me.colFOTO_2.OptionsColumn.AllowEdit = False
        Me.colFOTO_2.Visible = True
        Me.colFOTO_2.VisibleIndex = 9
        '
        'colFOTO_3
        '
        Me.colFOTO_3.Caption = "Foto 3"
        Me.colFOTO_3.FieldName = "FOTO_3"
        Me.colFOTO_3.Name = "colFOTO_3"
        Me.colFOTO_3.OptionsColumn.AllowEdit = False
        Me.colFOTO_3.Visible = True
        Me.colFOTO_3.VisibleIndex = 10
        '
        'colEstatusSat
        '
        Me.colEstatusSat.Caption = "Estado Sat"
        Me.colEstatusSat.FieldName = "EstatusSat"
        Me.colEstatusSat.Name = "colEstatusSat"
        Me.colEstatusSat.OptionsColumn.AllowEdit = False
        Me.colEstatusSat.Visible = True
        Me.colEstatusSat.VisibleIndex = 12
        '
        'colMESSAGE
        '
        Me.colMESSAGE.Caption = "Mensaje"
        Me.colMESSAGE.FieldName = "MESSAGE"
        Me.colMESSAGE.Name = "colMESSAGE"
        Me.colMESSAGE.OptionsColumn.AllowEdit = False
        Me.colMESSAGE.Visible = True
        Me.colMESSAGE.VisibleIndex = 13
        '
        'RepositoryIsLogged
        '
        Me.RepositoryIsLogged.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.RepositoryIsLogged.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Value
        Me.RepositoryIsLogged.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "LogIn"), New DevExpress.XtraEditors.Controls.RadioGroupItem(0, "LogOut")})
        Me.RepositoryIsLogged.Name = "RepositoryIsLogged"
        Me.RepositoryIsLogged.NullText = "1"
        '
        'btnFiltar
        '
        Me.btnFiltar.Image = CType(resources.GetObject("btnFiltar.Image"), System.Drawing.Image)
        Me.btnFiltar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnFiltar.Location = New System.Drawing.Point(689, 2)
        Me.btnFiltar.Name = "btnFiltar"
        Me.btnFiltar.Size = New System.Drawing.Size(45, 25)
        Me.btnFiltar.TabIndex = 29
        '
        'dtFechaFinal
        '
        Me.dtFechaFinal.EditValue = Nothing
        Me.dtFechaFinal.Location = New System.Drawing.Point(559, 5)
        Me.dtFechaFinal.Name = "dtFechaFinal"
        Me.dtFechaFinal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaFinal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaFinal.Size = New System.Drawing.Size(124, 20)
        Me.dtFechaFinal.TabIndex = 28
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(493, 5)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl2.TabIndex = 27
        Me.LabelControl2.Text = "Fecha Final:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(283, 8)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl1.TabIndex = 26
        Me.LabelControl1.Text = "Fecha de Inicio:"
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.EditValue = Nothing
        Me.dtFechaInicio.Location = New System.Drawing.Point(365, 5)
        Me.dtFechaInicio.Name = "dtFechaInicio"
        Me.dtFechaInicio.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaInicio.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaInicio.Size = New System.Drawing.Size(124, 20)
        Me.dtFechaInicio.TabIndex = 25
        '
        'pnlFotografias
        '
        Me.pnlFotografias.Controls.Add(Me.pctFoto4)
        Me.pnlFotografias.Controls.Add(Me.btnCerrar)
        Me.pnlFotografias.Controls.Add(Me.pctFoto3)
        Me.pnlFotografias.Controls.Add(Me.pctFoto1)
        Me.pnlFotografias.Controls.Add(Me.pctFoto2)
        Me.pnlFotografias.Location = New System.Drawing.Point(241, 30)
        Me.pnlFotografias.Name = "pnlFotografias"
        Me.pnlFotografias.Size = New System.Drawing.Size(672, 479)
        Me.pnlFotografias.TabIndex = 30
        Me.pnlFotografias.Text = "Fotografias"
        Me.pnlFotografias.Visible = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.Location = New System.Drawing.Point(629, 24)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(38, 44)
        Me.btnCerrar.TabIndex = 5
        '
        'pctFoto3
        '
        Me.pctFoto3.Location = New System.Drawing.Point(552, 306)
        Me.pctFoto3.Name = "pctFoto3"
        Me.pctFoto3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.pctFoto3.Size = New System.Drawing.Size(100, 100)
        Me.pctFoto3.TabIndex = 2
        '
        'pctFoto1
        '
        Me.pctFoto1.Location = New System.Drawing.Point(552, 94)
        Me.pctFoto1.Name = "pctFoto1"
        Me.pctFoto1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.pctFoto1.Size = New System.Drawing.Size(100, 100)
        Me.pctFoto1.TabIndex = 1
        '
        'pctFoto2
        '
        Me.pctFoto2.Location = New System.Drawing.Point(552, 200)
        Me.pctFoto2.Name = "pctFoto2"
        Me.pctFoto2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.pctFoto2.Size = New System.Drawing.Size(100, 100)
        Me.pctFoto2.TabIndex = 0
        '
        'DataSet_TransHistory1
        '
        Me.DataSet_TransHistory1.DataSetName = "DataSet_TransHistory"
        Me.DataSet_TransHistory1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TransitionManager1
        '
        Transition2.Control = Me.pctFoto4
        Transition2.ShowWaitingIndicator = DevExpress.Utils.DefaultBoolean.[False]
        SlideFadeTransition2.Parameters.Background = System.Drawing.Color.Empty
        SlideFadeTransition2.Parameters.FrameCount = Nothing
        Transition2.TransitionType = SlideFadeTransition2
        Me.TransitionManager1.Transitions.Add(Transition2)
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1, Me.BarButtonItem2})
        Me.BarManager1.MaxItemId = 2
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar1
        '
        Me.Bar1.BarName = "Herramientas"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarButtonItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.AllowQuickCustomization = False
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Herramientas"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Enviar Sat"
        Me.BarButtonItem1.Glyph = CType(resources.GetObject("BarButtonItem1.Glyph"), System.Drawing.Image)
        Me.BarButtonItem1.Id = 0
        Me.BarButtonItem1.LargeGlyph = CType(resources.GetObject("BarButtonItem1.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Barra de estado"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Barra de estado"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(994, 31)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 510)
        Me.barDockControlBottom.Size = New System.Drawing.Size(994, 23)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 31)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 479)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(994, 31)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 479)
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Cancelar Nota Acuse de Recibo"
        Me.BarButtonItem2.Glyph = CType(resources.GetObject("BarButtonItem2.Glyph"), System.Drawing.Image)
        Me.BarButtonItem2.Id = 1
        Me.BarButtonItem2.LargeGlyph = CType(resources.GetObject("BarButtonItem2.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'colNUMBER_OF_ATTEMPTS
        '
        Me.colNUMBER_OF_ATTEMPTS.Caption = "Numero de Intentos"
        Me.colNUMBER_OF_ATTEMPTS.Name = "colNUMBER_OF_ATTEMPTS"
        Me.colNUMBER_OF_ATTEMPTS.Visible = True
        Me.colNUMBER_OF_ATTEMPTS.VisibleIndex = 14
        '
        'FrmAcuseRecibo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 533)
        Me.Controls.Add(Me.pnlFotografias)
        Me.Controls.Add(Me.btnFiltar)
        Me.Controls.Add(Me.dtFechaFinal)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.dtFechaInicio)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FrmAcuseRecibo"
        Me.Text = "Acuses de Recibo"
        CType(Me.pctFoto4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryIsLogged, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaFinal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaInicio.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaInicio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlFotografias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFotografias.ResumeLayout(False)
        CType(Me.pctFoto3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctFoto1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctFoto2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_TransHistory1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryIsLogged As DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup
    Friend WithEvents colCODIGO_POLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFOB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODIGO_TRANSPORTISTA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPLACA_TRANSPORTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNUMERO_CONTENEDOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNUMERO_MARCHAMO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFOTO_1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFOTO_2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFOTO_3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnFiltar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtFechaFinal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtFechaInicio As DevExpress.XtraEditors.DateEdit
    Friend WithEvents pnlFotografias As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnCerrar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pctFoto3 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents pctFoto1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents pctFoto2 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents pctFoto4 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents DataSet_TransHistory1 As WMSOnePlan_Client.DataSet_TransHistory
    Friend WithEvents TransitionManager1 As DevExpress.Utils.Animation.TransitionManager
    Friend WithEvents colEstatusSat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMESSAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colNUMBER_OF_ATTEMPTS As DevExpress.XtraGrid.Columns.GridColumn
End Class
