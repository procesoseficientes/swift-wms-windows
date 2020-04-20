<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_inv_x_lic
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.SmartGrid1 = New Resco.Controls.SmartGrid.SmartGrid
        Me.Column_MATERIAL_NAME = New Resco.Controls.SmartGrid.Column
        Me.Column_QTY = New Resco.Controls.SmartGrid.Column
        Me.SuspendLayout()
        '
        'SmartGrid1
        '
        Me.SmartGrid1.AllowColumnDrag = True
        Me.SmartGrid1.AutoSizeColumnsMode = Resco.Controls.SmartGrid.AutoSizeColumnsMode.ColumnHeader
        Me.SmartGrid1.AutoSizeRowsMode = Resco.Controls.SmartGrid.AutoSizeRowsMode.HeaderRow
        Me.SmartGrid1.ColumnHeaderHeight = 19
        Me.SmartGrid1.Columns.Add(Me.Column_MATERIAL_NAME)
        Me.SmartGrid1.Columns.Add(Me.Column_QTY)
        Me.SmartGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SmartGrid1.HeaderBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SmartGrid1.HeaderForeColor = System.Drawing.Color.Goldenrod
        Me.SmartGrid1.HeaderGridLineColor = System.Drawing.Color.DarkGray
        Me.SmartGrid1.HeaderVistaStyle = True
        Me.SmartGrid1.KeyNavigation = True
        Me.SmartGrid1.Location = New System.Drawing.Point(0, 0)
        Me.SmartGrid1.Name = "SmartGrid1"
        Me.SmartGrid1.RowHeadersVisible = True
        Me.SmartGrid1.RowHeight = 32
        Me.SmartGrid1.ScrollVFullPage = True
        Me.SmartGrid1.SelectionVistaStyle = True
        Me.SmartGrid1.ShowToolTips = True
        Me.SmartGrid1.Size = New System.Drawing.Size(240, 400)
        Me.SmartGrid1.TabIndex = 0
        Me.SmartGrid1.Text = "Inventario por licencia"
        Me.SmartGrid1.TouchScrolling = True
        '
        'Column_MATERIAL_NAME
        '
        Me.Column_MATERIAL_NAME.AutoSizeColumnMode = Resco.Controls.SmartGrid.AutoSizeColumnMode.Fill
        Me.Column_MATERIAL_NAME.CustomizeCells = True
        Me.Column_MATERIAL_NAME.DataMember = "MATERIAL_NAME"
        Me.Column_MATERIAL_NAME.HeaderText = "SKU"
        Me.Column_MATERIAL_NAME.Name = "Column_MATERIAL_NAME"
        Me.Column_MATERIAL_NAME.Width = 113
        '
        'Column_QTY
        '
        Me.Column_QTY.Alignment = Resco.Controls.SmartGrid.Alignment.TopRight
        Me.Column_QTY.AutoSizeColumnMode = Resco.Controls.SmartGrid.AutoSizeColumnMode.Fill
        Me.Column_QTY.DataMember = "QTY"
        Me.Column_QTY.HeaderText = "CANTIDAD"
        Me.Column_QTY.Name = "Column_QTY"
        Me.Column_QTY.Width = 113
        '
        'ctrl_inv_x_lic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.SmartGrid1)
        Me.Name = "ctrl_inv_x_lic"
        Me.Size = New System.Drawing.Size(240, 400)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SmartGrid1 As Resco.Controls.SmartGrid.SmartGrid
    Friend WithEvents Column_MATERIAL_NAME As Resco.Controls.SmartGrid.Column
    Friend WithEvents Column_QTY As Resco.Controls.SmartGrid.Column

End Class
