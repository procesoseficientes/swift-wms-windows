<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInventoryFile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInventoryFile))
        Me.colTERMS_OF_TRADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridViewInvSku = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colISMATERIAL_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colISMATERIAL_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colISBARCODE_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colISALTERNATE_BARCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmbClientes = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GrpDetail = New System.Windows.Forms.GroupBox()
        Me.PbrStatus = New System.Windows.Forms.ProgressBar()
        Me.BtnSend = New System.Windows.Forms.Button()
        Me.LblRows = New System.Windows.Forms.Label()
        Me.DgvLoadInventory = New System.Windows.Forms.DataGridView()
        Me.GrpHeader = New System.Windows.Forms.GroupBox()
        Me.CmbUbicacion = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GrpResp = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PbxResult = New System.Windows.Forms.PictureBox()
        Me.CmbBodega = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.BtnUpload = New System.Windows.Forms.Button()
        Me.CmbUbicacion1 = New System.Windows.Forms.ComboBox()
        Me.CmbBodega1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.GridViewInvSku, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbClientes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDetail.SuspendLayout()
        CType(Me.DgvLoadInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpHeader.SuspendLayout()
        CType(Me.CmbUbicacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpResp.SuspendLayout()
        CType(Me.PbxResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbBodega.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colTERMS_OF_TRADE
        '
        Me.colTERMS_OF_TRADE.Caption = "Precio"
        Me.colTERMS_OF_TRADE.FieldName = "TERMS_OF_TRADE"
        Me.colTERMS_OF_TRADE.Name = "colTERMS_OF_TRADE"
        Me.colTERMS_OF_TRADE.OptionsColumn.AllowEdit = False
        '
        'GridViewInvSku
        '
        Me.GridViewInvSku.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colISMATERIAL_ID, Me.colISMATERIAL_NAME, Me.colISBARCODE_ID, Me.colISALTERNATE_BARCODE})
        Me.GridViewInvSku.Name = "GridViewInvSku"
        Me.GridViewInvSku.OptionsView.ShowAutoFilterRow = True
        Me.GridViewInvSku.OptionsView.ShowFooter = True
        Me.GridViewInvSku.OptionsView.ShowGroupPanel = False
        '
        'colISMATERIAL_ID
        '
        Me.colISMATERIAL_ID.Caption = "Código Producto"
        Me.colISMATERIAL_ID.FieldName = "MATERIAL_ID"
        Me.colISMATERIAL_ID.Name = "colISMATERIAL_ID"
        Me.colISMATERIAL_ID.OptionsColumn.AllowEdit = False
        Me.colISMATERIAL_ID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.colISMATERIAL_ID.Visible = True
        Me.colISMATERIAL_ID.VisibleIndex = 0
        '
        'colISMATERIAL_NAME
        '
        Me.colISMATERIAL_NAME.Caption = "Descripción"
        Me.colISMATERIAL_NAME.FieldName = "MATERIAL_NAME"
        Me.colISMATERIAL_NAME.Name = "colISMATERIAL_NAME"
        Me.colISMATERIAL_NAME.OptionsColumn.AllowEdit = False
        Me.colISMATERIAL_NAME.Visible = True
        Me.colISMATERIAL_NAME.VisibleIndex = 1
        '
        'colISBARCODE_ID
        '
        Me.colISBARCODE_ID.Caption = "Código de Barras"
        Me.colISBARCODE_ID.FieldName = "BARCODE_ID"
        Me.colISBARCODE_ID.Name = "colISBARCODE_ID"
        Me.colISBARCODE_ID.OptionsColumn.AllowEdit = False
        Me.colISBARCODE_ID.Visible = True
        Me.colISBARCODE_ID.VisibleIndex = 2
        '
        'colISALTERNATE_BARCODE
        '
        Me.colISALTERNATE_BARCODE.Caption = "Código de Barras Alterno"
        Me.colISALTERNATE_BARCODE.FieldName = "ALTERNATE_BARCODE"
        Me.colISALTERNATE_BARCODE.Name = "colISALTERNATE_BARCODE"
        Me.colISALTERNATE_BARCODE.OptionsColumn.AllowEdit = False
        Me.colISALTERNATE_BARCODE.Visible = True
        Me.colISALTERNATE_BARCODE.VisibleIndex = 3
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Código Producto"
        Me.GridColumn1.FieldName = "MATERIAL_ID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Descripción"
        Me.GridColumn2.FieldName = "MATERIAL_NAME"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Código de Barras"
        Me.GridColumn3.FieldName = "BARCODE_ID"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Código de Barras Alterno"
        Me.GridColumn4.FieldName = "ALTERNATE_BARCODE"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8})
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsView.ShowAutoFilterRow = True
        Me.GridView3.OptionsView.ShowFooter = True
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Código Producto"
        Me.GridColumn5.FieldName = "MATERIAL_ID"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Descripción"
        Me.GridColumn6.FieldName = "MATERIAL_NAME"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Código de Barras"
        Me.GridColumn7.FieldName = "BARCODE_ID"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Código de Barras Alterno"
        Me.GridColumn8.FieldName = "ALTERNATE_BARCODE"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 3
        '
        'cmbClientes
        '
        Me.cmbClientes.Location = New System.Drawing.Point(634, 330)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbClientes.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbClientes.Properties.NullText = ""
        Me.cmbClientes.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.cmbClientes.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cmbClientes.Properties.View = Me.GridView2
        Me.cmbClientes.Size = New System.Drawing.Size(538, 20)
        Me.cmbClientes.TabIndex = 7
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GrpDetail
        '
        Me.GrpDetail.Controls.Add(Me.PbrStatus)
        Me.GrpDetail.Controls.Add(Me.BtnSend)
        Me.GrpDetail.Controls.Add(Me.LblRows)
        Me.GrpDetail.Controls.Add(Me.DgvLoadInventory)
        Me.GrpDetail.Location = New System.Drawing.Point(18, 129)
        Me.GrpDetail.Name = "GrpDetail"
        Me.GrpDetail.Size = New System.Drawing.Size(670, 320)
        Me.GrpDetail.TabIndex = 9
        Me.GrpDetail.TabStop = False
        Me.GrpDetail.Text = "Detalle"
        '
        'PbrStatus
        '
        Me.PbrStatus.Location = New System.Drawing.Point(240, 283)
        Me.PbrStatus.Name = "PbrStatus"
        Me.PbrStatus.Size = New System.Drawing.Size(300, 30)
        Me.PbrStatus.TabIndex = 21
        '
        'BtnSend
        '
        Me.BtnSend.Enabled = False
        Me.BtnSend.Location = New System.Drawing.Point(555, 283)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(90, 30)
        Me.BtnSend.TabIndex = 20
        Me.BtnSend.Text = "Enviar"
        Me.BtnSend.UseVisualStyleBackColor = True
        '
        'LblRows
        '
        Me.LblRows.AutoSize = True
        Me.LblRows.Location = New System.Drawing.Point(6, 292)
        Me.LblRows.Name = "LblRows"
        Me.LblRows.Size = New System.Drawing.Size(16, 13)
        Me.LblRows.TabIndex = 1
        Me.LblRows.Text = "..."
        '
        'DgvLoadInventory
        '
        Me.DgvLoadInventory.AllowUserToAddRows = False
        Me.DgvLoadInventory.AllowUserToDeleteRows = False
        Me.DgvLoadInventory.AllowUserToResizeColumns = False
        Me.DgvLoadInventory.AllowUserToResizeRows = False
        Me.DgvLoadInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvLoadInventory.Location = New System.Drawing.Point(6, 19)
        Me.DgvLoadInventory.Name = "DgvLoadInventory"
        Me.DgvLoadInventory.ReadOnly = True
        Me.DgvLoadInventory.Size = New System.Drawing.Size(660, 250)
        Me.DgvLoadInventory.TabIndex = 0
        '
        'GrpHeader
        '
        Me.GrpHeader.Controls.Add(Me.CmbUbicacion)
        Me.GrpHeader.Controls.Add(Me.GrpResp)
        Me.GrpHeader.Controls.Add(Me.CmbBodega)
        Me.GrpHeader.Controls.Add(Me.Label10)
        Me.GrpHeader.Controls.Add(Me.Label9)
        Me.GrpHeader.Controls.Add(Me.LblCliente)
        Me.GrpHeader.Controls.Add(Me.BtnUpload)
        Me.GrpHeader.Location = New System.Drawing.Point(18, 12)
        Me.GrpHeader.Name = "GrpHeader"
        Me.GrpHeader.Size = New System.Drawing.Size(760, 100)
        Me.GrpHeader.TabIndex = 8
        Me.GrpHeader.TabStop = False
        Me.GrpHeader.Text = "Datos Generales"
        '
        'CmbUbicacion
        '
        Me.CmbUbicacion.Location = New System.Drawing.Point(60, 64)
        Me.CmbUbicacion.Name = "CmbUbicacion"
        Me.CmbUbicacion.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.CmbUbicacion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbUbicacion.Properties.NullText = ""
        Me.CmbUbicacion.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.CmbUbicacion.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.CmbUbicacion.Properties.View = Me.GridView5
        Me.CmbUbicacion.Size = New System.Drawing.Size(538, 20)
        Me.CmbUbicacion.TabIndex = 11
        '
        'GridView5
        '
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsView.ShowAutoFilterRow = True
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'GrpResp
        '
        Me.GrpResp.Controls.Add(Me.Label11)
        Me.GrpResp.Controls.Add(Me.PbxResult)
        Me.GrpResp.Location = New System.Drawing.Point(604, 16)
        Me.GrpResp.Name = "GrpResp"
        Me.GrpResp.Size = New System.Drawing.Size(150, 80)
        Me.GrpResp.TabIndex = 9
        Me.GrpResp.TabStop = False
        Me.GrpResp.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(34, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Carga Completa"
        '
        'PbxResult
        '
        Me.PbxResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PbxResult.InitialImage = CType(resources.GetObject("PbxResult.InitialImage"), System.Drawing.Image)
        Me.PbxResult.Location = New System.Drawing.Point(37, 11)
        Me.PbxResult.Name = "PbxResult"
        Me.PbxResult.Size = New System.Drawing.Size(80, 40)
        Me.PbxResult.TabIndex = 13
        Me.PbxResult.TabStop = False
        '
        'CmbBodega
        '
        Me.CmbBodega.Location = New System.Drawing.Point(59, 37)
        Me.CmbBodega.Name = "CmbBodega"
        Me.CmbBodega.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.CmbBodega.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbBodega.Properties.NullText = ""
        Me.CmbBodega.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.CmbBodega.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.CmbBodega.Properties.View = Me.GridView4
        Me.CmbBodega.Size = New System.Drawing.Size(538, 20)
        Me.CmbBodega.TabIndex = 10
        '
        'GridView4
        '
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowAutoFilterRow = True
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Ubicacion:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Bodega:"
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.Location = New System.Drawing.Point(6, 16)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(42, 13)
        Me.LblCliente.TabIndex = 3
        Me.LblCliente.Text = "Cliente:"
        '
        'BtnUpload
        '
        Me.BtnUpload.Location = New System.Drawing.Point(538, 69)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.Size = New System.Drawing.Size(60, 25)
        Me.BtnUpload.TabIndex = 0
        Me.BtnUpload.Text = "Archivo..."
        Me.BtnUpload.UseVisualStyleBackColor = True
        Me.BtnUpload.Visible = False
        '
        'CmbUbicacion1
        '
        Me.CmbUbicacion1.FormattingEnabled = True
        Me.CmbUbicacion1.Location = New System.Drawing.Point(706, 172)
        Me.CmbUbicacion1.Name = "CmbUbicacion1"
        Me.CmbUbicacion1.Size = New System.Drawing.Size(266, 21)
        Me.CmbUbicacion1.TabIndex = 7
        '
        'CmbBodega1
        '
        Me.CmbBodega1.FormattingEnabled = True
        Me.CmbBodega1.Location = New System.Drawing.Point(706, 145)
        Me.CmbBodega1.Name = "CmbBodega1"
        Me.CmbBodega1.Size = New System.Drawing.Size(266, 21)
        Me.CmbBodega1.TabIndex = 5
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(706, 118)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(266, 21)
        Me.ComboBox1.TabIndex = 4
        '
        'FrmInventoryFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 548)
        Me.Controls.Add(Me.CmbUbicacion1)
        Me.Controls.Add(Me.GrpDetail)
        Me.Controls.Add(Me.GrpHeader)
        Me.Controls.Add(Me.CmbBodega1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.cmbClientes)
        Me.Name = "FrmInventoryFile"
        Me.Text = "InventarioExterrno"
        CType(Me.GridViewInvSku, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbClientes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDetail.ResumeLayout(False)
        Me.GrpDetail.PerformLayout()
        CType(Me.DgvLoadInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpHeader.ResumeLayout(False)
        Me.GrpHeader.PerformLayout()
        CType(Me.CmbUbicacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpResp.ResumeLayout(False)
        Me.GrpResp.PerformLayout()
        CType(Me.PbxResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbBodega.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents colTERMS_OF_TRADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridViewInvSku As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colISMATERIAL_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colISMATERIAL_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colISBARCODE_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colISALTERNATE_BARCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbClientes As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GrpDetail As System.Windows.Forms.GroupBox
    Friend WithEvents PbrStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents BtnSend As System.Windows.Forms.Button
    Friend WithEvents LblRows As System.Windows.Forms.Label
    Friend WithEvents DgvLoadInventory As System.Windows.Forms.DataGridView
    Friend WithEvents GrpHeader As System.Windows.Forms.GroupBox
    Friend WithEvents GrpResp As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PbxResult As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbUbicacion1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbBodega1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents BtnUpload As System.Windows.Forms.Button
    Friend WithEvents CmbBodega As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CmbUbicacion As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
