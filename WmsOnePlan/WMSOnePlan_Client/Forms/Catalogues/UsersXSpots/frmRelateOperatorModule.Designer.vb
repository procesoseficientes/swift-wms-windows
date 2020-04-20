<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelateOperatorModule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRelateOperatorModule))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.cmbLocation = New DevExpress.XtraEditors.GridLookUpEdit
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbOperador = New DevExpress.XtraEditors.GridLookUpEdit
        Me.GridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton
        Me.GridColumn_Spot = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn_Linea = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn_ID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn_NAME = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.cmbLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOperador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.cmbLocation)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.cmbOperador)
        Me.PanelControl1.Controls.Add(Me.btnAceptar)
        Me.PanelControl1.Location = New System.Drawing.Point(12, 12)
        Me.PanelControl1.LookAndFeel.SkinName = "VS2010"
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(402, 180)
        Me.PanelControl1.TabIndex = 0
        '
        'cmbLocation
        '
        Me.cmbLocation.Location = New System.Drawing.Point(88, 83)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbLocation.Properties.View = Me.GridView1
        Me.cmbLocation.Size = New System.Drawing.Size(296, 20)
        Me.cmbLocation.TabIndex = 6
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn_Spot, Me.GridColumn_Linea})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 32)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Operador Disponible:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 32)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ubicacion Disponible:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'cmbOperador
        '
        Me.cmbOperador.Location = New System.Drawing.Point(88, 17)
        Me.cmbOperador.Name = "cmbOperador"
        Me.cmbOperador.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbOperador.Properties.View = Me.GridLookUpEdit1View
        Me.cmbOperador.Size = New System.Drawing.Size(296, 20)
        Me.cmbOperador.TabIndex = 1
        '
        'GridLookUpEdit1View
        '
        Me.GridLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn_ID, Me.GridColumn_NAME})
        Me.GridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridLookUpEdit1View.Name = "GridLookUpEdit1View"
        Me.GridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridLookUpEdit1View.OptionsView.ShowAutoFilterRow = True
        Me.GridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Location = New System.Drawing.Point(309, 139)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        '
        'GridColumn_Spot
        '
        Me.GridColumn_Spot.Caption = "Ubicacion"
        Me.GridColumn_Spot.FieldName = "LOCATION_SPOT"
        Me.GridColumn_Spot.Name = "GridColumn_Spot"
        Me.GridColumn_Spot.OptionsColumn.AllowEdit = False
        Me.GridColumn_Spot.OptionsColumn.FixedWidth = True
        Me.GridColumn_Spot.OptionsColumn.ReadOnly = True
        Me.GridColumn_Spot.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.GridColumn_Spot.Visible = True
        Me.GridColumn_Spot.VisibleIndex = 0
        '
        'GridColumn_Linea
        '
        Me.GridColumn_Linea.Caption = "Linea"
        Me.GridColumn_Linea.FieldName = "LINE_ID"
        Me.GridColumn_Linea.Name = "GridColumn_Linea"
        Me.GridColumn_Linea.OptionsColumn.AllowEdit = False
        Me.GridColumn_Linea.OptionsColumn.ReadOnly = True
        Me.GridColumn_Linea.Visible = True
        Me.GridColumn_Linea.VisibleIndex = 1
        '
        'GridColumn_ID
        '
        Me.GridColumn_ID.Caption = "Codigo"
        Me.GridColumn_ID.FieldName = "LOGIN_ID"
        Me.GridColumn_ID.Name = "GridColumn_ID"
        Me.GridColumn_ID.OptionsColumn.AllowEdit = False
        Me.GridColumn_ID.OptionsColumn.FixedWidth = True
        Me.GridColumn_ID.OptionsColumn.ReadOnly = True
        Me.GridColumn_ID.Visible = True
        Me.GridColumn_ID.VisibleIndex = 0
        '
        'GridColumn_NAME
        '
        Me.GridColumn_NAME.Caption = "Nombre"
        Me.GridColumn_NAME.FieldName = "LOGIN_NAME"
        Me.GridColumn_NAME.Name = "GridColumn_NAME"
        Me.GridColumn_NAME.OptionsColumn.AllowEdit = False
        Me.GridColumn_NAME.OptionsColumn.ReadOnly = True
        Me.GridColumn_NAME.Visible = True
        Me.GridColumn_NAME.VisibleIndex = 1
        '
        'frmRelateOperatorModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 210)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRelateOperatorModule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relacionar Operador - Modulo"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.cmbLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOperador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cmbOperador As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GridColumn_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbLocation As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn_Spot As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Linea As DevExpress.XtraGrid.Columns.GridColumn
End Class
