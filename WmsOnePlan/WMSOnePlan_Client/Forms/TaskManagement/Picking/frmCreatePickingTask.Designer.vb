<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreatePickingD
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
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton
        Me.lblMaterial = New DevExpress.XtraEditors.LabelControl
        Me.txtMaterialID = New DevExpress.XtraEditors.ButtonEdit
        Me.lblWarehouse = New DevExpress.XtraEditors.LabelControl
        Me.cmbWarehouse = New DevExpress.XtraEditors.ComboBoxEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.lblMaterialName = New DevExpress.XtraEditors.LabelControl
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.cmbLine = New DevExpress.XtraEditors.LookUpEdit
        Me.lblClientName = New DevExpress.XtraEditors.LabelControl
        Me.txtSAPClient = New DevExpress.XtraEditors.ButtonEdit
        Me.lblSAPClient = New DevExpress.XtraEditors.LabelControl
        Me.txtSAPDoc = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.txtQty = New DevExpress.XtraEditors.SpinEdit
        CType(Me.txtMaterialID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbWarehouse.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.cmbLine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSAPClient.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSAPDoc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(157, 333)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(158, 23)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        '
        'lblMaterial
        '
        Me.lblMaterial.Location = New System.Drawing.Point(16, 231)
        Me.lblMaterial.Name = "lblMaterial"
        Me.lblMaterial.Size = New System.Drawing.Size(43, 13)
        Me.lblMaterial.TabIndex = 1
        Me.lblMaterial.Text = "Producto"
        '
        'txtMaterialID
        '
        Me.txtMaterialID.EnterMoveNextControl = True
        Me.txtMaterialID.Location = New System.Drawing.Point(157, 224)
        Me.txtMaterialID.Name = "txtMaterialID"
        Me.txtMaterialID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.txtMaterialID.Size = New System.Drawing.Size(158, 20)
        Me.txtMaterialID.TabIndex = 4
        '
        'lblWarehouse
        '
        Me.lblWarehouse.Location = New System.Drawing.Point(16, 38)
        Me.lblWarehouse.Name = "lblWarehouse"
        Me.lblWarehouse.Size = New System.Drawing.Size(36, 13)
        Me.lblWarehouse.TabIndex = 6
        Me.lblWarehouse.Text = "Bodega"
        '
        'cmbWarehouse
        '
        Me.cmbWarehouse.EditValue = "PICKING"
        Me.cmbWarehouse.EnterMoveNextControl = True
        Me.cmbWarehouse.Location = New System.Drawing.Point(157, 35)
        Me.cmbWarehouse.Name = "cmbWarehouse"
        Me.cmbWarehouse.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbWarehouse.Properties.Items.AddRange(New Object() {"PICKING"})
        Me.cmbWarehouse.Size = New System.Drawing.Size(158, 20)
        Me.cmbWarehouse.TabIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(16, 64)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl3.TabIndex = 8
        Me.LabelControl3.Text = "Linea asignada:"
        '
        'lblMaterialName
        '
        Me.lblMaterialName.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaterialName.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblMaterialName.Appearance.Options.UseFont = True
        Me.lblMaterialName.Appearance.Options.UseForeColor = True
        Me.lblMaterialName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblMaterialName.Location = New System.Drawing.Point(16, 250)
        Me.lblMaterialName.Name = "lblMaterialName"
        Me.lblMaterialName.Size = New System.Drawing.Size(299, 15)
        Me.lblMaterialName.TabIndex = 10
        Me.lblMaterialName.Text = "..."
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(157, 362)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(158, 23)
        Me.SimpleButton1.TabIndex = 7
        Me.SimpleButton1.Text = "Salir"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.cmbLine)
        Me.GroupControl1.Controls.Add(Me.lblClientName)
        Me.GroupControl1.Controls.Add(Me.txtSAPClient)
        Me.GroupControl1.Controls.Add(Me.lblSAPClient)
        Me.GroupControl1.Controls.Add(Me.txtSAPDoc)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.lblWarehouse)
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Controls.Add(Me.btnAceptar)
        Me.GroupControl1.Controls.Add(Me.lblMaterialName)
        Me.GroupControl1.Controls.Add(Me.lblMaterial)
        Me.GroupControl1.Controls.Add(Me.txtMaterialID)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.cmbWarehouse)
        Me.GroupControl1.Controls.Add(Me.txtQty)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(362, 419)
        Me.GroupControl1.TabIndex = 12
        Me.GroupControl1.Text = "Informacion de la tarea"
        '
        'cmbLine
        '
        Me.cmbLine.EditValue = "..."
        Me.cmbLine.EnterMoveNextControl = True
        Me.cmbLine.Location = New System.Drawing.Point(157, 61)
        Me.cmbLine.Name = "cmbLine"
        Me.cmbLine.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbLine.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PICKING_LINE", "ID", 20, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None)})
        Me.cmbLine.Properties.DropDownRows = 12
        Me.cmbLine.Properties.HideSelection = False
        Me.cmbLine.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned
        Me.cmbLine.Size = New System.Drawing.Size(158, 20)
        Me.cmbLine.TabIndex = 1
        '
        'lblClientName
        '
        Me.lblClientName.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientName.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblClientName.Appearance.Options.UseFont = True
        Me.lblClientName.Appearance.Options.UseForeColor = True
        Me.lblClientName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblClientName.Location = New System.Drawing.Point(16, 173)
        Me.lblClientName.Name = "lblClientName"
        Me.lblClientName.Size = New System.Drawing.Size(299, 15)
        Me.lblClientName.TabIndex = 16
        Me.lblClientName.Text = "..."
        '
        'txtSAPClient
        '
        Me.txtSAPClient.EnterMoveNextControl = True
        Me.txtSAPClient.Location = New System.Drawing.Point(157, 147)
        Me.txtSAPClient.Name = "txtSAPClient"
        Me.txtSAPClient.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.txtSAPClient.Size = New System.Drawing.Size(158, 20)
        Me.txtSAPClient.TabIndex = 3
        '
        'lblSAPClient
        '
        Me.lblSAPClient.Location = New System.Drawing.Point(16, 150)
        Me.lblSAPClient.Name = "lblSAPClient"
        Me.lblSAPClient.Size = New System.Drawing.Size(80, 13)
        Me.lblSAPClient.TabIndex = 14
        Me.lblSAPClient.Text = "Cliente Asignado"
        '
        'txtSAPDoc
        '
        Me.txtSAPDoc.EnterMoveNextControl = True
        Me.txtSAPDoc.Location = New System.Drawing.Point(157, 119)
        Me.txtSAPDoc.Name = "txtSAPDoc"
        Me.txtSAPDoc.Size = New System.Drawing.Size(158, 20)
        Me.txtSAPDoc.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(16, 122)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl2.TabIndex = 12
        Me.LabelControl2.Text = "Documento SAP"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(16, 278)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Cantidad"
        '
        'txtQty
        '
        Me.txtQty.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtQty.EnterMoveNextControl = True
        Me.txtQty.Location = New System.Drawing.Point(157, 271)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.txtQty.Size = New System.Drawing.Size(100, 20)
        Me.txtQty.TabIndex = 5
        '
        'frmCreatePickingD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 419)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCreatePickingD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tareas: Picking Discrecional"
        CType(Me.txtMaterialID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbWarehouse.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.cmbLine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSAPClient.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSAPDoc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblMaterial As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMaterialID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lblWarehouse As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbWarehouse As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblMaterialName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtQty As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtSAPClient As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lblSAPClient As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSAPDoc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblClientName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbLine As DevExpress.XtraEditors.LookUpEdit
End Class
