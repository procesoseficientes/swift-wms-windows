<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAcuerdoComercial
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
        Me.GridViewDet = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridAcuerdoComercial = New DevExpress.XtraGrid.GridControl()
        Me.GridViewAcuerdoComercial = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colACUERDO_COMERCIAL_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colACUERDO_COMERCIAL_NOMBRE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colREGIMEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colWAREHOUSE_WEATHER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVALID_FROM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVALID_TO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEXPIRES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCURRENCY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAUTHORIZER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOMMENTS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.tstOpciones = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnUpdate = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnPorCliente = New System.Windows.Forms.ToolStripButton()
        Me.btnExporExel = New System.Windows.Forms.ToolStripButton()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.DsReportTariff = New WMSOnePlan_Client.dsReportTariff()
        Me.RepAcuerdoComercialBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.GridViewDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridAcuerdoComercial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAcuerdoComercial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstOpciones.SuspendLayout()
        CType(Me.DsReportTariff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepAcuerdoComercialBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridViewDet
        '
        Me.GridViewDet.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDESCRIPTION})
        Me.GridViewDet.GridControl = Me.GridAcuerdoComercial
        Me.GridViewDet.Name = "GridViewDet"
        '
        'colDESCRIPTION
        '
        Me.colDESCRIPTION.Caption = "Descripcion"
        Me.colDESCRIPTION.FieldName = "DESCRIPTION"
        Me.colDESCRIPTION.Name = "colDESCRIPTION"
        Me.colDESCRIPTION.Visible = True
        Me.colDESCRIPTION.VisibleIndex = 0
        '
        'GridAcuerdoComercial
        '
        Me.GridAcuerdoComercial.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridAcuerdoComercial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridAcuerdoComercial.Location = New System.Drawing.Point(0, 22)
        Me.GridAcuerdoComercial.MainView = Me.GridViewAcuerdoComercial
        Me.GridAcuerdoComercial.Name = "GridAcuerdoComercial"
        Me.GridAcuerdoComercial.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridAcuerdoComercial.Size = New System.Drawing.Size(1033, 488)
        Me.GridAcuerdoComercial.TabIndex = 7
        Me.GridAcuerdoComercial.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewAcuerdoComercial, Me.GridViewDet})
        '
        'GridViewAcuerdoComercial
        '
        Me.GridViewAcuerdoComercial.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colACUERDO_COMERCIAL_ID, Me.colACUERDO_COMERCIAL_NOMBRE, Me.colREGIMEN, Me.colWAREHOUSE_WEATHER, Me.colVALID_FROM, Me.colVALID_TO, Me.colEXPIRES, Me.colCURRENCY, Me.colSTATUS, Me.colAUTHORIZER, Me.colCOMMENTS})
        Me.GridViewAcuerdoComercial.GridControl = Me.GridAcuerdoComercial
        Me.GridViewAcuerdoComercial.Name = "GridViewAcuerdoComercial"
        Me.GridViewAcuerdoComercial.OptionsBehavior.Editable = False
        Me.GridViewAcuerdoComercial.OptionsView.ShowAutoFilterRow = True
        Me.GridViewAcuerdoComercial.OptionsView.ShowFooter = True
        '
        'colACUERDO_COMERCIAL_ID
        '
        Me.colACUERDO_COMERCIAL_ID.Caption = "Codigo"
        Me.colACUERDO_COMERCIAL_ID.FieldName = "ACUERDO_COMERCIAL_ID"
        Me.colACUERDO_COMERCIAL_ID.Name = "colACUERDO_COMERCIAL_ID"
        '
        'colACUERDO_COMERCIAL_NOMBRE
        '
        Me.colACUERDO_COMERCIAL_NOMBRE.Caption = "Nombre"
        Me.colACUERDO_COMERCIAL_NOMBRE.FieldName = "ACUERDO_COMERCIAL_NOMBRE"
        Me.colACUERDO_COMERCIAL_NOMBRE.Name = "colACUERDO_COMERCIAL_NOMBRE"
        Me.colACUERDO_COMERCIAL_NOMBRE.Visible = True
        Me.colACUERDO_COMERCIAL_NOMBRE.VisibleIndex = 0
        '
        'colREGIMEN
        '
        Me.colREGIMEN.Caption = "Regimen"
        Me.colREGIMEN.FieldName = "REGIMEN"
        Me.colREGIMEN.Name = "colREGIMEN"
        Me.colREGIMEN.Visible = True
        Me.colREGIMEN.VisibleIndex = 1
        '
        'colWAREHOUSE_WEATHER
        '
        Me.colWAREHOUSE_WEATHER.Caption = "Clima"
        Me.colWAREHOUSE_WEATHER.FieldName = "WAREHOUSE_WEATHER"
        Me.colWAREHOUSE_WEATHER.Name = "colWAREHOUSE_WEATHER"
        Me.colWAREHOUSE_WEATHER.Visible = True
        Me.colWAREHOUSE_WEATHER.VisibleIndex = 2
        '
        'colVALID_FROM
        '
        Me.colVALID_FROM.Caption = "Fecha de Inicio"
        Me.colVALID_FROM.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.colVALID_FROM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colVALID_FROM.FieldName = "VALID_FROM"
        Me.colVALID_FROM.Name = "colVALID_FROM"
        Me.colVALID_FROM.Visible = True
        Me.colVALID_FROM.VisibleIndex = 3
        '
        'colVALID_TO
        '
        Me.colVALID_TO.Caption = "Fecha Final"
        Me.colVALID_TO.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.colVALID_TO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colVALID_TO.FieldName = "VALID_TO"
        Me.colVALID_TO.Name = "colVALID_TO"
        Me.colVALID_TO.Visible = True
        Me.colVALID_TO.VisibleIndex = 4
        '
        'colEXPIRES
        '
        Me.colEXPIRES.Caption = "Ha Expirado"
        Me.colEXPIRES.FieldName = "EXPIRES"
        Me.colEXPIRES.Name = "colEXPIRES"
        Me.colEXPIRES.Visible = True
        Me.colEXPIRES.VisibleIndex = 5
        '
        'colCURRENCY
        '
        Me.colCURRENCY.Caption = "Moneda"
        Me.colCURRENCY.FieldName = "CURRENCY"
        Me.colCURRENCY.Name = "colCURRENCY"
        Me.colCURRENCY.Visible = True
        Me.colCURRENCY.VisibleIndex = 6
        '
        'colSTATUS
        '
        Me.colSTATUS.Caption = "Estado"
        Me.colSTATUS.FieldName = "STATUS"
        Me.colSTATUS.Name = "colSTATUS"
        Me.colSTATUS.Visible = True
        Me.colSTATUS.VisibleIndex = 7
        '
        'colAUTHORIZER
        '
        Me.colAUTHORIZER.Caption = "Autorizado por"
        Me.colAUTHORIZER.FieldName = "AUTHORIZER"
        Me.colAUTHORIZER.Name = "colAUTHORIZER"
        Me.colAUTHORIZER.Visible = True
        Me.colAUTHORIZER.VisibleIndex = 8
        '
        'colCOMMENTS
        '
        Me.colCOMMENTS.Caption = "Comentario"
        Me.colCOMMENTS.FieldName = "COMMENTS"
        Me.colCOMMENTS.Name = "colCOMMENTS"
        Me.colCOMMENTS.Visible = True
        Me.colCOMMENTS.VisibleIndex = 9
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'tstOpciones
        '
        Me.tstOpciones.AutoSize = False
        Me.tstOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnUpdate, Me.btnDelete, Me.btnPorCliente, Me.btnExporExel})
        Me.tstOpciones.Location = New System.Drawing.Point(0, 0)
        Me.tstOpciones.Name = "tstOpciones"
        Me.tstOpciones.Size = New System.Drawing.Size(1033, 22)
        Me.tstOpciones.TabIndex = 6
        Me.tstOpciones.Text = "ToolStrip1"
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
        'btnPorCliente
        '
        Me.btnPorCliente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPorCliente.Image = Global.WMSOnePlan_Client.My.Resources.Resources.arrow_in
        Me.btnPorCliente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPorCliente.Name = "btnPorCliente"
        Me.btnPorCliente.Size = New System.Drawing.Size(23, 19)
        Me.btnPorCliente.Text = "Acuerdos Comerciales por Cliente"
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
        'DsReportTariff
        '
        Me.DsReportTariff.DataSetName = "dsReportTariff"
        Me.DsReportTariff.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RepAcuerdoComercialBindingSource
        '
        Me.RepAcuerdoComercialBindingSource.DataMember = "repAcuerdoComercial"
        Me.RepAcuerdoComercialBindingSource.DataSource = Me.DsReportTariff
        '
        'FrmAcuerdoComercial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 510)
        Me.Controls.Add(Me.GridAcuerdoComercial)
        Me.Controls.Add(Me.tstOpciones)
        Me.Name = "FrmAcuerdoComercial"
        Me.Text = "Acuerdo Comercial"
        CType(Me.GridViewDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridAcuerdoComercial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAcuerdoComercial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstOpciones.ResumeLayout(False)
        Me.tstOpciones.PerformLayout()
        CType(Me.DsReportTariff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepAcuerdoComercialBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridAcuerdoComercial As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAcuerdoComercial As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents tstOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExporExel As System.Windows.Forms.ToolStripButton
    Friend WithEvents colACUERDO_COMERCIAL_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colACUERDO_COMERCIAL_NOMBRE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colREGIMEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colWAREHOUSE_WEATHER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVALID_FROM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVALID_TO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEXPIRES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCURRENCY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOMMENTS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnPorCliente As System.Windows.Forms.ToolStripButton
    Friend WithEvents colAUTHORIZER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridViewDet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colDESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DsReportTariff As WMSOnePlan_Client.dsReportTariff
    Friend WithEvents RepAcuerdoComercialBindingSource As System.Windows.Forms.BindingSource
End Class
