<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCertificado
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
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GridCertificate = New DevExpress.XtraGrid.GridControl()
        Me.GridViewCertificate = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCERTIFICATE_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENT_OWHEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCERTIFICATE_STATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVALID_TO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENT_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHAS_BOND = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOMPANY_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAMOUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBOND_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCREATION_DATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnUpdate = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnExporExel = New System.Windows.Forms.ToolStripButton()
        Me.btnProrroga = New System.Windows.Forms.ToolStripButton()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.colCURRENCY = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GridCertificate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewCertificate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.GridCertificate)
        Me.PanelControl1.Controls.Add(Me.ToolStrip1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1053, 487)
        Me.PanelControl1.TabIndex = 0
        '
        'GridCertificate
        '
        Me.GridCertificate.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridCertificate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridCertificate.Location = New System.Drawing.Point(2, 24)
        Me.GridCertificate.MainView = Me.GridViewCertificate
        Me.GridCertificate.Name = "GridCertificate"
        Me.GridCertificate.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridCertificate.Size = New System.Drawing.Size(1049, 461)
        Me.GridCertificate.TabIndex = 3
        Me.GridCertificate.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewCertificate})
        '
        'GridViewCertificate
        '
        Me.GridViewCertificate.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCERTIFICATE_ID, Me.colCLIENT_OWHEN, Me.colNAME, Me.colCERTIFICATE_STATUS, Me.colVALID_TO, Me.colCLIENT_NAME, Me.colHAS_BOND, Me.colCOMPANY_NAME, Me.colBOND_ID, Me.colCURRENCY, Me.colAMOUNT, Me.colCREATION_DATE})
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        StyleFormatCondition1.Appearance.Options.UseBackColor = True
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition1.Value1 = CType(1, Short)
        Me.GridViewCertificate.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1})
        Me.GridViewCertificate.GridControl = Me.GridCertificate
        Me.GridViewCertificate.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "HAS_BOND", Me.colHAS_BOND, "")})
        Me.GridViewCertificate.Name = "GridViewCertificate"
        Me.GridViewCertificate.OptionsBehavior.Editable = False
        Me.GridViewCertificate.OptionsView.ShowAutoFilterRow = True
        Me.GridViewCertificate.OptionsView.ShowFooter = True
        '
        'colCERTIFICATE_ID
        '
        Me.colCERTIFICATE_ID.Caption = "Codigo"
        Me.colCERTIFICATE_ID.FieldName = "CERTIFICATE_ID"
        Me.colCERTIFICATE_ID.Name = "colCERTIFICATE_ID"
        Me.colCERTIFICATE_ID.OptionsColumn.AllowEdit = False
        Me.colCERTIFICATE_ID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CERTIFICATE_ID", "Cantidad = {0}")})
        '
        'colCLIENT_OWHEN
        '
        Me.colCLIENT_OWHEN.Caption = "Inspección"
        Me.colCLIENT_OWHEN.FieldName = "CLIENT_OWHEN"
        Me.colCLIENT_OWHEN.Name = "colCLIENT_OWHEN"
        Me.colCLIENT_OWHEN.OptionsColumn.AllowEdit = False
        Me.colCLIENT_OWHEN.Visible = True
        Me.colCLIENT_OWHEN.VisibleIndex = 0
        '
        'colNAME
        '
        Me.colNAME.Caption = "Bodega"
        Me.colNAME.FieldName = "NAME"
        Me.colNAME.Name = "colNAME"
        Me.colNAME.OptionsColumn.AllowEdit = False
        Me.colNAME.Visible = True
        Me.colNAME.VisibleIndex = 1
        '
        'colCERTIFICATE_STATUS
        '
        Me.colCERTIFICATE_STATUS.Caption = "Estado"
        Me.colCERTIFICATE_STATUS.FieldName = "CERTIFICATE_STATUS"
        Me.colCERTIFICATE_STATUS.Name = "colCERTIFICATE_STATUS"
        Me.colCERTIFICATE_STATUS.OptionsColumn.AllowEdit = False
        Me.colCERTIFICATE_STATUS.Visible = True
        Me.colCERTIFICATE_STATUS.VisibleIndex = 2
        '
        'colVALID_TO
        '
        Me.colVALID_TO.Caption = "Vencimiento"
        Me.colVALID_TO.FieldName = "VALID_TO"
        Me.colVALID_TO.Name = "colVALID_TO"
        Me.colVALID_TO.OptionsColumn.AllowEdit = False
        Me.colVALID_TO.Visible = True
        Me.colVALID_TO.VisibleIndex = 4
        '
        'colCLIENT_NAME
        '
        Me.colCLIENT_NAME.Caption = "Cliente"
        Me.colCLIENT_NAME.FieldName = "CLIENT_NAME"
        Me.colCLIENT_NAME.Name = "colCLIENT_NAME"
        Me.colCLIENT_NAME.OptionsColumn.AllowEdit = False
        Me.colCLIENT_NAME.Visible = True
        Me.colCLIENT_NAME.VisibleIndex = 5
        '
        'colHAS_BOND
        '
        Me.colHAS_BOND.Caption = "Bono"
        Me.colHAS_BOND.FieldName = "HAS_BOND"
        Me.colHAS_BOND.Name = "colHAS_BOND"
        Me.colHAS_BOND.OptionsColumn.AllowEdit = False
        Me.colHAS_BOND.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "HAS_BOND", "Total = {0}")})
        Me.colHAS_BOND.Visible = True
        Me.colHAS_BOND.VisibleIndex = 6
        '
        'colCOMPANY_NAME
        '
        Me.colCOMPANY_NAME.Caption = "Compañia del Bono"
        Me.colCOMPANY_NAME.FieldName = "COMPANY_NAME"
        Me.colCOMPANY_NAME.Name = "colCOMPANY_NAME"
        Me.colCOMPANY_NAME.OptionsColumn.AllowEdit = False
        Me.colCOMPANY_NAME.Visible = True
        Me.colCOMPANY_NAME.VisibleIndex = 8
        '
        'colAMOUNT
        '
        Me.colAMOUNT.Caption = "Monto del Bono"
        Me.colAMOUNT.DisplayFormat.FormatString = "#,#.00#"
        Me.colAMOUNT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAMOUNT.FieldName = "AMOUNT"
        Me.colAMOUNT.Name = "colAMOUNT"
        Me.colAMOUNT.OptionsColumn.AllowEdit = False
        Me.colAMOUNT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AMOUNT", "Total = {0}")})
        Me.colAMOUNT.Visible = True
        Me.colAMOUNT.VisibleIndex = 9
        '
        'colBOND_ID
        '
        Me.colBOND_ID.Caption = "Numero de Bono"
        Me.colBOND_ID.FieldName = "BOND_ID"
        Me.colBOND_ID.Name = "colBOND_ID"
        Me.colBOND_ID.Visible = True
        Me.colBOND_ID.VisibleIndex = 7
        '
        'colCREATION_DATE
        '
        Me.colCREATION_DATE.Caption = "Fecha de Creación"
        Me.colCREATION_DATE.DisplayFormat.FormatString = "MM/dd/yyyy  HH:mm"
        Me.colCREATION_DATE.FieldName = "CREATION_DATE"
        Me.colCREATION_DATE.Name = "colCREATION_DATE"
        Me.colCREATION_DATE.Visible = True
        Me.colCREATION_DATE.VisibleIndex = 3
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnUpdate, Me.btnDelete, Me.btnExporExel, Me.btnProrroga})
        Me.ToolStrip1.Location = New System.Drawing.Point(2, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1049, 22)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNew.Image = Global.WMSOnePlan_Client.My.Resources.Resources.SaveAsPlainText
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(23, 19)
        Me.btnNew.Text = "Nuevo"
        '
        'btnUpdate
        '
        Me.btnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUpdate.Image = Global.WMSOnePlan_Client.My.Resources.Resources.SaveAsSmall
        Me.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(23, 19)
        Me.btnUpdate.Text = "Editar"
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDelete.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Symbols_Delete_icon
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(23, 19)
        Me.btnDelete.Text = "Borrar"
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
        'btnProrroga
        '
        Me.btnProrroga.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnProrroga.Image = Global.WMSOnePlan_Client.My.Resources.Resources.clock_select_remain
        Me.btnProrroga.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnProrroga.Name = "btnProrroga"
        Me.btnProrroga.Size = New System.Drawing.Size(23, 19)
        Me.btnProrroga.Text = "Prorroga"
        '
        'colCURRENCY
        '
        Me.colCURRENCY.Caption = "Tipo de Moneda"
        Me.colCURRENCY.FieldName = "CURRENCY"
        Me.colCURRENCY.Name = "colCURRENCY"
        Me.colCURRENCY.Visible = True
        Me.colCURRENCY.VisibleIndex = 10
        '
        'frmCertificado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1053, 487)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "frmCertificado"
        Me.Text = "Certificados"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GridCertificate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewCertificate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExporExel As System.Windows.Forms.ToolStripButton
    Friend WithEvents GridCertificate As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewCertificate As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colCERTIFICATE_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENT_OWHEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCERTIFICATE_STATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVALID_TO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENT_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHAS_BOND As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOMPANY_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAMOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBOND_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents colCREATION_DATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnProrroga As System.Windows.Forms.ToolStripButton
    Friend WithEvents colCURRENCY As DevExpress.XtraGrid.Columns.GridColumn
End Class
