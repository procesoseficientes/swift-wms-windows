<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class myCounting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(myCounting))
        Me.AdvancedTree1 = New Resco.Controls.AdvancedTree.AdvancedTree
        Me.NodeTemplate1 = New Resco.Controls.AdvancedTree.NodeTemplate
        Me.TextCell1 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell2 = New Resco.Controls.AdvancedTree.TextCell
        Me.NodeTemplate2 = New Resco.Controls.AdvancedTree.NodeTemplate
        Me.TextCell3 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell4 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell5 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell8 = New Resco.Controls.AdvancedTree.TextCell
        Me.ButtonCell1 = New Resco.Controls.AdvancedTree.ButtonCell
        Me.NodeTemplate3 = New Resco.Controls.AdvancedTree.NodeTemplate
        Me.TextCell6 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell7 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell9 = New Resco.Controls.AdvancedTree.TextCell
        Me.SuspendLayout()
        '
        'AdvancedTree1
        '
        Me.AdvancedTree1.AutoScroll = True
        Me.AdvancedTree1.BackgroundImage = CType(resources.GetObject("AdvancedTree1.BackgroundImage"), System.Drawing.Image)
        Me.AdvancedTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvancedTree1.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.AdvancedTree1.KeyNavigation = True
        Me.AdvancedTree1.Location = New System.Drawing.Point(0, 0)
        Me.AdvancedTree1.MinusImage = CType(resources.GetObject("AdvancedTree1.MinusImage"), System.Drawing.Image)
        Me.AdvancedTree1.Name = "AdvancedTree1"
        Me.AdvancedTree1.PlusImage = CType(resources.GetObject("AdvancedTree1.PlusImage"), System.Drawing.Image)
        Me.AdvancedTree1.PlusMinusMargin = New System.Drawing.Size(4, 4)
        Me.AdvancedTree1.PlusMinusSize = New System.Drawing.Size(32, 32)
        Me.AdvancedTree1.ScrollbarSmallChange = 24
        Me.AdvancedTree1.ScrollbarWidth = 24
        Me.AdvancedTree1.SelectionMode = Resco.Controls.AdvancedTree.SelectionMode.SelectDeselect
        Me.AdvancedTree1.Size = New System.Drawing.Size(240, 400)
        Me.AdvancedTree1.TabIndex = 1
        Me.AdvancedTree1.Templates.Add(Me.NodeTemplate1)
        Me.AdvancedTree1.Templates.Add(Me.NodeTemplate2)
        Me.AdvancedTree1.Templates.Add(Me.NodeTemplate3)
        Me.AdvancedTree1.TouchScrolling = True
        Me.AdvancedTree1.TouchSensitivity = 9
        Me.AdvancedTree1.TreeNodeLines = True
        '
        'NodeTemplate1
        '
        Me.NodeTemplate1.BackColor = System.Drawing.Color.Transparent
        Me.NodeTemplate1.CellTemplates.Add(Me.TextCell1)
        Me.NodeTemplate1.CellTemplates.Add(Me.TextCell2)
        Me.NodeTemplate1.ForeColor = System.Drawing.Color.White
        Me.NodeTemplate1.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.SystemColors.ControlLightLight, Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.NodeTemplate1.Height = 48
        Me.NodeTemplate1.Name = "NodeTemplate1"
        Me.NodeTemplate1.UseTemplateBackground = True
        '
        'TextCell1
        '
        Me.TextCell1.CellSource.ColumnName = "WAVE_PICKING_ID"
        Me.TextCell1.DesignName = "TextCell1"
        Me.TextCell1.ForeColor = System.Drawing.Color.White
        Me.TextCell1.Location = New System.Drawing.Point(0, 0)
        Me.TextCell1.Size = New System.Drawing.Size(50, 48)
        Me.TextCell1.TextFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell2
        '
        Me.TextCell2.CellSource.ColumnName = "TASK_COMMENTS"
        Me.TextCell2.DesignName = "TextCell2"
        Me.TextCell2.ForeColor = System.Drawing.Color.White
        Me.TextCell2.Location = New System.Drawing.Point(52, 0)
        Me.TextCell2.Size = New System.Drawing.Size(-1, 48)
        Me.TextCell2.TextFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular)
        '
        'NodeTemplate2
        '
        Me.NodeTemplate2.BackColor = System.Drawing.Color.Transparent
        Me.NodeTemplate2.CellTemplates.Add(Me.TextCell3)
        Me.NodeTemplate2.CellTemplates.Add(Me.TextCell4)
        Me.NodeTemplate2.CellTemplates.Add(Me.TextCell5)
        Me.NodeTemplate2.CellTemplates.Add(Me.TextCell8)
        Me.NodeTemplate2.CellTemplates.Add(Me.ButtonCell1)
        Me.NodeTemplate2.ForeColor = System.Drawing.Color.White
        Me.NodeTemplate2.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.SystemColors.ControlLightLight, Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.NodeTemplate2.Height = 72
        Me.NodeTemplate2.Name = "NodeTemplate2"
        Me.NodeTemplate2.UseTemplateBackground = True
        '
        'TextCell3
        '
        Me.TextCell3.CellSource.ColumnName = "BARCODE_ID"
        Me.TextCell3.DesignName = "TextCell3"
        Me.TextCell3.ForeColor = System.Drawing.Color.White
        Me.TextCell3.Location = New System.Drawing.Point(0, 0)
        Me.TextCell3.Size = New System.Drawing.Size(-1, 24)
        Me.TextCell3.TextFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        '
        'TextCell4
        '
        Me.TextCell4.CellSource.ColumnName = "MATERIAL_NAME"
        Me.TextCell4.DesignName = "TextCell4"
        Me.TextCell4.ForeColor = System.Drawing.Color.White
        Me.TextCell4.Location = New System.Drawing.Point(0, 25)
        Me.TextCell4.Size = New System.Drawing.Size(-1, 24)
        Me.TextCell4.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell5
        '
        Me.TextCell5.CellSource.ColumnName = "QUANTITY_PENDING"
        Me.TextCell5.DesignName = "TextCell5"
        Me.TextCell5.Location = New System.Drawing.Point(0, 50)
        Me.TextCell5.Size = New System.Drawing.Size(50, 24)
        Me.TextCell5.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell8
        '
        Me.TextCell8.CellSource.ColumnName = "CODIGO_POLIZA_SOURCE"
        Me.TextCell8.DesignName = "TextCell8"
        Me.TextCell8.Location = New System.Drawing.Point(240, 0)
        Me.TextCell8.Size = New System.Drawing.Size(5, 72)
        Me.TextCell8.Visible = False
        '
        'ButtonCell1
        '
        Me.ButtonCell1.ButtonStyle = Resco.Controls.AdvancedTree.ButtonCell.ButtonType.VistaStyleImageButton
        Me.ButtonCell1.DesignName = "ButtonCell1"
        Me.ButtonCell1.Location = New System.Drawing.Point(195, 0)
        Me.ButtonCell1.Size = New System.Drawing.Size(50, 70)
        Me.ButtonCell1.Text = "OK"
        Me.ButtonCell1.TextFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        '
        'NodeTemplate3
        '
        Me.NodeTemplate3.BackColor = System.Drawing.Color.Transparent
        Me.NodeTemplate3.CellTemplates.Add(Me.TextCell6)
        Me.NodeTemplate3.CellTemplates.Add(Me.TextCell7)
        Me.NodeTemplate3.CellTemplates.Add(Me.TextCell9)
        Me.NodeTemplate3.ForeColor = System.Drawing.Color.White
        Me.NodeTemplate3.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.SystemColors.ControlLightLight, Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.NodeTemplate3.Height = 24
        Me.NodeTemplate3.Name = "NodeTemplate3"
        Me.NodeTemplate3.UseTemplateBackground = True
        '
        'TextCell6
        '
        Me.TextCell6.Border = Resco.Controls.AdvancedTree.BorderType.Raised
        Me.TextCell6.CellSource.ColumnName = "LOCATION_SPOT_SOURCE"
        Me.TextCell6.DesignName = "TextCell6"
        Me.TextCell6.ForeColor = System.Drawing.Color.White
        Me.TextCell6.Location = New System.Drawing.Point(0, 0)
        Me.TextCell6.Size = New System.Drawing.Size(130, 24)
        Me.TextCell6.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell7
        '
        Me.TextCell7.Border = Resco.Controls.AdvancedTree.BorderType.Raised
        Me.TextCell7.CellSource.ColumnName = "LICENSE_ID_SOURCE"
        Me.TextCell7.DesignName = "TextCell7"
        Me.TextCell7.ForeColor = System.Drawing.Color.White
        Me.TextCell7.Location = New System.Drawing.Point(132, 0)
        Me.TextCell7.Size = New System.Drawing.Size(40, 24)
        Me.TextCell7.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell9
        '
        Me.TextCell9.Border = Resco.Controls.AdvancedTree.BorderType.Raised
        Me.TextCell9.CellSource.ColumnName = "QTY_AVAILABLE"
        Me.TextCell9.DesignName = "TextCell9"
        Me.TextCell9.ForeColor = System.Drawing.Color.White
        Me.TextCell9.Location = New System.Drawing.Point(173, 0)
        Me.TextCell9.Size = New System.Drawing.Size(-1, 24)
        Me.TextCell9.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'myCounting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Controls.Add(Me.AdvancedTree1)
        Me.Name = "myCounting"
        Me.Size = New System.Drawing.Size(240, 400)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AdvancedTree1 As Resco.Controls.AdvancedTree.AdvancedTree
    Friend WithEvents NodeTemplate1 As Resco.Controls.AdvancedTree.NodeTemplate
    Friend WithEvents TextCell1 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell2 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents NodeTemplate2 As Resco.Controls.AdvancedTree.NodeTemplate
    Friend WithEvents TextCell3 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell4 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell5 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell8 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents ButtonCell1 As Resco.Controls.AdvancedTree.ButtonCell
    Friend WithEvents NodeTemplate3 As Resco.Controls.AdvancedTree.NodeTemplate
    Friend WithEvents TextCell6 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell7 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell9 As Resco.Controls.AdvancedTree.TextCell

End Class
