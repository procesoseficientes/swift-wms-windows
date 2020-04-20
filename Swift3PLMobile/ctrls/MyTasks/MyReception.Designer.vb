<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MyReception
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
        Me.UiListaTareas = New Resco.Controls.AdvancedList.AdvancedList
        Me.TextCell1 = New Resco.Controls.AdvancedList.TextCell
        Me.ButtonCell1 = New Resco.Controls.AdvancedList.ButtonCell
        Me.TextCell2 = New Resco.Controls.AdvancedList.TextCell
        Me.TextCell4 = New Resco.Controls.AdvancedList.TextCell
        Me.TextCell3 = New Resco.Controls.AdvancedList.TextCell
        Me.TextCell5 = New Resco.Controls.AdvancedList.TextCell
        Me.TextCell6 = New Resco.Controls.AdvancedList.TextCell
        Me.TextCell7 = New Resco.Controls.AdvancedList.TextCell
        Me.Task = New Resco.Controls.AdvancedList.RowTemplate
        Me.SuspendLayout()
        '
        'UiListaTareas
        '
        Me.UiListaTareas.DataRows.Clear()
        Me.UiListaTareas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiListaTareas.GradientBackColor = New Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(71, Byte), Integer)), System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(132, Byte), Integer)), Resco.Controls.AdvancedList.FillDirection.Horizontal)
        Me.UiListaTareas.Location = New System.Drawing.Point(0, 0)
        Me.UiListaTareas.Name = "UiListaTareas"
        Me.UiListaTareas.Size = New System.Drawing.Size(240, 400)
        Me.UiListaTareas.TabIndex = 0
        Me.UiListaTareas.Templates.Add(Me.Task)
        '
        'TextCell1
        '
        Me.TextCell1.CellSource.ColumnName = "TAREA"
        Me.TextCell1.DesignName = "TextCell1"
        Me.TextCell1.ForeColor = System.Drawing.Color.White
        Me.TextCell1.FormatString = "Tarea: {0}"
        Me.TextCell1.Location = New System.Drawing.Point(1, 4)
        Me.TextCell1.Name = "TAREA"
        Me.TextCell1.Size = New System.Drawing.Size(162, 16)
        Me.TextCell1.TextFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        '
        'ButtonCell1
        '
        Me.ButtonCell1.ButtonStyle = Resco.Controls.AdvancedList.ButtonCell.ButtonType.VistaStyleImageButton
        Me.ButtonCell1.DesignName = "ButtonCell1"
        Me.ButtonCell1.Location = New System.Drawing.Point(166, 3)
        Me.ButtonCell1.Selectable = True
        Me.ButtonCell1.Size = New System.Drawing.Size(70, 38)
        Me.ButtonCell1.Text = "ACEPTAR"
        '
        'TextCell2
        '
        Me.TextCell2.CellSource.ColumnName = "CLIENT_CODE"
        Me.TextCell2.DesignName = "TextCell2"
        Me.TextCell2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TextCell2.Location = New System.Drawing.Point(0, 87)
        Me.TextCell2.Name = "CLIENT_CODE"
        Me.TextCell2.Size = New System.Drawing.Size(108, 29)
        Me.TextCell2.TextFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell4
        '
        Me.TextCell4.CellSource.ColumnName = "SUBTIPO"
        Me.TextCell4.DesignName = "TextCell4"
        Me.TextCell4.ForeColor = System.Drawing.Color.White
        Me.TextCell4.Location = New System.Drawing.Point(111, 88)
        Me.TextCell4.Name = "SUBTIPO"
        Me.TextCell4.Size = New System.Drawing.Size(129, 27)
        '
        'TextCell3
        '
        Me.TextCell3.CellSource.ColumnName = "POLIZA"
        Me.TextCell3.DesignName = "TextCell3"
        Me.TextCell3.ForeColor = System.Drawing.Color.White
        Me.TextCell3.FormatString = "Poliza: {0}"
        Me.TextCell3.Location = New System.Drawing.Point(2, 23)
        Me.TextCell3.Name = "POLIZA"
        Me.TextCell3.Size = New System.Drawing.Size(160, 17)
        '
        'TextCell5
        '
        Me.TextCell5.CellSource.ColumnName = "ORDEN"
        Me.TextCell5.DesignName = "TextCell5"
        Me.TextCell5.ForeColor = System.Drawing.Color.White
        Me.TextCell5.FormatString = "Orden: {0}"
        Me.TextCell5.Location = New System.Drawing.Point(1, 43)
        Me.TextCell5.Name = "ORDEN"
        Me.TextCell5.Size = New System.Drawing.Size(233, 20)
        '
        'TextCell6
        '
        Me.TextCell6.CellSource.ColumnName = "LOCATION_SPOT_TARGET"
        Me.TextCell6.DesignName = "TextCell6"
        Me.TextCell6.ForeColor = System.Drawing.Color.White
        Me.TextCell6.Location = New System.Drawing.Point(0, 65)
        Me.TextCell6.Name = "LOCATION_SPOT_TARGET"
        Me.TextCell6.Size = New System.Drawing.Size(108, 19)
        '
        'TextCell7
        '
        Me.TextCell7.CellSource.ColumnName = "PRIORITY"
        Me.TextCell7.DesignName = "TextCell7"
        Me.TextCell7.ForeColor = System.Drawing.Color.White
        Me.TextCell7.FormatString = "Prioridad: {0}"
        Me.TextCell7.Location = New System.Drawing.Point(111, 65)
        Me.TextCell7.Name = "PRIORITY"
        Me.TextCell7.Size = New System.Drawing.Size(129, 19)
        '
        'Task
        '
        Me.Task.BackColor = System.Drawing.Color.Transparent
        Me.Task.CellTemplates.Add(Me.TextCell1)
        Me.Task.CellTemplates.Add(Me.ButtonCell1)
        Me.Task.CellTemplates.Add(Me.TextCell2)
        Me.Task.CellTemplates.Add(Me.TextCell4)
        Me.Task.CellTemplates.Add(Me.TextCell3)
        Me.Task.CellTemplates.Add(Me.TextCell5)
        Me.Task.CellTemplates.Add(Me.TextCell6)
        Me.Task.CellTemplates.Add(Me.TextCell7)
        Me.Task.Height = 115
        Me.Task.Name = "Task"
        '
        'MyReception
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.UiListaTareas)
        Me.Name = "MyReception"
        Me.Size = New System.Drawing.Size(240, 400)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UiListaTareas As Resco.Controls.AdvancedList.AdvancedList
    Friend WithEvents Task As Resco.Controls.AdvancedList.RowTemplate
    Friend WithEvents TextCell1 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents ButtonCell1 As Resco.Controls.AdvancedList.ButtonCell
    Friend WithEvents TextCell2 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents TextCell4 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents TextCell3 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents TextCell5 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents TextCell6 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents TextCell7 As Resco.Controls.AdvancedList.TextCell

End Class
