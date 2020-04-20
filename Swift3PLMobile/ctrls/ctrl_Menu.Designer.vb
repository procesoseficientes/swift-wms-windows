<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_Menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrl_Menu))
        Me.AdvancedList1 = New Resco.Controls.AdvancedList.AdvancedList
        Me.RowTemplate1 = New Resco.Controls.AdvancedList.RowTemplate
        Me.TextCell4 = New Resco.Controls.AdvancedList.TextCell
        Me.TextCell2 = New Resco.Controls.AdvancedList.TextCell
        Me.TextCell6 = New Resco.Controls.AdvancedList.TextCell
        Me.TextCell8 = New Resco.Controls.AdvancedList.TextCell
        Me.RowTemplate2 = New Resco.Controls.AdvancedList.RowTemplate
        Me.TextCell5 = New Resco.Controls.AdvancedList.TextCell
        Me.TextCell3 = New Resco.Controls.AdvancedList.TextCell
        Me.TextCell7 = New Resco.Controls.AdvancedList.TextCell
        Me.TextCell9 = New Resco.Controls.AdvancedList.TextCell
        Me.ImageList1 = New System.Windows.Forms.ImageList
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.SuspendLayout()
        '
        'AdvancedList1
        '
        Me.AdvancedList1.ActiveTemplateIndex = 0
        Me.AdvancedList1.AlternateTemplateIndex = 2
        Me.AdvancedList1.BackColor = System.Drawing.Color.Transparent
        Me.AdvancedList1.DataRows.Clear()
        Me.AdvancedList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvancedList1.EnableHTCGyroSensor = True
        Me.AdvancedList1.EnableHTCNavSensor = True
        Me.AdvancedList1.FocusOnClick = True
        Me.AdvancedList1.GradientBackColor = New Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(71, Byte), Integer)), System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(132, Byte), Integer)), Resco.Controls.AdvancedList.FillDirection.Horizontal)
        Me.AdvancedList1.GridColor = System.Drawing.Color.DimGray
        Me.AdvancedList1.GyroSensorNavigation = True
        Me.AdvancedList1.HeaderRow = New Resco.Controls.AdvancedList.HeaderRow(2, New String(-1) {})
        Me.AdvancedList1.KeyNavigation = True
        Me.AdvancedList1.Location = New System.Drawing.Point(0, 0)
        Me.AdvancedList1.Name = "AdvancedList1"
        Me.AdvancedList1.NavSensorNavigation = True
        Me.AdvancedList1.SelectedTemplateIndex = 2
        Me.AdvancedList1.ShowHeader = True
        Me.AdvancedList1.ShowScrollbar = False
        Me.AdvancedList1.Size = New System.Drawing.Size(250, 400)
        Me.AdvancedList1.TabIndex = 1
        Me.AdvancedList1.Templates.Add(Me.RowTemplate1)
        Me.AdvancedList1.Templates.Add(Me.RowTemplate2)
        Me.AdvancedList1.TouchScrolling = True
        Me.AdvancedList1.TouchSensitivity = 20
        '
        'RowTemplate1
        '
        Me.RowTemplate1.BackColor = System.Drawing.Color.Transparent
        Me.RowTemplate1.CellTemplates.Add(Me.TextCell4)
        Me.RowTemplate1.CellTemplates.Add(Me.TextCell2)
        Me.RowTemplate1.CellTemplates.Add(Me.TextCell6)
        Me.RowTemplate1.CellTemplates.Add(Me.TextCell8)
        Me.RowTemplate1.ForeColor = System.Drawing.Color.Black
        Me.RowTemplate1.Height = 50
        Me.RowTemplate1.Name = "RowTemplate1"
        '
        'TextCell4
        '
        Me.TextCell4.CellSource.ColumnName = "OPTION_ID"
        Me.TextCell4.DesignName = "TextCell4"
        Me.TextCell4.Location = New System.Drawing.Point(0, 32)
        Me.TextCell4.Size = New System.Drawing.Size(-1, 32)
        Me.TextCell4.Visible = False
        '
        'TextCell2
        '
        Me.TextCell2.Alignment = Resco.Controls.AdvancedList.Alignment.MiddleLeft
        Me.TextCell2.AutoHeight = True
        Me.TextCell2.CellSource.ColumnName = "OPTION_DESC"
        Me.TextCell2.DesignName = "TextCell2"
        Me.TextCell2.ForeColor = System.Drawing.Color.White
        Me.TextCell2.Location = New System.Drawing.Point(5, 0)
        Me.TextCell2.Size = New System.Drawing.Size(-1, 32)
        Me.TextCell2.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell6
        '
        Me.TextCell6.CellSource.ColumnName = "OPTION_PANEL"
        Me.TextCell6.DesignName = "TextCell6"
        Me.TextCell6.Location = New System.Drawing.Point(0, 32)
        Me.TextCell6.Size = New System.Drawing.Size(-1, 32)
        Me.TextCell6.Visible = False
        '
        'TextCell8
        '
        Me.TextCell8.CellSource.ColumnName = "OPTION_TRANS_TYPE"
        Me.TextCell8.DesignName = "TextCell8"
        Me.TextCell8.Location = New System.Drawing.Point(0, 64)
        Me.TextCell8.Size = New System.Drawing.Size(-1, 32)
        Me.TextCell8.Visible = False
        '
        'RowTemplate2
        '
        Me.RowTemplate2.BackColor = System.Drawing.Color.Transparent
        Me.RowTemplate2.CellTemplates.Add(Me.TextCell5)
        Me.RowTemplate2.CellTemplates.Add(Me.TextCell3)
        Me.RowTemplate2.CellTemplates.Add(Me.TextCell7)
        Me.RowTemplate2.CellTemplates.Add(Me.TextCell9)
        Me.RowTemplate2.ForeColor = System.Drawing.Color.Black
        Me.RowTemplate2.GradientBackColor = New Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, Resco.Controls.AdvancedList.FillDirection.Vertical)
        Me.RowTemplate2.Height = 50
        Me.RowTemplate2.Name = "RowTemplate2"
        '
        'TextCell5
        '
        Me.TextCell5.CellSource.ColumnName = "OPTION_ID"
        Me.TextCell5.DesignName = "TextCell5"
        Me.TextCell5.Location = New System.Drawing.Point(0, 32)
        Me.TextCell5.Size = New System.Drawing.Size(-1, 32)
        Me.TextCell5.Visible = False
        '
        'TextCell3
        '
        Me.TextCell3.Alignment = Resco.Controls.AdvancedList.Alignment.BottomLeft
        Me.TextCell3.CellSource.ColumnName = "OPTION_DESC"
        Me.TextCell3.CustomizeCell = True
        Me.TextCell3.DesignName = "TextCell3"
        Me.TextCell3.ForeColor = System.Drawing.Color.Orange
        Me.TextCell3.Location = New System.Drawing.Point(5, 0)
        Me.TextCell3.SelectedForeColor = System.Drawing.Color.Orange
        Me.TextCell3.Size = New System.Drawing.Size(-1, 32)
        Me.TextCell3.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell7
        '
        Me.TextCell7.CellSource.ColumnName = "OPTION_PANEL"
        Me.TextCell7.DesignName = "TextCell7"
        Me.TextCell7.Location = New System.Drawing.Point(0, 32)
        Me.TextCell7.Size = New System.Drawing.Size(-1, 32)
        Me.TextCell7.Visible = False
        '
        'TextCell9
        '
        Me.TextCell9.CellSource.ColumnName = "OPTION_TRANS_TYPE"
        Me.TextCell9.DesignName = "TextCell9"
        Me.TextCell9.Location = New System.Drawing.Point(0, 64)
        Me.TextCell9.Size = New System.Drawing.Size(-1, 32)
        Me.TextCell9.Visible = False
        Me.ImageList1.Images.Clear()
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource1"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource2"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource3"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource4"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource5"), System.Drawing.Icon))
        '
        'Timer1
        '
        '
        'ctrl_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.AdvancedList1)
        Me.Name = "ctrl_Menu"
        Me.Size = New System.Drawing.Size(250, 400)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AdvancedList1 As Resco.Controls.AdvancedList.AdvancedList
    Friend WithEvents RowTemplate1 As Resco.Controls.AdvancedList.RowTemplate
    Friend WithEvents TextCell2 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents RowTemplate2 As Resco.Controls.AdvancedList.RowTemplate
    Friend WithEvents TextCell3 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents TextCell4 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents TextCell5 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents TextCell6 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents TextCell7 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TextCell8 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents TextCell9 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

End Class
