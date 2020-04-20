<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngresoAcuerdoComercial
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNombre = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.dtFechaIncio = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.dtFechaFinal = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.lblEstado = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.menComentarioEnc = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbRegimen = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.grupDetalle = New DevExpress.XtraEditors.GroupControl()
        Me.cmbMedida = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbTipoMedida = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.menComentarioDet = New DevExpress.XtraEditors.MemoEdit()
        Me.tstOpcionesDet = New System.Windows.Forms.ToolStrip()
        Me.btnNewDet = New System.Windows.Forms.ToolStripButton()
        Me.btnUpdateDet = New System.Windows.Forms.ToolStripButton()
        Me.btnDeleteDet = New System.Windows.Forms.ToolStripButton()
        Me.btnGrabarDet = New System.Windows.Forms.ToolStripButton()
        Me.GridDet = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDet = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSERIAL_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTYPE_CHARGE_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUNIT_PRICE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBILLING_FRECUENCY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLIMIT_TO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTYPE_MEASURE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colU_MEASURE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTX_SOURCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOMMENTS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPARAM_CAPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTransaccion = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.spinLimite = New DevExpress.XtraEditors.SpinEdit()
        Me.cmbFrecuencia = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.spinPrecioUn = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbTipoCobro = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmbMoneda = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tstOpecionesEnc = New System.Windows.Forms.ToolStrip()
        Me.btnGrabarEnc = New System.Windows.Forms.ToolStripButton()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbClima = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.dxError = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        Me.cmbUsuario = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.lblDiasFechas = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtNombre.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.dtFechaIncio.Properties.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.dtFechaIncio.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.dtFechaFinal.Properties.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.dtFechaFinal.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.menComentarioEnc.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmbRegimen.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.grupDetalle,System.ComponentModel.ISupportInitialize).BeginInit
        Me.grupDetalle.SuspendLayout
        CType(Me.cmbMedida.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmbTipoMedida.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.menComentarioDet.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tstOpcionesDet.SuspendLayout
        CType(Me.GridDet,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridViewDet,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemCheckEdit1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtTransaccion.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.spinLimite.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmbFrecuencia.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.spinPrecioUn.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmbTipoCobro.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmbMoneda.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView5,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tstOpecionesEnc.SuspendLayout
        CType(Me.cmbClima.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.dxError,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmbUsuario.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 44)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Nombre:"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(77, 41)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Properties.MaxLength = 50
        Me.txtNombre.Size = New System.Drawing.Size(729, 20)
        Me.txtNombre.TabIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 70)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Valido de "
        '
        'dtFechaIncio
        '
        Me.dtFechaIncio.EditValue = Nothing
        Me.dtFechaIncio.Location = New System.Drawing.Point(77, 67)
        Me.dtFechaIncio.Name = "dtFechaIncio"
        Me.dtFechaIncio.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaIncio.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaIncio.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtFechaIncio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtFechaIncio.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.dtFechaIncio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtFechaIncio.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtFechaIncio.Size = New System.Drawing.Size(100, 20)
        Me.dtFechaIncio.TabIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(197, 70)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(8, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "al"
        '
        'dtFechaFinal
        '
        Me.dtFechaFinal.EditValue = Nothing
        Me.dtFechaFinal.Location = New System.Drawing.Point(231, 67)
        Me.dtFechaFinal.Name = "dtFechaFinal"
        Me.dtFechaFinal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaFinal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaFinal.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.dtFechaFinal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtFechaFinal.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.dtFechaFinal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtFechaFinal.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dtFechaFinal.Size = New System.Drawing.Size(100, 20)
        Me.dtFechaFinal.TabIndex = 2
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(183, 96)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Moneda:"
        '
        'lblEstado
        '
        Me.lblEstado.Location = New System.Drawing.Point(183, 22)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(43, 13)
        Me.lblEstado.TabIndex = 8
        Me.lblEstado.Text = "lblEstado"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(12, 127)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl8.TabIndex = 12
        Me.LabelControl8.Text = "Comentario:"
        '
        'menComentarioEnc
        '
        Me.menComentarioEnc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.menComentarioEnc.Location = New System.Drawing.Point(12, 146)
        Me.menComentarioEnc.Name = "menComentarioEnc"
        Me.menComentarioEnc.Size = New System.Drawing.Size(1255, 64)
        Me.menComentarioEnc.TabIndex = 8
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 96)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl6.TabIndex = 14
        Me.LabelControl6.Text = "Regimen:"
        '
        'cmbRegimen
        '
        Me.cmbRegimen.EditValue = "FISCAL"
        Me.cmbRegimen.Location = New System.Drawing.Point(77, 93)
        Me.cmbRegimen.Name = "cmbRegimen"
        Me.cmbRegimen.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbRegimen.Properties.Items.AddRange(New Object() {"FISCAL", "GENERAL"})
        Me.cmbRegimen.Size = New System.Drawing.Size(100, 20)
        Me.cmbRegimen.TabIndex = 5
        '
        'grupDetalle
        '
        Me.grupDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grupDetalle.Controls.Add(Me.cmbMedida)
        Me.grupDetalle.Controls.Add(Me.LabelControl17)
        Me.grupDetalle.Controls.Add(Me.cmbTipoMedida)
        Me.grupDetalle.Controls.Add(Me.LabelControl7)
        Me.grupDetalle.Controls.Add(Me.menComentarioDet)
        Me.grupDetalle.Controls.Add(Me.tstOpcionesDet)
        Me.grupDetalle.Controls.Add(Me.GridDet)
        Me.grupDetalle.Controls.Add(Me.LabelControl16)
        Me.grupDetalle.Controls.Add(Me.txtTransaccion)
        Me.grupDetalle.Controls.Add(Me.LabelControl14)
        Me.grupDetalle.Controls.Add(Me.LabelControl13)
        Me.grupDetalle.Controls.Add(Me.spinLimite)
        Me.grupDetalle.Controls.Add(Me.cmbFrecuencia)
        Me.grupDetalle.Controls.Add(Me.LabelControl12)
        Me.grupDetalle.Controls.Add(Me.LabelControl11)
        Me.grupDetalle.Controls.Add(Me.spinPrecioUn)
        Me.grupDetalle.Controls.Add(Me.LabelControl10)
        Me.grupDetalle.Controls.Add(Me.cmbTipoCobro)
        Me.grupDetalle.Enabled = false
        Me.grupDetalle.Location = New System.Drawing.Point(12, 216)
        Me.grupDetalle.Name = "grupDetalle"
        Me.grupDetalle.Size = New System.Drawing.Size(1260, 444)
        Me.grupDetalle.TabIndex = 9
        Me.grupDetalle.Text = "Detalle"
        '
        'cmbMedida
        '
        Me.cmbMedida.EditValue = "N/A"
        Me.cmbMedida.Location = New System.Drawing.Point(84, 102)
        Me.cmbMedida.Name = "cmbMedida"
        Me.cmbMedida.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbMedida.Properties.Items.AddRange(New Object() {"N/A", "UNIDAD_CANTIDAD", "UNIDAD_PESO", "UNIDAD_VOLUMEN"})
        Me.cmbMedida.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cmbMedida.Size = New System.Drawing.Size(178, 20)
        Me.cmbMedida.TabIndex = 4
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(7, 105)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl17.TabIndex = 31
        Me.LabelControl17.Text = "Medida:"
        '
        'cmbTipoMedida
        '
        Me.cmbTipoMedida.Enabled = false
        Me.cmbTipoMedida.Location = New System.Drawing.Point(335, 102)
        Me.cmbTipoMedida.Name = "cmbTipoMedida"
        Me.cmbTipoMedida.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbTipoMedida.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbTipoMedida.Properties.NullText = ""
        Me.cmbTipoMedida.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.cmbTipoMedida.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cmbTipoMedida.Properties.View = Me.GridView3
        Me.cmbTipoMedida.Size = New System.Drawing.Size(194, 20)
        Me.cmbTipoMedida.TabIndex = 5
        '
        'GridView3
        '
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.GridView3.OptionsView.ShowAutoFilterRow = true
        Me.GridView3.OptionsView.ShowGroupPanel = false
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(7, 131)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl7.TabIndex = 25
        Me.LabelControl7.Text = "Comentario:"
        '
        'menComentarioDet
        '
        Me.menComentarioDet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.menComentarioDet.Location = New System.Drawing.Point(7, 150)
        Me.menComentarioDet.Name = "menComentarioDet"
        Me.menComentarioDet.Size = New System.Drawing.Size(1239, 61)
        Me.menComentarioDet.TabIndex = 7
        '
        'tstOpcionesDet
        '
        Me.tstOpcionesDet.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNewDet, Me.btnUpdateDet, Me.btnDeleteDet, Me.btnGrabarDet})
        Me.tstOpcionesDet.Location = New System.Drawing.Point(2, 20)
        Me.tstOpcionesDet.Name = "tstOpcionesDet"
        Me.tstOpcionesDet.Size = New System.Drawing.Size(1256, 25)
        Me.tstOpcionesDet.TabIndex = 9
        Me.tstOpcionesDet.Text = "ToolStrip1"
        '
        'btnNewDet
        '
        Me.btnNewDet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNewDet.Image = Global.WMSOnePlan_Client.My.Resources.Resources.SaveAsPlainText
        Me.btnNewDet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNewDet.Name = "btnNewDet"
        Me.btnNewDet.Size = New System.Drawing.Size(23, 22)
        Me.btnNewDet.Text = "Nuevo"
        '
        'btnUpdateDet
        '
        Me.btnUpdateDet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUpdateDet.Image = Global.WMSOnePlan_Client.My.Resources.Resources.SaveAsSmall
        Me.btnUpdateDet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUpdateDet.Name = "btnUpdateDet"
        Me.btnUpdateDet.Size = New System.Drawing.Size(23, 22)
        Me.btnUpdateDet.Text = "Editar"
        '
        'btnDeleteDet
        '
        Me.btnDeleteDet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDeleteDet.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Symbols_Delete_icon
        Me.btnDeleteDet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeleteDet.Name = "btnDeleteDet"
        Me.btnDeleteDet.Size = New System.Drawing.Size(23, 22)
        Me.btnDeleteDet.Text = "Borrar"
        '
        'btnGrabarDet
        '
        Me.btnGrabarDet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGrabarDet.Image = Global.WMSOnePlan_Client.My.Resources.Resources.save_large
        Me.btnGrabarDet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGrabarDet.Name = "btnGrabarDet"
        Me.btnGrabarDet.Size = New System.Drawing.Size(23, 22)
        Me.btnGrabarDet.Text = "Grabar"
        '
        'GridDet
        '
        Me.GridDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GridDet.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridDet.Location = New System.Drawing.Point(5, 217)
        Me.GridDet.MainView = Me.GridViewDet
        Me.GridDet.Name = "GridDet"
        Me.GridDet.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridDet.Size = New System.Drawing.Size(1250, 222)
        Me.GridDet.TabIndex = 8
        Me.GridDet.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDet})
        '
        'GridViewDet
        '
        Me.GridViewDet.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSERIAL_ID, Me.colTYPE_CHARGE_ID, Me.colDESCRIPTION, Me.colUNIT_PRICE, Me.colBILLING_FRECUENCY, Me.colLIMIT_TO, Me.colTYPE_MEASURE, Me.colU_MEASURE, Me.colTX_SOURCE, Me.colCOMMENTS, Me.colPARAM_CAPTION})
        Me.GridViewDet.GridControl = Me.GridDet
        Me.GridViewDet.Name = "GridViewDet"
        Me.GridViewDet.OptionsBehavior.Editable = false
        Me.GridViewDet.OptionsView.ShowAutoFilterRow = true
        Me.GridViewDet.OptionsView.ShowFooter = true
        '
        'colSERIAL_ID
        '
        Me.colSERIAL_ID.Caption = "Serial"
        Me.colSERIAL_ID.FieldName = "SERIAL_ID"
        Me.colSERIAL_ID.Name = "colSERIAL_ID"
        '
        'colTYPE_CHARGE_ID
        '
        Me.colTYPE_CHARGE_ID.Caption = "Codigo Tipo de Cobro"
        Me.colTYPE_CHARGE_ID.FieldName = "TYPE_CHARGE_ID"
        Me.colTYPE_CHARGE_ID.Name = "colTYPE_CHARGE_ID"
        '
        'colDESCRIPTION
        '
        Me.colDESCRIPTION.Caption = "Tipo de Cobro"
        Me.colDESCRIPTION.FieldName = "DESCRIPTION"
        Me.colDESCRIPTION.Name = "colDESCRIPTION"
        Me.colDESCRIPTION.Visible = true
        Me.colDESCRIPTION.VisibleIndex = 0
        '
        'colUNIT_PRICE
        '
        Me.colUNIT_PRICE.Caption = "Precio"
        Me.colUNIT_PRICE.FieldName = "UNIT_PRICE"
        Me.colUNIT_PRICE.Name = "colUNIT_PRICE"
        Me.colUNIT_PRICE.Visible = true
        Me.colUNIT_PRICE.VisibleIndex = 1
        '
        'colBILLING_FRECUENCY
        '
        Me.colBILLING_FRECUENCY.Caption = "Frecuencia"
        Me.colBILLING_FRECUENCY.FieldName = "BILLING_FRECUENCY"
        Me.colBILLING_FRECUENCY.Name = "colBILLING_FRECUENCY"
        Me.colBILLING_FRECUENCY.Visible = true
        Me.colBILLING_FRECUENCY.VisibleIndex = 2
        '
        'colLIMIT_TO
        '
        Me.colLIMIT_TO.Caption = "Limite"
        Me.colLIMIT_TO.FieldName = "LIMIT_TO"
        Me.colLIMIT_TO.Name = "colLIMIT_TO"
        Me.colLIMIT_TO.Visible = true
        Me.colLIMIT_TO.VisibleIndex = 3
        '
        'colTYPE_MEASURE
        '
        Me.colTYPE_MEASURE.Caption = "Tipo de Medida"
        Me.colTYPE_MEASURE.FieldName = "TYPE_MEASURE"
        Me.colTYPE_MEASURE.Name = "colTYPE_MEASURE"
        Me.colTYPE_MEASURE.Visible = true
        Me.colTYPE_MEASURE.VisibleIndex = 4
        '
        'colU_MEASURE
        '
        Me.colU_MEASURE.Caption = "Medida"
        Me.colU_MEASURE.FieldName = "U_MEASURE"
        Me.colU_MEASURE.Name = "colU_MEASURE"
        '
        'colTX_SOURCE
        '
        Me.colTX_SOURCE.Caption = "Transacción"
        Me.colTX_SOURCE.FieldName = "TX_SOURCE"
        Me.colTX_SOURCE.Name = "colTX_SOURCE"
        Me.colTX_SOURCE.Visible = true
        Me.colTX_SOURCE.VisibleIndex = 6
        '
        'colCOMMENTS
        '
        Me.colCOMMENTS.Caption = "Comentarios"
        Me.colCOMMENTS.FieldName = "COMMENTS"
        Me.colCOMMENTS.Name = "colCOMMENTS"
        Me.colCOMMENTS.Visible = true
        Me.colCOMMENTS.VisibleIndex = 7
        '
        'colPARAM_CAPTION
        '
        Me.colPARAM_CAPTION.Caption = "Tiopo de Medida"
        Me.colPARAM_CAPTION.FieldName = "PARAM_CAPTION"
        Me.colPARAM_CAPTION.Name = "colPARAM_CAPTION"
        Me.colPARAM_CAPTION.Visible = true
        Me.colPARAM_CAPTION.VisibleIndex = 5
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = false
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(535, 105)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl16.TabIndex = 23
        Me.LabelControl16.Text = "Transacción:"
        '
        'txtTransaccion
        '
        Me.txtTransaccion.Location = New System.Drawing.Point(624, 102)
        Me.txtTransaccion.Name = "txtTransaccion"
        Me.txtTransaccion.Size = New System.Drawing.Size(180, 20)
        Me.txtTransaccion.TabIndex = 6
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(268, 105)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl14.TabIndex = 20
        Me.LabelControl14.Text = "Tipo Medida:"
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(535, 79)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(83, 13)
        Me.LabelControl13.TabIndex = 18
        Me.LabelControl13.Text = "Minimo de Cobro:"
        '
        'spinLimite
        '
        Me.spinLimite.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.spinLimite.Location = New System.Drawing.Point(624, 76)
        Me.spinLimite.Name = "spinLimite"
        Me.spinLimite.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.spinLimite.Size = New System.Drawing.Size(180, 20)
        Me.spinLimite.TabIndex = 3
        '
        'cmbFrecuencia
        '
        Me.cmbFrecuencia.EditValue = "N/A"
        Me.cmbFrecuencia.Location = New System.Drawing.Point(84, 76)
        Me.cmbFrecuencia.Name = "cmbFrecuencia"
        Me.cmbFrecuencia.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbFrecuencia.Properties.Items.AddRange(New Object() {"N/A", "1=DIARIO", "7=SEMANAL", "15=QUINCENAL", "30=MENSUAL"})
        Me.cmbFrecuencia.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cmbFrecuencia.Size = New System.Drawing.Size(178, 20)
        Me.cmbFrecuencia.TabIndex = 2
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(7, 79)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl12.TabIndex = 12
        Me.LabelControl12.Text = "Frecuencia:"
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(535, 53)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl11.TabIndex = 11
        Me.LabelControl11.Text = "Precio Unitario:"
        '
        'spinPrecioUn
        '
        Me.spinPrecioUn.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.spinPrecioUn.Location = New System.Drawing.Point(624, 50)
        Me.spinPrecioUn.Name = "spinPrecioUn"
        Me.spinPrecioUn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.spinPrecioUn.Size = New System.Drawing.Size(180, 20)
        Me.spinPrecioUn.TabIndex = 1
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(7, 53)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl10.TabIndex = 9
        Me.LabelControl10.Text = "Tipo de Cobro:"
        '
        'cmbTipoCobro
        '
        Me.cmbTipoCobro.Location = New System.Drawing.Point(84, 50)
        Me.cmbTipoCobro.Name = "cmbTipoCobro"
        Me.cmbTipoCobro.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbTipoCobro.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbTipoCobro.Properties.NullText = ""
        Me.cmbTipoCobro.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.cmbTipoCobro.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cmbTipoCobro.Properties.View = Me.GridView1
        Me.cmbTipoCobro.Size = New System.Drawing.Size(445, 20)
        Me.cmbTipoCobro.TabIndex = 0
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.GridView1.OptionsView.ShowAutoFilterRow = true
        Me.GridView1.OptionsView.ShowGroupPanel = false
        '
        'cmbMoneda
        '
        Me.cmbMoneda.Location = New System.Drawing.Point(231, 93)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbMoneda.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbMoneda.Properties.NullText = ""
        Me.cmbMoneda.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.cmbMoneda.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cmbMoneda.Properties.View = Me.GridView5
        Me.cmbMoneda.Size = New System.Drawing.Size(150, 20)
        Me.cmbMoneda.TabIndex = 6
        '
        'GridView5
        '
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.GridView5.OptionsView.ShowAutoFilterRow = true
        Me.GridView5.OptionsView.ShowGroupPanel = false
        '
        'tstOpecionesEnc
        '
        Me.tstOpecionesEnc.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGrabarEnc, Me.btnClose})
        Me.tstOpecionesEnc.Location = New System.Drawing.Point(0, 0)
        Me.tstOpecionesEnc.Name = "tstOpecionesEnc"
        Me.tstOpecionesEnc.Size = New System.Drawing.Size(1284, 25)
        Me.tstOpecionesEnc.TabIndex = 9
        Me.tstOpecionesEnc.Text = "ToolStrip1"
        '
        'btnGrabarEnc
        '
        Me.btnGrabarEnc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGrabarEnc.Image = Global.WMSOnePlan_Client.My.Resources.Resources.save_large
        Me.btnGrabarEnc.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGrabarEnc.Name = "btnGrabarEnc"
        Me.btnGrabarEnc.Size = New System.Drawing.Size(23, 22)
        Me.btnGrabarEnc.Text = "Nuevo"
        '
        'btnClose
        '
        Me.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnClose.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Closed
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(23, 22)
        Me.btnClose.Text = "Cerrar"
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(387, 70)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl15.TabIndex = 27
        Me.LabelControl15.Text = "Clima:"
        '
        'cmbClima
        '
        Me.cmbClima.EditValue = "SECO"
        Me.cmbClima.Location = New System.Drawing.Point(468, 67)
        Me.cmbClima.Name = "cmbClima"
        Me.cmbClima.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbClima.Properties.Items.AddRange(New Object() {"SECO", "CONGELADO", "REFRIGERADO"})
        Me.cmbClima.Size = New System.Drawing.Size(125, 20)
        Me.cmbClima.TabIndex = 3
        '
        'dxError
        '
        Me.dxError.ContainerControl = Me
        '
        'cmbUsuario
        '
        Me.cmbUsuario.Location = New System.Drawing.Point(468, 93)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbUsuario.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbUsuario.Properties.NullText = ""
        Me.cmbUsuario.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.cmbUsuario.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cmbUsuario.Properties.View = Me.GridView2
        Me.cmbUsuario.Size = New System.Drawing.Size(353, 20)
        Me.cmbUsuario.TabIndex = 7
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(387, 96)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl9.TabIndex = 29
        Me.LabelControl9.Text = "Autorizador por:"
        '
        'lblDiasFechas
        '
        Me.lblDiasFechas.Location = New System.Drawing.Point(12, 22)
        Me.lblDiasFechas.Name = "lblDiasFechas"
        Me.lblDiasFechas.Size = New System.Drawing.Size(64, 13)
        Me.lblDiasFechas.TabIndex = 30
        Me.lblDiasFechas.Text = "lblDiasFechas"
        '
        'FrmIngresoAcuerdoComercial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 672)
        Me.Controls.Add(Me.lblDiasFechas)
        Me.Controls.Add(Me.cmbMoneda)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.cmbUsuario)
        Me.Controls.Add(Me.cmbClima)
        Me.Controls.Add(Me.LabelControl15)
        Me.Controls.Add(Me.tstOpecionesEnc)
        Me.Controls.Add(Me.grupDetalle)
        Me.Controls.Add(Me.cmbRegimen)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.menComentarioEnc)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.dtFechaFinal)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.dtFechaIncio)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "FrmIngresoAcuerdoComercial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso Acuerdo Comercial"
        CType(Me.txtNombre.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtFechaIncio.Properties.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtFechaIncio.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtFechaFinal.Properties.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dtFechaFinal.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.menComentarioEnc.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbRegimen.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.grupDetalle,System.ComponentModel.ISupportInitialize).EndInit
        Me.grupDetalle.ResumeLayout(false)
        Me.grupDetalle.PerformLayout
        CType(Me.cmbMedida.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbTipoMedida.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.menComentarioDet.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.tstOpcionesDet.ResumeLayout(false)
        Me.tstOpcionesDet.PerformLayout
        CType(Me.GridDet,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridViewDet,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemCheckEdit1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtTransaccion.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.spinLimite.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbFrecuencia.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.spinPrecioUn.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbTipoCobro.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbMoneda.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView5,System.ComponentModel.ISupportInitialize).EndInit
        Me.tstOpecionesEnc.ResumeLayout(false)
        Me.tstOpecionesEnc.PerformLayout
        CType(Me.cmbClima.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dxError,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbUsuario.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView2,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtFechaIncio As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtFechaFinal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblEstado As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents menComentarioEnc As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbRegimen As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents grupDetalle As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmbFrecuencia As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents spinPrecioUn As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbTipoCobro As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTransaccion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents spinLimite As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents GridDet As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents tstOpcionesDet As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNewDet As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUpdateDet As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDeleteDet As System.Windows.Forms.ToolStripButton
    Friend WithEvents tstOpecionesEnc As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGrabarEnc As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbClima As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents colSERIAL_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTYPE_CHARGE_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUNIT_PRICE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBILLING_FRECUENCY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLIMIT_TO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colU_MEASURE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTX_SOURCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents menComentarioDet As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents btnGrabarDet As System.Windows.Forms.ToolStripButton
    Friend WithEvents colDESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOMMENTS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents dxError As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents cmbMoneda As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbUsuario As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbTipoMedida As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbMedida As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents colTYPE_MEASURE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblDiasFechas As DevExpress.XtraEditors.LabelControl
    Friend WithEvents colPARAM_CAPTION As DevExpress.XtraGrid.Columns.GridColumn
End Class
