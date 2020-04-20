<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class myPicking
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
        Me.TipoVisualizacion = New Resco.Controls.AdvancedComboBox.AdvancedComboBox
        Me.AdvancedTree1 = New Resco.Controls.AdvancedTree.AdvancedTree
        Me.CELL_LOCATION_SPOT_SOURCE = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell12 = New Resco.Controls.AdvancedTree.TextCell
        Me.LocationNode = New Resco.Controls.AdvancedTree.NodeTemplate
        Me.TextCell3 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell4 = New Resco.Controls.AdvancedTree.TextCell
        Me.MaterialNode = New Resco.Controls.AdvancedTree.NodeTemplate
        Me.TextCell2 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell10 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell11 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell7 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell9 = New Resco.Controls.AdvancedTree.TextCell
        Me.ButtonCell1 = New Resco.Controls.AdvancedTree.ButtonCell
        Me.UiBotonCancelarLinea = New Resco.Controls.AdvancedTree.ButtonCell
        Me.TextCell1 = New Resco.Controls.AdvancedTree.TextCell
        Me.LicenseNode = New Resco.Controls.AdvancedTree.NodeTemplate
        Me.SuspendLayout()
        '
        'TipoVisualizacion
        '
        Me.TipoVisualizacion.AutoHideDropDownList = False
        Me.TipoVisualizacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.TipoVisualizacion.Items.Add(New Resco.Controls.AdvancedComboBox.ListItem(0, 0, -1, -1, Nothing, New String() {resources.GetString("TipoVisualizacion.Items")}))
        Me.TipoVisualizacion.Items.Add(New Resco.Controls.AdvancedComboBox.ListItem(0, 0, -1, -1, Nothing, New String() {resources.GetString("TipoVisualizacion.Items1")}))
        Me.TipoVisualizacion.Location = New System.Drawing.Point(0, 0)
        Me.TipoVisualizacion.Name = "TipoVisualizacion"
        Me.TipoVisualizacion.Size = New System.Drawing.Size(240, 24)
        Me.TipoVisualizacion.TabIndex = 0
        '
        'AdvancedTree1
        '
        Me.AdvancedTree1.AutoScroll = True
        Me.AdvancedTree1.BackColor = System.Drawing.Color.Transparent
        Me.AdvancedTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvancedTree1.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(71, Byte), Integer)), System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(132, Byte), Integer)), Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.AdvancedTree1.GridColor = System.Drawing.Color.Transparent
        Me.AdvancedTree1.KeyNavigation = True
        Me.AdvancedTree1.Location = New System.Drawing.Point(0, 24)
        Me.AdvancedTree1.MinusImage = CType(resources.GetObject("AdvancedTree1.MinusImage"), System.Drawing.Image)
        Me.AdvancedTree1.Name = "AdvancedTree1"
        Me.AdvancedTree1.PlusImage = CType(resources.GetObject("AdvancedTree1.PlusImage"), System.Drawing.Image)
        Me.AdvancedTree1.PlusMinusMargin = New System.Drawing.Size(4, 4)
        Me.AdvancedTree1.PlusMinusSize = New System.Drawing.Size(50, 50)
        Me.AdvancedTree1.ScrollbarSmallChange = 24
        Me.AdvancedTree1.ScrollbarWidth = 24
        Me.AdvancedTree1.SelectionMode = Resco.Controls.AdvancedTree.SelectionMode.SelectDeselect
        Me.AdvancedTree1.Size = New System.Drawing.Size(240, 376)
        Me.AdvancedTree1.TabIndex = 0
        Me.AdvancedTree1.Templates.Add(Me.LocationNode)
        Me.AdvancedTree1.Templates.Add(Me.MaterialNode)
        Me.AdvancedTree1.Templates.Add(Me.LicenseNode)
        Me.AdvancedTree1.TouchScrolling = True
        Me.AdvancedTree1.TouchSensitivity = 9
        Me.AdvancedTree1.TreeNodeLines = True
        Me.AdvancedTree1.UseGradient = True
        '
        'CELL_LOCATION_SPOT_SOURCE
        '
        Me.CELL_LOCATION_SPOT_SOURCE.CellSource.ColumnName = "LOCATION_SPOT_SOURCE"
        Me.CELL_LOCATION_SPOT_SOURCE.DesignName = "CELL_LOCATION_SPOT_SOURCE"
        Me.CELL_LOCATION_SPOT_SOURCE.ForeColor = System.Drawing.Color.White
        Me.CELL_LOCATION_SPOT_SOURCE.Location = New System.Drawing.Point(0, 0)
        Me.CELL_LOCATION_SPOT_SOURCE.Size = New System.Drawing.Size(251, 24)
        Me.CELL_LOCATION_SPOT_SOURCE.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell12
        '
        Me.TextCell12.CellSource.ColumnName = "PRIORITY_DESCRIPTION"
        Me.TextCell12.DesignName = "TextCell12"
        Me.TextCell12.Location = New System.Drawing.Point(253, 0)
        Me.TextCell12.Size = New System.Drawing.Size(348, 24)
        Me.TextCell12.TextFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'LocationNode
        '
        Me.LocationNode.BackColor = System.Drawing.Color.Transparent
        Me.LocationNode.CellTemplates.Add(Me.CELL_LOCATION_SPOT_SOURCE)
        Me.LocationNode.CellTemplates.Add(Me.TextCell12)
        Me.LocationNode.ForeColor = System.Drawing.Color.White
        Me.LocationNode.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.LocationNode.Height = 55
        Me.LocationNode.Name = "LocationNode"
        Me.LocationNode.UseTemplateBackground = True
        '
        'TextCell3
        '
        Me.TextCell3.CellSource.ColumnName = "MATERIAL_ID"
        Me.TextCell3.DesignName = "TextCell3"
        Me.TextCell3.ForeColor = System.Drawing.Color.White
        Me.TextCell3.Location = New System.Drawing.Point(0, 0)
        Me.TextCell3.Size = New System.Drawing.Size(-1, 30)
        Me.TextCell3.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        '
        'TextCell4
        '
        Me.TextCell4.CellSource.ColumnName = "MATERIAL_NAME"
        Me.TextCell4.DesignName = "TextCell4"
        Me.TextCell4.ForeColor = System.Drawing.Color.White
        Me.TextCell4.Location = New System.Drawing.Point(0, 30)
        Me.TextCell4.Size = New System.Drawing.Size(598, 30)
        Me.TextCell4.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'MaterialNode
        '
        Me.MaterialNode.BackColor = System.Drawing.Color.Transparent
        Me.MaterialNode.CellTemplates.Add(Me.TextCell3)
        Me.MaterialNode.CellTemplates.Add(Me.TextCell4)
        Me.MaterialNode.ForeColor = System.Drawing.Color.White
        Me.MaterialNode.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.MaterialNode.Height = 65
        Me.MaterialNode.Name = "MaterialNode"
        Me.MaterialNode.UseTemplateBackground = True
        '
        'TextCell2
        '
        Me.TextCell2.CellSource.ColumnName = "WAVE_PICKING_ID"
        Me.TextCell2.DesignName = "TextCell2"
        Me.TextCell2.ForeColor = System.Drawing.Color.White
        Me.TextCell2.FormatString = "Tarea: {0}"
        Me.TextCell2.Location = New System.Drawing.Point(0, 0)
        Me.TextCell2.Size = New System.Drawing.Size(150, 30)
        Me.TextCell2.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell10
        '
        Me.TextCell10.CellSource.ColumnName = "LOCATION_SPOT_TARGET"
        Me.TextCell10.DesignName = "TextCell10"
        Me.TextCell10.ForeColor = System.Drawing.Color.White
        Me.TextCell10.Location = New System.Drawing.Point(0, 60)
        Me.TextCell10.Size = New System.Drawing.Size(150, 30)
        Me.TextCell10.TextFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell11
        '
        Me.TextCell11.CellSource.ColumnName = "TYPE_DEMAND_NAME"
        Me.TextCell11.DesignName = "TextCell11"
        Me.TextCell11.ForeColor = System.Drawing.Color.White
        Me.TextCell11.Location = New System.Drawing.Point(150, 0)
        Me.TextCell11.Size = New System.Drawing.Size(150, 30)
        Me.TextCell11.TextFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell7
        '
        Me.TextCell7.CellSource.ColumnName = "LICENSE_ID_SOURCE"
        Me.TextCell7.DesignName = "TextCell7"
        Me.TextCell7.ForeColor = System.Drawing.Color.White
        Me.TextCell7.Location = New System.Drawing.Point(0, 30)
        Me.TextCell7.Size = New System.Drawing.Size(150, 30)
        Me.TextCell7.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell9
        '
        Me.TextCell9.CellSource.ColumnName = "QTY_AVAILABLE"
        Me.TextCell9.DesignName = "TextCell9"
        Me.TextCell9.ForeColor = System.Drawing.Color.White
        Me.TextCell9.Location = New System.Drawing.Point(150, 30)
        Me.TextCell9.Size = New System.Drawing.Size(150, 30)
        Me.TextCell9.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'ButtonCell1
        '
        Me.ButtonCell1.ButtonStyle = Resco.Controls.AdvancedTree.ButtonCell.ButtonType.VistaStyleImageButton
        Me.ButtonCell1.DesignName = "ButtonCell1"
        Me.ButtonCell1.Location = New System.Drawing.Point(2, 99)
        Me.ButtonCell1.Size = New System.Drawing.Size(118, 61)
        Me.ButtonCell1.Text = "OK"
        Me.ButtonCell1.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        '
        'UiBotonCancelarLinea
        '
        Me.UiBotonCancelarLinea.ButtonStyle = Resco.Controls.AdvancedTree.ButtonCell.ButtonType.VistaStyleImageButton
        Me.UiBotonCancelarLinea.DesignName = "UiBotonCancelarLinea"
        Me.UiBotonCancelarLinea.Location = New System.Drawing.Point(124, 99)
        Me.UiBotonCancelarLinea.Size = New System.Drawing.Size(128, 61)
        Me.UiBotonCancelarLinea.Text = "Finalizar"
        Me.UiBotonCancelarLinea.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        '
        'TextCell1
        '
        Me.TextCell1.CellSource.ColumnName = "TASK_SUBTYPE"
        Me.TextCell1.DesignName = "TextCell1"
        Me.TextCell1.ForeColor = System.Drawing.Color.White
        Me.TextCell1.Location = New System.Drawing.Point(150, 60)
        Me.TextCell1.Size = New System.Drawing.Size(150, 30)
        Me.TextCell1.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'LicenseNode
        '
        Me.LicenseNode.BackColor = System.Drawing.Color.Transparent
        Me.LicenseNode.CellTemplates.Add(Me.TextCell2)
        Me.LicenseNode.CellTemplates.Add(Me.TextCell10)
        Me.LicenseNode.CellTemplates.Add(Me.TextCell11)
        Me.LicenseNode.CellTemplates.Add(Me.TextCell7)
        Me.LicenseNode.CellTemplates.Add(Me.TextCell9)
        Me.LicenseNode.CellTemplates.Add(Me.ButtonCell1)
        Me.LicenseNode.CellTemplates.Add(Me.UiBotonCancelarLinea)
        Me.LicenseNode.CellTemplates.Add(Me.TextCell1)
        Me.LicenseNode.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.SystemColors.ControlLightLight, Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.LicenseNode.Height = 160
        Me.LicenseNode.Name = "LicenseNode"
        '
        'myPicking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Controls.Add(Me.AdvancedTree1)
        Me.Controls.Add(Me.TipoVisualizacion)
        Me.Name = "myPicking"
        Me.Size = New System.Drawing.Size(240, 400)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TipoVisualizacion As Resco.Controls.AdvancedComboBox.AdvancedComboBox
    Friend WithEvents AdvancedTree1 As Resco.Controls.AdvancedTree.AdvancedTree
    Friend WithEvents LocationNode As Resco.Controls.AdvancedTree.NodeTemplate
    Friend WithEvents CELL_LOCATION_SPOT_SOURCE As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell12 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents MaterialNode As Resco.Controls.AdvancedTree.NodeTemplate
    Friend WithEvents TextCell3 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell4 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents LicenseNode As Resco.Controls.AdvancedTree.NodeTemplate
    Friend WithEvents TextCell2 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell10 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell11 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell7 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell9 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents ButtonCell1 As Resco.Controls.AdvancedTree.ButtonCell
    Friend WithEvents UiBotonCancelarLinea As Resco.Controls.AdvancedTree.ButtonCell
    Friend WithEvents TextCell1 As Resco.Controls.AdvancedTree.TextCell

End Class
