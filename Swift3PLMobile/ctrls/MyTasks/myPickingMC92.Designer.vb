<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class myPickingMC92
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(myPicking))
        Me.AdvancedTree1 = New Resco.Controls.AdvancedTree.AdvancedTree
        Me.TextCell1 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell2 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell10 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell11 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell12 = New Resco.Controls.AdvancedTree.TextCell
        Me.NodeTemplate1 = New Resco.Controls.AdvancedTree.NodeTemplate
        Me.TextCell3 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell4 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell5 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell8 = New Resco.Controls.AdvancedTree.TextCell
        Me.ButtonCell1 = New Resco.Controls.AdvancedTree.ButtonCell
        Me.UiBotonCancelarLinea = New Resco.Controls.AdvancedTree.ButtonCell
        Me.LOCATION_SPOT_TARGET = New Resco.Controls.AdvancedTree.TextCell
        Me.NodeTemplate2 = New Resco.Controls.AdvancedTree.NodeTemplate
        Me.TextCell6 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell7 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell9 = New Resco.Controls.AdvancedTree.TextCell
        Me.NodeTemplate3 = New Resco.Controls.AdvancedTree.NodeTemplate
        Me.SuspendLayout()
        '
        'AdvancedTree1
        '
        Me.AdvancedTree1.AutoScroll = True
        Me.AdvancedTree1.BackColor = System.Drawing.Color.Transparent
        Me.AdvancedTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvancedTree1.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(71, Byte), Integer)), System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(132, Byte), Integer)), Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.AdvancedTree1.GridColor = System.Drawing.Color.Transparent
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
        Me.AdvancedTree1.TabIndex = 0
        Me.AdvancedTree1.Templates.Add(Me.NodeTemplate1)
        Me.AdvancedTree1.Templates.Add(Me.NodeTemplate2)
        Me.AdvancedTree1.Templates.Add(Me.NodeTemplate3)
        Me.AdvancedTree1.TouchScrolling = True
        Me.AdvancedTree1.TouchSensitivity = 9
        Me.AdvancedTree1.TreeNodeLines = True
        Me.AdvancedTree1.UseGradient = True
        '
        'TextCell1
        '
        Me.TextCell1.CellSource.ColumnName = "WAVE_PICKING_ID"
        Me.TextCell1.DesignName = "TextCell1"
        Me.TextCell1.ForeColor = System.Drawing.Color.White
        Me.TextCell1.Location = New System.Drawing.Point(0, 0)
        Me.TextCell1.Size = New System.Drawing.Size(53, 24)
        Me.TextCell1.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell2
        '
        Me.TextCell2.CellSource.ColumnName = "TASK_COMMENTS"
        Me.TextCell2.DesignName = "TextCell2"
        Me.TextCell2.ForeColor = System.Drawing.Color.White
        Me.TextCell2.Location = New System.Drawing.Point(53, 0)
        Me.TextCell2.Size = New System.Drawing.Size(-1, 24)
        Me.TextCell2.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell10
        '
        Me.TextCell10.CellSource.ColumnName = "LOCATION_SPOT_TARGET"
        Me.TextCell10.DesignName = "TextCell10"
        Me.TextCell10.Location = New System.Drawing.Point(0, 25)
        Me.TextCell10.Size = New System.Drawing.Size(-1, 24)
        '
        'TextCell11
        '
        Me.TextCell11.CellSource.ColumnName = "TYPE_DEMAND_NAME"
        Me.TextCell11.DesignName = "TextCell11"
        Me.TextCell11.Location = New System.Drawing.Point(100, 49)
        Me.TextCell11.Size = New System.Drawing.Size(-1, 24)
        '
        'TextCell12
        '
        Me.TextCell12.CellSource.ColumnName = "PRIORITY_DESCRIPTION"
        Me.TextCell12.DesignName = "TextCell12"
        Me.TextCell12.Location = New System.Drawing.Point(0, 49)
        Me.TextCell12.Size = New System.Drawing.Size(100, 24)
        '
        'NodeTemplate1
        '
        Me.NodeTemplate1.BackColor = System.Drawing.Color.Transparent
        Me.NodeTemplate1.CellTemplates.Add(Me.TextCell1)
        Me.NodeTemplate1.CellTemplates.Add(Me.TextCell2)
        Me.NodeTemplate1.CellTemplates.Add(Me.TextCell10)
        Me.NodeTemplate1.CellTemplates.Add(Me.TextCell11)
        Me.NodeTemplate1.CellTemplates.Add(Me.TextCell12)
        Me.NodeTemplate1.ForeColor = System.Drawing.Color.White
        Me.NodeTemplate1.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.NodeTemplate1.Height = 75
        Me.NodeTemplate1.Name = "NodeTemplate1"
        Me.NodeTemplate1.UseTemplateBackground = True
        '
        'TextCell3
        '
        Me.TextCell3.CellSource.ColumnName = "MATERIAL_ID"
        Me.TextCell3.DesignName = "TextCell3"
        Me.TextCell3.ForeColor = System.Drawing.Color.White
        Me.TextCell3.Location = New System.Drawing.Point(0, 0)
        Me.TextCell3.Size = New System.Drawing.Size(-1, 24)
        Me.TextCell3.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        '
        'TextCell4
        '
        Me.TextCell4.CellSource.ColumnName = "MATERIAL_NAME"
        Me.TextCell4.DesignName = "TextCell4"
        Me.TextCell4.ForeColor = System.Drawing.Color.White
        Me.TextCell4.Location = New System.Drawing.Point(0, 25)
        Me.TextCell4.Size = New System.Drawing.Size(199, 24)
        Me.TextCell4.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell5
        '
        Me.TextCell5.CellSource.ColumnName = "QUANTITY_PENDING"
        Me.TextCell5.DesignName = "TextCell5"
        Me.TextCell5.Location = New System.Drawing.Point(0, 50)
        Me.TextCell5.Size = New System.Drawing.Size(55, 24)
        Me.TextCell5.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        '
        'TextCell8
        '
        Me.TextCell8.CellSource.ColumnName = "CODIGO_POLIZA_SOURCE"
        Me.TextCell8.DesignName = "TextCell8"
        Me.TextCell8.Location = New System.Drawing.Point(78, 50)
        Me.TextCell8.Size = New System.Drawing.Size(69, 25)
        Me.TextCell8.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        Me.TextCell8.Visible = False
        '
        'ButtonCell1
        '
        Me.ButtonCell1.ButtonStyle = Resco.Controls.AdvancedTree.ButtonCell.ButtonType.VistaStyleImageButton
        Me.ButtonCell1.DesignName = "ButtonCell1"
        Me.ButtonCell1.Location = New System.Drawing.Point(9, 83)
        Me.ButtonCell1.Size = New System.Drawing.Size(69, 40)
        Me.ButtonCell1.Text = "OK"
        Me.ButtonCell1.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        '
        'UiBotonCancelarLinea
        '
        Me.UiBotonCancelarLinea.ButtonStyle = Resco.Controls.AdvancedTree.ButtonCell.ButtonType.VistaStyleImageButton
        Me.UiBotonCancelarLinea.DesignName = "UiBotonCancelarLinea"
        Me.UiBotonCancelarLinea.Location = New System.Drawing.Point(94, 82)
        Me.UiBotonCancelarLinea.Size = New System.Drawing.Size(70, 41)
        Me.UiBotonCancelarLinea.Text = "Finalizar"
        Me.UiBotonCancelarLinea.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        '
        'LOCATION_SPOT_TARGET
        '
        Me.LOCATION_SPOT_TARGET.CellSource.ColumnName = "LOCATION_SPOT_TARGET"
        Me.LOCATION_SPOT_TARGET.DesignName = "LOCATION_SPOT_TARGET"
        Me.LOCATION_SPOT_TARGET.Location = New System.Drawing.Point(56, 50)
        Me.LOCATION_SPOT_TARGET.Size = New System.Drawing.Size(103, 25)
        Me.LOCATION_SPOT_TARGET.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'NodeTemplate2
        '
        Me.NodeTemplate2.BackColor = System.Drawing.Color.Transparent
        Me.NodeTemplate2.CellTemplates.Add(Me.TextCell3)
        Me.NodeTemplate2.CellTemplates.Add(Me.TextCell4)
        Me.NodeTemplate2.CellTemplates.Add(Me.TextCell5)
        Me.NodeTemplate2.CellTemplates.Add(Me.TextCell8)
        Me.NodeTemplate2.CellTemplates.Add(Me.ButtonCell1)
        Me.NodeTemplate2.CellTemplates.Add(Me.UiBotonCancelarLinea)
        Me.NodeTemplate2.CellTemplates.Add(Me.LOCATION_SPOT_TARGET)
        Me.NodeTemplate2.ForeColor = System.Drawing.Color.White
        Me.NodeTemplate2.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.NodeTemplate2.Height = 125
        Me.NodeTemplate2.Name = "NodeTemplate2"
        Me.NodeTemplate2.UseTemplateBackground = True
        '
        'TextCell6
        '
        Me.TextCell6.Border = Resco.Controls.AdvancedTree.BorderType.Raised
        Me.TextCell6.CellSource.ColumnName = "LOCATION_SPOT_SOURCE"
        Me.TextCell6.DesignName = "TextCell6"
        Me.TextCell6.ForeColor = System.Drawing.Color.White
        Me.TextCell6.Location = New System.Drawing.Point(0, 0)
        Me.TextCell6.Size = New System.Drawing.Size(-1, 21)
        Me.TextCell6.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell7
        '
        Me.TextCell7.Border = Resco.Controls.AdvancedTree.BorderType.Raised
        Me.TextCell7.CellSource.ColumnName = "LICENSE_ID_SOURCE"
        Me.TextCell7.DesignName = "TextCell7"
        Me.TextCell7.ForeColor = System.Drawing.Color.White
        Me.TextCell7.Location = New System.Drawing.Point(0, 21)
        Me.TextCell7.Size = New System.Drawing.Size(75, 21)
        Me.TextCell7.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell9
        '
        Me.TextCell9.Border = Resco.Controls.AdvancedTree.BorderType.Raised
        Me.TextCell9.CellSource.ColumnName = "QTY_AVAILABLE"
        Me.TextCell9.DesignName = "TextCell9"
        Me.TextCell9.ForeColor = System.Drawing.Color.White
        Me.TextCell9.Location = New System.Drawing.Point(75, 21)
        Me.TextCell9.Size = New System.Drawing.Size(-1, 21)
        Me.TextCell9.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'NodeTemplate3
        '
        Me.NodeTemplate3.BackColor = System.Drawing.Color.Transparent
        Me.NodeTemplate3.CellTemplates.Add(Me.TextCell6)
        Me.NodeTemplate3.CellTemplates.Add(Me.TextCell7)
        Me.NodeTemplate3.CellTemplates.Add(Me.TextCell9)
        Me.NodeTemplate3.ForeColor = System.Drawing.Color.White
        Me.NodeTemplate3.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.NodeTemplate3.Height = 42
        Me.NodeTemplate3.Name = "NodeTemplate3"
        Me.NodeTemplate3.UseTemplateBackground = True
        '
        'myPicking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Controls.Add(Me.AdvancedTree1)
        Me.Name = "myPicking"
        Me.Size = New System.Drawing.Size(240, 400)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AdvancedTree1 As Resco.Controls.AdvancedTree.AdvancedTree
    Friend WithEvents NodeTemplate1 As Resco.Controls.AdvancedTree.NodeTemplate
    Friend WithEvents TextCell1 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell2 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell10 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell11 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell12 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents NodeTemplate2 As Resco.Controls.AdvancedTree.NodeTemplate
    Friend WithEvents TextCell3 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell4 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell5 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell8 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents ButtonCell1 As Resco.Controls.AdvancedTree.ButtonCell
    Friend WithEvents UiBotonCancelarLinea As Resco.Controls.AdvancedTree.ButtonCell
    Friend WithEvents LOCATION_SPOT_TARGET As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents NodeTemplate3 As Resco.Controls.AdvancedTree.NodeTemplate
    Friend WithEvents TextCell6 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell7 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell9 As Resco.Controls.AdvancedTree.TextCell

End Class
