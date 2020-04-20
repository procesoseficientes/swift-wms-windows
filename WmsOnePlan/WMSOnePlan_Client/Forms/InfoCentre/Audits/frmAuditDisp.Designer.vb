<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuditDisp
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
        Me.components = New System.ComponentModel.Container()
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAuditDisp))
        Me.GridColumnDiff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnPoliza = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSKU = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMaterialName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCounted = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPicked = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpdated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView8 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit2 = New DevExpress.XtraEditors.DateEdit()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DateEdit2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridColumnDiff
        '
        Me.GridColumnDiff.Caption = "Direfencia"
        Me.GridColumnDiff.FieldName = "AUDIT_DIFF"
        Me.GridColumnDiff.Name = "GridColumnDiff"
        Me.GridColumnDiff.OptionsColumn.ReadOnly = True
        Me.GridColumnDiff.Visible = True
        Me.GridColumnDiff.VisibleIndex = 6
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.Name = "GridView2"
        '
        'GridControl1
        '
        Me.GridControl1.DataMember = Nothing
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 54)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(973, 390)
        Me.GridControl1.TabIndex = 4
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.GridView7, Me.GridView8, Me.GridView4, Me.GridView5, Me.GridView3, Me.GridView6, Me.GridView2})
        '
        'GridView1
        '
        Me.GridView1.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView1.AppearancePrint.HeaderPanel.BackColor2 = System.Drawing.Color.Silver
        Me.GridView1.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GridView1.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GridView1.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GridView1.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnPoliza, Me.GridColumnNO, Me.GridColumnSKU, Me.GridColumnMaterialName, Me.GridColumnCounted, Me.GridColumnPicked, Me.GridColumnDiff, Me.GridColumnUser, Me.GridColumnLastUpdated})
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Green
        StyleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.Olive
        StyleFormatCondition1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        StyleFormatCondition1.Appearance.Options.UseBackColor = True
        StyleFormatCondition1.Column = Me.GridColumnDiff
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition1.Value1 = CType(0, Short)
        Me.GridView1.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsDetail.AllowOnlyOneMasterRowExpanded = True
        Me.GridView1.OptionsPrint.ExpandAllDetails = True
        Me.GridView1.OptionsPrint.PrintDetails = True
        Me.GridView1.OptionsPrint.PrintFilterInfo = True
        Me.GridView1.OptionsPrint.UsePrintStyles = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'GridColumnPoliza
        '
        Me.GridColumnPoliza.Caption = "Poliza"
        Me.GridColumnPoliza.FieldName = "CODIGO_POLIZA"
        Me.GridColumnPoliza.Name = "GridColumnPoliza"
        Me.GridColumnPoliza.OptionsColumn.ReadOnly = True
        Me.GridColumnPoliza.Visible = True
        Me.GridColumnPoliza.VisibleIndex = 0
        '
        'GridColumnNO
        '
        Me.GridColumnNO.Caption = "NumeroOrden"
        Me.GridColumnNO.FieldName = "NUMERO_ORDEN"
        Me.GridColumnNO.Name = "GridColumnNO"
        Me.GridColumnNO.OptionsColumn.ReadOnly = True
        Me.GridColumnNO.Visible = True
        Me.GridColumnNO.VisibleIndex = 1
        '
        'GridColumnSKU
        '
        Me.GridColumnSKU.Caption = "SKU"
        Me.GridColumnSKU.FieldName = "BARCODE_ID"
        Me.GridColumnSKU.Name = "GridColumnSKU"
        Me.GridColumnSKU.OptionsColumn.ReadOnly = True
        Me.GridColumnSKU.Visible = True
        Me.GridColumnSKU.VisibleIndex = 2
        '
        'GridColumnMaterialName
        '
        Me.GridColumnMaterialName.Caption = "Descripción"
        Me.GridColumnMaterialName.FieldName = "MATERIAL_NAME"
        Me.GridColumnMaterialName.Name = "GridColumnMaterialName"
        Me.GridColumnMaterialName.OptionsColumn.ReadOnly = True
        Me.GridColumnMaterialName.Visible = True
        Me.GridColumnMaterialName.VisibleIndex = 3
        '
        'GridColumnCounted
        '
        Me.GridColumnCounted.Caption = "Auditado"
        Me.GridColumnCounted.FieldName = "COUNTED"
        Me.GridColumnCounted.Name = "GridColumnCounted"
        Me.GridColumnCounted.OptionsColumn.ReadOnly = True
        Me.GridColumnCounted.Visible = True
        Me.GridColumnCounted.VisibleIndex = 4
        '
        'GridColumnPicked
        '
        Me.GridColumnPicked.Caption = "Picking"
        Me.GridColumnPicked.FieldName = "PICKED"
        Me.GridColumnPicked.Name = "GridColumnPicked"
        Me.GridColumnPicked.OptionsColumn.ReadOnly = True
        Me.GridColumnPicked.Visible = True
        Me.GridColumnPicked.VisibleIndex = 5
        '
        'GridColumnUser
        '
        Me.GridColumnUser.Caption = "Operador"
        Me.GridColumnUser.FieldName = "LAST_UPDATED_BY"
        Me.GridColumnUser.Name = "GridColumnUser"
        Me.GridColumnUser.Visible = True
        Me.GridColumnUser.VisibleIndex = 7
        '
        'GridColumnLastUpdated
        '
        Me.GridColumnLastUpdated.Caption = "FechaHora"
        Me.GridColumnLastUpdated.FieldName = "LAST_UPDATED"
        Me.GridColumnLastUpdated.Name = "GridColumnLastUpdated"
        Me.GridColumnLastUpdated.Visible = True
        Me.GridColumnLastUpdated.VisibleIndex = 8
        '
        'GridView7
        '
        Me.GridView7.GridControl = Me.GridControl1
        Me.GridView7.Name = "GridView7"
        '
        'GridView8
        '
        Me.GridView8.GridControl = Me.GridControl1
        Me.GridView8.Name = "GridView8"
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.GridControl1
        Me.GridView4.Name = "GridView4"
        '
        'GridView5
        '
        Me.GridView5.GridControl = Me.GridControl1
        Me.GridView5.Name = "GridView5"
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GridControl1
        Me.GridView3.Name = "GridView3"
        '
        'GridView6
        '
        Me.GridView6.GridControl = Me.GridControl1
        Me.GridView6.Name = "GridView6"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.DateEdit2)
        Me.PanelControl1.Controls.Add(Me.btnOK)
        Me.PanelControl1.Controls.Add(Me.DateEdit1)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(973, 54)
        Me.PanelControl1.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl2.Location = New System.Drawing.Point(165, 5)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(65, 22)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Fecha Final:"
        '
        'DateEdit2
        '
        Me.DateEdit2.EditValue = Nothing
        Me.DateEdit2.Location = New System.Drawing.Point(165, 28)
        Me.DateEdit2.Name = "DateEdit2"
        Me.DateEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Properties.EditFormat.FormatString = "yyyy-MM-dd"
        Me.DateEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit2.Properties.Mask.EditMask = ""
        Me.DateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DateEdit2.Size = New System.Drawing.Size(146, 20)
        Me.DateEdit2.TabIndex = 3
        '
        'btnOK
        '
        Me.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Image = Global.WMSOnePlan_Client.My.Resources.Resources.play
        Me.btnOK.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnOK.Location = New System.Drawing.Point(859, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(56, 50)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(13, 28)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.EditFormat.FormatString = "yyyy-MM-dd"
        Me.DateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit1.Properties.Mask.EditMask = ""
        Me.DateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DateEdit1.Size = New System.Drawing.Size(146, 20)
        Me.DateEdit1.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Location = New System.Drawing.Point(13, 5)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(65, 22)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Fecha Inicial:"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.Image = Global.WMSOnePlan_Client.My.Resources.Resources.print_large
        Me.SimpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SimpleButton1.Location = New System.Drawing.Point(915, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(56, 50)
        Me.SimpleButton1.TabIndex = 5
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        '
        '
        '
        Me.PrintableComponentLink1.ImageCollection.ImageStream = CType(resources.GetObject("PrintableComponentLink1.ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PageHeaderFooter = New DevExpress.XtraPrinting.PageHeaderFooter(New DevExpress.XtraPrinting.PageHeaderArea(New String() {"CEALSA", "AUDITORIA DE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DESPACHO ", "[Page # of Pages #]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[Date Printed] [Time Printed]"}, New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), DevExpress.XtraPrinting.BrickAlignment.Near), New DevExpress.XtraPrinting.PageFooterArea(New String() {"", "[Page # of Pages #]", ""}, New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), DevExpress.XtraPrinting.BrickAlignment.Near))
        Me.PrintableComponentLink1.PrintingSystem = Me.PrintingSystem1
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'frmAuditDisp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 444)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAuditDisp"
        Me.Text = "Auditoria de Despacho"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.DateEdit2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView8 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents GridColumnPoliza As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSKU As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMaterialName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCounted As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPicked As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDiff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUpdated As DevExpress.XtraGrid.Columns.GridColumn
End Class
