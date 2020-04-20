<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAcuerdoXCliente
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
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbCliente = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridViewCliente = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnAgregar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnQuitarTodo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAgregarTodo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnQuitar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lstAcuerdoDisponible = New DevExpress.XtraEditors.ListBoxControl()
        Me.lstAcuerdoAsignado = New DevExpress.XtraEditors.ListBoxControl()
        CType(Me.cmbCliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstAcuerdoDisponible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstAcuerdoAsignado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl8.TabIndex = 8
        Me.LabelControl8.Text = "Cliente:"
        '
        'cmbCliente
        '
        Me.cmbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCliente.Location = New System.Drawing.Point(55, 9)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbCliente.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbCliente.Properties.NullText = ""
        Me.cmbCliente.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.cmbCliente.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cmbCliente.Properties.View = Me.GridViewCliente
        Me.cmbCliente.Size = New System.Drawing.Size(620, 20)
        Me.cmbCliente.TabIndex = 7
        '
        'GridViewCliente
        '
        Me.GridViewCliente.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridViewCliente.Name = "GridViewCliente"
        Me.GridViewCliente.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewCliente.OptionsView.ShowAutoFilterRow = True
        Me.GridViewCliente.OptionsView.ShowGroupPanel = False
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(318, 63)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(58, 23)
        Me.btnAgregar.TabIndex = 10
        Me.btnAgregar.Text = "<"
        '
        'btnQuitarTodo
        '
        Me.btnQuitarTodo.Location = New System.Drawing.Point(317, 150)
        Me.btnQuitarTodo.Name = "btnQuitarTodo"
        Me.btnQuitarTodo.Size = New System.Drawing.Size(58, 23)
        Me.btnQuitarTodo.TabIndex = 11
        Me.btnQuitarTodo.Text = ">>"
        '
        'btnAgregarTodo
        '
        Me.btnAgregarTodo.Location = New System.Drawing.Point(318, 121)
        Me.btnAgregarTodo.Name = "btnAgregarTodo"
        Me.btnAgregarTodo.Size = New System.Drawing.Size(58, 23)
        Me.btnAgregarTodo.TabIndex = 12
        Me.btnAgregarTodo.Text = "<<"
        '
        'btnQuitar
        '
        Me.btnQuitar.Location = New System.Drawing.Point(318, 92)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(58, 23)
        Me.btnQuitar.TabIndex = 13
        Me.btnQuitar.Text = ">"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 44)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(161, 13)
        Me.LabelControl1.TabIndex = 17
        Me.LabelControl1.Text = "Acuerdos Comerciales Asignados:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(382, 44)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(165, 13)
        Me.LabelControl2.TabIndex = 18
        Me.LabelControl2.Text = "Acuerdos Comerciales Disponibles:"
        '
        'lstAcuerdoDisponible
        '
        Me.lstAcuerdoDisponible.DisplayMember = "ACUERDO_COMERCIAL_NOMBRE"
        Me.lstAcuerdoDisponible.Location = New System.Drawing.Point(381, 66)
        Me.lstAcuerdoDisponible.Name = "lstAcuerdoDisponible"
        Me.lstAcuerdoDisponible.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstAcuerdoDisponible.Size = New System.Drawing.Size(294, 381)
        Me.lstAcuerdoDisponible.TabIndex = 20
        Me.lstAcuerdoDisponible.ValueMember = "ACUERDO_COMERCIAL_ID"
        '
        'lstAcuerdoAsignado
        '
        Me.lstAcuerdoAsignado.DisplayMember = "ACUERDO_COMERCIAL_NOMBRE"
        Me.lstAcuerdoAsignado.Location = New System.Drawing.Point(12, 63)
        Me.lstAcuerdoAsignado.Name = "lstAcuerdoAsignado"
        Me.lstAcuerdoAsignado.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstAcuerdoAsignado.Size = New System.Drawing.Size(294, 381)
        Me.lstAcuerdoAsignado.TabIndex = 21
        Me.lstAcuerdoAsignado.ValueMember = "ACUERDO_COMERCIAL_ID"
        '
        'FrmAcuerdoXCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 459)
        Me.Controls.Add(Me.lstAcuerdoAsignado)
        Me.Controls.Add(Me.lstAcuerdoDisponible)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnAgregarTodo)
        Me.Controls.Add(Me.btnQuitarTodo)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.cmbCliente)
        Me.Name = "FrmAcuerdoXCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acuerdos Por Cliente"
        CType(Me.cmbCliente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstAcuerdoDisponible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstAcuerdoAsignado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbCliente As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridViewCliente As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnAgregar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnQuitarTodo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAgregarTodo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnQuitar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lstAcuerdoDisponible As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents lstAcuerdoAsignado As DevExpress.XtraEditors.ListBoxControl
End Class
